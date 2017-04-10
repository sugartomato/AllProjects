using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSExcelAddIn
{
    public class Config
    {

        private static Boolean _propHightLightRowAndColumn = false;
       public static Boolean HightLightRowAndColumn {
            get
            {
                return _propHightLightRowAndColumn;
            }
            set
            {
                _propHightLightRowAndColumn = value;
            }
        }

        private static Int32 _propHightLightRowColumnColor = 4;
        public static Int32 HightLightRowColumnColor {
            get
            {
                return _propHightLightRowColumnColor;
            }
            set
            {
                _propHightLightRowColumnColor = value;
            }
        }


        public static Dictionary<string, Microsoft.Office.Tools.CustomTaskPane> TaskPans = new Dictionary<string, Microsoft.Office.Tools.CustomTaskPane>();
        public static Microsoft.Office.Tools.CustomTaskPane GetCustomTaskPane(String panID, string panTitle, System.Windows.Forms.UserControl ctrl)
        {
            string key = string.Format("{0}({1})",panID,Globals.ThisAddIn.Application.Hwnd);
            if (!TaskPans.ContainsKey(key))
            {
                var pan = Globals.ThisAddIn.CustomTaskPanes.Add(ctrl, panTitle);
                TaskPans[key] = pan;
            }
            return TaskPans[key];
        }

    }
}
