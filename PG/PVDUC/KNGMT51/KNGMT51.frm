VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�����}�X�^�o�^�^����"
   ClientHeight    =   9840
   ClientLeft      =   180
   ClientTop       =   990
   ClientWidth     =   14955
   FillColor       =   &H00FF0000&
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
   Icon            =   "KNGMT51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   9840
   ScaleWidth      =   14955
   Begin VB.TextBox BD_DATKB 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   5805
      MaxLength       =   1
      TabIndex        =   34
      Text            =   "9"
      Top             =   2445
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox BD_UPDATE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   14520
      MaxLength       =   1
      TabIndex        =   33
      Top             =   2445
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.TextBox BD_HDNTAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   12030
      MaxLength       =   1
      TabIndex        =   16
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox BD_SAPMAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   13275
      MaxLength       =   1
      TabIndex        =   15
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox BD_SALTAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   10785
      MaxLength       =   1
      TabIndex        =   9
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   4
      Left            =   10785
      TabIndex        =   23
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   $"KNGMT51.frx":030A
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   5
      Left            =   12030
      TabIndex        =   24
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   $"KNGMT51.frx":031C
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   6
      Left            =   13275
      TabIndex        =   25
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   $"KNGMT51.frx":032E
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_PGID 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   1005
      MaxLength       =   8
      TabIndex        =   22
      Text            =   "XXXXXXX8"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1380
   End
   Begin VB.TextBox BD_FILEAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   9540
      MaxLength       =   1
      TabIndex        =   21
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox BD_MEINMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   2370
      MaxLength       =   40
      TabIndex        =   19
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   2440
      Visible         =   0   'False
      Width           =   3450
   End
   Begin VB.TextBox BD_PRTAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   8295
      MaxLength       =   1
      TabIndex        =   18
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox BD_UPDAUTH 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   7050
      MaxLength       =   1
      TabIndex        =   17
      Text            =   "9"
      Top             =   2440
      Visible         =   0   'False
      Width           =   1260
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11730
      MaxLength       =   10
      TabIndex        =   13
      Text            =   "XXXXX6"
      Top             =   705
      Width           =   765
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12480
      MaxLength       =   24
      TabIndex        =   12
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   705
      Width           =   2280
   End
   Begin VB.TextBox BD_UPDKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   375
      MaxLength       =   8
      TabIndex        =   11
      Text            =   "XXXX"
      Top             =   2440
      Visible         =   0   'False
      Width           =   645
   End
   Begin VB.TextBox HD_KNGGRCD 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Left            =   2745
      MaxLength       =   3
      TabIndex        =   10
      Text            =   "XX3"
      Top             =   1050
      Width           =   495
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   1
      Left            =   -30
      TabIndex        =   6
      Top             =   9105
      Width           =   15060
      _ExtentX        =   26564
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
         Index           =   3
         Left            =   675
         TabIndex        =   7
         Top             =   135
         Width           =   10500
         _ExtentX        =   18521
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
            TabIndex        =   8
            Text            =   "KNGMT51.frx":034A
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "KNGMT51.frx":0381
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   645
      Left            =   0
      TabIndex        =   3
      Top             =   10300
      Width           =   13605
      _ExtentX        =   16695
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
      OutLine         =   -1  'True
      Begin VB.VScrollBar VS_Scrl 
         Height          =   555
         Left            =   13185
         TabIndex        =   5
         Top             =   45
         Width           =   330
      End
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   375
         Left            =   12195
         TabIndex        =   4
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5820
         Picture         =   "KNGMT51.frx":050B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5460
         Picture         =   "KNGMT51.frx":0B5D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4740
         Picture         =   "KNGMT51.frx":11AF
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5100
         Picture         =   "KNGMT51.frx":1801
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   8040
         Picture         =   "KNGMT51.frx":1E53
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   8400
         Picture         =   "KNGMT51.frx":24A5
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "KNGMT51.frx":2AF7
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "KNGMT51.frx":2C81
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6660
         Picture         =   "KNGMT51.frx":2E0B
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6300
         Picture         =   "KNGMT51.frx":2F95
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "KNGMT51.frx":311F
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "KNGMT51.frx":32A9
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "KNGMT51.frx":3433
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "KNGMT51.frx":35BD
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "KNGMT51.frx":3747
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "KNGMT51.frx":38D1
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "KNGMT51.frx":3A5B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "KNGMT51.frx":3BE5
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "KNGMT51.frx":3D6F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "KNGMT51.frx":3EF9
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_1 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "KNGMT51.frx":4083
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_1 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "KNGMT51.frx":420D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   0
      Left            =   -45
      TabIndex        =   1
      Top             =   0
      Width           =   15210
      _ExtentX        =   26829
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
         Left            =   13125
         TabIndex        =   2
         Top             =   105
         Width           =   1680
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
      Begin VB.Image CM_SelectCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   5565
         Picture         =   "KNGMT51.frx":4397
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   225
         Picture         =   "KNGMT51.frx":4521
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1395
         Picture         =   "KNGMT51.frx":46AB
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   5115
         Picture         =   "KNGMT51.frx":4CFD
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   585
         Picture         =   "KNGMT51.frx":4E87
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1035
         Picture         =   "KNGMT51.frx":54D9
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   3945
         Picture         =   "KNGMT51.frx":5B2B
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   4305
         Picture         =   "KNGMT51.frx":5CB5
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   600
         Left            =   0
         Top             =   -45
         Width           =   15195
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
      Index           =   2
      Left            =   10515
      TabIndex        =   14
      Top             =   705
      Width           =   1230
      _ExtentX        =   2170
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "���͒S����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   7
      Left            =   7050
      TabIndex        =   26
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   "�X�V"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   10
      Left            =   1005
      TabIndex        =   27
      Top             =   1605
      Width           =   1380
      _ExtentX        =   2434
      _ExtentY        =   1508
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
      Caption         =   "��۸��тh�c"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   11
      Left            =   2370
      TabIndex        =   28
      Top             =   1605
      Width           =   3450
      _ExtentX        =   6085
      _ExtentY        =   1508
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
      Caption         =   "�v���O������"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   8
      Left            =   8295
      TabIndex        =   29
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   "���"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   9
      Left            =   9540
      TabIndex        =   30
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   $"KNGMT51.frx":5E3F
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   330
      Index           =   12
      Left            =   1005
      TabIndex        =   31
      Top             =   1050
      Width           =   1755
      _ExtentX        =   3096
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
      Caption         =   "*������ٰ��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   13
      Left            =   375
      TabIndex        =   32
      Top             =   1605
      Width           =   645
      _ExtentX        =   1138
      _ExtentY        =   1508
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
      Caption         =   "Ӱ��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   855
      Index           =   14
      Left            =   5805
      TabIndex        =   35
      Top             =   1605
      Width           =   1260
      _ExtentX        =   2223
      _ExtentY        =   1508
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
      Caption         =   "�N��"
      OutLine         =   -1  'True
   End
   Begin VB.Label Label1 
      Caption         =   "1:�@9:�s��"
      Height          =   360
      Left            =   5835
      TabIndex        =   20
      Top             =   1320
      Width           =   2430
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "�o�^(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_DeleteCM 
         Caption         =   "�폜(&D)"
         Shortcut        =   ^D
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
      Begin VB.Menu MN_ClearDE 
         Caption         =   "���׍s������"
         Enabled         =   0   'False
         Visible         =   0   'False
      End
      Begin VB.Menu MN_DeleteDE 
         Caption         =   "���׍s�폜(&T)"
         Enabled         =   0   'False
         Shortcut        =   ^T
         Visible         =   0   'False
      End
      Begin VB.Menu MN_InsertDE 
         Caption         =   "���׍s�}��(&I)"
         Enabled         =   0   'False
         Shortcut        =   ^I
         Visible         =   0   'False
      End
      Begin VB.Menu MN_UnDoDe 
         Caption         =   "���׍s����"
         Enabled         =   0   'False
         Visible         =   0   'False
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
      Begin VB.Menu MN_Prev 
         Caption         =   "�O��"
         Shortcut        =   {F8}
      End
      Begin VB.Menu MN_NextCm 
         Caption         =   "����"
         Shortcut        =   {F9}
      End
      Begin VB.Menu MN_SelectCm 
         Caption         =   "�ꗗ�\��"
         Shortcut        =   {F4}
      End
      Begin VB.Menu Bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "�E�C���h�E�\��(&L)"
         Shortcut        =   {F5}
      End
      Begin VB.Menu MN_UPDKB 
         Caption         =   "���[�h�ύX"
         Shortcut        =   {F6}
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
Private Const FM_PANEL3D1_CNT       As Integer = 14 '�p�l���R���g���[����
'*** End Of Generated Declaration Section ****

'=== ����ʂ̑S�����i�[ =================
Private Main_Inf    As Cls_All
'=== ����ʂ̑S�����i�[ =================

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Init_Def_Dsp
    '   �T�v�F  ��ʂ̊e���ڏ���ݒ�
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

    '���׃y�[�W���ݒ�
    MinPageNum = 1
    MaxPageNum = 1
    NowPageNum = 1

    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
' 2006/11/15  CHG START  KUMEDA
'        .Dsp_Ctg = DSP_CTG_ENTRY                    '��ʕ���
'        .Item_Cnt = 241                             '��ʍ��ڐ�
'        .Dsp_Body_Cnt = 20                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
'        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
'        .Body_Col_Cnt = 9                           '���ׂ̗񍀖ڐ�
'        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
' 2006/11/21  CHG START  KUMEDA
'        .Dsp_Ctg = DSP_CTG_ENTRY                    '��ʕ���
'        .Item_Cnt = 262                             '��ʍ��ڐ�
'        .Dsp_Body_Cnt = 20                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
'        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
'        .Body_Col_Cnt = 10                          '���ׂ̗񍀖ڐ�
'        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
        .Dsp_Ctg = DSP_CTG_ENTRY                    '��ʕ���
'ADD START FKS)INABA 2009/10/08 *************************************************
'�A���[��FC09101403
        .Item_Cnt = 284                             '��ʍ��ڐ�
'        .Item_Cnt = 283                             '��ʍ��ڐ�
'ADD  END  FKS)INABA 2009/10/08 *************************************************
        .Dsp_Body_Cnt = 20                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 11                          '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
' 2006/11/21  CHG END
' 2006/11/15  CHG END
    End With

    '��ʍ��ڏ��
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o�^
    MN_Execute.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Execute
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
'ADD START FKS)INABA 2009/10/08 ***********************
'�A���[��FC09101403
    Index_Wk = Index_Wk + 1
    '�o�^
    MN_DeleteCM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteCM
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
'ADD  END  FKS)INABA 2009/10/08 ***********************
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����Q(�ҏW)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���׍s������
    MN_ClearDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_ClearDE
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���׍s�폜
    MN_DeleteDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_DeleteDE
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���׍s�}��
    MN_InsertDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_InsertDE
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���׍s����
    MN_UnDoDe.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UnDoDe
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����R(�⏕)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�O��
    MN_Prev.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_Prev
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    MN_NextCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_NextCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�ꗗ�\��
    MN_SelectCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_SelectCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�E�C���h�E�\��
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���[�h�ύX
    MN_UPDKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_UPDKB
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
    Set Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�o�^�C���[�W
    CM_Execute.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_Execute
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
    Set Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '���׍s�}���C���[�W
    CM_INSERTDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_INSERTDE
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_INSERTDE_Inf.Click_Off_Img = IM_INSERTDE(0)
    Set Main_Inf.IM_INSERTDE_Inf.Click_On_Img = IM_INSERTDE(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '���׍s�폜�C���[�W
    CM_DELETEDE.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_DELETEDE
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_DELETEDE_Inf.Click_Off_Img = IM_DELETEDE(0)
    Set Main_Inf.IM_DELETEDE_Inf.Click_On_Img = IM_DELETEDE(1)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
    Set Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�O�ŃC���[�W
    CM_PREV.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_PREV
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PREV(0)
    Set Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PREV(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '���ŃC���[�W
    CM_NEXTCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_NEXTCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NEXTCM(0)
    Set Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NEXTCM(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�ꗗ�\���C���[�W
    CM_SelectCm.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SelectCm
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SelectCm(0)
    Set Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SelectCm(1)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����O���[�v
    HD_KNGGRCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KNGGRCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

    '///////////////
    '// �{�f�B���ҏW
    '///////////////
    Index_Wk = Index_Wk + 1
    '���[�h
    BD_UPDKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_N
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 4
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 4
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '�v���O�����h�c
    BD_PGID(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PGID(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�v���O������
    BD_MEINMA(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MEINMA(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

' 2006/11/21  ADD START  KUMEDA
    Index_Wk = Index_Wk + 1
    '�N��
    BD_DATKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DATKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
' 2006/11/21  ADD END

    Index_Wk = Index_Wk + 1
    '�X�V
    BD_UPDAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '���
    BD_PRTAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRTAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�t�@�C���o��
    BD_FILEAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_FILEAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�̔��P���ύX
    BD_SALTAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SALTAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�����P���ύX
    BD_HDNTAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HDNTAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�̔��v��N���v��C��
    BD_SAPMAUTH(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SAPMAUTH(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

' 2006/11/15  ADD START  KUMEDA
    Index_Wk = Index_Wk + 1
    '�X�V�t���O
    BD_UPDATE(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDATE(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
' 2006/11/15  ADD END

    For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        Load BD_UPDKB(BD_Cnt)           '���[�h
        Load BD_PGID(BD_Cnt)            '�v���O�����h�c
        Load BD_MEINMA(BD_Cnt)          '�v���O������
' 2006/11/21  ADD START  KUMEDA
        Load BD_DATKB(BD_Cnt)           '�N��
' 2006/11/21  ADD END
        Load BD_UPDAUTH(BD_Cnt)         '�X�V
        Load BD_PRTAUTH(BD_Cnt)         '���
        Load BD_FILEAUTH(BD_Cnt)        '�t�@�C���o��
        Load BD_SALTAUTH(BD_Cnt)        '�̔��P���ύX
        Load BD_HDNTAUTH(BD_Cnt)        '�����P���ύX
        Load BD_SAPMAUTH(BD_Cnt)        '�̔��v��N���v��C��
' 2006/11/15  ADD START  KUMEDA
        Load BD_UPDATE(BD_Cnt)          '�X�V�t���O
' 2006/11/15  ADD END

        Index_Wk = Index_Wk + 1
        '���[�h
        BD_UPDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�v���O�����h�c
        BD_PGID(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PGID(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�v���O������
        BD_MEINMA(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MEINMA(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

' 2006/11/21  ADD START  KUMEDA
        Index_Wk = Index_Wk + 1
        '�N��
        BD_DATKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DATKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
' 2006/11/21  ADD END

        Index_Wk = Index_Wk + 1
        '�X�V
        BD_UPDAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���
        BD_PRTAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRTAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�t�@�C���o��
        BD_FILEAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_FILEAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�̔��P���ύX
        BD_SALTAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SALTAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�����P���ύX
        BD_HDNTAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HDNTAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�̔��v��N���v��C��
        BD_SAPMAUTH(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SAPMAUTH(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

' 2006/11/15  ADD START  KUMEDA
        Index_Wk = Index_Wk + 1
        '�̔��v��N���v��C��
        BD_UPDATE(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDATE(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
' 2006/11/15  ADD END
    
    Next

    '///////////////
    '// �t�b�^���ҏW
    '///////////////


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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '///////////////////
    '// ���̑��ҏW
    '///////////////////
    For Wk_Cnt = 0 To FM_PANEL3D1_CNT - 1
        Index_Wk = Index_Wk + 1

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
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    Next

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
    '��ʕύX�Ȃ��Ƃ���
    gv_bolKNGMT51_INIT = False
    gv_bolInit = False
    gv_bolKNGMT51_LF_Enable = True
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyReturn
    '   �T�v�F  �e���ڂ�VBKEYRETURN����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        '������ړ�����
        Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
        
        '�ŏI���ځi���Ɉړ��ł��Ȃ����ځj�̏ꍇ
        If Move_Flg = False Then
            If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
            '�{�f�B��
                '�o�^�������s��
                Call Ctl_MN_Execute_Click
            End If
        End If
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
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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

    'KEYRIGHT����
    Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
    Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
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
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
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
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYUP����
        Call SSSMAIN0001.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

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
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '          pm_KeyCode   :�L�[�R�[�h
    '          pm_Shift     :shift�L�[�������
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C��
    'Enter���̂݃t���O��ON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If

        gv_bolKeyFlg = True
    End If
' === 20060801 === INSERT E

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

' === 20060930 === INSERT S - �t�@���N�V�����L�[�����Ή�
        '�t�@���N�V�����L�[������
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
' === 20060930 === INSERT E -

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KEYUP
    '   �T�v�F  �e���ڂ�KEYUP����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C��
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
' === 20060801 === INSERT E -

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
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

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '����̫������۰َ擾
    Act_Index = CInt(Me.ActiveControl.Tag)

' === 20060702 === INSERT S
    '۽�̫������s����
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
' === 20060702 === INSERT E

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
    
' === 20060921 === INSERT S
    '�����O���[�v�̏ꍇ
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Ctl.NAME = FR_SSSMAIN.HD_KNGGRCD.NAME Then
        '�����}�X�^�ɂ͑��݂������A���̃}�X�^�ƌ��т��f�[�^�����������ꍇ
        If (Rtn_Chk = CHK_OK) And (gv_bolMeiErrFlg = True) Then
            Chk_Move_Flg = False
        End If
    End If
' === 20060921 === INSERT E

    If Chk_Move_Flg = True Then
        '������ړ�����
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

        '����̫������۰ق̑I�������Đݒ�
        '�I����Ԃ̐ݒ�
        Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), 0)
        '���ڐF�ݒ�
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_GotFocus
    '   �T�v�F  �e���ڂ�GOTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
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

        'ͯ�ޕ�����
        Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)

        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If

' === 20060801 === INSERT S - ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
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

    '����̫����擾����
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyPress
    '   �T�v�F  �e���ڂ�KEYPRESS����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           pm_KeyAscii     :�L�[��ASCII�R�[�h
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
        '�Ώۍ��ڂ������O���[�v�ȊO�̏ꍇ
        If Main_Inf.Dsp_Sub_Inf(Trg_Index).Ctl.NAME <> FR_SSSMAIN.HD_KNGGRCD.NAME Then
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
        End If
        
        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANGE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
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
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
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
' === 20060702 === DELETE S
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
' === 20060702 === DELETE E

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060801 === INSERT S - ����W�{�^���Ή�
        Case TypeOf pm_Ctl Is SSCommand5
' 2006/11/28  ADD START  KUMEDA
            If Me.ActiveControl Is Nothing Then
                Exit Function
            End If
' 2006/11/28  ADD END

            '�{�^���̏ꍇ
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060801 === INSERT E

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_Execute.Tag)
                '�o�^�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
                Case CInt(CM_INSERTDE.Tag)
                '���׍s�}���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, False, Main_Inf)
                Case CInt(CM_DELETEDE.Tag)
                '���׍s�폜�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, False, Main_Inf)
                Case CInt(CM_SLIST.Tag)
                '�����Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
                Case CInt(CM_PREV.Tag)
                '�O�ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                Case CInt(CM_NEXTCm.Tag)
                '���ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
                Case CInt(CM_SelectCm.Tag)
                '�ꗗ�\���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)

            End Select
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseMove
    '   �T�v�F  �e���ڂ�MOUSEMOVE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
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
        Case CInt(CM_Execute.Tag)
        '�o�^�Ұ��
            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_INSERTDE.Tag)
        '���׍s�}���Ұ��
            Call CF_Set_Prompt(IMG_INSERTDE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_DELETEDE.Tag)
        '���׍s�폜�Ұ��
            Call CF_Set_Prompt(IMG_DELETEDE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_SLIST.Tag)
        '�����Ұ��
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_PREV.Tag)
        '�O�ŲҰ��
            Call CF_Set_Prompt(IMG_PREV_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_NEXTCm.Tag)
        '���ŲҰ��
            Call CF_Set_Prompt(IMG_NEXTCM_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_SelectCm.Tag)
        '�ꗗ�\���Ұ��
            Call CF_Set_Prompt("�ꗗ�\�����܂��B", COLOR_BLACK, Main_Inf)

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseDown
    '   �T�v�F  �e���ڂ�MOUSEDOWN����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer
    Dim Act_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20060702 === INSERT S
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)
' === 20060702 === INSERT E

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '�o�^�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        Case CInt(CM_INSERTDE.Tag)
        '���׍s�}���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, True, Main_Inf)

        Case CInt(CM_DELETEDE.Tag)
        '���׍s�폜�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, True, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '������ʕ\���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)

        Case CInt(CM_PREV.Tag)
        '�O�ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)

        Case CInt(CM_NEXTCm.Tag)
        '���ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)

        Case CInt(CM_SelectCm.Tag)
        '�ꗗ�\���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)

    End Select

' === 20060702 === INSERT S
    '����MOUSEDOWN����
    Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
' === 20060702 === INSERT E

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Click
    '   �T�v�F  �e���ڂ�CLICK����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Wk_Index    As Integer
    Dim RetnCd      As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    RetnCd = -1

    Select Case Trg_Index

        Case CInt(CM_SLIST.Tag), CInt(MN_Slist.Tag)
            '�e������ʌďo
            Call F_Ctl_CS(Main_Inf)

        Case CInt(CM_Execute.Tag), CInt(MN_Execute.Tag)
            '�o�^
            Call Ctl_MN_Execute_Click

        Case CInt(CM_INSERTDE.Tag), CInt(MN_InsertDE.Tag)
            '���׍s�}��
            Call Ctl_MN_InsertDE_Click

        Case CInt(CM_DELETEDE.Tag), CInt(MN_DeleteDE.Tag)
            '���׍s�폜
            Call Ctl_MN_DeleteDE_Click

        Case CInt(CM_PREV.Tag), CInt(MN_Prev.Tag)
            '�O�ł�
            Call Ctl_CM_PREV_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_NEXTCm.Tag), CInt(MN_NextCm.Tag)
            '���ł�
            Call Ctl_CM_NEXTCM_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_SelectCm.Tag), CInt(MN_SelectCm.Tag)
            '�ꗗ�\��
            Call Ctl_MN_SelectCm_Click

        '=============================================

        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

        Case CInt(CM_EndCm.Tag), CInt(MN_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click
            Exit Function

        Case CInt(MN_EditMn.Tag)
            '�ҏW�Q
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

        Case CInt(MN_ClearDE.Tag)
            '���׍s������
            Call Ctl_MN_ClearDE_Click

        Case CInt(MN_UnDoDe.Tag)
            '���׍s����
            Call Ctl_MN_UnDoDe_Click

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
            '�⏕�R
            Call Ctl_MN_Oprt_Click

        Case CInt(MN_UPDKB.Tag)
            '���[�h�ύX
            Call Ctl_MN_UPDKB_Click

        Case CInt(SM_AllCopy.Tag)
            '���ړ��e�ɃR�s�[
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '������
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '���ڂɓ\��t��
            Call Ctl_SM_FullPast_Click
'ADD START FKS)INABA 2009/10/08 *************
'�A���[��FC09101403
        Case CInt(MN_DeleteCM.Tag)
            '�폜
            Call Ctl_MN_DeleteCM_Click
'ADD  END  FKS)INABA 2009/10/08 *************
    End Select

    '�X�e�[�^�X�o�[������
    Call CF_Clr_Prompt(Main_Inf)

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
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)
    If Trim(FR_SSSMAIN.HD_KNGGRCD.Text) = "" Then
        MN_Execute.Enabled = False
        MN_DeleteCM.Enabled = False
    Else
        MN_Execute.Enabled = True
        MN_DeleteCM.Enabled = True
    End If
    '��o�^�����
'    MN_Execute.Enabled = pv_InpTan_KNG     2007/01/11 DLT
'    '��폜�����
'    MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     '��I�������
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EditMn_Click
    '   �T�v�F  ���j���[�ҏW�Q�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

'    '���ʏ����������
'    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڏ����������
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڕ��������
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s�����������
    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '����׍s�폜�����
'    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_DeleteDE.Enabled = False
'    '����׍s�}�������
'    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_InsertDE.Enabled = False
    '����׍s���������
    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '��؂��裔���
'    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '��R�s�[�����
'    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '��\��t�������
'    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Oprt_Click
    '   �T�v�F  ���j���[�⏕�R�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

'    '��O�ţ����ţ����
'    Call F_Ctl_PageButton_Enabled(Main_Inf)
    '��ꗗ�\���������
    MN_SelectCm.Enabled = False
    '��E�C���h�E�\���������
    MN_Slist.Enabled = False
    '����[�h�ύX�������
    MN_UPDKB.Enabled = False

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  �o�^
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer

    intRet = F_Ctl_Upd_Process(Main_Inf)
    If intRet = 0 Then
        If NowPageNum < MaxPageNum Then
        '�\������Ă��閾�ׂ��ő�y�[�W�ԍ��łȂ��Ȃ玟�y�[�W��\��
            NowPageNum = NowPageNum + 1
            
' 2006/11/28  ADD START  KUMEDA
            If Me.ActiveControl Is Nothing Then
                Exit Function
            End If
' 2006/11/28  ADD END

            Trg_Index = CInt(Me.ActiveControl.Tag)
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
            'Call F_Init_Cursor_Set(Main_Inf)
            Call F_Cursor_Set(Main_Inf)
            
        Else
            '�\������Ă��閾�ׂ��ő�y�[�W�ԍ��Ȃ�ĕ\��
            '�ŏ㖾�׃C���f�b�N�X�̑ޔ�
            Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
            
            '��ʃ{�f�B��������
            Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
            '�f�[�^�Ď擾
'CHG START FKS)INABA 2009/10/08 ********************************
'�A���[��FC09101403
            Call F_GET_BD_DATA(Main_Inf, "Ctl_MN_Execute_Click")
'CHG  END  FKS)INABA 2009/10/08 ********************************
            '�ŏ㖾�׃C���f�b�N�X��߂�
            Main_Inf.Dsp_Body_Inf.Cur_Top_Index = Wk_Cur_Top_Index
            
' 2006/11/28  ADD START  KUMEDA
            If Me.ActiveControl Is Nothing Then
                Exit Function
            End If
' 2006/11/28  ADD END

            Trg_Index = CInt(Me.ActiveControl.Tag)
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
            Call F_Cursor_Set(Main_Inf)
        End If
        
        gv_bolKNGMT51_INIT = False
    End If

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
'ADD START FKS)INABA 2009/10/08 ***********
'�A���[��FC09101403
    Dim intRet          As Integer
    
    intRet = SSSMAIN0001.F_Ctl_Del_Process(Main_Inf)
    If intRet = 0 Then
        '��ʏ�����
        Call Ctl_MN_APPENDC_Click
    End If
'ADD  END  FKS)INABA 2009/10/08 ***********
End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_HARDCOPY_Click
    '   �T�v�F  ��ʈ��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer
'�r���������������������������������������������������������r
    Dim wk_Cursor As Integer

    'Operable=TRUE�̎��̂�ok
    If PP_SSSMAIN.Operable = False Then
        Exit Function
    End If
    '�n�[�h�R�s�[�C�x���g���s
    If SSSMAIN_Hardcopy_Getevent() Then
        wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
    End If
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
    Unload FR_SSSMAIN
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

    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
    Main_Inf.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW

    '�����t�H�[�J�X�ʒu�ݒ�
    Call F_Init_Cursor_Set(Main_Inf)

' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
    gv_bolKNGMT51_LF_Enable = True
' === 20060801 === INSERT E

    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
    
    gv_bolKNGMT51_INIT = False

    '���̓R���g���[���̎g�p�ې���
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click

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
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '��ʓ��e������
    Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

    '����̫����擾����
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click

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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̕�������
    Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)

    '�I����Ԃ̐ݒ�i�����I���j
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)

    '���ڐF�ݒ�
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

'�r���������������������������������������������������������r
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

    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̏���������
    Call SSSMAIN0001.CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteDE_Click
    '   �T�v�F  ���׍s�폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̍폜����
    Call SSSMAIN0001.CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_InsertDE_Click
    '   �T�v�F  ���׍s�}��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̑}������
    Call SSSMAIN0001.CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoDe_Click
    '   �T�v�F  ���׍s����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoDe_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̕�������
    Call SSSMAIN0001.CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

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
    '   ���́F  Function Ctl_MN_Copy_Click
    '   �T�v�F  �R�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̃R�s�[
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_SelectCm_Click
    '   �T�v�F  �ꗗ�\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SelectCm_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  �E�B���h�E�\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer
'�r���������������������������������������������������������r
    Call F_Ctl_CS(Main_Inf)
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UPDKB_Click
    '   �T�v�F  ���[�h�ύX
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UPDKB_Click() As Integer
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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_PREV_Click
    '   �T�v�F  ���ׂ̑O�y�[�W��\��
    '   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_PREV_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer
    
    If NowPageNum > MinPageNum Then
    ''�\������Ă��閾�ׂ�2�y�[�W�ڈȍ~�Ȃ�O�y�[�W��\��

        intRet = F_Ctl_Upd_Process2(Main_Inf)
        If intRet = 0 Then
            '�ŏ㖾�׃C���f�b�N�X�̑ޔ�
            Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
            
            '��ʃ{�f�B��������
            Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
            '�f�[�^�Ď擾
'CHG START FKS)INABA 2009/10/08 ********************************
'�A���[��FC09101403
            Call F_GET_BD_DATA(Main_Inf, "Ctl_CM_PREV_Click")
'            Call F_GET_BD_DATA(Main_Inf)
'CHG  END  FKS)INABA 2009/10/08 ********************************
            '�ŏ㖾�׃C���f�b�N�X��߂�
            Main_Inf.Dsp_Body_Inf.Cur_Top_Index = Wk_Cur_Top_Index
        
            NowPageNum = NowPageNum - 1
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)
        
            Call F_Cursor_Set(pm_All)
            
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CM_NEXTCM_Click
    '   �T�v�F  ���ׂ̎��y�[�W��\��
    '   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
    '           pm_all              :�S�\����
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_NEXTCM_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer

    If NowPageNum < MaxPageNum Then
    '�\������Ă��閾�ׂ��ő�y�[�W�ԍ��łȂ��Ȃ玟�y�[�W��\��

        intRet = F_Ctl_Upd_Process2(Main_Inf)
        If intRet = 0 Then
            '�ŏ㖾�׃C���f�b�N�X�̑ޔ�
            Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
            
            '��ʃ{�f�B��������
            Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
            '�f�[�^�Ď擾
'CHG START FKS)INABA 2009/10/08 ********************************
'�A���[��FC09101403
            Call F_GET_BD_DATA(Main_Inf, "Ctl_CM_NEXTCM_Click")
'            Call F_GET_BD_DATA(Main_Inf)
'CHG  END  FKS)INABA 2009/10/08 ********************************
            '�ŏ㖾�׃C���f�b�N�X��߂�
            Main_Inf.Dsp_Body_Inf.Cur_Top_Index = Wk_Cur_Top_Index
            
            NowPageNum = NowPageNum + 1
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)
            
            Call F_Cursor_Set(pm_All)
            
        End If
        
    Else
    '���y�[�W���Ȃ��ꍇ�A���b�Z�[�W�\��
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_015, Main_Inf)
    End If

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
    '�t�H�[���^�C�g��
    FR_SSSMAIN.Caption = SSS_PrgNm

    Index_Wk = CInt(SYSDT.Tag)
    '��ʓ��t
' === 20060727 === UPDATE S
'    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
' === 20060727 === UPDATE E
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

    Const Hosei_Value   As Integer = -20

    Dim BD_UPDKB_Top    As Integer      '���[�h��Top
    Dim BD_UPDKB_Height As Integer      '���[�h��Height

    Dim Bd_Index        As Integer

    '�P�s�ڂ̃��[�h��Top��Height����Ƃ���
    BD_UPDKB_Top = BD_UPDKB(0).Top
    BD_UPDKB_Height = BD_UPDKB(0).Height + Hosei_Value

    '�\���ŏI�s�܂ŏ���
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        If Bd_Index >= 2 Then
        '�Q�s�ڈȍ~����
            '�z�u
            '���[�h
            BD_UPDKB(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�v���O�����h�c
            BD_PGID(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�v���O������
            BD_MEINMA(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/21  ADD START  KUMEDA
            '�N��
            BD_DATKB(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/21  ADD END
            '�X�V
            BD_UPDAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '���
            BD_PRTAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�t�@�C���o��
            BD_FILEAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�̔��P���ύX
            BD_SALTAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�����P���ύX
            BD_HDNTAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '�̔��v��N���v��C��
            BD_SAPMAUTH(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/15  ADD START  KUMEDA
            '�X�V�t���O
            BD_UPDATE(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/15  ADD END
        End If

        '�\��
        '���[�h
        BD_UPDKB(Bd_Index).Visible = True
        '�v���O�����h�c
        BD_PGID(Bd_Index).Visible = True
        '�v���O������
        BD_MEINMA(Bd_Index).Visible = True
' 2006/11/21  ADD START  KUMEDA
        '�N��
        BD_DATKB(Bd_Index).Visible = True
' 2006/11/21  ADD END
        '�X�V
        BD_UPDAUTH(Bd_Index).Visible = True
        '���
        BD_PRTAUTH(Bd_Index).Visible = True
        '�t�@�C���o��
        BD_FILEAUTH(Bd_Index).Visible = True
        '�̔��P���ύX
        BD_SALTAUTH(Bd_Index).Visible = True
        '�����P���ύX
        BD_HDNTAUTH(Bd_Index).Visible = True
        '�̔��v��N���v��C��
        BD_SAPMAUTH(Bd_Index).Visible = True
' 2006/11/15  ADD START  KUMEDA
        '�X�V�t���O
        BD_UPDATE(Bd_Index).Visible = False
' 2006/11/15  ADD END

    Next

End Function

'ADD START FKS)INABA 2009/10/08 ********
'�A���[��FC09101403
Private Sub MN_DeleteCM_Click()
    Call Ctl_Item_Click(MN_DeleteCM)

End Sub
'ADD  END  FKS)INABA 2009/10/08 ********

Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '��ʈ���N������TRUE�Ƃ���
    PP_SSSMAIN.Operable = True
    '����̫����ʒu�ݒ�s
    Call F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()

    'DB�ڑ�
    Call CF_Ora_USR1_Open

    '���ʏ���������
    Call CF_Init

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

    '���͒S���ҍX�V�����擾
    Call F_Get_Inp_KNG(Main_Inf)

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSMAIN)

    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    '���j���[�g�p�ې���
    Call F_Ctl_MN_Enabled(Main_Inf)

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)

    '��ʕҏW�Ȃ��Ƃ���
    gv_bolKNGMT51_INIT = False
    gv_bolInit = False
    gv_bolKNGMT51_LF_Enable = True

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    Dim intRet      As Integer
    Dim Col_Index   As Integer
    
    '�m�F���b�Z�[�W�\��
    If (gv_bolKNGMT51_INIT = True) And (pv_InpTan_KNG = True) Then
    '��ʍ��ڂɕύX������A�X�V����������ꍇ
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_013, Main_Inf)
    Else
    '��ʍ��ڂɕύX���Ȃ��A�܂��͍X�V�������Ȃ��ꍇ
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_006, Main_Inf)
    End If
    
    If intRet <> vbNo Then
    '������ʃN���[�Y
        Call F_Ctl_WLS_Close

        '���ʏI�������H
        Set FR_SSSMAIN = Nothing
        
    Else
        Cancel = True
        '�X�e�[�^�X�o�[������
        Call CF_Clr_Prompt(Main_Inf)

        Exit Sub
        
    End If
    
' === 20060907 === INSERT S
    Main_Inf.Dsp_Base.IsUnload = True
' === 20060907 === INSERT E
    
    'DB�ڑ�����
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
    
' 2006/11/15  ADD START  KUMEDA
    Call SSSWIN_LOGWRT("�v���O�����I��")
' 2006/11/15  ADD END

End Sub

Private Sub MN_Ctrl_Click()
    Debug.Print "MN_Ctrl_Click"
    Call Ctl_Item_Click(MN_Ctrl)
End Sub

Private Sub MN_EditMn_Click()
    Debug.Print "MN_EditMn_Click"
    Call Ctl_Item_Click(MN_EditMn)
End Sub

Private Sub MN_Oprt_Click()
    Debug.Print "MN_Oprt_Click"
    Call Ctl_Item_Click(MN_Oprt)
End Sub

Private Sub MN_Execute_Click()
    Debug.Print "MN_Execute_Click"
    Call Ctl_Item_Click(MN_Execute)
End Sub

Private Sub MN_EndCm_Click()
    Debug.Print "MN_EndCm_Click"
    Call Ctl_Item_Click(MN_EndCm)
End Sub

Private Sub MN_APPENDC_Click()
    Debug.Print "MN_APPENDC_Click"
    Call Ctl_Item_Click(MN_APPENDC)
End Sub

Private Sub MN_ClearItm_Click()
    Debug.Print "MN_ClearItm_Click"
    Call Ctl_Item_Click(MN_ClearItm)
End Sub

Private Sub MN_UnDoItem_Click()
    Debug.Print "MN_UnDoItem_Click"
    Call Ctl_Item_Click(MN_UnDoItem)
End Sub

Private Sub MN_ClearDE_Click()
    Debug.Print "MN_ClearDE_Click"
    Call Ctl_Item_Click(MN_ClearDE)
End Sub

Private Sub MN_DeleteDE_Click()
    Debug.Print "MN_DeleteDE_Click"
    Call Ctl_Item_Click(MN_DeleteDE)
End Sub

Private Sub MN_InsertDE_Click()
    Debug.Print "MN_InsertDE_Click"
    Call Ctl_Item_Click(MN_InsertDE)
End Sub

Private Sub MN_UnDoDe_Click()
    Debug.Print "MN_UnDoDe_Click"
    Call Ctl_Item_Click(MN_UnDoDe)
End Sub

Private Sub MN_Cut_Click()
    Debug.Print "MN_Cut_Click"
    Call Ctl_Item_Click(MN_Cut)
End Sub

Private Sub MN_Copy_Click()
    Debug.Print "MN_Copy_Click"
    Call Ctl_Item_Click(MN_Copy)
End Sub

Private Sub MN_Paste_Click()
    Debug.Print "MN_Paste_Click"
    Call Ctl_Item_Click(MN_Paste)
End Sub

Private Sub MN_Prev_Click()
    Debug.Print "MN_Prev_Click"
    Call Ctl_Item_Click(MN_Prev)
End Sub

Private Sub MN_NextCm_Click()
    Debug.Print "MN_NextCm_Click"
    Call Ctl_Item_Click(MN_NextCm)
End Sub

Private Sub MN_SelectCm_Click()
    Debug.Print "MN_SelectCm_Click"
    Call Ctl_Item_Click(MN_SelectCm)
End Sub

Private Sub MN_Slist_Click()
    Debug.Print "MN_Slist_Click"
    Call Ctl_Item_Click(MN_Slist)
End Sub

Private Sub MN_UPDKB_Click()
    Debug.Print "MN_UPDKB_Click"
    Call Ctl_Item_Click(MN_UPDKB)
End Sub

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub CM_Execute_Click()
    Debug.Print "CM_Execute_Click"
    Call Ctl_Item_Click(CM_Execute)
End Sub

Private Sub CM_INSERTDE_Click()
    Debug.Print "CM_INSERTDE_Click"
    Call Ctl_Item_Click(CM_INSERTDE)
End Sub

Private Sub CM_DELETEDE_Click()
    Debug.Print "CM_DELETEDE_Click"
    Call Ctl_Item_Click(CM_DELETEDE)
End Sub

Private Sub CM_SLIST_Click()
    Debug.Print "CM_SLIST_Click"
    Call Ctl_Item_Click(CM_SLIST)
End Sub

Private Sub CM_PREV_Click()
    Debug.Print "CM_PREV_Click"
    Call Ctl_Item_Click(CM_PREV)
End Sub

Private Sub CM_NEXTCm_Click()
    Debug.Print "CM_NEXTCm_Click"
    Call Ctl_Item_Click(CM_NEXTCm)
End Sub

Private Sub CM_SelectCm_Click()
    Debug.Print "MCM_SelectCm_Click"
    Call Ctl_Item_Click(CM_SelectCm)
End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseDown"
    Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_INSERTDE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_INSERTDE_MouseDown"
    Call Ctl_Item_MouseDown(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_DELETEDE_MouseDown"
    Call Ctl_Item_MouseDown(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseDown"
    Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_PREV_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PREV_MouseDown"
    Call Ctl_Item_MouseDown(CM_PREV, Button, Shift, X, Y)
End Sub

Private Sub CM_NEXTCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NEXTCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_NEXTCm, Button, Shift, X, Y)
End Sub

Private Sub CM_SelectCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SelectCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_SelectCm, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseMove"
    Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_INSERTDE_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_INSERTDE_MouseMove"
    Call Ctl_Item_MouseMove(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_DELETEDE_MouseMove"
    Call Ctl_Item_MouseMove(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseMove"
    Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_PREV_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PREV_MouseMove"
    Call Ctl_Item_MouseMove(CM_PREV, Button, Shift, X, Y)
End Sub

Private Sub CM_NEXTCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NEXTCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_NEXTCm, Button, Shift, X, Y)
End Sub

Private Sub CM_SelectCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SelectCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_SelectCm, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseUp"
    Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_INSERTDE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_INSERTDE_MouseUp"
    Call Ctl_Item_MouseUp(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_DELETEDE_MouseUp"
    Call Ctl_Item_MouseUp(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseUp"
    Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_PREV_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_PREV_MouseUp"
    Call Ctl_Item_MouseUp(CM_PREV, Button, Shift, X, Y)
End Sub

Private Sub CM_NEXTCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_NEXTCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_NEXTCm, Button, Shift, X, Y)
End Sub

Private Sub CM_SelectCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SelectCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_SelectCm, Button, Shift, X, Y)
End Sub

Private Sub SYSDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
' === 20060817 === DELETE S
'    Debug.Print "SYSDT_MouseDown"
'    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
' === 20060817 === DELETE E
End Sub

Private Sub SYSDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "SYSDT_MouseUp"
    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_Change()
    Debug.Print "HD_IN_TANCD_Change"
    Call Ctl_Item_Change(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_Change()
    Debug.Print "HD_IN_TANNM_Change"
    Call Ctl_Item_Change(HD_IN_TANNM)
End Sub

Private Sub HD_KNGGRCD_Change()
    Debug.Print "HD_KNGGRCD_Change"
    Call Ctl_Item_Change(HD_KNGGRCD)
End Sub

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_KNGGRCD_GotFocus()
    Debug.Print "HD_KNGGRCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_KNGGRCD)
End Sub

Private Sub HD_IN_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
End Sub

Private Sub HD_KNGGRCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_KNGGRCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_KNGGRCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub HD_KNGGRCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KNGGRCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_KNGGRCD, KeyAscii)
End Sub

Private Sub HD_IN_TANCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANNM)
End Sub

Private Sub HD_KNGGRCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_KNGGRCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_KNGGRCD)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub HD_KNGGRCD_LostFocus()
    Debug.Print "HD_KNGGRCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_KNGGRCD)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KNGGRCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KNGGRCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_KNGGRCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_KNGGRCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KNGGRCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_KNGGRCD, Button, Shift, X, Y)
End Sub

Private Sub BD_UPDKB_Change(Index As Integer)
    Debug.Print "BD_UPDKB_Change"
    Call Ctl_Item_Change(BD_UPDKB(Index))
End Sub

Private Sub BD_PGID_Change(Index As Integer)
    Debug.Print "BD_PGID_Change"
    Call Ctl_Item_Change(BD_PGID(Index))
End Sub

Private Sub BD_MEINMA_Change(Index As Integer)
    Debug.Print "BD_MEINMA_Change"
    Call Ctl_Item_Change(BD_MEINMA(Index))
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_Change(Index As Integer)
    Debug.Print "BD_DATKB_Change"
    Call Ctl_Item_Change(BD_DATKB(Index))
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_Change(Index As Integer)
    Debug.Print "BD_UPDAUTH_Change"
    Call Ctl_Item_Change(BD_UPDAUTH(Index))
End Sub

Private Sub BD_PRTAUTH_Change(Index As Integer)
    Debug.Print "BD_PRTAUTH_Change"
    Call Ctl_Item_Change(BD_PRTAUTH(Index))
End Sub

Private Sub BD_FILEAUTH_Change(Index As Integer)
    Debug.Print "BD_FILEAUTH_Change"
    Call Ctl_Item_Change(BD_FILEAUTH(Index))
End Sub

Private Sub BD_SALTAUTH_Change(Index As Integer)
    Debug.Print "BD_SALTAUTH_Change"
    Call Ctl_Item_Change(BD_SALTAUTH(Index))
End Sub

Private Sub BD_HDNTAUTH_Change(Index As Integer)
    Debug.Print "BD_HDNTAUTH_Change"
    Call Ctl_Item_Change(BD_HDNTAUTH(Index))
End Sub

Private Sub BD_SAPMAUTH_Change(Index As Integer)
    Debug.Print "BD_SAPMAUTH_Change"
    Call Ctl_Item_Change(BD_SAPMAUTH(Index))
End Sub

Private Sub BD_UPDKB_GotFocus(Index As Integer)
    Debug.Print "BD_UPDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_UPDKB(Index))
End Sub

Private Sub BD_PGID_GotFocus(Index As Integer)
    Debug.Print "BD_PGID_GotFocus"
    Call Ctl_Item_GotFocus(BD_PGID(Index))
End Sub

Private Sub BD_MEINMA_GotFocus(Index As Integer)
    Debug.Print "BD_MEINMA_GotFocus"
    Call Ctl_Item_GotFocus(BD_MEINMA(Index))
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_GotFocus(Index As Integer)
    Debug.Print "BD_DATKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_DATKB(Index))
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_UPDAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_UPDAUTH(Index))
End Sub

Private Sub BD_PRTAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_PRTAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_PRTAUTH(Index))
End Sub

Private Sub BD_FILEAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_FILEAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_FILEAUTH(Index))
End Sub

Private Sub BD_SALTAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_SALTAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_SALTAUTH(Index))
End Sub

Private Sub BD_HDNTAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_HDNTAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_HDNTAUTH(Index))
End Sub

Private Sub BD_SAPMAUTH_GotFocus(Index As Integer)
    Debug.Print "BD_SAPMAUTH_GotFocus"
    Call Ctl_Item_GotFocus(BD_SAPMAUTH(Index))
End Sub

Private Sub BD_UPDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_UPDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_PGID_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PGID_KeyDown"
    Call Ctl_Item_KeyDown(BD_PGID(Index), KEYCODE, Shift)
End Sub

Private Sub BD_MEINMA_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_MEINMA_KeyDown"
    Call Ctl_Item_KeyDown(BD_MEINMA(Index), KEYCODE, Shift)
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DATKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_DATKB(Index), KEYCODE, Shift)
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_UPDAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_PRTAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRTAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_PRTAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_FILEAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_FILEAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_FILEAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SALTAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SALTAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_SALTAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_HDNTAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HDNTAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_HDNTAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SAPMAUTH_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SAPMAUTH_KeyDown"
    Call Ctl_Item_KeyDown(BD_SAPMAUTH(Index), KEYCODE, Shift)
End Sub

Private Sub BD_UPDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UPDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_UPDKB(Index), KeyAscii)
End Sub

Private Sub BD_PGID_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_PGID_KeyPress"
    Call Ctl_Item_KeyPress(BD_PGID(Index), KeyAscii)
End Sub

Private Sub BD_MEINMA_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_MEINMA_KeyPress"
    Call Ctl_Item_KeyPress(BD_MEINMA(Index), KeyAscii)
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_DATKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_DATKB(Index), KeyAscii)
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UPDAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_UPDAUTH(Index), KeyAscii)
End Sub

Private Sub BD_PRTAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_PRTAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_PRTAUTH(Index), KeyAscii)
End Sub

Private Sub BD_FILEAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_FILEAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_FILEAUTH(Index), KeyAscii)
End Sub

Private Sub BD_SALTAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SALTAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_SALTAUTH(Index), KeyAscii)
End Sub

Private Sub BD_HDNTAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HDNTAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_HDNTAUTH(Index), KeyAscii)
End Sub

Private Sub BD_SAPMAUTH_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SAPMAUTH_KeyPress"
    Call Ctl_Item_KeyPress(BD_SAPMAUTH(Index), KeyAscii)
End Sub

Private Sub BD_UPDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_UPDKB(Index))
End Sub

Private Sub BD_PGID_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PGID_KeyUp"
    Call Ctl_Item_KeyUp(BD_PGID(Index))
End Sub

Private Sub BD_MEINMA_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_MEINMA_KeyUp"
    Call Ctl_Item_KeyUp(BD_MEINMA(Index))
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DATKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_DATKB(Index))
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_UPDAUTH(Index))
End Sub

Private Sub BD_PRTAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRTAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_PRTAUTH(Index))
End Sub

Private Sub BD_FILEAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_FILEAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_FILEAUTH(Index))
End Sub

Private Sub BD_SALTAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SALTAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_SALTAUTH(Index))
End Sub

Private Sub BD_HDNTAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HDNTAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_HDNTAUTH(Index))
End Sub

Private Sub BD_SAPMAUTH_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SAPMAUTH_KeyUp"
    Call Ctl_Item_KeyUp(BD_SAPMAUTH(Index))
End Sub

Private Sub BD_UPDKB_LostFocus(Index As Integer)
    Debug.Print "BD_UPDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_UPDKB(Index))
End Sub

Private Sub BD_PGID_LostFocus(Index As Integer)
    Debug.Print "BD_PGID_LostFocus"
    Call Ctl_Item_LostFocus(BD_PGID(Index))
End Sub

Private Sub BD_MEINMA_LostFocus(Index As Integer)
    Debug.Print "BD_MEINMA_LostFocus"
    Call Ctl_Item_LostFocus(BD_MEINMA(Index))
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_LostFocus(Index As Integer)
    Debug.Print "BD_DATKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_DATKB(Index))
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_UPDAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_UPDAUTH(Index))
End Sub

Private Sub BD_PRTAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_PRTAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_PRTAUTH(Index))
End Sub

Private Sub BD_FILEAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_FILEAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_FILEAUTH(Index))
End Sub

Private Sub BD_SALTAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_SALTAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_SALTAUTH(Index))
End Sub

Private Sub BD_HDNTAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_HDNTAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_HDNTAUTH(Index))
End Sub

Private Sub BD_SAPMAUTH_LostFocus(Index As Integer)
    Debug.Print "BD_SAPMAUTH_LostFocus"
    Call Ctl_Item_LostFocus(BD_SAPMAUTH(Index))
End Sub

Private Sub BD_UPDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_UPDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PGID_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PGID_MouseDown"
    Call Ctl_Item_MouseDown(BD_PGID(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_MEINMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_MEINMA_MouseDown"
    Call Ctl_Item_MouseDown(BD_MEINMA(Index), Button, Shift, X, Y)
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DATKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_DATKB(Index), Button, Shift, X, Y)
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_UPDAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRTAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRTAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_PRTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_FILEAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_FILEAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_FILEAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SALTAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SALTAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_SALTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HDNTAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HDNTAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_HDNTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SAPMAUTH_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SAPMAUTH_MouseDown"
    Call Ctl_Item_MouseDown(BD_SAPMAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UPDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_UPDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PGID_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PGID_MouseUp"
    Call Ctl_Item_MouseUp(BD_PGID(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_MEINMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_MEINMA_MouseUp"
    Call Ctl_Item_MouseUp(BD_MEINMA(Index), Button, Shift, X, Y)
End Sub

' 2006/11/21  ADD START  KUMEDA
Private Sub BD_DATKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DATKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_DATKB(Index), Button, Shift, X, Y)
End Sub
' 2006/11/21  ADD END

Private Sub BD_UPDAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_UPDAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRTAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRTAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_PRTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_FILEAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_FILEAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_FILEAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SALTAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SALTAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_SALTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HDNTAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HDNTAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_HDNTAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SAPMAUTH_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SAPMAUTH_MouseUp"
    Call Ctl_Item_MouseUp(BD_SAPMAUTH(Index), Button, Shift, X, Y)
End Sub

Private Sub TX_Message_Change()
    Debug.Print "TX_Message_Change"
    Call Ctl_Item_Change(TX_Message)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Message_KeyPress"
    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseUp"
    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub Image1_Click()
    Debug.Print "Image1_Click"
    Call Ctl_Item_Click(Image1)
End Sub

Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
' === 20060817 === DELETE S
'    Debug.Print "Image1_MouseDown"
'    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
' === 20060817 === DELETE E
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseUp"
    Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
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

Private Sub SM_ShortCut_Click()
'    Debug.Print "SM_ShortCut_Click"
'    Call Ctl_Item_Click(SM_ShortCut)
End Sub
