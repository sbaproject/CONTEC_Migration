VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "倉庫登録"
   ClientHeight    =   8895
   ClientLeft      =   855
   ClientTop       =   2550
   ClientWidth     =   15165
   FillColor       =   &H00FF0000&
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
   Icon            =   "SOUMT51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   8895
   ScaleWidth      =   15165
   Begin VB.TextBox BD_SOUZP 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   1005
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   9465
      MaxLength       =   24
      TabIndex        =   16
      Text            =   "XXX－XXXX"
      Top             =   2730
      Width           =   1005
   End
   Begin VB.TextBox BD_SOUTRINM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   7305
      MaxLength       =   24
      TabIndex        =   51
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2730
      Width           =   2175
   End
   Begin VB.TextBox BD_SALPALKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   6720
      MaxLength       =   5
      TabIndex        =   46
      Text            =   "9"
      Top             =   3390
      Width           =   2760
   End
   Begin VB.TextBox BD_HIKKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   6720
      MaxLength       =   5
      TabIndex        =   44
      Text            =   "9"
      Top             =   3060
      Width           =   1440
   End
   Begin VB.TextBox BD_SOUKOKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   5295
      MaxLength       =   6
      TabIndex        =   42
      Text            =   "12"
      Top             =   2730
      Width           =   300
   End
   Begin VB.TextBox BD_SOUKONM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   5580
      MaxLength       =   14
      TabIndex        =   41
      Text            =   "MMMMMMMMM1"
      Top             =   2730
      Width           =   1155
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   735
      Index           =   0
      Left            =   -45
      TabIndex        =   10
      Top             =   8160
      Width           =   15210
      _ExtentX        =   26829
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
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   465
         Index           =   2
         Left            =   675
         TabIndex        =   11
         Top             =   135
         Width           =   14100
         _ExtentX        =   24871
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
            TabIndex        =   12
            Text            =   "SOUMT51.frx":000C
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "SOUMT51.frx":0043
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Left            =   12780
      MaxLength       =   24
      TabIndex        =   37
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   650
      Width           =   2265
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   12090
      MaxLength       =   10
      TabIndex        =   36
      Text            =   "XXXXX6"
      Top             =   650
      Width           =   705
   End
   Begin VB.TextBox BD_SISNKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   5295
      MaxLength       =   5
      TabIndex        =   34
      Text            =   "9"
      Top             =   3390
      Width           =   1440
   End
   Begin VB.TextBox BD_SOUTRICD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   6720
      MaxLength       =   9
      TabIndex        =   33
      Text            =   "XXXX5"
      Top             =   2730
      Width           =   600
   End
   Begin VB.TextBox BD_SOUBSNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   1005
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   4125
      MaxLength       =   24
      TabIndex        =   32
      Text            =   "MMMMMMMMM1"
      Top             =   2730
      Width           =   1185
   End
   Begin VB.TextBox BD_SRSCNKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   8145
      MaxLength       =   5
      TabIndex        =   28
      Text            =   "9"
      Top             =   3060
      Width           =   1335
   End
   Begin VB.TextBox BD_SOUKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   5295
      MaxLength       =   5
      TabIndex        =   27
      Text            =   "9"
      Top             =   3060
      Width           =   1440
   End
   Begin VB.TextBox BD_SOUBSCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   1005
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   3720
      MaxLength       =   7
      TabIndex        =   25
      Text            =   "XXX"
      Top             =   2730
      Width           =   420
   End
   Begin VB.TextBox BD_SOUADB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   10455
      MaxLength       =   44
      TabIndex        =   24
      Text            =   "?XXXXXXXXXXXXXXXXXXXXXXXXXXXX?"
      Top             =   3060
      Width           =   3225
   End
   Begin VB.TextBox BD_SOUADC 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   10455
      MaxLength       =   44
      TabIndex        =   23
      Text            =   "?XXXXXXXXXXXXXXXXXXXXXXXXXXXX?"
      Top             =   3390
      Width           =   3225
   End
   Begin VB.TextBox BD_SOUFX 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   540
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   13665
      MaxLength       =   24
      TabIndex        =   22
      Text            =   "XXXXXXXXX1XXX"
      Top             =   3195
      Width           =   1440
   End
   Begin VB.TextBox BD_SOUTL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   480
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   13665
      MaxLength       =   24
      TabIndex        =   20
      Text            =   "XXXXXXXXX1XXX"
      Top             =   2730
      Width           =   1440
   End
   Begin VB.TextBox BD_SOUADA 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   10455
      MaxLength       =   44
      TabIndex        =   18
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   2730
      Width           =   3225
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   975
      Index           =   2
      Left            =   1575
      TabIndex        =   3
      Top             =   1770
      Width           =   2160
      _ExtentX        =   3810
      _ExtentY        =   1720
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
      Caption         =   "*倉 庫 名 称"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   495
      Left            =   0
      TabIndex        =   5
      Top             =   8880
      Width           =   13605
      _ExtentX        =   23998
      _ExtentY        =   873
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
         TabIndex        =   7
         Text            =   "ﾓｰﾄﾞ"
         Top             =   45
         Width           =   870
      End
      Begin VB.VScrollBar VS_Scrl 
         Height          =   555
         Left            =   13185
         TabIndex        =   6
         Top             =   45
         Width           =   330
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "SOUMT51.frx":01CD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "SOUMT51.frx":081F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "SOUMT51.frx":0E71
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "SOUMT51.frx":0FFB
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "SOUMT51.frx":1185
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "SOUMT51.frx":130F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "SOUMT51.frx":1499
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "SOUMT51.frx":1623
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "SOUMT51.frx":17AD
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "SOUMT51.frx":1DFF
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "SOUMT51.frx":2451
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "SOUMT51.frx":2AA3
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "SOUMT51.frx":30F5
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "SOUMT51.frx":327F
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "SOUMT51.frx":3409
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "SOUMT51.frx":3593
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   6300
         Picture         =   "SOUMT51.frx":371D
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   6660
         Picture         =   "SOUMT51.frx":38A7
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "SOUMT51.frx":3A31
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "SOUMT51.frx":3BBB
         Top             =   45
         Width           =   300
      End
   End
   Begin VB.TextBox BD_SOUNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   1005
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   1575
      MaxLength       =   24
      TabIndex        =   4
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2730
      Width           =   2160
   End
   Begin VB.TextBox BD_SOUCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00FFFFFF&
      Height          =   1005
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   560
      MaxLength       =   7
      TabIndex        =   2
      Text            =   "999"
      Top             =   2730
      Width           =   1035
   End
   Begin VB.TextBox BD_UPDKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      ForeColor       =   &H00000000&
      Height          =   1005
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   50
      MaxLength       =   8
      TabIndex        =   1
      Text            =   "XXXX"
      Top             =   2730
      Width           =   525
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
      TabIndex        =   0
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSCommand5 CS_SOUCD 
      Height          =   975
      Left            =   555
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   1770
      Width           =   1035
      _ExtentX        =   1826
      _ExtentY        =   1720
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
      Caption         =   "*倉庫ｺｰﾄﾞ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CM_UPDKB 
      Height          =   975
      Left            =   45
      TabIndex        =   8
      TabStop         =   0   'False
      Top             =   1770
      Width           =   525
      _ExtentX        =   926
      _ExtentY        =   1720
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
      Caption         =   "ﾓｰﾄﾞ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D14 
      Height          =   555
      Left            =   -45
      TabIndex        =   13
      Top             =   0
      Width           =   15210
      _ExtentX        =   26829
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
         Left            =   13200
         TabIndex        =   14
         Top             =   120
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
      Begin VB.Image CM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1305
         Picture         =   "SOUMT51.frx":3D45
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   945
         Picture         =   "SOUMT51.frx":3ECF
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   2175
         Picture         =   "SOUMT51.frx":4059
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   585
         Picture         =   "SOUMT51.frx":46AB
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   5520
         Picture         =   "SOUMT51.frx":4CFD
         Top             =   0
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1725
         Picture         =   "SOUMT51.frx":4E87
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   2535
         Picture         =   "SOUMT51.frx":5011
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   225
         Picture         =   "SOUMT51.frx":5663
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   3000
         Picture         =   "SOUMT51.frx":57ED
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   555
         Left            =   0
         Top             =   -45
         Width           =   6315
      End
   End
   Begin Threed5.SSPanel5 FM_SOUZP 
      Height          =   975
      Index           =   0
      Left            =   9465
      TabIndex        =   15
      Top             =   1770
      Width           =   1005
      _ExtentX        =   1773
      _ExtentY        =   1720
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
      Caption         =   "〒"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_SOUAD 
      Height          =   975
      Index           =   0
      Left            =   10455
      TabIndex        =   17
      Top             =   1770
      Width           =   3225
      _ExtentX        =   5689
      _ExtentY        =   1720
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
      Caption         =   "住所"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_TEL 
      Height          =   510
      Index           =   0
      Left            =   13665
      TabIndex        =   19
      Top             =   1770
      Width           =   1440
      _ExtentX        =   2540
      _ExtentY        =   900
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
      Caption         =   "電話番号"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_FX 
      Height          =   495
      Index           =   0
      Left            =   13665
      TabIndex        =   21
      Top             =   2250
      Width           =   1440
      _ExtentX        =   2540
      _ExtentY        =   873
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
      Caption         =   "FAX番号"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_SOUBSCD 
      Height          =   975
      Left            =   3720
      TabIndex        =   26
      TabStop         =   0   'False
      Top             =   1770
      Width           =   1590
      _ExtentX        =   2805
      _ExtentY        =   1720
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
      Caption         =   "*場　所"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_SOUKB 
      Height          =   345
      Index           =   1
      Left            =   5295
      TabIndex        =   30
      Top             =   2085
      Width           =   1440
      _ExtentX        =   2540
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
      Caption         =   " 倉庫種別"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_SRSCNKB 
      Height          =   345
      Index           =   1
      Left            =   8145
      TabIndex        =   31
      Top             =   2085
      Width           =   1335
      _ExtentX        =   2355
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
      Caption         =   "ｼﾘｱﾙｽｷｬﾝ要否"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_SISNKB 
      Height          =   345
      Index           =   0
      Left            =   5295
      TabIndex        =   35
      Top             =   2400
      Width           =   1440
      _ExtentX        =   2540
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
      Caption         =   "   資産元区分"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   330
      Index           =   4
      Left            =   10920
      TabIndex        =   38
      Top             =   645
      Width           =   1185
      _ExtentX        =   2090
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
      Caption         =   "入力担当者"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_SOUTRICD 
      Height          =   345
      Left            =   6720
      TabIndex        =   40
      TabStop         =   0   'False
      Top             =   1770
      Width           =   2760
      _ExtentX        =   4868
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
      Caption         =   "取引先ｺｰﾄﾞ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_SOUKOKB 
      Height          =   345
      Left            =   5295
      TabIndex        =   43
      TabStop         =   0   'False
      Top             =   1770
      Width           =   1440
      _ExtentX        =   2540
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
      Caption         =   "*倉庫区分"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_SRSCNKB 
      Height          =   345
      Index           =   0
      Left            =   6720
      TabIndex        =   45
      Top             =   2085
      Width           =   1440
      _ExtentX        =   2540
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
      Caption         =   "引当対象区分"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_SRSCNKB 
      Height          =   345
      Index           =   2
      Left            =   6720
      TabIndex        =   47
      Top             =   2400
      Width           =   2760
      _ExtentX        =   4868
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
      Caption         =   "販売計画対象区分"
      OutLine         =   -1  'True
   End
   Begin VB.Label Label5 
      Caption         =   "販売計画対象区分・・・1：対象　9：対象外"
      Height          =   255
      Left            =   6480
      TabIndex        =   50
      Top             =   1440
      Width           =   4575
   End
   Begin VB.Label Label4 
      Caption         =   "ｼﾘｱﾙｽｷｬﾝ要否区分・・・1：要　9：否"
      Height          =   255
      Left            =   11160
      TabIndex        =   49
      Top             =   1200
      Width           =   3615
   End
   Begin VB.Label Label3 
      Caption         =   "倉庫種別　・・・1：物理　2：論理"
      Height          =   255
      Left            =   2640
      TabIndex        =   48
      Top             =   1200
      Width           =   3735
   End
   Begin VB.Label Label1 
      Caption         =   "資産元区分・・・0：自社　1：他社"
      Height          =   255
      Left            =   2640
      TabIndex        =   39
      Top             =   1440
      Width           =   3735
   End
   Begin VB.Label LaB_1 
      Caption         =   "引当対象区分　　・・・1：対象　9：対象外"
      Height          =   255
      Left            =   6480
      TabIndex        =   29
      Top             =   1200
      Width           =   4575
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "処理(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "登録(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu Bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "終了(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "編集(&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "画面初期化(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "項目初期化"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "項目復元"
      End
      Begin VB.Menu MN_ClearDE 
         Caption         =   "明細行初期化"
      End
      Begin VB.Menu MN_DeleteDE 
         Caption         =   "明細行削除(&T)"
         Shortcut        =   ^T
      End
      Begin VB.Menu MN_InsertDE 
         Caption         =   "明細行挿入(&I)"
         Shortcut        =   ^I
      End
      Begin VB.Menu MN_UnDoDe 
         Caption         =   "明細行復元"
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
      Caption         =   "補助(&3)"
      Begin VB.Menu MN_Prev 
         Caption         =   "前頁"
         Shortcut        =   {F8}
      End
      Begin VB.Menu MN_NextCm 
         Caption         =   "次頁"
         Shortcut        =   {F9}
      End
      Begin VB.Menu MN_SelectCm 
         Caption         =   "一覧表示"
         Shortcut        =   {F4}
      End
      Begin VB.Menu Bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "ウインドウ表示(&L)"
         Shortcut        =   {F5}
      End
      Begin VB.Menu MN_UPDKB 
         Caption         =   "モード変更"
         Shortcut        =   {F6}
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
'*** End Of Generated Declaration Section ****










Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "メニューに戻ります。"
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "登録します。"
End Sub

Private Sub CM_Hardcopy_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "画面を印刷します。"
End Sub

Private Sub CM_InsertDe_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "行を挿入します。"
End Sub

Private Sub CM_DeleteDe_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "行を削除します。"
End Sub

Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ウィンドウを表示します。"
End Sub

Private Sub CM_Prev_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "前のページを表示します。"
End Sub

Private Sub CM_NextCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "次のページを表示します。"
End Sub

Private Sub CM_SelectCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "一覧表示します。"
End Sub

Private Sub BD_HIKKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_HIKKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_HIKKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HIKKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 12 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12 + 36 * PP_SSSMAIN.De), BD_HIKKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKKB(Index))
   BD_HIKKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_HIKKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_HIKKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HIKKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_HIKKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 12 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKKB(Index), KeyAscii)
End Sub

Private Sub BD_HIKKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HIKKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_HIKKB(Index).SetFocus
         End If
      End If
   End If
   If BD_HIKKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_HIKKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_HIKKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_HIKKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_HIKKB(Index).TabIndex
   End If
End Sub

Private Sub BD_HIKKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_HIKKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKKB(Index))
End Sub

Private Sub BD_SALPALKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SALPALKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SALPALKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SALPALKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SALPALKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 15 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15 + 36 * PP_SSSMAIN.De), BD_SALPALKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SALPALKB(Index))
   BD_SALPALKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SALPALKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SALPALKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SALPALKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SALPALKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 15 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SALPALKB(Index), KeyAscii)
End Sub

Private Sub BD_SALPALKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SALPALKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SALPALKB(Index).SetFocus
         End If
      End If
   End If
   If BD_SALPALKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SALPALKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SALPALKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SALPALKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SALPALKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SALPALKB(Index).TabIndex
   End If
End Sub

Private Sub BD_SALPALKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SALPALKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SALPALKB(Index))
End Sub

Private Sub BD_SISNKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SISNKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SISNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SISNKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SISNKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 14 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14 + 36 * PP_SSSMAIN.De), BD_SISNKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SISNKB(Index))
   BD_SISNKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SISNKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SISNKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SISNKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SISNKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 14 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SISNKB(Index), KeyAscii)
End Sub

Private Sub BD_SISNKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SISNKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SISNKB(Index).SetFocus
         End If
      End If
   End If
   If BD_SISNKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SISNKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SISNKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SISNKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SISNKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SISNKB(Index).TabIndex
   End If
End Sub

Private Sub BD_SISNKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SISNKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SISNKB(Index))
End Sub

Private Sub BD_SOUADA_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADA(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUADA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUADA_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUADA(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 17 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17 + 36 * PP_SSSMAIN.De), BD_SOUADA(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADA(Index))
   BD_SOUADA(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUADA_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUADA(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUADA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUADA_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 17 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADA(Index), KeyAscii)
End Sub

Private Sub BD_SOUADA_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUADA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUADA(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUADA(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUADA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADA(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUADA(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUADA(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUADA(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUADA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUADA(Index).Locked = False
End Sub

Private Sub BD_SOUADB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUADB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUADB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUADB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 18 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18 + 36 * PP_SSSMAIN.De), BD_SOUADB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADB(Index))
   BD_SOUADB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUADB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUADB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUADB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUADB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 18 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADB(Index), KeyAscii)
End Sub

Private Sub BD_SOUADB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUADB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUADB(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUADB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUADB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUADB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUADB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUADB(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUADB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUADB(Index).Locked = False
End Sub

Private Sub BD_SOUADC_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADC(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUADC(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUADC_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUADC(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 19 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(19 + 36 * PP_SSSMAIN.De), BD_SOUADC(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADC(Index))
   BD_SOUADC(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUADC_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUADC(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUADC(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUADC_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 19 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADC(Index), KeyAscii)
End Sub

Private Sub BD_SOUADC_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUADC(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUADC(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUADC(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUADC_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUADC(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUADC(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUADC(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUADC(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUADC_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUADC(Index).Locked = False
End Sub

Private Sub BD_SOUBSCD_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSCD(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUBSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUBSCD_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUBSCD(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 5 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5 + 36 * PP_SSSMAIN.De), BD_SOUBSCD(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSCD(Index))
   BD_SOUBSCD(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = SOUBSCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5 + 36 * PP_SSSMAIN.De).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = wk_Slisted
         CP_SSSMAIN(PP_SSSMAIN.Px).CIn = Cn_ChrInput
         BD_SOUBSCD(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_SOUBSCD(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_SOUBSCD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUBSCD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUBSCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUBSCD_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 5 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSCD(Index), KeyAscii)
End Sub

Private Sub BD_SOUBSCD_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUBSCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUBSCD(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUBSCD(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUBSCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSCD(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUBSCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUBSCD(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUBSCD(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUBSCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUBSCD(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSCD(Index))
End Sub

Private Sub BD_SOUBSNM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSNM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUBSNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUBSNM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUBSNM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 6 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6 + 36 * PP_SSSMAIN.De), BD_SOUBSNM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSNM(Index))
   BD_SOUBSNM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUBSNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUBSNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUBSNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUBSNM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 6 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSNM(Index), KeyAscii)
End Sub

Private Sub BD_SOUBSNM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUBSNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUBSNM(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUBSNM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUBSNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUBSNM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUBSNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUBSNM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUBSNM(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUBSNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUBSNM(Index).Locked = False
End Sub

Private Sub BD_SOUCD_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUCD_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUCD(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 3 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3 + 36 * PP_SSSMAIN.De), BD_SOUCD(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
   BD_SOUCD(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = SOUCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3 + 36 * PP_SSSMAIN.De).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = wk_Slisted
         CP_SSSMAIN(PP_SSSMAIN.Px).CIn = Cn_ChrInput
         BD_SOUCD(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_SOUCD(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_SOUCD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUCD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUCD_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 3 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index), KeyAscii)
End Sub

Private Sub BD_SOUCD_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUCD(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUCD(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUCD(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUCD(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUCD(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUCD(Index))
End Sub

Private Sub BD_SOUFX_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUFX(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUFX(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUFX_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUFX(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 21 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(21 + 36 * PP_SSSMAIN.De), BD_SOUFX(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUFX(Index))
   BD_SOUFX(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUFX_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUFX(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUFX(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUFX_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 21 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUFX(Index), KeyAscii)
End Sub

Private Sub BD_SOUFX_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUFX(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUFX(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUFX(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUFX_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUFX(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUFX(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUFX(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUFX(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUFX_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUFX(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUFX(Index))
End Sub

Private Sub BD_SOUKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 11 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11 + 36 * PP_SSSMAIN.De), BD_SOUKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKB(Index))
   BD_SOUKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 11 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKB(Index), KeyAscii)
End Sub

Private Sub BD_SOUKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUKB(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUKB(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKB(Index))
End Sub

Private Sub BD_SOUKOKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKOKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUKOKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUKOKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUKOKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 7 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7 + 36 * PP_SSSMAIN.De), BD_SOUKOKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKOKB(Index))
   BD_SOUKOKB(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = SOUKOKB_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(7 + 36 * PP_SSSMAIN.De).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = wk_Slisted
         CP_SSSMAIN(PP_SSSMAIN.Px).CIn = Cn_ChrInput
         BD_SOUKOKB(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_SOUKOKB(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_SOUKOKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUKOKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUKOKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUKOKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 7 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKOKB(Index), KeyAscii)
End Sub

Private Sub BD_SOUKOKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUKOKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUKOKB(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUKOKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUKOKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKOKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUKOKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUKOKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUKOKB(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUKOKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUKOKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKOKB(Index))
End Sub

Private Sub BD_SOUKONM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKONM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUKONM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUKONM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUKONM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 8 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8 + 36 * PP_SSSMAIN.De), BD_SOUKONM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKONM(Index))
   BD_SOUKONM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUKONM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUKONM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUKONM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUKONM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 8 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKONM(Index), KeyAscii)
End Sub

Private Sub BD_SOUKONM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUKONM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUKONM(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUKONM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUKONM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKONM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUKONM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUKONM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUKONM(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUKONM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUKONM(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUKONM(Index))
End Sub

Private Sub BD_SOUNM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUNM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUNM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 4 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4 + 36 * PP_SSSMAIN.De), BD_SOUNM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index))
   BD_SOUNM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUNM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 4 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index), KeyAscii)
End Sub

Private Sub BD_SOUNM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUNM(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUNM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUNM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUNM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUNM(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUNM(Index).Locked = False
End Sub

Private Sub BD_SOUTL_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTL(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUTL(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUTL_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUTL(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 20 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(20 + 36 * PP_SSSMAIN.De), BD_SOUTL(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTL(Index))
   BD_SOUTL(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUTL_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUTL(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUTL(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUTL_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 20 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTL(Index), KeyAscii)
End Sub

Private Sub BD_SOUTL_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUTL(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUTL(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUTL(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUTL_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTL(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUTL(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUTL(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUTL(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUTL_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUTL(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTL(Index))
End Sub

Private Sub BD_SOUTRICD_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRICD(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUTRICD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUTRICD_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUTRICD(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 9 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9 + 36 * PP_SSSMAIN.De), BD_SOUTRICD(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRICD(Index))
   BD_SOUTRICD(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = SOUTRICD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9 + 36 * PP_SSSMAIN.De).CuVal))
   Else
      wk_Slisted = PP_SSSMAIN.SlistCom
   End If
   If Not IsNull(wk_Slisted) And PP_SSSMAIN.Px = PP_SSSMAIN.SlistPx Then
      PP_SSSMAIN.SlistPx = -1
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      PP_SSSMAIN.JustAfterSList = True
      PP_SSSMAIN.SlistCom = Null
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         CP_SSSMAIN(PP_SSSMAIN.Px).TpStr = wk_Slisted
         CP_SSSMAIN(PP_SSSMAIN.Px).CIn = Cn_ChrInput
         BD_SOUTRICD(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_SOUTRICD(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_SOUTRICD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUTRICD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUTRICD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUTRICD_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 9 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRICD(Index), KeyAscii)
End Sub

Private Sub BD_SOUTRICD_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUTRICD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUTRICD(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUTRICD(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUTRICD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRICD(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUTRICD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUTRICD(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUTRICD(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUTRICD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUTRICD(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRICD(Index))
End Sub

Private Sub BD_SOUTRINM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRINM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUTRINM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUTRINM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUTRINM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 10 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10 + 36 * PP_SSSMAIN.De), BD_SOUTRINM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRINM(Index))
   BD_SOUTRINM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUTRINM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUTRINM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUTRINM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUTRINM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 10 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRINM(Index), KeyAscii)
End Sub

Private Sub BD_SOUTRINM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUTRINM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUTRINM(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUTRINM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUTRINM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRINM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUTRINM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUTRINM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUTRINM(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUTRINM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUTRINM(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUTRINM(Index))
End Sub

Private Sub BD_SOUZP_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUZP(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUZP(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SOUZP_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SOUZP(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 16 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16 + 36 * PP_SSSMAIN.De), BD_SOUZP(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUZP(Index))
   BD_SOUZP(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SOUZP_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SOUZP(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUZP(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SOUZP_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 16 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUZP(Index), KeyAscii)
End Sub

Private Sub BD_SOUZP_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUZP(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SOUZP(Index).SetFocus
         End If
      End If
   End If
   If BD_SOUZP(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SOUZP_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUZP(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SOUZP(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SOUZP(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SOUZP(Index).TabIndex
   End If
End Sub

Private Sub BD_SOUZP_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SOUZP(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SOUZP(Index))
End Sub

Private Sub BD_SRSCNKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SRSCNKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SRSCNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SRSCNKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SRSCNKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 13 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13 + 36 * PP_SSSMAIN.De), BD_SRSCNKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SRSCNKB(Index))
   BD_SRSCNKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SRSCNKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SRSCNKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SRSCNKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SRSCNKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 13 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SRSCNKB(Index), KeyAscii)
End Sub

Private Sub BD_SRSCNKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SRSCNKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SRSCNKB(Index).SetFocus
         End If
      End If
   End If
   If BD_SRSCNKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SRSCNKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SRSCNKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SRSCNKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SRSCNKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SRSCNKB(Index).TabIndex
   End If
End Sub

Private Sub BD_SRSCNKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SRSCNKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SRSCNKB(Index))
End Sub

Private Sub BD_UPDKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_UPDKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_UPDKB_DblClick(Index As Integer) 'Generated.
Dim wk_SaveDe As Integer
Dim wk_SaveDe2 As Integer
   wk_SaveDe = PP_SSSMAIN.De: wk_SaveDe2 = PP_SSSMAIN.De2
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe: PP_SSSMAIN.De2 = PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Var = UPDKB_GetEvent()
   PP_SSSMAIN.De = wk_SaveDe: PP_SSSMAIN.De2 = wk_SaveDe2
End Sub

Private Sub BD_UPDKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_UPDKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 2 + 36 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2 + 36 * PP_SSSMAIN.De), BD_UPDKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 2 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index))
   BD_UPDKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_UPDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_UPDKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UPDKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_UPDKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 + 20 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index), KeyAscii)
End Sub

Private Sub BD_UPDKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UPDKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_UPDKB(Index).SetFocus
         End If
      End If
   End If
   If BD_UPDKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_UPDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_UPDKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_UPDKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_UPDKB(Index).TabIndex
   End If
End Sub

Private Sub BD_UPDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_UPDKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UPDKB(Index))
End Sub

Private Sub CM_DeleteDe_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         Call AE_DeleteDe_SSSMAIN
      End If
   Else
      Beep
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_DELETEDE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_DELETEDE.Picture = IM_DELETEDE(1).Picture
End Sub

Private Sub CM_DELETEDE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_DELETEDE.Picture = IM_DELETEDE(0).Picture
End Sub

Private Sub CM_EndCm_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   PP_SSSMAIN.CloseCode = 1
   Call AE_EndCm_SSSMAIN
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_ENDCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_EndCm.Picture = IM_EndCm(1).Picture
End Sub

Private Sub CM_ENDCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_EndCm.Picture = IM_EndCm(0).Picture
End Sub

Private Sub CM_Execute_Click() 'Generated.
Dim wk_Cursor As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Executing Then Exit Sub
   PP_SSSMAIN.Executing = True
   PP_SSSMAIN.ExplicitExec = True
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If Execute_GetEvent() Then
   wk_Cursor = AE_Execute_SSSMAIN()
      End If
   End If
   PP_SSSMAIN.ExplicitExec = False
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
   PP_SSSMAIN.Executing = False
End Sub

Private Sub CM_EXECUTE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_Execute.Picture = IM_Execute(1).Picture
End Sub

Private Sub CM_EXECUTE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_Execute.Picture = IM_Execute(0).Picture
End Sub

Private Sub CM_Hardcopy_Click() 'Generated.
Dim wk_Cursor As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If SSSMAIN_Hardcopy_Getevent() Then
   wk_Cursor = AE_Hardcopy_SSSMAIN()
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
End Sub

Private Sub CM_HARDCOPY_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_Hardcopy.Picture = IM_Hardcopy(1).Picture
End Sub

Private Sub CM_HARDCOPY_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_Hardcopy.Picture = IM_Hardcopy(0).Picture
End Sub

Private Sub CM_InsertDe_Click() 'Generated.
Dim wk_Cursor As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If INSERTDE_GETEVENT() Then
   If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         wk_Cursor = AE_InsertDe_SSSMAIN()
      End If
   Else
      Beep
   End If
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
End Sub

Private Sub CM_INSERTDE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_INSERTDE.Picture = IM_INSERTDE(1).Picture
End Sub

Private Sub CM_INSERTDE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_INSERTDE.Picture = IM_INSERTDE(0).Picture
End Sub

Private Sub CM_NextCm_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If NEXTCm_GETEVENT() Then
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
      wk_Int = AE_NextCm_SSSMAIN(True)
   Else
      Beep
   End If
      End If
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorInit_SSSMAIN
End Sub

Private Sub CM_NEXTCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_NEXTCm.Picture = IM_NEXTCM(1).Picture
End Sub

Private Sub CM_NEXTCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_NEXTCm.Picture = IM_NEXTCM(0).Picture
End Sub

Private Sub CM_Prev_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If PREV_GETEVENT() Then
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
      wk_Int = AE_Prev_SSSMAIN(True)
   Else
      Beep
   End If
      End If
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorInit_SSSMAIN
End Sub

Private Sub CM_PREV_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_PREV.Picture = IM_PREV(1).Picture
End Sub

Private Sub CM_PREV_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_PREV.Picture = IM_PREV(0).Picture
End Sub

Private Sub CM_SelectCm_Click() 'Generated.
Dim wk_Cursor As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode2 Then
      Beep
      wk_Cursor = Cn_CuCurrent
   Else
      wk_Cursor = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, False)
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
End Sub

Private Sub CM_SELECTCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SelectCm.Picture = IM_SelectCm(1).Picture
End Sub

Private Sub CM_SELECTCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SelectCm.Picture = IM_SelectCm(0).Picture
End Sub

Private Sub CM_Slist_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.NeglectLostFocusCheck = False
   If PP_SSSMAIN.SlistPx >= 0 Or Ck_Error <> 0 Then Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_Slist(1).Picture
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_SLIST.Picture = IM_Slist(0).Picture
End Sub

Private Sub CM_UPDKB_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If UPDKB_GetEvent() Then
   End If
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_UPDKB_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CM_UPDKB_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CM_UPDKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CS_SOUBSCD_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
Dim wk_TxBase As Integer
Dim wk_PxBase As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 102 Then
      wk_PxBase = 36 * PP_SSSMAIN.De
      wk_TxBase = 20 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
   Else
      wk_PxBase = 36 * PP_SSSMAIN.TopDe
      wk_TxBase = 0
   End If
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(5 + wk_PxBase).TypeA, 5 + wk_TxBase) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(5 + wk_TxBase)
      If PP_SSSMAIN.Tx <> 5 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_SOUBSCD_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_SOUBSCD_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_SOUBSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_SOUCD_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
Dim wk_TxBase As Integer
Dim wk_PxBase As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 102 Then
      wk_PxBase = 36 * PP_SSSMAIN.De
      wk_TxBase = 20 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
   Else
      wk_PxBase = 36 * PP_SSSMAIN.TopDe
      wk_TxBase = 0
   End If
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(3 + wk_PxBase).TypeA, 3 + wk_TxBase) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(3 + wk_TxBase)
      If PP_SSSMAIN.Tx <> 3 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_SOUCD_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_SOUCD_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_SOUCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_SOUKOKB_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
Dim wk_TxBase As Integer
Dim wk_PxBase As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 102 Then
      wk_PxBase = 36 * PP_SSSMAIN.De
      wk_TxBase = 20 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
   Else
      wk_PxBase = 36 * PP_SSSMAIN.TopDe
      wk_TxBase = 0
   End If
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(7 + wk_PxBase).TypeA, 7 + wk_TxBase) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(7 + wk_TxBase)
      If PP_SSSMAIN.Tx <> 7 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_SOUKOKB_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_SOUKOKB_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_SOUKOKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_SOUTRICD_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
Dim wk_TxBase As Integer
Dim wk_PxBase As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 102 Then
      wk_PxBase = 36 * PP_SSSMAIN.De
      wk_TxBase = 20 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
   Else
      wk_PxBase = 36 * PP_SSSMAIN.TopDe
      wk_TxBase = 0
   End If
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(9 + wk_PxBase).TypeA, 9 + wk_TxBase) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(9 + wk_TxBase)
      If PP_SSSMAIN.Tx <> 9 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_SOUTRICD_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_SOUTRICD_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_SOUTRICD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub FM_FX_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D1_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D14_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D15_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D2_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D4_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_SISNKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_SOUAD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_SOUKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_SOUZP_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_SRSCNKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_TEL_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub Form_Activate() 'Generated.
Dim wk_ww As Integer
Dim Wk_De As Integer
Dim wk_xx As Integer
   If PP_SSSMAIN.Activated = 0 Then
      PP_SSSMAIN.Activated = 1
      Wk_De = 1
      Do While Wk_De <= PP_SSSMAIN.MaxDspC
         wk_ww = 0
         Do While wk_ww < 20
            wk_xx = 2 + 20 * Wk_De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 2 + wk_ww).Visible
            wk_ww = wk_ww + 1
         Loop
         Wk_De = Wk_De + 1
      Loop
   End If
End Sub

Private Sub Form_Load() 'Generated.
Dim Wk_De As Integer
Dim wk_ww As Integer
Dim wk_Tx As Integer
Dim wk_TxBase As Integer
Dim wk_HeadN As Integer
Dim wk_BodyN As Integer
Dim wk_EBodyN As Integer
Dim wk_TailN As Integer
Dim wk_Top As Single
Dim wk_Height As Single
Dim wk_Px As Integer
Dim wk_PxBase As Integer
Dim wk_SmrBuf$
Dim PY_BBtm As Single
Dim PY_BTSpace As Single
Dim PY_TTop As Single
   AE_Title$ = "倉庫登録                          "
'初画面表示の性能チューニング用 ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 15165
   .FormHeight = 8895
   .MaxDe = 4
   .MaxDsp = 4
   .HeadN = 2
   .BodyN = 20
   .BodyV = 36
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 0
   .BodyPx = 2
   .EBodyPx = 182
   .TailPx = 182
   .PrpC = 182
   .Operable = False
   .BrightOnOff = Cn_ClBrightON
   .SuppressVSScroll = 0
   .UniScrl = False
   .SetCursorRR = True
   .SetCursorLF = False
   .VisibleForItem = False
   .AllowNullDes = False
   .No2Scroll = False
   .SpecSubID = "sss"
   .UnDoDeOp = 0
   .ActiveBlockNo = -1
   .MaxBlockNo = 1
   If .MainForm = "" Then
      .ScX = AE_ScX
      AE_ScX = AE_ScX + 1
      ReDim Preserve AE_Timer(.ScX)
      ReDim Preserve AE_CursorRest(.ScX)
      ReDim Preserve AE_ModeBar(.ScX)
      ReDim Preserve AE_StatusBar(.ScX)
      ReDim Preserve AE_StatusCodeBar(.ScX)
      ReDim Preserve AE_ScrlBar(.ScX)
      .CtB = AE_CtB
      AE_CtB = AE_CtB + 102
      ReDim Preserve AE_Controls(.CtB + 101)
      .MainFormFile = "SOUMT51.FRM"
      .MainFormObj = "FR_SSSMAIN"
      .SelValid = False
      .ArrowLimit = False
      .NullZero = True
      .ErrorByBackColor = False
      AE_SSSWin = True
      .AL = False
   End If
   If AE_FormInit$(PP_SSSMAIN, Me, AE_Title$, Cn_ClIncomplete, Cn_ClCheckError, Cn_ClRelCheck, Cn_ClChecked) <> "V6.60" Then
#If ActiveXcompile = 0 Then
      AE_MsgBox "再生成が必要です。", vbCritical, "ｅｅｅ": End
#Else
      AE_MsgBox "再生成が必要です。", vbCritical, "ｅｅｅ"
#End If
   End If
   If .MainForm = "" Then
      .MainForm = "SSSMAIN"
      Call AE_PSIR_SSSMAIN
      wk_ww = 0
      Wk_De = 1
      wk_HeadN = 0: wk_BodyN = 0: wk_EBodyN = 0: wk_TailN = 0
      Do While wk_ww < AE_PSIC
         wk_SmrBuf$ = Trim$(AE_PSI$(wk_ww)) & Space$(1)
         wk_ww = wk_ww + 1
         Select Case UCase$(Left$(wk_SmrBuf$, Cn_PrfxLen))
            Case "HD_", "HV_"
               Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf$, CQ_SSSMAIN(wk_HeadN))
               wk_HeadN = wk_HeadN + 1
            Case "BD_", "BV_"
               Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 2), wk_BodyN + 2, wk_SmrBuf$, CQ_SSSMAIN(wk_BodyN + 2))
               wk_BodyN = wk_BodyN + 1
         End Select
      Loop
      Do While Wk_De <= 4
         wk_PxBase = 2
         Do While wk_PxBase < 38
            wk_Px = wk_PxBase + 36 * Wk_De
            Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
            wk_PxBase = wk_PxBase + 1
         Loop
         Wk_De = Wk_De + 1
      Loop
   End If
   HD_OPEID = ""
   HD_OPENM = ""
   BD_UPDKB(0) = ""
   BD_SOUCD(0) = ""
   BD_SOUNM(0) = ""
   BD_SOUBSCD(0) = ""
   BD_SOUBSNM(0) = ""
   BD_SOUKOKB(0) = ""
   BD_SOUKONM(0) = ""
   BD_SOUTRICD(0) = ""
   BD_SOUTRINM(0) = ""
   BD_SOUKB(0) = ""
   BD_HIKKB(0) = ""
   BD_SRSCNKB(0) = ""
   BD_SISNKB(0) = ""
   BD_SALPALKB(0) = ""
   BD_SOUZP(0) = ""
   BD_SOUADA(0) = ""
   BD_SOUADB(0) = ""
   BD_SOUADC(0) = ""
   BD_SOUTL(0) = ""
   BD_SOUFX(0) = ""
   For Wk_De = 1 To 4
      Load BD_SOUFX(Wk_De)
      Load BD_SOUTL(Wk_De)
      Load BD_SOUADC(Wk_De)
      Load BD_SOUADB(Wk_De)
      Load BD_SOUADA(Wk_De)
      Load BD_SOUZP(Wk_De)
      Load BD_SALPALKB(Wk_De)
      Load BD_SISNKB(Wk_De)
      Load BD_SRSCNKB(Wk_De)
      Load BD_HIKKB(Wk_De)
      Load BD_SOUKB(Wk_De)
      Load BD_SOUTRINM(Wk_De)
      Load BD_SOUTRICD(Wk_De)
      Load BD_SOUKONM(Wk_De)
      Load BD_SOUKOKB(Wk_De)
      Load BD_SOUBSNM(Wk_De)
      Load BD_SOUBSCD(Wk_De)
      Load BD_SOUNM(Wk_De)
      Load BD_SOUCD(Wk_De)
      Load BD_UPDKB(Wk_De)
   Next Wk_De
   HD_OPEID.TabIndex = 0
   Set AE_Controls(.CtB + 0) = HD_OPEID
   HD_OPENM.TabIndex = 1
   Set AE_Controls(.CtB + 1) = HD_OPENM
   For Wk_De = 0 To 4
      wk_TxBase = 20 * Wk_De
      BD_UPDKB(Wk_De).TabIndex = 2 + wk_TxBase
      Set AE_Controls(.CtB + 2 + wk_TxBase) = BD_UPDKB(Wk_De)
      BD_SOUCD(Wk_De).TabIndex = 3 + wk_TxBase
      Set AE_Controls(.CtB + 3 + wk_TxBase) = BD_SOUCD(Wk_De)
      BD_SOUNM(Wk_De).TabIndex = 4 + wk_TxBase
      Set AE_Controls(.CtB + 4 + wk_TxBase) = BD_SOUNM(Wk_De)
      BD_SOUBSCD(Wk_De).TabIndex = 5 + wk_TxBase
      Set AE_Controls(.CtB + 5 + wk_TxBase) = BD_SOUBSCD(Wk_De)
      BD_SOUBSNM(Wk_De).TabIndex = 6 + wk_TxBase
      Set AE_Controls(.CtB + 6 + wk_TxBase) = BD_SOUBSNM(Wk_De)
      BD_SOUKOKB(Wk_De).TabIndex = 7 + wk_TxBase
      Set AE_Controls(.CtB + 7 + wk_TxBase) = BD_SOUKOKB(Wk_De)
      BD_SOUKONM(Wk_De).TabIndex = 8 + wk_TxBase
      Set AE_Controls(.CtB + 8 + wk_TxBase) = BD_SOUKONM(Wk_De)
      BD_SOUTRICD(Wk_De).TabIndex = 9 + wk_TxBase
      Set AE_Controls(.CtB + 9 + wk_TxBase) = BD_SOUTRICD(Wk_De)
      BD_SOUTRINM(Wk_De).TabIndex = 10 + wk_TxBase
      Set AE_Controls(.CtB + 10 + wk_TxBase) = BD_SOUTRINM(Wk_De)
      BD_SOUKB(Wk_De).TabIndex = 11 + wk_TxBase
      Set AE_Controls(.CtB + 11 + wk_TxBase) = BD_SOUKB(Wk_De)
      BD_HIKKB(Wk_De).TabIndex = 12 + wk_TxBase
      Set AE_Controls(.CtB + 12 + wk_TxBase) = BD_HIKKB(Wk_De)
      BD_SRSCNKB(Wk_De).TabIndex = 13 + wk_TxBase
      Set AE_Controls(.CtB + 13 + wk_TxBase) = BD_SRSCNKB(Wk_De)
      BD_SISNKB(Wk_De).TabIndex = 14 + wk_TxBase
      Set AE_Controls(.CtB + 14 + wk_TxBase) = BD_SISNKB(Wk_De)
      BD_SALPALKB(Wk_De).TabIndex = 15 + wk_TxBase
      Set AE_Controls(.CtB + 15 + wk_TxBase) = BD_SALPALKB(Wk_De)
      BD_SOUZP(Wk_De).TabIndex = 16 + wk_TxBase
      Set AE_Controls(.CtB + 16 + wk_TxBase) = BD_SOUZP(Wk_De)
      BD_SOUADA(Wk_De).TabIndex = 17 + wk_TxBase
      Set AE_Controls(.CtB + 17 + wk_TxBase) = BD_SOUADA(Wk_De)
      BD_SOUADB(Wk_De).TabIndex = 18 + wk_TxBase
      Set AE_Controls(.CtB + 18 + wk_TxBase) = BD_SOUADB(Wk_De)
      BD_SOUADC(Wk_De).TabIndex = 19 + wk_TxBase
      Set AE_Controls(.CtB + 19 + wk_TxBase) = BD_SOUADC(Wk_De)
      BD_SOUTL(Wk_De).TabIndex = 20 + wk_TxBase
      Set AE_Controls(.CtB + 20 + wk_TxBase) = BD_SOUTL(Wk_De)
      BD_SOUFX(Wk_De).TabIndex = 21 + wk_TxBase
      Set AE_Controls(.CtB + 21 + wk_TxBase) = BD_SOUFX(Wk_De)
   Next Wk_De
   TX_CursorRest.TabIndex = 102
   Set AE_Timer(.ScX) = TM_StartUp
   Set AE_CursorRest(.ScX) = TX_CursorRest
   Set AE_ModeBar(.ScX) = TX_Mode
   Set AE_StatusBar(.ScX) = TX_Message
   Set AE_StatusCodeBar(.ScX) = TX_Message
   .Mode = Cn_Mode1: TX_Mode = "追加"
   Call AE_ClearInitValStatus_SSSMAIN
   .PY_BTop = FR_SSSMAIN.Height
   ReDim AE_BodyTop(20)
   wk_Tx = 2
   Do While wk_Tx < 22
      wk_Top = AE_Controls(.CtB + wk_Tx).Top
      If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
      AE_BodyTop(wk_Tx - 2) = wk_Top
      wk_Tx = wk_Tx + 1
   Loop
   .PY_EBTop = FR_SSSMAIN.Height
   PY_TTop = FR_SSSMAIN.Height
   Set AE_ScrlBar(.ScX) = VS_Scrl
   PY_BBtm = 0
   wk_Tx = 2: wk_ww = 0
   Do While wk_Tx < 22
      wk_Height = AE_Controls(.CtB + wk_Tx).Height
      wk_Top = AE_BodyTop(wk_ww)
      If wk_Top + wk_Height > PY_BBtm Then PY_BBtm = wk_Top + wk_Height
      wk_Tx = wk_Tx + 1: wk_ww = wk_ww + 1
   Loop
   .PY_BHgt = PY_BBtm - .PY_BTop - 15
   If .PY_BHgt = 0 Then .PY_BHgt = 15
   PY_BTSpace = 120
   .MaxDspC = (PY_TTop - PY_BTSpace - .PY_BTop) \ .PY_BHgt - 1
   If .MaxDspC < 0 Then .MaxDspC = 0
   If .MaxDspC > 4 Then .MaxDspC = 4
   .NrBodyTx = 2 + 20 * (.MaxDspC + 1)
   .ScrlMaxL = .MaxDspC: If .ScrlMaxL = 0 Then .ScrlMaxL = 1
   wk_Top = .PY_BTop
   VS_Scrl.Top = wk_Top
   wk_Height = .PY_BHgt * (.MaxDspC + 1)
   VS_Scrl.Height = wk_Height + 15
   VS_Scrl.TabStop = False
   VS_Scrl.Min = 0
   VS_Scrl.Max = 0
   VS_Scrl.LargeChange = .ScrlMaxL
   If .MaxDspC = 4 Then VS_Scrl.Visible = False
   .MaxEDspC = 0
   .NrEBodyTx = 102
   .EScrlMaxL = 1
   Call AE_TabStop_SSSMAIN(0, 101, True)
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   Wk_De = 1
   Do While Wk_De <= .MaxDspC
      wk_ww = 0
      Do While wk_ww < 20
         wk_Tx = 2 + 20 * Wk_De + wk_ww
         AE_Controls(.CtB + wk_Tx).Top = AE_BodyTop(wk_ww) + .PY_BHgt * Wk_De
         wk_ww = wk_ww + 1
      Loop
      Wk_De = Wk_De + 1
   Loop
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
   Call AE_WindowProcSet_SSSMAIN
   ReleaseTabCapture 0
   SetTabCapture FR_SSSMAIN.hwnd
   wk_Var = SSSMAIN_BeginPrg()
   .FormWidth = FR_SSSMAIN.Width
   .FormHeight = FR_SSSMAIN.Height
'初画面表示の性能チューニング用 ----------
'   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
'-----------------------------------------
   .TimerStartUp = True
   End With
   TM_StartUp = True

' === 20080901 === UPDATE S - RISE)Izumi チェック項目追加
''2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
'    ReDim M_MOTO_A_inf(4)
''2007/12/18 add-end T.KAWAMUKAI
    ReDim M_SOUMT_A_inf(4)
' === 20080901 === UPDATE E - RISE)Izumi
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer) 'Generated.
   PP_SSSMAIN.UnloadMode = UnloadMode
   Select Case UnloadMode
      Case 0, 3
         PP_SSSMAIN.CloseCode = 2
         Cancel = True
         Call AE_EndCm_SSSMAIN
      Case 2
         PP_SSSMAIN.Caption = FR_SSSMAIN.Caption
         If AE_MsgLibrary(PP_SSSMAIN, "QueryUnload") = False Then Cancel = True
   End Select
End Sub

Private Sub Form_Resize() 'Generated.
Static FirstTime
   If IsEmpty(FirstTime) Then
       FirstTime = False
   ElseIf Not PP_SSSMAIN.Operable Then
   Else
      If FR_SSSMAIN.WindowState = 0 Then
         If FR_SSSMAIN.Height > PP_SSSMAIN.FormHeight Then FR_SSSMAIN.Height = PP_SSSMAIN.FormHeight
         If FR_SSSMAIN.Width > PP_SSSMAIN.FormWidth Then FR_SSSMAIN.Width = PP_SSSMAIN.FormWidth
      End If
   End If
'   Call AE_Resize(PP_SSSMAIN)
End Sub

Private Sub Form_Unload(Cancel As Integer) 'Generated.
Dim ReturnCode As Integer
   PP_SSSMAIN.CloseCode = 11
   If PP_SSSMAIN.InitValStatus <> PP_SSSMAIN.Mode Then
      If AE_MsgLibrary(PP_SSSMAIN, "EndCk") Then Cancel = True: Exit Sub
   Else
      If AE_MsgLibrary(PP_SSSMAIN, "EndCm") Then Cancel = True: Exit Sub
   End If
   wk_Var = SSSMAIN_Close()
   If wk_Var <> 0 Then
   End If
   If wk_Var = -1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hwnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
#If ActiveXcompile = 0 Then
      End
#End If
   ElseIf wk_Var = 0 Then
      Cancel = True
   ElseIf wk_Var = 1 Then
      wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
      Call AE_WindowProcReset(PP_SSSMAIN)
      ReleaseTabCapture FR_SSSMAIN.hwnd
      If PP_SSSMAIN.hIMC <> 0 Then
         Call ImmReleaseContext(PP_SSSMAIN.hIMCHwnd, PP_SSSMAIN.hIMC)
      End If
   End If
   PP_SSSMAIN.CloseCode = -1
End Sub

Private Sub HD_OPEID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OPEID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OPEID_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 0
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 0
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
   HD_OPEID.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (0)
   End If
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 0 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPEID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(0), (HD_OPEID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPEID.SetFocus
      End If
   End If
   If HD_OPEID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OPEID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPEID)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OPEID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OPEID.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 0
   End If
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPEID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_OPEID)
End Sub

Private Sub HD_OPENM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OPENM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OPENM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 1
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM)
   HD_OPENM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (1)
   End If
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 1 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_OPENM, KeyAscii)
End Sub

Private Sub HD_OPENM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(1), (HD_OPENM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPENM.SetFocus
      End If
   End If
   If HD_OPENM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OPENM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OPENM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OPENM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OPENM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub
Private Sub MN_AppendC_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
   If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_ClearDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
            Call AE_ClearDe2_SSSMAIN
         End If
      End If
   Else
      Beep
   End If
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub MN_ClearItm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   Call AE_ClearItm_SSSMAIN(False)
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub MN_Copy_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      Clipboard.Clear
      If Screen.ActiveControl.SelLength <= 1 Then
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.Text
         On Error GoTo 0
      Else
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.SelText
         On Error GoTo 0
      End If
   End If
End Sub

Private Sub MN_Ctrl_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
End Sub

Private Sub MN_Cut_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
         On Error Resume Next
         Clipboard.SetText Screen.ActiveControl.Text
         Call AE_ClearItm_SSSMAIN(False)
         On Error GoTo 0
         Call AE_CursorCurrent_SSSMAIN
      End If
   End If
End Sub

Private Sub MN_DeleteDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         Call AE_DeleteDe_SSSMAIN
      End If
   Else
      Beep
   End If
End Sub

Private Sub MN_EditMn_Click() 'Generated.
Const CF_TEXT As Integer = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_APPENDC = True
   If PP_SSSMAIN.Mode <> Cn_Mode2 Then
      MN_SelectCm = True
   Else
      MN_SelectCm = False
   End If
   MN_ClearItm = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 102 Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
   End If
   MN_UnDoDe = False
   If PP_SSSMAIN.Mode = Cn_Mode3 Then
   ElseIf PP_SSSMAIN.UnDoDeOp = 1 Then
      If AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.UnDoDeNo) And PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe = True
   ElseIf PP_SSSMAIN.UnDoDeOp = 2 Then
      If PP_SSSMAIN.ActiveDe >= 0 Then
         If PP_SSSMAIN.UnDoDeNo < PP_SSSMAIN.LastDe Then MN_UnDoDe = True
      Else
         If PP_SSSMAIN.UnDoDeNo <= PP_SSSMAIN.LastDe Then MN_UnDoDe = True
      End If
   End If
   MN_ClearDE = False
   MN_DeleteDE = False
   MN_InsertDE = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
            If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then MN_ClearDE = True
         End If
         MN_DeleteDE = True
         MN_InsertDE = True
      End If
   End If
   MN_Copy = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 102 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
      End If
   End If
   MN_Cut = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 102 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SelLength > 0 Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
               If CP_SSSMAIN(PP_SSSMAIN.Px).FixedFormat <> 1 Then
                  If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Cut = True
               End If
            End If
         End If
      End If
   End If
   MN_Paste = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 102 Then
      If TypeOf Screen.ActiveControl Is TextBox Then
         If Clipboard.GetFormat(CF_TEXT) Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
         End If
      End If
   End If
   MN_UnDoItem = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 102 Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
         If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <= Cn_Status2 Then
            MN_UnDoItem = True
         ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> Cn_Status0 Then
            If IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).CuVal) Xor IsNull(CP_SSSMAIN(PP_SSSMAIN.Px).ExVal) Then
               MN_UnDoItem = True
            ElseIf CP_SSSMAIN(PP_SSSMAIN.Px).ExStatus <> CP_SSSMAIN(PP_SSSMAIN.Px).StatusF Or CP_SSSMAIN(PP_SSSMAIN.Px).CuVal <> CP_SSSMAIN(PP_SSSMAIN.Px).ExVal Then
               MN_UnDoItem = True
            End If
         End If
      End If
   End If
End Sub

Private Sub MN_EndCm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.CloseCode = 1
   Call AE_EndCm_SSSMAIN
End Sub

Private Sub MN_Execute_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Executing Then Exit Sub
   PP_SSSMAIN.Executing = True
   PP_SSSMAIN.ExplicitExec = True
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If Execute_GetEvent() Then
   wk_Cursor = AE_Execute_SSSMAIN()
      End If
   End If
   PP_SSSMAIN.ExplicitExec = False
   If wk_Cursor = Cn_CuInit Then PP_SSSMAIN.SuppressGotLostFocus = 1
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
   PP_SSSMAIN.Executing = False
End Sub

Private Sub MN_InsertDe_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If INSERTDE_GETEVENT() Then
   If PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If (PP_SSSMAIN.Tx - 2) \ 20 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         wk_Cursor = AE_InsertDe_SSSMAIN()
      End If
   Else
      Beep
   End If
   End If
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
End Sub

Private Sub MN_NextCm_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If NEXTCm_GETEVENT() Then
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
      wk_Int = AE_NextCm_SSSMAIN(True)
   Else
      Beep
   End If
      End If
   End If
   Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_Oprt_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_Slist = False
   If False Then
   ElseIf (PP_SSSMAIN.Tx - 2) Mod 20 = 1 And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf (PP_SSSMAIN.Tx - 2) Mod 20 = 3 And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf (PP_SSSMAIN.Tx - 2) Mod 20 = 5 And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf (PP_SSSMAIN.Tx - 2) Mod 20 = 7 And PP_SSSMAIN.Tx >= 2 And PP_SSSMAIN.Tx < 102 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   End If
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
      MN_NextCm = True
      MN_Prev = True
   Else
      MN_NextCm = False
      MN_Prev = False
   End If
End Sub

Private Sub MN_Paste_Click() 'Generated.
Dim MaxLB As Integer
Dim wk_LnSt As Integer
Dim Tx As Integer
Dim Px As Integer
Dim wk_Txt$
Dim st_Work$
Dim wk_Moji$
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If TypeOf Screen.ActiveControl Is TextBox Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
      If Screen.ActiveControl.TabIndex >= 102 Then
            Screen.ActiveControl.SelText = Clipboard.GetText()
         Else
            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), Screen.ActiveControl)
         End If
      End If
   End If
End Sub

Private Sub MN_Prev_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
      Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
   End If
   If AE_CompleteCheck_SSSMAIN(False) <> 0 Then
      Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
      PP_SSSMAIN.CursorSet = True
   Else
      If PREV_GETEVENT() Then
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
      wk_Int = AE_Prev_SSSMAIN(True)
   Else
      Beep
   End If
      End If
   End If
   Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_SelectCm_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode2 Then
      Beep
      wk_Cursor = Cn_CuCurrent
   Else
      wk_Cursor = AE_SelectCm_SSSMAIN(PP_SSSMAIN.Mode, False)
   End If
   If wk_Cursor >= Cn_CuInit Then Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_Slist_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.SlistSw = True
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.SlistSw = False
End Sub

Private Sub MN_UnDoDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
      Call AE_UnDoDe_SSSMAIN
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub MN_UnDoItem_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   Call AE_UnDoItem_SSSMAIN
End Sub

Private Sub MN_UPDKB_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If UPDKB_GetEvent() Then
   End If
End Sub

Private Sub SM_AllCopy_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.ShortCutTx = -2 Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText TX_Mode.Text
      On Error GoTo 0
   ElseIf PP_SSSMAIN.ShortCutTx = -3 Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText TX_Message.Text
      On Error GoTo 0
   ElseIf TypeOf AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx) Is TextBox Then
      Clipboard.Clear
      On Error Resume Next
      Clipboard.SetText AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.ShortCutTx).Text
      On Error GoTo 0
   End If
End Sub

Private Sub SM_FullPast_Click() 'Generated.
   If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then
      PP_SSSMAIN.Tx = PP_SSSMAIN.PopupTx
      Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx))
      PP_SSSMAIN.Tx = -1
   End If
End Sub

Private Sub SSCommand52_Click()

End Sub

Private Sub TM_StartUp_Timer() 'Generated.
Dim wk_ww As Integer
Dim De As Integer
Dim Tx As Integer
Dim wk_Cursor As Integer
   TM_StartUp.Enabled = False
   If PP_SSSMAIN.TimerStartUp = True Then
      PP_SSSMAIN.TimerStartUp = False
      De = 1
      Do While De <= PP_SSSMAIN.MaxDspC
         wk_ww = 0
         Do While wk_ww < 20
            Tx = 2 + 20 * De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 2 + wk_ww).Visible
            wk_ww = wk_ww + 1
         Loop
         De = De + 1
         DoEvents
      Loop
      PP_SSSMAIN.MaskMode = False
      PP_SSSMAIN.Operable = True
      If AE_AppendC_SSSMAIN(Cn_Mode1) = Cn_CuCurrent Then
         PP_SSSMAIN.CloseCode = 0
         Call AE_EndCm_SSSMAIN
      Else
         Call AE_CursorInit_SSSMAIN
      End If
   End If
   If PP_SSSMAIN.TimerWorkId = 1 Then
      PP_SSSMAIN.TimerWorkId = 0
      Call AE_CursorSub_SSSMAIN(AE_ExecuteX_SSSMAIN())
   ElseIf PP_SSSMAIN.TimerWorkId = 8 Then
      PP_SSSMAIN.TimerWorkId = 0
      On Error Resume Next
      AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorSave).SetFocus
   ElseIf PP_SSSMAIN.TimerWorkId = 9 Then
      PP_SSSMAIN.TimerWorkId = 0
      Call AE_CursorSub_SSSMAIN(AE_NextCm_SSSMAIN(True))
   End If
End Sub

Private Sub TX_CursorRest_GotFocus() 'Generated.
   CM_SLIST.Enabled = False
   If PP_SSSMAIN.PrpC = 0 Then
      PP_SSSMAIN.De2 = -1
      TX_CursorRest.TabStop = False
   ElseIf PP_SSSMAIN.SSCommand5Ajst Then
      TX_CursorRest.TabStop = False
      PP_SSSMAIN.BrightOnOff = AE_BackColor(CL_SSSMAIN(PP_SSSMAIN.Px) Mod 10)
      PP_SSSMAIN.SSCommand5Ajst = False
   ElseIf PP_SSSMAIN.NextTx = Cn_NextTxCleared Then
      PP_SSSMAIN.De2 = -1
      PP_SSSMAIN.Tx = -1
      If PP_SSSMAIN.CursorToWhere >= 0 Then
            If PP_SSSMAIN.CursorToWhere = Cn_CursorToHome Then
               PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
               If AE_CursorNext_SSSMAIN(-1) Then TX_CursorRest.TabStop = False
            Else
               If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OutputOnly Then
               ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.CursorToWhere)).TypeA = Cn_OptionButtonC Then
               Else
                  If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).TabStop Then
                     PP_SSSMAIN.NextTx = PP_SSSMAIN.CursorToWhere
                     On Error Resume Next
                     AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.CursorToWhere).SetFocus
                     TX_CursorRest.TabStop = False
                  End If
               End If
            End If
         PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
      Else
         PP_SSSMAIN.ExMode = PP_SSSMAIN.Mode
      End If
   Else
      PP_SSSMAIN.De2 = -1
      If PP_SSSMAIN.Tx >= 0 Then
         If CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OutputOnly Then
         ElseIf CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonH Or CP_SSSMAIN(AE_Px(PP_SSSMAIN, PP_SSSMAIN.Tx)).TypeA = Cn_OptionButtonC Then
         Else
            If AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Visible And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).Enabled And AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).TabStop Then
               On Error Resume Next
               AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx).SetFocus
               TX_CursorRest.TabStop = False
               Exit Sub
            End If
         End If
      End If
      TX_CursorRest.TabStop = True
      PP_SSSMAIN.Tx = -1
      PP_SSSMAIN.CursorToWhere = Cn_CursorToRest
   End If
End Sub

Private Sub TX_CursorRest_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
Dim wk_TopDe As Integer
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   If KEYCODE = vbKeyUp And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
         Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
         wk_Bool = AE_CursorUp_SSSMAIN(102)
      End If
   ElseIf KEYCODE = vbKeyDown And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
         Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
         wk_Bool = AE_CursorDown_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyRight And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
         Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + 1, False)
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
         wk_Bool = AE_CursorNext_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyLeft And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
         Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - 1, False)
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(102)
      End If
   ElseIf (KEYCODE = vbKeyExecute Or KEYCODE = vbKeyReturn) And Shift = 0 Then
   ElseIf KEYCODE = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(4, False)
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorPrevDsp_SSSMAIN(102) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KEYCODE = vbKeyHome And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(0, False)
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KEYCODE = vbKeyPageDown And Shift = 0 Then
      If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe + PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
   ElseIf KEYCODE = vbKeyPageUp And Shift = 0 Then
      If (PP_SSSMAIN.ScrollObject And 1) > 0 Then Call AE_Scrl_SSSMAIN(PP_SSSMAIN.TopDe - PP_SSSMAIN.ScrlMaxL, PP_SSSMAIN.Mode <> Cn_Mode3)
   ElseIf KEYCODE = vbKeyShift Then
   ElseIf KEYCODE = vbKeyControl Then
   ElseIf KEYCODE = vbKeyMenu Then
   ElseIf KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
      wk_Int = AE_FuncKey_SSSMAIN(KEYCODE, Shift)
      If KEYCODE = vbKeyF10 And Shift = 0 Then Exit Sub
      If KEYCODE = vbKeyF4 And (Shift And 6) = 4 Then Exit Sub
   Else
      If Shift <> 4 Then Beep
   End If
   KEYCODE = 0
End Sub

Private Sub TX_CursorRest_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Mode = Cn_Mode3 Then
      KeyAscii = 0
   Else
      KeyAscii = 0
      Call AE_CursorInit_SSSMAIN
   End If
End Sub

Private Sub TX_Message_Click() 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub TX_Message_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KEYCODE = 0
End Sub

Private Sub TX_Message_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Message_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button And vbRightButton) = vbRightButton Then
      TX_Message.Enabled = False
      PP_SSSMAIN.ShortCutTx = -3
      SM_FullPast.Enabled = False
      PopupMenu SM_ShortCut, vbPopupMenuRightButton
      TX_Message.Enabled = True
   End If
End Sub

Private Sub TX_Mode_GotFocus() 'Generated.
   Beep
   Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.Tx)
End Sub

Private Sub TX_Mode_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KEYCODE = 0
End Sub

Private Sub TX_Mode_KeyPress(KeyAscii As Integer) 'Generated.
   Call AE_CursorInit_SSSMAIN
   KeyAscii = 0
End Sub

Private Sub TX_Mode_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If (Button And vbRightButton) = vbRightButton Then
      TX_Mode.Enabled = False
      PP_SSSMAIN.ShortCutTx = -2
      SM_FullPast.Enabled = False
      PopupMenu SM_ShortCut, vbPopupMenuRightButton
      TX_Mode.Enabled = True
   End If
End Sub

Private Sub VS_Scrl_Change() 'Generated.
   If PP_SSSMAIN.Tx >= 0 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
         Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
      End If
   End If
   Call AE_Scrl_SSSMAIN((VS_Scrl), (PP_SSSMAIN.SuppressVSScroll And 2) = 0)
   PP_SSSMAIN.SuppressVSScroll = PP_SSSMAIN.SuppressVSScroll And 5
End Sub


