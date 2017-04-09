using System;
using System.Runtime.InteropServices;

namespace ZS.Common.Win32
{
    public partial class API
    {

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="lpPoint">
        ///     [out][Type: LPPOINT]
        ///     A pointer to a POINT structure that receives the screen coordinates of the cursor.
        /// </param>
        /// <returns>
        ///     [Type: BOOL]
        ///     Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     The cursor position is always specified in screen coordinates and is not affected by the mapping mode of the window that contains the cursor.
        ///     The calling process must have WINSTA_READATTRIBUTES access to the window station.
        ///     The input desktop must be the current desktop when you call GetCursorPos. Call OpenInputDesktop to determine whether the current desktop is the input desktop. If it is not, call SetThreadDesktop with the HDESK returned by OpenInputDesktop to switch to that desktop.
        /// </remarks>
        /// <see cref="https://msdn.microsoft.com/en-us/library/windows/desktop/ms648390(v=vs.85).aspx"/>
        /// <example>
        /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms648380(v=vs.85).aspx#_win32_Using_the_Keyboard_to_Move_the_Cursor
        /// </example>
        [DllImport("User32.dll")]
        public static extern Boolean GetCursorPos(ref POINT lpPoint);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="X">
        ///      [in][Type: int]
        ///      The new x-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <param name="Y">
        ///     [in][Type: int]
        ///     The new y-coordinate of the cursor, in screen coordinates.
        /// </param>
        /// <returns>
        /// Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// The cursor is a shared resource. A window should move the cursor only when the cursor is in the window's client area.
        /// The calling process must have WINSTA_WRITEATTRIBUTES access to the window station.
        /// The input desktop must be the current desktop when you call SetCursorPos. Call OpenInputDesktop to determine whether the current desktop is the input desktop. If it is not, call SetThreadDesktop with the HDESK returned by OpenInputDesktop to switch to that desktop.
        /// </remarks>
        /// <see cref="https://msdn.microsoft.com/en-us/library/ms648394(VS.85).aspx"/>
        /// <example>
        /// https://msdn.microsoft.com/en-us/library/ms648380(v=vs.85).aspx#_win32_Using_the_Keyboard_to_Move_the_Cursor
        /// </example>
        [DllImport("User32.dll")]
        public static extern Boolean SetCursorPos(Int32 X, Int32 Y);
    }
}
