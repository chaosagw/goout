Public Class SplitByATR
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Public Sub New()

  End Sub

  Protected Overrides Sub OnClick()
    '
    '  TODO: Sample code showing how to access button host
    '
        Dim frmM As New frmMain

        frmM.Show()

        My.ArcMap.Application.CurrentTool = Nothing

  End Sub

  Protected Overrides Sub OnUpdate()
    Enabled = My.ArcMap.Application IsNot Nothing
  End Sub
End Class
