
''' <summary>
''' C123短信网 简易短信发送接口
''' </summary>
''' <remarks></remarks>
Public Class SimpleSMSAdapter

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
    Private Shared _instance As SimpleSMSAdapter = Nothing
    ''' <summary>
    ''' 返回SMS的单例对象
    ''' </summary>
    ''' <param name="userID">账号</param>
    ''' <param name="password">密码，是MD5加密之后的密码</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Instance(ByVal userID As String, ByVal password As String) As SimpleSMSAdapter
        If (_instance Is Nothing) Then
            _instance = New SimpleSMSAdapter(userID, password)
        End If
        Return _instance
    End Function

#End Region


    ''' <summary>
    ''' 针对指定的手机号码发送短信
    ''' </summary>
    ''' <param name="v_Phone">手机号码集合</param>
    ''' <param name="v_Message">短消息内容</param>
    ''' <param name="v_Error">执行失败的消息</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SendSMS(ByVal v_Phone As List(Of String), ByVal v_Message As String, ByRef v_Error As String) As Boolean

        Dim strPhones As String = String.Empty
        Dim strBaseUrl As String = "http://dxhttp.c123.cn/tx/"
        Dim strPostData As String = "uid=" & m_UserID & "&pwd=" & m_Password
        Dim objHttpRequest As System.Net.HttpWebRequest = Nothing
        Dim objHttpResponse As System.Net.HttpWebResponse = Nothing

        ' 生成发送的手机号码
        If (v_Phone Is Nothing OrElse v_Phone.Count = 0) Then
            Return False
        End If
        strPostData &= "&mobile="
        For i As Int32 = 0 To v_Phone.Count - 1
            strPhones &= v_Phone(i) & ","
        Next
        strPhones = strPhones.Trim(",")
        strPostData &= strPhones

        ' 短信内容
        'strPostData &= "&content=" & v_Message
        'strPostData &= "&content=" & System.Uri.EscapeUriString(v_Message)
        strPostData &= "&content=" & System.Uri.EscapeDataString(v_Message) ' 将短信内容进行编码，解决特殊字符传输的问题。
        'strPostData = System.Uri.EscapeDataString(strPostData)

        Try
            objHttpRequest = System.Net.HttpWebRequest.Create(strBaseUrl)
            objHttpRequest.Method = "POST"
            objHttpRequest.ContentType = "application/x-www-form-urlencoded"

            Dim data As System.Byte() = System.Text.Encoding.UTF8.GetBytes(strPostData)

            Dim sw As System.IO.Stream = Nothing
            sw = objHttpRequest.GetRequestStream()
            sw.Write(data, 0, data.Length)

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
                v_Error = "执行发送请求失败。代码：" & state.ToString()
                Return False
            End If
        Catch ex As Exception
            Throw New ApplicationException("执行发送程序异常。", ex)
        Finally
            objHttpResponse = Nothing
            objHttpRequest = Nothing
        End Try

    End Function

    ''' <summary>
    ''' 获取剩余的短信条数
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Get_RemainderAmount() As Int32
        Dim strBaseUrl As String = "http://dxhttp.c123.cn/mm/?uid=" & m_UserID & "&pwd=" & m_Password
        Dim objHttpRequest As System.Net.HttpWebRequest = Nothing
        Dim objHttpResponse As System.Net.HttpWebResponse = Nothing

        Try

            objHttpRequest = System.Net.HttpWebRequest.Create(strBaseUrl)
            objHttpRequest.Method = "GET"
            objHttpResponse = objHttpRequest.GetResponse()
            Dim state As System.Net.HttpStatusCode = objHttpResponse.StatusCode
            If (state = Net.HttpStatusCode.OK) Then
                Dim str As String = GetWebResponseString(objHttpResponse)
                ' 替换掉默认返回的分隔符。用默认的分隔符进行分割，数组就是三个，中间会产生一个空字符串。
                str = str.Replace("||", "-")
                ' 接口返回的格式为 状态码||剩余可发短信条数，例如 100||22348
                Dim arrCount As String() = str.Split("-")
                If arrCount.Length = 2 Then
                    Return Int32.Parse(arrCount(1))
                Else
                    Throw New ApplicationException("获取的短信剩余条数不是有效的数字。" & str)
                End If

            Else
                Throw New ApplicationException("http请求状态错误。" & state)
            End If

        Catch ex As Exception
            Throw New ApplicationException("获取短信剩余条数失败。", ex)
        Finally
            objHttpResponse = Nothing
            objHttpRequest = Nothing
        End Try

    End Function

    Private Function SendSMSByPost()

    End Function





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
