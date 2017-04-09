Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = ZS.Images.ImageAdapter.Instance().GetImage("Actions/AddItem_32x32.png")
    End Sub

End Class
