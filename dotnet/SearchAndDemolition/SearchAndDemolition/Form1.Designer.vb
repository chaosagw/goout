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

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cbNameOnly = New System.Windows.Forms.CheckBox()
        Me.cbDirOpt = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbnWhole = New System.Windows.Forms.RadioButton()
        Me.rbnEnd = New System.Windows.Forms.RadioButton()
        Me.rbnBegin = New System.Windows.Forms.RadioButton()
        Me.rbnInclude = New System.Windows.Forms.RadioButton()
        Me.ImageButton1 = New VbPowerPack.ImageButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbRslt = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.UtilityToolBar1 = New VbPowerPack.UtilityToolBar()
        Me.SaveUtilityButton1 = New VbPowerPack.SaveUtilityButton()
        Me.UtilityToolBarButton1 = New VbPowerPack.UtilityToolBarButton()
        Me.CopyUtilityButton1 = New VbPowerPack.CopyUtilityButton()
        Me.UtilityToolBarButton3 = New VbPowerPack.UtilityToolBarButton()
        Me.DeleteUtilityButton1 = New VbPowerPack.DeleteUtilityButton()
        Me.UtilityToolBarButton2 = New VbPowerPack.UtilityToolBarButton()
        Me.StopUtilityButton1 = New VbPowerPack.StopUtilityButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NotificationWindow1 = New VbPowerPack.NotificationWindow(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbNameOnly)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbDirOpt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ImageButton1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Size = New System.Drawing.Size(641, 540)
        Me.SplitContainer1.SplitterDistance = 294
        Me.SplitContainer1.TabIndex = 0
        '
        'cbNameOnly
        '
        Me.cbNameOnly.AutoSize = True
        Me.cbNameOnly.Location = New System.Drawing.Point(160, 481)
        Me.cbNameOnly.Name = "cbNameOnly"
        Me.cbNameOnly.Size = New System.Drawing.Size(115, 16)
        Me.cbNameOnly.TabIndex = 2
        Me.cbNameOnly.Text = "ファイル名のみ表示"
        Me.cbNameOnly.UseVisualStyleBackColor = True
        '
        'cbDirOpt
        '
        Me.cbDirOpt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbDirOpt.AutoSize = True
        Me.cbDirOpt.Location = New System.Drawing.Point(14, 481)
        Me.cbDirOpt.Name = "cbDirOpt"
        Me.cbDirOpt.Size = New System.Drawing.Size(111, 16)
        Me.cbDirOpt.TabIndex = 1
        Me.cbDirOpt.Text = "サブフォルダも検索"
        Me.cbDirOpt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.TreeView1)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 409)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索場所"
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(3, 15)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(264, 391)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Close Folder.ico")
        Me.ImageList1.Images.SetKeyName(1, "Open Folder.ico")
        Me.ImageList1.Images.SetKeyName(2, "HD WIN.ico")
        Me.ImageList1.Images.SetKeyName(3, "optical.ico")
        Me.ImageList1.Images.SetKeyName(4, "net.ico")
        Me.ImageList1.Images.SetKeyName(5, "usb.ico")
        Me.ImageList1.Images.SetKeyName(6, "ram.ico")
        Me.ImageList1.Images.SetKeyName(7, "hdd_noroot.ico")
        Me.ImageList1.Images.SetKeyName(8, "hdd_unknown.ico")
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 465)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(220, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbnWhole)
        Me.GroupBox4.Controls.Add(Me.rbnEnd)
        Me.GroupBox4.Controls.Add(Me.rbnBegin)
        Me.GroupBox4.Controls.Add(Me.rbnInclude)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 98)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(316, 42)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "検索条件"
        '
        'rbnWhole
        '
        Me.rbnWhole.AutoSize = True
        Me.rbnWhole.Location = New System.Drawing.Point(226, 18)
        Me.rbnWhole.Name = "rbnWhole"
        Me.rbnWhole.Size = New System.Drawing.Size(80, 16)
        Me.rbnWhole.TabIndex = 3
        Me.rbnWhole.TabStop = True
        Me.rbnWhole.Text = "...と一致する"
        Me.rbnWhole.UseVisualStyleBackColor = True
        '
        'rbnEnd
        '
        Me.rbnEnd.AutoSize = True
        Me.rbnEnd.Location = New System.Drawing.Point(149, 18)
        Me.rbnEnd.Name = "rbnEnd"
        Me.rbnEnd.Size = New System.Drawing.Size(70, 16)
        Me.rbnEnd.TabIndex = 2
        Me.rbnEnd.TabStop = True
        Me.rbnEnd.Text = "...で終わる"
        Me.rbnEnd.UseVisualStyleBackColor = True
        '
        'rbnBegin
        '
        Me.rbnBegin.AutoSize = True
        Me.rbnBegin.Location = New System.Drawing.Point(73, 18)
        Me.rbnBegin.Name = "rbnBegin"
        Me.rbnBegin.Size = New System.Drawing.Size(69, 16)
        Me.rbnBegin.TabIndex = 1
        Me.rbnBegin.TabStop = True
        Me.rbnBegin.Text = "...で始まる"
        Me.rbnBegin.UseVisualStyleBackColor = True
        '
        'rbnInclude
        '
        Me.rbnInclude.AutoSize = True
        Me.rbnInclude.Location = New System.Drawing.Point(6, 18)
        Me.rbnInclude.Name = "rbnInclude"
        Me.rbnInclude.Size = New System.Drawing.Size(60, 16)
        Me.rbnInclude.TabIndex = 0
        Me.rbnInclude.TabStop = True
        Me.rbnInclude.Text = "...を含む"
        Me.rbnInclude.UseVisualStyleBackColor = True
        '
        'ImageButton1
        '
        Me.ImageButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.ImageButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ImageButton1.Location = New System.Drawing.Point(251, 465)
        Me.ImageButton1.Name = "ImageButton1"
        Me.ImageButton1.NormalImage = CType(resources.GetObject("ImageButton1.NormalImage"), System.Drawing.Image)
        Me.ImageButton1.Size = New System.Drawing.Size(77, 50)
        Me.ImageButton1.SizeMode = VbPowerPack.ImageButtonSizeMode.StretchImage
        Me.ImageButton1.TabIndex = 2
        Me.ImageButton1.Text = "検索"
        Me.ImageButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ImageButton1.TransparentColor = System.Drawing.Color.Black
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.lbRslt)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 146)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 313)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "検索結果"
        '
        'lbRslt
        '
        Me.lbRslt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRslt.FormattingEnabled = True
        Me.lbRslt.HorizontalScrollbar = True
        Me.lbRslt.ItemHeight = 12
        Me.lbRslt.Location = New System.Drawing.Point(3, 15)
        Me.lbRslt.Name = "lbRslt"
        Me.lbRslt.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbRslt.Size = New System.Drawing.Size(311, 295)
        Me.lbRslt.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtFind)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 42)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "検索パターン(カンマ区切りで指定)"
        '
        'txtFind
        '
        Me.txtFind.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFind.Location = New System.Drawing.Point(3, 15)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(311, 19)
        Me.txtFind.TabIndex = 0
        '
        'UtilityToolBar1
        '
        Me.UtilityToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.SaveUtilityButton1, Me.UtilityToolBarButton1, Me.CopyUtilityButton1, Me.UtilityToolBarButton3, Me.DeleteUtilityButton1, Me.UtilityToolBarButton2, Me.StopUtilityButton1})
        Me.UtilityToolBar1.DropDownArrows = True
        Me.UtilityToolBar1.IconOptions = VbPowerPack.UtilityToolBarIconOptions.LargeIcons
        Me.UtilityToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.UtilityToolBar1.Name = "UtilityToolBar1"
        Me.UtilityToolBar1.ShowText = VbPowerPack.UtilityToolBarShowText.ShowTextLabels
        Me.UtilityToolBar1.Size = New System.Drawing.Size(641, 49)
        Me.UtilityToolBar1.TabIndex = 1
        Me.UtilityToolBar1.TextAlign = False
        '
        'SaveUtilityButton1
        '
        Me.SaveUtilityButton1.ImageIndex = 16
        Me.SaveUtilityButton1.Name = "SaveUtilityButton1"
        Me.SaveUtilityButton1.Text = "Save"
        '
        'UtilityToolBarButton1
        '
        Me.UtilityToolBarButton1.Name = "UtilityToolBarButton1"
        Me.UtilityToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'CopyUtilityButton1
        '
        Me.CopyUtilityButton1.ImageIndex = 13
        Me.CopyUtilityButton1.Name = "CopyUtilityButton1"
        Me.CopyUtilityButton1.Text = "Copy"
        '
        'UtilityToolBarButton3
        '
        Me.UtilityToolBarButton3.Name = "UtilityToolBarButton3"
        Me.UtilityToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'DeleteUtilityButton1
        '
        Me.DeleteUtilityButton1.ImageIndex = 25
        Me.DeleteUtilityButton1.Name = "DeleteUtilityButton1"
        Me.DeleteUtilityButton1.Text = "Delete"
        '
        'UtilityToolBarButton2
        '
        Me.UtilityToolBarButton2.Name = "UtilityToolBarButton2"
        Me.UtilityToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'StopUtilityButton1
        '
        Me.StopUtilityButton1.ImageIndex = 3
        Me.StopUtilityButton1.Name = "StopUtilityButton1"
        Me.StopUtilityButton1.Text = "Stop"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 518)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(641, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'NotificationWindow1
        '
        Me.NotificationWindow1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.SystemColors.InactiveCaption, System.Drawing.SystemColors.Window)
        Me.NotificationWindow1.CornerImage = CType(resources.GetObject("NotificationWindow1.CornerImage"), System.Drawing.Image)
        Me.NotificationWindow1.DefaultText = Nothing
        Me.NotificationWindow1.DefaultTimeout = 3000
        Me.NotificationWindow1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.NotificationWindow1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "txt"
        Me.SaveFileDialog1.Filter = "テキストファイル|*.txt"
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "コピー先を指定してください"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 540)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.UtilityToolBar1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents UtilityToolBar1 As VbPowerPack.UtilityToolBar
    Friend WithEvents SaveUtilityButton1 As VbPowerPack.SaveUtilityButton
    Friend WithEvents DeleteUtilityButton1 As VbPowerPack.DeleteUtilityButton
    Friend WithEvents cbDirOpt As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageButton1 As VbPowerPack.ImageButton
    Friend WithEvents UtilityToolBarButton1 As VbPowerPack.UtilityToolBarButton
    Friend WithEvents UtilityToolBarButton2 As VbPowerPack.UtilityToolBarButton
    Friend WithEvents StopUtilityButton1 As VbPowerPack.StopUtilityButton
    Friend WithEvents lbRslt As System.Windows.Forms.ListBox
    Friend WithEvents NotificationWindow1 As VbPowerPack.NotificationWindow
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbnBegin As System.Windows.Forms.RadioButton
    Friend WithEvents rbnInclude As System.Windows.Forms.RadioButton
    Friend WithEvents rbnWhole As System.Windows.Forms.RadioButton
    Friend WithEvents rbnEnd As System.Windows.Forms.RadioButton
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CopyUtilityButton1 As VbPowerPack.CopyUtilityButton
    Friend WithEvents UtilityToolBarButton3 As VbPowerPack.UtilityToolBarButton
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents cbNameOnly As System.Windows.Forms.CheckBox

End Class
