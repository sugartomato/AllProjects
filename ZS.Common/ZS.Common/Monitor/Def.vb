Imports System.Runtime.InteropServices
Imports System.Drawing
Namespace Monitor

    Public Class Def
        ''' <summary>
        ''' This is the primary display monitor.
        ''' </summary>
        Public Const MONITORINFOF_PRIMARY As Int32 = 1
    End Class


    ''' <summary>
    ''' API函数MonitorFromWindow的flag参数
    ''' </summary>
    Public Enum MONITOR_DEFAULTTO As Integer
        ''' <summary>
        ''' Returns NULL.
        ''' 返回NULL
        ''' </summary>
        MONITOR_DEFAULTTONULL = &H0
        ''' <summary>
        ''' Returns a handle to the primary display monitor.
        ''' 返回代表主显示器的句柄。
        ''' </summary>
        MONITOR_DEFAULTTOPRIMARY = &H1

        ''' <summary>
        ''' Returns a handle to the display monitor that is nearest to the window.
        ''' 返回代表最靠近窗口的显示器的句柄
        ''' </summary>
        MONITOR_DEFAULTTONEAREST = &H2

    End Enum


    ''' <summary>
    ''' The MONITORINFO structure contains information about a display monitor.
    ''' The GetMonitorInfo function stores information in a MONITORINFO structure or a MONITORINFOEX structure.
    ''' The MONITORINFO structure is a subset of the MONITORINFOEX structure. The MONITORINFOEX structure adds a string member to contain a name for the display monitor.
    ''' </summary>
    ''' <link ref="https://msdn.microsoft.com/en-us/library/windows/desktop/dd145065(v=vs.85).aspx" />
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Class MONITORINFO
        ''' <summary>
        ''' The size of the structure, in bytes.
        ''' Set this member to sizeof ( MONITORINFO ) before calling the GetMonitorInfo function. Doing so lets the function determine the type of structure you are passing to it.
        ''' </summary>
        Public cbSize As Int32 = Marshal.SizeOf(GetType(MONITORINFO))
        ''' <summary>
        ''' A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. 
        ''' Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        ''' </summary>
        Public rcMonitor As System.Drawing.Rectangle = New System.Drawing.Rectangle()
        ''' <summary>
        ''' A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. 
        ''' Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        ''' </summary>
        Public rcWork As System.Drawing.Rectangle = New System.Drawing.Rectangle()
        ''' <summary>
        ''' A set of flags that represent attributes of the display monitor.
        ''' </summary>
        Public dwFlags As Int32 = 0

    End Class

    Public Structure RECT

        Public Left As Int32
        Public Top As Int32
        Public Right As Int32
        Public Bottom As Int32

        Public Shared ReadOnly Empty As RECT = New RECT()

        Public ReadOnly Property Width As Int32
            Get
                Return Math.Abs(Right - Left)
            End Get
        End Property

        Public ReadOnly Property Height As Int32
            Get
                Return Bottom - Top
            End Get
        End Property

#Region "构造"

        Public Sub New(ByVal _left As Int32, ByVal _top As Int32, ByVal _right As Int32, ByVal _bottom As Int32)
            With Me
                .Left = _left
                .Right = _right
                .Top = _top
                .Bottom = _bottom
            End With

        End Sub



#End Region

    End Structure

End Namespace
