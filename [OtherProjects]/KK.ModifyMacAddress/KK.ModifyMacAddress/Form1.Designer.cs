namespace KK.ModifyMacAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listConnIDS = new System.Windows.Forms.ListBox();
            this.txtCurrentMac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetMac = new System.Windows.Forms.TextBox();
            this.btnGenerateMac = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkOpenNetcpl = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslSystemInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listConnIDS
            // 
            this.listConnIDS.FormattingEnabled = true;
            this.listConnIDS.ItemHeight = 12;
            this.listConnIDS.Location = new System.Drawing.Point(12, 48);
            this.listConnIDS.Name = "listConnIDS";
            this.listConnIDS.Size = new System.Drawing.Size(317, 100);
            this.listConnIDS.TabIndex = 0;
            this.listConnIDS.SelectedIndexChanged += new System.EventHandler(this.listConnIDS_SelectedIndexChanged);
            // 
            // txtCurrentMac
            // 
            this.txtCurrentMac.Location = new System.Drawing.Point(77, 164);
            this.txtCurrentMac.Name = "txtCurrentMac";
            this.txtCurrentMac.ReadOnly = true;
            this.txtCurrentMac.Size = new System.Drawing.Size(110, 21);
            this.txtCurrentMac.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前MAC：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "修改MAC：";
            // 
            // txtTargetMac
            // 
            this.txtTargetMac.Location = new System.Drawing.Point(77, 195);
            this.txtTargetMac.Name = "txtTargetMac";
            this.txtTargetMac.Size = new System.Drawing.Size(110, 21);
            this.txtTargetMac.TabIndex = 3;
            // 
            // btnGenerateMac
            // 
            this.btnGenerateMac.Location = new System.Drawing.Point(193, 193);
            this.btnGenerateMac.Name = "btnGenerateMac";
            this.btnGenerateMac.Size = new System.Drawing.Size(81, 23);
            this.btnGenerateMac.TabIndex = 5;
            this.btnGenerateMac.Text = "随机生成(&R)";
            this.btnGenerateMac.UseVisualStyleBackColor = true;
            this.btnGenerateMac.Click += new System.EventHandler(this.btnGenerateMac_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChange.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChange.Location = new System.Drawing.Point(157, 259);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(83, 45);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "修改并重连";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(246, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "关闭(&C)";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(10, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "网卡列表";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(68, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 45);
            this.button2.TabIndex = 9;
            this.button2.Text = "恢复默认";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "必须以管理员身份运行";
            // 
            // chkOpenNetcpl
            // 
            this.chkOpenNetcpl.AutoSize = true;
            this.chkOpenNetcpl.Checked = true;
            this.chkOpenNetcpl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpenNetcpl.Location = new System.Drawing.Point(12, 222);
            this.chkOpenNetcpl.Name = "chkOpenNetcpl";
            this.chkOpenNetcpl.Size = new System.Drawing.Size(156, 16);
            this.chkOpenNetcpl.TabIndex = 11;
            this.chkOpenNetcpl.Text = "设置完成后打开网络连接";
            this.chkOpenNetcpl.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSystemInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(341, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslSystemInfo
            // 
            this.tsslSystemInfo.Name = "tsslSystemInfo";
            this.tsslSystemInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 329);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chkOpenNetcpl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnGenerateMac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTargetMac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentMac);
            this.Controls.Add(this.listConnIDS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAC地址修改器 - DHD";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listConnIDS;
        private System.Windows.Forms.TextBox txtCurrentMac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetMac;
        private System.Windows.Forms.Button btnGenerateMac;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkOpenNetcpl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslSystemInfo;
    }
}

