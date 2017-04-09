using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.WordAddIn
{
    /// <summary>
    /// 系统气泡类
    /// </summary>
    public class NotifyHelper
    {

        private static System.Windows.Forms.NotifyIcon m_Notify;


        /// <summary>
        /// 显示系统气泡，提示指定的信息。
        /// </summary>
        /// <param name="message"></param>
        /// <param name="delay"></param>
        public static void Show(string message, Int32 delay = 3000)
        {

            Notify frm = new Notify();
            System.Windows.Forms.Screen sc = System.Windows.Forms.Screen.FromHandle((IntPtr)Globals.ThisAddIn.Application.ActiveWindow.Hwnd);
            frm.Show();
            frm.Location = new System.Drawing.Point(sc.WorkingArea.Width - frm.Width, sc.WorkingArea.Height - frm.Height);

            return;

            if (m_Notify == null)
            {
                m_Notify = new System.Windows.Forms.NotifyIcon();
                m_Notify.BalloonTipClosed += M_Notify_BalloonTipClosed;
            }
            m_Notify.Visible = true;
            m_Notify.Icon = System.Drawing.SystemIcons.Information;

            //m_Notify.BalloonTipTitle = "KK工具箱【Word】";
            //m_Notify.BalloonTipText = message;
            m_Notify.ShowBalloonTip(3000, "Biaoti ", message, System.Windows.Forms.ToolTipIcon.Info);

        }

        private static void M_Notify_BalloonTipClosed(object sender, EventArgs e)
        {
            m_Notify.Visible = false;
        }
    }
}
