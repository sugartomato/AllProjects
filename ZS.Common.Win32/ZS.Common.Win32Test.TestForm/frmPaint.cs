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
    public partial class frmPaint : Form
    {
        public frmPaint()
        {
            InitializeComponent();
        }

        Boolean m_IsDrag = false;
        Rectangle m_Rec = new Rectangle(new Point(0, 0), new Size(0, 0));
        Point m_StartPt;

        private void frmPaint_MouseDown(Object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                m_IsDrag = true;
            }

            m_StartPt = (sender as Control).PointToScreen(new Point(e.X, e.Y));
        }

        private void frmPaint_MouseMove(Object sender, MouseEventArgs e)
        {
            if(m_IsDrag)
            {
                ControlPaint.DrawReversibleFrame(m_Rec, this.BackColor, FrameStyle.Dashed);
                Point endPoint = (sender as Control).PointToScreen(new Point(e.X, e.Y));
                int width = endPoint.X - m_StartPt.X;
                int height = endPoint.Y - m_StartPt.Y;
                m_Rec = new Rectangle(m_StartPt.X, m_StartPt.Y, width, height);
                ControlPaint.DrawReversibleFrame(m_Rec, this.BackColor, FrameStyle.Dashed);
            }
        }

        private void frmPaint_MouseUp(Object sender, MouseEventArgs e)
        {
            m_IsDrag = false;
            ControlPaint.DrawReversibleFrame(m_Rec, this.BackColor, FrameStyle.Dashed);
            Rectangle rectangle;
            //MessageBox.Show(Controls.Count.ToString());
            for(Int32 i = 0; i < Controls.Count; i++)
            {
                rectangle = Controls[i].RectangleToScreen(Controls[i].ClientRectangle);
                if(rectangle.IntersectsWith(m_Rec))
                {
                    Controls[i].BackColor = Color.Blue;
                }
            }
            m_Rec = new Rectangle(0, 0, 0, 0);
        }
    }
}
