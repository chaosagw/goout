Imports System.Text
Imports System.Windows.Forms
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

''' <summary>
''' Designer class of the dockable window add-in. It contains user interfaces that
''' make up the dockable window.
''' </summary>
Public Class DockableWindwJunkai

    Public Sub New(ByVal hook As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Hook = hook
    End Sub


    Private m_hook As Object
    ''' <summary>
    ''' Host object of the dockable window
    ''' </summary> 
    Public Property Hook() As Object
        Get
            Return m_hook
        End Get
        Set(ByVal value As Object)
            m_hook = value
        End Set
    End Property

    ''' <summary>
    ''' Implementation class of the dockable window add-in. It is responsible for
    ''' creating and disposing the user interface class for the dockable window.
    ''' </summary>
    Public Class AddinImpl
        Inherits ESRI.ArcGIS.Desktop.AddIns.DockableWindow

        Private m_windowUI As DockableWindwJunkai

        Protected Overrides Function OnCreateChild() As System.IntPtr
            m_windowUI = New DockableWindwJunkai(Me.Hook)
            Return m_windowUI.Handle
        End Function

        Protected Overrides Sub Dispose(ByVal Param As Boolean)
            If m_windowUI IsNot Nothing Then
                m_windowUI.Dispose(Param)
            End If

            MyBase.Dispose(Param)
        End Sub

    End Class

    Dim flgInit As Boolean = False
    Public flgSel As Boolean
    Public selIndx2 As Integer

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click

        Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
        Dim pMap As IMap = activeView.FocusMap
        Dim FL As IFeatureLayer = Nothing
        Dim FS As IFeatureSelection = Nothing
        Dim SS As ISelectionSet = Nothing
        Dim pFCursor As IFeatureCursor = Nothing
        Dim pFeature As IFeature = Nothing
        Dim pFields As IFields = Nothing
        Dim fldIdx As Integer = 0
        Dim geom As IGeometry = Nothing
        Dim dtRow As DataRow
        Dim dtAtr As DataTable = New DataTable()
        Dim idx As Integer = 0
        Dim X As Double
        Dim Y As Double

        Try

            If pMap.LayerCount > 0 Then

                InitDgv(dtAtr)

                Dim pEnumLayer As IEnumLayer
                Dim pLayer As ILayer
                Dim pId As ESRI.ArcGIS.esriSystem.IUID = New ESRI.ArcGIS.esriSystem.UIDClass

                pId.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}"
                pEnumLayer = pMap.Layers((CType(pId, ESRI.ArcGIS.esriSystem.UID)), True)
                pEnumLayer.Reset()

                pLayer = pEnumLayer.Next
                Do While Not (pLayer Is Nothing)

                    FL = pLayer
                    If FL.FeatureClass Is Nothing Then
                    Else

                        FS = pLayer
                        SS = FS.SelectionSet

                        If SS.Count > 0 Then

                            SS.Search(Nothing, False, pFCursor)
                            pFeature = pFCursor.NextFeature
                            ClearSelectedMapFeatures(activeView, FL)
                            activeView.Refresh()

                            ToolStripProgressBar1.Maximum = SS.Count
                            ToolStripProgressBar1.Visible = True

                            pFields = pFeature.Fields

                            '巡回用IDがなかったらFID、OID、OBJECTIDを使う

                            fldIdx = pFields.FindField("j_id")

                            If fldIdx = -1 Then
                                fldIdx = 0
                            End If

                            'MessageBox.Show(fldIdx)

                            Do Until pFeature Is Nothing

                                geom = pFeature.Shape

                                If geom.GeometryType = esriGeometryType.esriGeometryPoint Then

                                    Dim CenterPnt As IPoint = geom

                                    X = CenterPnt.X
                                    Y = CenterPnt.Y

                                ElseIf geom.GeometryType = esriGeometryType.esriGeometryPolyline Then

                                    Dim pPolyline As IArea = geom.Envelope
                                    Dim CenterPnt As IPoint = pPolyline.Centroid

                                    X = CenterPnt.X
                                    Y = CenterPnt.Y

                                ElseIf geom.GeometryType = esriGeometryType.esriGeometryPolygon Then

                                    Dim pPolygon As IArea = geom
                                    Dim CenterPnt As IPoint = pPolygon.Centroid

                                    X = CenterPnt.X
                                    Y = CenterPnt.Y

                                Else

                                    Dim pGeom As IArea = geom.Envelope
                                    Dim CenterPnt As IPoint = pGeom.Centroid

                                    X = CenterPnt.X
                                    Y = CenterPnt.Y

                                End If

                                idx = idx + 1
                                dtRow = dtAtr.NewRow()

                                dtRow.Item(0) = idx
                                dtRow.Item(1) = pLayer.Name
                                dtRow.Item(2) = pFeature.Value(fldIdx)
                                dtRow.Item(3) = X
                                dtRow.Item(4) = Y
                                'dtRow.Item(5) = i

                                dtAtr.Rows.Add(dtRow)

                                pFeature = pFCursor.NextFeature
                                ToolStripProgressBar1.Increment(1)

                                Application.DoEvents()

                            Loop

                            ToolStripProgressBar1.Visible = False

                        End If

                    End If

                    pLayer = pEnumLayer.Next()
                Loop


                DataGridView1.DataSource = dtAtr
                'DataGridView1.CurrentCell = DataGridView1(0, 0)

                'If pFCursor Is Nothing Then
                'Else
                '    pFCursor.Flush()
                'End If


                If idx <> 0 Then
                    ToolStripStatusLabel1.Text = "1/" & idx
                Else
                    ToolStripStatusLabel1.Text = "0/" & idx
                End If

            End If

            FL = Nothing
            FS = Nothing
            SS = Nothing
            pFCursor = Nothing
            pFeature = Nothing
            geom = Nothing

            SortGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        flgInit = False
    End Sub

    Private Sub DataGridView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseDown
        flgInit = False
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged

        Try
            Dim application As ESRI.ArcGIS.Framework.IApplication = My.ArcMap.Application
            Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
            Dim pMap As IMap = activeView.FocusMap
            'Dim lyrNum As Integer = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(5).Value
            Dim selectionID As Integer
            If flgSel = False Then
                selectionID = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value
            Else
                selectionID = DataGridView1.Rows(selIndx2).Cells(2).Value
            End If
            'MessageBox.Show(flgSel)
            'MessageBox.Show(selectionID)
            'Dim lyrCount As Integer = pMap.LayerCount
            Dim pFCursor As IFeatureCursor = Nothing
            Dim pFeature As IFeature = Nothing
            'Dim geom As IGeometry = Nothing
            Dim pQFilt As IQueryFilter = New QueryFilter
            Dim display As IDisplay = activeView.ScreenDisplay
            Dim rgbColor As ESRI.ArcGIS.Display.IRgbColor = New ESRI.ArcGIS.Display.RgbColorClass
            rgbColor.Red = 255

            Dim X As Double
            Dim Y As Double
            Dim sel As Integer = DataGridView1.Rows.Count
            Dim idx As Integer
            Dim lyrName As String

            If flgSel = False Then
                X = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value
                Y = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(4).Value
                idx = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value
                lyrName = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value
            Else
                X = DataGridView1.Rows(selIndx2).Cells(3).Value
                Y = DataGridView1.Rows(selIndx2).Cells(4).Value
                idx = DataGridView1.Rows(selIndx2).Cells(0).Value
                lyrName = DataGridView1.Rows(selIndx2).Cells(1).Value
            End If

            Dim pEnumLayer As IEnumLayer
            Dim pLayer As ILayer
            Dim pId As ESRI.ArcGIS.esriSystem.IUID = New ESRI.ArcGIS.esriSystem.UIDClass
            Dim FL As IFeatureLayer = Nothing
            Dim FC As IFeatureClass = Nothing

            pId.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}"
            pEnumLayer = pMap.Layers((CType(pId, ESRI.ArcGIS.esriSystem.UID)), True)
            pEnumLayer.Reset()

            pLayer = pEnumLayer.Next
            Do While Not (pLayer Is Nothing)

                If pLayer.Name = lyrName Then

                    FL = pLayer
                    FC = FL.FeatureClass

                    Exit Do

                End If

                pLayer = pEnumLayer.Next()
            Loop

            If flgInit = False Then


                FindCommandAndExecute(application, "{37C833F3-DBFD-11D1-AA7E-00C04FA37860}")    '選択解除コマンド実行

                If cbSel.Checked = True Or cbExpand.Checked = True Then

                    'Dim fld As String = ""

                    pQFilt.WhereClause = "j_id = " & selectionID

                    Try
                        'MessageBox.Show("j_id = " & selectionID)
                        pFCursor = FC.Search(pQFilt, True)
                    Catch ex As Exception

                        Try
                            pQFilt.WhereClause = "OBJECTID_1 = " & selectionID
                            pFCursor = FC.Search(pQFilt, True)
                        Catch ex1 As Exception

                            Try
                                pQFilt.WhereClause = "OID = " & selectionID
                                pFCursor = FC.Search(pQFilt, True)
                            Catch ex2 As Exception

                                Try
                                    'MessageBox.Show("OBJECTID_1")
                                    pQFilt.WhereClause = "OBJECTID = " & selectionID
                                    pFCursor = FC.Search(pQFilt, True)
                                Catch ex3 As Exception
                                    pQFilt.WhereClause = "FID = " & selectionID
                                    pFCursor = FC.Search(pQFilt, True)
                                End Try

                            End Try

                        End Try

                    End Try

                    pFeature = pFCursor.NextFeature

                    pMap.SelectFeature(FL, pFeature)

                End If

                If cbExpand.Checked = True Then

                    FindCommandAndExecute(application, "{AB073B49-DE5E-11D1-AA80-00C04FA37860}")    'Zoom To Selected Featuresコマンド実行

                    If cbSel.Checked = False Then
                        FindCommandAndExecute(application, "{37C833F3-DBFD-11D1-AA7E-00C04FA37860}")    '選択解除コマンド実行
                    End If

                Else

                    Dim ratio As Double = 1
                    ZoomByRatioAndRecenter(activeView, ratio, X, Y)

                End If

                'FlashGeometry(geom, rgbColor, display, 100)

                'activeView.Refresh()

                'If cbSel.Checked = True Or cbExpand.Checked = True Then
                '    pFCursor.Flush()
                'End If

                Me.Focus()

                ToolStripStatusLabel1.Text = idx & "/" & sel

            End If

            FL = Nothing
            FC = Nothing

            If cbSel.Checked = True Or cbExpand.Checked = True Then
                pFCursor = Nothing
            End If

            pFeature = Nothing
            'geom = Nothing
            pQFilt = Nothing
            display = Nothing


        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        flgSel = False

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        SaveToCsv(DataGridView1)
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        CsvtoDgv()
    End Sub

    Private Sub btn_next_Click(sender As System.Object, e As System.EventArgs) Handles btn_next.Click
        Try
            flgInit = False
            flgSel = True
            Dim rowIDX As Integer = DataGridView1.CurrentCell.RowIndex
            Dim nxtIdx As Integer = rowIDX + 1
            Dim sel1 As Integer = DataGridView1.Rows.Count

            selIndx2 = nxtIdx
            DataGridView1.CurrentCell = DataGridView1(0, nxtIdx)
            ToolStripStatusLabel1.Text = DataGridView1.CurrentCell.Value & "/" & sel1
            'MessageBox.Show(nxtIdx)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_prev_Click(sender As System.Object, e As System.EventArgs) Handles btn_prev.Click
        Try
            flgInit = False
            flgSel = True
            Dim rowIDX As Integer = DataGridView1.CurrentCell.RowIndex
            Dim prvIdx As Integer = rowIDX - 1
            Dim sel2 As Integer = DataGridView1.Rows.Count

            selIndx2 = prvIdx
            DataGridView1.CurrentCell = DataGridView1(0, prvIdx)
            ToolStripStatusLabel1.Text = DataGridView1.CurrentCell.Value & "/" & sel2
            'MessageBox.Show(prvIdx)

        Catch ex As Exception

        End Try

    End Sub


    WithEvents KeyboardHooker1 As New KeyboardHooker
    Sub KeybordHooker1_KeyDown(sender As Object, e As KeyBoardHookerEventArgs) Handles KeyboardHooker1.KeyDown
        Try
            Select Case e.vkCode
                Case Keys.F3
                    'MessageBox.Show("Qkey was Pressed!")
                    btn_prev.PerformClick()
                Case Keys.F4
                    'MessageBox.Show("Wkey was Pressed!")
                    btn_next.PerformClick()
                    'Case Keys.X
            End Select

        Catch ex As Exception

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

#Region "ジオメトリを点滅させる"
    ' ArcGIS スニペット タイトル:
    ' ジオメトリを点滅させる
    ' 
    ' 詳細説明:
    ' 画面上のジオメトリを点滅させます。ジオメトリ タイプは、ポリゴン、ポリライン、ポイント、またはマルチポイントのいずれかです。
    ' 
    ' プロジェクトに次の参照を追加:
    ' ESRI.ArcGIS.Display
    ' ESRI.ArcGIS.Geometry
    ' ESRI.ArcGIS.System
    ' 
    ' このスニペットが適用されるArcGIS製品:
    ' ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
    ' ArcGIS Engine
    ' ArcGIS Server
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

    '''<summary>画面上のジオメトリを点滅させます。ジオメトリ タイプは、ポリゴン、ポリライン、ポイント、またはマルチポイントのいずれかです。</summary>
    '''
    '''<param name="geometry">IGeometryインタフェース</param>
    '''<param name="color">IRgbColorインタフェース</param>
    '''<param name="display">IDisplayインタフェース</param>
    '''<param name="delay">一時停止する時間(ミリ秒)を示すSystem.Int32型の整数</param>
    ''' 
    '''<remarks></remarks>
    Public Sub FlashGeometry(ByVal geometry As ESRI.ArcGIS.Geometry.IGeometry, ByVal color As ESRI.ArcGIS.Display.IRgbColor, ByVal display As ESRI.ArcGIS.Display.IDisplay, ByVal delay As System.Int32)

        If geometry Is Nothing OrElse color Is Nothing OrElse display Is Nothing Then
            Return
        End If

        display.StartDrawing(display.hDC, CShort(ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache))

        Select Case geometry.GeometryType
            Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon

                '点滅用のシンボルを設定します。
                Dim simpleFillSymbol As ESRI.ArcGIS.Display.ISimpleFillSymbol = New ESRI.ArcGIS.Display.SimpleFillSymbolClass
                simpleFillSymbol.Color = color
                Dim symbol As ESRI.ArcGIS.Display.ISymbol = TryCast(simpleFillSymbol, ESRI.ArcGIS.Display.ISymbol) ' ダイナミック キャスト
                symbol.ROP2 = ESRI.ArcGIS.Display.esriRasterOpCode.esriROPNotXOrPen

                '入力ポリゴンのジオメトリを点滅させます。
                display.SetSymbol(symbol)
                display.DrawPolygon(geometry)
                System.Threading.Thread.Sleep(delay)
                display.DrawPolygon(geometry)
                Exit Select

            Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline

                '点滅用のシンボルを設定します。
                Dim simpleLineSymbol As ESRI.ArcGIS.Display.ISimpleLineSymbol = New ESRI.ArcGIS.Display.SimpleLineSymbolClass
                simpleLineSymbol.Width = 4
                simpleLineSymbol.Color = color
                Dim symbol As ESRI.ArcGIS.Display.ISymbol = TryCast(simpleLineSymbol, ESRI.ArcGIS.Display.ISymbol) ' ダイナミック キャスト
                symbol.ROP2 = ESRI.ArcGIS.Display.esriRasterOpCode.esriROPNotXOrPen

                '入力ポリラインのジオメトリを点滅させます。
                display.SetSymbol(symbol)
                display.DrawPolyline(geometry)
                System.Threading.Thread.Sleep(delay)
                display.DrawPolyline(geometry)
                Exit Select

            Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint

                '点滅用のシンボルを設定します。
                Dim simpleMarkerSymbol As ESRI.ArcGIS.Display.ISimpleMarkerSymbol = New ESRI.ArcGIS.Display.SimpleMarkerSymbolClass
                simpleMarkerSymbol.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle
                simpleMarkerSymbol.Size = 12
                simpleMarkerSymbol.Color = color
                Dim symbol As ESRI.ArcGIS.Display.ISymbol = TryCast(simpleMarkerSymbol, ESRI.ArcGIS.Display.ISymbol) ' ダイナミック キャスト
                symbol.ROP2 = ESRI.ArcGIS.Display.esriRasterOpCode.esriROPNotXOrPen

                '入力ポイントのジオメトリを点滅させます。
                display.SetSymbol(symbol)
                display.DrawPoint(geometry)
                System.Threading.Thread.Sleep(delay)
                display.DrawPoint(geometry)
                Exit Select

            Case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint

                '点滅用のシンボルを設定します。
                Dim simpleMarkerSymbol As ESRI.ArcGIS.Display.ISimpleMarkerSymbol = New ESRI.ArcGIS.Display.SimpleMarkerSymbolClass
                simpleMarkerSymbol.Style = ESRI.ArcGIS.Display.esriSimpleMarkerStyle.esriSMSCircle
                simpleMarkerSymbol.Size = 12
                simpleMarkerSymbol.Color = color
                Dim symbol As ESRI.ArcGIS.Display.ISymbol = TryCast(simpleMarkerSymbol, ESRI.ArcGIS.Display.ISymbol) ' ダイナミック キャスト
                symbol.ROP2 = ESRI.ArcGIS.Display.esriRasterOpCode.esriROPNotXOrPen

                '入力マルチポイントのジオメトリを点滅させます。
                display.SetSymbol(symbol)
                display.DrawMultipoint(geometry)
                System.Threading.Thread.Sleep(delay)
                display.DrawMultipoint(geometry)
                Exit Select

        End Select

        display.FinishDrawing()

    End Sub
#End Region


#Region "マップの選択フィーチャを解除する"
    ' ArcGIS スニペット タイトル:
    ' マップの選択フィーチャを解除する
    ' 
    ' 詳細説明:
    ' 指定されたIFeatureLayerのIActiveViewの選択フィーチャを解除します。
    ' 
    ' プロジェクトに次の参照を追加:
    ' ESRI.ArcGIS.Carto
    ' ESRI.ArcGIS.Geometry
    ' 
    ' このスニペットが適用されるArcGIS製品:
    ' ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
    ' ArcGIS Engine
    ' ArcGIS Server
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

    '''<summary>指定されたIFeatureLayerのIActiveViewの選択フィーチャを解除します。</summary>
    ''' 
    '''<param name="activeView">IActiveViewインタフェース</param>
    '''<param name="featureLayer">IFeatureLayerインタフェース</param>
    ''' 
    '''<remarks></remarks>
    Public Sub ClearSelectedMapFeatures(ByVal activeView As ESRI.ArcGIS.Carto.IActiveView, ByVal featureLayer As ESRI.ArcGIS.Carto.IFeatureLayer)

        If activeView Is Nothing OrElse featureLayer Is Nothing Then

            Return

        End If

        Dim featureSelection As ESRI.ArcGIS.Carto.IFeatureSelection = TryCast(featureLayer, ESRI.ArcGIS.Carto.IFeatureSelection) ' ダイナミック キャスト

        ' 選択キャッシュのみを無効化します。オリジナルの選択をフラグ化します。
        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, Nothing, Nothing)

        ' 選択解除します。
        featureSelection.Clear()

        ' 新しい選択をフラグ化します。
        activeView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, Nothing, Nothing)

    End Sub
#End Region

#Region "中心に表示"
    ' ArcGIS Snippet Title:
    ' Zoom by Ratio and Recenter
    ' 
    ' Long Description:
    ' Zoom in ActiveView using a ratio of the current extent and re-center based upon supplied x,y map coordinates.
    ' 
    ' Add the following references to the project:
    ' ESRI.ArcGIS.Carto
    ' ESRI.ArcGIS.Geometry
    ' ESRI.ArcGIS.System
    ' 
    ' Intended ArcGIS Products for this snippet:
    ' ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
    ' ArcGIS Engine
    ' ArcGIS Server
    ' 
    ' Applicable ArcGIS Product Versions:
    ' 9.2
    ' 9.3
    ' 9.3.1
    ' 10.0
    ' 
    ' Required ArcGIS Extensions:
    ' (NONE)
    ' 
    ' Notes:
    ' This snippet is intended to be inserted at the base level of a Class.
    ' It is not intended to be nested within an existing Function or Sub.
    ' 

    '''<summary>Zoom in ActiveView using a ratio of the current extent and re-center based upon supplied x,y map coordinates.</summary>
    '''
    '''<param name="activeView">An IActiveView interface.</param>
    '''<param name="zoomRatio">A System.Double that is the ratio to zoom in. Less that 1 zooms in (Example: .75), greater than 1 zooms out (Example: 2).</param>
    '''<param name="xMap">A System.Double that is the x portion of a point in map units to re-center on.</param>
    '''<param name="yMap">A System.Double that is the y portion of a point in map units to re-center on.</param>
    ''' 
    '''<remarks>Both the width and height ratio of the zoomed area is preserved.</remarks>
    Public Sub ZoomByRatioAndRecenter(ByVal activeView As ESRI.ArcGIS.Carto.IActiveView, ByVal zoomRatio As System.Double, ByVal xMap As System.Double, ByVal yMap As System.Double)

        If activeView Is Nothing OrElse zoomRatio < 0 Then
            Return
        End If

        Dim envelope As ESRI.ArcGIS.Geometry.IEnvelope = activeView.Extent
        Dim point As ESRI.ArcGIS.Geometry.IPoint = New ESRI.ArcGIS.Geometry.PointClass
        point.X = xMap
        point.Y = yMap
        envelope.CenterAt(point)
        envelope.Expand(zoomRatio, zoomRatio, True)

        activeView.Extent = envelope
        activeView.Refresh()

    End Sub
#End Region

#Region "データグリッドビューを初期化"
    Private Sub InitDgv(ByRef dtAtr_a As DataTable)

        flgInit = True

        Dim colName1() = {"index", "layer", "j_id", "X", "Y"}
        Dim colType1() = {"System.Int32", "System.String", "System.Int32", "System.Double", "System.Double"}
        Dim dtCol As DataColumn             ' 列情報

        DataGridView1.Columns.Clear()

        For i As Integer = 0 To colName1.Length - 1
            dtCol = New DataColumn
            With dtCol
                .DataType = System.Type.GetType(colType1(i))
                .ColumnName = colName1(i)
            End With
            dtAtr_a.Columns.Add(dtCol)
        Next


    End Sub

#End Region
#Region "データグリッドビューをsort"
    Private Sub SortGrid()
        '並び替える列を決める
        Dim sortColumn As DataGridViewColumn =
        DataGridView1.Columns.Item(2)

        '並び替えの方向（昇順か降順か）を決める
        Dim sortDirection As System.ComponentModel.ListSortDirection =
        System.ComponentModel.ListSortDirection.Ascending

        DataGridView1.Sort(sortColumn, sortDirection)
    End Sub

#End Region


    ''' <summary>
    ''' Datagridviewの内容をcsvに保存
    ''' </summary>
    ''' <param name="tempDgv">csvで保存したいdatagridview</param>
    ''' <remarks></remarks>
    Public Sub SaveToCsv(ByVal tempDgv As DataGridView)

        '1行もデータが無い場合は、保存を中止します。
        If tempDgv.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim dtNow As DateTime = DateTime.Now
        Dim strToday As String = dtNow.ToString("yyyy_MM_dd")

        SaveFileDialog1.FileName = strToday & "_junkai.csv"

        '変数を定義します。
        Dim i As Integer
        Dim j As Integer
        Dim strFileName As String
        Dim strResult As New System.Text.StringBuilder

        '保存ダイアログでファイル名を設定した場合に処理を実行します。
        If Me.SaveFileDialog1.ShowDialog = DialogResult.OK Then

            'コラムヘッダを1行目に列記します。
            '※ヘッダ行が不要な場合は削除可能です。
            'For i = 0 To tempDgv.Columns.Count - 1
            '    Select Case i
            '        Case 0
            '            strResult.Append("""" & _
            '            tempDgv.Columns(i).HeaderText.ToString & """")

            '        Case tempDgv.Columns.Count - 1
            '            strResult.Append("," & """" & _
            '            tempDgv.Columns(i).HeaderText.ToString & _
            '            """" & vbCrLf)

            '        Case Else
            '            strResult.Append("," & """" & _
            '            tempDgv.Columns(i).HeaderText.ToString & """")
            '    End Select

            'Next

            'データを保存します。
            '※新規行の追加を認めている場合は、次行の
            '「tempDgv.Columns.Count - 1」を
            '「tempDgv.Columns.Count - 2」としてください。
            For i = 0 To tempDgv.Rows.Count - 1
                For j = 0 To tempDgv.Columns.Count - 1
                    Select Case j
                        Case 0
                            strResult.Append("""" &
                            tempDgv.Rows(i).Cells(j).Value.ToString &
                            """")

                        Case tempDgv.Columns.Count - 1
                            strResult.Append("," & """" &
                            tempDgv.Rows(i).Cells(j).Value.ToString &
                            """" & vbCrLf)

                        Case Else
                            strResult.Append("," & """" &
                            tempDgv.Rows(i).Cells(j).Value.ToString &
                            """")
                    End Select

                Next
            Next

            'ファイル名を保存ダイアログで指定した値に設定します。
            strFileName = SaveFileDialog1.FileName

            'Shift-JISで保存します。
            Dim swText As New System.IO.StreamWriter(strFileName,
              False, System.Text.Encoding.GetEncoding(932))
            swText.Write(strResult.ToString)
            swText.Dispose()

        End If

    End Sub

    ''' <summary>
    ''' csvをDatagridviewに読み込む
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CsvtoDgv()

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Try
                Dim inputCsv As String = OpenFileDialog1.FileName
                Dim parser As FileIO.TextFieldParser = New FileIO.TextFieldParser(inputCsv, Encoding.GetEncoding("Shift_JIS"))
                parser.TextFieldType = FileIO.FieldType.Delimited
                parser.SetDelimiters(",") ' 区切り文字はコンマ

                Dim dtAtr As DataTable = New DataTable()
                Dim dtRow As DataRow

                InitDgv(dtAtr)

                While (Not parser.EndOfData)
                    Dim row As String() = parser.ReadFields() ' 1行読み込み
                    ' 読み込んだデータ(1行をDataGridViewに表示する)
                    dtRow = dtAtr.NewRow()

                    dtRow.Item(0) = row(0)
                    dtRow.Item(1) = row(1)
                    dtRow.Item(2) = row(2)
                    dtRow.Item(3) = row(3)
                    dtRow.Item(4) = row(4)

                    dtAtr.Rows.Add(dtRow)
                End While

                DataGridView1.DataSource = dtAtr

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show(ex.StackTrace, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

End Class