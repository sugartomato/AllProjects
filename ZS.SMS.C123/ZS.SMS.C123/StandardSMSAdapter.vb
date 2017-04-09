
''' <summary>
''' C123短信平台 标准短信接口
''' </summary>
''' <remarks></remarks>
Public Class StandardSMSAdapter

#Region "构造"


    ''' <summary>短信网账号</summary>
    Private m_UserID As String = String.Empty
    ''' <summary>短信网密码</summary>
    Private m_Password As String = String.Empty

    ''' <summary>
    ''' 通过用户名和密码构造一个新的短信发送对象
    ''' </summary>
    ''' <param name="userID">账号</param>
    ''' <param name="password">密码，是MD5加密之后的密码</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal userID As String, ByVal password As String)

        m_UserID = userID
        m_Password = password

    End Sub

#End Region


#Region "单例"

    ''' <summary>单例对象</summary>
    Private Shared _instance As StandardSMSAdapter = Nothing
    ''' <summary>
    ''' 返回SMS的单例对象
    ''' </summary>
    ''' <param name="userID">账号</param>
    ''' <param name="password">密码，是MD5加密之后的密码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Instance(ByVal userID As String, ByVal password As String) As StandardSMSAdapter
        If (_instance Is Nothing) Then
            _instance = New StandardSMSAdapter(userID, password)
        End If
        Return _instance
    End Function

#End Region



#Region "获取发送状态"

    Public Function GetSendStatus()


        Dim strBaseUrl As String = "http://smsapi.c123.cn/DataPlatform/DataApi?action= getSendState"
        Dim strPostData As String = "&ac=1001@" & m_UserID & "&authkey=" & m_Password.ToUpper()
        Dim objHttpRequest As System.Net.HttpWebRequest = Nothing
        Dim objHttpResponse As System.Net.HttpWebResponse = Nothing


        Try
            objHttpRequest = System.Net.HttpWebRequest.Create(strBaseUrl)
            objHttpRequest.Method = "GET"
            objHttpRequest.ContentType = "application/x-www-form-urlencoded"

            objHttpResponse = objHttpRequest.GetResponse()
            Dim state As System.Net.HttpStatusCode = objHttpResponse.StatusCode

            ' 请求执行成功时，获取返回的状态消息。
            If (state = Net.HttpStatusCode.OK) Then
                Dim str As String = GetWebResponseString(objHttpResponse)

                If str = "100" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New ApplicationException("执行发送程序异常。", ex)
        Finally
            objHttpResponse = Nothing
            objHttpRequest = Nothing
        End Try


    End Function



#End Region


    Private Function GetWebResponseString(ByVal obj As System.Net.HttpWebResponse)
        If (obj Is Nothing) Then Return String.Empty

        Dim sr As System.IO.StreamReader = Nothing
        Dim strReturn As String = String.Empty

        Try
            sr = New System.IO.StreamReader(obj.GetResponseStream())
            strReturn = sr.ReadToEnd()
        Catch ex As Exception
            Throw New ApplicationException("读取HttpWebResponse返回结果失败。", ex)
        Finally
            obj.GetResponseStream().Close()
            sr.Close()
            sr = Nothing
        End Try
        Return strReturn
    End Function

End Class
