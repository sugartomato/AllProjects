
''' <summary>
''' MAC地址对象
''' </summary>
Public Class ZMACAddress

    Private m_MacAddress As String = String.Empty

    Public Sub New(ByVal macAdd As String)
        If (Not macAdd.IsMacAddress()) Then
            Throw New ApplicationException("无效的MAC地址")
        End If

        If (macAdd.Length = 12) Then
            Dim tempMAC As String = String.Empty
            For i As Int32 = 0 To macAdd.Length - 1 Step 3
                tempMAC = macAdd.Substring(i, 2) & "-"
            Next
            m_MacAddress = tempMAC.Trim("-")
        Else
            m_MacAddress = macAdd.Replace(":", "-")
        End If
        m_MacAddress = m_MacAddress.ToUpper()
    End Sub

    ''' <summary>
    ''' 输出以-分隔的MAC地址形式
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ToString() As String
        Return m_MacAddress
    End Function

    ''' <summary>
    ''' 以指定的分隔符类型输出MAC地址的字符串形式
    ''' </summary>
    ''' <param name="sType"></param>
    ''' <returns></returns>
    Public Overloads Function ToString(ByVal sType As SplitType) As String
        Select Case sType
            Case SplitType.None
                Return m_MacAddress.Replace("-", "")
            Case SplitType.Minus
                Return m_MacAddress
            Case SplitType.Colon
                Return m_MacAddress.Replace("-", ":")
        End Select
    End Function

    Public Enum SplitType
        ''' <summary>
        ''' 无分隔符
        ''' </summary>
        None
        ''' <summary>
        ''' 以 - 分隔
        ''' </summary>
        Minus
        ''' <summary>
        ''' 以 : 分隔
        ''' </summary>
        Colon
    End Enum

    Public Shared Function TryParse(ByVal macAddress As String, ByRef out As ZMACAddress) As Boolean
        Try
            out = New ZMACAddress(macAddress)
            Return True
        Catch ex As Exception
            out = Nothing
            Return False
        End Try
    End Function


    Public Shared Function IsMacAddress(ByVal macAdd As String) As Boolean
        Return macAdd.IsMacAddress()
    End Function

End Class
