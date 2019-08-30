Imports System
Imports System.IO

Public Class frmMain

    Private Sub ListBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'コピーを許可するようにドラッグ元に通知する
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragDrop

        ListBox1.Items.AddRange(e.Data.GetData(DataFormats.FileDrop))

        ToolStripProgressBar1.Maximum = ListBox1.Items.Count

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Application.Exit()

    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click

        Dim i As Integer
        Dim fNum As Integer = ListBox1.Items.Count
        
        For i = 0 To fNum - 1

            Application.DoEvents()

            Dim imgFile As String = ListBox1.Items.Item(i)
            Dim outFile As String = IO.Path.ChangeExtension(imgFile, ".txt")
            Dim txt As IO.StreamWriter
            Dim img As New System.Drawing.Bitmap(imgFile)
            Dim item As System.Drawing.Imaging.PropertyItem

            'Exifデータ書き込み用テキストファイルを作成　ファイルがすでにあったら上書きなのでモードは上書きモード「False」

            txt = New IO.StreamWriter(outFile, False, System.Text.Encoding.Default)
            txt.Close()

            For Each item In img.PropertyItems
                'データの型を判断
                If item.Type = 2 Then

                    If item.Id = 306 Then

                        'ASCII文字の場合は、文字列に変換する
                        Dim val As String = System.Text.Encoding.ASCII.GetString(item.Value)
                        val = val.Trim(New Char() {ControlChars.NullChar})

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.WriteLine("撮影日" & "," & item.Id & "," & item.Type & "," & val)
                        txt.Close()


                    End If

                    'ElseIf item.Type = 3 Then

                    '    If item.Id = 41990 Then

                    '        Dim val As Integer = BitConverter.ToInt16(item.Value, 0)

                    '        Select val

                    '            Case 0

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.WriteLine("シーン撮影タイプ" & "," & item.Id & "," & item.Type & "," & "標準")
                    '                txt.Close()

                    '            Case 1

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.WriteLine("シーン撮影タイプ" & "," & item.Id & "," & item.Type & "," & "風景")
                    '                txt.Close()

                    '            Case 2

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.WriteLine("シーン撮影タイプ" & "," & item.Id & "," & item.Type & "," & "人物")
                    '                txt.Close()

                    '            Case 3

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.WriteLine("シーン撮影タイプ" & "," & item.Id & "," & item.Type & "," & "夜景")
                    '                txt.Close()

                    '        End Select

                    '    End If

                ElseIf item.Type = 5 Then


                    If item.Id = 2 Then '緯度

                        Dim LatD As Single = BytetoInt(item.Value, 0)
                        Dim LatM As Single = BytetoInt(item.Value, 8)
                        Dim LatS As Single = BytetoInt(item.Value, 16)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        If rbDeg.Checked Then

                            Dim lat As Double = LatD + LatM / 60 + LatS / 3600

                            txt.WriteLine("緯度" & "," & item.Id & "," & item.Type & "," & lat)

                        ElseIf rbDms.Checked Then

                            txt.WriteLine("緯度" & "," & item.Id & "," & item.Type & "," & LatD & "°" & LatM & "′" & LatS & "″")

                        End If

                        txt.Close()

                    ElseIf item.Id = 4 Then '経度

                        Dim LonD As Single = BytetoInt(item.Value, 0)
                        Dim LonM As Single = BytetoInt(item.Value, 8)
                        Dim LonS As Single = BytetoInt(item.Value, 16)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        If rbDeg.Checked Then

                            Dim lon As Double = LonD + LonM / 60 + LonS / 3600

                            txt.WriteLine("経度" & "," & item.Id & "," & item.Type & "," & lon)

                        ElseIf rbDms.Checked Then

                            txt.WriteLine("経度" & "," & item.Id & "," & item.Type & "," & LonD & "°" & LonM & "′" & LonS & "″")

                        End If

                        txt.Close()

                    ElseIf item.Id = 6 Then   '標高

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.WriteLine("標高" & "," & item.Id & "," & item.Type & "," & val)
                        txt.Close()

                    ElseIf item.Id = 15 Then    '真北角

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.WriteLine("真北角" & "," & item.Id & "," & item.Type & "," & val)
                        txt.Close()

                    ElseIf item.Id = 17 Then  '磁北角

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.WriteLine("磁北角" & "," & item.Id & "," & item.Type & "," & val)
                        txt.Close()

                    End If

                    End If

            Next item

            img.Dispose()

            ToolStripProgressBar1.Value = i

        Next i

        ToolStripProgressBar1.Value = 0

        MsgBox("Exif情報が書き込まれました")

    End Sub

    Private Sub btnRun1file_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun1file.Click

        Dim i As Integer
        Dim fNum As Integer = ListBox1.Items.Count
        Dim outFile As String = IO.Path.GetDirectoryName(ListBox1.Items.Item(0)) & "\All_EXIF.txt"
        Dim txt As IO.StreamWriter

        txt = New IO.StreamWriter(outFile, False, System.Text.Encoding.Default)
        txt.WriteLine("ファイル名,撮影日,緯度,経度,標高,真北角,磁北角")
        txt.Close()

        For i = 0 To fNum - 1

            Application.DoEvents()

            Dim imgFile As String = ListBox1.Items.Item(i)
            Dim img As New System.Drawing.Bitmap(imgFile)
            Dim item As System.Drawing.Imaging.PropertyItem

            'MsgBox(outFile)

            ''Exifデータ書き込み用テキストファイルを作成　

            txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
            txt.Write(IO.Path.GetFileName(imgFile) & ",")
            txt.Close()

            For Each item In img.PropertyItems
                'データの型を判断
                If item.Type = 2 Then

                    If item.Id = 306 Then

                        'ASCII文字の場合は、文字列に変換する
                        Dim val As String = System.Text.Encoding.ASCII.GetString(item.Value)
                        val = val.Trim(New Char() {ControlChars.NullChar})

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.Write(val & ",")
                        txt.Close()

                    End If

                    'ElseIf item.Type = 3 Then

                    '    If item.Id = 41990 Then

                    '        Dim val As Integer = BitConverter.ToInt16(item.Value, 0)

                    '        Select Case val

                    '            Case 0

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.Write("標準,")
                    '                txt.Close()

                    '            Case 1

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.Write("風景,")
                    '                txt.Close()

                    '            Case 2

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.Write("人物,")
                    '                txt.Close()

                    '            Case 3

                    '                txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                    '                txt.Write("夜景,")
                    '                txt.Close()

                    '        End Select

                    '    End If

                ElseIf item.Type = 5 Then


                    If item.Id = 2 Then '緯度

                        Dim LatD As Single = BytetoInt(item.Value, 0)
                        Dim LatM As Single = BytetoInt(item.Value, 8)
                        Dim LatS As Single = BytetoInt(item.Value, 16)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        If rbDeg.Checked Then

                            Dim lat As Double = LatD + LatM / 60 + LatS / 3600

                            txt.Write(lat & ",")

                        ElseIf rbDms.Checked Then

                            txt.Write(LatD & "°" & LatM & "′" & LatS & "″" & ",")

                        End If

                        txt.Close()

                    ElseIf item.Id = 4 Then '経度

                        Dim LonD As Single = BytetoInt(item.Value, 0)
                        Dim LonM As Single = BytetoInt(item.Value, 8)
                        Dim LonS As Single = BytetoInt(item.Value, 16)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        If rbDeg.Checked Then

                            Dim lon As Double = LonD + LonM / 60 + LonS / 3600

                            txt.Write(lon & ",")

                        ElseIf rbDms.Checked Then

                            txt.Write(LonD & "°" & LonM & "′" & LonS & "″" & ",")

                        End If

                        txt.Close()

                    ElseIf item.Id = 6 Then   '標高

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.Write(val & ",")
                        txt.Close()

                    ElseIf item.Id = 15 Then    '真北角

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.Write(val & ",")
                        txt.Close()

                    ElseIf item.Id = 17 Then  '磁北角

                        'MsgBox(item.Id)

                        Dim val As Single
                        val = BytetoInt(item.Value, 0)

                        'ファイルにカキコ
                        txt = New IO.StreamWriter(outFile, True, System.Text.Encoding.Default)
                        txt.WriteLine(val)
                        txt.Close()

                    End If

                End If

            Next item

            img.Dispose()

            ToolStripProgressBar1.Value = i

        Next i

        ToolStripProgressBar1.Value = 0

        MsgBox("Exif情報が書き込まれました")

    End Sub

    Private Function BytetoInt(ByVal val() As Byte, ByVal ofs As Integer) As Single
        Dim aaa As Single = BitConverter.ToInt32(val, ofs)
        Dim bbb As Single = BitConverter.ToInt32(val, ofs + 4)
        Return aaa / bbb
        'Dim lb() As Byte = {val(0), val(1), val(2), val(3)}
        'Return BitConverter.ToInt32(lb, 0)
    End Function

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        