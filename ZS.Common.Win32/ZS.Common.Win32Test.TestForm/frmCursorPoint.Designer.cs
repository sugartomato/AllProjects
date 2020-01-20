namespace ZS.Common.Win32Test.TestForm
{
    partial class frmCursorPoint
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
            if(disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtX = new System.Windows.Forms.TextBox();
			this.txtY = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnTarget1 = new System.Windows.Forms.Button();
			this.btnTarget2 = new System.Windows.Forms.Button();
			this.btnTarget4 = new System.Windows.Forms.Button();
			this.btnTarget3 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.lblCursorPointStick = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.lblCursorPointGlobal = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(284, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "点击:";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 77);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "设置坐标";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtX
			// 
			this.txtX.Location = new System.Drawing.Point(12, 12);
			this.txtX.Name = "txtX";
			this.txtX.Size = new System.Drawing.Size(65, 21);
			this.txtX.TabIndex = 3;
			// 
			// txtY
			// 
			this.txtY.Location = new System.Drawing.Point(12, 39);
			this.txtY.Name = "txtY";
			this.txtY.Size = new System.Drawing.Size(65, 21);
			this.txtY.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 340);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "移动鼠标";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 106);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "鼠标点击";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(127, 68);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(150, 253);
			this.textBox1.TabIndex = 7;
			// 
			// btnTarget1
			// 
			this.btnTarget1.Location = new System.Drawing.Point(12, 159);
			this.btnTarget1.Name = "btnTarget1";
			this.btnTarget1.Size = new System.Drawing.Size(75, 23);
			this.btnTarget1.TabIndex = 8;
			this.btnTarget1.Text = "button5";
			this.btnTarget1.UseVisualStyleBackColor = true;
			this.btnTarget1.Click += new System.EventHandler(this.btnTarget2_Click);
			// 
			// btnTarget2
			// 
			this.btnTarget2.Location = new System.Drawing.Point(284, 77);
			this.btnTarget2.Name = "btnTarget2";
			this.btnTarget2.Size = new System.Drawing.Size(75, 23);
			this.btnTarget2.TabIndex = 9;
			this.btnTarget2.Text = "button5";
			this.btnTarget2.UseVisualStyleBackColor = true;
			this.btnTarget2.Click += new System.EventHandler(this.btnTarget2_Click);
			// 
			// btnTarget4
			// 
			this.btnTarget4.Location = new System.Drawing.Point(12, 217);
			this.btnTarget4.Name = "btnTarget4";
			this.btnTarget4.Size = new System.Drawing.Size(75, 23);
			this.btnTarget4.TabIndex = 10;
			this.btnTarget4.Text = "button5";
			this.btnTarget4.UseVisualStyleBackColor = true;
			this.btnTarget4.Click += new System.EventHandler(this.btnTarget2_Click);
			// 
			// btnTarget3
			// 
			this.btnTarget3.Location = new System.Drawing.Point(12, 188);
			this.btnTarget3.Name = "btnTarget3";
			this.btnTarget3.Size = new System.Drawing.Size(75, 23);
			this.btnTarget3.TabIndex = 11;
			this.btnTarget3.Text = "button5";
			this.btnTarget3.UseVisualStyleBackColor = true;
			this.btnTarget3.Click += new System.EventHandler(this.btnTarget2_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(12, 369);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 12;
			this.button5.Text = "移动鼠标2";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(107, 369);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
			this.numericUpDown1.TabIndex = 13;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblCursorPointStick
			// 
			this.lblCursorPointStick.AutoSize = true;
			this.lblCursorPointStick.Location = new System.Drawing.Point(416, 15);
			this.lblCursorPointStick.Name = "lblCursorPointStick";
			this.lblCursorPointStick.Size = new System.Drawing.Size(119, 12);
			this.lblCursorPointStick.TabIndex = 14;
			this.lblCursorPointStick.Text = "lblCursorPointStick";
			this.lblCursorPointStick.Click += new System.EventHandler(this.label2_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(418, 170);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 15;
			this.button6.Text = "注册钩子";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// lblCursorPointGlobal
			// 
			this.lblCursorPointGlobal.AutoSize = true;
			this.lblCursorPointGlobal.Location = new System.Drawing.Point(416, 35);
			this.lblCursorPointGlobal.Name = "lblCursorPointGlobal";
			this.lblCursorPointGlobal.Size = new System.Drawing.Size(41, 12);
			this.lblCursorPointGlobal.TabIndex = 16;
			this.lblCursorPointGlobal.Text = "label2";
			// 
			// frmCursorPoint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 495);
			this.Controls.Add(this.lblCursorPointGlobal);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.lblCursorPointStick);
			this.Controls.Add(this.numericUpDown1);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.btnTarget3);
			this.Controls.Add(this.btnTarget4);
			this.Controls.Add(this.btnTarget2);
			this.Controls.Add(this.btnTarget1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.txtY);
			this.Controls.Add(this.txtX);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "frmCursorPoint";
			this.Text = "frmCursorPoint";
			this.Load += new System.EventHandler(this.frmCursorPoint_Load);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmCursorPoint_MouseMove);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTarget1;
        private System.Windows.Forms.Button btnTarget2;
        private System.Windows.Forms.Button btnTarget4;
        private System.Windows.Forms.Button btnTarget3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label lblCursorPointStick;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label lblCursorPointGlobal;
	}
}