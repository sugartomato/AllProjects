using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.Common.Win32Test.TestForm
{
    public partial class frmForm_Menu_ContextMenu_ToolBar_StatusBarcs : Form
    {
        public frmForm_Menu_ContextMenu_ToolBar_StatusBarcs()
        {
            InitializeComponent();
        }

        private void frmForm_Menu_ContextMenu_ToolBar_StatusBarcs_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show();
        }

        private void frmForm_Menu_ContextMenu_ToolBar_StatusBarcs_Load(object sender, EventArgs e)
        {
            textBox1.ContextMenuStrip = contextMenuStrip2;
        }
    }
}
