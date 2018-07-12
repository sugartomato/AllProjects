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
            this.listConnIDS = new System.Windows.Forms.ListBox();
            this.txtCurrentMac = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetMac = new System.Windows.Forms.TextBox();
            this.btnGenerateMac = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listConnIDS
            // 
            this.listConnIDS.FormattingEnabled = true;
            this.listConnIDS.ItemHeight = 12;
            this.listConnIDS.Location = new System.Drawing.Point(12, 12);
            this.listConnIDS.Name = "listConnIDS";
            this.listConnIDS.Size = new System.Drawing.Size(262, 136);
            this.listConnIDS.TabIndex = 0;
            this.listConnIDS.SelectedIndexChanged += new System.EventHandler(this.listConnIDS_SelectedIndexChanged);
            // 
            // txtCurrentMac
            // 
            this.txtCurrentMac.Location = new System.Drawing.Point(77, 164);
            this.txtCurrentMac.Name = "txtCurrentMac";
            this.txtCurrentMac.Size = new System.Drawing.Size(120, 21);
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
            this.txtTargetMac.Size = new System.Drawing.Size(120, 21);
            this.txtTargetMac.TabIndex = 3;
            // 
            // btnGenerateMac
            // 
            this.btnGenerateMac.Location = new System.Drawing.Point(199, 193);
            this.btnGenerateMac.Name = "btnGenerateMac";
            this.btnGenerateMac.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateMac.TabIndex = 5;
            this.btnGenerateMac.Text = "随机生成";
            this.btnGenerateMac.UseVisualStyleBackColor = true;
            this.btnGenerateMac.Click += new System.EventHandler(this.btnGenerateMac_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(104, 232);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(83, 45);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "修改并重连";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "关闭";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 292);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnGenerateMac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTargetMac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentMac);
            this.Controls.Add(this.listConnIDS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAC地址修改器";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

