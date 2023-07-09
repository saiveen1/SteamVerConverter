using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamVerConverter.Service
{
    internal class FileService
    {
        public static string GetCurrentDirectory()
        {
            string curPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] directories = Directory.GetDirectories(curPath, "*", SearchOption.AllDirectories);

            string searchValue = "backup"; // 要搜索的值

            var directoriesContainingValue = directories.Where(directory => directory.Contains(searchValue)).ToList();

            return directoriesContainingValue[0];
        }

        public static Version GetFileVersion(string fileName)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            return new Version(versionInfo.FileVersion ?? "0.0.0");
        }

        public static bool ZipFiles(string zipFilePath, string dstPath) 
        {
            try
            {
                using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string entryDestinationPath = Path.GetFullPath(Path.Combine(dstPath, entry.FullName));

                        if (!string.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(entryDestinationPath));
                            entry.ExtractToFile(entryDestinationPath, true);
                        }
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
