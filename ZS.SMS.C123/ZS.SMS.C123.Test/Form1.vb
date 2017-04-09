Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim obj As ZS.SMS.C123.SimpleSMSAdapter = ZS.SMS.C123.SimpleSMSAdapter.Instance("501006770001", "6e6e334fb000a7b89fcdd2487379c414")
        Dim strError As String = String.Empty
        Dim mm As List(Of String) = New List(Of String)()
        mm.Add("15801524452")

        obj.SendSMS(mm, ".Net短信发送测试!@#$%^&*()_+\|[]{};'/?.,<>", strError)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As ZS.SMS.C123.StandardSMSAdapter = ZS.SMS.C123.StandardSMSAdapter.Instance("501006770001", "6e6e334fb000a7b89fcdd2487379c414")
        obj.GetSendStatus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim obj As ZS.SMS.C123.SimpleSMSAdapter = ZS.SMS.C123.SimpleSMSAdapter.Instance("501006770001", "6e6e334fb000a7b89fcdd2487379c414")
            Dim count As Int32 = obj.Get_RemainderAmount()
            MessageBox.Show(count)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class
