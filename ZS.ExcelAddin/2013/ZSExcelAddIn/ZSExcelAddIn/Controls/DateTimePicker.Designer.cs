namespace ZSExcelAddIn.Controls
{
    partial class DateTimePicker
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
            this.objTimePicker = new System.Windows.Forms.DateTimePicker();
            this.objDatePicker = new System.Windows.Forms.MonthCalendar();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkSelectTime = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // objTimePicker
            // 
            this.objTimePicker.CustomFormat = "HH:mm:ss";
            this.objTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.objTimePicker.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.objTimePicker.Location = new System.Drawing.Point(31, 192);
            this.objTimePicker.Name = "objTimePicker";
            this.objTimePicker.ShowUpDown = true;
            this.objTimePicker.Size = new System.Drawing.Size(76, 21);
            this.objTimePicker.TabIndex = 0;
            // 
            // objDatePicker
            // 
            this.objDatePicker.Location = new System.Drawing.Point(1, 1);
            this.objDatePicker.Name = "objDatePicker";
            this.objDatePicker.ShowWeekNumbers = true;
            this.objDatePicker.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(163, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定(O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkSelectTime
            // 
            this.chkSelectTime.AutoSize = true;
            this.chkSelectTime.Checked = true;
            this.chkSelectTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSelectTime.Location = new System.Drawing.Point(10, 196);
            this.chkSelectTime.Name = "chkSelectTime";
            this.chkSelectTime.Size = new System.Drawing.Size(15, 14);
            this.chkSelectTime.TabIndex = 3;
            this.chkSelectTime.UseVisualStyleBackColor = true;
            this.chkSelectTime.CheckedChanged += new System.EventHandler(this.chkSelectTime_CheckedChanged);
            // 
            // DateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 228);
            this.Controls.Add(this.chkSelectTime);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.objDatePicker);
            this.Controls.Add(this.objTimePicker);
            this.Name = "DateTimePicker";
            this.Text = "DateTimePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker objTimePicker;
        private System.Windows.Forms.MonthCalendar objDatePicker;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkSelectTime;
    }
}