VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSSUB01 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "���Ԉ���/�ʉ���"
   ClientHeight    =   8325
   ClientLeft      =   855
   ClientTop       =   1875
   ClientWidth     =   11715
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
   Icon            =   "HIKET54A.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   8325
   ScaleWidth      =   11715
   Begin VB.TextBox BD_MNSU 
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
      Index           =   0
      Left            =   8900
      MaxLength       =   24
      TabIndex        =   42
      Text            =   "999,999 "
      Top             =   2670
      Width           =   1185
   End
   Begin VB.TextBox HD_MNSU 
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
      Left            =   9210
      MaxLength       =   10
      TabIndex        =   40
      Tag             =   "XXXXXXXXXXXXX"
      Text            =   " 999,999"
      Top             =   1845
      Width           =   1015
   End
   Begin VB.TextBox HD_DEN_SBT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BorderStyle     =   0  '�Ȃ�
      Height          =   255
      Left            =   465
      MaxLength       =   8
      TabIndex        =   1
      Text            =   "MMMMMMM8"
      Top             =   1020
      Width           =   1155
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   375
      IMEMode         =   2  '��
      Left            =   46100
      TabIndex        =   39
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
      Left            =   427
      MaxLength       =   17
      TabIndex        =   37
      Text            =   "XXXXXXXX10"
      Top             =   1845
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
      Left            =   4905
      MaxLength       =   50
      TabIndex        =   36
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   1845
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
      Left            =   1605
      MaxLength       =   30
      TabIndex        =   35
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   1845
      Width           =   3330
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
      Left            =   8325
      MaxLength       =   10
      TabIndex        =   30
      Text            =   "XXXXX6"
      Top             =   660
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
      Left            =   9105
      MaxLength       =   24
      TabIndex        =   29
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   660
      Width           =   2205
   End
   Begin VB.TextBox HD_ZUMISU 
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
      Left            =   10215
      MaxLength       =   10
      TabIndex        =   24
      Tag             =   "XXXXXXXXXXXXX"
      Text            =   " 999,999"
      Top             =   1845
      Width           =   1005
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
      Left            =   3217
      MaxLength       =   10
      TabIndex        =   22
      Tag             =   "XXXXXXXXXXXXX"
      Text            =   "XXXXXXXXX1"
      Top             =   1020
      Width           =   1305
   End
   Begin VB.TextBox BD_ZUMISU 
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
      Index           =   0
      Left            =   6555
      MaxLength       =   24
      TabIndex        =   20
      Text            =   "999,999 "
      Top             =   2670
      Width           =   1185
   End
   Begin VB.TextBox BD_RELZAISU 
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
      Index           =   0
      Left            =   5385
      MaxLength       =   24
      TabIndex        =   18
      Text            =   "999,999 "
      Top             =   2670
      Width           =   1185
   End
   Begin VB.TextBox HD_UODSU 
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
      Left            =   8250
      MaxLength       =   10
      TabIndex        =   17
      Tag             =   "XXXXXXXXXXXXX"
      Text            =   " 999,999"
      Top             =   1845
      Width           =   970
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   4935
      Left            =   11265
      TabIndex        =   16
      Top             =   2670
      Width           =   270
   End
   Begin VB.TextBox BD_INP_HIKSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H00FFFFFF&
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
      Index           =   0
      Left            =   10065
      MaxLength       =   24
      TabIndex        =   12
      Text            =   "999,999 "
      Top             =   2670
      Width           =   1185
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
      Index           =   0
      Left            =   7725
      MaxLength       =   24
      TabIndex        =   11
      Text            =   "999,999 "
      Top             =   2670
      Width           =   1185
   End
   Begin VB.TextBox BD_LOTNO 
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
      Index           =   0
      Left            =   2805
      MaxLength       =   20
      TabIndex        =   10
      Text            =   "XXXXXXXX9"
      Top             =   2670
      Width           =   1260
   End
   Begin VB.TextBox BD_NYUYTDT 
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
      Index           =   0
      Left            =   4050
      MaxLength       =   12
      TabIndex        =   9
      Text            =   " 9999/99/99"
      Top             =   2670
      Width           =   1350
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   9
      Left            =   2805
      TabIndex        =   8
      Top             =   2340
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "ۯĔԍ�"
      OutLine         =   -1  'True
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
      Index           =   0
      Left            =   420
      MaxLength       =   20
      TabIndex        =   7
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2670
      Width           =   2400
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   8
      Left            =   420
      TabIndex        =   6
      Top             =   2340
      Width           =   2400
      _ExtentX        =   4233
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
      Index           =   15
      Left            =   -90
      TabIndex        =   3
      Top             =   7650
      Width           =   11820
      _ExtentX        =   20849
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
         Index           =   16
         Left            =   660
         TabIndex        =   4
         Top             =   120
         Width           =   10845
         _ExtentX        =   19129
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
            TabIndex        =   5
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKET54A.frx":030A
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
         TabIndex        =   2
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "HIKET54A.frx":0494
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "HIKET54A.frx":0AE6
         Top             =   180
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2925
         Picture         =   "HIKET54A.frx":1138
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2565
         Picture         =   "HIKET54A.frx":12C2
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "HIKET54A.frx":144C
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "HIKET54A.frx":15D6
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "HIKET54A.frx":1760
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "HIKET54A.frx":18EA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "HIKET54A.frx":1A74
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "HIKET54A.frx":1BFE
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "HIKET54A.frx":1D88
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "HIKET54A.frx":1F12
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "HIKET54A.frx":209C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "HIKET54A.frx":2226
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "HIKET54A.frx":23B0
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "HIKET54A.frx":253A
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
      Index           =   10
      Left            =   4050
      TabIndex        =   13
      Top             =   2340
      Width           =   1350
      _ExtentX        =   2381
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
      Caption         =   "���ɗ\���"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   13
      Left            =   7725
      TabIndex        =   14
      Top             =   2340
      Width           =   1185
      _ExtentX        =   2090
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
      Caption         =   "�����\��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   14
      Left            =   10065
      TabIndex        =   15
      Top             =   2340
      Width           =   1185
      _ExtentX        =   2090
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
      Height          =   345
      Index           =   11
      Left            =   5385
      TabIndex        =   19
      Top             =   2340
      Width           =   1185
      _ExtentX        =   2090
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
      Caption         =   "���݌ɐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   12
      Left            =   6555
      TabIndex        =   21
      Top             =   2340
      Width           =   1185
      _ExtentX        =   2090
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
      Caption         =   "�����ϐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   6
      Left            =   8250
      TabIndex        =   23
      Top             =   1515
      Width           =   975
      _ExtentX        =   1720
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
      Caption         =   "����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   7
      Left            =   10215
      TabIndex        =   25
      Top             =   1515
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
      Caption         =   "�����ϐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   0
      Left            =   0
      TabIndex        =   26
      Top             =   0
      Width           =   11720
      _ExtentX        =   20664
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
         Left            =   9600
         TabIndex        =   27
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
      Begin VB.Image CM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   555
         Picture         =   "HIKET54A.frx":26C4
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   195
         Picture         =   "HIKET54A.frx":2D16
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
      Index           =   2
      Left            =   1905
      TabIndex        =   28
      Top             =   1020
      Width           =   1320
      _ExtentX        =   2328
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
      Caption         =   "���@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   7080
      TabIndex        =   31
      Top             =   660
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
      Caption         =   " ���͒S����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   4
      Left            =   1605
      TabIndex        =   32
      Top             =   1515
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
      Index           =   5
      Left            =   4905
      TabIndex        =   33
      Top             =   1515
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
      Index           =   3
      Left            =   420
      TabIndex        =   34
      Top             =   1515
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
      Height          =   225
      Index           =   17
      Left            =   210
      TabIndex        =   38
      Top             =   660
      Width           =   1455
      _ExtentX        =   2566
      _ExtentY        =   397
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
      BorderWidth     =   1
      BevelOuter      =   0
      Caption         =   "���`�[���"
      FloodColor      =   16777215
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   18
      Left            =   9210
      TabIndex        =   41
      Top             =   1515
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "�蓮�ϐ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   19
      Left            =   8900
      TabIndex        =   43
      Top             =   2340
      Width           =   1185
      _ExtentX        =   2090
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
      Caption         =   "�蓮������"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "�o�^(&R)"
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
      Visible         =   0   'False
      Begin VB.Menu MN_SELECTCM 
         Caption         =   "�I��"
         Shortcut        =   {F7}
      End
      Begin VB.Menu MN_PREV 
         Caption         =   "�O��"
         Enabled         =   0   'False
         Shortcut        =   {F8}
         Visible         =   0   'False
      End
      Begin VB.Menu MN_NEXTCM 
         Caption         =   "����"
         Enabled         =   0   'False
         Shortcut        =   {F9}
         Visible         =   0   'False
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
Attribute VB_Name = "FR_SSSSUB01"
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
Private Const FM_PANEL3D1_CNT       As Integer = 20 '�p�l���R���g���[����

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
        .Dsp_Ctg = DSP_CTG_REVISION                 '��ʕ���
        .Item_Cnt = 183                             '��ʍ��ڐ�
        .Dsp_Body_Cnt = 15                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 99                          '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 8                           '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
        Set .FormCtl = FR_SSSSUB01
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

    Index_Wk = Index_Wk + 1
    '��ʈ��
    MN_HARDCOPY.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�I��
    MN_SELECTCM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_SELECTCM
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
    MN_PREV.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_PREV
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
    MN_NEXTCM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_NEXTCM
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
    '���s�C���[�W
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
    '�`�[���
    HD_DEN_SBT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DEN_SBT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    HD_SBNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
'UPD 20160216 START C2-20160129-01
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
'UPD 20160216 END C2-20160129-01
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
    '���i�R�[�h
    HD_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
'''' UPD 2009/02/20  FKS) S.Nakajima    Start
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
'''' UPD 2009/02/20  FKS) S.Nakajima    End
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
    '�^��
    HD_HINNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
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
    '�i��
    HD_HINNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
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
    '����
    HD_UODSU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_UODSU
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
    '�蓮�ϐ�
    HD_MNSU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MNSU
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
    '�����ϐ�
    HD_ZUMISU.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_ZUMISU
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
    '�q��(����)
    BD_SOUNM(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '���b�g�ԍ�
    BD_LOTNO(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LOTNO(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���ח\���
    BD_NYUYTDT(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUYTDT(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���݌ɐ�
    BD_RELZAISU(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_RELZAISU(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����ϐ�
    BD_ZUMISU(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ZUMISU(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����\��
    BD_HIKSU(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�蓮������
    BD_MNSU(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MNSU(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '������
    BD_INP_HIKSU(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_INP_HIKSU(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        Load BD_SOUNM(BD_Cnt)           '�q�ɖ�
        Load BD_LOTNO(BD_Cnt)           '���b�g�ԍ�
        Load BD_NYUYTDT(BD_Cnt)         '���ɗ\���
        Load BD_RELZAISU(BD_Cnt)        '���݌ɐ�
        Load BD_ZUMISU(BD_Cnt)          '�����ϐ�
        Load BD_HIKSU(BD_Cnt)           '�����\��
        Load BD_MNSU(BD_Cnt)            '�蓮������
        Load BD_INP_HIKSU(BD_Cnt)       '������

        Index_Wk = Index_Wk + 1
        '�q�ɖ�
        BD_SOUNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���b�g�ԍ�
        BD_LOTNO(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LOTNO(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���ɗ\���
        BD_NYUYTDT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_NYUYTDT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���݌ɐ�
        BD_RELZAISU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_RELZAISU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�����ϐ�
        BD_ZUMISU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ZUMISU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�����\��
        BD_HIKSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HIKSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�蓮������
        BD_MNSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_MNSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
        
        Index_Wk = Index_Wk + 1
        '������
        BD_INP_HIKSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_INP_HIKSU(BD_Cnt)
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

    '���ו��̉B���s���\��/�g�p�s�ɐݒ�
    BD_SOUNM(0).Visible = False: BD_SOUNM(0).Enabled = False
    BD_LOTNO(0).Visible = False: BD_LOTNO(0).Enabled = False
    BD_NYUYTDT(0).Visible = False: BD_NYUYTDT(0).Enabled = False
    BD_RELZAISU(0).Visible = False: BD_RELZAISU(0).Enabled = False
    BD_ZUMISU(0).Visible = False: BD_ZUMISU(0).Enabled = False
    BD_HIKSU(0).Visible = False: BD_HIKSU(0).Enabled = False
    BD_MNSU(0).Visible = False: BD_MNSU(0).Enabled = False
    BD_INP_HIKSU(0).Visible = False: BD_INP_HIKSU(0).Enabled = False

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
    
    '��ʕҏW�t���O������
    gv_bolHIKET54_INIT = False

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
    Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
        Call SSSMAIN0003.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
    Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call SSSMAIN0003.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
    Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYDOWN����
        Call SSSMAIN0003.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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
    Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call SSSMAIN0003.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
    Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0003.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYUP����
        Call SSSMAIN0003.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
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
            Call SSSMAIN0003.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

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

    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Boolean

    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Ctl_Item_LostFocus = True
    
    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
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
    Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        '������ړ�����
        Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

    Ctl_Item_LostFocus = Chk_Move_Flg

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
        Rtn_Chk = SSSMAIN0003.F_Ctl_Head_Chk(Main_Inf)
'�d���������������������������������������������������������d
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If

'�r���������������������������������������������������������r
    '����̫����擾����
    Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
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
    Call SSSMAIN0003.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
        Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then

            '����̫����ʒu����E�ֈړ�
            Call SSSMAIN0003.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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
    Call SSSMAIN0003.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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
            Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                
                Case CInt(CM_Execute.Tag)
                '���s�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
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
            Call CF_Set_Prompt(IMG_ENDCM_SUB_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '���s�Ұ��
            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)

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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)
        
        Case CInt(CM_Execute.Tag)
        '���s�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

    End Select

    '����MOUSEDOWN����
    Call SSSMAIN0003.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

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

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

'�r���������������������������������������������������������r
    '�e������ʌďo
    Select Case Trg_Index
        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_Execute.Tag)
            '���s
            Call Ctl_MN_Execute_Click

        Case CInt(MN_HARDCOPY.Tag)
            '��ʈ��
            Call Ctl_MN_HARDCOPY_Click

        Case CInt(MN_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click

        Case CInt(MN_EditMn.Tag)
            '�����Q
            Call Ctl_MN_EditMn_Click

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

        Case CInt(MN_SELECTCM.Tag)
            '�I��
            Call Ctl_MN_SELECTCM_Click

        Case CInt(MN_PREV.Tag)
            '�O��
            Call Ctl_MN_PREV_Click

        Case CInt(MN_NEXTCM.Tag)
            '����
            Call Ctl_MN_NEXTCM_Click

        Case CInt(MN_Slist.Tag)
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

'�����j���[�C���[�W
        Case CInt(CM_EndCm.Tag)
            '�I��
            Unload Me

        Case CInt(CM_Execute.Tag)
            '���s
            Call Ctl_MN_Execute_Click

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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '����s�����
    MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '���ʈ�������
    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
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

    '����ڏ����������
    MN_ClearItm.Enabled = False
    '����ڕ��������
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��؂��裔���
    MN_Cut.Enabled = False
    '��R�s�[�����
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��\��t�������
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '��I�𣏉����
    MN_SELECTCM.Enabled = False
    '��O�ţ������
    MN_PREV.Enabled = False
    '����ţ������
    MN_NEXTCM.Enabled = False
    '����̈ꗗ�������
    MN_Slist.Enabled = False

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
Public Function Ctl_MN_Execute_Click() As Integer
    
    Dim intRet          As Integer
    
    intRet = SSSMAIN0003.F_Ctl_Upd_Process(Main_Inf)
    
    '�X�V������̏ꍇ�͏��������Ɠ����������s��
    If intRet = 0 Then
        '��ʓ��e������
        Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)
    
        '��ʖ��׏��ݒ�
        Call Init_Def_Body_Inf
    
        '��ʖ��ו�������
        Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)
    
        '���׃��P�[�V����
        Call Set_Body_Location
    
        '�����\���ҏW
        Call Edi_Dsp_Def
        
        '��ʕ\���ʒu�ݒ�
        Call CF_Set_Frm_Location(FR_SSSSUB01)
        
        '���͒S���ҕҏW
        Call CF_Set_Frm_IN_TANCD(FR_SSSSUB01, Main_Inf)
        
        '�{�f�B���ҏW_�T�u�Ɖ��ʗp
        Call SSSMAIN0003.F_DSP_BD_Inf_SUB(0, Main_Inf)
        
        '��ʖ��ו\��
        Call CF_Body_Dsp(Main_Inf)
        
        '���׃J���[�t��
        Call SSSMAIN0003.CF_Set_BD_Color(Main_Inf)
    
        '�V�X�e�����ʏ���
        Call CF_System_Process(Me)
    
        '��ʕҏW�t���O������
        gv_bolHIKET54_INIT = False
        
        '����̫����ʒu�ݒ�
        Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
    End If

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
        wk_Cursor = SSSMAIN0003.AE_Hardcopy_SSSMAIN()
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
    Unload FR_SSSSUB01
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
    Call SSSMAIN0003.F_Init_Clr_Dsp(Act_Index, Main_Inf)
        
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
    
    '����̫����擾����
    Call SSSMAIN0003.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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
    Rtn_Chk = SSSMAIN0003.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
    
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
    Call SSSMAIN0003.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
    
    '�I����Ԃ̐ݒ�i�����I���j
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
    
    '���ڐF�ݒ�
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

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
    Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
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
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
    Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

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
    Dim Rtn_LF      As Boolean
    Dim Err_Row     As Integer

    If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
        Main_Inf.Dsp_Base.VS_Scr_Flg = False
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    If Act_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx _
    And Act_Index < Main_Inf.Dsp_Base.Foot_Fst_Idx Then
        Rtn_LF = Ctl_Item_LostFocus(Me.ActiveControl)
    Else
        Rtn_LF = True
    End If

    If Rtn_LF = True Then
        '����VS_SCRL_CHANGE����
        Call SSSMAIN0003.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    Else
        '�c�X�N���[���o�[��ݒ�
        Call CF_Set_Item_Direct(Main_Inf.Dsp_Body_Inf.Cur_Top_Index, Main_Inf.Dsp_Sub_Inf(CInt(Main_Inf.Bd_Vs_Scrl.Tag)), Main_Inf)
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    Dim strMsg              As String

    '�I�����b�Z�[�W�̏o��
    If gv_bolHIKET54_INIT = False Then
        '�I�����܂����H
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_001, Main_Inf) = vbNo Then
            Cancel = vbCancel
            Exit Sub
        End If
    Else
        '���o�^�̂܂܏I�����܂����H
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_013, Main_Inf) = vbNo Then
            Cancel = vbCancel
            Exit Sub
        End If
    End If
    
    '�r������
    Call CF_Unlock_EXCTBZ(strMsg)
    
' add 20170616 start
    '�r������
    Call CF_Unlock_EXCTBZ2(strMsg)
' add 20170616 end

    Main_Inf.Dsp_Base.IsUnload = True
    '���ʏI�������H
    Set FR_SSSSUB01 = Nothing
    
    FR_SSSMAIN.Show

End Sub

' add 20170616 start
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function CF_Unlock_EXCTBZ2
'   �T�v�F�@�r�������������
'   �����F�@Pot_strMsg       : �G���[���e
'   �ߒl�F�@0 : ����  9 : �ُ�
'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Unlock_EXCTBZ2(ByRef pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Unlock_EXCTBZ_Err

    CF_Unlock_EXCTBZ2 = 9
    pot_strMsg = ""
    bolTrn = False
    
    '�g�����U�N�V�����̊J�n
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
        
    intRet = AE_Execute_PLSQL_EXCTBZ_2("D", strMsg)
    If intRet <> 0 Then
        '�r���G���[
        pot_strMsg = strMsg
        CF_Unlock_EXCTBZ2 = intRet
        GoTo CF_Unlock_EXCTBZ_Err
    End If
    
    '�R�~�b�g
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Unlock_EXCTBZ2 = 0
    
    Exit Function
    
CF_Unlock_EXCTBZ_Err:

    '���[���o�b�N
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function
' add 20170616 end

Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '��ʈ���N������TRUE�Ƃ���
    PP_SSSMAIN.Operable = True
    '����̫����ʒu�ݒ�
    Call SSSMAIN0003.F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()

    '��ʏ��ݒ�
    Call Init_Def_Dsp
    
    '��ʓ��e������
    Call SSSMAIN0003.F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʖ��׏��ݒ�
    Call Init_Def_Body_Inf

    '��ʖ��ו�������
    Call SSSMAIN0003.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '���׃��P�[�V����
    Call Set_Body_Location

    '�����\���ҏW
    Call Edi_Dsp_Def
    
    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSSUB01)
    
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSSUB01, Main_Inf)
    
    '�{�f�B���ҏW_�T�u�Ɖ��ʗp
    Call SSSMAIN0003.F_DSP_BD_Inf_SUB(0, Main_Inf)
    
    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

    '���׃J���[�t��
    Call SSSMAIN0003.CF_Set_BD_Color(Main_Inf)

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)
    
    '��ʕҏW�t���O������
    gv_bolHIKET54_INIT = False

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
    Dim strTANCD        As String
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

    Dim BD_SOUNM_Top    As Integer
    Dim BD_SOUNM_Height As Integer

    Dim Bd_Index        As Integer

'�r���������������������������������������������������������r
    '�P�s�ڂ�No��Top��Height����Ƃ���
    BD_SOUNM_Top = BD_SOUNM(1).Top
    BD_SOUNM_Height = BD_SOUNM(1).Height + Hosei_Value

    '�\���ŏI�s�܂ŏ���
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        If Bd_Index >= 2 Then
        '�Q�s�ڈȍ~����
            '�z�u
            BD_SOUNM(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_LOTNO(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_NYUYTDT(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_RELZAISU(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_ZUMISU(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_HIKSU(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_MNSU(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
            BD_INP_HIKSU(Bd_Index).Top = BD_SOUNM_Top + BD_SOUNM_Height * (Bd_Index - 1)
        End If

        '�\��
        BD_SOUNM(Bd_Index).Visible = True
        BD_LOTNO(Bd_Index).Visible = True
        BD_NYUYTDT(Bd_Index).Visible = True
        BD_RELZAISU(Bd_Index).Visible = True
        BD_ZUMISU(Bd_Index).Visible = True
        BD_HIKSU(Bd_Index).Visible = True
        BD_MNSU(Bd_Index).Visible = True
        BD_INP_HIKSU(Bd_Index).Visible = True

    Next

    '�X�N���[���o�[�̐ݒ�
    Main_Inf.Bd_Vs_Scrl.Top = BD_SOUNM_Top
    Main_Inf.Bd_Vs_Scrl.Height = BD_SOUNM_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt

'�d���������������������������������������������������������d

End Function

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub CM_Execute_Click()
    Debug.Print "CM_Execute_Click"
    Call Ctl_Item_Click(CM_Execute)
End Sub

Private Sub Image1_Click()
    Debug.Print "Image1_Click"
    Call Ctl_Item_Click(Image1)
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

Private Sub MN_Execute_Click()
    Debug.Print "MN_Execute_Click"
    Call Ctl_Item_Click(MN_Execute)
End Sub

Private Sub MN_HARDCOPY_Click()
    Debug.Print "MN_HARDCOPY_Click"
    Call Ctl_Item_Click(MN_HARDCOPY)
End Sub

Private Sub MN_NEXTCM_Click()
    Debug.Print "MN_NEXTCM_Click"
    Call Ctl_Item_Click(MN_NEXTCM)
End Sub

Private Sub MN_Oprt_Click()
    Debug.Print "MN_Oprt_Click"
    Call Ctl_Item_Click(MN_Oprt)
End Sub

Private Sub MN_Paste_Click()
    Debug.Print "MN_Paste_Click"
    Call Ctl_Item_Click(MN_Paste)
End Sub

Private Sub MN_PREV_Click()
    Debug.Print "MN_PREV_Click"
    Call Ctl_Item_Click(MN_PREV)
End Sub

Private Sub MN_SELECTCM_Click()
    Debug.Print "MN_SELECTCM_Click"
    Call Ctl_Item_Click(MN_SELECTCM)
End Sub

Private Sub MN_Slist_Click()
    Debug.Print "MN_Slist_Click"
    Call Ctl_Item_Click(MN_Slist)
End Sub

Private Sub MN_UnDoItem_Click()
    Debug.Print "MN_UnDoItem_Click"
    Call Ctl_Item_Click(MN_UnDoItem)
End Sub

Private Sub BD_HIKSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HIKSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_MNSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_MNSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_MNSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_INP_HIKSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_INP_HIKSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_INP_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_LOTNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LOTNO_MouseDown"
    Call Ctl_Item_MouseDown(BD_LOTNO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_NYUYTDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_NYUYTDT_MouseDown"
    Call Ctl_Item_MouseDown(BD_NYUYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_RELZAISU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_RELZAISU_MouseDown"
    Call Ctl_Item_MouseDown(BD_RELZAISU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_SOUNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ZUMISU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ZUMISU_MouseDown"
    Call Ctl_Item_MouseDown(BD_ZUMISU(Index), Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseDown"
    Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub HD_DEN_SBT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DEN_SBT_MouseDown"
    Call Ctl_Item_MouseDown(HD_DEN_SBT, Button, Shift, X, Y)
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

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
End Sub


Private Sub HD_UODSU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_UODSU_MouseDown"
    Call Ctl_Item_MouseDown(HD_UODSU, Button, Shift, X, Y)
End Sub

Private Sub HD_MNSU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MNSU_MouseDown"
    Call Ctl_Item_MouseDown(HD_MNSU, Button, Shift, X, Y)
End Sub

Private Sub HD_ZUMISU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_ZUMISU_MouseDown"
    Call Ctl_Item_MouseDown(HD_ZUMISU, Button, Shift, X, Y)
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

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseMove"
    Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub BD_HIKSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HIKSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_MNSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_MNSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_MNSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_INP_HIKSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_INP_HIKSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_INP_HIKSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_LOTNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LOTNO_MouseUp"
    Call Ctl_Item_MouseUp(BD_LOTNO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_NYUYTDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_NYUYTDT_MouseUp"
    Call Ctl_Item_MouseUp(BD_NYUYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_RELZAISU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_RELZAISU_MouseUp"
    Call Ctl_Item_MouseUp(BD_RELZAISU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_SOUNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ZUMISU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ZUMISU_MouseUp"
    Call Ctl_Item_MouseUp(BD_ZUMISU(Index), Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseUp"
    Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_DEN_SBT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DEN_SBT_MouseUp"
    Call Ctl_Item_MouseUp(HD_DEN_SBT, Button, Shift, X, Y)
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

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
End Sub

Private Sub HD_UODSU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_UODSU_MouseUp"
    Call Ctl_Item_MouseUp(HD_UODSU, Button, Shift, X, Y)
End Sub

Private Sub HD_MNSU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MNSU_MouseUp"
    Call Ctl_Item_MouseUp(HD_MNSU, Button, Shift, X, Y)
End Sub

Private Sub HD_ZUMISU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_ZUMISU_MouseUp"
    Call Ctl_Item_MouseUp(HD_ZUMISU, Button, Shift, X, Y)
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

Private Sub BD_HIKSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HIKSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_HIKSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_MNSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_MNSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_MNSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_INP_HIKSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_INP_HIKSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_INP_HIKSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_LOTNO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_LOTNO_KeyDown"
    Call Ctl_Item_KeyDown(BD_LOTNO(Index), KEYCODE, Shift)
End Sub

Private Sub BD_NYUYTDT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_NYUYTDT_KeyDown"
    Call Ctl_Item_KeyDown(BD_NYUYTDT(Index), KEYCODE, Shift)
End Sub

Private Sub BD_RELZAISU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_RELZAISU_KeyDown"
    Call Ctl_Item_KeyDown(BD_RELZAISU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SOUNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
End Sub

Private Sub BD_ZUMISU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ZUMISU_KeyDown"
    Call Ctl_Item_KeyDown(BD_ZUMISU(Index), KEYCODE, Shift)
End Sub

Private Sub HD_DEN_SBT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DEN_SBT_KeyDown"
    Call Ctl_Item_KeyDown(HD_DEN_SBT, KEYCODE, Shift)
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

Private Sub HD_IN_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
End Sub

Private Sub HD_SBNNO_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
End Sub

Private Sub HD_UODSU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_UODSU_KeyDown"
    Call Ctl_Item_KeyDown(HD_UODSU, KEYCODE, Shift)
End Sub

Private Sub HD_MNSU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_MNSU_KeyDown"
    Call Ctl_Item_KeyDown(HD_MNSU, KEYCODE, Shift)
End Sub

Private Sub HD_ZUMISU_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_ZUMISU_KeyDown"
    Call Ctl_Item_KeyDown(HD_ZUMISU, KEYCODE, Shift)
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
End Sub

Private Sub BD_HIKSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HIKSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_HIKSU(Index), KeyAscii)
End Sub

Private Sub BD_MNSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_MNSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_MNSU(Index), KeyAscii)
End Sub

Private Sub BD_INP_HIKSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_INP_HIKSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_INP_HIKSU(Index), KeyAscii)
End Sub

Private Sub BD_LOTNO_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_LOTNO_KeyPress"
    Call Ctl_Item_KeyPress(BD_LOTNO(Index), KeyAscii)
End Sub

Private Sub BD_NYUYTDT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_NYUYTDT_KeyPress"
    Call Ctl_Item_KeyPress(BD_NYUYTDT(Index), KeyAscii)
End Sub

Private Sub BD_RELZAISU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_RELZAISU_KeyPress"
    Call Ctl_Item_KeyPress(BD_RELZAISU(Index), KeyAscii)
End Sub

Private Sub BD_SOUNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SOUNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_SOUNM(Index), KeyAscii)
End Sub

Private Sub BD_ZUMISU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_ZUMISU_KeyPress"
    Call Ctl_Item_KeyPress(BD_ZUMISU(Index), KeyAscii)
End Sub

Private Sub HD_DEN_SBT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_DEN_SBT_KeyPress"
    Call Ctl_Item_KeyPress(HD_DEN_SBT, KeyAscii)
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

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub HD_SBNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SBNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
End Sub

Private Sub HD_UODSU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_UODSU_KeyPress"
    Call Ctl_Item_KeyPress(HD_UODSU, KeyAscii)
End Sub

Private Sub HD_MNSU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MNSU_KeyPress"
    Call Ctl_Item_KeyPress(HD_MNSU, KeyAscii)
End Sub

Private Sub HD_ZUMISU_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_ZUMISU_KeyPress"
    Call Ctl_Item_KeyPress(HD_ZUMISU, KeyAscii)
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Message_KeyPress"
    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
End Sub

Private Sub BD_HIKSU_GotFocus(Index As Integer)
    Debug.Print "BD_HIKSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_HIKSU(Index))
End Sub

Private Sub BD_MNSU_GotFocus(Index As Integer)
    Debug.Print "BD_MNSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_MNSU(Index))
End Sub

Private Sub BD_INP_HIKSU_GotFocus(Index As Integer)
    Debug.Print "BD_INP_HIKSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_INP_HIKSU(Index))
End Sub

Private Sub BD_LOTNO_GotFocus(Index As Integer)
    Debug.Print "BD_LOTNO_GotFocus"
    Call Ctl_Item_GotFocus(BD_LOTNO(Index))
End Sub

Private Sub BD_NYUYTDT_GotFocus(Index As Integer)
    Debug.Print "BD_NYUYTDT_GotFocus"
    Call Ctl_Item_GotFocus(BD_NYUYTDT(Index))
End Sub

Private Sub BD_RELZAISU_GotFocus(Index As Integer)
    Debug.Print "BD_RELZAISU_GotFocus"
    Call Ctl_Item_GotFocus(BD_RELZAISU(Index))
End Sub

Private Sub BD_SOUNM_GotFocus(Index As Integer)
    Debug.Print "BD_SOUNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_SOUNM(Index))
End Sub

Private Sub BD_ZUMISU_GotFocus(Index As Integer)
    Debug.Print "BD_ZUMISU_GotFocus"
    Call Ctl_Item_GotFocus(BD_ZUMISU(Index))
End Sub

Private Sub HD_DEN_SBT_GotFocus()
    Debug.Print "HD_DEN_SBT_GotFocus"
    Call Ctl_Item_GotFocus(HD_DEN_SBT)
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

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_SBNNO_GotFocus()
    Debug.Print "HD_SBNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_SBNNO)
End Sub

Private Sub HD_UODSU_GotFocus()
    Debug.Print "HD_UODSU_GotFocus"
    Call Ctl_Item_GotFocus(HD_UODSU)
End Sub

Private Sub HD_MNSU_GotFocus()
    Debug.Print "HD_MNSU_GotFocus"
    Call Ctl_Item_GotFocus(HD_MNSU)
End Sub

Private Sub HD_ZUMISU_GotFocus()
    Debug.Print "HD_ZUMISU_GotFocus"
    Call Ctl_Item_GotFocus(HD_ZUMISU)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub BD_HIKSU_LostFocus(Index As Integer)
    Debug.Print "BD_HIKSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_HIKSU(Index))
End Sub

Private Sub BD_MNSU_LostFocus(Index As Integer)
    Debug.Print "BD_MNSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_MNSU(Index))
End Sub

Private Sub BD_INP_HIKSU_LostFocus(Index As Integer)
    Debug.Print "BD_INP_HIKSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_INP_HIKSU(Index))
End Sub

Private Sub BD_LOTNO_LostFocus(Index As Integer)
    Debug.Print "BD_LOTNO_LostFocus"
    Call Ctl_Item_LostFocus(BD_LOTNO(Index))
End Sub

Private Sub BD_NYUYTDT_LostFocus(Index As Integer)
    Debug.Print "BD_NYUYTDT_LostFocus"
    Call Ctl_Item_LostFocus(BD_NYUYTDT(Index))
End Sub

Private Sub BD_RELZAISU_LostFocus(Index As Integer)
    Debug.Print "BD_RELZAISU_LostFocus"
    Call Ctl_Item_LostFocus(BD_RELZAISU(Index))
End Sub

Private Sub BD_SOUNM_LostFocus(Index As Integer)
    Debug.Print "BD_SOUNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_SOUNM(Index))
End Sub

Private Sub BD_ZUMISU_LostFocus(Index As Integer)
    Debug.Print "BD_ZUMISU_LostFocus"
    Call Ctl_Item_LostFocus(BD_ZUMISU(Index))
End Sub

Private Sub HD_DEN_SBT_LostFocus()
    Debug.Print "HD_DEN_SBT_LostFocus"
    Call Ctl_Item_LostFocus(HD_DEN_SBT)
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

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub HD_SBNNO_LostFocus()
    Debug.Print "HD_SBNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_SBNNO)
End Sub

Private Sub HD_UODSU_LostFocus()
    Debug.Print "HD_UODSU_LostFocus"
    Call Ctl_Item_LostFocus(HD_UODSU)
End Sub

Private Sub HD_MNSU_LostFocus()
    Debug.Print "HD_MNSU_LostFocus"
    Call Ctl_Item_LostFocus(HD_MNSU)
End Sub

Private Sub HD_ZUMISU_LostFocus()
    Debug.Print "HD_ZUMISU_LostFocus"
    Call Ctl_Item_LostFocus(HD_ZUMISU)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub BD_HIKSU_Change(Index As Integer)
    Debug.Print "BD_HIKSU_Change"
    Call Ctl_Item_Change(BD_HIKSU(Index))
End Sub

Private Sub BD_MNSU_Change(Index As Integer)
    Debug.Print "BD_MNSU_Change"
    Call Ctl_Item_Change(BD_MNSU(Index))
End Sub

Private Sub BD_INP_HIKSU_Change(Index As Integer)
    Debug.Print "BD_INP_HIKSU_Change"
    Call Ctl_Item_Change(BD_INP_HIKSU(Index))
End Sub

Private Sub BD_LOTNO_Change(Index As Integer)
    Debug.Print "BD_LOTNO_Change"
    Call Ctl_Item_Change(BD_LOTNO(Index))
End Sub

Private Sub BD_NYUYTDT_Change(Index As Integer)
    Debug.Print "BD_NYUYTDT_Change"
    Call Ctl_Item_Change(BD_NYUYTDT(Index))
End Sub

Private Sub BD_RELZAISU_Change(Index As Integer)
    Debug.Print "BD_RELZAISU_Change"
    Call Ctl_Item_Change(BD_RELZAISU(Index))
End Sub

Private Sub BD_SOUNM_Change(Index As Integer)
    Debug.Print "BD_SOUNM_Change"
    Call Ctl_Item_Change(BD_SOUNM(Index))
End Sub

Private Sub BD_ZUMISU_Change(Index As Integer)
    Debug.Print "BD_ZUMISU_Change"
    Call Ctl_Item_Change(BD_ZUMISU(Index))
End Sub

Private Sub HD_DEN_SBT_Change()
    Debug.Print "HD_DEN_SBT_Change"
    Call Ctl_Item_Change(HD_DEN_SBT)
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

Private Sub HD_IN_TANCD_Change()
    Debug.Print "HD_IN_TANCD_Change"
    Call Ctl_Item_Change(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_Change()
    Debug.Print "HD_IN_TANNM_Change"
    Call Ctl_Item_Change(HD_IN_TANNM)
End Sub

Private Sub HD_SBNNO_Change()
    Debug.Print "HD_SBNNO_Change"
    Call Ctl_Item_Change(HD_SBNNO)
End Sub

Private Sub HD_UODSU_Change()
    Debug.Print "HD_UODSU_Change"
    Call Ctl_Item_Change(HD_UODSU)
End Sub

Private Sub HD_MNSU_Change()
    Debug.Print "HD_MNSU_Change"
    Call Ctl_Item_Change(HD_MNSU)
End Sub

Private Sub HD_ZUMISU_Change()
    Debug.Print "HD_ZUMISU_Change"
    Call Ctl_Item_Change(HD_ZUMISU)
End Sub

Private Sub TX_Message_Change()
    Debug.Print "TX_Message_Change"
    Call Ctl_Item_Change(TX_Message)
End Sub

Private Sub VS_Scrl_Change()
    Debug.Print "VS_Scrl_Change"
    Call Ctl_VS_Scrl_Change(VS_Scrl)
End Sub

Private Sub BD_HIKSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HIKSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_HIKSU(Index))
End Sub

Private Sub BD_MNSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_MNSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_MNSU(Index))
End Sub

Private Sub BD_INP_HIKSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_INP_HIKSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_INP_HIKSU(Index))
End Sub

Private Sub BD_LOTNO_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_LOTNO_KeyUp"
    Call Ctl_Item_KeyUp(BD_LOTNO(Index))
End Sub

Private Sub BD_NYUYTDT_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_NYUYTDT_KeyUp"
    Call Ctl_Item_KeyUp(BD_NYUYTDT(Index))
End Sub

Private Sub BD_RELZAISU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_RELZAISU_KeyUp"
    Call Ctl_Item_KeyUp(BD_RELZAISU(Index))
End Sub

Private Sub BD_SOUNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_SOUNM(Index))
End Sub

Private Sub BD_ZUMISU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ZUMISU_KeyUp"
    Call Ctl_Item_KeyUp(BD_ZUMISU(Index))
End Sub

Private Sub HD_DEN_SBT_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_DEN_SBT_KeyUp"
    Call Ctl_Item_KeyUp(HD_DEN_SBT)
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

Private Sub HD_SBNNO_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_SBNNO)
End Sub

Private Sub HD_UODSU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_UODSU_KeyUp"
    Call Ctl_Item_KeyUp(HD_UODSU)
End Sub

Private Sub HD_MNSU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_MNSU_KeyUp"
    Call Ctl_Item_KeyUp(HD_MNSU)
End Sub

Private Sub HD_ZUMISU_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_ZUMISU_KeyUp"
    Call Ctl_Item_KeyUp(HD_ZUMISU)
End Sub

Private Sub SM_AllCopy_Click()
    Debug.Print "SM_AllCopy_Click"
    Call Ctl_Item_Click(SM_AllCopy)
End Sub

Private Sub SM_FullPast_Click()
    Debug.Print "SM_FullPast_Click"
    Call Ctl_Item_Click(SM_FullPast)
End Sub

Private Sub SM_Esc_Click()
    Debug.Print "SM_Esc_Click"
    Call Ctl_Item_Click(SM_Esc)
End Sub

Private Sub TX_CursorRest_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_CursorRest_KeyDown"
    If KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
        Call Ctl_Item_KeyDown(TX_CursorRest, KEYCODE, Shift)
    End If
End Sub
