namespace KK.FileWatcher
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
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(12, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(318, 21);
            this.txtFolder.TabIndex = 0;
            // 
            // btnSelFolder
            // 
            this.btnSelFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelFolder.Location = new System.Drawing.Point(336, 12);
            this.btnSelFolder.Name = "btnSelFolder";
            this.btnSelFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelFolder.TabIndex = 1;
            this.btnSelFolder.Text = "选择目录";
            this.btnSelFolder.UseVisualStyleBackColor = true;
            this.btnSelFolder.Click += new System.EventHandler(this.btnSelFolder_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 61);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(12, 39);
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
            this.chkWatchCreate.Location = new System.Drawing.Point(114, 39);
            this.chkWatchCreate.Name = "chkWatchCreate";
            this.chkWatchCreate.Size = new System.Drawing.Size(48, 16);
            this.chkWatchCreate.TabIndex = 6;
            this.chkWatchCreate.Text = "创建";
            this.chkWatchCreate.UseVisualStyleBackColor = true;
            // 
            // chkWatchChange
            // 
            this.chkWatchChange.AutoSize = true;
            this.chkWatchChange.Location = new System.Drawing.Point(168, 39);
            this.chkWatchChange.Name = "chkWatchChange";
            this.chkWatchChange.Size = new System.Drawing.Size(48, 16);
            this.chkWatchChange.TabIndex = 7;
            this.chkWatchChange.Text = "修改";
            this.chkWatchChange.UseVisualStyleBackColor = true;
            // 
            // chkWatchDelete
            // 
            this.chkWatchDelete.AutoSize = true;
            this.chkWatchDelete.Location = new System.Drawing.Point(222, 39);
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
            this.txtConsole.Location = new System.Drawing.Point(12, 90);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(399, 190);
            this.txtConsole.TabIndex = 9;
            this.txtConsole.Text = "";
            // 
            // chkWatchRename
            // 
            this.chkWatchRename.AutoSize = true;
            this.chkWatchRename.Location = new System.Drawing.Point(276, 39);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 270);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(423, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblIsRunning
            // 
            this.lblIsRunning.Name = "lblIsRunning";
            this.lblIsRunning.Size = new System.Drawing.Size(32, 17);
            this.lblIsRunning.Text = "停止";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 292);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkWatchRename);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.chkWatchDelete);
            this.Controls.Add(this.chkWatchChange);
            this.Controls.Add(this.chkWatchCreate);
            this.Controls.Add(this.chkTopMost);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSelFolder);
            this.Controls.Add(this.txtFolder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}

