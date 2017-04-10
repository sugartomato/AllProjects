using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZSExcelAddIn.Controls
{
    public partial class DateTimePicker : Form
    {
        public DateTimePicker()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.Text = "日期选择";
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            objDatePicker.MaxSelectionCount = 1;
            objDatePicker.ShowTodayCircle = false;

            objTimePicker.Value = DateTime.Now;
            objTimePicker.Show();
        }

        private DateTime? _propDate = null;
        /// <summary>
        /// 选择的日期时间
        /// </summary>
        public DateTime? Date { get { return _propDate; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectTime.Checked)
                {
                    string date = objDatePicker.SelectionStart.Date.ToString("yyyy-MM-dd");
                    string time = objTimePicker.Value.ToString("HH:mm:ss");
                    MessageBox.Show(date + " " + time);
                    this._propDate = DateTime.Parse(date + " " + time);
                }
                else
                {
                    this._propDate = objDatePicker.SelectionStart.Date;
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkSelectTime_CheckedChanged(object sender, EventArgs e)
        {
            objTimePicker.Enabled = chkSelectTime.Checked;
        }
    }
}
