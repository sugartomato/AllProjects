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
    public partial class ucMapSearch : UserControl
    {
        public ucMapSearch()
        {
            InitializeComponent();
        }

        private void ucMapSearch_Load(object sender, EventArgs e)
        {
            try
            {

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
