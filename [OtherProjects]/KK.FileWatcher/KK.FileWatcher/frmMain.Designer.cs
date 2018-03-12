namespace KK.FileWatcher
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnSelFolder = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.chkWatchCreate = new System.Windows.Forms.CheckBox();
            this.chkWatchChange = new System.Windows.Forms.CheckBox();
            this.chkWatchDelete = new System.Windows.Forms.CheckBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.chkWatchRename = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblIsRunning = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkIncludeSubDir = new System.Windows.Forms.CheckBox();
            this.panOptions = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(88, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(418, 21);
            this.txtFolder.TabIndex = 0;
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelFolder.Location = new System.Drawing.Point(512, 12);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelFolder.TabIndex = 1;
            this.btnSelFolder.Text = "选择目录";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStart.Location = new System.Drawing.Point(9, 72);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.ForeColor = System.Drawing.Color.Yellow;
            this.btnStop.Location = new System.Drawing.Point(90, 72);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(12, 42);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(72, 16);
            this.chkTopMost.TabIndex = 5;
            this.chkTopMost.Text = "顶端显示";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.checkTopMost_CheckedChanged);
            // 
            // chkWatchCreate
            // 
            this.chkWatchCreate.AutoSize = true;
            this.chkWatchCreate.Checked = true;
            this.chkWatchCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchCreate.Location = new System.Drawing.Point(87, 3);
            this.chkWatchCreate.Name = "chkWatchCreate";
            this.chkWatchCreate.Size = new System.Drawing.Size(48, 16);
            this.chkWatchCreate.TabIndex = 6;
            this.chkWatchCreate.Text = "创建";
            this.chkWatchCreate.UseVisualStyleBackColor = true;
            // 
            // chkWatchChange
            // 
            this.chkWatchChange.AutoSize = true;
            this.chkWatchChange.Checked = true;
            this.chkWatchChange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchChange.Location = new System.Drawing.Point(141, 3);
            this.chkWatchChange.Name = "chkWatchChange";
            this.chkWatchChange.Size = new System.Drawing.Size(48, 16);
            this.chkWatchChange.TabIndex = 7;
            this.chkWatchChange.Text = "修改";
            this.chkWatchChange.UseVisualStyleBackColor = true;
            // 
            // chkWatchDelete
            // 
            this.chkWatchDelete.AutoSize = true;
            this.chkWatchDelete.Checked = true;
            this.chkWatchDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchDelete.Location = new System.Drawing.Point(195, 3);
            this.chkWatchDelete.Name = "chkWatchDelete";
            this.chkWatchDelete.Size = new System.Drawing.Size(48, 16);
            this.chkWatchDelete.TabIndex = 8;
            this.chkWatchDelete.Text = "删除";
            this.chkWatchDelete.UseVisualStyleBackColor = true;
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(12, 117);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(575, 238);
            this.txtConsole.TabIndex = 9;
            this.txtConsole.Text = "";
            // 
            // chkWatchRename
            // 
            this.chkWatchRename.AutoSize = true;
            this.chkWatchRename.Checked = true;
            this.chkWatchRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchRename.Location = new System.Drawing.Point(249, 3);
            this.chkWatchRename.Name = "chkWatchRename";
            this.chkWatchRename.Size = new System.Drawing.Size(60, 16);
            this.chkWatchRename.TabIndex = 10;
            this.chkWatchRename.Text = "重命名";
            this.chkWatchRename.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblIsRunning});
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblIsRunning
            // 
            this.lblIsRunning.Name = "lblIsRunning";
            this.lblIsRunning.Size = new System.Drawing.Size(32, 17);
            this.lblIsRunning.Text = "停止";
            // 
            // chkIncludeSubDir
            // 
            this.chkIncludeSubDir.AutoSize = true;
            this.chkIncludeSubDir.Checked = true;
            this.chkIncludeSubDir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubDir.Location = new System.Drawing.Point(3, 3);
            this.chkIncludeSubDir.Name = "chkIncludeSubDir";
            this.chkIncludeSubDir.Size = new System.Drawing.Size(84, 16);
            this.chkIncludeSubDir.TabIndex = 12;
            this.chkIncludeSubDir.Text = "包含子目录";
            this.chkIncludeSubDir.UseVisualStyleBackColor = true;
            // 
            // panOptions
            // 
            this.panOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panOptions.Controls.Add(this.chkIncludeSubDir);
            this.panOptions.Controls.Add(this.chkWatchCreate);
            this.panOptions.Controls.Add(this.chkWatchChange);
            this.panOptions.Controls.Add(this.chkWatchRename);
            this.panOptions.Controls.Add(this.chkWatchDelete);
            this.panOptions.Location = new System.Drawing.Point(124, 39);
            this.panOptions.Name = "panOptions";
            this.panOptions.Size = new System.Drawing.Size(315, 22);
            this.panOptions.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "监视目录：";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 380);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panOptions);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelFolder);
            this.Controls.Add(this.txtFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件访问监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panOptions.ResumeLayout(false);
            this.panOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnSelFolder;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.CheckBox chkWatchCreate;
        private System.Windows.Forms.CheckBox chkWatchChange;
        private System.Windows.Forms.CheckBox chkWatchDelete;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.CheckBox chkWatchRename;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblIsRunning;
        private System.Windows.Forms.CheckBox chkIncludeSubDir;
        private System.Windows.Forms.Panel panOptions;
        private System.Windows.Forms.Label label1;
    }
}

