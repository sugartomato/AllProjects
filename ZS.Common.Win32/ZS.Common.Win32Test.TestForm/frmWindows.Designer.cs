namespace ZS.Common.Win32Test.TestForm
{
    partial class frmWindows
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
			this.button1 = new System.Windows.Forms.Button();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.txtWindowTitleA = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtWindowTitleB = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btnEnumWindows = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.txtControlText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 128);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "枚举子窗口";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtConsole
			// 
			this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsole.Location = new System.Drawing.Point(12, 157);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConsole.Size = new System.Drawing.Size(752, 450);
			this.txtConsole.TabIndex = 1;
			// 
			// txtWindowTitleA
			// 
			this.txtWindowTitleA.Location = new System.Drawing.Point(63, 6);
			this.txtWindowTitleA.Name = "txtWindowTitleA";
			this.txtWindowTitleA.Size = new System.Drawing.Size(241, 21);
			this.txtWindowTitleA.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "窗口名A";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "窗口名B";
			// 
			// txtWindowTitleB
			// 
			this.txtWindowTitleB.Location = new System.Drawing.Point(63, 33);
			this.txtWindowTitleB.Name = "txtWindowTitleB";
			this.txtWindowTitleB.Size = new System.Drawing.Size(241, 21);
			this.txtWindowTitleB.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 99);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 6;
			this.button2.Text = "设置父窗口";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(689, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "清空";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// btnEnumWindows
			// 
			this.btnEnumWindows.Location = new System.Drawing.Point(12, 70);
			this.btnEnumWindows.Name = "btnEnumWindows";
			this.btnEnumWindows.Size = new System.Drawing.Size(158, 23);
			this.btnEnumWindows.TabIndex = 8;
			this.btnEnumWindows.Text = "遍历所有窗口，获取窗口标题";
			this.btnEnumWindows.UseVisualStyleBackColor = true;
			this.btnEnumWindows.Click += new System.EventHandler(this.btnEnumWindows_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(198, 70);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(106, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "设置控件文字：";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtControlText
			// 
			this.txtControlText.Location = new System.Drawing.Point(310, 70);
			this.txtControlText.Name = "txtControlText";
			this.txtControlText.Size = new System.Drawing.Size(100, 21);
			this.txtControlText.TabIndex = 10;
			// 
			// frmWindows
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 619);
			this.Controls.Add(this.txtControlText);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.btnEnumWindows);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtWindowTitleB);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtWindowTitleA);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.button1);
			this.Name = "frmWindows";
			this.Text = "frmWindows";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TextBox txtWindowTitleA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWindowTitleB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnEnumWindows;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtControlText;
	}
}