VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�݌Ɉ���/�ʉ���"
   ClientHeight    =   9795
   ClientLeft      =   45
   ClientTop       =   615
   ClientWidth     =   14880
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
   Icon            =   "HIKET51.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   10944.14
   ScaleMode       =   0  'հ�ް
   ScaleWidth      =   15820.86
   Begin VB.OptionButton BD_SELECTB 
      Height          =   675
      Index           =   1
      Left            =   660
      TabIndex        =   98
      Top             =   4230
      Width           =   255
   End
   Begin VB.Frame Frame1 
      Height          =   930
      Left            =   150
      TabIndex        =   91
      Top             =   570
      Width           =   2895
      Begin VB.TextBox HD_MITNOV 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         Height          =   345
         IMEMode         =   2  '��
         Left            =   2460
         MaxLength       =   12
         TabIndex        =   94
         Text            =   "12"
         Top             =   165
         Width           =   270
      End
      Begin VB.TextBox HD_MITNO 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         Height          =   345
         IMEMode         =   2  '��
         Left            =   1530
         MaxLength       =   10
         TabIndex        =   93
         TabStop         =   0   'False
         Text            =   "12345678"
         Top             =   165
         Width           =   945
      End
      Begin VB.TextBox HD_JDNNO 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFFFFF&
         Height          =   345
         IMEMode         =   2  '��
         Left            =   1530
         MaxLength       =   10
         TabIndex        =   92
         TabStop         =   0   'False
         Text            =   "XXXXX6"
         Top             =   495
         Width           =   945
      End
      Begin Threed5.SSCommand5 CS_MITNO 
         Height          =   345
         Left            =   105
         TabIndex        =   95
         TabStop         =   0   'False
         Top             =   165
         Width           =   1455
         _ExtentX        =   2566
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
         Caption         =   " �Ώی��ϔԍ�"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_JDNNO 
         Height          =   345
         Left            =   105
         TabIndex        =   96
         TabStop         =   0   'False
         Top             =   495
         Width           =   1455
         _ExtentX        =   2566
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
         Caption         =   " �Ώێ󒍔ԍ�"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.TextBox TL_SBAUZEKN 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   10680
      MaxLength       =   17
      TabIndex        =   87
      Text            =   "-9,999,999,999"
      Top             =   8595
      Width           =   1575
   End
   Begin VB.TextBox TL_SBAUODKN 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   9120
      MaxLength       =   17
      TabIndex        =   86
      Text            =   "-9,999,999,999"
      Top             =   8595
      Width           =   1575
   End
   Begin VB.TextBox TL_SBAUZKKN 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   12240
      MaxLength       =   17
      TabIndex        =   85
      Text            =   "-9,999,999,999"
      Top             =   8595
      Width           =   1575
   End
   Begin VB.TextBox HD_NHSNMB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   6345
      MaxLength       =   32
      TabIndex        =   82
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   2865
      Width           =   3300
   End
   Begin VB.TextBox HD_NHSNMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   6345
      MaxLength       =   32
      TabIndex        =   81
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   2535
      Width           =   3300
   End
   Begin VB.TextBox HD_NHSCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   2  '��
      Left            =   5295
      MaxLength       =   9
      TabIndex        =   80
      Text            =   "XXXXXXXX9"
      Top             =   2535
      Width           =   1080
   End
   Begin VB.TextBox HD_KENNMB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   5295
      MaxLength       =   40
      TabIndex        =   79
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   2205
      Width           =   4350
   End
   Begin VB.TextBox HD_KENNMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   5295
      MaxLength       =   40
      TabIndex        =   78
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   1875
      Width           =   4350
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11325
      MaxLength       =   10
      TabIndex        =   63
      Text            =   "XXXXX6"
      Top             =   1545
      Width           =   720
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12030
      MaxLength       =   24
      TabIndex        =   62
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1545
      Width           =   2250
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   3990
      Left            =   13860
      TabIndex        =   60
      Top             =   4215
      Width           =   330
   End
   Begin VB.TextBox BD_GNKCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   5940
      MaxLength       =   8
      TabIndex        =   57
      Text            =   "XX3"
      Top             =   4230
      Width           =   525
   End
   Begin VB.TextBox HD_URIKJN 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11325
      MaxLength       =   10
      TabIndex        =   56
      Text            =   "12"
      Top             =   2865
      Width           =   285
   End
   Begin VB.TextBox HD_BINCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   13260
      MaxLength       =   10
      TabIndex        =   55
      Text            =   "12"
      Top             =   2865
      Width           =   270
   End
   Begin VB.TextBox HD_TOKJDNNO 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   1695
      MaxLength       =   23
      TabIndex        =   54
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXX"
      Top             =   2250
      Width           =   2535
   End
   Begin VB.TextBox BD_TOKJDNNO 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   1320
      MaxLength       =   17
      TabIndex        =   52
      Text            =   "XXXXXXXXX1"
      Top             =   4560
      Width           =   1335
   End
   Begin VB.TextBox HD_URIKJNNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11595
      MaxLength       =   30
      TabIndex        =   45
      Text            =   "MMMMMMMMM1"
      Top             =   2865
      Width           =   1125
   End
   Begin VB.TextBox HD_JDNTRNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   1995
      MaxLength       =   24
      TabIndex        =   44
      Text            =   "MMMMMMMMM1"
      Top             =   1545
      Width           =   1185
   End
   Begin VB.TextBox HD_JDNTRKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   1695
      MaxLength       =   10
      TabIndex        =   43
      Text            =   "X2"
      Top             =   1545
      Width           =   315
   End
   Begin VB.TextBox BD_ODNYTDT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   2  '��
      Index           =   1
      Left            =   11565
      MaxLength       =   14
      TabIndex        =   42
      Text            =   "9999/99/99"
      Top             =   4230
      Width           =   1125
   End
   Begin VB.TextBox BD_SIKRT 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   10605
      MaxLength       =   9
      TabIndex        =   41
      Text            =   "-9999.9��"
      Top             =   4230
      Width           =   975
   End
   Begin VB.TextBox BD_UODKN 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   9255
      MaxLength       =   13
      TabIndex        =   39
      Text            =   "-999,999,999"
      Top             =   4230
      Width           =   1365
   End
   Begin VB.TextBox BD_TEIKATK 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   9255
      MaxLength       =   13
      TabIndex        =   38
      Text            =   "-999,999,999"
      Top             =   4560
      Width           =   1365
   End
   Begin VB.TextBox BD_UODTK 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   7935
      MaxLength       =   13
      TabIndex        =   36
      Text            =   "999,999,999"
      Top             =   4230
      Width           =   1335
   End
   Begin VB.TextBox BD_UODSU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   6450
      MaxLength       =   8
      TabIndex        =   35
      Text            =   "-999,999"
      Top             =   4230
      Width           =   975
   End
   Begin VB.TextBox HD_TOKRN 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   6345
      MaxLength       =   32
      TabIndex        =   33
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   1545
      Width           =   3300
   End
   Begin VB.TextBox HD_TOKCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   5295
      MaxLength       =   7
      TabIndex        =   32
      Text            =   "XXXX5"
      Top             =   1545
      Width           =   1080
   End
   Begin VB.TextBox HD_BUMNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12030
      MaxLength       =   20
      TabIndex        =   31
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2205
      Width           =   2250
   End
   Begin VB.TextBox HD_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12030
      MaxLength       =   20
      TabIndex        =   30
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1875
      Width           =   2250
   End
   Begin VB.TextBox HD_BINNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   13515
      MaxLength       =   30
      TabIndex        =   29
      Text            =   "MMMMMMMMM1"
      Top             =   2865
      Width           =   1110
   End
   Begin VB.TextBox HD_BUMCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11325
      MaxLength       =   7
      TabIndex        =   28
      Text            =   "123456"
      Top             =   2205
      Width           =   720
   End
   Begin VB.TextBox HD_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11325
      MaxLength       =   7
      TabIndex        =   27
      Text            =   "XXXXX6"
      Top             =   1875
      Width           =   720
   End
   Begin VB.TextBox HD_SOUCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11325
      MaxLength       =   7
      TabIndex        =   26
      Text            =   "123"
      Top             =   2535
      Width           =   720
   End
   Begin VB.TextBox HD_SOUNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12030
      MaxLength       =   20
      TabIndex        =   25
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2535
      Width           =   2250
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   12360
      MaxLength       =   24
      TabIndex        =   24
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   585
      Width           =   2250
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   11655
      MaxLength       =   10
      TabIndex        =   23
      Text            =   "XXXXX6"
      Top             =   585
      Width           =   720
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   420
      Left            =   120
      TabIndex        =   20
      Top             =   10530
      Width           =   13605
      _ExtentX        =   23998
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
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   555
         Left            =   12195
         TabIndex        =   21
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "HIKET51.frx":030A
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "HIKET51.frx":0494
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7470
         Picture         =   "HIKET51.frx":061E
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7155
         Picture         =   "HIKET51.frx":07A8
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "HIKET51.frx":0932
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "HIKET51.frx":0ABC
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "HIKET51.frx":0C46
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "HIKET51.frx":0DD0
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "HIKET51.frx":0F5A
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "HIKET51.frx":10E4
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "HIKET51.frx":126E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "HIKET51.frx":13F8
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "HIKET51.frx":1582
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "HIKET51.frx":170C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "HIKET51.frx":1896
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "HIKET51.frx":1A20
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "HIKET51.frx":1BAA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "HIKET51.frx":1D34
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_ 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "HIKET51.frx":1EBE
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_ 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "HIKET51.frx":2048
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   32
      Left            =   -30
      TabIndex        =   18
      Top             =   0
      Width           =   16455
      _ExtentX        =   29025
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
         Left            =   12945
         TabIndex        =   19
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
         Picture         =   "HIKET51.frx":21D2
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SELECTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1410
         Picture         =   "HIKET51.frx":235C
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   915
         Picture         =   "HIKET51.frx":24E6
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   195
         Picture         =   "HIKET51.frx":2670
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   6315
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   345
      Index           =   6
      Left            =   18930
      TabIndex        =   17
      Top             =   3300
      Width           =   645
      _ExtentX        =   1138
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
      Caption         =   "�Ő�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   23
      Left            =   7935
      TabIndex        =   16
      Top             =   3900
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "�c�Ǝd��"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_LINNO 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      ForeColor       =   &H00000000&
      Height          =   675
      IMEMode         =   2  '��
      Index           =   1
      Left            =   960
      MaxLength       =   7
      TabIndex        =   15
      Text            =   "12"
      Top             =   4230
      Width           =   375
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   14
      Left            =   960
      TabIndex        =   14
      Top             =   3570
      Width           =   375
      _ExtentX        =   661
      _ExtentY        =   1191
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
      Caption         =   "No"
      OutLine         =   -1  'True
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
      TabIndex        =   13
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   28
      Left            =   12675
      TabIndex        =   12
      Top             =   3570
      Width           =   1170
      _ExtentX        =   2064
      _ExtentY        =   1191
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
      Caption         =   "�� �l"
      OutLine         =   -1  'True
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   3
         Index           =   4
         X1              =   -45
         X2              =   -45
         Y1              =   225
         Y2              =   645
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   21
      Left            =   7410
      TabIndex        =   11
      Top             =   3570
      Width           =   540
      _ExtentX        =   953
      _ExtentY        =   1191
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
      Caption         =   "�P��"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   17
      Left            =   2640
      TabIndex        =   10
      Top             =   3570
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
   Begin VB.TextBox BD_HINNMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   2640
      MaxLength       =   30
      TabIndex        =   9
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   4230
      Width           =   3315
   End
   Begin VB.TextBox BD_HINNMB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   2640
      MaxLength       =   30
      TabIndex        =   8
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3"
      Top             =   4560
      Width           =   3315
   End
   Begin VB.TextBox BD_SIKTK 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   7935
      MaxLength       =   13
      TabIndex        =   6
      Text            =   "999,999,999"
      Top             =   4560
      Width           =   1335
   End
   Begin VB.TextBox BD_UNTNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   675
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   7410
      MaxLength       =   8
      TabIndex        =   5
      Text            =   "MMM4"
      Top             =   4230
      Width           =   540
   End
   Begin VB.TextBox BD_HINCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Index           =   1
      Left            =   1320
      MaxLength       =   17
      TabIndex        =   4
      Text            =   "XXXXXXX8"
      Top             =   4230
      Width           =   1335
   End
   Begin VB.TextBox HD_JDNDT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   1695
      MaxLength       =   14
      TabIndex        =   2
      Text            =   "9999/99/99"
      Top             =   1875
      Width           =   1485
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   18
      Left            =   2640
      TabIndex        =   1
      Top             =   3900
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
      Caption         =   "�i�@�@��"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_DEFNOKDT 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   1695
      MaxLength       =   14
      TabIndex        =   0
      Text            =   "9999/99/99"
      Top             =   2580
      Width           =   1185
   End
   Begin Threed5.SSCommand5 CS_TOKCD 
      Height          =   345
      Left            =   16590
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   3300
      Width           =   1215
      _ExtentX        =   2143
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
      Caption         =   "����No."
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   705
      Index           =   20
      Left            =   6450
      TabIndex        =   34
      Top             =   3570
      Width           =   975
      _ExtentX        =   1720
      _ExtentY        =   1244
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
      Caption         =   "�� ��"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   25
      Left            =   9255
      TabIndex        =   37
      Top             =   3900
      Width           =   1365
      _ExtentX        =   2408
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
      Caption         =   "��@�@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   24
      Left            =   9255
      TabIndex        =   40
      Top             =   3570
      Width           =   1365
      _ExtentX        =   2408
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
      Caption         =   "���@�@�z"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   33
      Left            =   -75
      TabIndex        =   46
      Top             =   9090
      Width           =   16680
      _ExtentX        =   29422
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
         Index           =   34
         Left            =   675
         TabIndex        =   47
         Top             =   135
         Width           =   13995
         _ExtentX        =   24686
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
            TabIndex        =   48
            Text            =   "HIKET51.frx":27FA
            Top             =   90
            Width           =   7575
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKET51.frx":2831
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSCommand5 SSCommand56 
      Height          =   345
      Left            =   19710
      TabIndex        =   49
      TabStop         =   0   'False
      Top             =   1830
      Width           =   525
      _ExtentX        =   926
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
      Caption         =   "����"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   345
      Index           =   20
      Left            =   16590
      TabIndex        =   50
      Top             =   3690
      Width           =   1215
      _ExtentX        =   2143
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
      Caption         =   "����󒍇�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   26
      Left            =   10605
      TabIndex        =   51
      Top             =   3570
      Width           =   975
      _ExtentX        =   1720
      _ExtentY        =   1191
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
      Caption         =   "�d�ؗ�"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_LINCMB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   12675
      MaxLength       =   24
      TabIndex        =   3
      Text            =   "MMMMMMMMM1"
      Top             =   4560
      Width           =   1170
   End
   Begin VB.TextBox BD_LINCMA 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   12675
      MaxLength       =   24
      TabIndex        =   7
      Text            =   "MMMMMMMMM1"
      Top             =   4230
      Width           =   1170
   End
   Begin VB.CheckBox HD_BUN_FUKA 
      Caption         =   "�����s��"
      Enabled         =   0   'False
      Height          =   420
      Left            =   330
      TabIndex        =   53
      Top             =   2970
      Width           =   1230
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   16
      Left            =   1320
      TabIndex        =   58
      Top             =   3900
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "�q�撍���ԍ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   3
      Left            =   255
      TabIndex        =   59
      Top             =   2250
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   " �q�撍���ԍ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   8
      Left            =   9690
      TabIndex        =   61
      Top             =   1545
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
      Caption         =   " �`�[���͒S����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   255
      TabIndex        =   64
      Top             =   1545
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   " �󒍎���敪"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   255
      TabIndex        =   65
      Top             =   1875
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   " �󒍓�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   5
      Left            =   4305
      TabIndex        =   66
      Top             =   1545
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
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " ���Ӑ�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   4
      Left            =   255
      TabIndex        =   67
      Top             =   2580
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   " �q��[��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   9
      Left            =   9690
      TabIndex        =   68
      Top             =   1875
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
      Caption         =   " �c�ƒS����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   10
      Left            =   9690
      TabIndex        =   69
      Top             =   2205
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
      Caption         =   " �c�ƕ���"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   11
      Left            =   9690
      TabIndex        =   70
      Top             =   2535
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
      Caption         =   " �o�בq��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   12
      Left            =   9690
      TabIndex        =   71
      Top             =   2865
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
      Caption         =   " ����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   375
      Index           =   13
      Left            =   12690
      TabIndex        =   72
      Top             =   2835
      Width           =   600
      _ExtentX        =   1058
      _ExtentY        =   661
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
      Caption         =   "�֖�"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   22
      Left            =   7935
      TabIndex        =   73
      Top             =   3570
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "�P�@�@��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   15
      Left            =   1320
      TabIndex        =   74
      Top             =   3570
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "���i����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   19
      Left            =   5940
      TabIndex        =   75
      Top             =   3570
      Width           =   525
      _ExtentX        =   926
      _ExtentY        =   1191
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
      Caption         =   $"HIKET51.frx":29BB
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   27
      Left            =   11565
      TabIndex        =   76
      Top             =   3570
      Width           =   1125
      _ExtentX        =   1984
      _ExtentY        =   1191
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
      Caption         =   "�o�ח\���"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   0
      Left            =   10020
      TabIndex        =   77
      Top             =   585
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
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   6
      Left            =   4305
      TabIndex        =   83
      Top             =   1875
      Width           =   1005
      _ExtentX        =   1773
      _ExtentY        =   1191
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
      Caption         =   " ����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   675
      Index           =   7
      Left            =   4305
      TabIndex        =   84
      Top             =   2535
      Width           =   1005
      _ExtentX        =   1773
      _ExtentY        =   1191
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
      Caption         =   " �[����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   30
      Left            =   10680
      TabIndex        =   88
      Top             =   8265
      Width           =   1575
      _ExtentX        =   2778
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
      Caption         =   "����Ŋz"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   29
      Left            =   9120
      TabIndex        =   89
      Top             =   8265
      Width           =   1575
      _ExtentX        =   2778
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
      Caption         =   "�{�̍��v���z"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   31
      Left            =   12240
      TabIndex        =   90
      Top             =   8265
      Width           =   1575
      _ExtentX        =   2778
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
      Caption         =   "�`�[���v���z"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_HIK 
      Height          =   345
      Left            =   960
      TabIndex        =   97
      TabStop         =   0   'False
      Top             =   8490
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   "�����^����"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin VB.Image IM_SELECTCM 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   0
      Picture         =   "HIKET51.frx":29C9
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_SELECTCM 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   0
      Picture         =   "HIKET51.frx":2B53
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   0
      Picture         =   "HIKET51.frx":2CDD
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   0
      Picture         =   "HIKET51.frx":2E67
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Opt 
      Height          =   750
      Index           =   1
      Left            =   4140
      Picture         =   "HIKET51.frx":2FF1
      Top             =   9129
      Width           =   285
   End
   Begin VB.Image IM_Opt 
      Height          =   750
      Index           =   0
      Left            =   3120
      Picture         =   "HIKET51.frx":3BEB
      Top             =   9129
      Width           =   285
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
      Begin VB.Menu bar11 
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
      Caption         =   "����(&3)"
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
Private Const FM_PANEL3D1_CNT       As Integer = 35 '�p�l���R���g���[����

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
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message


    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                '��ʕ���
        .Item_Cnt = 200                             '��ʍ��ڐ�
        .Dsp_Body_Cnt = 6                           '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 17                          '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
        Set .FormCtl = FR_SSSMAIN
' === 20060920 === INSERT E
    End With

'    '���׏��p�z�񏉊���
'    Erase HIKET51_DSP_BD_DATA_Inf
'    ReDim HIKET51_DSP_BD_DATA_Inf(Main_Inf.Dsp_Base.Dsp_Body_Cnt)

    '�I�𖾍׃I�v�V�����{�^���摜�ݒ��
    Set HIKET51_Bd_Sel_Img.Click_Off_Img = IM_Opt(0)
    Set HIKET51_Bd_Sel_Img.Click_On_Img = IM_Opt(1)
    
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
    '���s
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
    '�O�y�[�W
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
    '���y�[�W
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
    '���̈ꗗ
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
    '������ʕ\���C���[�W
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
    '�����C���[�W
    CM_SELECTCM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CM_SELECTCM
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
    Set Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SELECTCM(0)
    Set Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SELECTCM(1)
    '=== �Ұ�ސݒ� ======================

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
    '�Ώی��ϔԍ��{�^��
    CS_MITNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_MITNO
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

    Index_Wk = Index_Wk + 1
    '�Ώی��ϔԍ�
    HD_MITNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_MITNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20060802 === UPDATE S - ACE)Nagasawa ���ϔԍ��͐��l���͂Ƃ���
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
' === 20180412 === UPDATE S - FJ)koroyasu ���ϔԍ��͉p����(���p�啶��)���͂Ƃ���
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20180412 === UPDATE E -
' === 20060802 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
' === 20060802 === UPDATE S - ACE)Nagasawa ���ϔԍ��͐��l���͂Ƃ���
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20180412 === UPDATE S - FJ)koroyasu ���ϔԍ��͉p����(���p�啶��)���͂Ƃ���
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(8)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20180412 === UPDATE E -
' === 20060802 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '�Ώێ󒍔ԍ��{�^��
    CS_JDNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_JDNNO
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

    Index_Wk = Index_Wk + 1
    '�Ώێ󒍔ԍ�
    HD_JDNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20061127 === UPDATE S - ACE)Nagasawa �R�[�h�̑啶���ϊ������ǉ�
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' === 20061127 === UPDATE E -

    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

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
    '�󒍎���敪
    HD_JDNTRKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
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
    '�󒍎���敪(����)
    HD_JDNTRNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNTRNM
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�`�[���t
    HD_JDNDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_JDNDT
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�q�撍���ԍ�
    HD_TOKJDNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKJDNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 23
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 23
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 23
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�q��[��
    HD_DEFNOKDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_DEFNOKDT
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����s��
    HD_BUN_FUKA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUN_FUKA
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

    Index_Wk = Index_Wk + 1
    '���Ӑ�(����)
    HD_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 5
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
    '���Ӑ�(����)
    HD_TOKRN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
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
    '�����P
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����Q
    HD_KENNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_KENNMB
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�[����(����)
    HD_NHSCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 9
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
    '�[����(���̂P)
    HD_NHSNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSNMA
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
    '�[����(���̂Q)
    HD_NHSNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_NHSNMB
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
    '�`�[���͒S����(����)
    HD_OPEID.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_OPEID
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
    '�`�[���͒S����(����)
    HD_OPENM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_OPENM
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
    '�c�ƒS����(����)
    HD_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANCD
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
    '�c�ƒS����(����)
    HD_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TANNM
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
    '�c�ƕ���(����)
    HD_BUMCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUMCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' === 20060802 === UPDATE S - ACE)Nagasawa  ����R�[�h�𕶎���ɕύX
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
' === 20060802 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
' === 20060802 === UPDATE S - ACE)Nagasawa  ����R�[�h�𕶎���ɕύX
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
' === 20060802 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�c�ƕ���(����)
    HD_BUMNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BUMNM
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
    '�o�בq��(����)
    HD_SOUCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SOUCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o�בq��(����)
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
    '����(����)
    HD_URIKJN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_URIKJN
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����(����)
    HD_URIKJNNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_URIKJNNM
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�֖�(����)
    HD_BINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BINCD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�֖�(����)
    HD_BINNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_BINNM
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

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
    '�I�𖾍׃I�v�V�����{�^��(�߸���)
    BD_SELECTB(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(1)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��
    
    Index_Wk = Index_Wk + 1
    'No
    BD_LINNO(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = "0"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���i�R�[�h
    BD_HINCD(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(1)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�q�撍���ԍ�
    BD_TOKJDNNO(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKJDNNO(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�^��
    BD_HINNMA(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�i��
    BD_HINNMB(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMB(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '��������
    BD_GNKCD(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_GNKCD(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����
    BD_UODSU(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU(1)
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
    '�P��
    BD_UNTNM(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UNTNM(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 4
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 4
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
    '�P��
    BD_UODTK(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODTK(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 11
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�c�Ǝd��
    BD_SIKTK(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKTK(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 11
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���z
    BD_UODKN(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�艿
    BD_TEIKATK(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEIKATK(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 9
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�d�ؗ�
    BD_SIKRT(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKRT(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
' === 20070201 === UPDATE S - ACE)Yano
'   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
'   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
'   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 3
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 4
' === 20070201 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_RT_1
' === 20070201 === UPDATE S - ACE)Yano
'   Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = "#,##0.0��"
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = "0.0��"
' === 20070201 === UPDATE E -
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�o�ח\���
    BD_ODNYTDT(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ODNYTDT(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_DATE_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���l�P
    BD_LINCMA(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���l�Q
    BD_LINCMB(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    For BD_Cnt = 2 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        Load BD_SELECTB(BD_Cnt)       '�I�𖾍׃I�v�V�����{�^��(�߸���(BD_Cnt)
'        Load BD_SELECT(BD_Cnt)        '�I�𖾍׃I�v�V�����{�^��
        Load BD_LINNO(BD_Cnt)         'No
        Load BD_HINCD(BD_Cnt)         '���i�R�[�h
        Load BD_TOKJDNNO(BD_Cnt)      '�q�撍���ԍ�
        Load BD_HINNMA(BD_Cnt)        '�^��
        Load BD_HINNMB(BD_Cnt)        '�i��
        Load BD_GNKCD(BD_Cnt)         '��������
        Load BD_UODSU(BD_Cnt)         '����
        Load BD_UNTNM(BD_Cnt)         '�P��
        Load BD_UODTK(BD_Cnt)         '�P��
        Load BD_SIKTK(BD_Cnt)         '�c�Ǝd��
        Load BD_UODKN(BD_Cnt)         '���z
        Load BD_TEIKATK(BD_Cnt)       '�艿
        Load BD_SIKRT(BD_Cnt)         '�d�ؗ�
        Load BD_ODNYTDT(BD_Cnt)       '�o�ח\���
        Load BD_LINCMA(BD_Cnt)        '���l�P
        Load BD_LINCMB(BD_Cnt)        '���l�Q

        Index_Wk = Index_Wk + 1
        '�I�𖾍׃I�v�V�����{�^��(�߸���)
        BD_SELECTB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        'No
        BD_LINNO(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINNO(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���i�R�[�h
        BD_HINCD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�q�撍���ԍ�
        BD_TOKJDNNO(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKJDNNO(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�^��
        BD_HINNMA(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�i��
        BD_HINNMB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '��������
        BD_GNKCD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_GNKCD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '����
        BD_UODSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�P��
        BD_UNTNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UNTNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�P��
        BD_UODTK(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODTK(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�c�Ǝd��
        BD_SIKTK(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKTK(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���z
        BD_UODKN(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UODKN(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�艿
        BD_TEIKATK(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TEIKATK(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�d�ؗ�
        BD_SIKRT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIKRT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�o�ח\���
        BD_ODNYTDT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ODNYTDT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���l�P
        BD_LINCMA(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMA(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���l�Q
        BD_LINCMB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_LINCMB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

    Next

    '///////////////
    '// �t�b�^���ҏW
    '///////////////
    Index_Wk = Index_Wk + 1
    '�����^�����{�^��
    CS_HIK.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HIK
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
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

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '�{�̍��v���z
    TL_SBAUODKN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUODKN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����Ŋz
    TL_SBAUZEKN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUZEKN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�`�[���v���z
    TL_SBAUZKKN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = TL_SBAUZKKN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_TL
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 11
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 14
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS_MINUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_LEFT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

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
    gv_bolHIKET51_LF_Enable = True

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
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
        Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
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
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
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
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
        'KEYDOWN����
        Call SSSMAIN0001.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        End If
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
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
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
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
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        End If

    Else
    '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Call CF_Set_Item_Color_MEISAI(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
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
            Call SSSMAIN0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
    
' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�����Ή�
        '�t�@���N�V�����L�[������
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
' === 20060930 === INSERT E -

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

    If gv_bolHIKET51_LF_Enable = False Then
        Exit Function
    End If
    
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
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        '������ړ�����
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -

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
    Dim Wk_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '��ʒP�ʂ̏���(�����Ȃ�)
    '�@���ו���̫������󂯎�����ꍇ�̃w�b�_���̓��������Ȃ�
    '���ו��ł��ړ��O�����ו��łȂ��ꍇ
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
'�r���������������������������������������������������������r
        'ͯ�ޕ�����
        Rtn_Chk = SSSMAIN0001.F_Ctl_Head_Chk(Main_Inf)
'�d���������������������������������������������������������d
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
' === 20060802 === INSERT S - ACE)Nagasawa ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
    If TypeOf pm_Ctl Is SSCommand5 And pm_Ctl.NAME <> CS_HIK.NAME Then
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
' === 20060802 === INSERT E

    '�A���ו����ł̎��s�ֈړ������ꍇ�������Ȃ�

    '����̫����擾����
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060907 === UPDATE S - ACE)Sejima �{�^���C���[�W������Ή�
'D    '���j���[�g�p�ې���
'D    Call F_Ctl_MN_Enabled(Main_Inf)
' === 20060907 === UPDATE ��
    '�����P
    Call Ctl_MN_Ctrl_Click
    '�����Q
    Call Ctl_MN_EditMn_Click
    '����R
    Call Ctl_MN_Oprt_Click
' === 20060907 === UPDATE E

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
    Call SSSMAIN0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
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
        Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            
            '����̫����ʒu����E�ֈړ�
            Call SSSMAIN0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
            '������ړ�����
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
' === 20061129 === UPDATE E -
        End If

    Else
        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
' === 20061129 === UPDATE S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
'        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
        Call CF_Set_Item_Color_MEISAI(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
' === 20061129 === UPDATE E -
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANG����
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
    Call SSSMAIN0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

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

' === 20061205 === INSERT S - ACE)Nagasawa VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061205 === INSERT E -

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
'            '���ڐF�ݒ�
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060802 === INSERT S - ACE)Nagasawa�@����W�{�^���Ή�
        Case TypeOf pm_Ctl Is SSCommand5
            '�{�^���̏ꍇ
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060802 === INSERT E -

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_Execute.Tag)
                '���s�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
        
                Case CInt(CM_SLIST.Tag)
                '������ʕ\���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
        
                Case CInt(CM_SELECTCM.Tag)
                '�����Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)
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

        Case CInt(CM_Execute.Tag)
            '���s�Ұ��
            Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_SLIST.Tag)
            '������ʲҰ��
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_SELECTCM.Tag)
            '�����H�Ұ��
            Call CF_Set_Prompt(IMG_SELECTCM_MSG_INF, COLOR_BLACK, Main_Inf)

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

        Case CInt(CM_Execute.Tag)
        '���s�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '������ʕ\���Ұ��
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
            '�u�I���v����
            Select Case Act_Index
                Case CInt(FR_SSSMAIN.HD_MITNO.Tag), _
                     CInt(FR_SSSMAIN.HD_MITNOV.Tag), _
                     CInt(FR_SSSMAIN.HD_JDNNO.Tag)
            
' === 20060907 === INSERT E
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
                
                Case Else
            
            End Select
' === 20060907 === INSERT E

        Case CInt(CM_SELECTCM.Tag)
        '�����Ұ��
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
            '�u�I���v����
            Select Case Act_Index
                Case CInt(FR_SSSMAIN.HD_MITNO.Tag), _
                     CInt(FR_SSSMAIN.HD_MITNOV.Tag), _
                     CInt(FR_SSSMAIN.HD_JDNNO.Tag)
            
                Case Else
' === 20060907 === INSERT E
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
            
            End Select
' === 20060907 === INSERT E

    End Select

' === 20060922 === INSERT S - ACE)Sejima �I�v�V�����{�^���ɕύX��
    Select Case pm_Ctl.NAME
        Case BD_SELECTB(1).NAME
            '�I�𖾍׃I�v�V�����{�^���C���[�W
            Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
            Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case Else

    End Select
' === 20060922 === INSERT E
    
    '����MOUSEDOWN����
    Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

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
    Dim Wk_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20070102 === INSERT S - ACE)Nagasawa �w�i�F�ύX
    Select Case Trg_Index
        Case CInt(CM_SLIST.Tag), CInt(CS_MITNO.Tag), CInt(CS_JDNNO.Tag)
        
            If Main_Inf.Dsp_Base.Head_Ok_Flg = True Then
                Exit Function
            End If
        Case Else
    End Select
' === 20070102 === INSERT E -

    '�e������ʌďo
    Select Case Trg_Index
'�����j���[
        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_Execute.Tag)
            '���s
            Call Ctl_MN_Execute_Click

'        Case CInt(MN_DeleteCM.Tag)
'            '�폜
'            Call Ctl_MN_DeleteCM_Click

        Case CInt(MN_HARDCOPY.Tag)
            '��ʈ��
            Call Ctl_MN_HARDCOPY_Click

        Case CInt(MN_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click
            Exit Function
            
        Case CInt(MN_EditMn.Tag)
            '�����Q
            Call Ctl_MN_EditMn_Click

'        Case CInt(MN_APPENDC.Tag)
'            '��ʏ�����
'            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '���ڏ�����
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '���ڕ���
            Call Ctl_MN_UnDoItem_Click

'        Case CInt(MN_ClearDE.Tag)
'            '���׍s������
'            Call Ctl_MN_ClearDE_Click
'
'        Case CInt(MN_DeleteCM.Tag)
'            '���׍s�폜
'            Call Ctl_MN_DeleteDE_Click
'
'        Case CInt(MN_InsertDE.Tag)
'            '���׍s�}��
'            Call Ctl_MN_InsertDE_Click
'
'        Case CInt(MN_UnDoDe.Tag)
'            '���׍s����
'            Call Ctl_MN_UnDoDe_Click

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
            '�I���i���ו��N���A�j
            Call Ctl_MN_SELECTCM_Click
            
'        Case CInt(MN_PREV.Tag)
'            '�O�y�[�W
'            Call Ctl_MN_PREV_Click
'
'        Case CInt(MN_NEXTCM.Tag)
'            '���y�[�W
'            Call Ctl_MN_NEXTCM_Click
                
        Case CInt(MN_Slist.Tag)
            '���̈ꗗ
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
            Call Ctl_MN_EndCm_Click
            Exit Function
            
        Case CInt(CM_Execute.Tag)
            '���s
            Call Ctl_MN_Execute_Click
            
' === 20060802 === INSERT S - ACE)Nagasawa
        Case CInt(CM_SLIST.Tag)
            '����W�\��
            Call Ctl_MN_Slist_Click
' === 20060802 === INSERT E -
        
        Case CInt(CM_SELECTCM.Tag)
            '�I���i���ו��N���A�j
            Call Ctl_MN_SELECTCM_Click
            
'���ق�
        Case CInt(CS_HIK.Tag)
            '�����^�����{�^��
            Call Ctl_CS_HIK_Click
            
        Case CInt(CS_MITNO.Tag)
            '���Ϗ�񌟍���ʌďo
            Call SSSMAIN0001.F_Ctl_CS_MITNO(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            
        Case CInt(CS_JDNNO.Tag)
            '�󒍏�񌟍���ʌďo
            Call SSSMAIN0001.F_Ctl_CS_JDNNO(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    
    End Select

    '���ו��̏ꍇ
' === 20060922 === DELETE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
'D    Select Case pm_Ctl.NAME
'D        Case BD_SELECTB(1).NAME
'D            '�I�𖾍׃I�v�V�����{�^���C���[�W
'D            Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
'D            Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Img)
'D
'D        Case Else
'D
'D    End Select
' === 20060922 === DELETE E
    
    '�X�e�[�^�X�o�[������
    Call CF_Clr_Prompt(Main_Inf)

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

    '�e������ʌďo
    Select Case Act_Index
        Case CInt(HD_MITNO.Tag)
            '�Ώی��ϔԍ���÷�Ă�̫����ړ�

        Case CInt(HD_MITNOV.Tag)
            '�Ő���÷�Ă�̫����ړ�

        Case CInt(HD_JDNNO.Tag)
            '�Ώێ󒍔ԍ���÷�Ă�̫����ړ�

    End Select

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
    Call SSSMAIN0001.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    '�s�I��
'    Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Index)
    Trg_Index = CInt(BD_SELECTB(1).Tag)
' === 20060922 === UPDATE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
'D    Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET51_Bd_Sel_Img)
' === 20060922 === UPDATE ��
    Call F_Ctl_BD_Select(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
' === 20060922 === UPDATE E
    
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

'�r���������������������������������������������������������r
    'Head_Ok_Flg = False (�w�b�_�Ƀt�H�[�J�X������ꍇ)
    If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
        '����s��g�p�\
        MN_Execute.Enabled = True
    Else
        '����s��g�p�s��
        MN_Execute.Enabled = False
    End If
    '���ʈ�������
    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     '��I�������
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
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
    '����ڏ����������
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڕ��������
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��؂��裔���
    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��R�s�[�����
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��\��t�������
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Oprt_Click
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
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
    '�u�I���v����
    Select Case Ant_Index
        Case CInt(FR_SSSMAIN.HD_MITNO.Tag), _
             CInt(FR_SSSMAIN.HD_MITNOV.Tag), _
             CInt(FR_SSSMAIN.HD_JDNNO.Tag)
    
            MN_SELECTCM.Enabled = False
        
        Case Else
            MN_SELECTCM.Enabled = True
    
    End Select
' === 20060907 === INSERT E
    '���j���[�g�p��/�s����
    '���j���[���e�ɍ��킹�ĕύX����
    '����̈ꗗ�������
    MN_Slist.Enabled = False

    '�g�p����
    '��è�ނȍ��ڂ̌����@�\������ꍇ�A�g�p��
    Select Case Me.ActiveControl.NAME
        Case HD_MITNO.NAME, HD_MITNOV.NAME, HD_JDNNO.NAME
            '�����@�\�̂�����͍��ڂ̏ꍇ

            MN_Slist.Enabled = True
    End Select
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Execute_Click
    '   �T�v�F  ���j���[����i���s�j
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

    Dim Wk_Index   As Integer
    
' === 20060908 === INSERT S - ACE)Sejima ���s�{�^���C���[�W�Ή�
    If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
' === 20060908 === INSERT E
        '�i�w�b�_�����͌�A�m�肷�铮���Ɠ����j
        Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx
        Call SSSMAIN0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, True, Main_Inf)
' === 20060908 === INSERT S - ACE)Sejima ���s�{�^���C���[�W�Ή�
    End If
' === 20060908 === INSERT E


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
    Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '�w�b�_�����͐���
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '��ʃ{�f�B��������
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)
    
' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
    '��ʐF�ݒ�
    Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
' === 20061127 === INSERT E -

    '�����t�H�[�J�X�ʒu�ݒ�
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearDE_Click
    '   �T�v�F  ���׍s������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer

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
    Call SSSMAIN0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d

    '����̫����擾����
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteDE_Click
    '   �T�v�F  ���׍s�폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EndCm_Click
    '   �T�v�F  �I��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
    Unload FR_SSSMAIN
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_SELECTCM_Click
    '   �T�v�F  �I���i���ו��N���A�j
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SELECTCM_Click() As Integer
    
    Dim Wk_Index        As Integer
    
' === 20060907 === INSERT S - ACE)Sejima �{�^���C���[�W������Ή�
    Dim Act_Index        As Integer
    
'    Act_Index = CInt(CF_Get_CCurString(FR_SSSMAIN.ActiveControl.Tag))
    Act_Index = CInt(FR_SSSMAIN.ActiveControl.Tag)
    If Act_Index <= Main_Inf.Dsp_Base.Head_Lst_Idx Then
        '�w�b�_���i���������j�ɂ���Ƃ��͏������s��Ȃ�
        Exit Function
    End If
' === 20060907 === INSERT E
    
    '��ʓ��e�������i���͍��ڂ������j
    Wk_Index = BD_SELECTB(1).Tag
' === 20060922 === UPDATE S - ACE)Sejima �I�v�V�����{�^���ɕύX��
'D    Call F_Clr_Dsp_Out(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf, HIKET51_Bd_Sel_Img)
' === 20060922 === UPDATE ��
    Call F_Clr_Dsp_Out(HIKET51_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf)
' === 20060922 === UPDATE E

    '�w�b�_�����͐���
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '��ʃ{�f�B��������
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)
    
' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
    '��ʐF�ݒ�
    Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
' === 20061127 === INSERT E -

' === 20060802 === INSERT S - ACE)Nagasawa
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)
' === 20060802 === INSERT E -
    
    '�����t�H�[�J�X�ʒu�ݒ�
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
    
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
        wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_InsertDE_Click
    '   �T�v�F  ���׍s�}��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer

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
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)
    
'�r���������������������������������������������������������r
    
    Select Case Act_Index
        '�Q�ƌ��ϔԍ�
        Case CInt(Me.HD_MITNO.Tag)
            Call CS_MITNO_Click
            
        '�Q�ƌ��ϔԍ��Ő�
        Case CInt(Me.HD_MITNOV.Tag)
            Call CS_MITNO_Click
            
' === 20060802 === INSERT S - ACE)Nagasawa  �󒍓`�[����W�Ή�
        '�󒍔ԍ�
        Case CInt(Me.HD_JDNNO.Tag)
            Call CS_JDNNO_Click
' === 20060802 === INSERT E -

        Case Else
    End Select
    
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
    
' === 20061116 === INSERT S - ACE)Yano VB�G���[�����Ή�
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' === 20061116 === INSERT E -
    
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
    '   ���́F  Function SM_AllCopy_Click
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

    '�Y�����ڂ̓\��t��
    '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
    Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)


End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_CS_HIK_Click
    '   �T�v�F  �����^�����{�^��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CS_HIK_Click() As Integer
    
    Dim Trg_Index           As Integer
' === 20061105 === INSERT S - ACE)Nagasawa �r������̒ǉ�
    Dim strMsg              As String
' === 20061105 === INSERT E -
'2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
    Dim intRet              As Integer
'2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01

    '�������ޯ���擾
    Trg_Index = CInt(FR_SSSMAIN.CS_HIK.Tag)
    
    If CF_Set_Focus_Ctl(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf) = True Then
            
' === 20060908 === INSERT S - ACE)Sejima ���Ɏ󒍂ƂȂ��Ă��錩��
        If Trim(HIKET51_DSP_DATA_Inf.MIT_JDNNO) = "" Then
' === 20060908 === INSERT E

' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
            '�X�V�������Ȃ��ꍇ�͔r������͍s��Ȃ�
            If Inp_Inf.InpJDNUPDKB = gc_strJDNUPDKB_OK Then
' === 20061129 === INSERT E -

' === 20061105 === INSERT S - ACE)Nagasawa
                '�r���`�F�b�N���s��
                Select Case CF_Chk_Lock_EXCTBZ(strMsg)
                    '����
                    Case 0
                        
                    '�r��������
                    Case 1
                        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_018, Main_Inf, "", strMsg)
                        Exit Function
                        
                    '�ُ�I��
                    Case 9
                        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_012, Main_Inf)
                        Exit Function
                        
                End Select
' === 20061105 === INSERT E -
' === 20061129 === INSERT S - ACE)Nagasawa �X�V�����`�F�b�N��ύX����
            End If
' === 20061129 === INSERT E -

'2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
            intRet = F_CHK_SOU(Main_Inf)
            If intRet <> CHK_OK Then
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_022, Main_Inf)
                Exit Function
            End If
'2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01

            '�C���^�[�t�F�[�X�i�[
            Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET51_Bd_Sel_Index), _
                                 HIKET51_DSP_DATA_Inf, _
                                 HIKET51_Interface)
                
' === 20060921 === INSERT S - ACE)Hashiri �T�u��ʕ\�����Ɍ���ʂ��\��
            FR_SSSMAIN.Hide
' === 20060921 === INSERT E

' === 20060921 === UPDATE S - ACE)Nagasawa ���[�_���\���͍s��Ȃ�
'            '�݌Ɉ����^�ʉ����\��
'            FR_SSSSUB01.Show vbModal
'' === 20060908 === INSERT S - ACE)Sejima ���Ɏ󒍂ƂȂ��Ă��錩��
'' === 20060921 === INSERT S - ACE)Hashiri ����ʂ̍ĕ\��
'            FR_SSSMAIN.Show
'' === 20060921 === INSERT E

            '�݌Ɉ����^�ʉ����\��
            FR_SSSSUB01.Show
' === 20060921 === UPDATE E -

        Else
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_E_016, Main_Inf)
        End If
' === 20060908 === INSERT E
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
    Dim strSYSDT        As String
    
    Index_Wk = CInt(SYSDT.Tag)
    '��ʓ��t
'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    
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

    Dim BD_LINNO_Top    As Integer
    Dim BD_LINNO_Height As Integer

    Dim BD_TOKJDNNO_Top    As Integer
    Dim BD_HINNMB_Top    As Integer
    Dim BD_SIKTK_Top    As Integer
    Dim BD_TEIKATK_Top    As Integer
    Dim BD_SIKRT_Top    As Integer
    Dim BD_LINCMB_Top    As Integer
    Dim BD_KHIKKB_Top    As Integer

    Dim Bd_Index        As Integer

    '�P�s�ڂ�No��Top��Height����Ƃ���
    BD_LINNO_Top = BD_LINNO(1).Top
    BD_LINNO_Height = BD_LINNO(1).Height + Hosei_Value

    '�P�s�ڢNo����碋q�撍���ԍ���܂ł̑��Έʒu���擾
    BD_TOKJDNNO_Top = BD_TOKJDNNO(1).Top - BD_LINNO_Top
    '�P�s�ڢNo����碕i����܂ł̑��Έʒu���擾
    BD_HINNMB_Top = BD_HINNMB(1).Top - BD_LINNO_Top
    '�P�s�ڢNo����碉c�Ǝd�أ�܂ł̑��Έʒu���擾
    BD_SIKTK_Top = BD_SIKTK(1).Top - BD_LINNO_Top
    '�P�s�ڢNo����碒艿��܂ł̑��Έʒu���擾
    BD_TEIKATK_Top = BD_TEIKATK(1).Top - BD_LINNO_Top
    '�P�s�ڢNo����碎d�ؗ���܂ł̑��Έʒu���擾
    BD_SIKRT_Top = BD_SIKRT(1).Top - BD_LINNO_Top
    '�P�s�ڢNo����碔��l�Q��܂ł̑��Έʒu���擾
    BD_LINCMB_Top = BD_LINCMB(1).Top - BD_LINNO_Top

    '�\���ŏI�s�܂ŏ���
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        '�z�u
        BD_SELECTB(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
'        BD_SELECT(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_LINNO(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_HINCD(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_TOKJDNNO(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TOKJDNNO_Top
        BD_HINNMA(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_HINNMB(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_HINNMB_Top
        BD_GNKCD(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_UODSU(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_UNTNM(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_UODTK(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_SIKTK(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_SIKTK_Top
        BD_UODKN(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_TEIKATK(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_TEIKATK_Top
        BD_SIKRT(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_ODNYTDT(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_LINCMA(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1)
        BD_LINCMB(Bd_Index).Top = BD_LINNO_Top + BD_LINNO_Height * (Bd_Index - 1) + BD_LINCMB_Top

        '�\��
        BD_SELECTB(Bd_Index).Visible = True
'        BD_SELECT(Bd_Index).Visible = True
        BD_LINNO(Bd_Index).Visible = True
        BD_HINCD(Bd_Index).Visible = True
        BD_TOKJDNNO(Bd_Index).Visible = True
        BD_HINNMA(Bd_Index).Visible = True
        BD_HINNMB(Bd_Index).Visible = True
        BD_GNKCD(Bd_Index).Visible = True
        BD_UODSU(Bd_Index).Visible = True
        BD_UNTNM(Bd_Index).Visible = True
        BD_UODTK(Bd_Index).Visible = True
        BD_SIKTK(Bd_Index).Visible = True
        BD_UODKN(Bd_Index).Visible = True
        BD_TEIKATK(Bd_Index).Visible = True
        BD_SIKRT(Bd_Index).Visible = True
        BD_ODNYTDT(Bd_Index).Visible = True
        BD_LINCMA(Bd_Index).Visible = True
        BD_LINCMB(Bd_Index).Visible = True

    Next

    '�X�N���[���o�[�̐ݒ�
    VS_Scrl.Top = BD_LINNO_Top
    VS_Scrl.Height = BD_LINNO_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt

End Function

Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '��ʈ���N������TRUE�Ƃ���
    PP_SSSMAIN.Operable = True
    '����̫����ʒu�ݒ�s
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()
    
    'DB�ڑ�
    Call CF_Ora_USR1_Open

    '���ʏ���������
    Call CF_Init
    
    '��ʏ��ݒ�
    Call Init_Def_Dsp
    
    '��ʓ��e������
    Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʖ��׏��ݒ�
    Call Init_Def_Body_Inf

    '��ʖ��ו�������
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '���׃��P�[�V����
    Call Set_Body_Location

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

' === 20061127 === INSERT S - ACE)Nagasawa ���ׂ̐F�ύX�Ή�
    '��ʐF�ݒ�
    Call SSSMAIN0001.CF_Set_BD_Color(Main_Inf)
' === 20061127 === INSERT E -

    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSMAIN)
    
    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)
    
End Sub

Private Sub VS_Scrl_Change()
    Debug.Print "VS_Scrl_Change"
    Call Ctl_VS_Scrl_Change(VS_Scrl)
End Sub

Private Sub BD_SELECTB_Click(Index As Integer)
    Debug.Print "BD_SELECTB_Click"
    Call Ctl_Item_Click(BD_SELECTB(Index))
End Sub

'Private Sub BD_SELECT_Click(Index As Integer)
'    Debug.Print "BD_SELECT_Click"
'    Call Ctl_Item_Click(BD_SELECT(Index))
'End Sub

Private Sub CS_HIK_Click()
    Debug.Print "CS_HIK_Click"
    Call Ctl_Item_Click(CS_HIK)
End Sub

Private Sub CS_MITNO_Click()
    Debug.Print "CS_MITNO_Click"
    Call Ctl_Item_Click(CS_MITNO)
End Sub

Private Sub CS_JDNNO_Click()
    Debug.Print "CS_JDNNO_Click"
    Call Ctl_Item_Click(CS_JDNNO)
End Sub

Private Sub CM_Execute_Click()
    Debug.Print "CM_Execute_Click"
    Call Ctl_Item_Click(CM_Execute)
End Sub

Private Sub CM_SELECTCM_Click()
    Debug.Print "CM_SELECTCM_Click"
    Call Ctl_Item_Click(CM_SELECTCM)
End Sub

Private Sub CM_SLIST_Click()
    Debug.Print "CM_SLIST_Click"
    Call Ctl_Item_Click(CM_SLIST)
End Sub

Private Sub CM_EndCm_Click()
    Debug.Print "CM_EndCm_Click"
    Call Ctl_Item_Click(CM_EndCm)
End Sub

Private Sub MN_Ctrl_Click()
    Debug.Print "MN_Ctrl_Click"
    Call Ctl_Item_Click(MN_Ctrl)
End Sub

Private Sub MN_Execute_Click()
    Debug.Print "MN_Execute_Click"
    Call Ctl_Item_Click(MN_Execute)
End Sub

'Private Sub MN_DeleteCM_Click()
'    Debug.Print "MN_DeleteCM_Click"
'    Call Ctl_Item_Click(MN_DeleteCM)
'End Sub

Private Sub MN_HARDCOPY_Click()
    Debug.Print "MN_HARDCOPY_Click"
    Call Ctl_Item_Click(MN_HARDCOPY)
End Sub

Private Sub MN_EndCm_Click()
    Debug.Print "MN_EndCm_Click"
    Call Ctl_Item_Click(MN_EndCm)
End Sub

Private Sub MN_EditMn_Click()
    Debug.Print "MN_EditMn_Click"
    Call Ctl_Item_Click(MN_EditMn)
End Sub

'Private Sub MN_APPENDC_Click()
'    Debug.Print "MN_APPENDC_Click"
'    Call Ctl_Item_Click(MN_APPENDC)
'End Sub

Private Sub MN_ClearItm_Click()
    Debug.Print "MN_ClearItm_Click"
    Call Ctl_Item_Click(MN_ClearItm)
End Sub

Private Sub MN_UnDoItem_Click()
    Debug.Print "MN_UnDoItem_Click"
    Call Ctl_Item_Click(MN_UnDoItem)
End Sub

'Private Sub MN_ClearDE_Click()
'    Debug.Print "MN_ClearDE_Click"
'    Call Ctl_Item_Click(MN_ClearDE)
'End Sub
'
'Private Sub MN_DeleteDE_Click()
'    Debug.Print "MN_DeleteDE_Click"
'    Call Ctl_Item_Click(MN_DeleteDE)
'End Sub
'
'Private Sub MN_InsertDE_Click()
'    Debug.Print "MN_InsertDE_Click"
'    Call Ctl_Item_Click(MN_InsertDE)
'End Sub
'
'Private Sub MN_UnDoDe_Click()
'    Debug.Print "MN_UnDoDe_Click"
'    Call Ctl_Item_Click(MN_UnDoDe)
'End Sub

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

Private Sub MN_Oprt_Click()
    Debug.Print "MN_Oprt_Click"
    Call Ctl_Item_Click(MN_Oprt)
End Sub

Private Sub MN_Slist_Click()
    Debug.Print "MN_Slist_Click"
    Call Ctl_Item_Click(MN_Slist)
End Sub

' === 20060802 === DELETE S - ACE)Nagasawa
'Private Sub SM_ShortCut_Click()
'    Debug.Print "SM_ShortCut_Click"
'    Call Ctl_Item_Click(SM_ShortCut)
'End Sub
' === 20060802 === DELETE E -

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

Private Sub BD_SELECTB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SELECTB_MouseDown"
    Call Ctl_Item_MouseDown(BD_SELECTB(Index), Button, Shift, X, Y)
End Sub

'Private Sub BD_SELECT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "BD_SELECT_MouseDown"
'    Call Ctl_Item_MouseDown(BD_SELECT(Index), Button, Shift, X, Y)
'End Sub

Private Sub HD_MITNOV_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNNO, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUZEKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUZEKN_MouseDown"
    Call Ctl_Item_MouseDown(TL_SBAUZEKN, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUODKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUODKN_MouseDown"
    Call Ctl_Item_MouseDown(TL_SBAUODKN, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUZKKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUZKKN_MouseDown"
    Call Ctl_Item_MouseDown(TL_SBAUZKKN, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSNMB_MouseDown"
    Call Ctl_Item_MouseDown(HD_NHSNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_NHSNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_NHSCD, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMB_MouseDown"
    Call Ctl_Item_MouseDown(HD_KENNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseDown"
    Call Ctl_Item_MouseDown(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_OPEID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_OPEID_MouseDown"
    Call Ctl_Item_MouseDown(HD_OPEID, Button, Shift, X, Y)
End Sub

Private Sub HD_OPENM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_OPENM_MouseDown"
    Call Ctl_Item_MouseDown(HD_OPENM, Button, Shift, X, Y)
End Sub

Private Sub BD_GNKCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_GNKCD_MouseDown"
    Call Ctl_Item_MouseDown(BD_GNKCD(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_URIKJN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_URIKJN_MouseDown"
    Call Ctl_Item_MouseDown(HD_URIKJN, Button, Shift, X, Y)
End Sub

Private Sub HD_BINCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BINCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_BINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKJDNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKJDNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKJDNNO, Button, Shift, X, Y)
End Sub

Private Sub BD_TOKJDNNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKJDNNO_MouseDown"
    Call Ctl_Item_MouseDown(BD_TOKJDNNO(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_URIKJNNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_URIKJNNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_URIKJNNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub BD_ODNYTDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ODNYTDT_MouseDown"
    Call Ctl_Item_MouseDown(BD_ODNYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIKRT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIKRT_MouseDown"
    Call Ctl_Item_MouseDown(BD_SIKRT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODKN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODKN_MouseDown"
    Call Ctl_Item_MouseDown(BD_UODKN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TEIKATK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TEIKATK_MouseDown"
    Call Ctl_Item_MouseDown(BD_TEIKATK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODTK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODTK_MouseDown"
    Call Ctl_Item_MouseDown(BD_UODTK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_UODSU(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_BUMNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BUMNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_BUMNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_BINNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BINNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_BINNM, Button, Shift, X, Y)
End Sub

Private Sub HD_BUMCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BUMCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_BUMCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_SOUCD, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_SOUNM, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

' === 20070127 === DELETE S - ACE)Nagasawa
'Private Sub SYSDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "SYSDT_MouseDown"
'    Call Ctl_Item_MouseDown(SYSDT, Button, Shift, X, Y)
'End Sub
' === 20070127 === DELETE E -

Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseDown"
    Call Ctl_Item_MouseDown(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_SELECTCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SELECTCM_MouseDown"
    Call Ctl_Item_MouseDown(CM_SELECTCM, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseDown"
    Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseDown"
    Call Ctl_Item_MouseDown(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub BD_LINNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINNO_MouseDown"
    Call Ctl_Item_MouseDown(BD_LINNO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMA_MouseDown"
    Call Ctl_Item_MouseDown(BD_HINNMA(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMB_MouseDown"
    Call Ctl_Item_MouseDown(BD_HINNMB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIKTK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIKTK_MouseDown"
    Call Ctl_Item_MouseDown(BD_SIKTK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UNTNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UNTNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_UNTNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINCD_MouseDown"
    Call Ctl_Item_MouseDown(BD_HINCD(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_JDNDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_JDNDT, Button, Shift, X, Y)
End Sub

Private Sub HD_DEFNOKDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DEFNOKDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_DEFNOKDT, Button, Shift, X, Y)
End Sub

Private Sub BD_LINCMB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINCMB_MouseDown"
    Call Ctl_Item_MouseDown(BD_LINCMB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_LINCMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINCMA_MouseDown"
    Call Ctl_Item_MouseDown(BD_LINCMA(Index), Button, Shift, X, Y)
End Sub

' === 20060804 === DELETE S - ACE)Nagasawa
'Private Sub FM_Panel3D1_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "FM_Panel3D1_MouseDown"
'    Call Ctl_Item_MouseDown(FM_Panel3D1(Index), Button, Shift, X, Y)
'End Sub
' === 20060804 === DELETE E -

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseMove"
    Call Ctl_Item_MouseMove(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_SELECTCM_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SELECTCM_MouseMove"
    Call Ctl_Item_MouseMove(CM_SELECTCM, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseMove"
    Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseMove"
    Call Ctl_Item_MouseMove(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub BD_SELECTB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SELECTB_MouseUp"
    Call Ctl_Item_MouseUp(BD_SELECTB(Index), Button, Shift, X, Y)
End Sub

'Private Sub BD_SELECT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "BD_SELECT_MouseUp"
'    Call Ctl_Item_MouseUp(BD_SELECT(Index), Button, Shift, X, Y)
'End Sub

Private Sub CS_HIK_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_HIK_MouseUp"
    Call Ctl_Item_MouseUp(CS_HIK, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNOV_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNOV_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNOV, Button, Shift, X, Y)
End Sub

Private Sub HD_MITNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_MITNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_MITNO, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNNO, Button, Shift, X, Y)
End Sub

Private Sub CS_MITNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_MITNO_MouseUp"
    Call Ctl_Item_MouseUp(CS_MITNO, Button, Shift, X, Y)
End Sub

Private Sub CS_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_JDNNO_MouseUp"
    Call Ctl_Item_MouseUp(CS_JDNNO, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUZEKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUZEKN_MouseUp"
    Call Ctl_Item_MouseUp(TL_SBAUZEKN, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUODKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUODKN_MouseUp"
    Call Ctl_Item_MouseUp(TL_SBAUODKN, Button, Shift, X, Y)
End Sub

Private Sub TL_SBAUZKKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TL_SBAUZKKN_MouseUp"
    Call Ctl_Item_MouseUp(TL_SBAUZKKN, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSNMB_MouseUp"
    Call Ctl_Item_MouseUp(HD_NHSNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_NHSNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_NHSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_NHSCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_NHSCD, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMB_MouseUp"
    Call Ctl_Item_MouseUp(HD_KENNMB, Button, Shift, X, Y)
End Sub

Private Sub HD_KENNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_KENNMA_MouseUp"
    Call Ctl_Item_MouseUp(HD_KENNMA, Button, Shift, X, Y)
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_OPEID_MouseUp"
    Call Ctl_Item_MouseUp(HD_OPEID, Button, Shift, X, Y)
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_OPENM_MouseUp"
    Call Ctl_Item_MouseUp(HD_OPENM, Button, Shift, X, Y)
End Sub

Private Sub BD_GNKCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_GNKCD_MouseUp"
    Call Ctl_Item_MouseUp(BD_GNKCD(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_URIKJN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_URIKJN_MouseUp"
    Call Ctl_Item_MouseUp(HD_URIKJN, Button, Shift, X, Y)
End Sub

Private Sub HD_BINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BINCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_BINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKJDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKJDNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKJDNNO, Button, Shift, X, Y)
End Sub

Private Sub BD_TOKJDNNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKJDNNO_MouseUp"
    Call Ctl_Item_MouseUp(BD_TOKJDNNO(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_URIKJNNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_URIKJNNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_URIKJNNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRNM, Button, Shift, X, Y)
End Sub

Private Sub HD_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNTRKB_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNTRKB, Button, Shift, X, Y)
End Sub

Private Sub BD_ODNYTDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ODNYTDT_MouseUp"
    Call Ctl_Item_MouseUp(BD_ODNYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIKRT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIKRT_MouseUp"
    Call Ctl_Item_MouseUp(BD_SIKRT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODKN_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODKN_MouseUp"
    Call Ctl_Item_MouseUp(BD_UODKN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TEIKATK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TEIKATK_MouseUp"
    Call Ctl_Item_MouseUp(BD_TEIKATK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODTK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODTK_MouseUp"
    Call Ctl_Item_MouseUp(BD_UODTK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UODSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UODSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_UODSU(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_BUMNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BUMNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_BUMNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_BINNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BINNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_BINNM, Button, Shift, X, Y)
End Sub

Private Sub HD_BUMCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BUMCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_BUMCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_SOUCD, Button, Shift, X, Y)
End Sub

Private Sub HD_SOUNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SOUNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_SOUNM, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub SYSDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "SYSDT_MouseUp"
    Call Ctl_Item_MouseUp(SYSDT, Button, Shift, X, Y)
End Sub

Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_Execute_MouseUp"
    Call Ctl_Item_MouseUp(CM_Execute, Button, Shift, X, Y)
End Sub

Private Sub CM_SELECTCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SELECTCM_MouseUp"
    Call Ctl_Item_MouseUp(CM_SELECTCM, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_SLIST_MouseUp"
    Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
End Sub

Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CM_EndCm_MouseUp"
    Call Ctl_Item_MouseUp(CM_EndCm, Button, Shift, X, Y)
End Sub

Private Sub BD_LINNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINNO_MouseUp"
    Call Ctl_Item_MouseUp(BD_LINNO(Index), Button, Shift, X, Y)
End Sub

Private Sub TX_CursorRest_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_CursorRest_MouseUp"
    Call Ctl_Item_MouseUp(TX_CursorRest, Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMA_MouseUp"
    Call Ctl_Item_MouseUp(BD_HINNMA(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMB_MouseUp"
    Call Ctl_Item_MouseUp(BD_HINNMB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIKTK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIKTK_MouseUp"
    Call Ctl_Item_MouseUp(BD_SIKTK(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UNTNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UNTNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_UNTNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(BD_HINCD(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_JDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_JDNDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_JDNDT, Button, Shift, X, Y)
End Sub

Private Sub HD_DEFNOKDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_DEFNOKDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_DEFNOKDT, Button, Shift, X, Y)
End Sub

Private Sub BD_LINCMB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINCMB_MouseUp"
    Call Ctl_Item_MouseUp(BD_LINCMB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_LINCMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_LINCMA_MouseUp"
    Call Ctl_Item_MouseUp(BD_LINCMA(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_BUN_FUKA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_BUN_FUKA_MouseUp"
    Call Ctl_Item_MouseUp(HD_BUN_FUKA, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SELECTB_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SELECTB_KeyDown"
    Call Ctl_Item_KeyDown(BD_SELECTB(Index), KeyCode, Shift)
End Sub

'Private Sub BD_SELECT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
'    Debug.Print "BD_SELECT_KeyDown"
'    Call Ctl_Item_KeyDown(BD_SELECT(Index), KEYCODE, Shift)
'End Sub

Private Sub HD_MITNOV_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNOV_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNOV, KeyCode, Shift)
End Sub

Private Sub HD_MITNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_MITNO, KeyCode, Shift)
End Sub

Private Sub HD_JDNNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNNO, KeyCode, Shift)
End Sub

Private Sub TL_SBAUZEKN_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUZEKN_KeyDown"
    Call Ctl_Item_KeyDown(TL_SBAUZEKN, KeyCode, Shift)
End Sub

Private Sub TL_SBAUODKN_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUODKN_KeyDown"
    Call Ctl_Item_KeyDown(TL_SBAUODKN, KeyCode, Shift)
End Sub

Private Sub TL_SBAUZKKN_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUZKKN_KeyDown"
    Call Ctl_Item_KeyDown(TL_SBAUZKKN, KeyCode, Shift)
End Sub

Private Sub HD_NHSNMB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSNMB_KeyDown"
    Call Ctl_Item_KeyDown(HD_NHSNMB, KeyCode, Shift)
End Sub

Private Sub HD_NHSNMA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_NHSNMA, KeyCode, Shift)
End Sub

Private Sub HD_NHSCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_NHSCD, KeyCode, Shift)
End Sub

Private Sub HD_KENNMB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMB_KeyDown"
    Call Ctl_Item_KeyDown(HD_KENNMB, KeyCode, Shift)
End Sub

Private Sub HD_KENNMA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMA_KeyDown"
    Call Ctl_Item_KeyDown(HD_KENNMA, KeyCode, Shift)
End Sub

Private Sub HD_OPEID_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_OPEID_KeyDown"
    Call Ctl_Item_KeyDown(HD_OPEID, KeyCode, Shift)
End Sub

Private Sub HD_OPENM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_OPENM_KeyDown"
    Call Ctl_Item_KeyDown(HD_OPENM, KeyCode, Shift)
End Sub

Private Sub BD_GNKCD_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_GNKCD_KeyDown"
    Call Ctl_Item_KeyDown(BD_GNKCD(Index), KeyCode, Shift)
End Sub

Private Sub HD_URIKJN_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_URIKJN_KeyDown"
    Call Ctl_Item_KeyDown(HD_URIKJN, KeyCode, Shift)
End Sub

Private Sub HD_BINCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BINCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_BINCD, KeyCode, Shift)
End Sub

Private Sub HD_TOKJDNNO_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKJDNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKJDNNO, KeyCode, Shift)
End Sub

Private Sub BD_TOKJDNNO_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_TOKJDNNO_KeyDown"
    Call Ctl_Item_KeyDown(BD_TOKJDNNO(Index), KeyCode, Shift)
End Sub

Private Sub HD_URIKJNNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_URIKJNNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_URIKJNNM, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRNM, KeyCode, Shift)
End Sub

Private Sub HD_JDNTRKB_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKB_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNTRKB, KeyCode, Shift)
End Sub

Private Sub BD_ODNYTDT_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_ODNYTDT_KeyDown"
    Call Ctl_Item_KeyDown(BD_ODNYTDT(Index), KeyCode, Shift)
End Sub

Private Sub BD_SIKRT_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SIKRT_KeyDown"
    Call Ctl_Item_KeyDown(BD_SIKRT(Index), KeyCode, Shift)
End Sub

Private Sub BD_UODKN_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODKN_KeyDown"
    Call Ctl_Item_KeyDown(BD_UODKN(Index), KeyCode, Shift)
End Sub

Private Sub BD_TEIKATK_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_TEIKATK_KeyDown"
    Call Ctl_Item_KeyDown(BD_TEIKATK(Index), KeyCode, Shift)
End Sub

Private Sub BD_UODTK_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODTK_KeyDown"
    Call Ctl_Item_KeyDown(BD_UODTK(Index), KeyCode, Shift)
End Sub

Private Sub BD_UODSU_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_UODSU(Index), KeyCode, Shift)
End Sub

Private Sub HD_TOKRN_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKRN, KeyCode, Shift)
End Sub

Private Sub HD_TOKCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKCD, KeyCode, Shift)
End Sub

Private Sub HD_BUMNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUMNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_BUMNM, KeyCode, Shift)
End Sub

Private Sub HD_TANNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANNM, KeyCode, Shift)
End Sub

Private Sub HD_BINNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BINNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_BINNM, KeyCode, Shift)
End Sub

Private Sub HD_BUMCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUMCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_BUMCD, KeyCode, Shift)
End Sub

Private Sub HD_TANCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TANCD, KeyCode, Shift)
End Sub

Private Sub HD_SOUCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_SOUCD, KeyCode, Shift)
End Sub

Private Sub HD_SOUNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_SOUNM, KeyCode, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KeyCode, Shift)
End Sub

Private Sub HD_IN_TANCD_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KeyCode, Shift)
End Sub

Private Sub BD_LINNO_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINNO_KeyDown"
    Call Ctl_Item_KeyDown(BD_LINNO(Index), KeyCode, Shift)
End Sub

Private Sub BD_HINNMA_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINNMA_KeyDown"
    Call Ctl_Item_KeyDown(BD_HINNMA(Index), KeyCode, Shift)
End Sub

Private Sub BD_HINNMB_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINNMB_KeyDown"
    Call Ctl_Item_KeyDown(BD_HINNMB(Index), KeyCode, Shift)
End Sub

Private Sub BD_SIKTK_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SIKTK_KeyDown"
    Call Ctl_Item_KeyDown(BD_SIKTK(Index), KeyCode, Shift)
End Sub

Private Sub BD_UNTNM_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UNTNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_UNTNM(Index), KeyCode, Shift)
End Sub

Private Sub BD_HINCD_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINCD_KeyDown"
    Call Ctl_Item_KeyDown(BD_HINCD(Index), KeyCode, Shift)
End Sub

Private Sub HD_JDNDT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_JDNDT, KeyCode, Shift)
End Sub

Private Sub HD_DEFNOKDT_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_DEFNOKDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_DEFNOKDT, KeyCode, Shift)
End Sub

Private Sub BD_LINCMB_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINCMB_KeyDown"
    Call Ctl_Item_KeyDown(BD_LINCMB(Index), KeyCode, Shift)
End Sub

Private Sub BD_LINCMA_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINCMA_KeyDown"
    Call Ctl_Item_KeyDown(BD_LINCMA(Index), KeyCode, Shift)
End Sub

Private Sub HD_BUN_FUKA_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUN_FUKA_KeyDown"
    Call Ctl_Item_KeyDown(HD_BUN_FUKA, KeyCode, Shift)
End Sub

Private Sub BD_SELECTB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SELECTB_KeyPress"
    Call Ctl_Item_KeyPress(BD_SELECTB(Index), KeyAscii)
End Sub

'Private Sub BD_SELECT_KeyPress(Index As Integer, KeyAscii As Integer)
'    Debug.Print "BD_SELECT_KeyPress"
'    Call Ctl_Item_KeyPress(BD_SELECT(Index), KeyAscii)
'End Sub

Private Sub HD_MITNOV_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNOV_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNOV, KeyAscii)
End Sub

Private Sub HD_MITNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_MITNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_MITNO, KeyAscii)
End Sub

Private Sub HD_JDNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNNO, KeyAscii)
End Sub

Private Sub TL_SBAUZEKN_KeyPress(KeyAscii As Integer)
    Debug.Print "TL_SBAUZEKN_KeyPress"
    Call Ctl_Item_KeyPress(TL_SBAUZEKN, KeyAscii)
End Sub

Private Sub TL_SBAUODKN_KeyPress(KeyAscii As Integer)
    Debug.Print "TL_SBAUODKN_KeyPress"
    Call Ctl_Item_KeyPress(TL_SBAUODKN, KeyAscii)
End Sub

Private Sub TL_SBAUZKKN_KeyPress(KeyAscii As Integer)
    Debug.Print "TL_SBAUZKKN_KeyPress"
    Call Ctl_Item_KeyPress(TL_SBAUZKKN, KeyAscii)
End Sub

Private Sub HD_NHSNMB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_NHSNMB_KeyPress"
    Call Ctl_Item_KeyPress(HD_NHSNMB, KeyAscii)
End Sub

Private Sub HD_NHSNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_NHSNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_NHSNMA, KeyAscii)
End Sub

Private Sub HD_NHSCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_NHSCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_NHSCD, KeyAscii)
End Sub

Private Sub HD_KENNMB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KENNMB_KeyPress"
    Call Ctl_Item_KeyPress(HD_KENNMB, KeyAscii)
End Sub

Private Sub HD_KENNMA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_KENNMA_KeyPress"
    Call Ctl_Item_KeyPress(HD_KENNMA, KeyAscii)
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_OPEID_KeyPress"
    Call Ctl_Item_KeyPress(HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_OPENM_KeyPress"
    Call Ctl_Item_KeyPress(HD_OPENM, KeyAscii)
End Sub

Private Sub BD_GNKCD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_GNKCD_KeyPress"
    Call Ctl_Item_KeyPress(BD_GNKCD(Index), KeyAscii)
End Sub

Private Sub HD_URIKJN_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_URIKJN_KeyPress"
    Call Ctl_Item_KeyPress(HD_URIKJN, KeyAscii)
End Sub

Private Sub HD_BINCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_BINCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_BINCD, KeyAscii)
End Sub

Private Sub HD_TOKJDNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKJDNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKJDNNO, KeyAscii)
End Sub

Private Sub BD_TOKJDNNO_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TOKJDNNO_KeyPress"
    Call Ctl_Item_KeyPress(BD_TOKJDNNO(Index), KeyAscii)
End Sub

Private Sub HD_URIKJNNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_URIKJNNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_URIKJNNM, KeyAscii)
End Sub

Private Sub HD_JDNTRNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRNM, KeyAscii)
End Sub

Private Sub HD_JDNTRKB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNTRKB_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNTRKB, KeyAscii)
End Sub

Private Sub BD_ODNYTDT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_ODNYTDT_KeyPress"
    Call Ctl_Item_KeyPress(BD_ODNYTDT(Index), KeyAscii)
End Sub

Private Sub BD_SIKRT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SIKRT_KeyPress"
    Call Ctl_Item_KeyPress(BD_SIKRT(Index), KeyAscii)
End Sub

Private Sub BD_UODKN_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UODKN_KeyPress"
    Call Ctl_Item_KeyPress(BD_UODKN(Index), KeyAscii)
End Sub

Private Sub BD_TEIKATK_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TEIKATK_KeyPress"
    Call Ctl_Item_KeyPress(BD_TEIKATK(Index), KeyAscii)
End Sub

Private Sub BD_UODTK_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UODTK_KeyPress"
    Call Ctl_Item_KeyPress(BD_UODTK(Index), KeyAscii)
End Sub

Private Sub BD_UODSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UODSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_UODSU(Index), KeyAscii)
End Sub

Private Sub HD_TOKRN_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKRN_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKRN, KeyAscii)
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_BUMNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_BUMNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_BUMNM, KeyAscii)
End Sub

Private Sub HD_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANNM, KeyAscii)
End Sub

Private Sub HD_BINNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_BINNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_BINNM, KeyAscii)
End Sub

Private Sub HD_BUMCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_BUMCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_BUMCD, KeyAscii)
End Sub

Private Sub HD_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TANCD, KeyAscii)
End Sub

Private Sub HD_SOUCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SOUCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_SOUCD, KeyAscii)
End Sub

Private Sub HD_SOUNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SOUNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_SOUNM, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub BD_LINNO_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_LINNO_KeyPress"
    Call Ctl_Item_KeyPress(BD_LINNO(Index), KeyAscii)
End Sub

Private Sub BD_HINNMA_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HINNMA_KeyPress"
    Call Ctl_Item_KeyPress(BD_HINNMA(Index), KeyAscii)
End Sub

Private Sub BD_HINNMB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HINNMB_KeyPress"
    Call Ctl_Item_KeyPress(BD_HINNMB(Index), KeyAscii)
End Sub

Private Sub BD_SIKTK_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SIKTK_KeyPress"
    Call Ctl_Item_KeyPress(BD_SIKTK(Index), KeyAscii)
End Sub

Private Sub BD_UNTNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UNTNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_UNTNM(Index), KeyAscii)
End Sub

Private Sub BD_HINCD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HINCD_KeyPress"
    Call Ctl_Item_KeyPress(BD_HINCD(Index), KeyAscii)
End Sub

Private Sub HD_JDNDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_JDNDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_JDNDT, KeyAscii)
End Sub

Private Sub HD_DEFNOKDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_DEFNOKDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_DEFNOKDT, KeyAscii)
End Sub

Private Sub BD_LINCMB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_LINCMB_KeyPress"
    Call Ctl_Item_KeyPress(BD_LINCMB(Index), KeyAscii)
End Sub

Private Sub BD_LINCMA_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_LINCMA_KeyPress"
    Call Ctl_Item_KeyPress(BD_LINCMA(Index), KeyAscii)
End Sub

Private Sub HD_BUN_FUKA_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_BUN_FUKA_KeyPress"
    Call Ctl_Item_KeyPress(HD_BUN_FUKA, KeyAscii)
End Sub

Private Sub CS_MITNO_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_MITNO_KeyUp"
    Call Ctl_Item_KeyUp(CS_MITNO)
End Sub

Private Sub CS_JDNNO_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_JDNNO_KeyUp"
    Call Ctl_Item_KeyUp(CS_JDNNO)
End Sub

'Private Sub BD_SELECTB_GotFocus(Index As Integer)
'    Debug.Print "BD_SELECTB_GotFocus"
'    Call Ctl_Item_GotFocus(BD_SELECTB(Index))
'End Sub

'Private Sub BD_SELECT_GotFocus(Index As Integer)
'    Debug.Print "BD_SELECT_GotFocus"
'    Call Ctl_Item_GotFocus(BD_SELECT(Index))
'End Sub

Private Sub CS_HIK_GotFocus()
    Debug.Print "CS_HIK_GotFocus"
    Call Ctl_Item_GotFocus(CS_HIK)
End Sub

Private Sub HD_MITNOV_GotFocus()
    Debug.Print "HD_MITNOV_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNOV)
End Sub

Private Sub HD_MITNO_GotFocus()
    Debug.Print "HD_MITNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_MITNO)
End Sub

Private Sub HD_JDNNO_GotFocus()
    Debug.Print "HD_JDNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNNO)
End Sub

Private Sub CS_MITNO_GotFocus()
    Debug.Print "CS_MITNO_GotFocus"
    Call Ctl_Item_GotFocus(CS_MITNO)
End Sub

Private Sub CS_JDNNO_GotFocus()
    Debug.Print "CS_JDNNO_GotFocus"
    Call Ctl_Item_GotFocus(CS_JDNNO)
End Sub

Private Sub TL_SBAUZEKN_GotFocus()
    Debug.Print "TL_SBAUZEKN_GotFocus"
    Call Ctl_Item_GotFocus(TL_SBAUZEKN)
End Sub

Private Sub TL_SBAUODKN_GotFocus()
    Debug.Print "TL_SBAUODKN_GotFocus"
    Call Ctl_Item_GotFocus(TL_SBAUODKN)
End Sub

Private Sub TL_SBAUZKKN_GotFocus()
    Debug.Print "TL_SBAUZKKN_GotFocus"
    Call Ctl_Item_GotFocus(TL_SBAUZKKN)
End Sub

Private Sub HD_NHSNMB_GotFocus()
    Debug.Print "HD_NHSNMB_GotFocus"
    Call Ctl_Item_GotFocus(HD_NHSNMB)
End Sub

Private Sub HD_NHSNMA_GotFocus()
    Debug.Print "HD_NHSNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_NHSNMA)
End Sub

Private Sub HD_NHSCD_GotFocus()
    Debug.Print "HD_NHSCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_NHSCD)
End Sub

Private Sub HD_KENNMB_GotFocus()
    Debug.Print "HD_KENNMB_GotFocus"
    Call Ctl_Item_GotFocus(HD_KENNMB)
End Sub

Private Sub HD_KENNMA_GotFocus()
    Debug.Print "HD_KENNMA_GotFocus"
    Call Ctl_Item_GotFocus(HD_KENNMA)
End Sub

Private Sub HD_OPEID_GotFocus()
    Debug.Print "HD_OPEID_GotFocus"
    Call Ctl_Item_GotFocus(HD_OPEID)
End Sub

Private Sub HD_OPENM_GotFocus()
    Debug.Print "HD_OPENM_GotFocus"
    Call Ctl_Item_GotFocus(HD_OPENM)
End Sub

Private Sub BD_GNKCD_GotFocus(Index As Integer)
    Debug.Print "BD_GNKCD_GotFocus"
    Call Ctl_Item_GotFocus(BD_GNKCD(Index))
End Sub

Private Sub HD_URIKJN_GotFocus()
    Debug.Print "HD_URIKJN_GotFocus"
    Call Ctl_Item_GotFocus(HD_URIKJN)
End Sub

Private Sub HD_BINCD_GotFocus()
    Debug.Print "HD_BINCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_BINCD)
End Sub

Private Sub HD_TOKJDNNO_GotFocus()
    Debug.Print "HD_TOKJDNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKJDNNO)
End Sub

Private Sub BD_TOKJDNNO_GotFocus(Index As Integer)
    Debug.Print "BD_TOKJDNNO_GotFocus"
    Call Ctl_Item_GotFocus(BD_TOKJDNNO(Index))
End Sub

Private Sub HD_URIKJNNM_GotFocus()
    Debug.Print "HD_URIKJNNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_URIKJNNM)
End Sub

Private Sub HD_JDNTRNM_GotFocus()
    Debug.Print "HD_JDNTRNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRNM)
End Sub

Private Sub HD_JDNTRKB_GotFocus()
    Debug.Print "HD_JDNTRKB_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNTRKB)
End Sub

Private Sub BD_ODNYTDT_GotFocus(Index As Integer)
    Debug.Print "BD_ODNYTDT_GotFocus"
    Call Ctl_Item_GotFocus(BD_ODNYTDT(Index))
End Sub

Private Sub BD_SIKRT_GotFocus(Index As Integer)
    Debug.Print "BD_SIKRT_GotFocus"
    Call Ctl_Item_GotFocus(BD_SIKRT(Index))
End Sub

Private Sub BD_UODKN_GotFocus(Index As Integer)
    Debug.Print "BD_UODKN_GotFocus"
    Call Ctl_Item_GotFocus(BD_UODKN(Index))
End Sub

Private Sub BD_TEIKATK_GotFocus(Index As Integer)
    Debug.Print "BD_TEIKATK_GotFocus"
    Call Ctl_Item_GotFocus(BD_TEIKATK(Index))
End Sub

Private Sub BD_UODTK_GotFocus(Index As Integer)
    Debug.Print "BD_UODTK_GotFocus"
    Call Ctl_Item_GotFocus(BD_UODTK(Index))
End Sub

Private Sub BD_UODSU_GotFocus(Index As Integer)
    Debug.Print "BD_UODSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_UODSU(Index))
End Sub

Private Sub HD_TOKRN_GotFocus()
    Debug.Print "HD_TOKRN_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKRN)
End Sub

Private Sub HD_TOKCD_GotFocus()
    Debug.Print "HD_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKCD)
End Sub

Private Sub HD_BUMNM_GotFocus()
    Debug.Print "HD_BUMNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_BUMNM)
End Sub

Private Sub HD_TANNM_GotFocus()
    Debug.Print "HD_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANNM)
End Sub

Private Sub HD_BINNM_GotFocus()
    Debug.Print "HD_BINNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_BINNM)
End Sub

Private Sub HD_BUMCD_GotFocus()
    Debug.Print "HD_BUMCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_BUMCD)
End Sub

Private Sub HD_TANCD_GotFocus()
    Debug.Print "HD_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TANCD)
End Sub

Private Sub HD_SOUCD_GotFocus()
    Debug.Print "HD_SOUCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_SOUCD)
End Sub

Private Sub HD_SOUNM_GotFocus()
    Debug.Print "HD_SOUNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_SOUNM)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub BD_LINNO_GotFocus(Index As Integer)
    Debug.Print "BD_LINNO_GotFocus"
    Call Ctl_Item_GotFocus(BD_LINNO(Index))
End Sub

Private Sub BD_HINNMA_GotFocus(Index As Integer)
    Debug.Print "BD_HINNMA_GotFocus"
    Call Ctl_Item_GotFocus(BD_HINNMA(Index))
End Sub

Private Sub BD_HINNMB_GotFocus(Index As Integer)
    Debug.Print "BD_HINNMB_GotFocus"
    Call Ctl_Item_GotFocus(BD_HINNMB(Index))
End Sub

Private Sub BD_SIKTK_GotFocus(Index As Integer)
    Debug.Print "BD_SIKTK_GotFocus"
    Call Ctl_Item_GotFocus(BD_SIKTK(Index))
End Sub

Private Sub BD_UNTNM_GotFocus(Index As Integer)
    Debug.Print "BD_UNTNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_UNTNM(Index))
End Sub

Private Sub BD_HINCD_GotFocus(Index As Integer)
    Debug.Print "BD_HINCD_GotFocus"
    Call Ctl_Item_GotFocus(BD_HINCD(Index))
End Sub

Private Sub HD_JDNDT_GotFocus()
    Debug.Print "HD_JDNDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_JDNDT)
End Sub

Private Sub HD_DEFNOKDT_GotFocus()
    Debug.Print "HD_DEFNOKDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_DEFNOKDT)
End Sub

Private Sub BD_SELECTB_GotFocus(Index As Integer)
    Debug.Print "BD_SELECTB_GotFocus"
    Call Ctl_Item_GotFocus(BD_SELECTB(Index))
End Sub

Private Sub BD_LINCMB_GotFocus(Index As Integer)
    Debug.Print "BD_LINCMB_GotFocus"
    Call Ctl_Item_GotFocus(BD_LINCMB(Index))
End Sub

Private Sub BD_LINCMA_GotFocus(Index As Integer)
    Debug.Print "BD_LINCMA_GotFocus"
    Call Ctl_Item_GotFocus(BD_LINCMA(Index))
End Sub

Private Sub HD_BUN_FUKA_GotFocus()
    Debug.Print "HD_BUN_FUKA_GotFocus"
    Call Ctl_Item_GotFocus(HD_BUN_FUKA)
End Sub

Private Sub CS_HIK_LostFocus()
    Debug.Print "CS_HIK_LostFocus"
    Call Ctl_Item_LostFocus(CS_HIK)
End Sub

Private Sub HD_MITNOV_LostFocus()
    Debug.Print "HD_MITNOV_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNOV)
End Sub

Private Sub HD_MITNO_LostFocus()
    Debug.Print "HD_MITNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_MITNO)
End Sub

Private Sub HD_JDNNO_LostFocus()
    Debug.Print "HD_JDNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNNO)
End Sub

Private Sub TL_SBAUZEKN_LostFocus()
    Debug.Print "TL_SBAUZEKN_LostFocus"
    Call Ctl_Item_LostFocus(TL_SBAUZEKN)
End Sub

Private Sub TL_SBAUODKN_LostFocus()
    Debug.Print "TL_SBAUODKN_LostFocus"
    Call Ctl_Item_LostFocus(TL_SBAUODKN)
End Sub

Private Sub TL_SBAUZKKN_LostFocus()
    Debug.Print "TL_SBAUZKKN_LostFocus"
    Call Ctl_Item_LostFocus(TL_SBAUZKKN)
End Sub

Private Sub HD_NHSNMB_LostFocus()
    Debug.Print "HD_NHSNMB_LostFocus"
    Call Ctl_Item_LostFocus(HD_NHSNMB)
End Sub

Private Sub HD_NHSNMA_LostFocus()
    Debug.Print "HD_NHSNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_NHSNMA)
End Sub

Private Sub HD_NHSCD_LostFocus()
    Debug.Print "HD_NHSCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_NHSCD)
End Sub

Private Sub HD_KENNMB_LostFocus()
    Debug.Print "HD_KENNMB_LostFocus"
    Call Ctl_Item_LostFocus(HD_KENNMB)
End Sub

Private Sub HD_KENNMA_LostFocus()
    Debug.Print "HD_KENNMA_LostFocus"
    Call Ctl_Item_LostFocus(HD_KENNMA)
End Sub

Private Sub HD_OPEID_LostFocus()
    Debug.Print "HD_OPEID_LostFocus"
    Call Ctl_Item_LostFocus(HD_OPEID)
End Sub

Private Sub HD_OPENM_LostFocus()
    Debug.Print "HD_OPENM_LostFocus"
    Call Ctl_Item_LostFocus(HD_OPENM)
End Sub

Private Sub BD_GNKCD_LostFocus(Index As Integer)
    Debug.Print "BD_GNKCD_LostFocus"
    Call Ctl_Item_LostFocus(BD_GNKCD(Index))
End Sub

Private Sub HD_URIKJN_LostFocus()
    Debug.Print "HD_URIKJN_LostFocus"
    Call Ctl_Item_LostFocus(HD_URIKJN)
End Sub

Private Sub HD_BINCD_LostFocus()
    Debug.Print "HD_BINCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_BINCD)
End Sub

Private Sub HD_TOKJDNNO_LostFocus()
    Debug.Print "HD_TOKJDNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKJDNNO)
End Sub

Private Sub BD_TOKJDNNO_LostFocus(Index As Integer)
    Debug.Print "BD_TOKJDNNO_LostFocus"
    Call Ctl_Item_LostFocus(BD_TOKJDNNO(Index))
End Sub

Private Sub HD_URIKJNNM_LostFocus()
    Debug.Print "HD_URIKJNNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_URIKJNNM)
End Sub

Private Sub HD_JDNTRNM_LostFocus()
    Debug.Print "HD_JDNTRNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRNM)
End Sub

Private Sub HD_JDNTRKB_LostFocus()
    Debug.Print "HD_JDNTRKB_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNTRKB)
End Sub

Private Sub BD_ODNYTDT_LostFocus(Index As Integer)
    Debug.Print "BD_ODNYTDT_LostFocus"
    Call Ctl_Item_LostFocus(BD_ODNYTDT(Index))
End Sub

Private Sub BD_SIKRT_LostFocus(Index As Integer)
    Debug.Print "BD_SIKRT_LostFocus"
    Call Ctl_Item_LostFocus(BD_SIKRT(Index))
End Sub

Private Sub BD_UODKN_LostFocus(Index As Integer)
    Debug.Print "BD_UODKN_LostFocus"
    Call Ctl_Item_LostFocus(BD_UODKN(Index))
End Sub

Private Sub BD_TEIKATK_LostFocus(Index As Integer)
    Debug.Print "BD_TEIKATK_LostFocus"
    Call Ctl_Item_LostFocus(BD_TEIKATK(Index))
End Sub

Private Sub BD_UODTK_LostFocus(Index As Integer)
    Debug.Print "BD_UODTK_LostFocus"
    Call Ctl_Item_LostFocus(BD_UODTK(Index))
End Sub

Private Sub BD_UODSU_LostFocus(Index As Integer)
    Debug.Print "BD_UODSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_UODSU(Index))
End Sub

Private Sub HD_TOKRN_LostFocus()
    Debug.Print "HD_TOKRN_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKRN)
End Sub

Private Sub HD_TOKCD_LostFocus()
    Debug.Print "HD_TOKCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKCD)
End Sub

Private Sub HD_BUMNM_LostFocus()
    Debug.Print "HD_BUMNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_BUMNM)
End Sub

Private Sub HD_TANNM_LostFocus()
    Debug.Print "HD_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANNM)
End Sub

Private Sub HD_BINNM_LostFocus()
    Debug.Print "HD_BINNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_BINNM)
End Sub

Private Sub HD_BUMCD_LostFocus()
    Debug.Print "HD_BUMCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_BUMCD)
End Sub

Private Sub HD_TANCD_LostFocus()
    Debug.Print "HD_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TANCD)
End Sub

Private Sub HD_SOUCD_LostFocus()
    Debug.Print "HD_SOUCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_SOUCD)
End Sub

Private Sub HD_SOUNM_LostFocus()
    Debug.Print "HD_SOUNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_SOUNM)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub BD_LINNO_LostFocus(Index As Integer)
    Debug.Print "BD_LINNO_LostFocus"
    Call Ctl_Item_LostFocus(BD_LINNO(Index))
End Sub

Private Sub BD_HINNMA_LostFocus(Index As Integer)
    Debug.Print "BD_HINNMA_LostFocus"
    Call Ctl_Item_LostFocus(BD_HINNMA(Index))
End Sub

Private Sub BD_HINNMB_LostFocus(Index As Integer)
    Debug.Print "BD_HINNMB_LostFocus"
    Call Ctl_Item_LostFocus(BD_HINNMB(Index))
End Sub

Private Sub BD_SIKTK_LostFocus(Index As Integer)
    Debug.Print "BD_SIKTK_LostFocus"
    Call Ctl_Item_LostFocus(BD_SIKTK(Index))
End Sub

Private Sub BD_UNTNM_LostFocus(Index As Integer)
    Debug.Print "BD_UNTNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_UNTNM(Index))
End Sub

Private Sub BD_HINCD_LostFocus(Index As Integer)
    Debug.Print "BD_HINCD_LostFocus"
    Call Ctl_Item_LostFocus(BD_HINCD(Index))
End Sub

Private Sub HD_JDNDT_LostFocus()
    Debug.Print "HD_JDNDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_JDNDT)
End Sub

Private Sub HD_DEFNOKDT_LostFocus()
    Debug.Print "HD_DEFNOKDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_DEFNOKDT)
End Sub

Private Sub BD_LINCMB_LostFocus(Index As Integer)
    Debug.Print "BD_LINCMB_LostFocus"
    Call Ctl_Item_LostFocus(BD_LINCMB(Index))
End Sub

Private Sub BD_LINCMA_LostFocus(Index As Integer)
    Debug.Print "BD_LINCMA_LostFocus"
    Call Ctl_Item_LostFocus(BD_LINCMA(Index))
End Sub

Private Sub HD_BUN_FUKA_LostFocus()
    Debug.Print "HD_BUN_FUKA_LostFocus"
    Call Ctl_Item_LostFocus(HD_BUN_FUKA)
End Sub

Private Sub HD_MITNOV_Change()
    Debug.Print "HD_MITNOV_Change"
    Call Ctl_Item_Change(HD_MITNOV)
End Sub

Private Sub HD_MITNO_Change()
    Debug.Print "HD_MITNO_Change"
    Call Ctl_Item_Change(HD_MITNO)
End Sub

Private Sub HD_JDNNO_Change()
    Debug.Print "HD_JDNNO_Change"
    Call Ctl_Item_Change(HD_JDNNO)
End Sub

Private Sub TL_SBAUZEKN_Change()
    Debug.Print "TL_SBAUZEKN_Change"
    Call Ctl_Item_Change(TL_SBAUZEKN)
End Sub

Private Sub TL_SBAUODKN_Change()
    Debug.Print "TL_SBAUODKN_Change"
    Call Ctl_Item_Change(TL_SBAUODKN)
End Sub

Private Sub TL_SBAUZKKN_Change()
    Debug.Print "TL_SBAUZKKN_Change"
    Call Ctl_Item_Change(TL_SBAUZKKN)
End Sub

Private Sub HD_NHSNMB_Change()
    Debug.Print "HD_NHSNMB_Change"
    Call Ctl_Item_Change(HD_NHSNMB)
End Sub

Private Sub HD_NHSNMA_Change()
    Debug.Print "HD_NHSNMA_Change"
    Call Ctl_Item_Change(HD_NHSNMA)
End Sub

Private Sub HD_NHSCD_Change()
    Debug.Print "HD_NHSCD_Change"
    Call Ctl_Item_Change(HD_NHSCD)
End Sub

Private Sub HD_KENNMB_Change()
    Debug.Print "HD_KENNMB_Change"
    Call Ctl_Item_Change(HD_KENNMB)
End Sub

Private Sub HD_KENNMA_Change()
    Debug.Print "HD_KENNMA_Change"
    Call Ctl_Item_Change(HD_KENNMA)
End Sub

Private Sub HD_OPEID_Change()
    Debug.Print "HD_OPEID_Change"
    Call Ctl_Item_Change(HD_OPEID)
End Sub

Private Sub HD_OPENM_Change()
    Debug.Print "HD_OPENM_Change"
    Call Ctl_Item_Change(HD_OPENM)
End Sub

Private Sub BD_GNKCD_Change(Index As Integer)
    Debug.Print "BD_GNKCD_Change"
    Call Ctl_Item_Change(BD_GNKCD(Index))
End Sub

Private Sub HD_URIKJN_Change()
    Debug.Print "HD_URIKJN_Change"
    Call Ctl_Item_Change(HD_URIKJN)
End Sub

Private Sub HD_BINCD_Change()
    Debug.Print "HD_BINCD_Change"
    Call Ctl_Item_Change(HD_BINCD)
End Sub

Private Sub HD_TOKJDNNO_Change()
    Debug.Print "HD_TOKJDNNO_Change"
    Call Ctl_Item_Change(HD_TOKJDNNO)
End Sub

Private Sub BD_TOKJDNNO_Change(Index As Integer)
    Debug.Print "BD_TOKJDNNO_Change"
    Call Ctl_Item_Change(BD_TOKJDNNO(Index))
End Sub

Private Sub HD_URIKJNNM_Change()
    Debug.Print "HD_URIKJNNM_Change"
    Call Ctl_Item_Change(HD_URIKJNNM)
End Sub

Private Sub HD_JDNTRNM_Change()
    Debug.Print "HD_JDNTRNM_Change"
    Call Ctl_Item_Change(HD_JDNTRNM)
End Sub

Private Sub HD_JDNTRKB_Change()
    Debug.Print "HD_JDNTRKB_Change"
    Call Ctl_Item_Change(HD_JDNTRKB)
End Sub

Private Sub BD_ODNYTDT_Change(Index As Integer)
    Debug.Print "BD_ODNYTDT_Change"
    Call Ctl_Item_Change(BD_ODNYTDT(Index))
End Sub

Private Sub BD_SIKRT_Change(Index As Integer)
    Debug.Print "BD_SIKRT_Change"
    Call Ctl_Item_Change(BD_SIKRT(Index))
End Sub

Private Sub BD_UODKN_Change(Index As Integer)
    Debug.Print "BD_UODKN_Change"
    Call Ctl_Item_Change(BD_UODKN(Index))
End Sub

Private Sub BD_TEIKATK_Change(Index As Integer)
    Debug.Print "BD_TEIKATK_Change"
    Call Ctl_Item_Change(BD_TEIKATK(Index))
End Sub

Private Sub BD_UODTK_Change(Index As Integer)
    Debug.Print "BD_UODTK_Change"
    Call Ctl_Item_Change(BD_UODTK(Index))
End Sub

Private Sub BD_UODSU_Change(Index As Integer)
    Debug.Print "BD_UODSU_Change"
    Call Ctl_Item_Change(BD_UODSU(Index))
End Sub

Private Sub HD_TOKRN_Change()
    Debug.Print "HD_TOKRN_Change"
    Call Ctl_Item_Change(HD_TOKRN)
End Sub

Private Sub HD_TOKCD_Change()
    Debug.Print "HD_TOKCD_Change"
    Call Ctl_Item_Change(HD_TOKCD)
End Sub

Private Sub HD_BUMNM_Change()
    Debug.Print "HD_BUMNM_Change"
    Call Ctl_Item_Change(HD_BUMNM)
End Sub

Private Sub HD_TANNM_Change()
    Debug.Print "HD_TANNM_Change"
    Call Ctl_Item_Change(HD_TANNM)
End Sub

Private Sub HD_BINNM_Change()
    Debug.Print "HD_BINNM_Change"
    Call Ctl_Item_Change(HD_BINNM)
End Sub

Private Sub HD_BUMCD_Change()
    Debug.Print "HD_BUMCD_Change"
    Call Ctl_Item_Change(HD_BUMCD)
End Sub

Private Sub HD_TANCD_Change()
    Debug.Print "HD_TANCD_Change"
    Call Ctl_Item_Change(HD_TANCD)
End Sub

Private Sub HD_SOUCD_Change()
    Debug.Print "HD_SOUCD_Change"
    Call Ctl_Item_Change(HD_SOUCD)
End Sub

Private Sub HD_SOUNM_Change()
    Debug.Print "HD_SOUNM_Change"
    Call Ctl_Item_Change(HD_SOUNM)
End Sub

Private Sub HD_IN_TANNM_Change()
    Debug.Print "HD_IN_TANNM_Change"
    Call Ctl_Item_Change(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_Change()
    Debug.Print "HD_IN_TANCD_Change"
    Call Ctl_Item_Change(HD_IN_TANCD)
End Sub

Private Sub BD_LINNO_Change(Index As Integer)
    Debug.Print "BD_LINNO_Change"
    Call Ctl_Item_Change(BD_LINNO(Index))
End Sub

Private Sub BD_HINNMA_Change(Index As Integer)
    Debug.Print "BD_HINNMA_Change"
    Call Ctl_Item_Change(BD_HINNMA(Index))
End Sub

Private Sub BD_HINNMB_Change(Index As Integer)
    Debug.Print "BD_HINNMB_Change"
    Call Ctl_Item_Change(BD_HINNMB(Index))
End Sub

Private Sub BD_SIKTK_Change(Index As Integer)
    Debug.Print "BD_SIKTK_Change"
    Call Ctl_Item_Change(BD_SIKTK(Index))
End Sub

Private Sub BD_UNTNM_Change(Index As Integer)
    Debug.Print "BD_UNTNM_Change"
    Call Ctl_Item_Change(BD_UNTNM(Index))
End Sub

Private Sub BD_HINCD_Change(Index As Integer)
    Debug.Print "BD_HINCD_Change"
    Call Ctl_Item_Change(BD_HINCD(Index))
End Sub

Private Sub HD_JDNDT_Change()
    Debug.Print "HD_JDNDT_Change"
    Call Ctl_Item_Change(HD_JDNDT)
End Sub

Private Sub HD_DEFNOKDT_Change()
    Debug.Print "HD_DEFNOKDT_Change"
    Call Ctl_Item_Change(HD_DEFNOKDT)
End Sub

Private Sub BD_LINCMB_Change(Index As Integer)
    Debug.Print "BD_LINCMB_Change"
    Call Ctl_Item_Change(BD_LINCMB(Index))
End Sub

Private Sub BD_LINCMA_Change(Index As Integer)
    Debug.Print "BD_LINCMA_Change"
    Call Ctl_Item_Change(BD_LINCMA(Index))
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseUp"
    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KeyCode, Shift)
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer)
    Debug.Print "TX_Message_KeyPress"
    Call Ctl_Item_KeyPress(TX_Message, KeyAscii)
End Sub

Private Sub TX_Message_GotFocus()
    Debug.Print "TX_Message_GotFocus"
    Call Ctl_Item_GotFocus(TX_Message)
End Sub

Private Sub TX_Message_LostFocus()
    Debug.Print "TX_Message_LostFocus"
    Call Ctl_Item_LostFocus(TX_Message)
End Sub

Private Sub TX_Message_Change()
    Debug.Print "TX_Message_Change"
    Call Ctl_Item_Change(TX_Message)
End Sub

Private Sub Image1_Click()
    Debug.Print "Image1_Click"
    Call Ctl_Item_Click(Image1)
End Sub

' === 20060804 === DELETE S - ACE)Nagasawa
'Private Sub Image1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "Image1_MouseDown"
'    Call Ctl_Item_MouseDown(Image1, Button, Shift, X, Y)
'End Sub
' === 20060804 === DELETE E -

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseMove"
    Call Ctl_Item_MouseMove(Image1, Button, Shift, X, Y)
End Sub

Private Sub Image1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "Image1_MouseUp"
    Call Ctl_Item_MouseUp(Image1, Button, Shift, X, Y)
End Sub

Private Sub MN_NEXTCM_Click()
    Debug.Print "MN_NEXTCM_Click"
    Call Ctl_Item_Click(MN_NEXTCM)
End Sub

Private Sub MN_PREV_Click()
    Debug.Print "MN_PREV_Click"
    Call Ctl_Item_Click(MN_PREV)
End Sub

Private Sub MN_SELECTCM_Click()
    Debug.Print "MN_SELECTCM_Click"
    Call Ctl_Item_Click(MN_SELECTCM)
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    '���b�Z�[�W�o��
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET51_A_001, Main_Inf) <> vbYes Then
        Cancel = True
        Exit Sub
    End If
' === 20060907 === INSERT S - ACE)Sejima
    Main_Inf.Dsp_Base.IsUnload = True
' === 20060907 === INSERT E
    
' === 20060802 === INSERT S - ACE)Nagasawa
    'DB�ڑ�����
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
' === 20060802 === INSERT E -

' === 20061102 === INSERT S - ACE)Yano ۸�̧�ُ����݁i�v���O�����I���j
    Call SSSWIN_LOGWRT("�v���O�����I��")
' === 20061102 === INSERT E
    
    '���ʏI�������H
    Set FR_SSSMAIN = Nothing
    
End Sub


' === 20060802 === INSERT S - ACE)Nagasawa  �G���^�[�L�[�A�łɂ��s��C��
Private Sub BD_GNKCD_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_GNKCD_KeyUp"
    Call Ctl_Item_KeyUp(BD_GNKCD(Index))
End Sub

Private Sub BD_HINCD_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINCD_KeyUp"
    Call Ctl_Item_KeyUp(BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINNMA_KeyUp"
    Call Ctl_Item_KeyUp(BD_HINNMA(Index))
End Sub

Private Sub BD_HINNMB_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_HINNMB_KeyUp"
    Call Ctl_Item_KeyUp(BD_HINNMB(Index))
End Sub

Private Sub BD_LINCMA_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINCMA_KeyUp"
    Call Ctl_Item_KeyUp(BD_LINCMA(Index))
End Sub

Private Sub BD_LINCMB_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINCMB_KeyUp"
    Call Ctl_Item_KeyUp(BD_LINCMB(Index))
End Sub

Private Sub BD_LINNO_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_LINNO_KeyUp"
    Call Ctl_Item_KeyUp(BD_LINNO(Index))
End Sub

Private Sub BD_ODNYTDT_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_ODNYTDT_KeyUp"
    Call Ctl_Item_KeyUp(BD_ODNYTDT(Index))
End Sub

Private Sub BD_SELECTB_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SELECTB_KeyUp"
    Call Ctl_Item_KeyUp(BD_SELECTB(Index))
End Sub

Private Sub BD_SIKRT_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SIKRT_KeyUp"
    Call Ctl_Item_KeyUp(BD_SIKRT(Index))
End Sub

Private Sub BD_SIKTK_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_SIKTK_KeyUp"
    Call Ctl_Item_KeyUp(BD_SIKTK(Index))
End Sub

Private Sub BD_TEIKATK_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_TEIKATK_KeyUp"
    Call Ctl_Item_KeyUp(BD_TEIKATK(Index))
End Sub

Private Sub BD_TOKJDNNO_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_TOKJDNNO_KeyUp"
    Call Ctl_Item_KeyUp(BD_TOKJDNNO(Index))
End Sub

Private Sub BD_UNTNM_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UNTNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_UNTNM(Index))
End Sub

Private Sub BD_UODKN_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODKN_KeyUp"
    Call Ctl_Item_KeyUp(BD_UODKN(Index))
End Sub

Private Sub BD_UODSU_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_UODSU(Index))
End Sub

Private Sub BD_UODTK_KeyUp(Index As Integer, KeyCode As Integer, Shift As Integer)
    Debug.Print "BD_UODTK_KeyUp"
    Call Ctl_Item_KeyUp(BD_UODTK(Index))
End Sub

Private Sub HD_BINCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BINCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_BINCD)
End Sub

Private Sub HD_BINNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BINNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_BINNM)
End Sub

Private Sub HD_BUMCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUMCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_BUMCD)
End Sub

Private Sub HD_BUMNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUMNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_BUMNM)
End Sub

Private Sub HD_BUN_FUKA_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_BUN_FUKA_KeyUp"
    Call Ctl_Item_KeyUp(HD_BUN_FUKA)
End Sub

Private Sub HD_DEFNOKDT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_DEFNOKDT_KeyUp"
    Call Ctl_Item_KeyUp(HD_DEFNOKDT)
End Sub

Private Sub HD_IN_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANNM)
End Sub

Private Sub HD_JDNDT_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNDT_KeyUp"
    Call Ctl_Item_KeyUp(HD_JDNDT)
End Sub

Private Sub HD_JDNNO_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_JDNNO)
End Sub

Private Sub HD_JDNTRKB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRKB_KeyUp"
    Call Ctl_Item_KeyUp(HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_JDNTRNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_JDNTRNM)
End Sub

Private Sub HD_KENNMA_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMA_KeyUp"
    Call Ctl_Item_KeyUp(HD_KENNMA)
End Sub

Private Sub HD_KENNMB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_KENNMB_KeyUp"
    Call Ctl_Item_KeyUp(HD_KENNMB)
End Sub

Private Sub HD_MITNO_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_MITNO)
End Sub

Private Sub HD_MITNOV_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_MITNOV_KeyUp"
    Call Ctl_Item_KeyUp(HD_MITNOV)
End Sub

Private Sub HD_NHSCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_NHSCD)
End Sub

Private Sub HD_NHSNMA_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSNMA_KeyUp"
    Call Ctl_Item_KeyUp(HD_NHSNMA)
End Sub

Private Sub HD_NHSNMB_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_NHSNMB_KeyUp"
    Call Ctl_Item_KeyUp(HD_NHSNMB)
End Sub

Private Sub HD_OPEID_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_OPEID_KeyUp"
    Call Ctl_Item_KeyUp(HD_OPEID)
End Sub

Private Sub HD_OPENM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_OPENM_KeyUp"
    Call Ctl_Item_KeyUp(HD_OPENM)
End Sub

Private Sub HD_SOUCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_SOUCD)
End Sub

Private Sub HD_SOUNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_SOUNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_SOUNM)
End Sub

Private Sub HD_TANCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_TANCD)
End Sub

Private Sub HD_TANNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_TANNM)
End Sub

Private Sub HD_TOKCD_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKCD)
End Sub

Private Sub HD_TOKJDNNO_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKJDNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKJDNNO)
End Sub

Private Sub HD_TOKRN_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKRN)
End Sub

Private Sub HD_URIKJN_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_URIKJN_KeyUp"
    Call Ctl_Item_KeyUp(HD_URIKJN)
End Sub

Private Sub HD_URIKJNNM_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "HD_URIKJNNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_URIKJNNM)
End Sub

Private Sub TL_SBAUODKN_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUODKN_KeyUp"
    Call Ctl_Item_KeyUp(TL_SBAUODKN)
End Sub

Private Sub TL_SBAUZEKN_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUZEKN_KeyUp"
    Call Ctl_Item_KeyUp(TL_SBAUZEKN)
End Sub

Private Sub TL_SBAUZKKN_KeyUp(KeyCode As Integer, Shift As Integer)
    Debug.Print "TL_SBAUZKKN_KeyUp"
    Call Ctl_Item_KeyUp(TL_SBAUZKKN)
End Sub

' === 20060802 === INSERT E -

' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�Ή�
Private Sub CS_HIK_KeyDown(KeyCode As Integer, Shift As Integer)
    Debug.Print "CS_HIK_KeyDown"
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        Call Ctl_Item_KeyDown(CS_HIK, KeyCode, Shift)
    End If
End Sub
' === 20060930 === INSERT E -
