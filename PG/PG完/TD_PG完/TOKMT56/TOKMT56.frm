VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'ﾌﾗｯﾄ
   BorderStyle     =   1  '固定(実線)
   Caption         =   "得意先別非取扱商品マスタ登録／訂正"
   ClientHeight    =   8400
   ClientLeft      =   975
   ClientTop       =   1740
   ClientWidth     =   10425
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
   Icon            =   "TOKMT56.frx":0000
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   8400
   ScaleWidth      =   10425
   Begin VB.TextBox BD_UPDATE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   7095
      MaxLength       =   30
      TabIndex        =   24
      Text            =   "XXXXX6"
      Top             =   2520
      Visible         =   0   'False
      Width           =   210
   End
   Begin VB.TextBox HD_SKHINGRP 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   3180
      MaxLength       =   50
      TabIndex        =   22
      Text            =   "XXX4"
      Top             =   1590
      Width           =   690
   End
   Begin VB.TextBox HD_SKHINRN 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Left            =   3855
      MaxLength       =   50
      TabIndex        =   21
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   1590
      Width           =   4320
   End
   Begin VB.TextBox BD_HINNMA 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   3795
      MaxLength       =   50
      TabIndex        =   19
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   2520
      Visible         =   0   'False
      Width           =   3315
   End
   Begin VB.TextBox HD_TOKRN 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Left            =   3855
      MaxLength       =   50
      TabIndex        =   17
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   1275
      Width           =   4320
   End
   Begin VB.TextBox HD_TOKCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   3180
      MaxLength       =   50
      TabIndex        =   15
      Text            =   "XXXX5"
      Top             =   1275
      Width           =   690
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  'ｵﾌ
      Left            =   7380
      MaxLength       =   14
      TabIndex        =   13
      Text            =   "XXXXX6"
      Top             =   660
      Width           =   720
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '全角ひらがな
      Left            =   8085
      MaxLength       =   24
      TabIndex        =   12
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   660
      Width           =   2175
   End
   Begin VB.TextBox BD_HINCD 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   2685
      MaxLength       =   30
      TabIndex        =   11
      Text            =   "XXXXX6"
      Top             =   2520
      Visible         =   0   'False
      Width           =   1125
   End
   Begin VB.TextBox BD_UPDKB 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   2055
      MaxLength       =   8
      TabIndex        =   10
      Text            =   "XXXX"
      Top             =   2520
      Visible         =   0   'False
      Width           =   645
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   1
      Left            =   -15
      TabIndex        =   6
      Top             =   7680
      Width           =   15390
      _ExtentX        =   27146
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
         Index           =   4
         Left            =   675
         TabIndex        =   7
         Top             =   135
         Width           =   9375
         _ExtentX        =   16536
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
            TabIndex        =   8
            Text            =   "TOKMT56.frx":030A
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "TOKMT56.frx":0341
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   645
      Left            =   0
      TabIndex        =   3
      Top             =   8000
      Width           =   13605
      _ExtentX        =   16695
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
      OutLine         =   -1  'True
      Begin VB.VScrollBar VS_Scrl 
         Height          =   555
         Left            =   13185
         TabIndex        =   5
         Top             =   45
         Width           =   330
      End
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H00FFC0FF&
         Height          =   375
         Left            =   12195
         TabIndex        =   4
         Text            =   "ﾓｰﾄﾞ"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5100
         Picture         =   "TOKMT56.frx":04CB
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   4740
         Picture         =   "TOKMT56.frx":0B1D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   5460
         Picture         =   "TOKMT56.frx":116F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   5820
         Picture         =   "TOKMT56.frx":17C1
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   8580
         Picture         =   "TOKMT56.frx":1E13
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   8220
         Picture         =   "TOKMT56.frx":2465
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "TOKMT56.frx":2AB7
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "TOKMT56.frx":2C41
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   6660
         Picture         =   "TOKMT56.frx":2DCB
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   6300
         Picture         =   "TOKMT56.frx":2F55
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "TOKMT56.frx":30DF
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "TOKMT56.frx":3269
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "TOKMT56.frx":33F3
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "TOKMT56.frx":357D
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "TOKMT56.frx":3707
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "TOKMT56.frx":3891
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "TOKMT56.frx":3A1B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "TOKMT56.frx":3BA5
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "TOKMT56.frx":3D2F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "TOKMT56.frx":3EB9
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "TOKMT56.frx":4043
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute_1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "TOKMT56.frx":41CD
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
         Left            =   8610
         TabIndex        =   2
         Top             =   105
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
      Begin VB.Image CM_INSERTDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   945
         Picture         =   "TOKMT56.frx":4357
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_DELETEDE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1305
         Picture         =   "TOKMT56.frx":44E1
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SelectCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   3060
         Picture         =   "TOKMT56.frx":466B
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   225
         Picture         =   "TOKMT56.frx":47F5
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCm 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   2595
         Picture         =   "TOKMT56.frx":497F
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   1770
         Picture         =   "TOKMT56.frx":4FD1
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   585
         Picture         =   "TOKMT56.frx":515B
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_PREV 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Left            =   2235
         Picture         =   "TOKMT56.frx":57AD
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   600
         Left            =   15
         Top             =   -45
         Width           =   15120
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
      TabIndex        =   0
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSCommand5 CS_UPDKB 
      Height          =   330
      Left            =   2055
      TabIndex        =   9
      TabStop         =   0   'False
      Top             =   2205
      Width           =   645
      _ExtentX        =   1138
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
      Caption         =   "ﾓｰﾄﾞ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   2
      Left            =   6180
      TabIndex        =   14
      Top             =   660
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
      BevelOuter      =   1
      Caption         =   "入力担当者"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_TOKCD 
      Height          =   330
      Left            =   1665
      TabIndex        =   16
      TabStop         =   0   'False
      Top             =   1275
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "*得意先　　  "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_HINCD 
      Height          =   330
      Left            =   2685
      TabIndex        =   18
      TabStop         =   0   'False
      Top             =   2205
      Width           =   1125
      _ExtentX        =   1984
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
      Caption         =   "*製品ｺｰﾄﾞ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   330
      Index           =   3
      Left            =   3795
      TabIndex        =   20
      Top             =   2205
      Width           =   3315
      _ExtentX        =   5847
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
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "型  式"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_SKHINGRP 
      Height          =   330
      Left            =   1665
      TabIndex        =   23
      TabStop         =   0   'False
      Top             =   1590
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "*仕切用商品群"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
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
'□□□□□□□□ 全画面ローカル共通処理 Start □□□□□□□□□□□□□□□□
Private Const FM_PANEL3D1_CNT       As Integer = 5 'パネルコントロール数
'*** End Of Generated Declaration Section ****

'=== 当画面の全情報を格納 =================
Private Main_Inf    As Cls_All
'=== 当画面の全情報を格納 =================

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Init_Def_Dsp
    '   概要：  画面の各項目情報を設定
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
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message

    '明細ページ数設定
    MinPageNum = 1
    MaxPageNum = 1
    NowPageNum = 1

    '画面基礎情報設定
    With Main_Inf.Dsp_Base
' 2006/11/15  CHG START  KUMEDA
'        .Dsp_Ctg = DSP_CTG_ENTRY                    '画面分類
'        .Item_Cnt = 98                              '画面項目数
'        .Dsp_Body_Cnt = 15                          '画面表示明細数（０：明細なし、１～：表示時明細数）
'        .Max_Body_Cnt = 0                           '最大表示明細数（０：明細なし、１～：最大明細数）
'        .Body_Col_Cnt = 3                           '明細の列項目数
'        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '画面移動量
        .Dsp_Ctg = DSP_CTG_ENTRY                    '画面分類
        .Item_Cnt = 114                             '画面項目数
        .Dsp_Body_Cnt = 15                          '画面表示明細数（０：明細なし、１～：表示時明細数）
        .Max_Body_Cnt = 0                           '最大表示明細数（０：明細なし、１～：最大明細数）
        .Body_Col_Cnt = 4                           '明細の列項目数
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '画面移動量
' 2006/11/15  CHG END
    End With

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
    '登録
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
    '処理２(編集)
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
    '画面初期化
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
    '明細行初期化
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
    '明細行削除
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
    '明細行挿入
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
    '明細行復元
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
    '処理３(補助)
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
    '前頁
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
    '次頁
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
    '一覧表示
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
    'ウインドウ表示
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
    'モード変更
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
    '登録イメージ
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
    '明細行挿入イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_INSERTDE_Inf.Click_Off_Img = IM_INSERTDE(0)
    Set Main_Inf.IM_INSERTDE_Inf.Click_On_Img = IM_INSERTDE(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '明細行削除イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_DELETEDE_Inf.Click_Off_Img = IM_DELETEDE(0)
    Set Main_Inf.IM_DELETEDE_Inf.Click_On_Img = IM_DELETEDE(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '検索イメージ
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
    '前頁イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PREV(0)
    Set Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PREV(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '次頁イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NEXTCM(0)
    Set Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NEXTCM(1)
    '=== ｲﾒｰｼﾞ設定 ======================

    Index_Wk = Index_Wk + 1
    '一覧表示イメージ
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
    '=== ｲﾒｰｼﾞ設定 ======================
    Set Main_Inf.IM_SelectCm_Inf.Click_Off_Img = IM_SelectCm(0)
    Set Main_Inf.IM_SelectCm_Inf.Click_On_Img = IM_SelectCm(1)
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

    Index_Wk = Index_Wk + 1
    '得意先ボタン
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
    
    Index_Wk = Index_Wk + 1
    '得意先(コード)
    HD_TOKCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' 2006/11/28  CHG START  KUMEDA
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' 2006/11/28  CHG END
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '得意先(名称)
    HD_TOKRN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_TOKRN
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
    '仕切用商品群ボタン
    CS_SKHINGRP.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_SKHINGRP
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
    '仕切用商品群(コード)
    HD_SKHINGRP.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SKHINGRP
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' 2006/11/28  CHG START  KUMEDA
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' 2006/11/28  CHG END
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 4
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 4
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
    '仕切用商品群(名称)
    HD_SKHINRN.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_SKHINRN
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

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      'ヘッダ部の最終の項目のｲﾝﾃﾞｯｸｽ

    '///////////////////////////
    '// ボディ（タイトル）部編集
    '///////////////////////////
    Index_Wk = Index_Wk + 1
    'モードボタン
    CS_UPDKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_UPDKB
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

    Index_Wk = Index_Wk + 1
    '製品ｺｰﾄﾞボタン
    CS_HINCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = CS_HINCD
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

    '///////////////
    '// ボディ部編集
    '///////////////
    Index_Wk = Index_Wk + 1
    'モード
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

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '明細部のｺﾝﾄﾛｰﾙ配列の最初の項目のｲﾝﾃﾞｯｸｽ

    Index_Wk = Index_Wk + 1
    '製品ｺｰﾄﾞ
    BD_HINCD(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
' 2006/11/28  CHG START  KUMEDA
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_XA
' 2006/11/28  CHG END
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '型式
    BD_HINNMA(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

' 2006/11/15  START  KUMEDA
    Index_Wk = Index_Wk + 1
    '更新フラグ
    BD_UPDATE(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDATE(0)
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
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
' 2006/11/15  ADD END
    
    For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        Load BD_UPDKB(BD_Cnt)           'モード
        Load BD_HINCD(BD_Cnt)           '製品ｺｰﾄﾞ
        Load BD_HINNMA(BD_Cnt)          '型式
' 2006/11/15  ADD START  KUMEDA
        Load BD_UPDATE(BD_Cnt)          '更新フラグ
' 2006/11/15  ADD END

        Index_Wk = Index_Wk + 1
        'モード
        BD_UPDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '製品ｺｰﾄﾞ
        BD_HINCD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINCD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '型式
        BD_HINNMA(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_HINNMA(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

' 2006/11/15  ADD START  KUMEDA
        Index_Wk = Index_Wk + 1
        '更新フラグ
        BD_UPDATE(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_UPDATE(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '明細部の１行上の情報を設定
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)
' 2006/11/15  ADD END

    Next

    '///////////////
    '// フッタ部編集
    '///////////////


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

    '画面基礎情報設定
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      'フッタ部の最初の項目のｲﾝﾃﾞｯｸｽ

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

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '画面変更なしとする
    gv_bolTOKMT56_INIT = False
    gv_bolInit = False
    gv_bolTOKMT56_LF_Enable = True
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_VbKeyReturn
    '   概要：  各項目のVBKEYRETURN制御
    '   引数：　Cls_Dsp_Sub_Inf     :画面項目情報
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
        
        '最終項目（次に移動できない項目）の場合
        If Move_Flg = False Then
            If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
            'ボディ部
                '登録処理を行う
                Call Ctl_MN_Execute_Click
            ElseIf pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Then
            'ヘッダ部
                'メッセージ表示
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT56_E_020, Main_Inf)
            End If
        End If
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
    '   引数：　Cls_Dsp_Sub_Inf     :画面項目情報
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
    '   引数：　Cls_Dsp_Sub_Inf     :画面項目情報
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
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

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
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
    'ﾁｪｯｸ後移動あり
        'KEYDOWN制御
        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
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
    '   引数：　Cls_Dsp_Sub_Inf     :画面項目情報
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
    '   引数：　Cls_Dsp_Sub_Inf     :画面項目情報
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
    '   引数：　pm_Ctl      :コントロールのクラス名
    '          pm_KeyCode   :キーコード
    '          pm_Shift     :shiftキー押下状態
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

' === 20060801 === INSERT S - エンターキー連打による不具合修正
    'Enter時のみフラグをON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If

        gv_bolKeyFlg = True
    End If
' === 20060801 === INSERT E

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
            Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)

' === 20060930 === INSERT S - ファンクションキー処理対応
        'ファンクションキー押下時
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            'ファンクションキー共通処理
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
' === 20060930 === INSERT E -

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KEYUP
    '   概要：  各項目のKEYUP制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20060801 === INSERT S - エンターキー連打による不具合修正
    'キーフラグを元に戻す
    gv_bolKeyFlg = False
' === 20060801 === INSERT E -

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_LostFocus
    '   概要：  各項目のLOSTFOCUS制御
    '   引数：　pm_Ctl      :コントロールのクラス名
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

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

' === 20060702 === INSERT S
    'ﾛｽﾄﾌｫｰｶｽ実行判定
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
' === 20060702 === INSERT E

    Move_Flg = False
    Chk_Move_Flg = True

    '各項目のﾁｪｯｸﾙｰﾁﾝ
    Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

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
    Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        'ﾁｪｯｸ後移動あり
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

        '現在ﾌｫｰｶｽｺﾝﾄﾛｰﾙの選択情報を再設定
        '選択状態の設定
        Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), 0)
        '項目色設定
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

    Else
        'ﾁｪｯｸ後移動なし
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_GotFocus
    '   概要：  各項目のGOTFOCUS制御
    '   引数：　pm_Ctl      :コントロールのクラス名
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_GotFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Rtn_Chk     As Integer
    Dim Move_Flg    As Boolean
    Dim Wk_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    '画面単位の処理(ﾁｪｯｸなど)
    '明細部でかつ移動前が明細部でない場合
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then

        'ﾍｯﾀﾞ部ﾁｪｯｸ
        Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)

        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If

' === 20060801 === INSERT S - 検索画面表示ボタンを押したことが見えるようにする対応
    If TypeOf pm_Ctl Is SSCommand5 Then
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
' === 20060801 === INSERT E

    '共通ﾌｫｰｶｽ取得処理
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

'    'メニュー使用可否制御
'    '処理１
'    Call Ctl_MN_Ctrl_Click
'    '編集２
'    Call Ctl_MN_EditMn_Click
'    '補助３
'    Call Ctl_MN_Oprt_Click

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_KeyPress
    '   概要：  各項目のKEYPRESS制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '           pm_KeyAscii     :キーのASCIIコード
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
    Call CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

' === 20060825 === INSERT S
    With Main_Inf.Dsp_Sub_Inf(Trg_Index)
        '対象項目が仕切用商品群の場合
        If Move_Flg = False And .Ctl.NAME = FR_SSSMAIN.HD_SKHINGRP.NAME Then
            '入力位置が最大バイト数と同じ場合
            If .Ctl.SelStart = .Detail.MaxLengthB Then
                '次の項目へ移動する処理を行う
                Move_Flg = True
            End If
        End If
    End With
' === 20060825 === INSERT E

' === 20060801 === INSERT S
    With Main_Inf.Dsp_Sub_Inf(Trg_Index)
        '対象項目が製品コードの場合
        If Move_Flg = False And .Ctl.NAME = FR_SSSMAIN.BD_HINCD(1).NAME Then
            '入力位置が最大バイト数と同じ場合
            If .Ctl.SelStart = .Detail.MaxLengthB Then
                '次の項目へ移動する処理を行う
                Move_Flg = True
            End If
        End If
    End With
' === 20060801 === INSERT E

    If Move_Flg = True Then
    '次の項目へ移動した場合
        '各項目のﾁｪｯｸﾙｰﾁﾝ
        Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)

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
        Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then

            '現在ﾌｫｰｶｽ位置から右へ移動
            Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
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

'    'メニュー使用可否制御
'    '編集２
'    Call Ctl_MN_EditMn_Click
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  各項目のCHANGE制御
    '   引数：　pm_Ctl          :コントロールのクラス名
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
    Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    '画面単位の処理(ﾁｪｯｸなど)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseUp
    '   概要：  各項目のMOUSEUP制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '           Button          :押下キー
    '           Shift           :シフトキー押下状態
    '           X               :X座標
    '           Y               :Y座標
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseUp(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '選択状態の設定（初期選択）
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_1)
' === 20060702 === DELETE S
'            '項目色設定
'            Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf)
' === 20060702 === DELETE E

        Case TypeOf pm_Ctl Is SSPanel5
            'パネルの場合
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

' === 20060801 === INSERT S - 検索Wボタン対応
        Case TypeOf pm_Ctl Is SSCommand5
            'ボタンの場合
' 2006/11/28  ADD START  KUMEDA
            If Me.ActiveControl Is Nothing Then
                Exit Function
            End If
' 2006/11/28  ADD END

            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If
' === 20060801 === INSERT E

        Case TypeOf pm_Ctl Is Image
            'イメージの場合
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '終了ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_Execute.Tag)
                '登録ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
                Case CInt(CM_INSERTDE.Tag)
                '明細行挿入ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, False, Main_Inf)
                Case CInt(CM_DELETEDE.Tag)
                '明細行削除ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, False, Main_Inf)
                Case CInt(CM_SLIST.Tag)
                '検索ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
                Case CInt(CM_PREV.Tag)
                '前頁ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                Case CInt(CM_NEXTCm.Tag)
                '次頁ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
                Case CInt(CM_SelectCm.Tag)
                '一覧表示ｲﾒｰｼﾞ
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)

            End Select
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseMove
    '   概要：  各項目のMOUSEMOVE制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '           Button          :押下キー
    '           Shift           :シフトキー押下状態
    '           X               :X座標
    '           Y               :Y座標
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
        '登録ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_INSERTDE.Tag)
        '明細行挿入ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_INSERTDE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_DELETEDE.Tag)
        '明細行削除ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_DELETEDE_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_SLIST.Tag)
        '検索ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_PREV.Tag)
        '前頁ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_PREV_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_NEXTCm.Tag)
        '次頁ｲﾒｰｼﾞ
            Call CF_Set_Prompt(IMG_NEXTCM_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_SelectCm.Tag)
        '一覧表示ｲﾒｰｼﾞ
            Call CF_Set_Prompt("一覧表示します。", COLOR_BLACK, Main_Inf)

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_MouseDown
    '   概要：  各項目のMOUSEDOWN制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '           Button          Button          :押下キー
    '           Shift           :シフトキー押下状態
    '           X               :X座標
    '           Y               :Y座標
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer
    Dim Act_Index    As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

' === 20060702 === INSERT S
    'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙ割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)
' === 20060702 === INSERT E

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '終了ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '登録ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

        Case CInt(CM_INSERTDE.Tag)
        '明細行挿入ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, True, Main_Inf)

        Case CInt(CM_DELETEDE.Tag)
        '明細行削除ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, True, Main_Inf)

        Case CInt(CM_SLIST.Tag)
        '検索画面表示ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)

        Case CInt(CM_PREV.Tag)
        '前頁ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)

        Case CInt(CM_NEXTCm.Tag)
        '次頁ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)

        Case CInt(CM_SelectCm.Tag)
        '一覧表示ｲﾒｰｼﾞ
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)

    End Select

' === 20060702 === INSERT S
    '共通MOUSEDOWN制御
    Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
' === 20060702 === INSERT E

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Click
    '   概要：  各項目のCLICK制御
    '   引数：　pm_Ctl          :コントロールのクラス名
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Wk_Index    As Integer
    Dim RetnCd      As Integer

    '割当ｲﾝﾃﾞｯｸｽ取得
    Trg_Index = CInt(pm_Ctl.Tag)

    RetnCd = -1

    Select Case Trg_Index

        Case CInt(CM_SLIST.Tag), CInt(MN_Slist.Tag)
            '各検索画面呼出
            Call F_Ctl_CS(Main_Inf)

        Case CInt(CS_TOKCD.Tag)
            '得意先画面呼出
            Call F_Ctl_CS_TOKCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        
        Case CInt(CS_SKHINGRP.Tag)
            '名称（仕切用商品群）検索画面呼出
           Call F_Ctl_CS_SKHINGRP(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CS_HINCD.Tag)
            '製品検索画面呼出
            Call F_Ctl_CS_HINCD(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_Execute.Tag), CInt(MN_Execute.Tag)
            '登録
            Call Ctl_MN_Execute_Click

        Case CInt(CM_INSERTDE.Tag), CInt(MN_InsertDE.Tag)
            '明細行挿入
            Call Ctl_MN_InsertDE_Click

        Case CInt(CM_DELETEDE.Tag), CInt(MN_DeleteDE.Tag)
            '明細行削除
            Call Ctl_MN_DeleteDE_Click

        Case CInt(CM_PREV.Tag), CInt(MN_Prev.Tag)
            '前頁へ
            Call Ctl_CM_PREV_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_NEXTCm.Tag), CInt(MN_NextCm.Tag)
            '次頁へ
            Call Ctl_CM_NEXTCM_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_SelectCm.Tag), CInt(MN_SelectCm.Tag)
            '一覧表示
            Call Ctl_MN_SelectCm_Click

        '=============================================

        Case CInt(MN_Ctrl.Tag)
            '処理１
            Call Ctl_MN_Ctrl_Click

        Case CInt(CM_EndCm.Tag), CInt(MN_EndCm.Tag)
            '終了
            Call Ctl_MN_EndCm_Click
            Exit Function

        Case CInt(MN_EditMn.Tag)
            '編集２
            Call Ctl_MN_EditMn_Click

        Case CInt(MN_APPENDC.Tag)
            '画面初期化
            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '項目初期化
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '項目復元
            Call Ctl_MN_UnDoItem_Click

        Case CInt(MN_ClearDE.Tag)
            '明細行初期化
            Call Ctl_MN_ClearDE_Click

        Case CInt(MN_UnDoDe.Tag)
            '明細行復元
            Call Ctl_MN_UnDoDe_Click

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
            '補助３
            Call Ctl_MN_Oprt_Click

        Case CInt(CS_UPDKB.Tag), CInt(MN_UPDKB.Tag)
            'モード変更
            Call Ctl_MN_UPDKB_Click

        Case CInt(SM_AllCopy.Tag)
            '項目内容にコピー
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '取り消し
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '項目に貼り付け
            Call Ctl_SM_FullPast_Click

    End Select

    'ステータスバー初期化
    Call CF_Clr_Prompt(Main_Inf)

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
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '｢登録｣判定
'    MN_Execute.Enabled = pv_InpTan_TOK     2007/01/11 DLT
'    '｢削除｣判定
'    MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢終了｣判定
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EditMn_Click
    '   概要：  メニュー編集２の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Ant_Index = CInt(Me.ActiveControl.Tag)

'    '｢画面初期化｣判定
'    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢項目初期化｣判定
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢項目復元｣判定
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行初期化｣判定
    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '｢明細行削除｣判定
'    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '｢明細行挿入｣判定
'    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '｢明細行復元｣判定
    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '｢切り取り｣判定
'    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '｢コピー｣判定
'    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '｢貼り付け｣判定
'    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Oprt_Click
    '   概要：  メニュー補助３の使用可不可を制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

'    '｢前頁｣｢次頁｣判定
'    Call F_Ctl_PageButton_Enabled(Main_Inf)
    '｢一覧表示｣初期可
    MN_SelectCm.Enabled = True
    '｢ウインドウ表示｣初期可
    MN_Slist.Enabled = True
    '｢モード変更｣初期可
    MN_UPDKB.Enabled = True
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Execute_Click
    '   概要：  登録
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer
    
    '得意先コードの取得
    pv_TOKMT56_TOKCD = Trim(FR_SSSMAIN.HD_TOKCD.Text)
    
    '仕切用商品群の取得
    pv_TOKMT56_SKHINGRP = Trim(FR_SSSMAIN.HD_SKHINGRP.Text)
    
    'ﾍｯﾀﾞ部ﾁｪｯｸ
    intRet = F_Ctl_Head_Chk(Main_Inf)
    If intRet <> CHK_OK Then
        Exit Function
    End If
    
    intRet = F_Ctl_Upd_Process(Main_Inf)
    If intRet = 0 Then
        If gv_bolSelectCmFlg = True Then
        '一覧表示の場合
            If NowPageNum < MaxPageNum Then
            '表示されている明細が最大ページ番号でないなら次ページを表示
                NowPageNum = NowPageNum + 1
                
' 2006/11/28  ADD START  KUMEDA
                If Me.ActiveControl Is Nothing Then
                    Exit Function
                End If
' 2006/11/28  ADD END

                Trg_Index = CInt(Me.ActiveControl.Tag)
                Call CF_Ctl_Dsp_Body_Page(NowPageNum, Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
                
                Call F_Cursor_Set(Main_Inf)
                
            Else
                '表示されている明細が最大ページ番号なら再表示
                '最上明細インデックスの退避
                Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
                
                '画面ボディ部初期化
                Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
                'データ再取得
                Call F_GET_BD_DATA(Main_Inf)
                '最上明細インデックスを戻す
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
            
        Else
        '単明細表示の場合
            '画面初期化
            Call Ctl_MN_APPENDC_Click
        End If
        
'        '一覧表示フラグを元に戻す
'        gv_bolSelectCmFlg = False
        
        gv_bolTOKMT56_INIT = False
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteCM_Click
    '   概要：  削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteCM_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_HARDCOPY_Click
    '   概要：  画面印刷
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Dim wk_Cursor As Integer

    'Operable=TRUEの時のみok
    If PP_SSSMAIN.Operable = False Then
        Exit Function
    End If
    'ハードコピーイベント実行
    If SSSMAIN_Hardcopy_Getevent() Then
        wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
    End If
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_EndCm_Click
    '   概要：  終了
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Unload FR_SSSMAIN
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    '画面ボディ部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '初期表示編集
    Call Edi_Dsp_Def

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)

    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    '初期フォーカス位置設定
    Call F_Init_Cursor_Set(Main_Inf)

' === 20060801 === INSERT S - 検索W表示時の不具合対応
    gv_bolTOKMT56_LF_Enable = True
' === 20060801 === INSERT E

    'キーフラグを元に戻す
    gv_bolKeyFlg = False
    
    '一覧表示フラグを元に戻す
    gv_bolSelectCmFlg = False
    
    gv_bolTOKMT56_INIT = False
    
    '条件保存変数クリア
    pv_TOKMT56_TOKCD = ""
    pv_TOKMT56_SKHINGRP = ""
    pv_TOKMT56_HINCD = ""
    
    '明細ページ数初期化
    MaxPageNum = 1
    NowPageNum = 1
    
    '入力コントロールの使用可否制御
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
'    'メニュー使用可否制御
'    '処理１
'    Call Ctl_MN_Ctrl_Click
'    '編集２
'    Call Ctl_MN_EditMn_Click
'    '補助３
'    Call Ctl_MN_Oprt_Click

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
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '画面内容初期化
    Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

    '共通ﾌｫｰｶｽ取得処理
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'    'メニュー使用可否制御
'    '処理１
'    Call Ctl_MN_Ctrl_Click
'    '編集２
'    Call Ctl_MN_EditMn_Click
'    '補助３
'    Call Ctl_MN_Oprt_Click

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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

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
    '   名称：  Function Ctl_MN_ClearDE_Click
    '   概要：  明細行初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer

    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当行の初期化処理
    Call SSSMAIN0001.CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_DeleteDE_Click
    '   概要：  明細行削除
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当行の削除処理
    Call SSSMAIN0001.CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_InsertDE_Click
    '   概要：  明細行挿入
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当行の挿入処理
    Call SSSMAIN0001.CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
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
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当行の復元処理
    Call SSSMAIN0001.CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

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
    '   名称：  Function Ctl_MN_Copy_Click
    '   概要：  コピー
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目のコピー
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_SelectCm_Click
    '   概要：  一覧表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SelectCm_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Dim Trg_Index   As Integer
    Dim RtnCode     As Integer

    '検索条件入力チェック
    If F_Chk_All_Input_Serch(Main_Inf) = True Then
        Exit Function
    End If
    
    '得意先コードの取得
    pv_TOKMT56_TOKCD = Trim(FR_SSSMAIN.HD_TOKCD.Text)
    
    '仕切用商品群の取得
    pv_TOKMT56_SKHINGRP = Trim(FR_SSSMAIN.HD_SKHINGRP.Text)
    
    '１番目の製品コードの取得
    pv_TOKMT56_HINCD = Trim(FR_SSSMAIN.BD_HINCD(1).Text)
    
    If gv_bolTOKMT56_INIT = True Then
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT56_A_018, Main_Inf) = vbNo Then
            Exit Function
        End If
    End If
    
    '画面ボディ部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
    
    RtnCode = F_GET_BD_DATA(Main_Inf)

    '現在のページ数初期化
    NowPageNum = 1
    
    '最上明細ｲﾝﾃﾞｯｸｽ初期化
    Main_Inf.Dsp_Body_Inf.Cur_Top_Index = 1

    If RtnCode = 0 Then
    '出力できる明細データが無い
' 2006/11/29  ADD START  KUMEDA
        '明細一行目を最終準備行として開放する
        Main_Inf.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
' 2006/1/29  ADD END
        Exit Function
    Else
        '入力コントロールの使用可否制御
        Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
        '明細を画面に編集
        Trg_Index = CInt(MN_SelectCm.Tag)
        Call F_DSP_BD_Inf(Main_Inf.Dsp_Sub_Inf(Trg_Index), DSP_SET, Main_Inf)
        
        '一覧表示フラグを立てる
        gv_bolSelectCmFlg = True
        
    End If
    
    gv_bolTOKMT56_INIT = False
        
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_Slist_Click
    '   概要：  ウィンドウ表示
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Call F_Ctl_CS(Main_Inf)
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_MN_UPDKB_Click
    '   概要：  モード変更
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UPDKB_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当行のモード変更処理
    Call F_Ctl_CS_UPDKB(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)
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
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_SM_Esc_Click
    '   概要：  取り消し
    '   引数：　なし
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer
'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '割当ｲﾝﾃﾞｯｸｽ取得
    Act_Index = CInt(Me.ActiveControl.Tag)

    '該当項目の貼り付け
    '注）メニューの画面｢貼り付け｣と同一関数を使用！！
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CM_PREV_Click
    '   概要：  明細の前ページを表示
    '   引数：　pm_Act_Dsp_Sub_Inf  :画面項目情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_PREV_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer
    
    '得意先コードの取得
    pv_TOKMT56_TOKCD = Trim(FR_SSSMAIN.HD_TOKCD.Text)
    
    '仕切用商品群の取得
    pv_TOKMT56_SKHINGRP = Trim(FR_SSSMAIN.HD_SKHINGRP.Text)
    
    If NowPageNum > MinPageNum Then
    ''表示されている明細が2ページ目以降なら前ページを表示
        
        intRet = F_Ctl_Upd_Process2(Main_Inf)
        If intRet = 0 Then
            '最上明細インデックスの退避
            Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
            
            '画面ボディ部初期化
            Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
            'データ再取得
            Call F_GET_BD_DATA(Main_Inf)
            '最上明細インデックスを戻す
            Main_Inf.Dsp_Body_Inf.Cur_Top_Index = Wk_Cur_Top_Index
            
            NowPageNum = NowPageNum - 1
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)
            
            Call F_Cursor_Set(pm_All)
            
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_CM_NEXTCM_Click
    '   概要：  明細の次ページを表示
    '   引数：　pm_Act_Dsp_Sub_Inf  :画面項目情報
    '           pm_all              :全構造体
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_NEXTCM_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim intRet              As Integer
    Dim Trg_Index           As Integer
    Dim Wk_Cur_Top_Index    As Integer
    
    '得意先コードの取得
    pv_TOKMT56_TOKCD = Trim(FR_SSSMAIN.HD_TOKCD.Text)
    
    '仕切用商品群の取得
    pv_TOKMT56_SKHINGRP = Trim(FR_SSSMAIN.HD_SKHINGRP.Text)
    
    If NowPageNum < MaxPageNum Then
    '表示されている明細が最大ページ番号でないなら次ページを表示
        
        intRet = F_Ctl_Upd_Process2(Main_Inf)
        If intRet = 0 Then
            '最上明細インデックスの退避
            Wk_Cur_Top_Index = Main_Inf.Dsp_Body_Inf.Cur_Top_Index
            
            '画面ボディ部初期化
            Call F_Init_Clr_Dsp_Body(-1, Main_Inf)
            'データ再取得
            Call F_GET_BD_DATA(Main_Inf)
            '最上明細インデックスを戻す
            Main_Inf.Dsp_Body_Inf.Cur_Top_Index = Wk_Cur_Top_Index
            
            NowPageNum = NowPageNum + 1
            Call CF_Ctl_Dsp_Body_Page(NowPageNum, pm_Act_Dsp_Sub_Inf, pm_All)
            
            Call F_Cursor_Set(pm_All)
            
        End If
        
    Else
    '次ページがない場合、メッセージ表示
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT56_E_019, Main_Inf)
    End If

End Function

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

'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    'フォームタイトル
    FR_SSSMAIN.Caption = SSS_PrgNm

    Index_Wk = CInt(SYSDT.Tag)
    '画面日付
' === 20060727 === UPDATE S
'    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
' === 20060727 === UPDATE E
'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

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

    Const Hosei_Value   As Integer = -20

    Dim BD_UPDKB_Top    As Integer      'モードのTop
    Dim BD_UPDKB_Height As Integer      'モードのHeight

    Dim Bd_Index        As Integer

    '１行目のモードのTopとHeightを基準とする
    BD_UPDKB_Top = BD_UPDKB(0).Top
    BD_UPDKB_Height = BD_UPDKB(0).Height + Hosei_Value

    '表示最終行まで処理
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        If Bd_Index >= 2 Then
        '２行目以降から
            '配置
            'モード
            BD_UPDKB(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '製品ｺｰﾄﾞ
            BD_HINCD(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
            '型式
            BD_HINNMA(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/15  ADD START  KUMEDA
            '更新フラグ
            BD_UPDATE(Bd_Index).Top = BD_UPDKB_Top + BD_UPDKB_Height * (Bd_Index - 1)
' 2006/11/15  ADD END
        End If

        '表示
        'モード
        BD_UPDKB(Bd_Index).Visible = True
        '製品ｺｰﾄﾞ
        BD_HINCD(Bd_Index).Visible = True
        '型式
        BD_HINNMA(Bd_Index).Visible = True
' 2006/11/15  ADD START  KUMEDA
        '更新フラグ
        BD_UPDATE(Bd_Index).Visible = False
' 2006/11/15  ADD END

    Next

End Function

Private Sub TM_StartUp_Timer()
    '一度きりのため使用不可
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '画面印刷起動時はTRUEとする
    PP_SSSMAIN.Operable = True
    '初期ﾌｫｰｶｽ位置設定s
    Call F_Init_Cursor_Set(Main_Inf)
End Sub

Private Sub Form_Load()

    'DB接続
    Call CF_Ora_USR1_Open

    '共通初期化処理
    Call CF_Init

    '画面情報設定
    Call Init_Def_Dsp

    '画面内容初期化
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    '画面明細情報設定
    Call Init_Def_Body_Inf

    '画面明細部初期化
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '明細ロケーション
    Call Set_Body_Location

    '初期表示編集
    Call Edi_Dsp_Def

    '入力担当者更新権限取得
    Call F_Get_Inp_TOK(Main_Inf)

    '画面明細表示
    Call CF_Body_Dsp(Main_Inf)

    '画面表示位置設定
    Call CF_Set_Frm_Location(FR_SSSMAIN)

    '入力担当者編集
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    'メニュー使用可否制御
    Call F_Ctl_MN_Enabled(Main_Inf)

    'システム共通処理
    Call CF_System_Process(Me)

    '画面編集なしとする
    gv_bolTOKMT56_INIT = False
    gv_bolInit = False
    gv_bolTOKMT56_LF_Enable = True
    gv_bolSelectCmFlg = False

End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)

    Dim intRet      As Integer
    Dim Col_Index   As Integer
    
    '確認メッセージ表示
    If (gv_bolTOKMT56_INIT = True) And (pv_InpTan_TOK = True) Then
    '画面項目に変更があり、更新権限がある場合
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT56_A_017, Main_Inf)
    Else
    '画面項目に変更がない、または更新権限がない場合
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgTOKMT56_A_006, Main_Inf)
    End If
    
    If intRet <> vbNo Then
    '検索画面クローズ
        Call F_Ctl_WLS_Close

        '共通終了処理？
        Set FR_SSSMAIN = Nothing
        
    Else
        Cancel = True
        'ステータスバー初期化
        Call CF_Clr_Prompt(Main_Inf)

        Exit Sub
        
    End If
    
' === 20060907 === INSERT S
    Main_Inf.Dsp_Base.IsUnload = True
' === 20060907 === INSERT E
    
    'DB接続解除
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
    
' 2006/11/15  ADD START  KUMEDA
    Call SSSWIN_LOGWRT("プログラム終了")
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

Private Sub CS_TOKCD_Click()
    Debug.Print "CS_TOKCD_Click"
    Call Ctl_Item_Click(CS_TOKCD)
End Sub

Private Sub CS_SKHINGRP_Click()
    Debug.Print "CS_SKHINGRP_Click"
    Call Ctl_Item_Click(CS_SKHINGRP)
End Sub

Private Sub CS_UPDKB_Click()
    Debug.Print "CS_UPDKB_Click"
    Call Ctl_Item_Click(CS_UPDKB)
End Sub

Private Sub CS_HINCD_Click()
    Debug.Print "CS_HINCD_Click"
    Call Ctl_Item_Click(CS_HINCD)
End Sub

Private Sub CS_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub CS_SKHINGRP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_SKHINGRP_MouseUp"
    Call Ctl_Item_MouseUp(CS_SKHINGRP, Button, Shift, X, Y)
End Sub

Private Sub CS_UPDKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_UPDKB_MouseUp"
    Call Ctl_Item_MouseUp(CS_UPDKB, Button, Shift, X, Y)
End Sub

Private Sub CS_HINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "CS_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(CS_HINCD, Button, Shift, X, Y)
End Sub

Private Sub CS_TOKCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_TOKCD)
End Sub

Private Sub CS_SKHINGRP_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_SKHINGRP_KeyUp"
    Call Ctl_Item_KeyUp(CS_SKHINGRP)
End Sub

Private Sub CS_UPDKB_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_UPDKB_KeyUp"
    Call Ctl_Item_KeyUp(CS_UPDKB)
End Sub

Private Sub CS_HINCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "CS_HINCD_KeyUp"
    Call Ctl_Item_KeyUp(CS_HINCD)
End Sub

Private Sub CS_TOKCD_GotFocus()
    Debug.Print "CS_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_TOKCD)
End Sub

Private Sub CS_SKHINGRP_GotFocus()
    Debug.Print "CS_SKHINGRP_GotFocus"
    Call Ctl_Item_GotFocus(CS_SKHINGRP)
End Sub

Private Sub CS_UPDKB_GotFocus()
    Debug.Print "CS_UPDKB_GotFocus"
    Call Ctl_Item_GotFocus(CS_UPDKB)
End Sub

Private Sub CS_HINCD_GotFocus()
    Debug.Print "CS_HINCD_GotFocus"
    Call Ctl_Item_GotFocus(CS_HINCD)
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

Private Sub HD_TOKCD_Change()
    Debug.Print "HD_TOKCD_Change"
    Call Ctl_Item_Change(HD_TOKCD)
End Sub

Private Sub HD_TOKRN_Change()
    Debug.Print "HD_TOKRN_Change"
    Call Ctl_Item_Change(HD_TOKRN)
End Sub

Private Sub HD_SKHINGRP_Change()
    Debug.Print "HD_SKHINGRP_Change"
    Call Ctl_Item_Change(HD_SKHINGRP)
End Sub

Private Sub HD_SKHINRN_Change()
    Debug.Print "HD_SKHINRN_Change"
    Call Ctl_Item_Change(HD_SKHINRN)
End Sub

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_TOKCD_GotFocus()
    Debug.Print "HD_TOKCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKCD)
End Sub

Private Sub HD_TOKRN_GotFocus()
    Debug.Print "HD_TOKRN_GotFocus"
    Call Ctl_Item_GotFocus(HD_TOKRN)
End Sub

Private Sub HD_SKHINGRP_GotFocus()
    Debug.Print "HD_SKHINGRP_GotFocus"
    Call Ctl_Item_GotFocus(HD_SKHINGRP)
End Sub

Private Sub HD_SKHINRN_GotFocus()
    Debug.Print "HD_SKHINRN_GotFocus"
    Call Ctl_Item_GotFocus(HD_SKHINRN)
End Sub

Private Sub HD_IN_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
End Sub

Private Sub HD_TOKCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKCD, KEYCODE, Shift)
End Sub

Private Sub HD_TOKRN_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyDown"
    Call Ctl_Item_KeyDown(HD_TOKRN, KEYCODE, Shift)
End Sub

Private Sub HD_SKHINGRP_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SKHINGRP_KeyDown"
    Call Ctl_Item_KeyDown(HD_SKHINGRP, KEYCODE, Shift)
End Sub

Private Sub HD_SKHINRN_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SKHINRN_KeyDown"
    Call Ctl_Item_KeyDown(HD_SKHINRN, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_TOKRN_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_TOKRN_KeyPress"
    Call Ctl_Item_KeyPress(HD_TOKRN, KeyAscii)
End Sub

Private Sub HD_SKHINGRP_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SKHINGRP_KeyPress"
    Call Ctl_Item_KeyPress(HD_SKHINGRP, KeyAscii)
End Sub

Private Sub HD_SKHINRN_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_SKHINRN_KeyPress"
    Call Ctl_Item_KeyPress(HD_SKHINRN, KeyAscii)
End Sub

Private Sub HD_IN_TANCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANNM)
End Sub

Private Sub HD_TOKCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKCD)
End Sub

Private Sub HD_TOKRN_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_TOKRN_KeyUp"
    Call Ctl_Item_KeyUp(HD_TOKRN)
End Sub

Private Sub HD_SKHINGRP_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SKHINGRP_KeyUp"
    Call Ctl_Item_KeyUp(HD_SKHINGRP)
End Sub

Private Sub HD_SKHINRN_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_SKHINRN_KeyUp"
    Call Ctl_Item_KeyUp(HD_SKHINRN)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub HD_TOKCD_LostFocus()
    Debug.Print "HD_TOKCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKCD)
End Sub

Private Sub HD_TOKRN_LostFocus()
    Debug.Print "HD_TOKRN_LostFocus"
    Call Ctl_Item_LostFocus(HD_TOKRN)
End Sub

Private Sub HD_SKHINGRP_LostFocus()
    Debug.Print "HD_SKHINGRP_LostFocus"
    Call Ctl_Item_LostFocus(HD_SKHINGRP)
End Sub

Private Sub HD_SKHINRN_LostFocus()
    Debug.Print "HD_SKHINRN_LostFocus"
    Call Ctl_Item_LostFocus(HD_SKHINRN)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseDown"
    Call Ctl_Item_MouseDown(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_SKHINGRP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SKHINGRP_MouseDown"
    Call Ctl_Item_MouseDown(HD_SKHINGRP, Button, Shift, X, Y)
End Sub

Private Sub HD_SKHINRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SKHINRN_MouseDown"
    Call Ctl_Item_MouseDown(HD_SKHINRN, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKCD, Button, Shift, X, Y)
End Sub

Private Sub HD_TOKRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_TOKRN_MouseUp"
    Call Ctl_Item_MouseUp(HD_TOKRN, Button, Shift, X, Y)
End Sub

Private Sub HD_SKHINGRP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SKHINGRP_MouseUp"
    Call Ctl_Item_MouseUp(HD_SKHINGRP, Button, Shift, X, Y)
End Sub

Private Sub HD_SKHINRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_SKHINRN_MouseUp"
    Call Ctl_Item_MouseUp(HD_SKHINRN, Button, Shift, X, Y)
End Sub

Private Sub BD_UPDKB_Change(Index As Integer)
    Debug.Print "BD_UPDKB_Change"
    Call Ctl_Item_Change(BD_UPDKB(Index))
End Sub

Private Sub BD_HINCD_Change(Index As Integer)
    Debug.Print "BD_HINCD_Change"
    Call Ctl_Item_Change(BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_Change(Index As Integer)
    Debug.Print "BD_HINNMA_Change"
    Call Ctl_Item_Change(BD_HINNMA(Index))
End Sub

Private Sub BD_UPDKB_GotFocus(Index As Integer)
    Debug.Print "BD_UPDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_UPDKB(Index))
End Sub

Private Sub BD_HINCD_GotFocus(Index As Integer)
    Debug.Print "BD_HINCD_GotFocus"
' === 20060825 === INSERT S
    Current_Hincd_Index = Index
' === 20060825 === INSERT E
    Call Ctl_Item_GotFocus(BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_GotFocus(Index As Integer)
    Debug.Print "BD_HINNMA_GotFocus"
    Call Ctl_Item_GotFocus(BD_HINNMA(Index))
End Sub

Private Sub BD_UPDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_UPDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_HINCD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HINCD_KeyDown"
    Call Ctl_Item_KeyDown(BD_HINCD(Index), KEYCODE, Shift)
End Sub

Private Sub BD_HINNMA_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HINNMA_KeyDown"
    Call Ctl_Item_KeyDown(BD_HINNMA(Index), KEYCODE, Shift)
End Sub

Private Sub BD_UPDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_UPDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_UPDKB(Index), KeyAscii)
End Sub

Private Sub BD_HINCD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HINCD_KeyPress"
    Call Ctl_Item_KeyPress(BD_HINCD(Index), KeyAscii)
End Sub

Private Sub BD_HINNMA_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_HINNMA_KeyPress"
    Call Ctl_Item_KeyPress(BD_HINNMA(Index), KeyAscii)
End Sub

Private Sub BD_UPDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_UPDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_UPDKB(Index))
End Sub

Private Sub BD_HINCD_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HINCD_KeyUp"
    Call Ctl_Item_KeyUp(BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_HINNMA_KeyUp"
    Call Ctl_Item_KeyUp(BD_HINNMA(Index))
End Sub

Private Sub BD_UPDKB_LostFocus(Index As Integer)
    Debug.Print "BD_UPDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_UPDKB(Index))
End Sub

Private Sub BD_HINCD_LostFocus(Index As Integer)
    Debug.Print "BD_HINCD_LostFocus"
    Call Ctl_Item_LostFocus(BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_LostFocus(Index As Integer)
    Debug.Print "BD_HINNMA_LostFocus"
    Call Ctl_Item_LostFocus(BD_HINNMA(Index))
End Sub

Private Sub BD_UPDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_UPDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINCD_MouseDown"
    Call Ctl_Item_MouseDown(BD_HINCD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMA_MouseDown"
    Call Ctl_Item_MouseDown(BD_HINNMA(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_UPDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_UPDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_UPDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINCD_MouseUp"
    Call Ctl_Item_MouseUp(BD_HINCD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_HINNMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_HINNMA_MouseUp"
    Call Ctl_Item_MouseUp(BD_HINNMA(Index), Button, Shift, X, Y)
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
