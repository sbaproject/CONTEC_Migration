VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�I�������\�o��"
   ClientHeight    =   5700
   ClientLeft      =   2295
   ClientTop       =   3180
   ClientWidth     =   9885
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "TNAPR83.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   5700
   ScaleWidth      =   9885
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   6765
      MaxLength       =   10
      TabIndex        =   16
      Text            =   "XXXXX6"
      Top             =   645
      Width           =   720
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   7470
      MaxLength       =   24
      TabIndex        =   15
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   645
      Width           =   2250
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   1410
      Index           =   0
      Left            =   0
      TabIndex        =   8
      Top             =   7065
      Width           =   8295
      _ExtentX        =   11933
      _ExtentY        =   2011
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.CommandButton CS_ENDDENDT 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         Caption         =   "D"
         Height          =   330
         Left            =   3915
         TabIndex        =   14
         TabStop         =   0   'False
         Top             =   630
         Width           =   330
      End
      Begin VB.CommandButton CS_STTDENDT 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         Caption         =   "D"
         Height          =   330
         Left            =   3510
         TabIndex        =   13
         TabStop         =   0   'False
         Top             =   630
         Width           =   330
      End
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   330
         Left            =   1575
         TabIndex        =   11
         Text            =   "Ӱ��"
         Top             =   630
         Width           =   735
      End
      Begin VB.CommandButton CS_STTTOKCD 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         Caption         =   "T"
         Height          =   330
         Left            =   720
         TabIndex        =   10
         TabStop         =   0   'False
         Top             =   630
         Width           =   330
      End
      Begin VB.CommandButton CS_ENDTOKCD 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         Caption         =   "T"
         Height          =   330
         Left            =   1170
         TabIndex        =   9
         TabStop         =   0   'False
         Top             =   630
         Width           =   330
      End
      Begin MSComDlg.CommonDialog CMDialogL 
         Left            =   45
         Top             =   630
         _ExtentX        =   847
         _ExtentY        =   847
         _Version        =   393216
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1845
         Picture         =   "TNAPR83.frx":030A
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   990
         Picture         =   "TNAPR83.frx":0494
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "TNAPR83.frx":061E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "TNAPR83.frx":07A8
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1395
         Picture         =   "TNAPR83.frx":0932
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2160
         Picture         =   "TNAPR83.frx":0ABC
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2520
         Picture         =   "TNAPR83.frx":0C46
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_VSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2880
         Picture         =   "TNAPR83.frx":0DD0
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3240
         Picture         =   "TNAPR83.frx":0F5A
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_FSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   3600
         Picture         =   "TNAPR83.frx":10E4
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3960
         Picture         =   "TNAPR83.frx":126E
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4320
         Picture         =   "TNAPR83.frx":13F8
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2025
         Picture         =   "TNAPR83.frx":1582
         Top             =   495
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   2430
         Picture         =   "TNAPR83.frx":170C
         Top             =   495
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   765
      Index           =   3
      Left            =   -30
      TabIndex        =   5
      Top             =   4950
      Width           =   9945
      _ExtentX        =   17542
      _ExtentY        =   1349
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 FM_Panel3D1 
         Height          =   465
         Index           =   4
         Left            =   675
         TabIndex        =   6
         Top             =   135
         Width           =   9120
         _ExtentX        =   16087
         _ExtentY        =   820
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  '�ׯ�
            BackColor       =   &H8000000F&
            BorderStyle     =   0  '�Ȃ�
            ForeColor       =   &H00000000&
            Height          =   195
            Left            =   45
            MultiLine       =   -1  'True
            TabIndex        =   7
            Text            =   "TNAPR83.frx":1896
            Top             =   90
            Width           =   5910
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "TNAPR83.frx":18CD
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   1
      Left            =   -45
      TabIndex        =   3
      Top             =   0
      Width           =   9945
      _ExtentX        =   17542
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 SYSDT 
         Height          =   285
         Left            =   8355
         TabIndex        =   4
         Top             =   135
         Width           =   1410
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "YYYY/MM/DD"
      End
      Begin VB.Image CM_LCONFIG 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1305
         Picture         =   "TNAPR83.frx":1A57
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_VSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   945
         Picture         =   "TNAPR83.frx":1BE1
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1665
         Picture         =   "TNAPR83.frx":1D6B
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   225
         Picture         =   "TNAPR83.frx":1EF5
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_LSTART 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   585
         Picture         =   "TNAPR83.frx":207F
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   4530
      End
   End
   Begin Threed5.SSPanel5 GAUGE 
      Height          =   420
      Left            =   1260
      TabIndex        =   2
      Top             =   3630
      Width           =   7365
      _ExtentX        =   12991
      _ExtentY        =   741
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "Panel3D2"
      FloodType       =   1
      OutLine         =   -1  'True
   End
   Begin VB.Frame Frame3D1 
      Caption         =   "�����w��"
      ForeColor       =   &H00000000&
      Height          =   2000
      Left            =   1260
      TabIndex        =   1
      Top             =   1425
      Width           =   7365
      Begin VB.TextBox HD_ZAIOUT 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         Height          =   285
         IMEMode         =   2  '��
         Left            =   1800
         MaxLength       =   7
         TabIndex        =   22
         Text            =   "X"
         Top             =   1215
         Width           =   255
      End
      Begin VB.TextBox HD_SOUNM 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   285
         IMEMode         =   4  '�S�p�Ђ炪��
         Left            =   2205
         MaxLength       =   20
         TabIndex        =   21
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   810
         Width           =   2235
      End
      Begin VB.TextBox HD_SOUCD 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         Height          =   285
         IMEMode         =   2  '��
         Left            =   1785
         MaxLength       =   7
         TabIndex        =   20
         Text            =   "XX6"
         Top             =   810
         Width           =   435
      End
      Begin VB.TextBox HD_Cursol_Wk2 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   6
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   180
         IMEMode         =   2  '��
         Left            =   1845
         TabIndex        =   19
         Text            =   "HD_Cursol_Wk_1"
         Top             =   855
         Width           =   435
      End
      Begin VB.TextBox HD_Cursol_Wk 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   6
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   180
         IMEMode         =   2  '��
         Left            =   2265
         TabIndex        =   18
         Text            =   "HD_Cursol_Wk_1"
         Top             =   855
         Width           =   435
      End
      Begin VB.Label Label3 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         BackStyle       =   0  '����
         Caption         =   "1:�o�͂���@9:�o�͂��Ȃ�"
         ForeColor       =   &H80000008&
         Height          =   255
         Left            =   2085
         TabIndex        =   25
         Top             =   1245
         Width           =   2970
      End
      Begin VB.Label Label1 
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         BackStyle       =   0  '����
         Caption         =   "�݌ɐ��o��"
         ForeColor       =   &H80000008&
         Height          =   330
         Left            =   675
         TabIndex        =   24
         Top             =   1245
         Width           =   1065
      End
      Begin VB.Label Label2 
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
         BackColor       =   &H80000005&
         BackStyle       =   0  '����
         Caption         =   "�q��"
         ForeColor       =   &H80000008&
         Height          =   330
         Left            =   675
         TabIndex        =   23
         Top             =   840
         Width           =   1065
      End
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   36855
      Top             =   36855
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   330
      IMEMode         =   2  '��
      Left            =   36855
      TabIndex        =   0
      Top             =   36855
      Width           =   285
   End
   Begin Threed5.SSCommand5 CM_LCANCEL 
      Height          =   285
      Left            =   4365
      TabIndex        =   12
      TabStop         =   0   'False
      Top             =   4455
      Width           =   1140
      _ExtentX        =   2011
      _ExtentY        =   503
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�� �~"
      OutLine         =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   5130
      TabIndex        =   17
      Top             =   645
      Width           =   1665
      _ExtentX        =   2937
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " ���͒S����"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_LSTART 
         Caption         =   "���(&P)"
         Shortcut        =   ^P
      End
      Begin VB.Menu MN_VSTART 
         Caption         =   "��ʕ\��"
      End
      Begin VB.Menu MN_FSTART 
         Caption         =   "�t�@�C���o��"
         Visible         =   0   'False
      End
      Begin VB.Menu MN_LCONFIG 
         Caption         =   "����ݒ�(&I)..."
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I��(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "�ҏW(&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "��ʏ�����(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "���ڏ�����"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "���ڕ���"
      End
      Begin VB.Menu Bar21 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Cut 
         Caption         =   "�؂���(&X)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "�R�s�[(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "�\��t��(&V)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "�⏕(&3)"
      Begin VB.Menu MN_Slist 
         Caption         =   "�E�C���h�E�\��(&L)"
         Shortcut        =   {F5}
      End
   End
   Begin VB.Menu SM_ShortCut 
      Caption         =   "ShortCut"
      Visible         =   0   'False
      Begin VB.Menu SM_AllCopy 
         Caption         =   "���ړ��e�R�s�[(&C)"
      End
      Begin VB.Menu SM_FullPast 
         Caption         =   "���ڂɓ\��t��(&P)"
      End
      Begin VB.Menu SM_Esc 
         Caption         =   "�����(Esc)"
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.

'���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
'=== ����ʂ̑S�����i�[ =================
Private Main_Inf    As Cls_All
'=== ����ʂ̑S�����i�[ =================
Private Const FM_PANEL3D1_CNT       As Integer = 5  '�p�l���R���g���[����

'�J�����_�\�����[�h
'���
Private Const mc_strCalMode_INPDATEF As String = "1"
Private Const mc_strCalMode_INPDATET As String = "2"

'HD_Cursol_Wk��GF�ň�����������s���邩�ǂ���
Private mv_bolTNAPR83_GF_Flg    As Boolean
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
    Set Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message

'�r���������������������������������������������������������r
    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                    '��ʕ���
        .Item_Cnt = 41         '��ʍ��ڐ�
        .Dsp_Body_Cnt = 0      '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 0      '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 0      '���ׂ̗񍀖ڐ�
    End With
'�d���������������������������������������������������������d

    '��ʍ��ڏ��
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

'�r���������������������������������������������������������r
    '/////////////////////
    '// �S��ʗp����p���۰�
    '/////////////////////
    '�����ݒ�p�^�C�}�[
    Set Main_Inf.TM_StartUp_Ctl = TM_StartUp
    Main_Inf.TM_StartUp_Ctl.Interval = 1
    Main_Inf.TM_StartUp_Ctl.Enabled = True

    Index_Wk = 0
    '�J�[�\������p�e�L�X�g
    TX_CursorRest.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_CursorRest
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '///////////////////
    '// ���j���[���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '�����P
    MN_Ctrl.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Ctrl
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���
    MN_LSTART.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_LSTART
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '��ʕ\��
    MN_VSTART.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_VSTART
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�t�@�C���o��
    MN_FSTART.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_FSTART
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����ݒ�
    MN_LCONFIG.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_LCONFIG
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�I��
    MN_EndCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EndCm
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����Q
    MN_EditMn.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_EditMn
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '��ʏ�����
    MN_APPENDC.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_APPENDC
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ڏ�����
    MN_ClearItm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearItm
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ڕ���
    MN_UnDoItem.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoItem
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�؂���
    MN_Cut.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Cut
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�R�s�[
    MN_Copy.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Copy
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�\��t��
    MN_Paste.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Paste
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����R
    MN_Oprt.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Oprt
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ڂ̈ꗗ
    MN_Slist.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Slist
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ړ��e�ɃR�s�[
    SM_AllCopy.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_AllCopy
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ڂɓ\��t��
    SM_FullPast.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_FullPast
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '������
    SM_Esc.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SM_Esc
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�I���C���[�W
    CM_EndCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_EndCm
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
    Set Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '����C���[�W
    CM_LSTART.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LSTART
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_LSTART_Inf.Click_Off_Img = IM_LSTART(0)
    Set Main_Inf.IM_LSTART_Inf.Click_On_Img = IM_LSTART(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '��ʕ\���C���[�W
    CM_VSTART.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_VSTART
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_VSTART_Inf.Click_Off_Img = IM_VSTART(0)
    Set Main_Inf.IM_VSTART_Inf.Click_On_Img = IM_VSTART(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '����ݒ�C���[�W
    CM_LCONFIG.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LCONFIG
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_LCONFIG_Inf.Click_Off_Img = IM_LCONFIG(0)
    Set Main_Inf.IM_LCONFIG_Inf.Click_On_Img = IM_LCONFIG(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�����C���[�W
    CM_SLIST.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SLIST
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
    Set Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�w�b�_�C���[�W
    Image1.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = Image1
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�������t
    SYSDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '///////////////////
    '// �w�b�_���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '���͒S����(����)
    HD_IN_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���͒S����(����)
    HD_IN_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�q�ɺ���
    HD_SOUCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '�q��(����)
    HD_SOUNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 20
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 20
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�݌ɐ��o��
    HD_ZAIOUT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_ZAIOUT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
    
    Index_Wk = Index_Wk + 1
    '�����ޯ��̫����ޔ�p�Q
    HD_Cursol_Wk2.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_Cursol_Wk2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����ޯ��̫����ޔ�p
    HD_Cursol_Wk.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_Cursol_Wk
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

    '///////////////
    '// �{�f�B���ҏW
    '///////////////
    
    '///////////////
    '// �t�b�^���ҏW
    '///////////////
    
    Index_Wk = Index_Wk + 1
    '�Q�[�W
    GAUGE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = GAUGE
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk          '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '���~�{�^��
    CM_LCANCEL.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_LCANCEL
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    '///////////////////
    '// ���b�Z�[�W���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '���b�Z�[�W
    TX_Message.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Message
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl.Locked = True

    Index_Wk = Index_Wk + 1
    'TX_Mode
    TX_Mode.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TX_Mode
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
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
    'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

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
        'Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
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
    '�J�[�\������p�e�L�X�g
    TX_CursorRest.TabStop = False
    TX_Message.TabStop = False

'�r���������������������������������������������������������r
    '������ԂŒ��~�{�^���͎g�p�s��
    CM_LCANCEL.Enabled = False
    
    '���X�g�t�H�[�J�X�t���O������
    gv_bolTNAPR83_LF_Enable = True
    
    '��������t���O������
    mv_bolTNAPR83_GF_Flg = True
    
    '������t���O������
    gv_bolNowPrinting = False
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

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False
    End If
    '�擾���e�\��/�N���A
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
        Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function


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

    'KEYRIGHT����(̫����ړ��Ȃ�)
    Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = False

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYDOWN����
        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

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

    'KEYLEFT����(̫����ړ��Ȃ�)
    Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYUP����
        Call F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If

    Else
    '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

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

    'Enter���̂݃t���O��ON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If
            
        gv_bolKeyFlg = True
    End If

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
            Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

        '�t�@���N�V�����L�[������
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
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

    If gv_bolTNAPR83_LF_Enable = False Then
        Exit Function
    End If
    '۽�̫������s����
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '����̫������۰َ擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

'@'        '����̫������۰ق̑I�������Đݒ�
'@'        '�I����Ԃ̐ݒ�
'@'        Call CF_Set_Sel_Ini(Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
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
        Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)
'�d���������������������������������������������������������d
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
'�r���������������������������������������������������������r
    Select Case Trg_Index
        Case CInt(HD_Cursol_Wk.Tag)

    On Error Resume Next

            '���[�o�͏���
            Call HD_SOUCD.SetFocus
            If mv_bolTNAPR83_GF_Flg Then
                
                Call PrintTNAPR83_Main(Main_Inf, -1)
                '�L�[�t���O�����ɖ߂�
                gv_bolKeyFlg = False
            End If
            mv_bolTNAPR83_GF_Flg = False
        
        Case CInt(HD_Cursol_Wk2.Tag)
            '�����ޯ���̌�̍��ڂ�̫������󂯎�����ꍇ
            
            If Trg_Index > Main_Inf.Dsp_Base.Cursor_Idx Then
                '����̫����Ɉړ�
                Call F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, Main_Inf)
            Else
                '�O̫����ʒu�ֈړ�
                Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
            End If
        
        Case Else
            If Trg_Index = CInt(HD_SOUCD.Tag) Then
                mv_bolTNAPR83_GF_Flg = True
            End If
            
            '����̫����擾����
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

    '����KEYPRESS����
    Call CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
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
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            
            '����̫����ʒu����E�ֈړ�
            Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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
    Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_LSTART.Tag)
                '����Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LSTART_Inf, False, Main_Inf)
                Case CInt(CM_VSTART.Tag)
                '��ʕ\���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_VSTART_Inf, False, Main_Inf)
                Case CInt(CM_LCONFIG.Tag)
                '����ݒ�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, False, Main_Inf)
                Case CInt(CM_SLIST.Tag)
                '�����Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
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
        Case CInt(Image1.Tag)
            '�Ұ�ނP������
            Call CF_Clr_Prompt(Main_Inf)

        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_LSTART.Tag)
        '����Ұ��
            Call CF_Set_Prompt(IMG_LSTART_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_VSTART.Tag)
        '��ʕ\���Ұ��
            Call CF_Set_Prompt(IMG_VSTART_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_LCONFIG.Tag)
        '����ݒ�Ұ��
            Call CF_Set_Prompt(IMG_LCONFIG_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '�����Ұ��
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)

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
    Dim Act_Index    As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    Act_Index = Val(Me.ActiveControl.Tag)

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_LSTART.Tag)
        '���[����Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LSTART_Inf, True, Main_Inf)

        Case CInt(CM_VSTART.Tag)
        '���[�\���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_VSTART_Inf, True, Main_Inf)

        Case CInt(CM_LCONFIG.Tag)
        '����ݒ�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_LCONFIG_Inf, True, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '�����Ұ��
            Select Case Main_Inf.Dsp_Sub_Inf(Act_Index).Ctl.NAME
                Case Me.HD_SOUCD.NAME
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
                Case Else
            End Select

    End Select

    '����MOUSEDOWN����
    Call CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

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

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = Val(pm_Ctl.Tag)

    '��è�޺��۰ي������ޯ���擾
    Act_Index = Val(Me.ActiveControl.Tag)

'�r���������������������������������������������������������r
    '�e������ʌďo
    Select Case Trg_Index
        Case CInt(CM_LCANCEL.Tag)
            '���~
            Call Ctl_CM_LCancel_Click
'�d���������������������������������������������������������d

        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_LSTART.Tag), CInt(CM_LSTART.Tag)
            '���
            Call Ctl_MN_LSTART_Click

        Case CInt(MN_VSTART.Tag), CInt(CM_VSTART.Tag)
            '��ʕ\��
            Call Ctl_MN_VSTART_Click

        Case CInt(MN_FSTART.Tag)
            '�t�@�C���o��
            Call Ctl_MN_FSTART_Click

        Case CInt(MN_LCONFIG.Tag), CInt(CM_LCONFIG.Tag)
            '����ݒ�
            Call Ctl_MN_LCONFIG_Click

        Case CInt(MN_EndCm.Tag), CInt(CM_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click

        Case CInt(MN_EditMn.Tag)
            '�����Q
            Call Ctl_MN_EditMn_Click

        Case CInt(MN_APPENDC.Tag)
            '��ʏ�����
            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '���ڏ�����
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '���ڕ���
            Call Ctl_MN_UnDoItem_Click

        Case CInt(MN_Cut.Tag)
            '�؂���
            Call Ctl_MN_Cut_Click

        Case CInt(MN_Copy.Tag)
            '�R�s�[
            Call Ctl_MN_Copy_Click

        Case CInt(MN_Paste.Tag)
            '�\��t��
            Call Ctl_MN_Paste_Click

        Case CInt(MN_Oprt.Tag)
            '����R
            Call Ctl_MN_Oprt_Click

        Case CInt(MN_Slist.Tag), CInt(CM_SLIST.Tag)
            '���ڂ̈ꗗ
            Call Ctl_MN_Slist_Click

        Case CInt(SM_AllCopy.Tag)
            '���ړ��e�ɃR�s�[
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '������
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '���ڂɓ\��t��
            Call Ctl_SM_FullPast_Click


    End Select

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
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
'�d���������������������������������������������������������d

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_VS_Scrl_Change
    '   �T�v�F  �c�X�N���[����CHANGE����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_VS_Scrl_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Act_Index   As Integer

    If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
        Main_Inf.Dsp_Base.VS_Scr_Flg = False
        Exit Function
    End If

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '����VS_SCRL_CHANGE����
    Call CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Ctrl_Click
    '   �T�v�F  ���j���[�����P�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Ctrl_Click() As Integer

    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '�u����v����
    MN_LSTART.Enabled = CF_Jge_Enabled_MN_LStart(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

    '�u��ʕ\���v����
    MN_VSTART.Enabled = CF_Jge_Enabled_MN_VStart(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

    '�u����ݒ�v����
    MN_LCONFIG.Enabled = CF_Jge_Enabled_MN_LConfig(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     
     '��I�������
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EditMn_Click
    '   �T�v�F  ���j���[�����Q�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '���ʏ����������
    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڏ����������
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڕ��������
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s�����������
'    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s�폜�����
'    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s�}�������
'    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s���������
'    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��؂��裔���
    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��R�s�[�����
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��\��t�������
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Oprt_Click
    '   �T�v�F  ���j���[�����R�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '����̈ꗗ�����
    MN_Slist.Enabled = CF_Jge_Enabled_MN_SList(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

'�r���������������������������������������������������������r
    '��è�ނȍ��ڂ̌����@�\���Ȃ��ꍇ�A�g�p�s��
    Select Case Me.ActiveControl.NAME
        Case HD_SOUCD
            MN_Slist.Enabled = False
        Case Else
            MN_Slist.Enabled = True
    End Select
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_APPENDC_Click
    '   �T�v�F  ��ʏ���������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_APPENDC_Click() As Integer

    '��ʓ��e������
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʃ{�f�B��������
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)
    
    '����̫����ʒu�ݒ�
    Call F_Init_Cursor_Set(Main_Inf)
    
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

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
    Dim Trg_Index   As Integer
    Dim Wk_Row      As Integer
    Dim Wk_Index    As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�I�����ڂ̏�����
    '��ʓ��e������
    Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

'�r���������������������������������������������������������r

    Select Case Me.ActiveControl.NAME
           Case Else
    End Select
'�d���������������������������������������������������������d
    
    '����̫����擾����
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

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
    '   ���́F  Function Ctl_MN_EndCm_Click
    '   �T�v�F  �I��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
'�r���������������������������������������������������������r
    Unload Me
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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  ���ڂ̈ꗗ
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer


    Dim Act_Index   As Integer

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)
    
'�r���������������������������������������������������������r
    
    Select Case Act_Index
        '�S���҃R�[�h
        Case CInt(Me.HD_SOUCD.Tag)
            Call SListOpen_SOUCD(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'
        Case Else
    End Select
    
'�d���������������������������������������������������������d
End Function
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SListOpen_SOUCD
    '   �T�v�F  �S���҃R�[�h������ʕ\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub SListOpen_SOUCD(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)
    
    Dim Trg_Index       As Integer
    Dim Dsp_Value       As Variant
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Dsp_Mode        As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Next_Focus      As Integer

    '�S���҃R�[�h����
    Trg_Index = CInt(FR_SSSMAIN.HD_SOUCD.Tag)
    WLSTAN_TANCLAKB = gc_strTANCLKB_EIGYO
            
    Next_Focus = Trg_Index + 1
    
    '̫�����S���҃R�[�h�ֈړ�
    If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
        '���݂�Active�R���g���[���̑I����ԉ���
        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
        '̫����ړ�
        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        '�I����Ԃ̐ݒ�i�����I���j
        Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
        '���ڐF�ݒ�
        Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
        
        gv_bolTNAPR83_LF_Enable = False
        
        'Windows�ɏ�����Ԃ�
        DoEvents

        '�S���Ҍ�����ʂ��Ăяo��
        WLSSOU.Show vbModal
        Unload WLSSOU
        
        gv_bolTNAPR83_LF_Enable = True

        If WLSSOU_RTNCODE <> "" Then
        '�����n�j
            '��ʂɕҏW
            Dsp_Value = CF_Cnv_Dsp_Item(WLSSOU_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
        
            '�`�F�b�N
            '�e���ڂ�����ٰ��
            Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
            
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
            Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
        
            If Chk_Move_Flg = True Then
                '������ړ�����
                Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
            Else
                '������ړ��Ȃ�
                Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
            End If
        End If
    End If

End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoDe_Click
    '   �T�v�F  ���׍s����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoDe_Click() As Integer
'    Dim Act_Index   As Integer
'
'    '�������ޯ���擾
'    Act_Index = CInt(Me.ActiveControl.Tag)
'
'    '�Y���s�̕�������
'    Call CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'
''�r���������������������������������������������������������r
''�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoItem_Click
    '   �T�v�F  ���ڕ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoItem_Click() As Integer

    Dim Act_Index   As Integer
    
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̕�������
    Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    
    Move_Flg = False
    Chk_Move_Flg = True
    
    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
    
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
    Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
    
    '�I����Ԃ̐ݒ�i�����I���j
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
    
    '���ڐF�ݒ�
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SM_AllCopy_Click
    '   �T�v�F  ���ړ��e�ɃR�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_AllCopy_Click() As Integer

    '���ړ��e�ɃR�s�[
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_Esc_Click
    '   �T�v�F  ������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_FullPast_Click
    '   �T�v�F  ���ڂɓ\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_FullPast_Click() As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
    Call CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_LSTART_Click
    '   �T�v�F  ���[���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_LSTART_Click() As Integer
'�r���������������������������������������������������������r

'    If Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_OK Then
        '�������
        Call PrintTNAPR83_Main(Main_Inf, SSS_PRINTER)
'    End If

    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_VSTART_Click
    '   �T�v�F  ���[��ʕ\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_VSTART_Click() As Integer
'�r���������������������������������������������������������r
    Call PrintTNAPR83_Main(Main_Inf, SSS_VIEW)
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_FSTART_Click
    '   �T�v�F  ���[�t�@�C���o��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_FSTART_Click() As Integer
'�r���������������������������������������������������������r
    Call PrintTNAPR83_Main(Main_Inf, SSS_FILE)
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_LCONFIG_Click
    '   �T�v�F  ����ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_LCONFIG_Click() As Integer
'�r���������������������������������������������������������r
    WLS_PRN.Show 1
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearDE_Click
    '   �T�v�F  ���׍s������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer
'
'    Dim Act_Index   As Integer
'
'    '�������ޯ���擾
'    Act_Index = CInt(Me.ActiveControl.Tag)
'
'    '�Y���s�̏���������
'    Call CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
'
''�r���������������������������������������������������������r
''�d���������������������������������������������������������d
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

'�r���������������������������������������������������������r
    Index_Wk = CInt(SYSDT.Tag)
    '��ʓ��t
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
    Call SSSMAIN0001.ShowGauge(False)
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Init_Def_Body_Inf
    '   �T�v�F  ��ʃ{�f�B���ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Body_Inf() As Integer

    Dim Bd_Col_Index    As Integer
    Dim Index_Wk        As Integer

    '������ʃ{�f�B���ݒ�
    Call CF_Init_Set_Body_Inf(Main_Inf)

    If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
    '���׍s�����݂���ꍇ

        '��ʃ{�f�B�̗񕪂̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT

        '�������p�ݒ�
        '��ʃ{�f�B�̗񕪂̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
        
        '�������ݒ�
        '�񕪂̕����s�̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
        
        '��ʃ{�f�B���̔z��O�Ԗڂɗ�����`����
        For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
            '��ʃ{�f�B���
            Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
            
            '�������p���
            Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
            
            '�������
            Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
        Next

    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Set_Body_Location
    '   �T�v�F  ���ׂ̔z�u
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Set_Body_Location() As Integer

    Const Hosei_Value    As Integer = -20

    Dim Bd_Index        As Integer

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_LCancel_Click
    '   �T�v�F  ���~�{�^���N���b�N
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_LCancel_Click() As Integer
    
    SSS_LSTOP = True
    
    Ctl_CM_LCancel_Click = 0
End Function

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    
    '������Ȃ�I�����Ȃ�
    If gv_bolNowPrinting Then
        Cancel = vbCancel
        Exit Sub
    End If
    
    '�I�����b�Z�[�W�̏o��
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTNAPR83_I_002, Main_Inf) = vbNo Then
        Cancel = vbCancel
        Exit Sub
    End If
    
    Main_Inf.Dsp_Base.IsUnload = True
    
    'DB�ؒf
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1) 'USR1
    Call CF_Ora_DisConnect(gv_Oss_USR9, gv_Odb_USR9) 'USR9
    
    Call SSSWIN_LOGWRT("�v���O�����I��")

End Sub






















Private Sub HD_SOUCD_Change()
    Debug.Print "HD_SOUCD_Change"
    Call Ctl_Item_Change(HD_SOUCD)
End Sub

Private Sub HD_SOUCD_GotFocus()
    Debug.Print "HD_SOUCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_SOUCD)
End Sub


Private Sub HD_SOUCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_SOUCD, KeyCode, Shift)
End Sub

Private Sub HD_SOUCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SOUCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_SOUCD, KeyAscii)
End Sub


Private Sub HD_SOUCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_SOUCD)
End Sub


Private Sub HD_SOUCD_LostFocus()
    Debug.Print "HD_SOUCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_SOUCD)
End Sub


Private Sub HD_SOUCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_SOUCD, Button, Shift, X, Y)
End Sub


Private Sub HD_SOUCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_SOUCD, Button, Shift, X, Y)
End Sub


Private Sub HD_ZAIOUT_Change()
    Debug.Print "HD_ZAIOUT_Change"
    Call Ctl_Item_Change(HD_ZAIOUT)
End Sub

Private Sub HD_ZAIOUT_GotFocus()
    Debug.Print "HD_ZAIOUT_GotFocus"
    Call Ctl_Item_GotFocus(HD_ZAIOUT)
End Sub


Private Sub HD_ZAIOUT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_ZAIOUT_KeyDown"
    Call Ctl_Item_KeyDown(HD_ZAIOUT, KeyCode, Shift)

End Sub


Private Sub HD_ZAIOUT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_ZAIOUT_KeyPress"
    Call Ctl_Item_KeyPress(HD_ZAIOUT, KeyAscii)
End Sub


Private Sub HD_ZAIOUT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_ZAIOUT_KeyUp"
    Call Ctl_Item_KeyUp(HD_ZAIOUT)
End Sub


Private Sub HD_ZAIOUT_LostFocus()
    Debug.Print "HD_ZAIOUT_LostFocus"
    Call Ctl_Item_LostFocus(HD_ZAIOUT)
End Sub


Private Sub HD_ZAIOUT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_ZAIOUT_MouseDown"
    Call Ctl_Item_MouseDown(HD_ZAIOUT, Button, Shift, X, Y)
End Sub


Private Sub HD_ZAIOUT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_ZAIOUT_MouseUp"
    Call Ctl_Item_MouseUp(HD_ZAIOUT, Button, Shift, X, Y)
End Sub


Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '����̫����ʒu�ݒ�
    Call F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()
    
    'DB�ڑ�
    Call CF_Ora_USR1_Open       'USR1
    Call CF_Ora_USR9_Open       'USR9
    
    '���ʏ���������
    Call CF_Init
    
    '�O����������s���̎擾
    gv_strInitYM = F_Get_InitYM

    '��ʏ��ݒ�
    Call Init_Def_Dsp
    
    '��ʓ��e������
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʖ��׏��ݒ�
    Call Init_Def_Body_Inf

    '��ʖ��ו�������
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '���׃��P�[�V����
    Call Set_Body_Location

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)

    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSMAIN)
    
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)


End Sub

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub CM_LCANCEL_Click()
    Debug.Print "CM_LCANCEL_Click"
    Call Ctl_Item_Click(CM_LCANCEL)
End Sub

Private Sub CM_LCONFIG_Click()
    Debug.Print "CM_LCONFIG_Click"
    Call Ctl_Item_Click(CM_LCONFIG)
End Sub

Private Sub CM_LSTART_Click()
    Debug.Print "CM_LSTART_Click"
    Call Ctl_Item_Click(CM_LSTART)
End Sub

Private Sub CM_SLIST_Click()
    Debug.Print "CM_SLIST_Click"
    Call Ctl_Item_Click(CM_SLIST)
End Sub

Private Sub CM_VSTART_Click()
    Debug.Print "CM_VSTART_Click"
    Call Ctl_Item_Click(CM_VSTART)
End Sub

Private Sub CS_ENDDENDT_Click()
    Debug.Print "CS_ENDDENDT_Click"
    Call Ctl_Item_Click(CS_ENDDENDT)
End Sub

Private Sub CS_STTDENDT_Click()
    Debug.Print "CS_STTDENDT_Click"
    Call Ctl_Item_Click(CS_STTDENDT)
End Sub

Private Sub MN_APPENDC_Click()
    Debug.Print "MN_APPENDC_Click"
    Call Ctl_Item_Click(MN_APPENDC)
End Sub

Private Sub MN_ClearItm_Click()
    Debug.Print "MN_ClearItm_Click"
    Call Ctl_Item_Click(MN_ClearItm)
End Sub

Private Sub MN_Copy_Click()
    Debug.Print "MN_Copy_Click"
    Call Ctl_Item_Click(MN_Copy)
End Sub

Private Sub MN_Ctrl_Click()
    Debug.Print "MN_Ctrl_Click"
    Call Ctl_Item_Click(MN_Ctrl)
End Sub

Private Sub MN_Cut_Click()
    Debug.Print "MN_Cut_Click"
    Call Ctl_Item_Click(MN_Cut)
End Sub

Private Sub MN_EditMn_Click()
    Debug.Print "MN_EditMn_Click"
    Call Ctl_Item_Click(MN_EditMn)
End Sub

Private Sub MN_EndCm_Click()
    Debug.Print "MN_EndCm_Click"
    Call Ctl_Item_Click(MN_EndCm)
End Sub

Private Sub MN_FSTART_Click()
    Debug.Print "MN_FSTART_Click"
    Call Ctl_Item_Click(MN_FSTART)
End Sub

Private Sub MN_LCONFIG_Click()
    Debug.Print "MN_LCONFIG_Click"
    Call Ctl_Item_Click(MN_LCONFIG)
End Sub

Private Sub MN_LSTART_Click()
    Debug.Print "MN_LSTART_Click"
    Call Ctl_Item_Click(MN_LSTART)
End Sub

Private Sub MN_Oprt_Click()
    Debug.Print "MN_Oprt_Click"
    Call Ctl_Item_Click(MN_Oprt)
End Sub

Private Sub MN_Paste_Click()
    Debug.Print "MN_Paste_Click"
    Call Ctl_Item_Click(MN_Paste)
End Sub

Private Sub MN_Slist_Click()
    Debug.Print "MN_Slist_Click"
    Call Ctl_Item_Click(MN_Slist)
End Sub

Private Sub MN_UnDoItem_Click()
    Debug.Print "MN_UnDoItem_Click"
    Call Ctl_Item_Click(MN_UnDoItem)
End Sub

Private Sub MN_VSTART_Click()
    Debug.Print "MN_VSTART_Click"
    Call Ctl_Item_Click(MN_VSTART)
End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_LCANCEL_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCANCEL_MouseDown"
    Call Ctl_Item_MouseDown(CM_LCANCEL, Button, Shift, X, Y)
End Sub

Private Sub CM_LCONFIG_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCONFIG_MouseDown"
    Call Ctl_Item_MouseDown(CM_LCONFIG, Button, Shift, X, Y)
End Sub

Private Sub CM_LSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LSTART_MouseDown"
    Call Ctl_Item_MouseDown(CM_LSTART, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseDown"
    Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_VSTART_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_VSTART_MouseDown"
    Call Ctl_Item_MouseDown(CM_VSTART, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_LCANCEL_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCANCEL_MouseMove"
    Call Ctl_Item_MouseMove(CM_LCANCEL, Button, Shift, X, Y)
End Sub

Private Sub CM_LCONFIG_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCONFIG_MouseMove"
    Call Ctl_Item_MouseMove(CM_LCONFIG, Button, Shift, X, Y)
End Sub

Private Sub CM_LSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LSTART_MouseMove"
    Call Ctl_Item_MouseMove(CM_LSTART, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseMove"
    Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_VSTART_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_VSTART_MouseMove"
    Call Ctl_Item_MouseMove(CM_VSTART, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_LCANCEL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCANCEL_MouseUp"
    Call Ctl_Item_MouseUp(CM_LCANCEL, Button, Shift, X, Y)
End Sub

Private Sub CM_LCONFIG_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LCONFIG_MouseUp"
    Call Ctl_Item_MouseUp(CM_LCONFIG, Button, Shift, X, Y)
End Sub

Private Sub CM_LSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_LSTART_MouseUp"
    Call Ctl_Item_MouseUp(CM_LSTART, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseUp"
    Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_VSTART_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_VSTART_MouseUp"
    Call Ctl_Item_MouseUp(CM_VSTART, Button, Shift, X, Y)
End Sub

Private Sub CM_LCANCEL_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "CM_LCANCEL_KeyDown"
    Call Ctl_Item_KeyDown(CM_LCANCEL, KeyCode, Shift)
End Sub

Private Sub CM_LCANCEL_KeyPress(KeyAscii As Integer)
    Debug.Print "CM_LCANCEL_KeyPress"
    Call Ctl_Item_KeyPress(CM_LCANCEL, KeyAscii)
End Sub


Private Sub CM_LCANCEL_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CM_LCANCEL_KeyUp"
    Call Ctl_Item_KeyUp(CM_LCANCEL)
End Sub

Private Sub HD_IN_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub






Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub TX_Message_Click()
    Debug.Print "TX_Message_Click"
    Call Ctl_Item_Click(TX_Message)
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub TX_Mode_Click()
    Debug.Print "TX_Mode_Click"
    Call Ctl_Item_Click(TX_Mode)
End Sub

Private Sub TX_Mode_GotFocus()
    Debug.Print "TX_Mode_GotFocus"
    Call Ctl_Item_GotFocus(TX_Mode)
End Sub
    
Private Sub TX_Mode_LostFocus()
    Debug.Print "TX_Mode_LostFocus"
    Call Ctl_Item_LostFocus(TX_Mode)
End Sub

Private Sub HD_Cursol_Wk_GotFocus()
    Debug.Print "HD_Cursol_Wk_GotFocus"
    Call Ctl_Item_GotFocus(HD_Cursol_Wk)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub SYSDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "SYSDT_MouseUp"
    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
End Sub

Private Sub HD_Cursol_Wk2_GotFocus()
    Debug.Print "HD_Cursol_Wk2_GotFocus"
    Call Ctl_Item_GotFocus(HD_Cursol_Wk2)
End Sub

Private Sub HD_Cursol_Wk_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_Cursol_Wk_MouseDown"
    Call Ctl_Item_MouseDown(HD_Cursol_Wk, Button, Shift, X, Y)
End Sub

Private Sub HD_Cursol_Wk2_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_Cursol_Wk2_MouseDown"
    Call Ctl_Item_MouseDown(HD_Cursol_Wk2, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub



Private Sub HD_Cursol_Wk_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_Cursol_Wk_MouseUp"
    Call Ctl_Item_MouseUp(HD_Cursol_Wk, Button, Shift, X, Y)
End Sub

Private Sub HD_Cursol_Wk2_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_Cursol_Wk2_MouseUp"
    Call Ctl_Item_MouseUp(HD_Cursol_Wk2, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub



Private Sub SM_AllCopy_Click()
    Debug.Print "SM_AllCopy_Click"
    Call Ctl_Item_Click(SM_AllCopy)
End Sub

Private Sub SM_Esc_Click()
    Debug.Print "SM_Esc_Click"
    Call Ctl_Item_Click(SM_Esc)
End Sub

Private Sub SM_FullPast_Click()
    Debug.Print "SM_FullPast_Click"
    Call Ctl_Item_Click(SM_FullPast)
End Sub

