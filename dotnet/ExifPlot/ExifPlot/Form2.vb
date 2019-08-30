﻿Public Class frmMain


    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        GisRelease()

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GC.Collect()

    End Sub

    Private Sub ListBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragEnter

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            e.Effect = DragDropEffects.Copy

        End If

    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragDrop

        ListBox1.Items.AddRange(e.Data.GetData(DataFormats.FileDrop))

        ToolStripProgressBar1.Maximum = ListBox1.Items.Count
        ToolStripStatusLabel1.Text = "0/" & ListBox1.Items.Count

    End Sub


    Private Sub btnPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlot.Click

        Dim imgFile As String
        Dim fName As String
        Dim fNum As Integer = ListBox1.Items.Count
        Dim lon, lat As Double
        Dim x, y, z As Double
        Dim ang As Double
        Dim flg As Integer = 0

        For i = 0 To fNum - 1

            Application.DoEvents()

            ToolStripStatusLabel1.Text = i + 1 & "/" & ListBox1.Items.Count
            ToolStripProgressBar1.Value = i + 1

            imgFile = ListBox1.Items.Item(i)
            fName = IO.Path.GetFileName(imgFile)

            Try

                Dim img As New System.Drawing.Bitmap(imgFile)
                Dim idlist As Integer() = img.PropertyIdList
                Dim indexLat As Integer = Array.IndexOf(idlist, 2)
                Dim indexLon As Integer = Array.IndexOf(idlist, 4)
                Dim indexTN As Integer = Array.IndexOf(idlist, 15)
                Dim itemLat As System.Drawing.Imaging.PropertyItem = img.PropertyItems(indexLat)
                Dim itemLon As System.Drawing.Imaging.PropertyItem = img.PropertyItems(indexLon)
                Dim itemTN As System.Drawing.Imaging.PropertyItem = img.PropertyItems(indexTN)

                Dim LatD As Double = BytetoInt(itemLat.Value, 0)
                Dim LatM As Double = BytetoInt(itemLat.Value, 8)
                Dim LatS As Double = BytetoInt(itemLat.Value, 16)

                Dim LonD As Double = BytetoInt(itemLon.Value, 0)
                Dim LonM As Double = BytetoInt(itemLon.Value, 8)
                Dim LonS As Double = BytetoInt(itemLon.Value, 16)

                lat = LatD + LatM / 60 + LatS / 3600
                lon = LonD + LonM / 60 + LonS / 3600
                ang = BytetoInt(itemTN.Value, 0)

            Catch ex As Exception

                'MsgBox("画像にExif情報が見つかりません！", MsgBoxStyle.Critical)
                flg = flg + 1

            End Try

            If GisGetAxesType() = SIS_AXES_SPHERICAL Then

                GisCreatePoint(lon, lat, 0, "", 0, 1)

                GisSetStr(SIS_OT_CURITEM, 0, "_URI$", imgFile)
                GisSetStr(SIS_OT_CURITEM, 0, "name$", fName)
                GisSetFlt(SIS_OT_CURITEM, 0, "_angleDeg#", ang)

            Else

                Dim strPos As String = GisGetAxesFromLatLonHgt(lat, lon, 0, "*JGD2000")

                GisSplitPos(x, y, z, strPos)

                GisCreatePoint(x, y, 0, "", 0, 1)

                GisSetStr(SIS_OT_CURITEM, 0, "_URI$", imgFile)
                GisSetStr(SIS_OT_CURITEM, 0, "name$", fName)
                GisSetFlt(SIS_OT_CURITEM, 0, "_angleDeg#", ang)

            End If




        Next

        If flg > 0 Then

            MsgBox("Exif情報が足りない画像が" & flg & "ファイルありました！" & vbCrLf & "確認して下さい！", MsgBoxStyle.Critical)

        End If

        Me.Close()

    End Sub

    'Private Sub btnPlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlot.Click

    '    Dim fNum As Integer = ListBox1.Items.Count
    '    Dim lon, lat As Double
    '    Dim x, y, z As Double

    '    For i = 0 To fNum - 1

    '        Application.DoEvents()

    '        ToolStripStatusLabel1.Text = i + 1 & "/" & ListBox1.Items.Count
    '        ToolStripProgressBar1.Value = i + 1

    '        Dim imgFile As String = ListBox1.Items.Item(i)
    '        Dim img As New System.Drawing.Bitmap(imgFile)
    '        Dim item As System.Drawing.Imaging.PropertyItem

    '        For Each item In img.PropertyItems

    '            If item.Type = 5 Then

    '                If item.Id = 2 Then '緯度

    '                    Dim LatD As Single = BytetoInt(item.Value, 0)
    '                    Dim LatM As Single = BytetoInt(item.Value, 8)
    '                    Dim LatS As Single = BytetoInt(item.Value, 16)

    '                    lat = LatD + LatM / 60 + LatS / 3600

    '                ElseIf item.Id = 4 Then '経度

    '                    Dim LonD As Single = BytetoInt(item.Value, 0)
    '                    Dim LonM As Single = BytetoInt(item.Value, 8)
    '                    Dim LonS As Single = BytetoInt(item.Value, 16)

    '                    lon = LonD + LonM / 60 + LonS / 3600

    '                End If

    '            End If


    '        Next

    '        If GisGetAxesType() = SIS_AXES_SPHERICAL Then

    '            GisCreatePoint(lon, lat, 0, "", 0, 1)

    '            GisSetStr(SIS_OT_CURITEM, 0, "_URI$", imgFile)

    '        Else

    '            Dim strPos As String = GisGetAxesFromLatLonHgt(lat, lon, 0, "*JGD2000")

    '            GisSplitPos(x, y, z, strPos)

    '            GisCreatePoint(x, y, 0, "", 0, 1)

    '            GisSetStr(SIS_OT_CURITEM, 0, "_URI$", imgFile)


    '        End If

    '    Next

    '    Me.Close()

    'End Sub

    Private Function BytetoInt(ByVal val() As Byte, ByVal ofs As Integer) As Single
        Dim aaa As Single = BitConverter.ToInt32(val, ofs)
        Dim bbb As Single = BitConverter.ToInt32(val, ofs + 4)
        Return aaa / bbb
        'Dim lb() As Byte = {val(0), val(1), val(2), val(3)}
        'Return BitConverter.ToInt32(lb, 0)
    End Function

End Class                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  