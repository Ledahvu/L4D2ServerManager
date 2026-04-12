using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace L4D2ServerManager
{
    public class MapRecord
    {
        public string WorkshopId { get; set; }
        public string DisplayName { get; set; }
        public string VpkFileName { get; set; } // Tên file VPK của bản mới
        public List<string> BspNames { get; set; } = new List<string>();

        // Phục hồi lại biến ExtractedFiles để tool nhận diện và dọn sạch rác của bản cũ
        public List<string> ExtractedFiles { get; set; } = new List<string>();
    }

    public class ServerProfile
    {
        public string Name { get; set; }
        public string InstallPath { get; set; }
        public int Port { get; set; }
        public List<MapRecord> MapRecords { get; set; } = new List<MapRecord>();
    }

    public class ProfileManager
    {
        private string profilesFile;
        public List<ServerProfile> Profiles { get; private set; } = new List<ServerProfile>();

        public void Initialize(string baseDirectory)
        {
            if (!Directory.Exists(baseDirectory)) Directory.CreateDirectory(baseDirectory);
            profilesFile = Path.Combine(baseDirectory, "profiles.json");
            LoadProfiles();
        }

        public void LoadProfiles()
        {
            if (File.Exists(profilesFile))
            {
                string json = File.ReadAllText(profilesFile);
                Profiles = JsonConvert.DeserializeObject<List<ServerProfile>>(json) ?? new List<ServerProfile>();
            }
        }

        public void SaveProfiles()
        {
            if (string.IsNullOrEmpty(profilesFile)) return;
            string json = JsonConvert.SerializeObject(Profiles, Formatting.Indented);
            File.WriteAllText(profilesFile, json);
        }

        public ServerProfile CreateProfile(string name, int port, string baseDir)
        {
            var existingProfile = Profiles.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (existingProfile != null)
            {
                existingProfile.Port = port;
                existingProfile.InstallPath = Path.Combine(baseDir, name);
                SaveProfiles();
                return existingProfile;
            }

            var newProfile = new ServerProfile
            {
                Name = name,
                Port = port,
                InstallPath = Path.Combine(baseDir, name)
            };
            Profiles.Add(newProfile);
            SaveProfiles();
            return newProfile;
        }

        public void RemoveSpecificMap(ServerProfile profile, MapRecord record)
        {
            // 1. AN TOÀN CHO BẢN MỚI: Chỉ xóa VPK nếu tên file thực sự tồn tại (Tránh lỗi path4)
            if (!string.IsNullOrEmpty(record.VpkFileName))
            {
                string vpkPath = Path.Combine(profile.InstallPath, "left4dead2", "addons", record.VpkFileName);
                if (File.Exists(vpkPath)) File.Delete(vpkPath);
            }

            // 2. DỌN RÁC CHO BẢN CŨ: Nếu là map tải từ bản cũ, vòng lặp này sẽ dọn dẹp sạch sẽ
            if (record.ExtractedFiles != null && record.ExtractedFiles.Count > 0)
            {
                foreach (string relativePath in record.ExtractedFiles)
                {
                    string fullPath = Path.Combine(profile.InstallPath, "left4dead2", relativePath);
                    if (File.Exists(fullPath)) File.Delete(fullPath);
                }
            }

            // Cuối cùng, gỡ tên map ra khỏi danh sách ListBox và lưu lại
            profile.MapRecords.Remove(record);
            SaveProfiles();
        }
    }
}