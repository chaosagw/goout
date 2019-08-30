Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework

Public Class GoJunkai
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()
        '
        '  TODO: Sample code showing how to access button host
        '
        'My.ArcMap.Application.CurrentTool = Nothing

        Dim dockWndID As UID = New UIDClass
        dockWndID.Value = My.IDs.DockableWindwJunkai

        Dim dockWnd As IDockableWindow = My.DockableWindowManager.GetDockableWindow(dockWndID)

        If Checked = False Then
            Checked = True
            dockWnd.Show(True)
        Else
            Checked = False
            dockWnd.Show(False)
        End If

    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
