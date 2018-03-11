using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {

        #region 错误消息

        /// <summary>
        /// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <returns></returns>
        /// <link>https://msdn.microsoft.com/en-us/library/ms679360(VS.85).aspx</link>
        [DllImport("Kernel32.dll")]
        public static extern Int32 GetLastError();

        #endregion


    }
}
