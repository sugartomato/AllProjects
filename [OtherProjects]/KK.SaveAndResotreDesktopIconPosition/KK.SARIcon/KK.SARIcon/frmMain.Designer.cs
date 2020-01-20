namespace KK.SARIcon
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
            this.btnSaveIcon = new System.Windows.Forms.Button();
            this.btnRestoreIcon = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnListIcons = new System.Windows.Forms.Button();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.btnLoadIconConfig = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveIcon
            // 
            this.btnSaveIcon.BackColor = System.Drawing.Color.LightGreen;
            this.btnSaveIcon.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSaveIcon.Location = new System.Drawing.Point(13, 12);
            this.btnSaveIcon.Name = "btnSaveIcon";
            this.btnSaveIcon.Size = new System.Drawing.Size(129, 35);
            this.btnSaveIcon.TabIndex = 0;
            this.btnSaveIcon.Text = "保存[默认文件](&S)";
            this.btnSaveIcon.UseVisualStyleBackColor = false;
            this.btnSaveIcon.Click += new System.EventHandler(this.btnSaveIcon_Click);
            // 
            // btnRestoreIcon
            // 
            this.btnRestoreIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnRestoreIcon.Location = new System.Drawing.Point(13, 53);
            this.btnRestoreIcon.Name = "btnRestoreIcon";
            this.btnRestoreIcon.Size = new System.Drawing.Size(129, 35);
            this.btnRestoreIcon.TabIndex = 1;
            this.btnRestoreIcon.Text = "恢复[默认文件](&R)";
            this.btnRestoreIcon.UseVisualStyleBackColor = false;
            this.btnRestoreIcon.Click += new System.EventHandler(this.btnRestoreIcon_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(148, 12);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(194, 171);
            this.txtConsole.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState,
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 221);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(354, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(32, 17);
            this.lblState.Text = "就绪";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel1.Text = "By DHD";
            // 
            // btnListIcons
            // 
            this.btnListIcons.Location = new System.Drawing.Point(13, 94);
            this.btnListIcons.Name = "btnListIcons";
            this.btnListIcons.Size = new System.Drawing.Size(129, 35);
            this.btnListIcons.TabIndex = 1;
            this.btnListIcons.Text = "列举图标(&L)";
            this.btnListIcons.UseVisualStyleBackColor = true;
            this.btnListIcons.Click += new System.EventHandler(this.btnListIcons_Click);
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Location = new System.Drawing.Point(267, 189);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(75, 23);
            this.btnClearConsole.TabIndex = 5;
            this.btnClearConsole.Text = "清空";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // btnLoadIconConfig
            // 
            this.btnLoadIconConfig.Location = new System.Drawing.Point(13, 164);
            this.btnLoadIconConfig.Name = "btnLoadIconConfig";
            this.btnLoadIconConfig.Size = new System.Drawing.Size(129, 23);
            this.btnLoadIconConfig.TabIndex = 6;
            this.btnLoadIconConfig.Text = "加载位置配置";
            this.btnLoadIconConfig.UseVisualStyleBackColor = true;
            this.btnLoadIconConfig.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "位置另存为...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 243);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoadIconConfig);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnListIcons);
            this.Controls.Add(this.btnRestoreIcon);
            this.Controls.Add(this.btnSaveIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "桌面图标位置保存与恢复";
            this.Load += new System.EventHandler(this.Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIcon;
        private System.Windows.Forms.Button btnRestoreIcon;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnListIcons;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.Button btnLoadIconConfig;
        private System.Windows.Forms.Button button2;
    }
}

