
Imports System.Runtime.InteropServices

Namespace Monitor

    ''' <summary>
    ''' 监视器操作
    ''' </summary>
    Public Class Monitor

        ''' <summary>
        ''' 获取指定句柄窗口所在的监视器句柄
        ''' </summary>
        ''' <param name="hWnd">窗口句柄</param>
        ''' <param name="flag">监视器识别类型</param>
        ''' <returns></returns>
        Public Shared Function MonitorFromWindow(ByVal hWnd As System.IntPtr, ByVal flag As MONITOR_DEFAULTTO) As System.IntPtr
            Return Win32API.MonitorFromWindow(hWnd, flag)
        End Function


        ''' <summary>
        ''' 设置窗口为最大化
        ''' </summary>
        ''' <param name="hWnd">窗口句柄</param>
        ''' <param name="lParam"></param>
        Public Shared Sub SetWindowToMax(ByVal hWnd As System.IntPtr, ByVal lParam As System.IntPtr)

            Dim mmi As Structures.Window.MINMAXINFO = Marshal.PtrToStructure(lParam, GetType(Structures.Window.MINMAXINFO))

            ' 获取窗口所在位置的监视器信息
            Dim targetScreen As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromHandle(hWnd)

            With mmi
                ' 设置窗口坐标
                .ptMaxPosition.X = Math.Abs(targetScreen.WorkingArea.Left - targetScreen.Bounds.Left)
                .ptMaxPosition.Y = Math.Abs(targetScreen.WorkingArea.Top - targetScreen.Bounds.Top)
                ' 设置窗口尺寸
                .ptMaxSize.X = targetScreen.WorkingArea.Width
                .ptMaxSize.Y = targetScreen.WorkingArea.Height
                ' 设置拖拽尺寸。这个必须要设置。即最大只能拖拽到全屏尺寸大小。
                .ptMaxTrackSize.X = .ptMaxSize.X
                .ptMaxTrackSize.Y = .ptMaxSize.Y
            End With

            '' 获取最近的监视器句柄
            'Dim hMonitor As System.IntPtr = MonitorFromWindow(hWnd, MONITOR_DEFAULTTO.MONITOR_DEFAULTTONEAREST)

            'If (hMonitor <> System.IntPtr.Zero) Then
            '    Console.WriteLine(hMonitor)
            'Else
            '    Console.WriteLine("TT")
            'End If
            '' 获取监视器信息
            'Dim info As Structures.Monitors.MONITORINFO = New Structures.Monitors.MONITORINFO()
            'info.cbSize = Marshal.SizeOf(info.GetType())
            'Dim r As Boolean = Win32API.GetMonitorInfo(hMonitor, info)

            'Dim rcWorkArea As Structures.Rectangle.RECT = info.rcWork
            'Dim rcMonitorArea As Structures.Rectangle.RECT = info.rcMonitor


            'mmi.ptMaxPosition.X = Math.Abs(rcWorkArea.left - rcMonitorArea.left)
            'mmi.ptMaxPosition.Y = Math.Abs(rcWorkArea.top - rcMonitorArea.top)
            'mmi.ptMaxSize.X = Math.Abs(rcWorkArea.right - rcWorkArea.left)
            'mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top)



            Marshal.StructureToPtr(mmi, lParam, True)
        End Sub

    End Class



End Namespace
