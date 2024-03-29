﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZSExcelAddIn.Controls.CustomPans
{
    public partial class MainPanHost : UserControl
    {

        private MainPan rf = null;
        public MainPanHost()
        {
            InitializeComponent();
            rf = new MainPan();
            elementHost1.Child = rf;
        }
        
        public Microsoft.Office.Interop.Excel.Workbook BindWorkbook
        {
            set
            {
                rf.BindWorkbook = value;
            }
        }

        public void WriteConsole(string info)
        {
            if (rf != null)
            {
                rf.ConsoleText = info;
            }
        }

    }


}
