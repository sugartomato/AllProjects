namespace ZS.Common.Win32Test.TestForm
{
    partial class frmReg
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
            if (disposing && (components != null))
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
            this.txtSubKeys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxRootKeys = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRegModifyTime = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSubKeys
            // 
            this.txtSubKeys.Location = new System.Drawing.Point(107, 54);
            this.txtSubKeys.Name = "txtSubKeys";
            this.txtSubKeys.Size = new System.Drawing.Size(355, 21);
            this.txtSubKeys.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "子健（不含根）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "根键";
            // 
            // cbxRootKeys
            // 
            this.cbxRootKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRootKeys.FormattingEnabled = true;
            this.cbxRootKeys.Items.AddRange(new object[] {
            "HKCU",
            "HKLM",
            "HKCR",
            "HKU"});
            this.cbxRootKeys.Location = new System.Drawing.Point(107, 16);
            this.cbxRootKeys.Name = "cbxRootKeys";
            this.cbxRootKeys.Size = new System.Drawing.Size(121, 20);
            this.cbxRootKeys.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "获取修改时间";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRegModifyTime
            // 
            this.txtRegModifyTime.Location = new System.Drawing.Point(118, 98);
            this.txtRegModifyTime.Name = "txtRegModifyTime";
            this.txtRegModifyTime.Size = new System.Drawing.Size(202, 21);
            this.txtRegModifyTime.TabIndex = 5;
            // 
            // frmReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 531);
            this.Controls.Add(this.txtRegModifyTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxRootKeys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubKeys);
            this.Name = "frmReg";
            this.Text = "frmReg";
            this.Load += new System.EventHandler(this.frmReg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubKeys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxRootKeys;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRegModifyTime;
    }
}