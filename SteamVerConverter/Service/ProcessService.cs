using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SteamVerConverter.Service
{
    internal class ProcessService
    {
        public static void KillProcesses(string processName, int delay)
        {
            Process[] processes = Process.GetProcesses();
            //foreach (Process process in processes)
            //    Console.WriteLine($"进程名称: {process.ProcessName} (ID: {process.Id})");

            if (processName.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                processName = Path.GetFileNameWithoutExtension(processName);
            processes = Array.FindAll(processes, p => p.ProcessName.Contains(processName));
            if (processes.Length > 0)
            {
                foreach (Process process in processes)
                    process.Kill();
                // 检测到进程再dealy
                Thread.Sleep(delay);
            }
        }

        public static string StartExplorerReturn(string path, string info)
        {
            Process.Start("explorer", path);
            return info;
        }
    }
}
