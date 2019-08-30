Public Class Form1
    Private sw As Stopwatch

    'マウスポインタの位置を取得する
    'X座標を取得する
    Dim x As Integer = System.Windows.Forms.Cursor.Position.X
    'Y座標を取得する
    Dim y As Integer = System.Windows.Forms.Cursor.Position.Y

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        '2画面分の領域を取得してフォームのサイズを再設定↓
        Dim s As System.Windows.Forms.Screen
        Dim intHeight As Integer = 0
        Dim intWidth As Integer = 0

        ''ディスプレイ情報取得
        For Each s In System.Windows.Forms.Screen.AllScreens
            intWidth = intWidth + s.Bounds.Width
            If intHeight < s.Bounds.Height Then
                intHeight = s.Bounds.Height
            End If
        Next

        ''画面プロパティ再設定
        'Console.WriteLine("高さ:{0} 幅:{1}", intHeight, intWidth)
        ''横位置、縦位置、横幅、高さ
        Me.Bounds = New Rectangle(0, 0, intWidth, intHeight)

        'ここまで↑

        Timer1.Enabled = True
        Timer1.Interval = 10
        sw = New Stopwatch()
        sw.Start()

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        'マウスポインタの位置を取得する
        'X座標を取得する
        Dim x2 As Integer = System.Windows.Forms.Cursor.Position.X
        'Y座標を取得する
        Dim y2 As Integer = System.Windows.Forms.Cursor.Position.Y

        If x <> x2 And y <> y2 Then
            Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If sw.IsRunning Then

            If sw.Elapsed.Minutes >= 1 Then
                Label1.Visible = False
                lblTime.Visible = True
                Label2.Visible = True
                PictureBox1.Visible = False
                PictureBox2.Visible = True

                lblTime.Text = sw.Elapsed.Hours.ToString("00") & ":" & sw.Elapsed.Minutes.ToString("00")
                'lblTime.Text = sw.Elapsed.ToString

            End If
        End If

    End Sub
End Class
