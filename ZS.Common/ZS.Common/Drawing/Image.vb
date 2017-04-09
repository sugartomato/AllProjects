Namespace Drawing

    Public Class Image





#Region "静态方法"

        ''' <summary>
        ''' 获取指定路径的图片的尺寸。
        ''' </summary>
        ''' <param name="pPath">图片的本地路径</param>
        ''' <returns></returns>
        Public Shared Function GetSize(ByVal pPath As String) As System.Drawing.Size
            If (Not System.IO.File.Exists(pPath)) Then
                Throw New Exception("指定的图片文件不存在！")
            End If


            Dim img As System.Drawing.Image = Nothing
            Dim imgSize As System.Drawing.Size = Nothing
            Try
                img = System.Drawing.Image.FromFile(pPath)
                imgSize = New System.Drawing.Size(img.Width, img.Height)
            Catch ex As Exception
                Throw New Exception("不能打开的图片文件。", ex)
            End Try
        End Function



#End Region

    End Class


End Namespace

