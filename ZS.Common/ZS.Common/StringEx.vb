Imports System.Runtime.CompilerServices
Imports System.ComponentModel

<Extension()>
Public Module StringEx

#Region "转换16进制"


    ''' <summary>
    ''' 将字符串转换为16进制字符串。该方法使用System.Text.Encoding.Default进行处理
    ''' 每个16进制字符之前使用\标记
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function ToHexString(ByVal str As String) As String

        Return str.ToHexString(System.Text.Encoding.Default)

    End Function

    ''' <summary>
    ''' 使用指定的编码格式将字符串转换为16进制。每个16进制字符之前使用\标记
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="encoding"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function ToHexString(ByVal str As String, ByVal encoding As System.Text.Encoding) As String

        If (str.Length = 0) Then
            Return String.Empty
        End If

        Dim bytes As Byte() = encoding.GetBytes(str)
        Dim arrString As String() = New String(bytes.Length) {}

        For i As Int32 = 0 To bytes.Length - 1
            arrString(i) = bytes(i).ToString("x")
        Next

        Dim strResult As String = String.Empty
        For i As Int32 = 0 To arrString.Length - 1
            If (Not arrString(i) Is Nothing AndAlso arrString(i).Length > 0) Then
                strResult &= "\" & arrString(i).ToUpper()
            Else
                strResult &= " "
            End If
        Next
        Return strResult

    End Function


#End Region

#Region "数字验证/转换"

    ''' <summary>
    ''' 验证字符串是否为Int32类型
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function IsInt32(ByVal str As String) As Boolean
        If (String.IsNullOrEmpty(str)) Then Return False
        Dim r As Int32 = 0
        If (Int32.TryParse(str, r)) Then
            Return True
        End If
        Return False
    End Function

    ''' <summary>
    ''' 将字符串转换为Int32数字
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ToInt32(ByVal str As String) As Int32
        If (String.IsNullOrEmpty(str)) Then Throw New ArgumentNullException("空字符串无法转换为数字")
        Dim r As Int32 = 0
        If (Int32.TryParse(str, r)) Then
            Return r
        Else
            Throw New ApplicationException("[" & str & "]为无效的数字。")
        End If

    End Function

#End Region

#Region "格式验证"

    ''' <summary>
    ''' 验证该地址是否为一个有效的IPv4地址
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IsIPv4Address(ByVal str As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(str, "^(([1-9]{1}[0-9]{0,1}|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\.){3}([1-9]{1}[0-9]{0,1}|1[0-9][0-9]|2[0-4][0-9]|25[0-5])$")
    End Function

    ''' <summary>
    ''' 验证该地址是否为一个有效的IPv6地址
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IsIPv6Address(ByVal str As String) As Boolean
        Throw New ApplicationException("未实现的方法")
    End Function

    ''' <summary>
    ''' 验证该字符串是否为一个有效的mac地址。支持如下格式：74-27-EA-F7-F6-B5或者74:27:EA:F7:F6:B5或者无分隔符7427EAF7F6B5
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IsMacAddress(ByVal str As String) As Boolean
        If (str Is Nothing) OrElse (str.Length = 0) Then Return False
        str = str.Replace(":", "-")
        If Not System.Text.RegularExpressions.Regex.IsMatch(str, "^([\da-fA-F]{2})(([-:]{0,1}[\da-fA-F]{2}){5})$") Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' 验证该字符串是否为一个有效的手机号码
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IsMobilePhoneNumber(ByVal str As String) As Boolean
        Return System.Text.RegularExpressions.Regex.IsMatch(str, "^[1]{1}[0-9]{2}[0-9]{8}$")
    End Function

#End Region

#Region "MD5"

    ''' <summary>
    ''' 获取该字符串的MD5
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ToMD5(ByVal str As String) As String
        Dim provider As System.Security.Cryptography.MD5CryptoServiceProvider
        provider = New Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytes As Byte() = System.Text.Encoding.Default.GetBytes(str)
        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()

        bytes = provider.ComputeHash(bytes)

        For Each b As Byte In bytes
            sb.Append(b.ToString("x2").ToUpper)
        Next

        Return sb.ToString()
    End Function

    ''' <summary>
    ''' 获取该字符串的MD5
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="encoded">编码格式。</param>
    ''' <returns></returns>
    Public Function ToMD5(ByVal str As String, ByVal encoded As System.Text.Encoding)
        If (encoded Is Nothing) Then
            Throw New ArgumentNullException("encoded")
        End If

        Dim provider As System.Security.Cryptography.MD5CryptoServiceProvider
        provider = New Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytes As Byte() = encoded.GetBytes(str)
        Dim sb As System.Text.StringBuilder = New Text.StringBuilder()

        bytes = provider.ComputeHash(bytes)

        For Each b As Byte In bytes
            sb.Append(b.ToString("x2").ToUpper)
        Next

        Return sb.ToString()

    End Function

#End Region

#Region "List转换"

    ''' <summary>
    ''' 将字符串按照指定的分隔符转换为泛型集合
    ''' </summary>
    ''' <param name="str"></param>
    ''' <param name="separator">跟个符号</param>
    ''' <param name="IsRemoveEmptyEntires">是否移除空内容的项目。默认为是，既如果分隔符号之间的内容为空，不添加到集合中</param>
    ''' <returns></returns>
    <Extension()>
    Public Function ToListOfString(ByVal str As String, ByVal separator As String, Optional ByVal IsRemoveEmptyEntires As StringSplitOptions = StringSplitOptions.RemoveEmptyEntries) As List(Of String)

        If str Is Nothing OrElse str.Length = 0 Then
            Return Nothing
        End If

        Dim arrTarget As Array
        Dim listString As New List(Of String)
        Dim i As Int32
        arrTarget = str.Split(New String() {separator}, IsRemoveEmptyEntires)
        For i = 0 To arrTarget.Length - 1
            listString.Add(arrTarget(i))
        Next
        Return listString

    End Function

    ''' <summary>
    ''' 将字符串按照指定的分隔符转换为Int类型的泛型集合
    ''' </summary>
    ''' <param name="str">要转换的字符串</param>
    ''' <param name="separaotr">分隔符</param>
    ''' <param name="IsDropEmpty">是否跳过空内容。默认为True。如果不跳过空内容，遇到空内容时引发异常。</param>
    ''' <returns></returns>
    <Extension>
    Public Function ToListOfInt32(ByVal str As String, ByVal separaotr As String, Optional ByVal IsDropEmpty As Boolean = True) As List(Of Int32)
        If (String.IsNullOrEmpty(str)) Then
            Return Nothing
        End If

        Dim arr As String() = str.Split(separaotr)
        If (arr.Length > 0) Then
            Dim result As New List(Of Int32)
            For Each s In arr
                If Not s.IsInt32 Then
                    Throw New ApplicationException("[" & s & "]不是有效地数字")
                End If
                result.Add(s.ToInt32())
            Next
            Return result
        End If
        Return Nothing
    End Function

#End Region


End Module
