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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbLayer = New System.Windows.Forms.ListBox()
        Me.btnOutdir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbOutdir = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.NotificationWindow1 = New VbPowerPack.NotificationWindow(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lbLayer)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(229, 197)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "出力するレイヤ"
        '
        'lbLayer
        '
        Me.lbLayer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbLayer.FormattingEnabled = True
        Me.lbLayer.HorizontalScrollbar = True
        Me.lbLayer.ItemHeight = 12
        Me.lbLayer.Location = New System.Drawing.Point(3, 15)
        Me.lbLayer.Name = "lbLayer"
        Me.lbLayer.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbLayer.Size = New System.Drawing.Size(223, 179)
        Me.lbLayer.TabIndex = 0
        '
        'btnOutdir
        '
        Me.btnOutdir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOutdir.Location = New System.Drawing.Point(199, 16)
        Me.btnOutdir.Name = "btnOutdir"
        Me.btnOutdir.Size = New System.Drawing.Size(24, 23)
        Me.btnOutdir.TabIndex = 1
        Me.btnOutdir.Text = "..."
        Me.btnOutdir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnOutdir)
        Me.GroupBox2.Controls.Add(Me.tbOutdir)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(229, 51)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "出力先"
        '
        'tbOutdir
        '
        Me.tbOutdir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbOutdir.Location = New System.Drawing.Point(6, 18)
        Me.tbOutdir.Name = "tbOutdir"
        Me.tbOutdir.Size = New System.Drawing.Size(187, 19)
        Me.tbOutdir.TabIndex = 0
        '
        'btnRun
        '
        Me.btnRun.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRun.Location = New System.Drawing.Point(9, 269)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(229, 23)
        Me.btnRun.TabIndex = 6
        Me.btnRun.Text = "Go"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'NotificationWindow1
        '
        Me.NotificationWindow1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.Window)
        Me.NotificationWindow1.BottomImage = CType(resources.GetObject("NotificationWindow1.BottomImage"), System.Drawing.Image)
        Me.NotificationWindow1.CornerImage = CType(resources.GetObject("NotificationWindow1.CornerImage"), System.Drawing.Image)
        Me.NotificationWindow1.DefaultText = Nothing
        Me.NotificationWindow1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NotificationWindow1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NotificationWindow1.ImageTransparentColor = System.Drawing.Color.Black
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(252, 303)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnRun)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Exports Selection"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lbLayer As System.Windows.Forms.ListBox
    Friend WithEvents btnOutdir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbOutdir As System.Windows.Forms.TextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents NotificationWindow1 As VbPowerPack.NotificationWindow
End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     