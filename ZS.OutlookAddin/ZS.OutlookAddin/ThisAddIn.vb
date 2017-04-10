Imports Microsoft.Office.Core

Public Class ThisAddIn

    Private Sub ThisAddIn_Startup() Handles Me.Startup

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Protected Overrides Function CreateRibbonExtensibilityObject() As IRibbonExtensibility
        Return New Ribbon1()
    End Function

End Class
