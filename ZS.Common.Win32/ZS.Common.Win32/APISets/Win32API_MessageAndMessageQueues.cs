using System;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {


        /// <summary>
        /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
        /// To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function. To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.
        /// </summary>
        /// <param name="hwnd">
        ///     [in][Type: HWND]
        ///     A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.
        ///     Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of lesser or equal integrity level.
        /// </param>
        /// <param name="Msg">
        ///     [in][Type: UINT]
        ///     The message to be sent.
        ///     For lists of the system-provided messages, see System-Defined Messages.
        /// </param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns>
        ///    [Type: LRESULT]
        ///    The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd,Int32 Msg, Int32 wParam, Int32 lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="Msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd, Int32 Msg, Int32 wParam, System.Text.StringBuilder lParam);

        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd, Int32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hwnd, Int32 Msg, Int32 wParam, IntPtr lParam);
		[DllImport("User32.dll")]
		public static extern Int32 SendMessage(IntPtr hwnd, Int32 msg, IntPtr wParam, String lParam);


    }
}
