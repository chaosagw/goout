Imports System.Windows.Forms
Imports ESRI.ArcGIS.Carto

''' <summary>
''' 
''' </summary>
Public Class SwitchLbl
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()

        '  TODO: Sample code showing how to access button host
        '
        'My.ArcMap.Application.CurrentTool = Nothing
        Dim layers As New ArrayList
        Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
        'Dim disp As IDisplay = My.ArcMap.Document.ActiveView.ScreenDisplay
        'Dim phase As esriDrawPhase = New esriDrawPhase.esriDPGeography
        Dim pMap As IMap = activeView.FocusMap
        Dim GFL As IGeoFeatureLayer
        'Dim FL As IFeatureLayer
        'Dim GL As IGroupLayer

        Try

            If Checked = False Then

                'イベントハンドラを設定
                'SetupActiveViewEvents(pMap)

                For i = 0 To pMap.LayerCount - 1

                    If TypeOf pMap.Layer(i) Is IGeoFeatureLayer Then
                        GFL = pMap.Layer(i)
                        GFL.DisplayAnnotation = True
                    End If
                Next

                Checked = True

            Else

                For i = 0 To pMap.LayerCount - 1

                    If TypeOf pMap.Layer(i) Is IGeoFeatureLayer Then
                        GFL = pMap.Layer(i)
                        GFL.DisplayAnnotation = False
                    End If
                Next

                Checked = False
                'イベントハンドラを削除
                'RemoveActiveViewEvents(pMap)

            End If

            activeView.Refresh()

        Catch ex As Exception

            MessageBox.Show("レイヤ一覧取得のところでエラーです！" & ex.Message & ex.InnerException.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

        'Checked = True

    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub

#Region "すべてのIActiveViewEventsのイベント ハンドラを追加する"
    ' ArcGIS スニペット タイトル:
    ' すべてのIActiveViewEventsのイベント ハンドラを追加する
    ' 
    ' 詳細説明:
    ' すべてのIActiveViewEventsのイベント ハンドラを追加します。デフォルトのメンバ変数が宣言され、すべてのイベントがセットアップ関数の呼び出しによって追加されます。イベントを削除するには、別の削除関数を呼び出します。イベントのカスタム アクションを追加するためのコード関数のスタブが作成されます
    ' 
    ' プロジェクトに次の参照を追加:
    ' ESRI.ArcGIS.Carto
    ' ESRI.ArcGIS.Display
    ' ESRI.ArcGIS.Geometry
    ' ESRI.ArcGIS.System
    ' 
    ' このスニペットが適用されるArcGIS製品:
    ' ArcGIS Desktop (ArcEditor, ArcInfo, ArcView)
    ' ArcGIS Engine
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

    ''' <summary>
    ''' セクション: イベント ハンドラの宣言
    ''' </summary>
    ''' <remarks>
    ''' 変数の接頭語'm_'はメンバ変数を意味します。 
    ''' これはこのクラス内で使用するグローバル変数を意味します。
    ''' </remarks>
    Private m_ActiveViewEventsAfterDraw As ESRI.ArcGIS.Carto.IActiveViewEvents_AfterDrawEventHandler
    Private m_ActiveViewEventsAfterItemDraw As ESRI.ArcGIS.Carto.IActiveViewEvents_AfterItemDrawEventHandler
    Private m_ActiveViewEventsContentsChanged As ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsChangedEventHandler
    Private m_ActiveViewEventsContentsCleared As ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsClearedEventHandler
    Private m_ActiveViewEventsFocusMapChanged As ESRI.ArcGIS.Carto.IActiveViewEvents_FocusMapChangedEventHandler
    Private m_ActiveViewEventsItemAdded As ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler
    Private m_ActiveViewEventsItemDeleted As ESRI.ArcGIS.Carto.IActiveViewEvents_ItemDeletedEventHandler
    Private m_ActiveViewEventsItemReordered As ESRI.ArcGIS.Carto.IActiveViewEvents_ItemReorderedEventHandler
    Private m_ActiveViewEventsSelectionChanged As ESRI.ArcGIS.Carto.IActiveViewEvents_SelectionChangedEventHandler
    Private m_ActiveViewEventsSpatialReferenceChanged As ESRI.ArcGIS.Carto.IActiveViewEvents_SpatialReferenceChangedEventHandler
    Private m_ActiveViewEventsViewRefreshed As ESRI.ArcGIS.Carto.IActiveViewEvents_ViewRefreshedEventHandler


    ''' <summary>
    ''' セクション: IActiveViewEventsの全てのイベント ハンドラの設定
    ''' </summary>
    ''' <param name="map">イベント ハンドラを設定するためのIMapインタフェース</param>
    ''' <remarks>全てのイベント ハンドラを設定する必要はありません。 
    ''' 使用したいイベント ハンドラを選択することができます。</remarks>
    Private Sub SetupActiveViewEvents(ByVal map As ESRI.ArcGIS.Carto.IMap)

        If map Is Nothing Then
            Return
        End If

        Dim activeViewEvents As ESRI.ArcGIS.Carto.IActiveViewEvents_Event = TryCast(map, ESRI.ArcGIS.Carto.IActiveViewEvents_Event)

        'デリゲートのインスタンスを作成し、AfterDrawイベントに追加します。
        m_ActiveViewEventsAfterDraw = New ESRI.ArcGIS.Carto.IActiveViewEvents_AfterDrawEventHandler(AddressOf OnActiveViewEventsAfterDraw)
        AddHandler activeViewEvents.AfterDraw, m_ActiveViewEventsAfterDraw

        'デリゲートのインスタンスを作成し、AfterItemDrawイベントに追加します。
        m_ActiveViewEventsAfterItemDraw = New ESRI.ArcGIS.Carto.IActiveViewEvents_AfterItemDrawEventHandler(AddressOf OnActiveViewEventsItemDraw)
        AddHandler activeViewEvents.AfterItemDraw, m_ActiveViewEventsAfterItemDraw

        'デリゲートのインスタンスを作成し、ContentsChangedイベントに追加します。
        m_ActiveViewEventsContentsChanged = New ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsChangedEventHandler(AddressOf OnActiveViewEventsContentsChanged)
        AddHandler activeViewEvents.ContentsChanged, m_ActiveViewEventsContentsChanged

        'デリゲートのインスタンスを作成し、ContentsClearedイベントに追加します。
        m_ActiveViewEventsContentsCleared = New ESRI.ArcGIS.Carto.IActiveViewEvents_ContentsClearedEventHandler(AddressOf OnActiveViewEventsContentsCleared)
        AddHandler activeViewEvents.ContentsCleared, m_ActiveViewEventsContentsCleared

        'デリゲートのインスタンスを作成し、FocusMapChangedイベントに追加します。
        m_ActiveViewEventsFocusMapChanged = New ESRI.ArcGIS.Carto.IActiveViewEvents_FocusMapChangedEventHandler(AddressOf OnActiveViewEventsFocusMapChanged)
        AddHandler activeViewEvents.FocusMapChanged, m_ActiveViewEventsFocusMapChanged

        'デリゲートのインスタンスを作成し、ItemAddedイベントに追加します。
        m_ActiveViewEventsItemAdded = New ESRI.ArcGIS.Carto.IActiveViewEvents_ItemAddedEventHandler(AddressOf OnActiveViewEventsItemAdded)
        AddHandler activeViewEvents.ItemAdded, m_ActiveViewEventsItemAdded

        'デリゲートのインスタンスを作成し、ItemDeletedイベントに追加します。
        m_ActiveViewEventsItemDeleted = New ESRI.ArcGIS.Carto.IActiveViewEvents_ItemDeletedEventHandler(AddressOf OnActiveViewEventsItemDeleted)
        AddHandler activeViewEvents.ItemDeleted, m_ActiveViewEventsItemDeleted

        'デリゲートのインスタンスを作成し、ItemReorderedイベントに追加します。
        m_ActiveViewEventsItemReordered = New ESRI.ArcGIS.Carto.IActiveViewEvents_ItemReorderedEventHandler(AddressOf OnActiveViewEventsItemReordered)
        AddHandler activeViewEvents.ItemReordered, m_ActiveViewEventsItemReordered

        'デリゲートのインスタンスを作成し、SelectionChangedイベントに追加します。
        m_ActiveViewEventsSelectionChanged = New ESRI.ArcGIS.Carto.IActiveViewEvents_SelectionChangedEventHandler(AddressOf OnActiveViewEventsSelectionChanged)
        AddHandler activeViewEvents.SelectionChanged, m_ActiveViewEventsSelectionChanged

        'デリゲートのインスタンスを作成し、SpatialReferenceChangedイベントに追加します。
        m_ActiveViewEventsSpatialReferenceChanged = New ESRI.ArcGIS.Carto.IActiveViewEvents_SpatialReferenceChangedEventHandler(AddressOf OnActiveViewEventsSpatialReferenceChanged)
        AddHandler activeViewEvents.SpatialReferenceChanged, m_ActiveViewEventsSpatialReferenceChanged

        'デリゲートのインスタンスを作成し、ViewRefreshedイベントに追加します。
        m_ActiveViewEventsViewRefreshed = New ESRI.ArcGIS.Carto.IActiveViewEvents_ViewRefreshedEventHandler(AddressOf OnActiveViewEventsViewRefreshed)
        AddHandler activeViewEvents.ViewRefreshed, m_ActiveViewEventsViewRefreshed
    End Sub

    ''' <summary>
    ''' セクション: IActiveViewEventsの全てのイベント ハンドラを削除します。
    ''' </summary>
    ''' <param name="map">イベント ハンドラを削除するためのIMapインタフェース</param>
    ''' <remarks>全てのイベント ハンドラを削除する必要はありません。 
    ''' 使用したいイベント ハンドラを選択することができます。</remarks>
    Private Sub RemoveActiveViewEvents(ByVal map As ESRI.ArcGIS.Carto.IMap)

        ' パラメータ チェック
        If map Is Nothing Then
            Return
        End If

        Dim activeViewEvents As ESRI.ArcGIS.Carto.IActiveViewEvents_Event = TryCast(map, ESRI.ArcGIS.Carto.IActiveViewEvents_Event)

        ' AfterDrawイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.AfterDraw, m_ActiveViewEventsAfterDraw

        ' AfterItemDrawイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.AfterItemDraw, m_ActiveViewEventsAfterItemDraw

        ' ContentsChangedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ContentsChanged, m_ActiveViewEventsContentsChanged

        ' ContentsClearedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ContentsCleared, m_ActiveViewEventsContentsCleared

        ' FocusMapChangedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.FocusMapChanged, m_ActiveViewEventsFocusMapChanged

        ' ItemAddedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ItemAdded, m_ActiveViewEventsItemAdded

        ' ItemDeletedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ItemDeleted, m_ActiveViewEventsItemDeleted

        ' ItemReorderedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ItemReordered, m_ActiveViewEventsItemReordered

        ' SelectionChangedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.SelectionChanged, m_ActiveViewEventsSelectionChanged

        ' SpatialReferenceChangedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.SpatialReferenceChanged, m_ActiveViewEventsSpatialReferenceChanged

        ' ViewRefreshedイベント ハンドラを削除します。
        RemoveHandler activeViewEvents.ViewRefreshed, m_ActiveViewEventsViewRefreshed

    End Sub

    ''' <summary>
    ''' AfterDrawイベント ハンドラ
    ''' </summary>
    ''' <param name="Display"></param>
    ''' <param name="phase"></param>
    ''' <remarks>セクション: イベントに機能を追加するために記述するカスタム関数</remarks>
    Private Sub OnActiveViewEventsAfterDraw(ByVal display As ESRI.ArcGIS.Display.IDisplay, ByVal phase As ESRI.ArcGIS.Carto.esriViewDrawPhase)
        ' TODO: ここにコードを追加します。
        If Checked = True Then
            If phase = 1 Then
                MessageBox.Show("AfterDraw")
            End If
        End If
    End Sub

    ''' <summary>
    ''' ItemDrawイベント ハンドラ
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <param name="Display"></param>
    ''' <param name="phase"></param>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsItemDraw(ByVal Index As System.Int16, ByVal display As ESRI.ArcGIS.Display.IDisplay, ByVal phase As ESRI.ArcGIS.esriSystem.esriDrawPhase)
        ' TODO: ここにコードを追加します。
        'System.Windows.Forms.MessageBox.Show("ItemDraw")
    End Sub

    ''' <summary>
    ''' ContentsChangedイベント ハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsContentsChanged()
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("ContentsChanged") 
    End Sub

    ''' <summary>
    ''' ContentsClearedイベント ハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsContentsCleared()
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("ContentsCleared") 
    End Sub

    ''' <summary>
    ''' FocusMapChangedイベント ハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsFocusMapChanged()
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("FocusMapChanged") 
    End Sub

    ''' <summary>
    ''' ItemAddedイベント ハンドラ
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsItemAdded(ByVal Item As System.Object)
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("ItemAdded") 
    End Sub

    ''' <summary>
    ''' ItemDeletedイベント ハンドラ
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsItemDeleted(ByVal Item As System.Object)
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("ItemDeleted") 
    End Sub

    ''' <summary>
    ''' ItemReorderedイベント ハンドラ
    ''' </summary>
    ''' <param name="Item"></param>
    ''' <param name="toIndex"></param>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsItemReordered(ByVal Item As System.Object, ByVal toIndex As System.Int32)
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("ItemReordered") 
    End Sub

    ''' <summary>
    ''' SelectionChangedイベント ハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsSelectionChanged()
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("SelectionChanged") 
    End Sub

    ''' <summary>
    ''' SpatialReferenceChangedイベント ハンドラ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsSpatialReferenceChanged()
        ' TODO: ここにコードを追加します。
        ' System.Windows.Forms.MessageBox.Show("SpatialReferenceChanged") 
    End Sub

    ''' <summary>
    ''' ViewRefreshedイベント ハンドラ
    ''' </summary>
    ''' <param name="view"></param>
    ''' <param name="phase"></param>
    ''' <param name="data"></param>
    ''' <param name="envelope"></param>
    ''' <remarks></remarks>
    Private Sub OnActiveViewEventsViewRefreshed(ByVal view As ESRI.ArcGIS.Carto.IActiveView, ByVal phase As ESRI.ArcGIS.Carto.esriViewDrawPhase, ByVal data As System.Object, ByVal envelope As ESRI.ArcGIS.Geometry.IEnvelope)
        ' TODO: ここにコードを追加します。
        'System.Windows.Forms.MessageBox.Show("ViewRefreshed")
    End Sub
#End Region
End Class
