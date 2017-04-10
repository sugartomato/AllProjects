<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BatchSaveAttachFile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rbtLast100 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelectSaveFolder = New System.Windows.Forms.Button()
        Me.lblSaveFolder = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 219)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "保存(&S)"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(118, 219)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "关闭(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rbtLast100
        '
        Me.rbtLast100.AutoSize = True
        Me.rbtLast100.Location = New System.Drawing.Point(6, 20)
        Me.rbtLast100.Name = "rbtLast100"
        Me.rbtLast100.Size = New System.Drawing.Size(77, 16)
        Me.rbtLast100.TabIndex = 1
        Me.rbtLast100.TabStop = True
        Me.rbtLast100.Text = "最近100封"
        Me.rbtLast100.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtLast100)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 84)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "筛选条件"
        '
        'txtConsole
        '
        Me.txtConsole.Location = New System.Drawing.Point(224, 12)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.Size = New System.Drawing.Size(261, 237)
        Me.txtConsole.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSaveFolder)
        Me.GroupBox2.Controls.Add(Me.btnSelectSaveFolder)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 111)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "保存设置"
        '
        'btnSelectSaveFolder
        '
        Me.btnSelectSaveFolder.Location = New System.Drawing.Point(6, 82)
        Me.btnSelectSaveFolder.Name = "btnSelectSaveFolder"
        Me.btnSelectSaveFolder.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSaveFolder.TabIndex = 0
        Me.btnSelectSaveFolder.Text = "保存目录"
        Me.btnSelectSaveFolder.UseVisualStyleBackColor = True
        '
        'lblSaveFolder
        '
        Me.lblSaveFolder.AutoSize = True
        Me.lblSaveFolder.Location = New System.Drawing.Point(87, 87)
        Me.lblSaveFolder.Name = "lblSaveFolder"
        Me.lblSaveFolder.Size = New System.Drawing.Size(41, 12)
        Me.lblSaveFolder.TabIndex = 1
        Me.lblSaveFolder.Text = "未设置"
        '
        'BatchSaveAttachFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 261)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtConsole)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "BatchSaveAttachFile"
        Me.Text = "BatchSaveAttachFile"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Windows.Forms.Button
    Friend WithEvents btnClose As Windows.Forms.Button
    Friend WithEvents rbtLast100 As Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents txtConsole As Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents btnSelectSaveFolder As Windows.Forms.Button
    Friend WithEvents lblSaveFolder As Windows.Forms.Label
End Class
