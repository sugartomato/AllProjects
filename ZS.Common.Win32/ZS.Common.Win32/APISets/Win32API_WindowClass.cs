using System;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {

        /// <summary>
        /// Retrieves the name of the class to which the specified window belongs.
        /// </summary>
        /// <param name="hwnd">
        ///     [in][Type: HWND]
        ///     A handle to the window and, indirectly, the class to which the window belongs.
        /// </param>
        /// <param name="lpClassName">
        ///     [out][Type: LPTSTR]
        ///     The class name string.
        /// </param>
        /// <param name="nMaxCount">
        ///     [int][Type: int]
        ///     The length of the lpClassName buffer, in characters. The buffer must be large enough to include the terminating null character; otherwise, the class name string is truncated to nMaxCount-1 characters.
        /// </param>
        /// <returns>
        ///     [Type: int]
        ///     If the function succeeds, the return value is the number of characters copied to the buffer, not including the terminating null character.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <link>
        /// https://msdn.microsoft.com/en-us/library/ms633582(v=vs.85).aspx
        /// </link>
        [DllImport("User32.dll")]
        public static extern Int32 GetClassName(IntPtr hwnd, System.Text.StringBuilder lpClassName, Int32 nMaxCount);

        /// <summary>
        /// 获取指定句柄的Class名
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static String GetClassName(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(256);
            Int32 ret = API.GetClassName(hWnd, sb, sb.Capacity);
            if (ret != 0)
            {
                return sb.ToString();
            }
            else
            {
                Int32 errCode = GetLastError();
                throw new ApplicationException("获取失败，错误代码：" + errCode);
            }
        }


    }
}
