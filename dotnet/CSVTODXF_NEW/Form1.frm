VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "CSVtoDXF Ver1.4"
   ClientHeight    =   4545
   ClientLeft      =   60
   ClientTop       =   375
   ClientWidth     =   3360
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4545
   ScaleWidth      =   3360
   StartUpPosition =   3  'Windows の既定値
   Begin VB.CommandButton Command1 
      Caption         =   "DXF出力"
      Height          =   735
      Left            =   1800
      TabIndex        =   6
      Top             =   3360
      Width           =   1215
   End
   Begin VB.Frame Frame3 
      Caption         =   "DXF出力形式"
      Height          =   1095
      Left            =   120
      TabIndex        =   2
      Top             =   3120
      Width           =   1455
      Begin VB.OptionButton Option3 
         Caption         =   "点と線"
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   720
         Width           =   975
      End
      Begin VB.OptionButton Option2 
         Caption         =   "線"
         Height          =   255
         Left            =   240
         TabIndex        =   4
         Top             =   480
         Width           =   855
      End
      Begin VB.OptionButton Option1 
         Caption         =   "点"
         Height          =   255
         Left            =   240
         TabIndex        =   3
         Top             =   240
         Width           =   975
      End
   End
   Begin VB.PictureBox Picture1 
      AutoRedraw      =   -1  'True
      BackColor       =   &H00FFFFFF&
      Height          =   2895
      Left            =   120
      ScaleHeight     =   189
      ScaleMode       =   3  'ﾋﾟｸｾﾙ
      ScaleWidth      =   205
      TabIndex        =   0
      Top             =   120
      Width           =   3135
   End
   Begin VB.Label Label3 
      Caption         =   "Copyright(C) 2001-2003  Y.Murai"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   4320
      Width           =   3015
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'////////////////////////////////////////////////////////
'       CSVtoDXF.exe Ver1.4
'           2003.5.6
'           made by Y.Murai
'           Visual Basic Ver6.0
'////////////////////////////////////////////////////////
Option Explicit
Dim maxi As Integer                     'データ行数（点数）
Dim maxj As Integer                     'データ列数（次元数）
Dim xymax, xymin, absmax As Double      'データの最大値、最小値
Dim t(10000, 1) As Double               '入力データ（ファイルからの読み込みデータ数、最大10000に固定）
                                        't(*,0):X座標、t(*,1)：Y座標
Dim scl As Double                       '表示用スケール
Dim myFile As String                    'DXF保存ファイル名（コモンダイヤログからの入力）

Private Sub Command1_Click()            'DXFファイル出力ボタンの処理
    Dim i As Integer
    i = InStr(Command$, ".")
    If i = 0 Then
          myFile = Command$ + ".DXF"
    Else: myFile = Left(Command$, i - 1) + ".DXF"
    End If
    
    filewrite                           'DXFファイルの書き込み
    Form1.Caption = "Form1" & myFile
    
End Sub

Private Sub form_load()
    '初期化
    Option2.Value = True
    Dim ret As Integer
    '
    'ファイルの読み込み
    On Error GoTo errtrap1
    If Command$ <> "" Then              'コマンドラインの解析（テキストファイル名の取得）
        Open Command$ For Input As #1
    Else
        ret = MsgBox("データファイル(*.csv)をドラッグ＆ドロップして起動してください", vbExclamation, "データエラー"): End
    '
    End If
    Dim i, j, k As Integer
    Dim dummy As String
    '
    Line Input #1, dummy                '面倒なので最初の行をコメントとして無条件にとばす
    '
    i = 0
    Do While Not EOF(1)
        Line Input #1, dummy
        If Left(CStr(dummy), 3) = "end" Or Left(CStr(dummy), 3) = "END" Then Exit Do  'endマークあっても無くても良い
        j = 0: k = 1
        Do While k <> 0
            k = InStr(dummy, ",")
            If k = 0 Then
                t(i, j) = CDbl(dummy)
            Else: t(i, j) = CDbl(Left(dummy, k - 1))
            End If
            dummy = Mid(dummy, k + 1)
            j = j + 1
        Loop
        i = i + 1
    Loop
    maxi = i: maxj = j                   'データ列数、行数の取得
    '
    If maxi < 2 Or maxi > 10000 Then ret = MsgBox("x,yデータ数は 2～10000個（セット）としてください", vbExclamation, "データエラー"): End
    Close #1
    '
    drawpic1                            'ピクチャーボックスへの描画
    Exit Sub
errtrap1:                               'エラー処理
    MsgBox Err.Description
    Err.Clear
    '
End Sub

Public Sub drawpic1()   '読み込んだテキストデータをピクチャーボックスにプレビュー
    Dim i As Integer
    Dim x0, y0, x1, y1, x2, y2 As Double
    '
    xymax = -1E+308                     '初期設定
    xymin = 1E+308
    '
    For i = 0 To maxi - 1
        If t(i, 0) >= xymax Then xymax = t(i, 0)
        If t(i, 1) >= xymax Then xymax = t(i, 1)
        If t(i, 0) <= xymin Then xymin = t(i, 0)
        If t(i, 1) <= xymin Then xymin = t(i, 1)
        If Abs(xymax) > Abs(xymin) Then absmax = Abs(xymax) Else absmax = Abs(xymin)
    Next i
    '描画処理(Picture1)
    x0 = Picture1.ScaleWidth / 2
    y0 = Picture1.ScaleHeight / 2
    scl = 0.9 * y0 / absmax             '描画スケール
    Picture1.Cls                        '画面クリア
    Picture1.DrawStyle = 0
    '
    For i = 0 To maxi - 2
    '描画
        x1 = x0 + scl * t(i, 0)
        x2 = x0 + scl * t(i + 1, 0)
        y1 = y0 - scl * t(i, 1)
        y2 = y0 - scl * t(i + 1, 1)
        Picture1.Line (x1, y1)-(x2, y2), RGB(0, 255, 0)
    Next i
    '
End Sub

Public Sub filewrite()  'DXFファイルへの書き込み
    On Error GoTo errtrap1
    Open myFile For Output As #1
    Dim i As Integer
    Dim x1, y1, x2, y2 As Double
    '
                                'ﾌｧｲﾙ書き始め
    Print #1, "0"               '決まり文句
    Print #1, "SECTION"         '決まり文句
    Print #1, "2"               '決まり文句
    Print #1, "ENTITIES"        '決まり文句
    '
    For i = 0 To maxi - 2
        x1 = t(i, 0)
        x2 = t(i + 1, 0)
        y1 = t(i, 1)
        y2 = t(i + 1, 1)
                                'ﾌｧｲﾙへの書き込み（点）
        If Option1.Value = True Or Option3.Value = True Then
            Print #1, "0"       '決まり文句
            Print #1, "POINT"   '決まり文句（点入力の場合）
            Print #1, "8"       '決まり文句（レイヤー名が続く）
            Print #1, "CSV_DXF" '好きな名前
            Print #1, "10"      '決まり文句（次の行にx座標の値を）
            Print #1, x1        'ｘ座標の値（始点）
            Print #1, "20"      '決まり文句（次の行にｙ座標の値を）
            Print #1, y1        'ｙ座標の値（始点）
            '
            Print #1, "0"       '決まり文句
            Print #1, "POINT"   '決まり文句（点入力の場合）
            Print #1, "8"       '決まり文句（レイヤー名が続く）
            Print #1, "CSV_DXF" '好きな名前
            Print #1, "10"      '決まり文句（次の行にx座標の値を）
            Print #1, x2        'ｘ座標の値（終点）
            Print #1, "20"      '決まり文句（次の行にｙ座標の値を）
            Print #1, y2        'ｙ座標の値（終点）
        End If
                                'ﾌｧｲﾙへの書き込み（線）
        If Option2.Value = True Or Option3.Value = True Then
            Print #1, "0"       '決まり文句
            Print #1, "LINE"    '決まり文句（線入力の場合）
            Print #1, "8"       '決まり文句（レイヤー名が続く）
            Print #1, "CSV_DXF" '好きな名前
            Print #1, "10"      '決まり文句（次の行に始点のｘ座標の値を）
            Print #1, x1        'ｘ座標の値（始点）
            Print #1, "20"      '決まり文句（次の行に始点のｙ座標の値を）
            Print #1, y1        'ｙ座標の値（始点）
            Print #1, "11"      '決まり文句（次の行に終点のｘ座標の値を）
            Print #1, x2        'ｘ座標の値（終点）
            Print #1, "21"      '決まり文句（次の行に終点のｙ座標の値を）
            Print #1, y2        'ｙ座標の値（終点）
        End If
    Next i
                            'ﾌｧｲﾙ最後
    Print #1, "0"           '決まり文句
    Print #1, "ENDSEC"      '決まり文句
    Print #1, "0"           '決まり文句
    Print #1, "EOF"         '決まり文句
    '
    Close #1
    Exit Sub
errtrap1:                   'エラー処理
    MsgBox Err.Description
    Err.Clear
End Sub

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             