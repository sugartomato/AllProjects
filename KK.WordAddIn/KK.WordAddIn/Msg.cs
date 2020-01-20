using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WordAddIn
{
    public class Msg
    {

        public static void ShowError(String msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
        }

        public static void ShowInfo(String msg)
        {
            System.Windows.Forms.MessageBox.Show(msg);
        }
    }
}
