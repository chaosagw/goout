﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.btnRun = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnRun1file = New System.Windows.Forms.Button
        Me.rbDeg = New System.Windows.Forms.RadioButton
        Me.rbDms = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 215)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exif情報を知りたい画像をドラッグして下さい"
        '
        'ListBox1
        '
        Me.ListBox1.AllowDrop = True
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(6, 18)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(256, 184)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 301)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(293, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(121, 240)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(55, 23)
        Me.btnRun.TabIndex = 2
        Me.btnRun.Text = "書き出し"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(121, 271)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(159, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "ヤメル"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRun1file
        '
        Me.btnRun1file.Location = New System.Drawing.Point(176, 240)
        Me.btnRun1file.Name = "btnRun1file"
        Me.btnRun1file.Size = New System.Drawing.Size(104, 23)
        Me.btnRun1file.TabIndex = 5
        Me.btnRun1file.Text = "1ファイルに書き出し"
        Me.btnRun1file.UseVisualStyleBackColor = True
        '
        'rbDeg
        '
        Me.rbDeg.AutoSize = True
        Me.rbDeg.Checked = True
        Me.rbDeg.Location = New System.Drawing.Point(6, 18)
        Me.rbDeg.Name = "rbDeg"
        Me.rbDeg.Size = New System.Drawing.Size(57, 16)
        Me.rbDeg.TabIndex = 6
        Me.rbDeg.TabStop = True
        Me.rbDeg.Text = "degree"
        Me.rbDeg.UseVisualStyleBackColor = True
        '
        'rbDms
        '
        Me.rbDms.AutoSize = True
        Me.rbDms.Location = New System.Drawing.Point(6, 38)
        Me.rbDms.Name = "rbDms"
        Me.rbDms.Size = New System.Drawing.Size(44, 16)
        Me.rbDms.TabIndex = 7
        Me.rbDms.Text = "dms"
        Me.rbDms.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbDeg)
        Me.GroupBox2.Controls.Add(Me.rbDms)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 233)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(102, 61)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "緯度経度の形式"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 323)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnRun1file)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "GetExif"
        Me.GroupBox1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnRun1file As System.Windows.Forms.Button
    Friend WithEvents rbDeg As System.Windows.Forms.RadioButton
    Friend WithEvents rbDms As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   