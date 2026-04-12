using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace L4D2ServerManager
{
    public class WorkshopManager
    {
        public string BaseDirectory { get; set; }
        private string SteamCmdPath => Path.Combine(Application.StartupPath, @"SteamCMD\steamcmd.exe");
        private string HlExtractPath => Path.Combine(Application.StartupPath, @"HLExtract\HLExtract.exe");

        public void SetupTools()
        {
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "SteamCMD"));
            Directory.CreateDirectory(Path.Combine(Application.StartupPath, "HLExtract"));

            string localHlExtract = Path.Combine(Application.StartupPath, "HLExtract.exe");
            string localHlLib = Path.Combine(Application.StartupPath, "HLLib.dll");
            if (File.Exists(localHlExtract) && !File.Exists(HlExtractPath))
            {
                File.Copy(localHlExtract, HlExtractPath, true);
                if (File.Exists(localHlLib)) File.Copy(localHlLib, Path.Combine(Application.StartupPath, @"HLExtract\HLLib.dll"), true);
            }
        }

        private void ExtractZipToDirectory(string zipPath, string destDir, Action<string> log)
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string safeName = entry.FullName.Replace('/', Path.DirectorySeparatorChar);
                        string fullPath = Path.Combine(destDir, safeName);

                        if (string.IsNullOrEmpty(entry.Name) || safeName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                            Directory.CreateDirectory(fullPath);
                        else
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                            entry.ExtractToFile(fullPath, true);
                        }
                    }
                }
            }
            catch (Exception ex) { log?.Invoke($"❌ Lỗi giải nén: {ex.Message}"); }
        }

        private async Task<string> GetLatestAlliedModsUrl(string baseUrl, string filePrefix, Action<string> log)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/120.0.0.0");
                    string fileName = await client.GetStringAsync(baseUrl + filePrefix + "-latest-windows");
                    return baseUrl + fileName.Trim();
                }
            }
            catch (Exception ex) { log($"❌ Lỗi lấy link tự động từ {baseUrl}: {ex.Message}"); return null; }
        }

        public async Task EnsureSteamCmdAsync(Action<string> log, Action<int> progress)
        {
            if (!File.Exists(SteamCmdPath))
            {
                log("⚠️ Đang tự động tải SteamCMD..."); progress?.Invoke(10);
                string zipPath = Path.Combine(Application.StartupPath, @"SteamCMD\steamcmd.zip");
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                    byte[] fileBytes = await client.GetByteArrayAsync("https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip");
                    File.WriteAllBytes(zipPath, fileBytes);
                }
                progress?.Invoke(50);
                ExtractZipToDirectory(zipPath, Path.GetDirectoryName(SteamCmdPath), log);
                File.Delete(zipPath);
                progress?.Invoke(100);
            }
        }

        public async Task InstallOrVerifyServerAsync(string installDir, bool isVerify, Action<string> log, Action<int> progress)
        {
            await EnsureSteamCmdAsync(log, progress);
            progress?.Invoke(20);
            log(isVerify ? "🛠 Đang gọi SteamCMD Verify máy chủ..." : "⏬ Đang gọi SteamCMD tải/cập nhật dữ liệu L4D2...");
            await Task.Run(() =>
            {
                string validateFlag = isVerify ? "validate" : "";
                ProcessStartInfo startInfo = new ProcessStartInfo { FileName = SteamCmdPath, Arguments = $"+force_install_dir \"{installDir}\" +login anonymous +app_update 222860 {validateFlag} +quit", UseShellExecute = false, CreateNoWindow = true };
                using (Process process = Process.Start(startInfo)) process.WaitForExit();
            });
            progress?.Invoke(100);
        }

        public async Task InstallModsAndExtensionsAsync(string profilePath, string mmBranch, string smBranch, string l4dToolzUrl, Action<string> log, Action<int> progress)
        {
            string l4d2Dir = Path.Combine(profilePath, "left4dead2");
            string addonsDir = Path.Combine(l4d2Dir, "addons");
            Directory.CreateDirectory(addonsDir);

            bool hasError = false;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/120.0.0.0");

                if (!string.IsNullOrEmpty(mmBranch))
                {
                    log($"🔍 Đang tìm link MetaMod mới nhất nhánh {mmBranch}..."); progress?.Invoke(10);
                    string mmUrl = await GetLatestAlliedModsUrl($"https://mms.alliedmods.net/mmsdrop/{mmBranch}/", "mmsource", log);
                    if (!string.IsNullOrEmpty(mmUrl))
                    {
                        try
                        {
                            log($"⏬ Đang tải MetaMod: {Path.GetFileName(mmUrl)}...");
                            string mmsZip = Path.Combine(l4d2Dir, "mms.zip");
                            File.WriteAllBytes(mmsZip, await client.GetByteArrayAsync(mmUrl));
                            ExtractZipToDirectory(mmsZip, l4d2Dir, log);
                            File.Delete(mmsZip);
                            File.WriteAllText(Path.Combine(addonsDir, "metamod.vdf"), "\"Plugin\"\n{\n\t\"file\"\t\"../left4dead2/addons/metamod/bin/server\"\n}");
                            log("✅ Cài đặt MetaMod thành công.");
                        }
                        catch (Exception ex) { log($"❌ Lỗi tải MetaMod: {ex.Message}"); hasError = true; }
                    }
                    else hasError = true;
                }

                if (!string.IsNullOrEmpty(smBranch))
                {
                    log($"🔍 Đang tìm link SourceMod mới nhất nhánh {smBranch}..."); progress?.Invoke(40);
                    string smUrl = await GetLatestAlliedModsUrl($"https://sm.alliedmods.net/smdrop/{smBranch}/", "sourcemod", log);
                    if (!string.IsNullOrEmpty(smUrl))
                    {
                        try
                        {
                            log($"⏬ Đang tải SourceMod: {Path.GetFileName(smUrl)}...");
                            string smZip = Path.Combine(l4d2Dir, "sm.zip");
                            File.WriteAllBytes(smZip, await client.GetByteArrayAsync(smUrl));
                            ExtractZipToDirectory(smZip, l4d2Dir, log);
                            File.Delete(smZip);
                            log("✅ Cài đặt SourceMod thành công.");
                        }
                        catch (Exception ex) { log($"❌ Lỗi tải SourceMod: {ex.Message}"); hasError = true; }
                    }
                    else hasError = true;
                }

                if (!string.IsNullOrEmpty(l4dToolzUrl))
                {
                    log($"⏬ Đang tải L4DToolZ Extension từ GitHub..."); progress?.Invoke(70);
                    try
                    {
                        string toolzZipPath = Path.Combine(l4d2Dir, "l4dtoolz.zip");
                        File.WriteAllBytes(toolzZipPath, await client.GetByteArrayAsync(l4dToolzUrl));

                        log("📦 Sắp xếp và đưa file L4DToolZ vào đúng thư mục...");
                        string l4dToolzDir = Path.Combine(addonsDir, "l4dtoolz");
                        string metaModDir = Path.Combine(addonsDir, "metamod");
                        Directory.CreateDirectory(l4dToolzDir);
                        Directory.CreateDirectory(metaModDir);

                        using (ZipArchive archive = ZipFile.OpenRead(toolzZipPath))
                        {
                            foreach (var entry in archive.Entries)
                            {
                                if (entry.FullName.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
                                    entry.ExtractToFile(Path.Combine(l4dToolzDir, entry.Name), true);
                                else if (entry.FullName.EndsWith(".so", StringComparison.OrdinalIgnoreCase))
                                    entry.ExtractToFile(Path.Combine(l4dToolzDir, entry.Name), true);
                            }
                        }
                        File.Delete(toolzZipPath);

                        log("⚙️ Tạo file kích hoạt addons/metamod/l4dtoolz.vdf...");
                        string vdfPath = Path.Combine(metaModDir, "l4dtoolz.vdf");
                        File.WriteAllText(vdfPath, "\"Metamod Plugin\"\n{\n\t\"alias\"\t\"l4dtoolz\"\n\t\"file\"\t\"addons/l4dtoolz/l4dtoolz\"\n}");

                        log("✅ Cài đặt L4DToolZ thành công!");
                    }
                    catch (Exception ex) { log($"❌ Lỗi cài L4DToolZ: {ex.Message}"); hasError = true; }
                }

                progress?.Invoke(100);
                log(hasError ? "\n⚠️ QUÁ TRÌNH CÀI ĐẶT CÓ LỖI XẢY RA!" : "\n✅ HOÀN TẤT CÀI ĐẶT BỘ 3 QUẢN LÝ (MetaMod + SourceMod + L4DToolZ)!");
            }
        }

        // ==========================================
        // CẬP NHẬT: HÀM LẤY TÊN THẬT CỦA MAP TỪ STEAM API
        // ==========================================
        private async Task<string> GetWorkshopTitleAsync(string workshopId, Action<string> log)
        {
            if (string.IsNullOrEmpty(workshopId) || workshopId.StartsWith("MANUAL")) return "Custom Map (Cài tay)";
            try
            {
                log?.Invoke($"🌐 Gọi API Steam để nhận dạng tên Map ID: {workshopId}...");
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[] {
                        new KeyValuePair<string, string>("itemcount", "1"),
                        new KeyValuePair<string, string>("publishedfileids[0]", workshopId)
                    });
                    var response = await client.PostAsync("https://api.steampowered.com/ISteamRemoteStorage/GetPublishedFileDetails/v1/", content);
                    string json = await response.Content.ReadAsStringAsync();

                    // Tìm trường "title" trong JSON trả về
                    Match m = Regex.Match(json, @"""title"":""(.*?)""");
                    if (m.Success)
                    {
                        return Regex.Unescape(m.Groups[1].Value); // Khử mã hóa Unicode
                    }
                }
            }
            catch { }
            return $"Workshop Map ({workshopId})";
        }

        private async Task<string> DownloadMapHttpFallbackAsync(string workshopId, Action<string> log)
        {
            try
            {
                log?.Invoke($"🌐 Đang tải file VPK dự phòng qua HTTP (ID: {workshopId})...");
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("itemcount", "1"), new KeyValuePair<string, string>("publishedfileids[0]", workshopId) });
                    var response = await client.PostAsync("https://api.steampowered.com/ISteamRemoteStorage/GetPublishedFileDetails/v1/", content);
                    string json = await response.Content.ReadAsStringAsync();
                    string fileUrl = Regex.Match(json, @"""file_url"":""(.*?)""").Groups[1].Value.Replace("\\/", "/");
                    if (string.IsNullOrEmpty(fileUrl)) return null;
                    string tempDir = Path.Combine(Path.GetTempPath(), $"HTTP_{workshopId}"); Directory.CreateDirectory(tempDir);
                    string savePath = Path.Combine(tempDir, $"{workshopId}.vpk");
                    File.WriteAllBytes(savePath, await client.GetByteArrayAsync(fileUrl));
                    return savePath;
                }
            }
            catch { return null; }
        }

        public string GetWorkshopId(string url) { Match m = Regex.Match(url, @"\?id=(\d+)"); return m.Success ? m.Groups[1].Value : null; }

        public async Task DownloadMapAsync(string workshopId, Action<string> log, Action<int> progress)
        {
            await EnsureSteamCmdAsync(log, progress);
            log($"⏬ Đang tải Map Workshop ID: {workshopId}...");
            await Task.Run(() => {
                ProcessStartInfo si = new ProcessStartInfo { FileName = SteamCmdPath, Arguments = $"+login anonymous +workshop_download_item 550 {workshopId} +quit", UseShellExecute = false, CreateNoWindow = true };
                using (Process p = Process.Start(si)) p.WaitForExit();
            });
            progress?.Invoke(100);
        }

        public async Task InstallManualVpkAsync(string sourceVpkPath, ServerProfile profile, ProfileManager profileManager, Action<string> log)
        {
            log?.Invoke("📦 Bắt đầu cài đặt VPK thủ công...");
            string fakeId = "MANUAL_" + Guid.NewGuid().ToString().Substring(0, 6);
            await ProcessAndSaveVpkAsync(sourceVpkPath, fakeId, profile, profileManager, log);
        }

        public async Task InstallVpkToProfileAsync(string workshopId, ServerProfile profile, ProfileManager profileManager, Action<string> log)
        {
            log?.Invoke($"🔍 Kiểm tra file VPK cho Map {workshopId}...");
            if (!File.Exists(HlExtractPath)) throw new Exception("Thiếu HLExtract.exe!");
            string workshopDir = Path.Combine(Path.GetDirectoryName(SteamCmdPath), $@"steamapps\workshop\content\550\{workshopId}");
            string vpkPath = null;
            if (Directory.Exists(workshopDir))
            {
                string[] files = Directory.GetFiles(workshopDir, "*.vpk");
                if (files.Length > 0) vpkPath = files[0];
            }
            if (string.IsNullOrEmpty(vpkPath) || !File.Exists(vpkPath))
            {
                vpkPath = await DownloadMapHttpFallbackAsync(workshopId, log);
                if (string.IsNullOrEmpty(vpkPath)) throw new Exception("Lỗi tải Map.");
            }
            await ProcessAndSaveVpkAsync(vpkPath, workshopId, profile, profileManager, log);
        }

        private async Task ProcessAndSaveVpkAsync(string vpkPath, string workshopId, ServerProfile profile, ProfileManager profileManager, Action<string> log)
        {

            // CẬP NHẬT: Lấy tên thật của Map trước khi lưu
            string realWorkshopTitle = await GetWorkshopTitleAsync(workshopId, log);

            log?.Invoke("⚙️ Đang xử lý bóc tách tên file .bsp bên trong...");
            await Task.Run(() => {
                var mapRecord = new MapRecord { WorkshopId = workshopId };
                ProcessStartInfo si = new ProcessStartInfo { FileName = HlExtractPath, Arguments = $"-p \"{vpkPath}\" -l", UseShellExecute = false, RedirectStandardOutput = true, CreateNoWindow = true };
                using (Process p = Process.Start(si))
                {
                    string output = p.StandardOutput.ReadToEnd(); p.WaitForExit();
                    var ms = Regex.Matches(output, @"([^\\\/\n\r]+)\.bsp", RegexOptions.IgnoreCase);
                    foreach (Match m in ms) { if (!mapRecord.BspNames.Contains(m.Groups[1].Value)) mapRecord.BspNames.Add(m.Groups[1].Value); }
                }
                string addonsDir = Path.Combine(profile.InstallPath, "left4dead2", "addons"); Directory.CreateDirectory(addonsDir);
                string destName = $"{workshopId}_{Guid.NewGuid().ToString().Substring(0, 5)}.vpk";
                File.Copy(vpkPath, Path.Combine(addonsDir, destName), true);
                mapRecord.VpkFileName = destName;

                // GÁN TÊN THẬT CHO DISPLAY NAME
                mapRecord.DisplayName = realWorkshopTitle;

                profile.MapRecords.Add(mapRecord); profileManager.SaveProfiles();
            });
        }
    }
}