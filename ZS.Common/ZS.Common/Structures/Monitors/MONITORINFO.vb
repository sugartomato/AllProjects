Imports System.Runtime.InteropServices

Namespace Structures.Monitors


    ''' <summary>
    ''' The MONITORINFO structure contains information about a display monitor.
    ''' The GetMonitorInfo function stores information in a MONITORINFO structure or a MONITORINFOEX structure.
    ''' The MONITORINFO structure is a subset of the MONITORINFOEX structure. The MONITORINFOEX structure adds a string member to contain a name for the display monitor.
    ''' </summary>
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
    Public Structure MONITORINFO

        ''' <summary>
        ''' The size of the structure, in bytes.
        ''' Set this member to sizeof ( MONITORINFO ) before calling the GetMonitorInfo function. Doing so lets the function determine the type of structure you are passing to it.
        ''' </summary>
        Public cbSize As Int32 '= Marshal.SizeOf(GetType(MONITORINFO))

        ''' <summary>
        ''' A RECT structure that specifies the display monitor rectangle, expressed in virtual-screen coordinates. 
        ''' Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        ''' </summary>
        Public rcMonitor As Rectangle.RECT '= New Rectangle.RECT()

        ''' <summary>
        ''' A RECT structure that specifies the work area rectangle of the display monitor, expressed in virtual-screen coordinates. 
        ''' Note that if the monitor is not the primary display monitor, some of the rectangle's coordinates may be negative values.
        ''' </summary>
        Public rcWork As Rectangle.RECT '= New Rectangle.RECT()

        ''' <summary>
        ''' A set of flags that represent attributes of the display monitor.
        ''' </summary>
        Public dwFlags As Int32 '= 0



    End Structure

End Namespace
