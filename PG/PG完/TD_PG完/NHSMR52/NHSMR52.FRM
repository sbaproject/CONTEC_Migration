VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'Ã◊Øƒ
   BorderStyle     =   1  'å≈íË(é¿ê¸)
   Caption         =   "î[ì¸êÊè⁄ç◊ìoò^"
   ClientHeight    =   7890
   ClientLeft      =   510
   ClientTop       =   2385
   ClientWidth     =   11715
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
   Icon            =   "NHSMR52.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z µ∞¿ﬁ∞
   ScaleHeight     =   7890
   ScaleWidth      =   11715
   Begin Threed5.SSCommand5 CS_DENNOA 
      Height          =   360
      Left            =   225
      TabIndex        =   69
      TabStop         =   0   'False
      Top             =   2475
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   635
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
      Caption         =   "é©ìÆçÃî‘"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin VB.TextBox HD_DENNOA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   300
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   255
      MaxLength       =   13
      TabIndex        =   70
      Text            =   "XXXXXXXX9"
      Top             =   2520
      Width           =   1080
   End
   Begin VB.Frame FM_TOKKB 
      Caption         =   "äCäOéÊà¯ãÊï™"
      Height          =   700
      Index           =   1
      Left            =   180
      TabIndex        =   66
      Top             =   705
      Width           =   2175
      Begin VB.TextBox HD_FRNKB 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   120
         MaxLength       =   5
         TabIndex        =   67
         Text            =   "9"
         Top             =   240
         Width           =   240
      End
      Begin VB.Label Label5 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H80000005&
         BackStyle       =   0  'ìßñæ
         Caption         =   "0:çëì‡  1:äCäO"
         ForeColor       =   &H80000008&
         Height          =   270
         Index           =   1
         Left            =   480
         TabIndex        =   68
         Top             =   300
         Width           =   1815
      End
   End
   Begin VB.TextBox HD_NHSMLAD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   5880
      MaxLength       =   54
      TabIndex        =   65
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3XXXXXXXXX4XXXXXXXXX5"
      Top             =   4905
      Width           =   5400
   End
   Begin VB.TextBox HD_OLNGRPCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   13
      TabIndex        =   63
      Text            =   "XXXXXXXX9"
      Top             =   6615
      Width           =   1200
   End
   Begin VB.TextBox HD_NGRPCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   13
      TabIndex        =   61
      Text            =   "XXXXXXXX9"
      Top             =   5985
      Width           =   1200
   End
   Begin VB.TextBox HD_OLDNHSCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   13
      TabIndex        =   59
      Text            =   "XXXXXXXX9"
      Top             =   6300
      Width           =   1200
   End
   Begin VB.TextBox HD_NHSZP 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   180
      MaxLength       =   24
      TabIndex        =   57
      Text            =   "XXXXXXX8"
      Top             =   3645
      Width           =   1380
   End
   Begin VB.TextBox HD_CHIIKIRN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   34
      TabIndex        =   55
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   5235
      Width           =   2310
   End
   Begin VB.TextBox HD_GYOSHURN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   34
      TabIndex        =   54
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   4920
      Width           =   2310
   End
   Begin VB.TextBox HD_BINRN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   2130
      MaxLength       =   44
      TabIndex        =   53
      Text            =   "MMMMMMMMM1"
      Top             =   5550
      Width           =   2310
   End
   Begin VB.TextBox HD_CHIIKI 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   1260
      MaxLength       =   9
      TabIndex        =   51
      Text            =   "XXXX5"
      Top             =   5235
      Width           =   885
   End
   Begin VB.TextBox HD_GYOSHU 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   1260
      MaxLength       =   9
      TabIndex        =   49
      Text            =   "XXXX5"
      Top             =   4920
      Width           =   885
   End
   Begin VB.TextBox HD_BINCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   1260
      MaxLength       =   6
      TabIndex        =   47
      Text            =   "12"
      Top             =   5550
      Width           =   885
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   9165
      MaxLength       =   24
      TabIndex        =   46
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   645
      Width           =   2205
   End
   Begin VB.TextBox HD_NHSRNNK 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   6  'îºäp∂¿∂≈
      Left            =   5880
      MaxLength       =   24
      TabIndex        =   45
      Text            =   "XXXXXXXXX1XXXXXXXXX2"
      Top             =   2790
      Width           =   2430
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H8000000F&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   6  'îºäp∂¿∂≈
      Left            =   8460
      MaxLength       =   10
      TabIndex        =   43
      Text            =   "XXXXX6"
      Top             =   645
      Width           =   720
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   735
      Index           =   0
      Left            =   -45
      TabIndex        =   35
      Top             =   7155
      Width           =   12135
      _ExtentX        =   21405
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
         Index           =   7
         Left            =   675
         TabIndex        =   36
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
            TabIndex        =   37
            Text            =   "NHSMR52.frx":000C
            Top             =   90
            Width           =   7575
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "NHSMR52.frx":0043
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D14 
      Height          =   555
      Left            =   -45
      TabIndex        =   33
      Top             =   0
      Width           =   11805
      _ExtentX        =   20823
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
         Left            =   9675
         TabIndex        =   34
         Top             =   135
         Width           =   1725
         _ExtentX        =   3043
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
      Begin VB.Image CM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   1440
         Picture         =   "NHSMR52.frx":01CD
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   585
         Picture         =   "NHSMR52.frx":081F
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   950
         Picture         =   "NHSMR52.frx":0E71
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   1800
         Picture         =   "NHSMR52.frx":0FFB
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   225
         Picture         =   "NHSMR52.frx":164D
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image2 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   510
         Left            =   0
         Top             =   0
         Width           =   3330
      End
   End
   Begin VB.Frame Frame3D2 
      Caption         =   "ñºèÃœ∆≠±Ÿì¸óÕãÊï™"
      ForeColor       =   &H00000000&
      Height          =   1005
      Left            =   5880
      TabIndex        =   29
      Top             =   5400
      Width           =   2880
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   330
         Index           =   8
         Left            =   540
         TabIndex        =   31
         Top             =   360
         Width           =   2010
         _ExtentX        =   3545
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
         Alignment       =   2
         BevelOuter      =   1
         Caption         =   " 1:Ç∑ÇÈ  9:ÇµÇ»Ç¢"
         OutLine         =   -1  'True
      End
      Begin VB.TextBox HD_NHSNMMKB 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         HelpContextID   =   285
         IMEMode         =   2  'µÃ
         Left            =   315
         MaxLength       =   5
         TabIndex        =   30
         Text            =   "9"
         Top             =   360
         Width           =   240
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   645
      Left            =   0
      TabIndex        =   28
      Top             =   8000
      Width           =   13605
      _ExtentX        =   16695
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
      OutLine         =   -1  'True
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   555
         Left            =   12105
         TabIndex        =   32
         Text            =   "”∞ƒﬁ"
         Top             =   90
         Width           =   870
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   4005
         Picture         =   "NHSMR52.frx":17D7
         Top             =   90
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   2
         Left            =   4320
         Picture         =   "NHSMR52.frx":1961
         Top             =   90
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   3150
         Picture         =   "NHSMR52.frx":1AEB
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   2745
         Picture         =   "NHSMR52.frx":213D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   2250
         Picture         =   "NHSMR52.frx":278F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   1395
         Picture         =   "NHSMR52.frx":2919
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "NHSMR52.frx":2AA3
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   540
         Picture         =   "NHSMR52.frx":2C2D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   990
         Picture         =   "NHSMR52.frx":2DB7
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   1845
         Picture         =   "NHSMR52.frx":2F41
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   7200
         Picture         =   "NHSMR52.frx":30CB
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   6795
         Picture         =   "NHSMR52.frx":371D
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   7605
         Picture         =   "NHSMR52.frx":3D6F
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   8010
         Picture         =   "NHSMR52.frx":43C1
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   11
      Left            =   8295
      TabIndex        =   27
      Top             =   3330
      Width           =   2325
      _ExtentX        =   4101
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
      Caption         =   "î[ì¸êÊíSìñé“"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSCTANM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   8295
      MaxLength       =   24
      TabIndex        =   26
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   3645
      Width           =   2325
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   10
      Left            =   8295
      TabIndex        =   25
      Top             =   3960
      Width           =   2325
      _ExtentX        =   4101
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
      Caption         =   "î[ïiêÊë„ï\é“ñº"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSBOSNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   8295
      MaxLength       =   24
      TabIndex        =   24
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   4275
      Width           =   2325
   End
   Begin VB.Frame Frame3D1 
      Caption         =   "î[ïiêÊï™óﬁ"
      ForeColor       =   &H00000000&
      Height          =   1275
      Left            =   12690
      TabIndex        =   17
      Top             =   4365
      Width           =   9690
      Begin VB.TextBox HD_NHSCLAID 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   90
         MaxLength       =   10
         TabIndex        =   21
         Text            =   "999999"
         Top             =   630
         Visible         =   0   'False
         Width           =   735
      End
      Begin VB.TextBox HD_NHSCLBID 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   3330
         MaxLength       =   10
         TabIndex        =   23
         Text            =   "999999"
         Top             =   630
         Visible         =   0   'False
         Width           =   735
      End
      Begin VB.TextBox HD_NHSCLBNM 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   4050
         MaxLength       =   24
         TabIndex        =   22
         Text            =   "XXXXXXXXXXXXXXXXXXXX"
         Top             =   630
         Visible         =   0   'False
         Width           =   2220
      End
      Begin VB.TextBox HD_NHSCLANM 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   810
         MaxLength       =   24
         TabIndex        =   20
         Text            =   "XXXXXXXXXXXXXXXXXXXX"
         Top             =   630
         Visible         =   0   'False
         Width           =   2220
      End
      Begin VB.TextBox HD_NHSCLCNM 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   7335
         MaxLength       =   24
         TabIndex        =   19
         Text            =   "XXXXXXXXXXXXXXXXXXXX"
         Top             =   630
         Visible         =   0   'False
         Width           =   2220
      End
      Begin VB.TextBox HD_NHSCLCID 
         Appearance      =   0  'Ã◊Øƒ
         BackColor       =   &H00FFFFFF&
         Height          =   330
         IMEMode         =   2  'µÃ
         Left            =   6615
         MaxLength       =   10
         TabIndex        =   18
         Text            =   "999999"
         Top             =   630
         Visible         =   0   'False
         Width           =   735
      End
      Begin Threed5.SSCommand5 CS_NHSCLCID 
         Height          =   330
         Left            =   6615
         TabIndex        =   41
         TabStop         =   0   'False
         Top             =   315
         Width           =   2940
         _ExtentX        =   5186
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
         Caption         =   "ï™Å@óﬁÅ@Çb"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_NHSCLBID 
         Height          =   330
         Left            =   3330
         TabIndex        =   40
         TabStop         =   0   'False
         Top             =   315
         Width           =   2940
         _ExtentX        =   5186
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
         Caption         =   "ï™Å@óﬁÅ@Ça"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSCommand5 CS_NHSCLAID 
         Height          =   330
         Left            =   90
         TabIndex        =   39
         TabStop         =   0   'False
         Top             =   315
         Width           =   2940
         _ExtentX        =   5186
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
         Caption         =   "ï™Å@óﬁÅ@Ç`"
         BevelWidth      =   1
         RoundedCorners  =   0   'False
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   6
      Left            =   5880
      TabIndex        =   16
      Top             =   3960
      Width           =   2430
      _ExtentX        =   4286
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
      Caption         =   "F A X"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSFX 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   5880
      MaxLength       =   24
      TabIndex        =   15
      Text            =   "XXXXXXXXX1XXXXXXXXX2"
      Top             =   4275
      Width           =   2430
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   5
      Left            =   5880
      TabIndex        =   14
      Top             =   3330
      Width           =   2430
      _ExtentX        =   4286
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
      Caption         =   "T E L"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSTL 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   5880
      MaxLength       =   24
      TabIndex        =   13
      Text            =   "XXXXXXXXX1XXXXXXXXX2"
      Top             =   3645
      Width           =   2430
   End
   Begin VB.TextBox HD_NHSADC 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   44
      TabIndex        =   12
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   4275
      Width           =   4380
   End
   Begin VB.TextBox HD_NHSADB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   44
      TabIndex        =   11
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   3960
      Width           =   4380
   End
   Begin VB.TextBox HD_NHSADA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   44
      TabIndex        =   10
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   3645
      Width           =   4380
   End
   Begin VB.TextBox HD_NHSRN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   44
      TabIndex        =   9
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   2790
      Width           =   4350
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   1
      Left            =   1545
      TabIndex        =   8
      Top             =   2475
      Width           =   4350
      _ExtentX        =   7673
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
      Caption         =   "ó™Å@Å@Å@èÃ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   0
      Left            =   5880
      TabIndex        =   7
      Top             =   1530
      Width           =   1275
      _ExtentX        =   2249
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
      Caption         =   "∂≈"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSNK 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   6  'îºäp∂¿∂≈
      Left            =   5880
      MaxLength       =   14
      TabIndex        =   6
      Text            =   "XXXXXXXXXX1"
      Top             =   1845
      Width           =   1275
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
      TabIndex        =   5
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   3
      Left            =   1545
      TabIndex        =   4
      Top             =   1530
      Width           =   4350
      _ExtentX        =   7673
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
      Caption         =   "*ñº           èÃ "
      OutLine         =   -1  'True
   End
   Begin VB.TextBox HD_NHSNMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   64
      TabIndex        =   3
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM6"
      Top             =   1845
      Width           =   4350
   End
   Begin VB.TextBox HD_NHSNMB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1545
      MaxLength       =   44
      TabIndex        =   2
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM6"
      Top             =   2160
      Width           =   4350
   End
   Begin VB.TextBox HD_NHSCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      HelpContextID   =   285
      IMEMode         =   2  'µÃ
      Left            =   195
      MaxLength       =   13
      TabIndex        =   1
      Text            =   "XXXXXXXX9"
      Top             =   1845
      Width           =   1365
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   4
      Left            =   1545
      TabIndex        =   0
      Top             =   3330
      Width           =   4380
      _ExtentX        =   7726
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
      Caption         =   "*èZÅ@Å@Å@Å@Å@èä"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_NHSCD 
      Height          =   330
      Left            =   195
      TabIndex        =   38
      TabStop         =   0   'False
      Top             =   1530
      Width           =   1365
      _ExtentX        =   2408
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
      Caption         =   "*î[ì¸êÊ∫∞ƒﬁ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   9
      Left            =   7245
      TabIndex        =   42
      Top             =   645
      Width           =   1230
      _ExtentX        =   2170
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
      Caption         =   "ì¸óÕíSìñé“"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   12
      Left            =   5880
      TabIndex        =   44
      Top             =   2475
      Width           =   2430
      _ExtentX        =   4286
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
      Caption         =   "*ó™èÃ∂≈"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_BINCD 
      Height          =   330
      Left            =   150
      TabIndex        =   48
      TabStop         =   0   'False
      Top             =   5550
      Width           =   1125
      _ExtentX        =   1984
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
      Caption         =   "*ï÷ñº"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_GYOSHU 
      Height          =   330
      Left            =   150
      TabIndex        =   50
      TabStop         =   0   'False
      Top             =   4920
      Width           =   1125
      _ExtentX        =   1984
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
      Caption         =   "*ã∆éÌ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSCommand5 CS_CHIIKI 
      Height          =   330
      Left            =   150
      TabIndex        =   52
      TabStop         =   0   'False
      Top             =   5235
      Width           =   1125
      _ExtentX        =   1984
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
      Caption         =   "*ínàÊ"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   2
      Left            =   180
      TabIndex        =   56
      Top             =   3330
      Width           =   1380
      _ExtentX        =   2434
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
      Caption         =   "*Åß"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   13
      Left            =   135
      TabIndex        =   58
      Top             =   6300
      Width           =   2025
      _ExtentX        =   3572
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
      Caption         =   "ãåî[ì¸êÊ∫∞ƒﬁÅ@"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   14
      Left            =   135
      TabIndex        =   60
      Top             =   5985
      Width           =   2025
      _ExtentX        =   3572
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
      Caption         =   "ë„ï\î[ì¸êÊ∫∞ƒﬁÅ@"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   15
      Left            =   135
      TabIndex        =   62
      Top             =   6615
      Width           =   2025
      _ExtentX        =   3572
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
      Caption         =   "ãåë„ï\âÔé–∫∞ƒﬁ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   16
      Left            =   5880
      TabIndex        =   64
      Top             =   4590
      Width           =   5400
      _ExtentX        =   9525
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
      Caption         =   "î[ì¸êÊ“∞Ÿ±ƒﬁ⁄Ω"
      OutLine         =   -1  'True
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "èàóù(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "ìoò^(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu MN_DeleteCm 
         Caption         =   "çÌèú(&D)"
         Shortcut        =   ^D
      End
      Begin VB.Menu MN_HARDCOPY 
         Caption         =   "âÊñ àÛç¸"
         Enabled         =   0   'False
         Visible         =   0   'False
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
      Begin VB.Menu MN_Prev 
         Caption         =   "ëOï≈"
         Shortcut        =   {F8}
      End
      Begin VB.Menu MN_NextCm 
         Caption         =   "éüï≈"
         Shortcut        =   {F9}
      End
      Begin VB.Menu bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "ÉEÉCÉìÉhÉEï\é¶(&L)..."
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

Private Sub CS_BINCD_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(21).TypeA, 21) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(21)
      If PP_SSSMAIN.Tx <> 21 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_BINCD_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_BINCD_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_BINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_CHIIKI_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(19).TypeA, 19) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(19)
      If PP_SSSMAIN.Tx <> 19 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_CHIIKI_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_CHIIKI_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_CHIIKI_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_DENNOA_Click() 'Generated.
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

Private Sub CS_DENNOA_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_DENNOA_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_DENNOA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_GYOSHU_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(17).TypeA, 17) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(17)
      If PP_SSSMAIN.Tx <> 17 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_GYOSHU_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_GYOSHU_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_GYOSHU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_NHSCD_Click() 'Generated.
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

Private Sub CS_NHSCD_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_NHSCD_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_NHSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_NHSCLAID_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(26).TypeA, 26) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(26)
      If PP_SSSMAIN.Tx <> 26 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_NHSCLAID_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_NHSCLAID_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_NHSCLAID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_NHSCLBID_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(28).TypeA, 28) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(28)
      If PP_SSSMAIN.Tx <> 28 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_NHSCLBID_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_NHSCLBID_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_NHSCLBID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_NHSCLCID_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(30).TypeA, 30) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(30)
      If PP_SSSMAIN.Tx <> 30 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_NHSCLCID_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_NHSCLCID_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_NHSCLCID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
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

Private Sub Form_Activate() 'Generated.
Dim wk_ww As Integer
Dim wk_De As Integer
Dim wk_xx As Integer
   If PP_SSSMAIN.Activated = 0 Then
      PP_SSSMAIN.Activated = 1
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
Dim PY_TTop As Single
   AE_Title$ = "î[ì¸êÊÉ}ÉXÉ^ìoò^Å^í˘ê≥                   "
'èââÊñ ï\é¶ÇÃê´î\É`ÉÖÅ[ÉjÉìÉOóp ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 11715
   .FormHeight = 7890
   .MaxDe = -1
   .MaxDsp = -1
   .HeadN = 35
   .BodyN = 0
   .BodyV = 0
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 0
   .BodyPx = 35
   .EBodyPx = 35
   .TailPx = 35
   .PrpC = 35
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
      .CtB = AE_CtB
      AE_CtB = AE_CtB + 35
      ReDim Preserve AE_Controls(.CtB + 34)
      .MainFormFile = "NHSMR52.FRM"
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
         End Select
      Loop
   End If
   HD_FRNKB = ""
   HD_DENNOA = ""
   HD_NHSCD = ""
   HD_NHSNMA = ""
   HD_NHSNMB = ""
   HD_NHSNK = ""
   HD_NHSRN = ""
   HD_NHSRNNK = ""
   HD_NHSZP = ""
   HD_NHSADA = ""
   HD_NHSADB = ""
   HD_NHSADC = ""
   HD_NHSTL = ""
   HD_NHSFX = ""
   HD_NHSCTANM = ""
   HD_NHSBOSNM = ""
   HD_NHSMLAD = ""
   HD_GYOSHU = ""
   HD_GYOSHURN = ""
   HD_CHIIKI = ""
   HD_CHIIKIRN = ""
   HD_BINCD = ""
   HD_BINRN = ""
   HD_NGRPCD = ""
   HD_OLDNHSCD = ""
   HD_OLNGRPCD = ""
   HD_NHSCLAID = ""
   HD_NHSCLANM = ""
   HD_NHSCLBID = ""
   HD_NHSCLBNM = ""
   HD_NHSCLCID = ""
   HD_NHSCLCNM = ""
   HD_NHSNMMKB = ""
   HD_OPEID = ""
   HD_OPENM = ""
   HD_FRNKB.TabIndex = 0
   Set AE_Controls(.CtB + 0) = HD_FRNKB
   HD_DENNOA.TabIndex = 1
   Set AE_Controls(.CtB + 1) = HD_DENNOA
   HD_NHSCD.TabIndex = 2
   Set AE_Controls(.CtB + 2) = HD_NHSCD
   HD_NHSNMA.TabIndex = 3
   Set AE_Controls(.CtB + 3) = HD_NHSNMA
   HD_NHSNMB.TabIndex = 4
   Set AE_Controls(.CtB + 4) = HD_NHSNMB
   HD_NHSNK.TabIndex = 5
   Set AE_Controls(.CtB + 5) = HD_NHSNK
   HD_NHSRN.TabIndex = 6
   Set AE_Controls(.CtB + 6) = HD_NHSRN
   HD_NHSRNNK.TabIndex = 7
   Set AE_Controls(.CtB + 7) = HD_NHSRNNK
   HD_NHSZP.TabIndex = 8
   Set AE_Controls(.CtB + 8) = HD_NHSZP
   HD_NHSADA.TabIndex = 9
   Set AE_Controls(.CtB + 9) = HD_NHSADA
   HD_NHSADB.TabIndex = 10
   Set AE_Controls(.CtB + 10) = HD_NHSADB
   HD_NHSADC.TabIndex = 11
   Set AE_Controls(.CtB + 11) = HD_NHSADC
   HD_NHSTL.TabIndex = 12
   Set AE_Controls(.CtB + 12) = HD_NHSTL
   HD_NHSFX.TabIndex = 13
   Set AE_Controls(.CtB + 13) = HD_NHSFX
   HD_NHSCTANM.TabIndex = 14
   Set AE_Controls(.CtB + 14) = HD_NHSCTANM
   HD_NHSBOSNM.TabIndex = 15
   Set AE_Controls(.CtB + 15) = HD_NHSBOSNM
   HD_NHSMLAD.TabIndex = 16
   Set AE_Controls(.CtB + 16) = HD_NHSMLAD
   HD_GYOSHU.TabIndex = 17
   Set AE_Controls(.CtB + 17) = HD_GYOSHU
   HD_GYOSHURN.TabIndex = 18
   Set AE_Controls(.CtB + 18) = HD_GYOSHURN
   HD_CHIIKI.TabIndex = 19
   Set AE_Controls(.CtB + 19) = HD_CHIIKI
   HD_CHIIKIRN.TabIndex = 20
   Set AE_Controls(.CtB + 20) = HD_CHIIKIRN
   HD_BINCD.TabIndex = 21
   Set AE_Controls(.CtB + 21) = HD_BINCD
   HD_BINRN.TabIndex = 22
   Set AE_Controls(.CtB + 22) = HD_BINRN
   HD_NGRPCD.TabIndex = 23
   Set AE_Controls(.CtB + 23) = HD_NGRPCD
   HD_OLDNHSCD.TabIndex = 24
   Set AE_Controls(.CtB + 24) = HD_OLDNHSCD
   HD_OLNGRPCD.TabIndex = 25
   Set AE_Controls(.CtB + 25) = HD_OLNGRPCD
   HD_NHSCLAID.TabIndex = 26
   Set AE_Controls(.CtB + 26) = HD_NHSCLAID
   HD_NHSCLANM.TabIndex = 27
   Set AE_Controls(.CtB + 27) = HD_NHSCLANM
   HD_NHSCLBID.TabIndex = 28
   Set AE_Controls(.CtB + 28) = HD_NHSCLBID
   HD_NHSCLBNM.TabIndex = 29
   Set AE_Controls(.CtB + 29) = HD_NHSCLBNM
   HD_NHSCLCID.TabIndex = 30
   Set AE_Controls(.CtB + 30) = HD_NHSCLCID
   HD_NHSCLCNM.TabIndex = 31
   Set AE_Controls(.CtB + 31) = HD_NHSCLCNM
   HD_NHSNMMKB.TabIndex = 32
   Set AE_Controls(.CtB + 32) = HD_NHSNMMKB
   HD_OPEID.TabIndex = 33
   Set AE_Controls(.CtB + 33) = HD_OPEID
   HD_OPENM.TabIndex = 34
   Set AE_Controls(.CtB + 34) = HD_OPENM
   TX_CursorRest.TabIndex = 35
   Set AE_Timer(.ScX) = TM_StartUp
   Set AE_CursorRest(.ScX) = TX_CursorRest
   Set AE_ModeBar(.ScX) = TX_Mode
   Set AE_StatusBar(.ScX) = TX_Message
   Set AE_StatusCodeBar(.ScX) = TX_Message
   .Mode = Cn_Mode1: TX_Mode = "í«â¡"
   Call AE_ClearInitValStatus_SSSMAIN
   .PY_BTop = FR_SSSMAIN.Height
   .PY_EBTop = FR_SSSMAIN.Height
   PY_TTop = FR_SSSMAIN.Height
   .MaxDspC = 0
   .NrBodyTx = 35
   .ScrlMaxL = 1
   .MaxEDspC = 0
   .NrEBodyTx = 35
   .EScrlMaxL = 1
   Call AE_TabStop_SSSMAIN(0, 34, True)
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
   Call AE_WindowProcSet_SSSMAIN
   ReleaseTabCapture 0
   SetTabCapture FR_SSSMAIN.hwnd
   wk_Var = SSSMAIN_BeginPrg()
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

Private Sub HD_BINCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_BINCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_BINCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 21
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 21
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
   HD_BINCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = BINCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(21).CuVal))
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
         CP_SSSMAIN(21).TpStr = wk_Slisted
         CP_SSSMAIN(21).CIn = Cn_ChrInput
         HD_BINCD = wk_Slisted
         Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), (HD_BINCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_BINCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_BINCD, KEYCODE, Shift, CP_SSSMAIN(21).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), (HD_BINCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (21)
   End If
End Sub

Private Sub HD_BINCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 21 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD, KeyAscii)
End Sub

Private Sub HD_BINCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(21).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BINCD(AE_Val3(CP_SSSMAIN(21), (HD_BINCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_BINCD.SetFocus
      End If
   End If
   If HD_BINCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(21), CL_SSSMAIN(21), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_BINCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BINCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_BINCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_BINCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 21
   End If
End Sub

Private Sub HD_BINCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_BINCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(21), HD_BINCD)
End Sub

Private Sub HD_BINRN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_BINRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_BINRN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 22
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 22
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN)
   HD_BINRN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_BINRN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_BINRN, KEYCODE, Shift, CP_SSSMAIN(22).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BINRN(AE_Val3(CP_SSSMAIN(22), (HD_BINRN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (22)
   End If
End Sub

Private Sub HD_BINRN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 22 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(22), HD_BINRN, KeyAscii)
End Sub

Private Sub HD_BINRN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(22).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BINRN(AE_Val3(CP_SSSMAIN(22), (HD_BINRN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_BINRN.SetFocus
      End If
   End If
   If HD_BINRN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(22), CL_SSSMAIN(22), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_BINRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BINRN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_BINRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_BINRN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 22
   End If
End Sub

Private Sub HD_BINRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_BINRN.Locked = False
End Sub

Private Sub HD_CHIIKI_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_CHIIKI(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_CHIIKI_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 19
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 19
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
   HD_CHIIKI.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = CHIIKI_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(19).CuVal))
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
         CP_SSSMAIN(19).TpStr = wk_Slisted
         CP_SSSMAIN(19).CIn = Cn_ChrInput
         HD_CHIIKI = wk_Slisted
         Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), (HD_CHIIKI)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_CHIIKI_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_CHIIKI, KEYCODE, Shift, CP_SSSMAIN(19).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), (HD_CHIIKI)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (19)
   End If
End Sub

Private Sub HD_CHIIKI_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 19 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI, KeyAscii)
End Sub

Private Sub HD_CHIIKI_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(19).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CHIIKI(AE_Val3(CP_SSSMAIN(19), (HD_CHIIKI)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_CHIIKI.SetFocus
      End If
   End If
   If HD_CHIIKI.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(19), CL_SSSMAIN(19), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_CHIIKI_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_CHIIKI)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_CHIIKI.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_CHIIKI.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 19
   End If
End Sub

Private Sub HD_CHIIKI_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_CHIIKI.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(19), HD_CHIIKI)
End Sub

Private Sub HD_CHIIKIRN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_CHIIKIRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_CHIIKIRN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 20
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 20
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN)
   HD_CHIIKIRN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_CHIIKIRN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_CHIIKIRN, KEYCODE, Shift, CP_SSSMAIN(20).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_CHIIKIRN(AE_Val3(CP_SSSMAIN(20), (HD_CHIIKIRN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (20)
   End If
End Sub

Private Sub HD_CHIIKIRN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 20 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(20), HD_CHIIKIRN, KeyAscii)
End Sub

Private Sub HD_CHIIKIRN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(20).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_CHIIKIRN(AE_Val3(CP_SSSMAIN(20), (HD_CHIIKIRN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_CHIIKIRN.SetFocus
      End If
   End If
   If HD_CHIIKIRN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(20), CL_SSSMAIN(20), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_CHIIKIRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_CHIIKIRN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_CHIIKIRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_CHIIKIRN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 20
   End If
End Sub

Private Sub HD_CHIIKIRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_CHIIKIRN.Locked = False
End Sub

Private Sub HD_DENNOA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_DENNOA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_DENNOA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 1
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If DENNOA_Skip(AE_Controls(PP_SSSMAIN.CtB + 1)) Then
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
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
   HD_DENNOA.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = DENNOA_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal))
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
         HD_DENNOA = wk_Slisted
         Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), (HD_DENNOA)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_DENNOA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_DENNOA, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), (HD_DENNOA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (1)
   End If
End Sub

Private Sub HD_DENNOA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 1 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA, KeyAscii)
End Sub

Private Sub HD_DENNOA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENNOA(AE_Val3(CP_SSSMAIN(1), (HD_DENNOA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_DENNOA.SetFocus
      End If
   End If
   If HD_DENNOA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_DENNOA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_DENNOA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_DENNOA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_DENNOA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_DENNOA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_DENNOA.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_DENNOA)
End Sub

Private Sub HD_FRNKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_FRNKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_FRNKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 0
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 0
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
   HD_FRNKB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_FRNKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_FRNKB, KEYCODE, Shift, CP_SSSMAIN(0).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(0), (HD_FRNKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (0)
   End If
End Sub

Private Sub HD_FRNKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 0 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB, KeyAscii)
End Sub

Private Sub HD_FRNKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_FRNKB(AE_Val3(CP_SSSMAIN(0), (HD_FRNKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_FRNKB.SetFocus
      End If
   End If
   If HD_FRNKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(0), CL_SSSMAIN(0), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_FRNKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_FRNKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_FRNKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_FRNKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 0
   End If
End Sub

Private Sub HD_FRNKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_FRNKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(0), HD_FRNKB)
End Sub

Private Sub HD_GYOSHU_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_GYOSHU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_GYOSHU_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 17
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 17
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
   HD_GYOSHU.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = GYOSHU_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(17).CuVal))
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
         CP_SSSMAIN(17).TpStr = wk_Slisted
         CP_SSSMAIN(17).CIn = Cn_ChrInput
         HD_GYOSHU = wk_Slisted
         Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), (HD_GYOSHU)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_GYOSHU_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_GYOSHU, KEYCODE, Shift, CP_SSSMAIN(17).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), (HD_GYOSHU)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (17)
   End If
End Sub

Private Sub HD_GYOSHU_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 17 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU, KeyAscii)
End Sub

Private Sub HD_GYOSHU_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(17).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_GYOSHU(AE_Val3(CP_SSSMAIN(17), (HD_GYOSHU)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_GYOSHU.SetFocus
      End If
   End If
   If HD_GYOSHU.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(17), CL_SSSMAIN(17), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_GYOSHU_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_GYOSHU)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_GYOSHU.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_GYOSHU.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 17
   End If
End Sub

Private Sub HD_GYOSHU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_GYOSHU.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(17), HD_GYOSHU)
End Sub

Private Sub HD_GYOSHURN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_GYOSHURN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_GYOSHURN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 18
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 18
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN)
   HD_GYOSHURN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_GYOSHURN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_GYOSHURN, KEYCODE, Shift, CP_SSSMAIN(18).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_GYOSHURN(AE_Val3(CP_SSSMAIN(18), (HD_GYOSHURN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (18)
   End If
End Sub

Private Sub HD_GYOSHURN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 18 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(18), HD_GYOSHURN, KeyAscii)
End Sub

Private Sub HD_GYOSHURN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(18).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_GYOSHURN(AE_Val3(CP_SSSMAIN(18), (HD_GYOSHURN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_GYOSHURN.SetFocus
      End If
   End If
   If HD_GYOSHURN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(18), CL_SSSMAIN(18), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_GYOSHURN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_GYOSHURN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_GYOSHURN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_GYOSHURN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 18
   End If
End Sub

Private Sub HD_GYOSHURN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_GYOSHURN.Locked = False
End Sub

Private Sub HD_NGRPCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NGRPCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NGRPCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 23
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 23
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
   HD_NGRPCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NGRPCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NGRPCD, KEYCODE, Shift, CP_SSSMAIN(23).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NGRPCD(AE_Val3(CP_SSSMAIN(23), (HD_NGRPCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (23)
   End If
End Sub

Private Sub HD_NGRPCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 23 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD, KeyAscii)
End Sub

Private Sub HD_NGRPCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(23).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NGRPCD(AE_Val3(CP_SSSMAIN(23), (HD_NGRPCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NGRPCD.SetFocus
      End If
   End If
   If HD_NGRPCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(23), CL_SSSMAIN(23), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NGRPCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NGRPCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NGRPCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NGRPCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 23
   End If
End Sub

Private Sub HD_NGRPCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NGRPCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(23), HD_NGRPCD)
End Sub

Private Sub HD_NHSADA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSADA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 9
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 9
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA)
   HD_NHSADA.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSADA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSADA, KEYCODE, Shift, CP_SSSMAIN(9).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(9), (HD_NHSADA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (9)
   End If
End Sub

Private Sub HD_NHSADA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 9 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_NHSADA, KeyAscii)
End Sub

Private Sub HD_NHSADA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(9), (HD_NHSADA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSADA.SetFocus
      End If
   End If
   If HD_NHSADA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSADA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSADA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSADA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 9
   End If
End Sub

Private Sub HD_NHSADA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSADA.Locked = False
End Sub

Private Sub HD_NHSADB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSADB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 10
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 10
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB)
   HD_NHSADB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSADB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSADB, KEYCODE, Shift, CP_SSSMAIN(10).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(10), (HD_NHSADB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (10)
   End If
End Sub

Private Sub HD_NHSADB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 10 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_NHSADB, KeyAscii)
End Sub

Private Sub HD_NHSADB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(10), (HD_NHSADB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSADB.SetFocus
      End If
   End If
   If HD_NHSADB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSADB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSADB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSADB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 10
   End If
End Sub

Private Sub HD_NHSADB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSADB.Locked = False
End Sub

Private Sub HD_NHSADC_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADC(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSADC_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 11
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 11
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC)
   HD_NHSADC.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSADC_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSADC, KEYCODE, Shift, CP_SSSMAIN(11).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(11), (HD_NHSADC)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (11)
   End If
End Sub

Private Sub HD_NHSADC_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 11 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_NHSADC, KeyAscii)
End Sub

Private Sub HD_NHSADC_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(11), (HD_NHSADC)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSADC.SetFocus
      End If
   End If
   If HD_NHSADC.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSADC_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSADC)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSADC.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSADC.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 11
   End If
End Sub

Private Sub HD_NHSADC_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSADC.Locked = False
End Sub

Private Sub HD_NHSBOSNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSBOSNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSBOSNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 15
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 15
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM)
   HD_NHSBOSNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSBOSNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSBOSNM, KEYCODE, Shift, CP_SSSMAIN(15).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSBOSNM(AE_Val3(CP_SSSMAIN(15), (HD_NHSBOSNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (15)
   End If
End Sub

Private Sub HD_NHSBOSNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 15 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(15), HD_NHSBOSNM, KeyAscii)
End Sub

Private Sub HD_NHSBOSNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(15).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSBOSNM(AE_Val3(CP_SSSMAIN(15), (HD_NHSBOSNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSBOSNM.SetFocus
      End If
   End If
   If HD_NHSBOSNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(15), CL_SSSMAIN(15), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSBOSNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSBOSNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSBOSNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSBOSNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 15
   End If
End Sub

Private Sub HD_NHSBOSNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSBOSNM.Locked = False
End Sub

Private Sub HD_NHSCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 2
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 2
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
   HD_NHSCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = NHSCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(2).CuVal))
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
         HD_NHSCD = wk_Slisted
         Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), (HD_NHSCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_NHSCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCD, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), (HD_NHSCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (2)
   End If
End Sub

Private Sub HD_NHSCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD, KeyAscii)
End Sub

Private Sub HD_NHSCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(2), (HD_NHSCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCD.SetFocus
      End If
   End If
   If HD_NHSCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 2
   End If
End Sub

Private Sub HD_NHSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_NHSCD)
End Sub

Private Sub HD_NHSCLAID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLAID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLAID_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 26
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 26
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
   HD_NHSCLAID.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = NHSCLAID_Slist(PP_SSSMAIN)
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
         CP_SSSMAIN(26).TpStr = wk_Slisted
         CP_SSSMAIN(26).CIn = Cn_ChrInput
         HD_NHSCLAID = wk_Slisted
         Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), (HD_NHSCLAID)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_NHSCLAID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLAID, KEYCODE, Shift, CP_SSSMAIN(26).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), (HD_NHSCLAID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (26)
   End If
End Sub

Private Sub HD_NHSCLAID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 26 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID, KeyAscii)
End Sub

Private Sub HD_NHSCLAID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(26).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLAID(AE_Val3(CP_SSSMAIN(26), (HD_NHSCLAID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLAID.SetFocus
      End If
   End If
   If HD_NHSCLAID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(26), CL_SSSMAIN(26), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLAID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLAID)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLAID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLAID.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 26
   End If
End Sub

Private Sub HD_NHSCLAID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLAID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(26), HD_NHSCLAID)
End Sub

Private Sub HD_NHSCLANM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLANM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLANM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 27
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 27
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM)
   HD_NHSCLANM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSCLANM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLANM, KEYCODE, Shift, CP_SSSMAIN(27).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLANM(AE_Val3(CP_SSSMAIN(27), (HD_NHSCLANM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (27)
   End If
End Sub

Private Sub HD_NHSCLANM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 27 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(27), HD_NHSCLANM, KeyAscii)
End Sub

Private Sub HD_NHSCLANM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(27).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLANM(AE_Val3(CP_SSSMAIN(27), (HD_NHSCLANM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLANM.SetFocus
      End If
   End If
   If HD_NHSCLANM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(27), CL_SSSMAIN(27), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLANM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLANM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLANM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLANM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 27
   End If
End Sub

Private Sub HD_NHSCLANM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLANM.Locked = False
End Sub

Private Sub HD_NHSCLBID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLBID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLBID_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 28
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 28
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
   HD_NHSCLBID.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = NHSCLBID_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(26).CuVal))
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
         CP_SSSMAIN(28).TpStr = wk_Slisted
         CP_SSSMAIN(28).CIn = Cn_ChrInput
         HD_NHSCLBID = wk_Slisted
         Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), (HD_NHSCLBID)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_NHSCLBID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLBID, KEYCODE, Shift, CP_SSSMAIN(28).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), (HD_NHSCLBID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (28)
   End If
End Sub

Private Sub HD_NHSCLBID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 28 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID, KeyAscii)
End Sub

Private Sub HD_NHSCLBID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(28).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLBID(AE_Val3(CP_SSSMAIN(28), (HD_NHSCLBID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLBID.SetFocus
      End If
   End If
   If HD_NHSCLBID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(28), CL_SSSMAIN(28), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLBID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLBID)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLBID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLBID.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 28
   End If
End Sub

Private Sub HD_NHSCLBID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLBID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(28), HD_NHSCLBID)
End Sub

Private Sub HD_NHSCLBNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLBNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLBNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 29
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 29
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM)
   HD_NHSCLBNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSCLBNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLBNM, KEYCODE, Shift, CP_SSSMAIN(29).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLBNM(AE_Val3(CP_SSSMAIN(29), (HD_NHSCLBNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (29)
   End If
End Sub

Private Sub HD_NHSCLBNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 29 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(29), HD_NHSCLBNM, KeyAscii)
End Sub

Private Sub HD_NHSCLBNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(29).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLBNM(AE_Val3(CP_SSSMAIN(29), (HD_NHSCLBNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLBNM.SetFocus
      End If
   End If
   If HD_NHSCLBNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(29), CL_SSSMAIN(29), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLBNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLBNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLBNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLBNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 29
   End If
End Sub

Private Sub HD_NHSCLBNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLBNM.Locked = False
End Sub

Private Sub HD_NHSCLCID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLCID(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLCID_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 30
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 30
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
   HD_NHSCLCID.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = NHSCLCID_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(26).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(28).CuVal))
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
         CP_SSSMAIN(30).TpStr = wk_Slisted
         CP_SSSMAIN(30).CIn = Cn_ChrInput
         HD_NHSCLCID = wk_Slisted
         Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), (HD_NHSCLCID)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_NHSCLCID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLCID, KEYCODE, Shift, CP_SSSMAIN(30).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), (HD_NHSCLCID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (30)
   End If
End Sub

Private Sub HD_NHSCLCID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 30 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID, KeyAscii)
End Sub

Private Sub HD_NHSCLCID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(30).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLCID(AE_Val3(CP_SSSMAIN(30), (HD_NHSCLCID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLCID.SetFocus
      End If
   End If
   If HD_NHSCLCID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(30), CL_SSSMAIN(30), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLCID_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLCID)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLCID.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLCID.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 30
   End If
End Sub

Private Sub HD_NHSCLCID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLCID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(30), HD_NHSCLCID)
End Sub

Private Sub HD_NHSCLCNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCLCNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCLCNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 31
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 31
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM)
   HD_NHSCLCNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSCLCNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCLCNM, KEYCODE, Shift, CP_SSSMAIN(31).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCLCNM(AE_Val3(CP_SSSMAIN(31), (HD_NHSCLCNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (31)
   End If
End Sub

Private Sub HD_NHSCLCNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 31 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(31), HD_NHSCLCNM, KeyAscii)
End Sub

Private Sub HD_NHSCLCNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(31).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCLCNM(AE_Val3(CP_SSSMAIN(31), (HD_NHSCLCNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCLCNM.SetFocus
      End If
   End If
   If HD_NHSCLCNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(31), CL_SSSMAIN(31), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCLCNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCLCNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCLCNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCLCNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 31
   End If
End Sub

Private Sub HD_NHSCLCNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCLCNM.Locked = False
End Sub

Private Sub HD_NHSCTANM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCTANM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSCTANM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 14
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 14
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM)
   HD_NHSCTANM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSCTANM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSCTANM, KEYCODE, Shift, CP_SSSMAIN(14).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCTANM(AE_Val3(CP_SSSMAIN(14), (HD_NHSCTANM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (14)
   End If
End Sub

Private Sub HD_NHSCTANM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 14 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(14), HD_NHSCTANM, KeyAscii)
End Sub

Private Sub HD_NHSCTANM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(14).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCTANM(AE_Val3(CP_SSSMAIN(14), (HD_NHSCTANM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSCTANM.SetFocus
      End If
   End If
   If HD_NHSCTANM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSCTANM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSCTANM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSCTANM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSCTANM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 14
   End If
End Sub

Private Sub HD_NHSCTANM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSCTANM.Locked = False
End Sub

Private Sub HD_NHSFX_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSFX(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSFX_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 13
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 13
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
   HD_NHSFX.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSFX_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSFX, KEYCODE, Shift, CP_SSSMAIN(13).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSFX(AE_Val3(CP_SSSMAIN(13), (HD_NHSFX)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (13)
   End If
End Sub

Private Sub HD_NHSFX_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 13 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX, KeyAscii)
End Sub

Private Sub HD_NHSFX_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(13).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSFX(AE_Val3(CP_SSSMAIN(13), (HD_NHSFX)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSFX.SetFocus
      End If
   End If
   If HD_NHSFX.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSFX_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSFX)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSFX.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSFX.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 13
   End If
End Sub

Private Sub HD_NHSFX_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSFX.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(13), HD_NHSFX)
End Sub

Private Sub HD_NHSMLAD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSMLAD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSMLAD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 16
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 16
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
   HD_NHSMLAD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSMLAD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSMLAD, KEYCODE, Shift, CP_SSSMAIN(16).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSMLAD(AE_Val3(CP_SSSMAIN(16), (HD_NHSMLAD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (16)
   End If
End Sub

Private Sub HD_NHSMLAD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 16 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD, KeyAscii)
End Sub

Private Sub HD_NHSMLAD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(16).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSMLAD(AE_Val3(CP_SSSMAIN(16), (HD_NHSMLAD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSMLAD.SetFocus
      End If
   End If
   If HD_NHSMLAD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(16), CL_SSSMAIN(16), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSMLAD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSMLAD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSMLAD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSMLAD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 16
   End If
End Sub

Private Sub HD_NHSMLAD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSMLAD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(16), HD_NHSMLAD)
End Sub

Private Sub HD_NHSNK_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSNK_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 5
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 5
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK)
   HD_NHSNK.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSNK_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSNK, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNK(AE_Val3(CP_SSSMAIN(5), (HD_NHSNK)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (5)
   End If
End Sub

Private Sub HD_NHSNK_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_NHSNK, KeyAscii)
End Sub

Private Sub HD_NHSNK_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNK(AE_Val3(CP_SSSMAIN(5), (HD_NHSNK)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSNK.SetFocus
      End If
   End If
   If HD_NHSNK.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSNK_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNK)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSNK.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSNK.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 5
   End If
End Sub

Private Sub HD_NHSNK_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSNK.Locked = False
End Sub

Private Sub HD_NHSNMA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSNMA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 3
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 3
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA)
   HD_NHSNMA.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSNMA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSNMA, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(3), (HD_NHSNMA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (3)
   End If
End Sub

Private Sub HD_NHSNMA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_NHSNMA, KeyAscii)
End Sub

Private Sub HD_NHSNMA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(3), (HD_NHSNMA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSNMA.SetFocus
      End If
   End If
   If HD_NHSNMA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSNMA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 3
   End If
End Sub

Private Sub HD_NHSNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSNMA.Locked = False
End Sub

Private Sub HD_NHSNMB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSNMB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 4
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 4
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB)
   HD_NHSNMB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSNMB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSNMB, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(4), (HD_NHSNMB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (4)
   End If
End Sub

Private Sub HD_NHSNMB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_NHSNMB, KeyAscii)
End Sub

Private Sub HD_NHSNMB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(4), (HD_NHSNMB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSNMB.SetFocus
      End If
   End If
   If HD_NHSNMB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSNMB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 4
   End If
End Sub

Private Sub HD_NHSNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSNMB.Locked = False
End Sub

Private Sub HD_NHSNMMKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNMMKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSNMMKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 32
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 32
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
   HD_NHSNMMKB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSNMMKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSNMMKB, KEYCODE, Shift, CP_SSSMAIN(32).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMMKB(AE_Val3(CP_SSSMAIN(32), (HD_NHSNMMKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (32)
   End If
End Sub

Private Sub HD_NHSNMMKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 32 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB, KeyAscii)
End Sub

Private Sub HD_NHSNMMKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(32).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMMKB(AE_Val3(CP_SSSMAIN(32), (HD_NHSNMMKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSNMMKB.SetFocus
      End If
   End If
   If HD_NHSNMMKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(32), CL_SSSMAIN(32), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSNMMKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSNMMKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSNMMKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSNMMKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 32
   End If
End Sub

Private Sub HD_NHSNMMKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSNMMKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(32), HD_NHSNMMKB)
End Sub

Private Sub HD_NHSRN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSRN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSRN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 6
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 6
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN)
   HD_NHSRN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSRN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSRN, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSRN(AE_Val3(CP_SSSMAIN(6), (HD_NHSRN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (6)
   End If
End Sub

Private Sub HD_NHSRN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 6 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_NHSRN, KeyAscii)
End Sub

Private Sub HD_NHSRN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSRN(AE_Val3(CP_SSSMAIN(6), (HD_NHSRN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSRN.SetFocus
      End If
   End If
   If HD_NHSRN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSRN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSRN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSRN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSRN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 6
   End If
End Sub

Private Sub HD_NHSRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSRN.Locked = False
End Sub

Private Sub HD_NHSRNNK_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSRNNK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSRNNK_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 7
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 7
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK)
   HD_NHSRNNK.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSRNNK_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSRNNK, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSRNNK(AE_Val3(CP_SSSMAIN(7), (HD_NHSRNNK)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (7)
   End If
End Sub

Private Sub HD_NHSRNNK_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 7 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_NHSRNNK, KeyAscii)
End Sub

Private Sub HD_NHSRNNK_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSRNNK(AE_Val3(CP_SSSMAIN(7), (HD_NHSRNNK)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSRNNK.SetFocus
      End If
   End If
   If HD_NHSRNNK.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSRNNK_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSRNNK)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSRNNK.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSRNNK.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 7
   End If
End Sub

Private Sub HD_NHSRNNK_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSRNNK.Locked = False
End Sub

Private Sub HD_NHSTL_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSTL(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSTL_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 12
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 12
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
   HD_NHSTL.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSTL_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSTL, KEYCODE, Shift, CP_SSSMAIN(12).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSTL(AE_Val3(CP_SSSMAIN(12), (HD_NHSTL)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (12)
   End If
End Sub

Private Sub HD_NHSTL_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 12 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL, KeyAscii)
End Sub

Private Sub HD_NHSTL_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSTL(AE_Val3(CP_SSSMAIN(12), (HD_NHSTL)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSTL.SetFocus
      End If
   End If
   If HD_NHSTL.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSTL_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSTL)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSTL.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSTL.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 12
   End If
End Sub

Private Sub HD_NHSTL_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSTL.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(12), HD_NHSTL)
End Sub

Private Sub HD_NHSZP_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSZP(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NHSZP_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 8
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
   HD_NHSZP.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NHSZP_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NHSZP, KEYCODE, Shift, CP_SSSMAIN(8).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSZP(AE_Val3(CP_SSSMAIN(8), (HD_NHSZP)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (8)
   End If
End Sub

Private Sub HD_NHSZP_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 8 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP, KeyAscii)
End Sub

Private Sub HD_NHSZP_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSZP(AE_Val3(CP_SSSMAIN(8), (HD_NHSZP)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NHSZP.SetFocus
      End If
   End If
   If HD_NHSZP.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NHSZP_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NHSZP)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NHSZP.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NHSZP.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 8
   End If
End Sub

Private Sub HD_NHSZP_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NHSZP.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8), HD_NHSZP)
End Sub

Private Sub HD_OLDNHSCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OLDNHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OLDNHSCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 24
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 24
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
   HD_OLDNHSCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OLDNHSCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OLDNHSCD, KEYCODE, Shift, CP_SSSMAIN(24).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OLDNHSCD(AE_Val3(CP_SSSMAIN(24), (HD_OLDNHSCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (24)
   End If
End Sub

Private Sub HD_OLDNHSCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 24 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD, KeyAscii)
End Sub

Private Sub HD_OLDNHSCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(24).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OLDNHSCD(AE_Val3(CP_SSSMAIN(24), (HD_OLDNHSCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OLDNHSCD.SetFocus
      End If
   End If
   If HD_OLDNHSCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(24), CL_SSSMAIN(24), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OLDNHSCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OLDNHSCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OLDNHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OLDNHSCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 24
   End If
End Sub

Private Sub HD_OLDNHSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OLDNHSCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(24), HD_OLDNHSCD)
End Sub

Private Sub HD_OLNGRPCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OLNGRPCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OLNGRPCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 25
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 25
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
   HD_OLNGRPCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OLNGRPCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OLNGRPCD, KEYCODE, Shift, CP_SSSMAIN(25).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OLNGRPCD(AE_Val3(CP_SSSMAIN(25), (HD_OLNGRPCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (25)
   End If
End Sub

Private Sub HD_OLNGRPCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 25 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD, KeyAscii)
End Sub

Private Sub HD_OLNGRPCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(25).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OLNGRPCD(AE_Val3(CP_SSSMAIN(25), (HD_OLNGRPCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OLNGRPCD.SetFocus
      End If
   End If
   If HD_OLNGRPCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(25), CL_SSSMAIN(25), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OLNGRPCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OLNGRPCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OLNGRPCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OLNGRPCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 25
   End If
End Sub

Private Sub HD_OLNGRPCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OLNGRPCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(25), HD_OLNGRPCD)
End Sub

Private Sub HD_OPEID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID) Then
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
   PP_SSSMAIN.Tx = 33
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 33
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
   HD_OPEID.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(33).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(33), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (33)
   End If
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 33 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPEID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(33).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(33), (HD_OPEID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPEID.SetFocus
      End If
   End If
   If HD_OPEID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(33), CL_SSSMAIN(33), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 33
   End If
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPEID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(33), HD_OPEID)
End Sub

Private Sub HD_OPENM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM) Then
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
   PP_SSSMAIN.Tx = 34
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 34
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM)
   HD_OPENM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(34).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(34), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (34)
   End If
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 34 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(34), HD_OPENM, KeyAscii)
End Sub

Private Sub HD_OPENM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(34).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(34), (HD_OPENM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPENM.SetFocus
      End If
   End If
   If HD_OPENM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(34), CL_SSSMAIN(34), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 34
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
End Sub

Private Sub Image2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub

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

Private Sub CM_Slist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ÉEÉBÉìÉhÉEÇï\é¶ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_Prev_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "ëOÇÃÉyÅ[ÉWÇï\é¶ÇµÇ‹Ç∑ÅB"
End Sub

Private Sub CM_NextCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "éüÇÃÉyÅ[ÉWÇï\é¶ÇµÇ‹Ç∑ÅB"
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
      MN_DeleteCm = True
   Else
      MN_DeleteCm = False
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
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
      If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 Then MN_ClearItm = True
   End If
   MN_Copy = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
      End If
   End If
   MN_Cut = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
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
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
      If TypeOf Screen.ActiveControl Is TextBox Then
         If Clipboard.GetFormat(CF_TEXT) Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
         End If
      End If
   End If
   MN_UnDoItem = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 35 Then
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

Private Sub MN_Hardcopy_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If SSSMAIN_Hardcopy_Getevent() Then
   wk_Cursor = AE_Hardcopy_SSSMAIN()
   End If
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
   ElseIf PP_SSSMAIN.Tx = 1 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 2 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 17 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 19 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 21 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 26 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 28 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 30 Then
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
      If Screen.ActiveControl.TabIndex >= 35 Then
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
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction4 '4: Up
         wk_Bool = AE_CursorUp_SSSMAIN(35)
      End If
   ElseIf KEYCODE = vbKeyDown And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction3 '3: Down
         wk_Bool = AE_CursorDown_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyRight And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
         wk_Bool = AE_CursorNext_SSSMAIN(-1)
      End If
   ElseIf KEYCODE = vbKeyLeft And Shift = 0 Then
      If PP_SSSMAIN.Mode = Cn_Mode3 Then
      Else
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(35)
      End If
   ElseIf (KEYCODE = vbKeyExecute Or KEYCODE = vbKeyReturn) And Shift = 0 Then
   ElseIf KEYCODE = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorPrevDsp_SSSMAIN(35) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KEYCODE = vbKeyHome And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorNextDsp_SSSMAIN(-1) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
      End If
   ElseIf KEYCODE = vbKeyPageDown And Shift = 0 Then
   ElseIf KEYCODE = vbKeyPageUp And Shift = 0 Then
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


