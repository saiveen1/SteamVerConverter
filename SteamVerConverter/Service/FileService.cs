using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;


namespace SteamVerConverter.Service
{
    internal class FileService
    {
        public static Version GetFileVersion(string fileName)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            return new Version(versionInfo.FileVersion ?? "0.0.0");
        }

        public delegate void FileProcessingDelegate(string filePath);
        public static bool ZipFiles(string zipFilePath, string dstPath, FileProcessingDelegate fileProcessingDelegate, IProgress<int> progress)
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    int totalEntries = archive.Entries.Count;
                    int processedEntries = 0;

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryDestinationPath = Path.GetFullPath(Path.Combine(dstPath, entry.FullName));

                        if (!string.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(entryDestinationPath));
                            entry.ExtractToFile(entryDestinationPath, true);

                            if (Path.GetFileName(entryDestinationPath) == "steam.exe")
                            {
                                // 调用委托处理文件
                                fileProcessingDelegate?.Invoke(entryDestinationPath);
                            }
                        }

                        processedEntries++;

                        // 计算并报告进度
                        int progressPercentage = (int)((double)processedEntries / totalEntries * 100);
                        progress.Report(progressPercentage);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }



        private static readonly string error_log_path = Path.Combine(Environment.CurrentDirectory, "error.log");
        public static void WriteError(Exception exception)
        {
            // 将错误信息写入 error.log 文件
            string errorLogPath = Path.Combine(Environment.CurrentDirectory, "error.log");
            using (StreamWriter writer = new(errorLogPath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] Error: {exception.Message}");
                // 输出详细信息
                writer.WriteLine($"StackTrace: {exception.StackTrace}");
                writer.WriteLine("----------------------------------------");
            }
        }
    }
}
