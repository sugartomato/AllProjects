Imports System.Runtime.CompilerServices
Imports System.ComponentModel


Module ListEx


#Region "字符串泛型"

    ''' <summary>
    ''' 将泛型集合中的字符串按照指定的连接符连接为一个字符串
    ''' </summary>
    ''' <param name="list"></param>
    ''' <param name="splitter">连接符号</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function Join(ByVal list As List(Of String), ByVal splitter As String) As String
        If (list Is Nothing) Then Return String.Empty
        If (list.Count = 0) Then Return String.Empty

        Dim strReturn As String = String.Empty
        For m As Int32 = 0 To list.Count - 1
            If (m < list.Count - 1) Then
                strReturn &= list(m) & splitter
            Else
                strReturn &= list(m)
            End If
        Next
        Return strReturn

    End Function


#End Region



End Module
