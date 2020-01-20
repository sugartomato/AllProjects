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
            this.button5 = new System.Windows.Forms.Button();
            this.txtWindowHandle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWindowText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.targetWindow = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.cbxFlashWindowType = new System.Windows.Forms.ComboBox();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "枚举子窗口(按标题)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.Location = new System.Drawing.Point(12, 379);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(976, 207);
            this.txtConsole.TabIndex = 1;
            // 
            // txtWindowTitleA
            // 
            this.txtWindowTitleA.Location = new System.Drawing.Point(590, 247);
            this.txtWindowTitleA.Name = "txtWindowTitleA";
            this.txtWindowTitleA.Size = new System.Drawing.Size(241, 21);
            this.txtWindowTitleA.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(537, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "窗口名A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "窗口名B";
            // 
            // txtWindowTitleB
            // 
            this.txtWindowTitleB.Location = new System.Drawing.Point(590, 274);
            this.txtWindowTitleB.Name = "txtWindowTitleB";
            this.txtWindowTitleB.Size = new System.Drawing.Size(241, 21);
            this.txtWindowTitleB.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 173);
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
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(913, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "清空";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEnumWindows
            // 
            this.btnEnumWindows.Location = new System.Drawing.Point(12, 206);
            this.btnEnumWindows.Name = "btnEnumWindows";
            this.btnEnumWindows.Size = new System.Drawing.Size(201, 23);
            this.btnEnumWindows.TabIndex = 8;
            this.btnEnumWindows.Text = "遍历所有窗口，获取窗口标题";
            this.btnEnumWindows.UseVisualStyleBackColor = true;
            this.btnEnumWindows.Click += new System.EventHandler(this.btnEnumWindows_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 144);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "设置控件文字：";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtControlText
            // 
            this.txtControlText.Location = new System.Drawing.Point(124, 146);
            this.txtControlText.Name = "txtControlText";
            this.txtControlText.Size = new System.Drawing.Size(100, 21);
            this.txtControlText.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 78);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(222, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "开始WindowFromPoint(&Q)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtWindowHandle
            // 
            this.txtWindowHandle.Location = new System.Drawing.Point(69, 6);
            this.txtWindowHandle.Name = "txtWindowHandle";
            this.txtWindowHandle.Size = new System.Drawing.Size(176, 21);
            this.txtWindowHandle.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "窗口句柄";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "窗口标题";
            // 
            // txtWindowText
            // 
            this.txtWindowText.Location = new System.Drawing.Point(69, 30);
            this.txtWindowText.Name = "txtWindowText";
            this.txtWindowText.Size = new System.Drawing.Size(176, 21);
            this.txtWindowText.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(234, 78);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(222, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "停止WindowFromPoint(&W)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 86);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "枚举子窗口(按句柄)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 115);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 23);
            this.button8.TabIndex = 17;
            this.button8.Text = "获取窗口位置(句柄)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(162, 57);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(149, 23);
            this.button9.TabIndex = 18;
            this.button9.Text = "查找子窗口（包含标题）";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(318, 268);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(163, 21);
            this.txtSearchKey.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "关键字：";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 21;
            this.button10.Text = "设置";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.targetWindow);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Location = new System.Drawing.Point(12, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 124);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置窗口位置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "目标窗口：";
            // 
            // targetWindow
            // 
            this.targetWindow.Location = new System.Drawing.Point(82, 50);
            this.targetWindow.Name = "targetWindow";
            this.targetWindow.Size = new System.Drawing.Size(101, 21);
            this.targetWindow.TabIndex = 22;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(162, 86);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 23);
            this.button11.TabIndex = 23;
            this.button11.Text = "IsWindow";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(6, 49);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(222, 23);
            this.button12.TabIndex = 24;
            this.button12.Text = "开始ChildWindowFromPointEx(&B)";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(234, 49);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(222, 23);
            this.button13.TabIndex = 25;
            this.button13.Text = "停止ChildWindowFromPointEx(&C)";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(6, 20);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(222, 23);
            this.button14.TabIndex = 26;
            this.button14.Text = "开始RealChildWindowFromPoint(&T)";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(234, 20);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(222, 23);
            this.button15.TabIndex = 27;
            this.button15.Text = "停止RealChildWindowFromPoint(&Y)";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button16);
            this.groupBox2.Controls.Add(this.button17);
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(492, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 163);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 107);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(222, 23);
            this.button16.TabIndex = 28;
            this.button16.Text = "开始ChildWindowFromPoint(&E)";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(234, 107);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(222, 23);
            this.button17.TabIndex = 29;
            this.button17.Text = "停止ChildWindowFromPoint(&R)";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(251, 206);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 29;
            this.button18.Text = "闪烁窗口";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // cbxFlashWindowType
            // 
            this.cbxFlashWindowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFlashWindowType.FormattingEnabled = true;
            this.cbxFlashWindowType.Items.AddRange(new object[] {
            "1停止",
            "2全部",
            "3标题",
            "4任务栏（通知区域？）",
            "5闪烁直到FLASHW_STOP设置为True",
            "6闪烁直到窗口到前端"});
            this.cbxFlashWindowType.Location = new System.Drawing.Point(332, 206);
            this.cbxFlashWindowType.Name = "cbxFlashWindowType";
            this.cbxFlashWindowType.Size = new System.Drawing.Size(121, 20);
            this.cbxFlashWindowType.TabIndex = 30;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(914, 185);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(75, 23);
            this.button19.TabIndex = 31;
            this.button19.Text = "容器";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // frmWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 598);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.cbxFlashWindowType);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSearchKey);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWindowText);
            this.Controls.Add(this.txtWindowHandle);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TextBox txtWindowHandle;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtWindowText;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.TextBox txtSearchKey;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox targetWindow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.ComboBox cbxFlashWindowType;
        private System.Windows.Forms.Button button19;
    }
}