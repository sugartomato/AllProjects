using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.WordAddIn.UserControls
{
    public partial class MainTaskPanHost : UserControl
    {
        private Microsoft.Office.Interop.Word.Document m_Doc = null;
        public MainTaskPanHost()
        {
            InitializeComponent();
        }

        public MainTaskPanHost(Microsoft.Office.Interop.Word.Document doc)
            :this()
        {
            m_Doc = doc;
        }

        private void MainTaskPanHost_Load(object sender, EventArgs e)
        {
            try
            {
                MainTaskPan child = new MainTaskPan() { WordDocument = m_Doc };
                elementHost1.Child = child;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载自定义面板【MainTaskPan】失败：" + ex.Message);
            }
        }
    }
}
