Namespace Helper

    ''' <summary>
    ''' 路由辅助操作。只允许1个单例
    ''' </summary>
    Public Class Helper

#Region "单例"

        Private Shared _instance As Helper
        Public Shared Function Instance(ByVal session As Session) As Helper
            If (_instance Is Nothing) Then
                _instance = New Helper(session)
            End If
            Return _instance
        End Function


#End Region

        Public Sub New(ByVal session As Session)
            Config.Session = session
        End Sub

        Public ReadOnly Property DHCPServer As DHCPServer
            Get
                Return New DHCPServer
            End Get
        End Property

        Public ReadOnly Property Hotspot As Hotspot
            Get
                Return New Hotspot()
            End Get
        End Property

        Public ReadOnly Property Script As Script
            Get
                Return New Script()
            End Get
        End Property

    End Class

End Namespace
