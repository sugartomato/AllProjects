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
            this.lblState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveIcon
            // 
            this.btnSaveIcon.Location = new System.Drawing.Point(39, 12);
            this.btnSaveIcon.Name = "btnSaveIcon";
            this.btnSaveIcon.Size = new System.Drawing.Size(110, 50);
            this.btnSaveIcon.TabIndex = 0;
            this.btnSaveIcon.Text = "保存图标位置(&S)";
            this.btnSaveIcon.UseVisualStyleBackColor = true;
            this.btnSaveIcon.Click += new System.EventHandler(this.btnSaveIcon_Click);
            // 
            // btnRestoreIcon
            // 
            this.btnRestoreIcon.Location = new System.Drawing.Point(169, 12);
            this.btnRestoreIcon.Name = "btnRestoreIcon";
            this.btnRestoreIcon.Size = new System.Drawing.Size(110, 50);
            this.btnRestoreIcon.TabIndex = 1;
            this.btnRestoreIcon.Text = "恢复图标位置(&R)";
            this.btnRestoreIcon.UseVisualStyleBackColor = true;
            this.btnRestoreIcon.Click += new System.EventHandler(this.btnRestoreIcon_Click);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.Blue;
            this.lblState.Location = new System.Drawing.Point(37, 71);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(31, 12);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "就绪";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 101);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.btnRestoreIcon);
            this.Controls.Add(this.btnSaveIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "桌面图标位置保存与恢复";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIcon;
        private System.Windows.Forms.Button btnRestoreIcon;
        private System.Windows.Forms.Label lblState;
    }
}

