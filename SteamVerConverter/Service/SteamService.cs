using Microsoft.Win32;
using SteamVerConverter.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace SteamVerConverter.services
{
    internal class SteamService
    {
        public static readonly string steamv1Version = "7.56.33.36";
        public static readonly string steamv2Version = "8.9.11.89";
        public static readonly string steamv3Version = "8.14.49.6";

        public static string GetSteamFolder()
        {
            using var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam");
            var steamFolder = key.GetValue("SteamPath").ToString();
            if (string.IsNullOrEmpty(steamFolder) || !Directory.Exists(steamFolder))
                return String.Empty;

            return Path.GetFullPath(Path.Combine(steamFolder, "steam.exe"));
        }

        public static string GetSteamPath()
        {
            using var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam");
            if (key is null)
                return String.Empty;

            var steamPath = key.GetValue("SteamExe").ToString();
            if (File.Exists(steamPath))
                return steamPath;
            else
                return String.Empty;
        }

        public static Dictionary<string, string> GetSteamVersion(string steamFilePath)
        {
            Dictionary<string, string> steamVersionInfo = new Dictionary<string, string>();

            var steamv1Ver = new Version(steamv1Version);
            var steamv3Ver = new Version(steamv3Version);
            var steamVersion = FileService.GetFileVersion(steamFilePath);
            string sSteamVersion = steamVersion.ToString();
            string sSteamVerNum = string.Empty;

            if (steamVersion <= steamv1Ver)
                sSteamVerNum = "V1";
            else if (steamVersion > steamv1Ver && steamVersion < steamv3Ver)
                sSteamVerNum = "V2";
            else if (steamVersion >= steamv3Ver)
                sSteamVerNum = "V3";

            steamVersionInfo.Add("Version", sSteamVersion);
            steamVersionInfo.Add("VerNum", sSteamVerNum);

            return steamVersionInfo;
        }

    }
}
