using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;

namespace ExtractWordObjects
{
    public partial class frmBatchSaveToPDF : Form
    {
        public frmBatchSaveToPDF()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MSWord.Application wordApp = null;
            MSWord.Document wordDoc = null;
            string[] files = System.IO.Directory.GetFiles(textBox1.Text);
            foreach (string file in files)
            {

                if (file.EndsWith(".doc") || file.EndsWith(".docx"))
                {
                    wordApp = new MSWord.Application();
                    wordApp.Visible = false;


                    wordDoc = wordApp.Documents.Open(file);
                    wordDoc.SaveAs2(file + ".pdf", MSWord.WdSaveFormat.wdFormatPDF);
                    wordDoc.Close(false);

                }
            }
        }
    }
}
