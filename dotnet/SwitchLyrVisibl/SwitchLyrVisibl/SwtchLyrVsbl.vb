Imports System.Windows.Forms
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem

Public Class SwtchLyrVsbl
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()
        '
        '  TODO: Sample code showing how to access button host
        '

        Dim layers As New ArrayList
        Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
        Dim pMap As IMap = activeView.FocusMap
        Dim FL As IFeatureLayer
        Dim GL As IGroupLayer
        Dim lst As New ArrayList
        Dim strArry As String()

        Try

            If My.Settings.flg = True Then
                My.Settings.flg = False
                My.Settings.visbl = ""
            Else
                My.Settings.flg = True
                strArry = My.Settings.visbl.Split(",")
                lst.AddRange(strArry)
            End If

            'MessageBox.Show(My.Settings.flg)

            For i = 0 To pMap.LayerCount - 1

                If TypeOf pMap.Layer(i) Is IFeatureLayer Then

                    FL = pMap.Layer(i)
                    'MessageBox.Show(FL.Name)
                    If My.Settings.flg = False Then
                        'MessageBox.Show("非表示")
                        'My.Settings.visib(i) = FL.Visible
                        My.Settings.visbl = My.Settings.visbl & FL.Visible.ToString & ","
                        FL.Visible = False
                    Else
                        'MessageBox.Show("表示")
                        'MessageBox.Show(My.Settings.visib(i))
                        If lst(i) = "True" Then
                            FL.Visible = True
                        Else
                            FL.Visible = False
                        End If

                    End If

                ElseIf TypeOf pMap.Layer(i) Is IGroupLayer Then

                    GL = pMap.Layer(i)

                    If My.Settings.flg = False Then
                        'My.Settings.visib(i) = GL.Visible
                        My.Settings.visbl = My.Settings.visbl & GL.Visible.ToString & ","
                        GL.Visible = False
                        'MessageBox.Show("非表示")
                    Else
                        If lst(i) = "True" Then
                            GL.Visible = True
                        Else
                            GL.Visible = False
                        End If

                        'MessageBox.Show("表示")
                    End If
                Else
                    If My.Settings.flg = False Then
                        My.Settings.visbl = My.Settings.visbl & " ,"
                    End If

                End If

            Next

            activeView.Refresh()

        Catch ex As Exception

            MessageBox.Show("レイヤ一覧取得のところでエラーです！" & ex.Message & ex.InnerException.ToString, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)

        End Try

        'My.ArcMap.Application.CurrentTool = Nothing
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
