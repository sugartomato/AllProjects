using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {

        [DllImport(DLLNameDef.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean FileTimeToSystemTime([In] ref System.Runtime.InteropServices.ComTypes.FILETIME lpFileTime, out _SYSTEMTIME lpSystemTime);


        [StructLayout(LayoutKind.Sequential)]
        public class _SYSTEMTIME
        {
            public Int32 wYear { get; set; }
            public Int32 wMonth { get; set; }
            public Int32 wDayOfWeek { get; set; }
            public Int32 wDay { get; set; }
            public Int32 wHour { get; set; }
            public Int32 wMinute { get; set; }
            public Int32 wSecond { get; set; }
            public Int32 wMilliseconds { get; set; }

            public override string ToString()
            {
                return String.Format("{0}-{1}-{2} {3}:{4}:{5} {6}", wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
            }
        }
    }
}
