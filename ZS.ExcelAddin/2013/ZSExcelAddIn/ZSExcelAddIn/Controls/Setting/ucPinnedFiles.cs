using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZSExcelAddIn.Controls.Setting
{
    public partial class ucPinnedFiles : UserControl
    {
        public ucPinnedFiles()
        {
            InitializeComponent();
        }

        private List<Model.PinnedFile> m_PinnedFiles = new List<Model.PinnedFile>();

        /// <summary>
        /// 初始化过程中，加载设置里面的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucPinnedFiles_Load(object sender, EventArgs e)
        {
            try
            {
                // 初始化Datagridview
                InitGridview();

                m_PinnedFiles = Config.PinnedFiles;

                BindData();
            }
            catch (Exception ex)
            {
                Msg.ShowError("初始化固定文件设置控件失败：" + ex.Message + ex.StackTrace);
                return;
            }
        }


        private void InitGridview()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnDelete";
            btn.HeaderText = "删除";
            btn.DefaultCellStyle.NullValue = "删除";
            dgvMain.Columns.Add(btn);

            dgvMain.Columns.Add("fileName", "文件名");
            dgvMain.Columns.Add("filePath", "文件路径");
            dgvMain.Columns["fileName"].DataPropertyName = "FileName";
            dgvMain.Columns["filePath"].DataPropertyName = "FilePath";

            dgvMain.Columns.Add("mark", "Mark");
            dgvMain.Columns["mark"].DataPropertyName = "Mark";
            dgvMain.Columns["mark"].Visible = false;


        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Msg.ShowInfo(e.ColumnIndex + "_" + e.RowIndex);
                if (dgvMain.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    m_PinnedFiles.Remove(m_PinnedFiles.Find(x => x.Mark == Convert.ToString(dgvMain.Rows[e.RowIndex].Cells["Mark"].Value)));

                    BindData();
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        /// <summary>
        /// 执行保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Config.PinnedFiles = m_PinnedFiles;
                Config.SaveConfig();
                Msg.ShowSuccess("固定文件保存成功！");
            }
            catch (Exception ex)
            {
                Msg.ShowError(ex.Message);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Model.PinnedFile file = new Model.PinnedFile();
                file.FileName = System.IO.Path.GetFileName(ofd.FileName);
                file.FilePath = ofd.FileName;
                m_PinnedFiles.Add(file);

                BindData();
            }
        }


        private void BindData()
        {
            dgvMain.DataSource = null;
            dgvMain.DataSource = m_PinnedFiles;
            dgvMain.AutoResizeColumns();
        }
    }
}
