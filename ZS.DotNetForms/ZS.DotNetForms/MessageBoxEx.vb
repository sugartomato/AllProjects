Public Class MessageBoxEx

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Me.Size = New Drawing.Size(420, 280)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub

    Public Sub New(ByVal msgContent As String, ByVal msgType As MessageType, ByVal ex As Exception)
        Me.New()

        Me.MsgContent = msgContent
        Me.MsgType = msgType
        Me.Ex = ex

    End Sub

    Private Sub MessageBoxEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = Title
            btnErrorDetial.Visible = Not Ex Is Nothing
            txtTextInfo.Text = MsgContent

            picIcon.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage

            Select Case MsgType
                Case MessageType.Error
                    lblTitle.Text = "发生了错误！"
                    picIcon.Image = My.Resources.ResourceMain._Error
                Case MessageType.Info
                    lblTitle.Text = "信息！"
                    picIcon.Image = My.Resources.ResourceMain.information
                Case MessageType.Success
                    lblTitle.Text = "成功！"
                    picIcon.Image = My.Resources.ResourceMain.Success
                Case MessageType.Warning
                    lblTitle.Text = "警告！"
                    picIcon.Image = My.Resources.ResourceMain.Warning
            End Select

            If Not Me.Ex Is Nothing Then
                btnErrorDetial.Visible = True
                RemoveHandler btnErrorDetial.Click, AddressOf btnErrorDetial_Click
                AddHandler btnErrorDetial.Click, AddressOf btnErrorDetial_Click
            Else
                btnErrorDetial.Visible = False
            End If

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


    Private Sub btnErrorDetial_Click(sender As Object, e As EventArgs)
        Dim frm As ExceptionDetial = New ExceptionDetial()
        frm.Ex = Me.Ex
        frm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class