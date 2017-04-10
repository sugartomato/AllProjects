﻿using System;
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

namespace ZS.WPFControls
{
    /// <summary>
    /// WebBrowserX.xaml 的交互逻辑
    /// </summary>
    public partial class WebBrowserX : UserControl
    {
        public WebBrowserX()
        {
            InitializeComponent();
        }


        public void OnClick_OpenURL(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(txtURL.Text, UriKind.RelativeOrAbsolute);
            if(!uri.IsAbsoluteUri)
            {
                MessageBox.Show("地址必须是绝对地址。比如：http://www.microsoft.com");
                return;
            }

            wbMain.Navigate(uri);

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}
