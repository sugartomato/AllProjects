using System;
using System.Runtime.InteropServices;

namespace ZS.WPFControls
{
    internal static class WinAPI
    {

        /// <summary>
        /// The MonitorFromWindow function retrieves a handle to the display monitor that has the largest area of intersection with the bounding rectangle of a specified window.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="flage"></param>
        /// <returns></returns>
        [DllImport("user32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flage);

        public const int MONITOR_DEFAULTTONEAREST = 0x00000002;
    }
}
