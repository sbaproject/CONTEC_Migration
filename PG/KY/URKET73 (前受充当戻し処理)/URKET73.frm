VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "spr32x30.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '固定(実線)
   Caption         =   "前受充当戻し"
   ClientHeight    =   10050
   ClientLeft      =   1455
   ClientTop       =   795
   ClientWidth     =   14520
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "URKET73.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   ScaleHeight     =   10050
   ScaleWidth      =   14520
   Begin Threed5.SSPanel5 pnl_syohizei 
      Height          =   330
      Left            =   4980
      TabIndex        =   57
      Top             =   2670
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   582
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "消費税差額"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 pnl_tesuryo 
      Height          =   330
      Left            =   3585
      TabIndex        =   55
      Top             =   2670
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   582
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderWidth     =   0
      BevelOuter      =   1
      Caption         =   "手数料"
      OutLine         =   -1  'True
   End
   Begin VB.PictureBox img_bklight 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'なし
      Height          =   330
      Index           =   1
      Left            =   585
      Picture         =   "URKET73.frx":030A
      ScaleHeight     =   330
      ScaleWidth      =   300
      TabIndex        =   38
      TabStop         =   0   'False
      Top             =   10140
      Width           =   300
   End
   Begin VB.PictureBox img_bklight 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'なし
      Height          =   330
      Index           =   0
      Left            =   225
      Picture         =   "URKET73.frx":0494
      ScaleHeight     =   330
      ScaleWidth      =   300
      TabIndex        =   37
      TabStop         =   0   'False
      Top             =   10140
      Width           =   300
   End
   Begin FPSpread.vaSpread spd_body 
      Height          =   5880
      Left            =   75
      TabIndex        =   6
      Top             =   3405
      Width           =   14385
      _Version        =   196608
      _ExtentX        =   25374
      _ExtentY        =   10372
      _StockProps     =   64
      AllowUserFormulas=   -1  'True
      ColHeaderDisplay=   0
      ColsFrozen      =   1
      DisplayRowHeaders=   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxCols         =   36
      MaxRows         =   9999
      NoBeep          =   -1  'True
      ScrollBars      =   2
      SpreadDesigner  =   "URKET73.frx":061E
      UserResize      =   2
      VisibleCols     =   36
      VisibleRows     =   9999
      ScrollBarTrack  =   1
   End
   Begin Threed5.SSCommand5 cmd_kesidt 
      Height          =   330
      Left            =   315
      TabIndex        =   10
      TabStop         =   0   'False
      Top             =   645
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*消込(充当)日"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 pnl_tail 
      Height          =   735
      Left            =   0
      TabIndex        =   8
      Top             =   9330
      Width           =   14535
      _ExtentX        =   25638
      _ExtentY        =   1296
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.PictureBox img_light 
         AutoSize        =   -1  'True
         BorderStyle     =   0  'なし
         Height          =   330
         Left            =   150
         Picture         =   "URKET73.frx":1C225
         ScaleHeight     =   330
         ScaleWidth      =   300
         TabIndex        =   23
         TabStop         =   0   'False
         Top             =   135
         Width           =   300
      End
      Begin Threed5.SSPanel5 pnl_msg 
         Height          =   465
         Left            =   600
         TabIndex        =   22
         Top             =   135
         Width           =   12480
         _ExtentX        =   22013
         _ExtentY        =   820
         Enabled         =   0   'False
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
         Begin VB.TextBox txt_message 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'なし
            Height          =   195
            Left            =   105
            TabIndex        =   24
            TabStop         =   0   'False
            Text            =   "エラーやプロンプトのメッセージが出力されるところです。"
            Top             =   90
            Width           =   12180
         End
      End
   End
   Begin Threed5.SSCommand5 cmd_tokseicd 
      Height          =   330
      Left            =   315
      TabIndex        =   12
      TabStop         =   0   'False
      Top             =   960
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*請求先    "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_kaidt_From 
      Height          =   330
      Left            =   315
      TabIndex        =   13
      TabStop         =   0   'False
      Top             =   1275
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   " *売上日(開始)"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_fridt 
      Height          =   330
      Left            =   315
      TabIndex        =   14
      TabStop         =   0   'False
      Top             =   2010
      Visible         =   0   'False
      Width           =   1695
      _ExtentX        =   2990
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "振込期日 "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_tesuryo 
      Height          =   330
      Left            =   3585
      TabIndex        =   15
      TabStop         =   0   'False
      Top             =   2670
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "手数料"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_syohi 
      Height          =   330
      Left            =   4980
      TabIndex        =   16
      TabStop         =   0   'False
      Top             =   2670
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "消費税差額"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_zenkesi 
      Height          =   330
      Left            =   11325
      TabIndex        =   17
      TabStop         =   0   'False
      Top             =   2670
      Width           =   1320
      _ExtentX        =   2328
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "全消込"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_zenkaijo 
      Height          =   330
      Left            =   9930
      TabIndex        =   18
      TabStop         =   0   'False
      Top             =   2670
      Width           =   1320
      _ExtentX        =   2328
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "全解除"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_saihyoji 
      Height          =   330
      Left            =   12855
      TabIndex        =   19
      TabStop         =   0   'False
      Top             =   2670
      Width           =   1320
      _ExtentX        =   2328
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "再表示"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 pnl_head 
      Height          =   555
      Left            =   0
      TabIndex        =   20
      Top             =   0
      Width           =   14535
      _ExtentX        =   25638
      _ExtentY        =   979
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 pnl_unydt 
         Height          =   330
         Left            =   12525
         TabIndex        =   21
         Top             =   105
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
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
      Begin VB.Image img_unlock 
         Height          =   330
         Left            =   1320
         Picture         =   "URKET73.frx":1C3AF
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_showwnd 
         Height          =   330
         Left            =   870
         Picture         =   "URKET73.frx":1C539
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_exit 
         Height          =   330
         Left            =   150
         Picture         =   "URKET73.frx":1C6C3
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_resist 
         Height          =   330
         Left            =   510
         Picture         =   "URKET73.frx":1C84D
         Top             =   90
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 pnl_condition1 
      Height          =   1860
      Left            =   60
      TabIndex        =   39
      Top             =   570
      Width           =   14310
      _ExtentX        =   25241
      _ExtentY        =   3281
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "条件用１"
      Begin VB.PictureBox Picture2 
         Appearance      =   0  'ﾌﾗｯﾄ
         BorderStyle     =   0  'なし
         Enabled         =   0   'False
         ForeColor       =   &H80000008&
         Height          =   405
         Left            =   11055
         ScaleHeight     =   405
         ScaleWidth      =   3180
         TabIndex        =   52
         Top             =   75
         Width           =   3180
         Begin VB.TextBox txt_opeid 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            Height          =   330
            Left            =   0
            TabIndex        =   54
            TabStop         =   0   'False
            Text            =   "XXXXXXX8"
            Top             =   0
            Width           =   915
         End
         Begin VB.TextBox txt_openm 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            Height          =   330
            Left            =   900
            TabIndex        =   53
            TabStop         =   0   'False
            Text            =   "MMMMMMMMM1MMMMMMMMM2"
            Top             =   0
            Width           =   2220
         End
      End
      Begin VB.Frame frm_opt1 
         Caption         =   "ｿｰﾄ条件"
         Height          =   660
         Left            =   9690
         TabIndex        =   44
         Top             =   615
         Width           =   4560
         Begin VB.OptionButton opt_sort 
            Caption         =   "客先注文番号"
            Height          =   195
            Index           =   2
            Left            =   2790
            TabIndex        =   11
            TabStop         =   0   'False
            Top             =   285
            Width           =   1590
         End
         Begin VB.OptionButton opt_sort 
            Caption         =   "売上日"
            Height          =   270
            Index           =   0
            Left            =   255
            TabIndex        =   7
            TabStop         =   0   'False
            Top             =   255
            Width           =   1200
         End
         Begin VB.OptionButton opt_sort 
            Caption         =   "受注番号"
            Height          =   195
            Index           =   1
            Left            =   1485
            TabIndex        =   9
            TabStop         =   0   'False
            Top             =   285
            Width           =   1260
         End
      End
      Begin VB.TextBox txt_kaidt_To 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   4815
         MaxLength       =   10
         TabIndex        =   3
         Text            =   "YYYY/MM/DD"
         Top             =   705
         Width           =   1215
      End
      Begin VB.TextBox txt_kesikb 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1935
         MaxLength       =   1
         TabIndex        =   4
         Text            =   "9"
         Top             =   1020
         Width           =   285
      End
      Begin VB.TextBox txt_kesidt 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1935
         MaxLength       =   10
         TabIndex        =   0
         Text            =   "YYYY/MM/DD"
         Top             =   75
         Width           =   1215
      End
      Begin VB.TextBox txt_tokseicd 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1935
         MaxLength       =   5
         TabIndex        =   1
         Text            =   "XXXX5"
         Top             =   390
         Width           =   1215
      End
      Begin VB.TextBox txt_kaidt_From 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1935
         MaxLength       =   10
         TabIndex        =   2
         Text            =   "YYYY/MM/DD"
         Top             =   705
         Width           =   1215
      End
      Begin VB.TextBox txt_fridt 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1935
         MaxLength       =   10
         TabIndex        =   5
         TabStop         =   0   'False
         Text            =   "YYYY/MM/DD"
         Top             =   1440
         Visible         =   0   'False
         Width           =   1215
      End
      Begin Threed5.SSPanel5 pnl_kesikb 
         Height          =   330
         Left            =   255
         TabIndex        =   40
         Top             =   1020
         Width           =   1695
         _ExtentX        =   2990
         _ExtentY        =   582
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
         Caption         =   "充当済ﾃﾞｰﾀ表示"
         OutLine         =   -1  'True
      End
      Begin Threed5.SSPanel5 pnl_condition2 
         Height          =   480
         Left            =   1920
         TabIndex        =   41
         Top             =   1020
         Width           =   450
         _ExtentX        =   794
         _ExtentY        =   847
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ Ｐゴシック"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Caption         =   "条件用２"
      End
      Begin Threed5.SSCommand5 cmd_kaidt_To 
         Height          =   330
         Left            =   3135
         TabIndex        =   43
         TabStop         =   0   'False
         Top             =   705
         Width           =   1695
         _ExtentX        =   2990
         _ExtentY        =   582
         ForeColor       =   -2147483640
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Caption         =   "*売上日(終了)"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 pnl_opeid 
         Height          =   330
         Left            =   9810
         TabIndex        =   45
         Top             =   75
         Width           =   1260
         _ExtentX        =   2223
         _ExtentY        =   582
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
      Begin VB.PictureBox Picture1 
         Appearance      =   0  'ﾌﾗｯﾄ
         BorderStyle     =   0  'なし
         Enabled         =   0   'False
         ForeColor       =   &H80000008&
         Height          =   405
         Left            =   3135
         ScaleHeight     =   405
         ScaleWidth      =   6540
         TabIndex        =   50
         Top             =   390
         Width           =   6540
         Begin VB.TextBox txt_tokseinma 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            Height          =   330
            Left            =   0
            TabIndex        =   51
            TabStop         =   0   'False
            Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
            Top             =   0
            Width           =   6465
         End
      End
      Begin VB.Label lbl_hytokkesdd 
         BackStyle       =   0  '透明
         Caption         =   "末日"
         Height          =   420
         Index           =   1
         Left            =   11265
         TabIndex        =   49
         Top             =   1635
         Width           =   1995
      End
      Begin VB.Label lbl_hytokkesdd 
         BackStyle       =   0  '透明
         Caption         =   "回収日  :"
         Height          =   420
         Index           =   0
         Left            =   10260
         TabIndex        =   48
         Top             =   1650
         Width           =   1995
      End
      Begin VB.Label lbl_shakbnm 
         BackStyle       =   0  '透明
         Caption         =   "振込または手形"
         Height          =   420
         Index           =   1
         Left            =   11250
         TabIndex        =   47
         Top             =   1380
         Width           =   3000
      End
      Begin VB.Label lbl_shakbnm 
         BackStyle       =   0  '透明
         Caption         =   "支払条件:"
         Height          =   420
         Index           =   0
         Left            =   10260
         TabIndex        =   46
         Top             =   1380
         Width           =   3000
      End
      Begin VB.Label lbl_b 
         Caption         =   "1:表示しない  9:表示する"
         Height          =   300
         Left            =   2385
         TabIndex        =   42
         Top             =   1080
         Width           =   2850
      End
   End
   Begin Threed5.SSPanel5 pnl_hihyoji 
      Height          =   2805
      Left            =   150
      TabIndex        =   25
      Top             =   570
      Width           =   14265
      _ExtentX        =   25162
      _ExtentY        =   4948
      Enabled         =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "表示限定テキストボックス設定用パネル"
      Begin VB.TextBox txt_urigoukei 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   165
         TabIndex        =   31
         TabStop         =   0   'False
         Text            =   "-9,999,999,999"
         Top             =   2415
         Width           =   1650
      End
      Begin VB.TextBox txt_nyukin 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   1800
         TabIndex        =   30
         TabStop         =   0   'False
         Text            =   "-9,999,999,999"
         Top             =   2415
         Width           =   1650
      End
      Begin VB.TextBox txt_nyugoukei 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   6225
         TabIndex        =   29
         TabStop         =   0   'False
         Text            =   "-9,999,999,999"
         Top             =   2415
         Width           =   1650
      End
      Begin VB.TextBox txt_kesizan 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   7860
         TabIndex        =   28
         TabStop         =   0   'False
         Text            =   "-9,999,999,999"
         Top             =   2415
         Width           =   1650
      End
      Begin VB.TextBox txt_tesuryo 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   3435
         TabIndex        =   27
         TabStop         =   0   'False
         Text            =   "-999,999"
         Top             =   2415
         Width           =   1410
      End
      Begin VB.TextBox txt_syohi 
         Alignment       =   1  '右揃え
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         Left            =   4830
         TabIndex        =   26
         TabStop         =   0   'False
         Text            =   "-999,999"
         Top             =   2415
         Width           =   1410
      End
      Begin Threed5.SSPanel5 pnl_urigoukei 
         Height          =   330
         Left            =   165
         TabIndex        =   32
         Top             =   2100
         Width           =   1650
         _ExtentX        =   2910
         _ExtentY        =   582
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
         Caption         =   "売上合計"
         OutLine         =   -1  'True
      End
      Begin Threed5.SSPanel5 pnl_nyukin 
         Height          =   330
         Left            =   1800
         TabIndex        =   33
         Top             =   2100
         Width           =   1650
         _ExtentX        =   2910
         _ExtentY        =   582
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
         Caption         =   "前受入金額"
         OutLine         =   -1  'True
      End
      Begin Threed5.SSPanel5 pnl_nyugoukei 
         Height          =   330
         Left            =   6225
         TabIndex        =   34
         Top             =   2100
         Width           =   1650
         _ExtentX        =   2910
         _ExtentY        =   582
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
         Caption         =   "前受入金合計"
         OutLine         =   -1  'True
      End
      Begin Threed5.SSPanel5 pnl_kesizan 
         Height          =   330
         Left            =   7860
         TabIndex        =   35
         Top             =   2100
         Width           =   1650
         _ExtentX        =   2910
         _ExtentY        =   582
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
         Caption         =   "充当残額"
         OutLine         =   -1  'True
      End
      Begin VB.Label lbl_c 
         Caption         =   "＜消込情報＞"
         Height          =   300
         Left            =   0
         TabIndex        =   36
         Top             =   1860
         Width           =   1455
      End
   End
   Begin Threed5.SSPanel5 SSPanel51 
      Height          =   330
      Left            =   0
      TabIndex        =   56
      Top             =   0
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   582
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderWidth     =   0
      BevelOuter      =   1
      Caption         =   "手数料"
      OutLine         =   -1  'True
   End
   Begin VB.Image img_bkunlock 
      Height          =   330
      Index           =   0
      Left            =   3489
      Picture         =   "URKET73.frx":1CE9F
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkunlock 
      Height          =   330
      Index           =   1
      Left            =   3915
      Picture         =   "URKET73.frx":1D029
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkshowwnd 
      Height          =   330
      Index           =   1
      Left            =   3066
      Picture         =   "URKET73.frx":1D1B3
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkshowwnd 
      Height          =   330
      Index           =   0
      Left            =   2643
      Picture         =   "URKET73.frx":1D33D
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkexit 
      Height          =   330
      Index           =   1
      Left            =   1374
      Picture         =   "URKET73.frx":1D4C7
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkexit 
      Height          =   330
      Index           =   0
      Left            =   951
      Picture         =   "URKET73.frx":1D651
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkresist 
      Height          =   330
      Index           =   1
      Left            =   2220
      Picture         =   "URKET73.frx":1D7DB
      Top             =   10140
      Width           =   360
   End
   Begin VB.Image img_bkresist 
      Height          =   330
      Index           =   0
      Left            =   1797
      Picture         =   "URKET73.frx":1DE2D
      Top             =   10140
      Width           =   360
   End
   Begin VB.Menu mnu_syo 
      Caption         =   "処理(&1)"
      Begin VB.Menu mnu_regist 
         Caption         =   "登録(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu mnu_exit 
         Caption         =   "終了(&X)"
      End
   End
   Begin VB.Menu mnu_hen 
      Caption         =   "編集(&2)"
      Begin VB.Menu mnu_initdsp 
         Caption         =   "画面初期化(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu bar21 
         Caption         =   "-"
      End
      Begin VB.Menu mnu_zenkesi 
         Caption         =   "全消込(&A)"
         Shortcut        =   ^A
      End
      Begin VB.Menu mnu_zenkaijo 
         Caption         =   "全解除(&U)"
         Shortcut        =   ^U
      End
   End
   Begin VB.Menu mnu_sou 
      Caption         =   "操作(&3)"
      Begin VB.Menu mnu_showwnd 
         Caption         =   "候補の一覧(&L)"
         Shortcut        =   {F5}
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
    Option Explicit
'//* All Right Reserved Copy Right (C)  株式会社富士通関西システムズ
'//***************************************************************************************
'//*
'//*＜名称＞
'//* URKET73 前受充当戻し
'//*
'//*＜バージョン＞
'//* 1.00
'//*
'//*＜作成者＞
'//* FKS)
'//*
'//*＜説明＞
'//* 前受充当の戻し処理画面
'//*
'//**************************************************************************************
'//*変更履歴
'//* ﾊﾞｰｼﾞｮﾝ  |  日付    | 更新者        |内容
'//* ---------|----------|---------------|-----------------------------------------------
'//* 1.00     |2009/06/13|FKS)中田       |新規作成(URKET53 入金消込より流用作成)
'//* 1.01     |2009/07/06|FKS)中田       |消込可能金額取得ロジックの追加
'//* 1.02     |2009/08/28|FKS)中田       |消込可能金額取得ロジックの変更(getUdntraNyukn)
'//* 1.03     |2009/09/03|FKS)中田       |振込期日に関する処理を変更(戻し画面からの入力をできなくする)
'//*          |          |               |　振込期日(cmd_fridt/txt_fridt)のVisibleを
'//* 　　　　 |          |               |　「Ture」から「False」へ変更
'//* 　　　　 |          |               |　振込期日(txt_fridt)のTabStopを「Ture」から「False」へ変更
'//* 1.04     |2009/09/07|FKS)中田       |請求締日以前の日付を入力不可とする。
'//* 　　　　 |          |               |請求先の担当者が営業担当で無い場合、エラーとする。
'//* 2.00     |2009/09/16|FKS)中田       |・入金消込サマリーの本入金項目に対して何も更新しないようにする
'//*          |          |               |・前月解除時の入金消込サマリーの戻し先変更（入金→消込）
'//*          |          |               |・手数料・消費は自身の持っている入金区分にて消込トランを作成する
'//*          |          |               |・分納対応のため、金額チェック・伝票単位チェックを外す
'//**************************************************************************************



Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long
Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long

Dim intUrigoukei    As Currency     '売上金額の合計を格納（明細表示時にセット）
Dim intBfkesiknkei  As Currency     '消込済額(締日前)の合計額を格納（明細表示時にセット）


Dim blnFriEnabled   As Boolean      '振込期日を入力できるかどうかのフラグ(判定は「手形」「振込期日（ファクタリング）」が存在する時）

Dim blnUsableSpread As Boolean      'ｽﾌﾟﾚｯﾄﾞのｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
Dim intMaxRow       As Integer      'ｽﾌﾟﾚｯﾄﾞの表示最大行数を格納

Dim blnUsableButton As Boolean      '手数料、消費税差額、全消込、全解除、再表示、振込期日(明細部)のｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
Dim intChkKb        As Integer      'チェック区分(1:チェック 2:チェック(前回から変更時のみ)
Dim blnUsableEvent  As Boolean      'ｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ(汎用)
Dim blnINIT_FLG     As Boolean


Dim intInputMode    As Integer      '入力状態(1:ヘッダー 2:明細 9:画面クリアー処理)


''赤黒チェック用構造体
Private Type TYPE_AKAKRO_CHK
    idx            As Long      '行番号
    CHKMK          As Integer   'チェックマーク
    UDNDT          As String    '売上日
    JDNNO          As String    '受注№
    KESIKN         As Currency  '消込金額
End Type

Private AKAKRO_CHK() As TYPE_AKAKRO_CHK


''伝票単位チェック用構造体
Private Type TYPE_JDNTRKB_CHK
    idx            As Long      '行番号
    JDNNO          As String    '受注№
    HYJDNNO        As String    '表示用受注番号
    KOMIKN         As Currency  '税込売上金額
End Type

Private JDNTRKB_CHK() As TYPE_JDNTRKB_CHK



'フォームロードイベント
Private Sub Form_Load()

    'WINDOW 位置設定
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    'ローカル変数初期化
    intUrigoukei = 0
    intBfkesiknkei = 0
    intMaxRow = 0
    intChkKb = 2

    blnFriEnabled = False
    blnUsableSpread = False
    blnUsableButton = False
    blnUsableEvent = True

    '★DBへの接続
    If CF_Ora_USR1_Open = False Then
        MsgBox "DBの接続に失敗しました。", vbCritical, "接続エラー"
    End If

    'PG初期化
    Call CF_Init

    '画面初期化
    initForm
    initCondition
    initHead
    initBody


    intInputMode = 1

    'システム共通処理
    Call CF_System_Process(Me)

    
    '★ログの書き出し
    Call SSSWIN_LOGWRT("プログラム起動")
End Sub

'フォームアンロードイベント
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    '●終了確認のMSG

    If ChkInputChange() = True Then
        If showMsg("0", "_ENDCK", 0) = vbNo Then
            Cancel = vbCancel
            Exit Sub
        End If
    Else
        If showMsg("0", "_ENDCM", 0) = vbNo Then
            Cancel = vbCancel
            Exit Sub
        End If
    End If


    '排他テーブル削除
    Call SSSEXC_EXCTBZ_CLOSE

' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

    'DBの接続を切断
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)

    Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)


    '★ログの書き出し
    Call SSSWIN_LOGWRT("プログラム終了")

    End '●PG終了
End Sub

'フォームの初期化
Private Sub initForm()
    Dim i As Integer
'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
    Dim strRet As String
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

    'フォームキャプションセット
    Me.Caption = SSS_PrgNm

    '運用日の取得
    gstrUnydt = getUnydt
    '前回経理締実行日の取得
    Call getSYSTBA
'''' UPD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
'    '権限の取得
'    Call Get_Authority(gstrUnydt)
    '権限の取得
    strRet = Get_Authority(gstrUnydt)
    If strRet = "9" Then
        '起動権限なしの場合、処理終了
        Call showMsg("2", "RUNAUTH", 0)
        End
    End If
'''' UPD 2009/11/26  FKS) T.Yamamoto    End

    '画面右上の項目に運用日をセット
    pnl_unydt.Caption = CNV_DATE(gstrUnydt)

    '入力担当者をセット
    txt_opeid.Text = SSS_OPEID
    txt_openm.Text = getTannm(SSS_OPEID)

    txt_message.Text = ""

    '条件固定用パネルを隠す
    pnl_condition1.Caption = ""
    pnl_condition1.BevelOuter = ssBevelNone
    pnl_condition2.Caption = ""
    pnl_condition2.BevelOuter = ssBevelNone

    '表示限定テキストボックス設定用パネルを隠す
    pnl_hihyoji.Caption = ""
    pnl_hihyoji.BevelOuter = ssBevelNone


    'ｽﾌﾟﾚｯﾄﾞ隠し項目を非表示にする
    If SHOW_HIDE_COLUMN_FLAG = False Then
        With spd_body
            .Row = -1
            For i = COL_BFKESIKN To COL_HENPI
                .Col = i
                .ColHidden = True
            Next i
        End With
    End If


End Sub

'入力条件の初期化
Private Sub initCondition()

    Call initVal    'ｸﾞﾛｰﾊﾞﾙ変数の初期化

    txt_kesidt.Text = CNV_DATE(gstrUnydt)   '運用日をセット
    txt_kesidt.ForeColor = vbBlack
    txt_kesidt.BackColor = vbWhite

    txt_tokseicd.Text = Space(5)            '5byte space
    txt_tokseicd.ForeColor = vbBlack
    txt_tokseicd.BackColor = vbWhite

    txt_tokseinma.Text = ""

    txt_kaidt_From.Text = Space(10)             '10byte space
    txt_kaidt_From.ForeColor = vbBlack
    txt_kaidt_From.BackColor = vbWhite

    txt_kaidt_To.Text = CNV_DATE(gstrUnydt)     '運用日をセット
    txt_kaidt_To.ForeColor = vbBlack
    txt_kaidt_To.BackColor = vbWhite



    '前受充当は初期値を「９」とする。
    'txt_kesikb.Text = 1
    txt_kesikb.Text = 9

    blnFriEnabled = False
    txt_fridt.Text = Space(10)                  '10byte space
    txt_fridt.ForeColor = vbBlack
    txt_fridt.BackColor = vbWhite
    txt_fridt.Enabled = blnFriEnabled

    blnUsableButton = False
    blnUsableEvent = True

    'オプション項目の制御
    frm_opt1.Visible = OPTION_SHOW_FLAG
    opt_sort(0).Value = True
    lbl_shakbnm(0).Visible = OPTION_SHOW_FLAG
    lbl_shakbnm(1).Visible = OPTION_SHOW_FLAG
    lbl_shakbnm(1).Caption = ""
    lbl_hytokkesdd(0).Visible = OPTION_SHOW_FLAG
    lbl_hytokkesdd(1).Visible = OPTION_SHOW_FLAG
    lbl_hytokkesdd(1).Caption = ""
    bar21.Visible = OPTION_SHOW_FLAG
    mnu_zenkesi.Visible = OPTION_SHOW_FLAG
    mnu_zenkaijo.Visible = OPTION_SHOW_FLAG
    mnu_zenkesi.Enabled = blnUsableButton
    mnu_zenkaijo.Enabled = blnUsableButton
End Sub

'ヘッダ部(消込情報)の初期化
Private Sub initHead()
    txt_urigoukei.Text = 0
    txt_nyukin.Text = 0
    txt_tesuryo.Text = 0
    txt_syohi.Text = 0
    txt_nyugoukei.Text = 0
    txt_kesizan.Text = 0
    intUrigoukei = 0
    intBfkesiknkei = 0
End Sub

'明細部の初期化
Private Sub initBody()
    '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
    blnUsableSpread = False

    With spd_body
        .ReDraw = False

        .Col = -1
        .Row = -1
        .Action = ActionClearText

        'カーソル位置を先頭に戻す
        .Col = 1
        .Row = 1
        .Action = ActionSelectBlock

        .MaxRows = 9999
        .ReDraw = True
    End With

    intMaxRow = 0

    'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
    blnUsableSpread = True
End Sub

'明細部の情報を表示
Private Sub showBody()
    Dim strSql  As Variant
    Dim Usr_Ody As U_Ody
    Dim tmp     As Variant
    Dim intRet  As Integer
    Dim lw_sort As Integer
    Dim bleNextFlg As Boolean
    Dim idxRow As Long
    Dim strHyjdnno As String
    Dim strTEGDT    As String

' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
    Dim rResult     As Integer  ' 処理チェック関数戻り値
    Dim strUDNDT    As String
' === 20130708 === INSERT E

' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

    '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
    blnUsableSpread = False

    '排他用配列の初期化
    ReDim ARY_UDNTRA_HAITA(0)
    ReDim ARY_JDNTRA_HAITA(0)
    ReDim ARY_UDNTRA_NYU_HAITA(0)
    
    ReDim ARY_NYUKN_KS(0)
    
    ARY_NYUKN_KS_CNT = 0

    'マウスカーソルを砂時計にする
    Me.MousePointer = vbHourglass
    
    '明細データ取得用SQLを作成
    Select Case True
        Case opt_sort(0).Value
            lw_sort = 0
        Case opt_sort(1).Value
            lw_sort = 1
        Case opt_sort(2).Value
            lw_sort = 2
    End Select
    
    
    '明細部表示データ取得SQLを作成する
    strSql = getSQLforBody( _
                            DB_SYSTBA.SMAUPDDT, _
                            gstrTokseicd, _
                            gstrKaidt_Fr, _
                            gstrKaidt_To, _
                            txt_kesikb.Text, _
                            lw_sort)
    'ﾃﾞｰﾀ取得
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '表示項目初期化
    initHead
    initBody


    '処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
    blnUsableSpread = False


    With spd_body
        .ReDraw = False

        Do While CF_Ora_EOF(Usr_Ody) = False

            '貼り付けるデータが返品データの場合､黒データを検索
            bleNextFlg = True

            '返品の赤黒チェック
            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then


                'データの表示を行わない
                bleNextFlg = False
            Else
                bleNextFlg = True
            End If
            
            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
                '返品後、受注訂正処理の赤黒チェック
                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", ""))) = False Then

                   'データの表示を行わない
                     bleNextFlg = False
                Else
                    bleNextFlg = True
                End If
            End If


        ''入力された消込日以降の売上データを出さない
            If bleNextFlg = False Then
                bleNextFlg = False

            Else
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim$(txt_kesidt.Text)) _
                        And Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) > 0 Then

                    '黒データで入力された消込日より後の売上は表示しない
                    bleNextFlg = False

                ElseIf Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim$(txt_kesidt.Text)) _
                        And Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) < 0 Then
                    '返品の場合は、既に画面上に同じ受注番号が存在するかを確認する。
                    With spd_body
                          For idxRow = intMaxRow To 1 Step -1
                              Call .GetText(COL_HYJDNNO, idxRow, tmp)
                              strHyjdnno = CStr(tmp)

                              If Trim(strHyjdnno) = Trim$(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
                                  '画面上に黒がいれば出力
                                  bleNextFlg = True
                                  Exit For
                              Else
                                  bleNextFlg = False
                              End If
                          Next idxRow
                      End With
                Else
                    bleNextFlg = True

                End If
            End If



            '//表示判断チェック
            If chkHenpin2(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
                bleNextFlg = False
            End If


            If bleNextFlg = True Then

                intMaxRow = intMaxRow + 1

                'スプレッドに取得したデータを表示
                .Row = intMaxRow
                .Col = COL_NO           'No.
                .Text = intMaxRow

                .Col = COL_NXTKB        '帳端
                .Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")

                .Col = COL_HYUDNDT      '売上日
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
                strUDNDT = .Text
' === 20130708 === INSERT E -

                .Col = COL_HYJDNNO      '受注番号
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
                If .Text <> "" Then
                    '排他チェック
                    rResult = SSSWIN_EXCTBZ_CHECK2(Left$(.Text, 6))
                    Select Case rResult
                        '正常
                        Case 0
                        
                        '排他処理中
                        Case 1
                        MsgBox ("他のプログラムで更新中のため、登録できません。" & vbCrLf & vbCrLf _
                                    & "行No:" & vbTab & intMaxRow & vbCrLf _
                                    & "売上日: " & vbTab & strUDNDT & vbCrLf _
                                    & "受注番号: " & vbTab & .Text)
                        Call SSSWIN_Unlock_EXCTBZ
                        initBody
                        GoTo STEP10_ShowBody
                        
                        '異常終了
                        Case 9
                        Call showMsg("2", "URKET73_034", 0)  '更新異常
                        Call SSSWIN_Unlock_EXCTBZ
                        initBody
                        GoTo STEP10_ShowBody
                    End Select
                End If
' === 20130708 === INSERT E -

                .Col = COL_HYKAIDT      '回収予定日
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")

                .Col = COL_TOKJDNNO     '客先注文番号
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")

                .Col = COL_TANNM        '営業担当者
                .Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")

                .Col = COL_URIKN        '税抜売上金額
                .Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")

                .Col = COL_UZEKN        '消費税額
                .Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")

                .Col = COL_KOMIKN       '税込売上金額
                .Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
                '合計金額を計算
                intUrigoukei = intUrigoukei + SSSVal(.Text)

                .Col = COL_KESIKN       '入金済額
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")

                .Col = COL_MINYUKN      '未入金額(非表示)
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")

                .Col = COL_HYFRIDT      '振込期日
                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
                If Trim(strTEGDT) <> "" Then
                    .Text = CNV_DATE(strTEGDT)
                Else
        '*** 2009/09/03 ADD START FKS)NAKATA V1.03
                    '入金レコードより振込期日を取得する
                    strTEGDT = Get_NYUKN_TEGDT(CF_Ora_GetDyn(Usr_Ody, "jdnno", ""), CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
        '*** 2009/09/03 ADD E.N.D FKS)NAKATA
                    If Trim(strTEGDT) <> "" Then
                        .Text = CNV_DATE(strTEGDT)
                    End If
                End If
                
                .Col = COL_BFHYFRIDT    '振込期日(変更前)
                If Trim(strTEGDT) <> "" Then
                    .Text = CNV_DATE(strTEGDT)
                
        '*** 2009/09/03 DEL START FKS)NAKATA V1.03
        '        Else
        '            .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
        '*** 2009/09/03 DEL START FKS)NAKATA V1.03
                End If
                .Col = COL_HYFRIDT      '振込期日

                'ヘッダ部と同じく、明細部の入力も制限

                .Lock = Not blnFriEnabled
                
                .Col = COL_BFKESIKN  '消込済額(締日前)
                .Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
                    '合計金額を計算
                    intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)

                    '●入金済額(KESIKN) - 消込済額(締日前) > 0 のときﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸを付ける
                    .GetText COL_KESIKN, .Row, tmp
                    
                    If SSSVal(tmp) <> 0 Then

                        .Col = COL_CHK
                        .Value = 1

                        .Col = COL_BFCHECK
                        .Value = 1

                    End If

                .Col = COL_AFKESIKN     '消込済額(締日後)
                .Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")

                .Col = COL_JDNNO        '受注番号(6桁)
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")

                .Col = COL_JDNLINNO     '受注行番号
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")

                .Col = COL_UDNDT        '売上日(スラッシュなし)
                .Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")

                .Col = COL_KESDT        '回収予定日(スラッシュなし）
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")

                .Col = COL_TOKCD        '得意先ｺｰﾄﾞ
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")

                .Col = COL_TOKSEICD     '請求先ｺｰﾄﾞ
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")

                .Col = COL_TANCD        '担当者ｺｰﾄﾞ
                .Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

                .Col = COL_JDNDT        '受注日
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")

                .Col = COL_TUKKB        '通貨区分
                .Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")

                .Col = COL_INVNO        'ｲﾝﾎﾞｲｽ番号
                .Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")

                .Col = COL_FURIKN       '海外売上金額
                .Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")

                .Col = COL_FRNKB        '海外取引区分
                .Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")

                .Col = COL_UDNDATNO     '売上DATNO
                .Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")

                .Col = COL_UDNLINNO     '売上行番号
                .Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")

                .Col = COL_MAEUKKB      '前受区分
                .Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")

                .Col = COL_JDNDATNO     '受注DATNO
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")


                .Col = COL_KESIKN_MAE   '消込金額前
                .Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))

                
                If SSSVal(CF_Ora_GetDyn(Usr_Ody, "komikn", "")) - SSSVal(CF_Ora_GetDyn(Usr_Ody, "kesikn", "")) < 0 Then
                    .Col = COL_HENPI
                    .Text = "1"
                End If
                
                
                '売上トランの排他情報取得
                ReDim Preserve ARY_UDNTRA_HAITA(intMaxRow)
                ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
                ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
                ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNOPEID", ""))
                ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNCLTID", ""))
                ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTDT", ""))
                ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTTM", ""))
                ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUOPEID", ""))
                ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUCLTID", ""))
                ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTDT", ""))
                ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTTM", ""))

                '受注トランの排他情報取得
                ReDim Preserve ARY_JDNTRA_HAITA(intMaxRow)
                ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNDATNO", ""))
                ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", ""))
                ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", ""))
                ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNOPEID", ""))
                ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNCLTID", ""))
                ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTDT", ""))
                ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTTM", ""))
                ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUOPEID", ""))
                ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUCLTID", ""))
                ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTDT", ""))
                ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTTM", ""))
                
                
                '売上トラン入金レコードの排他情報取得
                Call getUdntraNyukn(CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")))

            End If

            Usr_Ody.Obj_Ody.MoveNext
        Loop

    End With

    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ

    '消込対象がなければメッセージを表示
    If intMaxRow = 0 Then
        Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
        txt_kesidt.SetFocus

    '対象がある時
    Else

        '入金消込トランの排他情報取得
        Call Get_NKSTRA_HAITA_INF

        '表示行数が16行以上のとき、ｽﾌﾟﾚｯﾄﾞ行数を設定
        If intMaxRow > 16 Then
            spd_body.MaxRows = intMaxRow
        Else
            spd_body.MaxRows = 16
        End If

        showHead    'ﾍｯﾀﾞ部の表示
        
        'spd_body.SetFocus
        blnUsableButton = True  '●ﾎﾞﾀﾝ使用の許可
        mnu_zenkesi.Enabled = blnUsableButton
        mnu_zenkaijo.Enabled = blnUsableButton
        '条件パネルのロック
        pnl_condition1.Enabled = False
        pnl_condition2.Enabled = False


'*** 2009/09/16 ADD START FKS)NAKATA
        '返品金額の考慮
        getHenpinKingaku
'*** 2009/09/16 ADD E.N.D FKS)NAKATA


    End If
' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
STEP10_ShowBody:
' === 20130708 === INSERT E
    


    spd_body.ReDraw = True

    
    'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
    blnUsableSpread = True

    'マウスカーソルを標準に戻す
    Me.MousePointer = vbNormal
End Sub

'ヘッダ部(消込情報)の表示
Public Sub showHead()

    Dim intZankn    As Currency     '消込日月度までの消込残額計
    Dim intKesikn   As Currency     '経理締日以降の消込額
    Dim intTesuryo  As Currency     '消込日月度の手数料額を格納
    Dim intSyohi    As Currency     '消込日月度の消費税額を格納

    Dim tmp As Currency
    Dim i       As Integer

    
    intZankn = 0
    intKesikn = 0
    intTesuryo = 0
    intSyohi = 0


    '排他情報と消込金額情報を取得
    Call getHaitaAndKnSum(DB_TOKMTA.TOKSEICD _
                        , Get_Acedt(gstrKesidt) _
                        , DB_TOKMTA.SHAKB)


    '消込日月度までの消込残額計
    For i = 0 To 9
        intZankn = intZankn + ARY_NKSSMB_KS(i).KSKZANKN
    Next i

    '経理締日以降の消込額
    For i = 0 To 9
        intKesikn = intKesikn + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN
    Next i

    '消込日月度の手数料・消費税額を格納
    i = SSSVal(TesuryoID)
    intTesuryo = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
    i = SSSVal(SyohiID)
    intSyohi = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))


    '売上合計金額の表示
    txt_urigoukei.Text = Format(intUrigoukei, "###,###,##0")

    '入金額・手数料額・消費税額の表示
    tmp = intZankn + intKesikn
    If tmp - (intTesuryo + intSyohi) > 0 Then
        txt_nyukin.Text = Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
        txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
        txt_syohi.Text = Format(intSyohi, "#,###,##0")
    '残がプラスのとき
    ElseIf tmp > 0 Then
        If intTesuryo > 0 Then
            If intSyohi > 0 Then
                '残額がプラスで、手数料も、消費税差額もプラスの時
                If tmp - intTesuryo > 0 Then
                    txt_nyukin.Text = Format(0, "#,###,##0")
                    txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = Format(tmp - intTesuryo, "#,###,##0")
                Else
                    txt_nyukin.Text = Format(0, "#,###,##0")
                    txt_tesuryo.Text = Format(tmp, "#,###,##0")
                    txt_syohi.Text = Format(0, "#,###,##0")
                End If

            ElseIf intSyohi <= 0 Then
                '残額がプラスで、手数料がプラス、消費税差額がマイナスの時
                txt_nyukin.Text = Format(0, "#,###,##0")
                txt_tesuryo.Text = Format(tmp - intSyohi, "#,###,##0")
                txt_syohi.Text = Format(intSyohi, "#,###,##0")
            End If

        ElseIf intTesuryo <= 0 Then
            If intSyohi > 0 Then
                '残額がプラスで、手数量がマイナス、消費税差額がプラスの時
                txt_nyukin.Text = Format(0, "#,###,##0")
                txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                txt_syohi.Text = Format(tmp - intTesuryo, "#,###,##0")
            ElseIf intSyohi <= 0 Then
                '残額がプラスで、手数料も、消費税差額もマイナスの時
                'tmp - (intTesuryo + intSyohi) は絶対に正なので、ここに処理は不要
            End If
        End If

    '残が負の時
    ElseIf tmp <= 0 Then
        If intTesuryo > 0 Then
            If intSyohi > 0 Then
                '残額がマイナスで、手数料も、消費税差額もプラスの時
                txt_nyukin.Text = Format(tmp, "#,###,##0")
                txt_tesuryo.Text = Format(0, "#,###,##0")
                txt_syohi.Text = Format(0, "#,###,##0")
            ElseIf intSyohi <= 0 Then
                '残額がマイナスで、手数料がプラス、消費税差額がマイナスの時
                If tmp + intTesuryo + intSyohi > 0 Then
                    txt_nyukin.Text = Format(0, "#,###,##0")
                    txt_tesuryo.Text = Format(tmp - intSyohi, "#,###,##0")
                    txt_syohi.Text = Format(intSyohi, "#,###,##0")
                Else
                    txt_nyukin.Text = Format(tmp - intSyohi, "#,###,##0")
                    txt_tesuryo.Text = Format(0, "#,###,##0")
                    txt_syohi.Text = Format(intSyohi, "#,###,##0")
                End If
            End If
        ElseIf intTesuryo <= 0 Then
            If intSyohi > 0 Then
                '残額がマイナスで、手数量がマイナス、消費税差額がプラスの時
                If tmp + intTesuryo + intSyohi > 0 Then
                    txt_nyukin.Text = Format(0, "#,###,##0")
                    txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = Format(tmp - intTesuryo, "#,###,##0")
                Else
                    txt_nyukin.Text = Format(tmp - intTesuryo, "#,###,##0")
                    txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                    txt_syohi.Text = Format(0, "#,###,##0")
                End If
            ElseIf intSyohi <= 0 Then
                '残額がマイナスで、手数料も、消費税差額もマイナスの時
                txt_nyukin.Text = Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
                txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                txt_syohi.Text = Format(intSyohi, "#,###,##0")
            End If
        End If
    End If

    '入金合計額の表示
    tmp = SSSVal(txt_nyukin.Text) + SSSVal(txt_tesuryo.Text) + SSSVal(txt_syohi.Text)
    txt_nyugoukei.Text = Format(tmp, "###,###,##0")

    '入金残額の表示
    txt_kesizan.Text = Format(intZankn + intKesikn, "###,###,##0")

End Sub

'明細部合計金額の取得
Private Function getBodyKesikei(strColName As String) As Currency
    Dim i As Integer
    Dim intKesikei As Currency
    Dim tmp As Variant

    intKesikei = 0
    blnUsableSpread = False
    With spd_body
        For i = 1 To intMaxRow
            .GetText strColName, i, tmp
            intKesikei = intKesikei + SSSVal(tmp)
        Next i
    End With
    blnUsableSpread = True

    getBodyKesikei = intKesikei
End Function


'排他情報と消込金額情報を取得、グローバル変数に格納
Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String _
                           , ByVal pin_strSMADT As String _
                           , ByVal pin_strSHAKB As String)
    Dim strSql  As Variant
    Dim Usr_Ody As U_Ody
    Dim i       As Integer

    '消込日月度の消込状態を取得
    
    strSql = ""
    strSql = strSql & " SELECT * "
    strSql = strSql & "   FROM NKSSMB "
    strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
    strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '入金消込サマリーの排他情報取得
    ReDim ARY_NKSSMB_HAITA(1)
    ARY_NKSSMB_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
    ARY_NKSSMB_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
    ARY_NKSSMB_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
    ARY_NKSSMB_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
    ARY_NKSSMB_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
    ARY_NKSSMB_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))

    '入金消込サマリの情報を構造体配列へ取得
    ReDim ARY_NKSSMB_KS(9)
    For i = 0 To 9
        With ARY_NKSSMB_KS(i)
            .UPDID = Format(i, "00")

            If i <> 8 Then
                If CF_Ora_EOF(Usr_Ody) = False Then
                    .SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & .UPDID, ""))
                    .KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & .UPDID, ""))
                    .KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & .UPDID, ""))
                End If
            Else
                '09：本入金 は、相手にしない
                .SSANYUKN = 0
                .KSKNYKKN = 0
                .KSKZANKN = 0
            End If

            '取引区分の設定
            Select Case i
                Case 0: .DATKB = "01"       '01：現金
                Case 1: .DATKB = "02"       '02：振込
                Case 2: .DATKB = "03"       '03：手形
                Case 3: .DATKB = "04"       '04：相殺
                Case 4: .DATKB = "05"       '05：値引
                Case 5: .DATKB = "06"       '06：手数
                Case 6: .DATKB = "07"       '07：他
                Case 7: .DATKB = "08"       '08：振込仮
                Case 8: .DATKB = "09"       '09：本入金
                Case 9: .DATKB = "99"       '99：消費
            End Select


            '消込順序の設定（-1 は消込なし）
            ' ①相殺→②消費税→③手数料→④現金→⑤振込→⑥手形→⑦振込仮→⑧値引き→⑨他
            Select Case i
                Case 0: .SEQ = 4            '取引区分＝01：現金
                Case 1: .SEQ = 5            '取引区分＝02：振込
                Case 2: .SEQ = 6            '取引区分＝03：手形
                Case 3: .SEQ = 1            '取引区分＝04：相殺
                Case 4: .SEQ = 8            '取引区分＝05：値引
                Case 5: .SEQ = 3            '取引区分＝06：手数
                Case 6: .SEQ = 9            '取引区分＝07：他
                Case 7: .SEQ = 7            '取引区分＝08：振込仮
                Case 8: .SEQ = -1           '取引区分＝09：本入金
                Case 9: .SEQ = 2            '取引区分＝99：消費
            End Select

        End With
    Next i

    Call CF_Ora_CloseDyn(Usr_Ody)


    For i = 0 To 9
        '残金を計算する
        With ARY_NKSSMB_KS(i)
            .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
        End With
    Next i
End Sub


'全解除メニュークリック時
Private Sub mnu_zenkaijo_Click()
    cmd_zenkaijo_Click
End Sub

'全選択メニュークリック時
Private Sub mnu_zenkesi_Click()
    cmd_zenkesi_Click
End Sub

Private Sub opt_sort_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)


    'ファンクションキー押下時
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        'ファンクションキー共通処理
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
End Sub

'ヘッダパネルマウスムーブ時
Private Sub pnl_head_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'ヒントの表示を初期化する
    img_light.Picture = img_bklight(0).Picture
    txt_message.Text = ""
End Sub

'アイコン[終了]クリック時
Private Sub img_exit_Click()
    Unload Me
End Sub
'アイコン[終了]マウスダウン時
Private Sub img_exit_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(1).Picture
End Sub
'アイコン[終了]マウスムーブ時
Private Sub img_exit_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "メニューに戻ります。"
End Sub
'アイコン[終了]マウスアップ時
Private Sub img_exit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(0).Picture
End Sub

'アイコン[登録]クリック時
Private Sub img_resist_Click()
    mnu_regist_Click
End Sub
'アイコン[登録]マウスダウン時
Private Sub img_resist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_resist.Picture = img_bkresist(1).Picture
End Sub
'アイコン[登録]マウスムーブ時
Private Sub img_resist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "登録します。"
End Sub
'アイコン[登録]マウスアップ時
Private Sub img_resist_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_resist.Picture = img_bkresist(0).Picture
End Sub

'アイコン[検索]クリック時
Private Sub img_showwnd_Click()
    mnu_showwnd_Click
End Sub
'アイコン[検索]マウスダウン時
Private Sub img_showwnd_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(1).Picture
End Sub
'アイコン[検索]マウスムーブ時
Private Sub img_showwnd_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "ウィンドウを表示します。"
End Sub
'アイコン[検索]マウスアップ時
Private Sub img_showwnd_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(0).Picture
End Sub

'アイコン[解除]クリック時
Private Sub img_unlock_Click()
    
    If blnUsableButton = True Then
        blnUsableButton = False
        pnl_condition1.Enabled = True
        pnl_condition2.Enabled = True
        initHead
        initBody
        txt_kesidt.SetFocus
        intInputMode = 1
' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
        Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -
   End If

End Sub
'アイコン[解除]マウスダウン時
Private Sub img_unlock_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_unlock.Picture = img_bkunlock(1).Picture
End Sub
'アイコン[解除]マウスムーブ時
Private Sub img_unlock_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "画面をクリアしてコードの入力を待ちます。"
End Sub
'アイコン[解除]マウスアップ時
Private Sub img_unlock_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_unlock.Picture = img_bkunlock(0).Picture
End Sub

'メニュー[処理]－[終了]選択時
Private Sub mnu_exit_Click()
    Unload Me
End Sub

'メニュー[処理]－[登録]選択時
Private Sub mnu_regist_Click()

Dim intRtn  As Integer


    'ヘッダ部の入力チェック
    If chkCondition = False Then Exit Sub
    '明細部の入力チェック
    If blnUsableButton = False Then
        showMsg "0", "_UPDATE", "2"     '●明細部未入力のMSG
        Exit Sub
    End If


    '返品処理のなき分かれチェック
    If chkAkaKro = False Then
        Exit Sub
    End If

'**** 2009/09/16 DEL START FKS)NAKATA
'分納対応のためチェックを外す
''    '売上金額と充当金額のチェック
''    If chkUrikn = False Then
''        Exit Sub
''    End If
''
''
''    '伝票単位での充当チェック
''    If chkJdntrkb = False Then
''        Exit Sub
''    End If
'**** 2009/09/16 DEL E.N.D FKS)NAKATA


    '入金が登録されているかのチェック
    If chkNyukn = False Then
        Exit Sub
    End If


    '手形が入っている場合は振込期日の入力チェック
    If chkFurikomiDT = False Then
        Exit Sub
    End If



    '●登録確認のMSG
    If showMsg("0", "_UPDATE", 0) = vbYes Then
        '★権限の判断
        If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
            showMsg "2", "UPDAUTH", "0"
            Exit Sub
        End If

        '排他チェック
        If Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
            MsgBox "【" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & _
                   Trim(SSS_PrgNm) & "を入力する事はできません。", vbExclamation Or vbOKOnly, SSS_PrgNm
'            Call HD_CLEAR
'            Call P_vaData_Init
            Exit Sub
        Else
            Call SSSEXC_EXCTBZ_OPEN
        End If


        Me.MousePointer = vbHourglass
        
        '更新処理
        Select Case sRegistration(spd_body)
            Case 9
                '●更新処理失敗時
                MsgBox "更新に失敗しました。", vbCritical, "更新エラー"
            Case 1
            
            Case 0
                '★ログの書き出し
                Call SSSWIN_LOGWRT("登録完了:" & Left(DB_TOKMTA.TOKSEICD, 5) & ":" & DB_TOKMTA.TOKRN)
                
                mnu_initdsp_Click   '画面表示の初期化

        End Select
        
        Me.MousePointer = vbDefault


    End If

End Sub

'メニュー[編集]－[画面初期化]選択時
Private Sub mnu_initdsp_Click()
    
    intInputMode = 9
    pnl_condition1.Enabled = True
    pnl_condition2.Enabled = True
    '画面の初期化
    initCondition
    initHead
    initBody
    '消込日にフォーカスを移動
    txt_kesidt.SetFocus
    txt_kesidt.BackColor = vbYellow
    blnINIT_FLG = True
' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

End Sub


'メニュー[操作]－[候補の一覧]
Private Sub mnu_showwnd_Click()
    '消込日にフォーカスがあるとき
    If Me.ActiveControl.Name = txt_kesidt.Name Then
        cmd_kesidt_Click

    '請求先ｺｰﾄﾞにフォーカスがあるとき
    ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then
        cmd_tokseicd_Click


    '回収予定日にフォーカスがあるとき
    ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then
        Call cmd_kaidt_From_Click

    '回収予定日にフォーカスがあるとき
    ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then
        Call cmd_kaidt_To_Click


    '振込期日にフォーカスがあるとき
    ElseIf Me.ActiveControl.Name = txt_fridt.Name Then
        cmd_fridt_Click
    End If
End Sub



Private Sub spd_body_Change(ByVal Col As Long, ByVal Row As Long)
Dim spd_fridt   As String
Dim spd_fridt_val  As Variant
Dim ret As Boolean
Dim lw_col  As Long
Dim lw_row  As Long

    If Col = 14 Then '期日振込日のチェック

        lw_col = Col
        lw_row = Row
        '経理締日以前の日付の時はエラー
        ret = spd_body.GetText(Col, Row, spd_fridt_val)
        If ret = True Then
            spd_fridt = Format$(spd_fridt_val, "yyyy/mm/dd")
            If Trim$(spd_fridt) = "" Then
                blnUsableButton = True
            End If
            If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
                Call showMsg("1", "URKET73_010", 0)     '●経理締め済みのMSG
                spd_body.Col = lw_col
                spd_body.Row = lw_row
                spd_body.ForeColor = vbRed
                spd_body.Action = 0
                blnUsableButton = False
            Else
                spd_body.Col = Col
                spd_body.Row = Row
                spd_body.ForeColor = vbBlack
                spd_body.Row = Row + 1
                spd_body.Action = 0
                blnUsableButton = True
            End If
        End If
     End If
End Sub

Private Sub spd_body_KeyDown(KeyCode As Integer, Shift As Integer)


    'ファンクションキー押下時
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        'ファンクションキー共通処理
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
End Sub

Private Sub txt_fridt_Validate(Cancel As Boolean)

    '入力チェック
    chkFridt

    '背景色を白に戻す
    txt_fridt.BackColor = vbWhite

End Sub


'請求先ｺｰﾄﾞ項目を変更した時
Private Sub txt_tokseicd_Change()
    Dim p As Integer

    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub

    blnUsableEvent = False
    p = txt_tokseicd.SelStart

    '全角を削除する
    txt_tokseicd.Text = delZenkaku(txt_tokseicd.Text)
    '入力値が5byteで無い時は空白埋め
    txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))

    txt_tokseicd.SelStart = p
    blnUsableEvent = True

    'カーソルが右端に移動した時は、次の項目へ移動
    If txt_tokseicd.SelStart = 5 Then
        intChkKb = 1                                '★請求先ｺｰﾄﾞの入力チェック

        '入力チェック
        If chkTokseicd = True Then
            '次項目
            txt_kaidt_From.SetFocus
        End If

    End If
    txt_tokseicd.SelLength = 1

End Sub

'請求先ｺｰﾄﾞ項目にフォーカスが移った時
Private Sub txt_tokseicd_GotFocus()
    '先頭位置を選択状態にする
    txt_tokseicd.SelStart = 0
    txt_tokseicd.SelLength = 1
    '背景色を黄色にする
    txt_tokseicd.BackColor = vbYellow
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True
End Sub


'請求先ｺｰﾄﾞ項目でキーを押した時
Private Sub txt_tokseicd_KeyDown(KeyCode As Integer, Shift As Integer)

    'キー入力制御
    Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
        Case 0
            '何もしない
        Case 1
            '入力チェック
            If chkTokseicd = True Then
                '次項目
                txt_kaidt_From.SetFocus
            End If
        Case 2
            '入力チェック
            If chkTokseicd = True Then
                '前項目
                txt_kesidt.SetFocus
            End If
    End Select
    
    KeyCode = 0
    
End Sub


'請求先ｺｰﾄﾞ項目でキーを押した時
Private Sub txt_tokseicd_KeyPress(KeyAscii As Integer)
    'アルファベット小文字を大文字に変換する
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

'請求先ｺｰﾄﾞ項目からフォーカスが移った時
Private Sub txt_tokseicd_LostFocus()
    
    '背景色を白に戻す
    txt_tokseicd.BackColor = vbWhite

End Sub


'消込済みﾃﾞｰﾀ表示項目を変更した時
Private Sub txt_kesikb_Change()
    If txt_kesikb.Text <> 9 Then
        txt_kesikb.Text = 1
    End If
    txt_kesikb.SelStart = 0
    txt_kesikb.SelLength = 1

    If txt_kesikb.Text = 1 Then
        cmd_kaidt_From.Caption = " 売上日(開始)"
    Else
        cmd_kaidt_From.Caption = " *売上日(開始)"
    End If

End Sub

'消込済みﾃﾞｰﾀ表示項目にフォーカスが移った時
Private Sub txt_kesikb_GotFocus()
    '選択状態にする
    txt_kesikb.SelStart = 0
    txt_kesikb.SelLength = 1
    '背景色を黄色にする
    txt_kesikb.BackColor = vbYellow
    '検索処理を実行不可とする
    mnu_showwnd.Enabled = False
End Sub

'消込済みﾃﾞｰﾀ表示項目でキーを押した時
Private Sub txt_kesikb_KeyDown(KeyCode As Integer, Shift As Integer)

    'ファンクションキー押下時
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        'ファンクションキー共通処理
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
    '上矢印 or 左矢印押下時
    If KeyCode = vbKeyUp Or KeyCode = vbKeyLeft Then
        txt_kaidt_To.SetFocus

    'Enter or 下矢印 or 右矢印押下時
    ElseIf KeyCode = vbKeyReturn Or KeyCode = vbKeyDown Or KeyCode = vbKeyRight Then
        '請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
        'それ以外は消込対象を検索
        If blnFriEnabled = True Then
            txt_fridt.SetFocus
        Else
            spd_body.SetFocus
        End If

    'TAB押
    ElseIf KeyCode = vbKeyF16 Then
        '請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
        'それ以外は消込対象を検索
        If blnFriEnabled = True Then
            txt_fridt.SetFocus
        Else
            spd_body.SetFocus
        End If

    

    'TAB押
    ElseIf KeyCode = vbKeyF15 Then
        txt_kaidt_To.SetFocus

    
    End If

    KeyCode = 0
End Sub

'消込済みﾃﾞｰﾀ表示項目でキーを押した時
Private Sub txt_kesikb_KeyPress(KeyAscii As Integer)
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

'消込済みﾃﾞｰﾀ表示項目からフォーカスが移った時
Private Sub txt_kesikb_LostFocus()
    '背景色を白に戻す
    txt_kesikb.BackColor = vbWhite
End Sub

'=======================================================明細部(スプレッド)=======================================================

'フォーカス取得時
Private Sub spd_body_GotFocus()

    If intInputMode <> 1 Then
        Exit Sub
    End If

    'ﾎﾞﾀﾝが使用可能(明細ﾃﾞｰﾀあり)の時は実行しない
    If blnUsableButton = True Then Exit Sub

    'ヘッダが入力されていたらデータを検索・表示する
    If chkCondition = True Then
    
        intInputMode = 2
    
        showBody    '★ﾃﾞｰﾀ表示
        
        '返品を消込し、ロック
        '前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
        'lockHenpin
        
    End If
End Sub

'明細ﾎﾞﾀﾝｸﾘｯｸ時
Private Sub spd_body_ButtonClicked(ByVal Col As Long, ByVal Row As Long, ByVal ButtonDown As Integer)

    Dim intKesizan  As Currency  'ヘッダ部消込残額
    Dim intKomikn   As Currency  '税込売上額
    Dim intKesikn   As Currency  '消込額
    Dim intBfKesikn As Currency  '消込額(締日前)
    Dim tmp As Variant

    Dim LS_HYFRIDT As Variant
    Dim sumHenpin       As Currency
    Dim intJDNNOKesikn  As Currency
    Dim intHenkn        As Currency
    Dim strHyjdnno      As String
    Dim str_theHYJDNNO  As String
    Dim intchk          As Integer
    Dim idxRowJDNNO     As Long

'*** 2009/09/03 ADD START FKS)NAKATA V1.03
    Dim strBfHYFRIDT  As String
'*** 2009/09/03 ADD E.N.D FKS)NAKATA



    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableSpread = False Then
        Exit Sub
    End If

    
    On Error Resume Next

    With spd_body
        'ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ時、明細の金額、ヘッダの残金額に応じてチェックのON、OFFを行う
        If Col = 1 Then
            .Col = Col
            .Row = Row

            '表示行以上の行をクリックした時はチェックはつけない
            If Row > intMaxRow Then
                'ﾁｪｯｸ解除しない
                blnUsableSpread = False
                .Value = 0
                blnUsableSpread = True
                Exit Sub
            End If

            intKesizan = SSSVal(txt_kesizan.Text)

            '税込売上額を取得
            Call .GetText(COL_KOMIKN, .Row, tmp)
            intKomikn = SSSVal(tmp)
            
            '明細部消込額
            Call .GetText(COL_KESIKN, .Row, tmp)
            intKesikn = SSSVal(tmp)

            'ﾁｪｯｸが付いていて、解除した時
            If ButtonDown = 0 Then

               '解除額がプラスであれば、無条件にヘッダ部に加算
                If intKesikn - intBfKesikn > 0 Then
                    txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    .SetText COL_KESIKN, .Row, intBfKesikn

                
                    If DB_TOKMTA.SHAKB Like "[256]" Then
                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        If Trim$(LS_HYFRIDT) <> "" Then
                            .SetText COL_HYFRIDT, .Row, ""
                        End If
                    End If


                ElseIf intKesizan >= intBfKesikn - intKesikn Then
                    txt_kesizan.Text = Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
                    .SetText COL_KESIKN, .Row, intBfKesikn


                    If DB_TOKMTA.SHAKB Like "[256]" Then
                        .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                        If Trim$(LS_HYFRIDT) <> "" Then
                            .SetText COL_HYFRIDT, .Row, ""
                        End If
                    End If

                Else
                    'ﾁｪｯｸ解除しない
                    blnUsableSpread = False
                    .Value = 1
                    blnUsableSpread = True
                End If


            'ﾁｪｯｸが付いていなくて、チェックを入れた時
            ElseIf ButtonDown = 1 Then

                    '消込額がマイナスであれば､無条件にヘッダ部に加算
                    If intKomikn - intKesikn < 0 Then
                        txt_kesizan.Text = Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        .SetText COL_KESIKN, .Row, intKomikn
    
                        If DB_TOKMTA.SHAKB Like "[256]" Then
                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                    
                            If Trim$(LS_HYFRIDT) = "" Then
                            '*** 2009/09/03 CHG START FKS)NAKATA V1.03
                                '.SetText COL_HYFRIDT, .Row, txt_fridt.Text
                                Call .GetText(COL_BFHYFRIDT, .Row, tmp)
                                strBfHYFRIDT = tmp
                                .SetText COL_HYFRIDT, .Row, strBfHYFRIDT
                            '*** 2009/09/03 CHG START FKS)NAKATA
                            End If
                        End If
                    'ヘッダ消込残が負の時はチェックをつけない
                    ElseIf intKesizan <= 0 Then
    
                        
                        blnUsableSpread = False
                        .Value = 0
                        blnUsableSpread = True
    
                    ElseIf intKesizan >= intKomikn - intKesikn Then
                        txt_kesizan.Text = Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
                        .SetText COL_KESIKN, .Row, intKomikn
       
                        If DB_TOKMTA.SHAKB Like "[256]" Then
                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
                            If Trim$(LS_HYFRIDT) = "" Then
                            '*** 2009/09/03 CHG START FKS)NAKATA V1.03
                                '.SetText COL_HYFRIDT, .Row, txt_fridt.Text
                                Call .GetText(COL_BFHYFRIDT, .Row, tmp)
                                strBfHYFRIDT = tmp
                                .SetText COL_HYFRIDT, .Row, strBfHYFRIDT
                            '*** 2009/09/03 CHG START FKS)NAKATA
                            End If
                        End If
                    Else
                        
                        '一部充当の禁止 (税込売上金額 <> 充当金額の場合)
                        Call showMsg("1", "URKET73_041", 0) '一部充当はできません。
                        blnUsableSpread = False
                        .Value = 0
                        blnUsableSpread = True
    
''一部充当を許す場合は、以下のコメントを外す
''DEL START (↓)
'                        txt_kesizan.Text = Format(0, "###,###,##0")
''                        .SetText COL_KESIKN, .Row, intKesikn + intKesizan
''
''                        If DB_TOKMTA.SHAKB Like "[256]" Then
''                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
''                            If Trim$(LS_HYFRIDT) = "" Then
''                                .SetText COL_HYFRIDT, .Row, txt_fridt.Text
''                            End If
''                        End If
''DEL START (↑)

                    End If
            End If
        End If
    End With
End Sub

'================================================================
'2009/06/12 DEL START FKS)NAKATA

'手数用・消費税額の登録は、本処理では行わない。
'本処理を使用する場合は、コメントアウトを外し
'「pnl_tesuryo」「pnl_syohizei」をフォームから削除してください。
'パネルの下にボタンを隠しています。


''手数料ﾎﾞﾀﾝ実行時
'Private Sub cmd_tesuryo_Click()
'
'    Dim tmp             As Variant
'    Dim intchk          As Long
'    Dim idxRow          As Long
'    Dim idxRowJDNNO     As Long
'
'    Dim kesizan         As Currency 'ヘッダ部消込残額
'    Dim kesikn          As Currency '明細行の入金済額
'
'
'    'ﾌﾗｸﾞがたっていなければ実行しない
'    If blnUsableButton = False Then Exit Sub
'
'    '●差額入金画面の表示
''    FR_SSSSUB.Show (vbModal)
'
'
'    'ヘッダ情報の再表示
'    showHead

'    'ヘッダ部消込残額の退避
'    kesizan = txt_kesizan.Text
'
'    With spd_body
'        For idxRow = 1 To intMaxRow
'            'チェックが入っているかを確認
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'            'チェックが入っている場合
'            If intchk = 1 Then
'                '消込額の取得
'                Call .GetText(COL_KESIKN, idxRow, tmp)
'                kesikn = kesikn + CCur(tmp)
'            End If
'
'       Next idxRow
'    End With
'
'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
'
'End Sub
'
''消費税額ﾎﾞﾀﾝ実行時
'Private Sub cmd_syohi_Click()
'
'
'    Dim tmp             As Variant
'    Dim intchk          As Long
'    Dim idxRow          As Long
'    Dim idxRowJDNNO     As Long
'
'    Dim kesizan         As Currency 'ヘッダ部消込残額
'    Dim kesikn          As Currency '明細行の入金済額
'
'
'    'ﾌﾗｸﾞがたっていなければ実行しない
'    If blnUsableButton = False Then Exit Sub
'
'    '●差額入金画面の表示
'    FR_SSSSUB.Show (vbModal)
'
'
'    'ヘッダ情報の再表示
'    showHead
'
'    'ヘッダ部消込残額の退避
'    kesizan = txt_kesizan.Text
'
'    With spd_body
'        For idxRow = 1 To intMaxRow
'            'チェックが入っているかを確認
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'            'チェックが入っている場合
'            If intchk = 1 Then
'                '消込額の取得
'                Call .GetText(COL_KESIKN, idxRow, tmp)
'                kesikn = kesikn + CCur(tmp)
'            End If
'
'       Next idxRow
'    End With
'
'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
'
'
'End Sub
'2009/06/12 DEL E.N.D FKS)NAKATA
'================================================================


'全消込ﾎﾞﾀﾝ実行時
Private Sub cmd_zenkesi_Click()
    Dim i As Integer
    Dim varKesikn As Variant

    'ﾌﾗｸﾞがたっていなければ実行しない
    If blnUsableButton = False Then Exit Sub
    

'全消込ボタンを押下時は、初期表示時と同じ消込対象にチェックを入れる。
'前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
'    lockHenpin


    '全行に対し、ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸ
    For i = 1 To intMaxRow
        With spd_body
            .Col = COL_CHK
            .Row = i
            If .Value = 0 Then
                '全消込時にチェックが入らない不具合を修正 2007/02/28 Saito
                spd_body_ButtonClicked COL_CHK, i, 1
                .GetText COL_KESIKN, i, varKesikn
                If SSSVal(varKesikn) <> 0 Then
                    blnUsableSpread = False
                    .Value = 1
                    blnUsableSpread = True
                End If
            End If
        End With
    Next i

End Sub

'全解除ﾎﾞﾀﾝ実行時
Private Sub cmd_zenkaijo_Click()
    Dim i As Integer
    Dim varKesikn As Variant
    Dim varBfKesikn As Variant

    'ﾌﾗｸﾞがたっていなければ実行しない
    If blnUsableButton = False Then Exit Sub

    '全行に対し、ﾁｪｯｸﾎﾞｯｸｽの解除
    For i = 1 To intMaxRow
        With spd_body
            .Col = COL_CHK
            .Row = i
            If .Value = 1 Then
                '解除時にチェックが外れない不具合を修正 2007/02/28 Saito
                spd_body_ButtonClicked COL_CHK, i, 0
            

                .GetText COL_KESIKN, i, varKesikn
                .GetText COL_BFKESIKN, i, varBfKesikn

                If SSSVal(varKesikn) = 0 Then

                    blnUsableSpread = False
                    .Value = 0
                    blnUsableSpread = True
                End If

            End If
        End With
    Next i
End Sub

'再表示ﾎﾞﾀﾝ実行時
Private Sub cmd_saihyoji_Click()
    'ﾌﾗｸﾞがたっていなければ実行しない
    If blnUsableButton = False Then Exit Sub


    If ChkInputChange() = True Then
        If showMsg("1", "URKET73_040", 0) = vbNo Then
            Exit Sub
        End If
    End If

    
    'ヘッダが入力されていたらデータを検索・表示する
    If chkCondition = True Then

        intInputMode = 2

        showBody    '★ﾃﾞｰﾀ表示
               
        '前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
        '返品を消込し、ロック
        'lockHenpin

    End If

End Sub

'消込日ﾎﾞﾀﾝｸﾘｯｸ時
Private Sub cmd_kesidt_Click()
    If txt_kesidt.Enabled = False Then Exit Sub

    If Trim(txt_kesidt.Text) <> "" Then
        Set_date = txt_kesidt.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    'カレンダーウィンドウを表示
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kesidt.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kesidt.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '★日付の入力チェック
        txt_tokseicd.SetFocus
    End If
End Sub

'請求先ｺｰﾄﾞﾎﾞﾀﾝｸﾘｯｸ時
Private Sub cmd_tokseicd_Click()
    If txt_tokseicd.Enabled = False Then Exit Sub
    WLS_TOK1.Show vbModal
    Unload WLS_TOK1

    txt_tokseicd.SetFocus
    If WLSTOKSUB_RTNCODE <> "" Then
        txt_tokseicd.Text = WLSTOKSUB_RTNCODE
        intChkKb = 1
        chkTokseicd
        txt_kaidt_From.SetFocus

    End If
End Sub

'回収日ﾎﾞﾀﾝｸﾘｯｸ時
Private Sub cmd_kaidt_From_Click()
    
    If txt_kaidt_From.Enabled = False Then Exit Sub

    If Trim(txt_kaidt_From.Text) <> "" Then
        Set_date = txt_kaidt_From.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    'カレンダーウィンドウを表示
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kaidt_From.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kaidt_From.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '★日付の入力チェック
        txt_kaidt_To.SetFocus
    End If

End Sub


'回収日ﾎﾞﾀﾝｸﾘｯｸ時
Private Sub cmd_kaidt_To_Click()
    If txt_kaidt_To.Enabled = False Then Exit Sub

    If Trim(txt_kaidt_To.Text) <> "" Then
        Set_date = txt_kaidt_To.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    'カレンダーウィンドウを表示
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kaidt_To.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kaidt_To.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '★日付の入力チェック
        txt_kesikb.SetFocus
    End If
End Sub


'振込期日ﾎﾞﾀﾝｸﾘｯｸ時
Private Sub cmd_fridt_Click()
    '振込期日が入力できない時はｲﾍﾞﾝﾄは実行しない
    If blnFriEnabled = False Then Exit Sub
    If txt_fridt.Enabled = False Then Exit Sub

    If Trim(txt_fridt.Text) <> "" Then
        If IsDate(txt_fridt.Text) = True Then
            Set_date = txt_fridt.Text
        Else
            Set_date = CNV_DATE(gstrUnydt)
            txt_fridt.Text = ""
        End If
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    'カレンダーウィンドウを表示
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_fridt.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_fridt.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '★日付の入力チェック
        spd_body.SetFocus
    End If
End Sub

'**** 2009/09/19 ADD START FKS)NAKATA
'分納対応
Private Sub getHenpinKingaku()
    
    
    Dim idxRow          As Long
    Dim tmp             As Variant
    
    
    Dim i               As Long
    Dim strHenpin       As String
    Dim strJdnno        As String
    Dim strJdnlinno     As String
    Dim strOkrjono      As String
    Dim curKomikn       As Currency
    Dim maxSeq           As Integer
        
    On Error Resume Next

    With spd_body
    
        For idxRow = 1 To intMaxRow
        
            strHenpin = ""
            
            '返品フラグの取得
            Call .GetText(COL_HENPI, idxRow, tmp)
            strHenpin = CStr(tmp)
            
            
            '返品であれば、金額調整を行う
            If strHenpin = "1" Then

                '受注番号の取得
                Call .GetText(COL_JDNNO, idxRow, tmp)
                strJdnno = CStr(tmp)
                
                '受注行番号の取得
                Call .GetText(COL_JDNLINNO, idxRow, tmp)
                strJdnlinno = CStr(tmp)

                '税込売上金額の取得
                Call .GetText(COL_KOMIKN, idxRow, tmp)
                curKomikn = CCur(tmp)
                
                '送り状№の取得
                strOkrjono = getOKRJONO(strJdnno, strJdnlinno)


                For i = 0 To UBound(ARY_NYUKN_KS)
                
                    '受注番号
                    If ARY_NYUKN_KS(i).OKRJONO = strOkrjono Then
                        maxSeq = i
                    End If
                    
                Next i

                '返品の金額を残金へ加算する
                ARY_NYUKN_KS(maxSeq).ZANKN = ARY_NYUKN_KS(maxSeq).ZANKN + curKomikn * (-1)
            
            End If
    
        Next idxRow
        
    End With
    
End Sub
'**** 2009/09/19 ADD E.N.D FKS)NAKATA


'返品消込
Private Sub lockHenpin()
    Dim intKesizan      As Currency  'ヘッダ部消込残額
    Dim intKomikn       As Currency  '税込売上額
    Dim intKesikn       As Currency  '消込額
    Dim intBfKesikn     As Currency  '消込額(締日前)
    Dim tmp             As Variant
    Dim LS_HYFRIDT      As Variant
    Dim idxRow          As Long
    Dim idxRowJDNNO     As Long
    Dim strFRIDT        As String
    Dim strHyjdnno      As String
    Dim str_theHYJDNNO  As String
    Dim intchk          As Integer

    On Error Resume Next
    '振込期日を取得

    strFRIDT = txt_fridt.Text
    '消込残額を取得

    intKesizan = SSSVal(txt_kesizan.Text)
    '返品を検索

    With spd_body

        For idxRow = 1 To intMaxRow
            '税込売上額を取得

            Call .GetText(COL_KOMIKN, idxRow, tmp)
            intKomikn = SSSVal(tmp)
            '入金済額を取得

            Call .GetText(COL_KESIKN, idxRow, tmp)
            intKesikn = SSSVal(tmp)
            '締日以前消込額


            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
            intBfKesikn = SSSVal(tmp)

            
            '消込額がマイナスであれば同一受注番号で相殺
            If intKomikn - intKesikn < 0 Then
                
                '消込額を消込残額へ追加
                intKesizan = intKesizan - (intKomikn - intKesikn)
                
                '入金済額設定
                .SetText COL_KESIKN, idxRow, intKomikn
                
                'チェックボックス設定
                blnUsableSpread = False
                .Row = idxRow
                .Col = COL_CHK
                .Value = 1
                blnUsableSpread = True
                

                Call .SetText(COL_HENPI, idxRow, "1")

                
                '受注番号取得
                Call .GetText(COL_HYJDNNO, idxRow, tmp)
                strHyjdnno = CStr(tmp)
                
                '同一受注番号を検索
                For idxRowJDNNO = intMaxRow To 1 Step -1
                    .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                    str_theHYJDNNO = CStr(tmp)
                    
                    '受注番号一致すれば相殺
                    If strHyjdnno <> str_theHYJDNNO Then
                    Else
                        .GetText COL_CHK, idxRowJDNNO, tmp
                        intchk = SSSVal(tmp)
                        
                        '自分自身でない、またはチェックされていない
                        If idxRowJDNNO <> idxRow And intchk = 1 Then
                        Else
                            
                            '税込売上額を取得
                            Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
                            intKomikn = SSSVal(tmp)
                            
                            '入金済額を取得
                            Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                            intKesikn = SSSVal(tmp)
                            
                            '締日以前消込額

                            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                            intBfKesikn = SSSVal(tmp)
                            
                            '税込売上金額全額相殺
                            If intKesizan >= intKomikn - intKesikn Then
                                
                                '入金済額設定
                                .SetText COL_KESIKN, idxRowJDNNO, intKomikn
                                
                                'チェックボックス設定
                                blnUsableSpread = False
                                .Row = idxRowJDNNO
                                .Col = COL_CHK
                                .Value = 1
                                blnUsableSpread = True
                                
                                Call .SetText(COL_HENPI, idxRowJDNNO, "1")

                                '消込残額設定
                                intKesizan = intKesizan - (intKomikn - intKesikn)
                                
                                '振込期日設定
                                If DB_TOKMTA.SHAKB Like "[256]" Then
                                    .GetText COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT
                                    If Trim$(LS_HYFRIDT) = "" Then
                                        .SetText COL_HYFRIDT, idxRowJDNNO, strFRIDT
                                    End If
                                End If
                                '税込売上金額一部相殺
                                '入金済額設定

                            Else

                                .SetText COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan
                                'チェックボックス設定


                           ''消込残額がゼロの場合、チェックをつけない
                            If intKesizan > 0 Then

                           
                                blnUsableSpread = False
                                .Row = idxRowJDNNO
                                .Col = COL_CHK
                                .Value = 1
                                blnUsableSpread = True
                           

                                Call .SetText(COL_HENPI, idxRowJDNNO, "1")

                        
                            End If
                                                           
                                '消込残額ゼロ
                                intKesizan = 0
                                
                                '振込期日設定
                                If DB_TOKMTA.SHAKB Like "[256]" Then
                                    .GetText COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT
                                    If Trim$(LS_HYFRIDT) = "" Then
                                        .SetText COL_HYFRIDT, idxRowJDNNO, strFRIDT
                                        '消込残額を設定

                                    End If
                                End If
                            End If
                        End If
                    End If
                Next idxRowJDNNO
            End If
        Next idxRow
    End With

    txt_kesizan.Text = Format(intKesizan, "###,###,##0")

End Sub

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function chk_HENPIN
'   概要： 締日をまたいで返品登録、受注訂正を行った際
'          赤黒にて相殺される受注を表示しない
'   引数： strJdnNo   : 受注伝票番号
'   　　： strJdnlinNo: 受注伝票行番号
'       :  strUrikn   : 売上金額
'   戻値： チェック結果
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

Function chkHenpin(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strRECNO As String, _
                                    ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String) As Boolean


    
    Dim Usr_Ody         As U_Ody
    Dim Usr_Ody2         As U_Ody
    Dim strSql          As String
    
    On Error GoTo ERR_chkHENPIN

    chkHenpin = False
    
    strSql = " "
    strSql = " SELECT *"
    strSql = strSql & " FROM    UDNTRA"
    strSql = strSql & " WHERE   JDNNO    =  '" & Trim$(strJdnno) & "'"
    strSql = strSql & " AND     JDNLINNO =  '" & Trim$(strJdnlinno) & "'"
    strSql = strSql & " AND     DATKB =  '1'"
    strSql = strSql & " AND     AKAKROKB =  '9'"
    strSql = strSql & " AND     DKBID    =  '01'"
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    'データが存在した場合
    Do While CF_Ora_EOF(Usr_Ody) = False
                   
        '消込されていない場合、処理を行う
        If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
                 
            '返品理由に値が格納されている売上を対象とする
            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then
                
                
                '黒と赤のURIKNの差額が「0」になるのなら表示しない
                If CLng(strUrikn) = CLng(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
                    chkHenpin = False
                    GoTo END_chkHENPIN
                Else


                '返品登録を行った受注に対し単価訂正を行った場合、旧単価とその時の返品レコードを出力しないよう修正
                
                    strSql = " "
                    strSql = " SELECT COUNT(*) AS CNT"
                    strSql = strSql & " FROM    UDNTRA"
                    strSql = strSql & " WHERE   JDNNO       =  '" & Trim$(strJdnno) & "'"
                    strSql = strSql & " AND     JDNLINNO    =  '" & Trim$(strJdnlinno) & "'"
                    strSql = strSql & " AND     DATKB       =  '1'"
                    strSql = strSql & " AND     AKAKROKB    =  '1'"
                    strSql = strSql & " AND     DKBID       =  '01'"
                    strSql = strSql & " AND     RECNO       =  '" & Trim$(strRECNO) & "'"
                    strSql = strSql & " AND     URITK       !=   " & strUritk & " "
                    strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  >  '" & strWrtFstDt & strWrtFstTm & "'"

                    'DBアクセス
                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)

                    'データが存在した場合
                    Do While CF_Ora_EOF(Usr_Ody2) = False
                        
                       If CLng(CF_Ora_GetDyn(Usr_Ody2, "CNT", 0)) >= 1 Then
                            chkHenpin = False
                            Call CF_Ora_CloseDyn(Usr_Ody2)
                            GoTo END_chkHENPIN
                       Else
                            chkHenpin = True
                            Call CF_Ora_CloseDyn(Usr_Ody2)
                            GoTo END_chkHENPIN
                       End If
                       Usr_Ody2.Obj_Ody.MoveNext
                    Loop

                End If
            End If
            
        End If
        
        Usr_Ody.Obj_Ody.MoveNext
    Loop
    
    chkHenpin = True
    
END_chkHENPIN:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHENPIN:
    GoTo END_chkHENPIN

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function chkHenpinTeisei
'   概要： 締日をまたいで返品登録、受注訂正を行った際
'          赤黒にて相殺される受注を表示しない
'   引数： strJdnNo   : 受注伝票番号
'   　　： strJdnlinNo: 受注伝票行番号
'   　　： strUrikn   : 売上金額
'   　　： strUdnno   : 売上伝票番号
'   　　： strLinno   : 行番号
'   　　： strUriDt   : 売上日
'   戻値： チェック結果
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function chkHenpinTeisei(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUrikn As String, _
                                ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String) As Boolean

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    On Error GoTo ERR_chkHenpinTeisei

    chkHenpinTeisei = False
    
    strSql = " "
    
    strSql = " SELECT *"
    strSql = strSql & " FROM    UDNTRA"
    strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
    strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
    strSql = strSql & " AND     DATKB =  '1'"
    strSql = strSql & " AND     AKAKROKB =  '9'"
    strSql = strSql & " AND     DKBID =  '01'"
    strSql = strSql & " AND     UDNNO  <>  '" & strUDNNO & "'"
    strSql = strSql & " AND     LINNO  =  '" & strLINNO & "'"
  '  strSql = strSql & " AND     UDNDT <>  '" & strURIDT & "'"
    strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  <>  '" & strWrtFstDt & strWrtFstTm & "'"


    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    'データが存在した場合
    Do While CF_Ora_EOF(Usr_Ody) = False
    
        '消込されていない場合、処理を行う
        If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
                                
            '黒と赤のURIKNの差額が「0」になるのなら表示しない
            If (CLng(strUrikn) + CLng(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then
                chkHenpinTeisei = False
                GoTo END_chkHenpinTeisei
            Else
                chkHenpinTeisei = True
                GoTo END_chkHenpinTeisei
            End If
        
        End If
        
        Usr_Ody.Obj_Ody.MoveNext
    Loop
    
    chkHenpinTeisei = True
    
END_chkHenpinTeisei:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHenpinTeisei:
    GoTo END_chkHenpinTeisei

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Sub chkAkaKro
'   概要： 一部返品が存在する売上を消込する際、赤と黒を割り出し
'　　　　  赤のみ消込される場合は、エラーメッセージを出す。
'          黒のみ消込される場合は、赤の存在があることをメッセージする。
'
'   備考： 2008/08/13 分納された売上に対しての赤黒チェックの追加・修正
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkAkaKro()

    Dim intKesizan      As Currency  'ヘッダ部消込残額
    Dim intKomikn       As Currency  '税込売上額
    Dim intKesikn       As Currency  '消込額
    Dim intBfKesikn     As Currency  '消込額(締日前)
    Dim intAfKesikn     As Currency

    Dim intUrikn        As Currency  '売上金額
    Dim wkKesikn        As Currency  '赤黒チェック用消込金ワーク変数
    Dim sumKesikn       As Currency  '赤黒チェック用消込金変数
    Dim Cnt             As Integer   '赤黒チェック用カウント変数
    Dim i               As Integer   '赤黒チェック用
    Dim wkRow           As Long      '赤黒チェック用行番号

    Dim tmp             As Variant
    Dim LS_HYFRIDT      As Variant
    Dim idxRow          As Long
    Dim idxRowJDNNO     As Long
    Dim strFRIDT        As String
    Dim strHyjdnno      As String
    Dim str_theHYJDNNO  As String
    Dim intchk          As Integer
    Dim strUDNDT       As String
     
     
    chkAkaKro = True
    
    '返品を検索
    With spd_body
        For idxRow = 1 To intMaxRow
            
            'チェックが入っているかを確認
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)

            
            'チェックが入っている場合
            If intchk = 1 Then

                ''赤黒チェック配列の初期化
                ReDim Preserve AKAKRO_CHK(0)
                Cnt = 1
             
                '画面入力値の消込日以降の日付されている場合エラーとする。
                '売上日の取得
                Call .GetText(COL_UDNDT, idxRow, tmp)
                strUDNDT = CStr(tmp)
                
                If strUDNDT > DeCNV_DATE(Trim$(txt_kesidt.Text)) Then
                    MsgBox ("入力された消込日以降の売上が存在します。")
                    chkAkaKro = False
                    Exit Function
                End If
                
                '入金済額(締日前)
                Call .GetText(COL_BFKESIKN, idxRow, tmp)
                intBfKesikn = SSSVal(tmp)
                
                '入金済額(締日後)
                Call .GetText(COL_AFKESIKN, idxRow, tmp)
                intAfKesikn = SSSVal(tmp)
                
                
                '入金済額を取得
                Call .GetText(COL_KESIKN, idxRow, tmp)
                intKesikn = SSSVal(tmp)
                
                '以前に消込されているもの以外
                If intBfKesikn + intAfKesikn = 0 Then
                                
                    '消込額がマイナスであれば同一受注番号の黒を検索
                    If intKesikn < 0 Then
                                               
                        '受注番号取得
                        Call .GetText(COL_HYJDNNO, idxRow, tmp)
                        strHyjdnno = CStr(tmp)
                        

                       '赤のデータを配列に格納
                        AKAKRO_CHK(0).idx = idxRow
                        AKAKRO_CHK(0).CHKMK = intchk
                        AKAKRO_CHK(0).UDNDT = strUDNDT
                        AKAKRO_CHK(0).JDNNO = strHyjdnno
                        AKAKRO_CHK(0).KESIKN = intKesikn

                                
                        '同一受注番号を検索
                        For idxRowJDNNO = intMaxRow To 1 Step -1
                            .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                            str_theHYJDNNO = CStr(tmp)
                            
                            '受注番号一致すれば相殺
                            If strHyjdnno <> str_theHYJDNNO Then
                            Else
                                .GetText COL_CHK, idxRowJDNNO, tmp
                                intchk = SSSVal(tmp)
                                
                            
                             
                                If idxRowJDNNO <> idxRow Then
                               
                                   ''同一受注番号の黒の消込金額を取得
                                    .GetText COL_KESIKN, idxRowJDNNO, tmp
                                    wkKesikn = SSSVal(tmp)
                                    
                                    
                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                     strUDNDT = CStr(tmp)
                                   
                                   ''同一受注番号の黒を配列に格納
                                    ReDim Preserve AKAKRO_CHK(Cnt)
                                    
                                    AKAKRO_CHK(Cnt).idx = idxRowJDNNO
                                    AKAKRO_CHK(Cnt).CHKMK = intchk
                                    AKAKRO_CHK(Cnt).JDNNO = strHyjdnno
                                    AKAKRO_CHK(Cnt).UDNDT = strUDNDT
                                    AKAKRO_CHK(Cnt).KESIKN = wkKesikn
                                
                                    Cnt = Cnt + 1
                                End If
                    
                            End If
                        Next idxRowJDNNO
                        
                        
                        ''返品の赤黒チェック
                        'サマリの初期化
                        sumKesikn = AKAKRO_CHK(0).KESIKN
                        
                        For i = 1 To Cnt - 1
                        
                            'チェックが入っていない場合
                            If AKAKRO_CHK(i).CHKMK = 0 Then
                                
                                wkRow = AKAKRO_CHK(i).idx
                                strUDNDT = AKAKRO_CHK(i).UDNDT
                            
                            '入っている場合
                            Else
                                '赤のマイナスの消込金以上に黒の消込がされている
                                 If sumKesikn + AKAKRO_CHK(i).KESIKN >= 0 Then
                                    sumKesikn = 0
                                    Exit For
                                Else
                                    '
                                    wkRow = AKAKRO_CHK(i).idx
                                    sumKesikn = sumKesikn + AKAKRO_CHK(i).KESIKN
                                End If
                            
                            End If
                        Next i
                        
                        'サマリがマイナスになっている場合はエラーメッセージを表示
                        If Cnt - 1 >= 1 And sumKesikn < 0 Then
                            MsgBox ("充当が必要な売上があります。" & vbCrLf & vbCrLf _
                                        & "行No:" & vbTab & wkRow & vbCrLf _
                                        & "売上日: " & vbTab & strUDNDT & vbCrLf _
                                        & "受注番号: " & vbTab & strHyjdnno)
                            chkAkaKro = False
                            Exit Function
                        End If

                    Else
                    '黒データからの検索
                    
                        '受注番号取得
                        Call .GetText(COL_HYJDNNO, idxRow, tmp)
                        strHyjdnno = CStr(tmp)
                        
                        '同一受注番号を検索
                        For idxRowJDNNO = intMaxRow To 1 Step -1
                            .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                            str_theHYJDNNO = CStr(tmp)
                            
                            '受注番号一致すれば相殺
                            If strHyjdnno <> str_theHYJDNNO Then
                            Else
                                
                                'チェック
                                .GetText COL_CHK, idxRowJDNNO, tmp
                                intchk = SSSVal(tmp)
                        
                                '売上金額
                                .GetText COL_URIKN, idxRowJDNNO, tmp
                                intUrikn = SSSVal(tmp)
                        
                        
                    
                                ''分納されている黒データを検出しないよう修正
                                '自分自身でない、かつチェックされていない、かつ黒データでない
                                If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
                        
                        
                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                    strUDNDT = CStr(tmp)
                                
                                    If MsgBox("充当が必要な売上があります。" & vbCrLf _
                                                & "更新しますか？" & vbCrLf & vbCrLf _
                                                & "行No:" & vbTab & idxRowJDNNO & vbCrLf _
                                                & "売上日: " & vbTab & strUDNDT & vbCrLf _
                                                & "受注番号: " & vbTab & strHyjdnno, vbOKCancel) = vbOK Then
                                    
                                        chkAkaKro = True
    
                                    Else
                                        chkAkaKro = False
                                        Exit Function
                                    End If
                                                                    
                                End If
                            End If
                        Next idxRowJDNNO
                        
                    End If
                End If
            End If
       Next idxRow
    End With

End Function

'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
''   名称： Function chkNyukn
''   概要： 入金されているかのチェック
''   備考：
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkNyukn()


    Dim tmp             As Variant
    Dim idxRow          As Long
    Dim intchk          As Integer
    Dim i               As Integer
    Dim BlnFlg          As Boolean
    
'*** 2009/10/09 ADD START FKS)NAKATA
    Dim BlnFlgDay          As Boolean
'*** 2009/10/09 ADD E.N.D FKS)NAKATA

    Dim strJdnno        As String    '受注番号
    Dim strJdnlinno     As String    '受注行番号
    Dim strHyjdnno      As String
    Dim strOkrjono      As String    '送り状№
    Dim curKesikn       As Currency
    Dim curKesiknMae    As Currency

    
    On Error GoTo ERR_chkNYUKN

    chkNyukn = True



    With spd_body
        For idxRow = 1 To intMaxRow

            'チェックが入っているかを確認
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)


            'チェックが入っている場合
            If intchk = 1 Then

                BlnFlg = False
'*** 2009/10/09 ADD START FKS)NAKATA
                BlnFlgDay = False
'*** 2009/10/09 ADD E.N.D FKS)NAKATA


                '受注番号を取得
                Call .GetText(COL_JDNNO, idxRow, tmp)
                strJdnno = CStr(tmp)

                '受注行番号を取得
                Call .GetText(COL_JDNLINNO, idxRow, tmp)
                strJdnlinno = CStr(tmp)

                '表示用受注番号を取得
                Call .GetText(COL_HYJDNNO, idxRow, tmp)
                strHyjdnno = CStr(tmp)

                '送り状№の取得
                strOkrjono = getOKRJONO(strJdnno, strJdnlinno)

                '入金額
                Call .GetText(COL_KESIKN, idxRow, tmp)
                curKesikn = SSSVal(tmp)

                '入金額
                Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                curKesiknMae = SSSVal(tmp)
                

                If Abs(curKesikn) > Abs(curKesiknMae) Then

                        For i = 0 To UBound(ARY_NYUKN_KS)
                            
                            '入金されているかの確認
                            If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
                                
                                BlnFlg = True
                                
                                '入金日と充当日のチェック
                                If ARY_NYUKN_KS(i).UDNDT <= gstrKesidt Then
                                    BlnFlgDay = True
                                Else
                                    Exit For
                                End If
                                    
                                Exit For
                            
                            End If
                        Next i
        
                        
                        '入金が行われていない場合、エラーとする。
                        If BlnFlg = False Then
                            If MsgBox("入金が登録されていません。" & vbCrLf & vbCrLf _
                                        & "行No:" & vbTab & idxRow & vbCrLf _
                                        & "受注番号: " & vbTab & strHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
                                chkNyukn = False
                                GoTo END_chkNyukn
                            End If
                        End If
                 
'*** 2009/10/09 ADD START FKS)NAKATA
                        '充当日より入金日が以前の場合、エラーとする。
                        If BlnFlgDay = False Then
                            If MsgBox("入金日以前では充当できません。" & vbCrLf & vbCrLf _
                                        & "行No:" & vbTab & idxRow & vbCrLf _
                                        & "受注番号: " & vbTab & strHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
                                chkNyukn = False
                                GoTo END_chkNyukn
                            End If
                        End If
'*** 2009/10/09 ADD E.N.D FKS)NAKATA
                 
                 
                 
                End If
                     
            End If
       
       Next idxRow
    End With


END_chkNyukn:
    
    Exit Function

ERR_chkNYUKN:
    GoTo END_chkNyukn

End Function

'**** 2009/09/16 DEL START FKS)NAKATA
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
''   名称： Function chkURIKN
''   概要： 売上金額と充当金額のチェック
''   備考：
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'Private Function chkUrikn()
'
'    Dim tmp             As Variant
'    Dim idxRow          As Long
'    Dim intchk          As Integer
'
'    Dim strJdnno        As String    '受注番号
'    Dim strJdnlinno     As String    '受注行番号
'    Dim strHyjdnno      As String    '表示用受注番号
'    Dim strOkrjono      As String    '送り状№
'    Dim strJdntrkb      As String    '受注取引区分
'
'    Dim curBfKesikn     As Currency  '消込額(締日前)
'    Dim curAfKesikn     As Currency  '消込額(締日後)
'
'    Dim curNYUKN        As Currency  '入金レコード入金額
'    Dim curUrikn        As Currency  '売上レコード売上金額 + 税金
'
'    Dim Usr_Ody         As U_Ody
'    Dim strSql          As String
'
'    On Error GoTo ERR_chkUrikn
'
'
'
'    chkUrikn = True
'
'    '返品を検索
'    With spd_body
'        For idxRow = 1 To intMaxRow
'
'            'チェックが入っているかを確認
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'
'            'チェックが入っている場合
'            If intchk = 1 Then
'
'
'                '受注番号を取得
'                Call .GetText(COL_JDNNO, idxRow, tmp)
'                strJdnno = CStr(tmp)
'
'
'                '受注行番号を取得
'                Call .GetText(COL_JDNLINNO, idxRow, tmp)
'                strJdnlinno = CStr(tmp)
'
'
'                '表示用受注番号を取得
'                Call .GetText(COL_HYJDNNO, idxRow, tmp)
'                strHyjdnno = CStr(tmp)
'
'
'                '入金済額(締日前)
'                Call .GetText(COL_BFKESIKN, idxRow, tmp)
'                curBfKesikn = SSSVal(tmp)
'
'
'                '入金済額(締日後)
'                Call .GetText(COL_AFKESIKN, idxRow, tmp)
'                curAfKesikn = SSSVal(tmp)
'
'
'                    '以前に消込されているもの以外を対象とする
'                    If curBfKesikn + curAfKesikn = 0 Then
'
'
'                            ''受注番号より受注取引区分を取得する。
'                            strSql = " "
'                            strSql = strSql & " SELECT  JDNTRKB"
'                            strSql = strSql & "  FROM   JDNTHA"
'                            strSql = strSql & " WHERE   DATNO IN"
'                            strSql = strSql & " ("
'                            strSql = strSql & "  SELECT  MAX(DATNO)"
'                            strSql = strSql & "   FROM   JDNTHA"
'                            strSql = strSql & "  WHERE   DATKB = '1'"
'                            strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
'                            strSql = strSql & " )"
'                            strSql = strSql & "    AND DATKB = '1'"
'
'
'                            'DBアクセス
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '受注取引区分
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
'
'
'
'                            ''受注番号・行番号より売上金額を取得する
'                            strSql = ""
'                            strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
'                            strSql = strSql & "  FROM UDNTRA"
'                            strSql = strSql & " WHERE JDNNO     = '" & strJdnno & "'"
'
'                            'セットアップ・システム以外の受注は明細行全体で金額をサマリする。
'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
'                            Else
'                                strSql = strSql & "   AND JDNLINNO  = '" & strJdnlinno & "'"
'                            End If
'
'                            strSql = strSql & "   AND IRISU     <> 9"
'                            strSql = strSql & "   AND DATKB     = '1'"
'
'
'                            'DBアクセス
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '売上金額
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
'
'
'
'                            '受注番号 + 行番号を「送り状№」へ変更
'                            'セットアップ・システムは、行番号を「001」固定
'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
'                                strOkrjono = Trim$(strJdnno) & "001"
'                            Else
'                                strOkrjono = Trim$(strJdnno) & Trim$(strJdnlinno)
'                            End If
'
'
'
'                            ''入金レコードより入金額を取得する。
'                            strSql = " "
'                            strSql = strSql & " SELECT  SUM(TRA.NYUKN) AS NYUKN"
'                            strSql = strSql & "  FROM    UDNTRA TRA ,"
'                            strSql = strSql & "          UDNTHA THA"
'                            strSql = strSql & " WHERE    TRA.DATNO = THA.DATNO"
'                            strSql = strSql & "  AND     TRA.DATKB = '1'"
'                            strSql = strSql & "  AND     TRA.DENKB = '8'"
'                            strSql = strSql & "  AND     THA.NYUCD = '2'"
'                            strSql = strSql & "  AND     THA.FRNKB = '0'"
'                            strSql = strSql & "  AND     TRA.OKRJONO = '" & strOkrjono & "'"
'
'
'
'                            'DBアクセス
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                curNYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")) '売上金額
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
'
'
'                            '売上金額と入金額が一致していない場合、エラー
'                            If curUrikn <> curNYUKN Then
'                                If MsgBox("売上金額と入金額が異なります。" & vbCrLf & vbCrLf _
'                                            & "行No:" & vbTab & idxRow & vbCrLf _
'                                            & "受注番号: " & vbTab & strHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
'                                    chkUrikn = False
'                                    GoTo END_chkUrikn
'                                End If
'                            End If
'
'                    End If
'            End If
'       Next idxRow
'    End With
'
'
'END_chkUrikn:
'    'クローズ
'    Call CF_Ora_CloseDyn(Usr_Ody)
'    Exit Function
'
'ERR_chkUrikn:
'    GoTo END_chkUrikn
'
'
'End Function
'**** 2009/09/16 DEL E.N.D FKS)NAKATA

'**** 2009/09/16 DEL START FKS)NAKATA
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
''   名称： Function chkJdntrkb
''   概要： 伝票単位での充当チェック
''   備考：
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'Private Function chkJdntrkb()
'
'    Dim tmp             As Variant
'    Dim idxRow          As Long
'    Dim intchk          As Integer
'
'    Dim i               As Integer
'    Dim Cnt             As Long
'
'    'スプレッド格納変数
'    Dim strJdnno        As String    '受注番号
'    Dim strJdnlinno     As String    '受注行番号
'    Dim strHyjdnno      As String    '表示用受注番号
'    Dim curKomikn       As Currency  '売上金額＋税金
'
'    '受注取引区分
'    Dim strOkrjono      As String    '送り状№
'    Dim strJdntrkb      As String    '受注取引区分
'
'
'    'チェック用変数
'    Dim wkIdx           As Integer
'    Dim wkJdnno         As String
'    Dim wkHyjdnno       As String
'    Dim wkKomikn        As Currency
'    Dim curUrikn        As Currency  '売上レコード売上金額 + 税金
'
'
'    Dim Usr_Ody         As U_Ody
'    Dim strSql          As String
'
'    On Error GoTo ERR_chkJdntrkb
'
'
'    chkJdntrkb = True
'
'
'    '配列の初期化
'    ReDim Preserve JDNTRKB_CHK(0)
'    Cnt = 0
'
'
'        With spd_body
'            For idxRow = 1 To intMaxRow
'
'                'チェックが入っているかを確認
'                .GetText COL_CHK, idxRow, tmp
'                intchk = SSSVal(tmp)
'
'
'                'チェックが入っている場合
'                If intchk = 1 Then
'
'
'                    '受注番号を取得
'                    Call .GetText(COL_JDNNO, idxRow, tmp)
'                    strJdnno = CStr(tmp)
'
'
'                    '受注行番号を取得
'                    Call .GetText(COL_JDNLINNO, idxRow, tmp)
'                    strJdnlinno = CStr(tmp)
'
'
'                    '表示用受注番号を取得
'                    Call .GetText(COL_HYJDNNO, idxRow, tmp)
'                    strHyjdnno = CStr(tmp)
'
'
'                    '税込売上金額を取得
'                    Call .GetText(COL_KOMIKN, idxRow, tmp)
'                    curKomikn = CCur(tmp)
'
'
'                    '受注番号より受注取引区分を取得する。
'                    strSql = " "
'                    strSql = strSql & " SELECT  JDNTRKB"
'                    strSql = strSql & "  FROM   JDNTHA"
'                    strSql = strSql & " WHERE   DATNO IN"
'                    strSql = strSql & " ("
'                    strSql = strSql & "  SELECT  MAX(DATNO)"
'                    strSql = strSql & "   FROM   JDNTHA"
'                    strSql = strSql & "  WHERE   DATKB = '1'"
'                    strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
'                    strSql = strSql & " )"
'                    strSql = strSql & "    AND DATKB = '1'"
'
'
'                    'DBアクセス
'                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                    If CF_Ora_EOF(Usr_Ody) = False Then
'                        strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '受注取引区分
'                    End If
'
'                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
'
'
'                    '受注取引区分がセットアップとシステムの時のみ配列に格納する
'                    If strJdntrkb = "11" Or strJdntrkb = "21" Then
'
'                        ReDim Preserve JDNTRKB_CHK(Cnt)
'                        With JDNTRKB_CHK(Cnt)
'                            .idx = idxRow
'                            .JDNNO = strJdnno
'                            .HYJDNNO = strHyjdnno
'                            .KOMIKN = curKomikn
'                        End With
'
'                        Cnt = Cnt + 1
'
'                    End If
'
'                End If
'            Next idxRow
'        End With
'
'
'        '配列1番目の受注番号を開始点としてセット
'        wkIdx = JDNTRKB_CHK(0).idx
'        wkJdnno = JDNTRKB_CHK(0).JDNNO
'        wkHyjdnno = JDNTRKB_CHK(0).HYJDNNO
'
'            For i = 0 To UBound(JDNTRKB_CHK)
'
'
'            If wkJdnno = JDNTRKB_CHK(i).JDNNO Then
'
'                '受注番号が同じ場合は、税込売上金額を加算する。
'                wkIdx = JDNTRKB_CHK(i).idx
'                wkHyjdnno = JDNTRKB_CHK(i).HYJDNNO
'                wkKomikn = wkKomikn + JDNTRKB_CHK(i).KOMIKN
'
'            Else
'
'                ''受注番号・行番号より売上金額を取得する
'                strSql = ""
'                strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
'                strSql = strSql & "  FROM UDNTRA"
'                strSql = strSql & " WHERE JDNNO     = '" & wkJdnno & "'"
'                strSql = strSql & "   AND IRISU     <> 9"
'                strSql = strSql & "   AND DATKB     = '1'"
'
'
'                'DBアクセス
'                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                If CF_Ora_EOF(Usr_Ody) = False Then
'                    curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '売上金額
'                End If
'
'                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
'
'
'                '取得した売上金額と画面でチェックされている売上金額を比較する。
'                If wkKomikn <> curUrikn Then
'
'                    If MsgBox("伝票単位で充当/充当解除を行ってください。" & vbCrLf & vbCrLf _
'                                & "行No:" & vbTab & wkIdx & vbCrLf _
'                                & "受注番号: " & vbTab & wkHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
'                        chkJdntrkb = False
'                        GoTo END_chkJdntrkb
'                    End If
'
'                End If
'
'                '受注番号をセット
'                wkIdx = JDNTRKB_CHK(i).idx
'                wkJdnno = JDNTRKB_CHK(i).JDNNO
'                wkKomikn = JDNTRKB_CHK(i).KOMIKN
'
'            End If
'        Next i
'
'
'
'END_chkJdntrkb:
'    'クローズ
'    Call CF_Ora_CloseDyn(Usr_Ody)
'    Exit Function
'
'ERR_chkJdntrkb:
'    GoTo END_chkJdntrkb
'
'
'End Function
'**** 2009/09/16 DEL E.N.D FKS)NAKATA


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub ChkInputChange
    '   概要：  明細の入力内容の変更確認
    '   引数：  無し
    '   戻値：　True:変更有り  False:変更無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function ChkInputChange() As Boolean

    Dim i           As Integer
    Dim vnt_AFCHK   As Variant
    Dim vnt_BFCHK   As Variant
    
    ChkInputChange = False

    With spd_body
        For i = 1 To .MaxRows
            Call .GetText(COL_CHK, i, vnt_AFCHK)
            Call .GetText(COL_BFCHECK, i, vnt_BFCHK)
            If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
                ChkInputChange = True
                Exit For
            End If
        Next i
    End With

End Function


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_NKSTRA_HAITA_INF
    '   概要：  入金消込トランの排他情報取得
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Get_NKSTRA_HAITA_INF() As Boolean
    
    Dim strSql      As Variant
    Dim Usr_Ody     As U_Ody
    Dim Usr_Ody_1   As U_Ody
    Dim i           As Long
    Dim Lng_Cnt     As Long
    
    Get_NKSTRA_HAITA_INF = False
    
    ReDim ARY_NKSTRA_HAITA(0)
    
    For i = 1 To UBound(ARY_UDNTRA_HAITA)
        strSql = ""
        strSql = strSql & "SELECT " & vbCrLf
        strSql = strSql & "       KDNNO  " & vbCrLf
        strSql = strSql & "      ,OPEID  " & vbCrLf
        strSql = strSql & "      ,CLTID  " & vbCrLf
        strSql = strSql & "      ,WRTDT  " & vbCrLf
        strSql = strSql & "      ,WRTTM  " & vbCrLf
        strSql = strSql & "      ,UOPEID " & vbCrLf
        strSql = strSql & "      ,UCLTID " & vbCrLf
        strSql = strSql & "      ,UWRTDT " & vbCrLf
        strSql = strSql & "      ,UWRTTM " & vbCrLf
        strSql = strSql & "FROM " & vbCrLf
        strSql = strSql & "       NKSTRA " & vbCrLf
        strSql = strSql & "WHERE " & vbCrLf
        strSql = strSql & "       UDNDATNO = '" & ARY_UDNTRA_HAITA(i).DATNO & "' " & vbCrLf
        strSql = strSql & "AND    UDNLINNO = '" & ARY_UDNTRA_HAITA(i).LINNO & "' " & vbCrLf
        strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
    
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        Do While CF_Ora_EOF(Usr_Ody) = False
            
            '取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
            strSql = ""
            strSql = strSql & "SELECT " & vbCrLf
            strSql = strSql & "       KDNNO " & vbCrLf
            strSql = strSql & "FROM " & vbCrLf
            strSql = strSql & "       NKSTRA " & vbCrLf
            strSql = strSql & "WHERE " & vbCrLf
            strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf

            'DBアクセス
            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
                
            If CF_Ora_EOF(Usr_Ody_1) Then
                Lng_Cnt = Lng_Cnt + 1
                ReDim Preserve ARY_NKSTRA_HAITA(Lng_Cnt)
                ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "KDNNO", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
                ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
            End If
            
            Call CF_Ora_CloseDyn(Usr_Ody_1)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            Usr_Ody.Obj_Ody.MoveNext
        Loop
        Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
    Next i
        
    Get_NKSTRA_HAITA_INF = True

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_NKSTRA_TEGDT
    '   概要：  入金消込トランの期日振込日の取得
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Get_NKSTRA_TEGDT(vnt_UDNDATNO As Variant, vnt_UDNLINNO As Variant) As String
    
    Dim strSql      As String
    Dim Usr_Ody     As U_Ody
    Dim Usr_Ody_1   As U_Ody
    Dim strTEGDT    As String
    Dim blnExist    As Boolean
        
    strTEGDT = ""
    
    blnExist = False
    

    strSql = ""
    strSql = strSql & "SELECT " & vbCrLf
    strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
    strSql = strSql & "FROM " & vbCrLf
    strSql = strSql & "       NKSTRA " & vbCrLf
    strSql = strSql & "WHERE " & vbCrLf
    strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
    strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
    strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
    strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
    strSql = strSql & "AND    KDNNO NOT IN ( " & vbCrLf
    strSql = strSql & "       SELECT " & vbCrLf
    strSql = strSql & "              MOTKDNNO " & vbCrLf
    strSql = strSql & "       FROM " & vbCrLf
    strSql = strSql & "              NKSTRA " & vbCrLf
    strSql = strSql & "       WHERE " & vbCrLf
    strSql = strSql & "              UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
    strSql = strSql & "       AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
    strSql = strSql & "       AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
    strSql = strSql & "       ) " & vbCrLf
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
    If Not CF_Ora_EOF(Usr_Ody) Then
        strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    End If
        
    Get_NKSTRA_TEGDT = strTEGDT

End Function
'*** 2009/09/03 ADD START FKS)NAKATA V1.03
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Get_NYUKN_TEGDT
    '   概要：  売上トラン.入金レコードの期日振込日の取得
    '   引数：  無し
    '   戻値：　True:正常  False:異常
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Get_NYUKN_TEGDT(vnt_JDNNO As String, vnt_JDNLINNO As String) As String
    
    Dim strSql      As String
    Dim Usr_Ody     As U_Ody
    Dim Usr_Ody_1   As U_Ody
    Dim strTEGDT    As String
    Dim strOkrjono  As String
    Dim blnExist    As Boolean
        
    strTEGDT = ""
    
    blnExist = False
    
    strOkrjono = getOKRJONO(vnt_JDNNO, vnt_JDNLINNO)


        strSql = " "
        strSql = strSql & " SELECT  " & vbCrLf
        strSql = strSql & "   MAX(TEGDT) AS TEGDT" & vbCrLf
        strSql = strSql & "  FROM  UDNTRA TRA" & vbCrLf
        strSql = strSql & " WHERE  TRA.DENKB     =   '8'" & vbCrLf
        strSql = strSql & "   AND  TRA.DATKB     =   '1'" & vbCrLf
        strSql = strSql & "   AND  TRA.AKAKROKB  =   '1'" & vbCrLf
        strSql = strSql & "   AND  TRA.KESIKB    =   '9'" & vbCrLf
        strSql = strSql & "   AND  TRA.OKRJONO   =   '" & strOkrjono & "'" & vbCrLf
        strSql = strSql & "   AND  TRA.DATNO IN" & vbCrLf
        strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
        strSql = strSql & "                FROM  UDNTRA" & vbCrLf
        strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
        strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
        strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
        strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
        strSql = strSql & "            )" & vbCrLf


    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
    If Not CF_Ora_EOF(Usr_Ody) Then
        strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    End If
        
    Get_NYUKN_TEGDT = strTEGDT

End Function
'*** 2009/09/03 ADD E.N.D FKS)NAKATA V1.03

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkCondition
'   概要：  ヘッダ部の入力チェック
'   引数：  無し
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkCondition() As Boolean
    chkCondition = False
    
    'チェック：消込日
    With txt_kesidt
        If Trim(.Text) = "" Then
            '必須入力チェック
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            'チェック処理
            If chkKesidt(True) = False Then 'チェック処理を強制的に走らせる
                'エラー
                Call .SetFocus
                Exit Function
            End If
        End If
    End With
    
    'チェック：請求先コード
    With txt_tokseicd
        If Trim(.Text) = "" Then
            '必須入力チェック
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            'チェック処理
            If chkTokseicd(True) = False Then 'チェック処理を強制的に走らせる
                'エラー
                Call .SetFocus
                Exit Function
            End If
        End If
    End With
    
    'チェック：売上日(開始)
    With txt_kaidt_From
        If Trim(.Text) = "" Then
            If Trim(txt_kesikb.Text) = "9" Then
                '必須入力チェック
                Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
                .ForeColor = vbRed
                .SetFocus
                Exit Function
            End If
        Else
            intChkKb = 1
            If chkKaidt_From(True) = False Then 'チェック処理を強制的に走らせる
                'エラー
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    'チェック：売上日(終了)
    With txt_kaidt_To
        If Trim(.Text) = "" Then
            '必須入力チェック
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            'チェック処理
            If chkKaidt_To(True) = False Then 'チェック処理を強制的に走らせる
                'エラー
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    With txt_fridt
        If Trim(.Text) = "" Then
            If blnFriEnabled = True Then
                '必須入力チェック
                Call showMsg("0", "_HEADCOMPLETEC", "0")    '●見出未入力ｴﾗｰMSG

                .Enabled = True

                .ForeColor = vbRed
                .SetFocus
                Exit Function
            End If
        Else
            intChkKb = 1
            'チェック処理
            If chkFridt(True) = False Then 'チェック処理を強制的に走らせる
                'エラー
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    chkCondition = True
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkKesidt
'   概要：  消込日付のチェック
'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKesidt = False

    With txt_kesidt
        If pin_blnChk = False Then
            'チェック区分が1のとき、あるいは変更されていたらチェックを行う
            If intChkKb <> 1 Then
                chkKesidt = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKesidt) Then
                chkKesidt = True
                GoTo END_STEP
            End If
        End If

        '空白入力時はチェックしない（chkConditionでチェック）
        If Trim(.Text) = "" Then
            chkKesidt = True
            Exit Function
        End If

        '日付形式のチェック
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If


'2009/09/03 ADD START RISE)MIYAJIMA
        '入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
        If Trim(txt_tokseicd) <> "" Then
            If DeCNV_DATE(.Text) <= DB_TOKMTA.TOKSMEDT Then
                Call showMsg("2", "URKET73_042", 0)     '●請求締日以前です。この日付では入力できません。MSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If
'2009/09/03 ADD E.N.D RISE)MIYAJIMA


        '経理締日以前の日付の時はエラー
        If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
        'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
            Call showMsg("1", "URKET73_010", 0)     '●経理締め済みのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '運用日より後日付の時はエラー
        If DeCNV_DATE(.Text) > gstrUnydt Then
            Call showMsg("2", "DATE_1", 3)          '●運用日後日付エラー
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '締めを跨いでの日付はエラー
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '●締めを跨いでの日付は入力できません
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        .ForeColor = vbBlack
    End With

    chkKesidt = True

END_STEP:

    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    intChkKb = 2            '●基本は変更時にチェック
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkTokseicd
'   概要：  請求先ｺｰﾄﾞのチェック
'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean


'2009/09/07 ADD START FKS)NAKATA
    Dim strTANCLAKB         As String
'2009/09/07 ADD E.N.D FKS)NAKATA


    chkTokseicd = False

    With txt_tokseicd
        If pin_blnChk = False Then
            'チェック区分が1のとき、あるいは変更されていたらチェックを行う
            If intChkKb <> 1 Then
                chkTokseicd = True
                GoTo END_STEP
            End If
            If .Text = gstrTokseicd Then
                chkTokseicd = True
                GoTo END_STEP
            End If
        End If

        '変更されていたら項目クリア
        If .Text <> gstrTokseicd Then
            txt_tokseinma.Text = ""
            txt_fridt.Text = Space(8)
            txt_fridt.Enabled = False
            
            lbl_shakbnm(1).Caption = ""
            lbl_hytokkesdd(1).Caption = ""
            gstrFridt = Space(8)
        End If

        '空白入力時はチェックしない（chkConditionでチェック）
        If Trim(.Text) = "" Then
            chkTokseicd = True
            Exit Function
        End If

        blnFriEnabled = False

        '得意先ﾏｽﾀから請求先名称を取得
        Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), .Text)
            '国内請求先のとき
            Case 0:
                .ForeColor = vbBlack
                txt_tokseinma.Text = DB_TOKMTA.TOKRN
                lbl_shakbnm(1).Caption = DB_TOKMTA.SHAKBNM
                lbl_hytokkesdd(1).Caption = DB_TOKMTA.HYTOKKESDD
                

'2009/09/07 ADD START FKS)NAKATA V1.04
                '入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
                If DeCNV_DATE(txt_kesidt.Text) <= DB_TOKMTA.TOKSMEDT Then
                    Call showMsg("2", "URKET73_042", 0)     '●請求締日以前です。この日付では入力できません。MSG
                    txt_kesidt.ForeColor = vbRed
                    txt_kesidt.SetFocus
                    GoTo END_STEP
                End If
'2009/09/07 ADD E.N.D FKS)NAKATA
'2009/09/07 ADD START FKS)NAKATA V1.04
                Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA.TANCD, strTANCLAKB)
                If strTANCLAKB <> "1" Then
                    Call showMsg("2", "URKET73_043", 0)     '●請求先担当者が営業でありません。
                    .ForeColor = vbRed
                    GoTo END_STEP
                End If
'2009/09/07 ADD E.N.D FKS)NAKATA



'*** 2009/09/03 CHG START FKS)NAKATA V1.03
'振込期日は、消込トラン又は売上トラン.入金レコードより取得するため
''                Call getInputHYFRIDT(DB_TOKMTA.TOKSEICD _
''                                    , Get_Acedt(DeCNV_DATE(txt_kesidt.Text)) _
''                                    , DB_TOKMTA.SHAKB)
''
''                txt_fridt.Enabled = blnFriEnabled
                blnFriEnabled = False
'*** 2009/09/03 CHG E.N.D FKS)NAKATA V1.03
                
                chkTokseicd = True

            '海外請求先のとき
            Case 1:
                Call showMsg("1", "URKET73_013", 0)     '●国内の得意先ではありません。
                .ForeColor = vbRed
                GoTo END_STEP

            '請求先でない得意先のとき
            Case 8:
                Call showMsg("2", "DONTSELECT", "2")    '●請求先ではない
                .ForeColor = vbRed
                GoTo END_STEP

            '請求先が存在しない時
            Case 9:
                Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
                .ForeColor = vbRed
                GoTo END_STEP
        End Select

        .ForeColor = vbBlack
    End With

    chkTokseicd = True

END_STEP:

    gstrTokseicd = txt_tokseicd.Text
    intChkKb = 2            '●基本は変更時にチェック
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkKaidt_From
'   概要：  回収予定日付（開始）のチェック
'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKaidt_From = False

    With txt_kaidt_From
        If pin_blnChk = False Then
            'チェック区分が1のとき、あるいは変更されていたらチェックを行う
            If intChkKb <> 1 Then
                chkKaidt_From = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKaidt_Fr) Then
                chkKaidt_From = True
                GoTo END_STEP
            End If
        End If

        '空白入力時はチェックしない（chkConditionでチェック）
        If Trim(.Text) = "" Then
            gstrKaidt_Fr = ""
            chkKaidt_From = True
            Exit Function
        End If

        '日付形式のチェック
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)                '●日付誤りのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '締めを跨いでの日付はエラー
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '●締めを跨いでの日付は入力できません
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '入金消込画面で受注日(売上日)＞入金消込日はエラー
        If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
            If Format(.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If

        .ForeColor = vbBlack
    End With

    chkKaidt_From = True

END_STEP:

    gstrKaidt_Fr = DeCNV_DATE(txt_kaidt_From.Text)
    intChkKb = 2            '●基本は変更時にチェック
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkKaidt_To
'   概要：  回収予定日付（終了）のチェック
'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKaidt_To = False

    With txt_kaidt_To
        If pin_blnChk = False Then
            'チェック区分が1のとき、あるいは変更されていたらチェックを行う
            If intChkKb <> 1 Then
                chkKaidt_To = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKaidt_To) Then
                chkKaidt_To = True
                GoTo END_STEP
            End If
        End If

        '空白入力時はチェックしない（chkConditionでチェック）
        If Trim(.Text) = "" Then
            chkKaidt_To = True
            Exit Function
        End If

        '日付形式のチェック
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '締めを跨いでの日付はエラー
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '●締めを跨いでの日付は入力できません
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '入金消込画面で受注日(売上日)＞入金消込日はエラー
        If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
            If Format(.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If

        '日付の大小比較
        If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
            If Format(txt_kaidt_From.Text, "0000/00/00") > Format(.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)     '●日付誤りのMSG
                .ForeColor = vbRed
                txt_kaidt_From.ForeColor = vbRed
                GoTo END_STEP
            Else
                'チェックエラーなし
                txt_kaidt_From.ForeColor = vbBlack
            End If
        End If

        .ForeColor = vbBlack
    End With

    chkKaidt_To = True

END_STEP:

    gstrKaidt_To = DeCNV_DATE(txt_kaidt_To.Text)
    intChkKb = 2            '●基本は変更時にチェック
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function chkFridt
'   概要：  振込期日のチェック
'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
'   戻値：　True:正常  False:異常
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    chkFridt = False

    With txt_fridt
        If pin_blnChk = False Then
            'チェック区分が1のとき、あるいは変更されていたらチェックを行う
            If intChkKb <> 1 Then
                chkFridt = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrFridt) Then
                chkFridt = True
                GoTo END_STEP
            End If
        End If

        '空白入力時はチェックしない（chkConditionでチェック）
        If Trim(.Text) = "" Then
            chkFridt = True
            Exit Function
        End If

        '日付形式のチェック
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '●日付誤りのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '経理締日以前の日付の時はエラー
        If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
        'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
            Call showMsg("1", "URKET73_010", 0)     '●経理締め済みのMSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        .ForeColor = vbBlack
    End With

    chkFridt = True

END_STEP:

    gstrFridt = DeCNV_DATE(txt_fridt.Text)
    intChkKb = 2            '●基本は変更時にチェック
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_Change
    '   概要：  日付項目日付変換
    '   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Ctl_DTItem_Change(pm_objDt As Object)
    
    With pm_objDt
        'スラッシュが存在しているときは、スラッシュを飛ばして次の項目へ
        If Mid(.Text, .SelStart + 1, 1) = "/" Then
            .SelStart = .SelStart + 1
        End If
        .SelLength = 1
        
        '入力された値が８桁に到達したのでスラッシュ編集する
        If Len(Trim(.Text)) = 8 Then
            .Text = Format(.Text, "0000/00/00")
            '日付の日の部分を選択状態にする
            .SelStart = 8
            .SelLength = 1
        End If
    End With

End Sub
    

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_GotFocus
    '   概要：  日付項目のカーソル位置付け
    '   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　無し
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Ctl_DTItem_GotFocus(pm_objDt As Object)
    
    With pm_objDt
        If Trim(.Text) = "" Or pm_objDt.ForeColor = vbRed Then
            'なにも入っていないまたはエラーの時に先頭へ位置づけ
            .SelStart = 0
            .SelLength = 1
        Else
            'なにか入っていたら日付の十の位を選択状態にする
            .SelStart = 8
            .SelLength = 1
        End If
        '背景色を黄色にする
        .BackColor = vbYellow
    End With

End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_KeyDown
    '   概要：  請求先ｺｰﾄﾞキー入力制御
    '   引数：  pm_KeyCode    : キーコード
    '           pm_Shift      : シフト押下状態
    '           pm_objDt      : 請求先ｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　0:移動無し 1:次項目 2:前項目
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_tokseicd_KeyDown( _
                                pm_KeyCode As Integer, _
                                pm_Shift As Integer, _
                                pm_objCD As Object) As Integer

    Ctl_tokseicd_KeyDown = 0
    
    With pm_objCD
    
        Select Case pm_KeyCode
        
            'ファンクションキー押下時
            Case vbKeyF1 To vbKeyF12
                'ファンクションキー共通処理
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
    
            '右矢印押下時
            Case vbKeyRight
                If .SelStart < 4 Then
                    .SelStart = .SelStart + 1
                    .SelLength = 1
                Else
                    intChkKb = 2                            '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                    Ctl_tokseicd_KeyDown = 1
                End If
            
            'Backspace or 左矢印押下時
            Case vbKeyBack, vbKeyLeft
                If .SelStart > 0 Then
                    .SelStart = .SelStart - 1
                    .SelLength = 1
                Else
                    'Backspaceの時は、入力値が空白の時、前項目へ移動
                    If Trim(.Text) <> "" And pm_KeyCode = vbKeyBack Then
                        Exit Function
                    End If
                    intChkKb = 2                            '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                    Ctl_tokseicd_KeyDown = 2
                End If
        
                '上矢印押下時
             Case vbKeyUp
                intChkKb = 2                                '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                Ctl_tokseicd_KeyDown = 2
    
            '下矢印押下時
            Case vbKeyDown
                intChkKb = 2                                '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
                Ctl_tokseicd_KeyDown = 1
    
            'Enter押下時
            Case vbKeyReturn
                intChkKb = 1                                '★請求先ｺｰﾄﾞの入力チェック
                Ctl_tokseicd_KeyDown = 1
    
            'Delete押下時
            Case vbKeyDelete
                Exit Function
    
            'TAB押
            Case vbKeyF16
                intChkKb = 1                                '★請求先ｺｰﾄﾞの入力チェック
                Ctl_tokseicd_KeyDown = 1
        
            'SHIFT+TAB押
            Case vbKeyF15
                intChkKb = 2                                '★請求先ｺｰﾄﾞの入力チェック
                Ctl_tokseicd_KeyDown = 2
                
            Case Else
                Exit Function
        
        End Select
        
    End With

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub Ctl_DTItem_KeyDown
    '   概要：  日付項目キー入力制御
    '   引数：  pm_KeyCode    : キーコード
    '           pm_Shift      : シフト押下状態
    '           pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
    '   戻値：　0:移動無し 1:次項目 2:前項目
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_DTItem_KeyDown( _
                                pm_KeyCode As Integer, _
                                pm_Shift As Integer, _
                                pm_objDt As Object) As Integer

    Ctl_DTItem_KeyDown = 0
    
    With pm_objDt
    
        Select Case pm_KeyCode
    
            'ファンクションキー押下時
            Case vbKeyF1 To vbKeyF12
                'ファンクションキー共通処理
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
    
            '右矢印 or Space押下時
            Case vbKeyRight, vbKeySpace
                
                If .SelStart < 9 Then
                    .SelStart = .SelStart + 1
                    'スラッシュにカーソルがきたら次の文字にカーソルを移動
                    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                        .SelStart = .SelStart + 1
                    End If
                'カーソルが右端に来たら次の項目へ移動
                Else
                    intChkKb = 2                        '★日付の入力チェック（変更時のみ)
                    Ctl_DTItem_KeyDown = 1
                End If
                .SelLength = 1
            
            'Backspace or 左矢印押下時
            Case vbKeyBack, vbKeyLeft
            
                If .SelStart > 0 Then
                    .SelStart = .SelStart - 1
                    'スラッシュにカーソルがきたら前の文字にカーソルを移動
                    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                        .SelStart = .SelStart - 1
                    End If
        
                'カーソルが左端に来たら前の項目へ移動
                Else
                    intChkKb = 2                        '★日付の入力チェック（変更時のみ)
                    Ctl_DTItem_KeyDown = 2
                End If
                .SelLength = 1
            
            '上矢印押下時
            Case vbKeyUp
                intChkKb = 2                            '★日付の入力チェック（変更時のみ)
                Ctl_DTItem_KeyDown = 2
            
            '下矢印押下時
            Case vbKeyDown
                intChkKb = 2                            '★日付の入力チェック（変更時のみ)
                Ctl_DTItem_KeyDown = 1

            'Enter押下時
            Case vbKeyReturn
                intChkKb = 1                            '★日付の入力チェック
                Ctl_DTItem_KeyDown = 1
        
            'TAB押
            Case vbKeyF16
                intChkKb = 1                            '★日付の入力チェック
                Ctl_DTItem_KeyDown = 1
    
            'Shift+TAB押
            Case vbKeyF15
                intChkKb = 2                            '★日付の入力チェック（変更時のみ)
                Ctl_DTItem_KeyDown = 2

            'Shift+DELETE押
            Case vbKeyDelete And pm_Shift = 1
                Dim str As String
                str = .Text
                If Len(str) > 0 And .SelStart < Len(str) Then
                    str = Mid$(str, 1, .SelStart) & Mid$(str, .SelStart + 2)
                    str = Replace(str, "/", "")
                    .SelStart = 0
                    If Len(str) > 0 Then
                        .SelLength = 1
                    End If
                End If
                .Text = str

        End Select

    End With

End Function


'=======================================================回収予定日(開始)=======================================================

'回収予定日クリック時
Private Sub txt_kaidt_From_Click()
    
    txt_kaidt_From.SelStart = 0
    txt_kaidt_From.SelLength = 1

End Sub

'回収予定日項目を変更した時
Private Sub txt_kaidt_From_Change()
    
    '日付変換処理
    Call Ctl_DTItem_Change(txt_kaidt_From)

End Sub

'回収予定日項目にフォーカスが移った時
Private Sub txt_kaidt_From_GotFocus()
    
    'カーソル位置付け
    Call Ctl_DTItem_GotFocus(txt_kaidt_From)
    
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True

End Sub

'回収予定日項目でキーを押した時
Private Sub txt_kaidt_From_KeyDown(KeyCode As Integer, Shift As Integer)
    
    'キー入力制御
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
        Case 0
            '何もしない
        Case 1
            '入力チェック
            If chkKaidt_From = True Then
                '次項目
                txt_kaidt_To.SetFocus
            End If
        Case 2
            '入力チェック
            If chkKaidt_From = True Then
                '前項目
                txt_tokseicd.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'回収予定日項目でキーを押した時
Private Sub txt_kaidt_From_KeyPress(KeyAscii As Integer)
    
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'回収予定日項目からフォーカスが移った時
Private Sub txt_kaidt_From_LostFocus()
    
    '背景色を白に戻す
    txt_kaidt_From.BackColor = vbWhite

End Sub

'=======================================================回収予定日(終了)=======================================================

'回収予定日クリック時
Private Sub txt_kaidt_To_Click()
    
    txt_kaidt_To.SelStart = 0
    txt_kaidt_To.SelLength = 1

End Sub

'回収予定日項目を変更した時
Private Sub txt_kaidt_To_Change()
    
    '日付変換処理
    Call Ctl_DTItem_Change(txt_kaidt_To)

End Sub

'回収予定日項目にフォーカスが移った時
Private Sub txt_kaidt_To_GotFocus()
    
    'カーソル位置付け
    Call Ctl_DTItem_GotFocus(txt_kaidt_To)
    
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True

End Sub

'回収予定日項目でキーを押した時
Private Sub txt_kaidt_To_KeyDown(KeyCode As Integer, Shift As Integer)
    
    'キー入力制御
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
        Case 0
            '何もしない
        Case 1
            '入力チェック
            If chkKaidt_To = True Then
                '次項目
                txt_kesikb.SetFocus
            End If
        Case 2
            '入力チェック
            If chkKaidt_To = True Then
                '前項目
                txt_kaidt_From.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'回収予定日項目でキーを押した時
Private Sub txt_kaidt_To_KeyPress(KeyAscii As Integer)
    
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'回収予定日項目からフォーカスが移った時
Private Sub txt_kaidt_To_LostFocus()
    
    '背景色を白に戻す
    txt_kaidt_To.BackColor = vbWhite

End Sub

'=======================================================消込日=======================================================

'消込日項目クリック時
Private Sub txt_kesidt_Click()
    
    txt_kesidt.SelStart = 0
    txt_kesidt.SelLength = 1

End Sub

'消込日項目を変更した時
Private Sub txt_kesidt_Change()
    
    '日付変換処理
    Call Ctl_DTItem_Change(txt_kesidt)

End Sub

'消込日項目にフォーカスが移った時
Private Sub txt_kesidt_GotFocus()
    
    intInputMode = 1
    
    'カーソル位置付け
    Call Ctl_DTItem_GotFocus(txt_kesidt)
    
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True

End Sub

'消込日項目でキーを押した時
Private Sub txt_kesidt_KeyDown(KeyCode As Integer, Shift As Integer)
    
    intChkKb = 0
    
    'キー入力制御
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
        Case 0
            '何もしない
        Case 1
            '入力チェック
            If chkKesidt = True Then
                '次項目
                txt_tokseicd.SetFocus
            End If
        Case 2
            '入力チェック
            If chkKesidt = True Then
                '前項目
                txt_kesidt.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'消込日項目でキーを押した時
Private Sub txt_kesidt_KeyPress(KeyAscii As Integer)
    
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'消込日項目からフォーカスが移った時
Private Sub txt_kesidt_LostFocus()
    
    '背景色を白に戻す
    txt_kesidt.BackColor = vbWhite

End Sub

'=======================================================振込期日=======================================================

'振込期日項目を変更した時
Private Sub txt_fridt_Change()
    
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then
        Exit Sub
    End If

    '日付変換処理
    Call Ctl_DTItem_Change(txt_fridt)

    blnUsableEvent = True

End Sub

'振込期日項目にフォーカスが移った時
Private Sub txt_fridt_GotFocus()
    
    'カーソル位置付け
    Call Ctl_DTItem_GotFocus(txt_fridt)
    
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True

End Sub

'振込期日項目でキーを押した時
Private Sub txt_fridt_KeyDown(KeyCode As Integer, Shift As Integer)

    'キー入力制御
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
        Case 0
            '何もしない
        Case 1
            '入力チェック
            If chkFridt = True Then
                '次項目
                spd_body.SetFocus
            End If
        Case 2
            '入力チェック
            If chkFridt = True Then
                '前項目
                txt_kesikb.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'振込期日項目でキーを押した時
Private Sub txt_fridt_KeyPress(KeyAscii As Integer)
    
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'振込期日項目からフォーカスが移った時
Private Sub txt_fridt_LostFocus()

    '背景色を白に戻す
    txt_fridt.BackColor = vbWhite

End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_FuncKey_Execute
    '   概要：  システム共通処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Integer, ByVal pm_Shift As Integer) As Integer

    CF_FuncKey_Execute = 0
   
    Select Case True
        'F1キー押下
        Case pm_KeyCode = vbKeyF1 And pm_Shift = 0
            SendKeys "%1"
            
        'F2キー押下
        Case pm_KeyCode = vbKeyF2 And pm_Shift = 0
            SendKeys "%2"
        
        'F3キー押下
        Case pm_KeyCode = vbKeyF3 And pm_Shift = 0
            SendKeys "%3"
   End Select
   
End Function
    
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_System_Process
    '   概要：  システム共通処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CF_System_Process(pm_Form As Form) As Integer
    

   'パッケージ内のＤＬＬにて
   '｢ＴＡＢ｣＆｢ＴＡＢ＋ＳＨＩＦＴ｣をそれぞれ｢Ｆ１６｣＆｢Ｆ１５｣に割当
   ReleaseTabCapture 0
   SetTabCapture pm_Form.hwnd

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Sub chkFurikomiDT
'   概要： TOKMTA.SHAKB（支払条件）に手形が入っている場合は振込期日が必須
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkFurikomiDT() As Boolean

    Dim idxRow          As Long
    Dim tmp             As Variant
    Dim intchk          As Integer
    Dim strHYFRIDT      As String
    
    chkFurikomiDT = False
    
    If blnFriEnabled = False Then
        chkFurikomiDT = True
        Exit Function
    End If
    
    '返品を検索
    With spd_body
        For idxRow = 1 To intMaxRow
            'チェックが入っているかを確認
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)
            
            'チェックが入っている場合
            If intchk = 1 Then
                '売上日の取得
                Call .GetText(COL_HYFRIDT, idxRow, tmp)
                strHYFRIDT = CStr(tmp)
                
                If Trim(strHYFRIDT) = "" Then
                    Call showMsg("0", "_COMPLETEC", 0)     '●入力されていない項目があります。入力してください。
                    Exit Function
                End If
            End If
       Next idxRow
    End With

    chkFurikomiDT = True

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称： Function chk_HENPIN
'   概要： 未来に返品が発生しているかチェックする
'   引数： strJdnNo   : 受注伝票番号
'   　　： strJdnlinNo: 受注伝票行番号
'       :  strUrikn   : 売上金額
'   戻値： チェック結果
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function chkHenpin2(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUDNDT As String) As Boolean

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    On Error GoTo ERR_chkHENPIN2

    '//表示します
    chkHenpin2 = True
    
    If Trim$(gstrKaidt_Fr) = "" Then
        '//表示します
        GoTo END_chkHENPIN2
    End If
    
    '//未来に返品データが存在しているか確認する
    strSql = " "
    strSql = " SELECT *"
    strSql = strSql & " FROM    UDNTRA"
    strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
    strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
    strSql = strSql & " AND     DATKB =  '1'"
    strSql = strSql & " AND     AKAKROKB =  '9'"
    strSql = strSql & " AND     DKBID    =  '02'"
    strSql = strSql & " AND     UDNDT    >= '" & gstrKaidt_Fr & "'"
    strSql = strSql & " AND     UDNDT    <= '" & gstrKaidt_To & "'"

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    'データが存在した場合
    If CF_Ora_EOF(Usr_Ody) = False Then
        
        Select Case txt_kesikb.Text
            Case 1
                '消込されていない場合、処理を行う
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
                    '//表示します
                    GoTo END_chkHENPIN2
                Else
                    '//表示しません
                    chkHenpin2 = False
                    GoTo END_chkHENPIN2
                End If
            Case 9
                '消込されていない場合、処理を行う
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
                    '//表示します
                    GoTo END_chkHENPIN2
                Else
                    '//表示しません
                    chkHenpin2 = False
                    GoTo END_chkHENPIN2
                End If
        End Select
        
        '//表示します
        GoTo END_chkHENPIN2
    
    End If
    
    'データが存在しなかった場合
    If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
        '//表示しません
        chkHenpin2 = False
        GoTo END_chkHENPIN2
    End If
    
END_chkHENPIN2:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHENPIN2:
    GoTo END_chkHENPIN2

End Function


'振込期日の入力可能判断
Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String _
                          , ByVal pin_strSMADT As String _
                          , ByVal pin_strSHAKB As String)
    
    Dim strSql      As Variant
    Dim Usr_Ody     As U_Ody
    
    Dim curNYUKIN1  As Integer
    Dim curNYUKIN2  As Integer

    '消込日月度の消込状態を取得
    strSql = ""
    strSql = strSql & " SELECT * "
    strSql = strSql & "   FROM NKSSMB "
    strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
    strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '振込期日を入力できるかどうかのフラグを設定する
    blnFriEnabled = False
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN02", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN02", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN02", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN07", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN07", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
        If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN07", "")) <> 0 Then
            blnFriEnabled = True
            GoTo END_getInputHYFRIDT
        End If
    End If

    Call CF_Ora_CloseDyn(Usr_Ody)

    
END_getInputHYFRIDT:
    
    Call CF_Ora_CloseDyn(Usr_Ody)

End Sub

'売上トラン・入金レコード(DENKB=8)の排他用データ取得
Private Sub getUdntraNyukn(ByVal strJdnno As String, ByVal strJdnlinno As String)


    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    Dim intCnt          As Integer
    
    Dim strJdntrkb      As String
    Dim strOkrjono      As String '送り状№
    
'*** 2009/08/26 ADD START FKS)NAKATA v1.02
    Dim i               As Integer
    Dim BlnFlg          As Boolean '2度読み用フラグ
'*** 2009/08/26 ADD E.N.D FKS)NAKATA v1.02

    
    On Error GoTo ERR_UdntraNyukn
            
            
            '二度読み用フラグ初期化
            BlnFlg = False
            
            
            ''受注番号より送り状№を取得する。
            strOkrjono = getOKRJONO(strJdnno, strJdnlinno)


            '売上トランの最新の入金レコードを取得
            strSql = " "
            strSql = strSql & " SELECT   DATNO"
            strSql = strSql & "         ,LINNO"
            strSql = strSql & "         ,UDNNO"
            strSql = strSql & "         ,OKRJONO"
            strSql = strSql & "         ,NYUKN"
            strSql = strSql & "         ,DKBID"
            strSql = strSql & "         ,UPDID"
            strSql = strSql & "         ,OPEID"
            strSql = strSql & "         ,OPEID"
            strSql = strSql & "         ,CLTID"
            strSql = strSql & "         ,WRTDT"
            strSql = strSql & "         ,WRTTM"
            strSql = strSql & "         ,UOPEID"
            strSql = strSql & "         ,UCLTID"
            strSql = strSql & "         ,UWRTDT"
            strSql = strSql & "         ,UWRTTM"
            strSql = strSql & " FROM UDNTRA"
            strSql = strSql & "  WHERE (DATNO , UDNNO , UPDID) IN"
            strSql = strSql & " (   SELECT  MAX(DATNO)"
            strSql = strSql & "             ,UDNNO"
            strSql = strSql & "             ,UPDID"
            strSql = strSql & "      FROM   UDNTRA"
            strSql = strSql & "      WHERE  DATKB = '1'"
            strSql = strSql & "       AND   DENKB = '8'"
            strSql = strSql & "       AND   OKRJONO = '" & strOkrjono & "'"
            strSql = strSql & "      GROUP BY UDNNO, UPDID"
            strSql = strSql & " )"
            strSql = strSql & "   AND   DATKB   =   '1'"
            strSql = strSql & "   AND   AKAKROKB =   '1'"
            strSql = strSql & "   AND   DENKB = '8'"
            strSql = strSql & "   AND   OKRJONO = '" & strOkrjono & "'"
    
    
            'ﾃﾞｰﾀ取得
            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
            Do While CF_Ora_EOF(Usr_Ody) = False
                
                ReDim Preserve ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
                
                    With ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
                    
                        .DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
                        .LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
                        .UDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNNO", ""))
                        .OKRJONO = CStr(CF_Ora_GetDyn(Usr_Ody, "OKRJONO", ""))
                        .OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
                        .CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
                        .WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
                        .WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
                        .UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
                        .UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
                        .UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
                        .UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))

                    End With

                ARY_UDNTRA_NYU_CNT = ARY_UDNTRA_NYU_CNT + 1

                Usr_Ody.Obj_Ody.MoveNext

            Loop
            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
            
            
            
            For i = 0 To UBound(ARY_NYUKN_KS)
                '二度読み回避変数と送り状№が同じ場合は、データの取得を行わない。
                If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
                        BlnFlg = True
                        Exit For
                End If
            Next i

            If BlnFlg = False Then
        

                '入金消込トラン・売上トラン．入金レコードより、入金額の残額を取得する。
                
                strSql = " " & vbCrLf
                strSql = strSql & " SELECT UDN.SEQ  AS SEQ" & vbCrLf
                strSql = strSql & "      , UDN.NYUKN - NVL(NKS.JKESIKN,0) AS ZANKN" & vbCrLf
                strSql = strSql & "      , UDN.DKBID AS DKBID" & vbCrLf
                strSql = strSql & "      , UDN.UPDID AS UPDID" & vbCrLf
                strSql = strSql & "      , UDN.NYUKB AS NYUKB" & vbCrLf
            '*** 2009/10/09 ADD START FKS)NAKATA
                strSql = strSql & "      , UDN.UDNDT AS UDNDT" & vbCrLf
            '*** 2009/10/09 ADD E.N.D FKS)NAKATA
                strSql = strSql & " FROM" & vbCrLf
                strSql = strSql & "    (" & vbCrLf
                strSql = strSql & "         SELECT  SUM(JKESIKN) AS JKESIKN" & vbCrLf
                strSql = strSql & "             ,   DKBID AS DKBID" & vbCrLf
                strSql = strSql & "             ,   UPDID AS UPDID" & vbCrLf
                strSql = strSql & "           FROM   NKSTRA" & vbCrLf
                strSql = strSql & "          WHERE   DATKB     = '1'" & vbCrLf
                strSql = strSql & "            AND   AKAKROKB  = '1'" & vbCrLf
                strSql = strSql & "            AND   JDNNO     = '" & Trim$(strJdnno) & "'" & vbCrLf
                strSql = strSql & "            AND   JDNLINNO  = '" & Trim$(strJdnlinno) & "'" & vbCrLf
                strSql = strSql & "            AND KDNNO NOT IN" & vbCrLf
                strSql = strSql & "                (" & vbCrLf
                strSql = strSql & "                 SELECT  MOTKDNNO" & vbCrLf
                strSql = strSql & "                   FROM  NKSTRA" & vbCrLf
                strSql = strSql & "                  WHERE  JDNNO     = '" & Trim$(strJdnno) & "'" & vbCrLf
                strSql = strSql & "                    AND  JDNLINNO  = '" & Trim$(strJdnlinno) & "'" & vbCrLf
                strSql = strSql & "                    AND  TRIM(MOTKDNNO) IS NOT NULL" & vbCrLf
                strSql = strSql & "                 )" & vbCrLf
                strSql = strSql & "         GROUP BY DKBID , UPDID" & vbCrLf
                strSql = strSql & "    ) NKS" & vbCrLf
                strSql = strSql & "    ," & vbCrLf
                strSql = strSql & "    (" & vbCrLf
                strSql = strSql & "          SELECT  SUM(NYUKN) AS NYUKN" & vbCrLf
                strSql = strSql & "          ,   CASE    WHEN   DKBID = '01' THEN  '4'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '02' THEN  '5'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '03' THEN  '6'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '04' THEN  '1'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '05' THEN  '8'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '06' THEN  '3'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '07' THEN  '9'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '08' THEN  '7'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '09' THEN  '-1'" & vbCrLf
                strSql = strSql & "                      WHEN   DKBID = '99' THEN  '2'" & vbCrLf
                strSql = strSql & "              END AS SEQ" & vbCrLf
                strSql = strSql & "          ,   DKBID" & vbCrLf
                strSql = strSql & "          ,   UPDID" & vbCrLf
                strSql = strSql & "          ,   MAX(TEGDT) AS TEGDT" & vbCrLf
                strSql = strSql & "          ,   NYUKB" & vbCrLf
              '*** 2009/10/09 ADD START FKS)NAKATA
                strSql = strSql & "          ,   MAX(TRA.UDNDT) AS UDNDT" & vbCrLf
              '*** 2009/10/09 ADD E.N.D FKS)NAKATA
                strSql = strSql & "        FROM  UDNTRA TRA" & vbCrLf
                strSql = strSql & "             ,UDNTHA THA" & vbCrLf
                strSql = strSql & "       WHERE  TRA.DENKB    =   '8'" & vbCrLf
                strSql = strSql & "         AND  TRA.DATKB    =   '1'" & vbCrLf
                strSql = strSql & "         AND  TRA.AKAKROKB =   '1'" & vbCrLf
                strSql = strSql & "         AND  TRA.KESIKB   =   '9'" & vbCrLf
                strSql = strSql & "         AND  TRA.DKBID   !=  '09'" & vbCrLf
                strSql = strSql & "         AND  TRA.OKRJONO  =   '" & strOkrjono & "'" & vbCrLf
                strSql = strSql & "         AND  TRA.DATNO    =   THA.DATNO" & vbCrLf
                strSql = strSql & "         AND  THA.NYUCD    = '2'" & vbCrLf
                strSql = strSql & "         AND  THA.FRNKB    = '0'" & vbCrLf
                strSql = strSql & "         AND  TRA.DATNO IN" & vbCrLf
                strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
                strSql = strSql & "                FROM  UDNTRA" & vbCrLf
                strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
                strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
                strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
                strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
                strSql = strSql & "            )" & vbCrLf
                strSql = strSql & "       GROUP BY DKBID ,UPDID ,TEGDT ,NYUKB" & vbCrLf
                strSql = strSql & "       ORDER BY SEQ" & vbCrLf
                strSql = strSql & "    )UDN" & vbCrLf
                strSql = strSql & " WHERE  NKS.UPDID(+) = UDN.UPDID" & vbCrLf
                strSql = strSql & "   AND    NKS.DKBID(+) = UDN.DKBID" & vbCrLf
                strSql = strSql & " ORDER BY UDN.SEQ"


                'ﾃﾞｰﾀ取得
                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
                Do While CF_Ora_EOF(Usr_Ody) = False
                    
                    
                    ReDim Preserve ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
                    
                        With ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
                        
                            .SEQ = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SEQ", ""))
                            .ZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ZANKN", ""))
                            .DKBID = Format(CStr(CF_Ora_GetDyn(Usr_Ody, "DKBID", "")), "00")
                            .UPDID = Format(CStr(CF_Ora_GetDyn(Usr_Ody, "UPDID", "")), "00")
                        '**** 2009/09/16 ADD START FKS)NAKATA
                        '入金区分
                            .NYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
                        '**** 2009/09/16 ADD E.N.D FKS)NAKATA
                        '**** 2009/10/09 ADD START FKS)NAKATA
                        '売上日(入金日)
                            .UDNDT = CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")
                        '**** 2009/10/09 ADD E.N.D FKS)NAKATA
                            .OKRJONO = strOkrjono
                            
                        End With

                    ARY_NYUKN_KS_CNT = ARY_NYUKN_KS_CNT + 1
    
                    Usr_Ody.Obj_Ody.MoveNext
    
                Loop
                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
                        
            End If
            

END_UdntraNyukn:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Sub

ERR_UdntraNyukn:
    Call SSSWIN_LOGWRT("getUdntraNyukn_ERROR")
    GoTo END_UdntraNyukn

End Sub

'2009/09/07 ADD START FKS)NAKATA
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function F_Util_GET_TANMTA_TANCLAKB
'   概要：  営業担当フラグを取得
'   引数：　pot_strTANCD       : 担当者コード
'       ：　pot_strKEIBMNCD    : 営業担当フラグ
'   戻値：　0:正常終了 9:異常終了
'   備考：
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, _
                                           ByRef pot_strTANCLAKB As String) As Integer

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String

On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
    
    F_Util_GET_TANMTA_TANCLAKB = 9
    
    pot_strTANCLAKB = ""
    
    '担当者Ｍ
    strSql = ""
    strSql = strSql & " SELECT TANCLAKB "
    strSql = strSql & " FROM TANMTA "
    strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
    Else
        GoTo END_F_Util_GET_TANMTA_TANCLAKB:
    End If

    F_Util_GET_TANMTA_TANCLAKB = 0
    
END_F_Util_GET_TANMTA_TANCLAKB:
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_F_Util_GET_TANMTA_TANCLAKB:
    GoTo END_F_Util_GET_TANMTA_TANCLAKB
    
End Function
'2009/09/07 ADD E.N.D FKS)NAKATA
