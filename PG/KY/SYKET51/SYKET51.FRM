VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'Ã◊Øƒ
   BorderStyle     =   1  'å≈íË(é¿ê¸)
   Caption         =   "èoâ◊éwé¶ìoò^Åiå¬ï Åj"
   ClientHeight    =   8715
   ClientLeft      =   795
   ClientTop       =   2565
   ClientWidth     =   14970
   BeginProperty Font 
      Name            =   "ÇlÇr ÉSÉVÉbÉN"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "SYKET51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z µ∞¿ﬁ∞
   ScaleHeight     =   8715
   ScaleWidth      =   14970
   Begin VB.TextBox BD_FRDSU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   13120
      MaxLength       =   11
      TabIndex        =   46
      Text            =   "999,999"
      Top             =   2955
      Width           =   1395
   End
   Begin VB.TextBox BD_OTPSU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   11760
      MaxLength       =   11
      TabIndex        =   44
      Text            =   "999,999"
      Top             =   2955
      Width           =   1395
   End
   Begin VB.TextBox BD_FRDKNSU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   10370
      MaxLength       =   11
      TabIndex        =   42
      Text            =   "999,999"
      Top             =   2955
      Width           =   1395
   End
   Begin VB.TextBox BD_FRDYZSU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   8990
      MaxLength       =   11
      TabIndex        =   40
      Text            =   "999,999"
      Top             =   2955
      Width           =   1395
   End
   Begin VB.TextBox BD_BKTHKNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   7030
      MaxLength       =   8
      TabIndex        =   38
      Text            =   "XXXX"
      Top             =   2955
      Width           =   585
   End
   Begin VB.TextBox BD_HINNMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   3700
      MaxLength       =   24
      TabIndex        =   36
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      Top             =   2955
      Width           =   3345
   End
   Begin VB.TextBox BD_HINCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   2540
      MaxLength       =   17
      TabIndex        =   34
      Text            =   "XXXXXXXX10"
      Top             =   2955
      Width           =   1185
   End
   Begin VB.TextBox BD_ODNYTDT 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   1360
      MaxLength       =   14
      TabIndex        =   32
      Text            =   "9999/99/99"
      Top             =   2955
      Width           =   1185
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11490
      MaxLength       =   10
      TabIndex        =   28
      Text            =   "XXXXX6"
      Top             =   720
      Width           =   705
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   12180
      MaxLength       =   24
      TabIndex        =   27
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   720
      Width           =   2265
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   1
      Left            =   195
      TabIndex        =   25
      Top             =   2145
      Width           =   1515
      _ExtentX        =   2672
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "ìæà”êÊ"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_JDNNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1695
      MaxLength       =   14
      TabIndex        =   24
      Text            =   "XXXXXXXXX1"
      Top             =   1350
      Width           =   1230
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   585
      Index           =   0
      Left            =   0
      TabIndex        =   20
      Top             =   10260
      Width           =   13605
      _ExtentX        =   23998
      _ExtentY        =   1032
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFC0FF&
         Height          =   555
         Left            =   12195
         TabIndex        =   21
         Text            =   "”∞ƒﬁ"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "SYKET51.frx":000C
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "SYKET51.frx":0196
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "SYKET51.frx":0320
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "SYKET51.frx":04AA
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "SYKET51.frx":0634
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "SYKET51.frx":07BE
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "SYKET51.frx":0948
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "SYKET51.frx":0AD2
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "SYKET51.frx":0C5C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "SYKET51.frx":0DE6
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "SYKET51.frx":0F70
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "SYKET51.frx":10FA
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "SYKET51.frx":1284
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "SYKET51.frx":140E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "SYKET51.frx":1598
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "SYKET51.frx":1722
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "SYKET51.frx":18AC
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "SYKET51.frx":1A36
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "SYKET51.frx":1BC0
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "SYKET51.frx":2212
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D14 
      Height          =   555
      Left            =   -45
      TabIndex        =   18
      Top             =   -15
      Width           =   15045
      _ExtentX        =   26538
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
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
         Left            =   12720
         TabIndex        =   19
         Top             =   135
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ÇlÇr ÉSÉVÉbÉN"
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
      Begin VB.Image CM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Enabled         =   0   'False
         Height          =   330
         Left            =   5880
         Picture         =   "SYKET51.frx":2864
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Enabled         =   0   'False
         Height          =   330
         Left            =   5355
         Picture         =   "SYKET51.frx":29EE
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_INSERTDE 
         Appearance      =   0  'Ã◊Øƒ
         Enabled         =   0   'False
         Height          =   330
         Left            =   4995
         Picture         =   "SYKET51.frx":2B78
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   585
         Picture         =   "SYKET51.frx":2D02
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Enabled         =   0   'False
         Height          =   330
         Left            =   4545
         Picture         =   "SYKET51.frx":3354
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   945
         Picture         =   "SYKET51.frx":34DE
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   225
         Picture         =   "SYKET51.frx":3668
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   6315
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   735
      Index           =   0
      Left            =   0
      TabIndex        =   15
      Top             =   7920
      Width           =   15120
      _ExtentX        =   26670
      _ExtentY        =   1296
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
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
         Index           =   9
         Left            =   675
         TabIndex        =   16
         Top             =   135
         Width           =   10500
         _ExtentX        =   18521
         _ExtentY        =   820
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ÇlÇr ÉSÉVÉbÉN"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  'Ã◊Øƒ
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'Ç»Çµ
            ForeColor       =   &H00000000&
            Height          =   285
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   17
            Text            =   "SYKET51.frx":37F2
            Top             =   90
            Width           =   7440
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "SYKET51.frx":3829
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   6
      Left            =   195
      TabIndex        =   14
      Top             =   720
      Width           =   1515
      _ExtentX        =   2672
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "*èàóùãÊï™Å@"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_SOUNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   2385
      MaxLength       =   24
      TabIndex        =   13
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1830
      Width           =   4440
   End
   Begin VB.TextBox HD_SOUCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1695
      MaxLength       =   7
      TabIndex        =   12
      Text            =   "123"
      Top             =   1830
      Width           =   705
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   2
      Left            =   7605
      TabIndex        =   11
      Top             =   2640
      Width           =   1395
      _ExtentX        =   2461
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "à¯ìñêî"
      OutLine         =   -1  'True
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   43380
      Top             =   43380
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  'Ã◊Øƒ
      BorderStyle     =   0  'Ç»Çµ
      Height          =   375
      IMEMode         =   2  'µÃ
      Left            =   43380
      TabIndex        =   7
      Top             =   43380
      Width           =   330
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   450
      Left            =   14500
      TabIndex        =   8
      Top             =   3000
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   3
      Left            =   195
      TabIndex        =   6
      Top             =   2640
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "êªÅ@î‘"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_TOKCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1695
      MaxLength       =   9
      TabIndex        =   5
      TabStop         =   0   'False
      Text            =   "XXXX5"
      Top             =   2145
      Width           =   705
   End
   Begin VB.TextBox BD_SBNNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   195
      MaxLength       =   14
      TabIndex        =   4
      Text            =   "XXXXXXXXX1"
      Top             =   2955
      Width           =   1185
   End
   Begin VB.TextBox BD_HIKSU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   7605
      MaxLength       =   11
      TabIndex        =   3
      Text            =   "999,999"
      Top             =   2955
      Width           =   1395
   End
   Begin VB.TextBox HD_WRKKB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1695
      MaxLength       =   5
      TabIndex        =   2
      Text            =   "9"
      Top             =   720
      Width           =   285
   End
   Begin VB.TextBox HD_FDNDT 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1695
      MaxLength       =   14
      TabIndex        =   1
      Text            =   "9999/99/99"
      Top             =   1035
      Width           =   1230
   End
   Begin VB.TextBox HD_TOKRN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   2385
      MaxLength       =   44
      TabIndex        =   0
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   2145
      Width           =   4440
   End
   Begin Threed5.SSCommand5 CS_JDNNO 
      Height          =   330
      Left            =   195
      TabIndex        =   23
      TabStop         =   0   'False
      Top             =   1350
      Width           =   1515
      _ExtentX        =   2672
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*èoâ◊éwé¶ëŒè€"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_FDNDT 
      Height          =   330
      Left            =   195
      TabIndex        =   22
      TabStop         =   0   'False
      Top             =   1035
      Width           =   1515
      _ExtentX        =   2672
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*ëŒè€ì˙Å@Å@"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   330
      Index           =   12
      Left            =   10320
      TabIndex        =   29
      Top             =   720
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "ì¸óÕíSìñé“"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   10
      Left            =   195
      TabIndex        =   30
      Top             =   1830
      Width           =   1515
      _ExtentX        =   2672
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "èoâ◊ëqå…"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   11
      Left            =   1360
      TabIndex        =   31
      Top             =   2640
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "èoâ◊ó\íËì˙"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   12
      Left            =   2540
      TabIndex        =   33
      Top             =   2640
      Width           =   1185
      _ExtentX        =   2090
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "êªïi∫∞ƒﬁ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   4
      Left            =   3700
      TabIndex        =   35
      Top             =   2640
      Width           =   3345
      _ExtentX        =   5900
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "å^Å@éÆ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   7
      Left            =   7030
      TabIndex        =   37
      Top             =   2640
      Width           =   585
      _ExtentX        =   1032
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "ï™î["
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   13
      Left            =   8990
      TabIndex        =   39
      Top             =   2640
      Width           =   1395
      _ExtentX        =   2461
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "èoâ◊ó\íËécêî"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   14
      Left            =   10370
      TabIndex        =   41
      Top             =   2640
      Width           =   1395
      _ExtentX        =   2461
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "èoâ◊â¬î\êî"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   15
      Left            =   11745
      TabIndex        =   43
      Top             =   2640
      Width           =   1395
      _ExtentX        =   2461
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "èoå…êî"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   16
      Left            =   13120
      TabIndex        =   45
      Top             =   2640
      Width           =   1395
      _ExtentX        =   2461
      _ExtentY        =   582
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "*èoâ◊éwé¶êî"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D3 
      Height          =   330
      Left            =   75
      TabIndex        =   9
      Top             =   2640
      Visible         =   0   'False
      Width           =   420
      _ExtentX        =   741
      _ExtentY        =   582
      ForeColor       =   0
      Enabled         =   0   'False
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÉSÉVÉbÉN"
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
   Begin VB.TextBox BD_LINNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Enabled         =   0   'False
      ForeColor       =   &H00000000&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   75
      MaxLength       =   7
      TabIndex        =   10
      Text            =   "999"
      Top             =   2955
      Visible         =   0   'False
      Width           =   420
   End
   Begin VB.Label Label2 
      Caption         =   "ñò"
      Height          =   255
      Left            =   3000
      TabIndex        =   47
      Top             =   1080
      Width           =   255
   End
   Begin VB.Label Label1 
      Caption         =   "Åi1:í èÌ 2:í îÃ 3:èâä˙ïsó« 4:êªî‘ 5:éxããïi 6:à⁄ìÆÅj"
      Height          =   255
      Left            =   2040
      TabIndex        =   26
      Top             =   750
      Width           =   5550
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "èàóù(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "ìoò^(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_DeleteCM 
         Caption         =   "çÌèú(&D)"
         Shortcut        =   ^D
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "èIóπ(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "ï“èW(&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "âÊñ èâä˙âª(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "çÄñ⁄èâä˙âª"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "çÄñ⁄ïúå≥"
      End
      Begin VB.Menu Bar21 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Cut 
         Caption         =   "êÿÇËéÊÇË(&X)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "ÉRÉsÅ[(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "ì\ÇËïtÇØ(&V)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "ëÄçÏ(&3)"
      Begin VB.Menu MN_Slist 
         Caption         =   "åÛï‚ÇÃàÍóó(&L&∆)..."
         Shortcut        =   {F5}
      End
   End
   Begin VB.Menu SM_ShortCut 
      Caption         =   "ShortCut"
      Visible         =   0   'False
      Begin VB.Menu SM_AllCopy 
         Caption         =   "çÄñ⁄ì‡óeÉRÉsÅ[(&C)"
      End
      Begin VB.Menu SM_FullPast 
         Caption         =   "çÄñ⁄Ç…ì\ÇËïtÇØ(&P)"
      End
      Begin VB.Menu SM_Esc 
         Caption         =   "éÊè¡Çµ(Esc)"
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
    TX_Message.Text = "ÉÅÉjÉÖÅ[Ç…ñﬂÇËÇ‹Ç∑ÅB"
End Sub

Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ìoò^ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_Hardcopy_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "âÊñ ÇàÛç¸ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_InsertDe_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ñæç◊çsÇë}ì¸ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_DeleteDe_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ñæç◊ÇàÍçsçÌèúÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ÉEÉBÉìÉhÉEÇï\é¶ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub BD_BKTHKNM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_BKTHKNM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_BKTHKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_BKTHKNM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_BKTHKNM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 14 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14 + 15 * PP_SSSMAIN.De), BD_BKTHKNM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_BKTHKNM(Index))
   BD_BKTHKNM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_BKTHKNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_BKTHKNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BKTHKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_BKTHKNM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 14 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_BKTHKNM(Index), KeyAscii)
End Sub

Private Sub BD_BKTHKNM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BKTHKNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_BKTHKNM(Index).SetFocus
         End If
      End If
   End If
   If BD_BKTHKNM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_BKTHKNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_BKTHKNM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_BKTHKNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_BKTHKNM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_BKTHKNM(Index).TabIndex
   End If
End Sub

Private Sub BD_BKTHKNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_BKTHKNM(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_BKTHKNM(Index))
End Sub

Private Sub BD_FRDKNSU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDKNSU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FRDKNSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_FRDKNSU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_FRDKNSU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 17 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17 + 15 * PP_SSSMAIN.De), BD_FRDKNSU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDKNSU(Index))
   BD_FRDKNSU(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_FRDKNSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_FRDKNSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRDKNSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_FRDKNSU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 17 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDKNSU(Index), KeyAscii)
End Sub

Private Sub BD_FRDKNSU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FRDKNSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_FRDKNSU(Index).SetFocus
         End If
      End If
   End If
   If BD_FRDKNSU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_FRDKNSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDKNSU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_FRDKNSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_FRDKNSU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_FRDKNSU(Index).TabIndex
   End If
End Sub

Private Sub BD_FRDKNSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_FRDKNSU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDKNSU(Index))
End Sub

Private Sub BD_FRDSU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDSU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FRDSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_FRDSU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_FRDSU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 19 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(19 + 15 * PP_SSSMAIN.De), BD_FRDSU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDSU(Index))
   BD_FRDSU(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_FRDSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_FRDSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRDSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_FRDSU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 19 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDSU(Index), KeyAscii)
End Sub

Private Sub BD_FRDSU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FRDSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_FRDSU(Index).SetFocus
         End If
      End If
   End If
   If BD_FRDSU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_FRDSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDSU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_FRDSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_FRDSU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_FRDSU(Index).TabIndex
   End If
End Sub

Private Sub BD_FRDSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_FRDSU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDSU(Index))
End Sub

Private Sub BD_FRDYZSU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDYZSU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FRDYZSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_FRDYZSU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_FRDYZSU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 16 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16 + 15 * PP_SSSMAIN.De), BD_FRDYZSU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDYZSU(Index))
   BD_FRDYZSU(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_FRDYZSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_FRDYZSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRDYZSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_FRDYZSU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 16 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDYZSU(Index), KeyAscii)
End Sub

Private Sub BD_FRDYZSU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FRDYZSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_FRDYZSU(Index).SetFocus
         End If
      End If
   End If
   If BD_FRDYZSU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_FRDYZSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDYZSU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_FRDYZSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_FRDYZSU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_FRDYZSU(Index).TabIndex
   End If
End Sub

Private Sub BD_FRDYZSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_FRDYZSU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_FRDYZSU(Index))
End Sub

Private Sub BD_HIKSU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKSU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_HIKSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_HIKSU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HIKSU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 15 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15 + 15 * PP_SSSMAIN.De), BD_HIKSU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKSU(Index))
   BD_HIKSU(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_HIKSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_HIKSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HIKSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_HIKSU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 15 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKSU(Index), KeyAscii)
End Sub

Private Sub BD_HIKSU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HIKSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_HIKSU(Index).SetFocus
         End If
      End If
   End If
   If BD_HIKSU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_HIKSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKSU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_HIKSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_HIKSU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_HIKSU(Index).TabIndex
   End If
End Sub

Private Sub BD_HIKSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_HIKSU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HIKSU(Index))
End Sub

Private Sub BD_HINCD_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_HINCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_HINCD_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HINCD(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 12 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12 + 15 * PP_SSSMAIN.De), BD_HINCD(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
   BD_HINCD(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = HINCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(12 + 15 * PP_SSSMAIN.De).CuVal))
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
         BD_HINCD(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_HINCD(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_HINCD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_HINCD(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_HINCD_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 12 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index), KeyAscii)
End Sub

Private Sub BD_HINCD_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINCD(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_HINCD(Index).SetFocus
         End If
      End If
   End If
   If BD_HINCD(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_HINCD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_HINCD(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_HINCD(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_HINCD(Index).TabIndex
   End If
End Sub

Private Sub BD_HINCD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_HINCD(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINCD(Index))
End Sub

Private Sub BD_HINNMA_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_HINNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_HINNMA_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HINNMA(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 13 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13 + 15 * PP_SSSMAIN.De), BD_HINNMA(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index))
   BD_HINNMA(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_HINNMA_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_HINNMA(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_HINNMA_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 13 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index), KeyAscii)
End Sub

Private Sub BD_HINNMA_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_HINNMA(Index).SetFocus
         End If
      End If
   End If
   If BD_HINNMA(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_HINNMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMA(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_HINNMA(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_HINNMA(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_HINNMA(Index).TabIndex
   End If
End Sub

Private Sub BD_HINNMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_HINNMA(Index).Locked = False
End Sub

Private Sub BD_LINNO_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_LINNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_LINNO_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_LINNO(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 9 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9 + 15 * PP_SSSMAIN.De), BD_LINNO(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
   BD_LINNO(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_LINNO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_LINNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_LINNO_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 9 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index), KeyAscii)
End Sub

Private Sub BD_LINNO_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_LINNO(Index).SetFocus
         End If
      End If
   End If
   If BD_LINNO(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_LINNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_LINNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_LINNO(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_LINNO(Index).TabIndex
   End If
End Sub

Private Sub BD_LINNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_LINNO(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINNO(Index))
End Sub

Private Sub BD_ODNYTDT_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ODNYTDT(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_ODNYTDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_ODNYTDT_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_ODNYTDT(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 11 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11 + 15 * PP_SSSMAIN.De), BD_ODNYTDT(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ODNYTDT(Index))
   BD_ODNYTDT(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_ODNYTDT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_ODNYTDT(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_ODNYTDT(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_ODNYTDT_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 11 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ODNYTDT(Index), KeyAscii)
End Sub

Private Sub BD_ODNYTDT_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_ODNYTDT(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_ODNYTDT(Index).SetFocus
         End If
      End If
   End If
   If BD_ODNYTDT(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_ODNYTDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ODNYTDT(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_ODNYTDT(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_ODNYTDT(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_ODNYTDT(Index).TabIndex
   End If
End Sub

Private Sub BD_ODNYTDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_ODNYTDT(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_ODNYTDT(Index))
End Sub

Private Sub BD_OTPSU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_OTPSU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OTPSU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_OTPSU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_OTPSU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 18 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18 + 15 * PP_SSSMAIN.De), BD_OTPSU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_OTPSU(Index))
   BD_OTPSU(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_OTPSU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_OTPSU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OTPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_OTPSU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 18 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_OTPSU(Index), KeyAscii)
End Sub

Private Sub BD_OTPSU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OTPSU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_OTPSU(Index).SetFocus
         End If
      End If
   End If
   If BD_OTPSU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_OTPSU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_OTPSU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_OTPSU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_OTPSU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_OTPSU(Index).TabIndex
   End If
End Sub

Private Sub BD_OTPSU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_OTPSU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_OTPSU(Index))
End Sub

Private Sub BD_SBNNO_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SBNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SBNNO_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SBNNO(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 10 + 15 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10 + 15 * PP_SSSMAIN.De), BD_SBNNO(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 9 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
   BD_SBNNO(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SBNNO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SBNNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SBNNO_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 10 + 11 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index), KeyAscii)
End Sub

Private Sub BD_SBNNO_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SBNNO(Index).SetFocus
         End If
      End If
   End If
   If BD_SBNNO(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SBNNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SBNNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SBNNO(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SBNNO(Index).TabIndex
   End If
End Sub

Private Sub BD_SBNNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SBNNO(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SBNNO(Index))
End Sub

Private Sub CM_DeleteDe_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If PP_SSSMAIN.Tx >= 9 And PP_SSSMAIN.Tx < 174 Then
      If (PP_SSSMAIN.Tx - 9) \ 11 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
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
   wk_Cursor = AE_Execute_SSSMAIN()
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
   If PP_SSSMAIN.Tx >= 9 And PP_SSSMAIN.Tx < 174 Then
      If (PP_SSSMAIN.Tx - 9) \ 11 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         wk_Cursor = AE_InsertDe_SSSMAIN()
      End If
   Else
      Beep
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

Private Sub CM_LCONFIG_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   PP_SSSMAIN.NeglectLostFocusCheck = False
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub CM_LCONFIG_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(1).Picture
End Sub

Private Sub CM_LCONFIG_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then CM_LCONFIG.Picture = IM_LCONFIG(0).Picture
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

Private Sub CS_FDNDT_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(1).TypeA, 1) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(1)
      If PP_SSSMAIN.Tx <> 1 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_FDNDT_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_FDNDT_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_FDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_JDNNO_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(2).TypeA, 2) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(2)
      If PP_SSSMAIN.Tx <> 2 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_JDNNO_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_JDNNO_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
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

Private Sub FM_PANEL3D3_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D4_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub Form_Activate() 'Generated.
Dim wk_ww As Integer
Dim wk_De As Integer
Dim wk_xx As Integer
   If PP_SSSMAIN.Activated = 0 Then
      PP_SSSMAIN.Activated = 1
      wk_De = 1
      Do While wk_De <= PP_SSSMAIN.MaxDspC
         wk_ww = 0
         Do While wk_ww < 11
            wk_xx = 9 + 11 * wk_De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 9 + wk_ww).Visible
            wk_ww = wk_ww + 1
         Loop
         wk_De = wk_De + 1
      Loop
   End If
End Sub

Private Sub Form_Load() 'Generated.
Dim wk_De As Integer
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
   AE_Title$ = "èoâ◊éwé¶ìoò^Åiå¬ï Åj                    "
'èââÊñ ï\é¶ÇÃê´î\É`ÉÖÅ[ÉjÉìÉOóp ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 14970
   .FormHeight = 8715
   .MaxDe = 98
   .MaxDsp = 14
   .HeadN = 9
   .BodyN = 11
   .BodyV = 15
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 0
   .BodyPx = 9
   .EBodyPx = 1494
   .TailPx = 1494
   .PrpC = 1494
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
      AE_CtB = AE_CtB + 174
      ReDim Preserve AE_Controls(.CtB + 173)
      .MainFormFile = "SYKET51.FRM"
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
      AE_MsgBox "çƒê∂ê¨Ç™ïKóvÇ≈Ç∑ÅB", vbCritical, "ÇÖÇÖÇÖ": End
#Else
      AE_MsgBox "çƒê∂ê¨Ç™ïKóvÇ≈Ç∑ÅB", vbCritical, "ÇÖÇÖÇÖ"
#End If
   End If
   If .MainForm = "" Then
      .MainForm = "SSSMAIN"
      Call AE_PSIR_SSSMAIN
      wk_ww = 0
      wk_De = 1
      wk_HeadN = 0: wk_BodyN = 0: wk_EBodyN = 0: wk_TailN = 0
      Do While wk_ww < AE_PSIC
         wk_SmrBuf$ = Trim$(AE_PSI$(wk_ww)) & Space$(1)
         wk_ww = wk_ww + 1
         Select Case UCase$(Left$(wk_SmrBuf$, Cn_PrfxLen))
            Case "HD_", "HV_"
               Call AE_SetCp(CP_SSSMAIN(wk_HeadN), wk_HeadN, wk_SmrBuf$, CQ_SSSMAIN(wk_HeadN))
               wk_HeadN = wk_HeadN + 1
            Case "BD_", "BV_"
               Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 9), wk_BodyN + 9, wk_SmrBuf$, CQ_SSSMAIN(wk_BodyN + 9))
               wk_BodyN = wk_BodyN + 1
         End Select
      Loop
      Do While wk_De <= 98
         wk_PxBase = 9
         Do While wk_PxBase < 24
            wk_Px = wk_PxBase + 15 * wk_De
            Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
            wk_PxBase = wk_PxBase + 1
         Loop
         wk_De = wk_De + 1
      Loop
   End If
   HD_WRKKB = ""
   HD_FDNDT = ""
   HD_JDNNO = ""
   HD_SOUCD = ""
   HD_SOUNM = ""
   HD_TOKCD = ""
   HD_TOKRN = ""
   HD_OPEID = ""
   HD_OPENM = ""
   BD_LINNO(0) = ""
   BD_SBNNO(0) = ""
   BD_ODNYTDT(0) = ""
   BD_HINCD(0) = ""
   BD_HINNMA(0) = ""
   BD_BKTHKNM(0) = ""
   BD_HIKSU(0) = ""
   BD_FRDYZSU(0) = ""
   BD_FRDKNSU(0) = ""
   BD_OTPSU(0) = ""
   BD_FRDSU(0) = ""
   For wk_De = 1 To 14
      Load BD_FRDSU(wk_De)
      Load BD_OTPSU(wk_De)
      Load BD_FRDKNSU(wk_De)
      Load BD_FRDYZSU(wk_De)
      Load BD_HIKSU(wk_De)
      Load BD_BKTHKNM(wk_De)
      Load BD_HINNMA(wk_De)
      Load BD_HINCD(wk_De)
      Load BD_ODNYTDT(wk_De)
      Load BD_SBNNO(wk_De)
      Load BD_LINNO(wk_De)
   Next wk_De
   HD_WRKKB.TabIndex = 0
   Set AE_Controls(.CtB + 0) = HD_WRKKB
   HD_FDNDT.TabIndex = 1
   Set AE_Controls(.CtB + 1) = HD_FDNDT
   HD_JDNNO.TabIndex = 2
   Set AE_Controls(.CtB + 2) = HD_JDNNO
   HD_SOUCD.TabIndex = 3
   Set AE_Controls(.CtB + 3) = HD_SOUCD
   HD_SOUNM.TabIndex = 4
   Set AE_Controls(.CtB + 4) = HD_SOUNM
   HD_TOKCD.TabIndex = 5
   Set AE_Controls(.CtB + 5) = HD_TOKCD
   HD_TOKRN.TabIndex = 6
   Set AE_Controls(.CtB + 6) = HD_TOKRN
   HD_OPEID.TabIndex = 7
   Set AE_Controls(.CtB + 7) = HD_OPEID
   HD_OPENM.TabIndex = 8
   Set AE_Controls(.CtB + 8) = HD_OPENM
   For wk_De = 0 To 14
      wk_TxBase = 11 * wk_De
      BD_LINNO(wk_De).TabIndex = 9 + wk_TxBase
      Set AE_Controls(.CtB + 9 + wk_TxBase) = BD_LINNO(wk_De)
      BD_SBNNO(wk_De).TabIndex = 10 + wk_TxBase
      Set AE_Controls(.CtB + 10 + wk_TxBase) = BD_SBNNO(wk_De)
      BD_ODNYTDT(wk_De).TabIndex = 11 + wk_TxBase
      Set AE_Controls(.CtB + 11 + wk_TxBase) = BD_ODNYTDT(wk_De)
      BD_HINCD(wk_De).TabIndex = 12 + wk_TxBase
      Set AE_Controls(.CtB + 12 + wk_TxBase) = BD_HINCD(wk_De)
      BD_HINNMA(wk_De).TabIndex = 13 + wk_TxBase
      Set AE_Controls(.CtB + 13 + wk_TxBase) = BD_HINNMA(wk_De)
      BD_BKTHKNM(wk_De).TabIndex = 14 + wk_TxBase
      Set AE_Controls(.CtB + 14 + wk_TxBase) = BD_BKTHKNM(wk_De)
      BD_HIKSU(wk_De).TabIndex = 15 + wk_TxBase
      Set AE_Controls(.CtB + 15 + wk_TxBase) = BD_HIKSU(wk_De)
      BD_FRDYZSU(wk_De).TabIndex = 16 + wk_TxBase
      Set AE_Controls(.CtB + 16 + wk_TxBase) = BD_FRDYZSU(wk_De)
      BD_FRDKNSU(wk_De).TabIndex = 17 + wk_TxBase
      Set AE_Controls(.CtB + 17 + wk_TxBase) = BD_FRDKNSU(wk_De)
      BD_OTPSU(wk_De).TabIndex = 18 + wk_TxBase
      Set AE_Controls(.CtB + 18 + wk_TxBase) = BD_OTPSU(wk_De)
      BD_FRDSU(wk_De).TabIndex = 19 + wk_TxBase
      Set AE_Controls(.CtB + 19 + wk_TxBase) = BD_FRDSU(wk_De)
   Next wk_De
   TX_CursorRest.TabIndex = 174
   Set AE_Timer(.ScX) = TM_StartUp
   Set AE_CursorRest(.ScX) = TX_CursorRest
   Set AE_ModeBar(.ScX) = TX_Mode
   Set AE_StatusBar(.ScX) = TX_Message
   Set AE_StatusCodeBar(.ScX) = TX_Message
   .Mode = Cn_Mode1: TX_Mode = "í«â¡"
   Call AE_ClearInitValStatus_SSSMAIN
   .PY_BTop = FR_SSSMAIN.Height
   ReDim AE_BodyTop(11)
   wk_Tx = 9
   Do While wk_Tx < 20
      wk_Top = AE_Controls(.CtB + wk_Tx).Top
      If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
      AE_BodyTop(wk_Tx - 9) = wk_Top
      wk_Tx = wk_Tx + 1
   Loop
   .PY_EBTop = FR_SSSMAIN.Height
   PY_TTop = FR_SSSMAIN.Height
   Set AE_ScrlBar(.ScX) = VS_Scrl
   PY_BBtm = 0
   wk_Tx = 9: wk_ww = 0
   Do While wk_Tx < 20
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
   If .MaxDspC > 14 Then .MaxDspC = 14
   .NrBodyTx = 9 + 11 * (.MaxDspC + 1)
   .ScrlMaxL = .MaxDspC: If .ScrlMaxL = 0 Then .ScrlMaxL = 1
   wk_Top = .PY_BTop
   VS_Scrl.Top = wk_Top
   wk_Height = .PY_BHgt * (.MaxDspC + 1)
   VS_Scrl.Height = wk_Height + 15
   VS_Scrl.TabStop = False
   VS_Scrl.Min = 0
   VS_Scrl.Max = 0
   VS_Scrl.LargeChange = .ScrlMaxL
   If .MaxDspC = 98 Then VS_Scrl.Visible = False
   .MaxEDspC = 0
   .NrEBodyTx = 174
   .EScrlMaxL = 1
   Call AE_TabStop_SSSMAIN(0, 173, True)
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   wk_De = 1
   Do While wk_De <= .MaxDspC
      wk_ww = 0
      Do While wk_ww < 11
         wk_Tx = 9 + 11 * wk_De + wk_ww
         AE_Controls(.CtB + wk_Tx).Top = AE_BodyTop(wk_ww) + .PY_BHgt * wk_De
         wk_ww = wk_ww + 1
      Loop
      wk_De = wk_De + 1
   Loop
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
   Call AE_WindowProcSet_SSSMAIN
   ReleaseTabCapture 0
   SetTabCapture FR_SSSMAIN.hwnd
   wk_Var = SSSMAIN_BeginPrg(PP_SSSMAIN)
   .FormWidth = FR_SSSMAIN.Width
   .FormHeight = FR_SSSMAIN.Height
'èââÊñ ï\é¶ÇÃê´î\É`ÉÖÅ[ÉjÉìÉOóp ----------
'   AE_MsgBox Str$(Timer - StartTime), vbInformation, AE_Title$
'-----------------------------------------
   .TimerStartUp = True
   End With
   TM_StartUp = True
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

Private Sub HD_FDNDT_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_FDNDT) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FDNDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_FDNDT_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 1
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_FDNDT)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If FDNDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 1)) Then
      PP_SSSMAIN.CursorDest = Cn_DestBySkip
      If AE_CursorSkip_SSSMAIN() Then
         PP_SSSMAIN.SlistCall = False
         Exit Sub
      End If
      wk_Int = AE_ExecuteX_SSSMAIN()
      If wk_Int <> Cn_CuCurrent And wk_Int <> Cn_CuInCompletePx Then
         Call AE_CursorSub_SSSMAIN(wk_Int)
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx)
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_FDNDT)
   HD_FDNDT.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = FDNDT_Slist(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal), PP_SSSMAIN)
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
         CP_SSSMAIN(1).TpStr = wk_Slisted
         CP_SSSMAIN(1).CIn = Cn_ChrInput
         HD_FDNDT = wk_Slisted
         Call AE_Check_SSSMAIN_FDNDT(AE_Val3(CP_SSSMAIN(1), (HD_FDNDT)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_FDNDT_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_FDNDT, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FDNDT(AE_Val3(CP_SSSMAIN(1), (HD_FDNDT)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (1)
   End If
End Sub

Private Sub HD_FDNDT_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 1 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_FDNDT, KeyAscii)
End Sub

Private Sub HD_FDNDT_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FDNDT(AE_Val3(CP_SSSMAIN(1), (HD_FDNDT)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_FDNDT.SetFocus
      End If
   End If
   If HD_FDNDT.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_FDNDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_FDNDT)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_FDNDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_FDNDT.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_FDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_FDNDT.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_FDNDT)
End Sub

Private Sub HD_JDNNO_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNNO) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_JDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_JDNNO_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 2
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 2
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNNO)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNNO)
   HD_JDNNO.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = JDNNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(0).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
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
         CP_SSSMAIN(2).TpStr = wk_Slisted
         CP_SSSMAIN(2).CIn = Cn_ChrInput
         HD_JDNNO = wk_Slisted
         Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(2), (HD_JDNNO)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_JDNNO_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_JDNNO, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(2), (HD_JDNNO)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (2)
   End If
End Sub

Private Sub HD_JDNNO_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNNO, KeyAscii)
End Sub

Private Sub HD_JDNNO_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(2), (HD_JDNNO)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_JDNNO.SetFocus
      End If
   End If
   If HD_JDNNO.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_JDNNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNNO)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_JDNNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_JDNNO.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 2
   End If
End Sub

Private Sub HD_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_JDNNO.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_JDNNO)
End Sub

Private Sub HD_OPEID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPEID) Then
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
   PP_SSSMAIN.Tx = 7
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 7
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPEID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPEID)
   HD_OPEID.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(7), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (7)
   End If
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 7 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPEID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(7), (HD_OPEID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPEID.SetFocus
      End If
   End If
   If HD_OPEID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 7
   End If
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPEID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), HD_OPEID)
End Sub

Private Sub HD_OPENM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_OPENM) Then
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
   PP_SSSMAIN.Tx = 8
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_OPENM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_OPENM)
   HD_OPENM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(8).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(8), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (8)
   End If
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 8 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_OPENM, KeyAscii)
End Sub

Private Sub HD_OPENM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(8), (HD_OPENM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPENM.SetFocus
      End If
   End If
   If HD_OPENM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 8
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), HD_OPENM)
End Sub

Private Sub HD_SOUCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_SOUCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_SOUCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 3
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 3
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_SOUCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_SOUCD)
   HD_SOUCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = SOUCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal))
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
         CP_SSSMAIN(3).TpStr = wk_Slisted
         CP_SSSMAIN(3).CIn = Cn_ChrInput
         HD_SOUCD = wk_Slisted
         Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(3), (HD_SOUCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_SOUCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_SOUCD, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(3), (HD_SOUCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (3)
   End If
End Sub

Private Sub HD_SOUCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_SOUCD, KeyAscii)
End Sub

Private Sub HD_SOUCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(3), (HD_SOUCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_SOUCD.SetFocus
      End If
   End If
   If HD_SOUCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_SOUCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_SOUCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_SOUCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_SOUCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 3
   End If
End Sub

Private Sub HD_SOUCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_SOUCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(3), HD_SOUCD)
End Sub

Private Sub HD_SOUNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_SOUNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_SOUNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 4
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 4
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_SOUNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_SOUNM)
   HD_SOUNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_SOUNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_SOUNM, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(4), (HD_SOUNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (4)
   End If
End Sub

Private Sub HD_SOUNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_SOUNM, KeyAscii)
End Sub

Private Sub HD_SOUNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(4), (HD_SOUNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_SOUNM.SetFocus
      End If
   End If
   If HD_SOUNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_SOUNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_SOUNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_SOUNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_SOUNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 4
   End If
End Sub

Private Sub HD_SOUNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_SOUNM.Locked = False
End Sub

Private Sub HD_TOKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TOKCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_TOKCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 5
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 5
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
   HD_TOKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = TOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(5).CuVal))
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
         CP_SSSMAIN(5).TpStr = wk_Slisted
         CP_SSSMAIN(5).CIn = Cn_ChrInput
         HD_TOKCD = wk_Slisted
         Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), (HD_TOKCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_TOKCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TOKCD, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), (HD_TOKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (5)
   End If
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_TOKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(5), (HD_TOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TOKCD.SetFocus
      End If
   End If
   If HD_TOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_TOKCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_TOKCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_TOKCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 5
   End If
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TOKCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(5), HD_TOKCD)
End Sub

Private Sub HD_TOKRN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TOKRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_TOKRN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 6
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 6
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN)
   HD_TOKRN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_TOKRN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TOKRN, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(6), (HD_TOKRN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (6)
   End If
End Sub

Private Sub HD_TOKRN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 6 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_TOKRN, KeyAscii)
End Sub

Private Sub HD_TOKRN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(6), (HD_TOKRN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TOKRN.SetFocus
      End If
   End If
   If HD_TOKRN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_TOKRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TOKRN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_TOKRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_TOKRN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 6
   End If
End Sub

Private Sub HD_TOKRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TOKRN.Locked = False
End Sub

Private Sub HD_WRKKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_WRKKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_WRKKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_WRKKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 0
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 0
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_WRKKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_WRKKB)
   HD_WRKKB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_WRKKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_WRKKB, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_WRKKB(AE_Val3(CP_SSSMAIN(0), (HD_WRKKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (0)
   End If
End Sub

Private Sub HD_WRKKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 0 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_WRKKB, KeyAscii)
End Sub

Private Sub HD_WRKKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_WRKKB(AE_Val3(CP_SSSMAIN(0), (HD_WRKKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_WRKKB.SetFocus
      End If
   End If
   If HD_WRKKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_WRKKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_WRKKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_WRKKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_WRKKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 0
   End If
End Sub

Private Sub HD_WRKKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_WRKKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_WRKKB)
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
   If PP_SSSMAIN.Mode = Cn_Mode4 Then
      MN_DeleteCM = True
   Else
      MN_DeleteCM = False
   End If
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

Private Sub MN_DeleteCm_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode < Cn_Mode4 Then
      Beep
      wk_Cursor = Cn_CuCurrent
   Else
      wk_Cursor = AE_DeleteCm_SSSMAIN()
   End If
   If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN
End Sub

Private Sub MN_EditMn_Click() 'Generated.
Const CF_TEXT As Integer = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_APPENDC = True
   MN_ClearItm = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 174 Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
   End If
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 9 And PP_SSSMAIN.Tx < 174 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
      If (PP_SSSMAIN.Tx - 9) \ 11 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
      End If
   End If
   MN_Copy = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 174 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
      End If
   End If
   MN_Cut = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 174 Then
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
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 174 Then
      If TypeOf Screen.ActiveControl Is TextBox Then
         If Clipboard.GetFormat(CF_TEXT) Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
         End If
      End If
   End If
   MN_UnDoItem = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 174 Then
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
   wk_Cursor = AE_Execute_SSSMAIN()
   PP_SSSMAIN.ExplicitExec = False
   If wk_Cursor = Cn_CuInit Then PP_SSSMAIN.SuppressGotLostFocus = 1
   Call AE_CursorSub_SSSMAIN(wk_Cursor)
   PP_SSSMAIN.Executing = False
End Sub

Private Sub MN_Oprt_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_Slist = False
   If False Then
   ElseIf PP_SSSMAIN.Tx = 1 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 2 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 3 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 5 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf (PP_SSSMAIN.Tx - 9) Mod 11 = 3 And PP_SSSMAIN.Tx >= 9 And PP_SSSMAIN.Tx < 174 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   End If
   If PP_SSSMAIN.Mode >= Cn_Mode3 Then
   Else
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
      If Screen.ActiveControl.TabIndex >= 174 Then
            Screen.ActiveControl.SelText = Clipboard.GetText()
         Else
            Call AE_Paste(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), Screen.ActiveControl)
         End If
      End If
   End If
End Sub

Private Sub MN_Slist_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.SlistSw = True
   PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
   Call AE_Slist_SSSMAIN
   PP_SSSMAIN.SlistSw = False
End Sub

Private Sub MN_UnDoItem_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   Call AE_UnDoItem_SSSMAIN
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
         Do While wk_ww < 11
            Tx = 9 + 11 * De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 9 + wk_ww).Visible
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
         wk_Bool = AE_CursorUp_SSSMAIN(174)
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
         wk_Bool = AE_CursorPrev_SSSMAIN(174)
      End If
   ElseIf (KEYCODE = vbKeyExecute Or KEYCODE = vbKeyReturn) And Shift = 0 Then
   ElseIf KEYCODE = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(98, False)
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorPrevDsp_SSSMAIN(174) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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


