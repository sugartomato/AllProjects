Namespace Win32Messages
    ''' <summary>
    ''' 系统消息值定义
    ''' 
    ''' </summary>
    Public Class Messages


        ' http://blog.163.com/yijia_luo/blog/static/12538832012312105632156/
        ' https://msdn.microsoft.com/en-us/library/windows/desktop/bg126469(v=vs.85).aspx




#Region "Mouse Input Notifications"

        ''' <summary>
        ''' Sent to a window in order to determine what part of the window corresponds to a particular screen coordinate. 
        ''' This can happen, for example, when the cursor moves, when a mouse button is pressed or released, or in response to a call to a function such as WindowFromPoint. 
        ''' If the mouse is not captured, the message is sent to the window beneath the cursor. Otherwise, the message is sent to the window that has captured the mouse.
        ''' </summary>
        Public Const WM_NCHITTEST As Int32 = &H84

        ''' <summary>
        ''' Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. 
        ''' If the mouse is not captured, the message is posted to the window beneath the cursor. 
        ''' Otherwise, the message is posted to the window that has captured the mouse.
        ''' </summary>
        ''' <link ref="https://msdn.microsoft.com/en-us/library/windows/desktop/ms645606(v=vs.85).aspx" />
        Public Const WM_LBUTTONDBLCLK As Int32 = &H203


#End Region


#Region "Window Notifications"
        ''' <summary>
        ''' Sent to a window when the size or position of the window is about to change. 
        ''' An application can use this message to override the window's default maximized size and position, or its default minimum or maximum tracking size.
        ''' 当窗体的尺寸或者位置发生改变时发送给窗体。
        ''' 应用程序可以使用该消息重写窗体的默认最大尺寸或者位置，或者最小/最大的可拉伸尺寸。
        ''' </summary>
        ''' <link ref="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632626(v=vs.85).aspx" />
        Public Const WM_GETMINMAXINFO As Int32 = &H24


#End Region



    End Class

    ''' <summary>
    ''' Windows消息枚举
    ''' </summary>
    Public Enum EnumMESSAGES As Integer
        WM_NCHITTEST = &H84

        ''' <summary>
        ''' Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. 
        ''' If the mouse is not captured, the message is posted to the window beneath the cursor. 
        ''' Otherwise, the message is posted to the window that has captured the mouse.
        ''' </summary>
        ''' <see ref="https://msdn.microsoft.com/en-us/library/windows/desktop/ms645606(v=vs.85).aspx"/>
        WM_LBUTTONDBLCLK = &H203
    End Enum

End Namespace
