VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_MTMET61 
   Caption         =   "���Ϗ�����"
   ClientHeight    =   5865
   ClientLeft      =   465
   ClientTop       =   1230
   ClientWidth     =   14325
   ControlBox      =   0   'False
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   ScaleHeight     =   5865
   ScaleWidth      =   14325
   Begin Threed5.SSCommand5 CS_JDNTRKB 
      Height          =   375
      Left            =   7800
      TabIndex        =   20
      TabStop         =   0   'False
      Top             =   75
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�󒍎��"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_TOKCD 
      Height          =   375
      Left            =   4785
      TabIndex        =   23
      TabStop         =   0   'False
      Top             =   555
      Width           =   1605
      _ExtentX        =   2831
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "���Ӑ�@�@�@�@ "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_MITDT 
      Height          =   375
      Left            =   75
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   555
      Width           =   1380
      _ExtentX        =   2434
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "���ϓ��t �@"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_TANCD 
      Height          =   375
      Left            =   75
      TabIndex        =   21
      TabStop         =   0   'False
      Top             =   75
      Width           =   1380
      _ExtentX        =   2434
      _ExtentY        =   661
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�c�ƒS����"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "��ݾ�"
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   330
      Left            =   7125
      TabIndex        =   19
      Top             =   5340
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "OK"
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   330
      Left            =   6045
      TabIndex        =   18
      Top             =   5340
      Width           =   1095
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   330
      Left            =   45
      TabIndex        =   7
      Top             =   1185
      Width           =   14235
      _ExtentX        =   25109
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   "���χ��@    �󒍎��   ���ϓ��t   ���Ӑ�                         ���ό���                                 �m��敪"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1020
      Index           =   0
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   14430
      _ExtentX        =   25453
      _ExtentY        =   1799
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox HD_KENNMA 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   4  '�S�p�Ђ炪��
         Left            =   8925
         TabIndex        =   16
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   540
         Width           =   4890
      End
      Begin VB.TextBox HD_KKTFL 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   11835
         TabIndex        =   5
         Text            =   "9"
         Top             =   60
         Width           =   315
      End
      Begin VB.TextBox HD_TOKCD 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   6360
         TabIndex        =   15
         Text            =   "XXXX5"
         Top             =   540
         Width           =   705
      End
      Begin VB.TextBox HD_MITDT 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   1425
         TabIndex        =   14
         Text            =   "9999/99/99"
         Top             =   540
         Width           =   1305
      End
      Begin VB.TextBox HD_MITNOV 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   7395
         TabIndex        =   4
         Text            =   "12"
         Top             =   60
         Width           =   315
      End
      Begin VB.TextBox HD_MITNO 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   6360
         TabIndex        =   3
         Text            =   "XXXXXXX8"
         Top             =   60
         Width           =   1050
      End
      Begin VB.TextBox HD_TANCD 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   1425
         TabIndex        =   1
         Text            =   "XXXXX6"
         Top             =   60
         Width           =   825
      End
      Begin VB.TextBox HD_JDNTRKB 
         Appearance      =   0  '�ׯ�
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         IMEMode         =   2  '��
         Left            =   8925
         TabIndex        =   12
         Text            =   "99"
         Top             =   60
         Width           =   360
      End
      Begin VB.TextBox HD_TANNM 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   2235
         TabIndex        =   2
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   60
         Width           =   2475
      End
      Begin VB.TextBox HD_JDNTRKBNM 
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   9270
         TabIndex        =   13
         Text            =   "MMMMMMMMM1"
         Top             =   60
         Width           =   1305
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   1
         Left            =   4770
         TabIndex        =   8
         Top             =   60
         Width           =   1605
         _ExtentX        =   2831
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�J�n���ϔԍ�"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   4
         Left            =   7785
         TabIndex        =   9
         Top             =   540
         Width           =   1155
         _ExtentX        =   2037
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "���ό���"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   3
         Left            =   12135
         TabIndex        =   6
         Top             =   60
         Width           =   2115
         _ExtentX        =   3731
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "0:�S�� 1:�m�� 9:���m��"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   375
         Index           =   2
         Left            =   10635
         TabIndex        =   11
         Top             =   60
         Width           =   1215
         _ExtentX        =   2143
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "*�m��敪"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin VB.Label Label2 
         Caption         =   "�ȍ~"
         BeginProperty Font 
            Name            =   "�l�r �o�S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   300
         Left            =   2790
         TabIndex        =   10
         Top             =   600
         Width           =   645
      End
   End
   Begin VB.ListBox LST 
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   3660
      ItemData        =   "WLS_MTMET61.frx":0000
      Left            =   30
      List            =   "WLS_MTMET61.frx":0007
      TabIndex        =   17
      Top             =   1485
      Width           =   14235
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   6585
      Picture         =   "WLS_MTMET61.frx":007D
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   7485
      Picture         =   "WLS_MTMET61.frx":06CF
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_NextCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   7080
      Picture         =   "WLS_MTMET61.frx":0D21
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_PrevCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   6180
      Picture         =   "WLS_MTMET61.frx":1373
      Top             =   6480
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image CM_NextCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   8385
      Picture         =   "WLS_MTMET61.frx":19C5
      Top             =   5340
      Width           =   360
   End
   Begin VB.Image CM_PrevCm 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   5505
      Picture         =   "WLS_MTMET61.frx":2017
      Top             =   5340
      Width           =   360
   End
End
Attribute VB_Name = "WLS_MTMET61"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'********************************************************************************
'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
'*  �v���O�������@�@�F�@���Ϗ�񌟍�
'*  �v���O�����h�c�@�F  WLS_MTMET61
'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
'*  �쐬���@�@�@�@�@�F  2006.07.04
'*-------------------------------------------------------------------------------
'*<01> YYYY.MM.DD�@�F�@�C�����
'*     �C����
'********************************************************************************
'************************************************************************************
'   �\����
'************************************************************************************
    Private Type Type_DB_MITTHA_W
        MITNO       As String       '���ϔԍ�
        MITNOV      As String       '���ϔԍ��Ő�
        JDNTRKB     As String       '�󒍎���敪
        JDNTRKBNM   As String       '�󒍎���敪��
        MITDT       As String       '���ϓ�
        TOKRN       As String       '���Ӑ旪��
        KENNMA      As String       '�����P
        KKTMTFL     As String       '�m�茩�ϋ敪
    End Type
'************************************************************************************
'   Private�萔
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "0"       '�J�n�R�[�h���͑��� [0,X]
    
    Private Const FM_PANEL3D1_CNT       As Integer = 5 '�p�l���R���g���[����

'************************************************************************************
'   Private�ϐ�
'************************************************************************************
'=== ����ʂ̑S�����i�[ =================
    Private Main_Inf    As Cls_All
'=== ����ʂ̑S�����i�[ =================

    Private Usr_Ody             As U_Ody            '�ް��ް����ð���
    Private DB_MITTHA_W         As Type_DB_MITTHA_W
    Private Dyn_Open            As Boolean          '�_�C�i�Z�b�g��ԁiTrue:Open False:Close)
    
    Private WM_WLS_MAX          As Integer
    Private WM_WLS_Pagecnt      As Integer          '�E�B���h�\���y�[�W�J�E���^
    Private WM_WLS_LastPage     As Integer          '�E�B���h�ŏI�y�[�W
    Private WM_WLS_LastFL       As Boolean          '�E�B���h�ŏI�f�[�^���B�t���O
    Private WM_WLS_DSPArray()   As String           '�E�B���h�\���f�[�^
    Private WM_WLS_Dspflg       As Integer          '�E�B���h�\���׸�(True or False)
    
    Private DblClickFl As Boolean


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Init_Def_Dsp
    '   �T�v�F  �e��ʂ̍��ڏ���ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Dsp() As Integer

    Dim Index_Wk        As Integer
    Dim BD_Cnt          As Integer
    Dim Wk_Cnt          As Integer

    '��ʊ�b���ʏ��ݒ�
    Call CF_Init_Def_Dsp(Me, Main_Inf)

    '/////////////////////
    '// ���b�Z�[�W���ʐݒ�
    '/////////////////////

'�r���������������������������������������������������������r
    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                '��ʕ���
' === 20060921 === UPDATE S - ACE)Sejima
'D        .Item_Cnt = 23                              '��ʍ��ڐ�
' === 20060921 === UPDATE ��
        .Item_Cnt = 24                              '��ʍ��ڐ�
' === 20060921 === UPDATE E
        .Dsp_Body_Cnt = 0                           '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 0                           '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = 0                      '��ʈړ���
' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
        Set .FormCtl = WLS_MTMET61
' === 20060920 === INSERT E
    End With
'�d���������������������������������������������������������d

    '��ʍ��ڏ��
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

'�r���������������������������������������������������������r
    '/////////////////////
    '// �S��ʗp����p���۰�
    '/////////////////////

    Index_Wk = 0

    '///////////////////
    '// �w�b�_���ҏW
    '///////////////////
    '�S���҃{�^��
    CS_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�S����(����)
    HD_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�S����(����)
    HD_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '���ϔԍ�
    HD_MITNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    '2018/04/12 UPD START CIS)�R��
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
    '2018/04/12 UPD END CIS)�R��
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '�Ő�
    HD_MITNOV.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNOV
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '�󒍎���敪�{�^��
    CS_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNTRKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�󒍎���敪(����)
    HD_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
' === 20070206 === UPDATE S - ACE)Nagasawa
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�󒍎���敪(����)
    HD_JDNTRKBNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKBNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�m��敪
    HD_KKTFL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KKTFL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '���ϓ��{�^��
    CS_MITDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_MITDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ϓ�
    HD_MITDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '���Ӑ�{�^��
    CS_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_TOKCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '���Ӑ�(����)
    HD_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20070206 === UPDATE S - ACE)Nagasawa CapsLock���͑Ή�
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20070206 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '����
    HD_KENNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
' === 20060921 === INSERT S - ACE)Sejima
    Index_Wk = Index_Wk + 1
    '���X�g���o��
    WLSLABEL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSLABEL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
' === 20060921 === INSERT E
    
    Index_Wk = Index_Wk + 1
    '���X�g
    LST.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = LST
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '�O�y�[�W�C���[�W
    CM_PrevCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PrevCm
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PrevCm(0)
    Set Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PrevCm(1)
    '=== �Ұ�ސݒ� ======================
    
    Index_Wk = Index_Wk + 1
    'OK�{�^��
    WLSOK.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSOK
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�L�����Z���{�^��
    WLSCANCEL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = WLSCANCEL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '���y�[�W�C���[�W
    CM_NextCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NextCm
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NextCm(0)
    Set Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NextCm(1)
    '=== �Ұ�ސݒ� ======================
    
    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

    '///////////////////
    '// ���̑��ҏW
    '///////////////////
    For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        Index_Wk = Index_Wk + 1
        'FM_Panel3D1
        FM_Panel3D1(Wk_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = FM_Panel3D1(Wk_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    Next
'�d���������������������������������������������������������d

    '��L�ݒ���e�����ۂ̺��۰قɐݒ肷��
    Call CF_Init_Item_Property(Main_Inf)
    '��ʍ��ڏ����Đݒ�
    Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

    '///////////////////
    '// ���ʍ��ڂ̍Đݒ�
    '///////////////////

'�r���������������������������������������������������������r
    '���X�g�s���̐ݒ�
    WM_WLS_MAX = 15
    
    '�Ԃ�l�̐ݒ�
    WLSMIT_RTNMITNO = ""
    WLSMIT_RTNMITNOV = ""
    
    '�m��t���O�̏����l�ݒ�
    If Trim(WLSMIT_KKTFL) = "1" Or Trim(WLSMIT_KKTFL) = "9" Then
        pv_strInit_KKTFL = Trim(WLSMIT_KKTFL)
    Else
        pv_strInit_KKTFL = "0"
    End If

    '�󒍎���敪�̏����l�ݒ�
    pv_strInit_JDNTRKB = Trim(WLSMIT_JDNTRKB)

'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyReturn
    '   �T�v�F  �e���ڂ�VBKEYRETURN����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyReturn(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer
    
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�e���ڂ�����ٰ��
    Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        Select Case Me.ActiveControl.NAME
            Case HD_TANCD.NAME, HD_MITNO.NAME, HD_MITNOV.NAME, HD_JDNTRKB.NAME _
               , HD_KKTFL.NAME, HD_MITDT.NAME, HD_TOKCD.NAME, HD_KENNMA.NAME
                '�ϐ��N���A
                Call WLS_Clear
                '���X�g�ҏW
                Call Get_MITTHA
                Call WLS_DspNew
               
                '̫����ړ�
                Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(LST.Tag), Main_Inf)
                
            Case LST.NAME
                Call Ctl_WLSOK_Click
                
            Case Else
        End Select
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_Clear
    '   �T�v�F  �ϐ�������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()
        '��ʕ\���y�[�W
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '�������ʕێ��z��
        ReDim WM_WLS_DSPArray(0)

    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Get_MITTHA
    '   �T�v�F  ���Ϗ�񌟍�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Get_MITTHA() As Integer

    Dim strSQL      As String
    
    '�Č���񌟍�����
    strSQL = ""
    strSQL = strSQL & " Select "
    strSQL = strSQL & "        MITTHA.MITNO       "     '���ϔԍ�
    strSQL = strSQL & "      , MITTHA.MITNOV      "     '�Ő�
    strSQL = strSQL & "      , MITTHA.MITDT       "     '���ϓ�
    strSQL = strSQL & "      , MITTHA.JDNTRKB     "     '�󒍎���敪
    strSQL = strSQL & "      , MEIMTA.MEINMA AS JDNTRKBNM   "     '�󒍎���敪��
    strSQL = strSQL & "      , MITTHA.TOKRN       "     '���Ӑ於
    strSQL = strSQL & "      , MITTHA.KENNMA      "     '�����P
    strSQL = strSQL & "      , MITTHA.KKTMTFL     "     '�m�茩�σt���O
    strSQL = strSQL & "   From MITTHA "
    strSQL = strSQL & "      , MEIMTA "
    strSQL = strSQL & "  Where MITTHA.DATKB       = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "    and MEIMTA.DATKB (+)   = '" & gc_strDATKB_USE & "' "
    strSQL = strSQL & "    and MEIMTA.KEYCD (+)   = '" & gc_strKEYCD_JDNTRKB & "' "
    strSQL = strSQL & "    and MITTHA.JDNTRKB     = MEIMTA.MEICDA (+) "
' === 20061006 === UPDATE S - ACE)Nagasawa �󒍎捞���s��ꂽ���ς̕\���͍s��Ȃ�
'    strSQL = strSQL & "    and MITTHA.JDNNO       = '" & Space(10) & "' "
' === 20061205 === UPDATE S - ACE)Nagasawa
'    If Trim(WLSMIT0001_JNDTRFLG) = "" Then
    If Trim(WLSMIT0001_JNDTRFLG) = "1" Then
' === 20061205 === UPDATE E -
        strSQL = strSQL & "    and MITTHA.JDNNO       = '" & Space(10) & "' "
    End If
' === 20061006 === UPDATE E -
    
    '�S����ID
    If Trim(HD_TANCD.Text) <> "" Then
        strSQL = strSQL & "    and TANCD  = '" & CF_Ora_String(Trim(HD_TANCD.Text), 6) & "' "
    End If

' === 20060725 === UPDATE S - ACE)Nagasawa
'    '�J�n���ϔԍ�
'    If Trim(HD_MITNO.Text) <> "" Then
'        strSQL = strSQL & "    and MITNO  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) & "' "
'    End If
'
'    '�J�n���ϔŐ�
'    If Trim(HD_MITNOV.Text) <> "" Then
'        strSQL = strSQL & "    and MITNOV >= '" & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
'    End If
    
    Select Case True
        '���ϔԍ��A�Ő����ɓ���
        Case Trim(HD_MITNO.Text) <> "" And Trim(HD_MITNOV.Text) <> ""
            strSQL = strSQL & "    and MITNO�@|| MITNOV  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) _
                                                               & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
        '���ϔԍ��̂ݓ���
        Case Trim(HD_MITNO.Text) <> "" And Trim(HD_MITNOV.Text) = ""
            strSQL = strSQL & "    and MITNO  >= '" & CF_Ora_String(Trim(HD_MITNO.Text), 10) & "' "
            
        '���ϔԍ��̂ݓ���
        Case Trim(HD_MITNO.Text) = "" And Trim(HD_MITNOV.Text) <> ""
            strSQL = strSQL & "    and MITNOV >= '" & CF_Ora_String(Trim(HD_MITNOV.Text), 2) & "' "
    End Select
' === 20060725 === UPDATE E -
    
    '�󒍎���敪
    If Trim(HD_JDNTRKB.Text) <> "" Then
        strSQL = strSQL & "    and JDNTRKB = '" & CF_Ora_String(Trim(HD_JDNTRKB.Text), 2) & "' "
    End If
    
    '�m��敪
    Select Case Trim(HD_KKTFL.Text)
        Case "0"
        
        Case "1", "9"
            strSQL = strSQL & "    and KKTMTFL   = '" & CF_Ora_String(Trim(HD_KKTFL.Text), 1) & "' "

    End Select
    
    '���ϓ��t
    If Trim(HD_MITDT.Text) <> "" Then
        strSQL = strSQL & "    and MITDT  >= '" & CF_Ora_Date(Trim(HD_MITDT.Text)) & "' "
    End If
    
    '���Ӑ�R�[�h
    If Trim(HD_TOKCD.Text) <> "" Then
        strSQL = strSQL & "    and TOKCD   = '" & CF_Ora_String(Trim(HD_TOKCD.Text), 10) & "' "
    End If
    
    '���ό���
    If Trim(HD_KENNMA.Text) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa �V���O���N�H�[�e�[�V�����Ή�
'        strSQL = strSQL & "    and KENNMA  LIKE '%" & Trim(HD_KENNMA.Text) & "%' "
        strSQL = strSQL & "    and KENNMA  LIKE '%" & CF_Ora_String(Trim(HD_KENNMA.Text), CF_Ctr_AnsiLenB(Trim(HD_KENNMA.Text))) & "%' "
' === 20080929 === UPDATE E -
    End If
    
    strSQL = strSQL & "  Order By "
    strSQL = strSQL & "           MITNO "
    strSQL = strSQL & "         , MITNOV "
    
    If Dyn_Open = True Then
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    Dyn_Open = True
    
    If CF_Ora_EOF(Usr_Ody) = True Then
        LST.Clear
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspNew
    '   �T�v�F  ���X�g�ҏW����(�������)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_DspNew()

    Dim Cnt             As Long
    
    Cnt = 0
    
    Do Until CF_Ora_EOF(Usr_Ody) = True
            
        '�擾���e�ޔ�
        With DB_MITTHA_W
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                '���ϔԍ�
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")              '�Ő�
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")            '�󒍎���敪
            .JDNTRKBNM = CF_Ora_GetDyn(Usr_Ody, "JDNTRKBNM", "")        '�󒍎���敪��
            
            '���ϓ�
            If IsDate(Format(CF_Ora_GetDyn(Usr_Ody, "MITDT", ""), "@@@@/@@/@@")) = True Then
                .MITDT = Format(CF_Ora_GetDyn(Usr_Ody, "MITDT", ""), "@@@@/@@/@@")
            Else
                .MITDT = Space(10)
            End If
            
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                '���Ӑ旪��
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")              '�����P
            If CF_Ora_GetDyn(Usr_Ody, "KKTMTFL", "") = "1" Then
                .KKTMTFL = "�m��"                                           '�m�茩�ϋ敪
            Else
                .KKTMTFL = "���m��"                                         '�m�茩�ϋ敪
            End If
        End With
        
        '�\�����y�[�W
        If Cnt Mod WM_WLS_MAX = 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            Cnt = 0
            '�ŏI�y�[�W�ޔ�
            WM_WLS_LastPage = WM_WLS_Pagecnt
        End If

        '�\���������W�J
        Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
        
        Cnt = Cnt + 1
        
        Call CF_Ora_MoveNext(Usr_Ody)
        
        If Cnt >= WM_WLS_MAX Then
            Exit Do
        End If
        
    Loop

    '�ŏI�f�[�^���B
    If CF_Ora_EOF(Usr_Ody) = True Then
        WM_WLS_LastFL = True
    End If
    
    If Cnt > 0 Then
        '�y�[�W��\��
        Call WLS_DspPage
    End If

End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_SetArray
    '   �T�v�F  ���X�g�ҏW
    '   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)

        With DB_MITTHA_W
            WM_WLS_DSPArray(ArrayCnt) = LeftWid$(.MITNO, 8) & "-" & _
                                        LeftWid$(.MITNOV, 2) & Space(1) & _
                                        LeftWid$(.JDNTRKBNM, 10) & Space(1) & _
                                        LeftWid$(.MITDT, 10) & Space(1) & _
                                        LeftWid$(.TOKRN, 30) & Space(1) & _
                                        LeftWid$(.KENNMA, 40) & Space(1) & _
                                        LeftWid$(.KKTMTFL, 6)
        End With
                                    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspPage
    '   �T�v�F  ���X�g�ҏW����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspPage()
        Dim WL_Mode As Integer
        Dim intCnt     As Integer

        LST.Clear

        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If
        
        intCnt = 0
        Do While intCnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
                LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)
            End If
            intCnt = intCnt + 1
        Loop
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            LST.SetFocus
        End If
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyRight
    '   �T�v�F  �e���ڂ�VBKEYRIGHT����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyRight(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    'KEYRIGHT����
    Call WLSMIT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        '�擾���e�\��/�N���A
        Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '�ϐ��N���A
                    Call WLS_Clear
                    '���X�g�ҏW
                    Call Get_MITTHA
                    Call WLS_DspNew
                Case Else
            End Select
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call WLSMIT0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'            '������ړ�����
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyDown
    '   �T�v�F  �e���ڂ�VBKEYDOWN����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyDown(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer
'
'    Dim Move_Flg        As Boolean
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Mode        As Integer
'
'    Move_Flg = False
'    Chk_Move_Flg = False
'
'    '�e���ڂ�����ٰ��
'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)
'
'    If Rtn_Chk = CHK_OK Then
'    '�`�F�b�N�n�j��
'        '�擾���e�\��
'        Dsp_Mode = DSP_SET
'    Else
'    '�`�F�b�N�m�f��
'        '�擾���e�N���A
'        Dsp_Mode = DSP_CLR
'    End If
'    '�擾���e�\��/�N���A
'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
'
'    If Chk_Move_Flg = True Then
'    '������ړ�����
'        'KEYDOWN����
'        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
'        If Move_Flg = True Then
'        '���̍��ڂֈړ������ꍇ
'            '������ړ�����
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        Else
'            '�I����Ԃ̐ݒ�i�����I���j
'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
'        End If
'    Else
'        '������ړ��Ȃ�
'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyLeft
    '   �T�v�F  �e���ڂ�VBKEYLEFT����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyLeft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYLEFT����
    Call WLSMIT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        '�擾���e�\��/�N���A
        Call WLSMIT0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call WLSMIT0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'            '������ړ�����
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyUp
    '   �T�v�F  �e���ڂ�VBKEYUP����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyUp(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

'    Dim Move_Flg        As Boolean
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Mode        As Integer
'
'    Move_Flg = False
'    Chk_Move_Flg = True
'
'    '�e���ڂ�����ٰ��
'    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)
'
'    If Rtn_Chk = CHK_OK Then
'    '�`�F�b�N�n�j��
'        '�擾���e�\��
'        Dsp_Mode = DSP_SET
'    Else
'    '�`�F�b�N�m�f��
'        '�擾���e�N���A
'        Dsp_Mode = DSP_CLR
'    End If
'    '�擾���e�\��/�N���A
'    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
'
'    If Chk_Move_Flg = True Then
'    '������ړ�����
'        'KEYUP����
'        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
'
'        If Move_Flg = True Then
'        '���̍��ڂֈړ������ꍇ
'            '������ړ�����
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        Else
'            '�I����Ԃ̐ݒ�i�����I���j
'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
'        End If
'
'    Else
'    '������ړ��Ȃ�
'        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyDown
    '   �T�v�F  �e���ڂ�KEYDOWN����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        '��������
        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
            pm_KeyCode = 0
            '����������
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
            '������
            pm_KeyCode = 0
            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'DELETE��
        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'INSERT��
        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'TAB��
        Case pm_KeyCode = vbKeyF16
            pm_KeyCode = 0
            '����������
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'Shift+TAB��
        Case pm_KeyCode = vbKeyF15
            pm_KeyCode = 0
            '�O̫����ʒu�ֈړ�
            Call WLSMIT0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

' === 20060902 === INSERT S - ACE)Nagasawa
    If gv_bolWLSMIT_LF_Enable = False Then
        Exit Function
    End If
' === 20060902 === INSERT E -

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '����̫������۰َ擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
'        '������ړ�����
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

'@'        '����̫������۰ق̑I�������Đݒ�
'@'        '�I����Ԃ̐ݒ�
'@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_DATE_SEL_KBN_DAY)
'@'        '���ڐF�ݒ�
'@'        Call CF_Set_Item_Color(Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS)

    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_GotFocus
    '   �T�v�F  �e���ڂ�GOTFOCUS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_GotFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Rtn_Chk     As Integer
    Dim Move_Flg    As Boolean
    Dim Wk_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '��ʒP�ʂ̏���(�����Ȃ�)
    '���ו��ł��ړ��O�����ו��łȂ��ꍇ
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
'�r���������������������������������������������������������r
        'ͯ�ޕ�����
'�d���������������������������������������������������������d
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
' === 20060801 === INSERT S - ACE)Nagasawa ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
    If TypeOf pm_Ctl Is SSCommand5 Then
        '������ʌďo�̏ꍇ�͏I��
        Exit Function
    End If
    
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
        '���׍s�R���g���[��������
        If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
            '���׌����{�^���̖��׍s���ϐ��ɓ����s����ݒ�
            For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                    '�ݒ�ς݂̏ꍇ�͏I��
                    Exit For
                End If
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
            Next
        End If
    Else
        '���׌����{�^���̖��׍s���ϐ���������
        For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
            If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                '�ݒ�ς݂̏ꍇ�͏I��
                Exit For
            End If
            Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
        Next
    End If
' === 20060801 === INSERT E
    
'�r���������������������������������������������������������r
    Select Case Trg_Index
        Case Else
            '����̫����擾����
            Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End Select
'�d���������������������������������������������������������d
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyPress
    '   �T�v�F  �e���ڂ�KEYPRESS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyPress(pm_Ctl As Control, ByRef pm_KeyAscii As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    
    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '����KEYPRESS����
    Call WLSMIT0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = WLSMIT0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        '�擾���e�\��/�N���A
        Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            Select Case Me.ActiveControl.NAME
                Case HD_KENNMA.NAME
                    '�ϐ��N���A
                    Call WLS_Clear
                    '���X�g�ҏW
                    Call Get_MITTHA
                    Call WLS_DspNew
                Case Else
            End Select
            
            '����̫����ʒu����E�ֈړ�
            Call WLSMIT0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
'            '������ړ�����
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
'        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANGE����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index    As Integer

    If Main_Inf.Dsp_Base.Change_Flg = True Then
        Main_Inf.Dsp_Base.Change_Flg = False
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '����KEYCHANG����
    Call WLSMIT0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

    '��ʒP�ʂ̏���(�����Ȃ�)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseUp
    '   �T�v�F  �e���ڂ�MOUSEUP����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseUp(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

' === 20061205 === INSERT S - ACE)Nagasawa VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061205 === INSERT E -

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
            
    Select Case True
        Case TypeOf pm_Ctl Is TextBox
' === 20061024 === INSERT S - ACE)Nagasawa ��������͍��ڂ̓r���܂ł̑I�����\�Ƃ���
            If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Typ <> IN_TYP_STR Then
' === 20061024 === INSERT E -
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
' === 20061024 === INSERT S - ACE)Nagasawa ��������͍��ڂ̓r���܂ł̑I�����\�Ƃ���
            End If
' === 20061024 === INSERT E -

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060801 === INSERT S - ACE)Nagasawa�@����W�{�^���Ή�
        Case TypeOf pm_Ctl Is SSCommand5
            '�{�^���̏ꍇ
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(WLS_MTMET61.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call WLSMIT0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060801 === INSERT E -

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_PrevCm.Tag)
                '�O�ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                Case CInt(CM_NextCm.Tag)
                '���ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
            End Select

    End Select
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseMove
    '   �T�v�F  �e���ڂ�MOUSEMOVE����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseMove(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseDown
    '   �T�v�F  �e���ڂ�MOUSEDOWN����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_PrevCm.Tag)
        '�O�ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)
        Case CInt(CM_NextCm.Tag)
        '���ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)
    End Select

    '����MOUSEDOWN����
    Call WLSMIT0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Click
    '   �T�v�F  �e���ڂ�CLICK����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Act_Index   As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�e������ʌďo
    Select Case Trg_Index
        Case CInt(CS_TANCD.Tag)
            '�S���Ҍ�����ʌďo
            Call WLSMIT0001.F_Ctl_CS_TANCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_JDNTRKB.Tag)
            '�󒍎���敪������ʌďo
            Call WLSMIT0001.F_Ctl_CS_JDNTRKB(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_MITDT.Tag)
            '���ϓ�������ʌďo
            Call WLSMIT0001.F_Ctl_CS_MITDT(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CS_TOKCD.Tag)
            '���Ӑ挟����ʌďo
            Call WLSMIT0001.F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CM_PrevCm.Tag)
            '�O��
            Call Ctl_CM_PrevCm_Click
            
        Case CInt(CM_NextCm.Tag)
            '����
            Call Ctl_CM_NextCm_Click
            
        Case CInt(WLSOK.Tag)
            'OK
            Call Ctl_WLSOK_Click
            
        Case CInt(WLSCANCEL.Tag)
            '�L�����Z��
            Call Ctl_WLSCANCEL_Click
            
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_PrevCm_Click
    '   �T�v�F  �O�y�[�W
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_PrevCm_Click() As Integer
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Call WLS_DspPage
    End If
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_NextCm_Click
    '   �T�v�F  ���y�[�W
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_NextCm_Click() As Integer

    If LST.ListCount <= 0 Then Exit Function
   
    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspNew
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_WLSOK_Click
    '   �T�v�F  OK�{�^��������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_WLSOK_Click() As Integer
        
        
    WLSMIT_RTNMITNO = MidWid$(LST.List(LST.ListIndex), 1, 8)
    WLSMIT_RTNMITNOV = MidWid$(LST.List(LST.ListIndex), 10, 2)
        
        Call Ctl_WLSCANCEL_Click
        
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_WLSCANCEL_Click
    '   �T�v�F  �L�����Z���{�^��������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_WLSCANCEL_Click() As Integer

    If Dyn_Open = True Then
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
    
    Hide
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Copy_Click
    '   �T�v�F  �R�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̃R�s�[
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Cut_Click
    '   �T�v�F  �؂���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Cut_Click() As Integer

    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̐؂���
    Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    '���ڏ�����
    Call Ctl_MN_ClearItm_Click

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteCM_Click
    '   �T�v�F  �폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteCM_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Paste_Click
    '   �T�v�F  �\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Paste_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    Call WLSMIT0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearItm_Click
    '   �T�v�F  ���ڏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearItm_Click() As Integer
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '��ʓ��e������
    Call WLSMIT0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)

    Select Case Me.ActiveControl.NAME
        Case HD_TANCD.NAME
            Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
            
        Case HD_JDNTRKB.NAME
            Call WLSMIT0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
    End Select
'�d���������������������������������������������������������d
    
    '����̫����擾����
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

End Function

'���������������� �S��ʃ��[�J�����ʏ��� End ��������������������������������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Edi_Dsp_Def
    '   �T�v�F  �������̉�ʕҏW
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Edi_Dsp_Def() As Integer
    Dim Index_Wk        As Integer

'�r��������������������������������������������������������
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KEYUP
    '   �T�v�F  �e���ڂ�KEYUP����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

Private Sub Form_Activate()

'    '�����t�H�[�J�X�ʒu�ݒ�
'    Call WLSMIT0001.F_Init_Cursor_Set(Main_Inf)
    
End Sub

Private Sub Form_Load()
    
    '��ʏ��ݒ�
    Call Init_Def_Dsp
    
    '��ʓ��e������
    Call WLSMIT0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '�����\���ҏW
    Call Edi_Dsp_Def
    
    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(WLS_MTMET61)
    
End Sub

Private Sub CM_NextCm_Click()
    Debug.Print "CM_NextCm_Click"
    Call Ctl_Item_Click(CM_NextCm)
End Sub

Private Sub CM_PrevCm_Click()
    Debug.Print "CM_PrevCm_Click"
    Call Ctl_Item_Click(CM_PrevCm)
End Sub

Private Sub CM_NextCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NextCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_NextCm, Button, Shift, X, Y)
End Sub

Private Sub CM_PrevCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PrevCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_PrevCm, Button, Shift, X, Y)
End Sub

Private Sub CM_NextCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NextCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_NextCm, Button, Shift, X, Y)
End Sub

Private Sub CM_PrevCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PrevCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_PrevCm, Button, Shift, X, Y)
End Sub

Private Sub CS_TANCD_Click()
    Debug.Print "CS_TANCD_Click"
    Call Ctl_Item_Click(CS_TANCD)
End Sub

Private Sub CS_JDNTRKB_Click()
    Debug.Print "CS_JDNTRKB_Click"
    Call Ctl_Item_Click(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_Click()
    Debug.Print "CS_MITDT_Click"
    Call Ctl_Item_Click(CS_MITDT)
End Sub

Private Sub CS_TOKCD_Click()
    Debug.Print "CS_TOKCD_Click"
    Call Ctl_Item_Click(CS_TOKCD)
End Sub
Private Sub CS_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(CS_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub CS_MITDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_MITDT_MouseUp"
    Call Ctl_Item_MouseUp(CS_MITDT, Button, Shift, X, Y)
End Sub

Private Sub CS_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TANCD, Button, Shift, X, Y)
End Sub

Private Sub CS_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub CS_JDNTRKB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_JDNTRKB_KeyUp"
    Call Ctl_Item_KeyUp(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_MITDT_KeyUp"
    Call Ctl_Item_KeyUp(CS_MITDT)
End Sub

Private Sub CS_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TANCD)
End Sub

Private Sub CS_TOKCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TOKCD)
End Sub

Private Sub CS_JDNTRKB_GotFocus()
    Debug.Print "CS_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(CS_JDNTRKB)
End Sub

Private Sub CS_MITDT_GotFocus()
    Debug.Print "CS_MITDT_GotFocus"
    Call Ctl_Item_GotFocus(CS_MITDT)
End Sub

Private Sub CS_TANCD_GotFocus()
    Debug.Print "CS_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TANCD)
End Sub

Private Sub CS_TOKCD_GotFocus()
    Debug.Print "CS_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TOKCD)
End Sub

Private Sub LST_DblClick()
    Debug.Print "LST_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, vbKeyReturn, 0)
End Sub

Private Sub LST_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "LST_KeyDown"
    Select Case KeyCode
        'Enter�L�[����
        Case vbKeyReturn
            Call Ctl_Item_KeyDown(LST, KeyCode, Shift)
            
        'Escape�L�[����
        Case vbKeyEscape
            Call WLSCANCEL_Click
        
        '���L�[����
        Case vbKeyLeft
            Call CM_PrevCm_Click
            
        '���L�[����
        Case vbKeyRight
            Call CM_NextCm_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
    
End Sub

Private Sub WLSCANCEL_Click()
    Debug.Print "WLSCANCEL_Click"
    Call Ctl_Item_Click(WLSCANCEL)
End Sub

Private Sub WLSOK_Click()
    Debug.Print "WLSOK_Click"
    Call Ctl_Item_Click(WLSOK)
End Sub

Private Sub HD_JDNTRKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKBNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_KKTFL_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KKTFL_MouseDown"
    Call Ctl_Item_MouseDown(HD_KKTFL, Button, Shift, X, Y)
End Sub

Private Sub HD_MITDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITDT, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNOV_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKBNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKBNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKBNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_KKTFL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KKTFL_MouseUp"
    Call Ctl_Item_MouseUp(HD_KKTFL, Button, Shift, X, Y)
End Sub

Private Sub HD_MITDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITDT, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNOV_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKB_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKBNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKBNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKBNM, KeyCode, Shift)
End Sub

Private Sub HD_KENNMA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
End Sub

Private Sub HD_KKTFL_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KKTFL_KeyDown"
    Call Ctl_Item_KeyDown(HD_KKTFL, KeyCode, Shift)
End Sub

Private Sub HD_MITDT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITDT, KeyCode, Shift)
End Sub

Private Sub HD_MITNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNO, KeyCode, Shift)
End Sub

Private Sub HD_MITNOV_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNOV_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNOV, KeyCode, Shift)
End Sub

Private Sub HD_TANCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
End Sub

Private Sub HD_TANNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
End Sub

Private Sub HD_TOKCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRKB_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
End Sub

Private Sub HD_JDNTRKBNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRKBNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKBNM, KeyAscii)
End Sub

Private Sub HD_KENNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KENNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
End Sub

Private Sub HD_KKTFL_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KKTFL_KeyPress"
    Call Ctl_Item_KeyPress(HD_KKTFL, KeyAscii)
End Sub

Private Sub HD_MITDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITDT, KeyAscii)
End Sub

Private Sub HD_MITNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNO, KeyAscii)
End Sub

Private Sub HD_MITNOV_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNOV_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNOV, KeyAscii)
End Sub

Private Sub HD_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
End Sub

Private Sub HD_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_JDNTRKB_GotFocus()
    Debug.Print "HD_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_GotFocus()
    Debug.Print "HD_JDNTRKBNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_GotFocus()
    Debug.Print "HD_KENNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_GotFocus()
    Debug.Print "HD_KKTFL_GotFocus"
    Call Ctl_Item_GotFocus(HD_KKTFL)
End Sub

Private Sub HD_MITDT_GotFocus()
    Debug.Print "HD_MITDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITDT)
End Sub

Private Sub HD_MITNO_GotFocus()
    Debug.Print "HD_MITNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNO)
End Sub

Private Sub HD_MITNOV_GotFocus()
    Debug.Print "HD_MITNOV_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNOV)
End Sub

Private Sub HD_TANCD_GotFocus()
    Debug.Print "HD_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANCD)
End Sub

Private Sub HD_TANNM_GotFocus()
    Debug.Print "HD_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANNM)
End Sub

Private Sub HD_TOKCD_GotFocus()
    Debug.Print "HD_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKCD)
End Sub

Private Sub HD_JDNTRKB_LostFocus()
    Debug.Print "HD_JDNTRKB_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_LostFocus()
    Debug.Print "HD_JDNTRKBNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_LostFocus()
    Debug.Print "HD_KENNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_LostFocus()
    Debug.Print "HD_KKTFL_LostFocus"
    Call Ctl_Item_LostFocus(HD_KKTFL)
End Sub

Private Sub HD_MITDT_LostFocus()
    Debug.Print "HD_MITDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITDT)
End Sub

Private Sub HD_MITNO_LostFocus()
    Debug.Print "HD_MITNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNO)
End Sub

Private Sub HD_MITNOV_LostFocus()
    Debug.Print "HD_MITNOV_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNOV)
End Sub

Private Sub HD_TANCD_LostFocus()
    Debug.Print "HD_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANCD)
End Sub

Private Sub HD_TANNM_LostFocus()
    Debug.Print "HD_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANNM)
End Sub

Private Sub HD_TOKCD_LostFocus()
    Debug.Print "HD_TOKCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKCD)
End Sub

Private Sub HD_JDNTRKB_Change()
    Debug.Print "HD_JDNTRKB_Change"
    Call Ctl_Item_Change(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRKBNM_Change()
    Debug.Print "HD_JDNTRKBNM_Change"
    Call Ctl_Item_Change(HD_JDNTRKBNM)
End Sub

Private Sub HD_KENNMA_Change()
    Debug.Print "HD_KENNMA_Change"
    Call Ctl_Item_Change(HD_KENNMA)
End Sub

Private Sub HD_KKTFL_Change()
    Debug.Print "HD_KKTFL_Change"
    Call Ctl_Item_Change(HD_KKTFL)
End Sub

Private Sub HD_MITDT_Change()
    Debug.Print "HD_MITDT_Change"
    Call Ctl_Item_Change(HD_MITDT)
End Sub

Private Sub HD_MITNO_Change()
    Debug.Print "HD_MITNO_Change"
    Call Ctl_Item_Change(HD_MITNO)
End Sub

Private Sub HD_MITNOV_Change()
    Debug.Print "HD_MITNOV_Change"
    Call Ctl_Item_Change(HD_MITNOV)
End Sub

Private Sub HD_TANCD_Change()
    Debug.Print "HD_TANCD_Change"
    Call Ctl_Item_Change(HD_TANCD)
End Sub

Private Sub HD_TANNM_Change()
    Debug.Print "HD_TANNM_Change"
    Call Ctl_Item_Change(HD_TANNM)
End Sub

Private Sub HD_TOKCD_Change()
    Debug.Print "HD_TOKCD_Change"
    Call Ctl_Item_Change(HD_TOKCD)
End Sub

' === 20060921 === INSERT S - ACE)Sejima
Private Sub WLSLABEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "WLSLABEL_MouseUp"
    Call Ctl_Item_MouseUp(WLSLABEL, Button, Shift, X, Y)
End Sub
' === 20060921 === INSERT E

' === 20060922 === INSERT S - ACE)Sejima
Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub
' === 20060922 === INSERT E

