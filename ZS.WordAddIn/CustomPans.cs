using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.WordAddIn
{
    public class CustomPans
    {


        private static Dictionary<string, Microsoft.Office.Tools.CustomTaskPane> pans = new Dictionary<string, Microsoft.Office.Tools.CustomTaskPane>();

        /// <summary>
        /// 获取指定参数的CustomTaskPan
        /// </summary>
        /// <returns></returns>
        public static Boolean Exists(string key)
        {
            return pans.ContainsKey(key);
        }

        /// <summary>
        /// 添加一个自定义面面板
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="title">标题</param>
        /// <param name="ctrl">内部控件</param>
        /// <param name="visible">是否可见</param>
        /// <param name="visibleChanged">可见性委托</param>
        /// <returns></returns>
        public static Microsoft.Office.Tools.CustomTaskPane Add(string key,string title, System.Windows.Forms.UserControl ctrl, bool visible, EventHandler visibleChanged)
        {
            if (!Exists(key))
            {
                Microsoft.Office.Tools.CustomTaskPane pan = Globals.ThisAddIn.CustomTaskPanes.Add(ctrl, title);
                pan.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
                pan.DockPositionRestrict = Microsoft.Office.Core.MsoCTPDockPositionRestrict.msoCTPDockPositionRestrictNoChange;

                if (visibleChanged != null)
                {
                    pan.VisibleChanged += visibleChanged;
                }


                pans.Add(key,pan);

                pan.Width = 400;
                pan.Visible = visible;
                return pan;
            }
            else
            {
                return pans[key];
            }
        }

        /// <summary>
        /// 获取指定Key的自定义面板
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Microsoft.Office.Tools.CustomTaskPane Get(string key)
        {
            if (Exists(key))
            {
                return pans[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 设置pan的可见性
        /// </summary>
        /// <param name="key"></param>
        /// <param name="visible"></param>
        public static void SetVisible(string key, bool visible)
        {
            if (pans.ContainsKey(key))
            {
                pans[key].Visible = visible;
            }
        }
    }

}
