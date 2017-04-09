Imports System.Management
Namespace HardDevice

    ''' <summary>
    ''' 网络适配器信息
    ''' </summary>
    Public Class NetworkAdapter


        ''' <summary>
        ''' 获取本机的所有网络适配器,以:做为分隔符
        ''' </summary>
        ''' <returns></returns>
        Public Shared Function GetAllMacAddress() As String()

            Dim listMac As List(Of String) = New List(Of String)()
            Dim objSearcher As ManagementObjectSearcher = New ManagementObjectSearcher()
            objSearcher.Query.QueryString = "SELECT MACAddress FROM Win32_NetworkAdapter"
            Dim objMCollect As ManagementObjectCollection = objSearcher.Get()
            If (Not objMCollect Is Nothing) AndAlso (objMCollect.Count > 0) Then
                For Each o In objMCollect
                    Dim s As String = o.GetPropertyValue("MACAddress")
                    If (Not s Is Nothing) AndAlso (s.Trim().Length > 0) Then
                        listMac.Add(s.Replace("-", ":"))
                    End If
                Next
            End If

            Return listMac.ToArray()
        End Function

    End Class



End Namespace
