using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZSExcelAddIn.Controls
{
    /// <summary>
    /// Interaction logic for ExportSheetsToSingleFile.xaml
    /// </summary>
    public partial class ExportSheetsToSingleFile : Window
    {
        public ExportSheetsToSingleFile()
        {
            InitializeComponent();

            // 绑定事件
            ZS_BTN_SelectFolder.Click += ZS_BTN_SelectFolder_Click;
        }

        private void ZS_BTN_SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ZS_LBL_SaveFolder.Content = fbd.SelectedPath;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ZS_LBL_SaveFolder.Content = Globals.ThisAddIn.Application.ActiveWorkbook.Path;

                // 文件名前缀
                ZS_Text_FileNamePrefix.Text = Globals.ThisAddIn.Application.ActiveWorkbook.Name;
                if (ZS_Text_FileNamePrefix.Text.IndexOf('.') > 0)
                {
                    ZS_Text_FileNamePrefix.Text = ZS_Text_FileNamePrefix.Text.Substring(0, ZS_Text_FileNamePrefix.Text.LastIndexOf('.'));
                }

                // 加载工作表列表
                List<String> sheetNames = Common.GetSheetNamesOfActiveBook();
                if (sheetNames != null & sheetNames.Count > 0)
                {
                    foreach (var sn in sheetNames)
                    {
                        CheckBox chk = new CheckBox();
                        //ZS_LIST_SheetName.
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BTN_DoExport_Click(object sender, RoutedEventArgs e)
        {

            string _saveFolder = string.Empty;
            string _subFolder = string.Empty;
            string _bookName = string.Empty;    // 工作簿名称，不包含文件后缀名
            string _fileNamePrefix = string.Empty;
            string _fileNameExt = string.Empty;

            Int32 i = 0;
            Microsoft.Office.Interop.Excel._Workbook _xlActiveBook = null;
            Microsoft.Office.Interop.Excel._Worksheet _xlSheet = null;
            Microsoft.Office.Interop.Excel._Workbook _xlTargetBook = null;
            Microsoft.Office.Interop.Excel._Worksheet _xlTargetSheet = null;


            try
            {
                // 设置按钮状态
                ZS_BTN_SelectFolder.IsEnabled = false;
                ZS_BTN_Exit.IsEnabled = false;
                ZS_BTN_DoExport.IsEnabled = false;

                _xlActiveBook = Globals.ThisAddIn.Application.ActiveWorkbook;

                // 文件后缀名
                if (_xlActiveBook.Name.Length > 0 && _xlActiveBook.Name.Contains(".x"))
                {
                    _fileNameExt = _xlActiveBook.Name.Substring(_xlActiveBook.Name.LastIndexOf('.'));
                }
                else
                {
                    _fileNameExt = string.Empty;
                }

                _saveFolder = ZS_LBL_SaveFolder.Content.ToString();
                // 检查目录是否存在
                if (!System.IO.Directory.Exists(_saveFolder))
                {
                    MessageBox.Show("未设置保存目录！");
                    return;
                }

                // 检查是否创建子目录，如果是，创建目录并且取得新的存储路径
                if ((bool)ZS_CHK_IsCreateSubFolder.IsChecked)
                {
                    _subFolder = _xlActiveBook.Name;
                    if (_subFolder.Trim().Length == 0)
                    {
                        _subFolder = System.Guid.NewGuid().ToString("N");
                    }
                    else
                    {
                        // 去掉后缀
                        if (_subFolder.IndexOf('.') > 0)
                        {
                            _subFolder = _subFolder.Substring(0, _subFolder.LastIndexOf('.'));
                        }
                    }
                    _saveFolder = _saveFolder + "\\" + _subFolder;
                    if (!System.IO.Directory.Exists(_saveFolder))
                    {
                        System.IO.Directory.CreateDirectory(_saveFolder);
                    }
                }

                // 检查文件名前缀设置
                if ((bool)ZS_CHK_IsAddWorkBookName.IsChecked)
                {
                    if (ZS_Text_FileNamePrefix.Text.Length == 0)
                    {
                        MessageBox.Show("请添加文件名前缀");
                        return;
                    }
                    _fileNamePrefix = ZS_Text_FileNamePrefix.Text + "_";
                }
                else
                {
                    _fileNamePrefix = string.Empty;
                }


                // 检查工作表个数


                Globals.ThisAddIn.Application.DisplayAlerts = false;
                Globals.ThisAddIn.Application.Visible = false;

                // 遍历工作表，执行导出
                for (i = 1; i <= _xlActiveBook.Worksheets.Count; ++i)
                {
                    _xlSheet = (Microsoft.Office.Interop.Excel._Worksheet)_xlActiveBook.Worksheets[i];
                    string saveFullName = _saveFolder + "\\" + _fileNamePrefix + _xlSheet.Name + ".xlsx";


                    // 创建新工作簿
                    _xlTargetBook = Globals.ThisAddIn.Application.Workbooks.Add();
                    
                    // 复制工作表
                    _xlTargetSheet = (Microsoft.Office.Interop.Excel._Worksheet)_xlTargetBook.Sheets[1];
                    _xlSheet.Copy(_xlTargetSheet);

                    // 删除多余的工作表
                    _xlTargetSheet.Delete();

                    // 删除已存在的工作簿
                    if (System.IO.File.Exists(saveFullName))
                    {
                        if ((bool)ZS_CHK_IsOverWrite.IsChecked)
                        {
                            System.IO.File.Delete(saveFullName);
                        }
                        else
                        {
                            saveFullName = saveFullName.Replace(_xlSheet.Name + ".xlsx", _xlSheet.Name + "_" + System.DateTime.Now.Millisecond.ToString() + ".xlsx");
                        }
                    }

                    // 保存工作簿
                    _xlTargetBook.SaveAs(saveFullName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing,
                        Type.Missing, Type.Missing
                       );

                    _xlTargetBook.Close(false);
                }


                MessageBox.Show("保存完成！");

                if ((bool)ZS_CHK_OpenFolderAfterFinish.IsChecked)
                {
                    System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                    psi.FileName = "Explorer.exe";
                    psi.Arguments = "/e,/select," + _saveFolder;
                    System.Diagnostics.Process.Start(psi);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                WriteRuntimeInfo(ex.Message + ex.StackTrace);
                System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
            }
            finally
            {
                ZS_BTN_SelectFolder.IsEnabled = true;
                ZS_BTN_Exit.IsEnabled = true;
                ZS_BTN_DoExport.IsEnabled = true;

                Globals.ThisAddIn.Application.DisplayAlerts = true;
                Globals.ThisAddIn.Application.Visible = true;

                if (_xlTargetBook != null)
                {
                    _xlTargetBook = null;
                }
            }
        }

        // 向当前窗口的调试信息界面写入信息
        private void WriteRuntimeInfo(string text)
        {
            if (_propRuntimeInfoControl != null) _propRuntimeInfoControl.WriteConsole(text);
        }
        private Controls.CustomPans.MainPanHost _propRuntimeInfoControl = null;
        public Controls.CustomPans.MainPanHost RuntimeInfoControl
        {
            set
            {
                _propRuntimeInfoControl = value;
            }
        }

        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
