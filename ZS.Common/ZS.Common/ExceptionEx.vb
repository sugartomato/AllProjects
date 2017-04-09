Imports System.Runtime.CompilerServices

<Extension()>
Public Module ExceptionEx

    ''' <summary>
    ''' 将内部异常信息一起返回。以换行符分隔每条异常消息。
    ''' </summary>
    ''' <param name="ex">异常对象</param>
    ''' <returns></returns>
    <Extension()>
    Public Function JoinWithInnerExMessage(ByVal ex As Exception) As String
        Dim exMsg As String = String.Empty
        exMsg = ex.Message
        If (Not ex.InnerException Is Nothing) Then
            exMsg = vbNewLine & JoinWithInnerExMessage(ex.InnerException)
        End If

        Return exMsg

    End Function

    ''' <summary>
    ''' 将内部异常信息组合为一条字符串信息返回。
    ''' </summary>
    ''' <param name="ex">异常对象</param>
    ''' <param name="separation">信息分隔符号。</param>
    ''' <returns></returns>
    Public Function JoinWithInnerExMessage(ByVal ex As Exception, ByVal separation As String) As String
        Dim exMsg As String = String.Empty
        exMsg = ex.Message
        If (Not ex.InnerException Is Nothing) Then
            exMsg = separation & JoinWithInnerExMessage(ex.InnerException)
        End If
        Return exMsg
    End Function

    ''' <summary>
    ''' 将内部异常信息组合为一条字符串信息返回
    ''' </summary>
    ''' <param name="ex">异常对象</param>
    ''' <param name="separation">信息分隔符号。</param>
    ''' <param name="withStackTrace">是否包含堆栈信息</param>
    ''' <returns></returns>
    Public Function JoinWithInnerExMessage(ByVal ex As Exception, ByVal separation As String, ByVal withStackTrace As Boolean)
        Dim exMsg As String = String.Empty
        exMsg = ex.Message
        If (Not ex.InnerException Is Nothing) Then
            exMsg = separation & JoinWithInnerExMessage(ex.InnerException)
        End If
        If (withStackTrace) Then
            exMsg = separation & ex.StackTrace
        End If
        Return exMsg
    End Function

End Module
