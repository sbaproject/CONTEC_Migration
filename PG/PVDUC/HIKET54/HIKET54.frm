VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "製番引当/個別解除"
   ClientHeight    =   8685
   ClientLeft      =   45
   ClientTop       =   615
   ClientWidth     =   14880
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "HIKET54.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   9703.915
   ScaleMode       =   0  'ﾕｰｻﾞｰ
   ScaleWidth      =   15820.86
   Begin VB.TextBox BD_SOUNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   12855
      MaxLength       =   20
      TabIndex        =   36
      Text            =   "MMMMMMMMM1MMMM"
      Top             =   2280
      Width           =   1650
   End
   Begin VB.TextBox BD_WRTFSTDT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   11715
      MaxLength       =   10
      TabIndex        =   33
      Text            =   "9999/99/99"
      Top             =   2280
      Width           =   1155
   End
   Begin VB.TextBox BD_SIRRN 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   8715
      MaxLength       =   30
      TabIndex        =   32
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   2280
      Width           =   3015
   End
   Begin VB.TextBox BD_OUTRSNNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   3555
      MaxLength       =   20
      TabIndex        =   30
      Text            =   "XXXXXXXXX1XXXXXXXXX2"
      Top             =   2280
      Width           =   2175
   End
   Begin VB.TextBox BD_ORGSBNNO 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   2400
      MaxLength       =   20
      TabIndex        =   28
      Text            =   "MMMMMMMMM1"
      Top             =   2280
      Width           =   1170
   End
   Begin VB.TextBox BD_OUTYTDT 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   300
      MaxLength       =   14
      TabIndex        =   25
      Text            =   "9999/99/99"
      Top             =   2280
      Width           =   1155
   End
   Begin VB.TextBox HD_HINNMB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   5910
      MaxLength       =   50
      TabIndex        =   23
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
      Top             =   1260
      Width           =   5385
   End
   Begin VB.TextBox HD_HINCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   1500
      MaxLength       =   10
      TabIndex        =   21
      Text            =   "XXXXXXXX10"
      Top             =   1260
      Width           =   1185
   End
   Begin VB.TextBox HD_HINNMA 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   2655
      MaxLength       =   30
      TabIndex        =   20
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXX3"
      Top             =   1260
      Width           =   3285
   End
   Begin VB.TextBox HD_SBNNO 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      Left            =   1500
      MaxLength       =   12
      TabIndex        =   19
      Text            =   "XXXXXXXXXX12"
      Top             =   930
      Width           =   1364
   End
   Begin VB.OptionButton BD_SELECTB 
      Height          =   345
      Index           =   1
      Left            =   30
      TabIndex        =   17
      Top             =   2250
      Width           =   255
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   3990
      Left            =   14520
      TabIndex        =   14
      Top             =   2280
      Width           =   330
   End
   Begin VB.TextBox BD_OUTYTSU 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   1440
      MaxLength       =   8
      TabIndex        =   10
      Text            =   "-999,999"
      Top             =   2280
      Width           =   975
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Left            =   12300
      MaxLength       =   24
      TabIndex        =   8
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   675
      Width           =   2250
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   11595
      MaxLength       =   10
      TabIndex        =   7
      Text            =   "XXXXX6"
      Top             =   675
      Width           =   720
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   420
      Left            =   120
      TabIndex        =   5
      Top             =   10530
      Width           =   13605
      _ExtentX        =   23998
      _ExtentY        =   741
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFC0FF&
         Height          =   555
         Left            =   12195
         TabIndex        =   6
         Text            =   "ﾓｰﾄﾞ"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "HIKET54.frx":030A
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "HIKET54.frx":0494
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   7470
         Picture         =   "HIKET54.frx":061E
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   7155
         Picture         =   "HIKET54.frx":07A8
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "HIKET54.frx":0932
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "HIKET54.frx":0ABC
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "HIKET54.frx":0C46
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "HIKET54.frx":0DD0
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "HIKET54.frx":0F5A
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "HIKET54.frx":10E4
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "HIKET54.frx":126E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "HIKET54.frx":13F8
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "HIKET54.frx":1582
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "HIKET54.frx":170C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "HIKET54.frx":1896
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "HIKET54.frx":1A20
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "HIKET54.frx":1BAA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "HIKET54.frx":1D34
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_ 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "HIKET54.frx":1EBE
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_ 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "HIKET54.frx":2048
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   10
      Left            =   -30
      TabIndex        =   3
      Top             =   0
      Width           =   16455
      _ExtentX        =   29025
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
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
         Left            =   12885
         TabIndex        =   4
         Top             =   90
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
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
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   555
         Picture         =   "HIKET54.frx":21D2
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SELECTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1410
         Picture         =   "HIKET54.frx":235C
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   915
         Picture         =   "HIKET54.frx":24E6
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   195
         Picture         =   "HIKET54.frx":2670
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   6315
      End
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   43380
      Top             =   43380
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  'ﾌﾗｯﾄ
      BorderStyle     =   0  'なし
      Height          =   375
      IMEMode         =   2  'ｵﾌ
      Left            =   43380
      TabIndex        =   2
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   6
      Left            =   5715
      TabIndex        =   1
      Top             =   1950
      Width           =   3015
      _ExtentX        =   5318
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "得意先"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_TOKRN 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      Index           =   1
      Left            =   5715
      MaxLength       =   30
      TabIndex        =   0
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   2280
      Width           =   3015
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   3
      Left            =   1440
      TabIndex        =   9
      Top             =   1950
      Width           =   975
      _ExtentX        =   1720
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "数 量"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   11
      Left            =   -75
      TabIndex        =   11
      Top             =   7980
      Width           =   16680
      _ExtentX        =   29422
      _ExtentY        =   1296
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
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
         Index           =   12
         Left            =   675
         TabIndex        =   12
         Top             =   135
         Width           =   13995
         _ExtentX        =   24686
         _ExtentY        =   820
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'なし
            ForeColor       =   &H00000000&
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   13
            Text            =   "HIKET54.frx":27FA
            Top             =   90
            Width           =   7575
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "HIKET54.frx":2831
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   0
      Left            =   9960
      TabIndex        =   15
      Top             =   675
      Width           =   1665
      _ExtentX        =   2937
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " 入力担当者"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_HIK 
      Height          =   345
      Left            =   960
      TabIndex        =   16
      TabStop         =   0   'False
      Top             =   7410
      Width           =   1455
      _ExtentX        =   2566
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "引当／解除"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   300
      TabIndex        =   18
      Top             =   930
      Width           =   1215
      _ExtentX        =   2143
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   "*製番"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_HINCD 
      Height          =   345
      Left            =   300
      TabIndex        =   24
      TabStop         =   0   'False
      Top             =   1260
      Width           =   1215
      _ExtentX        =   2143
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*製品ｺｰﾄﾞ  "
      BevelWidth      =   1
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   300
      TabIndex        =   26
      Top             =   1950
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "出庫予定日"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   4
      Left            =   2400
      TabIndex        =   27
      Top             =   1950
      Width           =   1170
      _ExtentX        =   2064
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "受注製番"
      OutLine         =   -1  'True
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   3
         Index           =   0
         X1              =   -45
         X2              =   -45
         Y1              =   225
         Y2              =   645
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   5
      Left            =   3555
      TabIndex        =   29
      Top             =   1950
      Width           =   2175
      _ExtentX        =   3836
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "出庫理由"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   7
      Left            =   8715
      TabIndex        =   31
      Top             =   1950
      Width           =   3015
      _ExtentX        =   5318
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "仕入先"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   8
      Left            =   11715
      TabIndex        =   34
      Top             =   1950
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "登録日"
      FloodColor      =   16777215
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   9
      Left            =   12855
      TabIndex        =   35
      Top             =   1950
      Width           =   1650
      _ExtentX        =   2910
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "倉庫"
      OutLine         =   -1  'True
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   3
         Index           =   1
         X1              =   -45
         X2              =   -45
         Y1              =   225
         Y2              =   645
      End
   End
   Begin VB.Label Label1 
      Caption         =   "（支給品または製番出庫の製番）"
      Height          =   345
      Left            =   2916
      TabIndex        =   22
      Top             =   990
      Width           =   4035
   End
   Begin VB.Image IM_SELECTCM 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   0
      Picture         =   "HIKET54.frx":29BB
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_SELECTCM 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   0
      Picture         =   "HIKET54.frx":2B45
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   0
      Picture         =   "HIKET54.frx":2CCF
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Execute 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   0
      Picture         =   "HIKET54.frx":2E59
      Top             =   0
      Width           =   360
   End
   Begin VB.Image IM_Opt 
      Height          =   750
      Index           =   1
      Left            =   4140
      Picture         =   "HIKET54.frx":2FE3
      Top             =   8025
      Width           =   285
   End
   Begin VB.Image IM_Opt 
      Height          =   750
      Index           =   0
      Left            =   3120
      Picture         =   "HIKET54.frx":3BDD
      Top             =   8025
      Width           =   285
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "処理(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "実行(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_HARDCOPY 
         Caption         =   "画面印刷"
         Enabled         =   0   'False
         Visible         =   0   'False
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "終了(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "編集(&2)"
      Begin VB.Menu MN_ClearItm 
         Caption         =   "項目初期化"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "項目復元"
      End
      Begin VB.Menu Bar21 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Cut 
         Caption         =   "切り取り(&X)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "コピー(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "貼り付け(&V)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "操作(&3)"
      Begin VB.Menu MN_SELECTCM 
         Caption         =   "選択"
         Shortcut        =   {F7}
      End
      Begin VB.Menu MN_PREV 
         Caption         =   "前頁"
         Enabled         =   0   'False
         Shortcut        =   {F8}
         Visible         =   0   'False
      End
      Begin VB.Menu MN_NEXTCM 
         Caption         =   "次頁"
         Enabled         =   0   'False
         Shortcut        =   {F9}
         Visible         =   0   'False
      End
      Begin VB.Menu Bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "候補の一覧(&L&ﾆ)..."
         Shortcut        =   {F5}
      End
   End
   Begin VB.Menu SM_ShortCut 
      Caption         =   "ShortCut"
      Visible         =   0   'False
      Begin VB.Menu SM_AllCopy 
         Caption         =   "項目内容コピー(&C)"
      End
      Begin VB.Menu SM_FullPast 
         Caption         =   "項目に貼り付け(&P)"
      End
      Begin VB.Menu SM_Esc 
         Caption         =   "取消し(Esc)"
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

'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
'=== 当画面の全情報を格納 =================
Private Main_Inf    As Cls_All
'=== 当画面の全情報を格納 =================
Private Const FM_PANEL3D1_CNT       As Integer = 13 'パネルコントロール数

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Def_Dsp
    '   概要：  各画面の項目情報を設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Dsp() As Integer

    Dim Index_Wk        As Integer
    Dim BD_Cnt          As Integer
    Dim Wk_Cnt          As Integer

    '画面基礎共通情報設定
    Call CF_Init_Def_Dsp(Me, Main_Inf)
    
    '/////////////////////
    '// メッセージ共通設定
    '/////////////////////
    Set Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message


    '画面基礎情報設定
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REFERENCE                '画面分類
        .Item_Cnt = 183                             '画面項目数
        .Dsp_Body_Cnt = 15                          '画面表示明細数（０：明細なし、１〜：表示時明細数）
        .Max_Body_Cnt = 200                         '最大表示明細数（０：明細なし、１〜：最大明細数）
        .Body_Col_Cnt = 9                           '明細の列項目数
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '画面移動量
        Set .FormCtl = FR_SSSMAIN
    End With

    '選択明細オプションボタン画像設定♪
    Set HIKET54_Bd_Sel_Img.Click_Off_Img = IM_Opt(0)
    Set HIKET54_Bd_Sel_Img.Click_On_Img = IM_Opt(1)
    
    '画面項目情報
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

    '/////////////////////
    '// 全画面用制御用ｺﾝﾄﾛｰﾙ
    '/////////////////////
    '初期設定用タイマー
    Set Main_Inf.TM_StartUp_Ctl = TM_StartUp
    Main_Inf.TM_StartUp_Ctl.Interval = 1
    Main_Inf.TM_StartUp_Ctl.Enabled = True

    Index_Wk = 0
    'カーソル制御用テキスト
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
    '// メニュー部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    '処理１
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
    '実行
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
    '画面印刷
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
    '終了
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
    '処理２
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
    '項目初期化
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
    '項目復元
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
    '切り取り
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
    'コピー
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
    '貼り付け
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
    '操作３
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
    '選択
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
    '前ページ
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
    '次ページ
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
    '候補の一覧
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
    '項目内容にコピー
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
    '取り消し
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
    '項目に貼り付け
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
    '終了イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
    Set Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '実行イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
    Set Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '検索画面表示イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_Slist_Inf.Click_Off_Img = IM_Slist(0)
    Set Main_Inf.IM_Slist_Inf.Click_On_Img = IM_Slist(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    'ヘッダイメージ
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
    '検索イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SELECTCM(0)
    Set Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SELECTCM(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '処理日付
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
    '// ヘッダ部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    '製番
    HD_SBNNO.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SBNNO
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
'UPD 20160216 START C2-20160129-01
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 12
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 12
'UPD 20160216 END C2-20160129-01
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '製品コードボタン
    CS_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
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
    '製品コード
    HD_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
'''' UPD 2009/02/20  FKS) S.Nakajima    Start
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 8
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 8
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 10
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 10
'''' UPD 2009/02/20  FKS) S.Nakajima    End
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '型式
    HD_HINNMA.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 30
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_PLUS
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '品名
    HD_HINNMB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_HINNMB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 50
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 50
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ

    Index_Wk = Index_Wk + 1
    '入力担当者(ｺｰﾄﾞ)
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
    '入力担当者(名称)
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

    '///////////////
    '// ボディ部編集
    '///////////////

    Index_Wk = Index_Wk + 1
    '縦スクロール
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
    '=== 明細縦スクロールバー設定 ======================
    Set Main_Inf.Bd_Vs_Scrl = VS_Scrl
    '=== 明細縦スクロールバー設定 ======================
    
    Index_Wk = Index_Wk + 1
    '選択明細オプションボタン(ﾋﾟｸﾁｬｰ)
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

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ
    
    Index_Wk = Index_Wk + 1
    '出荷予定日
    BD_OUTYTDT(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTDT(1)
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
    '数量
    BD_OUTYTSU(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTSU(1)
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
    '元製番
    BD_ORGSBNNO(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ORGSBNNO(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '出庫理由
    BD_OUTRSNNM(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTRSNNM(1)
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
    '得意先略称
    BD_TOKRN(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(1)
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
    '仕入先略称
    BD_SIRRN(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIRRN(1)
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
    '登録日
    BD_WRTFSTDT(1).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WRTFSTDT(1)
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
    '倉庫名
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
        Load BD_SELECTB(BD_Cnt)       '選択明細オプションボタン(ﾋﾟｸﾁｬｰ(BD_Cnt)
        Load BD_OUTYTDT(BD_Cnt)       '出庫予定日
        Load BD_OUTYTSU(BD_Cnt)       '数量
        Load BD_ORGSBNNO(BD_Cnt)      '元製番
        Load BD_OUTRSNNM(BD_Cnt)      '出庫理由名
        Load BD_TOKRN(BD_Cnt)         '得意先略称
        Load BD_SIRRN(BD_Cnt)         '仕入先略称
        Load BD_WRTFSTDT(BD_Cnt)      '登録日
        Load BD_SOUNM(BD_Cnt)         '倉庫名

        Index_Wk = Index_Wk + 1
        '選択明細オプションボタン(ﾋﾟｸﾁｬｰ)
        BD_SELECTB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SELECTB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '出庫予定日
        BD_OUTYTDT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTDT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '数量
        BD_OUTYTSU(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTYTSU(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '元製番
        BD_ORGSBNNO(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_ORGSBNNO(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '出庫理由名
        BD_OUTRSNNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_OUTRSNNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '得意先略称
        BD_TOKRN(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_TOKRN(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '仕入先略称
        BD_SIRRN(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SIRRN(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '登録日
        BD_WRTFSTDT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WRTFSTDT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '倉庫名
        BD_SOUNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SOUNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

    Next

    '///////////////
    '// フッタ部編集
    '///////////////
    Index_Wk = Index_Wk + 1
    '引当／解除ボタン
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

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

    '///////////////////
    '// メッセージ部編集
    '///////////////////
    Index_Wk = Index_Wk + 1
    'メッセージ
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
    '// その他編集
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

    '上記設定内容を実際のｺﾝﾄﾛｰﾙに設定する
    Call CF_Init_Item_Property(Main_Inf)
    '画面項目情報を再設定
    Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

    '///////////////////
    '// 特別項目の再設定
    '///////////////////
    'カーソル制御用テキスト
    TX_CursorRest.TabStop = False
    TX_Message.TabStop = False
    gv_bolHIKET54_LF_Enable = True

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyReturn
    '   概要：  各項目のVBKEYRETURN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyReturn(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
        'キーフラグを元に戻す
        gv_bolKeyFlg = False
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        'ﾁｪｯｸ後移動あり
        Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyRight
    '   概要：  各項目のVBKEYRIGHT制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyRight(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYRIGHT制御
    Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYRIGHT制御(ﾌｫｰｶｽ移動なし)
            Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyDown
    '   概要：  各項目のVBKEYDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyDown(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = False

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    'ﾁｪｯｸ後移動あり
        'KEYDOWN制御
        Call SSSMAIN0001.F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '次の項目へ移動した場合
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '項目色設定
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyLeft
    '   概要：  各項目のVBKEYLEFT制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyLeft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYLEFT制御
    Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            'KEYLEFT制御(ﾌｫｰｶｽ移動あり)
            Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            'ﾁｪｯｸ後移動なし
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyUp
    '   概要：  各項目のVBKEYUP制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyUp(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
    'ﾁｪｯｸ後移動あり
        'KEYUP制御
        Call SSSMAIN0001.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '次の項目へ移動した場合
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '項目色設定
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If

    Else
    'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyDown
    '   概要：  各項目のKEYDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

    'Enter時のみフラグをON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If
            
        gv_bolKeyFlg = True
    End If

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        'ｴﾝﾀｰｷｰ押
        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
            pm_KeyCode = 0
            'ｴﾝﾀｰｷｰ制御
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '→押
        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
            pm_KeyCode = 0
            '→制御
            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '↓押
        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
            pm_KeyCode = 0
            '↓制御
            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '←押
        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
            pm_KeyCode = 0
            '←制御
            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '↑押
        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
            '↑制御
            pm_KeyCode = 0
            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'DELETE押
        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'INSERT押
        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'TAB押
        Case pm_KeyCode = vbKeyF16
            pm_KeyCode = 0
            'ｴﾝﾀｰｷｰ制御
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'Shift+TAB押
        Case pm_KeyCode = vbKeyF15
            pm_KeyCode = 0
            '前ﾌｫｰｶｽ位置へ移動
            Call SSSMAIN0001.F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
    
        'ファンクションキー押下時
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)

    End Select
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_LostFocus
    '   概要：  各項目のLOSTFOCUS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer
 
    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    If gv_bolHIKET54_LF_Enable = False Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    'ﾛｽﾄﾌｫｰｶｽ実行判定
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
    
    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
        'ﾁｪｯｸ後移動あり
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_GotFocus
    '   概要：  各項目のGOTFOCUS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_GotFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Rtn_Chk     As Integer
    Dim Wk_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    '画面単位の処理(ﾁｪｯｸなど)
    '�@明細部でﾌｫｰｶｽを受け取った場合のヘッダ部の入力ﾁｪｯｸなど
    '明細部でかつ移動前が明細部でない場合
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        'ﾍｯﾀﾞ部ﾁｪｯｸ
        Rtn_Chk = SSSMAIN0001.F_Ctl_Head_Chk(Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If
    
    If TypeOf pm_Ctl Is SSCommand5 And pm_Ctl.NAME <> CS_HIK.NAME Then
        '検索画面呼出の場合は終了
        Exit Function
    End If
    
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
        '明細行コントロールか判定
        If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
            '明細検索ボタンの明細行数変数に同じ行数を設定
            For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                    '設定済みの場合は終了
                    Exit For
                End If
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
            Next
        End If
    Else
        '明細検索ボタンの明細行数変数を初期化
        For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
            If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                '設定済みの場合は終了
                Exit For
            End If
            Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
        Next
    End If

    '�A明細部内での次行へ移動した場合のﾁｪｯｸなど

    '共通ﾌｫｰｶｽ取得処理
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

    '処理１
    Call Ctl_MN_Ctrl_Click
    '処理２
    Call Ctl_MN_EditMn_Click
    '操作３
    Call Ctl_MN_Oprt_Click

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyPress
    '   概要：  各項目のKEYPRESS制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyPress(pm_Ctl As Control, ByRef pm_KeyAscii As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '共通KEYPRESS制御
    Call SSSMAIN0001.CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
        
        If Rtn_Chk = CHK_OK Then
        'チェックＯＫ時
            '取得内容表示
            Dsp_Mode = DSP_SET
        Else
        'チェックＮＧ時
            '取得内容クリア
            Dsp_Mode = DSP_CLR
        End If
        '取得内容表示/クリア
        Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
        
        If Chk_Move_Flg = True Then
            
            '現在ﾌｫｰｶｽ位置から右へ移動
            Call SSSMAIN0001.F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
            'ﾁｪｯｸ後移動あり
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

            '項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
        End If

    Else
        '項目色設定(入力開始で色をﾌｫｰｶｽありの前景色＝黒に設定！！)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  各項目のCHANG制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index    As Integer

    If Main_Inf.Dsp_Base.Change_Flg = True Then
        Main_Inf.Dsp_Base.Change_Flg = False
        Exit Function
    End If

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    '共通KEYCHANG制御
    Call SSSMAIN0001.CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

    '画面単位の処理(ﾁｪｯｸなど)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseUp
    '   概要：  各項目のMOUSEUP制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseUp(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)

        Case TypeOf pm_Ctl Is SSPanel5
            'パネルの場合
            Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is SSCommand5
            'ボタンの場合
            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If

        Case TypeOf pm_Ctl Is Image
            'イメージの場合
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '終了ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_Execute.Tag)
                '実行ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
        
                Case CInt(CM_SLIST.Tag)
                '検索画面表示ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
        
                Case CInt(CM_SELECTCM.Tag)
                '検索ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)
            End Select

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseMove
    '   概要：  各項目のMOUSEMOVE制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseMove(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(Image1.Tag)
            'ｲﾒｰｼﾞ１初期化
            Call CF_Clr_Prompt(Main_Inf)

        Case CInt(CM_EndCm.Tag)
            '終了ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_Execute.Tag)
            '実行ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_EXECUTE2_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_SLIST.Tag)
            '検索画面ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)

        Case CInt(CM_SELECTCM.Tag)
            '検索？ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_SELECTCM_MSG_INF, COLOR_BLACK, Main_Inf)

    End Select
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseDown
    '   概要：  各項目のMOUSEDOWN制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '終了ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '実行ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '検索画面表示ｲﾒｰｼﾞ
            '「選択」判定
            Select Case Act_Index
                Case CInt(FR_SSSMAIN.HD_SBNNO.Tag), _
                     CInt(FR_SSSMAIN.HD_HINCD.Tag)
            
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
                
                Case Else
            
            End Select

        Case CInt(CM_SELECTCM.Tag)
        '検索ｲﾒｰｼﾞ
            '「選択」判定
            Select Case Act_Index
                Case CInt(FR_SSSMAIN.HD_SBNNO.Tag), _
                     CInt(FR_SSSMAIN.HD_HINCD.Tag)
            
                Case Else
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)
            
            End Select

    End Select

    Select Case pm_Ctl.NAME
        Case BD_SELECTB(1).NAME
            '選択明細オプションボタンイメージ
            Call F_Set_BD_Sel_Index(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf, HIKET54_Bd_Sel_Index)
            Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case Else

    End Select
    
    '共通MOUSEDOWN制御
    Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Click
    '   概要：  各項目のCLICK制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Wk_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(CM_SLIST.Tag), CInt(CS_HINCD.Tag)
        
            If Main_Inf.Dsp_Base.Head_Ok_Flg = True Then
                Exit Function
            End If
        Case Else
    End Select

    '各検索画面呼出
    Select Case Trg_Index
'■メニュー
        Case CInt(MN_Ctrl.Tag)
            '処理１
            Call Ctl_MN_Ctrl_Click

        Case CInt(MN_Execute.Tag)
            '実行
            Call Ctl_MN_Execute_Click

'        Case CInt(MN_DeleteCM.Tag)
'            '削除
'            Call Ctl_MN_DeleteCM_Click

        Case CInt(MN_HARDCOPY.Tag)
            '画面印刷
            Call Ctl_MN_HARDCOPY_Click

        Case CInt(MN_EndCm.Tag)
            '終了
            Call Ctl_MN_EndCm_Click
            Exit Function
            
        Case CInt(MN_EditMn.Tag)
            '処理２
            Call Ctl_MN_EditMn_Click

'        Case CInt(MN_APPENDC.Tag)
'            '画面初期化
'            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '項目初期化
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '項目復元
            Call Ctl_MN_UnDoItem_Click

'        Case CInt(MN_ClearDE.Tag)
'            '明細行初期化
'            Call Ctl_MN_ClearDE_Click
'
'        Case CInt(MN_DeleteCM.Tag)
'            '明細行削除
'            Call Ctl_MN_DeleteDE_Click
'
'        Case CInt(MN_InsertDE.Tag)
'            '明細行挿入
'            Call Ctl_MN_InsertDE_Click
'
'        Case CInt(MN_UnDoDe.Tag)
'            '明細行復元
'            Call Ctl_MN_UnDoDe_Click

        Case CInt(MN_Cut.Tag)
            '切り取り
            Call Ctl_MN_Cut_Click

        Case CInt(MN_Copy.Tag)
            'コピー
            Call Ctl_MN_Copy_Click

        Case CInt(MN_Paste.Tag)
            '貼り付け
            Call Ctl_MN_Paste_Click

        Case CInt(MN_Oprt.Tag)
            '操作３
            Call Ctl_MN_Oprt_Click

        Case CInt(MN_SELECTCM.Tag)
            '選択（明細部クリア）
            Call Ctl_MN_SELECTCM_Click
            
'        Case CInt(MN_PREV.Tag)
'            '前ページ
'            Call Ctl_MN_PREV_Click
'
'        Case CInt(MN_NEXTCM.Tag)
'            '次ページ
'            Call Ctl_MN_NEXTCM_Click
                
        Case CInt(MN_Slist.Tag)
            '候補の一覧
            Call Ctl_MN_Slist_Click

        Case CInt(SM_AllCopy.Tag)
            '項目内容にコピー
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '取り消し
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '項目に貼り付け
            Call Ctl_SM_FullPast_Click

'■メニューイメージ
        Case CInt(CM_EndCm.Tag)
            '終了
            Call Ctl_MN_EndCm_Click
            Exit Function
            
        Case CInt(CM_Execute.Tag)
            '実行
            Call Ctl_MN_Execute_Click
            
        Case CInt(CM_SLIST.Tag)
            '検索W表示
            Call Ctl_MN_Slist_Click
        
        Case CInt(CM_SELECTCM.Tag)
            '選択（明細部クリア）
            Call Ctl_MN_SELECTCM_Click
            
'■ほか
        Case CInt(CS_HIK.Tag)
            '引当／解除ボタン
            Call Ctl_CS_HIK_Click
            
        Case CInt(CS_HINCD.Tag)
            '製品検索画面呼出
            Call SSSMAIN0001.F_Ctl_CS_HINCD(Main_Inf)
            
    End Select

    'ステータスバー初期化
    Call CF_Clr_Prompt(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyUp
    '   概要：  各項目のCLICK制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Act_Index   As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(pm_Ctl.Tag)

    'キーフラグを元に戻す
    gv_bolKeyFlg = False

    '各検索画面呼出
    Select Case Act_Index
        Case CInt(HD_SBNNO.Tag)
            '製番のﾃｷｽﾄへﾌｫｰｶｽ移動

        Case CInt(HD_HINCD.Tag)
            '製品ｺｰﾄﾞのﾃｷｽﾄへﾌｫｰｶｽ移動

    End Select

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_VS_Scrl_Change
    '   概要：  縦スクロールのCHANGE制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_VS_Scrl_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Act_Index   As Integer

    If Main_Inf.Dsp_Base.VS_Scr_Flg = True Then
        Main_Inf.Dsp_Base.VS_Scr_Flg = False
        Exit Function
    End If

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '共通VS_SCRL_CHANGE制御
    Call SSSMAIN0001.CF_Ctl_VS_Scrl_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    '行選択
    Trg_Index = CInt(BD_SELECTB(1).Tag)
    Call F_Ctl_BD_Select(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Ctrl_Click
    '   概要：  メニュー処理１の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Ctrl_Click() As Integer

    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'Head_Ok_Flg = False (ヘッダにフォーカスがある場合)
    If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
        '｢実行｣使用可能
        MN_Execute.Enabled = True
    Else
        '｢実行｣使用不可
        MN_Execute.Enabled = False
    End If
    '｢画面印刷｣判定
    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     '｢終了｣判定
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EditMn_Click
    '   概要：  メニュー処理２の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '｢項目初期化｣判定
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢項目復元｣判定
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢切り取り｣判定
    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢コピー｣判定
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢貼り付け｣判定
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Oprt_Click
    '   概要：  メニュー操作３の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer


    Dim Ant_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '「選択」判定
    Select Case Ant_Index
        Case CInt(FR_SSSMAIN.HD_SBNNO.Tag), _
             CInt(FR_SSSMAIN.HD_HINCD.Tag)
    
            MN_SELECTCM.Enabled = False
        
        Case Else
            MN_SELECTCM.Enabled = True
    
    End Select
    'メニュー使用可/不可制御
    'メニュー内容に合わせて変更する
    '｢候補の一覧｣初期化
    MN_Slist.Enabled = False

    '使用可制御
    'ｱｸﾃｨﾌﾞな項目の検索機能がある場合、使用可
    Select Case Me.ActiveControl.NAME
        Case HD_HINCD.NAME
            '検索機能のある入力項目の場合

            MN_Slist.Enabled = True
    End Select
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Execute_Click
    '   概要：  メニュー動作（実行）
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

    Dim Wk_Index   As Integer
    
    If Main_Inf.Dsp_Base.Head_Ok_Flg = False Then
        '（ヘッダ部入力後、確定する動きと同じ）
        Wk_Index = Main_Inf.Dsp_Base.Head_Lst_Idx
        Call SSSMAIN0001.F_Set_Next_Focus(Main_Inf.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, True, Main_Inf)
    End If


End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_APPENDC_Click
    '   概要：  画面初期化制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_APPENDC_Click() As Integer

    '画面内容初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

    'ヘッダ部入力制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '画面ボディ部初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)
    
    '初期フォーカス位置設定
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearDE_Click
    '   概要：  明細行初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_ClearItm_Click
    '   概要：  項目初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearItm_Click() As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '画面内容初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp(Act_Index, Main_Inf)
    
    Select Case Me.ActiveControl.NAME
        Case HD_HINCD.NAME
            Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), DSP_CLR, Main_Inf)
    End Select

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '共通ﾌｫｰｶｽ取得処理
    Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Copy_Click
    '   概要：  コピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目のコピー
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Cut_Click
    '   概要：  切り取り
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Cut_Click() As Integer

    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の切り取り
    Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    '項目初期化
    Call Ctl_MN_ClearItm_Click

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteCM_Click
    '   概要：  削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteCM_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteDE_Click
    '   概要：  明細行削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EndCm_Click
    '   概要：  終了
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
    Unload FR_SSSMAIN
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_SELECTCM_Click
    '   概要：  選択（明細部クリア）
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SELECTCM_Click() As Integer
    
    Dim Wk_Index        As Integer
    
    Dim Act_Index        As Integer
    
    Act_Index = CInt(FR_SSSMAIN.ActiveControl.Tag)
    If Act_Index <= Main_Inf.Dsp_Base.Head_Lst_Idx Then
        'ヘッダ部（検索条件）にいるときは処理を行わない
        Exit Function
    End If
    
    '画面内容初期化（入力項目を除く）
    Wk_Index = BD_SELECTB(1).Tag
    Call F_Clr_Dsp_Out(HIKET54_Bd_Sel_Index, Main_Inf.Dsp_Sub_Inf(Wk_Index), Main_Inf)

    'ヘッダ部入力制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
    '画面ボディ部初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)
    
    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)
    
    '初期フォーカス位置設定
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_HARDCOPY_Click
    '   概要：  画面印刷
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer

    Dim wk_Cursor As Integer
    
    'Operable=TRUEの時のみok
    If PP_SSSMAIN.Operable = False Then
        Exit Function
    End If
    'ハードコピーイベント実行
    If SSSMAIN_Hardcopy_Getevent() Then
        wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_InsertDE_Click
    '   概要：  明細行挿入
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Paste_Click
    '   概要：  貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Paste_Click() As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Slist_Click
    '   概要：  項目の一覧
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer

    Dim Act_Index   As Integer

    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)
    
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    
    Select Case Act_Index
        '参照見積番号
        Case CInt(Me.HD_HINCD.Tag)
            Call CS_HINCD_Click
            
        Case Else
    End Select
    
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UnDoDe_Click
    '   概要：  明細行復元
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoDe_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UnDoItem_Click
    '   概要：  項目復元
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
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
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の復元処理
    Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
    
    Move_Flg = False
    Chk_Move_Flg = True
    
    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)
    
    If Rtn_Chk = CHK_OK Then
    'チェックＯＫ時
        '取得内容表示
        Dsp_Mode = DSP_SET
    Else
    'チェックＮＧ時
        '取得内容クリア
        Dsp_Mode = DSP_CLR
    End If
    '取得内容表示/クリア
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
    
    '選択状態の設定（初期選択）
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)
    
    '項目色設定
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function SM_AllCopy_Click
    '   概要：  項目内容にコピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_AllCopy_Click() As Integer

    '項目内容にコピー
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_SM_Esc_Click
    '   概要：  取り消し
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_SM_FullPast_Click
    '   概要：  項目に貼り付け
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_FullPast_Click() As Integer
    Dim Act_Index   As Integer
    
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
    
    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    '注）メニューの画面｢貼り付け｣と同一関数を使用！！
    Call SSSMAIN0003.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)


End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CS_HIK_Click
    '   概要：  引当／解除ボタン
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CS_HIK_Click() As Integer
    
    Dim Trg_Index           As Integer
    Dim strMsg              As String

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(FR_SSSMAIN.CS_HIK.Tag)
    
    If CF_Set_Focus_Ctl(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf) = True Then
            
        '更新権限がない場合は排他制御は行わない
        If Inp_Inf.InpJDNUPDKB = gc_strJDNUPDKB_OK Then

            '排他チェックを行う
            Select Case CF_Chk_Lock_EXCTBZ(strMsg)
                '正常
                Case 0
                    
                '排他処理中
                Case 1
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_018, Main_Inf, "", strMsg)
                    Exit Function
                    
                '異常終了
                Case 9
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, Main_Inf)
                    Exit Function
                    
            End Select
            
' add 20170616 start
            '排他チェックを行う
            Select Case CF_Chk_Lock_EXCTBZ2(strMsg)
                '正常
                Case 0
                    
                '排他処理中
                Case 1
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_018, Main_Inf, "", strMsg)
                    Exit Function
                    
                '異常終了
                Case 9
                    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_E_012, Main_Inf)
                    Exit Function
                    
            End Select
' add 20170616 end
        End If

        'インターフェース格納
'''' UPD 2012/03/13  FKS) T.Yamamoto    Start    連絡票��FC12031301
'        Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET54_Bd_Sel_Index), _
'                             HIKET54_DSP_DATA_Inf, _
'                             HIKET54_Interface)
        Call F_Set_Interface(Main_Inf.Dsp_Body_Inf.Row_Inf(HIKET54_Bd_Sel_Index), _
                             HIKET54_DSP_DATA_Inf, _
                             HIKET54_Interface, _
                             HIKET54_Bd_Sel_Index)
'''' UPD 2012/03/13  FKS) T.Yamamoto    End
            
        FR_SSSMAIN.Hide

        '在庫引当／個別解除表示
        FR_SSSSUB01.Show

    End If


End Function

' add 20170616 start
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CF_Chk_Lock_EXCTBZ2
'   概要：　排他制御処理
'   引数：　Pot_strMsg       : エラー内容
'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function CF_Chk_Lock_EXCTBZ2(ByRef pot_strMsg As String) As Integer
    
    Dim intRet          As Integer
    Dim strMsg          As String
    Dim bolTrn          As Boolean
    
On Error GoTo CF_Chk_Lock_EXCTBZ_Err

    CF_Chk_Lock_EXCTBZ2 = 9
    pot_strMsg = ""
    bolTrn = False
    
    intRet = AE_Execute_PLSQL_EXCTBZ_2("C", strMsg)
    If intRet <> 0 Then
        '排他エラー
        pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ2 = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'トランザクションの開始
    Call CF_Ora_BeginTrans(gv_Oss_USR1)
    bolTrn = True
    
    '排他制御
    intRet = AE_Execute_PLSQL_EXCTBZ_2("W", strMsg)
    If intRet <> 0 Then
        '排他エラー
        pot_strMsg = strMsg
        CF_Chk_Lock_EXCTBZ2 = intRet
        GoTo CF_Chk_Lock_EXCTBZ_Err
    End If
    
    'コミット
    Call CF_Ora_CommitTrans(gv_Oss_USR1)
    bolTrn = False
    
    CF_Chk_Lock_EXCTBZ2 = 0
    
    Exit Function
    
CF_Chk_Lock_EXCTBZ_Err:

    'ロールバック
    If bolTrn = True Then
        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
    End If
    
End Function
' add 20170616 end

'□□□□□□□□ 全画面ローカル共通処理 End □□□□□□□□□□□□□□□□

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Edi_Dsp_Def
    '   概要：  初期時の画面編集
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Edi_Dsp_Def() As Integer
    Dim Index_Wk        As Integer
    Dim strSYSDT        As String
    
    Index_Wk = CInt(SYSDT.Tag)
    '画面日付
'   Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    strSYSDT = Mid(GV_UNYDate, 1, 4) & "/" & Mid(GV_UNYDate, 5, 2) & "/" & Mid(GV_UNYDate, 7, 2)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(strSYSDT, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Def_Body_Inf
    '   概要：  画面ボディ情報設定
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Body_Inf() As Integer

    Dim Bd_Col_Index    As Integer
    Dim Index_Wk        As Integer

    '初期画面ボディ情報設定
    Call CF_Init_Set_Body_Inf(Main_Inf)

    If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
    '明細行が存在する場合

        '画面ボディの列分の配列定義
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '初期状態
        Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT

        '初期化用設定
        '画面ボディの列分の配列定義
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '初期状態
        Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
        
        '復元情報設定
        '列分の復元行の配列定義
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '初期状態
        Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
        
        '画面ボディ情報の配列０番目に列情報を定義する
        For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
            '画面ボディ情報
            Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
            
            '初期化用情報
            Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
            
            '復元情報
            Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
        Next

    End If

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Set_Body_Location
    '   概要：  明細の配置
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Set_Body_Location() As Integer

    Const Hosei_Value     As Integer = -20

    Dim BD_OUTYTDT_Top    As Integer
    Dim BD_OUTYTDT_Height As Integer

    Dim BD_OUTYTSU_Top    As Integer
    Dim BD_ORGSBNNO_Top   As Integer
    Dim BD_OUTRSNNM_Top   As Integer
    Dim BD_TOKRN_Top      As Integer
    Dim BD_SIRRN_Top      As Integer
    Dim BD_WRTFSTDT_Top   As Integer
    Dim BD_SOUNM_Top      As Integer

    Dim Bd_Index          As Integer

    '１行目のNoのTopとHeightを基準とする
    BD_OUTYTDT_Top = BD_OUTYTDT(1).Top
    BD_OUTYTDT_Height = BD_OUTYTDT(1).Height + Hosei_Value

    '１行目｢入出庫日｣から｢数量｣までの相対位置を取得
    BD_OUTYTSU_Top = BD_OUTYTSU(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢元製番｣までの相対位置を取得
    BD_ORGSBNNO_Top = BD_ORGSBNNO(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢出庫理由名｣までの相対位置を取得
    BD_OUTRSNNM_Top = BD_OUTRSNNM(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢得意先略称｣までの相対位置を取得
    BD_TOKRN_Top = BD_TOKRN(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢仕入先略称｣までの相対位置を取得
    BD_SIRRN_Top = BD_SIRRN(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢登録日｣までの相対位置を取得
    BD_WRTFSTDT_Top = BD_WRTFSTDT(1).Top - BD_OUTYTDT_Top
    '１行目｢入出庫日｣から｢倉庫名｣までの相対位置を取得
    BD_SOUNM_Top = BD_SOUNM(1).Top - BD_OUTYTDT_Top

    '表示最終行まで処理
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        '配置
        BD_SELECTB(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_OUTYTDT(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_OUTYTSU(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_ORGSBNNO(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_OUTRSNNM(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_TOKRN(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_SIRRN(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_WRTFSTDT(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)
        BD_SOUNM(Bd_Index).Top = BD_OUTYTDT_Top + BD_OUTYTDT_Height * (Bd_Index - 1)

        '表示
        BD_SELECTB(Bd_Index).Visible = True
        BD_OUTYTDT(Bd_Index).Visible = True
        BD_OUTYTSU(Bd_Index).Visible = True
        BD_ORGSBNNO(Bd_Index).Visible = True
        BD_OUTRSNNM(Bd_Index).Visible = True
        BD_TOKRN(Bd_Index).Visible = True
        BD_SIRRN(Bd_Index).Visible = True
        BD_WRTFSTDT(Bd_Index).Visible = True
        BD_SOUNM(Bd_Index).Visible = True

    Next

    'スクロールバーの設定
    VS_Scrl.Top = BD_OUTYTDT_Top
    VS_Scrl.Height = BD_OUTYTDT_Height * Main_Inf.Dsp_Base.Dsp_Body_Cnt

End Function

Private Sub TM_StartUp_Timer()
    '一度きりのため使用不可
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '画面印刷起動時はTRUEとする
    PP_SSSMAIN.Operable = True
    '初期ﾌｫｰｶｽ位置設定s
    Call SSSMAIN0001.F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()
    
    'DB接続
    Call CF_Ora_USR1_Open

    '共通初期化処理
    Call CF_Init
    
    '画面情報設定
    Call Init_Def_Dsp
    
    '画面内容初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp(-1, Main_Inf)

    '画面明細情報設定
    Call Init_Def_Body_Inf

    '画面明細部初期化
    Call SSSMAIN0001.F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '明細ロケーション
    Call Set_Body_Location

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)
    
    '画面表示位置設定
    Call CF_Set_Frm_Location(FR_SSSMAIN)
    
    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    'システム共通処理
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

Private Sub CS_HIK_Click()
    Debug.Print "CS_HIK_Click"
    Call Ctl_Item_Click(CS_HIK)
End Sub

Private Sub CS_HINCD_Click()
    Debug.Print "CS_HINCD_Click"
    Call Ctl_Item_Click(CS_HINCD)
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

'Private Sub SM_ShortCut_Click()
'    Debug.Print "SM_ShortCut_Click"
'    Call Ctl_Item_Click(SM_ShortCut)
'End Sub

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

Private Sub HD_SBNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseDown"
    Call Ctl_Item_MouseDown(HD_SBNNO, Button, Shift, X, Y)
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

Private Sub BD_SELECTB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SELECTB_MouseDown"
    Call Ctl_Item_MouseDown(BD_SELECTB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTYTDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTYTDT_MouseDown"
    Call Ctl_Item_MouseDown(BD_OUTYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTYTSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTYTSU_MouseDown"
    Call Ctl_Item_MouseDown(BD_OUTYTSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ORGSBNNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ORGSBNNO_MouseDown"
    Call Ctl_Item_MouseDown(BD_ORGSBNNO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTRSNNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTRSNNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_OUTRSNNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TOKRN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKRN_MouseDown"
    Call Ctl_Item_MouseDown(BD_TOKRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIRRN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIRRN_MouseDown"
    Call Ctl_Item_MouseDown(BD_SIRRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WRTFSTDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WRTFSTDT_MouseDown"
    Call Ctl_Item_MouseDown(BD_WRTFSTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_SOUNM(Index), Button, Shift, X, Y)
End Sub

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

Private Sub CS_HIK_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_HIK_MouseUp"
    Call Ctl_Item_MouseUp(CS_HIK, Button, Shift, X, Y)
End Sub

Private Sub CS_HINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_HINCD, Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SBNNO_MouseUp"
    Call Ctl_Item_MouseUp(HD_SBNNO, Button, Shift, X, Y)
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

Private Sub BD_SELECTB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SELECTB_MouseUp"
    Call Ctl_Item_MouseUp(BD_SELECTB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTYTDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTYTDT_MouseUp"
    Call Ctl_Item_MouseUp(BD_OUTYTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTYTSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTYTSU_MouseUp"
    Call Ctl_Item_MouseUp(BD_OUTYTSU(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_ORGSBNNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_ORGSBNNO_MouseUp"
    Call Ctl_Item_MouseUp(BD_ORGSBNNO(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_OUTRSNNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_OUTRSNNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_OUTRSNNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_TOKRN_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_TOKRN_MouseUp"
    Call Ctl_Item_MouseUp(BD_TOKRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SIRRN_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SIRRN_MouseUp"
    Call Ctl_Item_MouseUp(BD_SIRRN(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WRTFSTDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WRTFSTDT_MouseUp"
    Call Ctl_Item_MouseUp(BD_WRTFSTDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SOUNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SOUNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_SOUNM(Index), Button, Shift, X, Y)
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

Private Sub TX_CursorRest_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_CursorRest_MouseUp"
    Call Ctl_Item_MouseUp(TX_CursorRest, Button, Shift, X, Y)
End Sub

Private Sub FM_Panel3D1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "FM_Panel3D1_MouseUp"
    Call Ctl_Item_MouseUp(FM_Panel3D1(Index), Button, Shift, X, Y)
End Sub

Private Sub HD_SBNNO_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyDown"
    Call Ctl_Item_KeyDown(HD_SBNNO, KEYCODE, Shift)
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

Private Sub BD_SELECTB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SELECTB_KeyDown"
    Call Ctl_Item_KeyDown(BD_SELECTB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_OUTYTDT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTYTDT_KeyDown"
    Call Ctl_Item_KeyDown(BD_OUTYTDT(Index), KEYCODE, Shift)
End Sub

Private Sub BD_OUTYTSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTYTSU_KeyDown"
    Call Ctl_Item_KeyDown(BD_OUTYTSU(Index), KEYCODE, Shift)
End Sub

Private Sub BD_ORGSBNNO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ORGSBNNO_KeyDown"
    Call Ctl_Item_KeyDown(BD_ORGSBNNO(Index), KEYCODE, Shift)
End Sub

Private Sub BD_OUTRSNNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTRSNNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_OUTRSNNM(Index), KEYCODE, Shift)
End Sub

Private Sub BD_TOKRN_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TOKRN_KeyDown"
    Call Ctl_Item_KeyDown(BD_TOKRN(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SIRRN_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SIRRN_KeyDown"
    Call Ctl_Item_KeyDown(BD_SIRRN(Index), KEYCODE, Shift)
End Sub

Private Sub BD_WRTFSTDT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WRTFSTDT_KeyDown"
    Call Ctl_Item_KeyDown(BD_WRTFSTDT(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SOUNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_SOUNM(Index), KEYCODE, Shift)
End Sub

Private Sub HD_SBNNO_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SBNNO_KeyPress"
    Call Ctl_Item_KeyPress(HD_SBNNO, KeyAscii)
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

Private Sub BD_SELECTB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SELECTB_KeyPress"
    Call Ctl_Item_KeyPress(BD_SELECTB(Index), KeyAscii)
End Sub

Private Sub BD_OUTYTDT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_OUTYTDT_KeyPress"
    Call Ctl_Item_KeyPress(BD_OUTYTDT(Index), KeyAscii)
End Sub

Private Sub BD_OUTYTSU_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_OUTYTSU_KeyPress"
    Call Ctl_Item_KeyPress(BD_OUTYTSU(Index), KeyAscii)
End Sub

Private Sub BD_ORGSBNNO_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_ORGSBNNO_KeyPress"
    Call Ctl_Item_KeyPress(BD_ORGSBNNO(Index), KeyAscii)
End Sub

Private Sub BD_OUTRSNNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_OUTRSNNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_OUTRSNNM(Index), KeyAscii)
End Sub

Private Sub BD_TOKRN_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_TOKRN_KeyPress"
    Call Ctl_Item_KeyPress(BD_TOKRN(Index), KeyAscii)
End Sub

Private Sub BD_SIRRN_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SIRRN_KeyPress"
    Call Ctl_Item_KeyPress(BD_SIRRN(Index), KeyAscii)
End Sub

Private Sub BD_WRTFSTDT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_WRTFSTDT_KeyPress"
    Call Ctl_Item_KeyPress(BD_WRTFSTDT(Index), KeyAscii)
End Sub

Private Sub BD_SOUNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SOUNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_SOUNM(Index), KeyAscii)
End Sub

Private Sub CS_HINCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_HINCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_HINCD)
End Sub

Private Sub CS_HIK_GotFocus()
    Debug.Print "CS_HIK_GotFocus"
    Call Ctl_Item_GotFocus(CS_HIK)
End Sub

Private Sub CS_HINCD_GotFocus()
    Debug.Print "CS_HINCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_HINCD)
End Sub

Private Sub HD_SBNNO_GotFocus()
    Debug.Print "HD_SBNNO_GotFocus"
    Call Ctl_Item_GotFocus(HD_SBNNO)
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

Private Sub BD_SELECTB_GotFocus(Index As Integer)
    Debug.Print "BD_SELECTB_GotFocus"
    Call Ctl_Item_GotFocus(BD_SELECTB(Index))
End Sub

Private Sub BD_OUTYTDT_GotFocus(Index As Integer)
    Debug.Print "BD_OUTYTDT_GotFocus"
    Call Ctl_Item_GotFocus(BD_OUTYTDT(Index))
End Sub

Private Sub BD_OUTYTSU_GotFocus(Index As Integer)
    Debug.Print "BD_OUTYTSU_GotFocus"
    Call Ctl_Item_GotFocus(BD_OUTYTSU(Index))
End Sub

Private Sub BD_ORGSBNNO_GotFocus(Index As Integer)
    Debug.Print "BD_ORGSBNNO_GotFocus"
    Call Ctl_Item_GotFocus(BD_ORGSBNNO(Index))
End Sub

Private Sub BD_OUTRSNNM_GotFocus(Index As Integer)
    Debug.Print "BD_OUTRSNNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_OUTRSNNM(Index))
End Sub

Private Sub BD_TOKRN_GotFocus(Index As Integer)
    Debug.Print "BD_TOKRN_GotFocus"
    Call Ctl_Item_GotFocus(BD_TOKRN(Index))
End Sub

Private Sub BD_SIRRN_GotFocus(Index As Integer)
    Debug.Print "BD_SIRRN_GotFocus"
    Call Ctl_Item_GotFocus(BD_SIRRN(Index))
End Sub

Private Sub BD_WRTFSTDT_GotFocus(Index As Integer)
    Debug.Print "BD_WRTFSTDT_GotFocus"
    Call Ctl_Item_GotFocus(BD_WRTFSTDT(Index))
End Sub

Private Sub BD_SOUNM_GotFocus(Index As Integer)
    Debug.Print "BD_SOUNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_SOUNM(Index))
End Sub

Private Sub CS_HIK_LostFocus()
    Debug.Print "CS_HIK_LostFocus"
    Call Ctl_Item_LostFocus(CS_HIK)
End Sub

Private Sub HD_SBNNO_LostFocus()
    Debug.Print "HD_SBNNO_LostFocus"
    Call Ctl_Item_LostFocus(HD_SBNNO)
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

Private Sub BD_OUTYTDT_LostFocus(Index As Integer)
    Debug.Print "BD_OUTYTDT_LostFocus"
    Call Ctl_Item_LostFocus(BD_OUTYTDT(Index))
End Sub

Private Sub BD_OUTYTSU_LostFocus(Index As Integer)
    Debug.Print "BD_OUTYTSU_LostFocus"
    Call Ctl_Item_LostFocus(BD_OUTYTSU(Index))
End Sub

Private Sub BD_ORGSBNNO_LostFocus(Index As Integer)
    Debug.Print "BD_ORGSBNNO_LostFocus"
    Call Ctl_Item_LostFocus(BD_ORGSBNNO(Index))
End Sub

Private Sub BD_OUTRSNNM_LostFocus(Index As Integer)
    Debug.Print "BD_OUTRSNNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_OUTRSNNM(Index))
End Sub

Private Sub BD_TOKRN_LostFocus(Index As Integer)
    Debug.Print "BD_TOKRN_LostFocus"
    Call Ctl_Item_LostFocus(BD_TOKRN(Index))
End Sub

Private Sub BD_SIRRN_LostFocus(Index As Integer)
    Debug.Print "BD_SIRRN_LostFocus"
    Call Ctl_Item_LostFocus(BD_SIRRN(Index))
End Sub

Private Sub BD_WRTFSTDT_LostFocus(Index As Integer)
    Debug.Print "BD_WRTFSTDT_LostFocus"
    Call Ctl_Item_LostFocus(BD_WRTFSTDT(Index))
End Sub

Private Sub BD_SOUNM_LostFocus(Index As Integer)
    Debug.Print "BD_SOUNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_SOUNM(Index))
End Sub

Private Sub HD_SBNNO_Change()
    Debug.Print "HD_SBNNO_Change"
    Call Ctl_Item_Change(HD_SBNNO)
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

Private Sub BD_OUTYTDT_Change(Index As Integer)
    Debug.Print "BD_OUTYTDT_Change"
    Call Ctl_Item_Change(BD_OUTYTDT(Index))
End Sub

Private Sub BD_OUTYTSU_Change(Index As Integer)
    Debug.Print "BD_OUTYTSU_Change"
    Call Ctl_Item_Change(BD_OUTYTSU(Index))
End Sub

Private Sub BD_ORGSBNNO_Change(Index As Integer)
    Debug.Print "BD_ORGSBNNO_Change"
    Call Ctl_Item_Change(BD_ORGSBNNO(Index))
End Sub

Private Sub BD_OUTRSNNM_Change(Index As Integer)
    Debug.Print "BD_OUTRSNNM_Change"
    Call Ctl_Item_Change(BD_OUTRSNNM(Index))
End Sub

Private Sub BD_TOKRN_Change(Index As Integer)
    Debug.Print "BD_TOKRN_Change"
    Call Ctl_Item_Change(BD_TOKRN(Index))
End Sub

Private Sub BD_SIRRN_Change(Index As Integer)
    Debug.Print "BD_SIRRN_Change"
    Call Ctl_Item_Change(BD_SIRRN(Index))
End Sub

Private Sub BD_WRTFSTDT_Change(Index As Integer)
    Debug.Print "BD_WRTFSTDT_Change"
    Call Ctl_Item_Change(BD_WRTFSTDT(Index))
End Sub

Private Sub BD_SOUNM_Change(Index As Integer)
    Debug.Print "BD_SOUNM_Change"
    Call Ctl_Item_Change(BD_SOUNM(Index))
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseDown"
    Call Ctl_Item_MouseDown(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "TX_Message_MouseUp"
    Call Ctl_Item_MouseUp(TX_Message, Button, Shift, X, Y)
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "TX_Message_KeyDown"
    Call Ctl_Item_KeyDown(TX_Message, KEYCODE, Shift)
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

    'メッセージ出力
    If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgHIKET54_A_001, Main_Inf) <> vbYes Then
        Cancel = True
        Exit Sub
    End If
    Main_Inf.Dsp_Base.IsUnload = True
    
    'DB接続解除
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)

    Call SSSWIN_LOGWRT("プログラム終了")
    
    '共通終了処理？
    Set FR_SSSMAIN = Nothing
    
End Sub

Private Sub HD_SBNNO_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SBNNO_KeyUp"
    Call Ctl_Item_KeyUp(HD_SBNNO)
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

Private Sub HD_IN_TANCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANNM)
End Sub

Private Sub BD_SELECTB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SELECTB_KeyUp"
    Call Ctl_Item_KeyUp(BD_SELECTB(Index))
End Sub

Private Sub BD_OUTYTDT_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTYTDT_KeyUp"
    Call Ctl_Item_KeyUp(BD_OUTYTDT(Index))
End Sub

Private Sub BD_OUTYTSU_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTYTSU_KeyUp"
    Call Ctl_Item_KeyUp(BD_OUTYTSU(Index))
End Sub

Private Sub BD_ORGSBNNO_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_ORGSBNNO_KeyUp"
    Call Ctl_Item_KeyUp(BD_ORGSBNNO(Index))
End Sub

Private Sub BD_OUTRSNNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_OUTRSNNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_OUTRSNNM(Index))
End Sub

Private Sub BD_TOKRN_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_TOKRN_KeyUp"
    Call Ctl_Item_KeyUp(BD_TOKRN(Index))
End Sub

Private Sub BD_SIRRN_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SIRRN_KeyUp"
    Call Ctl_Item_KeyUp(BD_SIRRN(Index))
End Sub

Private Sub BD_WRTFSTDT_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WRTFSTDT_KeyUp"
    Call Ctl_Item_KeyUp(BD_WRTFSTDT(Index))
End Sub

Private Sub BD_SOUNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SOUNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_SOUNM(Index))
End Sub

Private Sub CS_HIK_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_HIK_KeyDown"
    If KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
        Call Ctl_Item_KeyDown(CS_HIK, KEYCODE, Shift)
    End If
End Sub
