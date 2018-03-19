namespace KK.FileBackup
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gridMain = new System.Windows.Forms.DataGridView();
            this.clmRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnResizeCLMWidth = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.grpMailSetting = new System.Windows.Forms.GroupBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEmail_Account = new System.Windows.Forms.Label();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMailAccount = new System.Windows.Forms.TextBox();
            this.btSendNow = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            this.grpMailSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMain
            // 
            this.gridMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmRemove,
            this.clmName,
            this.clmPath});
            this.gridMain.Location = new System.Drawing.Point(12, 41);
            this.gridMain.Name = "gridMain";
            this.gridMain.RowTemplate.Height = 23;
            this.gridMain.Size = new System.Drawing.Size(557, 240);
            this.gridMain.TabIndex = 0;
            this.gridMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMain_CellContentClick);
            // 
            // clmRemove
            // 
            this.clmRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clmRemove.Frozen = true;
            this.clmRemove.HeaderText = "";
            this.clmRemove.MinimumWidth = 80;
            this.clmRemove.Name = "clmRemove";
            this.clmRemove.Text = "移除";
            this.clmRemove.UseColumnTextForButtonValue = true;
            // 
            // clmName
            // 
            this.clmName.HeaderText = "文件名";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmPath
            // 
            this.clmPath.HeaderText = "路径";
            this.clmPath.Name = "clmPath";
            this.clmPath.ReadOnly = true;
            // 
            // btnAddFile
            // 
            this.btnAddFile.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddFile.Location = new System.Drawing.Point(12, 12);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(101, 23);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "添加文件(&A)";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnResizeCLMWidth
            // 
            this.btnResizeCLMWidth.Location = new System.Drawing.Point(491, 12);
            this.btnResizeCLMWidth.Name = "btnResizeCLMWidth";
            this.btnResizeCLMWidth.Size = new System.Drawing.Size(75, 23);
            this.btnResizeCLMWidth.TabIndex = 2;
            this.btnResizeCLMWidth.Text = "调整列宽";
            this.btnResizeCLMWidth.UseVisualStyleBackColor = true;
            this.btnResizeCLMWidth.Click += new System.EventHandler(this.btnResizeCLMWidth_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(410, 12);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "清空所有行";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // grpMailSetting
            // 
            this.grpMailSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMailSetting.Controls.Add(this.txtPort);
            this.grpMailSetting.Controls.Add(this.label4);
            this.grpMailSetting.Controls.Add(this.label1);
            this.grpMailSetting.Controls.Add(this.txtServerUrl);
            this.grpMailSetting.Controls.Add(this.label3);
            this.grpMailSetting.Controls.Add(this.label2);
            this.grpMailSetting.Controls.Add(this.lblEmail_Account);
            this.grpMailSetting.Controls.Add(this.txtReceiver);
            this.grpMailSetting.Controls.Add(this.txtPassword);
            this.grpMailSetting.Controls.Add(this.txtMailAccount);
            this.grpMailSetting.Location = new System.Drawing.Point(578, 12);
            this.grpMailSetting.Name = "grpMailSetting";
            this.grpMailSetting.Size = new System.Drawing.Size(264, 168);
            this.grpMailSetting.TabIndex = 4;
            this.grpMailSetting.TabStop = false;
            this.grpMailSetting.Text = "邮箱配置";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(83, 47);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(175, 21);
            this.txtPort.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "端口号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器地址";
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(83, 20);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(175, 21);
            this.txtServerUrl.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "接收邮箱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // lblEmail_Account
            // 
            this.lblEmail_Account.AutoSize = true;
            this.lblEmail_Account.Location = new System.Drawing.Point(6, 77);
            this.lblEmail_Account.Name = "lblEmail_Account";
            this.lblEmail_Account.Size = new System.Drawing.Size(29, 12);
            this.lblEmail_Account.TabIndex = 3;
            this.lblEmail_Account.Text = "帐号";
            // 
            // txtReceiver
            // 
            this.txtReceiver.Location = new System.Drawing.Point(83, 134);
            this.txtReceiver.Multiline = true;
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Size = new System.Drawing.Size(175, 24);
            this.txtReceiver.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 104);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '#';
            this.txtPassword.Size = new System.Drawing.Size(175, 24);
            this.txtPassword.TabIndex = 1;
            // 
            // txtMailAccount
            // 
            this.txtMailAccount.Location = new System.Drawing.Point(83, 74);
            this.txtMailAccount.Multiline = true;
            this.txtMailAccount.Name = "txtMailAccount";
            this.txtMailAccount.Size = new System.Drawing.Size(175, 24);
            this.txtMailAccount.TabIndex = 0;
            // 
            // btSendNow
            // 
            this.btSendNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSendNow.Location = new System.Drawing.Point(578, 186);
            this.btSendNow.Name = "btSendNow";
            this.btSendNow.Size = new System.Drawing.Size(117, 39);
            this.btSendNow.TabIndex = 5;
            this.btSendNow.Text = "立即备份";
            this.btSendNow.UseVisualStyleBackColor = true;
            this.btSendNow.Click += new System.EventHandler(this.btSendNow_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtConsole.ForeColor = System.Drawing.Color.Lime;
            this.txtConsole.Location = new System.Drawing.Point(12, 318);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(845, 136);
            this.txtConsole.TabIndex = 6;
            this.txtConsole.Text = "消息文本";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "文件备份程序";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(12, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 28);
            this.label5.TabIndex = 7;
            this.label5.Text = "关闭时会自动保存文件列表\r\n最小化之后双击右下角图标重新显示";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.Lime;
            this.btnStart.Location = new System.Drawing.Point(578, 231);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 50);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "启动定时备份";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnStop.Location = new System.Drawing.Point(698, 231);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 50);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "停止定时备份";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(672, 285);
            this.timePicker.Name = "timePicker";
            this.timePicker.Size = new System.Drawing.Size(105, 21);
            this.timePicker.TabIndex = 10;
            this.timePicker.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(575, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "定时备份时间";
            this.label6.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 466);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btSendNow);
            this.Controls.Add(this.grpMailSetting);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnResizeCLMWidth);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.gridMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[KK专用]文件备份";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            this.grpMailSetting.ResumeLayout(false);
            this.grpMailSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridMain;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.DataGridViewButtonColumn clmRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPath;
        private System.Windows.Forms.Button btnResizeCLMWidth;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.GroupBox grpMailSetting;
        private System.Windows.Forms.TextBox txtMailAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmail_Account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerUrl;
        private System.Windows.Forms.Button btSendNow;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label label6;
    }
}

