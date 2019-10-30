VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSSUB 
   BorderStyle     =   1  '固定(実線)
   Caption         =   "差額入金登録"
   ClientHeight    =   4680
   ClientLeft      =   6540
   ClientTop       =   3525
   ClientWidth     =   9450
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "FR_SSSSUB.frx":0000
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   ScaleHeight     =   4680
   ScaleWidth      =   9450
   Begin VB.PictureBox img_bklight 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'なし
      Height          =   330
      Index           =   0
      Left            =   2280
      Picture         =   "FR_SSSSUB.frx":030A
      ScaleHeight     =   330
      ScaleWidth      =   300
      TabIndex        =   37
      Top             =   4965
      Width           =   300
   End
   Begin VB.PictureBox img_bklight 
      AutoSize        =   -1  'True
      BorderStyle     =   0  'なし
      Height          =   330
      Index           =   1
      Left            =   2640
      Picture         =   "FR_SSSSUB.frx":0494
      ScaleHeight     =   330
      ScaleWidth      =   300
      TabIndex        =   36
      Top             =   4965
      Width           =   300
   End
   Begin VB.TextBox txt_BDkouza 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   2
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   10
      Top             =   3360
      Width           =   1215
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   2
      Left            =   315
      MaxLength       =   2
      TabIndex        =   9
      Top             =   3360
      Width           =   330
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   2
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   11
      Top             =   3360
      Width           =   1515
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Index           =   2
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   12
      Top             =   3360
      Width           =   2430
   End
   Begin VB.TextBox txt_BDkouza 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   1
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   6
      Top             =   3045
      Width           =   1215
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   1
      Left            =   315
      MaxLength       =   2
      TabIndex        =   5
      Top             =   3045
      Width           =   330
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   1
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   7
      Top             =   3045
      Width           =   1515
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Index           =   1
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   8
      Top             =   3045
      Width           =   2430
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   4  '全角ひらがな
      Index           =   0
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   4
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2730
      Width           =   2430
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   3
      Text            =   "9,999,999"
      Top             =   2730
      Width           =   1515
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   315
      MaxLength       =   2
      TabIndex        =   1
      Text            =   "99"
      Top             =   2730
      Width           =   330
   End
   Begin VB.TextBox txt_BDkouza 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Index           =   0
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   2
      Text            =   "XXXXXXXXX1"
      Top             =   2730
      Width           =   1215
   End
   Begin VB.TextBox txt_HDkouza 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      IMEMode         =   2  'ｵﾌ
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   0
      Text            =   "XXXXXXXXX1"
      Top             =   1815
      Width           =   1215
   End
   Begin Threed5.SSPanel5 pnl_head 
      Height          =   555
      Left            =   0
      TabIndex        =   14
      Top             =   0
      Width           =   9465
      _ExtentX        =   16695
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
         Left            =   7455
         TabIndex        =   15
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
      Begin VB.Image img_gyoin 
         Height          =   330
         Left            =   870
         Picture         =   "FR_SSSSUB.frx":061E
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_gyodel 
         Height          =   330
         Left            =   1230
         Picture         =   "FR_SSSSUB.frx":07A8
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_regist 
         Height          =   330
         Left            =   510
         Picture         =   "FR_SSSSUB.frx":0932
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_exit 
         Height          =   330
         Left            =   150
         Picture         =   "FR_SSSSUB.frx":0F84
         Top             =   90
         Width           =   360
      End
      Begin VB.Image img_showwnd 
         Height          =   330
         Left            =   1590
         Picture         =   "FR_SSSSUB.frx":110E
         Top             =   90
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 pnl_tokseicd 
      Height          =   330
      Left            =   315
      TabIndex        =   16
      Top             =   1365
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
      Caption         =   "請求先"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 pnl_nyudt 
      Height          =   330
      Left            =   315
      TabIndex        =   17
      Top             =   1050
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
      Caption         =   "入金日"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 pnl_opeid 
      Height          =   330
      Left            =   4785
      TabIndex        =   18
      Top             =   720
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
   Begin Threed5.SSCommand5 cmd_HDkouza 
      Height          =   330
      Left            =   315
      TabIndex        =   19
      TabStop         =   0   'False
      Top             =   1815
      Width           =   1260
      _ExtentX        =   2223
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
      Caption         =   "勘定口座"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_BDkouza 
      Height          =   330
      Left            =   1560
      TabIndex        =   20
      TabStop         =   0   'False
      Top             =   2415
      Width           =   1215
      _ExtentX        =   2143
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
      Caption         =   "*勘定口座 "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 cmd_BDdkbid 
      Height          =   330
      Left            =   315
      TabIndex        =   13
      TabStop         =   0   'False
      Top             =   2415
      Width           =   1260
      _ExtentX        =   2223
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
      Caption         =   "*入金種別"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 pnl_nyukn 
      Height          =   330
      Left            =   2760
      TabIndex        =   21
      Top             =   2415
      Width           =   1515
      _ExtentX        =   2672
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
      Caption         =   "*入金額 "
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 pnl_lincma 
      Height          =   330
      Left            =   4260
      TabIndex        =   22
      Top             =   2415
      Width           =   2430
      _ExtentX        =   4286
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
      Caption         =   "備考"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 pnl_tail 
      Height          =   735
      Left            =   0
      TabIndex        =   23
      Top             =   3960
      Width           =   9465
      _ExtentX        =   16695
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
         Picture         =   "FR_SSSSUB.frx":1298
         ScaleHeight     =   330
         ScaleWidth      =   300
         TabIndex        =   24
         Top             =   135
         Width           =   300
      End
      Begin Threed5.SSPanel5 pnl_msg 
         Height          =   465
         Left            =   615
         TabIndex        =   25
         Top             =   135
         Width           =   8190
         _ExtentX        =   14446
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
            TabIndex        =   26
            TabStop         =   0   'False
            Text            =   "エラーやプロンプトのメッセージが出力されるところです。"
            Top             =   90
            Width           =   7680
         End
      End
   End
   Begin Threed5.SSPanel5 pnl_hihyoji 
      Height          =   3225
      Left            =   180
      TabIndex        =   27
      Top             =   645
      Width           =   9075
      _ExtentX        =   16007
      _ExtentY        =   5689
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
      Caption         =   "表示限定テキストボックス設定用パネル"
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Index           =   2
         Left            =   450
         MaxLength       =   10
         TabIndex        =   35
         Top             =   2715
         Width           =   945
      End
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Index           =   1
         Left            =   450
         MaxLength       =   10
         TabIndex        =   34
         Top             =   2400
         Width           =   945
      End
      Begin VB.TextBox txt_tokseicd 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1380
         MaxLength       =   5
         TabIndex        =   33
         Text            =   "XXXX5"
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox txt_tokseinma 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   2580
         MaxLength       =   60
         TabIndex        =   32
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
         Top             =   720
         Width           =   6390
      End
      Begin VB.TextBox txt_nyudt 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   1380
         MaxLength       =   10
         TabIndex        =   31
         Text            =   "YYYY/MM/DD"
         Top             =   405
         Width           =   1215
      End
      Begin VB.TextBox txt_opeid 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   5850
         MaxLength       =   8
         TabIndex        =   30
         Text            =   "XXXXXXX8"
         Top             =   75
         Width           =   915
      End
      Begin VB.TextBox txt_openm 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Left            =   6750
         MaxLength       =   20
         TabIndex        =   29
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   75
         Width           =   2220
      End
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  'ﾌﾗｯﾄ
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  'ｵﾌ
         Index           =   0
         Left            =   450
         MaxLength       =   10
         TabIndex        =   28
         Text            =   "XXXXX6"
         Top             =   2085
         Width           =   945
      End
   End
   Begin VB.Image img_bkshowwnd 
      Height          =   330
      Index           =   1
      Left            =   1800
      Picture         =   "FR_SSSSUB.frx":1422
      Top             =   5190
      Width           =   360
   End
   Begin VB.Image img_bkexit 
      Height          =   330
      Index           =   1
      Left            =   360
      Picture         =   "FR_SSSSUB.frx":15AC
      Top             =   5190
      Width           =   360
   End
   Begin VB.Image img_bkregist 
      Height          =   330
      Index           =   1
      Left            =   720
      Picture         =   "FR_SSSSUB.frx":1736
      Top             =   5190
      Width           =   360
   End
   Begin VB.Image img_bkgyodel 
      Height          =   330
      Index           =   1
      Left            =   1440
      Picture         =   "FR_SSSSUB.frx":1D88
      Top             =   5190
      Width           =   360
   End
   Begin VB.Image img_bkgyoin 
      Height          =   330
      Index           =   1
      Left            =   1080
      Picture         =   "FR_SSSSUB.frx":1F12
      Top             =   5190
      Width           =   360
   End
   Begin VB.Image img_bkshowwnd 
      Height          =   330
      Index           =   0
      Left            =   1650
      Picture         =   "FR_SSSSUB.frx":209C
      Top             =   4800
      Width           =   360
   End
   Begin VB.Image img_bkexit 
      Height          =   330
      Index           =   0
      Left            =   210
      Picture         =   "FR_SSSSUB.frx":2226
      Top             =   4800
      Width           =   360
   End
   Begin VB.Image img_bkregist 
      Height          =   330
      Index           =   0
      Left            =   570
      Picture         =   "FR_SSSSUB.frx":23B0
      Top             =   4800
      Width           =   360
   End
   Begin VB.Image img_bkgyodel 
      Height          =   330
      Index           =   0
      Left            =   1290
      Picture         =   "FR_SSSSUB.frx":2A02
      Top             =   4800
      Width           =   360
   End
   Begin VB.Image img_bkgyoin 
      Height          =   330
      Index           =   0
      Left            =   930
      Picture         =   "FR_SSSSUB.frx":2B8C
      Top             =   4800
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
      Begin VB.Menu mnu_bdinitdsp 
         Caption         =   "明細行初期化"
      End
      Begin VB.Menu mnu_gyodel 
         Caption         =   "明細行削除(&T)"
         Shortcut        =   ^T
      End
      Begin VB.Menu mnu_gyoin 
         Caption         =   "明細行挿入(&I)"
         Shortcut        =   ^I
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
Attribute VB_Name = "FR_SSSSUB"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim blnUsableEvent  As Boolean  'ｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ(汎用)
Dim intChkKb        As Integer  'チェック区分(1:チェック
                                '             2:チェック(前回から変更時のみ)
                                '             3:チェック(フォーカスは移動しない)

Dim strHDkouza      As String   'ヘッダの勘定口座の値を格納
Dim CurrentLine     As Integer  'フォーカスのある行番号をセット(ヘッダの時は-1）


Dim intEventUkai    As Integer  'ｲﾍﾞﾝﾄを迂回するかどうかのﾌﾗｸﾞ(汎用)


'フォームロード時
Private Sub Form_Load()
    'WINDOW 位置設定
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    '初期化
    initForm
    '項目初期化
    initItem
End Sub

'フォームアンロード時
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    '●終了確認のMSG
    If chkLineNull(0) = True Then
        If chkLineNull(1) = True Then
            If chkLineNull(2) = True Then
                If showMsg("0", "_ENDCM", 0) = vbNo Then
                    Cancel = vbCancel
                    Exit Sub
                Else
                    Unload Me '●PG終了
                    Exit Sub
                End If
            End If
        End If
    End If
    
    If showMsg("0", "_ENDCK", 0) = vbNo Then
        Cancel = vbCancel
        Exit Sub
    End If
    
    Unload Me '●PG終了
End Sub




Private Sub initForm()
    '★ひとまず行追加は保留
    mnu_gyoin.Visible = False
    img_gyoin.Visible = False
    
    '運用日の表示
    pnl_unydt.Caption = CNV_DATE(gstrUnydt)
    
    '入金日の表示
    txt_nyudt.Text = CNV_DATE(gstrKesidt)
    
    '請求先の表示
    txt_tokseicd.Text = DB_TOKMTA.TOKSEICD
    txt_tokseinma.Text = DB_TOKMTA.TOKNMA
    
    '入力担当者の表示
    txt_opeid.Text = FR_SSSMAIN.txt_opeid.Text
    txt_openm.Text = FR_SSSMAIN.txt_openm.Text
    
    '表示限定テキストボックス設定用パネルを隠す
    pnl_hihyoji.Caption = ""
    pnl_hihyoji.BevelOuter = ssBevelNone
End Sub

'項目の初期化
Private Sub initItem()
    txt_HDkouza.Text = "          "     '10byte space
    txt_HDkouza.ForeColor = vbBlack
    txt_HDkouza.BackColor = vbWhite
    strHDkouza = ""
    
    blnUsableEvent = True
    intChkKb = 2
    
    initBody
End Sub

'明細部の削除
Private Sub initBody()
    Dim i As Integer
    For i = 0 To 2
        initLine (i)
    Next i
End Sub

'行の初期化
Private Sub initLine(intRow As Integer)
    txt_BDdkbid(intRow).Text = "  "     '2byte space
    txt_BDdkbnm(intRow).Text = ""
    txt_BDkouza(intRow).Text = "          "     '10byte space
    txt_BDnyukn(intRow).Text = ""
    txt_BDlincma(intRow).Text = "                    "  '20byte space
    
    txt_BDdkbid(intRow).ForeColor = vbBlack
    txt_BDdkbid(intRow).BackColor = vbWhite
    txt_BDkouza(intRow).ForeColor = vbBlack
    txt_BDkouza(intRow).BackColor = vbWhite
    txt_BDnyukn(intRow).ForeColor = vbBlack
    txt_BDnyukn(intRow).BackColor = vbWhite
    txt_BDlincma(intRow).ForeColor = vbBlack
    txt_BDlincma(intRow).BackColor = vbWhite
    
    Call initSubFormType(intRow)
End Sub

Private Function chkHDkouza() As Boolean
    chkHDkouza = False
    
    'チェック区分が1,3のとき、あるいは変更されていたらチェックを行う
    If intChkKb = 1 Or txt_HDkouza.Text <> strHDkouza Or intChkKb = 3 Then
        
        '空白入力時はチェックしない
        If Trim(txt_HDkouza.Text) = "" Then Exit Function
        
        '●名称ﾏｽﾀから勘定口座名称を取得
        Select Case GET_MEIMTA_KANKOZ(txt_HDkouza.Text)
            '存在するとき
            Case 0:
                txt_HDkouza.ForeColor = vbBlack
                chkHDkouza = True
                

            '存在するが、削除レコードの場合
            Case 8:
                'チェック区分が3でないとき、メッセージを表示
                If intChkKb <> 3 Then
                    Call showMsg("2", "URKET73_039", "0")   '●削除済みレコードです
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus
                End If

            
            '存在しない時
            Case 9:
                'チェック区分が3でないとき、メッセージを表示
                If intChkKb <> 3 Then
                    Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus
                End If
        End Select
    End If
    strHDkouza = txt_HDkouza.Text
    intChkKb = 2            '●基本は変更時にチェック
End Function

'明細部勘定口座の入力チェック
Private Function chkBDkouza(Index As Integer) As Boolean
    chkBDkouza = False
    
    'チェック区分が1のとき、あるいは変更されていたらチェックを行う。
    If intChkKb = 1 Or txt_BDkouza(Index).Text <> gtypeFR_SUB(Index).SUB_KOUZA Then
        
        '空白入力時はチェックしない
        If Trim(txt_BDkouza(Index).Text) <> "" Then
        
            '●名称ﾏｽﾀから勘定口座名称を取得
            Select Case GET_MEIMTA_KANKOZ(txt_BDkouza(Index).Text)
                '存在するとき
                Case 0:
                    txt_BDkouza(Index).ForeColor = vbBlack
                    chkBDkouza = True
                    

            '存在するが、削除レコードの場合
            Case 8:
                    Call showMsg("2", "URKET73_039", "0")   '●削除済みレコードです
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus

            
                '存在しない時
                Case 9:
                    Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
                    txt_BDkouza(Index).ForeColor = vbRed
                    txt_BDkouza(Index).SetFocus
            End Select
        End If
    End If
    
    gtypeFR_SUB(Index).SUB_KOUZA = txt_BDkouza(Index).Text
    intChkKb = 2            '●基本は変更時にチェック
End Function

'入金種別の入力チェック
Private Function chkBDdkbid(Index As Integer) As Boolean
    Dim tmp As String
    
    chkBDdkbid = False
    
    'チェック区分が1のとき、あるいは変更されていたらチェックを行う
    If intChkKb = 1 Or Trim(txt_BDdkbid(Index).Text) <> Trim(gtypeFR_SUB(Index).SUB_DKBID) Then
        txt_BDdkbnm(Index).Text = ""
        
        '空白入力時はチェックしない
        If Trim(txt_BDdkbid(Index).Text) <> "" Then
        
            '入力値が2byteで無い時は0埋め
            blnUsableEvent = False
            txt_BDdkbid(Index).Text = Format((txt_BDdkbid(Index).Text), "00")
            blnUsableEvent = True
            
            '●SYSTBDから入金種別名称を取得
            tmp = getDkbnm(txt_BDdkbid(Index).Text, Index)
            If tmp <> "" Then
                '存在するとき
                txt_BDdkbid(Index).ForeColor = vbBlack
                txt_BDdkbnm(Index).Text = tmp
                'ヘッダに勘定口座が指定されていて、かつ明細に勘定口座が入力されていなければコピー
                intChkKb = 3    'チェックのみ
                If txt_HDkouza.Text <> "" And chkHDkouza = True Then
                    blnUsableEvent = False
                    
                    If Trim(txt_BDkouza(Index).Text) = "" Then
                        txt_BDkouza(Index).Text = txt_HDkouza.Text
                    End If

                    blnUsableEvent = True
                End If
                chkBDdkbid = True
            
            '存在しない時
            Else
                Call showMsg("2", "RNOTFOUND", "0")    '●該当データなし
                txt_BDdkbid(Index).ForeColor = vbRed
                txt_BDdkbid(Index).SetFocus
            End If
        
        '空白のとき、登録処理を実行する
        Else
            gtypeFR_SUB(Index).SUB_DKBID = ""
            mnu_regist_Click
        End If
    End If
    
    gtypeFR_SUB(Index).SUB_DKBID = txt_BDdkbid(Index).Text
    intChkKb = 2            '●基本は変更時にチェック
End Function

'行単位に入力チェックを行う
'intPatternが0の時は必ずチェック
Private Function chkLine(intRow As Integer, Optional intPattern As Integer = 1) As Boolean
    chkLine = False
    
    CurrentLine = intRow
    '行にいずれかに項目が入力されていたら、別の必須項目の入力チェックを行う
    If Trim(txt_BDdkbid(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" _
        Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDlincma(intRow).Text) <> "" Or intPattern = 0 Then
        
        If Trim(txt_BDdkbid(intRow).Text) = "" Then
            showMsg "0", "_COMPLETEC", "0"       '●必須項目未入力のMSG
            txt_BDdkbid(intRow).ForeColor = vbRed
            txt_BDdkbid(intRow).SetFocus
            Exit Function
        Else
            intChkKb = 1
            If chkBDdkbid(intRow) = False Then
                Exit Function
            End If
        End If
        
        If Trim(txt_BDkouza(intRow).Text) = "" Then
            txt_BDkouza(intRow).ForeColor = vbRed
            txt_BDkouza(intRow).SetFocus
            showMsg "0", "_COMPLETEC", "0"
            Exit Function
        Else
            intChkKb = 1
            If chkBDkouza(intRow) = False Then
                Exit Function
            End If
        End If
        
        If Trim(txt_BDnyukn(intRow).Text) = "" Then
            showMsg "0", "_COMPLETEC", "0"
            txt_BDnyukn(intRow).ForeColor = vbRed
            txt_BDnyukn(intRow).SetFocus
            Exit Function
        End If
    End If
    
    chkLine = True
End Function

'行がNULLがどうかを確認
Private Function chkLineNull(intRow As Integer) As Boolean
    chkLineNull = False
    
    If Trim(txt_BDdkbid(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDkouza(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDnyukn(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDlincma(intRow).Text) <> "" Then Exit Function
    
    chkLineNull = True
End Function



'終了ボタンクリック時
Private Sub img_exit_Click()
    mnu_exit_Click
End Sub
'終了マウスダウン時
Private Sub img_exit_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(1).Picture
End Sub
'終了マウスムーブ時
Private Sub img_exit_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "メニューに戻ります。"
End Sub
'終了マウスアップ時
Private Sub img_exit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(0).Picture
End Sub

'行削除ボタンクリック時
Private Sub img_gyodel_Click()
    If mnu_gyodel.Enabled = False Then Exit Sub
    mnu_gyodel_Click
End Sub
'行削除マウスダウン時
Private Sub img_gyodel_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyodel.Picture = img_bkgyodel(1).Picture
End Sub
'行削除マウスムーブ時
Private Sub img_gyodel_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "明細を一行削除します。"
End Sub
'行削除マウスアップ時
Private Sub img_gyodel_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyodel.Picture = img_bkgyodel(0).Picture
End Sub

'行挿入ボタンクリック時
Private Sub img_gyoin_Click()
    If mnu_gyoin.Enabled = False Then Exit Sub
    mnu_gyoin_Click
End Sub
'行挿入マウスダウン時
Private Sub img_gyoin_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyoin.Picture = img_bkgyoin(1).Picture
End Sub
'行挿入マウスムーブ時
Private Sub img_gyoin_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "明細行を挿入します。"
End Sub
'行挿入マウスアップ時
Private Sub img_gyoin_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyoin.Picture = img_bkgyoin(0).Picture
End Sub

'登録ボタンクリック時
Private Sub img_regist_Click()
    mnu_regist_Click
End Sub
'登録マウスダウン時
Private Sub img_regist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_regist.Picture = img_bkregist(1).Picture
End Sub
'登録マウスムーブ時
Private Sub img_regist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "登録します。"
End Sub
'登録マウスアップ時
Private Sub img_regist_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_regist.Picture = img_bkregist(0).Picture
End Sub

'検索ボタンクリック時
Private Sub img_showwnd_Click()
    mnu_showwnd_Click
End Sub
'検索マウスダウン時
Private Sub img_showwnd_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(1).Picture
End Sub
'検索マウスムーブ時
Private Sub img_showwnd_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "ウィンドウを表示します。"
End Sub
'検索マウスアップ時
Private Sub img_showwnd_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(0).Picture
End Sub

'明細行初期化メニュークリック時
Private Sub mnu_bdinitdsp_Click()
    '行の消去を行う
    initLine CurrentLine
    txt_BDdkbid(CurrentLine).SetFocus
    txt_BDdkbid(CurrentLine).BackColor = vbYellow
End Sub

'終了メニュークリック時
Private Sub mnu_exit_Click()
    Unload Me
End Sub

'行削除メニュークリック時
Private Sub mnu_gyodel_Click()
    Dim i As Integer
    
    '行の消去を行う
    initLine CurrentLine
    '下段の行を現在行に移動
    If CurrentLine < 2 Then
        For i = CurrentLine To 1 - CurrentLine
        '下段の行が空白でなかったら、上段にコピー
            If chkLineNull(i + 1) = False Then
                blnUsableEvent = False
                
                txt_BDdkbid(i).Text = txt_BDdkbid(i + 1).Text
                txt_BDdkbnm(i).Text = txt_BDdkbnm(i + 1).Text
                txt_BDkouza(i).Text = txt_BDkouza(i + 1).Text
                txt_BDnyukn(i).Text = txt_BDnyukn(i + 1).Text
                txt_BDlincma(i).Text = txt_BDlincma(i + 1).Text
                Call moveSubFormType(i)   '構造体の値もコピー
                initLine i + 1     '下段の情報を削除
                
                blnUsableEvent = True
            End If
        Next i
    End If
    txt_BDdkbid(CurrentLine).SetFocus
    txt_BDdkbid(CurrentLine).BackColor = vbYellow
End Sub

'行追加メニュークリック時
Private Sub mnu_gyoin_Click()
    '
End Sub

'画面初期化メニュークリック時
Private Sub mnu_initdsp_Click()
    '初期化
    initItem
    'ヘッダ部勘定口座にフォーカスを移動
    CurrentLine = -1    'ヘッダを示す-1をセット
    txt_HDkouza.SetFocus
    txt_HDkouza.BackColor = vbYellow
End Sub

'登録メニュークリック時
Private Sub mnu_regist_Click()
    Dim p As Integer
    Dim i As Integer
    
    
    intEventUkai = 1
    p = CurrentLine
    If chkLine(0, 0) = False Then
        intEventUkai = 0
        Exit Sub  '1行目は必須入力
    End If
    If chkLine(1) = False Then
        intEventUkai = 0
        Exit Sub
    End If
    If chkLine(2) = False Then
        intEventUkai = 0
        Exit Sub
    End If
    CurrentLine = p
    intEventUkai = 0

    
    
    '●登録確認のMSG
    If showMsg("0", "_UPDATE", 0) = vbYes Then
        '★権限の判断
        If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
            showMsg "2", "UPDAUTH", "0"
        Else
            Me.MousePointer = vbHourglass
            If F_UPDATE_SUB = 1 Then
                mnu_initdsp_Click   '画面表示の初期化
            Else
                '●更新処理失敗時
                MsgBox "更新に失敗しました。", vbCritical, "更新エラー"
            End If
            Me.MousePointer = vbDefault
        End If
    Else
        If CurrentLine <> -1 Then
            txt_BDdkbid(CurrentLine).SetFocus
        End If
    End If
End Sub

'検索メニュークリック時
Private Sub mnu_showwnd_Click()
    'ヘッダ部勘定口座にフォーカスがあるとき
    If Me.ActiveControl.Name = txt_HDkouza.Name Then
        blnUsableEvent = False
        cmd_HDkouza_Click
        blnUsableEvent = True
        
    '明細部にフォーカスがあるとき
    ElseIf CurrentLine >= 0 Then
        '入金種別のとき
        If Me.ActiveControl.Name = txt_BDdkbid(CurrentLine).Name Then
            blnUsableEvent = False
            cmd_BDdkbid_Click
            blnUsableEvent = True
        
        '勘定口座のとき
        ElseIf Me.ActiveControl.Name = txt_BDkouza(CurrentLine).Name Then
            blnUsableEvent = False
            cmd_BDkouza_Click
            blnUsableEvent = True
        End If
    End If
End Sub

'ヘッダパネルマウスムーブ時
Private Sub pnl_head_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'ヒントの表示を初期化する
    img_light.Picture = img_bklight(0).Picture
    txt_message.Text = ""
End Sub






'=======================================================入金種別(明細)必須項目=======================================================


Private Sub txt_BDdkbid_Change(Index As Integer)
    Dim p As Integer
    
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub
        
    'カーソルが右端に移動した時は、次の項目へ移動
    If txt_BDdkbid(Index).SelStart = 2 Then
        intChkKb = 1                                '★入金種別の入力チェック
        txt_BDkouza(Index).SetFocus                 '明細部勘定口座項目へ移動
    End If
    
End Sub

Private Sub txt_BDdkbid_GotFocus(Index As Integer)
    '全選択状態にする
    txt_BDdkbid(Index).SelStart = 0
    txt_BDdkbid(Index).SelLength = 2
    '背景色を黄色にする
    txt_BDdkbid(Index).BackColor = vbYellow
    '明細行コマンドを実行可とする
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True
    '現在行番号を保存
    CurrentLine = Index
End Sub

Private Sub txt_BDdkbid_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '右矢印押下時
    If KeyCode = vbKeyRight Then
        If txt_BDdkbid(Index).SelStart < (2 - 1) Then
            txt_BDdkbid(Index).SelStart = txt_BDdkbid(Index).SelStart + 1

        'カーソルが右端に来たら次の項目へ移動
        Else
            intChkKb = 2                                '★入金種別の入力チェック（変更時のみ）
            txt_BDkouza(Index).SetFocus                 '明細部勘定口座項目へ移動
        End If
        txt_BDdkbid(Index).SelLength = 1
    
    'Backspace or 左矢印押下時
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDdkbid(Index).SelStart > 0 Then
            txt_BDdkbid(Index).SelStart = txt_BDdkbid(Index).SelStart - 1
            
        'カーソルが左端に来たら前の項目へ移動
        Else
            'Backspaceの時は、入力値が空白の時、前項目へ移動
            If Trim(txt_BDdkbid(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            
            intChkKb = 2                                '★入金種別の入力チェック（変更時のみ）
            If Index = 0 Then
                txt_HDkouza.SetFocus                    'ヘッダ部勘定口座項目へ移動
            Else
                txt_BDlincma(Index - 1).SetFocus        '備考項目へ移動
            End If
        End If
        txt_BDdkbid(Index).SelLength = 1
        
    '上矢印押下時
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 2                                '★入金種別の入力チェック（変更時のみ）
        If Index = 0 Then
            txt_HDkouza.SetFocus                    'ヘッダ部勘定口座項目へ移動
        Else
            txt_BDdkbid(Index - 1).SetFocus        '備考項目へ移動
        End If
        
    '下矢印押下時
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 2                                '★入金種別の入力チェック（変更時のみ）
        If Index < 2 Then
            txt_BDdkbid(Index + 1).SetFocus               '明細部勘定口座項目へ移動
        End If
        
    'Enter押下時
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '★入金種別の入力チェック
        txt_BDkouza(Index).SetFocus                 '明細部勘定口座項目へ移動
        
    'Delete押下時
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDdkbid_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii = vbKeyBack Then Exit Sub
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_BDdkbid_LostFocus(Index As Integer)
    'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
    If blnUsableEvent = False Then Exit Sub
    
    '入力チェック
    chkBDdkbid Index
    '背景色を白に戻す
    txt_BDdkbid(Index).BackColor = vbWhite
End Sub


'=======================================================勘定口座(明細)必須項目=======================================================


Private Sub txt_BDkouza_Change(Index As Integer)
    Dim p As Integer
    
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub
    
    blnUsableEvent = False
    p = txt_BDkouza(Index).SelStart
    
    '全角を削除する
    txt_BDkouza(Index).Text = delZenkaku(txt_BDkouza(Index).Text)
    '入力値が10byteで無い時は空白埋め
    txt_BDkouza(Index).Text = txt_BDkouza(Index).Text & Space(10 - Len(txt_BDkouza(Index).Text))
    
    txt_BDkouza(Index).SelStart = p
    blnUsableEvent = True
    
    'カーソルが右端に移動した時は、次の項目へ移動
    If txt_BDkouza(Index).SelStart = 10 Then
        intChkKb = 1                                '★勘定口座ｺｰﾄﾞの入力チェック
        txt_BDnyukn(Index).SetFocus                     '入金額項目へ移動
    End If
    txt_BDkouza(Index).SelLength = 1
End Sub

Private Sub txt_BDkouza_GotFocus(Index As Integer)
    '先頭位置を選択状態にする
    txt_BDkouza(Index).SelStart = 0
    txt_BDkouza(Index).SelLength = 1
    '背景色を黄色にする
    txt_BDkouza(Index).BackColor = vbYellow
    '明細行コマンドを実行可とする
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True
    '現在行番号を保存
    CurrentLine = Index
End Sub

Private Sub txt_BDkouza_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '右矢印押下時
    If KeyCode = vbKeyRight Then
        If txt_BDkouza(Index).SelStart < (10 - 1) Then
            txt_BDkouza(Index).SelStart = txt_BDkouza(Index).SelStart + 1
            
        'カーソルが右端に来たら次の項目へ移動
        Else
            intChkKb = 2                                '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
            txt_BDnyukn(Index).SetFocus                 '入金額項目へ移動
        End If
        txt_BDkouza(Index).SelLength = 1
    
    'Backspace or 左矢印押下時
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDkouza(Index).SelStart > 0 Then
            txt_BDkouza(Index).SelStart = txt_BDkouza(Index).SelStart - 1
            
        'カーソルが左端に来たら前の項目へ移動
        Else
            'Backspaceの時は、入力値が空白の時、前項目へ移動
            If Trim(txt_BDkouza(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            intChkKb = 2                                '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
            txt_BDdkbid(Index).SetFocus                 '入金種別項目へ移動
        End If
        txt_BDkouza(Index).SelLength = 1
        
    '上矢印押下時
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 2                                '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
        If Index = 0 Then
            txt_HDkouza.SetFocus
        Else
            txt_BDkouza(Index - 1).SetFocus                    '入金種別項目へ移動
        End If
        
    '下矢印押下時
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 2                                '★勘定口座ｺｰﾄﾞの入力チェック（変更時のみ）
        If Index < 2 Then
            txt_BDkouza(Index + 1).SetFocus                     '入金額項目へ移動
        End If
        
    'Enter押下時
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '★勘定口座ｺｰﾄﾞの入力チェック
        txt_BDnyukn(Index).SetFocus                     '入金額項目へ移動
        
    'Delete押下時
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDkouza_KeyPress(Index As Integer, KeyAscii As Integer)
    'アルファベット小文字を大文字に変換する
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

Private Sub txt_BDkouza_LostFocus(Index As Integer)
    'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
    If blnUsableEvent = False Then Exit Sub
    
    '入力チェック(空白は無視)
    chkBDkouza Index
    '背景色を白に戻す
    txt_BDkouza(Index).BackColor = vbWhite
End Sub


'=======================================================備考(明細)=======================================================


Private Sub txt_BDlincma_Change(Index As Integer)
    Dim p As Integer
    
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub
    
    With txt_BDlincma(Index)
        blnUsableEvent = False
        p = .SelStart
        
        '入力値が10byteで無い時は空白埋め
        .Text = LeftWid$(.Text, 20)
        
        .SelStart = p
        blnUsableEvent = True
        
        'カーソルが右端に移動した時は、次の項目へ移動
        If .SelStart = 20 Then
            If Index < 2 Then
                txt_BDdkbid(Index + 1).SetFocus         '入金種別項目へ移動
            Else
                intChkKb = 2                            '★登録実行
                txt_HDkouza.SetFocus
            End If
        End If
        .SelLength = 1
        
        gtypeFR_SUB(Index).SUB_LINCMA = .Text
    End With
    
End Sub

Private Sub txt_BDlincma_GotFocus(Index As Integer)
    '先頭位置を選択状態にする
    txt_BDlincma(Index).SelStart = 0
    txt_BDlincma(Index).SelLength = 1
    '背景色を黄色にする
    txt_BDlincma(Index).BackColor = vbYellow
    '明細行コマンドを実行可とする
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '検索処理を実行不可とする
    mnu_showwnd.Enabled = False
    '現在行番号を保存
    CurrentLine = Index
End Sub

Private Sub txt_BDlincma_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '右矢印押下時
    If KeyCode = vbKeyRight Then
        If txt_BDlincma(Index).SelStart < 19 Then
            txt_BDlincma(Index).SelStart = txt_BDlincma(Index).SelStart + 1
            
        'カーソルが右端に来たら次の項目へ移動
        Else
            If Index < 2 Then
                txt_BDdkbid(Index + 1).SetFocus       '入金種別項目へ移動
            Else
                intChkKb = 1                          '★登録実行
                txt_HDkouza.SetFocus
            End If
        End If
        txt_BDlincma(Index).SelLength = 1
    
    'Backspace or 左矢印押下時
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDlincma(Index).SelStart > 0 Then
            txt_BDlincma(Index).SelStart = txt_BDlincma(Index).SelStart - 1
            
        'カーソルが左端に来たら前の項目へ移動
        Else
            'Backspaceの時は、入力値が空白の時、前項目へ移動
            If Trim(txt_BDlincma(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            intChkKb = 1                            '登録しない
            txt_BDnyukn(Index).SetFocus             '入金額項目へ移動
        End If
        txt_BDlincma(Index).SelLength = 1
        
    '上矢印押下時
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 1                                '登録しない
        If Index = 0 Then
            txt_HDkouza.SetFocus
        Else
            txt_BDlincma(Index - 1).SetFocus               '消込日項目へ移動
        End If
        
    '下矢印押下時
    ElseIf KeyCode = vbKeyDown Then
        If Index < 2 Then
            txt_BDlincma(Index + 1).SetFocus         '入金種別項目へ移動
        Else
            intChkKb = 2                            '★登録実行
            txt_HDkouza.SetFocus
        End If
        
    'Enter押下時
    ElseIf KeyCode = vbKeyReturn Then
        If Index < 2 Then
            txt_BDdkbid(Index + 1).SetFocus         '入金種別項目へ移動
        Else
            intChkKb = 2                            '★登録実行
            txt_HDkouza.SetFocus
        End If
        
    'Delete押下時
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDlincma_LostFocus(Index As Integer)
    '背景色を白に戻す
    txt_BDlincma(Index).BackColor = vbWhite
    '★登録実行
    If Index = 2 And intChkKb = 2 Then
        
        If intEventUkai = 0 Then
            mnu_regist_Click
        End If

    End If
    intChkKb = 1
End Sub


'=======================================================入金額(明細)必須項目=======================================================


'入金額項目変更時
Private Sub txt_BDnyukn_Change(Index As Integer)
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub
    
    With txt_BDnyukn(Index)
        blnUsableEvent = False
        '金額の桁数表示文字を付加
        
        If SSSVal(.Text) <> 0 Then
            .Text = Format(SSSVal(.Text), "#,###,##0")
        Else
            .Text = Format(.Text, "#,###,##0")
        End If
        .SelStart = Len(.Text)

        blnUsableEvent = True
    
        
        gtypeFR_SUB(Index).SUB_NYUKN = SSSVal(.Text)
    End With
End Sub

Private Sub txt_BDnyukn_GotFocus(Index As Integer)
    '全選択状態にする
    txt_BDnyukn(Index).SelStart = 0
    txt_BDnyukn(Index).SelLength = 9
    '背景色を黄色にする
    txt_BDnyukn(Index).BackColor = vbYellow
    '明細行コマンドを実行可とする
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '検索処理を実行不可とする
    mnu_showwnd.Enabled = False
    '現在行番号を保存
    CurrentLine = Index
End Sub

Private Sub txt_BDnyukn_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    With txt_BDnyukn(Index)
        
        '右矢印 or Space押下時
        If KeyCode = vbKeyRight Or KeyCode = vbKeySpace Then
            If .SelStart < 9 Then
                
                .SelStart = .SelStart + 1
                If Mid(.Text, .SelStart + 1, 1) = "," Then
                    .SelStart = .SelStart + 1
                End If

                
            'カーソルが右端に来たら次の項目へ移動
            Else
                txt_BDlincma(Index).SetFocus                 '備考項目へ移動
            End If
        
        'Backspace or 左矢印押下時
        ElseIf KeyCode = vbKeyLeft Then
            If .SelStart > 0 Then
                
                .SelStart = .SelStart - 1
                If Mid(.Text, .SelStart + 1, 1) = "," Then
                    .SelStart = .SelStart - 1
                End If
                
            'カーソルが左端に来たら前の項目へ移動
            Else
                txt_BDkouza(Index).SetFocus               '勘定口座項目へ移動
            End If
        
        '上矢印押下時
        ElseIf KeyCode = vbKeyUp Then
            If Index = 0 Then
                txt_HDkouza.SetFocus
            Else
                txt_BDnyukn(Index - 1).SetFocus               '勘定口座項目へ移動
            End If
            
        '下矢印押下時
        ElseIf KeyCode = vbKeyDown Then
            If Index < 2 Then
                txt_BDnyukn(Index + 1).SetFocus                 '備考項目へ移動
            End If
            
        'Enter押下時
        ElseIf KeyCode = vbKeyReturn Then
            txt_BDlincma(Index).SetFocus                 '備考項目へ移動
            
        ElseIf KeyCode = vbKeyDelete Then
            Exit Sub
        End If
    
    End With
    KeyCode = 0
End Sub

Private Sub txt_BDnyukn_KeyPress(Index As Integer, KeyAscii As Integer)
    'Backspace, マイナス記号は入力できる
    If KeyAscii = vbKeyBack Then Exit Sub
    If KeyAscii = 45 And Left(txt_BDnyukn(Index).Text, 1) <> "-" Then Exit Sub
    

    If SSSVal(txt_BDnyukn(Index)) >= 9999999 Or SSSVal(txt_BDnyukn(Index)) <= -999999 Then
        KeyAscii = 0
        Exit Sub
    End If

    
    '数値のみ入力可とする
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_BDnyukn_LostFocus(Index As Integer)
    '文字色を黒に戻す
    txt_BDnyukn(Index).ForeColor = vbBlack
    '背景色を白に戻す
    txt_BDnyukn(Index).BackColor = vbWhite
End Sub


'=======================================================勘定口座(ヘッダ)=======================================================

Private Sub txt_HDkouza_Change()
    Dim p As Integer
    
    'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
    If blnUsableEvent = False Then Exit Sub
    
    blnUsableEvent = False
    p = txt_HDkouza.SelStart
    
    '全角を削除する
    txt_HDkouza.Text = delZenkaku(txt_HDkouza.Text)
    '入力値が10byteで無い時は空白埋め
    txt_HDkouza.Text = txt_HDkouza.Text & Space(10 - Len(txt_HDkouza.Text))
    
    txt_HDkouza.SelStart = p
    blnUsableEvent = True
    
    'カーソルが右端に移動した時は、次の項目へ移動
    If txt_HDkouza.SelStart = 10 Then
        intChkKb = 1                                '★勘定口座ｺｰﾄﾞの入力チェック
        txt_BDdkbid(0).SetFocus                          '入金種別項目へ移動
    End If
    txt_HDkouza.SelLength = 1
End Sub

Private Sub txt_HDkouza_GotFocus()
    '先頭位置を選択状態にする
    txt_HDkouza.SelStart = 0
    txt_HDkouza.SelLength = 1
    '背景色を黄色にする
    txt_HDkouza.BackColor = vbYellow
    
    '明細行コマンドを実行不可とする
    mnu_bdinitdsp.Enabled = False
    mnu_gyoin.Enabled = False
    mnu_gyodel.Enabled = False
    
    '検索処理を実行可能とする
    mnu_showwnd.Enabled = True
    
    CurrentLine = -1    'ヘッダを表す値をセット
End Sub

Private Sub txt_HDkouza_KeyDown(KeyCode As Integer, Shift As Integer)
    
    '右矢印押下時
    If KeyCode = vbKeyRight Then
        If txt_HDkouza.SelStart < (10 - 1) Then
            txt_HDkouza.SelStart = txt_HDkouza.SelStart + 1
            
        'カーソルが右端に来たら次の項目へ移動
        Else
            intChkKb = 1                            '★勘定口座ｺｰﾄﾞの入力チェック
            txt_BDdkbid(0).SetFocus                 '入金種別項目へ移動
        End If
        txt_HDkouza.SelLength = 1
    
    'Backspace or 左矢印押下時
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_HDkouza.SelStart > 0 Then
            txt_HDkouza.SelStart = txt_HDkouza.SelStart - 1
        End If
        txt_HDkouza.SelLength = 1
        
    '上矢印押下時
    ElseIf KeyCode = vbKeyUp Then
        '
        
    '下矢印押下時
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 1                                '★勘定口座ｺｰﾄﾞの入力チェック
        txt_BDdkbid(0).SetFocus                     '入金種別項目へ移動
        
    'Enter押下時
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '★勘定口座ｺｰﾄﾞの入力チェック
        txt_BDdkbid(0).SetFocus                     '入金種別項目へ移動
        
    'Delete押下時
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_HDkouza_KeyPress(KeyAscii As Integer)
    'アルファベット小文字を大文字に変換する
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

Private Sub txt_HDkouza_LostFocus()
    'ｲﾍﾞﾝﾄﾌﾗｸﾞが立っていないときは実行しない
    If blnUsableEvent = False Then Exit Sub
    
    '入力チェック(空白は無視)
    chkHDkouza
    '背景色を白に戻す
    txt_HDkouza.BackColor = vbWhite
End Sub

'明細部入金種別ボタンクリック時
Private Sub cmd_BDdkbid_Click()
    If CurrentLine >= 0 Then
        'リストを表示
        WLS_LIST1.Show vbModal
        Unload WLS_LIST1
        
        txt_BDdkbid(CurrentLine).SetFocus
        If WLSTBD_RTNCODE <> "" Then
            txt_BDdkbid(CurrentLine).Text = WLSTBD_RTNCODE
            txt_BDkouza(CurrentLine).SetFocus
        End If
    End If
End Sub

'明細部勘定口座ボタンクリック時
Private Sub cmd_BDkouza_Click()
    If CurrentLine >= 0 Then
        'リストを表示
        WLS_LIST2.Show vbModal
        Unload WLS_LIST2
        
        txt_BDkouza(CurrentLine).SetFocus
        If WLSKOZ_RTNCODE <> "" Then
            txt_BDkouza(CurrentLine).Text = WLSKOZ_RTNCODE
            txt_BDnyukn(CurrentLine).SetFocus
        End If
    End If
End Sub

'ヘッダ部勘定口座ボタンクリック時
Private Sub cmd_HDkouza_Click()
    'リストを表示
    WLS_LIST2.Show vbModal
    Unload WLS_LIST2
    
    txt_HDkouza.SetFocus
    If WLSKOZ_RTNCODE <> "" Then
        txt_HDkouza.Text = WLSKOZ_RTNCODE
        txt_BDdkbid(0).SetFocus
    End If
End Sub

