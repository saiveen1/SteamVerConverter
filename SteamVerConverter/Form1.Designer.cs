﻿namespace SteamVerConverter
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.folderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tSteamDir = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tVersionDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lsteamVer = new System.Windows.Forms.Label();
            this.lsteamVerNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbReplaceItems = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.tutorialUrl = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.versionUrl = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // folderButton
            // 
            this.folderButton.Font = new System.Drawing.Font("宋体", 12F);
            this.folderButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.folderButton.Location = new System.Drawing.Point(286, 8);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(80, 35);
            this.folderButton.TabIndex = 24;
            this.folderButton.Text = "Browse";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.folderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Steam路径:";
            // 
            // tSteamDir
            // 
            this.tSteamDir.AcceptsTab = true;
            this.tSteamDir.BackColor = System.Drawing.SystemColors.Info;
            this.tSteamDir.Font = new System.Drawing.Font("宋体", 15.75F);
            this.tSteamDir.Location = new System.Drawing.Point(12, 43);
            this.tSteamDir.Multiline = true;
            this.tSteamDir.Name = "tSteamDir";
            this.tSteamDir.Size = new System.Drawing.Size(354, 70);
            this.tSteamDir.TabIndex = 23;
            this.tSteamDir.TextChanged += new System.EventHandler(this.steamDirText_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(286, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 35);
            this.button1.TabIndex = 27;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(8, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "版本路径:";
            // 
            // tVersionDir
            // 
            this.tVersionDir.AcceptsTab = true;
            this.tVersionDir.BackColor = System.Drawing.SystemColors.Info;
            this.tVersionDir.Font = new System.Drawing.Font("宋体", 15.75F);
            this.tVersionDir.Location = new System.Drawing.Point(12, 161);
            this.tVersionDir.Multiline = true;
            this.tVersionDir.Name = "tVersionDir";
            this.tVersionDir.Size = new System.Drawing.Size(354, 70);
            this.tVersionDir.TabIndex = 26;
            this.tVersionDir.TextChanged += new System.EventHandler(this.tVerDir_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(8, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 21);
            this.label3.TabIndex = 28;
            this.label3.Text = "可替换版本:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(8, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 21);
            this.label4.TabIndex = 29;
            this.label4.Text = "当前steam版本:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(165, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 30;
            // 
            // lsteamVer
            // 
            this.lsteamVer.AutoSize = true;
            this.lsteamVer.Font = new System.Drawing.Font("宋体", 15.75F);
            this.lsteamVer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lsteamVer.Location = new System.Drawing.Point(165, 245);
            this.lsteamVer.Name = "lsteamVer";
            this.lsteamVer.Size = new System.Drawing.Size(98, 21);
            this.lsteamVer.TabIndex = 31;
            this.lsteamVer.Text = "steamVer";
            this.lsteamVer.Visible = false;
            // 
            // lsteamVerNum
            // 
            this.lsteamVerNum.AutoSize = true;
            this.lsteamVerNum.Font = new System.Drawing.Font("宋体", 15.75F);
            this.lsteamVerNum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lsteamVerNum.Location = new System.Drawing.Point(300, 245);
            this.lsteamVerNum.Name = "lsteamVerNum";
            this.lsteamVerNum.Size = new System.Drawing.Size(32, 21);
            this.lsteamVerNum.TabIndex = 32;
            this.lsteamVerNum.Text = "v1";
            this.lsteamVerNum.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(282, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 21);
            this.label6.TabIndex = 33;
            this.label6.Text = "|";
            // 
            // cbReplaceItems
            // 
            this.cbReplaceItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReplaceItems.Font = new System.Drawing.Font("宋体", 15.75F);
            this.cbReplaceItems.FormattingEnabled = true;
            this.cbReplaceItems.Location = new System.Drawing.Point(140, 349);
            this.cbReplaceItems.Name = "cbReplaceItems";
            this.cbReplaceItems.Size = new System.Drawing.Size(144, 29);
            this.cbReplaceItems.TabIndex = 34;
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("宋体", 12F);
            this.btnChange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChange.Location = new System.Drawing.Point(286, 345);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(80, 35);
            this.btnChange.TabIndex = 35;
            this.btnChange.Text = "替换";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_ClickAsync);
            // 
            // tutorialUrl
            // 
            this.tutorialUrl.AutoSize = true;
            this.tutorialUrl.Font = new System.Drawing.Font("宋体", 15.75F);
            this.tutorialUrl.Location = new System.Drawing.Point(8, 277);
            this.tutorialUrl.Name = "tutorialUrl";
            this.tutorialUrl.Size = new System.Drawing.Size(52, 21);
            this.tutorialUrl.TabIndex = 36;
            this.tutorialUrl.TabStop = true;
            this.tutorialUrl.Text = "教程";
            this.tutorialUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.tutorialUrl_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(159, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "交流群：1908912779";
            // 
            // versionUrl
            // 
            this.versionUrl.AutoSize = true;
            this.versionUrl.Font = new System.Drawing.Font("宋体", 15.75F);
            this.versionUrl.Location = new System.Drawing.Point(66, 277);
            this.versionUrl.Name = "versionUrl";
            this.versionUrl.Size = new System.Drawing.Size(94, 21);
            this.versionUrl.TabIndex = 38;
            this.versionUrl.TabStop = true;
            this.versionUrl.Text = "版本下载";
            this.versionUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.versionUrl_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 313);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(350, 26);
            this.progressBar1.TabIndex = 39;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 382);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.versionUrl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tutorialUrl);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.cbReplaceItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lsteamVerNum);
            this.Controls.Add(this.lsteamVer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tVersionDir);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tSteamDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Steam版本转换";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tSteamDir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tVersionDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lsteamVer;
        private System.Windows.Forms.Label lsteamVerNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbReplaceItems;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.LinkLabel tutorialUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel versionUrl;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

