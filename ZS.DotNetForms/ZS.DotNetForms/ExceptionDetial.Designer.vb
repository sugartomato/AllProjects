<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExceptionDetial
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtErrorDetial = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnInnerEx = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtErrorDetial
        '
        Me.txtErrorDetial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErrorDetial.BackColor = System.Drawing.Color.DarkGreen
        Me.txtErrorDetial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtErrorDetial.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtErrorDetial.ForeColor = System.Drawing.Color.White
        Me.txtErrorDetial.Location = New System.Drawing.Point(12, 12)
        Me.txtErrorDetial.Multiline = True
        Me.txtErrorDetial.Name = "txtErrorDetial"
        Me.txtErrorDetial.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtErrorDetial.Size = New System.Drawing.Size(776, 385)
        Me.txtErrorDetial.TabIndex = 0
        Me.txtErrorDetial.Text = "异常内容"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(708, 403)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 35)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "确定(&O)"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnInnerEx
        '
        Me.btnInnerEx.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInnerEx.Location = New System.Drawing.Point(622, 403)
        Me.btnInnerEx.Name = "btnInnerEx"
        Me.btnInnerEx.Size = New System.Drawing.Size(80, 35)
        Me.btnInnerEx.TabIndex = 2
        Me.btnInnerEx.Text = "内部异常(&I)"
        Me.btnInnerEx.UseVisualStyleBackColor = True
        '
        'ExceptionDetial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnInnerEx)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtErrorDetial)
        Me.Name = "ExceptionDetial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "错误详情"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtErrorDetial As Windows.Forms.TextBox
    Friend WithEvents btnOK As Windows.Forms.Button
    Friend WithEvents btnInnerEx As Windows.Forms.Button
End Class
