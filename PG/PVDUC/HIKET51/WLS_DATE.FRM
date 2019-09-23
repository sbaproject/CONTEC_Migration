VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_DATE 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "ｶﾚﾝﾀﾞｰ"
   ClientHeight    =   3540
   ClientLeft      =   5520
   ClientTop       =   2910
   ClientWidth     =   2970
   ControlBox      =   0   'False
   FillColor       =   &H00404040&
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H00404040&
   LinkTopic       =   "0"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   3540
   ScaleWidth      =   2970
   Begin Threed5.SSPanel5 ymdpanel 
      Height          =   330
      Left            =   540
      TabIndex        =   51
      Top             =   45
      Width           =   1860
      _ExtentX        =   3281
      _ExtentY        =   582
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "95年 01月"
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   1665
      TabIndex        =   43
      Top             =   3105
      Width           =   1050
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   180
      TabIndex        =   42
      Top             =   3105
      Width           =   1050
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   0
      Left            =   90
      TabIndex        =   50
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   255
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "日"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   1
      Left            =   540
      TabIndex        =   49
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "月"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   2
      Left            =   900
      TabIndex        =   48
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "火"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   3
      Left            =   1305
      TabIndex        =   47
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "水"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   4
      Left            =   1665
      TabIndex        =   46
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "木"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   5
      Left            =   2070
      TabIndex        =   45
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "金"
   End
   Begin Threed5.SSPanel5 panelday 
      Height          =   330
      Index           =   6
      Left            =   2475
      TabIndex        =   44
      Top             =   540
      Width           =   375
      _ExtentX        =   503
      _ExtentY        =   423
      BackColor       =   12632256
      ForeColor       =   16711680
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "土"
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Left            =   90
      Picture         =   "WLS_DATE.frx":0000
      Top             =   45
      Width           =   285
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Left            =   2565
      Picture         =   "WLS_DATE.frx":0166
      Top             =   45
      Width           =   285
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Index           =   1
      Left            =   1080
      Picture         =   "WLS_DATE.frx":02CC
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Index           =   1
      Left            =   1890
      Picture         =   "WLS_DATE.frx":0432
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Index           =   0
      Left            =   1485
      Picture         =   "WLS_DATE.frx":0598
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   285
      Index           =   0
      Left            =   675
      Picture         =   "WLS_DATE.frx":06FE
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   41
      Left            =   2475
      TabIndex        =   41
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   40
      Left            =   2070
      TabIndex        =   40
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   39
      Left            =   1665
      TabIndex        =   39
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   38
      Left            =   1305
      TabIndex        =   38
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   37
      Left            =   900
      TabIndex        =   37
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   36
      Left            =   540
      TabIndex        =   36
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   35
      Left            =   90
      TabIndex        =   35
      Top             =   2520
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   34
      Left            =   2475
      TabIndex        =   34
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   33
      Left            =   2070
      TabIndex        =   33
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   32
      Left            =   1665
      TabIndex        =   32
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   31
      Left            =   1305
      TabIndex        =   31
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   30
      Left            =   900
      TabIndex        =   30
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   29
      Left            =   540
      TabIndex        =   29
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   28
      Left            =   90
      TabIndex        =   28
      Top             =   2205
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   27
      Left            =   2475
      TabIndex        =   27
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   26
      Left            =   2070
      TabIndex        =   26
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   25
      Left            =   1665
      TabIndex        =   25
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   24
      Left            =   1305
      TabIndex        =   24
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   23
      Left            =   900
      TabIndex        =   23
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   22
      Left            =   540
      TabIndex        =   22
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   21
      Left            =   90
      TabIndex        =   21
      Top             =   1890
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   20
      Left            =   2475
      TabIndex        =   20
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   19
      Left            =   2070
      TabIndex        =   19
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   18
      Left            =   1665
      TabIndex        =   18
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   17
      Left            =   1305
      TabIndex        =   17
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   16
      Left            =   900
      TabIndex        =   16
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   15
      Left            =   540
      TabIndex        =   15
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   14
      Left            =   90
      TabIndex        =   14
      Top             =   1575
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   13
      Left            =   2475
      TabIndex        =   13
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   12
      Left            =   2070
      TabIndex        =   12
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   11
      Left            =   1665
      TabIndex        =   11
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   10
      Left            =   1305
      TabIndex        =   10
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   9
      Left            =   900
      TabIndex        =   9
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   8
      Left            =   540
      TabIndex        =   8
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   7
      Left            =   90
      TabIndex        =   7
      Top             =   1260
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   6
      Left            =   2475
      TabIndex        =   6
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   5
      Left            =   2070
      TabIndex        =   5
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   4
      Left            =   1665
      TabIndex        =   4
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   3
      Left            =   1305
      TabIndex        =   3
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   2
      Left            =   900
      TabIndex        =   2
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   1
      Left            =   540
      TabIndex        =   1
      Top             =   900
      Width           =   375
   End
   Begin VB.Label Label1 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H00C0C0C0&
      Caption         =   "Label1"
      ForeColor       =   &H80000008&
      Height          =   330
      Index           =   0
      Left            =   90
      TabIndex        =   0
      Top             =   900
      Width           =   375
   End
End
Attribute VB_Name = "WLS_DATE"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim DAYIDX As Integer
'   システムの日付
Dim Sys_date As String * 10
Dim Sys_year As String * 4
Dim Sys_month As String * 2
Dim Sys_day As String * 2
'   カレンダー表示の年月
Dim Cur_year As String * 4
Dim Cur_month As String * 2
'   祝日のバッファー
' H_KB 祝日区分  0:祝日でない（取りやめ／施行前）, 1:振り替え休日のある祝日,
'               2:振り替えのない休日, 3:春分/秋分, 4:第ｎ○曜
'               第ｎ○曜の日付の意味  一桁目:第ｎ 二桁目:2～6 を 月～金 とする
'                 例)第二月曜 = 22, 第四金曜 = 46
' H_SttYY 施行年
' H_OldDD 施行年以前の設定日
' H_OldKB 施行年以前の祝日区分
' 施行年の設定例 07/20(1)1996:00(0) = 1996年から7月20日が通常の祝日として新設された
'               01/22(4)2000:15(1) = 2000年から第2月曜に変更された(以前は15日だった)
Private Type HOLIDAY_TYPE
    H_MM As Integer
    H_DD As Integer
    H_KB As Integer
    H_SttYY As Integer
    H_OldDD As Integer
    H_OldKB As Integer
End Type

'各カレンダ区分識別色
Private Const KBNDAY_BACKCOLOR     As Long = &HFFFFFF
'通常日背景色
Private Const NORMALDAY_BACKCOLOR  As Long = &HC0C0C0
'選択日背景色
Private Const SELECTDAY_BACKCOLOR  As Long = &HFFFF00

'休日前景色
Private Const HOLIDAY_FORECOlOR    As Long = &HFF&
'土曜前景色
Private Const SATDAY_FORECOlOR     As Long = &HFF0000
'通常日前景色
Private Const NORMALDAY_FORECOlOR  As Long = &H80000008


Dim WLS_HoliDay() As HOLIDAY_TYPE

'カレンダマスタ情報
Private WLS_Cldmt() As TYPE_DB_CLDMTA

Dim HdayCnt As Integer
Dim D_MAX As Integer
Dim W_DAY As Integer
Dim W_DAYIDX As Integer

Private DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Get_Cldmta
    '   概要：  カレンダ情報取得
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_Get_Cldmta(yy As Integer, mm As Integer)
        
    Dim strSQL          As String
    Dim Usr_Ody_LC      As U_Ody
    Dim Cnt             As Integer
    
    strSQL = ""
    strSQL = strSQL & " Select CLDDT "       '日付
    strSQL = strSQL & "      , CLDWKKB "     '曜日
    strSQL = strSQL & "      , CLDHLKB "     '祝日
    strSQL = strSQL & "      , SLDKB "       '営業日区分
    strSQL = strSQL & "      , BNKKDKB "     '銀行稼動区分
    strSQL = strSQL & "      , DTBKDKB "     '物流稼動区分
    strSQL = strSQL & "      , ETCKBA "      'その他区分１
    strSQL = strSQL & "      , ETCKBB "      'その他区分２
    strSQL = strSQL & "      , ETCKBC "      'その他区分３
    strSQL = strSQL & "      , ETCKBD "      'その他区分４
    strSQL = strSQL & "      , ETCKBE "      'その他区分５
    strSQL = strSQL & "      , ETCKBF "      'その他区分６
    strSQL = strSQL & "      , ETCKBG "      'その他区分７
    strSQL = strSQL & "      , ETCKBH "      'その他区分８
    strSQL = strSQL & "      , ETCKBI "      'その他区分９
    strSQL = strSQL & "      , ETCKBJ "      'その他区分１０
    strSQL = strSQL & "   from CLDMTA "
    strSQL = strSQL & "  Where DATKB = '1' "
    strSQL = strSQL & "   and  CLDDT >= " & Format(yy, "0000") & Format(mm, "00") & "01"
    strSQL = strSQL & "   and  CLDDT <= " & Format(yy, "0000") & Format(mm, "00") & "99"
    strSQL = strSQL & "   order by "
    strSQL = strSQL & "        CLDDT "          '日付
    
     'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    
    ReDim WLS_Cldmt(0)
    Cnt = 0
    Do Until CF_Ora_EOF(Usr_Ody_LC) = True
        
        Cnt = Cnt + 1
        ReDim Preserve WLS_Cldmt(Cnt)
        
        With WLS_Cldmt(Cnt)
            .CLDDT = CF_Ora_GetDyn(Usr_Ody_LC, "CLDDT", "")            '日付
            .CLDWKKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDWKKB", "")        '曜日
            .CLDHLKB = CF_Ora_GetDyn(Usr_Ody_LC, "CLDHLKB", "")        '祝日
            .SLDKB = CF_Ora_GetDyn(Usr_Ody_LC, "SLDKB", "")            '営業日区分
            .BNKKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "BNKKDKB", "")        '銀行稼動区分
            .DTBKDKB = CF_Ora_GetDyn(Usr_Ody_LC, "DTBKDKB", "")        '物流稼動区分
            .ETCKBA = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBA", "")          'その他区分１
            .ETCKBB = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBB", "")          'その他区分２
            .ETCKBC = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBC", "")          'その他区分３
            .ETCKBD = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBD", "")          'その他区分４
            .ETCKBE = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBE", "")          'その他区分５
            .ETCKBF = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBF", "")          'その他区分６
            .ETCKBG = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBG", "")          'その他区分７
            .ETCKBH = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBH", "")          'その他区分８
            .ETCKBI = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBI", "")          'その他区分９
            .ETCKBJ = CF_Ora_GetDyn(Usr_Ody_LC, "ETCKBJ", "")          'その他区分１０
        End With
        
        Call CF_Ora_MoveNext(Usr_Ody_LC)
    Loop
     
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Get_YmdKbn
    '   概要：  区分情報取得
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function WLS_Get_YmdKbn(yy As Integer, mm As Integer, dd As Integer) As Boolean
        
    Dim Cnt             As Integer
    Dim bolKbnFlg       As Boolean
    Dim strKbn          As String
    
    '区分設定フラグ
    bolKbnFlg = False
    
    For Cnt = 1 To UBound(WLS_Cldmt)
        
        If SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 1, 4)) = yy _
        And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 5, 2)) = mm _
        And SSSVal(Mid(WLS_Cldmt(Cnt).CLDDT, 7, 2)) = dd _
        Then
        '日付が一致
            strKbn = ""
            Select Case WLSDATE_KBN
                Case DATE_KBN_SLDKB
                    '営業日区分
                    strKbn = WLS_Cldmt(Cnt).SLDKB
                Case DATE_KBN_BNKKDKB
                    '銀行稼動区分
                    strKbn = WLS_Cldmt(Cnt).BNKKDKB
                Case DATE_KBN_DTBKDKB
                    '物流稼動区分
                    strKbn = WLS_Cldmt(Cnt).DTBKDKB
                Case DATE_KBN_ETCKBA
                    'その他区分１
                    strKbn = WLS_Cldmt(Cnt).ETCKBA
                Case DATE_KBN_ETCKBB
                    'その他区分２
                    strKbn = WLS_Cldmt(Cnt).ETCKBB
                Case DATE_KBN_ETCKBC
                    'その他区分３
                    strKbn = WLS_Cldmt(Cnt).ETCKBC
                Case DATE_KBN_ETCKBD
                    'その他区分４
                    strKbn = WLS_Cldmt(Cnt).ETCKBD
                Case DATE_KBN_ETCKBE
                    'その他区分５
                    strKbn = WLS_Cldmt(Cnt).ETCKBE
                Case DATE_KBN_ETCKBF
                    'その他区分６
                    strKbn = WLS_Cldmt(Cnt).ETCKBF
                Case DATE_KBN_ETCKBG
                    'その他区分７
                    strKbn = WLS_Cldmt(Cnt).ETCKBG
                Case DATE_KBN_ETCKBH
                    'その他区分８
                    strKbn = WLS_Cldmt(Cnt).ETCKBH
                Case DATE_KBN_ETCKBI
                    'その他区分９
                    strKbn = WLS_Cldmt(Cnt).ETCKBI
                Case DATE_KBN_ETCKBJ
                    'その他区分１０
                    strKbn = WLS_Cldmt(Cnt).ETCKBJ
            End Select
            
            '当検索画面のパラメータに該当する区分で判定
            If strKbn = "1" Then
                bolKbnFlg = True
            End If
            Exit For
        
        End If
    Next
    
    WLS_Get_YmdKbn = bolKbnFlg

End Function

Private Sub Form_Activate()
    
    DblClickFl = False
    
    If IsNull(Set_date) Or Not IsDate(Set_date) Then
        Sys_date = Date$
        Sys_year = Left$(Sys_date, 4)
        Sys_month = Mid$(Sys_date, 6, 2)
        Sys_day = Right$(Sys_date, 2)
    Else
        Sys_date = Set_date
        Sys_year = Left$(Set_date, 4)
        Sys_month = Mid$(Set_date, 6, 2)
        Sys_day = Right$(Set_date, 2)
    End If
    Cur_year = Sys_year
    Cur_month = Sys_month
    Set_calendar

End Sub

Private Sub Form_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = 27 Then Hide
End Sub

Private Sub Form_Load()
Dim w_date As String
    w_date = Date
    If Len(w_date) <> 10 Then
        MsgBox "日付の形式が違います。" & Chr(13) & "コントロールパネルの各国対応の短い形式を修正して下さい。", 48
        Hide
    End If
    
'   祝日の設定
Dim INI_NO%, sLine$
    INI_NO = FreeFile
 
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    
    WLSDATE_RTNCODE = ""
    
    On Error Resume Next
    Open SSS_INIDAT(2) & "CALENDAR.INI" For Input As #INI_NO
    If Err <> 0 Then
        On Error GoTo CALENDAR_ERR
        Open SSS_INIDAT(0) & "CALENDAR.INI" For Input As #INI_NO
    End If
    
    ReDim WLS_HoliDay(20)
    
    HdayCnt = 0
    Do Until EOF(INI_NO)
        Line Input #INI_NO, sLine
        If InStr(sLine, "=") = 3 And InStr(sLine, "/") = 6 And Len(sLine) > 10 Then
            If HdayCnt > UBound(WLS_HoliDay) Then ReDim Preserve WLS_HoliDay(HdayCnt + 10)
            WLS_HoliDay(HdayCnt).H_MM = SSSVal(Mid$(sLine, 4, 2))
            WLS_HoliDay(HdayCnt).H_DD = SSSVal(Mid$(sLine, 7, 2))
            WLS_HoliDay(HdayCnt).H_KB = SSSVal(Mid$(sLine, 10, 1))
            If InStr(sLine, ":") = 16 And InStr(sLine, ";") = 22 Then
                WLS_HoliDay(HdayCnt).H_SttYY = SSSVal(Mid$(sLine, 12, 4))
                WLS_HoliDay(HdayCnt).H_OldDD = SSSVal(Mid$(sLine, 17, 2))
                WLS_HoliDay(HdayCnt).H_OldKB = SSSVal(Mid$(sLine, 20, 1))
            End If
            HdayCnt = HdayCnt + 1
        End If
    Loop
    Close #INI_NO
    
    Exit Sub
    
    
CALENDAR_ERR:
    MsgBox "カレンダー情報が正しくありません。", 48
End Sub

Private Sub Label1_Click(Index As Integer)
    Dim W_DAY As String
    Sys_year = Cur_year
    Sys_month = Cur_month
    Sys_day = Format$(SSSVal(WLS_DATE.Label1(Index).Caption), "00")
    
    W_DAY = Format$(SSSVal(WLS_DATE.Label1(W_DAYIDX).Caption), "00")
    'カレンダマスタの○○区分判定
    If WLS_Get_YmdKbn(SSSVal(Sys_year), SSSVal(Sys_month), SSSVal(W_DAY)) = True Then
        '背景色【白】
        WLS_DATE.Label1(W_DAYIDX).BackColor = KBNDAY_BACKCOLOR
    Else
        WLS_DATE.Label1(W_DAYIDX).BackColor = NORMALDAY_BACKCOLOR
    End If
    
    W_DAYIDX = Index
    WLS_DATE.Label1(Index).BackColor = SELECTDAY_BACKCOLOR
End Sub

Private Sub Label1_DblClick(Index As Integer)
    Dim C_day As Integer
    C_day = Index + 2 - W_DAY
    If C_day > 0 And C_day <= D_MAX Then
        Set_date = Cur_year & "/" & Cur_month & "/" & Format$(C_day, "00")
        WLSDATE_RTNCODE = Cur_year & "/" & Cur_month & "/" & Format$(C_day, "00")
        Call WLS_SLIST_MOVE(Set_date, Len(Set_date))
        'DblClickイベント障害対応  97/04/07
        DblClickFl = True
    End If
End Sub

Private Sub Set_calendar()
'   初期化設定
    Dim yy As Integer
    Dim mm As Integer
    Dim hyear%, hday%, hidx%
    Dim HdayArr%()
    
    yy = SSSVal(Cur_year)
    mm = SSSVal(Cur_month)
    WLS_DATE.ymdpanel.Caption = Format$(yy, "0000") & "年 " & Format$(mm, "00") & "月"

    'カレンダ情報取得
    Call WLS_Get_Cldmta(yy, mm)
    
'   当月の日数計算(28-31)
    If mm = 1 Or mm = 3 Or mm = 5 Or mm = 7 Or mm = 8 Or mm = 10 Or mm = 12 Then
        D_MAX = 31
    ElseIf mm = 4 Or mm = 6 Or mm = 9 Or mm = 11 Then
        D_MAX = 30
    ElseIf (yy Mod 4 = 0 And yy Mod 100 <> 0) Or yy Mod 400 = 0 Then
        D_MAX = 29
    Else
        D_MAX = 28
    End If

    ReDim HdayArr(D_MAX)
    Dim tmpN%, tmpX%, tmpD%
    
'   当月一日の曜日計算(1-7)
    Dim s_date As String * 10
    s_date = Format$(yy, "0000") & "/" & Format$(mm, "00") & "/01"
    W_DAY = Weekday(DateValue(s_date))

'   各日付への区分設定 0:通常, 1:振替可能祝日, 2:振替不可休日
    For hidx = 0 To HdayCnt - 1
        If WLS_HoliDay(hidx).H_MM = mm Then
            If WLS_HoliDay(hidx).H_KB = 3 Then '春分/秋分
            '   春分と秋分の計算
                hyear = yy - 1980
                If mm = 3 Then
                    Select Case hyear
                        Case 0, 4, 8, 12, 13, 16, 17, 20, 21, 24, 25, 28, 29, 32, 33, 36, 37, 40, 41, 44, 45, 46, 48, 49, 50, 52, 53, 54, 56, 57, 58, 60, 61, 62, 64, 65, 66, 68, 69, 70
                            hday = 20
                        Case Else
                            hday = 21
                    End Select
                ElseIf mm = 9 Then
                    Select Case hyear
                        Case 32, 36, 40, 44, 48, 52, 56, 60, 64, 65, 68, 69
                            hday = 22
                        Case Else
                            hday = 23
                    End Select
                End If
                HdayArr(hday) = 1
            ElseIf WLS_HoliDay(hidx).H_SttYY > yy Then '施行日以前
                'H_OldDD =0 の場合はダミー配列(=0)に入る
                If WLS_HoliDay(hidx).H_OldKB = 4 Then '第N X曜日
                    tmpN = WLS_HoliDay(hidx).H_OldDD / 10
                    tmpX = WLS_HoliDay(hidx).H_OldDD Mod 10
                    tmpD = tmpX - W_DAY + (tmpN - 1) * 7
                    If tmpX < W_DAY Then tmpD = tmpD + 7
                    HdayArr(tmpD) = 2
                Else
                    HdayArr(WLS_HoliDay(hidx).H_OldDD) = WLS_HoliDay(hidx).H_OldKB
                End If
            ElseIf WLS_HoliDay(hidx).H_KB = 4 Then '第N X曜日
                tmpN = WLS_HoliDay(hidx).H_DD / 10
                tmpX = WLS_HoliDay(hidx).H_DD Mod 10
                tmpD = tmpX - W_DAY + (tmpN - 1) * 7 + 1
                If tmpX < W_DAY Then tmpD = tmpD + 7
                HdayArr(tmpD) = 2
            Else
                HdayArr(WLS_HoliDay(hidx).H_DD) = WLS_HoliDay(hidx).H_KB
            End If
        End If
    Next hidx

'   日付の計算
    Dim count As Integer ' count:日数
    Dim hnext As Integer ' hnext:振替休日かどうか
    Dim X%, Y%, k%, L%   ' x:X座標, y:Y座標, k:座標連番(0～41),
    hnext = False
    count = 2 - W_DAY
    For Y% = 0 To 5
        For X% = 0 To 6
            k% = Y% * 7 + X%
            If count > 0 And count <= D_MAX Then
                WLS_DATE.Label1(k%).Enabled = True
                WLS_DATE.Label1(k%).Caption = Str$(count)
                WLS_DATE.Label1(k%).ForeColor = NORMALDAY_FORECOlOR
                WLS_DATE.Label1(k%).BackColor = NORMALDAY_BACKCOLOR
                If hnext Then      ' 振替休日かどうか
                    WLS_DATE.Label1(k%).ForeColor = HOLIDAY_FORECOlOR
                    hnext = False
                ElseIf X% = 0 Then ' 日曜日
                    WLS_DATE.Label1(k%).ForeColor = HOLIDAY_FORECOlOR
                    If HdayArr(count) = 1 Then hnext = True '当日が振替可能な祝日なら振替休日を設定する
                ElseIf HdayArr(count) > 0 Then
                    WLS_DATE.Label1(k%).ForeColor = HOLIDAY_FORECOlOR
                ElseIf X% = 6 Then '土曜日
                        WLS_DATE.Label1(k%).ForeColor = SATDAY_FORECOlOR
                End If
                If SSSVal(Sys_year) = yy And SSSVal(Sys_month) = mm And SSSVal(Sys_day) = count Then
                    WLS_DATE.Label1(k%).BackColor = SELECTDAY_BACKCOLOR
                    W_DAYIDX = k%
                End If
                
                'カレンダマスタの○○区分判定
                If WLS_Get_YmdKbn(yy, mm, count) = True Then
                    '背景色【白】
                    WLS_DATE.Label1(k%).BackColor = KBNDAY_BACKCOLOR
                End If
            Else
                WLS_DATE.Label1(k%).Enabled = False
                WLS_DATE.Label1(k%).Caption = ""
                WLS_DATE.Label1(k%).ForeColor = NORMALDAY_FORECOlOR
                WLS_DATE.Label1(k%).BackColor = NORMALDAY_BACKCOLOR
            End If
            count = count + 1
        Next X%
    Next Y%
End Sub

Private Sub Label1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub WLSATO_Click()
    Dim yy As Integer
    Dim mm As Integer
    yy = SSSVal(Cur_year)
    mm = SSSVal(Cur_month)
    If mm = 12 Then
        yy = yy + 1
        mm = 1
    Else
        mm = mm + 1
    End If
    Cur_year = Format$(yy, "0000")
    Cur_month = Format$(mm, "00")
    Set_calendar

End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub

Private Sub WLSCANCEL_CLICK()
    Hide
End Sub

Private Sub WLSMAE_Click()
    Dim yy As Integer
    Dim mm As Integer
    yy = SSSVal(Cur_year)
    mm = SSSVal(Cur_month)
    If mm = 1 Then
        yy = yy - 1
        mm = 12
    Else
        mm = mm - 1
    End If
    Cur_year = Format$(yy, "0000")
    Cur_month = Format$(mm, "00")
    Set_calendar

End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub WLSOK_Click()
    Dim C_day As Integer
    
    If (Sys_year = Cur_year) And (Sys_month = Cur_month) Then
        C_day = W_DAYIDX + 2 - W_DAY
        If C_day > 0 And C_day <= D_MAX Then
            Set_date = Cur_year & "/" & Cur_month & "/" & Format$(C_day, "00")
            WLSDATE_RTNCODE = Cur_year & "/" & Cur_month & "/" & Format$(C_day, "00")
            Call WLSCANCEL_CLICK
        End If
    Else
        MsgBox ("日付が選択されていません")
    End If
End Sub


