namespace ZSExcelAddIn.Controls
{
    partial class RefEdit__
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnState = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(0, 0);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(220, 21);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Enter += new System.EventHandler(this.txtAddress_Enter);
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            this.txtAddress.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtAddress_PreviewKeyDown);
            // 
            // btnState
            // 
            this.btnState.Image = global::ZSExcelAddIn.Properties.Resources.RefEditMin;
            this.btnState.Location = new System.Drawing.Point(200, 1);
            this.btnState.Name = "btnState";
            this.btnState.Size = new System.Drawing.Size(19, 19);
            this.btnState.TabIndex = 1;
            this.btnState.UseVisualStyleBackColor = true;
            this.btnState.Click += new System.EventHandler(this.btnState_Click);
            // 
            // button1
            // 
            this.button1.Image = global::ZSExcelAddIn.Properties.Resources.RefEditMin;
            this.button1.Location = new System.Drawing.Point(200, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(19, 19);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 21);
            this.textBox1.TabIndex = 2;
            // 
            // RefEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnState);
            this.Controls.Add(this.txtAddress);
            this.Name = "RefEdit";
            this.Size = new System.Drawing.Size(220, 106);
            this.Load += new System.EventHandler(this.RefEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnState;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
