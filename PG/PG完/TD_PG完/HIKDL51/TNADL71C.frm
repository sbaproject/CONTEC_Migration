VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSSUB03 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�����󋵏Ɖ�"
   ClientHeight    =   8325
   ClientLeft      =   855
   ClientTop       =   1875
   ClientWidth     =   15270
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
      Size            =   12
      Charset         =   128
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "TNADL71C.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   8325
   ScaleWidth      =   15270
   Begin VB.TextBox BD_TRAKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   240
      MaxLength       =   24
      TabIndex        =   58
      Text            =   "MMMMMMM8"
      Top             =   2610
      Width           =   1005
   End
   Begin VB.TextBox BD_TRANO 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   1230
      MaxLength       =   14
      TabIndex        =   56
      Text            =   "XXXXXXXXX1xxxx"
      Top             =   2610
      Width           =   1695
   End
   Begin VB.TextBox BD_BUMNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   10350
      MaxLength       =   32
      TabIndex        =   54
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2610
      Width           =   1995
   End
   Begin VB.TextBox BD_TOKRN 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   8370
      MaxLength       =   32
      TabIndex        =   52
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMM3MM"
      Top             =   2610
      Width           =   1995
   End
   Begin VB.TextBox HD_STKDLVDT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   240
      MaxLength       =   17
      TabIndex        =   40
      Text            =   "9999/99/99"
      Top             =   1650
      Width           =   1275
   End
   Begin VB.TextBox HD_DLVSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   1500
      MaxLength       =   13
      TabIndex        =   39
      Text            =   "-999,999"
      Top             =   1650
      Width           =   1020
   End
   Begin VB.TextBox HD_HIKSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   2505
      MaxLength       =   13
      TabIndex        =   38
      Text            =   "-999,999"
      Top             =   1650
      Width           =   1020
   End
   Begin VB.TextBox HD_JOTAI 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   3510
      MaxLength       =   10
      TabIndex        =   37
      Text            =   "MMMMMMMMM1"
      Top             =   1650
      Width           =   950
   End
   Begin VB.TextBox HD_STKSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   4440
      MaxLength       =   13
      TabIndex        =   36
      Text            =   "-999,999"
      Top             =   1650
      Width           =   1020
   End
   Begin VB.TextBox HD_SZAISU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   5445
      MaxLength       =   13
      TabIndex        =   35
      Text            =   "-999,999"
      Top             =   1650
      Width           =   1020
   End
   Begin VB.TextBox HD_TOKRN 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   8970
      MaxLength       =   32
      TabIndex        =   34
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMM3MM"
      Top             =   1650
      Width           =   2355
   End
   Begin VB.TextBox HD_SOUNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11310
      MaxLength       =   32
      TabIndex        =   33
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1650
      Width           =   1335
   End
   Begin VB.TextBox HD_TOKJDNNO 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   12630
      MaxLength       =   23
      TabIndex        =   32
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXX"
      Top             =   1650
      Width           =   2535
   End
   Begin VB.TextBox HD_DENDT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   6450
      MaxLength       =   17
      TabIndex        =   31
      Text            =   "9999/99/99"
      Top             =   1650
      Width           =   1275
   End
   Begin VB.TextBox HD_SBNNO 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   7710
      MaxLength       =   14
      TabIndex        =   30
      Text            =   "XXXXXXXXX1xxxx"
      Top             =   1650
      Width           =   1275
   End
   Begin VB.TextBox BD_ATMNKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   6300
      MaxLength       =   24
      TabIndex        =   28
      Text            =   "MMMMMMM8"
      Top             =   2610
      Width           =   1005
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   375
      IMEMode         =   2  '��
      Left            =   46100
      TabIndex        =   27
      Top             =   48100
      Width           =   330
   End
   Begin VB.TextBox HD_HINCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   240
      MaxLength       =   17
      TabIndex        =   26
      Text            =   "XXXXXXXX10"
      Top             =   930
      Width           =   1200
   End
   Begin VB.TextBox HD_HINNMB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   4755
      MaxLength       =   50
      TabIndex        =   25
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   930
      Width           =   3360
   End
   Begin VB.TextBox HD_HINNMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   1440
      MaxLength       =   30
      TabIndex        =   24
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   930
      Width           =   3315
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Left            =   12165
      MaxLength       =   10
      TabIndex        =   19
      Text            =   "XXXXX6"
      Top             =   600
      Width           =   795
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12945
      MaxLength       =   24
      TabIndex        =   18
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   600
      Width           =   2205
   End
   Begin VB.TextBox BD_HIKSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   5220
      MaxLength       =   24
      TabIndex        =   14
      Text            =   "999,999 "
      Top             =   2610
      Width           =   1095
   End
   Begin VB.TextBox BD_SYUSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   4140
      MaxLength       =   24
      TabIndex        =   12
      Text            =   "999,999 "
      Top             =   2610
      Width           =   1095
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   4935
      Left            =   14325
      TabIndex        =   11
      Top             =   2610
      Width           =   270
   End
   Begin VB.TextBox BD_NYUSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   7290
      MaxLength       =   24
      TabIndex        =   8
      Text            =   "999,999 "
      Top             =   2610
      Width           =   1095
   End
   Begin VB.TextBox BD_TRADT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   2910
      MaxLength       =   12
      TabIndex        =   7
      Text            =   " 9999/99/99"
      Top             =   2610
      Width           =   1245
   End
   Begin VB.TextBox BD_SOUNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   12330
      MaxLength       =   20
      TabIndex        =   6
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2610
      Width           =   1995
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   25
      Left            =   12330
      TabIndex        =   5
      Top             =   2280
      Width           =   1995
      _ExtentX        =   3519
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
      Caption         =   "�q��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   26
      Left            =   -90
      TabIndex        =   2
      Top             =   7650
      Width           =   15390
      _ExtentX        =   27146
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
         Index           =   27
         Left            =   660
         TabIndex        =   3
         Top             =   120
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
            BeginProperty Font 
               Name            =   "�l�r �S�V�b�N"
               Size            =   9.75
               Charset         =   128
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            ForeColor       =   &H00000000&
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   4
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "TNADL71C.frx":030A
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   570
      Index           =   2
      Left            =   -120
      TabIndex        =   0
      Top             =   9345
      Width           =   13605
      _ExtentX        =   23998
      _ExtentY        =   1005
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
         BeginProperty Font 
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   555
         Left            =   12195
         TabIndex        =   1
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "TNADL71C.frx":0494
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "TNADL71C.frx":0AE6
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2925
         Picture         =   "TNADL71C.frx":1138
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2565
         Picture         =   "TNADL71C.frx":12C2
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "TNADL71C.frx":144C
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "TNADL71C.frx":15D6
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "TNADL71C.frx":1760
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "TNADL71C.frx":18EA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "TNADL71C.frx":1A74
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "TNADL71C.frx":1BFE
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "TNADL71C.frx":1D88
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "TNADL71C.frx":1F12
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "TNADL71C.frx":209C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "TNADL71C.frx":2226
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "TNADL71C.frx":23B0
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "TNADL71C.frx":253A
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   43380
      Top             =   43380
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   18
      Left            =   2910
      TabIndex        =   9
      Top             =   2280
      Width           =   1245
      _ExtentX        =   2196
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
      Caption         =   "���o�ɓ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   22
      Left            =   7290
      TabIndex        =   10
      Top             =   2280
      Width           =   1095
      _ExtentX        =   1931
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
      Caption         =   "���ɐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   19
      Left            =   4140
      TabIndex        =   13
      Top             =   2280
      Width           =   1095
      _ExtentX        =   1931
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
      Caption         =   "�o�ɐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   20
      Left            =   5220
      TabIndex        =   15
      Top             =   2280
      Width           =   1095
      _ExtentX        =   1931
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
      Caption         =   "������"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   0
      Left            =   0
      TabIndex        =   16
      Top             =   0
      Width           =   15390
      _ExtentX        =   27146
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
         TabIndex        =   17
         Top             =   90
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
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   195
         Picture         =   "TNADL71C.frx":26C4
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   7665
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   10920
      TabIndex        =   20
      Top             =   600
      Width           =   1260
      _ExtentX        =   2223
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
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   3
      Left            =   1440
      TabIndex        =   21
      Top             =   600
      Width           =   3315
      _ExtentX        =   5847
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
      Caption         =   "�^�@�@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   4
      Left            =   4755
      TabIndex        =   22
      Top             =   600
      Width           =   3360
      _ExtentX        =   5927
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
      Caption         =   "�i�@�@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   240
      TabIndex        =   23
      Top             =   600
      Width           =   1200
      _ExtentX        =   2117
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
      Caption         =   "���i����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   21
      Left            =   6300
      TabIndex        =   29
      Top             =   2280
      Width           =   1005
      _ExtentX        =   1773
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
      Caption         =   "���^��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   6
      Left            =   1500
      TabIndex        =   41
      Top             =   1320
      Width           =   1020
      _ExtentX        =   1799
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
      BevelOuter      =   1
      Caption         =   "�o��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   5
      Left            =   240
      TabIndex        =   42
      Top             =   1320
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
      BevelOuter      =   1
      Caption         =   "���o�ɓ�"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   7
      Left            =   2505
      TabIndex        =   43
      Top             =   1320
      Width           =   1020
      _ExtentX        =   1799
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
      BevelOuter      =   1
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   8
      Left            =   3510
      TabIndex        =   44
      Top             =   1320
      Width           =   950
      _ExtentX        =   1667
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
      BevelOuter      =   1
      Caption         =   "���"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   9
      Left            =   4440
      TabIndex        =   45
      Top             =   1320
      Width           =   1020
      _ExtentX        =   1799
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
      BevelOuter      =   1
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   10
      Left            =   5445
      TabIndex        =   46
      Top             =   1320
      Width           =   1020
      _ExtentX        =   1799
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
      BevelOuter      =   1
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   13
      Left            =   8970
      TabIndex        =   47
      Top             =   1320
      Width           =   2355
      _ExtentX        =   4154
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
      BevelOuter      =   1
      Caption         =   "���Ӑ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   14
      Left            =   11310
      TabIndex        =   48
      Top             =   1320
      Width           =   1335
      _ExtentX        =   2355
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
      BevelOuter      =   1
      Caption         =   "�q�@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   15
      Left            =   12630
      TabIndex        =   49
      Top             =   1320
      Width           =   2535
      _ExtentX        =   4471
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
      BevelOuter      =   1
      Caption         =   "�q�撍���ԍ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   11
      Left            =   6450
      TabIndex        =   50
      Top             =   1320
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
      BevelOuter      =   1
      Caption         =   "�o�^��"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   12
      Left            =   7710
      TabIndex        =   51
      Top             =   1320
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
      BevelOuter      =   1
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   23
      Left            =   8370
      TabIndex        =   53
      Top             =   2280
      Width           =   1995
      _ExtentX        =   3519
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
      BevelOuter      =   1
      Caption         =   "���Ӑ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   24
      Left            =   10350
      TabIndex        =   55
      Top             =   2280
      Width           =   1995
      _ExtentX        =   3519
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
      BevelOuter      =   1
      Caption         =   "�c�ƕ���"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   17
      Left            =   1230
      TabIndex        =   57
      Top             =   2280
      Width           =   1695
      _ExtentX        =   2990
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
      BevelOuter      =   1
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   16
      Left            =   240
      TabIndex        =   59
      Top             =   2280
      Width           =   1005
      _ExtentX        =   1773
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
      Caption         =   "���"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I��(&X)"
      End
   End
End
Attribute VB_Name = "FR_SSSSUB03"
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
Private Const FM_PANEL3D1_CNT       As Integer = 28 '�p�l���R���g���[����

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

    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                '��ʕ���
        .Item_Cnt = 202                             '��ʍ��ڐ�
        .Dsp_Body_Cnt = 15                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 99                          '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 10                          '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
        Set .FormCtl = FR_SSSSUB03
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
    '���i�R�[�h
    HD_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
'''' UPD 2009/02/19  FKS) S.Nakajima    Start
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
'''' UPD 2009/02/19  FKS) S.Nakajima    End
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�^��
    HD_HINNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���i��
    HD_HINNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 40
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 20
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
    '���o�ɓ�
    HD_STKDLVDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_STKDLVDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o��
    HD_DLVSU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DLVSU
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    HD_HIKSU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HIKSU
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���
    HD_JOTAI.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JOTAI
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
' === 20150928 === UPDATE S -
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
' === 20150928 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
' === 20150928 === UPDATE S -
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20150928 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    HD_STKSU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_STKSU
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    HD_SZAISU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SZAISU
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o�^��
    HD_DENDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DENDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    HD_SBNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
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
    '���Ӑ�
    HD_TOKRN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
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
    '�q��
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�q�撍���ԍ�
    HD_TOKJDNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKJDNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 23
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 23
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

    '///////////////
    '// �{�f�B���ҏW
    '///////////////
    Index_Wk = Index_Wk + 1
    '�c�X�N���[��
    VS_Scrl.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = VS_Scrl
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    '=== ���׏c�X�N���[���o�[�ݒ� ======================
    Set Main_Inf.Bd_Vs_Scrl = VS_Scrl
    '=== ���׏c�X�N���[���o�[�ݒ� ======================

    Index_Wk = Index_Wk + 1
    '���
    BD_TRAKB(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRAKB(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '����
    BD_TRANO(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRANO(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '���o�ɓ�
    BD_TRADT(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRADT(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o�ɐ�
    BD_SYUSU(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SYUSU(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '������
    BD_HIKSU(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���^��
    BD_ATMNKB(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ATMNKB(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ɐ�
    BD_NYUSU(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUSU(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '���Ӑ�
    BD_TOKRN(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�c�ƕ���
    BD_BUMNM(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BUMNM(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '�q��
    BD_SOUNM(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        Load BD_TRAKB(BD_Cnt)           '���
        Load BD_TRANO(BD_Cnt)           '����
        Load BD_TRADT(BD_Cnt)           '���o�ɓ�
        Load BD_SYUSU(BD_Cnt)           '�o��
        Load BD_HIKSU(BD_Cnt)           '����
        Load BD_ATMNKB(BD_Cnt)          '���^��
        Load BD_NYUSU(BD_Cnt)           '����
        Load BD_TOKRN(BD_Cnt)           '���Ӑ�
        Load BD_BUMNM(BD_Cnt)           '�c�ƕ���
        Load BD_SOUNM(BD_Cnt)           '�q��

        Index_Wk = Index_Wk + 1
        '���
        BD_TRAKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRAKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '����
        BD_TRANO(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRANO(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���o�ɓ�
        BD_TRADT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TRADT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�o��
        BD_SYUSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SYUSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '����
        BD_HIKSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���^��
        BD_ATMNKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ATMNKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '����
        BD_NYUSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
        
        Index_Wk = Index_Wk + 1
        '���Ӑ�
        BD_TOKRN(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�c�ƕ���
        BD_BUMNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BUMNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�q��
        BD_SOUNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

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
    Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
' === 20060905 === INSERT S - ACE)Hashiri  �G���^�[�L�[�A�łɂ��s��C��2
        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False
' === 20060905 === INSERT E -
    End If
    '�擾���e�\��/�N���A
    Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
        Call SSSMAIN0005.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20060804 === UPDATE S - ACE)Nagasawa
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20060804 === UPDATE E -
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

    'KEYRIGHT����
    Call SSSMAIN0005.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call SSSMAIN0005.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
    Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYDOWN����
        Call SSSMAIN0005.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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

    'KEYLEFT����
    Call SSSMAIN0005.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call SSSMAIN0005.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
    Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0005.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYUP����
        Call SSSMAIN0005.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If

    Else
    '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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

' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
    'Enter���̂݃t���O��ON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If
            
        gv_bolKeyFlg = True
    End If
' === 20060802 === INSERT E -

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
''        '��������
''        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
''            pm_KeyCode = 0
''            '����������
''            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        '����
''        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
''            pm_KeyCode = 0
''            '������
''            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        '����
''        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
''            pm_KeyCode = 0
''            '������
''            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        '����
''        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
''            pm_KeyCode = 0
''            '������
''            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        '����
''        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
''            '������
''            pm_KeyCode = 0
''            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        'DELETE��
''        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
''            pm_KeyCode = 0
''            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
''
''        'INSERT��
''        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
''            pm_KeyCode = 0
''            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
''
''        'TAB��
''        Case pm_KeyCode = vbKeyF16
''            pm_KeyCode = 0
''            '����������
''            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))
''
''        'Shift+TAB��
''        Case pm_KeyCode = vbKeyF15
''            pm_KeyCode = 0
''            '�O̫����ʒu�ֈړ�
''            Call SSSMAIN0005.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

        '�t�@���N�V�����L�[������
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
    End Select
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyUp
    '   �T�v�F  �e���ڂ�CLICK����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Act_Index   As Integer

    '�������ޯ���擾
    Act_Index = CInt(pm_Ctl.Tag)

' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
' === 20060802 === INSERT E -

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060920 === UPDATE S - ACE)Sejima
'DPrivate Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer
' === 20060920 === UPDATE ��
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Boolean
' === 20060920 === UPDATE E

    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '����̫������۰َ擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '۽�̫������s����
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
    
    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0005.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        '������ړ�����
        Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

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

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '��ʒP�ʂ̏���(�����Ȃ�)
    '���ו��ł��ړ��O�����ו��łȂ��ꍇ
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
'�r���������������������������������������������������������r
        'ͯ�ޕ�����
        Rtn_Chk = SSSMAIN0005.F_Ctl_Head_Chk(Main_Inf)
'�d���������������������������������������������������������d
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If

'�r���������������������������������������������������������r
    '����̫����擾����
    Call SSSMAIN0005.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
    Call SSSMAIN0005.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0005.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0005.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then

            '����̫����ʒu����E�ֈړ�
            Call SSSMAIN0005.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
        Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
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
    Call SSSMAIN0005.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call SSSMAIN0005.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                
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
' === 20060926 === UPDATE S - ACE)Nagasawa �K�C�h���b�Z�[�W�̕ύX
'            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)
            Call CF_Set_Prompt(IMG_ENDCM_SUB_MSG_INF, COLOR_BLACK, Main_Inf)
' === 20060926 === UPDATE E -

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
    Dim Act_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)
        
    End Select

    '����MOUSEDOWN����
    Call SSSMAIN0005.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

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

'�r���������������������������������������������������������r
    '�e������ʌďo
    Select Case Trg_Index
        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click

'�����j���[�C���[�W
        Case CInt(CM_EndCm.Tag)
            '�I��
            Unload Me

    End Select
'�d���������������������������������������������������������d

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
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)
     
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
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EditMn_Click
    '   �T�v�F  ���j���[����R�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

    Dim Ant_Index   As Integer
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  ���s
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_HARDCOPY_Click
    '   �T�v�F  ��ʈ��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer

    Dim wk_Cursor As Integer
    
    'Operable=TRUE�̎��̂�ok
    If PP_SSSMAIN.Operable = False Then
        Exit Function
    End If
    '�n�[�h�R�s�[�C�x���g���s
    If SSSMAIN_Hardcopy_Getevent() Then
        wk_Cursor = SSSMAIN0005.AE_Hardcopy_SSSMAIN()
    End If

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
    Unload FR_SSSSUB03
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

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoItem_Click
    '   �T�v�F  ���ڕ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoItem_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Cut_Click
    '   �T�v�F  �؂���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Cut_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Copy_Click
    '   �T�v�F  �R�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Paste_Click
    '   �T�v�F  �\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Paste_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_SELECTCM_Click
    '   �T�v�F  �I��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SELECTCM_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_PREV_Click
    '   �T�v�F  �O��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_PREV_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_NEXTCM_Click
    '   �T�v�F  ����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_NEXTCM_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  ���̈ꗗ
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_AllCopy_Click
    '   �T�v�F  ���ړ��e�ɃR�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_AllCopy_Click() As Integer

    '���ړ��e�ɃR�s�[
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_Esc_Click
    '   �T�v�F  ������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer

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
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

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

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '����VS_SCRL_CHANGE����
    Call SSSMAIN0005.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

End Function

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    Main_Inf.Dsp_Base.IsUnload = True
    
    '���ʏI�������H
    Set FR_SSSSUB03 = Nothing
    
'ADD 20151007
    If SSS_PrgId <> "HIKDL51" Then
'ADD 20151007
    FR_SSSMAIN.Show
'ADD 20151007
    End If
'ADD 20151007

End Sub

Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '��ʈ���N������TRUE�Ƃ���
    PP_SSSMAIN.Operable = True
    '����̫����ʒu�ݒ�
    Call SSSMAIN0005.F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()

    '��ʏ��ݒ�
    Call Init_Def_Dsp
    
    '��ʓ��e������
    Call SSSMAIN0005.F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʖ��׏��ݒ�
    Call Init_Def_Body_Inf

    '��ʖ��ו�������
    Call SSSMAIN0005.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '���׃��P�[�V����
    Call Set_Body_Location

    '�����\���ҏW
    Call Edi_Dsp_Def
    
    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSSUB03)
    
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSSUB03, Main_Inf)
    
    '�{�f�B���ҏW_�T�u�Ɖ��ʗp
    Call SSSMAIN0005.F_DSP_BD_Inf_SUB(0, Main_Inf)
    
    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

    '��ʐF�ݒ�
    Call SSSMAIN0005.CF_Set_BD_Color(Main_Inf)

End Sub

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
    Dim strSYSDT        As String

'�r���������������������������������������������������������r
    Index_Wk = CInt(SYSDT.Tag)
    '��ʓ��t
'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
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

    Dim BD_TRAKB_Top    As Integer
    Dim BD_TRAKB_Height As Integer

    Dim Bd_Index        As Integer

    '�P�s�ڂ�No��Top��Height����Ƃ���
    BD_TRAKB_Top = BD_TRAKB(1).Top
    BD_TRAKB_Height = BD_TRAKB(1).Height + Hosei_Value

    '�\���ŏI�s�܂ŏ���
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        If Bd_Index >= 2 Then
        '�Q�s�ڈȍ~����
            '�z�u
            BD_TRAKB(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_TRANO(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_TRADT(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_SYUSU(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_HIKSU(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_ATMNKB(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_NYUSU(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_TOKRN(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_BUMNM(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
            BD_SOUNM(Bd_Index).Top = BD_TRAKB_Top + BD_TRAKB_Height * (Bd_Index - 1)
        End If

        '�\��
        BD_TRAKB(Bd_Index).Visible = True
        BD_TRANO(Bd_Index).Visible = True
        BD_TRADT(Bd_Index).Visible = True
        BD_SYUSU(Bd_Index).Visible = True
        BD_HIKSU(Bd_Index).Visible = True
        BD_ATMNKB(Bd_Index).Visible = True
        BD_NYUSU(Bd_Index).Visible = True
        BD_TOKRN(Bd_Index).Visible = True
        BD_BUMNM(Bd_Index).Visible = True
        BD_SOUNM(Bd_Index).Visible = True

    Next

    '�X�N���[���o�[�̐ݒ�
    Main_Inf.Bd_Vs_Scrl.Top = BD_TRAKB_Top
    Main_Inf.Bd_Vs_Scrl.Height = BD_TRAKB_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt

'�d���������������������������������������������������������d

End Function

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub Image1_Click()
    Debug.Print "Image1_Click"
    Call Ctl_Item_Click(Image1)
End Sub

Private Sub MN_Ctrl_Click()
    Debug.Print "MN_Ctrl_Click"
    Call Ctl_Item_Click(MN_Ctrl)
End Sub

Private Sub MN_EndCm_Click()
    Debug.Print "MN_EndCm_Click"
    Call Ctl_Item_Click(MN_EndCm)
End Sub

Private Sub BD_TRKBN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRAKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_TRAKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TRANO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRANO_MouseDown"
    Call Ctl_Item_MouseDown(BD_TRANO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TRADT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRADT_MouseDown"
    Call Ctl_Item_MouseDown(BD_TRADT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SYUSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SYUSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_SYUSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HIKSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HIKSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ATMNKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ATMNKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_ATMNKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_NYUSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_NYUSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_NYUSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TOKRN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKRN_MouseDown"
    Call Ctl_Item_MouseDown(BD_TOKRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_BUMNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_BUMNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_BUMNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_SOUNM(Index), Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub HD_HINCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMB_MouseDown"
    Call Ctl_Item_MouseDown(HD_HINNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_STKDLVDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_STKDLVDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_STKDLVDT, Button, Shift, X, Y)
End Sub

Private Sub HD_DLVSU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DLVSU_MouseDown"
    Call Ctl_Item_MouseDown(HD_DLVSU, Button, Shift, X, Y)
End Sub

Private Sub HD_HIKSU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HIKSU_MouseDown"
    Call Ctl_Item_MouseDown(HD_HIKSU, Button, Shift, X, Y)
End Sub

Private Sub HD_JOTAI_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JOTAI_MouseDown"
    Call Ctl_Item_MouseDown(HD_JOTAI, Button, Shift, X, Y)
End Sub

Private Sub HD_STKSU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_STKSU_MouseDown"
    Call Ctl_Item_MouseDown(HD_STKSU, Button, Shift, X, Y)
End Sub

Private Sub HD_SZAISU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SZAISU_MouseDown"
    Call Ctl_Item_MouseDown(HD_SZAISU, Button, Shift, X, Y)
End Sub

Private Sub HD_DENDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DENDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_DENDT, Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_SOUNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKJDNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKJDNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKJDNNO, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseDown"
    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub BD_TRAKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRAKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_TRAKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TRANO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRANO_MouseUp"
    Call Ctl_Item_MouseUp(BD_TRANO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TRADT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TRADT_MouseUp"
    Call Ctl_Item_MouseUp(BD_TRADT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SYUSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SYUSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_SYUSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HIKSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HIKSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ATMNKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ATMNKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_ATMNKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_NYUSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_NYUSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_NYUSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TOKRN_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKRN_MouseUp"
    Call Ctl_Item_MouseUp(BD_TOKRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_BUMNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_BUMNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_BUMNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_SOUNM(Index), Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_HINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_HINNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HINNMB_MouseUp"
    Call Ctl_Item_MouseUp(HD_HINNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_STKDLVDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_STKDLVDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_STKDLVDT, Button, Shift, X, Y)
End Sub

Private Sub HD_DLVSU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DLVSU_MouseUp"
    Call Ctl_Item_MouseUp(HD_DLVSU, Button, Shift, X, Y)
End Sub

Private Sub HD_HIKSU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_HIKSU_MouseUp"
    Call Ctl_Item_MouseUp(HD_HIKSU, Button, Shift, X, Y)
End Sub

Private Sub HD_JOTAI_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JOTAI_MouseUp"
    Call Ctl_Item_MouseUp(HD_JOTAI, Button, Shift, X, Y)
End Sub

Private Sub HD_STKSU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_STKSU_MouseUp"
    Call Ctl_Item_MouseUp(HD_STKSU, Button, Shift, X, Y)
End Sub

Private Sub HD_SZAISU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SZAISU_MouseUp"
    Call Ctl_Item_MouseUp(HD_SZAISU, Button, Shift, X, Y)
End Sub

Private Sub HD_DENDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DENDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_DENDT, Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_SOUNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKJDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKJDNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKJDNNO, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseUp"
    Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
End Sub

Private Sub SYSDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "SYSDT_MouseUp"
    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseUp"
    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub BD_TRAKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRAKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_TRAKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_TRANO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRANO_KeyDown"
    Call Ctl_Item_KeyDown(BD_TRANO(Index), KEYCODE, Shift)
End Sub

Private Sub BD_TRADT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRADT_KeyDown"
    Call Ctl_Item_KeyDown(BD_TRADT(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SYUSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SYUSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_SYUSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_HIKSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HIKSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_HIKSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_ATMNKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ATMNKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_ATMNKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_NYUSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_NYUSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_NYUSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_TOKRN_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TOKRN_KeyDown"
    Call Ctl_Item_KeyDown(BD_TOKRN(Index), KEYCODE, Shift)
End Sub

Private Sub BD_BUMNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_BUMNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_BUMNM(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SOUNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
End Sub

Private Sub HD_HINCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINCD, KEYCODE, Shift)
End Sub

Private Sub HD_HINNMA_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINNMA, KEYCODE, Shift)
End Sub

Private Sub HD_HINNMB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMB_KeyDown"
    Call Ctl_Item_KeyDown(HD_HINNMB, KEYCODE, Shift)
End Sub

Private Sub HD_STKDLVDT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_STKDLVDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_STKDLVDT, KEYCODE, Shift)
End Sub

Private Sub HD_DLVSU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DLVSU_KeyDown"
    Call Ctl_Item_KeyDown(HD_DLVSU, KEYCODE, Shift)
End Sub

Private Sub HD_HIKSU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HIKSU_KeyDown"
    Call Ctl_Item_KeyDown(HD_HIKSU, KEYCODE, Shift)
End Sub

Private Sub HD_JOTAI_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_JOTAI_KeyDown"
    Call Ctl_Item_KeyDown(HD_JOTAI, KEYCODE, Shift)
End Sub

Private Sub HD_STKSU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_STKSU_KeyDown"
    Call Ctl_Item_KeyDown(HD_STKSU, KEYCODE, Shift)
End Sub

Private Sub HD_SZAISU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SZAISU_KeyDown"
    Call Ctl_Item_KeyDown(HD_SZAISU, KEYCODE, Shift)
End Sub

Private Sub HD_DENDT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DENDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_DENDT, KEYCODE, Shift)
End Sub

Private Sub HD_SBNNO_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
End Sub

Private Sub HD_TOKRN_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKRN, KEYCODE, Shift)
End Sub

Private Sub HD_SOUNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SOUNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_SOUNM, KEYCODE, Shift)
End Sub

Private Sub HD_TOKJDNNO_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKJDNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKJDNNO, KEYCODE, Shift)
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
End Sub

Private Sub BD_TRAKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TRAKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_TRAKB(Index), KeyAscii)
End Sub

Private Sub BD_TRANO_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TRANO_KeyPress"
    Call Ctl_Item_KeyPress(BD_TRANO(Index), KeyAscii)
End Sub

Private Sub BD_TRADT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TRADT_KeyPress"
    Call Ctl_Item_KeyPress(BD_TRADT(Index), KeyAscii)
End Sub

Private Sub BD_SYUSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SYUSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_SYUSU(Index), KeyAscii)
End Sub

Private Sub BD_HIKSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HIKSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_HIKSU(Index), KeyAscii)
End Sub

Private Sub BD_ATMNKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_ATMNKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_ATMNKB(Index), KeyAscii)
End Sub

Private Sub BD_NYUSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_NYUSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_NYUSU(Index), KeyAscii)
End Sub

Private Sub BD_TOKRN_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TOKRN_KeyPress"
    Call Ctl_Item_KeyPress(BD_TOKRN(Index), KeyAscii)
End Sub

Private Sub BD_BUMNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_BUMNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_BUMNM(Index), KeyAscii)
End Sub

Private Sub BD_SOUNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SOUNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_SOUNM(Index), KeyAscii)
End Sub

Private Sub HD_HINCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINCD, KeyAscii)
End Sub

Private Sub HD_HINNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINNMA, KeyAscii)
End Sub

Private Sub HD_HINNMB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HINNMB_KeyPress"
    Call Ctl_Item_KeyPress(HD_HINNMB, KeyAscii)
End Sub

Private Sub HD_STKDLVDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_STKDLVDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_STKDLVDT, KeyAscii)
End Sub

Private Sub HD_DLVSU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_DLVSU_KeyPress"
    Call Ctl_Item_KeyPress(HD_DLVSU, KeyAscii)
End Sub

Private Sub HD_HIKSU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_HIKSU_KeyPress"
    Call Ctl_Item_KeyPress(HD_HIKSU, KeyAscii)
End Sub

Private Sub HD_JOTAI_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JOTAI_KeyPress"
    Call Ctl_Item_KeyPress(HD_JOTAI, KeyAscii)
End Sub

Private Sub HD_STKSU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_STKSU_KeyPress"
    Call Ctl_Item_KeyPress(HD_STKSU, KeyAscii)
End Sub

Private Sub HD_SZAISU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SZAISU_KeyPress"
    Call Ctl_Item_KeyPress(HD_SZAISU, KeyAscii)
End Sub

Private Sub HD_DENDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_DENDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_DENDT, KeyAscii)
End Sub

Private Sub HD_SBNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SBNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
End Sub

Private Sub HD_TOKRN_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKRN_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKRN, KeyAscii)
End Sub

Private Sub HD_SOUNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SOUNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_SOUNM, KeyAscii)
End Sub

Private Sub HD_TOKJDNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKJDNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKJDNNO, KeyAscii)
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Message_KeyPress"
    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
End Sub

Private Sub BD_TRAKB_GotFocus(Index As Integer)
    Debug.Print "BD_TRAKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_TRAKB(Index))
End Sub

Private Sub BD_TRANO_GotFocus(Index As Integer)
    Debug.Print "BD_TRANO_GotFocus"
    Call Ctl_Item_GotFocus(BD_TRANO(Index))
End Sub

Private Sub BD_TRADT_GotFocus(Index As Integer)
    Debug.Print "BD_TRADT_GotFocus"
    Call Ctl_Item_GotFocus(BD_TRADT(Index))
End Sub

Private Sub BD_SYUSU_GotFocus(Index As Integer)
    Debug.Print "BD_SYUSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_SYUSU(Index))
End Sub

Private Sub BD_HIKSU_GotFocus(Index As Integer)
    Debug.Print "BD_HIKSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_HIKSU(Index))
End Sub

Private Sub BD_ATMNKB_GotFocus(Index As Integer)
    Debug.Print "BD_ATMNKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_ATMNKB(Index))
End Sub

Private Sub BD_NYUSU_GotFocus(Index As Integer)
    Debug.Print "BD_NYUSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_NYUSU(Index))
End Sub

Private Sub BD_TOKRN_GotFocus(Index As Integer)
    Debug.Print "BD_TOKRN_GotFocus"
    Call Ctl_Item_GotFocus(BD_TOKRN(Index))
End Sub

Private Sub BD_BUMNM_GotFocus(Index As Integer)
    Debug.Print "BD_BUMNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_BUMNM(Index))
End Sub

Private Sub BD_SOUNM_GotFocus(Index As Integer)
    Debug.Print "BD_SOUNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_SOUNM(Index))
End Sub

Private Sub HD_HINCD_GotFocus()
    Debug.Print "HD_HINCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINCD)
End Sub

Private Sub HD_HINNMA_GotFocus()
    Debug.Print "HD_HINNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_GotFocus()
    Debug.Print "HD_HINNMB_GotFocus"
    Call Ctl_Item_GotFocus(HD_HINNMB)
End Sub

Private Sub HD_STKDLVDT_GotFocus()
    Debug.Print "HD_STKDLVDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_STKDLVDT)
End Sub

Private Sub HD_DLVSU_GotFocus()
    Debug.Print "HD_DLVSU_GotFocus"
    Call Ctl_Item_GotFocus(HD_DLVSU)
End Sub

Private Sub HD_HIKSU_GotFocus()
    Debug.Print "HD_HIKSU_GotFocus"
    Call Ctl_Item_GotFocus(HD_HIKSU)
End Sub

Private Sub HD_JOTAI_GotFocus()
    Debug.Print "HD_JOTAI_GotFocus"
    Call Ctl_Item_GotFocus(HD_JOTAI)
End Sub

Private Sub HD_STKSU_GotFocus()
    Debug.Print "HD_STKSU_GotFocus"
    Call Ctl_Item_GotFocus(HD_STKSU)
End Sub

Private Sub HD_SZAISU_GotFocus()
    Debug.Print "HD_SZAISU_GotFocus"
    Call Ctl_Item_GotFocus(HD_SZAISU)
End Sub

Private Sub HD_DENDT_GotFocus()
    Debug.Print "HD_DENDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_DENDT)
End Sub

Private Sub HD_SBNNO_GotFocus()
    Debug.Print "HD_SBNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_SBNNO)
End Sub

Private Sub HD_TOKRN_GotFocus()
    Debug.Print "HD_TOKRN_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKRN)
End Sub

Private Sub HD_SOUNM_GotFocus()
    Debug.Print "HD_SOUNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_SOUNM)
End Sub

Private Sub HD_TOKJDNNO_GotFocus()
    Debug.Print "HD_TOKJDNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKJDNNO)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub BD_TRAKB_LostFocus(Index As Integer)
    Debug.Print "BD_TRAKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_TRAKB(Index))
End Sub

Private Sub BD_TRANO_LostFocus(Index As Integer)
    Debug.Print "BD_TRANO_LostFocus"
    Call Ctl_Item_LostFocus(BD_TRANO(Index))
End Sub

Private Sub BD_TRADT_LostFocus(Index As Integer)
    Debug.Print "BD_TRADT_LostFocus"
    Call Ctl_Item_LostFocus(BD_TRADT(Index))
End Sub

Private Sub BD_SYUSU_LostFocus(Index As Integer)
    Debug.Print "BD_SYUSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_SYUSU(Index))
End Sub

Private Sub BD_HIKSU_LostFocus(Index As Integer)
    Debug.Print "BD_HIKSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_HIKSU(Index))
End Sub

Private Sub BD_ATMNKB_LostFocus(Index As Integer)
    Debug.Print "BD_ATMNKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_ATMNKB(Index))
End Sub

Private Sub BD_NYUSU_LostFocus(Index As Integer)
    Debug.Print "BD_NYUSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_NYUSU(Index))
End Sub

Private Sub BD_TOKRN_LostFocus(Index As Integer)
    Debug.Print "BD_TOKRN_LostFocus"
    Call Ctl_Item_LostFocus(BD_TOKRN(Index))
End Sub

Private Sub BD_BUMNM_LostFocus(Index As Integer)
    Debug.Print "BD_BUMNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_BUMNM(Index))
End Sub

Private Sub BD_SOUNM_LostFocus(Index As Integer)
    Debug.Print "BD_SOUNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_SOUNM(Index))
End Sub

Private Sub HD_HINCD_LostFocus()
    Debug.Print "HD_HINCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINCD)
End Sub

Private Sub HD_HINNMA_LostFocus()
    Debug.Print "HD_HINNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_LostFocus()
    Debug.Print "HD_HINNMB_LostFocus"
    Call Ctl_Item_LostFocus(HD_HINNMB)
End Sub

Private Sub HD_STKDLVDT_LostFocus()
    Debug.Print "HD_STKDLVDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_STKDLVDT)
End Sub

Private Sub HD_DLVSU_LostFocus()
    Debug.Print "HD_DLVSU_LostFocus"
    Call Ctl_Item_LostFocus(HD_DLVSU)
End Sub

Private Sub HD_HIKSU_LostFocus()
    Debug.Print "HD_HIKSU_LostFocus"
    Call Ctl_Item_LostFocus(HD_HIKSU)
End Sub

Private Sub HD_JOTAI_LostFocus()
    Debug.Print "HD_JOTAI_LostFocus"
    Call Ctl_Item_LostFocus(HD_JOTAI)
End Sub

Private Sub HD_STKSU_LostFocus()
    Debug.Print "HD_STKSU_LostFocus"
    Call Ctl_Item_LostFocus(HD_STKSU)
End Sub

Private Sub HD_SZAISU_LostFocus()
    Debug.Print "HD_SZAISU_LostFocus"
    Call Ctl_Item_LostFocus(HD_SZAISU)
End Sub

Private Sub HD_DENDT_LostFocus()
    Debug.Print "HD_DENDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_DENDT)
End Sub

Private Sub HD_SBNNO_LostFocus()
    Debug.Print "HD_SBNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_SBNNO)
End Sub

Private Sub HD_TOKRN_LostFocus()
    Debug.Print "HD_TOKRN_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKRN)
End Sub

Private Sub HD_SOUNM_LostFocus()
    Debug.Print "HD_SOUNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_SOUNM)
End Sub

Private Sub HD_TOKJDNNO_LostFocus()
    Debug.Print "HD_TOKJDNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKJDNNO)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub BD_TRAKB_Change(Index As Integer)
    Debug.Print "BD_TRAKB_Change"
    Call Ctl_Item_Change(BD_TRAKB(Index))
End Sub

Private Sub BD_TRANO_Change(Index As Integer)
    Debug.Print "BD_TRANO_Change"
    Call Ctl_Item_Change(BD_TRANO(Index))
End Sub

Private Sub BD_TRADT_Change(Index As Integer)
    Debug.Print "BD_TRADT_Change"
    Call Ctl_Item_Change(BD_TRADT(Index))
End Sub

Private Sub BD_SYUSU_Change(Index As Integer)
    Debug.Print "BD_SYUSU_Change"
    Call Ctl_Item_Change(BD_SYUSU(Index))
End Sub

Private Sub BD_HIKSU_Change(Index As Integer)
    Debug.Print "BD_HIKSU_Change"
    Call Ctl_Item_Change(BD_HIKSU(Index))
End Sub

Private Sub BD_ATMNKB_Change(Index As Integer)
    Debug.Print "BD_ATMNKB_Change"
    Call Ctl_Item_Change(BD_ATMNKB(Index))
End Sub

Private Sub BD_NYUSU_Change(Index As Integer)
    Debug.Print "BD_NYUSU_Change"
    Call Ctl_Item_Change(BD_NYUSU(Index))
End Sub

Private Sub BD_TOKRN_Change(Index As Integer)
    Debug.Print "BD_TOKRN_Change"
    Call Ctl_Item_Change(BD_TOKRN(Index))
End Sub

Private Sub BD_BUMNM_Change(Index As Integer)
    Debug.Print "BD_BUMNM_Change"
    Call Ctl_Item_Change(BD_BUMNM(Index))
End Sub

Private Sub BD_SOUNM_Change(Index As Integer)
    Debug.Print "BD_SOUNM_Change"
    Call Ctl_Item_Change(BD_SOUNM(Index))
End Sub

Private Sub HD_HINCD_Change()
    Debug.Print "HD_HINCD_Change"
    Call Ctl_Item_Change(HD_HINCD)
End Sub

Private Sub HD_HINNMA_Change()
    Debug.Print "HD_HINNMA_Change"
    Call Ctl_Item_Change(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_Change()
    Debug.Print "HD_HINNMB_Change"
    Call Ctl_Item_Change(HD_HINNMB)
End Sub

Private Sub HD_STKDLVDT_Change()
    Debug.Print "HD_STKDLVDT_Change"
    Call Ctl_Item_Change(HD_STKDLVDT)
End Sub

Private Sub HD_DLVSU_Change()
    Debug.Print "HD_DLVSU_Change"
    Call Ctl_Item_Change(HD_DLVSU)
End Sub

Private Sub HD_HIKSU_Change()
    Debug.Print "HD_HIKSU_Change"
    Call Ctl_Item_Change(HD_HIKSU)
End Sub

Private Sub HD_JOTAI_Change()
    Debug.Print "HD_JOTAI_Change"
    Call Ctl_Item_Change(HD_JOTAI)
End Sub

Private Sub HD_STKSU_Change()
    Debug.Print "HD_STKSU_Change"
    Call Ctl_Item_Change(HD_STKSU)
End Sub

Private Sub HD_SZAISU_Change()
    Debug.Print "HD_SZAISU_Change"
    Call Ctl_Item_Change(HD_SZAISU)
End Sub

Private Sub HD_DENDT_Change()
    Debug.Print "HD_DENDT_Change"
    Call Ctl_Item_Change(HD_DENDT)
End Sub

Private Sub HD_SBNNO_Change()
    Debug.Print "HD_SBNNO_Change"
    Call Ctl_Item_Change(HD_SBNNO)
End Sub

Private Sub HD_TOKRN_Change()
    Debug.Print "HD_TOKRN_Change"
    Call Ctl_Item_Change(HD_TOKRN)
End Sub

Private Sub HD_SOUNM_Change()
    Debug.Print "HD_SOUNM_Change"
    Call Ctl_Item_Change(HD_SOUNM)
End Sub

Private Sub HD_TOKJDNNO_Change()
    Debug.Print "HD_TOKJDNNO_Change"
    Call Ctl_Item_Change(HD_TOKJDNNO)
End Sub

Private Sub TX_Message_Change()
    Debug.Print "TX_Message_Change"
    Call Ctl_Item_Change(TX_Message)
End Sub

Private Sub VS_Scrl_Change()
    Debug.Print "VS_Scrl_Change"
    Call Ctl_VS_Scrl_Change(VS_Scrl)
End Sub

Private Sub BD_TRAKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRAKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_TRAKB(Index))
End Sub

Private Sub BD_TRANO_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRANO_KeyUp"
    Call Ctl_Item_KeyUp(BD_TRANO(Index))
End Sub

Private Sub BD_TRADT_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TRADT_KeyUp"
    Call Ctl_Item_KeyUp(BD_TRADT(Index))
End Sub

Private Sub BD_SYUSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SYUSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_SYUSU(Index))
End Sub

Private Sub BD_HIKSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HIKSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_HIKSU(Index))
End Sub

Private Sub BD_ATMNKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ATMNKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_ATMNKB(Index))
End Sub

Private Sub BD_NYUSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_NYUSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_NYUSU(Index))
End Sub

Private Sub BD_TOKRN_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TOKRN_KeyUp"
    Call Ctl_Item_KeyUp(BD_TOKRN(Index))
End Sub

Private Sub BD_BUMNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_BUMNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_BUMNM(Index))
End Sub

Private Sub BD_SOUNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_SOUNM(Index))
End Sub

Private Sub HD_HINCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_HINCD)
End Sub

Private Sub HD_HINNMA_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMA_KeyUp"
    Call Ctl_Item_KeyUp(HD_HINNMA)
End Sub

Private Sub HD_HINNMB_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HINNMB_KeyUp"
    Call Ctl_Item_KeyUp(HD_HINNMB)
End Sub

Private Sub HD_STKDLVDT_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_STKDLVDT_KeyUp"
    Call Ctl_Item_KeyUp(HD_STKDLVDT)
End Sub

Private Sub HD_DLVSU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DLVSU_KeyUp"
    Call Ctl_Item_KeyUp(HD_DLVSU)
End Sub

Private Sub HD_HIKSU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_HIKSU_KeyUp"
    Call Ctl_Item_KeyUp(HD_HIKSU)
End Sub

Private Sub HD_JOTAI_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_JOTAI_KeyUp"
    Call Ctl_Item_KeyUp(HD_JOTAI)
End Sub

Private Sub HD_STKSU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_STKSU_KeyUp"
    Call Ctl_Item_KeyUp(HD_STKSU)
End Sub

Private Sub HD_SZAISU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SZAISU_KeyUp"
    Call Ctl_Item_KeyUp(HD_SZAISU)
End Sub

Private Sub HD_DENDT_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DENDT_KeyUp"
    Call Ctl_Item_KeyUp(HD_DENDT)
End Sub

Private Sub HD_SBNNO_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_SBNNO)
End Sub

Private Sub HD_TOKRN_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKRN)
End Sub

Private Sub HD_SOUNM_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SOUNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_SOUNM)
End Sub

Private Sub HD_TOKJDNNO_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKJDNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKJDNNO)
End Sub
' === 20060802 === INSERT E -

' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�Ή�
Private Sub TX_CursorRest_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_CursorRest_KeyDown"
    If KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
        Call Ctl_Item_KeyDown(TX_CursorRest, KEYCODE, Shift)
    End If
End Sub
' === 20060930 === INSERT E -
