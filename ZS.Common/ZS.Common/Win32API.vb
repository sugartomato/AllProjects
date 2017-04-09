Imports System.Runtime.InteropServices

Public Class Win32API



    ' http://www.pinvoke.net/default.aspx
    ' https://msdn.microsoft.com/en-us/library/172wfck9.aspx

    ''' <summary>
    ''' The MonitorFromWindow function retrieves a handle to the display monitor that has the largest area of intersection with the bounding rectangle of a specified window.
    ''' </summary>
    ''' <param name="hwnd">A handle to the window of interest.</param>
    ''' <param name="dwFlags">
    ''' Determines the function's return value if the window does not intersect any display monitor.
    ''' This parameter can be one of the following values:
    ''' MONITOR_DEFAULTTONEAREST:Returns a handle to the display monitor that is nearest to the window.
    ''' MONITOR_DEFAULTTONULL:Returns NULL.
    ''' MONITOR_DEFAULTTOPRIMARY:Returns a handle to the primary display monitor.
    ''' </param>
    ''' <returns>
    ''' If the window intersects one or more display monitor rectangles, the return value is an HMONITOR handle to the display monitor that has the largest area of intersection with the window.
    ''' If the window does not intersect a display monitor, the return value depends on the value of dwFlags.
    ''' </returns>
    ''' <remarks>
    ''' If the window is currently minimized, MonitorFromWindow uses the rectangle of the window before it was minimized.
    ''' </remarks>
    ''' <link ref="https://msdn.microsoft.com/en-us/library/windows/desktop/dd145064(v=vs.85).aspx" />
    <DllImport("User32.dll", EntryPoint:="MonitorFromWindow")>
    Public Shared Function MonitorFromWindow(ByVal hwnd As IntPtr, ByVal dwFlags As Integer) As IntPtr
    End Function

    ''' <summary>
    ''' The GetMonitorInfo function retrieves information about a display monitor.
    ''' </summary>
    ''' <param name="hMonitor">A handle to the display monitor of interest.</param>
    ''' <param name="lpmi">A pointer to a MONITORINFO or MONITORINFOEX structure that receives information about the specified display monitor.
    ''' You must set the cbSize member of the structure to sizeof(MONITORINFO) or sizeof(MONITORINFOEX) before calling the GetMonitorInfo function. Doing so lets the function determine the type of structure you are passing to it.
    ''' The MONITORINFOEX structure is a superset of the MONITORINFO structure. It has one additional member: a string that contains a name for the display monitor. Most applications have no use for a display monitor name, and so can save some bytes by using a MONITORINFO structure.
    ''' </param>
    ''' <returns>
    ''' If the function succeeds, the return value is nonzero.
    ''' If the function fails, the return value is zero.
    ''' </returns>
    ''' <link ref="https://msdn.microsoft.com/en-us/library/windows/desktop/dd144901" />
    <DllImport("User32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function GetMonitorInfo(ByVal hMonitor As IntPtr, ByRef lpmi As Structures.Monitors.MONITORINFO) As Int32
    End Function



End Class


