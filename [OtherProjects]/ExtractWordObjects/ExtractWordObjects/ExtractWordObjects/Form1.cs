using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;

namespace ExtractWordObjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Word文档|*.doc;*.docx";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            MSWord.Application wordApp = null;
            MSWord.Document wordDoc = null;
            try
            {
                // 获取文件保存的根目录
                string tmpFolderName = string.Empty;
                string rootPath = System.IO.Path.GetDirectoryName(txtFilePath.Text);
                rootPath = rootPath + "\\";
                // 启动文档
                wordApp = new MSWord.Application();
                wordApp.Visible = false;
                
                
                wordDoc = wordApp.Documents.Open(txtFilePath.Text);
                
                if (!IsHaveInlineObject(wordDoc))
                {
                    MessageBox.Show("文档中没有可提取的对象！");
                    return;
                }

                //MessageBox.Show(wordDoc.Name);
                // 先创建以该文件命名的目录
                tmpFolderName = rootPath + System.IO.Path.GetFileNameWithoutExtension(wordDoc.Name) + "_分项\\";
                if (!System.IO.Directory.Exists(tmpFolderName))
                {
                    System.IO.Directory.CreateDirectory(tmpFolderName);
                }

                ExtractInlineWord(wordDoc, tmpFolderName);

                //foreach (MSWord.InlineShape shape in wordDoc.InlineShapes)
                //{
                //    string fileType = shape.OLEFormat.ClassType;
                //    string fileName = shape.OLEFormat.IconLabel;
                //    shape.OLEFormat.ActivateAs(fileType);
                //    shape.OLEFormat.Open();
                //    MSWord.Document obj1 = shape.OLEFormat.Object;
                //    obj1.SaveAs(tmpFolderName + fileName);
                //    obj1.Close();
                //    obj1 = null;
                //}

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (wordDoc != null)
                {
                    wordDoc.Close(false);
                }
                if (wordApp != null)
                {
                    wordApp.Quit(false);
                }

                MessageBox.Show("处理完成！");
            }

        }


        private void ExtractInlineWord(MSWord.Document doc, string folder)
        {
            if (doc == null)
                return;

            doc.Application.Visible = false;

            if (!folder.EndsWith("\\"))
            {
                folder = folder + "\\";
            }

            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }

            // 获取所有内嵌word文档
            List<MSWord.InlineShape> wordObj = GetInlineWordObject(doc);

            // 如果doc包含内嵌，就遍历提取
            if (wordObj != null && wordObj.Count > 0)
            {
                //// 创建目录
                //string folderName = folder + System.IO.Path.GetFileNameWithoutExtension(parentFileName) + "\\";
                //if (!System.IO.Directory.Exists(folderName))
                //{
                //    System.IO.Directory.CreateDirectory(folderName);
                //}

                foreach (MSWord.InlineShape shape in wordObj)
                {
                    string fileType = shape.OLEFormat.ClassType;
                    string fileName = shape.OLEFormat.IconLabel;
                    shape.OLEFormat.ActivateAs(fileType);
                    shape.OLEFormat.Open();
                    MSWord.Document obj1 = shape.OLEFormat.Object;
                    if (IsHaveInlineObject(obj1))
                    {
                        ExtractInlineWord(obj1, folder + System.IO.Path.GetFileNameWithoutExtension(fileName) + "_分项");
                    }
                    obj1.SaveAs(folder + fileName);
                    obj1.Close();
                    obj1 = null;
                }
            }

            //// 另存doc文件
            //doc.SaveAs2(folder + doc);
            //doc.Close(false);

        }


        List<MSWord.InlineShape> GetInlineWordObject(MSWord.Document doc)
        {
            List<MSWord.InlineShape> result = new List<MSWord.InlineShape>();
            if (doc == null || doc.InlineShapes.Count == 0)
                return null;

            foreach (MSWord.InlineShape shape in doc.InlineShapes)
            {
                if (shape.OLEFormat != null && shape.OLEFormat.ClassType != null && shape.OLEFormat.ClassType.StartsWith("Word.Document"))
                {
                    result.Add(shape);
                }
            }

            return result;
        }

        Boolean IsHaveInlineObject(MSWord.Document doc)
        {
            List<MSWord.InlineShape> wordObjs = GetInlineWordObject(doc);
            if (wordObjs != null && wordObjs.Count > 0)
                return true;

            return false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBatchSaveToPDF frm = new frmBatchSaveToPDF();
            frm.Show();
        }
    }
}
