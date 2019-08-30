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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnVec = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbVec = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbTmp = New System.Windows.Forms.TextBox()
        Me.btnTmp = New System.Windows.Forms.Button()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.OpenFileDialog_vec = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog_tmp = New System.Windows.Forms.OpenFileDialog()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnVec
        '
        Me.btnVec.Location = New System.Drawing.Point(6, 21)
        Me.btnVec.Name = "btnVec"
        Me.btnVec.Size = New System.Drawing.Size(75, 23)
        Me.btnVec.TabIndex = 0
        Me.btnVec.Text = "VEC"
        Me.btnVec.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbVec)
        Me.GroupBox1.Controls.Add(Me.btnVec)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 55)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "VECデータを選択"
        '
        'tbVec
        '
        Me.tbVec.Location = New System.Drawing.Point(87, 23)
        Me.tbVec.Name = "tbVec"
        Me.tbVec.Size = New System.Drawing.Size(365, 19)
        Me.tbVec.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.tbTmp)
        Me.GroupBox2.Controls.Add(Me.btnTmp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(458, 59)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "精度管理表テンプレートを選択"
        '
        'tbTmp
        '
        Me.tbTmp.Location = New System.Drawing.Point(87, 20)
        Me.tbTmp.Name = "tbTmp"
        Me.tbTmp.Size = New System.Drawing.Size(365, 19)
        Me.tbTmp.TabIndex = 2
        '
        'btnTmp
        '
        Me.btnTmp.Location = New System.Drawing.Point(6, 18)
        Me.btnTmp.Name = "btnTmp"
        Me.btnTmp.Size = New System.Drawing.Size(75, 23)
        Me.btnTmp.TabIndex = 2
        Me.btnTmp.Text = "テンプレート"
        Me.btnTmp.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(395, 138)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "出力"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'OpenFileDialog_vec
        '
        Me.OpenFileDialog_vec.Filter = "vecファイル(*.vec)|*.vec"
        Me.OpenFileDialog_vec.RestoreDirectory = True
        Me.OpenFileDialog_vec.Title = "vecを選択しなさい"
        '
        'OpenFileDialog_tmp
        '
        Me.OpenFileDialog_tmp.Filter = "Excelファイル(*.xls;*.xlsx)|*.xls;*.xlsx"
        Me.OpenFileDialog_tmp.RestoreDirectory = True
        Me.OpenFileDialog_tmp.Title = "精度管理表のテンプレートを選択しなさい"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 138)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(377, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(163, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 19)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 179)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "25点"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVec As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbVec As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbTmp As TextBox
    Friend WithEvents btnTmp As Button
    Friend WithEvents btnGo As Button
    Friend WithEvents OpenFileDialog_vec As OpenFileDialog
    Friend WithEvents OpenFileDialog_tmp As OpenFileDialog
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextBox1 As TextBox
End Class
