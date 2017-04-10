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
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Markup;


namespace ZSExcelAddIn.Controls
{
    /// <summary>
    /// Interaction logic for MergeSheets.xaml
    /// </summary>
    public partial class MergeSheets : Window
    {
        public MergeSheets()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            FrameworkTemplate template = btnTest.Template;
            TXTControlTemplate.Text = template.ToString();

            XmlWriterSettings xmlSet = new XmlWriterSettings();
            xmlSet.Indent = true;
            xmlSet.IndentChars = new string(' ', 4);
            xmlSet.NewLineOnAttributes = true;

            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(sb, xmlSet);
            XamlWriter.Save(template, writer);
            TXTControlTemplate.Text = sb.ToString();

        }
    }
}
