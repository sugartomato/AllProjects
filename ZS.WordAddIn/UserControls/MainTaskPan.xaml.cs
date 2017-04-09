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
using Word = Microsoft.Office.Interop.Word;

namespace ZS.WordAddIn.UserControls
{
    /// <summary>
    /// Interaction logic for MainTaskPan.xaml
    /// </summary>
    public partial class MainTaskPan : UserControl
    {

        private DocumentHelper m_DocHelper = null;

        public MainTaskPan()
        {
            InitializeComponent();

        }

        public Word.Document WordDocument { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(WordDocument != null)
            {
                txtTitle.Text = WordDocument.Name + "|" + WordDocument.Path;
                m_DocHelper = new DocumentHelper(WordDocument);
            }
            else
            {
                txtTitle.Text = "未得到文档对象！";
            }

            // 加载样式
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri("/ZS.WPFControls;component/Styles/Default/Style.xaml", UriKind.Relative);
            //this.Resources.MergedDictionaries.Add(rd);

            // 显示选项卡勾选状态处理

        }

        /// <summary>
        /// 段落操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick_Paragraph(object sender, RoutedEventArgs e)
        {
            try
            {
                if(sender == null)
                    return;

                if(sender.GetType() == typeof(Button))
                {
                    switch((sender as Button).Name)
                    {
                        case "BTN_PG_SelLastPG":
                            if(WordDocument == null)
                            {
                                MessageBox.Show("文档对象为空！");
                                return;
                            }
                            WordDocument.Paragraphs.Last.Range.Select();
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WordDocument.DeleteAllComments();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ListData.ItemsSource = m_DocHelper.Paragraph_GetAll();
        }

        private void ListData_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object obj = ListData.SelectedItem;

            DocumentHelper.Paragraph p;

            if(obj != null)
            {
                p = (DocumentHelper.Paragraph)obj;
                p.Rang.Select();
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            m_DocHelper.Shape_GetAllPicture();
        }

        private void OnClick_InsertShapeImage(object sender, RoutedEventArgs e)
        {
            string img = txtImage.Text;
            object linkToFile = false;
            object saveWithDocument = true;
            object left = 0;
            object top = 0;
            object width = 100;
            object height = 100;
            object anchor = null;
            WordDocument.Shapes.AddPicture(img); //, ref linkToFile, ref saveWithDocument, ref left,ref top,ref width,ref height,ref anchor
        }

        private void OnClick_OpenUrl(Object sender, RoutedEventArgs e)
        {
            WB_Main.Navigate(TB_BrowserURL.Text);
        }

        private void OnClick_InvokeScript(Object sender, RoutedEventArgs e)
        {
            WB_Main.InvokeScript("textFun");
        }


        private void OnClick_ListBookMarks(Object sender, RoutedEventArgs e)
        {
            if(WordDocument == null)
                return;

            if(WordDocument.Bookmarks == null || WordDocument.Bookmarks.Count == 0)
                return;

            foreach(Word.Bookmark bm in WordDocument.Bookmarks)
            {
                BM_List_BookMarks.Items.Add(bm.Name + bm.Range.Text);
            }
        }

        private void OnClick_ReplaceBookmarkContent(Object sender, RoutedEventArgs e)
        {

        }

        // 复制书签内容
        private void OnClick_BK_CopyBK(Object sender, RoutedEventArgs e)
        {
            try
            {

                if(WordDocument == null)
                    return;

                if(WordDocument.Bookmarks == null || WordDocument.Bookmarks.Count == 0)
                    return;

                Word.Range source = WordDocument.Bookmarks[1].Range.FormattedText;

                for(Int32 i = 0; i < 4; i++)
                {
                    WordDocument.Paragraphs.Last.Range.Select();
                    Globals.ThisAddIn.Application.Selection.InsertBreak(Type: Word.WdBreakType.wdLineBreak);
                    WordDocument.Paragraphs.Last.Range.Select();
                    Word.Range x = source;
                    x.Text += i;
                    Globals.ThisAddIn.Application.Selection.FormattedText = x;
                    
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BM_List_BookMarks_MouseDoubleClick(Object sender, MouseButtonEventArgs e)
        {
            object obj = ListData.SelectedItem;

            MessageBox.Show(obj.ToString());

            return;
            DocumentHelper.Paragraph p;

            if(obj != null)
            {
                p = (DocumentHelper.Paragraph)obj;
                p.Rang.Select();
            }
        }

        private void OnClick_Test_GetUserInfo(object sender, RoutedEventArgs e)
        {

            foreach(Word.Paragraph p in WordDocument.Paragraphs)
            {
                if(p.Range.Text.Length > 5)
                {
                    string[] arrInfo = p.Range.Text.Split('，');
                    if(arrInfo.Length > 0)
                    {
                        foreach(string s in arrInfo)
                        {
                            Test_List_Info.Items.Add(s);
                        }
                    }
                }
            }

        }

        private void OnClick_ReadOutLine(Object sender, RoutedEventArgs e)
        {
            foreach(Word.Paragraph p in WordDocument.Paragraphs)
            {
                switch(p.Format.OutlineLevel)
                {
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel1:
                        List_OutLine.Items.Add("1级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel2:
                        List_OutLine.Items.Add("2级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel3:
                        List_OutLine.Items.Add("3级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel4:
                        List_OutLine.Items.Add("4级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel5:
                        List_OutLine.Items.Add("5级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevel6:
                        List_OutLine.Items.Add("6级大纲：" + p.Range.Text);
                        break;
                    case Microsoft.Office.Interop.Word.WdOutlineLevel.wdOutlineLevelBodyText:
                        List_OutLine.Items.Add("正文：" + p.Range.Text);
                        break;

                }
            }
        }

        private void OnClick_SortParagraphs(object sender, RoutedEventArgs e)
        {
            Word.ListParagraphs list = WordDocument.ListParagraphs;
            MessageBox.Show(list.Count.ToString());
        }

        private void ShowWordItem_Checked(Object sender, RoutedEventArgs e)
        {
            CheckBox ctrl = (CheckBox)sender;
            Boolean isChecked = (Boolean)ctrl.IsChecked;
            switch(ctrl.Tag.ToString())
            {
                case "Ruler":
                    WordDocument.Application.ActiveWindow.DisplayRulers = isChecked;
                    break;
                case "Gridlines":
                    break;

            }
        }


        private void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void Button_Click_3(Object sender, RoutedEventArgs e)
        {
            //WordDocument.Application.ActiveWindow.UsableWidth
        }

    }




}
