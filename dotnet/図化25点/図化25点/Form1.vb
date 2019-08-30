Imports System.IO
Imports Microsoft.office.Interop
Imports System.Runtime

Public Class Form1
    Private Sub btnVec_Click(sender As Object, e As EventArgs) Handles btnVec.Click
        If OpenFileDialog_vec.ShowDialog() = DialogResult.OK Then
            tbVec.Text = OpenFileDialog_vec.FileName
        End If
    End Sub

    Private Sub btnTmp_Click(sender As Object, e As EventArgs) Handles btnTmp.Click
        If OpenFileDialog_tmp.ShowDialog() = DialogResult.OK Then
            tbTmp.Text = OpenFileDialog_tmp.FileName
        End If
    End Sub

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If tbVec.Text = "" Then
            MessageBox.Show("vecが指定されていない")
            Exit Sub
        ElseIf tbTmp.Text = "" Then
            MessageBox.Show("テンプレートが指定されていない")
            Exit Sub
        End If

        Dim vec As String = tbVec.Text
        Dim tmp As String = tbTmp.Text
        Dim reader As New StreamReader(vec)
        Dim app As Excel.Application = Nothing
        Dim book As Excel.Workbook = Nothing
        Dim sheets As Excel.Sheets = Nothing
        Dim sheet As Excel.Worksheet = Nothing
        Dim pageCnt As Integer = 0
        Dim line As String = ""
        Dim outPath As String = IO.Path.GetDirectoryName(tbVec.Text)
        Dim zukakuCell As Excel.Range
        Dim x1Cell As Excel.Range
        Dim y1Cell As Excel.Range
        Dim X2Cell As Excel.Range
        Dim Y2Cell As Excel.Range
        Dim X3Cell As Excel.Range
        Dim Y3Cell As Excel.Range
        Dim Z1Cell As Excel.Range
        Dim Z2Cell As Excel.Range
        Dim xlRange As Excel.Range
        Dim xlPasteRange As Excel.Range
        Dim printRange As Excel.Range

        Try
            app = CreateObject("Excel.Application")
            app.Visible = False
            book = app.Workbooks.Open(tmp)     'ファイルを開く
            sheets = book.Worksheets
            sheet = sheets(1)
            sheet.Activate()
            xlRange = sheet.Cells.Range("A1:BO40")

            Dim linStrs As String()

            While reader.Peek() > -1
                line = reader.ReadLine
                linStrs = line.Split(","c)
                'MessageBox.Show(linStrs(0))
                If linStrs.Length = 1 Then
                    pageCnt += 1
                End If
                Array.Clear(linStrs, 0, linStrs.Length)
            End While

            reader.Close()
            'MessageBox.Show(pageCnt)
            ProgressBar1.Maximum = pageCnt

            Dim pageNo As Integer = 41
            xlRange = sheet.Cells.Range("A1:BO40")
            Dim strA1 As String = ""

            For i As Integer = 1 To pageCnt - 1
                xlPasteRange = sheet.Cells(pageNo, 1)
                xlRange.Copy(xlPasteRange)
                strA1 = xlPasteRange.Address
                sheet.HPageBreaks.Add(sheet.Range(strA1))
                pageNo = pageNo + 40
            Next

            pageNo = pageNo - 1
            Dim strPrintArea As String
            printRange = sheet.Cells(pageNo, 68)
            'strPrintArea = """" & "$A$1:" & printRange.Address & """"
            strPrintArea = "$A$1:" & printRange.Address
            'MessageBox.Show(strPrintArea)
            TextBox1.Text = strPrintArea
            sheet.PageSetup.PrintArea = strPrintArea
            'sheet.PageSetup.PrintArea = "$A$1:$BP$2160"

            Dim strZukaku As String = ""
            Dim x1 As Double = 0
            Dim y1 As Double = 0
            Dim X2 As Double = 0
            Dim Y2 As Double = 0
            Dim Z1 As Double = 0
            Dim Z2 As Double = 0

            Dim gyoCnt As Integer = 1
            Dim zukakuCnt As Integer = 6
            Dim zahyouCnt As Integer = 12
            Dim pntCnt As Integer = 0

            Dim reader2 As New StreamReader(vec)


            While reader2.Peek() > -1
                line = reader2.ReadLine
                linStrs = line.Split(","c)
                'MessageBox.Show(linStrs(0))

                zukakuCell = sheet.Cells(zukakuCnt, 20)
                x1Cell = sheet.Cells(zahyouCnt + pntCnt, 3)
                y1Cell = sheet.Cells(zahyouCnt + pntCnt, 10)
                X2Cell = sheet.Cells(zahyouCnt + pntCnt, 17)
                Y2Cell = sheet.Cells(zahyouCnt + pntCnt, 24)
                X3Cell = sheet.Cells(zahyouCnt + pntCnt, 37)
                Y3Cell = sheet.Cells(zahyouCnt + pntCnt, 44)
                Z1Cell = sheet.Cells(zahyouCnt + pntCnt, 51)
                Z2Cell = sheet.Cells(zahyouCnt + pntCnt, 58)

                If linStrs.Length = 1 Then

                    ProgressBar1.Increment(1)

                    strZukaku = linStrs(0)
                    zukakuCell.Value = strZukaku
                    pntCnt = 0
                    zukakuCnt += 40

                    If gyoCnt > 1 Then
                        zahyouCnt += 40
                    End If

                Else

                    x1 = linStrs(0)
                    y1 = linStrs(1)
                    X2 = linStrs(3)
                    Y2 = linStrs(4)
                    Z1 = linStrs(2)
                    Z2 = linStrs(5)

                    x1Cell.Value = x1
                    y1Cell.Value = y1
                    X2Cell.Value = X2
                    Y2Cell.Value = Y2
                    X3Cell.Value = X2
                    Y3Cell.Value = Y2
                    Z1Cell.Value = Z1
                    Z2Cell.Value = Z2

                    pntCnt += 1

                End If

                gyoCnt += 1
                Array.Clear(linStrs, 0, linStrs.Length)

            End While

            reader2.Close()

            Dim newFile As String = outPath & "\out.xlsx"
            app.DisplayAlerts = False
            book.SaveAs(newFile)
            'book.Save()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ' オブジェクトを解放します。
            reader.Close()
            book.Close()

            sheets = Nothing
            sheet = Nothing
            book = Nothing
            'app = Nothing
            xlRange = Nothing
            xlPasteRange = Nothing
            printRange = Nothing
            zukakuCell = Nothing
            x1Cell = Nothing
            y1Cell = Nothing
            X2Cell = Nothing
            Y2Cell = Nothing
            X3Cell = Nothing
            Y3Cell = Nothing
            Z1Cell = Nothing
            Z2Cell = Nothing

            GP_ReleaseComObject(xlRange)
            GP_ReleaseComObject(xlPasteRange)
            GP_ReleaseComObject(printRange)
            GP_ReleaseComObject(zukakuCell)
            GP_ReleaseComObject(x1Cell)
            GP_ReleaseComObject(y1Cell)
            GP_ReleaseComObject(X2Cell)
            GP_ReleaseComObject(Y2Cell)
            GP_ReleaseComObject(X3Cell)
            GP_ReleaseComObject(Y3Cell)
            GP_ReleaseComObject(Z1Cell)
            GP_ReleaseComObject(Z2Cell)

            app.DisplayAlerts = True
            app.Quit()
            GP_ReleaseComObject(sheets)
            GP_ReleaseComObject(sheet)
            GP_ReleaseComObject(book)
            GP_ReleaseComObject(app)
            GC.Collect()

        End Try

        MessageBox.Show("おわり～")

    End Sub


    Private Sub GP_ReleaseComObject(ByRef objCOM As Object)
        '-------------------------------------------------------------------------------------------
        ' 明示的にCOMオブジェクトへの参照を解放する
        Try
            ' ランタイム呼び出し可能ラッパーの参照カウントをデクリメント
            If ((objCOM IsNot Nothing) AndAlso (InteropServices.Marshal.IsComObject(objCOM))) Then
                InteropServices.Marshal.FinalReleaseComObject(objCOM)
            End If
        Finally
            ' 参照を解除する
            objCOM = Nothing
        End Try
    End Sub
End Class
