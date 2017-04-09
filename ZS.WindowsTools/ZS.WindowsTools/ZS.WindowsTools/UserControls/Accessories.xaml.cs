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

namespace ZS.WindowsTools.UserControls
{
    /// <summary>
    /// Interaction logic for Accessories.xaml
    /// </summary>
    public partial class Accessories : UserControl
    {
        public Accessories()
        {
            InitializeComponent();
        }

        #region GUID
        string _guidFormat = "N";
        string _guidCase = "U";
        private void ZS_BTN_CreateGUID_Click(object sender, RoutedEventArgs e)
        {
            string txtGUID = System.Guid.NewGuid().ToString(_guidFormat);
            if (_guidCase == "U")
            {
                txtGUID = txtGUID.ToUpper();
            }
            ZS_TXT_GUID.Text = txtGUID;
        }

        #endregion

        private void RadioButton_GUID_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;
            RadioButton rbt = sender as RadioButton;
            if (rbt.IsChecked != null && (bool)rbt.IsChecked)
            {
                _guidFormat = rbt.Tag.ToString();
            }
        }

        private void ZS_BTN_CopyGUID_Click(object sender, RoutedEventArgs e)
        {
            string txtGUID = ZS_TXT_GUID.Text;
            if (txtGUID.Length > 0)
            {
                System.Windows.Clipboard.SetText(txtGUID);
                MessageBox.Show("已复制到剪贴板！\r\n" + txtGUID);
            }
            else
            {
                MessageBox.Show("先点击生成按钮生成GUID！");
            }
        }

        private void RadioButton_Case_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == null) return;
            RadioButton rbt = sender as RadioButton;
            _guidCase = rbt.Tag.ToString();
        }
    }
}
