using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace L4D2ServerManager
{
    public class ServerInfo
    {
        public string Name { get; set; }
        public string Map { get; set; }
        public int Players { get; set; }
        public int MaxPlayers { get; set; }
        public long Ping { get; set; }
    }

    public class ServerScanner
    {
        // Gói tin chuẩn A2S_INFO của Source Engine
        private readonly byte[] A2S_INFO_REQUEST = { 0xFF, 0xFF, 0xFF, 0xFF, 0x54, 0x53, 0x6F, 0x75, 0x72, 0x63, 0x65, 0x20, 0x45, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x20, 0x51, 0x75, 0x65, 0x72, 0x79, 0x00 };

        public async Task<ServerInfo> PingServerAsync(string ip, int port)
        {
            using (UdpClient client = new UdpClient())
            {
                client.Client.SendTimeout = 2000;
                client.Client.ReceiveTimeout = 2000;

                try
                {
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                    var watch = System.Diagnostics.Stopwatch.StartNew();
                    await client.SendAsync(A2S_INFO_REQUEST, A2S_INFO_REQUEST.Length, endPoint);

                    var receiveResult = await client.ReceiveAsync();
                    watch.Stop();

                    byte[] data = receiveResult.Buffer;

                    // Phân tích byte trả về (bỏ qua header)
                    int offset = 5; // Bỏ qua 4 byte 0xFF và byte protocol
                    string name = ReadNullTerminatedString(data, ref offset);
                    string map = ReadNullTerminatedString(data, ref offset);
                    string folder = ReadNullTerminatedString(data, ref offset);
                    string game = ReadNullTerminatedString(data, ref offset);

                    offset += 2; // Bỏ qua AppID
                    int players = data[offset++];
                    int maxPlayers = data[offset++];

                    return new ServerInfo
                    {
                        Name = name,
                        Map = map,
                        Players = players,
                        MaxPlayers = maxPlayers,
                        Ping = watch.ElapsedMilliseconds
                    };
                }
                catch
                {
                    return null; // Server offline hoặc không phản hồi
                }
            }
        }

        private string ReadNullTerminatedString(byte[] data, ref int offset)
        {
            int start = offset;
            while (data[offset] != 0x00) offset++;
            string result = Encoding.UTF8.GetString(data, start, offset - start);
            offset++; // Bỏ qua byte null
            return result;
        }

        public bool IsVietNamServer(ServerInfo info)
        {
            if (info == null) return false;
            string lowerName = info.Name.ToLower();
            return lowerName.Contains("[vn]") || lowerName.Contains("viet nam") || lowerName.Contains("việt nam");
        }
    }
}