VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "spr32x30.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�O��[���߂�"
   ClientHeight    =   10050
   ClientLeft      =   1455
   ClientTop       =   795
   ClientWidth     =   14520
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
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
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "����ō��z"
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
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderWidth     =   0
      BevelOuter      =   1
      Caption         =   "�萔��"
      OutLine         =   -1  'True
   End
   Begin VB.PictureBox img_bklight 
      AutoSize        =   -1  'True
      BorderStyle     =   0  '�Ȃ�
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
      BorderStyle     =   0  '�Ȃ�
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
         Name            =   "�l�r �S�V�b�N"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*����(�[��)��"
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
         Name            =   "�l�r �o�S�V�b�N"
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
         BorderStyle     =   0  '�Ȃ�
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox txt_message 
            Appearance      =   0  '�ׯ�
            BackColor       =   &H8000000F&
            BorderStyle     =   0  '�Ȃ�
            Height          =   195
            Left            =   105
            TabIndex        =   24
            TabStop         =   0   'False
            Text            =   "�G���[��v�����v�g�̃��b�Z�[�W���o�͂����Ƃ���ł��B"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*������    "
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   " *�����(�J�n)"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�U������ "
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�萔��"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "����ō��z"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�S����"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�S����"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�ĕ\��"
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
         Name            =   "�l�r �o�S�V�b�N"
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
            Name            =   "�l�r �S�V�b�N"
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
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�����p�P"
      Begin VB.PictureBox Picture2 
         Appearance      =   0  '�ׯ�
         BorderStyle     =   0  '�Ȃ�
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
            Appearance      =   0  '�ׯ�
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
            Appearance      =   0  '�ׯ�
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
         Caption         =   "��ď���"
         Height          =   660
         Left            =   9690
         TabIndex        =   44
         Top             =   615
         Width           =   4560
         Begin VB.OptionButton opt_sort 
            Caption         =   "�q�撍���ԍ�"
            Height          =   195
            Index           =   2
            Left            =   2790
            TabIndex        =   11
            TabStop         =   0   'False
            Top             =   285
            Width           =   1590
         End
         Begin VB.OptionButton opt_sort 
            Caption         =   "�����"
            Height          =   270
            Index           =   0
            Left            =   255
            TabIndex        =   7
            TabStop         =   0   'False
            Top             =   255
            Width           =   1200
         End
         Begin VB.OptionButton opt_sort 
            Caption         =   "�󒍔ԍ�"
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
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
         Left            =   4815
         MaxLength       =   10
         TabIndex        =   3
         Text            =   "YYYY/MM/DD"
         Top             =   705
         Width           =   1215
      End
      Begin VB.TextBox txt_kesikb 
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1935
         MaxLength       =   1
         TabIndex        =   4
         Text            =   "9"
         Top             =   1020
         Width           =   285
      End
      Begin VB.TextBox txt_kesidt 
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1935
         MaxLength       =   10
         TabIndex        =   0
         Text            =   "YYYY/MM/DD"
         Top             =   75
         Width           =   1215
      End
      Begin VB.TextBox txt_tokseicd 
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1935
         MaxLength       =   5
         TabIndex        =   1
         Text            =   "XXXX5"
         Top             =   390
         Width           =   1215
      End
      Begin VB.TextBox txt_kaidt_From 
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1935
         MaxLength       =   10
         TabIndex        =   2
         Text            =   "YYYY/MM/DD"
         Top             =   705
         Width           =   1215
      End
      Begin VB.TextBox txt_fridt 
         Appearance      =   0  '�ׯ�
         Height          =   330
         IMEMode         =   2  '��
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�[�����ް��\��"
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
            Name            =   "�l�r �o�S�V�b�N"
            Size            =   9
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Caption         =   "�����p�Q"
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Caption         =   "*�����(�I��)"
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "���͒S����"
         OutLine         =   -1  'True
      End
      Begin VB.PictureBox Picture1 
         Appearance      =   0  '�ׯ�
         BorderStyle     =   0  '�Ȃ�
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
            Appearance      =   0  '�ׯ�
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
         BackStyle       =   0  '����
         Caption         =   "����"
         Height          =   420
         Index           =   1
         Left            =   11265
         TabIndex        =   49
         Top             =   1635
         Width           =   1995
      End
      Begin VB.Label lbl_hytokkesdd 
         BackStyle       =   0  '����
         Caption         =   "�����  :"
         Height          =   420
         Index           =   0
         Left            =   10260
         TabIndex        =   48
         Top             =   1650
         Width           =   1995
      End
      Begin VB.Label lbl_shakbnm 
         BackStyle       =   0  '����
         Caption         =   "�U���܂��͎�`"
         Height          =   420
         Index           =   1
         Left            =   11250
         TabIndex        =   47
         Top             =   1380
         Width           =   3000
      End
      Begin VB.Label lbl_shakbnm 
         BackStyle       =   0  '����
         Caption         =   "�x������:"
         Height          =   420
         Index           =   0
         Left            =   10260
         TabIndex        =   46
         Top             =   1380
         Width           =   3000
      End
      Begin VB.Label lbl_b 
         Caption         =   "1:�\�����Ȃ�  9:�\������"
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
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�\������e�L�X�g�{�b�N�X�ݒ�p�p�l��"
      Begin VB.TextBox txt_urigoukei 
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
         Alignment       =   1  '�E����
         Appearance      =   0  '�ׯ�
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "���㍇�v"
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�O������z"
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�O��������v"
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
            Name            =   "�l�r �S�V�b�N"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�[���c�z"
         OutLine         =   -1  'True
      End
      Begin VB.Label lbl_c 
         Caption         =   "���������"
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
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BorderWidth     =   0
      BevelOuter      =   1
      Caption         =   "�萔��"
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
      Caption         =   "����(&1)"
      Begin VB.Menu mnu_regist 
         Caption         =   "�o�^(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu mnu_exit 
         Caption         =   "�I��(&X)"
      End
   End
   Begin VB.Menu mnu_hen 
      Caption         =   "�ҏW(&2)"
      Begin VB.Menu mnu_initdsp 
         Caption         =   "��ʏ�����(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu bar21 
         Caption         =   "-"
      End
      Begin VB.Menu mnu_zenkesi 
         Caption         =   "�S����(&A)"
         Shortcut        =   ^A
      End
      Begin VB.Menu mnu_zenkaijo 
         Caption         =   "�S����(&U)"
         Shortcut        =   ^U
      End
   End
   Begin VB.Menu mnu_sou 
      Caption         =   "����(&3)"
      Begin VB.Menu mnu_showwnd 
         Caption         =   "���̈ꗗ(&L)"
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
'//* All Right Reserved Copy Right (C)  ������Еx�m�ʊ֐��V�X�e���Y
'//***************************************************************************************
'//*
'//*�����́�
'//* URKET73 �O��[���߂�
'//*
'//*���o�[�W������
'//* 1.00
'//*
'//*���쐬�ҁ�
'//* FKS)
'//*
'//*��������
'//* �O��[���̖߂��������
'//*
'//**************************************************************************************
'//*�ύX����
'//* �ް�ޮ�  |  ���t    | �X�V��        |���e
'//* ---------|----------|---------------|-----------------------------------------------
'//* 1.00     |2009/06/13|FKS)���c       |�V�K�쐬(URKET53 ����������藬�p�쐬)
'//* 1.01     |2009/07/06|FKS)���c       |�����\���z�擾���W�b�N�̒ǉ�
'//* 1.02     |2009/08/28|FKS)���c       |�����\���z�擾���W�b�N�̕ύX(getUdntraNyukn)
'//* 1.03     |2009/09/03|FKS)���c       |�U�������Ɋւ��鏈����ύX(�߂���ʂ���̓��͂��ł��Ȃ�����)
'//*          |          |               |�@�U������(cmd_fridt/txt_fridt)��Visible��
'//* �@�@�@�@ |          |               |�@�uTure�v����uFalse�v�֕ύX
'//* �@�@�@�@ |          |               |�@�U������(txt_fridt)��TabStop���uTure�v����uFalse�v�֕ύX
'//* 1.04     |2009/09/07|FKS)���c       |���������ȑO�̓��t����͕s�Ƃ���B
'//* �@�@�@�@ |          |               |������̒S���҂��c�ƒS���Ŗ����ꍇ�A�G���[�Ƃ���B
'//* 2.00     |2009/09/16|FKS)���c       |�E���������T�}���[�̖{�������ڂɑ΂��ĉ����X�V���Ȃ��悤�ɂ���
'//*          |          |               |�E�O���������̓��������T�}���[�̖߂���ύX�i�����������j
'//*          |          |               |�E�萔���E����͎��g�̎����Ă�������敪�ɂď����g�������쐬����
'//*          |          |               |�E���[�Ή��̂��߁A���z�`�F�b�N�E�`�[�P�ʃ`�F�b�N���O��
'//**************************************************************************************



Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long
Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long

Dim intUrigoukei    As Currency     '������z�̍��v���i�[�i���ו\�����ɃZ�b�g�j
Dim intBfkesiknkei  As Currency     '�����ϊz(�����O)�̍��v�z���i�[�i���ו\�����ɃZ�b�g�j


Dim blnFriEnabled   As Boolean      '�U����������͂ł��邩�ǂ����̃t���O(����́u��`�v�u�U�������i�t�@�N�^�����O�j�v�����݂��鎞�j

Dim blnUsableSpread As Boolean      '���گ�ނ̲���Ă����s���邩�ǂ������׸�
Dim intMaxRow       As Integer      '���گ�ނ̕\���ő�s�����i�[

Dim blnUsableButton As Boolean      '�萔���A����ō��z�A�S�����A�S�����A�ĕ\���A�U������(���ו�)�̲���Ă����s���邩�ǂ������׸�
Dim intChkKb        As Integer      '�`�F�b�N�敪(1:�`�F�b�N 2:�`�F�b�N(�O�񂩂�ύX���̂�)
Dim blnUsableEvent  As Boolean      '����Ă����s���邩�ǂ������׸�(�ėp)
Dim blnINIT_FLG     As Boolean


Dim intInputMode    As Integer      '���͏��(1:�w�b�_�[ 2:���� 9:��ʃN���A�[����)


''�ԍ��`�F�b�N�p�\����
Private Type TYPE_AKAKRO_CHK
    idx            As Long      '�s�ԍ�
    CHKMK          As Integer   '�`�F�b�N�}�[�N
    UDNDT          As String    '�����
    JDNNO          As String    '�󒍇�
    KESIKN         As Currency  '�������z
End Type

Private AKAKRO_CHK() As TYPE_AKAKRO_CHK


''�`�[�P�ʃ`�F�b�N�p�\����
Private Type TYPE_JDNTRKB_CHK
    idx            As Long      '�s�ԍ�
    JDNNO          As String    '�󒍇�
    HYJDNNO        As String    '�\���p�󒍔ԍ�
    KOMIKN         As Currency  '�ō�������z
End Type

Private JDNTRKB_CHK() As TYPE_JDNTRKB_CHK



'�t�H�[�����[�h�C�x���g
Private Sub Form_Load()

    'WINDOW �ʒu�ݒ�
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    '���[�J���ϐ�������
    intUrigoukei = 0
    intBfkesiknkei = 0
    intMaxRow = 0
    intChkKb = 2

    blnFriEnabled = False
    blnUsableSpread = False
    blnUsableButton = False
    blnUsableEvent = True

    '��DB�ւ̐ڑ�
    If CF_Ora_USR1_Open = False Then
        MsgBox "DB�̐ڑ��Ɏ��s���܂����B", vbCritical, "�ڑ��G���["
    End If

    'PG������
    Call CF_Init

    '��ʏ�����
    initForm
    initCondition
    initHead
    initBody


    intInputMode = 1

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)

    
    '�����O�̏����o��
    Call SSSWIN_LOGWRT("�v���O�����N��")
End Sub

'�t�H�[���A�����[�h�C�x���g
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    '���I���m�F��MSG

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


    '�r���e�[�u���폜
    Call SSSEXC_EXCTBZ_CLOSE

' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

    'DB�̐ڑ���ؒf
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)

    Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)


    '�����O�̏����o��
    Call SSSWIN_LOGWRT("�v���O�����I��")

    End '��PG�I��
End Sub

'�t�H�[���̏�����
Private Sub initForm()
    Dim i As Integer
'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
    Dim strRet As String
'''' ADD 2009/11/26  FKS) T.Yamamoto    End

    '�t�H�[���L���v�V�����Z�b�g
    Me.Caption = SSS_PrgNm

    '�^�p���̎擾
    gstrUnydt = getUnydt
    '�O��o�������s���̎擾
    Call getSYSTBA
'''' UPD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
'    '�����̎擾
'    Call Get_Authority(gstrUnydt)
    '�����̎擾
    strRet = Get_Authority(gstrUnydt)
    If strRet = "9" Then
        '�N�������Ȃ��̏ꍇ�A�����I��
        Call showMsg("2", "RUNAUTH", 0)
        End
    End If
'''' UPD 2009/11/26  FKS) T.Yamamoto    End

    '��ʉE��̍��ڂɉ^�p�����Z�b�g
    pnl_unydt.Caption = CNV_DATE(gstrUnydt)

    '���͒S���҂��Z�b�g
    txt_opeid.Text = SSS_OPEID
    txt_openm.Text = getTannm(SSS_OPEID)

    txt_message.Text = ""

    '�����Œ�p�p�l�����B��
    pnl_condition1.Caption = ""
    pnl_condition1.BevelOuter = ssBevelNone
    pnl_condition2.Caption = ""
    pnl_condition2.BevelOuter = ssBevelNone

    '�\������e�L�X�g�{�b�N�X�ݒ�p�p�l�����B��
    pnl_hihyoji.Caption = ""
    pnl_hihyoji.BevelOuter = ssBevelNone


    '���گ�މB�����ڂ��\���ɂ���
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

'���͏����̏�����
Private Sub initCondition()

    Call initVal    '��۰��ٕϐ��̏�����

    txt_kesidt.Text = CNV_DATE(gstrUnydt)   '�^�p�����Z�b�g
    txt_kesidt.ForeColor = vbBlack
    txt_kesidt.BackColor = vbWhite

    txt_tokseicd.Text = Space(5)            '5byte space
    txt_tokseicd.ForeColor = vbBlack
    txt_tokseicd.BackColor = vbWhite

    txt_tokseinma.Text = ""

    txt_kaidt_From.Text = Space(10)             '10byte space
    txt_kaidt_From.ForeColor = vbBlack
    txt_kaidt_From.BackColor = vbWhite

    txt_kaidt_To.Text = CNV_DATE(gstrUnydt)     '�^�p�����Z�b�g
    txt_kaidt_To.ForeColor = vbBlack
    txt_kaidt_To.BackColor = vbWhite



    '�O��[���͏����l���u�X�v�Ƃ���B
    'txt_kesikb.Text = 1
    txt_kesikb.Text = 9

    blnFriEnabled = False
    txt_fridt.Text = Space(10)                  '10byte space
    txt_fridt.ForeColor = vbBlack
    txt_fridt.BackColor = vbWhite
    txt_fridt.Enabled = blnFriEnabled

    blnUsableButton = False
    blnUsableEvent = True

    '�I�v�V�������ڂ̐���
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

'�w�b�_��(�������)�̏�����
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

'���ו��̏�����
Private Sub initBody()
    '�������ͽ��گ�޲���Ă����s�����Ȃ�
    blnUsableSpread = False

    With spd_body
        .ReDraw = False

        .Col = -1
        .Row = -1
        .Action = ActionClearText

        '�J�[�\���ʒu��擪�ɖ߂�
        .Col = 1
        .Row = 1
        .Action = ActionSelectBlock

        .MaxRows = 9999
        .ReDraw = True
    End With

    intMaxRow = 0

    '���گ�޲���Ă̋���
    blnUsableSpread = True
End Sub

'���ו��̏���\��
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

' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
    Dim rResult     As Integer  ' �����`�F�b�N�֐��߂�l
    Dim strUDNDT    As String
' === 20130708 === INSERT E

' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

    '�������ͽ��گ�޲���Ă����s�����Ȃ�
    blnUsableSpread = False

    '�r���p�z��̏�����
    ReDim ARY_UDNTRA_HAITA(0)
    ReDim ARY_JDNTRA_HAITA(0)
    ReDim ARY_UDNTRA_NYU_HAITA(0)
    
    ReDim ARY_NYUKN_KS(0)
    
    ARY_NYUKN_KS_CNT = 0

    '�}�E�X�J�[�\���������v�ɂ���
    Me.MousePointer = vbHourglass
    
    '���׃f�[�^�擾�pSQL���쐬
    Select Case True
        Case opt_sort(0).Value
            lw_sort = 0
        Case opt_sort(1).Value
            lw_sort = 1
        Case opt_sort(2).Value
            lw_sort = 2
    End Select
    
    
    '���ו��\���f�[�^�擾SQL���쐬����
    strSql = getSQLforBody( _
                            DB_SYSTBA.SMAUPDDT, _
                            gstrTokseicd, _
                            gstrKaidt_Fr, _
                            gstrKaidt_To, _
                            txt_kesikb.Text, _
                            lw_sort)
    '�ް��擾
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '�\�����ڏ�����
    initHead
    initBody


    '�������ͽ��گ�޲���Ă����s�����Ȃ�
    blnUsableSpread = False


    With spd_body
        .ReDraw = False

        Do While CF_Ora_EOF(Usr_Ody) = False

            '�\��t����f�[�^���ԕi�f�[�^�̏ꍇ����f�[�^������
            bleNextFlg = True

            '�ԕi�̐ԍ��`�F�b�N
            If chkHenpin(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then


                '�f�[�^�̕\�����s��Ȃ�
                bleNextFlg = False
            Else
                bleNextFlg = True
            End If
            
            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
                '�ԕi��A�󒍒��������̐ԍ��`�F�b�N
                If chkHenpinTeisei(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), _
                                Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", ""))) = False Then

                   '�f�[�^�̕\�����s��Ȃ�
                     bleNextFlg = False
                Else
                    bleNextFlg = True
                End If
            End If


        ''���͂��ꂽ�������ȍ~�̔���f�[�^���o���Ȃ�
            If bleNextFlg = False Then
                bleNextFlg = False

            Else
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim$(txt_kesidt.Text)) _
                        And Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) > 0 Then

                    '���f�[�^�œ��͂��ꂽ����������̔���͕\�����Ȃ�
                    bleNextFlg = False

                ElseIf Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim$(txt_kesidt.Text)) _
                        And Trim$(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) < 0 Then
                    '�ԕi�̏ꍇ�́A���ɉ�ʏ�ɓ����󒍔ԍ������݂��邩���m�F����B
                    With spd_body
                          For idxRow = intMaxRow To 1 Step -1
                              Call .GetText(COL_HYJDNNO, idxRow, tmp)
                              strHyjdnno = CStr(tmp)

                              If Trim(strHyjdnno) = Trim$(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
                                  '��ʏ�ɍ�������Ώo��
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



            '//�\�����f�`�F�b�N
            If chkHenpin2(Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), _
                            Trim$(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
                bleNextFlg = False
            End If


            If bleNextFlg = True Then

                intMaxRow = intMaxRow + 1

                '�X�v���b�h�Ɏ擾�����f�[�^��\��
                .Row = intMaxRow
                .Col = COL_NO           'No.
                .Text = intMaxRow

                .Col = COL_NXTKB        '���[
                .Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")

                .Col = COL_HYUDNDT      '�����
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
                strUDNDT = .Text
' === 20130708 === INSERT E -

                .Col = COL_HYJDNNO      '�󒍔ԍ�
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
                If .Text <> "" Then
                    '�r���`�F�b�N
                    rResult = SSSWIN_EXCTBZ_CHECK2(Left$(.Text, 6))
                    Select Case rResult
                        '����
                        Case 0
                        
                        '�r��������
                        Case 1
                        MsgBox ("���̃v���O�����ōX�V���̂��߁A�o�^�ł��܂���B" & vbCrLf & vbCrLf _
                                    & "�sNo:" & vbTab & intMaxRow & vbCrLf _
                                    & "�����: " & vbTab & strUDNDT & vbCrLf _
                                    & "�󒍔ԍ�: " & vbTab & .Text)
                        Call SSSWIN_Unlock_EXCTBZ
                        initBody
                        GoTo STEP10_ShowBody
                        
                        '�ُ�I��
                        Case 9
                        Call showMsg("2", "URKET73_034", 0)  '�X�V�ُ�
                        Call SSSWIN_Unlock_EXCTBZ
                        initBody
                        GoTo STEP10_ShowBody
                    End Select
                End If
' === 20130708 === INSERT E -

                .Col = COL_HYKAIDT      '����\���
                .Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")

                .Col = COL_TOKJDNNO     '�q�撍���ԍ�
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")

                .Col = COL_TANNM        '�c�ƒS����
                .Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")

                .Col = COL_URIKN        '�Ŕ�������z
                .Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")

                .Col = COL_UZEKN        '����Ŋz
                .Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")

                .Col = COL_KOMIKN       '�ō�������z
                .Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
                '���v���z���v�Z
                intUrigoukei = intUrigoukei + SSSVal(.Text)

                .Col = COL_KESIKN       '�����ϊz
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")

                .Col = COL_MINYUKN      '�������z(��\��)
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")

                .Col = COL_HYFRIDT      '�U������
                strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
                If Trim(strTEGDT) <> "" Then
                    .Text = CNV_DATE(strTEGDT)
                Else
        '*** 2009/09/03 ADD START FKS)NAKATA V1.03
                    '�������R�[�h���U���������擾����
                    strTEGDT = Get_NYUKN_TEGDT(CF_Ora_GetDyn(Usr_Ody, "jdnno", ""), CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
        '*** 2009/09/03 ADD E.N.D FKS)NAKATA
                    If Trim(strTEGDT) <> "" Then
                        .Text = CNV_DATE(strTEGDT)
                    End If
                End If
                
                .Col = COL_BFHYFRIDT    '�U������(�ύX�O)
                If Trim(strTEGDT) <> "" Then
                    .Text = CNV_DATE(strTEGDT)
                
        '*** 2009/09/03 DEL START FKS)NAKATA V1.03
        '        Else
        '            .Text = CNV_DATE(gstrFridt)                 'ͯ�ނŎw�肵���U�������������\��
        '*** 2009/09/03 DEL START FKS)NAKATA V1.03
                End If
                .Col = COL_HYFRIDT      '�U������

                '�w�b�_���Ɠ������A���ו��̓��͂�����

                .Lock = Not blnFriEnabled
                
                .Col = COL_BFKESIKN  '�����ϊz(�����O)
                .Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
                    '���v���z���v�Z
                    intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)

                    '�������ϊz(KESIKN) - �����ϊz(�����O) > 0 �̂Ƃ������ޯ����������t����
                    .GetText COL_KESIKN, .Row, tmp
                    
                    If SSSVal(tmp) <> 0 Then

                        .Col = COL_CHK
                        .Value = 1

                        .Col = COL_BFCHECK
                        .Value = 1

                    End If

                .Col = COL_AFKESIKN     '�����ϊz(������)
                .Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")

                .Col = COL_JDNNO        '�󒍔ԍ�(6��)
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")

                .Col = COL_JDNLINNO     '�󒍍s�ԍ�
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")

                .Col = COL_UDNDT        '�����(�X���b�V���Ȃ�)
                .Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")

                .Col = COL_KESDT        '����\���(�X���b�V���Ȃ��j
                .Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")

                .Col = COL_TOKCD        '���Ӑ溰��
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")

                .Col = COL_TOKSEICD     '�����溰��
                .Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")

                .Col = COL_TANCD        '�S���Һ���
                .Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")

                .Col = COL_JDNDT        '�󒍓�
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")

                .Col = COL_TUKKB        '�ʉ݋敪
                .Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")

                .Col = COL_INVNO        '���޲��ԍ�
                .Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")

                .Col = COL_FURIKN       '�C�O������z
                .Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")

                .Col = COL_FRNKB        '�C�O����敪
                .Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")

                .Col = COL_UDNDATNO     '����DATNO
                .Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")

                .Col = COL_UDNLINNO     '����s�ԍ�
                .Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")

                .Col = COL_MAEUKKB      '�O��敪
                .Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")

                .Col = COL_JDNDATNO     '��DATNO
                .Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")


                .Col = COL_KESIKN_MAE   '�������z�O
                .Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))

                
                If SSSVal(CF_Ora_GetDyn(Usr_Ody, "komikn", "")) - SSSVal(CF_Ora_GetDyn(Usr_Ody, "kesikn", "")) < 0 Then
                    .Col = COL_HENPI
                    .Text = "1"
                End If
                
                
                '����g�����̔r�����擾
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

                '�󒍃g�����̔r�����擾
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
                
                
                '����g�����������R�[�h�̔r�����擾
                Call getUdntraNyukn(CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")))

            End If

            Usr_Ody.Obj_Ody.MoveNext
        Loop

    End With

    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��

    '�����Ώۂ��Ȃ���΃��b�Z�[�W��\��
    If intMaxRow = 0 Then
        Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
        txt_kesidt.SetFocus

    '�Ώۂ����鎞
    Else

        '���������g�����̔r�����擾
        Call Get_NKSTRA_HAITA_INF

        '�\���s����16�s�ȏ�̂Ƃ��A���گ�ލs����ݒ�
        If intMaxRow > 16 Then
            spd_body.MaxRows = intMaxRow
        Else
            spd_body.MaxRows = 16
        End If

        showHead    'ͯ�ޕ��̕\��
        
        'spd_body.SetFocus
        blnUsableButton = True  '�����ݎg�p�̋���
        mnu_zenkesi.Enabled = blnUsableButton
        mnu_zenkaijo.Enabled = blnUsableButton
        '�����p�l���̃��b�N
        pnl_condition1.Enabled = False
        pnl_condition2.Enabled = False


'*** 2009/09/16 ADD START FKS)NAKATA
        '�ԕi���z�̍l��
        getHenpinKingaku
'*** 2009/09/16 ADD E.N.D FKS)NAKATA


    End If
' === 20130708 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
STEP10_ShowBody:
' === 20130708 === INSERT E
    


    spd_body.ReDraw = True

    
    '���گ�޲���Ă̋���
    blnUsableSpread = True

    '�}�E�X�J�[�\����W���ɖ߂�
    Me.MousePointer = vbNormal
End Sub

'�w�b�_��(�������)�̕\��
Public Sub showHead()

    Dim intZankn    As Currency     '���������x�܂ł̏����c�z�v
    Dim intKesikn   As Currency     '�o�������ȍ~�̏����z
    Dim intTesuryo  As Currency     '���������x�̎萔���z���i�[
    Dim intSyohi    As Currency     '���������x�̏���Ŋz���i�[

    Dim tmp As Currency
    Dim i       As Integer

    
    intZankn = 0
    intKesikn = 0
    intTesuryo = 0
    intSyohi = 0


    '�r�����Ə������z�����擾
    Call getHaitaAndKnSum(DB_TOKMTA.TOKSEICD _
                        , Get_Acedt(gstrKesidt) _
                        , DB_TOKMTA.SHAKB)


    '���������x�܂ł̏����c�z�v
    For i = 0 To 9
        intZankn = intZankn + ARY_NKSSMB_KS(i).KSKZANKN
    Next i

    '�o�������ȍ~�̏����z
    For i = 0 To 9
        intKesikn = intKesikn + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN
    Next i

    '���������x�̎萔���E����Ŋz���i�[
    i = SSSVal(TesuryoID)
    intTesuryo = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
    i = SSSVal(SyohiID)
    intSyohi = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))


    '���㍇�v���z�̕\��
    txt_urigoukei.Text = Format(intUrigoukei, "###,###,##0")

    '�����z�E�萔���z�E����Ŋz�̕\��
    tmp = intZankn + intKesikn
    If tmp - (intTesuryo + intSyohi) > 0 Then
        txt_nyukin.Text = Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
        txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
        txt_syohi.Text = Format(intSyohi, "#,###,##0")
    '�c���v���X�̂Ƃ�
    ElseIf tmp > 0 Then
        If intTesuryo > 0 Then
            If intSyohi > 0 Then
                '�c�z���v���X�ŁA�萔�����A����ō��z���v���X�̎�
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
                '�c�z���v���X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
                txt_nyukin.Text = Format(0, "#,###,##0")
                txt_tesuryo.Text = Format(tmp - intSyohi, "#,###,##0")
                txt_syohi.Text = Format(intSyohi, "#,###,##0")
            End If

        ElseIf intTesuryo <= 0 Then
            If intSyohi > 0 Then
                '�c�z���v���X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
                txt_nyukin.Text = Format(0, "#,###,##0")
                txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                txt_syohi.Text = Format(tmp - intTesuryo, "#,###,##0")
            ElseIf intSyohi <= 0 Then
                '�c�z���v���X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
                'tmp - (intTesuryo + intSyohi) �͐�΂ɐ��Ȃ̂ŁA�����ɏ����͕s�v
            End If
        End If

    '�c�����̎�
    ElseIf tmp <= 0 Then
        If intTesuryo > 0 Then
            If intSyohi > 0 Then
                '�c�z���}�C�i�X�ŁA�萔�����A����ō��z���v���X�̎�
                txt_nyukin.Text = Format(tmp, "#,###,##0")
                txt_tesuryo.Text = Format(0, "#,###,##0")
                txt_syohi.Text = Format(0, "#,###,##0")
            ElseIf intSyohi <= 0 Then
                '�c�z���}�C�i�X�ŁA�萔�����v���X�A����ō��z���}�C�i�X�̎�
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
                '�c�z���}�C�i�X�ŁA�萔�ʂ��}�C�i�X�A����ō��z���v���X�̎�
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
                '�c�z���}�C�i�X�ŁA�萔�����A����ō��z���}�C�i�X�̎�
                txt_nyukin.Text = Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
                txt_tesuryo.Text = Format(intTesuryo, "#,###,##0")
                txt_syohi.Text = Format(intSyohi, "#,###,##0")
            End If
        End If
    End If

    '�������v�z�̕\��
    tmp = SSSVal(txt_nyukin.Text) + SSSVal(txt_tesuryo.Text) + SSSVal(txt_syohi.Text)
    txt_nyugoukei.Text = Format(tmp, "###,###,##0")

    '�����c�z�̕\��
    txt_kesizan.Text = Format(intZankn + intKesikn, "###,###,##0")

End Sub

'���ו����v���z�̎擾
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


'�r�����Ə������z�����擾�A�O���[�o���ϐ��Ɋi�[
Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String _
                           , ByVal pin_strSMADT As String _
                           , ByVal pin_strSHAKB As String)
    Dim strSql  As Variant
    Dim Usr_Ody As U_Ody
    Dim i       As Integer

    '���������x�̏�����Ԃ��擾
    
    strSql = ""
    strSql = strSql & " SELECT * "
    strSql = strSql & "   FROM NKSSMB "
    strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
    strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '���������T�}���[�̔r�����擾
    ReDim ARY_NKSSMB_HAITA(1)
    ARY_NKSSMB_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
    ARY_NKSSMB_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
    ARY_NKSSMB_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
    ARY_NKSSMB_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
    ARY_NKSSMB_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
    ARY_NKSSMB_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))

    '���������T�}���̏����\���̔z��֎擾
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
                '09�F�{���� �́A����ɂ��Ȃ�
                .SSANYUKN = 0
                .KSKNYKKN = 0
                .KSKZANKN = 0
            End If

            '����敪�̐ݒ�
            Select Case i
                Case 0: .DATKB = "01"       '01�F����
                Case 1: .DATKB = "02"       '02�F�U��
                Case 2: .DATKB = "03"       '03�F��`
                Case 3: .DATKB = "04"       '04�F���E
                Case 4: .DATKB = "05"       '05�F�l��
                Case 5: .DATKB = "06"       '06�F�萔
                Case 6: .DATKB = "07"       '07�F��
                Case 7: .DATKB = "08"       '08�F�U����
                Case 8: .DATKB = "09"       '09�F�{����
                Case 9: .DATKB = "99"       '99�F����
            End Select


            '���������̐ݒ�i-1 �͏����Ȃ��j
            ' �@���E���A����Ł��B�萔�����C�������D�U�����E��`���F�U�������G�l�������H��
            Select Case i
                Case 0: .SEQ = 4            '����敪��01�F����
                Case 1: .SEQ = 5            '����敪��02�F�U��
                Case 2: .SEQ = 6            '����敪��03�F��`
                Case 3: .SEQ = 1            '����敪��04�F���E
                Case 4: .SEQ = 8            '����敪��05�F�l��
                Case 5: .SEQ = 3            '����敪��06�F�萔
                Case 6: .SEQ = 9            '����敪��07�F��
                Case 7: .SEQ = 7            '����敪��08�F�U����
                Case 8: .SEQ = -1           '����敪��09�F�{����
                Case 9: .SEQ = 2            '����敪��99�F����
            End Select

        End With
    Next i

    Call CF_Ora_CloseDyn(Usr_Ody)


    For i = 0 To 9
        '�c�����v�Z����
        With ARY_NKSSMB_KS(i)
            .ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
        End With
    Next i
End Sub


'�S�������j���[�N���b�N��
Private Sub mnu_zenkaijo_Click()
    cmd_zenkaijo_Click
End Sub

'�S�I�����j���[�N���b�N��
Private Sub mnu_zenkesi_Click()
    cmd_zenkesi_Click
End Sub

Private Sub opt_sort_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)


    '�t�@���N�V�����L�[������
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        '�t�@���N�V�����L�[���ʏ���
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
End Sub

'�w�b�_�p�l���}�E�X���[�u��
Private Sub pnl_head_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '�q���g�̕\��������������
    img_light.Picture = img_bklight(0).Picture
    txt_message.Text = ""
End Sub

'�A�C�R��[�I��]�N���b�N��
Private Sub img_exit_Click()
    Unload Me
End Sub
'�A�C�R��[�I��]�}�E�X�_�E����
Private Sub img_exit_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(1).Picture
End Sub
'�A�C�R��[�I��]�}�E�X���[�u��
Private Sub img_exit_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "���j���[�ɖ߂�܂��B"
End Sub
'�A�C�R��[�I��]�}�E�X�A�b�v��
Private Sub img_exit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(0).Picture
End Sub

'�A�C�R��[�o�^]�N���b�N��
Private Sub img_resist_Click()
    mnu_regist_Click
End Sub
'�A�C�R��[�o�^]�}�E�X�_�E����
Private Sub img_resist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_resist.Picture = img_bkresist(1).Picture
End Sub
'�A�C�R��[�o�^]�}�E�X���[�u��
Private Sub img_resist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "�o�^���܂��B"
End Sub
'�A�C�R��[�o�^]�}�E�X�A�b�v��
Private Sub img_resist_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_resist.Picture = img_bkresist(0).Picture
End Sub

'�A�C�R��[����]�N���b�N��
Private Sub img_showwnd_Click()
    mnu_showwnd_Click
End Sub
'�A�C�R��[����]�}�E�X�_�E����
Private Sub img_showwnd_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(1).Picture
End Sub
'�A�C�R��[����]�}�E�X���[�u��
Private Sub img_showwnd_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "�E�B���h�E��\�����܂��B"
End Sub
'�A�C�R��[����]�}�E�X�A�b�v��
Private Sub img_showwnd_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(0).Picture
End Sub

'�A�C�R��[����]�N���b�N��
Private Sub img_unlock_Click()
    
    If blnUsableButton = True Then
        blnUsableButton = False
        pnl_condition1.Enabled = True
        pnl_condition2.Enabled = True
        initHead
        initBody
        txt_kesidt.SetFocus
        intInputMode = 1
' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
        Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -
   End If

End Sub
'�A�C�R��[����]�}�E�X�_�E����
Private Sub img_unlock_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_unlock.Picture = img_bkunlock(1).Picture
End Sub
'�A�C�R��[����]�}�E�X���[�u��
Private Sub img_unlock_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "��ʂ��N���A���ăR�[�h�̓��͂�҂��܂��B"
End Sub
'�A�C�R��[����]�}�E�X�A�b�v��
Private Sub img_unlock_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_unlock.Picture = img_bkunlock(0).Picture
End Sub

'���j���[[����]�|[�I��]�I����
Private Sub mnu_exit_Click()
    Unload Me
End Sub

'���j���[[����]�|[�o�^]�I����
Private Sub mnu_regist_Click()

Dim intRtn  As Integer


    '�w�b�_���̓��̓`�F�b�N
    If chkCondition = False Then Exit Sub
    '���ו��̓��̓`�F�b�N
    If blnUsableButton = False Then
        showMsg "0", "_UPDATE", "2"     '�����ו������͂�MSG
        Exit Sub
    End If


    '�ԕi�����̂Ȃ�������`�F�b�N
    If chkAkaKro = False Then
        Exit Sub
    End If

'**** 2009/09/16 DEL START FKS)NAKATA
'���[�Ή��̂��߃`�F�b�N���O��
''    '������z�Ə[�����z�̃`�F�b�N
''    If chkUrikn = False Then
''        Exit Sub
''    End If
''
''
''    '�`�[�P�ʂł̏[���`�F�b�N
''    If chkJdntrkb = False Then
''        Exit Sub
''    End If
'**** 2009/09/16 DEL E.N.D FKS)NAKATA


    '�������o�^����Ă��邩�̃`�F�b�N
    If chkNyukn = False Then
        Exit Sub
    End If


    '��`�������Ă���ꍇ�͐U�������̓��̓`�F�b�N
    If chkFurikomiDT = False Then
        Exit Sub
    End If



    '���o�^�m�F��MSG
    If showMsg("0", "_UPDATE", 0) = vbYes Then
        '�������̔��f
        If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
            showMsg "2", "UPDAUTH", "0"
            Exit Sub
        End If

        '�r���`�F�b�N
        If Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
            MsgBox "�y" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "�z���N�����ł��B" & _
                   Trim(SSS_PrgNm) & "����͂��鎖�͂ł��܂���B", vbExclamation Or vbOKOnly, SSS_PrgNm
'            Call HD_CLEAR
'            Call P_vaData_Init
            Exit Sub
        Else
            Call SSSEXC_EXCTBZ_OPEN
        End If


        Me.MousePointer = vbHourglass
        
        '�X�V����
        Select Case sRegistration(spd_body)
            Case 9
                '���X�V�������s��
                MsgBox "�X�V�Ɏ��s���܂����B", vbCritical, "�X�V�G���["
            Case 1
            
            Case 0
                '�����O�̏����o��
                Call SSSWIN_LOGWRT("�o�^����:" & Left(DB_TOKMTA.TOKSEICD, 5) & ":" & DB_TOKMTA.TOKRN)
                
                mnu_initdsp_Click   '��ʕ\���̏�����

        End Select
        
        Me.MousePointer = vbDefault


    End If

End Sub

'���j���[[�ҏW]�|[��ʏ�����]�I����
Private Sub mnu_initdsp_Click()
    
    intInputMode = 9
    pnl_condition1.Enabled = True
    pnl_condition2.Enabled = True
    '��ʂ̏�����
    initCondition
    initHead
    initBody
    '�������Ƀt�H�[�J�X���ړ�
    txt_kesidt.SetFocus
    txt_kesidt.BackColor = vbYellow
    blnINIT_FLG = True
' === 20130708 === INSERT S - FWEST)Koroyasu �r������̉���
    Call SSSWIN_Unlock_EXCTBZ
' === 20130708 === INSERT E -

End Sub


'���j���[[����]�|[���̈ꗗ]
Private Sub mnu_showwnd_Click()
    '�������Ƀt�H�[�J�X������Ƃ�
    If Me.ActiveControl.Name = txt_kesidt.Name Then
        cmd_kesidt_Click

    '�����溰�ނɃt�H�[�J�X������Ƃ�
    ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then
        cmd_tokseicd_Click


    '����\����Ƀt�H�[�J�X������Ƃ�
    ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then
        Call cmd_kaidt_From_Click

    '����\����Ƀt�H�[�J�X������Ƃ�
    ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then
        Call cmd_kaidt_To_Click


    '�U�������Ƀt�H�[�J�X������Ƃ�
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

    If Col = 14 Then '�����U�����̃`�F�b�N

        lw_col = Col
        lw_row = Row
        '�o�������ȑO�̓��t�̎��̓G���[
        ret = spd_body.GetText(Col, Row, spd_fridt_val)
        If ret = True Then
            spd_fridt = Format$(spd_fridt_val, "yyyy/mm/dd")
            If Trim$(spd_fridt) = "" Then
                blnUsableButton = True
            End If
            If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
                Call showMsg("1", "URKET73_010", 0)     '���o�����ߍς݂�MSG
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


    '�t�@���N�V�����L�[������
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        '�t�@���N�V�����L�[���ʏ���
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
End Sub

Private Sub txt_fridt_Validate(Cancel As Boolean)

    '���̓`�F�b�N
    chkFridt

    '�w�i�F�𔒂ɖ߂�
    txt_fridt.BackColor = vbWhite

End Sub


'�����溰�ލ��ڂ�ύX������
Private Sub txt_tokseicd_Change()
    Dim p As Integer

    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub

    blnUsableEvent = False
    p = txt_tokseicd.SelStart

    '�S�p���폜����
    txt_tokseicd.Text = delZenkaku(txt_tokseicd.Text)
    '���͒l��5byte�Ŗ������͋󔒖���
    txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))

    txt_tokseicd.SelStart = p
    blnUsableEvent = True

    '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
    If txt_tokseicd.SelStart = 5 Then
        intChkKb = 1                                '�������溰�ނ̓��̓`�F�b�N

        '���̓`�F�b�N
        If chkTokseicd = True Then
            '������
            txt_kaidt_From.SetFocus
        End If

    End If
    txt_tokseicd.SelLength = 1

End Sub

'�����溰�ލ��ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_tokseicd_GotFocus()
    '�擪�ʒu��I����Ԃɂ���
    txt_tokseicd.SelStart = 0
    txt_tokseicd.SelLength = 1
    '�w�i�F�����F�ɂ���
    txt_tokseicd.BackColor = vbYellow
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True
End Sub


'�����溰�ލ��ڂŃL�[����������
Private Sub txt_tokseicd_KeyDown(KeyCode As Integer, Shift As Integer)

    '�L�[���͐���
    Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
        Case 0
            '�������Ȃ�
        Case 1
            '���̓`�F�b�N
            If chkTokseicd = True Then
                '������
                txt_kaidt_From.SetFocus
            End If
        Case 2
            '���̓`�F�b�N
            If chkTokseicd = True Then
                '�O����
                txt_kesidt.SetFocus
            End If
    End Select
    
    KeyCode = 0
    
End Sub


'�����溰�ލ��ڂŃL�[����������
Private Sub txt_tokseicd_KeyPress(KeyAscii As Integer)
    '�A���t�@�x�b�g��������啶���ɕϊ�����
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

'�����溰�ލ��ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_tokseicd_LostFocus()
    
    '�w�i�F�𔒂ɖ߂�
    txt_tokseicd.BackColor = vbWhite

End Sub


'�����ς��ް��\�����ڂ�ύX������
Private Sub txt_kesikb_Change()
    If txt_kesikb.Text <> 9 Then
        txt_kesikb.Text = 1
    End If
    txt_kesikb.SelStart = 0
    txt_kesikb.SelLength = 1

    If txt_kesikb.Text = 1 Then
        cmd_kaidt_From.Caption = " �����(�J�n)"
    Else
        cmd_kaidt_From.Caption = " *�����(�J�n)"
    End If

End Sub

'�����ς��ް��\�����ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_kesikb_GotFocus()
    '�I����Ԃɂ���
    txt_kesikb.SelStart = 0
    txt_kesikb.SelLength = 1
    '�w�i�F�����F�ɂ���
    txt_kesikb.BackColor = vbYellow
    '�������������s�s�Ƃ���
    mnu_showwnd.Enabled = False
End Sub

'�����ς��ް��\�����ڂŃL�[����������
Private Sub txt_kesikb_KeyDown(KeyCode As Integer, Shift As Integer)

    '�t�@���N�V�����L�[������
    If KeyCode >= vbKeyF1 And KeyCode <= vbKeyF12 Then
        '�t�@���N�V�����L�[���ʏ���
        Call CF_FuncKey_Execute(KeyCode, Shift)
    End If

    
    '���� or ����󉟉���
    If KeyCode = vbKeyUp Or KeyCode = vbKeyLeft Then
        txt_kaidt_To.SetFocus

    'Enter or ����� or �E��󉟉���
    ElseIf KeyCode = vbKeyReturn Or KeyCode = vbKeyDown Or KeyCode = vbKeyRight Then
        '������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
        '����ȊO�͏����Ώۂ�����
        If blnFriEnabled = True Then
            txt_fridt.SetFocus
        Else
            spd_body.SetFocus
        End If

    'TAB��
    ElseIf KeyCode = vbKeyF16 Then
        '������̎x���������U�������A̧���ݸނ̎��͐U�������ɍ��ڈړ�
        '����ȊO�͏����Ώۂ�����
        If blnFriEnabled = True Then
            txt_fridt.SetFocus
        Else
            spd_body.SetFocus
        End If

    

    'TAB��
    ElseIf KeyCode = vbKeyF15 Then
        txt_kaidt_To.SetFocus

    
    End If

    KeyCode = 0
End Sub

'�����ς��ް��\�����ڂŃL�[����������
Private Sub txt_kesikb_KeyPress(KeyAscii As Integer)
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

'�����ς��ް��\�����ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_kesikb_LostFocus()
    '�w�i�F�𔒂ɖ߂�
    txt_kesikb.BackColor = vbWhite
End Sub

'=======================================================���ו�(�X�v���b�h)=======================================================

'�t�H�[�J�X�擾��
Private Sub spd_body_GotFocus()

    If intInputMode <> 1 Then
        Exit Sub
    End If

    '���݂��g�p�\(�����ް�����)�̎��͎��s���Ȃ�
    If blnUsableButton = True Then Exit Sub

    '�w�b�_�����͂���Ă�����f�[�^�������E�\������
    If chkCondition = True Then
    
        intInputMode = 2
    
        showBody    '���ް��\��
        
        '�ԕi���������A���b�N
        '�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
        'lockHenpin
        
    End If
End Sub

'�������ݸد���
Private Sub spd_body_ButtonClicked(ByVal Col As Long, ByVal Row As Long, ByVal ButtonDown As Integer)

    Dim intKesizan  As Currency  '�w�b�_�������c�z
    Dim intKomikn   As Currency  '�ō�����z
    Dim intKesikn   As Currency  '�����z
    Dim intBfKesikn As Currency  '�����z(�����O)
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



    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableSpread = False Then
        Exit Sub
    End If

    
    On Error Resume Next

    With spd_body
        '�����ޯ���د����A���ׂ̋��z�A�w�b�_�̎c���z�ɉ����ă`�F�b�N��ON�AOFF���s��
        If Col = 1 Then
            .Col = Col
            .Row = Row

            '�\���s�ȏ�̍s���N���b�N�������̓`�F�b�N�͂��Ȃ�
            If Row > intMaxRow Then
                '�����������Ȃ�
                blnUsableSpread = False
                .Value = 0
                blnUsableSpread = True
                Exit Sub
            End If

            intKesizan = SSSVal(txt_kesizan.Text)

            '�ō�����z���擾
            Call .GetText(COL_KOMIKN, .Row, tmp)
            intKomikn = SSSVal(tmp)
            
            '���ו������z
            Call .GetText(COL_KESIKN, .Row, tmp)
            intKesikn = SSSVal(tmp)

            '�������t���Ă��āA����������
            If ButtonDown = 0 Then

               '�����z���v���X�ł���΁A�������Ƀw�b�_���ɉ��Z
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
                    '�����������Ȃ�
                    blnUsableSpread = False
                    .Value = 1
                    blnUsableSpread = True
                End If


            '�������t���Ă��Ȃ��āA�`�F�b�N����ꂽ��
            ElseIf ButtonDown = 1 Then

                    '�����z���}�C�i�X�ł���Τ�������Ƀw�b�_���ɉ��Z
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
                    '�w�b�_�����c�����̎��̓`�F�b�N�����Ȃ�
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
                        
                        '�ꕔ�[���̋֎~ (�ō�������z <> �[�����z�̏ꍇ)
                        Call showMsg("1", "URKET73_041", 0) '�ꕔ�[���͂ł��܂���B
                        blnUsableSpread = False
                        .Value = 0
                        blnUsableSpread = True
    
''�ꕔ�[���������ꍇ�́A�ȉ��̃R�����g���O��
''DEL START (��)
'                        txt_kesizan.Text = Format(0, "###,###,##0")
''                        .SetText COL_KESIKN, .Row, intKesikn + intKesizan
''
''                        If DB_TOKMTA.SHAKB Like "[256]" Then
''                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
''                            If Trim$(LS_HYFRIDT) = "" Then
''                                .SetText COL_HYFRIDT, .Row, txt_fridt.Text
''                            End If
''                        End If
''DEL START (��)

                    End If
            End If
        End If
    End With
End Sub

'================================================================
'2009/06/12 DEL START FKS)NAKATA

'�萔�p�E����Ŋz�̓o�^�́A�{�����ł͍s��Ȃ��B
'�{�������g�p����ꍇ�́A�R�����g�A�E�g���O��
'�upnl_tesuryo�v�upnl_syohizei�v���t�H�[������폜���Ă��������B
'�p�l���̉��Ƀ{�^�����B���Ă��܂��B


''�萔�����ݎ��s��
'Private Sub cmd_tesuryo_Click()
'
'    Dim tmp             As Variant
'    Dim intchk          As Long
'    Dim idxRow          As Long
'    Dim idxRowJDNNO     As Long
'
'    Dim kesizan         As Currency '�w�b�_�������c�z
'    Dim kesikn          As Currency '���׍s�̓����ϊz
'
'
'    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
'    If blnUsableButton = False Then Exit Sub
'
'    '�����z������ʂ̕\��
''    FR_SSSSUB.Show (vbModal)
'
'
'    '�w�b�_���̍ĕ\��
'    showHead

'    '�w�b�_�������c�z�̑ޔ�
'    kesizan = txt_kesizan.Text
'
'    With spd_body
'        For idxRow = 1 To intMaxRow
'            '�`�F�b�N�������Ă��邩���m�F
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'            '�`�F�b�N�������Ă���ꍇ
'            If intchk = 1 Then
'                '�����z�̎擾
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
''����Ŋz���ݎ��s��
'Private Sub cmd_syohi_Click()
'
'
'    Dim tmp             As Variant
'    Dim intchk          As Long
'    Dim idxRow          As Long
'    Dim idxRowJDNNO     As Long
'
'    Dim kesizan         As Currency '�w�b�_�������c�z
'    Dim kesikn          As Currency '���׍s�̓����ϊz
'
'
'    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
'    If blnUsableButton = False Then Exit Sub
'
'    '�����z������ʂ̕\��
'    FR_SSSSUB.Show (vbModal)
'
'
'    '�w�b�_���̍ĕ\��
'    showHead
'
'    '�w�b�_�������c�z�̑ޔ�
'    kesizan = txt_kesizan.Text
'
'    With spd_body
'        For idxRow = 1 To intMaxRow
'            '�`�F�b�N�������Ă��邩���m�F
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'            '�`�F�b�N�������Ă���ꍇ
'            If intchk = 1 Then
'                '�����z�̎擾
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


'�S�������ݎ��s��
Private Sub cmd_zenkesi_Click()
    Dim i As Integer
    Dim varKesikn As Variant

    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
    If blnUsableButton = False Then Exit Sub
    

'�S�����{�^�����������́A�����\�����Ɠ��������ΏۂɃ`�F�b�N������B
'�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
'    lockHenpin


    '�S�s�ɑ΂��A�����ޯ��������
    For i = 1 To intMaxRow
        With spd_body
            .Col = COL_CHK
            .Row = i
            If .Value = 0 Then
                '�S�������Ƀ`�F�b�N������Ȃ��s����C�� 2007/02/28 Saito
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

'�S�������ݎ��s��
Private Sub cmd_zenkaijo_Click()
    Dim i As Integer
    Dim varKesikn As Variant
    Dim varBfKesikn As Variant

    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
    If blnUsableButton = False Then Exit Sub

    '�S�s�ɑ΂��A�����ޯ���̉���
    For i = 1 To intMaxRow
        With spd_body
            .Col = COL_CHK
            .Row = i
            If .Value = 1 Then
                '�������Ƀ`�F�b�N���O��Ȃ��s����C�� 2007/02/28 Saito
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

'�ĕ\�����ݎ��s��
Private Sub cmd_saihyoji_Click()
    '�׸ނ������Ă��Ȃ���Ύ��s���Ȃ�
    If blnUsableButton = False Then Exit Sub


    If ChkInputChange() = True Then
        If showMsg("1", "URKET73_040", 0) = vbNo Then
            Exit Sub
        End If
    End If

    
    '�w�b�_�����͂���Ă�����f�[�^�������E�\������
    If chkCondition = True Then

        intInputMode = 2

        showBody    '���ް��\��
               
        '�O��ł́A�����`�F�b�N�@�\���g�p���Ȃ��B(�L���ɂ���ꍇ�̓R�����g���O���Ă�������)
        '�ԕi���������A���b�N
        'lockHenpin

    End If

End Sub

'���������ݸد���
Private Sub cmd_kesidt_Click()
    If txt_kesidt.Enabled = False Then Exit Sub

    If Trim(txt_kesidt.Text) <> "" Then
        Set_date = txt_kesidt.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    '�J�����_�[�E�B���h�E��\��
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kesidt.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kesidt.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '�����t�̓��̓`�F�b�N
        txt_tokseicd.SetFocus
    End If
End Sub

'�����溰�����ݸد���
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

'��������ݸد���
Private Sub cmd_kaidt_From_Click()
    
    If txt_kaidt_From.Enabled = False Then Exit Sub

    If Trim(txt_kaidt_From.Text) <> "" Then
        Set_date = txt_kaidt_From.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    '�J�����_�[�E�B���h�E��\��
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kaidt_From.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kaidt_From.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '�����t�̓��̓`�F�b�N
        txt_kaidt_To.SetFocus
    End If

End Sub


'��������ݸد���
Private Sub cmd_kaidt_To_Click()
    If txt_kaidt_To.Enabled = False Then Exit Sub

    If Trim(txt_kaidt_To.Text) <> "" Then
        Set_date = txt_kaidt_To.Text
    Else
        Set_date = CNV_DATE(gstrUnydt)
    End If

    WLSDATE_RTNCODE = ""

    '�J�����_�[�E�B���h�E��\��
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_kaidt_To.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_kaidt_To.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '�����t�̓��̓`�F�b�N
        txt_kesikb.SetFocus
    End If
End Sub


'�U���������ݸد���
Private Sub cmd_fridt_Click()
    '�U�����������͂ł��Ȃ����Ͳ���Ă͎��s���Ȃ�
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

    '�J�����_�[�E�B���h�E��\��
    WLS_DATE.Show vbModal
    Unload WLS_DATE

    txt_fridt.SetFocus
    If WLSDATE_RTNCODE <> "" Then
        txt_fridt.Text = WLSDATE_RTNCODE
        intChkKb = 1                   '�����t�̓��̓`�F�b�N
        spd_body.SetFocus
    End If
End Sub

'**** 2009/09/19 ADD START FKS)NAKATA
'���[�Ή�
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
            
            '�ԕi�t���O�̎擾
            Call .GetText(COL_HENPI, idxRow, tmp)
            strHenpin = CStr(tmp)
            
            
            '�ԕi�ł���΁A���z�������s��
            If strHenpin = "1" Then

                '�󒍔ԍ��̎擾
                Call .GetText(COL_JDNNO, idxRow, tmp)
                strJdnno = CStr(tmp)
                
                '�󒍍s�ԍ��̎擾
                Call .GetText(COL_JDNLINNO, idxRow, tmp)
                strJdnlinno = CStr(tmp)

                '�ō�������z�̎擾
                Call .GetText(COL_KOMIKN, idxRow, tmp)
                curKomikn = CCur(tmp)
                
                '����󇂂̎擾
                strOkrjono = getOKRJONO(strJdnno, strJdnlinno)


                For i = 0 To UBound(ARY_NYUKN_KS)
                
                    '�󒍔ԍ�
                    If ARY_NYUKN_KS(i).OKRJONO = strOkrjono Then
                        maxSeq = i
                    End If
                    
                Next i

                '�ԕi�̋��z���c���։��Z����
                ARY_NYUKN_KS(maxSeq).ZANKN = ARY_NYUKN_KS(maxSeq).ZANKN + curKomikn * (-1)
            
            End If
    
        Next idxRow
        
    End With
    
End Sub
'**** 2009/09/19 ADD E.N.D FKS)NAKATA


'�ԕi����
Private Sub lockHenpin()
    Dim intKesizan      As Currency  '�w�b�_�������c�z
    Dim intKomikn       As Currency  '�ō�����z
    Dim intKesikn       As Currency  '�����z
    Dim intBfKesikn     As Currency  '�����z(�����O)
    Dim tmp             As Variant
    Dim LS_HYFRIDT      As Variant
    Dim idxRow          As Long
    Dim idxRowJDNNO     As Long
    Dim strFRIDT        As String
    Dim strHyjdnno      As String
    Dim str_theHYJDNNO  As String
    Dim intchk          As Integer

    On Error Resume Next
    '�U���������擾

    strFRIDT = txt_fridt.Text
    '�����c�z���擾

    intKesizan = SSSVal(txt_kesizan.Text)
    '�ԕi������

    With spd_body

        For idxRow = 1 To intMaxRow
            '�ō�����z���擾

            Call .GetText(COL_KOMIKN, idxRow, tmp)
            intKomikn = SSSVal(tmp)
            '�����ϊz���擾

            Call .GetText(COL_KESIKN, idxRow, tmp)
            intKesikn = SSSVal(tmp)
            '�����ȑO�����z


            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
            intBfKesikn = SSSVal(tmp)

            
            '�����z���}�C�i�X�ł���Γ���󒍔ԍ��ő��E
            If intKomikn - intKesikn < 0 Then
                
                '�����z�������c�z�֒ǉ�
                intKesizan = intKesizan - (intKomikn - intKesikn)
                
                '�����ϊz�ݒ�
                .SetText COL_KESIKN, idxRow, intKomikn
                
                '�`�F�b�N�{�b�N�X�ݒ�
                blnUsableSpread = False
                .Row = idxRow
                .Col = COL_CHK
                .Value = 1
                blnUsableSpread = True
                

                Call .SetText(COL_HENPI, idxRow, "1")

                
                '�󒍔ԍ��擾
                Call .GetText(COL_HYJDNNO, idxRow, tmp)
                strHyjdnno = CStr(tmp)
                
                '����󒍔ԍ�������
                For idxRowJDNNO = intMaxRow To 1 Step -1
                    .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                    str_theHYJDNNO = CStr(tmp)
                    
                    '�󒍔ԍ���v����Α��E
                    If strHyjdnno <> str_theHYJDNNO Then
                    Else
                        .GetText COL_CHK, idxRowJDNNO, tmp
                        intchk = SSSVal(tmp)
                        
                        '�������g�łȂ��A�܂��̓`�F�b�N����Ă��Ȃ�
                        If idxRowJDNNO <> idxRow And intchk = 1 Then
                        Else
                            
                            '�ō�����z���擾
                            Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
                            intKomikn = SSSVal(tmp)
                            
                            '�����ϊz���擾
                            Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
                            intKesikn = SSSVal(tmp)
                            
                            '�����ȑO�����z

                            Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                            intBfKesikn = SSSVal(tmp)
                            
                            '�ō�������z�S�z���E
                            If intKesizan >= intKomikn - intKesikn Then
                                
                                '�����ϊz�ݒ�
                                .SetText COL_KESIKN, idxRowJDNNO, intKomikn
                                
                                '�`�F�b�N�{�b�N�X�ݒ�
                                blnUsableSpread = False
                                .Row = idxRowJDNNO
                                .Col = COL_CHK
                                .Value = 1
                                blnUsableSpread = True
                                
                                Call .SetText(COL_HENPI, idxRowJDNNO, "1")

                                '�����c�z�ݒ�
                                intKesizan = intKesizan - (intKomikn - intKesikn)
                                
                                '�U�������ݒ�
                                If DB_TOKMTA.SHAKB Like "[256]" Then
                                    .GetText COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT
                                    If Trim$(LS_HYFRIDT) = "" Then
                                        .SetText COL_HYFRIDT, idxRowJDNNO, strFRIDT
                                    End If
                                End If
                                '�ō�������z�ꕔ���E
                                '�����ϊz�ݒ�

                            Else

                                .SetText COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan
                                '�`�F�b�N�{�b�N�X�ݒ�


                           ''�����c�z���[���̏ꍇ�A�`�F�b�N�����Ȃ�
                            If intKesizan > 0 Then

                           
                                blnUsableSpread = False
                                .Row = idxRowJDNNO
                                .Col = COL_CHK
                                .Value = 1
                                blnUsableSpread = True
                           

                                Call .SetText(COL_HENPI, idxRowJDNNO, "1")

                        
                            End If
                                                           
                                '�����c�z�[��
                                intKesizan = 0
                                
                                '�U�������ݒ�
                                If DB_TOKMTA.SHAKB Like "[256]" Then
                                    .GetText COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT
                                    If Trim$(LS_HYFRIDT) = "" Then
                                        .SetText COL_HYFRIDT, idxRowJDNNO, strFRIDT
                                        '�����c�z��ݒ�

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
'   ���́F Function chk_HENPIN
'   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
'          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
'   �����F strJdnNo   : �󒍓`�[�ԍ�
'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
'       :  strUrikn   : ������z
'   �ߒl�F �`�F�b�N����
'   ���l�F
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
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    '�f�[�^�����݂����ꍇ
    Do While CF_Ora_EOF(Usr_Ody) = False
                   
        '��������Ă��Ȃ��ꍇ�A�������s��
        If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
                 
            '�ԕi���R�ɒl���i�[����Ă��锄���ΏۂƂ���
            If Trim$(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then
                
                
                '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
                If CLng(strUrikn) = CLng(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
                    chkHenpin = False
                    GoTo END_chkHENPIN
                Else


                '�ԕi�o�^���s�����󒍂ɑ΂��P���������s�����ꍇ�A���P���Ƃ��̎��̕ԕi���R�[�h���o�͂��Ȃ��悤�C��
                
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

                    'DB�A�N�Z�X
                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)

                    '�f�[�^�����݂����ꍇ
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
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHENPIN:
    GoTo END_chkHENPIN

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F Function chkHenpinTeisei
'   �T�v�F �������܂����ŕԕi�o�^�A�󒍒������s������
'          �ԍ��ɂđ��E�����󒍂�\�����Ȃ�
'   �����F strJdnNo   : �󒍓`�[�ԍ�
'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
'   �@�@�F strUrikn   : ������z
'   �@�@�F strUdnno   : ����`�[�ԍ�
'   �@�@�F strLinno   : �s�ԍ�
'   �@�@�F strUriDt   : �����
'   �ߒl�F �`�F�b�N����
'   ���l�F
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


    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
    
    '�f�[�^�����݂����ꍇ
    Do While CF_Ora_EOF(Usr_Ody) = False
    
        '��������Ă��Ȃ��ꍇ�A�������s��
        If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
                                
            '���ƐԂ�URIKN�̍��z���u0�v�ɂȂ�̂Ȃ�\�����Ȃ�
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
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHenpinTeisei:
    GoTo END_chkHenpinTeisei

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F Sub chkAkaKro
'   �T�v�F �ꕔ�ԕi�����݂��锄�����������ہA�Ԃƍ�������o��
'�@�@�@�@  �Ԃ̂ݏ��������ꍇ�́A�G���[���b�Z�[�W���o���B
'          ���̂ݏ��������ꍇ�́A�Ԃ̑��݂����邱�Ƃ����b�Z�[�W����B
'
'   ���l�F 2008/08/13 ���[���ꂽ����ɑ΂��Ă̐ԍ��`�F�b�N�̒ǉ��E�C��
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkAkaKro()

    Dim intKesizan      As Currency  '�w�b�_�������c�z
    Dim intKomikn       As Currency  '�ō�����z
    Dim intKesikn       As Currency  '�����z
    Dim intBfKesikn     As Currency  '�����z(�����O)
    Dim intAfKesikn     As Currency

    Dim intUrikn        As Currency  '������z
    Dim wkKesikn        As Currency  '�ԍ��`�F�b�N�p���������[�N�ϐ�
    Dim sumKesikn       As Currency  '�ԍ��`�F�b�N�p�������ϐ�
    Dim Cnt             As Integer   '�ԍ��`�F�b�N�p�J�E���g�ϐ�
    Dim i               As Integer   '�ԍ��`�F�b�N�p
    Dim wkRow           As Long      '�ԍ��`�F�b�N�p�s�ԍ�

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
    
    '�ԕi������
    With spd_body
        For idxRow = 1 To intMaxRow
            
            '�`�F�b�N�������Ă��邩���m�F
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)

            
            '�`�F�b�N�������Ă���ꍇ
            If intchk = 1 Then

                ''�ԍ��`�F�b�N�z��̏�����
                ReDim Preserve AKAKRO_CHK(0)
                Cnt = 1
             
                '��ʓ��͒l�̏������ȍ~�̓��t����Ă���ꍇ�G���[�Ƃ���B
                '������̎擾
                Call .GetText(COL_UDNDT, idxRow, tmp)
                strUDNDT = CStr(tmp)
                
                If strUDNDT > DeCNV_DATE(Trim$(txt_kesidt.Text)) Then
                    MsgBox ("���͂��ꂽ�������ȍ~�̔��オ���݂��܂��B")
                    chkAkaKro = False
                    Exit Function
                End If
                
                '�����ϊz(�����O)
                Call .GetText(COL_BFKESIKN, idxRow, tmp)
                intBfKesikn = SSSVal(tmp)
                
                '�����ϊz(������)
                Call .GetText(COL_AFKESIKN, idxRow, tmp)
                intAfKesikn = SSSVal(tmp)
                
                
                '�����ϊz���擾
                Call .GetText(COL_KESIKN, idxRow, tmp)
                intKesikn = SSSVal(tmp)
                
                '�ȑO�ɏ�������Ă�����̈ȊO
                If intBfKesikn + intAfKesikn = 0 Then
                                
                    '�����z���}�C�i�X�ł���Γ���󒍔ԍ��̍�������
                    If intKesikn < 0 Then
                                               
                        '�󒍔ԍ��擾
                        Call .GetText(COL_HYJDNNO, idxRow, tmp)
                        strHyjdnno = CStr(tmp)
                        

                       '�Ԃ̃f�[�^��z��Ɋi�[
                        AKAKRO_CHK(0).idx = idxRow
                        AKAKRO_CHK(0).CHKMK = intchk
                        AKAKRO_CHK(0).UDNDT = strUDNDT
                        AKAKRO_CHK(0).JDNNO = strHyjdnno
                        AKAKRO_CHK(0).KESIKN = intKesikn

                                
                        '����󒍔ԍ�������
                        For idxRowJDNNO = intMaxRow To 1 Step -1
                            .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                            str_theHYJDNNO = CStr(tmp)
                            
                            '�󒍔ԍ���v����Α��E
                            If strHyjdnno <> str_theHYJDNNO Then
                            Else
                                .GetText COL_CHK, idxRowJDNNO, tmp
                                intchk = SSSVal(tmp)
                                
                            
                             
                                If idxRowJDNNO <> idxRow Then
                               
                                   ''����󒍔ԍ��̍��̏������z���擾
                                    .GetText COL_KESIKN, idxRowJDNNO, tmp
                                    wkKesikn = SSSVal(tmp)
                                    
                                    
                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                     strUDNDT = CStr(tmp)
                                   
                                   ''����󒍔ԍ��̍���z��Ɋi�[
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
                        
                        
                        ''�ԕi�̐ԍ��`�F�b�N
                        '�T�}���̏�����
                        sumKesikn = AKAKRO_CHK(0).KESIKN
                        
                        For i = 1 To Cnt - 1
                        
                            '�`�F�b�N�������Ă��Ȃ��ꍇ
                            If AKAKRO_CHK(i).CHKMK = 0 Then
                                
                                wkRow = AKAKRO_CHK(i).idx
                                strUDNDT = AKAKRO_CHK(i).UDNDT
                            
                            '�����Ă���ꍇ
                            Else
                                '�Ԃ̃}�C�i�X�̏������ȏ�ɍ��̏���������Ă���
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
                        
                        '�T�}�����}�C�i�X�ɂȂ��Ă���ꍇ�̓G���[���b�Z�[�W��\��
                        If Cnt - 1 >= 1 And sumKesikn < 0 Then
                            MsgBox ("�[�����K�v�Ȕ��オ����܂��B" & vbCrLf & vbCrLf _
                                        & "�sNo:" & vbTab & wkRow & vbCrLf _
                                        & "�����: " & vbTab & strUDNDT & vbCrLf _
                                        & "�󒍔ԍ�: " & vbTab & strHyjdnno)
                            chkAkaKro = False
                            Exit Function
                        End If

                    Else
                    '���f�[�^����̌���
                    
                        '�󒍔ԍ��擾
                        Call .GetText(COL_HYJDNNO, idxRow, tmp)
                        strHyjdnno = CStr(tmp)
                        
                        '����󒍔ԍ�������
                        For idxRowJDNNO = intMaxRow To 1 Step -1
                            .GetText COL_HYJDNNO, idxRowJDNNO, tmp
                            str_theHYJDNNO = CStr(tmp)
                            
                            '�󒍔ԍ���v����Α��E
                            If strHyjdnno <> str_theHYJDNNO Then
                            Else
                                
                                '�`�F�b�N
                                .GetText COL_CHK, idxRowJDNNO, tmp
                                intchk = SSSVal(tmp)
                        
                                '������z
                                .GetText COL_URIKN, idxRowJDNNO, tmp
                                intUrikn = SSSVal(tmp)
                        
                        
                    
                                ''���[����Ă��鍕�f�[�^�����o���Ȃ��悤�C��
                                '�������g�łȂ��A���`�F�b�N����Ă��Ȃ��A�����f�[�^�łȂ�
                                If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
                        
                        
                                    .GetText COL_UDNDT, idxRowJDNNO, tmp
                                    strUDNDT = CStr(tmp)
                                
                                    If MsgBox("�[�����K�v�Ȕ��オ����܂��B" & vbCrLf _
                                                & "�X�V���܂����H" & vbCrLf & vbCrLf _
                                                & "�sNo:" & vbTab & idxRowJDNNO & vbCrLf _
                                                & "�����: " & vbTab & strUDNDT & vbCrLf _
                                                & "�󒍔ԍ�: " & vbTab & strHyjdnno, vbOKCancel) = vbOK Then
                                    
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
''   ���́F Function chkNyukn
''   �T�v�F ��������Ă��邩�̃`�F�b�N
''   ���l�F
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

    Dim strJdnno        As String    '�󒍔ԍ�
    Dim strJdnlinno     As String    '�󒍍s�ԍ�
    Dim strHyjdnno      As String
    Dim strOkrjono      As String    '�����
    Dim curKesikn       As Currency
    Dim curKesiknMae    As Currency

    
    On Error GoTo ERR_chkNYUKN

    chkNyukn = True



    With spd_body
        For idxRow = 1 To intMaxRow

            '�`�F�b�N�������Ă��邩���m�F
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)


            '�`�F�b�N�������Ă���ꍇ
            If intchk = 1 Then

                BlnFlg = False
'*** 2009/10/09 ADD START FKS)NAKATA
                BlnFlgDay = False
'*** 2009/10/09 ADD E.N.D FKS)NAKATA


                '�󒍔ԍ����擾
                Call .GetText(COL_JDNNO, idxRow, tmp)
                strJdnno = CStr(tmp)

                '�󒍍s�ԍ����擾
                Call .GetText(COL_JDNLINNO, idxRow, tmp)
                strJdnlinno = CStr(tmp)

                '�\���p�󒍔ԍ����擾
                Call .GetText(COL_HYJDNNO, idxRow, tmp)
                strHyjdnno = CStr(tmp)

                '����󇂂̎擾
                strOkrjono = getOKRJONO(strJdnno, strJdnlinno)

                '�����z
                Call .GetText(COL_KESIKN, idxRow, tmp)
                curKesikn = SSSVal(tmp)

                '�����z
                Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
                curKesiknMae = SSSVal(tmp)
                

                If Abs(curKesikn) > Abs(curKesiknMae) Then

                        For i = 0 To UBound(ARY_NYUKN_KS)
                            
                            '��������Ă��邩�̊m�F
                            If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
                                
                                BlnFlg = True
                                
                                '�������Ə[�����̃`�F�b�N
                                If ARY_NYUKN_KS(i).UDNDT <= gstrKesidt Then
                                    BlnFlgDay = True
                                Else
                                    Exit For
                                End If
                                    
                                Exit For
                            
                            End If
                        Next i
        
                        
                        '�������s���Ă��Ȃ��ꍇ�A�G���[�Ƃ���B
                        If BlnFlg = False Then
                            If MsgBox("�������o�^����Ă��܂���B" & vbCrLf & vbCrLf _
                                        & "�sNo:" & vbTab & idxRow & vbCrLf _
                                        & "�󒍔ԍ�: " & vbTab & strHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
                                chkNyukn = False
                                GoTo END_chkNyukn
                            End If
                        End If
                 
'*** 2009/10/09 ADD START FKS)NAKATA
                        '�[���������������ȑO�̏ꍇ�A�G���[�Ƃ���B
                        If BlnFlgDay = False Then
                            If MsgBox("�������ȑO�ł͏[���ł��܂���B" & vbCrLf & vbCrLf _
                                        & "�sNo:" & vbTab & idxRow & vbCrLf _
                                        & "�󒍔ԍ�: " & vbTab & strHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
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
''   ���́F Function chkURIKN
''   �T�v�F ������z�Ə[�����z�̃`�F�b�N
''   ���l�F
'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'Private Function chkUrikn()
'
'    Dim tmp             As Variant
'    Dim idxRow          As Long
'    Dim intchk          As Integer
'
'    Dim strJdnno        As String    '�󒍔ԍ�
'    Dim strJdnlinno     As String    '�󒍍s�ԍ�
'    Dim strHyjdnno      As String    '�\���p�󒍔ԍ�
'    Dim strOkrjono      As String    '�����
'    Dim strJdntrkb      As String    '�󒍎���敪
'
'    Dim curBfKesikn     As Currency  '�����z(�����O)
'    Dim curAfKesikn     As Currency  '�����z(������)
'
'    Dim curNYUKN        As Currency  '�������R�[�h�����z
'    Dim curUrikn        As Currency  '���ヌ�R�[�h������z + �ŋ�
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
'    '�ԕi������
'    With spd_body
'        For idxRow = 1 To intMaxRow
'
'            '�`�F�b�N�������Ă��邩���m�F
'            .GetText COL_CHK, idxRow, tmp
'            intchk = SSSVal(tmp)
'
'
'            '�`�F�b�N�������Ă���ꍇ
'            If intchk = 1 Then
'
'
'                '�󒍔ԍ����擾
'                Call .GetText(COL_JDNNO, idxRow, tmp)
'                strJdnno = CStr(tmp)
'
'
'                '�󒍍s�ԍ����擾
'                Call .GetText(COL_JDNLINNO, idxRow, tmp)
'                strJdnlinno = CStr(tmp)
'
'
'                '�\���p�󒍔ԍ����擾
'                Call .GetText(COL_HYJDNNO, idxRow, tmp)
'                strHyjdnno = CStr(tmp)
'
'
'                '�����ϊz(�����O)
'                Call .GetText(COL_BFKESIKN, idxRow, tmp)
'                curBfKesikn = SSSVal(tmp)
'
'
'                '�����ϊz(������)
'                Call .GetText(COL_AFKESIKN, idxRow, tmp)
'                curAfKesikn = SSSVal(tmp)
'
'
'                    '�ȑO�ɏ�������Ă�����̈ȊO��ΏۂƂ���
'                    If curBfKesikn + curAfKesikn = 0 Then
'
'
'                            ''�󒍔ԍ����󒍎���敪���擾����B
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
'                            'DB�A�N�Z�X
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '�󒍎���敪
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
'
'
'
'                            ''�󒍔ԍ��E�s�ԍ���蔄����z���擾����
'                            strSql = ""
'                            strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
'                            strSql = strSql & "  FROM UDNTRA"
'                            strSql = strSql & " WHERE JDNNO     = '" & strJdnno & "'"
'
'                            '�Z�b�g�A�b�v�E�V�X�e���ȊO�̎󒍂͖��׍s�S�̂ŋ��z���T�}������B
'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
'                            Else
'                                strSql = strSql & "   AND JDNLINNO  = '" & strJdnlinno & "'"
'                            End If
'
'                            strSql = strSql & "   AND IRISU     <> 9"
'                            strSql = strSql & "   AND DATKB     = '1'"
'
'
'                            'DB�A�N�Z�X
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '������z
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
'
'
'
'                            '�󒍔ԍ� + �s�ԍ����u����󇂁v�֕ύX
'                            '�Z�b�g�A�b�v�E�V�X�e���́A�s�ԍ����u001�v�Œ�
'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
'                                strOkrjono = Trim$(strJdnno) & "001"
'                            Else
'                                strOkrjono = Trim$(strJdnno) & Trim$(strJdnlinno)
'                            End If
'
'
'
'                            ''�������R�[�h�������z���擾����B
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
'                            'DB�A�N�Z�X
'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                            If CF_Ora_EOF(Usr_Ody) = False Then
'                                curNYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")) '������z
'                            End If
'
'                            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
'
'
'                            '������z�Ɠ����z����v���Ă��Ȃ��ꍇ�A�G���[
'                            If curUrikn <> curNYUKN Then
'                                If MsgBox("������z�Ɠ����z���قȂ�܂��B" & vbCrLf & vbCrLf _
'                                            & "�sNo:" & vbTab & idxRow & vbCrLf _
'                                            & "�󒍔ԍ�: " & vbTab & strHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
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
'    '�N���[�Y
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
''   ���́F Function chkJdntrkb
''   �T�v�F �`�[�P�ʂł̏[���`�F�b�N
''   ���l�F
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
'    '�X�v���b�h�i�[�ϐ�
'    Dim strJdnno        As String    '�󒍔ԍ�
'    Dim strJdnlinno     As String    '�󒍍s�ԍ�
'    Dim strHyjdnno      As String    '�\���p�󒍔ԍ�
'    Dim curKomikn       As Currency  '������z�{�ŋ�
'
'    '�󒍎���敪
'    Dim strOkrjono      As String    '�����
'    Dim strJdntrkb      As String    '�󒍎���敪
'
'
'    '�`�F�b�N�p�ϐ�
'    Dim wkIdx           As Integer
'    Dim wkJdnno         As String
'    Dim wkHyjdnno       As String
'    Dim wkKomikn        As Currency
'    Dim curUrikn        As Currency  '���ヌ�R�[�h������z + �ŋ�
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
'    '�z��̏�����
'    ReDim Preserve JDNTRKB_CHK(0)
'    Cnt = 0
'
'
'        With spd_body
'            For idxRow = 1 To intMaxRow
'
'                '�`�F�b�N�������Ă��邩���m�F
'                .GetText COL_CHK, idxRow, tmp
'                intchk = SSSVal(tmp)
'
'
'                '�`�F�b�N�������Ă���ꍇ
'                If intchk = 1 Then
'
'
'                    '�󒍔ԍ����擾
'                    Call .GetText(COL_JDNNO, idxRow, tmp)
'                    strJdnno = CStr(tmp)
'
'
'                    '�󒍍s�ԍ����擾
'                    Call .GetText(COL_JDNLINNO, idxRow, tmp)
'                    strJdnlinno = CStr(tmp)
'
'
'                    '�\���p�󒍔ԍ����擾
'                    Call .GetText(COL_HYJDNNO, idxRow, tmp)
'                    strHyjdnno = CStr(tmp)
'
'
'                    '�ō�������z���擾
'                    Call .GetText(COL_KOMIKN, idxRow, tmp)
'                    curKomikn = CCur(tmp)
'
'
'                    '�󒍔ԍ����󒍎���敪���擾����B
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
'                    'DB�A�N�Z�X
'                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                    If CF_Ora_EOF(Usr_Ody) = False Then
'                        strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '�󒍎���敪
'                    End If
'
'                    Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
'
'
'                    '�󒍎���敪���Z�b�g�A�b�v�ƃV�X�e���̎��̂ݔz��Ɋi�[����
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
'        '�z��1�Ԗڂ̎󒍔ԍ����J�n�_�Ƃ��ăZ�b�g
'        wkIdx = JDNTRKB_CHK(0).idx
'        wkJdnno = JDNTRKB_CHK(0).JDNNO
'        wkHyjdnno = JDNTRKB_CHK(0).HYJDNNO
'
'            For i = 0 To UBound(JDNTRKB_CHK)
'
'
'            If wkJdnno = JDNTRKB_CHK(i).JDNNO Then
'
'                '�󒍔ԍ��������ꍇ�́A�ō�������z�����Z����B
'                wkIdx = JDNTRKB_CHK(i).idx
'                wkHyjdnno = JDNTRKB_CHK(i).HYJDNNO
'                wkKomikn = wkKomikn + JDNTRKB_CHK(i).KOMIKN
'
'            Else
'
'                ''�󒍔ԍ��E�s�ԍ���蔄����z���擾����
'                strSql = ""
'                strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
'                strSql = strSql & "  FROM UDNTRA"
'                strSql = strSql & " WHERE JDNNO     = '" & wkJdnno & "'"
'                strSql = strSql & "   AND IRISU     <> 9"
'                strSql = strSql & "   AND DATKB     = '1'"
'
'
'                'DB�A�N�Z�X
'                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
'
'                If CF_Ora_EOF(Usr_Ody) = False Then
'                    curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '������z
'                End If
'
'                Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
'
'
'                '�擾����������z�Ɖ�ʂŃ`�F�b�N����Ă��锄����z���r����B
'                If wkKomikn <> curUrikn Then
'
'                    If MsgBox("�`�[�P�ʂŏ[��/�[���������s���Ă��������B" & vbCrLf & vbCrLf _
'                                & "�sNo:" & vbTab & wkIdx & vbCrLf _
'                                & "�󒍔ԍ�: " & vbTab & wkHyjdnno, vbOKOnly, "�O��[���߂�����") = vbOK Then
'                        chkJdntrkb = False
'                        GoTo END_chkJdntrkb
'                    End If
'
'                End If
'
'                '�󒍔ԍ����Z�b�g
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
'    '�N���[�Y
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
    '   ���́F  Sub ChkInputChange
    '   �T�v�F  ���ׂ̓��͓��e�̕ύX�m�F
    '   �����F  ����
    '   �ߒl�F�@True:�ύX�L��  False:�ύX����
    '   ���l�F
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
    '   ���́F  Function Get_NKSTRA_HAITA_INF
    '   �T�v�F  ���������g�����̔r�����擾
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
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
    
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

        Do While CF_Ora_EOF(Usr_Ody) = False
            
            '����f�[�^�����݂��邩�m�F���A���Ȃ��ꍇ�͎���������Ă��Ȃ��̂ŁA���������R�[�h���������{����
            strSql = ""
            strSql = strSql & "SELECT " & vbCrLf
            strSql = strSql & "       KDNNO " & vbCrLf
            strSql = strSql & "FROM " & vbCrLf
            strSql = strSql & "       NKSTRA " & vbCrLf
            strSql = strSql & "WHERE " & vbCrLf
            strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf

            'DB�A�N�Z�X
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
            
            Call CF_Ora_CloseDyn(Usr_Ody_1)   '�ް���ĸ۰��
            Usr_Ody.Obj_Ody.MoveNext
        Loop
        Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
    Next i
        
    Get_NKSTRA_HAITA_INF = True

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Get_NKSTRA_TEGDT
    '   �T�v�F  ���������g�����̊����U�����̎擾
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
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
    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
    If Not CF_Ora_EOF(Usr_Ody) Then
        strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    End If
        
    Get_NKSTRA_TEGDT = strTEGDT

End Function
'*** 2009/09/03 ADD START FKS)NAKATA V1.03
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Get_NYUKN_TEGDT
    '   �T�v�F  ����g����.�������R�[�h�̊����U�����̎擾
    '   �����F  ����
    '   �ߒl�F�@True:����  False:�ُ�
    '   ���l�F
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


    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
    If Not CF_Ora_EOF(Usr_Ody) Then
        strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
    End If
        
    Get_NYUKN_TEGDT = strTEGDT

End Function
'*** 2009/09/03 ADD E.N.D FKS)NAKATA V1.03

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkCondition
'   �T�v�F  �w�b�_���̓��̓`�F�b�N
'   �����F  ����
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkCondition() As Boolean
    chkCondition = False
    
    '�`�F�b�N�F������
    With txt_kesidt
        If Trim(.Text) = "" Then
            '�K�{���̓`�F�b�N
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            '�`�F�b�N����
            If chkKesidt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                '�G���[
                Call .SetFocus
                Exit Function
            End If
        End If
    End With
    
    '�`�F�b�N�F������R�[�h
    With txt_tokseicd
        If Trim(.Text) = "" Then
            '�K�{���̓`�F�b�N
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            '�`�F�b�N����
            If chkTokseicd(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                '�G���[
                Call .SetFocus
                Exit Function
            End If
        End If
    End With
    
    '�`�F�b�N�F�����(�J�n)
    With txt_kaidt_From
        If Trim(.Text) = "" Then
            If Trim(txt_kesikb.Text) = "9" Then
                '�K�{���̓`�F�b�N
                Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
                .ForeColor = vbRed
                .SetFocus
                Exit Function
            End If
        Else
            intChkKb = 1
            If chkKaidt_From(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                '�G���[
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    '�`�F�b�N�F�����(�I��)
    With txt_kaidt_To
        If Trim(.Text) = "" Then
            '�K�{���̓`�F�b�N
            Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG
            .ForeColor = vbRed
            .SetFocus
            Exit Function
        Else
            intChkKb = 1
            '�`�F�b�N����
            If chkKaidt_To(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                '�G���[
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    With txt_fridt
        If Trim(.Text) = "" Then
            If blnFriEnabled = True Then
                '�K�{���̓`�F�b�N
                Call showMsg("0", "_HEADCOMPLETEC", "0")    '�����o�����ʹװMSG

                .Enabled = True

                .ForeColor = vbRed
                .SetFocus
                Exit Function
            End If
        Else
            intChkKb = 1
            '�`�F�b�N����
            If chkFridt(True) = False Then '�`�F�b�N�����������I�ɑ��点��
                '�G���[
                .SetFocus
                Exit Function
            End If
        End If
    End With
    
    chkCondition = True
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkKesidt
'   �T�v�F  �������t�̃`�F�b�N
'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKesidt = False

    With txt_kesidt
        If pin_blnChk = False Then
            '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
            If intChkKb <> 1 Then
                chkKesidt = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKesidt) Then
                chkKesidt = True
                GoTo END_STEP
            End If
        End If

        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
        If Trim(.Text) = "" Then
            chkKesidt = True
            Exit Function
        End If

        '���t�`���̃`�F�b�N
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '�����t����MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If


'2009/09/03 ADD START RISE)MIYAJIMA
        '�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
        If Trim(txt_tokseicd) <> "" Then
            If DeCNV_DATE(.Text) <= DB_TOKMTA.TOKSMEDT Then
                Call showMsg("2", "URKET73_042", 0)     '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If
'2009/09/03 ADD E.N.D RISE)MIYAJIMA


        '�o�������ȑO�̓��t�̎��̓G���[
        If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
        'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
            Call showMsg("1", "URKET73_010", 0)     '���o�����ߍς݂�MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '�^�p��������t�̎��̓G���[
        If DeCNV_DATE(.Text) > gstrUnydt Then
            Call showMsg("2", "DATE_1", 3)          '���^�p������t�G���[
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '���߂��ׂ��ł̓��t�̓G���[
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        .ForeColor = vbBlack
    End With

    chkKesidt = True

END_STEP:

    gstrKesidt = DeCNV_DATE(txt_kesidt.Text)
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkTokseicd
'   �T�v�F  �����溰�ނ̃`�F�b�N
'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean


'2009/09/07 ADD START FKS)NAKATA
    Dim strTANCLAKB         As String
'2009/09/07 ADD E.N.D FKS)NAKATA


    chkTokseicd = False

    With txt_tokseicd
        If pin_blnChk = False Then
            '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
            If intChkKb <> 1 Then
                chkTokseicd = True
                GoTo END_STEP
            End If
            If .Text = gstrTokseicd Then
                chkTokseicd = True
                GoTo END_STEP
            End If
        End If

        '�ύX����Ă����獀�ڃN���A
        If .Text <> gstrTokseicd Then
            txt_tokseinma.Text = ""
            txt_fridt.Text = Space(8)
            txt_fridt.Enabled = False
            
            lbl_shakbnm(1).Caption = ""
            lbl_hytokkesdd(1).Caption = ""
            gstrFridt = Space(8)
        End If

        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
        If Trim(.Text) = "" Then
            chkTokseicd = True
            Exit Function
        End If

        blnFriEnabled = False

        '���Ӑ�Ͻ����琿���於�̂��擾
        Select Case getTokseinm(DeCNV_DATE(txt_kesidt.Text), .Text)
            '����������̂Ƃ�
            Case 0:
                .ForeColor = vbBlack
                txt_tokseinma.Text = DB_TOKMTA.TOKRN
                lbl_shakbnm(1).Caption = DB_TOKMTA.SHAKBNM
                lbl_hytokkesdd(1).Caption = DB_TOKMTA.HYTOKKESDD
                

'2009/09/07 ADD START FKS)NAKATA V1.04
                '�������̃`�F�b�N���A�O�񌎎��X�V���s�������łȂ��A�O�񐿋������Ƃ̃`�F�b�N���K�v
                If DeCNV_DATE(txt_kesidt.Text) <= DB_TOKMTA.TOKSMEDT Then
                    Call showMsg("2", "URKET73_042", 0)     '�����������ȑO�ł��B���̓��t�ł͓��͂ł��܂���BMSG
                    txt_kesidt.ForeColor = vbRed
                    txt_kesidt.SetFocus
                    GoTo END_STEP
                End If
'2009/09/07 ADD E.N.D FKS)NAKATA
'2009/09/07 ADD START FKS)NAKATA V1.04
                Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA.TANCD, strTANCLAKB)
                If strTANCLAKB <> "1" Then
                    Call showMsg("2", "URKET73_043", 0)     '��������S���҂��c�Ƃł���܂���B
                    .ForeColor = vbRed
                    GoTo END_STEP
                End If
'2009/09/07 ADD E.N.D FKS)NAKATA



'*** 2009/09/03 CHG START FKS)NAKATA V1.03
'�U�������́A�����g�������͔���g����.�������R�[�h���擾���邽��
''                Call getInputHYFRIDT(DB_TOKMTA.TOKSEICD _
''                                    , Get_Acedt(DeCNV_DATE(txt_kesidt.Text)) _
''                                    , DB_TOKMTA.SHAKB)
''
''                txt_fridt.Enabled = blnFriEnabled
                blnFriEnabled = False
'*** 2009/09/03 CHG E.N.D FKS)NAKATA V1.03
                
                chkTokseicd = True

            '�C�O������̂Ƃ�
            Case 1:
                Call showMsg("1", "URKET73_013", 0)     '�������̓��Ӑ�ł͂���܂���B
                .ForeColor = vbRed
                GoTo END_STEP

            '������łȂ����Ӑ�̂Ƃ�
            Case 8:
                Call showMsg("2", "DONTSELECT", "2")    '��������ł͂Ȃ�
                .ForeColor = vbRed
                GoTo END_STEP

            '�����悪���݂��Ȃ���
            Case 9:
                Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
                .ForeColor = vbRed
                GoTo END_STEP
        End Select

        .ForeColor = vbBlack
    End With

    chkTokseicd = True

END_STEP:

    gstrTokseicd = txt_tokseicd.Text
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkKaidt_From
'   �T�v�F  ����\����t�i�J�n�j�̃`�F�b�N
'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKaidt_From = False

    With txt_kaidt_From
        If pin_blnChk = False Then
            '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
            If intChkKb <> 1 Then
                chkKaidt_From = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKaidt_Fr) Then
                chkKaidt_From = True
                GoTo END_STEP
            End If
        End If

        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
        If Trim(.Text) = "" Then
            gstrKaidt_Fr = ""
            chkKaidt_From = True
            Exit Function
        End If

        '���t�`���̃`�F�b�N
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)                '�����t����MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '���߂��ׂ��ł̓��t�̓G���[
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '����������ʂŎ󒍓�(�����)�������������̓G���[
        If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
            If Format(.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)            '�����t����MSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If

        .ForeColor = vbBlack
    End With

    chkKaidt_From = True

END_STEP:

    gstrKaidt_Fr = DeCNV_DATE(txt_kaidt_From.Text)
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkKaidt_To
'   �T�v�F  ����\����t�i�I���j�̃`�F�b�N
'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    Dim date1 As String
    Dim date2 As String
    Dim date3 As String

    chkKaidt_To = False

    With txt_kaidt_To
        If pin_blnChk = False Then
            '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
            If intChkKb <> 1 Then
                chkKaidt_To = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrKaidt_To) Then
                chkKaidt_To = True
                GoTo END_STEP
            End If
        End If

        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
        If Trim(.Text) = "" Then
            chkKaidt_To = True
            Exit Function
        End If

        '���t�`���̃`�F�b�N
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '�����t����MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '���߂��ׂ��ł̓��t�̓G���[
        date1 = Format(CNV_DATE(Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
        date2 = DateAdd("m", 2, date1)
        date3 = DateAdd("d", -1, date2)
        If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
            Call showMsg("1", "URKET73_038", 0)     '�����߂��ׂ��ł̓��t�͓��͂ł��܂���
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '����������ʂŎ󒍓�(�����)�������������̓G���[
        If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
            If Format(.Text, "0000/00/00") > Format(txt_kesidt.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)            '�����t����MSG
                .ForeColor = vbRed
                GoTo END_STEP
            End If
        End If

        '���t�̑召��r
        If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
            If Format(txt_kaidt_From.Text, "0000/00/00") > Format(.Text, "0000/00/00") Then
                Call showMsg("2", "DATE", 0)     '�����t����MSG
                .ForeColor = vbRed
                txt_kaidt_From.ForeColor = vbRed
                GoTo END_STEP
            Else
                '�`�F�b�N�G���[�Ȃ�
                txt_kaidt_From.ForeColor = vbBlack
            End If
        End If

        .ForeColor = vbBlack
    End With

    chkKaidt_To = True

END_STEP:

    gstrKaidt_To = DeCNV_DATE(txt_kaidt_To.Text)
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function chkFridt
'   �T�v�F  �U�������̃`�F�b�N
'   �����F  pin_blnChk : True=�����I�Ƀ`�F�b�N�����ׂđ��点��
'   �ߒl�F�@True:����  False:�ُ�
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
    chkFridt = False

    With txt_fridt
        If pin_blnChk = False Then
            '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
            If intChkKb <> 1 Then
                chkFridt = True
                GoTo END_STEP
            End If
            If .Text = CNV_DATE(gstrFridt) Then
                chkFridt = True
                GoTo END_STEP
            End If
        End If

        '�󔒓��͎��̓`�F�b�N���Ȃ��ichkCondition�Ń`�F�b�N�j
        If Trim(.Text) = "" Then
            chkFridt = True
            Exit Function
        End If

        '���t�`���̃`�F�b�N
        If IsDate(.Text) = False Then
            Call showMsg("2", "DATE", 0)            '�����t����MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        '�o�������ȑO�̓��t�̎��̓G���[
        If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
        'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '�����{�����̏����P�p
            Call showMsg("1", "URKET73_010", 0)     '���o�����ߍς݂�MSG
            .ForeColor = vbRed
            GoTo END_STEP
        End If

        .ForeColor = vbBlack
    End With

    chkFridt = True

END_STEP:

    gstrFridt = DeCNV_DATE(txt_fridt.Text)
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_Change
    '   �T�v�F  ���t���ړ��t�ϊ�
    '   �����F  pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Ctl_DTItem_Change(pm_objDt As Object)
    
    With pm_objDt
        '�X���b�V�������݂��Ă���Ƃ��́A�X���b�V�����΂��Ď��̍��ڂ�
        If Mid(.Text, .SelStart + 1, 1) = "/" Then
            .SelStart = .SelStart + 1
        End If
        .SelLength = 1
        
        '���͂��ꂽ�l���W���ɓ��B�����̂ŃX���b�V���ҏW����
        If Len(Trim(.Text)) = 8 Then
            .Text = Format(.Text, "0000/00/00")
            '���t�̓��̕�����I����Ԃɂ���
            .SelStart = 8
            .SelLength = 1
        End If
    End With

End Sub
    

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_GotFocus
    '   �T�v�F  ���t���ڂ̃J�[�\���ʒu�t��
    '   �����F  pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Ctl_DTItem_GotFocus(pm_objDt As Object)
    
    With pm_objDt
        If Trim(.Text) = "" Or pm_objDt.ForeColor = vbRed Then
            '�Ȃɂ������Ă��Ȃ��܂��̓G���[�̎��ɐ擪�ֈʒu�Â�
            .SelStart = 0
            .SelLength = 1
        Else
            '�Ȃɂ������Ă�������t�̏\�̈ʂ�I����Ԃɂ���
            .SelStart = 8
            .SelLength = 1
        End If
        '�w�i�F�����F�ɂ���
        .BackColor = vbYellow
    End With

End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_KeyDown
    '   �T�v�F  �����溰�ރL�[���͐���
    '   �����F  pm_KeyCode    : �L�[�R�[�h
    '           pm_Shift      : �V�t�g�������
    '           pm_objDt      : �����溰�޵�޼ު��
    '   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_tokseicd_KeyDown( _
                                pm_KeyCode As Integer, _
                                pm_Shift As Integer, _
                                pm_objCD As Object) As Integer

    Ctl_tokseicd_KeyDown = 0
    
    With pm_objCD
    
        Select Case pm_KeyCode
        
            '�t�@���N�V�����L�[������
            Case vbKeyF1 To vbKeyF12
                '�t�@���N�V�����L�[���ʏ���
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
    
            '�E��󉟉���
            Case vbKeyRight
                If .SelStart < 4 Then
                    .SelStart = .SelStart + 1
                    .SelLength = 1
                Else
                    intChkKb = 2                            '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                    Ctl_tokseicd_KeyDown = 1
                End If
            
            'Backspace or ����󉟉���
            Case vbKeyBack, vbKeyLeft
                If .SelStart > 0 Then
                    .SelStart = .SelStart - 1
                    .SelLength = 1
                Else
                    'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
                    If Trim(.Text) <> "" And pm_KeyCode = vbKeyBack Then
                        Exit Function
                    End If
                    intChkKb = 2                            '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                    Ctl_tokseicd_KeyDown = 2
                End If
        
                '���󉟉���
             Case vbKeyUp
                intChkKb = 2                                '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                Ctl_tokseicd_KeyDown = 2
    
            '����󉟉���
            Case vbKeyDown
                intChkKb = 2                                '�������溰�ނ̓��̓`�F�b�N�i�ύX���̂݁j
                Ctl_tokseicd_KeyDown = 1
    
            'Enter������
            Case vbKeyReturn
                intChkKb = 1                                '�������溰�ނ̓��̓`�F�b�N
                Ctl_tokseicd_KeyDown = 1
    
            'Delete������
            Case vbKeyDelete
                Exit Function
    
            'TAB��
            Case vbKeyF16
                intChkKb = 1                                '�������溰�ނ̓��̓`�F�b�N
                Ctl_tokseicd_KeyDown = 1
        
            'SHIFT+TAB��
            Case vbKeyF15
                intChkKb = 2                                '�������溰�ނ̓��̓`�F�b�N
                Ctl_tokseicd_KeyDown = 2
                
            Case Else
                Exit Function
        
        End Select
        
    End With

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Ctl_DTItem_KeyDown
    '   �T�v�F  ���t���ڃL�[���͐���
    '   �����F  pm_KeyCode    : �L�[�R�[�h
    '           pm_Shift      : �V�t�g�������
    '           pm_objDt      : ���t���ڵ�޼ު��
    '   �ߒl�F�@0:�ړ����� 1:������ 2:�O����
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_DTItem_KeyDown( _
                                pm_KeyCode As Integer, _
                                pm_Shift As Integer, _
                                pm_objDt As Object) As Integer

    Ctl_DTItem_KeyDown = 0
    
    With pm_objDt
    
        Select Case pm_KeyCode
    
            '�t�@���N�V�����L�[������
            Case vbKeyF1 To vbKeyF12
                '�t�@���N�V�����L�[���ʏ���
                Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
    
            '�E��� or Space������
            Case vbKeyRight, vbKeySpace
                
                If .SelStart < 9 Then
                    .SelStart = .SelStart + 1
                    '�X���b�V���ɃJ�[�\���������玟�̕����ɃJ�[�\�����ړ�
                    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                        .SelStart = .SelStart + 1
                    End If
                '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
                Else
                    intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                    Ctl_DTItem_KeyDown = 1
                End If
                .SelLength = 1
            
            'Backspace or ����󉟉���
            Case vbKeyBack, vbKeyLeft
            
                If .SelStart > 0 Then
                    .SelStart = .SelStart - 1
                    '�X���b�V���ɃJ�[�\����������O�̕����ɃJ�[�\�����ړ�
                    If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
                        .SelStart = .SelStart - 1
                    End If
        
                '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
                Else
                    intChkKb = 2                        '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                    Ctl_DTItem_KeyDown = 2
                End If
                .SelLength = 1
            
            '���󉟉���
            Case vbKeyUp
                intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                Ctl_DTItem_KeyDown = 2
            
            '����󉟉���
            Case vbKeyDown
                intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                Ctl_DTItem_KeyDown = 1

            'Enter������
            Case vbKeyReturn
                intChkKb = 1                            '�����t�̓��̓`�F�b�N
                Ctl_DTItem_KeyDown = 1
        
            'TAB��
            Case vbKeyF16
                intChkKb = 1                            '�����t�̓��̓`�F�b�N
                Ctl_DTItem_KeyDown = 1
    
            'Shift+TAB��
            Case vbKeyF15
                intChkKb = 2                            '�����t�̓��̓`�F�b�N�i�ύX���̂�)
                Ctl_DTItem_KeyDown = 2

            'Shift+DELETE��
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


'=======================================================����\���(�J�n)=======================================================

'����\����N���b�N��
Private Sub txt_kaidt_From_Click()
    
    txt_kaidt_From.SelStart = 0
    txt_kaidt_From.SelLength = 1

End Sub

'����\������ڂ�ύX������
Private Sub txt_kaidt_From_Change()
    
    '���t�ϊ�����
    Call Ctl_DTItem_Change(txt_kaidt_From)

End Sub

'����\������ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_kaidt_From_GotFocus()
    
    '�J�[�\���ʒu�t��
    Call Ctl_DTItem_GotFocus(txt_kaidt_From)
    
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True

End Sub

'����\������ڂŃL�[����������
Private Sub txt_kaidt_From_KeyDown(KeyCode As Integer, Shift As Integer)
    
    '�L�[���͐���
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
        Case 0
            '�������Ȃ�
        Case 1
            '���̓`�F�b�N
            If chkKaidt_From = True Then
                '������
                txt_kaidt_To.SetFocus
            End If
        Case 2
            '���̓`�F�b�N
            If chkKaidt_From = True Then
                '�O����
                txt_tokseicd.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'����\������ڂŃL�[����������
Private Sub txt_kaidt_From_KeyPress(KeyAscii As Integer)
    
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'����\������ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_kaidt_From_LostFocus()
    
    '�w�i�F�𔒂ɖ߂�
    txt_kaidt_From.BackColor = vbWhite

End Sub

'=======================================================����\���(�I��)=======================================================

'����\����N���b�N��
Private Sub txt_kaidt_To_Click()
    
    txt_kaidt_To.SelStart = 0
    txt_kaidt_To.SelLength = 1

End Sub

'����\������ڂ�ύX������
Private Sub txt_kaidt_To_Change()
    
    '���t�ϊ�����
    Call Ctl_DTItem_Change(txt_kaidt_To)

End Sub

'����\������ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_kaidt_To_GotFocus()
    
    '�J�[�\���ʒu�t��
    Call Ctl_DTItem_GotFocus(txt_kaidt_To)
    
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True

End Sub

'����\������ڂŃL�[����������
Private Sub txt_kaidt_To_KeyDown(KeyCode As Integer, Shift As Integer)
    
    '�L�[���͐���
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
        Case 0
            '�������Ȃ�
        Case 1
            '���̓`�F�b�N
            If chkKaidt_To = True Then
                '������
                txt_kesikb.SetFocus
            End If
        Case 2
            '���̓`�F�b�N
            If chkKaidt_To = True Then
                '�O����
                txt_kaidt_From.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'����\������ڂŃL�[����������
Private Sub txt_kaidt_To_KeyPress(KeyAscii As Integer)
    
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'����\������ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_kaidt_To_LostFocus()
    
    '�w�i�F�𔒂ɖ߂�
    txt_kaidt_To.BackColor = vbWhite

End Sub

'=======================================================������=======================================================

'���������ڃN���b�N��
Private Sub txt_kesidt_Click()
    
    txt_kesidt.SelStart = 0
    txt_kesidt.SelLength = 1

End Sub

'���������ڂ�ύX������
Private Sub txt_kesidt_Change()
    
    '���t�ϊ�����
    Call Ctl_DTItem_Change(txt_kesidt)

End Sub

'���������ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_kesidt_GotFocus()
    
    intInputMode = 1
    
    '�J�[�\���ʒu�t��
    Call Ctl_DTItem_GotFocus(txt_kesidt)
    
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True

End Sub

'���������ڂŃL�[����������
Private Sub txt_kesidt_KeyDown(KeyCode As Integer, Shift As Integer)
    
    intChkKb = 0
    
    '�L�[���͐���
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
        Case 0
            '�������Ȃ�
        Case 1
            '���̓`�F�b�N
            If chkKesidt = True Then
                '������
                txt_tokseicd.SetFocus
            End If
        Case 2
            '���̓`�F�b�N
            If chkKesidt = True Then
                '�O����
                txt_kesidt.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'���������ڂŃL�[����������
Private Sub txt_kesidt_KeyPress(KeyAscii As Integer)
    
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'���������ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_kesidt_LostFocus()
    
    '�w�i�F�𔒂ɖ߂�
    txt_kesidt.BackColor = vbWhite

End Sub

'=======================================================�U������=======================================================

'�U���������ڂ�ύX������
Private Sub txt_fridt_Change()
    
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then
        Exit Sub
    End If

    '���t�ϊ�����
    Call Ctl_DTItem_Change(txt_fridt)

    blnUsableEvent = True

End Sub

'�U���������ڂɃt�H�[�J�X���ڂ�����
Private Sub txt_fridt_GotFocus()
    
    '�J�[�\���ʒu�t��
    Call Ctl_DTItem_GotFocus(txt_fridt)
    
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True

End Sub

'�U���������ڂŃL�[����������
Private Sub txt_fridt_KeyDown(KeyCode As Integer, Shift As Integer)

    '�L�[���͐���
    Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
        Case 0
            '�������Ȃ�
        Case 1
            '���̓`�F�b�N
            If chkFridt = True Then
                '������
                spd_body.SetFocus
            End If
        Case 2
            '���̓`�F�b�N
            If chkFridt = True Then
                '�O����
                txt_kesikb.SetFocus
            End If
    End Select
    
    KeyCode = 0

End Sub

'�U���������ڂŃL�[����������
Private Sub txt_fridt_KeyPress(KeyAscii As Integer)
    
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If

End Sub

'�U���������ڂ���t�H�[�J�X���ڂ�����
Private Sub txt_fridt_LostFocus()

    '�w�i�F�𔒂ɖ߂�
    txt_fridt.BackColor = vbWhite

End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_FuncKey_Execute
    '   �T�v�F  �V�X�e�����ʏ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Integer, ByVal pm_Shift As Integer) As Integer

    CF_FuncKey_Execute = 0
   
    Select Case True
        'F1�L�[����
        Case pm_KeyCode = vbKeyF1 And pm_Shift = 0
            SendKeys "%1"
            
        'F2�L�[����
        Case pm_KeyCode = vbKeyF2 And pm_Shift = 0
            SendKeys "%2"
        
        'F3�L�[����
        Case pm_KeyCode = vbKeyF3 And pm_Shift = 0
            SendKeys "%3"
   End Select
   
End Function
    
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function CF_System_Process
    '   �T�v�F  �V�X�e�����ʏ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function CF_System_Process(pm_Form As Form) As Integer
    

   '�p�b�P�[�W���̂c�k�k�ɂ�
   '��s�`�a�����s�`�a�{�r�g�h�e�s������ꂼ�ꢂe�P�U�����e�P�T��Ɋ���
   ReleaseTabCapture 0
   SetTabCapture pm_Form.hwnd

End Function


' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F Sub chkFurikomiDT
'   �T�v�F TOKMTA.SHAKB�i�x�������j�Ɏ�`�������Ă���ꍇ�͐U���������K�{
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
    
    '�ԕi������
    With spd_body
        For idxRow = 1 To intMaxRow
            '�`�F�b�N�������Ă��邩���m�F
            .GetText COL_CHK, idxRow, tmp
            intchk = SSSVal(tmp)
            
            '�`�F�b�N�������Ă���ꍇ
            If intchk = 1 Then
                '������̎擾
                Call .GetText(COL_HYFRIDT, idxRow, tmp)
                strHYFRIDT = CStr(tmp)
                
                If Trim(strHYFRIDT) = "" Then
                    Call showMsg("0", "_COMPLETEC", 0)     '�����͂���Ă��Ȃ����ڂ�����܂��B���͂��Ă��������B
                    Exit Function
                End If
            End If
       Next idxRow
    End With

    chkFurikomiDT = True

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F Function chk_HENPIN
'   �T�v�F �����ɕԕi���������Ă��邩�`�F�b�N����
'   �����F strJdnNo   : �󒍓`�[�ԍ�
'   �@�@�F strJdnlinNo: �󒍓`�[�s�ԍ�
'       :  strUrikn   : ������z
'   �ߒl�F �`�F�b�N����
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function chkHenpin2(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUDNDT As String) As Boolean

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    On Error GoTo ERR_chkHENPIN2

    '//�\�����܂�
    chkHenpin2 = True
    
    If Trim$(gstrKaidt_Fr) = "" Then
        '//�\�����܂�
        GoTo END_chkHENPIN2
    End If
    
    '//�����ɕԕi�f�[�^�����݂��Ă��邩�m�F����
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

    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '�f�[�^�����݂����ꍇ
    If CF_Ora_EOF(Usr_Ody) = False Then
        
        Select Case txt_kesikb.Text
            Case 1
                '��������Ă��Ȃ��ꍇ�A�������s��
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
                    '//�\�����܂�
                    GoTo END_chkHENPIN2
                Else
                    '//�\�����܂���
                    chkHenpin2 = False
                    GoTo END_chkHENPIN2
                End If
            Case 9
                '��������Ă��Ȃ��ꍇ�A�������s��
                If Trim$(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
                    '//�\�����܂�
                    GoTo END_chkHENPIN2
                Else
                    '//�\�����܂���
                    chkHenpin2 = False
                    GoTo END_chkHENPIN2
                End If
        End Select
        
        '//�\�����܂�
        GoTo END_chkHENPIN2
    
    End If
    
    '�f�[�^�����݂��Ȃ������ꍇ
    If Trim$(strUDNDT) < Trim$(gstrKaidt_Fr) Then
        '//�\�����܂���
        chkHenpin2 = False
        GoTo END_chkHENPIN2
    End If
    
END_chkHENPIN2:
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_chkHENPIN2:
    GoTo END_chkHENPIN2

End Function


'�U�������̓��͉\���f
Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String _
                          , ByVal pin_strSMADT As String _
                          , ByVal pin_strSHAKB As String)
    
    Dim strSql      As Variant
    Dim Usr_Ody     As U_Ody
    
    Dim curNYUKIN1  As Integer
    Dim curNYUKIN2  As Integer

    '���������x�̏�����Ԃ��擾
    strSql = ""
    strSql = strSql & " SELECT * "
    strSql = strSql & "   FROM NKSSMB "
    strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
    strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    '�U����������͂ł��邩�ǂ����̃t���O��ݒ肷��
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

'����g�����E�������R�[�h(DENKB=8)�̔r���p�f�[�^�擾
Private Sub getUdntraNyukn(ByVal strJdnno As String, ByVal strJdnlinno As String)


    Dim Usr_Ody         As U_Ody
    Dim strSql          As String
    
    Dim intCnt          As Integer
    
    Dim strJdntrkb      As String
    Dim strOkrjono      As String '�����
    
'*** 2009/08/26 ADD START FKS)NAKATA v1.02
    Dim i               As Integer
    Dim BlnFlg          As Boolean '2�x�ǂݗp�t���O
'*** 2009/08/26 ADD E.N.D FKS)NAKATA v1.02

    
    On Error GoTo ERR_UdntraNyukn
            
            
            '��x�ǂݗp�t���O������
            BlnFlg = False
            
            
            ''�󒍔ԍ���著��󇂂��擾����B
            strOkrjono = getOKRJONO(strJdnno, strJdnlinno)


            '����g�����̍ŐV�̓������R�[�h���擾
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
    
    
            '�ް��擾
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
            Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
            
            
            
            For i = 0 To UBound(ARY_NYUKN_KS)
                '��x�ǂ݉��ϐ��Ƒ���󇂂������ꍇ�́A�f�[�^�̎擾���s��Ȃ��B
                If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
                        BlnFlg = True
                        Exit For
                End If
            Next i

            If BlnFlg = False Then
        

                '���������g�����E����g�����D�������R�[�h���A�����z�̎c�z���擾����B
                
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


                '�ް��擾
                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
                Do While CF_Ora_EOF(Usr_Ody) = False
                    
                    
                    ReDim Preserve ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
                    
                        With ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
                        
                            .SEQ = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SEQ", ""))
                            .ZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ZANKN", ""))
                            .DKBID = Format(CStr(CF_Ora_GetDyn(Usr_Ody, "DKBID", "")), "00")
                            .UPDID = Format(CStr(CF_Ora_GetDyn(Usr_Ody, "UPDID", "")), "00")
                        '**** 2009/09/16 ADD START FKS)NAKATA
                        '�����敪
                            .NYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
                        '**** 2009/09/16 ADD E.N.D FKS)NAKATA
                        '**** 2009/10/09 ADD START FKS)NAKATA
                        '�����(������)
                            .UDNDT = CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")
                        '**** 2009/10/09 ADD E.N.D FKS)NAKATA
                            .OKRJONO = strOkrjono
                            
                        End With

                    ARY_NYUKN_KS_CNT = ARY_NYUKN_KS_CNT + 1
    
                    Usr_Ody.Obj_Ody.MoveNext
    
                Loop
                Call CF_Ora_CloseDyn(Usr_Ody)   '�ް���ĸ۰��
                        
            End If
            

END_UdntraNyukn:
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Sub

ERR_UdntraNyukn:
    Call SSSWIN_LOGWRT("getUdntraNyukn_ERROR")
    GoTo END_UdntraNyukn

End Sub

'2009/09/07 ADD START FKS)NAKATA
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function F_Util_GET_TANMTA_TANCLAKB
'   �T�v�F  �c�ƒS���t���O���擾
'   �����F�@pot_strTANCD       : �S���҃R�[�h
'       �F�@pot_strKEIBMNCD    : �c�ƒS���t���O
'   �ߒl�F�@0:����I�� 9:�ُ�I��
'   ���l�F
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, _
                                           ByRef pot_strTANCLAKB As String) As Integer

    Dim Usr_Ody         As U_Ody
    Dim strSql          As String

On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
    
    F_Util_GET_TANMTA_TANCLAKB = 9
    
    pot_strTANCLAKB = ""
    
    '�S���҂l
    strSql = ""
    strSql = strSql & " SELECT TANCLAKB "
    strSql = strSql & " FROM TANMTA "
    strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "

    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)

    If CF_Ora_EOF(Usr_Ody) = False Then
        pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
    Else
        GoTo END_F_Util_GET_TANMTA_TANCLAKB:
    End If

    F_Util_GET_TANMTA_TANCLAKB = 0
    
END_F_Util_GET_TANMTA_TANCLAKB:
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody)

    Exit Function

ERR_F_Util_GET_TANMTA_TANCLAKB:
    GoTo END_F_Util_GET_TANMTA_TANCLAKB
    
End Function
'2009/09/07 ADD E.N.D FKS)NAKATA
