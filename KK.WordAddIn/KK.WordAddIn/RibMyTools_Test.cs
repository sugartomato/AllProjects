using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;

namespace KK.WordAddIn
{
    public partial class RibMyTools : Office.IRibbonExtensibility
    {

        public void OnClick_Test(Office.IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "KK_BTN_GetOutLine":
                    System.Windows.Forms.MessageBox.Show("1");
                    break;
                default:
                    break;
            }
        }

    }
}
