Imports ConvBL__XY

Public Class Form1

    Dim ORgBMP As Bitmap = Nothing

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'リソースに埋め込んでおいた画像データをBitmapオブジェクトに読み込んでおく
        ORgBMP = My.Resources.写真
        cmbSR.SelectedIndex = 0
        cmbStart.SelectedIndex = 0
        cmbSR.SelectedIndex = 0
        cmbCourse.SelectedIndex = 1
        cmbPhotoNum.SelectedIndex = 0
        cmbX.SelectedIndex = 2
        cmbY.SelectedIndex = 3
        cmbZ.SelectedIndex = 4
        cmbOmega.SelectedIndex = 5
        cmbPhi.SelectedIndex = 6
        cmbKapper.SelectedIndex = 7

    End Sub

    Private Sub lbPics_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lbPics.DragDrop
        lbPics.Items.AddRange(e.Data.GetData(DataFormats.FileDrop))
    End Sub

    Private Sub lbPics_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lbPics.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            e.Effect = DragDropEffects.Copy

        End If
    End Sub


    Private Sub btnSet_Click(sender As System.Object, e As System.EventArgs) Handles btnSet.Click

        Dim bmp As Bitmap

        Try

            Dim kei As Integer

            Select Case cmbSR.SelectedIndex

                Case 0
                    kei = 1
                Case 1
                    kei = 2
                Case 2
                    kei = 3
                Case 3
                    kei = 4
                Case 4
                    kei = 5
                Case 5
                    kei = 6
                Case 6
                    kei = 7
                Case 7
                    kei = 8
                Case 8
                    kei = 9
                Case 9
                    kei = 10
                Case 10
                    kei = 11
                Case 11
                    kei = 12
                Case 12
                    kei = 13
                Case 13
                    kei = 14
                Case 14
                    kei = 15
                Case 15
                    kei = 16
                Case 16
                    kei = 17
                Case 17
                    kei = 18
                Case 18
                    kei = 19

            End Select

            For i As Integer = 0 To lbPics.Items.Count - 1

                '埋め込まれたリソースの画像ファイルからPropertyItemを取得

                Dim pis() As System.Drawing.Imaging.PropertyItem = ORgBMP.PropertyItems
                Dim pils() As Integer = ORgBMP.PropertyIdList
                Dim piLatRef As System.Drawing.Imaging.PropertyItem = Nothing
                Dim piLonRef As System.Drawing.Imaging.PropertyItem = Nothing
                Dim piLat As System.Drawing.Imaging.PropertyItem = Nothing
                Dim piLon As System.Drawing.Imaging.PropertyItem = Nothing

                '指定されたファイルの拡張子を読み込む
                Dim savemode As Integer = 2
                Dim Filename As String = lbPics.Items.Item(i)
                Dim outFile As String = IO.Path.GetDirectoryName(Filename) & "\exif\" & IO.Path.GetFileName(Filename)

                If IO.Directory.Exists(IO.Path.GetDirectoryName(Filename) & "\exif") = False Then
                    IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(Filename) & "\exif")
                End If

                '指定されたファイルを読み込む
                bmp = New Bitmap(Filename)
                Dim idx As Integer = 0
                Dim sPI As System.Drawing.Imaging.PropertyItem = Nothing
                'いったん全てのGPS関連情報を対象のBitmapに書き込む
                For intloop As Integer = 0 To 26
                    idx = Array.IndexOf(pils, intloop)
                    If idx > 0 Then
                        sPI = ORgBMP.PropertyItems(idx)
                        bmp.SetPropertyItem(sPI)
                    End If
                Next

                'LatitudeRef取得（北緯か南緯か）
                idx = Array.IndexOf(pils, 1)
                piLatRef = ORgBMP.PropertyItems(idx)
                'LogitudeRef取得（東経か、西経か）
                idx = Array.IndexOf(pils, 3)
                piLonRef = ORgBMP.PropertyItems(idx)
                'Latitude取得（緯度）
                idx = Array.IndexOf(pils, 2)
                piLat = ORgBMP.PropertyItems(idx)
                'Logitude取得（経度）
                idx = Array.IndexOf(pils, 4)
                piLon = ORgBMP.PropertyItems(idx)

                '設定値を書き込む(PropertyItemの値を書き換える)

                piLatRef.Value(0) = Asc("N")
                'piLatRef.Value(0) = Asc("S")
                piLonRef.Value(0) = Asc("E")
                'piLonRef.Value(0) = Asc("W")

                '度（degree）の値を度、分、秒に分解
                Dim DF As Double = Fix(26.350603304191843)
                Dim M As Double = (26.350603304191843 - DF) * 60
                Dim MF As Integer = Fix(M)
                Dim S As Double = (M - MF) * 60

                Dim latDo As Integer = DF
                Dim latFun As Integer = MF
                Dim latByou As Double = S

                DF = Fix(127.7452690154314)
                M = (127.7452690154314 - DF) * 60
                MF = Fix(M)
                S = (M - MF) * 60

                Dim lonDo As Integer = DF
                Dim lonFun As Integer = MF
                Dim lonByou As Double = S

                Dim DataBits() As Byte = Nothing

                '--------------Latitude書き込み--------------
                'BitConverterで数値をByte列に変換して４バイト書き込み
                DataBits = BitConverter.GetBytes(latDo)    '度
                piLat.Value(0) = DataBits(0)
                piLat.Value(1) = DataBits(1)
                piLat.Value(2) = DataBits(2)
                piLat.Value(3) = DataBits(3)
                'かけ率は１なので、１を書き込み
                piLat.Value(4) = 1
                piLat.Value(5) = 0
                piLat.Value(6) = 0
                piLat.Value(7) = 0
                'BitConverterで数値をByte列に変換して４バイト書き込み
                DataBits = BitConverter.GetBytes(latFun)    '分
                piLat.Value(8) = DataBits(0)
                piLat.Value(9) = DataBits(1)
                piLat.Value(10) = DataBits(2)
                piLat.Value(11) = DataBits(3)
                'かけ率は１なので、１を書き込み
                piLat.Value(12) = 1
                piLat.Value(13) = 0
                piLat.Value(14) = 0
                piLat.Value(15) = 0
                'BitConverterで数値をByte列に変換して４バイト書き込み（値は1000倍して書き込み）
                DataBits = BitConverter.GetBytes(CInt(latByou * 100000)) '秒
                piLat.Value(16) = DataBits(0)
                piLat.Value(17) = DataBits(1)
                piLat.Value(18) = DataBits(2)
                piLat.Value(19) = DataBits(3)
                'かけ率は1000なので、1000をバイト例つに変換して書き込み
                DataBits = BitConverter.GetBytes(100000)
                piLat.Value(20) = DataBits(0)
                piLat.Value(21) = DataBits(1)
                piLat.Value(22) = DataBits(2)
                piLat.Value(23) = DataBits(3)


                '--------------Longitude書き込み--------------
                'BitConverterで数値をByte列に変換して４バイト書き込み
                DataBits = BitConverter.GetBytes(lonDo)    '度
                piLon.Value(0) = DataBits(0)
                piLon.Value(1) = DataBits(1)
                piLon.Value(2) = DataBits(2)
                piLon.Value(3) = DataBits(3)
                'かけ率は１なので、１を書き込み
                piLon.Value(4) = 1
                piLon.Value(5) = 0
                piLon.Value(6) = 0
                piLon.Value(7) = 0
                'BitConverterで数値をByte列に変換して４バイト書き込み
                DataBits = BitConverter.GetBytes(lonFun)    '分
                piLon.Value(8) = DataBits(0)
                piLon.Value(9) = DataBits(1)
                piLon.Value(10) = DataBits(2)
                piLon.Value(11) = DataBits(3)
                'かけ率は１なので、１を書き込み
                piLon.Value(12) = 1
                piLon.Value(13) = 0
                piLon.Value(14) = 0
                piLon.Value(15) = 0
                'BitConverterで数値をByte列に変換して４バイト書き込み（値は1000倍して書き込み）
                DataBits = BitConverter.GetBytes(CInt(lonByou * 100000)) '秒
                piLon.Value(16) = DataBits(0)
                piLon.Value(17) = DataBits(1)
                piLon.Value(18) = DataBits(2)
                piLon.Value(19) = DataBits(3)
                'かけ率は1000なので、1000をバイト例つに変換して書き込み
                DataBits = BitConverter.GetBytes(100000)
                piLon.Value(20) = DataBits(0)
                piLon.Value(21) = DataBits(1)
                piLon.Value(22) = DataBits(2)
                piLon.Value(23) = DataBits(3)


                '設定されたPropertyItemを保存する
                bmp.SetPropertyItem(piLatRef)
                bmp.SetPropertyItem(piLonRef)
                bmp.SetPropertyItem(piLat)
                bmp.SetPropertyItem(piLon)

                '保存する
                bmp.Save(outFile)
                bmp.Dispose()

            Next

            MessageBox.Show("owari deth!", "Done!")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "err deth!")
        End Try

    End Sub


    Private Sub btnSelEo_Click(sender As System.Object, e As System.EventArgs) Handles btnSelEo.Click

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            tbEo.Text = OpenFileDialog1.SafeFileName
        End If

    End Sub
End Class
