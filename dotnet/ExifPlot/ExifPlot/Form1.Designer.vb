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
        Me.btnLink = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnExt = New System.Windows.Forms.Button()
        Me.btnOpnLnk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLink
        '
        Me.btnLink.Location = New System.Drawing.Point(12, 12)
        Me.btnLink.Name = "btnLink"
        Me.btnLink.Size = New System.Drawing.Size(170, 23)
        Me.btnLink.TabIndex = 0
        Me.btnLink.Text = "ListCaps"
        Me.btnLink.UseVisualStyleBackColor = True
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(12, 41)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(170, 23)
        Me.btnRun.TabIndex = 1
        Me.btnRun.Text = "便利(&B)|ExifPlot|実行"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'btnExt
        '
        Me.btnExt.Location = New System.Drawing.Point(12, 70)
        Me.btnExt.Name = "btnExt"
        Me.btnExt.Size = New System.Drawing.Size(170, 23)
        Me.btnExt.TabIndex = 2
        Me.btnExt.Text = "便利(&B)|ExifPlot|終了"
        Me.btnExt.UseVisualStyleBackColor = True
        '
        'btnOpnLnk
        '
        Me.btnOpnLnk.Location = New System.Drawing.Point(12, 99)
        Me.btnOpnLnk.Name = "btnOpnLnk"
        Me.btnOpnLnk.Size = New System.Drawing.Size(170, 23)
        Me.btnOpnLnk.TabIndex = 3
        Me.btnOpnLnk.Text = "OpenLNK"
        Me.btnOpnLnk.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(206, 140)
        Me.Controls.Add(Me.btnOpnLnk)
        Me.Controls.Add(Me.btnExt)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.btnLink)
        Me.Name = "Form1"
        Me.ShowInTaskbar = False
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLink As System.Windows.Forms.Button
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnExt As System.Windows.Forms.Button
    Friend WithEvents btnOpnLnk As System.Windows.Forms.Button

End Class
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      