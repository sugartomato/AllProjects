
Namespace Structures.Monitors

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


End Namespace


