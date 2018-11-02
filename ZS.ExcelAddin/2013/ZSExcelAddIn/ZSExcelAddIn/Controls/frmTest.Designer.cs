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
			// frmTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(865, 514);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtSheetName);
			this.Name = "frmTest";
			this.Text = "frmTest";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtSheetName;
		private System.Windows.Forms.Button button1;
	}
}