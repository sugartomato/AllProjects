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
using WinForm = System.Windows.Forms;
using ZS.Common;
using Word = Microsoft.Office.Interop.Word;
using WordTools = Microsoft.Office.Tools.Word;

namespace ZS.WordAddIn.UserControls
{
    /// <summary>
    /// BatchInsertImages.xaml 的交互逻辑
    /// </summary>
    public partial class frmBatchInsertImages : WPFControls.WindowBase
    {

        private Word.Application m_WordApp = Globals.ThisAddIn.Application;

        public frmBatchInsertImages()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        private void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            // 注册事件
            m_WordApp.DocumentChange += M_WordApp_DocumentChange;
            m_WordApp.WindowActivate += M_WordApp_WindowActivate;
            m_WordApp.WindowDeactivate += M_WordApp_WindowDeactivate;
        }

        private void M_WordApp_WindowDeactivate(Word.Document Doc, Word.Window Wn)
        {
            this.Topmost = false;
        }

        private void M_WordApp_WindowActivate(Word.Document Doc, Word.Window Wn)
        {
            this.Topmost = true;
        }

        private void M_WordApp_DocumentChange()
        {
            
        }

        #region 选择-插入图片

        private void OnClick_SelectPicture(object sender, RoutedEventArgs e)
        {
            try
            {
                // 选择文件
                WinForm.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
                ofd.Filter = "图片文件（.jpg;*.png;*.gif）|*.jpg;*.png;*.gif";
                ofd.Multiselect = true;
                ofd.Title = "选择图片";

                if (ofd.ShowDialog() == WinForm.DialogResult.OK)
                {
                    // 加载图片到ListView
                    //MessageBox.Show(ofd.FileNames.Length.ToString());
                    listImages.ItemsSource = ofd.FileNames;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        /// <summary>
        /// 插入图片到文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_InsertPicture(object sender, RoutedEventArgs e)
        {

            // http://software-solutions-online.com/word-vba-insert-images/

            object _start = 0;
            object _end = 0;
            Word.Range _sel = m_WordApp.ActiveDocument.Range(ref _start, ref _end);
            _sel.Select();

            // 设置纸张方向，统一设置为横向
            // TODO 需要做调整。根据图片尺寸来调整纸张方向
            m_WordApp.Selection.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

            // 设置页面边距
            // 上下左右四个边距
            m_WordApp.ActiveDocument.PageSetup.TopMargin = m_WordApp.CentimetersToPoints((float)0.25);
            m_WordApp.ActiveDocument.PageSetup.LeftMargin = m_WordApp.CentimetersToPoints((float)0.25);
            m_WordApp.ActiveDocument.PageSetup.RightMargin = m_WordApp.CentimetersToPoints((float)0.25);
            m_WordApp.ActiveDocument.PageSetup.BottomMargin = m_WordApp.CentimetersToPoints((float)0.25);

            // 遍历处理图片
            if (listImages.Items.Count > 0)
            {
                foreach (var item in listImages.Items)
                {
                    m_WordApp.Selection.InsertNewPage();

                    // 获取图片的尺寸
                    System.Drawing.Size imgSize = ZS.Common.Drawing.Image.GetSize(item.ToString());

                    if (imgSize == null)
                    {
                        // 做尺寸获取的错误处理
                        continue;
                    }
                    m_WordApp.Selection.InlineShapes.AddPicture(item.ToString());
                }
            }

            DocumentHelper.SaveAsPDF(m_WordApp.ActiveDocument);
        }

        #endregion

        #region 异常处理

        /// <summary>
        /// 错误处理
        /// </summary>
        /// <param name="ex"></param>
        private void HandleException(Exception ex)
        {
            MessageBox.Show(ex.JoinWithInnerExMessage(), "执行错误！", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #endregion

    }
}
