
Imports ZS.Common

Public Class ZIPAddress

    Private m_IPAddress As String = String.Empty


    Public Sub New(ByVal ipAddress As String)
        If (Not IsIPAddress(ipAddress)) Then
            Throw New ApplicationException("无效的IP地址")
        End If
        m_IPAddress = ipAddress
    End Sub

    Public Overrides Function ToString() As String
        Return m_IPAddress
    End Function


    ''' <summary>
    ''' 检查指定的字符串是否为有效的IP地址
    ''' </summary>
    ''' <param name="ipAddress"></param>
    ''' <returns></returns>
    Public Shared Function IsIPAddress(ByVal ipAddress As String) As Boolean
        If (ipAddress Is Nothing) OrElse (ipAddress.Length = 0) Then Return False
        If (ipAddress.IsIPv4Address()) OrElse (ipAddress.IsIPv6Address) Then Return True
        Return False
    End Function

    ''' <summary>
    ''' 尝试将指定的字符串转换为ZIPAddress类型。如果转换成功，则返回True，并通过result转换成功的对象，如果转换失败，则返回False
    ''' </summary>
    ''' <param name="source">源字符串</param>
    ''' <param name="result">转换后的对象</param>
    ''' <returns></returns>
    Public Shared Function TryParse(ByVal source As String, ByRef result As ZIPAddress) As Boolean
        Try
            result = New ZIPAddress(source)
            Return True
        Catch ex As Exception
            result = Nothing
            Return False
        End Try
    End Function


End Class
