using SteamVerConverter.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SteamVerConverter
{
    public partial class Form1 : Form
    {
        string steamPath = SteamService.GetSteamPath();

        Version steamVersion = new Version();
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ChangeSteamVer(string steamPath)
        {
            // 需要转换成Version
            var steamv1Ver = new Version("7.56.33.36");
            var steamv2Ver = new Version("8.9.11.89");
            var steamv3Ver = new Version("8.14.49.6");
            steamVersion = FileSerivce.GetFileVersion(steamPath);
            this.lsteamVer.Text = steamVersion.ToString();
            this.lsteamVer.Visible = true;
            if (steamVersion <= steamv1Ver)
                this.lsteamVerNum.Text = "V1";
            else if (steamVersion > steamv1Ver && steamVersion < steamv3Ver)
                this.lsteamVerNum.Text = "V2";
            else if (steamVersion >= steamv3Ver)
                this.lsteamVerNum.Text = "V3";
            this.lsteamVerNum.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(steamPath))
                MessageBox.Show("Steam路径获取失败，请手动获取", "错误");
            else
            {
                this.tsteamDir.Text = steamPath;
                ChangeSteamVer(steamPath);
            }

            this.tversionDir.Text = Environment.CurrentDirectory;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 创建子窗口集合的副本
            List<Form> childForms = new(this.MdiChildren);

            // 关闭所有子窗口
            foreach (Form childForm in childForms)
                childForm.Close();
        }

        private void folderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new() { Description = "Steam目录" };
            if (dlg.ShowDialog() == DialogResult.OK)
            { 
                steamPath = Path.GetFullPath(Path.Combine(dlg.SelectedPath, "steam.exe"));
                if (File.Exists(steamPath))
                    tsteamDir.Text = steamPath;
                else
                    MessageBox.Show("steam.exe未找到!");
            }
                
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new() { Description = "版本文件目录" };
            if (dlg.ShowDialog() == DialogResult.OK)
                tsteamDir.Text = dlg.SelectedPath;
        }

        private void steamDirText_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tsteamDir.Text))
                ChangeSteamVer(this.tsteamDir.Text);
        }

        private void tversionDir_TextChanged(object sender, EventArgs e)
        {
            string[] zipFiles = Directory.GetFiles(tversionDir.Text, "*.zip");

            foreach (string filePath in zipFiles)
                cbreplaceItems.Items.Add(Path.GetFileName(filePath));
            cbreplaceItems.SelectedIndex = 0;
        }
    }
}
