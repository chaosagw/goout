Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Desktop.AddIns
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.ADF.Connection.Local
Imports ESRI.ArcGIS.Geoprocessor
Imports ESRI.ArcGIS.DataManagementTools
Imports System.Windows.Forms
Imports System.Linq

Public Class GetZval
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()

        If MessageBox.Show("頂点のZ値を属性に持たせますか？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then

            Dim frmM As New frmMain
            Dim flg2D As Boolean = False

            If MessageBox.Show("2Dシェープファイルを作成しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                flg2D = True
            End If

            frmM.Show()

            Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
            Dim pMap As IMap = activeView.FocusMap
            Dim FC As IFeatureClass
            Dim FL As IFeatureLayer
            'Dim DS As IDataset
            Dim fCursor As IFeatureCursor = Nothing
            Dim curFeature As IFeature = Nothing
            Dim fIndex As Integer = Nothing
            Dim pFields As IFields = Nothing
            Dim pField As IField = Nothing
            Dim comReleaser As New ESRI.ArcGIS.ADF.ComReleaser
            Dim GP As Geoprocessor = New Geoprocessor
            GP.OverwriteOutput = True
            Dim CreateFeatureClass As CreateFeatureclass = New CreateFeatureclass
            Dim Append As Append = New Append


            For i = 0 To pMap.LayerCount - 1

                frmM.Text = i + 1 & "/" & pMap.LayerCount & "を処理中！"
                frmM.ProgressBar1.Value = 0

                If TypeOf pMap.Layer(i) Is IFeatureLayer Then

                    FL = pMap.Layer(i)
                    FC = FL.FeatureClass
                    'DS = FC
                    pFields = FC.Fields

                    If FC.ShapeType = esriGeometryType.esriGeometryPolygon Then
                        'スキーマロックを取得する()
                        Dim schemaLock As ISchemaLock = FC
                        schemaLock.ChangeSchemaLock(esriSchemaLock.esriExclusiveSchemaLock)

                        Dim fld1 As IField = CreateField("first_Z", "double")
                        Dim fld2 As IField = CreateField("max_Z", "double")
                        Dim fld3 As IField = CreateField("min_Z", "double")
                        Dim fld4 As IField = CreateField("avrg_Z", "double")

                        'Dim WS As IWorkspace = DS.Workspace
                        'Dim workspaceEdit As IWorkspaceEdit = CType(WS, IWorkspaceEdit)
                        'workspaceEdit.StartEditing(True)
                        'workspaceEdit.StartEditOperation()


                        Try

                            fIndex = pFields.FindField("first_Z")

                            If fIndex = -1 Then
                                FC.AddField(fld1)
                            End If

                            fIndex = pFields.FindField("max_Z")

                            If fIndex = -1 Then
                                FC.AddField(fld2)
                            End If

                            fIndex = pFields.FindField("min_Z")

                            If fIndex = -1 Then
                                FC.AddField(fld3)
                            End If

                            fIndex = pFields.FindField("avrg_Z")

                            If fIndex = -1 Then
                                FC.AddField(fld4)
                            End If

                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        schemaLock.ChangeSchemaLock(esriSchemaLock.esriSharedSchemaLock)

                        fCursor = FC.Update(Nothing, True)
                        curFeature = fCursor.NextFeature

                        comReleaser.ManageLifetime(fCursor)

                        frmM.ProgressBar1.Maximum = FC.FeatureCount(Nothing)

                        Do Until curFeature Is Nothing

                            Application.DoEvents()

                            frmM.ProgressBar1.Increment(1)

                            Dim pGeom As IGeometry = curFeature.Shape
                            Dim pPointCol As IPointCollection = pGeom
                            Dim vrtxNum As Integer = pPointCol.PointCount
                            Dim pPoint As IPoint = Nothing
                            Dim Zcol As New ArrayList
                            Dim firstZ As Double
                            Dim maxZ As Double
                            Dim minZ As Double
                            Dim avrgZ As Double

                            For ii As Integer = 0 To vrtxNum - 1

                                pPoint = pPointCol.Point(ii)
                                '1点目だったら
                                If ii = 0 Then
                                    firstZ = pPoint.Z
                                End If

                                Zcol.Add(pPoint.Z)

                            Next

                            Dim ZdblArry(Zcol.Count - 1) As Double

                            For iii As Integer = 0 To Zcol.Count - 1
                                ZdblArry(iii) = CDbl(Zcol(iii))
                            Next

                            maxZ = Aggregate max In ZdblArry Into Max()
                            minZ = Aggregate min In ZdblArry Into Min()
                            avrgZ = Aggregate avg In ZdblArry Into Average()

                            fIndex = pFields.FindField("first_Z")
                            If fIndex <> -1 Then
                                curFeature.Value(fIndex) = firstZ
                            End If

                            fIndex = pFields.FindField("max_Z")
                            If fIndex <> -1 Then
                                curFeature.Value(fIndex) = maxZ
                            End If

                            fIndex = pFields.FindField("min_Z")
                            If fIndex <> -1 Then
                                curFeature.Value(fIndex) = minZ
                            End If

                            fIndex = pFields.FindField("avrg_Z")
                            If fIndex <> -1 Then
                                curFeature.Value(fIndex) = avrgZ
                            End If

                            fCursor.UpdateFeature(curFeature)

                            curFeature = fCursor.NextFeature

                        Loop

                        '編集終了
                        'workspaceEdit.StopEditOperation()
                        'workspaceEdit.StopEditing(True)
                        fCursor.Flush()

                        '2Dシェープ出力
                        If flg2D = True Then
                            '3Dシェープを2dシェープに変換
                            '(2Dシェープを新規作成して3DシェープをアペンドするとZ値が削除される：ジオプロセッシングツール使用)
                            Dim DS As IDataset = CType(FC, IDataset)
                            Dim outpath As String = DS.Workspace.PathName
                            Dim outname As String = FL.Name & "_2D"
                            CreateFeatureClass.out_path = outpath
                            CreateFeatureClass.out_name = outname
                            CreateFeatureClass.geometry_type = "POLYGON"
                            CreateFeatureClass.template = outpath & "\" & FL.Name & ".shp"
                            CreateFeatureClass.has_m = "DISABLED"
                            CreateFeatureClass.has_z = "DISABLED"
                            RunTool(GP, CreateFeatureClass, Nothing)

                            Append.inputs = outpath & "\" & FL.Name & ".shp"
                            Append.target = outpath & "\" & outname & ".shp"
                            RunTool(GP, Append, Nothing)

                        End If

                    Else
                        MessageBox.Show(FL.Name & "はポリゴンではないので処理しません！", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Next

            comReleaser.Dispose()

            frmM.Close()

            MessageBox.Show("終わった", "GetVertexZ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Else
            Exit Sub
        End If

        My.ArcMap.Application.CurrentTool = Nothing

    End Sub

    Private Function CreateField(ByVal fldName As String, ByVal fldType As String) As IField

        Dim newFld As IField = New FieldClass
        Dim fieldEdit As IFieldEdit = newFld

        Select Case fldType

            Case "short"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeSmallInteger
                fieldEdit.Precision_2 = 10

            Case "long"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger
                fieldEdit.Precision_2 = 10

            Case "single"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle
                fieldEdit.Precision_2 = 10
                fieldEdit.Scale_2 = 3

            Case "double"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble
                fieldEdit.Precision_2 = 10
                fieldEdit.Scale_2 = 3

            Case "string"
                fieldEdit.Length_2 = 30 ' Only string fields require that you set the length.
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeString

            Case "date"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeDate

            Case "oid"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeOID

            Case "geom"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry

            Case "blob"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeBlob
                fieldEdit.Length_2 = 254

            Case "raster"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeRaster

            Case "guid"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeGUID

            Case "globalid"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeGlobalID

            Case "xml"
                fieldEdit.Name_2 = fldName
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeXML

        End Select

        'Try
        '    newFld = fieldEdit
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Return newFld

    End Function

    Private Shared Sub RunTool(ByVal geoprocessor As Geoprocessor, ByVal process As IGPProcess, ByVal TC As ITrackCancel)

        ' Set the overwrite output option to true
        geoprocessor.OverwriteOutput = True

        Try
            geoprocessor.Execute(process, Nothing)
            'ReturnMessages(geoprocessor)

        Catch err As Exception
            MsgBox(err.Message)
            ReturnMessages(geoprocessor)
        End Try
    End Sub

    ' Function for returning the tool messages.
    Private Shared Sub ReturnMessages(ByVal gp As Geoprocessor)
        ' Print out the messages from tool executions
        Dim Count As Integer
        If gp.MessageCount > 0 Then
            For Count = 0 To gp.MessageCount - 1
                MsgBox(gp.GetMessage(Count))
            Next
        End If
    End Sub


    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  