Imports System.Windows.Forms

''' <summary>
''' 文本预览窗体
''' </summary>
''' <remarks></remarks>
Public Class TextPreview

#Region "构造"

    Public Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

    End Sub

    Public Sub New(ByVal showInTaskbar As Boolean, ByVal windowState As System.Windows.Forms.FormWindowState)

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Me.ShowInTaskbar = showInTaskbar
        Me.WindowState = windowState

    End Sub

#End Region

    Private Sub TextPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtMain.Text = _propPreviewText
        txtMain.SelectionStart = 0
        chkWarp.Checked = False
        chkEdit.Checked = False
    End Sub


    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        txtMain.SelectAll()
        txtMain.Copy()
        lblStatus.Text = "内容已复制到剪贴板！"
    End Sub

    Private Sub chkWarp_CheckedChanged(sender As Object, e As EventArgs) Handles chkWarp.CheckedChanged
        If (chkWarp.Checked = True) Then
            txtMain.ScrollBars = ScrollBars.Vertical
            txtMain.WordWrap = True
        Else
            txtMain.ScrollBars = ScrollBars.Both
            txtMain.WordWrap = False
        End If
    End Sub

    Private Sub chkEdit_CheckedChanged(sender As Object, e As EventArgs) Handles chkEdit.CheckedChanged

        If (chkEdit.Checked = True) Then
            txtMain.ReadOnly = False
        Else
            txtMain.ReadOnly = True
        End If

    End Sub


    Private _propPreviewText As String
    ''' <summary>
    ''' 设置要显示的文本。
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property PreviewText() As String
        Set(ByVal value As String)
            _propPreviewText = value
            txtMain.Text = _propPreviewText
        End Set
    End Property


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class