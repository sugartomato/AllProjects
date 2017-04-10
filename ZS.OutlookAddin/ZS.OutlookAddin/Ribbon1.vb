'TODO:  Follow these steps to enable the Ribbon (XML) item:

'1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

'Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
'    Return New Ribbon1()
'End Function

'2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
'   actions, such as clicking a button. Note: if you have exported this Ribbon from the
'   Ribbon designer, move your code from the event handlers to the callback methods and
'   modify the code to work with the Ribbon extensibility (RibbonX) programming model.

'3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.

'For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


Imports Outlook = Microsoft.Office.Interop.Outlook

<Runtime.InteropServices.ComVisible(True)> _
Public Class Ribbon1
    Implements Office.IRibbonExtensibility

    Private ribbon As Office.IRibbonUI

    Public Sub New()
    End Sub

    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("ZS.OutlookAddin.Ribbon1.xml")
    End Function

#Region "Ribbon Callbacks"
    'Create callback methods here. For more information about adding callback methods, visit http://go.microsoft.com/fwlink/?LinkID=271226
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
    End Sub





#End Region


#Region "另存附件"

    Public Sub OnClick_BatchSaveAttachFile(ByVal ctrl As Office.IRibbonControl)
        Dim frm As New BatchSaveAttachFile()
        frm.ShowDialog()
    End Sub


    Public Function Get_LabelSet(ByVal ctrl As Office.IRibbonControl) As String
        Select Case ctrl.Id
            Case "LBLTTT"
                Return "== " & New System.Random().Next(1000, 3000) & " =="
            Case "rdGRP"
                Return "切换组：" & New System.Random().Next(1000, 3000)
            Case "rdGRP1"
                Return "组员1：" & New System.Random().Next(1000, 3000)
            Case "rdGRP2"
                Return "组员2：" & New System.Random().Next(1000, 3000)
        End Select






        Return "没指定ID"
    End Function

    Public Function Get_ItemLabel(ByVal ctrl As Office.IRibbonControl, ByVal index As Integer) As String
        Return "第" & index & “选项” & New System.Random().Next(1000, 3000)
    End Function

    Public Function Get_ItemCount(ByVal ctrl As Office.IRibbonControl)
        Return New System.Random().Next(5, 10)
    End Function

    Public Sub OnClick_ChangeLabel(ByVal ctrl As Office.IRibbonControl)
        ribbon.InvalidateControl("LBLTTT")

        Select Case ctrl.Id
            Case “btnChangeImage”
                ribbon.InvalidateControl("rdGRP")
        End Select
    End Sub

#End Region


#Region "Helpers"

    Private Shared Function GetResourceText(ByVal resourceName As String) As String
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim resourceNames() As String = asm.GetManifestResourceNames()
        For i As Integer = 0 To resourceNames.Length - 1
            If String.Compare(resourceName, resourceNames(i), StringComparison.OrdinalIgnoreCase) = 0 Then
                Using resourceReader As IO.StreamReader = New IO.StreamReader(asm.GetManifestResourceStream(resourceNames(i)))
                    If resourceReader IsNot Nothing Then
                        Return resourceReader.ReadToEnd()
                    End If
                End Using
            End If
        Next
        Return Nothing
    End Function

#End Region



#Region "测试"

    Public Sub OnClick_ChangeExplorer(ByVal ctrl As Office.IRibbonControl)
        MsgBox(Globals.ThisAddIn.Application.ActiveExplorer().Caption)

        Dim views As Outlook.Views = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderToDo).Views
        Dim tableView As Outlook.TableView
        If (IsViewExists("Test")) Then
            tableView = views("Test")
        Else
            tableView = views.Add("Test", Outlook.OlViewType.olTableView, Outlook.OlViewSaveOption.olViewSaveOptionThisFolderEveryone)
        End If
        tableView.Save()

        tableView.Apply()


        For Each clm As Outlook.ViewField In tableView.ViewFields
            'MsgBox(clm.ViewXMLSchemaName)
        Next

        For i As Int32 = 2 To tableView.ViewFields.Count

            tableView.ViewFields.Remove(i)
            i -= 1
            If (tableView.ViewFields.Count <= 1) Then Exit For
        Next

        tableView.ViewFields.Add("subject")
        tableView.Save()

        tableView.Apply()

    End Sub


    Private Function IsViewExists(ByVal name As String) As Boolean
        Dim views As Outlook.Views = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderToDo).Views
        For Each view As Outlook.View In views
            If view.Name = name Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

End Class
