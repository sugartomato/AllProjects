Imports System.Reflection

''' <summary>
''' 图片读取
''' </summary>
''' <remarks></remarks>
Public Class ImageAdapter

#Region "构造"

    Private m_ImageStream As Dictionary(Of String, System.IO.Stream) = Nothing

    Public Sub New()
        Try
            m_ImageStream = New Dictionary(Of String, IO.Stream)()

            Dim objThisAssembly As Assembly = Assembly.GetExecutingAssembly()

            Dim data As Byte() = Nothing
            Dim dataType As String = String.Empty

            Using reader As New Resources.ResourceReader(objThisAssembly.GetManifestResourceStream("ZS.Images.g.resources"))
                Dim dict As IDictionaryEnumerator = reader.GetEnumerator()

                While dict.MoveNext

                    Dim key As String = dict.Key
                    reader.GetResourceData(key, dataType, data)
                    If (Not String.Equals(dataType, "ResourceTypeCode.Stream", StringComparison.Ordinal)) Then
                        Continue While
                    End If

                    m_ImageStream.Add(key, dict.Value)

                End While

            End Using

        Catch ex As Exception
            Throw New ApplicationException("初始化图片资源失败。", ex)
        End Try

    End Sub

#End Region


#Region "单例"

    Private Shared _instance As ImageAdapter = Nothing
    ''' <summary>
    ''' 获取图片容器类的单例
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Instance() As ImageAdapter
        If _instance Is Nothing Then
            _instance = New ImageAdapter()
        End If
        Return _instance
    End Function

#End Region


    ''' <summary>
    ''' 获取指定名称的图片，以System.Drawing.Image形式返回。
    ''' </summary>
    ''' <param name="imgUrl">。图片路径，不包含根Image目录。例如：Actions/Add_16x16.png</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetImage(ByVal imgUrl As String) As System.Drawing.Image
        Try
            imgUrl = imgUrl.Replace("\", "/")
            imgUrl = "images/" & imgUrl
            imgUrl = imgUrl.Replace("//", "/").ToLower()
            If (m_ImageStream.ContainsKey(imgUrl)) Then
                Return System.Drawing.Image.FromStream(m_ImageStream(imgUrl))
            Else
                Return System.Drawing.Image.FromStream(m_ImageStream("images/Miscellaneous/ImageNotExist.png".ToLower()))
            End If
        Catch ex As Exception
            Throw New ApplicationException("获取图片【" & imgUrl & "】失败", ex)
        End Try

    End Function

    ''' <summary>
    ''' 获取指定名称的图片，以System.IO.Stream形式返回。
    ''' </summary>
    ''' <param name="imgUrl">。图片路径，不包含根Image目录。例如：Actions/Add_16x16.png</param>
    ''' <returns></returns>
    Public Function GetImageAsStream(ByVal imgUrl As String) As System.IO.Stream
        Try
            imgUrl = imgUrl.Replace("\", "/")
            imgUrl = "images/" & imgUrl
            imgUrl = imgUrl.Replace("//", "/").ToLower()
            If (m_ImageStream.ContainsKey(imgUrl)) Then
                Return m_ImageStream(imgUrl)
            Else
                Return m_ImageStream("images/Miscellaneous/ImageNotExist.png".ToLower())
            End If
        Catch ex As Exception
            Throw New ApplicationException("获取图片【" & imgUrl & "】失败", ex)
        End Try
    End Function

End Class
