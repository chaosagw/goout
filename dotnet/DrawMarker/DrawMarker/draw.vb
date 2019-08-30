﻿Imports System.Windows.Forms

Public Class draw
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Public flgOnOff As Boolean = False

    Protected Overrides Sub OnClick()
        '
        '  TODO: Sample code showing how to access button host
        '
        Try
            If flgOnOff = False Then
                DrawArrow()
            Else
                Redraw()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        My.ArcMap.Application.CurrentTool = Nothing
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub

    Private Sub DrawArrow()

        If My.ArcMap.Document.FocusMap.SelectionCount = 0 Then Return

        flgOnOff = True

        Dim screenDisp As IScreenDisplay2 = My.ArcMap.Document.ActiveView.ScreenDisplay

        Dim pt1 As IPoint = New PointClass
        Dim pt2 As IPoint = New PointClass
        pt1 = screenDisp.DisplayTransformation.ToMapPoint(0, 0)
        pt2 = screenDisp.DisplayTransformation.ToMapPoint(1, 0)

        Dim ml As Double = GetPixelSize(My.ArcMap.Document.ActiveView)

        Dim pRGB As IRgbColor = New RgbColorClass
        pRGB.RGB = RGB(0, 0, 0)

        Dim arrowMarker As IArrowMarkerSymbol = New ArrowMarkerSymbolClass
        arrowMarker.Color = pRGB
        arrowMarker.Size = 12
        arrowMarker.Length = 6
        arrowMarker.Width = 4

        'Using releaser As ComReleaser = New ComReleaser
        screenDisp.StartDrawing(0, esriScreenCache.esriNoScreenCache)

        Dim selection As ISelection = My.ArcMap.Document.FocusMap.FeatureSelection

        Dim enumFeature As IEnumFeature = selection
        enumFeature.Reset()

        Dim feature As IFeature = enumFeature.Next
        Do Until feature Is Nothing

            Dim featureclass As IFeatureClass = feature.Class
            If featureclass.ShapeType = esriGeometryType.esriGeometryPolyline Then

                Dim polyCurve As IPolycurve2 = feature.ShapeCopy

                Dim polyCurveLength As Double = polyCurve.Length
                Dim screenLength As Integer = polyCurveLength / ml
                Dim scrStep As Double = 100
                Dim mapStep As Double = scrStep * ml

                Dim distArray() As Double = Nothing
                Dim count As Integer = 0

                For d As Double = 10 * ml To polyCurveLength - (20 * ml) Step mapStep
                    ReDim Preserve distArray(count)
                    distArray(count) = d
                    count += 1
                Next

                Dim geometryBridge As IGeometryBridge2 = New GeometryEnvironmentClass
                Dim splitPoints As IEnumSplitPoint = geometryBridge.SplitAtDistances(polyCurve, distArray, False, True)

                splitPoints.Reset()

                Dim curPoint As IPoint = Nothing
                Dim partIndex As Integer = 0
                Dim vertexIndex As Integer = 0
                Dim pointCount As Integer = 0

                splitPoints.Next(curPoint, partIndex, vertexIndex)

                Do Until curPoint Is Nothing
                    arrowMarker.Angle = 90
                    screenDisp.SetSymbol(arrowMarker)
                    screenDisp.DrawPoint(curPoint)

                    splitPoints.Next(curPoint, partIndex, vertexIndex)

                Loop
            End If

            feature = enumFeature.Next

        Loop

        screenDisp.FinishDrawing()

        'End Using

    End Sub

    Private Sub Redraw()
        'Dim screenDisp As IScreenDisplay2 = My.ArcMap.Document.ActiveView.ScreenDisplay
        'screenDisp.UpdateWindow()
        My.ArcMap.Document.ActiveView.Refresh()
        flgOnOff = False
    End Sub

    Public Function GetPixelSize(ByVal activeView As ESRI.ArcGIS.Carto.IActiveView) As System.Double

        If activeView Is Nothing Then
            Return -1
        End If

        'Get the ScreenDisplay
        Dim screenDisplay As ESRI.ArcGIS.Display.IScreenDisplay = activeView.ScreenDisplay

        'Get the DisplayTransformation 
        Dim displayTransformation As ESRI.ArcGIS.Display.IDisplayTransformation = screenDisplay.DisplayTransformation

        'Get the device frame which will give us the number of pixels in the X direction
        Dim deviceRECT As ESRI.ArcGIS.esriSystem.tagRECT = displayTransformation.DeviceFrame
        Dim pixelExtent As System.Int32 = (deviceRECT.right - deviceRECT.left)

        'Get the map extent of the currently visible area
        Dim envelope As ESRI.ArcGIS.Geometry.IEnvelope = displayTransformation.VisibleBounds
        Dim realWorldDisplayExtent As System.Double = envelope.Width

        'Calculate the size of one pixel
        If pixelExtent = 0 Then
            Return -1
        End If

        Dim sizeOfOnePixel As System.Double = (realWorldDisplayExtent / pixelExtent)

        'Multiply this by the input argument to get the result
        Return (sizeOfOnePixel)

    End Function

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 