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
    public partial class frmListBox : Form
    {
        public frmListBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            listBox1.Items.Add("AB");
            listBox1.Items.Add("CD");
            listBox1.Items.Add("EF");
            listBox1.Items.Add("GH");
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.AppendText(e.KeyChar.ToString() + "\r\n");
        }

        private Boolean isSkip = false;
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    MessageBox.Show(listBox1.SelectedItems.ToString());
                }

                isSkip = true;
            }
            else
            {
                isSkip = false;
            }

        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void listBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (isSkip) e.Handled = true;
        }
    }
}
