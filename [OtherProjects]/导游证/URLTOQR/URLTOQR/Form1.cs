using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;

namespace URLTOQR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode code = encoder.Encode(txtURL.Text);
            Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer render = new Gma.QrCodeNet.Encoding.Windows.Render.GraphicsRenderer(new Gma.QrCodeNet.Encoding.Windows.Render.FixedModuleSize(5, Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two), Brushes.Black, Brushes.White);
            using (System.IO.Stream s = new System.IO.MemoryStream())
            {
                render.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Png, s);
                Image img = Image.FromStream(s);
                pictureBox1.Image = img;
            }

            //using (System.IO.FileStream s = new System.IO.FileStream("c:\\1.png", System.IO.FileMode.Create))
            //{
            //    render.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Png, s);
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // 获取图片
                pictureBox1.Image.Save(fbd.SelectedPath + "\\qrc.jpg");
                MessageBox.Show("保存完成！");
            }


        }
    }
}
