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
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveIcon
            // 
            this.btnSaveIcon.Location = new System.Drawing.Point(13, 21);
            this.btnSaveIcon.Name = "btnSaveIcon";
            this.btnSaveIcon.Size = new System.Drawing.Size(110, 50);
            this.btnSaveIcon.TabIndex = 0;
            this.btnSaveIcon.Text = "保存图标位置(&S)";
            this.btnSaveIcon.UseVisualStyleBackColor = true;
            this.btnSaveIcon.Click += new System.EventHandler(this.btnSaveIcon_Click);
            // 
            // btnRestoreIcon
            // 
            this.btnRestoreIcon.Location = new System.Drawing.Point(13, 77);
            this.btnRestoreIcon.Name = "btnRestoreIcon";
            this.btnRestoreIcon.Size = new System.Drawing.Size(110, 50);
            this.btnRestoreIcon.TabIndex = 1;
            this.btnRestoreIcon.Text = "恢复图标位置(&R)";
            this.btnRestoreIcon.UseVisualStyleBackColor = true;
            this.btnRestoreIcon.Click += new System.EventHandler(this.btnRestoreIcon_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(129, 12);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(213, 157);
            this.txtConsole.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState,
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 186);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 208);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtConsole);
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
    }
}

