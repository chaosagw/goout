Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Runtime


Public Class Form1


    Private Sub btn_go_Click(sender As System.Object, e As System.EventArgs) Handles btn_go.Click

        Dim f As String = ""
        Dim err_log As String = tbPath.Text & "\err.txt"
        Dim err_writer As New StreamWriter(err_log, False, System.Text.Encoding.GetEncoding("shift_jis"))


        Dim app As Excel.Application = Nothing
        Dim book As Excel.Workbook = Nothing
        Dim sheets As Excel.Sheets = Nothing
        Dim sheet As Excel.Worksheet = Nothing
        Dim shp As Excel.Shape = Nothing
        Dim fList As New List(Of String)
        Dim typList1 As New List(Of String)(New String() {"水銀ランプ ", "高圧水銀ランプ", "高圧水銀ランプ", "高圧、水銀灯"})
        Dim typList2 As New List(Of String)(New String() {"セラミックメタルハライドランプ（エコセラ R）", "セラミックメタルハライドランプ（エコセラR）", "セラ ミックメタルハライドランプ（エコセラⅡ）", "セラミ ックメタルハライドランプ（FCE セラルクスエース EX）", "アルミナセラミック", "エコセラⅡ"})
        Dim typList3 As New List(Of String)(New String() {"蛍光ランプ", "コンパクト型蛍光ランプ", "コンパクト蛍光ランプ", "蛍光灯"})
        Dim files As String()
        Dim outDB As String = tbPath.Text & "\db.csv"
        Dim strLine As String
        Dim writer As New StreamWriter(outDB, False, System.Text.Encoding.GetEncoding("shift_jis"))

        writer.WriteLine("整理番号,路線名,設置場所,ポール地上高（ｍ）,光源の種類,光源の種類2,電力（Ｗ）,ポール出巾（ｃｍ）,共架柱番号,設置年,設置方式,お客様番号,照明灯番号,補修経歴_年日1,補修経歴_内容1,補修経歴_原因1,補修経歴_年日2,補修経歴_内容2,補修経歴_原因2,補修経歴_年日3,補修経歴_内容3,補修経歴_原因3,補修経歴_年日4,補修経歴_内容4,補修経歴_原因4,補修経歴_年日5,補修経歴_内容5,補修経歴_原因5")

        files = IO.Directory.GetFiles(tbPath.Text, "*.xls*", IO.SearchOption.AllDirectories)
        fList.AddRange(files)
        pgBar.Maximum = fList.Count

        app = CreateObject("Excel.Application")
        app.Visible = False    'アプリケーションの非表示

        For Each f In fList

            Dim adrs As String
            Dim val1 As String = ""
            Dim val2 As String = ""
            Dim val3 As String = ""
            Dim val4 As String = ""
            Dim val5 As String = ""
            Dim val5_1 As String = ""
            Dim val6 As String = ""
            Dim val7 As String = ""
            Dim val8 As String = ""
            Dim val9 As String = ""
            Dim val10 As String = ""
            Dim val11 As String = ""
            Dim val12 As String = ""
            Dim val13 As String = ""
            Dim val14 As String = ""
            Dim val15 As String = ""
            Dim val16 As String = ""
            Dim val17 As String = ""
            Dim val18 As String = ""
            Dim val19 As String = ""
            Dim val20 As String = ""
            Dim val21 As String = ""
            Dim val22 As String = ""
            Dim val23 As String = ""
            Dim val24 As String = ""
            Dim val25 As String = ""
            Dim val26 As String = ""
            Dim val27 As String = ""

            Try

                book = app.Workbooks.Open(f)     'ファイルを開く
                sheets = book.Worksheets

                'Dim cnt As Integer = 1
                For Each sheet In sheets
                    If sheet.Name = "照明灯台帳" Then
                        Exit For
                    End If
                    'cnt = cnt + 1
                Next


                'If Strings.Right(f, 1) = "x" Then
                '    sheet = book.Worksheets(5)     '照明灯台帳を選択
                'Else
                '    sheet = book.Worksheets(6)     '照明灯台帳を選択
                'End If

                'MessageBox.Show(sheet.Name)
                'For Each sheet In book.Worksheets
                '    MessageBox.Show(sheet.Name)
                'Next
                'Debug.WriteLine(sheet.Cells(4, 40).Value)   '値を読み出す
                'MessageBox.Show(sheet.Name)
                'MessageBox.Show(sheet.Cells(4, 40).Value)
                val1 = sheet.Cells(4, 40).Value
                'MessageBox.Show(sheet.Cells(4, 1).Value)
                val2 = sheet.Cells(4, 1).Value
                'MessageBox.Show(sheet.Cells(4, 13).Value & sheet.Cells(4, 21).Value)
                val3 = sheet.Cells(4, 13).Value & sheet.Cells(4, 21).Value
                'MessageBox.Show(sheet.Cells(8, 21).Value)
                val4 = sheet.Cells(8, 21).Value
                '光源の種類
                'MessageBox.Show(sheet.Cells(7, 1).Value)
                val5 = sheet.Cells(7, 1).Value
                val5 = val5.Replace(vbTab, "")
                val5 = val5.Replace("　", "")
                val5 = val5.Replace(vbLf, "")
                'MessageBox.Show(val5)
                val5_1 = val5
                If typList1.Contains(val5) Then
                    val5 = "水銀灯"

                ElseIf typList2.Contains(val5) Then
                    val5 = "セラミックメタルハライドランプ"
                ElseIf val5 = "ナトリウム灯" Then
                    val5 = "高圧ナトリウムランプ"
                ElseIf typList3.Contains(val5) Then
                    val5 = "その他"
                End If

                'MessageBox.Show(sheet.Cells(8, 13).Value)
                val6 = sheet.Cells(8, 13).Value
                'MessageBox.Show(sheet.Cells(8, 29).Value)
                val7 = sheet.Cells(8, 29).Value
                'MessageBox.Show(sheet.Cells(10, 34).Value)
                val8 = sheet.Cells(10, 34).Value
                'MessageBox.Show(sheet.Cells(7, 37).Value & sheet.Cells(7, 42).Value)

                Dim year As String = sheet.Cells(7, 37).Value
                Dim mon As String = sheet.Cells(7, 42).Value

                If Not year = "不明" Then

                    If year <> "" Then

                        If Not year.Contains("年") Then
                            year = year & "年"
                        End If

                        If Not mon.Contains("月") Then
                            mon = mon & "月"
                        End If

                    End If

                End If

                val9 = year & mon
                'MessageBox.Show(sheet.Cells(18, 9).Value)
                val11 = sheet.Cells(18, 9).Value
                'MessageBox.Show(sheet.Cells(17, 9).Value)
                val12 = sheet.Cells(17, 9).Value
                'MessageBox.Show(sheet.Cells(56, 1).Value)
                val13 = sheet.Cells(56, 1).Value
                'MessageBox.Show(sheet.Cells(56, 10).Value)
                val14 = sheet.Cells(56, 10).Value
                'MessageBox.Show(sheet.Cells(56, 28).Value)
                val15 = sheet.Cells(56, 28).Value
                'MessageBox.Show(sheet.Cells(57, 1).Value)
                val16 = sheet.Cells(57, 1).Value
                'MessageBox.Show(sheet.Cells(57, 10).Value)
                val17 = sheet.Cells(57, 10).Value
                'MessageBox.Show(sheet.Cells(57, 28).Value)
                val18 = sheet.Cells(57, 28).Value
                'MessageBox.Show(sheet.Cells(58, 1).Value)
                val19 = sheet.Cells(58, 1).Value
                'MessageBox.Show(sheet.Cells(58, 10).Value)
                val20 = sheet.Cells(58, 10).Value
                'MessageBox.Show(sheet.Cells(58, 28).Value)
                val21 = sheet.Cells(58, 28).Value
                'MessageBox.Show(sheet.Cells(59, 1).Value)
                val22 = sheet.Cells(59, 1).Value
                'MessageBox.Show(sheet.Cells(59, 10).Value)
                val23 = sheet.Cells(59, 10).Value
                'MessageBox.Show(sheet.Cells(59, 28).Value)
                val24 = sheet.Cells(59, 28).Value
                'MessageBox.Show(sheet.Cells(60, 1).Value)
                val25 = sheet.Cells(60, 1).Value
                'MessageBox.Show(sheet.Cells(60, 10).Value)
                val26 = sheet.Cells(60, 10).Value
                'MessageBox.Show(sheet.Cells(60, 28).Value)
                val27 = sheet.Cells(60, 28).Value

                'シート内全てのオートシェイプの場所を調べる
                For Each shp In sheet.Shapes
                    'MessageBox.Show(shp.TopLeftCell.Address(False, False))
                    adrs = shp.TopLeftCell.Address(False, False)

                    If adrs = "V11" Then

                        val10 = "架空"
                        Exit For

                    ElseIf adrs = "Y11" Then

                        val10 = "地下"
                        Exit For

                    ElseIf adrs = "AB10" Then

                        val10 = "共架"
                        Exit For

                    ElseIf adrs = "AE10" Then

                        val10 = "その他"
                        Exit For

                    End If

                Next

                strLine = val1 & "," & val2 & "," & val3 & "," & val4 & "," & val5_1 & "," & val5 & "," & val6 & "," & val7 & "," & val8 & "," & val9 & "," & val10 & "," & val11 & "," & val12 & "," & val13 & "," & val14 & "," & val15 & "," & val16 & "," & val17 & "," & val18 & "," & val19 & "," & val20 & "," & val21 & "," & val22 & "," & val23 & "," & val24 & "," & val25 & "," & val26 & "," & val27
                writer.WriteLine(strLine)
                'book.Close()
                'app.DisplayAlerts = False
                'app.Quit() '終了

                pgBar.Increment(1)

            Catch ex As Exception
                'MessageBox.Show("エラー！")
                'MessageBox.Show(f)
                'MessageBox.Show(ex.Message)
                err_writer.WriteLine(f & "," & ex.Message)
            Finally
                book.Close()
                app.DisplayAlerts = False
                app.Quit() '終了
                pgBar.Increment(1)

            End Try

            Application.DoEvents()

        Next
        'book = app.Workbooks.Add     '新規作成
        writer.Close()
        err_writer.Close()

        ' オブジェクトを解放します。
        'sheet = Nothing
        'book = Nothing
        'app = Nothing
        GP_ReleaseComObject(sheets)
        GP_ReleaseComObject(sheet)
        GP_ReleaseComObject(book)
        GP_ReleaseComObject(shp)
        GP_ReleaseComObject(app)
        writer = Nothing
        GC.Collect()

        btn_go.Text = "おわり"


    End Sub

    '---------------------------------------------------------------------------
    '   COMオブジェクトの解放処理(共通処理)
    '---------------------------------------------------------------------------
    Private Sub GP_ReleaseComObject(ByRef objCOM As Object)
        ' 明示的にCOMオブジェクトの参照を解放
        Try
            ' オブジェクトが有効(Nothing以外)か判断
            If Not objCOM Is Nothing Then
                ' COMオブジェクトであるか判断(念のため)
                If InteropServices.Marshal.IsComObject(objCOM) Then
                    ' 参照カウントを0になるまで減算
                    Dim CNT As Integer
                    Do
                        CNT = InteropServices.Marshal.ReleaseComObject(objCOM)
                    Loop Until CNT <= 0
                End If
            End If
        Catch
            ' ここでのエラーは無視
        End Try
        ' 参照を解除する
        objCOM = Nothing
    End Sub

End Class
                                                            