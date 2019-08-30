Public Class Form1

    Dim strPath As String
    Dim frmNotification As Form

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        rbnInclude.Checked = True        ' 「...を含む」ボタンにチェックを入れる
        'cbDirOpt.Checked = True    ' 「サブフォルダも探す」にチェックを入れる



    End Sub


    Private Sub UtilityToolBar1_StopPressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.StopPressed

        Application.Exit()

    End Sub


    Private Sub ImageButton1_Click() Handles ImageButton1.Click

        Dim arrPtrn() As String = txtFind.Text.Split(",")
        Dim numPtrn As Integer = arrPtrn.Length

        ToolStripStatusLabel1.Text = "検索中！"
        PictureBox1.Visible = True

        'MsgBox(strPath)
        strPath = AxDirTreeCtrl1.GetCurrentPath & "\"

        lbRslt.Items.Clear()

        ' エラーのチェック
        If IsError() = True Then

            PictureBox1.Visible = False
            Exit Sub

        End If

        For i = 0 To numPtrn - 1

            Application.DoEvents()

            ' 検索条件のチェック
            If rbnInclude.Checked Then
                arrPtrn(i) = "*" & arrPtrn(i) & "*"
            ElseIf rbnBegin.Checked Then
                arrPtrn(i) = arrPtrn(i) & "*"
            ElseIf rbnEnd.Checked Then
                arrPtrn(i) = "*" & arrPtrn(i)
            End If

            Try

                SearchFiles(strPath, arrPtrn(i))        ' 検索の実行

            Catch ex As Exception

                '    PictureBox1.Visible = False
                '    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End Try

        Next i

        PictureBox1.Visible = False

        If lbRslt.Items.Count = 0 Then

            ToolStripStatusLabel1.Text = "ファイルが1個も見つかりませんでした！"
            frmNotification = NotificationWindow1.Notify("ファイルが1個も" & vbCrLf & "見つかりませんでした！")

        Else

            ToolStripStatusLabel1.Text = lbRslt.Items.Count & "個のファイルが見つかりました！"
            frmNotification = NotificationWindow1.Notify(lbRslt.Items.Count & "個のファイルが" & vbCrLf & "見つかりました！")

        End If

    End Sub

    Private Function IsError() As Boolean
        ' エラーの内容を示す文字列
        Dim strError As String = ""

        ' 検索文字のチェック
        If txtFind.Text = "" Then
            ' 空文字のチェック
            strError &= "検索文字列が入力されていません。" & vbCrLf
        Else
            ' 無効な文字のチェック
            If InStr(txtFind.Text, IO.Path.AltDirectorySeparatorChar) <> 0 Then
                strError &= "検索文字列に「" & IO.Path.AltDirectorySeparatorChar _
                                 & "」は使用できません。" & vbCrLf
            End If
            If InStr(txtFind.Text, IO.Path.DirectorySeparatorChar) <> 0 Then
                strError &= "検索文字列に「" & IO.Path.DirectorySeparatorChar _
                                 & "」は使用できません。" & vbCrLf
            End If
            If InStr(txtFind.Text, IO.Path.VolumeSeparatorChar) <> 0 Then
                strError &= "検索文字列に「" & IO.Path.VolumeSeparatorChar _
                                 & "」は使用できません。" & vbCrLf
            End If
            If InStr(txtFind.Text, IO.Path.PathSeparator) <> 0 Then
                strError &= "検索文字列に「" & IO.Path.PathSeparator _
                                 & "」は使用できません。" & vbCrLf
            End If
            Dim c As Char
            For Each c In IO.Path.GetInvalidPathChars
                If InStr(txtFind.Text, c) <> 0 Then
                    strError &= "検索文字列に「" & c & "」は使用できません。" & vbCrLf
                End If
            Next

        End If

        ' 検索場所のチェック
        If strPath = "" Then
            ' 空文字のチェック
            strError &= "検索場所が入力されていません。" & vbCrLf

        Else
            ' 区切り文字のチェック
            If strPath.EndsWith("\") = False Then

                strPath &= "\"

            End If

            ' フォルダの存在のチェック
            If IO.Directory.Exists(strPath) = False Then

                strError &= "検索場所が見つかりません。" & vbCrLf

                'ElseIf (GetAttr(strPath) And FileAttribute.Hidden) = FileAttribute.Hidden Then
                '     属性のチェック
                '    strError &= "このフォルダにはアクセスできません。" & vbCrLf

            End If

        End If

        ' 値を返す True | False
        If strError <> "" Then
            ' エラーがあるときはメッセージを表示して True を返す
            MessageBox.Show("エラー ：" & vbCrLf & strError, "ERROR", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return True

        Else
            ' エラーがないときは False を返す
            Return False

        End If

    End Function

    Private Sub SearchFiles(ByVal folder As String, ByVal pattern As String)

        ' ファイルを取得してListBoxに追加
        Dim aFiles As String() = IO.Directory.GetFiles(folder, pattern)

        lbRslt.Items.AddRange(aFiles)

        ' サブフォルダも探す時
        If cbDirOpt.Checked Then
            ' folderのサブフォルダを取得する
            Dim aSubfolders As String() = IO.Directory.GetDirectories(folder)
            Dim strSubfolder As String

            ' サブフォルダにあるファイルも調べる
            For Each strSubfolder In aSubfolders
                ' 再帰処理
                Application.DoEvents()

                If (GetAttr(strSubfolder) And FileAttribute.Hidden) <> FileAttribute.Hidden Then
                    SearchFiles(strSubfolder, pattern)
                End If

            Next

        End If

    End Sub

    Private Sub lbRslt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRslt.DoubleClick

        For i = 0 To lbRslt.Items.Count - 1

            lbRslt.SetSelected(i, True)

        Next i

    End Sub

    Private Sub UtilityToolBar1_SavePressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.SavePressed

        Dim path As String
        Dim txt As IO.StreamWriter

        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            path = SaveFileDialog1.FileName

            If IO.File.Exists(path) = True Then

                IO.File.Delete(path)

            End If

            For i = 0 To lbRslt.Items.Count - 1

                txt = New IO.StreamWriter(path, True, System.Text.Encoding.Default)

                txt.WriteLine(lbRslt.Items(i))

                txt.Close()

            Next i

            ToolStripStatusLabel1.Text = "検索結果が" & path & "に書き込まれました！"
            frmNotification = NotificationWindow1.Notify("検索結果が" & vbCrLf & path & vbCrLf & "に書き込まれました！")

        Else

            Exit Sub

        End If

    End Sub

    Private Sub UtilityToolBar1_DeletePressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.DeletePressed

        If lbRslt.SelectedItems.Count > 0 Then

            If MessageBox.Show("削除したファイルは元に戻りません！" & vbCrLf & "本当に削除しますか？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                For i = 0 To lbRslt.Items.Count - 1

                    Try

                        IO.File.Delete(lbRslt.Items(i))

                    Catch ex As Exception

                        frmNotification = NotificationWindow1.Notify(ex.Message)

                    End Try

                Next i

                frmNotification = NotificationWindow1.Notify("選択したファイルを" & vbCrLf & "削除しました！")

            End If

        Else

            frmNotification = NotificationWindow1.Notify("ファイルが" & vbCrLf & "選択されていません！")

        End If

    End Sub

End Class
