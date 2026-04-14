using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace L4D2ServerManager
{
    public static class SecurityManager
    {
        // Nhập thư viện Windows API tầng thấp để quét Debugger
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool IsDebuggerPresent();

        public static void InitializeAntiCrack()
        {
            // 1. Kiểm tra có ai đang gắn Debugger của .NET vào không
            if (Debugger.IsAttached) SelfDestruct();

            // 2. Kiểm tra Debugger ở tầng System Windows (Bắt các tool mạnh hơn)
            if (IsDebuggerPresent()) SelfDestruct();

            // 3. Kiểm tra Remote Debugger (Bắt các tool theo dõi từ xa)
            bool isDebuggerAttached = false;
            CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerAttached);
            if (isDebuggerAttached) SelfDestruct();

            // 4. Tạo một tiến trình chạy ngầm liên tục quét các công cụ Crack phổ biến
            Thread scanThread = new Thread(() =>
            {
                while (true)
                {
                    ScanForBlacklistedProcesses();
                    Thread.Sleep(3000); // Quét 3 giây 1 lần
                }
            });
            scanThread.IsBackground = true;
            scanThread.Start();
        }

        private static void ScanForBlacklistedProcesses()
        {
            // Danh sách các công cụ chuyên dùng để Crack, soi code, chặn bắt HTTP
            string[] badProcesses = {
                "dnspy", "cheatengine", "ollydbg", "x64dbg", "x32dbg",
                "ida", "ida64", "wireshark", "fiddler", "httpdebugger", "charles"
            };

            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                try
                {
                    string pName = p.ProcessName.ToLower();
                    foreach (string bad in badProcesses)
                    {
                        if (pName.Contains(bad)) SelfDestruct();
                    }
                }
                catch { /* Bỏ qua lỗi truy cập quyền admin của process khác */ }
            }
        }

        private static void SelfDestruct()
        {
            // LƯU Ý: Tuyệt đối không dùng MessageBox báo lỗi. Hacker sẽ dựa vào chữ báo lỗi để tìm ra dòng code này và xóa nó đi.
            // Ép phần mềm tự sát ngay lập tức ở cấp độ Process.
            Process.GetCurrentProcess().Kill();
            Environment.Exit(0);
        }
    }
}