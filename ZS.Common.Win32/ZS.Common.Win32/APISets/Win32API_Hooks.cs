using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
	public partial class API
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="nCode">
		/// [in][Type:int]
		///     Specifies whether the hook procedure must process the message. 
		///     If nCode is HC_ACTION, the hook procedure must process the message. If nCode is less than zero, the hook procedure must pass the message to the CallNextHookEx function without further processing and must return the value returned by CallNextHookEx.
		/// </param>
		/// <param name="wParam">
		/// [in][Type:WPARAM]
		///     Specifies whether the message was sent by the current thread. If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
		/// </param>
		/// <param name="lParam">
		/// [in][Type::PARAM]
		///     A pointer to a CWPSTRUCT structure that contains details about the message.
		/// </param>
		/// <returns></returns>
		public delegate Int32 HookProcDelegate(Int32 nCode, Int32 wParam, IntPtr lParam);
		//public delegate Int32 HookProc(Int32 nCode, Int32 wParam, Message lParam);

		/// <summary>
		/// Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the system for certain types of events. These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
		/// </summary>
		/// <param name="idHook">
		/// [in][Type:int]
		///     The type of hook procedure to be installed. This parameter can be one of the following values. 
		/// </param>
		/// <param name="lpfn">
		/// [in][Type:HOOKPROC]
		///     A pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL. Otherwise, lpfn can point to a hook procedure in the code associated with the current process.
		/// </param>
		/// <param name="hMod">
		/// [in][Type:HINSTANCE]
		///     A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and if the hook procedure is within the code associated with the current process.
		/// </param>
		/// <param name="dwThreadId">
		/// [in][Type:DWORD]
		/// The identifier of the thread with which the hook procedure is to be associated. For desktop apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same desktop as the calling thread. For Windows Store apps, see the Remarks section.
		/// </param>
		/// <returns>
		/// [Type: HHOOK]
		/// If the function succeeds, the return value is the handle to the hook procedure.
		/// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
		/// </returns>
		/// <link>https://msdn.microsoft.com/en-us/library/ms644990(VS.85).aspx</link>
		[DllImport("User32.dll", SetLastError = true)]
		public static extern Int32 SetWindowsHookEx(WindowsHookType idHook, HookProcDelegate lpfn, IntPtr hMod, Int32 dwThreadId);

		/// <summary>
		/// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
		/// </summary>
		/// <param name="hhk">
		/// A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to SetWindowsHookEx.
		/// </param>
		/// <returns>
		/// [Type: BOOL]
		///     If the function succeeds, the return value is nonzero.
		///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		/// <link>https://msdn.microsoft.com/en-us/library/ms644993(v=vs.85).aspx</link>
		[DllImport("User32.dll", SetLastError = true)]
		public static extern Boolean UnhookWindowsHookEx(Int32 hhk);

		/// <summary>
		/// Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this function either before or after processing the hook information.
		/// </summary>
		/// <param name="idHook"></param>
		/// <param name="nCode"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		[DllImport("User32.dll", SetLastError = true)]
		public static extern Int32 CallNextHookEx(Int32 idHook, Int32 nCode, Int32 wParam, IntPtr lParam);


		/// <summary>
		/// 钩子类型定义
		/// </summary>
		public enum WindowsHookType
		{
			/// <summary>
			/// Installs a hook procedure that monitors messages before the system sends them to the destination window procedure. For more information, see the CallWndProc hook procedure.
			/// </summary>
			WH_CALLWNDPROC = 4,
			/// <summary>
			/// Installs a hook procedure that monitors messages after they have been processed by the destination window procedure. For more information, see the CallWndRetProc hook procedure.
			/// </summary>
			WH_CALLWNDPROCRET = 12,
			/// <summary>
			/// Installs a hook procedure that receives notifications useful to a CBT application. For more information, see the CBTProc hook procedure.
			/// </summary>
			WH_CBT = 5,
			WH_DEBUG = 9,
			WH_FOREGROUNDIDLE = 11,
            /// <summary>
            /// Installs a hook procedure that monitors messages posted to a message queue. 
            /// For more information, see the GetMsgProc hook procedure.
            /// https://msdn.microsoft.com/en-us/library/ms644981(v=VS.85).aspx
            /// </summary>
			WH_GETMESSAGE = 3,
			WH_JOURNALPLAYBACK = 1,
			WH_JOURNALRECORD = 0,
			WH_KEYBOARD = 2,
			WH_KEYBOARD_LL = 13,
			WH_MOUSE = 7,
			WH_MOUSE_LL = 14,
			/// <summary>
			/// Installs a hook procedure that monitors messages generated as a result of an input event in a dialog box, message box, menu, or scroll bar. For more information, see the MessageProc hook procedure.
			/// </summary>
			WH_MSGFILTER = -1,
			/// <summary>
			/// Installs a hook procedure that receives notifications useful to shell applications. For more information, see the ShellProc hook procedure.
			/// </summary>
			WH_SHELL = 10,
			WH_SYSMSGFILTER = 6,

		}


		[StructLayout(LayoutKind.Sequential)]
		public class MouseLLHookStruct
		{
			public POINT pt;
			public Int32 mouseData;
			public Int32 flags;
			public Int32 time;
			public Int32 dwExtraInfo;
		}


        /// <summary>
        /// CWPSTRUCT 
        /// Defines the message parameters passed to a WH_CALLWNDPROC hook procedure, CallWndProc.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            /// <summary>
            /// Additional information about the message. The exact meaning depends on the message value.
            /// </summary>
            public IntPtr lParam { get; set; }
            /// <summary>
            /// Additional information about the message. The exact meaning depends on the message value.
            /// </summary>
            public IntPtr wParam { get; set; }
            /// <summary>
            /// The message.
            /// </summary>
            public UInt32 message { get; set; }
            /// <summary>
            /// A handle to the window to receive the message.
            /// </summary>
            public IntPtr hwnd { get; set; }
        }

    }
}
