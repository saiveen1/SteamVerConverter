using SteamVerConverter.Service;
using SteamVerConverter.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SteamVerConverter.Service.DialogService;
using static SteamVerConverter.Service.FileService;

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

        private void RefreshSteamVersionText(string steamPath)
        {
            // var steamv2Ver = new Version("8.9.11.89");

            var steamVerInfo = SteamService.GetSteamVersion(steamPath);

            this.lsteamVer.Text = steamVerInfo["Version"];
            this.lsteamVer.Visible = true;
            this.lsteamVerNum.Text = steamVerInfo["VerNum"];
            this.lsteamVerNum.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // DialogService.ShowNonClickableMessageBox("这是一个无法点击的消息框", "提示", 10000);
            // NonClickableMessageBox.Show("这是一个无法点击的消息框", "提示", 3000);

            if (string.IsNullOrEmpty(steamPath))
                MessageBox.Show("Steam路径获取失败，请手动获取", "错误");
            else
            {
                this.tSteamDir.Text = Path.GetDirectoryName(steamPath);
                RefreshSteamVersionText(steamPath);
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
                RefreshSteamVersionText(steamPath);
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
            //        GetSteamVNum(this.tSteamDir.Text);
        }

        //获取程序运行目录的steam版本文件.zip
        private void tVerDir_TextChanged(object sender, EventArgs e)
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

        private async void btnChange_ClickAsync(object sender, EventArgs e)
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
                    ProcessService.KillProcesses("steam.exe", 3000);
                    // filePath 是要被处理的文件由主函数调用，这里是steam.exe
                    void fileProcessingDelegate(string filePath)
                    {
                        // 在这里执行特定的文件操作逻辑
                        Version fileVersion = FileService.GetFileVersion(filePath);
                        Version targetVersion = new Version(SteamService.steamv3Version); // 目标版本

                        // 如果版本大于等于V3 则删除steam.cfg 保持最新状态
                        if (fileVersion >= targetVersion)
                        {
                            string directoryPath = Path.GetDirectoryName(filePath);
                            var msg = $"即将完成替换v3，是否暂停steam更新？" +
                                $"\n如果后续需要保持steam为最新，删除steam.cfg即可";
                            var result = MessageBox.Show(msg, "提示", MessageBoxButtons.YesNo);

                            if (result == DialogResult.No)
                            {
                                string cfgFilePath = Path.Combine(directoryPath, "steam.cfg");

                                if (File.Exists(cfgFilePath))
                                {
                                    File.Delete(cfgFilePath);
                                    Console.WriteLine("Deleted steam.cfg file.");
                                }
                            }
                        }
                    }

                    // 创建进度报告对象
                    var progress = new Progress<int>(value =>
                    {
                        // 更新进度条的值
                        progressBar1.Value = value;
                    });

                    // 调用 ZipFiles 方法，并使用进度报告对象
                    bool zipResult = await Task.Run(() => ZipFiles(zipFilePath, dstPath, fileProcessingDelegate, progress));

                    if(zipResult)
                        msg = "替换完成，如无法运行保留如下\n" +
                            "文件：steam.exe\n" +
                            "文件夹: userdata steamapps\n" +
                            "其它删除后重新打开steam.exe即可重新安装最新。";
                    else
                        msg = "文件替换操作失败\n" +
                            "请以管理员运行后再试\n" +
                            "如再次失败，手动解压。";
                    NonClickableMessageBox.Show(msg + "\n\n10s后自动关闭",
                        "10s后自动关闭",
                        10000);
                    // 关闭窗口
                    this.Close();
                }
                catch (Exception exp)
                {
                    FileService.WriteError(exp);
                    ProcessService.StartExplorerReturn(Environment.CurrentDirectory, "");
                    MessageBox.Show(exp.ToString(), "未知错误, 请将error.log发送qq：1186565583");
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
