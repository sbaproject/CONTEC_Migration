VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "����݌ɏƉ�"
   ClientHeight    =   9930
   ClientLeft      =   465
   ClientTop       =   2100
   ClientWidth     =   15270
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
   Icon            =   "HIKDL51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   10303.54
   ScaleMode       =   0  'հ�ް
   ScaleWidth      =   15270
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12900
      MaxLength       =   24
      TabIndex        =   9
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   645
      Width           =   2265
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   12090
      MaxLength       =   10
      TabIndex        =   8
      Text            =   "XXXXX6"
      Top             =   645
      Width           =   840
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   23
      Left            =   -30
      TabIndex        =   5
      Top             =   9225
      Width           =   15330
      _ExtentX        =   27040
      _ExtentY        =   1296
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
         Index           =   22
         Left            =   675
         TabIndex        =   6
         Top             =   135
         Width           =   14415
         _ExtentX        =   25426
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
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   7
            Text            =   "HIKDL51.frx":030A
            Top             =   90
            Width           =   7260
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKDL51.frx":0341
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   870
      Index           =   1
      Left            =   100
      TabIndex        =   3
      Top             =   11235
      Width           =   12605
      _ExtentX        =   22225
      _ExtentY        =   1535
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
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   555
         Left            =   12195
         TabIndex        =   4
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6615
         Picture         =   "HIKDL51.frx":04CB
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6300
         Picture         =   "HIKDL51.frx":0655
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2925
         Picture         =   "HIKDL51.frx":07DF
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2565
         Picture         =   "HIKDL51.frx":0969
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "HIKDL51.frx":0AF3
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "HIKDL51.frx":0C7D
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "HIKDL51.frx":0E07
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "HIKDL51.frx":1459
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "HIKDL51.frx":1AAB
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "HIKDL51.frx":20FD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "HIKDL51.frx":274F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "HIKDL51.frx":28D9
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "HIKDL51.frx":2A63
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "HIKDL51.frx":2BED
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "HIKDL51.frx":2D77
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "HIKDL51.frx":2F01
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   21
      Left            =   -60
      TabIndex        =   1
      Top             =   0
      Width           =   15420
      _ExtentX        =   27199
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
         Height          =   330
         Left            =   13530
         TabIndex        =   2
         Top             =   105
         Width           =   1650
         _ExtentX        =   2910
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
      Begin VB.Image CM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   600
         Picture         =   "HIKDL51.frx":308B
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   960
         Picture         =   "HIKDL51.frx":3215
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   240
         Picture         =   "HIKDL51.frx":339F
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   2325
         Picture         =   "HIKDL51.frx":3529
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1965
         Picture         =   "HIKDL51.frx":3B7B
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1470
         Picture         =   "HIKDL51.frx":41CD
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   555
         Left            =   0
         Top             =   -15
         Width           =   15390
      End
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   43380
      Top             =   43380
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   375
      IMEMode         =   2  '��
      Left            =   43380
      TabIndex        =   0
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   0
      Left            =   10845
      TabIndex        =   10
      Top             =   645
      Width           =   1275
      _ExtentX        =   2249
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
      Caption         =   "  �Ɖ�Җ�"
      OutLine         =   -1  'True
   End
   Begin VB.Image IM_Opt 
      Appearance      =   0  '�ׯ�
      Height          =   270
      Index           =   1
      Left            =   2520
      Picture         =   "HIKDL51.frx":4357
      Top             =   15885
      Width           =   270
   End
   Begin VB.Image IM_Opt 
      Appearance      =   0  '�ׯ�
      Height          =   285
      Index           =   0
      Left            =   1680
      Picture         =   "HIKDL51.frx":4789
      Top             =   15885
      Width           =   270
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "���s(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_HARDCOPY 
         Caption         =   "��ʈ��"
         Enabled         =   0   'False
         Visible         =   0   'False
      End
      Begin VB.Menu Bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I��(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "�ҏW(&2)"
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
         Caption         =   "�؂���(&T)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "�R�s�[(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "�\��t��(&P)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "����(&3)"
      Begin VB.Menu MN_SELECTCM 
         Caption         =   "�I��"
         Shortcut        =   {F7}
      End
      Begin VB.Menu MN_PREV 
         Caption         =   "�O��"
         Shortcut        =   {F8}
      End
      Begin VB.Menu MN_NEXTCM 
         Caption         =   "����"
         Shortcut        =   {F9}
      End
      Begin VB.Menu Bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "���̈ꗗ(&L&�)..."
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

Public gv_bolKeyFlg                 As Boolean

Private Sub Form_Load()
    
    '��d�N������
    If App.PrevInstance Then
        MsgBox "�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", vbExclamation Or vbOKOnly, SSS_PrgNm
        End
    End If

    ' "���΂炭���҂���������" �E�B���h�E�\��
    Load ICN_ICON
    
    'DB�ڑ�
    Call CF_Ora_USR1_Open
    
    '���ʏ���������
    Call CF_Init

    '�����󋵏Ɖ�ďo������
    Call F_DSP_TNADL71C
    
    ' "���΂炭���҂���������" �E�B���h�E����
    Unload ICN_ICON
    
    '��ʏI��
    Unload Me

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    Set FR_SSSMAIN = Nothing
    
    'DB�ڑ�����
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)

End Sub

