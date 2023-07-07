using Microsoft.Win32;
using System;
using System.IO;

namespace SteamVerConverter.Service
{
    internal class SteamService
    {
        public static string GetSteamPath()
        {
            using var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam");
            if (key is null)
                return String.Empty;

            var steamFolder = key.GetValue("SteamPath").ToString();
            if (string.IsNullOrEmpty(steamFolder) || !Directory.Exists(steamFolder))
                return String.Empty;

            return Path.GetFullPath(Path.Combine(steamFolder, "steam.exe")); ;
        }
    }
}
