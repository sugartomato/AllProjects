﻿namespace ZS.Common.Win32Test.TestForm
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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 33);
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
            this.button2.Location = new System.Drawing.Point(93, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "WM_GETTEXT ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.Location = new System.Drawing.Point(12, 89);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.Size = new System.Drawing.Size(289, 222);
            this.txtConsole.TabIndex = 4;
            // 
            // frmWindowsMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 357);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtWindowTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmWindowsMessages";
            this.Text = "frmWindowsMessages";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWindowTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtConsole;
    }
}