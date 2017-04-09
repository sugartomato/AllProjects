Public Class PopupWindow

    Private countTime As System.DateTime
    Private _oriTitle As String

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)

        Dim thisScrees As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromHandle(Me.Handle)
        Dim x As Int32
        Dim y As Int32
        x = thisScrees.WorkingArea.Width - Me.Width
        y = thisScrees.WorkingArea.Height - Me.Height

        If thisScrees.WorkingArea.Location.X <> 0 Then
            x = thisScrees.WorkingArea.Location.X + thisScrees.WorkingArea.Width - Me.Width
            y = thisScrees.WorkingArea.Location.Y + thisScrees.WorkingArea.Height - Me.Height
        End If

        Me.Location = New Drawing.Point(x, y)
        ZS.Common.Win32.API.AnimateWindow(Me.Handle, 500, ZS.Common.Win32.API.AnimateWindowType.AW_HOR_NEGATIVE)

        MyBase.OnLoad(e)
    End Sub

    ''' <summary>
    ''' 标题
    ''' </summary>
    ''' <returns></returns>
    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    ''' <summary>
    ''' 提示信息内容
    ''' </summary>
    ''' <returns></returns>
    Public Property Content() As String
        Get
            Return txtContent.Text
        End Get
        Set(ByVal value As String)
            txtContent.Text = value
        End Set
    End Property

    Private _propIsAutoClose As Boolean = True
    ''' <summary>
    ''' 是否自动关闭
    ''' </summary>
    ''' <returns></returns>
    Public Property IsAutoColse() As Boolean
        Get
            Return _propIsAutoClose
        End Get
        Set(ByVal value As Boolean)
            _propIsAutoClose = value
        End Set
    End Property

    Private _propDelay As Int32 = 5
    ''' <summary>
    ''' 自动关闭时间。单位为秒，5.
    ''' </summary>
    ''' <returns></returns>
    Public Property Delay() As Int32
        Get
            Return _propDelay
        End Get
        Set(ByVal value As Int32)
            _propDelay = value
        End Set
    End Property

    Private Sub PopupWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        countTime = DateTime.Now
        _oriTitle = Me.Text

        If _propIsAutoClose Then
            Timer1.Enabled = True
            Timer1.Interval = 1000
            Timer1.Start()
            Me.Text = _oriTitle & " - [" & _propDelay & "]"
        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim t As TimeSpan = ((countTime.AddSeconds(_propDelay)) - DateTime.Now)
        Me.Text = _oriTitle & " - [" & t.Seconds & "]"
        'If (DateTime.Now.AddSeconds(-_propDelay) > countTime) Then
        If (t.Seconds <= 0) Then
            CloseMe()
            Timer1.Stop()
        End If
    End Sub

    Private Sub CloseMe()
        ZS.Common.Win32.API.AnimateWindow(Me.Handle, 500, ZS.Common.Win32.API.AnimateWindowType.AW_HIDE + Common.Win32.API.AnimateWindowType.AW_BLEND)
        Me.Dispose()
    End Sub
End Class