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
   StartUpPosition =   3  'Windows �̊���l
   Begin VB.CommandButton Command1 
      Caption         =   "DXF�o��"
      Height          =   735
      Left            =   1800
      TabIndex        =   6
      Top             =   3360
      Width           =   1215
   End
   Begin VB.Frame Frame3 
      Caption         =   "DXF�o�͌`��"
      Height          =   1095
      Left            =   120
      TabIndex        =   2
      Top             =   3120
      Width           =   1455
      Begin VB.OptionButton Option3 
         Caption         =   "�_�Ɛ�"
         Height          =   255
         Left            =   240
         TabIndex        =   5
         Top             =   720
         Width           =   975
      End
      Begin VB.OptionButton Option2 
         Caption         =   "��"
         Height          =   255
         Left            =   240
         TabIndex        =   4
         Top             =   480
         Width           =   855
      End
      Begin VB.OptionButton Option1 
         Caption         =   "�_"
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
      ScaleMode       =   3  '�߸��
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
Dim maxi As Integer                     '�f�[�^�s���i�_���j
Dim maxj As Integer                     '�f�[�^�񐔁i�������j
Dim xymax, xymin, absmax As Double      '�f�[�^�̍ő�l�A�ŏ��l
Dim t(10000, 1) As Double               '���̓f�[�^�i�t�@�C������̓ǂݍ��݃f�[�^���A�ő�10000�ɌŒ�j
                                        't(*,0):X���W�At(*,1)�FY���W
Dim scl As Double                       '�\���p�X�P�[��
Dim myFile As String                    'DXF�ۑ��t�@�C�����i�R�����_�C�����O����̓��́j

Private Sub Command1_Click()            'DXF�t�@�C���o�̓{�^���̏���
    Dim i As Integer
    i = InStr(Command$, ".")
    If i = 0 Then
          myFile = Command$ + ".DXF"
    Else: myFile = Left(Command$, i - 1) + ".DXF"
    End If
    
    filewrite                           'DXF�t�@�C���̏�������
    Form1.Caption = "Form1" & myFile
    
End Sub

Private Sub form_load()
    '������
    Option2.Value = True
    Dim ret As Integer
    '
    '�t�@�C���̓ǂݍ���
    On Error GoTo errtrap1
    If Command$ <> "" Then              '�R�}���h���C���̉�́i�e�L�X�g�t�@�C�����̎擾�j
        Open Command$ For Input As #1
    Else
        ret = MsgBox("�f�[�^�t�@�C��(*.csv)���h���b�O���h���b�v���ċN�����Ă�������", vbExclamation, "�f�[�^�G���["): End
    '
    End If
    Dim i, j, k As Integer
    Dim dummy As String
    '
    Line Input #1, dummy                '�ʓ|�Ȃ̂ōŏ��̍s���R�����g�Ƃ��Ė������ɂƂ΂�
    '
    i = 0
    Do While Not EOF(1)
        Line Input #1, dummy
        If Left(CStr(dummy), 3) = "end" Or Left(CStr(dummy), 3) = "END" Then Exit Do  'end�}�[�N�����Ă������Ă��ǂ�
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
    maxi = i: maxj = j                   '�f�[�^�񐔁A�s���̎擾
    '
    If maxi < 2 Or maxi > 10000 Then ret = MsgBox("x,y�f�[�^���� 2�`10000�i�Z�b�g�j�Ƃ��Ă�������", vbExclamation, "�f�[�^�G���["): End
    Close #1
    '
    drawpic1                            '�s�N�`���[�{�b�N�X�ւ̕`��
    Exit Sub
errtrap1:                               '�G���[����
    MsgBox Err.Description
    Err.Clear
    '
End Sub

Public Sub drawpic1()   '�ǂݍ��񂾃e�L�X�g�f�[�^���s�N�`���[�{�b�N�X�Ƀv���r���[
    Dim i As Integer
    Dim x0, y0, x1, y1, x2, y2 As Double
    '
    xymax = -1E+308                     '�����ݒ�
    xymin = 1E+308
    '
    For i = 0 To maxi - 1
        If t(i, 0) >= xymax Then xymax = t(i, 0)
        If t(i, 1) >= xymax Then xymax = t(i, 1)
        If t(i, 0) <= xymin Then xymin = t(i, 0)
        If t(i, 1) <= xymin Then xymin = t(i, 1)
        If Abs(xymax) > Abs(xymin) Then absmax = Abs(xymax) Else absmax = Abs(xymin)
    Next i
    '�`�揈��(Picture1)
    x0 = Picture1.ScaleWidth / 2
    y0 = Picture1.ScaleHeight / 2
    scl = 0.9 * y0 / absmax             '�`��X�P�[��
    Picture1.Cls                        '��ʃN���A
    Picture1.DrawStyle = 0
    '
    For i = 0 To maxi - 2
    '�`��
        x1 = x0 + scl * t(i, 0)
        x2 = x0 + scl * t(i + 1, 0)
        y1 = y0 - scl * t(i, 1)
        y2 = y0 - scl * t(i + 1, 1)
        Picture1.Line (x1, y1)-(x2, y2), RGB(0, 255, 0)
    Next i
    '
End Sub

Public Sub filewrite()  'DXF�t�@�C���ւ̏�������
    On Error GoTo errtrap1
    Open myFile For Output As #1
    Dim i As Integer
    Dim x1, y1, x2, y2 As Double
    '
                                '̧�ُ����n��
    Print #1, "0"               '���܂蕶��
    Print #1, "SECTION"         '���܂蕶��
    Print #1, "2"               '���܂蕶��
    Print #1, "ENTITIES"        '���܂蕶��
    '
    For i = 0 To maxi - 2
        x1 = t(i, 0)
        x2 = t(i + 1, 0)
        y1 = t(i, 1)
        y2 = t(i + 1, 1)
                                '̧�قւ̏������݁i�_�j
        If Option1.Value = True Or Option3.Value = True Then
            Print #1, "0"       '���܂蕶��
            Print #1, "POINT"   '���܂蕶��i�_���͂̏ꍇ�j
            Print #1, "8"       '���܂蕶��i���C���[���������j
            Print #1, "CSV_DXF" '�D���Ȗ��O
            Print #1, "10"      '���܂蕶��i���̍s��x���W�̒l���j
            Print #1, x1        '�����W�̒l�i�n�_�j
            Print #1, "20"      '���܂蕶��i���̍s�ɂ����W�̒l���j
            Print #1, y1        '�����W�̒l�i�n�_�j
            '
            Print #1, "0"       '���܂蕶��
            Print #1, "POINT"   '���܂蕶��i�_���͂̏ꍇ�j
            Print #1, "8"       '���܂蕶��i���C���[���������j
            Print #1, "CSV_DXF" '�D���Ȗ��O
            Print #1, "10"      '���܂蕶��i���̍s��x���W�̒l���j
            Print #1, x2        '�����W�̒l�i�I�_�j
            Print #1, "20"      '���܂蕶��i���̍s�ɂ����W�̒l���j
            Print #1, y2        '�����W�̒l�i�I�_�j
        End If
                                '̧�قւ̏������݁i���j
        If Option2.Value = True Or Option3.Value = True Then
            Print #1, "0"       '���܂蕶��
            Print #1, "LINE"    '���܂蕶��i�����͂̏ꍇ�j
            Print #1, "8"       '���܂蕶��i���C���[���������j
            Print #1, "CSV_DXF" '�D���Ȗ��O
            Print #1, "10"      '���܂蕶��i���̍s�Ɏn�_�̂����W�̒l���j
            Print #1, x1        '�����W�̒l�i�n�_�j
            Print #1, "20"      '���܂蕶��i���̍s�Ɏn�_�̂����W�̒l���j
            Print #1, y1        '�����W�̒l�i�n�_�j
            Print #1, "11"      '���܂蕶��i���̍s�ɏI�_�̂����W�̒l���j
            Print #1, x2        '�����W�̒l�i�I�_�j
            Print #1, "21"      '���܂蕶��i���̍s�ɏI�_�̂����W�̒l���j
            Print #1, y2        '�����W�̒l�i�I�_�j
        End If
    Next i
                            '̧�ٍŌ�
    Print #1, "0"           '���܂蕶��
    Print #1, "ENDSEC"      '���܂蕶��
    Print #1, "0"           '���܂蕶��
    Print #1, "EOF"         '���܂蕶��
    '
    Close #1
    Exit Sub
errtrap1:                   '�G���[����
    MsgBox Err.Description
    Err.Clear
End Sub

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             