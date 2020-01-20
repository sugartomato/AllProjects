using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
   public partial class API
    {
        // ############################################################
        /// <summary>
        /// The ScreenToClient function converts the screen coordinates of a specified point on the screen to client-area coordinates.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Boolean ScreenToClient(IntPtr hwnd, ref POINT lpPoint);

    }
}
