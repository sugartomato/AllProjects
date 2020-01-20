using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MSExcel = Microsoft.Office.Interop.Excel;

namespace ZSExcelAddIn.Controls.CustomPans
{
    /// <summary>
    /// Interaction logic for Console.xaml
    /// </summary>
    public partial class MainPan : UserControl
    {

        #region 初始化
        public MainPan()
        {
            InitializeComponent();
            // 注册一个事件，让工作表活动时，刷新工作表列表
            Globals.ThisAddIn.Application.SheetActivate += Application_SheetActivate;
            Globals.ThisAddIn.Application.SheetDeactivate += Application_SheetDeactivate;
            //Globals.ThisAddIn.Application.SheetSelectionChange += Application_SheetSelectionChange;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //ZS_Text_Console.Document.text;
            LoadSheetsList();
            ZS_Tab_Console.IsSelected = false;
        }
        #endregion

        private void Application_SheetSelectionChange(object Sh, MSExcel.Range Target)
        {
            //LoadSheetsList();
        }

        private void Application_SheetDeactivate(object Sh)
        {
            //LoadSheetsList();
        }

        private void Application_SheetActivate(object Sh)
        {
            //LoadSheetsList();
        }

        Int32 _newMessageCount = 0;

        public string ConsoleText
        {
            get
            {
                //return ZS_Text_Console.Text;
                TextRange txt = new TextRange(ZS_Text_Console.Document.ContentStart, ZS_Text_Console.Document.ContentEnd);
                return txt.Text;
            }
            set
            {
                // 设置历史记录的颜色
                ZS_Text_Console.SelectAll();
                ZS_Text_Console.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Yellow);

                Paragraph p = new Paragraph();

                Run runSeparaotr = new Run("=".PadRight(20, '=') + "\r");
                p.Inlines.Add(runSeparaotr);

                Run runTime = new Run(System.DateTime.Now + " " + System.DateTime.Now.Millisecond.ToString() + "\r") { FontStyle = FontStyles.Italic };
                runTime.FontStyle = FontStyles.Italic;
                p.Inlines.Add(runTime);

                Run runMsgContent = new Run(value);
                p.Inlines.Add(runMsgContent);


                p.Foreground = Brushes.LightGreen;
                ZS_Text_Console.Document.Blocks.Add(p);

                //ZS_Text_Console.Text += "\r\n" + "=".PadRight(20, '=');
                //ZS_Text_Console.Text += "\r\n" + System.DateTime.Now + " " + System.DateTime.Now.Millisecond.ToString() + "\r\n" + value;

                // 将内容滚动到最新的地方
                ZS_Text_Console.ScrollToEnd();

                if (!ZS_Tab_Console.IsSelected)
                {
                    _newMessageCount += 1;
                    ZS_Text_InfoCount.Text = _newMessageCount.ToString();
                }

            }
        }


        #region 工作表列表

        private void LoadSheetsList()
        {
            try
            {
                MSExcel._Worksheet xlSheet = null;
                XLSheets sheetList = new XLSheets();
                if (_propBindWorkbook == null) return;
                sheetList.SheetName = _propBindWorkbook.Name;

                //MessageBox.Show(Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Count.ToString());
                if (_propBindWorkbook.Worksheets.Count > 0)
                {

                    int i = 0;
                    for (i = 1; i <= _propBindWorkbook.Worksheets.Count; ++i)
                    {
                        xlSheet = (MSExcel._Worksheet)_propBindWorkbook.Worksheets[i];
                        string name = xlSheet.Name;
                        XLSheets tmpObj = new XLSheets();
                        tmpObj.SheetName = name;

                        SolidColorBrush backGroundColor = Brushes.Transparent;
                        // 标签颜色
                        string color = ((object)xlSheet.Tab.Color).ToString();
                        Int32 intColor;
                        if (Int32.TryParse(color, out intColor))
                        {
                            // 得到的是长度为4的一个byte数组。顺序是RGBA
                            Byte[] bytes = BitConverter.GetBytes(intColor);

                            backGroundColor = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, bytes[0], bytes[1], bytes[2]));
                            tmpObj.BackGround = backGroundColor.ToString();

                            WriteConsole("获取并且转换之后的工作表标签背景色：" + backGroundColor.Color.ToString(), false);

                            // TODO 理解这两句的处理原理
                            //int argb = (intColor >> 16) | (intColor & 0xFF) << 16 | (intColor & 0x00FF00);
                            //System.Drawing.Color sc = System.Drawing.Color.FromArgb(argb);

                        }

                        sheetList.Items.Add(tmpObj);
                    }
                }

                ZS_Tree_SheetList.Items.Clear();
                ZS_Tree_SheetList.Items.Add(sheetList);

                // 展开Tree
                TreeViewItem rootItem = ZS_Tree_SheetList.ItemContainerGenerator.ContainerFromItem(ZS_Tree_SheetList.Items[0]) as TreeViewItem;
                if (rootItem != null && rootItem.Items.Count > 0)
                {
                    rootItem.IsExpanded = true;
                }


                ZS_Tree_SheetList.UpdateLayout();

                // 选中与活动工作表同名的选项
                foreach (var m in rootItem.Items)
                {
                    XLSheets s = m as XLSheets;
                    if (s.SheetName == Common.GetActiveSheetName())
                    {
                        TreeViewItem selItem = rootItem.ItemContainerGenerator.ContainerFromItem(m) as TreeViewItem;
                        selItem.IsSelected = true;
                        selItem.Focus();
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                WriteConsole(ex.Message + ex.StackTrace, true);
            }

        }

        /// <summary>
        /// 工作表列表菜单树双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZS_Tree_SheetList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object o = ZS_Tree_SheetList.SelectedItem;
                if (o != null)
                {
                    XLSheets x = o as XLSheets;
                    ((MSExcel.Worksheet)_propBindWorkbook.Worksheets[x.SheetName]).Activate();
                }

            }
            catch (Exception ex)
            {
                WriteConsole(ex.Message + ex.StackTrace, true);
            }
        }

        private MSExcel.Workbook _propBindWorkbook = null;
        /// <summary>
        /// 该面板控件绑定的工作簿对象。
        /// </summary>
        public MSExcel.Workbook BindWorkbook
        {
            set
            {
                _propBindWorkbook = value;
            }
        } 

        #endregion

        #region 消息输出

        private void WriteConsole(string msg, bool switchTab)
        {
            this.ConsoleText = msg;
            if (switchTab)
            {
                ZS_Tab_Console.IsSelected = true;
            }
        }

        #endregion

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem item = (TabItem)ZS_Tab_Main.SelectedItem;
            if (item.Name == "ZS_Tab_Console")
            {
                ZS_Text_InfoCount.Text = "";
                _newMessageCount = 0;
            }
        }
    }

    public partial class XLSheets : Common.TreeViewItemBase
    {

        public XLSheets()
        {
            this.Items = new ObservableCollection<XLSheets>();
        }

        public string SheetName { get; set; }
        public string BackGround { get; set; }

        public ObservableCollection<XLSheets> Items { get; set; }


    }



}
