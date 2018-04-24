Imports System.Net

Namespace HttpHelper

    ''' <summary>
    ''' HTTP请求帮助类
    ''' </summary>
    Public Class HttpHelper



        ''' <summary>
        ''' 请求指定地址，并获取对应的HTML字符串
        ''' </summary>
        ''' <param name="url"></param>
        ''' <returns></returns>
        Public Shared Function GetHTML(ByVal url As String) As String
            Dim result As String = String.Empty

            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Try

                Using rstream As System.IO.Stream = response.GetResponseStream()
                    Using sreader As System.IO.StreamReader = New IO.StreamReader(rstream, System.Text.Encoding.UTF8)
                        result = sreader.ReadToEnd()
                    End Using
                End Using

                Return result
            Catch ex As Exception
                Throw
            Finally
                response.Close()
                response = Nothing
            End Try

            Return String.Empty
        End Function


        Public Shared Function [Get]() As HttpContent

        End Function



    End Class

End Namespace

