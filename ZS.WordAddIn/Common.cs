using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZS.WordAddIn
{
    public class Common
    {

        public static System.Drawing.Point Get_SelectionTextLocation()
        {
            int left;
            int top;
            int width;
            int height;
            Globals.ThisAddIn.Application.ActiveWindow.GetPoint(out left, out top, out width, out height, Globals.ThisAddIn.Application.Selection.Range);

            return new System.Drawing.Point(left, top);


        }


    }
}
