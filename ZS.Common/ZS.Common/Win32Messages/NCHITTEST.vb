Namespace Win32Messages


    Public Class NCHITTEST

        ' http://www.cnblogs.com/findumars/p/5304564.html


        ''' <summary>
        ''' In the border of a window that does not have a sizing border.
        ''' </summary>
        Public Const HTBORDER As Int32 = 18

        ''' <summary>
        ''' In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).
        ''' </summary>
        Public Const HTBOTTOM As Int32 = 15

        ''' <summary>
        ''' In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        ''' </summary>
        Public Const HTBOTTOMLEFT As Int32 = 16

        ''' <summary>
        ''' In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
        ''' </summary>
        Public Const HTBOTTOMRIGHT As Int32 = 17

        ''' <summary>
        ''' In a title bar.
        ''' </summary>
        Public Const HTCAPTION As Int32 = 2

        ''' <summary>
        ''' In a client area.
        ''' </summary>
        Public Const HTCLIENT As Int32 = 1

        ''' <summary>
        ''' In a Close button.
        ''' </summary>
        Public Const HTCLOSE As Int32 = 20

        ''' <summary>
        ''' On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function produces a system beep to indicate an error).
        ''' </summary>
        Public Const HTERROR As Int32 = -2

        ''' <summary>
        ''' In a size box (same as HTSIZE).
        ''' </summary>
        Public Const HTGROWBOX As Int32 = 4

        ''' <summary>
        ''' In a Help button.
        ''' </summary>
        Public Const HTHELP As Int32 = 21

        ''' <summary>
        ''' In a horizontal scroll bar.
        ''' </summary>
        Public Const HTHSCROLL As Int32 = 6

        ''' <summary>
        ''' In the left border of a resizable window (the user can click the mouse to resize the window horizontally).
        ''' </summary>
        Public Const HTLEFT As Int32 = 10

        ''' <summary>
        ''' In a menu.
        ''' </summary>
        Public Const HTMENU As Int32 = 5

        ''' <summary>
        ''' In a Maximize button.
        ''' </summary>
        Public Const HTMAXBUTTON As Int32 = 9

        ''' <summary>
        ''' In a Minimize button.
        ''' </summary>
        Public Const HTMINBUTTON As Int32 = 8

        ''' <summary>
        ''' On the screen background or on a dividing line between windows.
        ''' </summary>
        Public Const HTNOWHERE As Int32 = 0

        ''' <summary>
        ''' In a Minimize button.
        ''' </summary>
        Public Const HTREDUCE As Int32 = 8

        ''' <summary>
        ''' In the right border of a resizable window (the user can click the mouse to resize the window horizontally).
        ''' </summary>
        Public Const HTRIGHT As Int32 = 11

        ''' <summary>
        ''' In a window menu or in a Close button in a child window.
        ''' </summary>
        Public Const HTSYSMENU As Int32 = 3

        ''' <summary>
        ''' In the upper-horizontal border of a window.
        ''' </summary>
        Public Const HTTOP As Int32 = 12

        ''' <summary>
        ''' In the upper-left corner of a window border.
        ''' </summary>
        Public Const HTTOPLEFT As Int32 = 13

        ''' <summary>
        ''' In the upper-right corner of a window border.
        ''' </summary>
        Public Const HTTOPRIGHT As Int32 = 14

        ''' <summary>
        ''' In a window currently covered by another window in the same thread
        ''' (the message will be sent to underlying windows in the same thread until one of them returns a code that is not HTTRANSPARENT).
        ''' </summary>
        Public Const HTTRANSPARENT As Int32 = -1

        ''' <summary>
        ''' In the vertical scroll bar.
        ''' </summary>
        Public Const HTVSCROLL As Int32 = 7

        ''' <summary>
        ''' In a Maximize button.
        ''' </summary>
        Public Const HTZOOM As Int32 = 9


    End Class

End Namespace
