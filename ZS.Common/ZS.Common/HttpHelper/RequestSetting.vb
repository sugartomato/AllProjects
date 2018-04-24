Namespace HttpHelper

    ''' <summary>
    ''' HTTP请求配置
    ''' </summary>
    Public Class RequestSetting

        Public Property Method As String = String.Empty



        Public Shared ReadOnly Property _Default As RequestSetting
            Get
                Dim result As RequestSetting = New RequestSetting()
                Return result
            End Get
        End Property


    End Class

End Namespace
