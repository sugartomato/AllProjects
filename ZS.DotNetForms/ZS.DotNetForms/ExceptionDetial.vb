Public Class ExceptionDetial

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        btnInnerEx.Visible = False
    End Sub

    Public Sub New(ByVal ex As Exception)
        Me.New()
        Me.Ex = ex
    End Sub


    Private Sub ExceptionDetial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.txtErrorDetial.Clear()

            If Me.Ex Is Nothing Then
                txtErrorDetial.Text = "无相关异常信息！"
                btnInnerEx.Visible = False
                Return
            End If

            txtErrorDetial.AppendText(Me.Ex.Message + vbNewLine + Me.Ex.StackTrace)

            If Not Me.Ex.InnerException Is Nothing Then
                btnInnerEx.Visible = True
                RemoveHandler btnInnerEx.Click, AddressOf btnInnerEx_Click
                AddHandler btnInnerEx.Click, AddressOf btnInnerEx_Click
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Property Ex As Exception = Nothing

    Private Sub btnInnerEx_Click(sender As Object, e As EventArgs)
        Dim frm As ExceptionDetial = New ExceptionDetial()
        frm.Ex = Me.Ex.InnerException
        frm.ShowDialog()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

End Class