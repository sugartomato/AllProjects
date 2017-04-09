using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZS.WordAddIn.TestForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            DataTable dt = new DataTable();
            DataColumn clm1 = new DataColumn();
            clm1.Caption = "A列";
            dt.Columns.Add(clm1);


            DataColumn clm2 = new DataColumn();
            clm2.Caption = "B列";
            dt.Columns.Add(clm2);

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "2";
            dt.Rows.Add(dr);

            comboBox1.DataSource = dt;
            

        }


        
    }
}
