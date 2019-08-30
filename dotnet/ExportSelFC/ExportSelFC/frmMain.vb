Imports System.Windows.Forms
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Geoprocessor
Imports ESRI.ArcGIS.DataManagementTools

Public Class frmMain

    Dim frmNotification As Form
    Dim tblLayer As New Hashtable

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim layers As ArrayList = New ArrayList()
        Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
        Dim pMap As IMap = activeView.FocusMap
        'Dim fieldList As ArrayList = New ArrayList()
        Dim FC As IFeatureClass
        Dim FL As IFeatureLayer

        Try

            For i = 0 To pMap.LayerCount - 1

                If TypeOf pMap.Layer(i) Is IFeatureLayer Then

                    lbLayer.Items.Add(pMap.Layer(i).Name)
                    tblLayer.Add(pMap.Layer(i).Name, i)

                    FL = pMap.Layer(i)

                    FC = FL.FeatureClass

                    'For ii = 0 To FC.Fields.FieldCount - 1

                    '    fieldList.Add(FC.Fields.Field(ii).Name)

                    'Next

                End If

            Next

        Catch ex As Exception

            System.Windows.Forms.MessageBox.Show("レイヤ一覧取得のところでエラーです！" & ex.Message, "Error", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)

        End Try

        'fieldList = array_uniqe(fieldList)

        'Dim atrAll() As String = DirectCast(fieldList.ToArray(GetType(String)), String())   'コレクションのままではなぜかコンボボックスにAddRange出来ないので配列に型変換

        'cmbAtrlist.Items.AddRange(atrAll)


    End Sub

    Private Sub btnOutdir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutdir.Click

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            tbOutdir.Text = FolderBrowserDialog1.SelectedPath

        End If

    End Sub

    Public Function array_uniqe(ByVal List)

        '重複を取り除いたコレクションをここに格納する
        Dim uniqe_list As ArrayList = New ArrayList()


        For Each str As String In List

            '要素がコレクションに存在しないか？
            If uniqe_list.Contains(str) = False Then
                '存在しなければ追加
                uniqe_list.Add(str)
            End If

        Next

        '重複を始末したコレクションを返す
        Return uniqe_list

    End Function

    'ジオプロセッサ実行
    Private Sub RunGPTool(ByVal gp As Geoprocessor, ByVal process As IGPProcess, ByVal TC As ITrackCancel)

        gp.OverwriteOutput = True

        Try

            gp.Execute(process, Nothing)
            'ReturnMessages(gp)

        Catch ex As Exception

            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ReturnMessages(gp)

        End Try

    End Sub

    'ジオプロセッサからメッセージを取得
    Private Sub ReturnMessages(ByVal gp As Geoprocessor)

        Dim Count As Integer

        If gp.MessageCount > 0 Then

            For Count = 0 To gp.MessageCount - 1

                MessageBox.Show(gp.GetMessage(Count), "Processor Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Next

        End If

    End Sub


    Private Sub lbLayer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLayer.DoubleClick

        For i = 0 To lbLayer.Items.Count - 1

            lbLayer.SetSelected(i, True)

        Next

    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click

        Try


            If tbOutdir.Text = "" Then

                MessageBox.Show("出力先を指定してください！", "WARNING!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

            'If cmbAtrlist.Text = "" Then

            '    MessageBox.Show("分割する属性を指定してください！", "WARNING!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            'End If

            Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
            Dim pMap As IMap = activeView.FocusMap
            Dim FC As IFeatureClass
            Dim FL As IFeatureLayer
            Dim arrayAtr As New ArrayList
            'Dim pFCursor As IFeatureCursor
            'Dim pFeature As IFeature
            'Dim pQF As IQueryFilter
            'Dim valAtr As String
            'Dim fIndex As Integer
            'Dim pFields As IFields
            'Dim pField As IField
            'Dim fType As String = ""
            'Dim strQuery As String = ""
            Dim GP As Geoprocessor = New Geoprocessor
            Dim outPath As String
            Dim application As ESRI.ArcGIS.Framework.IApplication = My.ArcMap.Application

            GP.OverwriteOutput = True

            'Dim SelectByAttribute As SelectLayerByAttribute = New SelectLayerByAttribute()  '属性で選択オブジェクト
            Dim copy_features As ESRI.ArcGIS.DataManagementTools.CopyFeatures = New ESRI.ArcGIS.DataManagementTools.CopyFeatures()  'コピーフューチャオブジェクト

            For i = 0 To lbLayer.SelectedItems.Count - 1    '選択されたレイヤー数繰り返し

                Me.Text = i + 1 & "/" & lbLayer.SelectedItems.Count & "を処理中！"
                My.ArcMap.Application.StatusBar.ShowProgressBar(lbLayer.SelectedItems(i) & "を処理中...", 0, lbLayer.SelectedItems.Count - 1, 1, True)

                IO.Directory.CreateDirectory(tbOutdir.Text & "\SelectedOut")
                outPath = tbOutdir.Text & "\SelectedOut\sel_"

                FL = pMap.Layer(tblLayer(lbLayer.SelectedItems(i)))
                FC = FL.FeatureClass

                '選択したアイテムをコピー(保存)
                copy_features.in_features = lbLayer.SelectedItems(i)
                copy_features.out_feature_class = outPath & lbLayer.SelectedItems(i)

                GP.AddOutputsToMap = False

                RunGPTool(GP, copy_features, Nothing)
                My.ArcMap.Application.StatusBar.StepProgressBar()

                'fIndex = FC.Fields.FindField(cmbAtrlist.Text)
                'pFields = FC.Fields
                'pField = pFields.Field(fIndex)
                'pQF = New QueryFilter   'クエリフィルタを定義すると全選択のクエリになる
                'pFCursor = FC.Search(pQF, True)
                'pFeature = pFCursor.NextFeature

                ''フィールドタイプの判定
                'Select Case pField.Type

                '    Case esriFieldType.esriFieldTypeSmallInteger
                '        fType = "Short Int"

                '    Case esriFieldType.esriFieldTypeInteger
                '        fType = "Long Int"

                '    Case esriFieldType.esriFieldTypeSingle
                '        fType = "Single"

                '    Case esriFieldType.esriFieldTypeDouble
                '        fType = "Double"

                '    Case esriFieldType.esriFieldTypeString
                '        fType = "String"

                '    Case esriFieldType.esriFieldTypeDate
                '        fType = "Date"

                '        'Case esriFieldType.esriFieldTypeOID
                '        '    fType = "Long Integer representing an object identifier"

                '        'Case esriFieldType.esriFieldTypeGeometry
                '        '    fType = "Geometry"

                '        'Case esriFieldType.esriFieldTypeBlob
                '        '    fType = "Binary Large Object, Blob Storage"

                '        'Case esriFieldType.esriFieldTypeRaster
                '        '    fType = "Raster"

                '        'Case esriFieldType.esriFieldTypeGUID
                '        '    fType = "Globally Unique Identifier"

                '        'Case esriFieldType.esriFieldTypeGlobalID
                '        '    fType = "ESRI Global ID"

                '        'Case esriFieldType.esriFieldTypeXML
                '        '    fType = "XML Document"

                'End Select

                ''全地物の属性を取得してユニーク値をコレクションに格納する
                'Do Until pFeature Is Nothing

                '    Try

                '        valAtr = pFeature.Value(fIndex)

                '        If arrayAtr.Contains(valAtr) = False Then

                '            arrayAtr.Add(valAtr)

                '        End If

                '    Catch ex As Exception

                '        MessageBox.Show(lbLayer.SelectedItems(i) & "にフィールドが存在しない、または値がありません！" & vbCrLf _
                '                    & "フィールドを指定し直すかデータを修正してください！", "!!ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

                '    End Try

                '    System.Windows.Forms.Application.DoEvents()

                '    pFeature = pFCursor.NextFeature


                'Loop




                '    For Each atr As String In arrayAtr  '属性の値の個数分セレクトしてエクスポートを繰り返し

                '        My.ArcMap.Application.StatusBar.StepProgressBar()

                '        'MsgBox(atr)

                '        If fType = "String" Then

                '            strQuery = cmbAtrlist.Text & " = " & "'" & atr & "'"

                '        Else

                '            strQuery = cmbAtrlist.Text & " = " & atr

                '        End If

                '        '属性で選択
                '        SelectByAttribute.in_layer_or_view = lbLayer.SelectedItems(i)
                '        SelectByAttribute.selection_type = "NEW_SELECTION"
                '        SelectByAttribute.where_clause = strQuery

                '        RunGPTool(GP, SelectByAttribute, Nothing)

                '        '選択したアイテムをコピー(保存)
                '        copy_features.in_features = lbLayer.SelectedItems(i)
                '        copy_features.out_feature_class = outPath & atr

                '        GP.AddOutputsToMap = False

                '        RunGPTool(GP, copy_features, Nothing)

                '    Next

                '    arrayAtr.Clear()

                '    My.ArcMap.Application.StatusBar.HideProgressBar()

            Next

            My.ArcMap.Application.StatusBar.HideProgressBar()
            FindCommandAndExecute(application, "{37C833F3-DBFD-11D1-AA7E-00C04FA37860}")    '選択解除コマンド実行
            Me.Text = "Complete!"
            'MessageBox.Show("処理が終わりました！", "Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmNotification = NotificationWindow1.Notify("ヲワッタヨ")

        Catch ex As Exception
            MessageBox.Show(ex.StackTrace)
        End Try

    End Sub









#Region "コマンドを検索し実行する"
    ' ArcGIS スニペット タイトル:
    ' コマンドを検索し実行する
    ' 
    ' 詳細説明:
    ' プログラムにより、コマンドの検索およびクリックを行います。
    ' 
    ' プロジェクトに次の参照を追加:
    ' ESRI.ArcGIS.Framework
    ' ESRI.ArcGIS.System
    ' 
    ' このスニペットが適用されるArcGIS製品:
    ' ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
    ' 
    ' 適用可能なArcGIS製品のバージョン:
    ' 9.2
    ' 9.3
    ' 9.3.1
    ' 10.0
    ' 
    ' 必要なArcGISエクステンション:
    ' (なし)
    ' 
    ' メモ:
    ' このスニペットはベースレベルのClassに挿入されます。
    ' 既存のFunctionまたはSub内部でネストして利用することはできません。
    ' 

    '''<summary>プログラムにより、コマンドの検索およびクリックを行います。</summary>
    '''  
    '''<param name="application">IApplicationインタフェース</param>
    '''<param name="commandName">返したいコマンドの名前を示すSystem.String型の文字列(例: "esriFramework.HelpContentsCommand" または "{D74B2F25-AC90-11D2-87F8-0000F8751720}")</param>
    '''   
    '''<remarks>commandNameパラメータとして利用可能なCLSIDとProgIDの一覧については、EDNドキュメント(http://edndoc.esri.com/arcobjects/9.1/default.asp?URL=/arcobjects/9.1/ArcGISDevHelp/TechnicalDocuments/Guids/ArcMapIds.htm)を参照してください。</remarks>
    Public Sub FindCommandAndExecute(ByVal application As ESRI.ArcGIS.Framework.IApplication, ByVal commandName As System.String)

        Dim commandBars As ESRI.ArcGIS.Framework.ICommandBars = application.Document.CommandBars
        Dim uid As ESRI.ArcGIS.esriSystem.UID = New ESRI.ArcGIS.esriSystem.UIDClass
        uid.Value = commandName ' 例: "ArcMapUI.ClearSelectionCommand" or "{D74B2F25-AC90-11D2-87F8-0000F8751720}"
        Dim commandItem As ESRI.ArcGIS.Framework.ICommandItem = commandBars.Find(uid, False, False)
        If Not (commandItem Is Nothing) Then
            commandItem.Execute()
        End If

    End Sub
#End Region

End Class                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     