using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace KK.WechatAuto
{
    public static class DataGridViewEx
    {

        public static void DoubleBufferedGrid(this DataGridView grid, Boolean flag)
        {
            Type t = grid.GetType();
            PropertyInfo pi = t.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(grid, flag, null);
        }


    }
}
