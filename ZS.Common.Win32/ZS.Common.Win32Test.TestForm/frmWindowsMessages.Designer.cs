namespace ZS.Common.Win32Test.TestForm
{
    partial class frmWindowsMessages
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtWindowTitle = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txtConsole = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.txtWindowHandle = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.rbtByText = new System.Windows.Forms.RadioButton();
			this.rbtByHandle = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 161);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "窗口标题";
			// 
			// txtWindowTitle
			// 
			this.txtWindowTitle.Location = new System.Drawing.Point(71, 6);
			this.txtWindowTitle.Name = "txtWindowTitle";
			this.txtWindowTitle.Size = new System.Drawing.Size(230, 21);
			this.txtWindowTitle.TabIndex = 2;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(93, 146);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "WM_GETTEXT ";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtConsole
			// 
			this.txtConsole.AllowDrop = true;
			this.txtConsole.Location = new System.Drawing.Point(12, 263);
			this.txtConsole.Multiline = true;
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.Size = new System.Drawing.Size(132, 222);
			this.txtConsole.TabIndex = 4;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(494, 128);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "钩子";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(348, 229);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowTemplate.Height = 23;
			this.dataGridView1.Size = new System.Drawing.Size(257, 256);
			this.dataGridView1.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "窗口句柄";
			// 
			// txtWindowHandle
			// 
			this.txtWindowHandle.Location = new System.Drawing.Point(71, 33);
			this.txtWindowHandle.Name = "txtWindowHandle";
			this.txtWindowHandle.Size = new System.Drawing.Size(230, 21);
			this.txtWindowHandle.TabIndex = 8;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(12, 60);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(105, 23);
			this.button4.TabIndex = 9;
			this.button4.Text = "发鼠标左键单击";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// rbtByText
			// 
			this.rbtByText.AutoSize = true;
			this.rbtByText.Location = new System.Drawing.Point(333, 9);
			this.rbtByText.Name = "rbtByText";
			this.rbtByText.Size = new System.Drawing.Size(83, 16);
			this.rbtByText.TabIndex = 10;
			this.rbtByText.Text = "按窗口标题";
			this.rbtByText.UseVisualStyleBackColor = true;
			// 
			// rbtByHandle
			// 
			this.rbtByHandle.AutoSize = true;
			this.rbtByHandle.Checked = true;
			this.rbtByHandle.Location = new System.Drawing.Point(434, 9);
			this.rbtByHandle.Name = "rbtByHandle";
			this.rbtByHandle.Size = new System.Drawing.Size(83, 16);
			this.rbtByHandle.TabIndex = 11;
			this.rbtByHandle.TabStop = true;
			this.rbtByHandle.Text = "按窗口句柄";
			this.rbtByHandle.UseVisualStyleBackColor = true;
			this.rbtByHandle.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// frmWindowsMessages
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 497);
			this.Controls.Add(this.rbtByHandle);
			this.Controls.Add(this.rbtByText);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.txtWindowHandle);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.txtConsole);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.txtWindowTitle);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "frmWindowsMessages";
			this.Text = "消息测试";
			this.Load += new System.EventHandler(this.frmWindowsMessages_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtWindowHandle;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.RadioButton rbtByText;
		private System.Windows.Forms.RadioButton rbtByHandle;
	}
}