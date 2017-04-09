Public Class Computer

    ''' <summary>
    ''' 设置本机的计算机名
    ''' </summary>
    ''' <param name="computerName">新的计算机名</param>
    ''' <returns></returns>
    Public Shared Function SetComputerName(ByVal computerName As String, ByRef errorCode As String) As Boolean

        Dim returnValue As Object = Nothing
        Dim objSearcher As Management.ManagementObjectSearcher = New Management.ManagementObjectSearcher()
        objSearcher.Query.QueryString = "SELECT * FROM Win32_ComputerSystem WHERE Name='" & Environment.MachineName & "'"

        Dim objCollect As Management.ManagementObjectCollection = objSearcher.Get()
        If (Not objCollect Is Nothing) AndAlso (objCollect.Count > 0) Then
            Dim obj As Management.ManagementObject = objCollect(0)
            Dim inParameter As Management.ManagementBaseObject = obj.GetMethodParameters("Rename")
            inParameter.SetPropertyValue("Name", computerName)
            Dim outParams As Management.ManagementBaseObject = obj.InvokeMethod("Rename", inParameter, Nothing)
            Dim m As Object = outParams.Properties.Item("ReturnValue")

            If (m Is Nothing) Then
                errorCode = "未能获取WMI方法返回对象。"
                Return False
            End If

            returnValue = (m.Value)

            If (returnValue Is Nothing) Then
                errorCode = "返回对象值为空。"
                Return False
            End If

            If (m.Value = 0) Then
                errorCode = String.Empty
                Return True
            Else
                errorCode = m.Value.ToString()
                Return False
            End If
        Else
            errorCode = "获取本机对象失败！"
            Return False
        End If

    End Function



End Class
