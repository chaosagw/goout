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
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnGet = New System.Windows.Forms.Button()
        Me.lbPDFs = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnGet
        '
        Me.btnGet.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnGet.Location = New System.Drawing.Point(0, 238)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(284, 23)
        Me.btnGet.TabIndex = 1
        Me.btnGet.Text = "ページ数取得"
        Me.btnGet.UseVisualStyleBackColor = True
        '
        'lbPDFs
        '
        Me.lbPDFs.AllowDrop = True
        Me.lbPDFs.FormattingEnabled = True
        Me.lbPDFs.HorizontalScrollbar = True
        Me.lbPDFs.ItemHeight = 12
        Me.lbPDFs.Location = New System.Drawing.Point(0, 0)
        Me.lbPDFs.Name = "lbPDFs"
        Me.lbPDFs.ScrollAlwaysVisible = True
        Me.lbPDFs.Size = New System.Drawing.Size(284, 232)
        Me.lbPDFs.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.lbPDFs)
        Me.Controls.Add(Me.btnGet)
        Me.Name = "Form1"
        Me.Text = "PDFページ数取得"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents btnGet As Button
    Friend WithEvents lbPDFs As ListBox
End Class
