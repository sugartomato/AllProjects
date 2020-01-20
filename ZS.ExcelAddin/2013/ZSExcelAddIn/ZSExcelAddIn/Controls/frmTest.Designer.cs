namespace ZSExcelAddIn.Controls
{
	partial class frmTest
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
            this.txtSheetName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetFormula = new System.Windows.Forms.Button();
            this.lblFormula = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.txtCellID = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.btnSpecialString = new System.Windows.Forms.Button();
            this.txtSpecialStringResult = new System.Windows.Forms.TextBox();
            this.txtSpecialStringSource = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSheetName
            // 
            this.txtSheetName.Location = new System.Drawing.Point(12, 12);
            this.txtSheetName.Name = "txtSheetName";
            this.txtSheetName.Size = new System.Drawing.Size(100, 21);
            this.txtSheetName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "工作表是否存在";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 44);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 22);
            this.button2.TabIndex = 2;
            this.button2.Text = "获取当前Ribbon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "星期一",
            "星期二",
            "星期三",
            "星期四",
            "星期五",
            "星期六",
            "星期XX"});
            this.listBox1.Location = new System.Drawing.Point(12, 108);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(127, 268);
            this.listBox1.TabIndex = 3;
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // btnGetFormula
            // 
            this.btnGetFormula.Location = new System.Drawing.Point(284, 10);
            this.btnGetFormula.Name = "btnGetFormula";
            this.btnGetFormula.Size = new System.Drawing.Size(103, 23);
            this.btnGetFormula.TabIndex = 5;
            this.btnGetFormula.Text = "获取单元格公式";
            this.btnGetFormula.UseVisualStyleBackColor = true;
            this.btnGetFormula.Click += new System.EventHandler(this.btnGetFomula_Click);
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(393, 15);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(41, 12);
            this.lblFormula.TabIndex = 6;
            this.lblFormula.Text = "label2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(534, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "错误消息提醒";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(534, 218);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 22);
            this.button4.TabIndex = 8;
            this.button4.Text = "写消息面板";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(284, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "设置获取单元格ID";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtCellID
            // 
            this.txtCellID.Location = new System.Drawing.Point(418, 46);
            this.txtCellID.Name = "txtCellID";
            this.txtCellID.Size = new System.Drawing.Size(100, 21);
            this.txtCellID.TabIndex = 10;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(284, 73);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(128, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "获取单元格ID";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(284, 102);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(128, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "设置单元格ID";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkTopMost);
            this.groupBox1.Location = new System.Drawing.Point(746, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 164);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // chkTopMost
            // 
            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Checked = true;
            this.chkTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTopMost.Location = new System.Drawing.Point(6, 20);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(72, 16);
            this.chkTopMost.TabIndex = 0;
            this.chkTopMost.Text = "顶端显示";
            this.chkTopMost.UseVisualStyleBackColor = true;
            this.chkTopMost.CheckedChanged += new System.EventHandler(this.chkTopMost_CheckedChanged);
            // 
            // btnSpecialString
            // 
            this.btnSpecialString.Location = new System.Drawing.Point(404, 407);
            this.btnSpecialString.Name = "btnSpecialString";
            this.btnSpecialString.Size = new System.Drawing.Size(75, 23);
            this.btnSpecialString.TabIndex = 13;
            this.btnSpecialString.Text = "上下标字符";
            this.btnSpecialString.UseVisualStyleBackColor = true;
            this.btnSpecialString.Click += new System.EventHandler(this.btnSpecialString_Click);
            // 
            // txtSpecialStringResult
            // 
            this.txtSpecialStringResult.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSpecialStringResult.Location = new System.Drawing.Point(485, 439);
            this.txtSpecialStringResult.Name = "txtSpecialStringResult";
            this.txtSpecialStringResult.Size = new System.Drawing.Size(271, 24);
            this.txtSpecialStringResult.TabIndex = 14;
            // 
            // txtSpecialStringSource
            // 
            this.txtSpecialStringSource.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSpecialStringSource.Location = new System.Drawing.Point(485, 409);
            this.txtSpecialStringSource.Name = "txtSpecialStringSource";
            this.txtSpecialStringSource.Size = new System.Drawing.Size(271, 24);
            this.txtSpecialStringSource.TabIndex = 15;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(534, 261);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(109, 23);
            this.button8.TabIndex = 16;
            this.button8.Text = "当前单元格坐标";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(649, 266);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(41, 12);
            this.lblLocation.TabIndex = 17;
            this.lblLocation.Text = "label2";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(12, 407);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(117, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "执行Word外接";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 514);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.txtSpecialStringSource);
            this.Controls.Add(this.txtSpecialStringResult);
            this.Controls.Add(this.btnSpecialString);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtCellID);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.btnGetFormula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSheetName);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSheetName;
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetFormula;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtCellID;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.Button btnSpecialString;
        private System.Windows.Forms.TextBox txtSpecialStringResult;
        private System.Windows.Forms.TextBox txtSpecialStringSource;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button button9;
    }
}