Imports SysDrawing = System.Drawing
Imports System.IO

Namespace Drawing

    ''' <summary>
    ''' 图片处理
    ''' </summary>
    <Obsolete("使用ZS.Common.ImageHelper类代替此类")>
    Public Class Image

#Region "图片尺寸与压缩"

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


        Public Shared Function Compress(ByVal source As System.Drawing.Bitmap, ByVal level As Int32) As Stream
            Dim _encPara As System.Drawing.Imaging.EncoderParameter
            Dim _encParas As System.Drawing.Imaging.EncoderParameters



        End Function


#End Region


        Public Shared Function GetEncoder(ByVal format As System.Drawing.Imaging.ImageFormat) As System.Drawing.Imaging.ImageCodecInfo
            Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
            Dim codec As System.Drawing.Imaging.ImageCodecInfo
            For Each codec In codecs
                If codec.FormatID = format.Guid Then
                    Return codec
                End If
            Next
            Return Nothing
        End Function


        Public Shared Function GetEncoder(ByVal mimeType As String) As System.Drawing.Imaging.ImageCodecInfo
            Dim codecs As System.Drawing.Imaging.ImageCodecInfo() = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
            Dim codec As System.Drawing.Imaging.ImageCodecInfo
            For Each codec In codecs
                If codec.MimeType = mimeType Then
                    Return codec
                End If
            Next
            Return Nothing
        End Function

    End Class


End Namespace

