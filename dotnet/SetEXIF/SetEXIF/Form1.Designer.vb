<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbPics = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSet = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelEo = New System.Windows.Forms.Button()
        Me.tbEo = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbSR = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbStart = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbKapper = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbPhi = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbOmega = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbZ = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbY = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbX = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbPhotoNum = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCourse = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCourseRec = New System.Windows.Forms.DataGridView()
        Me.course = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.photo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.X = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Y = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Z = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.omega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kapper = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvCourseRec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbPics
        '
        Me.lbPics.AllowDrop = True
        Me.lbPics.FormattingEnabled = True
        Me.lbPics.HorizontalScrollbar = True
        Me.lbPics.ItemHeight = 12
        Me.lbPics.Location = New System.Drawing.Point(6, 18)
        Me.lbPics.Name = "lbPics"
        Me.lbPics.Size = New System.Drawing.Size(188, 220)
        Me.lbPics.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbPics)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 242)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "イメージファイルをドロップ"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(137, 367)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(75, 23)
        Me.btnSet.TabIndex = 2
        Me.btnSet.Text = "SET"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelEo)
        Me.GroupBox2.Controls.Add(Me.tbEo)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 260)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 44)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "EOファイルを指定"
        '
        'btnSelEo
        '
        Me.btnSelEo.Location = New System.Drawing.Point(170, 16)
        Me.btnSelEo.Name = "btnSelEo"
        Me.btnSelEo.Size = New System.Drawing.Size(24, 23)
        Me.btnSelEo.TabIndex = 1
        Me.btnSelEo.Text = "..."
        Me.btnSelEo.UseVisualStyleBackColor = True
        '
        'tbEo
        '
        Me.tbEo.Location = New System.Drawing.Point(6, 18)
        Me.tbEo.Name = "tbEo"
        Me.tbEo.Size = New System.Drawing.Size(158, 19)
        Me.tbEo.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.RestoreDirectory = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbSR)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 310)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 44)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "座標系を指定"
        '
        'cmbSR
        '
        Me.cmbSR.FormattingEnabled = True
        Me.cmbSR.Items.AddRange(New Object() {"平面直角座標系第1系(JGD 2000)", "平面直角座標系第2系(JGD 2000)", "平面直角座標系第3系(JGD 2000)", "平面直角座標系第4系(JGD 2000)", "平面直角座標系第5系(JGD 2000)", "平面直角座標系第6系(JGD 2000)", "平面直角座標系第7系(JGD 2000)", "平面直角座標系第8系(JGD 2000)", "平面直角座標系第9系(JGD 2000)", "平面直角座標系第10系(JGD 2000)", "平面直角座標系第11系(JGD 2000)", "平面直角座標系第12系(JGD 2000)", "平面直角座標系第13系(JGD 2000)", "平面直角座標系第14系(JGD 2000)", "平面直角座標系第15系(JGD 2000)", "平面直角座標系第16系(JGD 2000)", "平面直角座標系第17系(JGD 2000)", "平面直角座標系第18系(JGD 2000)", "平面直角座標系第19系(JGD 2000)"})
        Me.cmbSR.Location = New System.Drawing.Point(6, 18)
        Me.cmbSR.Name = "cmbSR"
        Me.cmbSR.Size = New System.Drawing.Size(188, 20)
        Me.cmbSR.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cmbStart)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.cmbKapper)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cmbPhi)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cmbOmega)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.cmbZ)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.cmbY)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.cmbX)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.cmbPhotoNum)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.cmbCourse)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(218, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(285, 292)
        Me.GroupBox4.TabIndex = 11
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "出力設定"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(225, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 12)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "行目"
        '
        'cmbStart
        '
        Me.cmbStart.FormattingEnabled = True
        Me.cmbStart.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbStart.Location = New System.Drawing.Point(98, 20)
        Me.cmbStart.Name = "cmbStart"
        Me.cmbStart.Size = New System.Drawing.Size(121, 20)
        Me.cmbStart.TabIndex = 27
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(17, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 12)
        Me.Label17.TabIndex = 26
        Me.Label17.Text = "データ開始行："
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(225, 261)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 12)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "カラム目"
        '
        'cmbKapper
        '
        Me.cmbKapper.FormattingEnabled = True
        Me.cmbKapper.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbKapper.Location = New System.Drawing.Point(98, 258)
        Me.cmbKapper.Name = "cmbKapper"
        Me.cmbKapper.Size = New System.Drawing.Size(121, 20)
        Me.cmbKapper.TabIndex = 24
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(225, 231)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 12)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "カラム目"
        '
        'cmbPhi
        '
        Me.cmbPhi.FormattingEnabled = True
        Me.cmbPhi.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbPhi.Location = New System.Drawing.Point(98, 228)
        Me.cmbPhi.Name = "cmbPhi"
        Me.cmbPhi.Size = New System.Drawing.Size(121, 20)
        Me.cmbPhi.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(225, 201)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 12)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "カラム目"
        '
        'cmbOmega
        '
        Me.cmbOmega.FormattingEnabled = True
        Me.cmbOmega.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbOmega.Location = New System.Drawing.Point(98, 198)
        Me.cmbOmega.Name = "cmbOmega"
        Me.cmbOmega.Size = New System.Drawing.Size(121, 20)
        Me.cmbOmega.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(225, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 12)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "カラム目"
        '
        'cmbZ
        '
        Me.cmbZ.FormattingEnabled = True
        Me.cmbZ.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbZ.Location = New System.Drawing.Point(98, 168)
        Me.cmbZ.Name = "cmbZ"
        Me.cmbZ.Size = New System.Drawing.Size(121, 20)
        Me.cmbZ.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(225, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 12)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "カラム目"
        '
        'cmbY
        '
        Me.cmbY.FormattingEnabled = True
        Me.cmbY.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbY.Location = New System.Drawing.Point(98, 138)
        Me.cmbY.Name = "cmbY"
        Me.cmbY.Size = New System.Drawing.Size(121, 20)
        Me.cmbY.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(225, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 12)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "カラム目"
        '
        'cmbX
        '
        Me.cmbX.FormattingEnabled = True
        Me.cmbX.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbX.Location = New System.Drawing.Point(98, 108)
        Me.cmbX.Name = "cmbX"
        Me.cmbX.Size = New System.Drawing.Size(121, 20)
        Me.cmbX.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(225, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 12)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "カラム目"
        '
        'cmbPhotoNum
        '
        Me.cmbPhotoNum.FormattingEnabled = True
        Me.cmbPhotoNum.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbPhotoNum.Location = New System.Drawing.Point(98, 78)
        Me.cmbPhotoNum.Name = "cmbPhotoNum"
        Me.cmbPhotoNum.Size = New System.Drawing.Size(121, 20)
        Me.cmbPhotoNum.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(225, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 12)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "カラム目"
        '
        'cmbCourse
        '
        Me.cmbCourse.FormattingEnabled = True
        Me.cmbCourse.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cmbCourse.Location = New System.Drawing.Point(98, 48)
        Me.cmbCourse.Name = "cmbCourse"
        Me.cmbCourse.Size = New System.Drawing.Size(121, 20)
        Me.cmbCourse.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(69, 261)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 12)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "κ："
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(69, 231)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 12)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "φ："
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "ω："
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(74, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Z："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(74, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Y："
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "X："
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "写真番号："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "コース番号："
        '
        'dgvCourseRec
        '
        Me.dgvCourseRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCourseRec.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.course, Me.photo, Me.X, Me.Y, Me.Z, Me.omega, Me.phi, Me.kapper})
        Me.dgvCourseRec.Location = New System.Drawing.Point(12, 399)
        Me.dgvCourseRec.Name = "dgvCourseRec"
        Me.dgvCourseRec.RowTemplate.Height = 21
        Me.dgvCourseRec.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCourseRec.Size = New System.Drawing.Size(830, 229)
        Me.dgvCourseRec.TabIndex = 12
        '
        'course
        '
        Me.course.HeaderText = "コース"
        Me.course.Name = "course"
        '
        'photo
        '
        Me.photo.HeaderText = "写真番号"
        Me.photo.Name = "photo"
        '
        'X
        '
        Me.X.HeaderText = "X"
        Me.X.Name = "X"
        '
        'Y
        '
        Me.Y.HeaderText = "Y"
        Me.Y.Name = "Y"
        '
        'Z
        '
        Me.Z.HeaderText = "Z"
        Me.Z.Name = "Z"
        '
        'omega
        '
        Me.omega.HeaderText = "オメガ"
        Me.omega.Name = "omega"
        '
        'phi
        '
        Me.phi.HeaderText = "ファイ"
        Me.phi.Name = "phi"
        '
        'kapper
        '
        Me.kapper.HeaderText = "カッパ"
        Me.kapper.Name = "kapper"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 640)
        Me.Controls.Add(Me.dgvCourseRec)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "SetEXIF"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvCourseRec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbPics As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelEo As System.Windows.Forms.Button
    Friend WithEvents tbEo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSR As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbStart As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbKapper As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbPhi As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbOmega As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbZ As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbY As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbX As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbPhotoNum As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbCourse As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCourseRec As System.Windows.Forms.DataGridView
    Friend WithEvents course As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents photo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents X As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Y As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Z As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents omega As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents phi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kapper As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
