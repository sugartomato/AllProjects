namespace ZSExcelAddIn.Controls
{
	partial class frmFocus
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
            this.components = new System.ComponentModel.Container();
            this.panelY = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelX = new System.Windows.Forms.Panel();
            this.timerCheckPosition = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelY
            // 
            this.panelY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelY.Location = new System.Drawing.Point(124, 16);
            this.panelY.Name = "panelY";
            this.panelY.Size = new System.Drawing.Size(10, 422);
            this.panelY.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.panelX);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(800, 450);
            this.panelMain.TabIndex = 1;
            // 
            // panelX
            // 
            this.panelX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelX.Location = new System.Drawing.Point(54, 190);
            this.panelX.Name = "panelX";
            this.panelX.Size = new System.Drawing.Size(200, 18);
            this.panelX.TabIndex = 0;
            // 
            // timerCheckPosition
            // 
            this.timerCheckPosition.Interval = 30;
            this.timerCheckPosition.Tick += new System.EventHandler(this.timerCheckPosition_Tick);
            // 
            // frmFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelY);
            this.Controls.Add(this.panelMain);
            this.Name = "frmFocus";
            this.Text = "frmFocus";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmFocus_Load);
            this.ResizeEnd += new System.EventHandler(this.frmFocus_ResizeEnd);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelY;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Timer timerCheckPosition;
		private System.Windows.Forms.Panel panelX;
	}
}