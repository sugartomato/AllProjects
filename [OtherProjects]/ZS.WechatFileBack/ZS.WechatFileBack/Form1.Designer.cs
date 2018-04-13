namespace ZS.WechatFileBack
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtWXFolder = new System.Windows.Forms.TextBox();
            this.txtBackFolder = new System.Windows.Forms.TextBox();
            this.btnSelWXFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelBackFolder = new System.Windows.Forms.Button();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblState = new System.Windows.Forms.Label();
            this.fsw = new System.IO.FileSystemWatcher();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWXFolder
            // 
            this.txtWXFolder.Location = new System.Drawing.Point(112, 12);
            this.txtWXFolder.Name = "txtWXFolder";
            this.txtWXFolder.Size = new System.Drawing.Size(192, 21);
            this.txtWXFolder.TabIndex = 0;
            // 
            // txtBackFolder
            // 
            this.txtBackFolder.Location = new System.Drawing.Point(112, 39);
            this.txtBackFolder.Name = "txtBackFolder";
            this.txtBackFolder.Size = new System.Drawing.Size(192, 21);
            this.txtBackFolder.TabIndex = 2;
            // 
            // btnSelWXFolder
            // 
            this.btnSelWXFolder.Location = new System.Drawing.Point(310, 10);
            this.btnSelWXFolder.Name = "btnSelWXFolder";
            this.btnSelWXFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelWXFolder.TabIndex = 1;
            this.btnSelWXFolder.Text = "选择..";
            this.btnSelWXFolder.UseVisualStyleBackColor = true;
            this.btnSelWXFolder.Click += new System.EventHandler(this.btnSelWXFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "微信文件目录：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 99;
            this.label2.Text = "备份目录：";
            // 
            // btnSelBackFolder
            // 
            this.btnSelBackFolder.Location = new System.Drawing.Point(310, 37);
            this.btnSelBackFolder.Name = "btnSelBackFolder";
            this.btnSelBackFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelBackFolder.TabIndex = 3;
            this.btnSelBackFolder.Text = "选择..";
            this.btnSelBackFolder.UseVisualStyleBackColor = true;
            this.btnSelBackFolder.Click += new System.EventHandler(this.btnSelBackFolder_Click);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(12, 77);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(96, 16);
            this.chkAutoStart.TabIndex = 4;
            this.chkAutoStart.Text = "开机自动运行";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(199, 76);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 35);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "开始(&S)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(295, 77);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 35);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "停止(T)";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(12, 100);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(83, 12);
            this.lblState.TabIndex = 9;
            this.lblState.Text = "备份已停止！";
            // 
            // fsw
            // 
            this.fsw.EnableRaisingEvents = true;
            this.fsw.SynchronizingObject = this;
            this.fsw.Created += new System.IO.FileSystemEventHandler(this.fsw_Created);
            this.fsw.Renamed += new System.IO.RenamedEventHandler(this.fsw_Renamed);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ZS微信文件备份\r\n[双击打开程序主界面]";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 123);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.btnSelBackFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelWXFolder);
            this.Controls.Add(this.txtBackFolder);
            this.Controls.Add(this.txtWXFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信接收文件备份 For ZS";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fsw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWXFolder;
        private System.Windows.Forms.TextBox txtBackFolder;
        private System.Windows.Forms.Button btnSelWXFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelBackFolder;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblState;
        private System.IO.FileSystemWatcher fsw;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

