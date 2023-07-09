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

        private void GetSteamVersion(string steamPath)
        {
            // 需要转换成Version
            var steamv1Ver = new Version("7.56.33.36");
            // var steamv2Ver = new Version("8.9.11.89");
            var steamv3Ver = new Version("8.14.49.6");
            steamVersion = FileService.GetFileVersion(steamPath);
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
                this.tSteamDir.Text = Path.GetDirectoryName(steamPath);
                GetSteamVersion(steamPath);
            }

            this.tVersionDir.Text = Environment.CurrentDirectory;
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
                    tSteamDir.Text = steamPath;
                else
                    MessageBox.Show("steam.exe未找到!");
            }
                
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new() { Description = "版本文件目录" };
            if (dlg.ShowDialog() == DialogResult.OK)
                tVersionDir.Text = dlg.SelectedPath;
        }

        private void steamDirText_TextChanged(object sender, EventArgs e)
        {
            //手动填写的目录
            var t = Path.GetFullPath(Path.Combine(this.tSteamDir.Text, "steam.exe"));
            if (File.Exists(t))
            {
                steamPath = t;
                GetSteamVersion(steamPath);
            }
            else
            {
                steamPath = "";
                this.lsteamVer.Visible = false;
                this.lsteamVerNum.Visible = false;
            }
            //steam.exe文件
            //if (!string.IsNullOrEmpty(this.tSteamDir.Text))
            //    if(File.Exists(this.tSteamDir.Text))
            //        GetSteamVersion(this.tSteamDir.Text);
        }

        //获取程序运行目录的steam版本文件.zip
        private void tversionDir_TextChanged(object sender, EventArgs e)
        {
            cbReplaceItems.Items.Clear();
            try
            {
                string[] zipFiles = Directory.GetFiles(tVersionDir.Text, "*.zip");

                if (zipFiles.Length != 0)
                {
                    foreach (string filePath in zipFiles)
                        cbReplaceItems.Items.Add(Path.GetFileName(filePath));
                    cbReplaceItems.SelectedIndex = 0;
                }
            }
            catch (DirectoryNotFoundException){
                return;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(steamPath))
                MessageBox.Show("未找到steam.exe, 请确认steam路径是否正确", "Error");
            var selectedItem = cbReplaceItems.SelectedItem;
            if (selectedItem == null)
                return;
            string selectedFileName = this.cbReplaceItems.SelectedItem.ToString(); 
            string zipFilePath = Path.Combine(this.tVersionDir.Text, selectedFileName); 
            string dstPath = this.tSteamDir.Text;

            var msg = $"是否确认替换版本为{selectedFileName}？";
            DialogResult result = MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                try
                {
                    if (FileService.ZipFiles(zipFilePath, dstPath))
                        MessageBox.Show("替换完成，如无法运行保留如下\n" +
                            "文件：steam.exe\n" +
                            "文件夹: userdata steamapps\n" +
                            "其它删除后重新打开steam.exe即可重新安装最新。");

                    this.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.ToString(), "出错，联系QQ：");
                }

        }

        private void tutorialUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bilibili.com");
        }

        private void versionUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://baidu.com");
        }
    }
}
