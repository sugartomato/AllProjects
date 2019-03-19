Public Class MessageBoxEx

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    Public Sub New(ByVal msgContent As String, ByVal msgType As MessageType, ByVal ex As Exception)

        ' 此调用是设计器所必需的。
        InitializeComponent()
        Me.MsgContent = msgContent
        Me.MsgType = msgType
        Me.Ex = ex
        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Private Sub MessageBoxEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = Title
            btnErrorDetial.Visible = Ex Is Nothing
            txtTextInfo.Text = MsgContent

            Select Case MsgType
                Case MessageType.Error
                    lblTitle.Text = "发生了错误！"
                    picIcon.Image = My.Resources.Img_Error
                Case MessageType.Info
                    lblTitle.Text = "信息！"
                    picIcon.Image = Nothing
                Case MessageType.Success
                    lblTitle.Text = "成功！"
                    picIcon.Image = My.Resources.Img_Success
                Case MessageType.Warning
                    lblTitle.Text = "警告！"
                    picIcon.Image = Nothing
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Public Property Title As String = "提示"

    ''' <summary>
    ''' 消息内容
    ''' </summary>
    ''' <returns></returns>
    Public Property MsgContent As String = String.Empty

    ''' <summary>
    ''' 消息类型
    ''' </summary>
    ''' <returns></returns>
    Public Property MsgType As MessageType

    ''' <summary>
    ''' 异常对象
    ''' </summary>
    ''' <returns></returns>
    Public Property Ex As Exception = Nothing

    Public Enum MessageType
        Info
        Warning
        [Error]
        Success
    End Enum

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class