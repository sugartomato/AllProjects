Imports System.Windows.Forms
Imports Outlook = Microsoft.Office.Interop.Outlook
Public Class BatchSaveAttachFile

    ''' <summary>
    ''' 选择保存目录
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSelectSaveFolder_Click(sender As Object, e As EventArgs) Handles btnSelectSaveFolder.Click
        Dim f As FolderBrowserDialog = New FolderBrowserDialog()
        If (f.ShowDialog() = DialogResult.OK) Then
            lblSaveFolder.Text = f.SelectedPath
        End If
    End Sub

    ''' <summary>
    ''' 执行保存
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' 检查设置

        If (Not System.IO.Directory.Exists(lblSaveFolder.Text)) Then
            MsgBox("清设置保存目录！")
            Exit Sub
        End If

        Dim _counter As Int32 = 1
        Try
            Dim inBox As Outlook.MAPIFolder = Globals.ThisAddIn.Application.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox)
            Dim inBoxItems As Outlook.Items = inBox.Items
            Dim tmpMail As Outlook.MailItem = Nothing

            For Each item As Object In inBoxItems
                tmpMail = CType(item, Outlook.MailItem)
                WriteConsole("正在处理邮件：" & tmpMail.Subject)
                If (Not tmpMail Is Nothing) Then
                    If tmpMail.Attachments.Count > 0 Then
                        For Each f As Outlook.Attachment In tmpMail.Attachments
                            f.SaveAsFile(lblSaveFolder.Text & "\" & f.FileName)
                        Next
                    End If
                    _counter += 1
                End If

                If (_counter > 100) Then
                    Exit For
                End If
            Next

            WriteConsole("处理完成！")
        Catch ex As Exception
            WriteConsole("执行异常：" & ex.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 退出
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub WriteConsole(ByVal msg As String)
        txtConsole.AppendText(msg & vbNewLine)
    End Sub
End Class