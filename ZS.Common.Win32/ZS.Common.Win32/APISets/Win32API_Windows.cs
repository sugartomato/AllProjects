using System;

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
        /// A handle to a child window. The search begins with the next child window in the Z order. The child window must be a direct child window of hwndParent, not just a descendant window.
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


        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>
        /// Type: HWND
        /// The return value is a handle to the desktop window.
        /// For an example, see Initializing a Dialog Box.
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms644996(v=vs.85).aspx#init_box
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Retrieves a handle to the foreground window (the window with which the user is currently working). The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        /// </summary>
        /// <returns>
        /// Type: HWND
        /// The return value is a handle to the foreground window. The foreground window can be NULL in certain circumstances, such as when a window is losing activation.
        /// </returns>
        [DllImport("User32.dll")]
        public static extern IntPtr GetForegroundWindow();

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
        /// <link>
        /// https://msdn.microsoft.com/en-us/library/ms633530(v=vs.85).aspx
        /// </link>
        [DllImport("User32.dll")]
        public static extern Boolean IsWindowVisible(IntPtr hwnd);


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
    }
}
