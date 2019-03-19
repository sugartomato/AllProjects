<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MessageBoxEx
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
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.txtTextInfo = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnErrorDetial = New System.Windows.Forms.Button()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picIcon
        '
        Me.picIcon.Location = New System.Drawing.Point(3, 3)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(50, 50)
        Me.picIcon.TabIndex = 0
        Me.picIcon.TabStop = False
        '
        'txtTextInfo
        '
        Me.txtTextInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTextInfo.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTextInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTextInfo.Font = New System.Drawing.Font("宋体", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.txtTextInfo.Location = New System.Drawing.Point(3, 59)
        Me.txtTextInfo.Multiline = True
        Me.txtTextInfo.Name = "txtTextInfo"
        Me.txtTextInfo.ReadOnly = True
        Me.txtTextInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtTextInfo.ShortcutsEnabled = False
        Me.txtTextInfo.Size = New System.Drawing.Size(390, 124)
        Me.txtTextInfo.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(313, 189)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 35)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "确定(O)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("宋体", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(59, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(152, 27)
        Me.lblTitle.TabIndex = 3
        Me.lblTitle.Text = "发生了错误"
        '
        'btnErrorDetial
        '
        Me.btnErrorDetial.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnErrorDetial.Location = New System.Drawing.Point(227, 189)
        Me.btnErrorDetial.Name = "btnErrorDetial"
        Me.btnErrorDetial.Size = New System.Drawing.Size(80, 35)
        Me.btnErrorDetial.TabIndex = 4
        Me.btnErrorDetial.Text = "详细错误"
        Me.btnErrorDetial.UseVisualStyleBackColor = True
        Me.btnErrorDetial.Visible = False
        '
        'MessageBoxEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 236)
        Me.Controls.Add(Me.btnErrorDetial)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtTextInfo)
        Me.Controls.Add(Me.picIcon)
        Me.Name = "MessageBoxEx"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "消息提示"
        Me.TopMost = True
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picIcon As Windows.Forms.PictureBox
    Friend WithEvents txtTextInfo As Windows.Forms.TextBox
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents lblTitle As Windows.Forms.Label
    Friend WithEvents btnErrorDetial As Windows.Forms.Button
End Class
