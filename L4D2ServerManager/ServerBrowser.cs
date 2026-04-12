using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace L4D2ServerManager
{
    public enum ServerRegion : byte
    {
        USEast = 0, USWest = 1, SouthAmerica = 2, Europe = 3,
        Asia = 4, Australia = 5, MiddleEast = 6, Africa = 7, World = 255
    }

    public class BrowserServerInfo
    {
        public int STT { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string Players { get; set; }
        public long Ping { get; set; }
        public string Endpoint { get; set; }
    }

    public class ServerBrowser
    {
        private readonly string apiKey;
        private static Dictionary<string, string> ipCountryCache = new Dictionary<string, string>();

        public ServerBrowser(string steamApiKey)
        {
            apiKey = steamApiKey;
        }

        public async Task ScanServersAsync(ServerRegion region, Action<BrowserServerInfo> onServerFound, Action<string> log)
        {
            if (string.IsNullOrEmpty(apiKey) || apiKey == "DÁN_API_KEY_CỦA_BẠN_VÀO_ĐÂY")
            {
                log?.Invoke("❌ Lỗi: Bạn chưa nhập Steam API Key vào Code!");
                return;
            }

            string regionFilter = region == ServerRegion.World ? "" : $"\\region\\{(int)region}";
            string url = $"https://api.steampowered.com/IGameServersService/GetServerList/v1/?key={apiKey}&filter=\\appid\\550{regionFilter}&limit=10000";

            log?.Invoke("1. Đang kéo TOÀN BỘ dữ liệu từ máy chủ Valve...");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(20);
                    string jsonResponse = await client.GetStringAsync(url);

                    MatchCollection matches = Regex.Matches(jsonResponse, @"\{(.*?)\}");
                    var tempList = new List<BrowserServerInfo>();

                    foreach (Match m in matches)
                    {
                        string block = m.Value;
                        string endpoint = Regex.Match(block, @"""addr"":""(.*?)""").Groups[1].Value;
                        string name = Regex.Match(block, @"""name"":""(.*?)""").Groups[1].Value;
                        string map = Regex.Match(block, @"""map"":""(.*?)""").Groups[1].Value;
                        string players = Regex.Match(block, @"""players"":(\d+)").Groups[1].Value;
                        string maxPlayers = Regex.Match(block, @"""max_players"":(\d+)").Groups[1].Value;

                        if (!string.IsNullOrEmpty(endpoint) && !string.IsNullOrEmpty(name))
                        {
                            name = Regex.Unescape(name);
                            tempList.Add(new BrowserServerInfo
                            {
                                STT = 0, // Sẽ đánh số lại sau khi sắp xếp
                                Country = GuessCountryFromName(name),
                                Name = name,
                                Map = map,
                                Players = $"{players}/{maxPlayers}",
                                Ping = 999,
                                Endpoint = endpoint
                            });
                        }
                    }

                    log?.Invoke($"2. Tìm thấy {tempList.Count} Server. Đang quét quốc gia (Có thể tốn vài giây để quét hết)...");
                    await ResolveCountriesAsync(tempList, client);

                    log?.Invoke($"3. Đang đo Ping (Giới hạn luồng để không làm treo mạng)...");

                    // GIẢI PHÁP MẠNG: Chỉ chạy 30 luồng Ping cùng lúc để Router/Modem không bị sập mạng gây Ping 999
                    Parallel.ForEach(tempList, new ParallelOptions { MaxDegreeOfParallelism = 30 }, server =>
                    {
                        try
                        {
                            string ip = server.Endpoint.Split(':')[0];
                            if (string.IsNullOrEmpty(server.Country))
                            {
                                server.Country = ipCountryCache.ContainsKey(ip) ? GetCountryFlag(ipCountryCache[ip]) : "🌍 Khác";
                            }

                            using (Ping pinger = new Ping())
                            {
                                PingReply reply = pinger.Send(ip, 1000);
                                if (reply.Status == IPStatus.Success) server.Ping = reply.RoundtripTime;
                            }
                        }
                        catch { }

                        onServerFound?.Invoke(server);
                    });

                    log?.Invoke($"✅ HOÀN TẤT! Đã quét xong toàn bộ {tempList.Count} Server.");
                }
            }
            catch (Exception ex)
            {
                log?.Invoke($"❌ Lỗi: {ex.Message}");
            }
        }

        private async Task ResolveCountriesAsync(List<BrowserServerInfo> servers, HttpClient client)
        {
            var ipsToResolve = servers.Where(s => string.IsNullOrEmpty(s.Country))
                                      .Select(s => s.Endpoint.Split(':')[0])
                                      .Distinct()
                                      .Where(ip => !ipCountryCache.ContainsKey(ip))
                                      .ToList();

            for (int i = 0; i < ipsToResolve.Count; i += 100)
            {
                var batch = ipsToResolve.Skip(i).Take(100).ToList();
                string jsonArray = "[" + string.Join(",", batch.Select(ip => $"\"{ip}\"")) + "]";

                try
                {
                    var content = new StringContent(jsonArray, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://ip-api.com/batch?fields=query,country", content);
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    MatchCollection matches = Regex.Matches(jsonResponse, @"\""query\"":\""(.*?)\"".*?\""country\"":\""(.*?)\""");
                    foreach (Match m in matches) ipCountryCache[m.Groups[1].Value] = m.Groups[2].Value;
                }
                catch { }
                await Task.Delay(1500); // Tránh bị IP-API khóa vì request quá nhanh
            }
        }

        private string GuessCountryFromName(string name)
        {
            name = name.ToLower();
            if (name.Contains("[vn]") || name.Contains("vietnam") || name.Contains("việt nam") || name.Contains("viet nam") || name.Contains(" vn ")) return "🇻🇳 Việt Nam";
            if (name.Contains("[sg]") || name.Contains("singapore")) return "🇸🇬 Singapore";
            if (name.Contains("[cn]") || name.Contains("china") || name.Contains("beijing") || name.Contains("shanghai")) return "🇨🇳 Trung Quốc";
            if (name.Contains("[jp]") || name.Contains("japan") || name.Contains("tokyo")) return "🇯🇵 Nhật Bản";
            if (name.Contains("[tw]") || name.Contains("taiwan")) return "🇹🇼 Đài Loan";
            if (name.Contains("[kr]") || name.Contains("korea") || name.Contains("seoul")) return "🇰🇷 Hàn Quốc";
            if (name.Contains("[hk]") || name.Contains("hong kong") || name.Contains("hongkong")) return "🇭🇰 Hong Kong";
            if (name.Contains("[th]") || name.Contains("thai") || name.Contains("bangkok")) return "🇹🇭 Thái Lan";
            if (name.Contains("[us]") || name.Contains("usa") || name.Contains("america")) return "🇺🇸 Mỹ";
            if (name.Contains("[ru]") || name.Contains("russia") || name.Contains("moscow")) return "🇷🇺 Nga";
            if (name.Contains("[my]") || name.Contains("malaysia")) return "🇲🇾 Malaysia";
            if (name.Contains("[id]") || name.Contains("indonesia") || name.Contains("indo ")) return "🇮🇩 Indonesia";
            if (name.Contains("[ph]") || name.Contains("philippine") || name.Contains("pinoy")) return "🇵🇭 Philippines";
            if (name.Contains("[au]") || name.Contains("australia") || name.Contains("sydney")) return "🇦🇺 Úc";
            return null;
        }

        private string GetCountryFlag(string countryName)
        {
            switch (countryName.ToLower())
            {
                case "vietnam": return "🇻🇳 Việt Nam";
                case "singapore": return "🇸🇬 Singapore";
                case "china": return "🇨🇳 China";
                case "japan": return "🇯🇵 Japan";
                case "taiwan": return "🇹🇼 Taiwan";
                case "south korea": return "🇰🇷 South Korea";
                case "hong kong": return "🇭🇰 Hong Kong";
                case "thailand": return "🇹🇭 Thailand";
                case "united states": return "🇺🇸 USA";
                case "russia": return "🇷🇺 Russia";
                case "malaysia": return "🇲🇾 Malaysia";
                case "indonesia": return "🇮🇩 Indonesia";
                case "philippines": return "🇵🇭 Philippines";
                case "australia": return "🇦🇺 Australia";
                default: return $"🌍 {countryName}";
            }
        }
    }
}