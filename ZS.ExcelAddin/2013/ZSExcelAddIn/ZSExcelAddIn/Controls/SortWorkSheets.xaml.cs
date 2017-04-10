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
using System.Data;

namespace ZSExcelAddIn.Controls
{
    /// <summary>
    /// Interaction logic for SortWorkSheets.xaml
    /// </summary>
    public partial class SortWorkSheets : Window
    {
        public SortWorkSheets()
        {
            InitializeComponent();
            this.Loaded += SortWorkSheets_Loaded;
            ZS_BTN_OK.Click += new RoutedEventHandler(Button_Click);
        }

        private void SortWorkSheets_Loaded(object sender, RoutedEventArgs e)
        {
            // 加载工作表数据
            TTTT.Inlines.Add(new Run("这是代码添加的！") { FontWeight = FontWeights.DemiBold});


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            
        }
    }
}
