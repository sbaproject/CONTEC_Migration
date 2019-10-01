VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  'Ã◊Øƒ
   BorderStyle     =   1  'å≈íË(é¿ê¸)
   Caption         =   "îÑè„í˘ê≥"
   ClientHeight    =   9915
   ClientLeft      =   60
   ClientTop       =   630
   ClientWidth     =   14925
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
   Icon            =   "URIET52.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z µ∞¿ﬁ∞
   ScaleHeight     =   9915
   ScaleWidth      =   14925
   Begin VB.TextBox HD_TOKCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   4905
      MaxLength       =   14
      TabIndex        =   13
      TabStop         =   0   'False
      Text            =   "XXXXXXXXX1"
      Top             =   975
      Width           =   1170
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   5
      Left            =   3480
      TabIndex        =   43
      Top             =   975
      Width           =   1455
      _ExtentX        =   2566
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
   Begin VB.Frame Frame1 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H80000005&
      BorderStyle     =   0  'Ç»Çµ
      Enabled         =   0   'False
      ForeColor       =   &H80000008&
      Height          =   375
      Left            =   1800
      TabIndex        =   94
      Top             =   720
      Width           =   1815
      Begin VB.CheckBox HD_EMGODNKB 
         Caption         =   "ãŸã}èoâ◊"
         BeginProperty Font 
            Name            =   "ÇlÇr ÉSÉVÉbÉN"
            Size            =   14.25
            Charset         =   128
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   0
         MaskColor       =   &H00000000&
         TabIndex        =   95
         Top             =   0
         Width           =   1815
      End
   End
   Begin Threed5.SSCommand5 CS_DATNO 
      Height          =   330
      Left            =   165
      TabIndex        =   92
      TabStop         =   0   'False
      Top             =   720
      Width           =   1530
      _ExtentX        =   2699
      _ExtentY        =   582
      ForeColor       =   -2147483640
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ÇlÇr ÇoÉSÉVÉbÉN"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*îÑè„í˘ê≥ëŒè€"
   End
   Begin VB.TextBox HD_DATNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   240
      MaxLength       =   14
      TabIndex        =   91
      Top             =   720
      Width           =   1365
   End
   Begin VB.TextBox TL_NHSADC 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1035
      MaxLength       =   64
      TabIndex        =   90
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
      Top             =   8610
      Width           =   4395
   End
   Begin VB.TextBox TL_SBADENKN 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11940
      MaxLength       =   19
      TabIndex        =   87
      Text            =   "-99,999,999,999.9999"
      Top             =   7380
      Width           =   2355
   End
   Begin VB.TextBox TL_DENCMIN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6825
      MaxLength       =   44
      TabIndex        =   86
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   8610
      Width           =   4380
   End
   Begin VB.TextBox TL_DENCM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6825
      MaxLength       =   44
      TabIndex        =   84
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   8295
      Width           =   4380
   End
   Begin VB.TextBox TL_MAEUKKB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   6825
      MaxLength       =   5
      TabIndex        =   82
      TabStop         =   0   'False
      Text            =   "1"
      Top             =   7980
      Width           =   405
   End
   Begin VB.TextBox TL_MAEUKNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   7215
      MaxLength       =   14
      TabIndex        =   81
      Text            =   "MMMMMMMMM1"
      Top             =   7980
      Width           =   1275
   End
   Begin VB.TextBox TL_NHSADB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1035
      MaxLength       =   64
      TabIndex        =   79
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
      Top             =   8295
      Width           =   4395
   End
   Begin VB.TextBox TL_NHSADA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1035
      MaxLength       =   64
      TabIndex        =   78
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
      Top             =   7980
      Width           =   4395
   End
   Begin VB.TextBox TL_NHSCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   645
      IMEMode         =   2  'µÃ
      Left            =   1035
      MaxLength       =   14
      TabIndex        =   76
      TabStop         =   0   'False
      Text            =   "XXXXXXXXX1"
      Top             =   7350
      Width           =   1140
   End
   Begin VB.TextBox TL_NHSNMB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   2160
      MaxLength       =   64
      TabIndex        =   75
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
      Top             =   7665
      Width           =   3270
   End
   Begin VB.TextBox TL_NHSNMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   2160
      MaxLength       =   64
      TabIndex        =   74
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
      Top             =   7350
      Width           =   3270
   End
   Begin VB.TextBox TL_KENNMB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1035
      MaxLength       =   44
      TabIndex        =   72
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   7035
      Width           =   4395
   End
   Begin VB.TextBox BD_TNKKB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   645
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   10350
      MaxLength       =   5
      TabIndex        =   71
      Text            =   "M2"
      Top             =   3375
      Width           =   600
   End
   Begin VB.TextBox BD_SIKTK 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   8385
      MaxLength       =   15
      TabIndex        =   68
      Text            =   "-99,999,999,999"
      Top             =   3690
      Width           =   1980
   End
   Begin VB.TextBox BD_URISU 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   645
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   6315
      MaxLength       =   11
      TabIndex        =   65
      Text            =   "-9,999,999.99"
      Top             =   3375
      Width           =   1500
   End
   Begin VB.TextBox BD_UNTNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   645
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   7800
      MaxLength       =   8
      TabIndex        =   64
      Text            =   "MMM4"
      Top             =   3375
      Width           =   600
   End
   Begin VB.TextBox BD_TOKJDNNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   735
      MaxLength       =   27
      TabIndex        =   63
      Text            =   "XXXXXXXXX1XXXXXXXXX2XXX"
      Top             =   3690
      Width           =   2385
   End
   Begin VB.TextBox BD_HINCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   1920
      MaxLength       =   14
      TabIndex        =   62
      Text            =   "XXXXXXXXX1"
      Top             =   3375
      Width           =   1200
   End
   Begin VB.TextBox HD_OPEID 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11865
      MaxLength       =   10
      TabIndex        =   57
      TabStop         =   0   'False
      Text            =   "XXXXX6"
      Top             =   855
      Width           =   780
   End
   Begin VB.TextBox HD_OPENM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   12630
      MaxLength       =   24
      TabIndex        =   56
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   855
      Width           =   2205
   End
   Begin VB.TextBox HD_TANCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   4905
      MaxLength       =   10
      TabIndex        =   54
      TabStop         =   0   'False
      Text            =   "XXXXX6"
      Top             =   1290
      Width           =   1170
   End
   Begin VB.TextBox HD_TANNM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6060
      MaxLength       =   44
      TabIndex        =   53
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1290
      Width           =   4350
   End
   Begin VB.TextBox HD_URIKJN 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   4905
      MaxLength       =   6
      TabIndex        =   51
      TabStop         =   0   'False
      Text            =   "1"
      Top             =   2235
      Width           =   1170
   End
   Begin VB.TextBox HD_URIKJNNM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6060
      MaxLength       =   24
      TabIndex        =   50
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2235
      Width           =   4350
   End
   Begin VB.TextBox HD_SOUCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   4905
      MaxLength       =   7
      TabIndex        =   48
      TabStop         =   0   'False
      Text            =   "123"
      Top             =   1920
      Width           =   1170
   End
   Begin VB.TextBox HD_SOUNM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6060
      MaxLength       =   24
      TabIndex        =   47
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   1920
      Width           =   4350
   End
   Begin VB.TextBox HD_BUMCD 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   4905
      MaxLength       =   10
      TabIndex        =   45
      TabStop         =   0   'False
      Text            =   "123456"
      Top             =   1605
      Width           =   1170
   End
   Begin VB.TextBox HD_BUNNM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6060
      MaxLength       =   44
      TabIndex        =   44
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   1605
      Width           =   4350
   End
   Begin VB.TextBox HD_JDNTRNM 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   2055
      MaxLength       =   14
      TabIndex        =   41
      Text            =   "MMMMMMMMM1"
      Top             =   1920
      Width           =   1350
   End
   Begin VB.TextBox HD_JDNTRKB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1680
      MaxLength       =   6
      TabIndex        =   40
      Text            =   "X2"
      Top             =   1920
      Width           =   390
   End
   Begin VB.TextBox HD_OKRJONO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1680
      MaxLength       =   19
      TabIndex        =   37
      Text            =   "XXXXXXXXX1XXXXX"
      Top             =   1140
      Width           =   1725
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   3
      Left            =   3105
      TabIndex        =   36
      Top             =   2745
      Width           =   3225
      _ExtentX        =   5689
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
      Caption         =   "å^Å@Å@Å@éÆ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   4
      Left            =   3105
      TabIndex        =   35
      Top             =   3060
      Width           =   3225
      _ExtentX        =   5689
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
      Caption         =   "ïiÅ@Å@Å@ñº"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D4 
      Height          =   870
      Left            =   0
      TabIndex        =   32
      Top             =   10230
      Width           =   13605
      _ExtentX        =   16695
      _ExtentY        =   1058
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
         TabIndex        =   33
         Text            =   "”∞ƒﬁ"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   825
         Picture         =   "URIET52.frx":000C
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   1185
         Picture         =   "URIET52.frx":065E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   6345
         Picture         =   "URIET52.frx":0CB0
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   6705
         Picture         =   "URIET52.frx":0E3A
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "URIET52.frx":0FC4
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "URIET52.frx":114E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "URIET52.frx":12D8
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "URIET52.frx":1462
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "URIET52.frx":15EC
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "URIET52.frx":1776
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "URIET52.frx":1900
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "URIET52.frx":1A8A
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "URIET52.frx":1C14
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "URIET52.frx":1D9E
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "URIET52.frx":1F28
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "URIET52.frx":20B2
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "URIET52.frx":223C
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "URIET52.frx":23C6
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "URIET52.frx":2550
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "URIET52.frx":26DA
         Top             =   45
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D14 
      Height          =   555
      Left            =   -45
      TabIndex        =   30
      Top             =   -15
      Width           =   14985
      _ExtentX        =   26432
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
         Left            =   13020
         TabIndex        =   31
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
      Begin VB.Image CM_Execute 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   585
         Picture         =   "URIET52.frx":2864
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_LCONFIG 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   2655
         Picture         =   "URIET52.frx":2EB6
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_DELETEDE 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   1755
         Picture         =   "URIET52.frx":3040
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Hardcopy 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   945
         Picture         =   "URIET52.frx":31CA
         Top             =   90
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image CM_SLIST 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   2115
         Picture         =   "URIET52.frx":3354
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Left            =   225
         Picture         =   "URIET52.frx":34DE
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
      Left            =   -45
      TabIndex        =   27
      Top             =   9210
      Width           =   15000
      _ExtentX        =   26458
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
         TabIndex        =   28
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
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   29
            Text            =   "URIET52.frx":3668
            Top             =   90
            Width           =   7080
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'Ã◊Øƒ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "URIET52.frx":369F
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   645
      Index           =   7
      Left            =   7800
      TabIndex        =   26
      Top             =   2745
      Width           =   600
      _ExtentX        =   1058
      _ExtentY        =   1138
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
      Caption         =   "íPà "
      FloodColor      =   16777215
      OutLine         =   -1  'True
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   3
         Index           =   0
         X1              =   0
         X2              =   0
         Y1              =   0
         Y2              =   420
      End
   End
   Begin VB.TextBox HD_TOKRN 
      Appearance      =   0  'Ã◊Øƒ
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   6060
      MaxLength       =   44
      TabIndex        =   25
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   975
      Width           =   4350
   End
   Begin VB.TextBox HD_UDNDT 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1680
      MaxLength       =   14
      TabIndex        =   24
      Text            =   "9999/99/99"
      Top             =   2235
      Width           =   1725
   End
   Begin Threed5.SSPanel5 FM_Panel3D12 
      Height          =   330
      Left            =   10365
      TabIndex        =   23
      Top             =   6750
      Width           =   1590
      _ExtentX        =   2805
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
      Caption         =   "ñ{ëÃçáåvã‡äz"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D13 
      Height          =   645
      Left            =   165
      TabIndex        =   22
      Top             =   6720
      Width           =   885
      _ExtentX        =   1561
      _ExtentY        =   1138
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
      Caption         =   "åè ñº"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox TL_KENNMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   1035
      MaxLength       =   44
      TabIndex        =   21
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
      Top             =   6720
      Width           =   4395
   End
   Begin VB.TextBox BD_LINCMB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   13275
      MaxLength       =   24
      TabIndex        =   20
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   3690
      Width           =   1155
   End
   Begin VB.TextBox BD_SBNNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   735
      MaxLength       =   24
      TabIndex        =   19
      Text            =   "XXXXXXXXX1"
      Top             =   3375
      Width           =   1200
   End
   Begin VB.TextBox BD_URITK 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   8385
      MaxLength       =   15
      TabIndex        =   18
      Text            =   "-999,999,999.9999"
      Top             =   3375
      Width           =   1980
   End
   Begin VB.TextBox BD_URIKN 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   10935
      MaxLength       =   15
      TabIndex        =   17
      Text            =   "-99,999,999,999.9999"
      Top             =   3375
      Width           =   2355
   End
   Begin VB.TextBox BD_LINCMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   13275
      MaxLength       =   24
      TabIndex        =   16
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   3375
      Width           =   1155
   End
   Begin VB.TextBox BD_HINNMB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   3105
      MaxLength       =   54
      TabIndex        =   15
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
      Top             =   3690
      Width           =   3225
   End
   Begin VB.TextBox BD_HINNMA 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Index           =   0
      Left            =   3105
      MaxLength       =   54
      TabIndex        =   14
      Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5"
      Top             =   3375
      Width           =   3225
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   8
      Left            =   10935
      TabIndex        =   12
      Top             =   2745
      Width           =   2355
      _ExtentX        =   4154
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
      Caption         =   "îÑè„ã‡äz"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D10 
      Height          =   645
      Left            =   13275
      TabIndex        =   11
      Top             =   2745
      Width           =   1155
      _ExtentX        =   2037
      _ExtentY        =   1138
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
      Caption         =   "îıçl"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox TL_SBAURIKN 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11940
      MaxLength       =   19
      TabIndex        =   10
      Text            =   "-99,999,999,999.9999"
      Top             =   6750
      Width           =   2355
   End
   Begin VB.VScrollBar VS_Scrl 
      Height          =   330
      Left            =   14430
      TabIndex        =   9
      Top             =   3360
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D3 
      Height          =   645
      Left            =   345
      TabIndex        =   8
      Top             =   2745
      Width           =   405
      _ExtentX        =   714
      _ExtentY        =   1138
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
      Caption         =   "No"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_LINNO 
      Appearance      =   0  'Ã◊Øƒ
      ForeColor       =   &H00000000&
      Height          =   645
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   345
      MaxLength       =   6
      TabIndex        =   7
      Text            =   "99"
      Top             =   3375
      Width           =   405
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   12
      Left            =   10935
      TabIndex        =   6
      Top             =   3060
      Width           =   2355
      _ExtentX        =   4154
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
      Caption         =   "ñ{ëÃâøäiÅiíËâøÅj"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_TEIKATK 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Index           =   0
      Left            =   10935
      MaxLength       =   15
      TabIndex        =   5
      Text            =   "-99,999,999,999.9999"
      Top             =   3690
      Width           =   2355
   End
   Begin VB.TextBox TL_SBAUZEKN 
      Alignment       =   1  'âEëµÇ¶
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11940
      MaxLength       =   18
      TabIndex        =   4
      Text            =   "-9,999,999,999"
      Top             =   7065
      Width           =   2355
   End
   Begin VB.TextBox HD_JDNNO 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   1680
      MaxLength       =   14
      TabIndex        =   3
      Text            =   "12345678"
      Top             =   1605
      Width           =   1005
   End
   Begin VB.TextBox HD_NXTNM 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   4  'ëSäpÇ–ÇÁÇ™Ç»
      Left            =   12135
      MaxLength       =   14
      TabIndex        =   2
      Text            =   "MMMMMMMMM1"
      Top             =   1290
      Width           =   1155
   End
   Begin VB.TextBox HD_NXTKB 
      Appearance      =   0  'Ã◊Øƒ
      BackColor       =   &H00FFFFFF&
      Height          =   330
      IMEMode         =   2  'µÃ
      Left            =   11865
      MaxLength       =   5
      TabIndex        =   1
      Text            =   "9"
      Top             =   1290
      Width           =   285
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
      TabIndex        =   0
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSCommand5 CS_NXTKB 
      Height          =   330
      Left            =   10470
      TabIndex        =   34
      TabStop         =   0   'False
      Top             =   1290
      Width           =   1410
      _ExtentX        =   2487
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
      Caption         =   "í†í["
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   2
      Left            =   165
      TabIndex        =   38
      Top             =   1140
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "ëóÇËèÛáÇ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   1
      Left            =   165
      TabIndex        =   39
      Top             =   1920
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "éÛíçéÊà¯ãÊï™"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_UDNDT 
      Height          =   330
      Left            =   165
      TabIndex        =   42
      TabStop         =   0   'False
      Top             =   2235
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "*îÑè„ì˙"
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   10
      Left            =   3480
      TabIndex        =   46
      Top             =   1605
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   "âcã∆ïîñÂ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   11
      Left            =   3480
      TabIndex        =   49
      Top             =   1920
      Width           =   1455
      _ExtentX        =   2566
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
      Index           =   13
      Left            =   3480
      TabIndex        =   52
      Top             =   2235
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   "îÑè„äÓèÄ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   6
      Left            =   3480
      TabIndex        =   55
      Top             =   1290
      Width           =   1455
      _ExtentX        =   2566
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
      Caption         =   "âcã∆íSìñé“"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   15
      Left            =   10470
      TabIndex        =   58
      Top             =   855
      Width           =   1410
      _ExtentX        =   2487
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
      Index           =   16
      Left            =   735
      TabIndex        =   59
      Top             =   2745
      Width           =   1200
      _ExtentX        =   2117
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
      Caption         =   "êªî‘"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   17
      Left            =   1920
      TabIndex        =   60
      Top             =   2745
      Width           =   1200
      _ExtentX        =   2117
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
      Index           =   18
      Left            =   735
      TabIndex        =   61
      Top             =   3060
      Width           =   2385
      _ExtentX        =   4207
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
      Caption         =   "ãqêÊíçï∂î‘çÜ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSCommand5 CS_URISU 
      Height          =   645
      Left            =   6315
      TabIndex        =   66
      TabStop         =   0   'False
      Top             =   2745
      Width           =   1500
      _ExtentX        =   2646
      _ExtentY        =   1138
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
      Caption         =   "*êîÅ@ó "
      BevelWidth      =   1
      RoundedCorners  =   0   'False
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   0
      Left            =   8385
      TabIndex        =   67
      Top             =   2745
      Width           =   1980
      _ExtentX        =   3493
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
      Caption         =   "îÑè„íPâø"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   14
      Left            =   8385
      TabIndex        =   69
      Top             =   3060
      Width           =   1980
      _ExtentX        =   3493
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
      Caption         =   "édêÿíPâø"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   645
      Index           =   19
      Left            =   10350
      TabIndex        =   70
      Top             =   2745
      Width           =   600
      _ExtentX        =   1058
      _ExtentY        =   1138
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
      Caption         =   "éÌï "
      FloodColor      =   16777215
      OutLine         =   -1  'True
      Begin VB.Line Line1 
         BorderColor     =   &H00FFFFFF&
         BorderWidth     =   3
         Index           =   1
         X1              =   0
         X2              =   0
         Y1              =   0
         Y2              =   420
      End
   End
   Begin Threed5.SSPanel5 SSPanel51 
      Height          =   645
      Left            =   165
      TabIndex        =   73
      Top             =   7350
      Width           =   885
      _ExtentX        =   1561
      _ExtentY        =   1138
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
      Caption         =   "î[ì¸êÊ"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel52 
      Height          =   960
      Left            =   165
      TabIndex        =   77
      Top             =   7980
      Width           =   885
      _ExtentX        =   1561
      _ExtentY        =   1693
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
      Caption         =   "èZ èä"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel53 
      Height          =   330
      Left            =   5610
      TabIndex        =   80
      Top             =   7980
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
      BevelOuter      =   1
      Caption         =   "ëOéÛãÊï™"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel54 
      Height          =   330
      Left            =   5610
      TabIndex        =   83
      Top             =   8295
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
      BevelOuter      =   1
      Caption         =   "îıÅ@çl"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel55 
      Height          =   330
      Left            =   5610
      TabIndex        =   85
      Top             =   8610
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
      BevelOuter      =   1
      Caption         =   "é–ì‡îıçl"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel56 
      Height          =   330
      Left            =   10365
      TabIndex        =   88
      Top             =   7065
      Width           =   1590
      _ExtentX        =   2805
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
      Caption         =   "è¡îÔê≈äz"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel57 
      Height          =   330
      Left            =   10365
      TabIndex        =   89
      Top             =   7380
      Width           =   1590
      _ExtentX        =   2805
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
      Caption         =   "ì`ï[çáåvã‡äz"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D2 
      Height          =   330
      Index           =   20
      Left            =   165
      TabIndex        =   93
      Top             =   1605
      Width           =   1530
      _ExtentX        =   2699
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
      Caption         =   "éQè∆éÛíçî‘çÜ"
      OutLine         =   -1  'True
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
      Begin VB.Menu MN_ClearDE 
         Caption         =   "ñæç◊çsèâä˙âª"
      End
      Begin VB.Menu MN_DeleteDE 
         Caption         =   "ñæç◊çsçÌèú(&T)"
         Shortcut        =   ^T
      End
      Begin VB.Menu MN_UnDoDe 
         Caption         =   "ñæç◊çsïúå≥"
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
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HINCD(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 60 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(60 + 88 * PP_SSSMAIN.De), BD_HINCD(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
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
   CM_SLIST.Enabled = False
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
   If PP_SSSMAIN.Tx <> 23 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
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
   PP_SSSMAIN.Px = 62 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(62 + 88 * PP_SSSMAIN.De), BD_HINNMA(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
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
   If PP_SSSMAIN.Tx <> 25 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
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

Private Sub BD_HINNMB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_HINNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_HINNMB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_HINNMB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 63 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(63 + 88 * PP_SSSMAIN.De), BD_HINNMB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index))
   BD_HINNMB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_HINNMB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_HINNMB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_HINNMB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 26 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index), KeyAscii)
End Sub

Private Sub BD_HINNMB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_HINNMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_HINNMB(Index).SetFocus
         End If
      End If
   End If
   If BD_HINNMB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_HINNMB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_HINNMB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_HINNMB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_HINNMB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_HINNMB(Index).TabIndex
   End If
End Sub

Private Sub BD_HINNMB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_HINNMB(Index).Locked = False
End Sub

Private Sub BD_LINCMA_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_LINCMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_LINCMA_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_LINCMA(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 71 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(71 + 88 * PP_SSSMAIN.De), BD_LINCMA(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index))
   BD_LINCMA(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_LINCMA_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_LINCMA(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_LINCMA_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 34 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index), KeyAscii)
End Sub

Private Sub BD_LINCMA_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINCMA(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_LINCMA(Index).SetFocus
         End If
      End If
   End If
   If BD_LINCMA(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_LINCMA_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMA(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_LINCMA(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_LINCMA(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_LINCMA(Index).TabIndex
   End If
End Sub

Private Sub BD_LINCMA_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_LINCMA(Index).Locked = False
End Sub

Private Sub BD_LINCMB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_LINCMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_LINCMB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_LINCMB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 72 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(72 + 88 * PP_SSSMAIN.De), BD_LINCMB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index))
   BD_LINCMB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_LINCMB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_LINCMB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_LINCMB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 35 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index), KeyAscii)
End Sub

Private Sub BD_LINCMB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_LINCMB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_LINCMB(Index).SetFocus
         End If
      End If
   End If
   If BD_LINCMB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_LINCMB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_LINCMB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_LINCMB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_LINCMB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_LINCMB(Index).TabIndex
   End If
End Sub

Private Sub BD_LINCMB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_LINCMB(Index).Locked = False
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
   PP_SSSMAIN.Px = 58 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(58 + 88 * PP_SSSMAIN.De), BD_LINNO(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
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
   If PP_SSSMAIN.Tx <> 21 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
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
   PP_SSSMAIN.Px = 59 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(59 + 88 * PP_SSSMAIN.De), BD_SBNNO(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
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
   If PP_SSSMAIN.Tx <> 22 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
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

Private Sub BD_SIKTK_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SIKTK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_SIKTK_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_SIKTK(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 67 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(67 + 88 * PP_SSSMAIN.De), BD_SIKTK(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
   BD_SIKTK(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_SIKTK_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_SIKTK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_SIKTK_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 30 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index), KeyAscii)
End Sub

Private Sub BD_SIKTK_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SIKTK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_SIKTK(Index).SetFocus
         End If
      End If
   End If
   If BD_SIKTK(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_SIKTK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_SIKTK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_SIKTK(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_SIKTK(Index).TabIndex
   End If
End Sub

Private Sub BD_SIKTK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_SIKTK(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_SIKTK(Index))
End Sub

Private Sub BD_TEIKATK_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TEIKATK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_TEIKATK_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_TEIKATK(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 70 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(70 + 88 * PP_SSSMAIN.De), BD_TEIKATK(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
   BD_TEIKATK(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_TEIKATK_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_TEIKATK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_TEIKATK_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 33 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index), KeyAscii)
End Sub

Private Sub BD_TEIKATK_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TEIKATK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_TEIKATK(Index).SetFocus
         End If
      End If
   End If
   If BD_TEIKATK(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_TEIKATK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_TEIKATK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_TEIKATK(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_TEIKATK(Index).TabIndex
   End If
End Sub

Private Sub BD_TEIKATK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_TEIKATK(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TEIKATK(Index))
End Sub

Private Sub BD_TNKKB_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKKB(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TNKKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_TNKKB_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_TNKKB(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 68 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(68 + 88 * PP_SSSMAIN.De), BD_TNKKB(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKKB(Index))
   BD_TNKKB(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_TNKKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_TNKKB(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TNKKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_TNKKB_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 31 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKKB(Index), KeyAscii)
End Sub

Private Sub BD_TNKKB_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TNKKB(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_TNKKB(Index).SetFocus
         End If
      End If
   End If
   If BD_TNKKB(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_TNKKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKKB(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_TNKKB(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_TNKKB(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_TNKKB(Index).TabIndex
   End If
End Sub

Private Sub BD_TNKKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_TNKKB(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TNKKB(Index))
End Sub

Private Sub BD_TOKJDNNO_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TOKJDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_TOKJDNNO_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_TOKJDNNO(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 61 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(61 + 88 * PP_SSSMAIN.De), BD_TOKJDNNO(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
   BD_TOKJDNNO(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_TOKJDNNO_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_TOKJDNNO(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_TOKJDNNO_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 24 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index), KeyAscii)
End Sub

Private Sub BD_TOKJDNNO_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKJDNNO(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_TOKJDNNO(Index).SetFocus
         End If
      End If
   End If
   If BD_TOKJDNNO(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_TOKJDNNO_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_TOKJDNNO(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_TOKJDNNO(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_TOKJDNNO(Index).TabIndex
   End If
End Sub

Private Sub BD_TOKJDNNO_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_TOKJDNNO(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_TOKJDNNO(Index))
End Sub

Private Sub BD_UNTNM_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_UNTNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_UNTNM_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_UNTNM(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 65 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(65 + 88 * PP_SSSMAIN.De), BD_UNTNM(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index))
   BD_UNTNM(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_UNTNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_UNTNM(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_UNTNM_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 28 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index), KeyAscii)
End Sub

Private Sub BD_UNTNM_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UNTNM(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_UNTNM(Index).SetFocus
         End If
      End If
   End If
   If BD_UNTNM(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_UNTNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_UNTNM(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_UNTNM(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_UNTNM(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_UNTNM(Index).TabIndex
   End If
End Sub

Private Sub BD_UNTNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_UNTNM(Index).Locked = False
End Sub

Private Sub BD_URIKN_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_URIKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_URIKN_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_URIKN(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 69 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(69 + 88 * PP_SSSMAIN.De), BD_URIKN(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   If URIKN_Skip(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(60 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(66 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(64 + 88 * PP_SSSMAIN.De).CuVal)) Then
      PP_SSSMAIN.CursorDest = Cn_DestBySkip
      If AE_CursorSkip_SSSMAIN() Then
         PP_SSSMAIN.CursorDirection = AE_ChangeDirection(PP_SSSMAIN.CursorDirection)
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
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
   BD_URIKN(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_URIKN_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_URIKN(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_URIKN_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 32 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index), KeyAscii)
End Sub

Private Sub BD_URIKN_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKN(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_URIKN(Index).SetFocus
         End If
      End If
   End If
   If BD_URIKN(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_URIKN_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_URIKN(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_URIKN(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_URIKN(Index).TabIndex
   End If
End Sub

Private Sub BD_URIKN_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_URIKN(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URIKN(Index))
End Sub

Private Sub BD_URISU_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_URISU(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_URISU_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_URISU(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 64 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(64 + 88 * PP_SSSMAIN.De), BD_URISU(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
   BD_URISU(Index).BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = URISU_Slist(PP_SSSMAIN, AE_NullCnv1_SSSMAIN(CP_SSSMAIN(78 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(60 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(59 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(79 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(51).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(108 + 88 * PP_SSSMAIN.De).CuVal), _
AE_NullCnv1_SSSMAIN(CP_SSSMAIN(109 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv1_SSSMAIN(CP_SSSMAIN(110 + 88 * PP_SSSMAIN.De).CuVal), PP_SSSMAIN.De2)
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
         BD_URISU(Index) = wk_Slisted
         Call AE_Check_SSSMAIN_URISU(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub BD_URISU_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_URISU(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_URISU_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 27 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index), KeyAscii)
End Sub

Private Sub BD_URISU_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URISU(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_URISU(Index).SetFocus
         End If
      End If
   End If
   If BD_URISU(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_URISU_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_URISU(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_URISU(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_URISU(Index).TabIndex
   End If
End Sub

Private Sub BD_URISU_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_URISU(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URISU(Index))
End Sub

Private Sub BD_URITK_Change(Index As Integer) 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index)) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_URITK(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub BD_URITK_GotFocus(Index As Integer) 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = BD_URITK(Index).TabIndex
   PP_SSSMAIN.De = Index + PP_SSSMAIN.TopDe
   PP_SSSMAIN.Px = 66 + 88 * PP_SSSMAIN.De
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(66 + 88 * PP_SSSMAIN.De), BD_URITK(Index))
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   PP_SSSMAIN.De2 = PP_SSSMAIN.De
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
   BD_URITK(Index).BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub BD_URITK_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(BD_URITK(Index), KEYCODE, Shift, CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) Then
      If RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).TpStr) = RTrim$(CP_SSSMAIN(PP_SSSMAIN.Px).IniStr) And CP_SSSMAIN(PP_SSSMAIN.Px).StatusC <> Cn_Status8 And AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
         Call AE_ClearItm_SSSMAIN(True)
         wk_Bool = AE_CursorSkip_SSSMAIN()
      Else
         If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, True, True)
         If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (PP_SSSMAIN.Tx)
      End If
   End If
End Sub

Private Sub BD_URITK_KeyPress(Index As Integer, KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 29 + 15 * Index Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index), KeyAscii)
End Sub

Private Sub BD_URITK_LostFocus(Index As Integer) 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If PP_SSSMAIN.ScrlFlag Then
      PP_SSSMAIN.ScrlFlag = False
   Else
      If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
         If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URITK(AE_Val3(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + AE_Tx(PP_SSSMAIN, PP_SSSMAIN.Px)))), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
         If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
            On Error Resume Next
            BD_URITK(Index).SetFocus
         End If
      End If
   End If
   If BD_URITK(Index).BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), CL_SSSMAIN(PP_SSSMAIN.Px), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub BD_URITK_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = BD_URITK(Index).TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         BD_URITK(Index).Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = BD_URITK(Index).TabIndex
   End If
End Sub

Private Sub BD_URITK_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   BD_URITK(Index).Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), BD_URITK(Index))
End Sub

Private Sub CM_DeleteDe_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv1_SSSMAIN(CP_SSSMAIN(126 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(75 + 88 * PP_SSSMAIN.De).CuVal)) Then
   If PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 Then
      If (PP_SSSMAIN.Tx - 21) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         Call AE_DeleteDe_SSSMAIN
      End If
   Else
      Beep
   End If
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

Private Sub CM_LCONFIG_Click() 'Generated.
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   PP_SSSMAIN.NeglectLostFocusCheck = True
   If LCONFIG_GetEvent() Then
   End If
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

Private Sub CS_DATNO_Click() 'Generated.
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

Private Sub CS_DATNO_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_DATNO_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_DATNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_NXTKB_Click() 'Generated.
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

Private Sub CS_NXTKB_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_NXTKB_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_NXTKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_UDNDT_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(6).TypeA, 6) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(6)
      If PP_SSSMAIN.Tx <> 6 Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0
End Sub

Private Sub CS_UDNDT_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_UDNDT_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_UDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub CS_URISU_Click() 'Generated.
Dim wk_Slisted As Variant
Dim wk_SaveTx As Integer
Dim wk_TxBase As Integer
Dim wk_PxBase As Integer

   PP_SSSMAIN.ButtonClick = True
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.De2 >= 0 And PP_SSSMAIN.Tx < 96 Then
      wk_PxBase = 88 * PP_SSSMAIN.De
      wk_TxBase = 15 * (PP_SSSMAIN.De - PP_SSSMAIN.TopDe)
   Else
      wk_PxBase = 88 * PP_SSSMAIN.TopDe
      wk_TxBase = 0
   End If
   If AE_CursorCheck_SSSMAIN(CP_SSSMAIN(64 + wk_PxBase).TypeA, 27 + wk_TxBase) Then
      PP_SSSMAIN.SlistCall = True
      PP_SSSMAIN.CursorDirection = Cn_Direction1 '1: Next
      Call AE_CursorMove_SSSMAIN(27 + wk_TxBase)
      If PP_SSSMAIN.Tx <> 27 + wk_TxBase Then PP_SSSMAIN.SSCommand5Ajst = True
   Else
      Beep
      Call AE_CursorCurrent_SSSMAIN
   End If
   PP_SSSMAIN.CursorDirection = 0

End Sub

Private Sub CS_URISU_GotFocus() 'Generated.
   PP_SSSMAIN.ButtonClick = False
End Sub

Private Sub CS_URISU_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then Call AE_CursorCurrent_SSSMAIN
   End If
End Sub

Private Sub CS_URISU_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If Not PP_SSSMAIN.ButtonClick Then
      Call AE_CursorCurrent_SSSMAIN
   Else
      PP_SSSMAIN.SSCommand5Ajst = False
   End If
End Sub

Private Sub FM_PANEL3D10_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D12_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D13_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
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

Private Sub FM_PANEL3D3_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   Call AE_CursorCurrent_SSSMAIN
End Sub

Private Sub FM_PANEL3D4_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
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
         Do While wk_ww < 15
            wk_xx = 21 + 15 * wk_De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + wk_xx).Visible = AE_Controls(PP_SSSMAIN.CtB + 21 + wk_ww).Visible
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
   AE_Title$ = "îÑè„í˘ê≥                          "
'èââÊñ ï\é¶ÇÃê´î\É`ÉÖÅ[ÉjÉìÉOóp ----------
'Dim StartTime
'   AE_MsgBox "Start Point", vbInformation, AE_Title$
'   StartTime = Timer
'-----------------------------------------
   With PP_SSSMAIN
   .FormWidth = 14925
   .FormHeight = 9915
   .MaxDe = 98
   .MaxDsp = 4
   .HeadN = 21
   .BodyN = 15
   .BodyV = 88
   .MaxEDe = -1
   .MaxEDsp = -1
   .EBodyN = 0
   .EBodyV = 0
   .TailN = 15
   .BodyPx = 58
   .EBodyPx = 8770
   .TailPx = 8770
   .PrpC = 8813
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
      AE_CtB = AE_CtB + 111
      ReDim Preserve AE_Controls(.CtB + 110)
      .MainFormFile = "URIET52.FRM"
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
               Call AE_SetCp(CP_SSSMAIN(wk_BodyN + 58), wk_BodyN + 58, wk_SmrBuf$, CQ_SSSMAIN(wk_BodyN + 58))
               wk_BodyN = wk_BodyN + 1
            Case "TL_", "TV_"
               Do While wk_De <= 98
                  wk_PxBase = 58
                  Do While wk_PxBase < 146
                     wk_Px = wk_PxBase + 88 * wk_De
                     Call AE_CopyCp_SSSMAIN(wk_Px, wk_PxBase)
                     wk_PxBase = wk_PxBase + 1
                  Loop
                  wk_De = wk_De + 1
               Loop
               Call AE_SetCp(CP_SSSMAIN(wk_TailN + 8770), wk_TailN + 8770, wk_SmrBuf$, CQ_SSSMAIN(wk_TailN + 146))
               wk_TailN = wk_TailN + 1
         End Select
      Loop
   End If
   HD_DATNO = ""
   HD_OKRJONO = ""
   HD_JDNNO = ""
   HD_JDNTRKB = ""
   HD_JDNTRNM = ""
   HD_UDNDT = ""
   HD_TOKCD = ""
   HD_TOKRN = ""
   HD_TANCD = ""
   HD_TANNM = ""
   HD_BUMCD = ""
   HD_BUNNM = ""
   HD_SOUCD = ""
   HD_SOUNM = ""
   HD_URIKJN = ""
   HD_URIKJNNM = ""
   HD_NXTKB = ""
   HD_NXTNM = ""
   HD_OPEID = ""
   HD_OPENM = ""
   BD_LINNO(0) = ""
   BD_SBNNO(0) = ""
   BD_HINCD(0) = ""
   BD_TOKJDNNO(0) = ""
   BD_HINNMA(0) = ""
   BD_HINNMB(0) = ""
   BD_URISU(0) = ""
   BD_UNTNM(0) = ""
   BD_URITK(0) = ""
   BD_SIKTK(0) = ""
   BD_TNKKB(0) = ""
   BD_URIKN(0) = ""
   BD_TEIKATK(0) = ""
   BD_LINCMA(0) = ""
   BD_LINCMB(0) = ""
   TL_KENNMA = ""
   TL_KENNMB = ""
   TL_NHSCD = ""
   TL_NHSNMA = ""
   TL_NHSNMB = ""
   TL_NHSADA = ""
   TL_NHSADB = ""
   TL_NHSADC = ""
   TL_MAEUKKB = ""
   TL_MAEUKNM = ""
   TL_DENCM = ""
   TL_DENCMIN = ""
   TL_SBAURIKN = ""
   TL_SBAUZEKN = ""
   TL_SBADENKN = ""
   For wk_De = 1 To 4
      Load BD_LINCMB(wk_De)
      Load BD_LINCMA(wk_De)
      Load BD_TEIKATK(wk_De)
      Load BD_URIKN(wk_De)
      Load BD_TNKKB(wk_De)
      Load BD_SIKTK(wk_De)
      Load BD_URITK(wk_De)
      Load BD_UNTNM(wk_De)
      Load BD_URISU(wk_De)
      Load BD_HINNMB(wk_De)
      Load BD_HINNMA(wk_De)
      Load BD_TOKJDNNO(wk_De)
      Load BD_HINCD(wk_De)
      Load BD_SBNNO(wk_De)
      Load BD_LINNO(wk_De)
   Next wk_De
   HD_EMGODNKB.TabIndex = 0
   Set AE_Controls(.CtB + 0) = HD_EMGODNKB
   HD_DATNO.TabIndex = 1
   Set AE_Controls(.CtB + 1) = HD_DATNO
   HD_OKRJONO.TabIndex = 2
   Set AE_Controls(.CtB + 2) = HD_OKRJONO
   HD_JDNNO.TabIndex = 3
   Set AE_Controls(.CtB + 3) = HD_JDNNO
   HD_JDNTRKB.TabIndex = 4
   Set AE_Controls(.CtB + 4) = HD_JDNTRKB
   HD_JDNTRNM.TabIndex = 5
   Set AE_Controls(.CtB + 5) = HD_JDNTRNM
   HD_UDNDT.TabIndex = 6
   Set AE_Controls(.CtB + 6) = HD_UDNDT
   HD_TOKCD.TabIndex = 7
   Set AE_Controls(.CtB + 7) = HD_TOKCD
   HD_TOKRN.TabIndex = 8
   Set AE_Controls(.CtB + 8) = HD_TOKRN
   HD_TANCD.TabIndex = 9
   Set AE_Controls(.CtB + 9) = HD_TANCD
   HD_TANNM.TabIndex = 10
   Set AE_Controls(.CtB + 10) = HD_TANNM
   HD_BUMCD.TabIndex = 11
   Set AE_Controls(.CtB + 11) = HD_BUMCD
   HD_BUNNM.TabIndex = 12
   Set AE_Controls(.CtB + 12) = HD_BUNNM
   HD_SOUCD.TabIndex = 13
   Set AE_Controls(.CtB + 13) = HD_SOUCD
   HD_SOUNM.TabIndex = 14
   Set AE_Controls(.CtB + 14) = HD_SOUNM
   HD_URIKJN.TabIndex = 15
   Set AE_Controls(.CtB + 15) = HD_URIKJN
   HD_URIKJNNM.TabIndex = 16
   Set AE_Controls(.CtB + 16) = HD_URIKJNNM
   HD_NXTKB.TabIndex = 17
   Set AE_Controls(.CtB + 17) = HD_NXTKB
   HD_NXTNM.TabIndex = 18
   Set AE_Controls(.CtB + 18) = HD_NXTNM
   HD_OPEID.TabIndex = 19
   Set AE_Controls(.CtB + 19) = HD_OPEID
   HD_OPENM.TabIndex = 20
   Set AE_Controls(.CtB + 20) = HD_OPENM
   For wk_De = 0 To 4
      wk_TxBase = 15 * wk_De
      BD_LINNO(wk_De).TabIndex = 21 + wk_TxBase
      Set AE_Controls(.CtB + 21 + wk_TxBase) = BD_LINNO(wk_De)
      BD_SBNNO(wk_De).TabIndex = 22 + wk_TxBase
      Set AE_Controls(.CtB + 22 + wk_TxBase) = BD_SBNNO(wk_De)
      BD_HINCD(wk_De).TabIndex = 23 + wk_TxBase
      Set AE_Controls(.CtB + 23 + wk_TxBase) = BD_HINCD(wk_De)
      BD_TOKJDNNO(wk_De).TabIndex = 24 + wk_TxBase
      Set AE_Controls(.CtB + 24 + wk_TxBase) = BD_TOKJDNNO(wk_De)
      BD_HINNMA(wk_De).TabIndex = 25 + wk_TxBase
      Set AE_Controls(.CtB + 25 + wk_TxBase) = BD_HINNMA(wk_De)
      BD_HINNMB(wk_De).TabIndex = 26 + wk_TxBase
      Set AE_Controls(.CtB + 26 + wk_TxBase) = BD_HINNMB(wk_De)
      BD_URISU(wk_De).TabIndex = 27 + wk_TxBase
      Set AE_Controls(.CtB + 27 + wk_TxBase) = BD_URISU(wk_De)
      BD_UNTNM(wk_De).TabIndex = 28 + wk_TxBase
      Set AE_Controls(.CtB + 28 + wk_TxBase) = BD_UNTNM(wk_De)
      BD_URITK(wk_De).TabIndex = 29 + wk_TxBase
      Set AE_Controls(.CtB + 29 + wk_TxBase) = BD_URITK(wk_De)
      BD_SIKTK(wk_De).TabIndex = 30 + wk_TxBase
      Set AE_Controls(.CtB + 30 + wk_TxBase) = BD_SIKTK(wk_De)
      BD_TNKKB(wk_De).TabIndex = 31 + wk_TxBase
      Set AE_Controls(.CtB + 31 + wk_TxBase) = BD_TNKKB(wk_De)
      BD_URIKN(wk_De).TabIndex = 32 + wk_TxBase
      Set AE_Controls(.CtB + 32 + wk_TxBase) = BD_URIKN(wk_De)
      BD_TEIKATK(wk_De).TabIndex = 33 + wk_TxBase
      Set AE_Controls(.CtB + 33 + wk_TxBase) = BD_TEIKATK(wk_De)
      BD_LINCMA(wk_De).TabIndex = 34 + wk_TxBase
      Set AE_Controls(.CtB + 34 + wk_TxBase) = BD_LINCMA(wk_De)
      BD_LINCMB(wk_De).TabIndex = 35 + wk_TxBase
      Set AE_Controls(.CtB + 35 + wk_TxBase) = BD_LINCMB(wk_De)
   Next wk_De
   TL_KENNMA.TabIndex = 96
   Set AE_Controls(.CtB + 96) = TL_KENNMA
   TL_KENNMB.TabIndex = 97
   Set AE_Controls(.CtB + 97) = TL_KENNMB
   TL_NHSCD.TabIndex = 98
   Set AE_Controls(.CtB + 98) = TL_NHSCD
   TL_NHSNMA.TabIndex = 99
   Set AE_Controls(.CtB + 99) = TL_NHSNMA
   TL_NHSNMB.TabIndex = 100
   Set AE_Controls(.CtB + 100) = TL_NHSNMB
   TL_NHSADA.TabIndex = 101
   Set AE_Controls(.CtB + 101) = TL_NHSADA
   TL_NHSADB.TabIndex = 102
   Set AE_Controls(.CtB + 102) = TL_NHSADB
   TL_NHSADC.TabIndex = 103
   Set AE_Controls(.CtB + 103) = TL_NHSADC
   TL_MAEUKKB.TabIndex = 104
   Set AE_Controls(.CtB + 104) = TL_MAEUKKB
   TL_MAEUKNM.TabIndex = 105
   Set AE_Controls(.CtB + 105) = TL_MAEUKNM
   TL_DENCM.TabIndex = 106
   Set AE_Controls(.CtB + 106) = TL_DENCM
   TL_DENCMIN.TabIndex = 107
   Set AE_Controls(.CtB + 107) = TL_DENCMIN
   TL_SBAURIKN.TabIndex = 108
   Set AE_Controls(.CtB + 108) = TL_SBAURIKN
   TL_SBAUZEKN.TabIndex = 109
   Set AE_Controls(.CtB + 109) = TL_SBAUZEKN
   TL_SBADENKN.TabIndex = 110
   Set AE_Controls(.CtB + 110) = TL_SBADENKN
   TX_CursorRest.TabIndex = 111
   Set AE_Timer(.ScX) = TM_StartUp
   Set AE_CursorRest(.ScX) = TX_CursorRest
   Set AE_ModeBar(.ScX) = TX_Mode
   Set AE_StatusBar(.ScX) = TX_Message
   Set AE_StatusCodeBar(.ScX) = TX_Message
   .Mode = Cn_Mode1: TX_Mode = "í«â¡"
   Call AE_ClearInitValStatus_SSSMAIN
   .PY_BTop = FR_SSSMAIN.Height
   ReDim AE_BodyTop(15)
   wk_Tx = 21
   Do While wk_Tx < 36
      wk_Top = AE_Controls(.CtB + wk_Tx).Top
      If wk_Top < .PY_BTop Then .PY_BTop = wk_Top
      AE_BodyTop(wk_Tx - 21) = wk_Top
      wk_Tx = wk_Tx + 1
   Loop
   .PY_EBTop = FR_SSSMAIN.Height
   PY_TTop = FR_SSSMAIN.Height
   wk_Tx = 96
   Do While wk_Tx < 111
      If TypeOf AE_Controls(.CtB + wk_Tx) Is OptionButton Then
      Else
         wk_Top = AE_Controls(.CtB + wk_Tx).Top
         If wk_Top < PY_TTop Then PY_TTop = wk_Top
      End If
      wk_Tx = wk_Tx + 1
   Loop
   Set AE_ScrlBar(.ScX) = VS_Scrl
   PY_BBtm = 0
   wk_Tx = 21: wk_ww = 0
   Do While wk_Tx < 36
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
   .NrBodyTx = 21 + 15 * (.MaxDspC + 1)
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
   .NrEBodyTx = 96
   .EScrlMaxL = 1
   Call AE_TabStop_SSSMAIN(0, 110, True)
   TX_CursorRest.TabStop = False
   TX_Mode.TabStop = False
   TX_Message.TabStop = False
   TX_Message = ""
   wk_De = 1
   Do While wk_De <= .MaxDspC
      wk_ww = 0
      Do While wk_ww < 15
         wk_Tx = 21 + 15 * wk_De + wk_ww
         AE_Controls(.CtB + wk_Tx).Top = AE_BodyTop(wk_ww) + .PY_BHgt * wk_De
         wk_ww = wk_ww + 1
      Loop
      wk_De = wk_De + 1
   Loop
   wk_Int = CspPurgeFilterReq(FR_SSSMAIN.hwnd)
   wk_Int = CspAddAltKeyCode(FR_SSSMAIN.hwnd, HD_EMGODNKB.hwnd, 2)
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

Private Sub HD_BUMCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(11), HD_BUMCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_BUMCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_BUMCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 11
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 11
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(11), HD_BUMCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(11), HD_BUMCD)
   HD_BUMCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_BUMCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_BUMCD, KEYCODE, Shift, CP_SSSMAIN(11).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BUMCD(AE_Val3(CP_SSSMAIN(11), (HD_BUMCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (11)
   End If
End Sub

Private Sub HD_BUMCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 11 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(11), HD_BUMCD, KeyAscii)
End Sub

Private Sub HD_BUMCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(11).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BUMCD(AE_Val3(CP_SSSMAIN(11), (HD_BUMCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_BUMCD.SetFocus
      End If
   End If
   If HD_BUMCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(11), CL_SSSMAIN(11), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_BUMCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BUMCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_BUMCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_BUMCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 11
   End If
End Sub

Private Sub HD_BUMCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_BUMCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(11), HD_BUMCD)
End Sub

Private Sub HD_BUNNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(12), HD_BUNNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_BUNNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_BUNNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 12
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 12
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(12), HD_BUNNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(12), HD_BUNNM)
   HD_BUNNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_BUNNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_BUNNM, KEYCODE, Shift, CP_SSSMAIN(12).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_BUNNM(AE_Val3(CP_SSSMAIN(12), (HD_BUNNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (12)
   End If
End Sub

Private Sub HD_BUNNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 12 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(12), HD_BUNNM, KeyAscii)
End Sub

Private Sub HD_BUNNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(12).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_BUNNM(AE_Val3(CP_SSSMAIN(12), (HD_BUNNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_BUNNM.SetFocus
      End If
   End If
   If HD_BUNNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(12), CL_SSSMAIN(12), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_BUNNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_BUNNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_BUNNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_BUNNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 12
   End If
End Sub

Private Sub HD_BUNNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_BUNNM.Locked = False
End Sub

Private Sub HD_DATNO_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(1), HD_DATNO) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_DATNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_DATNO_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 1
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(1), HD_DATNO)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If DATNO_Skip(AE_Controls(PP_SSSMAIN.CtB + 1)) Then
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
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(1), HD_DATNO)
   HD_DATNO.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = DATNO_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(1).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(3).CuVal))
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
         HD_DATNO = wk_Slisted
         Call AE_Check_SSSMAIN_DATNO(AE_Val3(CP_SSSMAIN(1), (HD_DATNO)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_DATNO_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_DATNO, KEYCODE, Shift, CP_SSSMAIN(1).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DATNO(AE_Val3(CP_SSSMAIN(1), (HD_DATNO)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (1)
   End If
End Sub

Private Sub HD_DATNO_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 1 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(1), HD_DATNO, KeyAscii)
End Sub

Private Sub HD_DATNO_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(1).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DATNO(AE_Val3(CP_SSSMAIN(1), (HD_DATNO)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_DATNO.SetFocus
      End If
   End If
   If HD_DATNO.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(1), CL_SSSMAIN(1), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_DATNO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_DATNO)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_DATNO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_DATNO.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 1
   End If
End Sub

Private Sub HD_DATNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_DATNO.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(1), HD_DATNO)
End Sub

Private Sub HD_EMGODNKB_Click() 'Generated.
   If PP_SSSMAIN.MaskMode = False Then
      PP_SSSMAIN.ButtonClick = True
      If Not PP_SSSMAIN.Operable Then Exit Sub
      If Trim$(CP_SSSMAIN(0).TpStr) = CStr(HD_EMGODNKB) Then Exit Sub
      Call AE_SetInitValStatus(PP_SSSMAIN, CP_SSSMAIN(0))
      CP_SSSMAIN(0).TpStr = CStr(HD_EMGODNKB)
      PP_SSSMAIN.CursorDirection = Cn_Direction1
      PP_SSSMAIN.CursorDest = Cn_Dest9
      Call AE_Check_SSSMAIN_EMGODNKB(AE_Val4(CP_SSSMAIN(0)), Cn_Status6, True, True)
   End If
End Sub

Private Sub HD_EMGODNKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 0
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 0
   PP_SSSMAIN.ButtonClick = False
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(0), HD_EMGODNKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_EMGODNKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If KEYCODE >= vbKeyF1 And KEYCODE <= vbKeyF12 Then
      wk_Int = AE_FuncKey_SSSMAIN(KEYCODE, Shift)
   End If
   If KEYCODE <> vbKeyF4 Or (Shift And 6) <> 4 Then KEYCODE = 0
End Sub

Private Sub HD_EMGODNKB_KeyPress(KeyAscii As Integer) 'Generated.
   KeyAscii = 0
End Sub

Private Sub HD_EMGODNKB_KeyUp(KEYCODE As Integer, Shift As Integer) 'Generated.
   If PP_SSSMAIN.ButtonClick = False Then
      If KEYCODE = vbKeySelect Then
         If AE_CursorNext_SSSMAIN(PP_SSSMAIN.Tx) = False Then wk_Bool = AE_CursorPrev_SSSMAIN(111)
      End If
   End If
   KEYCODE = 0
End Sub

Private Sub HD_EMGODNKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(0).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_EMGODNKB(AE_Val3(CP_SSSMAIN(0), (HD_EMGODNKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_EMGODNKB.SetFocus
      End If
   End If
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_JDNNO_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNNO) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_JDNNO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_JDNNO_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 3
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 3
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNNO)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNNO)
   HD_JDNNO.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_JDNNO_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_JDNNO, KEYCODE, Shift, CP_SSSMAIN(3).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(3), (HD_JDNNO)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (3)
   End If
End Sub

Private Sub HD_JDNNO_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 3 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNNO, KeyAscii)
End Sub

Private Sub HD_JDNNO_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(3).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNNO(AE_Val3(CP_SSSMAIN(3), (HD_JDNNO)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_JDNNO.SetFocus
      End If
   End If
   If HD_JDNNO.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(3), CL_SSSMAIN(3), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 3
   End If
End Sub

Private Sub HD_JDNNO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_JDNNO.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(3), HD_JDNNO)
End Sub

Private Sub HD_JDNTRKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(4), HD_JDNTRKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_JDNTRKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_JDNTRKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 4
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 4
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(4), HD_JDNTRKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(4), HD_JDNTRKB)
   HD_JDNTRKB.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = JDNTRKB_Slist(PP_SSSMAIN)
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
         CP_SSSMAIN(4).TpStr = wk_Slisted
         CP_SSSMAIN(4).CIn = Cn_ChrInput
         HD_JDNTRKB = wk_Slisted
         Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(4), (HD_JDNTRKB)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_JDNTRKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_JDNTRKB, KEYCODE, Shift, CP_SSSMAIN(4).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(4), (HD_JDNTRKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (4)
   End If
End Sub

Private Sub HD_JDNTRKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 4 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(4), HD_JDNTRKB, KeyAscii)
End Sub

Private Sub HD_JDNTRKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(4).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRKB(AE_Val3(CP_SSSMAIN(4), (HD_JDNTRKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_JDNTRKB.SetFocus
      End If
   End If
   If HD_JDNTRKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(4), CL_SSSMAIN(4), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_JDNTRKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_JDNTRKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_JDNTRKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 4
   End If
End Sub

Private Sub HD_JDNTRKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_JDNTRKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(4), HD_JDNTRKB)
End Sub

Private Sub HD_JDNTRNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(5), HD_JDNTRNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_JDNTRNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_JDNTRNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 5
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 5
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(5), HD_JDNTRNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(5), HD_JDNTRNM)
   HD_JDNTRNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_JDNTRNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_JDNTRNM, KEYCODE, Shift, CP_SSSMAIN(5).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(5), (HD_JDNTRNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (5)
   End If
End Sub

Private Sub HD_JDNTRNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 5 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(5), HD_JDNTRNM, KeyAscii)
End Sub

Private Sub HD_JDNTRNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(5).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_JDNTRNM(AE_Val3(CP_SSSMAIN(5), (HD_JDNTRNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_JDNTRNM.SetFocus
      End If
   End If
   If HD_JDNTRNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(5), CL_SSSMAIN(5), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_JDNTRNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_JDNTRNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_JDNTRNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_JDNTRNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 5
   End If
End Sub

Private Sub HD_JDNTRNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_JDNTRNM.Locked = False
End Sub

Private Sub HD_NXTKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(17), HD_NXTKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NXTKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NXTKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 17
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 17
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(17), HD_NXTKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(17), HD_NXTKB)
   HD_NXTKB.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = NXTKB_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(24).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(25).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(26).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal))
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
         HD_NXTKB = wk_Slisted
         Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(17), (HD_NXTKB)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_NXTKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NXTKB, KEYCODE, Shift, CP_SSSMAIN(17).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(17), (HD_NXTKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (17)
   End If
End Sub

Private Sub HD_NXTKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 17 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(17), HD_NXTKB, KeyAscii)
End Sub

Private Sub HD_NXTKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(17).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NXTKB(AE_Val3(CP_SSSMAIN(17), (HD_NXTKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NXTKB.SetFocus
      End If
   End If
   If HD_NXTKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(17), CL_SSSMAIN(17), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NXTKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NXTKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NXTKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NXTKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 17
   End If
End Sub

Private Sub HD_NXTKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NXTKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(17), HD_NXTKB)
End Sub

Private Sub HD_NXTNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(18), HD_NXTNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NXTNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_NXTNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 18
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 18
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(18), HD_NXTNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(18), HD_NXTNM)
   HD_NXTNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_NXTNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_NXTNM, KEYCODE, Shift, CP_SSSMAIN(18).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NXTNM(AE_Val3(CP_SSSMAIN(18), (HD_NXTNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (18)
   End If
End Sub

Private Sub HD_NXTNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 18 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(18), HD_NXTNM, KeyAscii)
End Sub

Private Sub HD_NXTNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(18).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NXTNM(AE_Val3(CP_SSSMAIN(18), (HD_NXTNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_NXTNM.SetFocus
      End If
   End If
   If HD_NXTNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(18), CL_SSSMAIN(18), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_NXTNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_NXTNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_NXTNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_NXTNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 18
   End If
End Sub

Private Sub HD_NXTNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_NXTNM.Locked = False
End Sub

Private Sub HD_OKRJONO_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(2), HD_OKRJONO) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_OKRJONO(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_OKRJONO_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 2
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 2
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(2), HD_OKRJONO)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(2), HD_OKRJONO)
   HD_OKRJONO.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OKRJONO_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OKRJONO, KEYCODE, Shift, CP_SSSMAIN(2).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OKRJONO(AE_Val3(CP_SSSMAIN(2), (HD_OKRJONO)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (2)
   End If
End Sub

Private Sub HD_OKRJONO_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 2 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(2), HD_OKRJONO, KeyAscii)
End Sub

Private Sub HD_OKRJONO_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(2).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OKRJONO(AE_Val3(CP_SSSMAIN(2), (HD_OKRJONO)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OKRJONO.SetFocus
      End If
   End If
   If HD_OKRJONO.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(2), CL_SSSMAIN(2), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_OKRJONO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_OKRJONO)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_OKRJONO.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_OKRJONO.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 2
   End If
End Sub

Private Sub HD_OKRJONO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OKRJONO.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(2), HD_OKRJONO)
End Sub

Private Sub HD_OPEID_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(19), HD_OPEID) Then
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
   PP_SSSMAIN.Tx = 19
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 19
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(19), HD_OPEID)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(19), HD_OPEID)
   HD_OPEID.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPEID_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPEID, KEYCODE, Shift, CP_SSSMAIN(19).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(19), (HD_OPEID)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (19)
   End If
End Sub

Private Sub HD_OPEID_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 19 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(19), HD_OPEID, KeyAscii)
End Sub

Private Sub HD_OPEID_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(19).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPEID(AE_Val3(CP_SSSMAIN(19), (HD_OPEID)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPEID.SetFocus
      End If
   End If
   If HD_OPEID.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(19), CL_SSSMAIN(19), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 19
   End If
End Sub

Private Sub HD_OPEID_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPEID.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(19), HD_OPEID)
End Sub

Private Sub HD_OPENM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(20), HD_OPENM) Then
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
   PP_SSSMAIN.Tx = 20
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 20
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(20), HD_OPENM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(20), HD_OPENM)
   HD_OPENM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_OPENM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_OPENM, KEYCODE, Shift, CP_SSSMAIN(20).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(20), (HD_OPENM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (20)
   End If
End Sub

Private Sub HD_OPENM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 20 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(20), HD_OPENM, KeyAscii)
End Sub

Private Sub HD_OPENM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(20).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_OPENM(AE_Val3(CP_SSSMAIN(20), (HD_OPENM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_OPENM.SetFocus
      End If
   End If
   If HD_OPENM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(20), CL_SSSMAIN(20), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 20
   End If
End Sub

Private Sub HD_OPENM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_OPENM.Locked = False
End Sub

Private Sub HD_SOUCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(13), HD_SOUCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SOUCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_SOUCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 13
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 13
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(13), HD_SOUCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(13), HD_SOUCD)
   HD_SOUCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_SOUCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_SOUCD, KEYCODE, Shift, CP_SSSMAIN(13).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(13), (HD_SOUCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (13)
   End If
End Sub

Private Sub HD_SOUCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 13 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(13), HD_SOUCD, KeyAscii)
End Sub

Private Sub HD_SOUCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(13).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUCD(AE_Val3(CP_SSSMAIN(13), (HD_SOUCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_SOUCD.SetFocus
      End If
   End If
   If HD_SOUCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(13), CL_SSSMAIN(13), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 13
   End If
End Sub

Private Sub HD_SOUCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_SOUCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(13), HD_SOUCD)
End Sub

Private Sub HD_SOUNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(14), HD_SOUNM) Then
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
   PP_SSSMAIN.Tx = 14
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 14
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(14), HD_SOUNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(14), HD_SOUNM)
   HD_SOUNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_SOUNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_SOUNM, KEYCODE, Shift, CP_SSSMAIN(14).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(14), (HD_SOUNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (14)
   End If
End Sub

Private Sub HD_SOUNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 14 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(14), HD_SOUNM, KeyAscii)
End Sub

Private Sub HD_SOUNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(14).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SOUNM(AE_Val3(CP_SSSMAIN(14), (HD_SOUNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_SOUNM.SetFocus
      End If
   End If
   If HD_SOUNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(14), CL_SSSMAIN(14), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 14
   End If
End Sub

Private Sub HD_SOUNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_SOUNM.Locked = False
End Sub

Private Sub HD_TANCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(9), HD_TANCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TANCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_TANCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 9
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 9
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(9), HD_TANCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(9), HD_TANCD)
   HD_TANCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = TANCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(9).CuVal))
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
         CP_SSSMAIN(9).TpStr = wk_Slisted
         CP_SSSMAIN(9).CIn = Cn_ChrInput
         HD_TANCD = wk_Slisted
         Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(9), (HD_TANCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TANCD, KEYCODE, Shift, CP_SSSMAIN(9).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(9), (HD_TANCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (9)
   End If
End Sub

Private Sub HD_TANCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 9 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(9), HD_TANCD, KeyAscii)
End Sub

Private Sub HD_TANCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(9).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANCD(AE_Val3(CP_SSSMAIN(9), (HD_TANCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TANCD.SetFocus
      End If
   End If
   If HD_TANCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(9), CL_SSSMAIN(9), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_TANCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_TANCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 9
   End If
End Sub

Private Sub HD_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TANCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(9), HD_TANCD)
End Sub

Private Sub HD_TANNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(10), HD_TANNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_TANNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_TANNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 10
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 10
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(10), HD_TANNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(10), HD_TANNM)
   HD_TANNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TANNM, KEYCODE, Shift, CP_SSSMAIN(10).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(10), (HD_TANNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (10)
   End If
End Sub

Private Sub HD_TANNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 10 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(10), HD_TANNM, KeyAscii)
End Sub

Private Sub HD_TANNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(10).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TANNM(AE_Val3(CP_SSSMAIN(10), (HD_TANNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TANNM.SetFocus
      End If
   End If
   If HD_TANNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(10), CL_SSSMAIN(10), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_TANNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_TANNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_TANNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 10
   End If
End Sub

Private Sub HD_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TANNM.Locked = False
End Sub

Private Sub HD_TOKCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(7), HD_TOKCD) Then
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
   PP_SSSMAIN.Tx = 7
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 7
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(7), HD_TOKCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(7), HD_TOKCD)
   HD_TOKCD.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = TOKCD_Slist(PP_SSSMAIN, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(7).CuVal))
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
         CP_SSSMAIN(7).TpStr = wk_Slisted
         CP_SSSMAIN(7).CIn = Cn_ChrInput
         HD_TOKCD = wk_Slisted
         Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(7), (HD_TOKCD)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_TOKCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TOKCD, KEYCODE, Shift, CP_SSSMAIN(7).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(7), (HD_TOKCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (7)
   End If
End Sub

Private Sub HD_TOKCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 7 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(7), HD_TOKCD, KeyAscii)
End Sub

Private Sub HD_TOKCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(7).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKCD(AE_Val3(CP_SSSMAIN(7), (HD_TOKCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TOKCD.SetFocus
      End If
   End If
   If HD_TOKCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(7), CL_SSSMAIN(7), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 7
   End If
End Sub

Private Sub HD_TOKCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TOKCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(7), HD_TOKCD)
End Sub

Private Sub HD_TOKRN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8), HD_TOKRN) Then
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
   PP_SSSMAIN.Tx = 8
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8), HD_TOKRN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8), HD_TOKRN)
   HD_TOKRN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_TOKRN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_TOKRN, KEYCODE, Shift, CP_SSSMAIN(8).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(8), (HD_TOKRN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (8)
   End If
End Sub

Private Sub HD_TOKRN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 8 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8), HD_TOKRN, KeyAscii)
End Sub

Private Sub HD_TOKRN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_TOKRN(AE_Val3(CP_SSSMAIN(8), (HD_TOKRN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_TOKRN.SetFocus
      End If
   End If
   If HD_TOKRN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8), CL_SSSMAIN(8), PP_SSSMAIN.Tx)
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
      PP_SSSMAIN.MouseDownTx = 8
   End If
End Sub

Private Sub HD_TOKRN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_TOKRN.Locked = False
End Sub

Private Sub HD_UDNDT_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(6), HD_UDNDT) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_UDNDT(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_UDNDT_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
Dim wk_Slisted As Variant
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 6
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 6
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(6), HD_UDNDT)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If UDNDT_Skip(AE_Controls(PP_SSSMAIN.CtB + 6)) Then
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
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(6), HD_UDNDT)
   HD_UDNDT.BackColor = Cn_ClBrightON
   If PP_SSSMAIN.SlistCall Then
      PP_SSSMAIN.SlistCall = False
      PP_SSSMAIN.SlistPx = PP_SSSMAIN.Px
      PP_SSSMAIN.KeyDownMode = PP_SSSMAIN.Mode
      wk_Slisted = UDNDT_Slist(AE_NullCnv2_SSSMAIN(CP_SSSMAIN(6).CuVal), PP_SSSMAIN)
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
         CP_SSSMAIN(6).TpStr = wk_Slisted
         CP_SSSMAIN(6).CIn = Cn_ChrInput
         HD_UDNDT = wk_Slisted
         Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(6), (HD_UDNDT)), Cn_Status6, True, True)
      End If
   End If
   CM_SLIST.Enabled = True
End Sub

Private Sub HD_UDNDT_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_UDNDT, KEYCODE, Shift, CP_SSSMAIN(6).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(6), (HD_UDNDT)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (6)
   End If
End Sub

Private Sub HD_UDNDT_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 6 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(6), HD_UDNDT, KeyAscii)
End Sub

Private Sub HD_UDNDT_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(6).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_UDNDT(AE_Val3(CP_SSSMAIN(6), (HD_UDNDT)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_UDNDT.SetFocus
      End If
   End If
   If HD_UDNDT.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(6), CL_SSSMAIN(6), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_UDNDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_UDNDT)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_UDNDT.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_UDNDT.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 6
   End If
End Sub

Private Sub HD_UDNDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_UDNDT.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(6), HD_UDNDT)
End Sub

Private Sub HD_URIKJN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(15), HD_URIKJN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_URIKJN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_URIKJN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 15
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 15
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(15), HD_URIKJN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(15), HD_URIKJN)
   HD_URIKJN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_URIKJN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_URIKJN, KEYCODE, Shift, CP_SSSMAIN(15).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKJN(AE_Val3(CP_SSSMAIN(15), (HD_URIKJN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (15)
   End If
End Sub

Private Sub HD_URIKJN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 15 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(15), HD_URIKJN, KeyAscii)
End Sub

Private Sub HD_URIKJN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(15).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKJN(AE_Val3(CP_SSSMAIN(15), (HD_URIKJN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_URIKJN.SetFocus
      End If
   End If
   If HD_URIKJN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(15), CL_SSSMAIN(15), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_URIKJN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_URIKJN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_URIKJN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_URIKJN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 15
   End If
End Sub

Private Sub HD_URIKJN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_URIKJN.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(15), HD_URIKJN)
End Sub

Private Sub HD_URIKJNNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(16), HD_URIKJNNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_URIKJNNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub HD_URIKJNNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 16
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 16
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(16), HD_URIKJNNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(16), HD_URIKJNNM)
   HD_URIKJNNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub HD_URIKJNNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(HD_URIKJNNM, KEYCODE, Shift, CP_SSSMAIN(16).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_URIKJNNM(AE_Val3(CP_SSSMAIN(16), (HD_URIKJNNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (16)
   End If
End Sub

Private Sub HD_URIKJNNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 16 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(16), HD_URIKJNNM, KeyAscii)
End Sub

Private Sub HD_URIKJNNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(16).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_URIKJNNM(AE_Val3(CP_SSSMAIN(16), (HD_URIKJNNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         HD_URIKJNNM.SetFocus
      End If
   End If
   If HD_URIKJNNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(16), CL_SSSMAIN(16), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub HD_URIKJNNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), HD_URIKJNNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = HD_URIKJNNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         HD_URIKJNNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 16
   End If
End Sub

Private Sub HD_URIKJNNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   HD_URIKJNNM.Locked = False
End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub
Private Sub MN_AppendC_Click() 'Generated.
Dim wk_Cursor As Integer
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Cursor = AE_AppendC_SSSMAIN(PP_SSSMAIN.Mode)
   If wk_Cursor = Cn_CuInit Then Call AE_CursorInit_SSSMAIN
' === 20130522 === INSERT S - FWEST)Koroyasu îrëºêßå‰ÇÃâèú
    Call SSSWIN_Unlock_EXCTBZ
' === 20130522 === INSERT E -
End Sub

Private Sub MN_ClearDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   
'2008/1/22 FKS)ichihara CHG START
'FJCLèCê≥ï™ÇÃîΩâfÅi377àƒåèï™Åj
'   If ClearDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv2_SSSMAIN(CP_SSSMAIN(75 + 88 * PP_SSSMAIN.De).CuVal)) Then
   If ClearDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv1_SSSMAIN(CP_SSSMAIN(126 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(75 + 88 * PP_SSSMAIN.De).CuVal)) Then
'2008/1/22 FKS)ichihara CHG END
   
   If PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 Then
      If (PP_SSSMAIN.Tx - 21) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then
            Call AE_ClearDe2_SSSMAIN
         End If
      End If
   Else
      Beep
   End If
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

Private Sub MN_DeleteDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   If PP_SSSMAIN.Mode = Cn_Mode3 Then Beep: Call AE_CursorCurrent_SSSMAIN: Exit Sub
   If DeleteDe_GetEvent(PP_SSSMAIN.De2, AE_NullCnv1_SSSMAIN(CP_SSSMAIN(126 + 88 * PP_SSSMAIN.De).CuVal), AE_NullCnv2_SSSMAIN(CP_SSSMAIN(75 + 88 * PP_SSSMAIN.De).CuVal)) Then
   If PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 Then
      If (PP_SSSMAIN.Tx - 21) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         Call AE_DeleteDe_SSSMAIN
      End If
   Else
      Beep
   End If
   End If
End Sub

Private Sub MN_EditMn_Click() 'Generated.
Const CF_TEXT As Integer = 1
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_APPENDC = True
   MN_ClearItm = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 111 Then
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
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 And PP_SSSMAIN.Mode <> Cn_Mode3 Then
      If (PP_SSSMAIN.Tx - 21) \ 15 + PP_SSSMAIN.TopDe < PP_SSSMAIN.LastDe Then
         If PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 Then
            If Not AE_IsClearedDe_SSSMAIN(PP_SSSMAIN.De) Then MN_ClearDE = True
         End If
         MN_DeleteDE = True
      End If
   End If
   MN_Copy = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 111 Then
      If CP_SSSMAIN(PP_SSSMAIN.Px).TypeA = Cn_NormalOrV Then
         If Not IsNull(AE_Val5(CP_SSSMAIN(PP_SSSMAIN.Px), (AE_Controls(PP_SSSMAIN.CtB + PP_SSSMAIN.Tx)))) Then MN_Copy = True
      End If
   End If
   MN_Cut = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 111 Then
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
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 111 Then
      If TypeOf Screen.ActiveControl Is TextBox Then
         If Clipboard.GetFormat(CF_TEXT) Then
            If AE_IsWritableInOutMode(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px)) And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Paste = True
         End If
      End If
   End If
   MN_UnDoItem = False
   If PP_SSSMAIN.OnFocus And PP_SSSMAIN.Tx >= 0 And PP_SSSMAIN.Tx < 111 Then
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

Private Sub MN_Oprt_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
   MN_Slist = False
   If False Then
   ElseIf PP_SSSMAIN.Tx = 1 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 4 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 6 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 7 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 9 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf PP_SSSMAIN.Tx = 17 Then
      If AE_GetInOutMode(CP_SSSMAIN(PP_SSSMAIN.Px).InOutMode, PP_SSSMAIN.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP_SSSMAIN(PP_SSSMAIN.Px).BlockNo, PP_SSSMAIN.ActiveBlockNo) Then MN_Slist = True
   ElseIf (PP_SSSMAIN.Tx - 21) Mod 15 = 6 And PP_SSSMAIN.Tx >= 21 And PP_SSSMAIN.Tx < 96 Then
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
      If Screen.ActiveControl.TabIndex >= 111 Then
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

Private Sub MN_UnDoDe_Click() 'Generated.
   If Not PP_SSSMAIN.Operable Then Exit Sub
      Call AE_UnDoDe_SSSMAIN
   Call AE_CursorCurrent_SSSMAIN
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

Private Sub TL_DENCM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8780), TL_DENCM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_DENCM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_DENCM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 106
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8780
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8780), TL_DENCM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8780), TL_DENCM)
   TL_DENCM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_DENCM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_DENCM, KEYCODE, Shift, CP_SSSMAIN(8780).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENCM(AE_Val3(CP_SSSMAIN(8780), (TL_DENCM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (106)
   End If
End Sub

Private Sub TL_DENCM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 106 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8780), TL_DENCM, KeyAscii)
End Sub

Private Sub TL_DENCM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8780).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENCM(AE_Val3(CP_SSSMAIN(8780), (TL_DENCM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_DENCM.SetFocus
      End If
   End If
   If TL_DENCM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8780), CL_SSSMAIN(8780), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_DENCM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_DENCM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_DENCM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_DENCM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 106
   End If
End Sub

Private Sub TL_DENCM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_DENCM.Locked = False
End Sub

Private Sub TL_DENCMIN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8781), TL_DENCMIN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_DENCMIN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_DENCMIN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 107
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8781
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8781), TL_DENCMIN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8781), TL_DENCMIN)
   TL_DENCMIN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_DENCMIN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_DENCMIN, KEYCODE, Shift, CP_SSSMAIN(8781).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_DENCMIN(AE_Val3(CP_SSSMAIN(8781), (TL_DENCMIN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (107)
   End If
End Sub

Private Sub TL_DENCMIN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 107 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8781), TL_DENCMIN, KeyAscii)
End Sub

Private Sub TL_DENCMIN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8781).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_DENCMIN(AE_Val3(CP_SSSMAIN(8781), (TL_DENCMIN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_DENCMIN.SetFocus
      End If
   End If
   If TL_DENCMIN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8781), CL_SSSMAIN(8781), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_DENCMIN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_DENCMIN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_DENCMIN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_DENCMIN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 107
   End If
End Sub

Private Sub TL_DENCMIN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_DENCMIN.Locked = False
End Sub

Private Sub TL_KENNMA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8770), TL_KENNMA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_KENNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_KENNMA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 96
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8770
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8770), TL_KENNMA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8770), TL_KENNMA)
   TL_KENNMA.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_KENNMA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_KENNMA, KEYCODE, Shift, CP_SSSMAIN(8770).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_KENNMA(AE_Val3(CP_SSSMAIN(8770), (TL_KENNMA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (96)
   End If
End Sub

Private Sub TL_KENNMA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 96 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8770), TL_KENNMA, KeyAscii)
End Sub

Private Sub TL_KENNMA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8770).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_KENNMA(AE_Val3(CP_SSSMAIN(8770), (TL_KENNMA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_KENNMA.SetFocus
      End If
   End If
   If TL_KENNMA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8770), CL_SSSMAIN(8770), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_KENNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_KENNMA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_KENNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_KENNMA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 96
   End If
End Sub

Private Sub TL_KENNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_KENNMA.Locked = False
End Sub

Private Sub TL_KENNMB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8771), TL_KENNMB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_KENNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_KENNMB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 97
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8771
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8771), TL_KENNMB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8771), TL_KENNMB)
   TL_KENNMB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_KENNMB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_KENNMB, KEYCODE, Shift, CP_SSSMAIN(8771).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_KENNMB(AE_Val3(CP_SSSMAIN(8771), (TL_KENNMB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (97)
   End If
End Sub

Private Sub TL_KENNMB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 97 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8771), TL_KENNMB, KeyAscii)
End Sub

Private Sub TL_KENNMB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8771).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_KENNMB(AE_Val3(CP_SSSMAIN(8771), (TL_KENNMB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_KENNMB.SetFocus
      End If
   End If
   If TL_KENNMB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8771), CL_SSSMAIN(8771), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_KENNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_KENNMB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_KENNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_KENNMB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 97
   End If
End Sub

Private Sub TL_KENNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_KENNMB.Locked = False
End Sub

Private Sub TL_MAEUKKB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8778), TL_MAEUKKB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_MAEUKKB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_MAEUKKB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 104
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8778
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8778), TL_MAEUKKB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8778), TL_MAEUKKB)
   TL_MAEUKKB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_MAEUKKB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_MAEUKKB, KEYCODE, Shift, CP_SSSMAIN(8778).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_MAEUKKB(AE_Val3(CP_SSSMAIN(8778), (TL_MAEUKKB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (104)
   End If
End Sub

Private Sub TL_MAEUKKB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 104 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8778), TL_MAEUKKB, KeyAscii)
End Sub

Private Sub TL_MAEUKKB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8778).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_MAEUKKB(AE_Val3(CP_SSSMAIN(8778), (TL_MAEUKKB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_MAEUKKB.SetFocus
      End If
   End If
   If TL_MAEUKKB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8778), CL_SSSMAIN(8778), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_MAEUKKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_MAEUKKB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_MAEUKKB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_MAEUKKB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 104
   End If
End Sub

Private Sub TL_MAEUKKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_MAEUKKB.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8778), TL_MAEUKKB)
End Sub

Private Sub TL_MAEUKNM_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8779), TL_MAEUKNM) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_MAEUKNM(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_MAEUKNM_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 105
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8779
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8779), TL_MAEUKNM)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8779), TL_MAEUKNM)
   TL_MAEUKNM.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_MAEUKNM_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_MAEUKNM, KEYCODE, Shift, CP_SSSMAIN(8779).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_MAEUKNM(AE_Val3(CP_SSSMAIN(8779), (TL_MAEUKNM)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (105)
   End If
End Sub

Private Sub TL_MAEUKNM_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 105 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8779), TL_MAEUKNM, KeyAscii)
End Sub

Private Sub TL_MAEUKNM_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8779).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_MAEUKNM(AE_Val3(CP_SSSMAIN(8779), (TL_MAEUKNM)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_MAEUKNM.SetFocus
      End If
   End If
   If TL_MAEUKNM.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8779), CL_SSSMAIN(8779), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_MAEUKNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_MAEUKNM)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_MAEUKNM.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_MAEUKNM.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 105
   End If
End Sub

Private Sub TL_MAEUKNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_MAEUKNM.Locked = False
End Sub

Private Sub TL_NHSADA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8775), TL_NHSADA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSADA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 101
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8775
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8775), TL_NHSADA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8775), TL_NHSADA)
   TL_NHSADA.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSADA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSADA, KEYCODE, Shift, CP_SSSMAIN(8775).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(8775), (TL_NHSADA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (101)
   End If
End Sub

Private Sub TL_NHSADA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 101 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8775), TL_NHSADA, KeyAscii)
End Sub

Private Sub TL_NHSADA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8775).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADA(AE_Val3(CP_SSSMAIN(8775), (TL_NHSADA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSADA.SetFocus
      End If
   End If
   If TL_NHSADA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8775), CL_SSSMAIN(8775), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSADA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSADA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSADA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 101
   End If
End Sub

Private Sub TL_NHSADA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSADA.Locked = False
End Sub

Private Sub TL_NHSADB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8776), TL_NHSADB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSADB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 102
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8776
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8776), TL_NHSADB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8776), TL_NHSADB)
   TL_NHSADB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSADB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSADB, KEYCODE, Shift, CP_SSSMAIN(8776).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(8776), (TL_NHSADB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (102)
   End If
End Sub

Private Sub TL_NHSADB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 102 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8776), TL_NHSADB, KeyAscii)
End Sub

Private Sub TL_NHSADB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8776).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADB(AE_Val3(CP_SSSMAIN(8776), (TL_NHSADB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSADB.SetFocus
      End If
   End If
   If TL_NHSADB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8776), CL_SSSMAIN(8776), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSADB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSADB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSADB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 102
   End If
End Sub

Private Sub TL_NHSADB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSADB.Locked = False
End Sub

Private Sub TL_NHSADC_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8777), TL_NHSADC) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSADC(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSADC_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 103
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8777
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8777), TL_NHSADC)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8777), TL_NHSADC)
   TL_NHSADC.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSADC_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSADC, KEYCODE, Shift, CP_SSSMAIN(8777).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(8777), (TL_NHSADC)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (103)
   End If
End Sub

Private Sub TL_NHSADC_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 103 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8777), TL_NHSADC, KeyAscii)
End Sub

Private Sub TL_NHSADC_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8777).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSADC(AE_Val3(CP_SSSMAIN(8777), (TL_NHSADC)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSADC.SetFocus
      End If
   End If
   If TL_NHSADC.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8777), CL_SSSMAIN(8777), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSADC_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSADC)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSADC.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSADC.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 103
   End If
End Sub

Private Sub TL_NHSADC_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSADC.Locked = False
End Sub

Private Sub TL_NHSCD_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8772), TL_NHSCD) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSCD(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSCD_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 98
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8772
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8772), TL_NHSCD)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8772), TL_NHSCD)
   TL_NHSCD.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSCD_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSCD, KEYCODE, Shift, CP_SSSMAIN(8772).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(8772), (TL_NHSCD)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (98)
   End If
End Sub

Private Sub TL_NHSCD_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 98 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8772), TL_NHSCD, KeyAscii)
End Sub

Private Sub TL_NHSCD_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8772).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSCD(AE_Val3(CP_SSSMAIN(8772), (TL_NHSCD)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSCD.SetFocus
      End If
   End If
   If TL_NHSCD.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8772), CL_SSSMAIN(8772), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSCD)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSCD.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSCD.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 98
   End If
End Sub

Private Sub TL_NHSCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSCD.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8772), TL_NHSCD)
End Sub

Private Sub TL_NHSNMA_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8773), TL_NHSNMA) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNMA(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSNMA_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 99
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8773
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8773), TL_NHSNMA)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8773), TL_NHSNMA)
   TL_NHSNMA.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSNMA_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSNMA, KEYCODE, Shift, CP_SSSMAIN(8773).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(8773), (TL_NHSNMA)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (99)
   End If
End Sub

Private Sub TL_NHSNMA_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 99 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8773), TL_NHSNMA, KeyAscii)
End Sub

Private Sub TL_NHSNMA_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8773).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMA(AE_Val3(CP_SSSMAIN(8773), (TL_NHSNMA)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSNMA.SetFocus
      End If
   End If
   If TL_NHSNMA.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8773), CL_SSSMAIN(8773), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSNMA_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSNMA)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSNMA.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSNMA.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 99
   End If
End Sub

Private Sub TL_NHSNMA_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSNMA.Locked = False
End Sub

Private Sub TL_NHSNMB_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8774), TL_NHSNMB) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_NHSNMB(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_NHSNMB_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 100
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8774
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8774), TL_NHSNMB)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8774), TL_NHSNMB)
   TL_NHSNMB.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_NHSNMB_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_NHSNMB, KEYCODE, Shift, CP_SSSMAIN(8774).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(8774), (TL_NHSNMB)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (100)
   End If
End Sub

Private Sub TL_NHSNMB_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 100 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8774), TL_NHSNMB, KeyAscii)
End Sub

Private Sub TL_NHSNMB_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8774).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_NHSNMB(AE_Val3(CP_SSSMAIN(8774), (TL_NHSNMB)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_NHSNMB.SetFocus
      End If
   End If
   If TL_NHSNMB.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8774), CL_SSSMAIN(8774), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_NHSNMB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_NHSNMB)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_NHSNMB.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_NHSNMB.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 100
   End If
End Sub

Private Sub TL_NHSNMB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_NHSNMB.Locked = False
End Sub

Private Sub TL_SBADENKN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8784), TL_SBADENKN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SBADENKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_SBADENKN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 110
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8784
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8784), TL_SBADENKN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8784), TL_SBADENKN)
   TL_SBADENKN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_SBADENKN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_SBADENKN, KEYCODE, Shift, CP_SSSMAIN(8784).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBADENKN(AE_Val3(CP_SSSMAIN(8784), (TL_SBADENKN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (110)
   End If
End Sub

Private Sub TL_SBADENKN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 110 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8784), TL_SBADENKN, KeyAscii)
End Sub

Private Sub TL_SBADENKN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8784).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBADENKN(AE_Val3(CP_SSSMAIN(8784), (TL_SBADENKN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_SBADENKN.SetFocus
      End If
   End If
   If TL_SBADENKN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8784), CL_SSSMAIN(8784), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_SBADENKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBADENKN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_SBADENKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_SBADENKN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 110
   End If
End Sub

Private Sub TL_SBADENKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_SBADENKN.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8784), TL_SBADENKN)
End Sub

Private Sub TL_SBAURIKN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8782), TL_SBAURIKN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SBAURIKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_SBAURIKN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 108
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8782
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8782), TL_SBAURIKN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8782), TL_SBAURIKN)
   TL_SBAURIKN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_SBAURIKN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_SBAURIKN, KEYCODE, Shift, CP_SSSMAIN(8782).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBAURIKN(AE_Val3(CP_SSSMAIN(8782), (TL_SBAURIKN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (108)
   End If
End Sub

Private Sub TL_SBAURIKN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 108 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8782), TL_SBAURIKN, KeyAscii)
End Sub

Private Sub TL_SBAURIKN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8782).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBAURIKN(AE_Val3(CP_SSSMAIN(8782), (TL_SBAURIKN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_SBAURIKN.SetFocus
      End If
   End If
   If TL_SBAURIKN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8782), CL_SSSMAIN(8782), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_SBAURIKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBAURIKN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_SBAURIKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_SBAURIKN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 108
   End If
End Sub

Private Sub TL_SBAURIKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_SBAURIKN.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8782), TL_SBAURIKN)
End Sub

Private Sub TL_SBAUZEKN_Change() 'Generated.
   If PP_SSSMAIN.MultiLineF > 0 Then
      PP_SSSMAIN.MultiLineF = PP_SSSMAIN.MultiLineF - 1
      If PP_SSSMAIN.MultiLineF = 0 Then Exit Sub
   End If
   If PP_SSSMAIN.MaskMode = False Then
      If AE_Change(PP_SSSMAIN, CP_SSSMAIN(8783), TL_SBAUZEKN) Then
         PP_SSSMAIN.CursorDirection = Cn_Direction1
         PP_SSSMAIN.CursorDest = Cn_Dest9
         Call AE_Check_SSSMAIN_SBAUZEKN(PP_SSSMAIN.NewVal, Cn_Status6, True, True)
      End If
   End If
End Sub

Private Sub TL_SBAUZEKN_GotFocus() 'Generated.
   If PP_SSSMAIN.NeglectPopupFocus Then Exit Sub
   PP_SSSMAIN.ExTx = PP_SSSMAIN.Tx
   If PP_SSSMAIN.ExTx = -1 Then TX_CursorRest.TabStop = False
   PP_SSSMAIN.Tx = 109
   PP_SSSMAIN.De2 = -1
   PP_SSSMAIN.Px = 8783
   If Not PP_SSSMAIN.Operable Then Exit Sub
   wk_Int = AE_GotFocus(PP_SSSMAIN, CP_SSSMAIN(8783), TL_SBAUZEKN)
   If wk_Int >= 0 Then Call AE_CursorSub_SSSMAIN(wk_Int): Exit Sub
   If PP_SSSMAIN.ExTx < 21 Then
      If AE_CompleteCheck_SSSMAIN(True) > 0 Then
         If PP_SSSMAIN.InCompletePx >= 0 Then
            If CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonH And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_OptionButtonC And CP_SSSMAIN(PP_SSSMAIN.InCompletePx).TypeA <> Cn_CheckBox Then Call AE_CursorMove_SSSMAIN(PP_SSSMAIN.InCompletePx): Exit Sub
         End If
         PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
         wk_Bool = AE_CursorPrev_SSSMAIN(PP_SSSMAIN.Tx): Exit Sub
      End If
   End If
   Call AE_SetSelLen(PP_SSSMAIN, CP_SSSMAIN(8783), TL_SBAUZEKN)
   TL_SBAUZEKN.BackColor = Cn_ClBrightON
   CM_SLIST.Enabled = False
End Sub

Private Sub TL_SBAUZEKN_KeyDown(KEYCODE As Integer, Shift As Integer) 'Generated.
   If AE_KeyDown_SSSMAIN(TL_SBAUZEKN, KEYCODE, Shift, CP_SSSMAIN(8783).TpStr) Then
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then Call AE_Check_SSSMAIN_SBAUZEKN(AE_Val3(CP_SSSMAIN(8783), (TL_SBAUZEKN)), Cn_Status6, True, True)
      If PP_SSSMAIN.Mode = Cn_Mode3 Then AE_CursorNext_SSSMAIN (109)
   End If
End Sub

Private Sub TL_SBAUZEKN_KeyPress(KeyAscii As Integer) 'Generated.
   If PP_SSSMAIN.Tx <> 109 Then Beep: KeyAscii = 0: Exit Sub
   Call AE_KeyPress(PP_SSSMAIN, CP_SSSMAIN(8783), TL_SBAUZEKN, KeyAscii)
End Sub

Private Sub TL_SBAUZEKN_LostFocus() 'Generated.
   PP_SSSMAIN.OnFocus = False
   If PP_SSSMAIN.SuppressGotLostFocus = 2 Then PP_SSSMAIN.SuppressGotLostFocus = 0: Exit Sub
   PP_SSSMAIN.SuppressGotLostFocus = 0
   If PP_SSSMAIN.NeglectPopupFocus Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest): Exit Sub
   If PP_SSSMAIN.SlistSw Then PP_SSSMAIN.SlistSw = False: Exit Sub
   If CP_SSSMAIN(8783).StatusC = Cn_Status1 And PP_SSSMAIN.ModalFlag = False Then
      If Not PP_SSSMAIN.NeglectLostFocusCheck Then Call AE_Check_SSSMAIN_SBAUZEKN(AE_Val3(CP_SSSMAIN(8783), (TL_SBAUZEKN)), Cn_Status6, False, True): PP_SSSMAIN.LostFocusCheck = True
      If Not PP_SSSMAIN.NeglectLostFocusCheck And Ck_Error <> 0 Then
         On Error Resume Next
         TL_SBAUZEKN.SetFocus
      End If
   End If
   If TL_SBAUZEKN.BackColor = Cn_ClBrightON Then Call AE_ColorSub2(PP_SSSMAIN, CP_SSSMAIN(8783), CL_SSSMAIN(8783), PP_SSSMAIN.Tx)
   Call AE_CursorRivise_SSSMAIN
End Sub

Private Sub TL_SBAUZEKN_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   If PP_SSSMAIN.Operable Then
      If (Button And vbRightButton) = vbRightButton Then
         SM_FullPast.Enabled = AE_PopupMenu(PP_SSSMAIN, CP_SSSMAIN(PP_SSSMAIN.Px), TL_SBAUZEKN)
         PopupMenu SM_ShortCut, vbPopupMenuLeftButton
         PP_SSSMAIN.NeglectPopupFocus = False
         Dim wk_Tx As Integer
         wk_Tx = PP_SSSMAIN.Tx
         If PP_SSSMAIN.PopupTx = TL_SBAUZEKN.TabIndex Then wk_Tx = PP_SSSMAIN.PopupTx
         DoEvents
         TL_SBAUZEKN.Enabled = True
         Call AE_CursorMove_SSSMAIN(wk_Tx)
      End If
      PP_SSSMAIN.MouseDownTx = 109
   End If
End Sub

Private Sub TL_SBAUZEKN_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Generated.
   TL_SBAUZEKN.Locked = False
   Call AE_SetSel(PP_SSSMAIN, CP_SSSMAIN(8783), TL_SBAUZEKN)
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
         Do While wk_ww < 15
            Tx = 21 + 15 * De + wk_ww
            AE_Controls(PP_SSSMAIN.CtB + Tx).Visible = AE_Controls(PP_SSSMAIN.CtB + 21 + wk_ww).Visible
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
         wk_Bool = AE_CursorUp_SSSMAIN(111)
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
         wk_Bool = AE_CursorPrev_SSSMAIN(111)
      End If
   ElseIf (KEYCODE = vbKeyExecute Or KEYCODE = vbKeyReturn) And Shift = 0 Then
   ElseIf KEYCODE = vbKeyEnd And Shift = 0 Then
      PP_SSSMAIN.CursorDirection = Cn_Direction2 '2: Prev
      If PP_SSSMAIN.Mode = Cn_Mode3 Then Call AE_Scrl_SSSMAIN(98, False)
      If PP_SSSMAIN.Mode <> Cn_Mode3 Then
         If AE_CursorPrevDsp_SSSMAIN(111) Then Call AE_CursorRestSub_SSSMAIN(Cn_CursorToRest)
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


