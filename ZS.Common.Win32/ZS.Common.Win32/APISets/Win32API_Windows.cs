using System;
using System.Text;
namespace ZS.Common.Win32
{
    using System.Runtime.InteropServices;
    /// <summary>
    /// Win32API接口
    /// </summary>
    public partial class API
    {

        /// <summary>
        ///     Enables you to produce special effects when showing or hiding windows. There are four types of animation: roll, slide, collapse or expand, and alpha-blended fade.
        /// </summary>
        /// <param name="hwnd">
        ///     [in][Type: HWND]
        ///     A handle to the window to animate. The calling thread must own this window.
        /// </param>
        /// <param name="dwTime">
        ///     [in][Type: DWORD]
        ///     The time it takes to play the animation, in milliseconds. Typically, an animation takes 200 milliseconds to play.
        /// </param>
        /// <param name="dwFlags">
        ///     [in][Type: DWORD]
        ///     动画类型。可以组合使用，比如AW_ACTIVATE + AW_BLEND渐变显示，再用AW_HIDE + AW_BLEND渐变隐藏
        ///     The type of animation. This parameter can be one or more of the following values. Note that, by default, these flags take effect when showing a window. To take effect when hiding a window, use AW_HIDE and a logical OR operator with the appropriate flags.
        /// </param>
        /// <returns>
        ///     [Type: BOOL]
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. The function will fail in the following situations:
        ///         If the window is already visible and you are trying to show the window.
        ///         If the window is already hidden and you are trying to hide the window.
        ///         If there is no direction specified for the slide or roll animation.
        ///         When trying to animate a child window with AW_BLEND.
        ///         If the thread does not own the window. Note that, in this case, AnimateWindow fails but GetLastError returns ERROR_SUCCESS.
        /// </returns>
        /// <remarks>
        ///     To show or hide a window without special effects, use ShowWindow.
        ///     When using slide or roll animation, you must specify the direction. It can be either AW_HOR_POSITIVE, AW_HOR_NEGATIVE, AW_VER_POSITIVE, or AW_VER_NEGATIVE.
        ///     You can combine AW_HOR_POSITIVE or AW_HOR_NEGATIVE with AW_VER_POSITIVE or AW_VER_NEGATIVE to animate a window diagonally.
        ///     The window procedures for the window and its child windows should handle any WM_PRINT or WM_PRINTCLIENT messages. Dialog boxes, controls, and common controls already handle WM_PRINTCLIENT. The default window procedure already handles WM_PRINT.
        ///     If a child window is displayed partially clipped, when it is animated it will have holes where it is clipped.
        ///     AnimateWindow supports RTL windows.
        ///     Avoid animating a window that has a drop shadow because it produces visually distracting, jerky animations.
        /// </remarks>
        /// <see cref="https://msdn.microsoft.com/en-us/library/ms632669(VS.85).aspx"/>
        /// <seealso cref="http://www.cnblogs.com/KeenLeung/archive/2013/05/19/3087728.html"/>
        [DllImport("User32.dll")]
        public static extern bool AnimateWindow(IntPtr hwnd, Int32 dwTime, AnimateWindowType dwFlags);

        /// <summary>
        /// 窗口动画效果
        /// </summary>
        public enum   AnimateWindowType : Int32
        {
            /// <summary>
            /// 直接显示
            /// Activates the window. Do not use this value with AW_HIDE.
            /// </summary>
            AW_ACTIVATE = 0x00020000,
            /// <summary>
            /// 淡入效果。
            /// Uses a fade effect. This flag can be used only if hwnd is a top-level window.
            /// </summary>
            AW_BLEND = 0x00080000,
            /// <summary>
            /// 从中间开始显示
            /// Makes the window appear to collapse inward if AW_HIDE is used or expand outward if the AW_HIDE is not used. The various direction flags have no effect.
            /// </summary>
            AW_CENTER = 0x00000010,
            /// <summary>
            /// Hides the window. By default, the window is shown.
            /// </summary>
            AW_HIDE = 0x00010000,
            /// <summary>
            /// Animates the window from left to right. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
            /// </summary>
            AW_HOR_POSITIVE = 0x00000001,
            /// <summary>
            /// Animates the window from right to left. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
            /// </summary>
            AW_HOR_NEGATIVE = 0x00000002,
            /// <summary>
            /// Uses slide animation. By default, roll animation is used. This flag is ignored when used with AW_CENTER.
            /// </summary>
            AW_SLIDE = 0x00040000,
            /// <summary>
            /// Animates the window from top to bottom. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
            /// </summary>
            AW_VER_POSITIVE = 0x00000004,
            /// <summary>
            /// Animates the window from bottom to top. This flag can be used with roll or slide animation. It is ignored when used with AW_CENTER or AW_BLEND.
            /// </summary>
            AW_VER_NEGATIVE = 0x00000008,
        }


        /// <summary>
        ///     据窗口类名或窗口标题名来获得窗口的句柄，该函数返回窗口的句柄。需要注意：如果按照窗口名称查找，则窗口类名参数应设置为null，而不是""。具体见参数解释。
        ///     Retrieves a handle to the top-level window whose class name and window name match the specified strings. This function does not search child windows. This function does not perform a case-sensitive search.
        ///     To search child windows, beginning with a specified child window, use the FindWindowEx function.
        /// </summary>
        /// <param name="lpClassName">
        ///     [in, optional]
        ///     [Type: LPCTSTR]
        ///     窗口的类名
        ///     The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero.
        ///     If lpClassName points to a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
        ///     If lpClassName is NULL, it finds any window whose title matches the lpWindowName parameter.
        /// </param>
        /// <param name="lpWindowName">
        ///     [in, optional]
        ///     [Type: LPCTSTR]
        ///     窗口标题名
        ///     The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>
        ///     [Type: HWND]
        ///     If the function succeeds, the return value is a handle to the window that has the specified class name and window name.
        ///     If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     If the lpWindowName parameter is not NULL, FindWindow calls the GetWindowText function to retrieve the window name for comparison. For a description of a potential problem that can arise, see the Remarks for GetWindowText.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        // ############################################################
        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings. The function searches child windows, beginning with the one following the specified child window. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="hwndParnet">
        ///  [in, optional]
        ///  Type: HWND
        ///  A handle to the parent window whose child windows are to be searched.
        ///  If hwndParent is NULL, the function uses the desktop window as the parent window. The function searches among windows that are child windows of the desktop.
        ///  If hwndParent is HWND_MESSAGE, the function searches all message-only windows.
        /// </param>
        /// <param name="hwndChildAfter">
        /// [in, optional]
        /// Type: HWND
        /// A handle to a child window. The search begins with the next child window in the Z order. 
		/// The child window must be a direct child window of hwndParent, not just a descendant window.
        /// If hwndChildAfter is NULL, the search begins with the first child window of hwndParent.
        /// Note that if both hwndParent and hwndChildAfter are NULL, the function searches all top-level and message-only windows.
        /// </param>
        /// <param name="lpszClass">
        /// [in, optional]
        /// Type: LPCTSTR
        /// The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be placed in the low-order word of lpszClass; the high-order word must be zero.
        /// If lpszClass is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names, or it can be MAKEINTATOM(0x8000). In this latter case, 0x8000 is the atom for a menu class. For more information, see the Remarks section of this topic.
        /// </param>
        /// <param name="lpszWindow">
        /// [in, optional]
        /// Type: LPCTSTR
        /// The window name (the window's title). If this parameter is NULL, all window names match.
        /// </param>
        /// <returns>
        /// Type: HWND
        /// If the function succeeds, the return value is a handle to the window that has the specified class and window names.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// If the lpszWindow parameter is not NULL, FindWindowEx calls the GetWindowText function to retrieve the window name for comparison. For a description of a potential problem that can arise, see the Remarks section of GetWindowText.
        /// An application can call this function in the following way:FindWindowEx( NULL, NULL, MAKEINTATOM(0x8000), NULL );
        /// Note that 0x8000 is the atom for a menu class. When an application calls this function, the function checks whether a context menu is being displayed that the application created.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParnet, IntPtr hwndChildAfter, String lpszClass, String lpszWindow);


        // ############################################################
        /// <summary>
        ///     Retrieves a handle to the desktop window. 
        ///     The desktop window covers the entire screen. 
        ///     The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>
        ///     Type: HWND
        ///     The return value is a handle to the desktop window.
        ///     For an example, see Initializing a Dialog Box.
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/ms644996(v=vs.85).aspx#init_box
        /// </returns>
        /// <link>
        ///     https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getdesktopwindow
        /// </link>
        [DllImport("User32.dll")]
        public static extern IntPtr GetDesktopWindow();


        // ############################################################
        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns>
        /// Type: HWND
        /// The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, such as when a window is losing activation.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();

        // ############################################################
        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="hWnd">
        /// [in]
        /// Type: HWND
        /// A handle to a window. The window handle retrieved is relative to this window, based on the value of the uCmd parameter.
        /// </param>
        /// <param name="uCmd">
        /// [in]
        /// Type: UINT
        /// The relationship between the specified window and the window whose handle is to be retrieved. This parameter can be one of the following values.
        /// </param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowTypeEnum uCmd);

        /// <summary>
        /// 
        /// </summary>
        public enum GetWindowTypeEnum
        {
            /// <summary>
            /// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. The function examines only child windows of the specified window. It does not examine descendant windows.
            /// </summary>
            GW_CHILD = 5,
            /// <summary>
            /// The retrieved handle identifies the enabled popup window owned by the specified window (the search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled popup windows, the retrieved handle is that of the specified window.
            /// </summary>
            GW_ENABLEDPOPUP = 6,
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is highest in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDFIRST = 0,
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDLAST = 1,
            /// <summary>
            /// The retrieved handle identifies the window below the specified window in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDNEXT = 2,
            /// <summary>
            /// The retrieved handle identifies the window above the specified window in the Z order.
            /// If the specified window is a topmost window, the handle identifies a topmost window. If the specified window is a top-level window, the handle identifies a top-level window. If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDPREV = 3,
            /// <summary>
            /// The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.
            /// </summary>
            GW_OWNER = 4
        }

        // ############################################################
        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="hWnd">
        /// [in]
        /// Type: HWND
        /// A handle to the window or control containing the text.
        /// </param>
        /// <param name="lpString">
        /// [out]
        /// Type: LPTSTR
        /// The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.
        /// </param>
        /// <param name="nMaxCount">
        /// [in]
        /// Type: int
        /// The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.
        /// </param>
        /// <returns>
        /// Type: int
        /// If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero. To get extended error information, call GetLastError.
        /// This function cannot retrieve the text of an edit control in another application.
        /// </returns>
        /// <remarks>
        /// If the target window is owned by the current process, GetWindowText causes a WM_GETTEXT message to be sent to the specified window or control. 
        /// If the target window is owned by another process and has a caption, GetWindowText retrieves the window caption text. 
        /// If the window does not have a caption, the return value is a null string. This behavior is by design. 
        /// It allows applications to call GetWindowText without becoming unresponsive if the process that owns the target window is not responding. 
        /// However, if the target window is not responding and it belongs to the calling application, GetWindowText will cause the calling application to become unresponsive.
        /// To retrieve the text of a control in another process, send a WM_GETTEXT message directly instead of calling GetWindowText.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern Int32 GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, Int32 nMaxCount);

        /// <summary>
        /// 获取指定窗口的标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static String GetWindowText(IntPtr hWnd)
        {
            Int32 txtLength = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder("", txtLength + 2);
            Int32 tCount = API.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        // ############################################################
        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). If the specified window is a control, the function retrieves the length of the text within the control. However, GetWindowTextLength cannot retrieve the length of the text of an edit control in another application.
        /// </summary>
        /// <param name="hWnd">
        /// [in]
        /// Type: HWND
        /// A handle to the window or control.
        /// </param>
        /// <returns>
        /// Type: int
        /// If the function succeeds, the return value is the length, in characters, of the text. Under certain conditions, this value may actually be greater than the length of the text. For more information, see the following Remarks section.
        /// If the window has no text, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// If the target window is owned by the current process, GetWindowTextLength causes a WM_GETTEXTLENGTH message to be sent to the specified window or control.
        /// Under certain conditions, the GetWindowTextLength function may return a value that is larger than the actual length of the text. This occurs with certain mixtures of ANSI and Unicode, and is due to the system allowing for the possible existence of double-byte character set (DBCS) characters within the text. The return value, however, will always be at least as large as the actual length of the text; you can thus always use it to guide buffer allocation. This behavior can occur when an application uses both ANSI functions and common dialogs, which use Unicode. It can also occur when an application uses the ANSI version of GetWindowTextLength with a window whose window procedure is Unicode, or the Unicode version of GetWindowTextLength with a window whose window procedure is ANSI. For more information on ANSI and ANSI functions, see Conventions for Function Prototypes.
        /// To obtain the exact length of the text, use the WM_GETTEXT, LB_GETTEXT, or CB_GETLBTEXT messages, or the GetWindowText function.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern Int32 GetWindowTextLength(IntPtr hWnd);

        // ############################################################
        /// <summary>
        /// Changes the parent window of the specified child window.
        /// </summary>
        /// <param name="hWndChild">
        /// [in]
        /// Type: HWND
        /// A handle to the child window.
        /// </param>
        /// <param name="hWndNewParent">
        /// [in, optional]
        /// Type: HWND
        /// A handle to the new parent window. If this parameter is NULL, the desktop window becomes the new parent window. If this parameter is HWND_MESSAGE, the child window becomes a message-only window.
        /// </param>
        /// <returns>
        /// Type: HWND
        /// If the function succeeds, the return value is a handle to the previous parent window.
        /// If the function fails, the return value is NULL. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// An application can use the SetParent function to set the parent window of a pop-up, overlapped, or child window.
        /// If the window identified by the hWndChild parameter is visible, the system performs the appropriate redrawing and repainting.
        /// For compatibility reasons, SetParent does not modify the WS_CHILD or WS_POPUP window styles of the window whose parent is being changed. Therefore, if hWndNewParent is NULL, you should also clear the WS_CHILD bit and set the WS_POPUP style after calling SetParent. Conversely, if hWndNewParent is not NULL and the window was previously a child of the desktop, you should clear the WS_POPUP style and set the WS_CHILD style before calling SetParent.
        /// When you change the parent of a window, you should synchronize the UISTATE of both windows. For more information, see WM_CHANGEUISTATE and WM_UPDATEUISTATE.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        // ############################################################
        /// <summary>
        /// Changes the position and dimensions of the specified window. 
        /// For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. 
        /// For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="nWidht"></param>
        /// <param name="nHeight"></param>
        /// <param name="bRepaint"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Boolean MoveWindow(IntPtr hwnd, Int32 X, Int32 Y, Int32 nWidht, Int32 nHeight, Boolean bRepaint);

        // ############################################################
        /// <summary>
        /// An application-defined callback function used with the EnumChildWindows function. It receives the child window handles. The WNDENUMPROC type defines a pointer to this callback function. EnumChildProc is a placeholder for the application-defined function name.
        /// </summary>
        /// <param name="hwnd">
        ///     [in][Type: HWND]
        ///     A handle to a child window of the parent window specified in EnumChildWindows.
        /// </param>
        /// <param name="lParam">
        ///      [in]
        ///      The application-defined value given in EnumChildWindows.
        /// </param>
        /// <returns>
        /// To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.
        /// </returns>
        /// <remarks>
        /// The callback function can carry out any desired task.
        /// An application must register this callback function by passing its address to EnumChildWindows.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms633493(v=vs.85).aspx</link>
        public delegate Boolean EnumChildProc(IntPtr hwnd, Int32 lParam);

        // ############################################################
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndParent">
        ///     [in, optional][Type: HWND]
        ///     A handle to the parent window whose child windows are to be enumerated. If this parameter is NULL, this function is equivalent to EnumWindows.
        /// </param>
        /// <param name="lpEnumFunc">
        ///     [in][Type: WNDENUMPROC]
        ///     A pointer to an application-defined callback function. For more information, see EnumChildProc.
        /// </param>
        /// <param name="lParam">
        ///     [in][Type: LPARAM]
        ///     An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// The return value is not used.
        /// </returns>
        /// <remarks>
        /// If a child window has created child windows of its own, EnumChildWindows enumerates those windows as well.
        /// A child window that is moved or repositioned in the Z order during the enumeration process will be properly enumerated. The function does not enumerate a child window that is destroyed before being enumerated or that is created during the enumeration process.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms633494(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern Boolean EnumChildWindows(IntPtr hWndParent, EnumChildProc lpEnumFunc, Int32 lParam);

        // ############################################################
        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function. EnumWindows continues until the last top-level window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="lpEnumFunc">
        ///     [in][Type: WNDENUMPROC]
        ///     A pointer to an application-defined callback function. For more information, see EnumWindowsProc.
        /// </param>
        /// <param name="lParam">
        ///     [in][Type: LPARAM]
        ///     An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        ///     [Type: BOOL]
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        ///     If EnumWindowsProc returns zero, the return value is also zero. In this case, the callback function should call SetLastError to obtain a meaningful error code to be returned to the caller of EnumWindows.
        ///     
        /// </returns>
        /// <remarks>
        /// The EnumWindows function does not enumerate child windows, with the exception of a few top-level windows owned by the system that have the WS_CHILD style.
        /// This function is more reliable than calling the GetWindow function in a loop. An application that calls GetWindow to perform this task risks being caught in an infinite loop or referencing a handle to a window that has been destroyed.
        /// Note  For Windows 8 and later, EnumWindows enumerates only top-level windows of desktop apps.
        /// </remarks>
        /// <link>
        /// https://msdn.microsoft.com/en-us/library/ms633497(v=vs.85).aspx
        /// </link>
        [DllImport("User32.dll")]
        public static extern Boolean EnumWindows(EnumWindowsProc lpEnumFunc, Int32 lParam);

        // ############################################################
        /// <summary>
        /// An application-defined callback function used with the EnumWindows or EnumDesktopWindows function. It receives top-level window handles. The WNDENUMPROC type defines a pointer to this callback function. EnumWindowsProc is a placeholder for the application-defined function name.
        /// </summary>
        /// <param name="hwnd">
        ///     [in]
        ///     A handle to a top-level window.
        /// </param>
        /// <param name="lParam">
        ///     [in]
        ///     The application-defined value given in EnumWindows or EnumDesktopWindows.
        /// </param>
        /// <returns>
        ///     To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return 
        /// </returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to EnumWindows or EnumDesktopWindows.
        /// </remarks>
        /// <link>
        /// https://msdn.microsoft.com/en-us/library/ms633498(v=vs.85).aspx
        /// </link>
        public delegate Boolean EnumWindowsProc(IntPtr hwnd, Int32 lParam);

        // ############################################################
        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="hwnd">
        ///     [in][Type: HWND]
        ///     A handle to the window to be tested.
        /// </param>
        /// <returns>
        ///     [Type: BOOL]
        ///     If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. Otherwise, the return value is zero.
        ///     Because the return value specifies whether the window has the WS_VISIBLE style, it may be nonzero even if the window is totally obscured by other windows.
        /// </returns>
        /// <remarks>
        /// The visibility state of a window is indicated by the WS_VISIBLE style bit. When WS_VISIBLE is set, the window is displayed and subsequent drawing into it is displayed as long as the window has the WS_VISIBLE style.
        /// Any drawing to a window with the WS_VISIBLE style will not be displayed if the window is obscured by other windows or is clipped by its parent window.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/ms633530(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern Boolean IsWindowVisible(IntPtr hwnd);

        // ############################################################
        /// <summary>
        /// Brings the specified window to the top of the Z order. If the window is a top-level window, it is activated. If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="hWnd">
        /// [in][Type: HWND]
        ///     A handle to the window to bring to the top of the Z order.
        /// </param>
        /// <returns>
        /// [Type: BOOL]
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// Use the BringWindowToTop function to uncover any window that is partially or completely obscured by other windows.
        /// Calling this function is similar to calling the SetWindowPos function to change a window's position in the Z order. BringWindowToTop does not make a window a top-level window.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms632673(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern Boolean BringWindowToTop(IntPtr hWnd);


        // ############################################################
        /// <summary>
        ///     Changes the size, position, and Z order of a child, pop-up, or top-level window. 
        ///     These windows are ordered according to their appearance on the screen. 
        ///     The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window.
        /// </param>
        /// <param name="hWndInsertAfter">
        ///     A handle to the window to precede the positioned window in the Z order. 
        ///     This parameter must be a window handle or one of the following values.
        /// </param>
        /// <param name="X">
        ///     The new position of the left side of the window, in client coordinates.
        /// </param>
        /// <param name="Y">
        ///     The new position of the top of the window, in client coordinates.
        /// </param>
        /// <param name="cx">
        ///     The new width of the window, in pixels.
        /// </param>
        /// <param name="cy">
        ///     The new height of the window, in pixels.
        /// </param>
        /// <param name="uFlags">
        ///     The window sizing and positioning flags. This parameter can be a combination of the following values.
        /// </param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Boolean SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 X, Int32 Y, Int32 cx, Int32 cy, SetWindowPosFlags uFlags);

        /// <summary>
        /// 
        /// </summary>
        public enum SetWindowPosFlags
        {
            /// <summary>
            /// If the calling thread and the thread that owns the window are attached to different input queues, 
            /// the system posts the request to the thread that owns the window. 
            /// This prevents the calling thread from blocking its execution while other threads process the request.
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,
            /// <summary>
            /// Prevents generation of the WM_SYNCPAINT message.
            /// </summary>
            SWP_DEFERERASE = 0x2000,
            /// <summary>
            /// Draws a frame (defined in the window's class description) around the window.
            /// </summary>
            SWP_DRAWFRAME = 0x0020,
            /// <summary>
            /// Applies new frame styles set using the SetWindowLong function. 
            /// Sends a WM_NCCALCSIZE message to the window, even if the window's size is not being changed. 
            /// If this flag is not specified, WM_NCCALCSIZE is sent only when the window's size is being changed.
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,
            /// <summary>
            /// Hides the window.
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,
            /// <summary>
            /// Does not activate the window. 
            /// If this flag is not set, the window is activated and moved to the top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOACTIVATE = 0x0010,
            /// <summary>
            /// Discards the entire contents of the client area. 
            /// If this flag is not specified, the valid contents of the client area are saved and copied back into the client area after the window is sized or repositioned.
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,
            /// <summary>
            /// Retains the current position (ignores X and Y parameters).
            /// </summary>
            SWP_NOMOVE = 0x0002,
            /// <summary>
            /// Does not change the owner window's position in the Z order.
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,
            /// <summary>
            /// Does not redraw changes. If this flag is set, no repainting of any kind occurs. 
            /// This applies to the client area, the nonclient area (including the title bar and scroll bars), 
            /// and any part of the parent window uncovered as a result of the window being moved. 
            /// When this flag is set, the application must explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
            /// </summary>
            SWP_NOREDRAW = 0x0008,
            /// <summary>
            /// 
            /// </summary>
            SWP_NOREPOSITION = 0x0200,
            /// <summary>
            /// Prevents the window from receiving the WM_WINDOWPOSCHANGING message.
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,
            /// <summary>
            /// Retains the current size (ignores the cx and cy parameters).
            /// </summary>
            SWP_NOSIZE = 0x0001,
            /// <summary>
            /// Retains the current Z order (ignores the hWndInsertAfter parameter).
            /// </summary>
            SWP_NOZORDER = 0x0004,
            /// <summary>
            /// Displays the window.
            /// </summary>
            SWP_SHOWWINDOW = 0x0040

        }


        // ############################################################
        /// <summary>
        ///     Brings the thread that created the specified window into the foreground and activates the window. 
        ///     Keyboard input is directed to the window, and various visual cues are changed for the user. 
        ///     The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the window that should be activated and brought to the foreground.
        /// </param>
        /// <returns></returns>
        /// <link>
        ///     https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setforegroundwindow
        /// </link>
        [DllImport("User32.dll")]
        public static extern Boolean SetForegroundWindow(IntPtr hwnd);


        // ############################################################
        /// <summary>
        /// <para>根据窗口句柄返回其进程标识符。</para>
        /// Retrieves the identifier of the thread that created the specified window and, optionally, the identifier of the process that created the window.
        /// </summary>
        /// <param name="hWnd">
        ///     [in][Type: HWND]
        ///     A handle to the window.
        /// </param>
        /// <param name="lpdwProcessId">
        ///     [out, optional][Type: LPDWORD]
        ///     A pointer to a variable that receives the process identifier. If this parameter is not NULL, GetWindowThreadProcessId copies the identifier of the process to the variable; otherwise, it does not.
        /// </param>
        /// <returns>
        ///     [Type: DWORD]
        ///     The return value is the identifier of the thread that created the window.
        /// </returns>
        /// <link>https://msdn.microsoft.com/en-us/library/ms633522</link>
        [DllImport("User32.dll")]
        public static extern Int32 GetWindowThreadProcessId(IntPtr hWnd, out Int32 lpdwProcessId);


        // ############################################################
        /// <summary>
        /// Retrieves a handle to the window that contains the specified physical point.
        /// </summary>
        /// <param name="point">
        /// [in][Type: POINT]
        ///     The physical coordinates of the point.
        /// </param>
        /// <returns>
        /// [Type: HWND]
        ///     A handle to the window that contains the given physical point. If no window exists at the point, this value is NULL.
        /// </returns>
        /// <remarks>
        /// The WindowFromPhysicalPoint function does not retrieve a handle to a hidden or disabled window, even if the point is within the window.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/aa969270(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern IntPtr WindowFromPhysicalPoint(POINT point);

        // ############################################################
        /// <summary>
        /// Retrieves a handle to the window that contains the specified point.
        /// </summary>
        /// <param name="point">
        /// [in][Type: POINT]
        ///     The point to be checked.
        /// </param>
        /// <returns>
        /// [Type: HWND]
        ///     The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is NULL. If the point is over a static text control, the return value is a handle to the window under the static text control.
        /// </returns>
        /// <remarks>
        /// The WindowFromPoint function does not retrieve a handle to a hidden or disabled window, even if the point is within the window. An application should use the ChildWindowFromPoint function for a nonrestrictive search.
        /// </remarks>
        /// <link>https://msdn.microsoft.com/en-us/library/windows/desktop/ms633558(v=vs.85).aspx</link>
        [DllImport("User32.dll")]
        public static extern IntPtr WindowFromPoint(POINT point);


        // ############################################################
        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. The search is restricted to immediate child windows. Grandchildren, and deeper descendant windows are not searched.
        /// To skip certain child windows, use the ChildWindowFromPointEx function.
        /// </summary>
        /// <param name="hwndParent">
        ///     A handle to the parent window.
        /// </param>
        /// <param name="point">
        ///     A structure that defines the client coordinates, relative to hWndParent, of the point to be checked.
        /// </param>
        /// <returns>
        ///     The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled. 
        ///     If the point lies outside the parent window, the return value is NULL. 
        ///     If the point is within the parent window but not within any child window, the return value is a handle to the parent window.
        /// </returns>
        /// <remarks>
        ///     The system maintains an internal list, containing the handles of the child windows associated with a parent window. The order of the handles in the list depends on the Z order of the child windows. If more than one child window contains the specified point, the system returns a handle to the first window in the list that contains the point.
        ///     ChildWindowFromPoint treats an HTTRANSPARENT area of a standard control the same as other parts of the control. In contrast, RealChildWindowFromPoint treats an HTTRANSPARENT area differently; it returns the child window behind a transparent area of a control. For example, if the point is in a transparent area of a groupbox, ChildWindowFromPoint returns the groupbox while RealChildWindowFromPoint returns the child window behind the groupbox. However, both APIs return a static field, even though it, too, returns HTTRANSPARENT.
        /// </remarks>
        /// <link>
        ///     https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-childwindowfrompoint
        /// </link>
        [DllImport("User32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hwndParent, POINT point);


        // ############################################################
        /// <summary>
        ///     Determines which, if any, of the child windows belonging to the specified parent window contains the specified point. 
        ///     The function can ignore invisible, disabled, and transparent child windows. 
        ///     The search is restricted to immediate child windows. Grandchildren and deeper descendants are not searched.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the parent window.
        /// </param>
        /// <param name="pt">
        ///     A structure that defines the client coordinates (relative to hwndParent) of the point to be checked.
        /// </param>
        /// <param name="flags">
        ///     The child windows to be skipped. This parameter can be one or more of the following values.
        /// </param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr hwnd, POINT pt, Int32 flags);


        // ############################################################
        /// <summary>
        ///     Retrieves a handle to the child window at the specified point. 
        ///     The search is restricted to immediate child windows; 
        ///     grandchildren and deeper descendant windows are not searched.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the window whose child is to be retrieved.
        /// </param>
        /// <param name="ptParentClientCoords">
        ///     A POINT structure that defines the client coordinates of the point to be checked.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        ///     RealChildWindowFromPoint treats HTTRANSPARENT areas of a standard control differently from other areas of the control; 
        ///     it returns the child window behind a transparent part of a control. 
        ///     In contrast, ChildWindowFromPoint treats HTTRANSPARENT areas of a control the same as other areas. 
        ///     For example, if the point is in a transparent area of a groupbox, RealChildWindowFromPoint returns the child window behind a groupbox, whereas ChildWindowFromPoint returns the groupbox. 
        ///     However, both APIs return a static field, even though it, too, returns HTTRANSPARENT.
        /// </remarks>
        /// <link>
        ///    https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-realchildwindowfrompoint 
        /// </link>
        [DllImport("User32.dll")]
        public static extern IntPtr RealChildWindowFromPoint(IntPtr hwnd, POINT ptParentClientCoords);

        // ############################################################
        /// <summary>
        ///     Determines whether the specified window handle identifies an existing window.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the window to be tested.
        /// </param>
        /// <returns>
        ///     If the window handle identifies an existing window, the return value is nonzero.
        ///     If the window handle does not identify an existing window, the return value is zero.
        /// </returns>
        /// <remarks>
        ///     A thread should not use IsWindow for a window that it did not create because the window could be destroyed after this function was called. 
        ///     Further, because window handles are recycled the handle could even point to a different window.
        /// </remarks>
        [DllImport("User32.dll")]
        public static extern Boolean IsWindow(IntPtr hwnd);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. 
        /// The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
		public static extern Boolean GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        // ############################################################
        /// <summary>
        ///		Retrieves a handle to the specified window's parent or owner.
        ///		To retrieve a handle to a specified ancestor, use the GetAncestor function.
        /// </summary>
        /// <param name="hwnd">
        ///		A handle to the window whose parent window handle is to be retrieved.
        /// </param>
        /// <returns>
        ///		If the window is a child window, the return value is a handle to the parent window. 
        ///		If the window is a top-level window with the WS_POPUP style, the return value is a handle to the owner window.
        /// </returns>
        /// <link>
        ///		https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getparent
        /// </link>
        [DllImport("User32.dll")]
		public static extern IntPtr GetParent(IntPtr hwnd);


        #region 菜单

        /// <summary>
        /// Retrieves a handle to the menu assigned to the specified window.
        /// </summary>
        /// <param name="hwnd">
        ///     A handle to the window whose menu handle is to be retrieved.
        /// </param>
        /// <returns>
        ///     The return value is a handle to the menu. If the specified window has no menu, the return value is NULL. 
        ///     If the window is a child window, the return value is undefined.
        /// </returns>
        /// <remarks>
        ///     GetMenu does not work on floating menu bars. 
        ///     Floating menu bars are custom controls that mimic standard menus; they are not menus. 
        ///     To get the handle on a floating menu bar, use the Active Accessibility APIs.
        /// </remarks>
        /// <link>
        ///     https://docs.microsoft.com/en-us/windows/desktop/api/Winuser/nf-winuser-getmenu
        /// </link>
        [DllImport("User32.dll")]
        public static extern IntPtr GetMenu(IntPtr hwnd);


        #endregion


        #region 效果

        // ############################################################
        /// <summary>
        ///     Flashes the specified window. It does not change the active state of the window.
        /// </summary>
        /// <returns></returns>
        [DllImport("User32.dll")]
        internal static extern Boolean FlashWindowEx(IntPtr FlashWindowEx);

        /// <summary>
        ///     闪烁窗口
        /// </summary>
        /// <param name="hwnd">
        ///     要闪烁的窗口句柄
        /// </param>
        /// <param name="flashType">
        ///     闪烁类型
        /// </param>
        /// <param name="rate">
        ///     闪烁的频率。单位为毫秒。
        /// </param>
        /// <param name="count">
        ///     闪烁的次数
        /// </param>
        /// <returns></returns>
        public static Boolean FlashWindowEx(IntPtr hwnd, FlashWindowType flashType, Int32 rate, Int32 count)
        {
            if (rate <= 0) rate = 1000;
            if (count <= 0) count = 1000;
            FlashInfoStruct s = new FlashInfoStruct();
            s.hwnd = hwnd;
            s.dwFlags = flashType;
            s.dwTimeout = rate;
            s.uCount = (UInt32)count;
            s.cbSize = (UInt32)Marshal.SizeOf(s);
            IntPtr add = IntPtr.Zero;
            add = Marshal.AllocHGlobal((Int32)s.cbSize);
            Marshal.StructureToPtr(s, add, true);
            return FlashWindowEx(add);
        }

        /// <summary>
        ///     闪烁指定的窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="flashType"></param>
        /// <returns></returns>
        public static Boolean FlashWindowEx(IntPtr hwnd, FlashWindowType flashType)
        {
            return FlashWindowEx(hwnd, flashType, 1000, 1000);
        }

        /// <summary>
        ///     窗口闪烁参数结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class FlashInfoStruct
        {
            /// <summary>
            ///     The size of the structure, in bytes.
            /// </summary>
            public UInt32 cbSize;
            /// <summary>
            ///     A handle to the window to be flashed. The window can be either opened or minimized.
            /// </summary>
            public IntPtr hwnd;
            /// <summary>
            ///     The flash status. This parameter can be one or more of the following values.
            /// </summary>
            public FlashWindowType dwFlags;
            /// <summary>
            ///     The number of times to flash the window.
            /// </summary>
            public UInt32 uCount;
            /// <summary>
            ///     The rate at which the window is to be flashed, in milliseconds. 
            ///     If dwTimeoutis zero, the function uses the default cursor blink rate.
            /// </summary>
            public Int32 dwTimeout;
        }

        /// <summary>
        ///     窗口闪烁类型枚举
        /// </summary>
        public enum FlashWindowType
        {
            /// <summary>
            ///     Flash both the window caption and taskbar button. 
            ///     This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.
            /// </summary>
            FLASHW_ALL = 0x00000003,
            /// <summary>
            ///     Flash the window caption.
            /// </summary>
            FLASHW_CAPTION = 0x00000001,
            /// <summary>
            ///     Stop flashing. The system restores the window to its original state.
            /// </summary>
            FLASHW_STOP = 0,
            /// <summary>
            ///     Flash continuously, until the FLASHW_STOP flag is set.
            /// </summary>
            FLASHW_TIMER = 0x00000004,
            /// <summary>
            ///     Flash continuously until the window comes to the foreground.
            /// </summary>
            FLASHW_TIMERNOFG = 0x0000000C,
            /// <summary>
            ///     Flash the taskbar button.
            /// </summary>
            FLASHW_TRAY = 0x00000002
        }

        #endregion
    }
}
