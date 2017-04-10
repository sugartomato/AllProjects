using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn.Controls
{
    public partial class PreSuffixInsert : Form
    {

        private Excel.Application m_xlApp;
        private Excel.Workbook m_xlBook;
        private Excel.Worksheet m_xlSheet;

        /// <summary>
        /// 构造
        /// </summary>
        public PreSuffixInsert()
        {
            InitializeComponent();

            // 窗体设置
            this.ShowInTaskbar = false;
            this.ShowIcon = false;
            this.Text = "前后缀操作";
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;

            lblState.Text = string.Empty;
            lblState.ForeColor = Color.Red;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreSuffixInsert_Load(object sender, EventArgs e)
        {
            try
            {
                chkPre.Checked = true;
                chkSuffix.Checked = true;
                chkSameAsPre.Checked = true;

                // 读取Excel对象
                m_xlApp = Globals.ThisAddIn.Application;
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体加载错误：" + ex.Message);
                this.Close();
            }

        }


        #region 条件设置相关事件

        private void chkPre_CheckedChanged(object sender, EventArgs e)
        {
            txtPre.Enabled = chkPre.Checked;
        }

        private void chkSuffix_CheckedChanged(object sender, EventArgs e)
        {
            txtSuffix.Enabled = chkSuffix.Checked;
        }

        private void chkSameAsPre_CheckedChanged(object sender, EventArgs e)
        {
            txtSuffix.ReadOnly = chkSameAsPre.Checked;
        }

        #endregion


        private void btnOK_Click(object sender, EventArgs e)
        {

        }




        private string _propPrefix = string.Empty;
        /// <summary>
        /// 设置的前缀
        /// </summary>
        public string Prefix
        {
            get
            {
                return _propPrefix;
            }
        }

        private string _propSuffix = string.Empty;
        /// <summary>
        /// 设置的后缀
        /// </summary>
        public string Suffix
        {
            get
            {
                return _propSuffix;
            }
        }

        private Boolean _propIsIgnorEmpryCell;
        /// <summary>
        /// 是否跳过空的单元格
        /// </summary>
        public Boolean IsIgnorEmptyCell
        {
            get
            {
                _propIsIgnorEmpryCell = chkIgnorEmpryCell.Checked;
                return _propIsIgnorEmpryCell;
            }
        }

        /// <summary>
        /// 获取或者设置选择的区域地址
        /// </summary>
        public string Address
        {
            get
            {
                return rangeSelector1.Address; ;
            }
            set
            {
                rangeSelector1.Address = value;
            }
        }


        private void txtPre_TextChanged(object sender, EventArgs e)
        {
            if (chkSameAsPre.Checked)
            {
                txtSuffix.Text = txtPre.Text;
            }
        }


        /// <summary>
        /// 验证界面输入设置
        /// </summary>
        /// <returns></returns>
        public Boolean CheckInput()
        {

            _propPrefix = txtPre.Text;
            _propSuffix = txtSuffix.Text;

            // 检查地址的有效性
            if (this.Address == null || this.Address == "")
            {
                MessageBox.Show("请设置操作区域！");
                rangeSelector1.Focus();
                return false;
            }

            return true;
        }


        /// <summary>
        /// 指定区域添加前后缀的执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_DoAdd(object sender, EventArgs e)
        {
            int _cellCount = 0;
            try
            {
                if (!CheckInput()) return;

                m_xlSheet = m_xlApp.ActiveWorkbook.ActiveSheet as Excel.Worksheet;


                // 检查区域，将其余拆分成数组
                String[] rngs = this.Address.Split(',');

                foreach (string tmpRng in rngs)
                {
                    Excel.Range selRang = m_xlSheet.Range[tmpRng];

                    Int32 cellTotal = 0;
                    if (selRang != null && selRang.Cells.Count > 0)
                    {
                        cellTotal = selRang.Cells.Count;
                        for (Int32 i = 1; i <= cellTotal; i++)
                        {
                            _cellCount += 1;

                            // 主要任务处理
                            Excel.Range c = (Excel.Range)selRang.Cells[i];

                            string val = Convert.ToString(c.Value);
                            if (val == null || val.ToString().Length == 0)
                            {
                                if (this.IsIgnorEmptyCell) break;
                            }

                            val = this.Prefix + val + this.Suffix;
                            c.Value = val;

                            lblState.Text = "处理第【" + _cellCount.ToString() + "】个单元格；";
                            Application.DoEvents();

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("添加执行错误：" + ex.Message);
            }



        }

        /// <summary>
        /// 指定区域移除前后缀的执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_DoRemove(object sender, EventArgs e)
        {

            try
            {
                if (!CheckInput()) return;

                m_xlSheet = m_xlApp.ActiveWorkbook.ActiveSheet as Excel.Worksheet;

                // 检查区域，将其余拆分成数组
                String[] rngs = this.Address.Split(',');

                foreach (string tmpRng in rngs)
                {
                    Excel.Range selRang = m_xlSheet.Range[tmpRng];

                    Int32 cellTotal = 0;
                    if (selRang != null && selRang.Cells.Count > 0)
                    {
                        cellTotal = selRang.Cells.Count;
                        for (Int32 i = 1; i <= cellTotal; i++)
                        {
                            // 主要任务处理
                            Excel.Range c = (Excel.Range)selRang.Cells[i];

                            string val = Convert.ToString(c.Value);
                            if (val == null || val.ToString().Length == 0)
                            {
                                if (this.IsIgnorEmptyCell) break;
                            }

                            // 去头
                            if (val.StartsWith(this.Prefix))
                            {
                                val = val.Substring(this.Prefix.Length);
                            }
                            // 去尾
                            if (val.EndsWith(this.Suffix))
                            {
                                val = val.Substring(0, val.Length - this.Suffix.Length);
                            }

                            c.Value = val;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("移除执行错误：" + ex.Message);
            }


        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
