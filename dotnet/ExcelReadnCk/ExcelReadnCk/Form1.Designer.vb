﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.btn_go = New System.Windows.Forms.Button()
        Me.tbPath = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pgBar = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_go
        '
        Me.btn_go.Location = New System.Drawing.Point(197, 68)
        Me.btn_go.Name = "btn_go"
        Me.btn_go.Size = New System.Drawing.Size(75, 23)
        Me.btn_go.TabIndex = 0
        Me.btn_go.UseVisualStyleBackColor = True
        '
        'tbPath
        '
        Me.tbPath.Location = New System.Drawing.Point(6, 18)
        Me.tbPath.Name = "tbPath"
        Me.tbPath.Size = New System.Drawing.Size(257, 19)
        Me.tbPath.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbPath)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(269, 50)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "パス"
        '
        'pgBar
        '
        Me.pgBar.Location = New System.Drawing.Point(3, 68)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(188, 23)
        Me.pgBar.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 100)
        Me.Controls.Add(Me.pgBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_go)
        Me.Name = "Form1"
        Me.Text = "照明台帳DB"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_go As System.Windows.Forms.Button
    Friend WithEvents tbPath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      