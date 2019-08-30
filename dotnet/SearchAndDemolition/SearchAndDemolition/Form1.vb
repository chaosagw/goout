Public Class Form1

    Dim strPath As String
    Dim frmNotification As Form

    '■ShowDriveNodes
    '■機能：フォルダツリーにドライブを表すルートノードを追加する。
    Private Sub ShowDriveNodes()
        Dim Drive As String
        Dim DriveNode As TreeNode = Nothing

        For Each Drive In IO.Directory.GetLogicalDrives

            Dim LgicDrv As New System.IO.DriveInfo(Drive.Substring(0, 1))

            'DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.Drive, ItemImage.Drive)
            'TreeView1.Nodes.Add(DriveNode)

            Select Case LgicDrv.DriveType
                Case System.IO.DriveType.CDRom
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.DVD, ItemImage.DVD)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.Fixed
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.Drive, ItemImage.Drive)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.Network
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.NW, ItemImage.NW)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.NoRootDirectory
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.NOROOT, ItemImage.NOROOT)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.Ram
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.RAM, ItemImage.RAM)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.Removable
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.USB, ItemImage.USB)
                    TreeView1.Nodes.Add(DriveNode)
                Case System.IO.DriveType.Unknown
                    DriveNode = New TreeNode(Drive.Replace("\", ""), ItemImage.UNKNOWN, ItemImage.UNKNOWN)
                    TreeView1.Nodes.Add(DriveNode)
            End Select


            'Cドライブを表すノードを選択状態にする。
            If Drive.Substring(0, 1) = "C" Then
                TreeView1.SelectedNode = DriveNode
                DriveNode.Collapse() 'このノードを閉じる(選択状態にすると開いてしまうので)
            End If

        Next

    End Sub
    '■AddSubNodes
    '■機能：フォルダツリーの子ノードにサブフォルダを追加する。
    '■引数：ParentNode 対象のノード
    Private Sub AddSubNodes(ByVal ParentNode As TreeNode)
        Try

            Dim Folder As New IO.DirectoryInfo(ParentNode.FullPath & "\")
            Dim oFolder As IO.DirectoryInfo
            Dim Node As TreeNode

            For Each oFolder In Folder.GetDirectories
                Node = New TreeNode(oFolder.Name, ItemImage.ClosedFolder, ItemImage.OpenedFolder)
                ParentNode.Nodes.Add(Node)
            Next

        Catch ex As Exception
            '何もしない
        End Try

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbnInclude.Checked = True        ' 「...を含む」ボタンにチェックを入れる
        ShowDriveNodes()
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        AddSubNodes(e.Node)
        ToolStripStatusLabel1.Text = e.Node.FullPath
        strPath = e.Node.FullPath & "\"
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
        'strPath = "\"

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

        Dim aFiles As String()
        Dim aNames As String()

        ' ファイルを取得してListBoxに追加
        If cbNameOnly.Checked Then
            aFiles = IO.Directory.GetFiles(folder, pattern)
            '配列やコレクションに対して一括で処理をする
            aNames = Array.ConvertAll(aFiles, AddressOf path2fname)
            lbRslt.BeginUpdate()
            lbRslt.Items.AddRange(aNames)
            lbRslt.EndUpdate()
        Else
            aFiles = IO.Directory.GetFiles(folder, pattern)
            lbRslt.BeginUpdate()
            lbRslt.Items.AddRange(aFiles)
            lbRslt.EndUpdate()
        End If

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

    '配列やコレクションに対して一括で処理をする内容
    Private Shared Function path2fname(ByVal strPath As String) As String

        Dim fName As String = IO.Path.GetFileName(strPath)
        Return fName

    End Function

    Private Sub lbRslt_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbRslt.DoubleClick

        For i = 0 To lbRslt.Items.Count - 1

            lbRslt.SetSelected(i, True)

        Next i

    End Sub

    Private Sub UtilityToolBar1_SavePressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.SavePressed

        Me.Text = "検索結果保存中"

        Dim path As String
        Dim txt As IO.StreamWriter


        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            path = SaveFileDialog1.FileName
            PictureBox1.Visible = True

            If IO.File.Exists(path) = True Then

                IO.File.Delete(path)

            End If

            For i = 0 To lbRslt.Items.Count - 1

                txt = New IO.StreamWriter(path, True, System.Text.Encoding.Default)

                txt.WriteLine(lbRslt.Items(i))

                txt.Close()

                Application.DoEvents()

            Next

            Me.Text = "検索結果保存おわり"
            ToolStripStatusLabel1.Text = "検索結果が" & path & "に書き込まれました！"
            frmNotification = NotificationWindow1.Notify("検索結果が" & vbCrLf & path & vbCrLf & "に書き込まれました！")
            PictureBox1.Visible = False

        Else

            Exit Sub

        End If

    End Sub

    Private Sub UtilityToolBar1_DeletePressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.DeletePressed

        Me.Text = "削除中"

        If lbRslt.SelectedItems.Count > 0 Then

            If MessageBox.Show("削除したファイルは元に戻りません！" & vbCrLf & "本当に削除しますか？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                PictureBox1.Visible = True

                For i = 0 To lbRslt.Items.Count - 1

                    Try

                        IO.File.Delete(lbRslt.Items(i))

                    Catch ex As Exception

                        'frmNotification = NotificationWindow1.Notify(ex.Message)
                        MsgBox(ex.Message)

                    End Try

                    Application.DoEvents()

                Next

                Me.Text = "削除おわり"
                frmNotification = NotificationWindow1.Notify("選択したファイルを" & vbCrLf & "削除しました！")
                PictureBox1.Visible = False

            End If

        Else

            frmNotification = NotificationWindow1.Notify("ファイルが" & vbCrLf & "選択されていません！")

        End If

    End Sub

    Private Sub UtilityToolBar1_CopyPressed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilityToolBar1.CopyPressed

        Me.Text = "コピー中"

        Dim NewPath As String

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

            PictureBox1.Visible = True

            For i = 0 To lbRslt.Items.Count - 1

                Try
                    NewPath = FolderBrowserDialog1.SelectedPath & "\" & IO.Path.GetFileName(lbRslt.Items(i))

                    IO.File.Copy(lbRslt.Items(i), NewPath)

                Catch ex As Exception

                    'frmNotification = NotificationWindow1.Notify(ex.Message)
                    MsgBox(ex.Message)

                End Try

                Application.DoEvents()

            Next

            PictureBox1.Visible = False

        Else

            Exit Sub

        End If

        Me.Text = "コピーおわり"
        frmNotification = NotificationWindow1.Notify("ファイルをコピーしました")
        PictureBox1.Visible = False

    End Sub



End Class
