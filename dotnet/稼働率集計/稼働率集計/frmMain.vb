Public Class frmMain

    'Public MDB As String = "X:\管理\稼働率\稼働率集計.mdb"
    Public MDB As String = "E:\#work\#Visual Studio\Projects\稼働率集計\稼働率集計\稼働率集計.mdb"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim db As New AccessMdb
        Dim tb1 As DataTable
        Dim tb2 As DataTable

        Try
            '従業員テーブル読み込んで従業員コンボに格納
            db.Connect(MDB, -1)
            tb1 = db.ExecuteSql("select 名前 from 従業員")

            cmbName.DataSource = tb1
            cmbName.DisplayMember = "名前"
            cmbName.ValueMember = "名前"

            '物件テーブル読み込んで物件コンボに格納
            tb2 = db.ExecuteSql("select 物件名 from 物件")

            cmbBukken.DataSource = tb2
            cmbBukken.DisplayMember = "物件名"
            cmbBukken.ValueMember = "物件名"

            db.Disconnect()

            cmbName.SelectedIndex = My.Settings.nameIdx
            cmbBukken.SelectedIndex = My.Settings.bukkenIdx
            cmbTime.SelectedIndex = 14

        Catch ex As Exception
            MessageBox.Show("稼働率集計.mdbが見つかりませんでした！" & "ネットワークを確認して下さい！", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try

    End Sub


    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        Dim db As New AccessMdb
        Dim no As Integer = cmbName.SelectedIndex + 1
        Dim year As Integer
        Dim month As Integer
        Dim day As Integer
        Dim today As DateTime = DateTime.Now
        Dim name As String = cmbName.SelectedValue
        Dim bukken As String = cmbBukken.SelectedValue
        Dim kado As Double = cmbTime.Text
        Dim strSQL As String
        Dim val As String

        year = today.Year
        month = today.Month
        day = today.Day

        'MessageBox.Show(today)
        'MessageBox.Show(year)
        'MessageBox.Show(month)

        val = "values(" & no & year & "," & month & "," & day & "," & "'" & today & "'" & "," & "'" & name & "'" & "," & "'" & bukken & "'" & "," & kado & ")"
        'MessageBox.Show(val)

        If MessageBox.Show("名前：" & name & vbCrLf & "物件：" & bukken & vbCrLf & "時間：" & _
                        kado & vbCrLf & "上記の内容で登録します。よろしいですか？", _
                        "確認！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

            strSQL = "insert into 集計(no,年,月,日,日付,名前,物件,時間) " & val
            'strSQL = "insert into 集計(年,月,日付,名前,物件,時間) " & "values('1234567890',9,'2007-03-04 05:06:07')"

            db.Connect(MDB, -1)

            db.BeginTransaction()

            db.ExecuteSql(strSQL)

            db.CommitTransaction()

            db.Disconnect()

            My.Settings.nameIdx = cmbName.SelectedIndex
            My.Settings.bukkenIdx = cmbBukken.SelectedIndex

        Else
            db.Connect(MDB, -1)
            db.Disconnect()

            My.Settings.nameIdx = cmbName.SelectedIndex
            My.Settings.bukkenIdx = cmbBukken.SelectedIndex

            Exit Sub

        End If

        MessageBox.Show("登録しました！" & vbCrLf & "ご利用ありがとうございました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class
