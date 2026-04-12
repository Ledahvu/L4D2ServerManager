using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace L4D2ServerManager
{
    // Cập nhật class này để DataGridView tự động nhận diện thay đổi
    public class ServerInstance : INotifyPropertyChanged
    {
        private string status;
        private int processId;

        public string Name { get; set; }
        public int Port { get; set; }

        public int ProcessId
        {
            get => processId;
            set { processId = value; OnPropertyChanged(nameof(ProcessId)); }
        }

        public string Status
        {
            get => status;
            set { status = value; OnPropertyChanged(nameof(Status)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class InstanceManager
    {
        public BindingList<ServerInstance> Instances { get; } = new BindingList<ServerInstance>();
        private SynchronizationContext syncContext;

        public InstanceManager(string defaultPath = "")
        {
            // Bắt lấy luồng giao diện (UI Thread) để cập nhật bảng mượt mà
            syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
        }

        // HÀM MỚI: Đồng bộ hóa toàn bộ danh sách Profile lên Bảng
        public void SyncWithProfiles(System.Collections.Generic.List<ServerProfile> profiles)
        {
            // Lọc và xóa những profile bị xóa
            var toRemove = Instances.Where(i => !profiles.Any(p => p.Name == i.Name)).ToList();
            foreach (var item in toRemove) Instances.Remove(item);

            // Thêm tất cả các Profile hiện có (Mặc định là Stopped)
            foreach (var p in profiles)
            {
                if (!Instances.Any(i => i.Name == p.Name))
                {
                    Instances.Add(new ServerInstance { Name = p.Name, Port = p.Port, Status = "🛑 Stopped", ProcessId = 0 });
                }
                else
                {
                    // Cập nhật lại Port nếu có thay đổi
                    var existing = Instances.First(i => i.Name == p.Name);
                    existing.Port = p.Port;
                }
            }
        }

        public void StartInstance(string name, string exePath, int port, string mapName, int maxPlayers, bool useConsole, string difficulty, string gameMode, Action<string> log)
        {
            // Lấy dòng hiển thị trên bảng của Profile này
            var instance = Instances.FirstOrDefault(i => i.Name == name);
            if (instance == null) return;

            try
            {
                string serverDir = Path.GetDirectoryName(exePath);
                string appidPath = Path.Combine(serverDir, "steam_appid.txt");
                if (File.Exists(appidPath)) File.Delete(appidPath);

                string args = $"-game left4dead2 +port {port} +map \"{mapName}\" +maxplayers {maxPlayers} +z_difficulty \"{difficulty}\" +mp_gamemode \"{gameMode}\"";
                if (useConsole) args = "-console " + args;

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = args,
                    WorkingDirectory = serverDir,
                    UseShellExecute = true
                };

                // ĐÃ NÂNG CẤP: Gắn cờ theo dõi khi Process tắt
                Process process = new Process { StartInfo = startInfo, EnableRaisingEvents = true };

                // Sự kiện này sẽ tự động bắn ra khi bạn nhấp dấu X đóng màn hình console
                process.Exited += (sender, e) =>
                {
                    syncContext.Post(_ =>
                    {
                        instance.Status = "🛑 Stopped";
                        instance.ProcessId = 0;
                        log?.Invoke($"⏹ Máy chủ [{instance.Name}] đã được đóng lại.");
                    }, null);
                };

                process.Start();

                // Cập nhật trạng thái hiển thị
                instance.ProcessId = process.Id;
                instance.Status = useConsole ? "▶ Running (Console)" : "▶ Running (GUI)";
                log?.Invoke($"✅ Server [{name}] đang chạy Map [{mapName}] | Chế độ: {gameMode} | Độ khó: {difficulty}");
            }
            catch (Exception ex)
            {
                log?.Invoke($"❌ Lỗi Start: {ex.Message}");
            }
        }

        public void StopInstance(string name)
        {
            var instance = Instances.FirstOrDefault(i => i.Name == name);
            if (instance != null && instance.ProcessId != 0)
            {
                try { Process.GetProcessById(instance.ProcessId).Kill(); } catch { }
                // Không cần gán Status bằng tay ở đây, vì lệnh Kill() sẽ kích hoạt hàm process.Exited ở bên trên tự xử lý!
            }
        }
    }
}