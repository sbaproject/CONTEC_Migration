VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_DATE 
   Appearance      =   0  'Ì×¯Ä
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  'ŒÅ’èÀŞ²±Û¸Ş
   Caption         =   "¶ÚİÀŞ°"
   ClientHeight    =   3540
   ClientLeft      =   5520
   ClientTop       =   2910
   ClientWidth     =   2970
   ControlBox      =   0   'False
   FillColor       =   &H00404040&
   BeginProperty Font 
      Name            =   "‚l‚r ƒSƒVƒbƒN"
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
   PaletteMode     =   1  'Z µ°ÀŞ°
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "95”N 01Œ"
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'Ì×¯Ä
      BackColor       =   &H80000005&
      Caption         =   "·¬İ¾Ù"
      Height          =   330
      Left            =   1665
      TabIndex        =   43
      Top             =   3105
      Width           =   1050
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'Ì×¯Ä
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "“ú"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "Œ"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "‰Î"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "…"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "–Ø"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "‹à"
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
         Name            =   "‚l‚r ƒSƒVƒbƒN"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   0
      Caption         =   "“y"
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Left            =   90
      Picture         =   "WLS_DATE.frx":0000
      Top             =   45
      Width           =   285
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Left            =   2565
      Picture         =   "WLS_DATE.frx":0166
      Top             =   45
      Width           =   285
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Index           =   1
      Left            =   1080
      Picture         =   "WLS_DATE.frx":02CC
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Index           =   1
      Left            =   1890
      Picture         =   "WLS_DATE.frx":0432
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Index           =   0
      Left            =   1485
      Picture         =   "WLS_DATE.frx":0598
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'Ì×¯Ä
      Height          =   285
      Index           =   0
      Left            =   675
      Picture         =   "WLS_DATE.frx":06FE
      Top             =   3645
      Visible         =   0   'False
      Width           =   285
   End
   Begin VB.Label Label1 
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
      Alignment       =   2  '’†‰›‘µ‚¦
      Appearance      =   0  'Ì×¯Ä
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
'   ƒVƒXƒeƒ€‚Ì“ú•t
Dim Sys_date As String * 10
Dim Sys_year As String * 4
Dim Sys_month As String * 2
Dim Sys_day As String * 2
'   ƒJƒŒƒ“ƒ_[•\¦‚Ì”NŒ
Dim Cur_year As String * 4
Dim Cur_month As String * 2
'   j“ú‚Ìƒoƒbƒtƒ@[
' H_KB j“ú‹æ•ª  0:j“ú‚Å‚È‚¢iæ‚è‚â‚ß^{s‘Oj, 1:U‚è‘Ö‚¦‹x“ú‚Ì‚ ‚éj“ú,
'               2:U‚è‘Ö‚¦‚Ì‚È‚¢‹x“ú, 3:t•ª/H•ª, 4:‘æ‚›—j
'               ‘æ‚›—j‚Ì“ú•t‚ÌˆÓ–¡  ˆêŒ…–Ú:‘æ‚ “ñŒ…–Ú:2`6 ‚ğ Œ`‹à ‚Æ‚·‚é
'                 —á)‘æ“ñŒ—j = 22, ‘æl‹à—j = 46
' H_SttYY {s”N
' H_OldDD {s”NˆÈ‘O‚Ìİ’è“ú
' H_OldKB {s”NˆÈ‘O‚Ìj“ú‹æ•ª
' {s”N‚Ìİ’è—á 07/20(1)1996:00(0) = 1996”N‚©‚ç7Œ20“ú‚ª’Êí‚Ìj“ú‚Æ‚µ‚ÄVİ‚³‚ê‚½
'               01/22(4)2000:15(1) = 2000”N‚©‚ç‘æ2Œ—j‚É•ÏX‚³‚ê‚½(ˆÈ‘O‚Í15“ú‚¾‚Á‚½)
Private Type HOLIDAY_TYPE
    H_MM As Integer
    H_DD As Integer
    H_KB As Integer
    H_SttYY As Integer
    H_OldDD As Integer
    H_OldKB As Integer
End Type
Dim WLS_HoliDay() As HOLIDAY_TYPE
Dim HdayCnt As Integer
Dim D_MAX As Integer
Dim W_DAY As Integer
Dim W_DAYIDX As Integer

Private DblClickFl As Boolean  'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰  97/04/07

Private Sub Form_Activate()
    'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰  97/04/07
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

Private Sub Form_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = 27 Then Hide
End Sub

Private Sub Form_Load()
Dim w_date As String
    w_date = Date
    If Len(w_date) <> 10 Then
        MsgBox "“ú•t‚ÌŒ`®‚ªˆá‚¢‚Ü‚·B" & Chr(13) & "ƒRƒ“ƒgƒ[ƒ‹ƒpƒlƒ‹‚ÌŠe‘‘Î‰‚Ì’Z‚¢Œ`®‚ğC³‚µ‚Ä‰º‚³‚¢B", 48
        Hide
    End If
    
'   j“ú‚Ìİ’è
Dim INI_NO%, sLine$
    INI_NO = FreeFile
    
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
 
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    Exit Sub
    
CALENDAR_ERR:
    MsgBox "ƒJƒŒƒ“ƒ_[î•ñ‚ª³‚µ‚­‚ ‚è‚Ü‚¹‚ñB", 48
End Sub

Private Sub Label1_Click(Index As Integer)
    Sys_year = Cur_year
    Sys_month = Cur_month
    Sys_day = Format$(SSSVal(WLS_DATE.Label1(Index).Caption), "00")
    WLS_DATE.Label1(W_DAYIDX).BackColor = &HC0C0C0
    W_DAYIDX = Index
    WLS_DATE.Label1(Index).BackColor = &HFFFF00
End Sub

Private Sub Label1_DblClick(Index As Integer)
    Dim C_day As Integer
    C_day = Index + 2 - W_DAY
    If C_day > 0 And C_day <= D_MAX Then
        Set_date = Cur_year & "/" & Cur_month & "/" & Format$(C_day, "00")
        Call WLS_SLIST_MOVE(Set_date, Len(Set_date))
        WLSDATE_RTNCODE = Set_date
        'DblClickƒCƒxƒ“ƒgáŠQ‘Î‰  97/04/07
        DblClickFl = True
    End If
End Sub

Private Sub Set_calendar()
'   ‰Šú‰»İ’è
    Dim yy As Integer
    Dim mm As Integer
    Dim hyear%, hday%, hidx%
    Dim HdayArr%()
    
    yy = SSSVal(Cur_year)
    mm = SSSVal(Cur_month)
    WLS_DATE.ymdpanel.Caption = Format$(yy, "0000") & "”N " & Format$(mm, "00") & "Œ"

'   “–Œ‚Ì“ú”ŒvZ(28-31)
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
    
'   “–Œˆê“ú‚Ì—j“úŒvZ(1-7)
    Dim s_date As String * 10
    s_date = Format$(yy, "0000") & "/" & Format$(mm, "00") & "/01"
    W_DAY = Weekday(DateValue(s_date))

'   Še“ú•t‚Ö‚Ì‹æ•ªİ’è 0:’Êí, 1:U‘Ö‰Â”\j“ú, 2:U‘Ö•s‰Â‹x“ú
    For hidx = 0 To HdayCnt - 1
        If WLS_HoliDay(hidx).H_MM = mm Then
            If WLS_HoliDay(hidx).H_KB = 3 Then 't•ª/H•ª
            '   t•ª‚ÆH•ª‚ÌŒvZ
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
            ElseIf WLS_HoliDay(hidx).H_SttYY > yy Then '{s“úˆÈ‘O
                'H_OldDD =0 ‚Ìê‡‚Íƒ_ƒ~[”z—ñ(=0)‚É“ü‚é
                If WLS_HoliDay(hidx).H_OldKB = 4 Then '‘æN X—j“ú
                    tmpN = WLS_HoliDay(hidx).H_OldDD / 10
                    tmpX = WLS_HoliDay(hidx).H_OldDD Mod 10
                    tmpD = tmpX - W_DAY + (tmpN - 1) * 7
                    If tmpX < W_DAY Then tmpD = tmpD + 7
                    HdayArr(tmpD) = 2
                Else
                    HdayArr(WLS_HoliDay(hidx).H_OldDD) = WLS_HoliDay(hidx).H_OldKB
                End If
            ElseIf WLS_HoliDay(hidx).H_KB = 4 Then '‘æN X—j“ú
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

'   “ú•t‚ÌŒvZ
    Dim count As Integer ' count:“ú”
    Dim hnext As Integer ' hnext:U‘Ö‹x“ú‚©‚Ç‚¤‚©
    Dim X%, Y%, k%, L%   ' x:XÀ•W, y:YÀ•W, k:À•W˜A”Ô(0`41),
    hnext = False
    count = 2 - W_DAY
    For Y% = 0 To 5
        For X% = 0 To 6
            k% = Y% * 7 + X%
            If count > 0 And count <= D_MAX Then
                WLS_DATE.Label1(k%).Enabled = True
                WLS_DATE.Label1(k%).Caption = Str$(count)
                WLS_DATE.Label1(k%).ForeColor = &H80000008
                WLS_DATE.Label1(k%).BackColor = &HC0C0C0
                If hnext Then      ' U‘Ö‹x“ú‚©‚Ç‚¤‚©
                    WLS_DATE.Label1(k%).ForeColor = &HFF&
                    hnext = False
                ElseIf X% = 0 Then ' “ú—j“ú
                    WLS_DATE.Label1(k%).ForeColor = &HFF&
                    If HdayArr(count) = 1 Then hnext = True '“–“ú‚ªU‘Ö‰Â”\‚Èj“ú‚È‚çU‘Ö‹x“ú‚ğİ’è‚·‚é
                ElseIf HdayArr(count) > 0 Then
                    WLS_DATE.Label1(k%).ForeColor = &HFF&
                ElseIf X% = 6 Then '“y—j“ú
                        WLS_DATE.Label1(k%).ForeColor = &HFF0000
                End If
                If SSSVal(Sys_year) = yy And SSSVal(Sys_month) = mm And SSSVal(Sys_day) = count Then
                    WLS_DATE.Label1(k%).BackColor = &HFFFF00
                    W_DAYIDX = k%
                End If
            Else
                WLS_DATE.Label1(k%).Enabled = False
                WLS_DATE.Label1(k%).Caption = ""
                WLS_DATE.Label1(k%).ForeColor = &H80000008
                WLS_DATE.Label1(k%).BackColor = &HC0C0C0
            End If
            count = count + 1
        Next X%
    Next Y%
End Sub

Private Sub Label1_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadƒCƒxƒ“ƒgáŠQ‘Î‰  97/04/07
    If DblClickFl Then Call WLSCANCEL_Click
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

Private Sub WLSCANCEL_Click()
    'UnLoadƒCƒxƒ“ƒgáŠQ‘Î‰  97/04/07
    'Unload Me
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
'            internal_flag = 3
            Call WLS_SLIST_MOVE(Set_date, Len(Set_date))
            WLSDATE_RTNCODE = Set_date
            Call WLSCANCEL_Click
        End If
    Else
        MsgBox ("“ú•t‚ª‘I‘ğ‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ")
    End If
End Sub


