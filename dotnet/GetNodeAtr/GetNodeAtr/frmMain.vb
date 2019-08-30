﻿Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Desktop.AddIns
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.ArcMapUI
Imports System.Windows.Forms

Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cbKETA.SelectedIndex = 8
    End Sub

    Private Sub btnOutFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOutFile.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            tbOutDir.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub


    Private Sub btnGetVrtx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetVrtx.Click

        Dim activeView As IActiveView = My.ArcMap.Document.ActiveView
        Dim pMap As IMap = activeView.FocusMap
        Dim fCursor As IFeatureCursor = Nothing
        Dim curFeature As IFeature = Nothing
        Dim FC As IFeatureClass = Nothing
        Dim FL As IFeatureLayer = Nothing
        Dim Keta As Integer = CInt(cbKETA.Text)

        If tbOutDir.Text = "" Then
            MessageBox.Show("出力先が指定されていません!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '読み込んでいるレイヤ分繰り返し
        For i As Integer = 0 To pMap.LayerCount - 1

            Application.DoEvents()

            Try
                If IO.File.Exists(tbOutDir.Text & "\" & pMap.Layer(i).Name & ".csv") = True Then
                    IO.File.Delete(tbOutDir.Text & "\" & pMap.Layer(i).Name & ".csv")
                End If
            Catch ex As Exception
                MessageBox.Show("出力ファイルを上書きできません!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            Dim outFile As String = tbOutDir.Text & "\" & pMap.Layer(i).Name & ".csv"
            Dim SW As New IO.StreamWriter(outFile, False, System.Text.Encoding.GetEncoding("Shift-JIS"))
            'csvのヘッダ書き込み
            SW.WriteLine("B,L,bsc,boc,bln,rpd,rps,rph,rmk,FLG,FLG2")

            FL = pMap.Layer(i)
            FC = FL.FeatureClass
            fCursor = FC.Search(Nothing, True)
            curFeature = fCursor.NextFeature

            My.ArcMap.Application.StatusBar.ShowProgressBar(pMap.Layer(i).Name & "を処理中...", 0, FC.FeatureCount(Nothing), 1, True)

            'レイヤ内全てのラインを巡回する
            Do Until curFeature Is Nothing

                My.ArcMap.Application.StatusBar.StepProgressBar()

                Dim bsc As Integer = curFeature.Value(2)
                Dim boc As String = curFeature.Value(3)
                Dim bln As String = curFeature.Value(4)
                Dim rpd As Double = ShisyaGonyu(curFeature.Value(5), 2)
                Dim rps As Double = ShisyaGonyu(curFeature.Value(6), 2)
                Dim rph As Double = ShisyaGonyu(curFeature.Value(7), 2)
                Dim rmk As String

                If curFeature.Value(8) = " " Then
                    rmk = ""
                Else
                    rmk = curFeature.Value(8)
                End If

                Dim flg As Integer = curFeature.Value(9)
                Dim pGeom As IGeometry = curFeature.Shape
                Dim pPointCol As IPointCollection = pGeom
                Dim vrtxNum As Integer = pPointCol.PointCount
                Dim pPoint As IPoint = Nothing

                '頂点をすべて巡回して座標を取得しcsvに書き込む
                For ii As Integer = 0 To vrtxNum - 1

                    Dim strPnt As String = ""

                    pPoint = pPointCol.Point(ii)
                    'スタート点だったら
                    If ii = 0 Then
                        strPnt = ShisyaGonyu(pPoint.Y, Keta) & "," & ShisyaGonyu(pPoint.X, Keta) & "," & bsc & "," & boc & "," & bln & "," & rpd & "," & rps & "," & rph & "," & rmk & "," & flg & ",s"
                        SW.WriteLine(strPnt)
                    ElseIf ii = vrtxNum - 1 Then    'エンド点だったら
                        strPnt = ShisyaGonyu(pPoint.Y, Keta) & "," & ShisyaGonyu(pPoint.X, Keta) & "," & bsc & "," & boc & "," & bln & "," & rpd & "," & rps & "," & rph & "," & rmk & "," & flg & ",e"
                        SW.WriteLine(strPnt)
                    Else    '間の点だったら
                        strPnt = ShisyaGonyu(pPoint.Y, Keta) & "," & ShisyaGonyu(pPoint.X, Keta) & "," & bsc & "," & boc & "," & bln & "," & rpd & "," & rps & "," & rph & "," & rmk & "," & flg & ",0"
                        SW.WriteLine(strPnt)
                    End If

                Next
                curFeature = fCursor.NextFeature
            Loop
            SW.Close()
        Next

        My.ArcMap.Application.StatusBar.HideProgressBar()
        MessageBox.Show("おわり", "おわり", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    '''=======================================================
    '''<summary>指定した精度に四捨五入。</summary>
    ''' 
    '''<param name="dValue">四捨五入する数値(double)</param>
    '''<param name="iDigits">桁数(integer)</param>
    '''  
    '''<returns>四捨五入された数値</returns>
    '''=======================================================
    Public Shared Function ShisyaGonyu(ByVal dValue As Double, ByVal iDigits As Integer) As Double
        Dim dCoef As Double = System.Math.Pow(10, iDigits)

        If dValue > 0 Then
            Return System.Math.Floor((dValue * dCoef) + 0.5) / dCoef
        Else
            Return System.Math.Ceiling((dValue * dCoef) - 0.5) / dCoef
        End If
    End Function

End Class                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  