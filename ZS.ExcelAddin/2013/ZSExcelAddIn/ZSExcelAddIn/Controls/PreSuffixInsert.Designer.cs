namespace ZSExcelAddIn.Controls
{
    partial class PreSuffixInsert
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
            this.chkPre = new System.Windows.Forms.CheckBox();
            this.chkSuffix = new System.Windows.Forms.CheckBox();
            this.txtPre = new System.Windows.Forms.TextBox();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.chkSameAsPre = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkIgnorEmpryCell = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rangeSelector1 = new ZSExcelAddIn.Controls.RangeSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblState = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkPre
            // 
            this.chkPre.AutoSize = true;
            this.chkPre.Location = new System.Drawing.Point(6, 22);
            this.chkPre.Name = "chkPre";
            this.chkPre.Size = new System.Drawing.Size(48, 16);
            this.chkPre.TabIndex = 0;
            this.chkPre.Text = "前缀";
            this.chkPre.UseVisualStyleBackColor = true;
            this.chkPre.CheckedChanged += new System.EventHandler(this.chkPre_CheckedChanged);
            // 
            // chkSuffix
            // 
            this.chkSuffix.AutoSize = true;
            this.chkSuffix.Location = new System.Drawing.Point(6, 49);
            this.chkSuffix.Name = "chkSuffix";
            this.chkSuffix.Size = new System.Drawing.Size(48, 16);
            this.chkSuffix.TabIndex = 1;
            this.chkSuffix.Text = "后缀";
            this.chkSuffix.UseVisualStyleBackColor = true;
            this.chkSuffix.CheckedChanged += new System.EventHandler(this.chkSuffix_CheckedChanged);
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(60, 20);
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(315, 21);
            this.txtPre.TabIndex = 3;
            this.txtPre.TextChanged += new System.EventHandler(this.txtPre_TextChanged);
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(60, 47);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(315, 21);
            this.txtSuffix.TabIndex = 4;
            // 
            // chkSameAsPre
            // 
            this.chkSameAsPre.AutoSize = true;
            this.chkSameAsPre.Location = new System.Drawing.Point(380, 49);
            this.chkSameAsPre.Name = "chkSameAsPre";
            this.chkSameAsPre.Size = new System.Drawing.Size(60, 16);
            this.chkSameAsPre.TabIndex = 5;
            this.chkSameAsPre.Text = "同前缀";
            this.chkSameAsPre.UseVisualStyleBackColor = true;
            this.chkSameAsPre.CheckedChanged += new System.EventHandler(this.chkSameAsPre_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(143, 150);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "执行添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.OnClick_DoAdd);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkIgnorEmpryCell
            // 
            this.chkIgnorEmpryCell.AutoSize = true;
            this.chkIgnorEmpryCell.Checked = true;
            this.chkIgnorEmpryCell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIgnorEmpryCell.Location = new System.Drawing.Point(6, 101);
            this.chkIgnorEmpryCell.Name = "chkIgnorEmpryCell";
            this.chkIgnorEmpryCell.Size = new System.Drawing.Size(96, 16);
            this.chkIgnorEmpryCell.TabIndex = 8;
            this.chkIgnorEmpryCell.Text = "忽略空单元格";
            this.chkIgnorEmpryCell.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(249, 150);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 35);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "执行移除(&D)";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.OnClick_DoRemove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "目标区域：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkPre);
            this.groupBox1.Controls.Add(this.rangeSelector1);
            this.groupBox1.Controls.Add(this.chkSuffix);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPre);
            this.groupBox1.Controls.Add(this.txtSuffix);
            this.groupBox1.Controls.Add(this.chkIgnorEmpryCell);
            this.groupBox1.Controls.Add(this.chkSameAsPre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 132);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // rangeSelector1
            // 
            this.rangeSelector1.Address = "";
            this.rangeSelector1.Location = new System.Drawing.Point(60, 74);
            this.rangeSelector1.Name = "rangeSelector1";
            this.rangeSelector1.Size = new System.Drawing.Size(315, 21);
            this.rangeSelector1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "label2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 191);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(467, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblState
            // 
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(59, 17);
            this.lblState.Text = "处理状态";
            // 
            // PreSuffixInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 213);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreSuffixInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "前后缀插入设置";
            this.Load += new System.EventHandler(this.PreSuffixInsert_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkPre;
        private System.Windows.Forms.CheckBox chkSuffix;
        private System.Windows.Forms.TextBox txtPre;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.CheckBox chkSameAsPre;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkIgnorEmpryCell;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private RangeSelector rangeSelector1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblState;
    }
}