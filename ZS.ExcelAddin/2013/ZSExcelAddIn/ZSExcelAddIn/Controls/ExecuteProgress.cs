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
    public partial class ExecuteProgress : Form
    {
        public ExecuteProgress()
        {
            InitializeComponent();
        }


        public Int32 Percentage {
            set
            {

                if (value < 0) value = 0;
                if (value > 100) value = 100;

                this.progressBar1.Value = value;
                this.label1.Text = value.ToString() + "%";

                if (_propAutoCloseAfterComplete)
                {
                    if (value == 100)
                    {
                        this.Close();
                    }
                }
            } }


        private Boolean _propAutoCloseAfterComplete = true;
        /// <summary>
        /// 是否在进度条加载完成之后自动关闭
        /// </summary>
        public Boolean AutoCloseAfterComplete
        {
            set
            {
                _propAutoCloseAfterComplete = value;
            }
        }

        private void ExecuteProgress_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
