VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSSUB 
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "���z�����o�^"
   ClientHeight    =   4680
   ClientLeft      =   6540
   ClientTop       =   3525
   ClientWidth     =   9450
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
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
      BorderStyle     =   0  '�Ȃ�
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
      BorderStyle     =   0  '�Ȃ�
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
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   2
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   10
      Top             =   3360
      Width           =   1215
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   2
      Left            =   315
      MaxLength       =   2
      TabIndex        =   9
      Top             =   3360
      Width           =   330
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   2
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   11
      Top             =   3360
      Width           =   1515
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   12
      Top             =   3360
      Width           =   2430
   End
   Begin VB.TextBox txt_BDkouza 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   1
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   6
      Top             =   3045
      Width           =   1215
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   1
      Left            =   315
      MaxLength       =   2
      TabIndex        =   5
      Top             =   3045
      Width           =   330
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   1
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   7
      Top             =   3045
      Width           =   1515
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   8
      Top             =   3045
      Width           =   2430
   End
   Begin VB.TextBox txt_BDlincma 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   4260
      MaxLength       =   20
      TabIndex        =   4
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   2730
      Width           =   2430
   End
   Begin VB.TextBox txt_BDnyukn 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   2760
      MaxLength       =   9
      TabIndex        =   3
      Text            =   "9,999,999"
      Top             =   2730
      Width           =   1515
   End
   Begin VB.TextBox txt_BDdkbid 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   315
      MaxLength       =   2
      TabIndex        =   1
      Text            =   "99"
      Top             =   2730
      Width           =   330
   End
   Begin VB.TextBox txt_BDkouza 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Index           =   0
      Left            =   1560
      MaxLength       =   10
      TabIndex        =   2
      Text            =   "XXXXXXXXX1"
      Top             =   2730
      Width           =   1215
   End
   Begin VB.TextBox txt_HDkouza 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
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
         Left            =   7455
         TabIndex        =   15
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "������"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "������"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�������"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*������� "
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "*�������"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "*�����z "
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      BevelOuter      =   1
      Caption         =   "���l"
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
            TabIndex        =   26
            TabStop         =   0   'False
            Text            =   "�G���[��v�����v�g�̃��b�Z�[�W���o�͂����Ƃ���ł��B"
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
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�\������e�L�X�g�{�b�N�X�ݒ�p�p�l��"
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Index           =   2
         Left            =   450
         MaxLength       =   10
         TabIndex        =   35
         Top             =   2715
         Width           =   945
      End
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Index           =   1
         Left            =   450
         MaxLength       =   10
         TabIndex        =   34
         Top             =   2400
         Width           =   945
      End
      Begin VB.TextBox txt_tokseicd 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1380
         MaxLength       =   5
         TabIndex        =   33
         Text            =   "XXXX5"
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox txt_tokseinma 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Left            =   2580
         MaxLength       =   60
         TabIndex        =   32
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4MMMMMMMMM5MMMMMMMMM6"
         Top             =   720
         Width           =   6390
      End
      Begin VB.TextBox txt_nyudt 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Left            =   1380
         MaxLength       =   10
         TabIndex        =   31
         Text            =   "YYYY/MM/DD"
         Top             =   405
         Width           =   1215
      End
      Begin VB.TextBox txt_opeid 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Left            =   5850
         MaxLength       =   8
         TabIndex        =   30
         Text            =   "XXXXXXX8"
         Top             =   75
         Width           =   915
      End
      Begin VB.TextBox txt_openm 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
         Left            =   6750
         MaxLength       =   20
         TabIndex        =   29
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   75
         Width           =   2220
      End
      Begin VB.TextBox txt_BDdkbnm 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H8000000F&
         Height          =   330
         IMEMode         =   2  '��
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
      Begin VB.Menu mnu_bdinitdsp 
         Caption         =   "���׍s������"
      End
      Begin VB.Menu mnu_gyodel 
         Caption         =   "���׍s�폜(&T)"
         Shortcut        =   ^T
      End
      Begin VB.Menu mnu_gyoin 
         Caption         =   "���׍s�}��(&I)"
         Shortcut        =   ^I
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
Attribute VB_Name = "FR_SSSSUB"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim blnUsableEvent  As Boolean  '����Ă����s���邩�ǂ������׸�(�ėp)
Dim intChkKb        As Integer  '�`�F�b�N�敪(1:�`�F�b�N
                                '             2:�`�F�b�N(�O�񂩂�ύX���̂�)
                                '             3:�`�F�b�N(�t�H�[�J�X�͈ړ����Ȃ�)

Dim strHDkouza      As String   '�w�b�_�̊�������̒l���i�[
Dim CurrentLine     As Integer  '�t�H�[�J�X�̂���s�ԍ����Z�b�g(�w�b�_�̎���-1�j


Dim intEventUkai    As Integer  '����Ă��I�񂷂邩�ǂ������׸�(�ėp)


'�t�H�[�����[�h��
Private Sub Form_Load()
    'WINDOW �ʒu�ݒ�
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    '������
    initForm
    '���ڏ�����
    initItem
End Sub

'�t�H�[���A�����[�h��
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    '���I���m�F��MSG
    If chkLineNull(0) = True Then
        If chkLineNull(1) = True Then
            If chkLineNull(2) = True Then
                If showMsg("0", "_ENDCM", 0) = vbNo Then
                    Cancel = vbCancel
                    Exit Sub
                Else
                    Unload Me '��PG�I��
                    Exit Sub
                End If
            End If
        End If
    End If
    
    If showMsg("0", "_ENDCK", 0) = vbNo Then
        Cancel = vbCancel
        Exit Sub
    End If
    
    Unload Me '��PG�I��
End Sub




Private Sub initForm()
    '���ЂƂ܂��s�ǉ��͕ۗ�
    mnu_gyoin.Visible = False
    img_gyoin.Visible = False
    
    '�^�p���̕\��
    pnl_unydt.Caption = CNV_DATE(gstrUnydt)
    
    '�������̕\��
    txt_nyudt.Text = CNV_DATE(gstrKesidt)
    
    '������̕\��
    txt_tokseicd.Text = DB_TOKMTA.TOKSEICD
    txt_tokseinma.Text = DB_TOKMTA.TOKNMA
    
    '���͒S���҂̕\��
    txt_opeid.Text = FR_SSSMAIN.txt_opeid.Text
    txt_openm.Text = FR_SSSMAIN.txt_openm.Text
    
    '�\������e�L�X�g�{�b�N�X�ݒ�p�p�l�����B��
    pnl_hihyoji.Caption = ""
    pnl_hihyoji.BevelOuter = ssBevelNone
End Sub

'���ڂ̏�����
Private Sub initItem()
    txt_HDkouza.Text = "          "     '10byte space
    txt_HDkouza.ForeColor = vbBlack
    txt_HDkouza.BackColor = vbWhite
    strHDkouza = ""
    
    blnUsableEvent = True
    intChkKb = 2
    
    initBody
End Sub

'���ו��̍폜
Private Sub initBody()
    Dim i As Integer
    For i = 0 To 2
        initLine (i)
    Next i
End Sub

'�s�̏�����
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
    
    '�`�F�b�N�敪��1,3�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    If intChkKb = 1 Or txt_HDkouza.Text <> strHDkouza Or intChkKb = 3 Then
        
        '�󔒓��͎��̓`�F�b�N���Ȃ�
        If Trim(txt_HDkouza.Text) = "" Then Exit Function
        
        '������Ͻ����犨��������̂��擾
        Select Case GET_MEIMTA_KANKOZ(txt_HDkouza.Text)
            '���݂���Ƃ�
            Case 0:
                txt_HDkouza.ForeColor = vbBlack
                chkHDkouza = True
                

            '���݂��邪�A�폜���R�[�h�̏ꍇ
            Case 8:
                '�`�F�b�N�敪��3�łȂ��Ƃ��A���b�Z�[�W��\��
                If intChkKb <> 3 Then
                    Call showMsg("2", "URKET73_039", "0")   '���폜�ς݃��R�[�h�ł�
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus
                End If

            
            '���݂��Ȃ���
            Case 9:
                '�`�F�b�N�敪��3�łȂ��Ƃ��A���b�Z�[�W��\��
                If intChkKb <> 3 Then
                    Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus
                End If
        End Select
    End If
    strHDkouza = txt_HDkouza.Text
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function

'���ו���������̓��̓`�F�b�N
Private Function chkBDkouza(Index As Integer) As Boolean
    chkBDkouza = False
    
    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s���B
    If intChkKb = 1 Or txt_BDkouza(Index).Text <> gtypeFR_SUB(Index).SUB_KOUZA Then
        
        '�󔒓��͎��̓`�F�b�N���Ȃ�
        If Trim(txt_BDkouza(Index).Text) <> "" Then
        
            '������Ͻ����犨��������̂��擾
            Select Case GET_MEIMTA_KANKOZ(txt_BDkouza(Index).Text)
                '���݂���Ƃ�
                Case 0:
                    txt_BDkouza(Index).ForeColor = vbBlack
                    chkBDkouza = True
                    

            '���݂��邪�A�폜���R�[�h�̏ꍇ
            Case 8:
                    Call showMsg("2", "URKET73_039", "0")   '���폜�ς݃��R�[�h�ł�
                    txt_HDkouza.ForeColor = vbRed
                    txt_HDkouza.SetFocus

            
                '���݂��Ȃ���
                Case 9:
                    Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
                    txt_BDkouza(Index).ForeColor = vbRed
                    txt_BDkouza(Index).SetFocus
            End Select
        End If
    End If
    
    gtypeFR_SUB(Index).SUB_KOUZA = txt_BDkouza(Index).Text
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function

'������ʂ̓��̓`�F�b�N
Private Function chkBDdkbid(Index As Integer) As Boolean
    Dim tmp As String
    
    chkBDdkbid = False
    
    '�`�F�b�N�敪��1�̂Ƃ��A���邢�͕ύX����Ă�����`�F�b�N���s��
    If intChkKb = 1 Or Trim(txt_BDdkbid(Index).Text) <> Trim(gtypeFR_SUB(Index).SUB_DKBID) Then
        txt_BDdkbnm(Index).Text = ""
        
        '�󔒓��͎��̓`�F�b�N���Ȃ�
        If Trim(txt_BDdkbid(Index).Text) <> "" Then
        
            '���͒l��2byte�Ŗ�������0����
            blnUsableEvent = False
            txt_BDdkbid(Index).Text = Format((txt_BDdkbid(Index).Text), "00")
            blnUsableEvent = True
            
            '��SYSTBD���������ʖ��̂��擾
            tmp = getDkbnm(txt_BDdkbid(Index).Text, Index)
            If tmp <> "" Then
                '���݂���Ƃ�
                txt_BDdkbid(Index).ForeColor = vbBlack
                txt_BDdkbnm(Index).Text = tmp
                '�w�b�_�Ɋ���������w�肳��Ă��āA�����ׂɊ�����������͂���Ă��Ȃ���΃R�s�[
                intChkKb = 3    '�`�F�b�N�̂�
                If txt_HDkouza.Text <> "" And chkHDkouza = True Then
                    blnUsableEvent = False
                    
                    If Trim(txt_BDkouza(Index).Text) = "" Then
                        txt_BDkouza(Index).Text = txt_HDkouza.Text
                    End If

                    blnUsableEvent = True
                End If
                chkBDdkbid = True
            
            '���݂��Ȃ���
            Else
                Call showMsg("2", "RNOTFOUND", "0")    '���Y���f�[�^�Ȃ�
                txt_BDdkbid(Index).ForeColor = vbRed
                txt_BDdkbid(Index).SetFocus
            End If
        
        '�󔒂̂Ƃ��A�o�^���������s����
        Else
            gtypeFR_SUB(Index).SUB_DKBID = ""
            mnu_regist_Click
        End If
    End If
    
    gtypeFR_SUB(Index).SUB_DKBID = txt_BDdkbid(Index).Text
    intChkKb = 2            '����{�͕ύX���Ƀ`�F�b�N
End Function

'�s�P�ʂɓ��̓`�F�b�N���s��
'intPattern��0�̎��͕K���`�F�b�N
Private Function chkLine(intRow As Integer, Optional intPattern As Integer = 1) As Boolean
    chkLine = False
    
    CurrentLine = intRow
    '�s�ɂ����ꂩ�ɍ��ڂ����͂���Ă�����A�ʂ̕K�{���ڂ̓��̓`�F�b�N���s��
    If Trim(txt_BDdkbid(intRow).Text) <> "" Or Trim(txt_BDkouza(intRow).Text) <> "" _
        Or Trim(txt_BDkouza(intRow).Text) <> "" Or Trim(txt_BDlincma(intRow).Text) <> "" Or intPattern = 0 Then
        
        If Trim(txt_BDdkbid(intRow).Text) = "" Then
            showMsg "0", "_COMPLETEC", "0"       '���K�{���ږ����͂�MSG
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

'�s��NULL���ǂ������m�F
Private Function chkLineNull(intRow As Integer) As Boolean
    chkLineNull = False
    
    If Trim(txt_BDdkbid(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDkouza(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDnyukn(intRow).Text) <> "" Then Exit Function
    If Trim(txt_BDlincma(intRow).Text) <> "" Then Exit Function
    
    chkLineNull = True
End Function



'�I���{�^���N���b�N��
Private Sub img_exit_Click()
    mnu_exit_Click
End Sub
'�I���}�E�X�_�E����
Private Sub img_exit_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(1).Picture
End Sub
'�I���}�E�X���[�u��
Private Sub img_exit_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "���j���[�ɖ߂�܂��B"
End Sub
'�I���}�E�X�A�b�v��
Private Sub img_exit_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_exit.Picture = img_bkexit(0).Picture
End Sub

'�s�폜�{�^���N���b�N��
Private Sub img_gyodel_Click()
    If mnu_gyodel.Enabled = False Then Exit Sub
    mnu_gyodel_Click
End Sub
'�s�폜�}�E�X�_�E����
Private Sub img_gyodel_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyodel.Picture = img_bkgyodel(1).Picture
End Sub
'�s�폜�}�E�X���[�u��
Private Sub img_gyodel_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "���ׂ���s�폜���܂��B"
End Sub
'�s�폜�}�E�X�A�b�v��
Private Sub img_gyodel_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyodel.Picture = img_bkgyodel(0).Picture
End Sub

'�s�}���{�^���N���b�N��
Private Sub img_gyoin_Click()
    If mnu_gyoin.Enabled = False Then Exit Sub
    mnu_gyoin_Click
End Sub
'�s�}���}�E�X�_�E����
Private Sub img_gyoin_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyoin.Picture = img_bkgyoin(1).Picture
End Sub
'�s�}���}�E�X���[�u��
Private Sub img_gyoin_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "���׍s��}�����܂��B"
End Sub
'�s�}���}�E�X�A�b�v��
Private Sub img_gyoin_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_gyoin.Picture = img_bkgyoin(0).Picture
End Sub

'�o�^�{�^���N���b�N��
Private Sub img_regist_Click()
    mnu_regist_Click
End Sub
'�o�^�}�E�X�_�E����
Private Sub img_regist_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_regist.Picture = img_bkregist(1).Picture
End Sub
'�o�^�}�E�X���[�u��
Private Sub img_regist_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "�o�^���܂��B"
End Sub
'�o�^�}�E�X�A�b�v��
Private Sub img_regist_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_regist.Picture = img_bkregist(0).Picture
End Sub

'�����{�^���N���b�N��
Private Sub img_showwnd_Click()
    mnu_showwnd_Click
End Sub
'�����}�E�X�_�E����
Private Sub img_showwnd_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(1).Picture
End Sub
'�����}�E�X���[�u��
Private Sub img_showwnd_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_light.Picture = img_bklight(1).Picture
    txt_message.Text = "�E�B���h�E��\�����܂��B"
End Sub
'�����}�E�X�A�b�v��
Private Sub img_showwnd_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    img_showwnd.Picture = img_bkshowwnd(0).Picture
End Sub

'���׍s���������j���[�N���b�N��
Private Sub mnu_bdinitdsp_Click()
    '�s�̏������s��
    initLine CurrentLine
    txt_BDdkbid(CurrentLine).SetFocus
    txt_BDdkbid(CurrentLine).BackColor = vbYellow
End Sub

'�I�����j���[�N���b�N��
Private Sub mnu_exit_Click()
    Unload Me
End Sub

'�s�폜���j���[�N���b�N��
Private Sub mnu_gyodel_Click()
    Dim i As Integer
    
    '�s�̏������s��
    initLine CurrentLine
    '���i�̍s�����ݍs�Ɉړ�
    If CurrentLine < 2 Then
        For i = CurrentLine To 1 - CurrentLine
        '���i�̍s���󔒂łȂ�������A��i�ɃR�s�[
            If chkLineNull(i + 1) = False Then
                blnUsableEvent = False
                
                txt_BDdkbid(i).Text = txt_BDdkbid(i + 1).Text
                txt_BDdkbnm(i).Text = txt_BDdkbnm(i + 1).Text
                txt_BDkouza(i).Text = txt_BDkouza(i + 1).Text
                txt_BDnyukn(i).Text = txt_BDnyukn(i + 1).Text
                txt_BDlincma(i).Text = txt_BDlincma(i + 1).Text
                Call moveSubFormType(i)   '�\���̂̒l���R�s�[
                initLine i + 1     '���i�̏����폜
                
                blnUsableEvent = True
            End If
        Next i
    End If
    txt_BDdkbid(CurrentLine).SetFocus
    txt_BDdkbid(CurrentLine).BackColor = vbYellow
End Sub

'�s�ǉ����j���[�N���b�N��
Private Sub mnu_gyoin_Click()
    '
End Sub

'��ʏ��������j���[�N���b�N��
Private Sub mnu_initdsp_Click()
    '������
    initItem
    '�w�b�_����������Ƀt�H�[�J�X���ړ�
    CurrentLine = -1    '�w�b�_������-1���Z�b�g
    txt_HDkouza.SetFocus
    txt_HDkouza.BackColor = vbYellow
End Sub

'�o�^���j���[�N���b�N��
Private Sub mnu_regist_Click()
    Dim p As Integer
    Dim i As Integer
    
    
    intEventUkai = 1
    p = CurrentLine
    If chkLine(0, 0) = False Then
        intEventUkai = 0
        Exit Sub  '1�s�ڂ͕K�{����
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

    
    
    '���o�^�m�F��MSG
    If showMsg("0", "_UPDATE", 0) = vbYes Then
        '�������̔��f
        If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
            showMsg "2", "UPDAUTH", "0"
        Else
            Me.MousePointer = vbHourglass
            If F_UPDATE_SUB = 1 Then
                mnu_initdsp_Click   '��ʕ\���̏�����
            Else
                '���X�V�������s��
                MsgBox "�X�V�Ɏ��s���܂����B", vbCritical, "�X�V�G���["
            End If
            Me.MousePointer = vbDefault
        End If
    Else
        If CurrentLine <> -1 Then
            txt_BDdkbid(CurrentLine).SetFocus
        End If
    End If
End Sub

'�������j���[�N���b�N��
Private Sub mnu_showwnd_Click()
    '�w�b�_����������Ƀt�H�[�J�X������Ƃ�
    If Me.ActiveControl.Name = txt_HDkouza.Name Then
        blnUsableEvent = False
        cmd_HDkouza_Click
        blnUsableEvent = True
        
    '���ו��Ƀt�H�[�J�X������Ƃ�
    ElseIf CurrentLine >= 0 Then
        '������ʂ̂Ƃ�
        If Me.ActiveControl.Name = txt_BDdkbid(CurrentLine).Name Then
            blnUsableEvent = False
            cmd_BDdkbid_Click
            blnUsableEvent = True
        
        '��������̂Ƃ�
        ElseIf Me.ActiveControl.Name = txt_BDkouza(CurrentLine).Name Then
            blnUsableEvent = False
            cmd_BDkouza_Click
            blnUsableEvent = True
        End If
    End If
End Sub

'�w�b�_�p�l���}�E�X���[�u��
Private Sub pnl_head_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    '�q���g�̕\��������������
    img_light.Picture = img_bklight(0).Picture
    txt_message.Text = ""
End Sub






'=======================================================�������(����)�K�{����=======================================================


Private Sub txt_BDdkbid_Change(Index As Integer)
    Dim p As Integer
    
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub
        
    '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
    If txt_BDdkbid(Index).SelStart = 2 Then
        intChkKb = 1                                '��������ʂ̓��̓`�F�b�N
        txt_BDkouza(Index).SetFocus                 '���ו�����������ڂֈړ�
    End If
    
End Sub

Private Sub txt_BDdkbid_GotFocus(Index As Integer)
    '�S�I����Ԃɂ���
    txt_BDdkbid(Index).SelStart = 0
    txt_BDdkbid(Index).SelLength = 2
    '�w�i�F�����F�ɂ���
    txt_BDdkbid(Index).BackColor = vbYellow
    '���׍s�R�}���h�����s�Ƃ���
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True
    '���ݍs�ԍ���ۑ�
    CurrentLine = Index
End Sub

Private Sub txt_BDdkbid_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '�E��󉟉���
    If KeyCode = vbKeyRight Then
        If txt_BDdkbid(Index).SelStart < (2 - 1) Then
            txt_BDdkbid(Index).SelStart = txt_BDdkbid(Index).SelStart + 1

        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
        Else
            intChkKb = 2                                '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
            txt_BDkouza(Index).SetFocus                 '���ו�����������ڂֈړ�
        End If
        txt_BDdkbid(Index).SelLength = 1
    
    'Backspace or ����󉟉���
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDdkbid(Index).SelStart > 0 Then
            txt_BDdkbid(Index).SelStart = txt_BDdkbid(Index).SelStart - 1
            
        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
        Else
            'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
            If Trim(txt_BDdkbid(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            
            intChkKb = 2                                '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
            If Index = 0 Then
                txt_HDkouza.SetFocus                    '�w�b�_������������ڂֈړ�
            Else
                txt_BDlincma(Index - 1).SetFocus        '���l���ڂֈړ�
            End If
        End If
        txt_BDdkbid(Index).SelLength = 1
        
    '���󉟉���
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 2                                '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
        If Index = 0 Then
            txt_HDkouza.SetFocus                    '�w�b�_������������ڂֈړ�
        Else
            txt_BDdkbid(Index - 1).SetFocus        '���l���ڂֈړ�
        End If
        
    '����󉟉���
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 2                                '��������ʂ̓��̓`�F�b�N�i�ύX���̂݁j
        If Index < 2 Then
            txt_BDdkbid(Index + 1).SetFocus               '���ו�����������ڂֈړ�
        End If
        
    'Enter������
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '��������ʂ̓��̓`�F�b�N
        txt_BDkouza(Index).SetFocus                 '���ו�����������ڂֈړ�
        
    'Delete������
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDdkbid_KeyPress(Index As Integer, KeyAscii As Integer)
    If KeyAscii = vbKeyBack Then Exit Sub
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_BDdkbid_LostFocus(Index As Integer)
    '������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    '���̓`�F�b�N
    chkBDdkbid Index
    '�w�i�F�𔒂ɖ߂�
    txt_BDdkbid(Index).BackColor = vbWhite
End Sub


'=======================================================�������(����)�K�{����=======================================================


Private Sub txt_BDkouza_Change(Index As Integer)
    Dim p As Integer
    
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    blnUsableEvent = False
    p = txt_BDkouza(Index).SelStart
    
    '�S�p���폜����
    txt_BDkouza(Index).Text = delZenkaku(txt_BDkouza(Index).Text)
    '���͒l��10byte�Ŗ������͋󔒖���
    txt_BDkouza(Index).Text = txt_BDkouza(Index).Text & Space(10 - Len(txt_BDkouza(Index).Text))
    
    txt_BDkouza(Index).SelStart = p
    blnUsableEvent = True
    
    '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
    If txt_BDkouza(Index).SelStart = 10 Then
        intChkKb = 1                                '������������ނ̓��̓`�F�b�N
        txt_BDnyukn(Index).SetFocus                     '�����z���ڂֈړ�
    End If
    txt_BDkouza(Index).SelLength = 1
End Sub

Private Sub txt_BDkouza_GotFocus(Index As Integer)
    '�擪�ʒu��I����Ԃɂ���
    txt_BDkouza(Index).SelStart = 0
    txt_BDkouza(Index).SelLength = 1
    '�w�i�F�����F�ɂ���
    txt_BDkouza(Index).BackColor = vbYellow
    '���׍s�R�}���h�����s�Ƃ���
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True
    '���ݍs�ԍ���ۑ�
    CurrentLine = Index
End Sub

Private Sub txt_BDkouza_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '�E��󉟉���
    If KeyCode = vbKeyRight Then
        If txt_BDkouza(Index).SelStart < (10 - 1) Then
            txt_BDkouza(Index).SelStart = txt_BDkouza(Index).SelStart + 1
            
        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
        Else
            intChkKb = 2                                '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
            txt_BDnyukn(Index).SetFocus                 '�����z���ڂֈړ�
        End If
        txt_BDkouza(Index).SelLength = 1
    
    'Backspace or ����󉟉���
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDkouza(Index).SelStart > 0 Then
            txt_BDkouza(Index).SelStart = txt_BDkouza(Index).SelStart - 1
            
        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
        Else
            'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
            If Trim(txt_BDkouza(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            intChkKb = 2                                '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
            txt_BDdkbid(Index).SetFocus                 '������ʍ��ڂֈړ�
        End If
        txt_BDkouza(Index).SelLength = 1
        
    '���󉟉���
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 2                                '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
        If Index = 0 Then
            txt_HDkouza.SetFocus
        Else
            txt_BDkouza(Index - 1).SetFocus                    '������ʍ��ڂֈړ�
        End If
        
    '����󉟉���
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 2                                '������������ނ̓��̓`�F�b�N�i�ύX���̂݁j
        If Index < 2 Then
            txt_BDkouza(Index + 1).SetFocus                     '�����z���ڂֈړ�
        End If
        
    'Enter������
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '������������ނ̓��̓`�F�b�N
        txt_BDnyukn(Index).SetFocus                     '�����z���ڂֈړ�
        
    'Delete������
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDkouza_KeyPress(Index As Integer, KeyAscii As Integer)
    '�A���t�@�x�b�g��������啶���ɕϊ�����
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

Private Sub txt_BDkouza_LostFocus(Index As Integer)
    '������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    '���̓`�F�b�N(�󔒂͖���)
    chkBDkouza Index
    '�w�i�F�𔒂ɖ߂�
    txt_BDkouza(Index).BackColor = vbWhite
End Sub


'=======================================================���l(����)=======================================================


Private Sub txt_BDlincma_Change(Index As Integer)
    Dim p As Integer
    
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    With txt_BDlincma(Index)
        blnUsableEvent = False
        p = .SelStart
        
        '���͒l��10byte�Ŗ������͋󔒖���
        .Text = LeftWid$(.Text, 20)
        
        .SelStart = p
        blnUsableEvent = True
        
        '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
        If .SelStart = 20 Then
            If Index < 2 Then
                txt_BDdkbid(Index + 1).SetFocus         '������ʍ��ڂֈړ�
            Else
                intChkKb = 2                            '���o�^���s
                txt_HDkouza.SetFocus
            End If
        End If
        .SelLength = 1
        
        gtypeFR_SUB(Index).SUB_LINCMA = .Text
    End With
    
End Sub

Private Sub txt_BDlincma_GotFocus(Index As Integer)
    '�擪�ʒu��I����Ԃɂ���
    txt_BDlincma(Index).SelStart = 0
    txt_BDlincma(Index).SelLength = 1
    '�w�i�F�����F�ɂ���
    txt_BDlincma(Index).BackColor = vbYellow
    '���׍s�R�}���h�����s�Ƃ���
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '�������������s�s�Ƃ���
    mnu_showwnd.Enabled = False
    '���ݍs�ԍ���ۑ�
    CurrentLine = Index
End Sub

Private Sub txt_BDlincma_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    
    '�E��󉟉���
    If KeyCode = vbKeyRight Then
        If txt_BDlincma(Index).SelStart < 19 Then
            txt_BDlincma(Index).SelStart = txt_BDlincma(Index).SelStart + 1
            
        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
        Else
            If Index < 2 Then
                txt_BDdkbid(Index + 1).SetFocus       '������ʍ��ڂֈړ�
            Else
                intChkKb = 1                          '���o�^���s
                txt_HDkouza.SetFocus
            End If
        End If
        txt_BDlincma(Index).SelLength = 1
    
    'Backspace or ����󉟉���
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_BDlincma(Index).SelStart > 0 Then
            txt_BDlincma(Index).SelStart = txt_BDlincma(Index).SelStart - 1
            
        '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
        Else
            'Backspace�̎��́A���͒l���󔒂̎��A�O���ڂֈړ�
            If Trim(txt_BDlincma(Index).Text) <> "" And KeyCode = vbKeyBack Then
                Exit Sub
            End If
            intChkKb = 1                            '�o�^���Ȃ�
            txt_BDnyukn(Index).SetFocus             '�����z���ڂֈړ�
        End If
        txt_BDlincma(Index).SelLength = 1
        
    '���󉟉���
    ElseIf KeyCode = vbKeyUp Then
        intChkKb = 1                                '�o�^���Ȃ�
        If Index = 0 Then
            txt_HDkouza.SetFocus
        Else
            txt_BDlincma(Index - 1).SetFocus               '���������ڂֈړ�
        End If
        
    '����󉟉���
    ElseIf KeyCode = vbKeyDown Then
        If Index < 2 Then
            txt_BDlincma(Index + 1).SetFocus         '������ʍ��ڂֈړ�
        Else
            intChkKb = 2                            '���o�^���s
            txt_HDkouza.SetFocus
        End If
        
    'Enter������
    ElseIf KeyCode = vbKeyReturn Then
        If Index < 2 Then
            txt_BDdkbid(Index + 1).SetFocus         '������ʍ��ڂֈړ�
        Else
            intChkKb = 2                            '���o�^���s
            txt_HDkouza.SetFocus
        End If
        
    'Delete������
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_BDlincma_LostFocus(Index As Integer)
    '�w�i�F�𔒂ɖ߂�
    txt_BDlincma(Index).BackColor = vbWhite
    '���o�^���s
    If Index = 2 And intChkKb = 2 Then
        
        If intEventUkai = 0 Then
            mnu_regist_Click
        End If

    End If
    intChkKb = 1
End Sub


'=======================================================�����z(����)�K�{����=======================================================


'�����z���ڕύX��
Private Sub txt_BDnyukn_Change(Index As Integer)
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    With txt_BDnyukn(Index)
        blnUsableEvent = False
        '���z�̌����\��������t��
        
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
    '�S�I����Ԃɂ���
    txt_BDnyukn(Index).SelStart = 0
    txt_BDnyukn(Index).SelLength = 9
    '�w�i�F�����F�ɂ���
    txt_BDnyukn(Index).BackColor = vbYellow
    '���׍s�R�}���h�����s�Ƃ���
    mnu_bdinitdsp.Enabled = True
    mnu_gyoin.Enabled = True
    mnu_gyodel.Enabled = True
    '�������������s�s�Ƃ���
    mnu_showwnd.Enabled = False
    '���ݍs�ԍ���ۑ�
    CurrentLine = Index
End Sub

Private Sub txt_BDnyukn_KeyDown(Index As Integer, KeyCode As Integer, Shift As Integer)
    With txt_BDnyukn(Index)
        
        '�E��� or Space������
        If KeyCode = vbKeyRight Or KeyCode = vbKeySpace Then
            If .SelStart < 9 Then
                
                .SelStart = .SelStart + 1
                If Mid(.Text, .SelStart + 1, 1) = "," Then
                    .SelStart = .SelStart + 1
                End If

                
            '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
            Else
                txt_BDlincma(Index).SetFocus                 '���l���ڂֈړ�
            End If
        
        'Backspace or ����󉟉���
        ElseIf KeyCode = vbKeyLeft Then
            If .SelStart > 0 Then
                
                .SelStart = .SelStart - 1
                If Mid(.Text, .SelStart + 1, 1) = "," Then
                    .SelStart = .SelStart - 1
                End If
                
            '�J�[�\�������[�ɗ�����O�̍��ڂֈړ�
            Else
                txt_BDkouza(Index).SetFocus               '����������ڂֈړ�
            End If
        
        '���󉟉���
        ElseIf KeyCode = vbKeyUp Then
            If Index = 0 Then
                txt_HDkouza.SetFocus
            Else
                txt_BDnyukn(Index - 1).SetFocus               '����������ڂֈړ�
            End If
            
        '����󉟉���
        ElseIf KeyCode = vbKeyDown Then
            If Index < 2 Then
                txt_BDnyukn(Index + 1).SetFocus                 '���l���ڂֈړ�
            End If
            
        'Enter������
        ElseIf KeyCode = vbKeyReturn Then
            txt_BDlincma(Index).SetFocus                 '���l���ڂֈړ�
            
        ElseIf KeyCode = vbKeyDelete Then
            Exit Sub
        End If
    
    End With
    KeyCode = 0
End Sub

Private Sub txt_BDnyukn_KeyPress(Index As Integer, KeyAscii As Integer)
    'Backspace, �}�C�i�X�L���͓��͂ł���
    If KeyAscii = vbKeyBack Then Exit Sub
    If KeyAscii = 45 And Left(txt_BDnyukn(Index).Text, 1) <> "-" Then Exit Sub
    

    If SSSVal(txt_BDnyukn(Index)) >= 9999999 Or SSSVal(txt_BDnyukn(Index)) <= -999999 Then
        KeyAscii = 0
        Exit Sub
    End If

    
    '���l�̂ݓ��͉Ƃ���
    If Not Chr(KeyAscii) Like "[0-9]" Then
        KeyAscii = 0
    End If
End Sub

Private Sub txt_BDnyukn_LostFocus(Index As Integer)
    '�����F�����ɖ߂�
    txt_BDnyukn(Index).ForeColor = vbBlack
    '�w�i�F�𔒂ɖ߂�
    txt_BDnyukn(Index).BackColor = vbWhite
End Sub


'=======================================================�������(�w�b�_)=======================================================

Private Sub txt_HDkouza_Change()
    Dim p As Integer
    
    '�׸ނ������Ă��Ȃ����Ͳ���Ă����s�����Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    blnUsableEvent = False
    p = txt_HDkouza.SelStart
    
    '�S�p���폜����
    txt_HDkouza.Text = delZenkaku(txt_HDkouza.Text)
    '���͒l��10byte�Ŗ������͋󔒖���
    txt_HDkouza.Text = txt_HDkouza.Text & Space(10 - Len(txt_HDkouza.Text))
    
    txt_HDkouza.SelStart = p
    blnUsableEvent = True
    
    '�J�[�\�����E�[�Ɉړ��������́A���̍��ڂֈړ�
    If txt_HDkouza.SelStart = 10 Then
        intChkKb = 1                                '������������ނ̓��̓`�F�b�N
        txt_BDdkbid(0).SetFocus                          '������ʍ��ڂֈړ�
    End If
    txt_HDkouza.SelLength = 1
End Sub

Private Sub txt_HDkouza_GotFocus()
    '�擪�ʒu��I����Ԃɂ���
    txt_HDkouza.SelStart = 0
    txt_HDkouza.SelLength = 1
    '�w�i�F�����F�ɂ���
    txt_HDkouza.BackColor = vbYellow
    
    '���׍s�R�}���h�����s�s�Ƃ���
    mnu_bdinitdsp.Enabled = False
    mnu_gyoin.Enabled = False
    mnu_gyodel.Enabled = False
    
    '�������������s�\�Ƃ���
    mnu_showwnd.Enabled = True
    
    CurrentLine = -1    '�w�b�_��\���l���Z�b�g
End Sub

Private Sub txt_HDkouza_KeyDown(KeyCode As Integer, Shift As Integer)
    
    '�E��󉟉���
    If KeyCode = vbKeyRight Then
        If txt_HDkouza.SelStart < (10 - 1) Then
            txt_HDkouza.SelStart = txt_HDkouza.SelStart + 1
            
        '�J�[�\�����E�[�ɗ����玟�̍��ڂֈړ�
        Else
            intChkKb = 1                            '������������ނ̓��̓`�F�b�N
            txt_BDdkbid(0).SetFocus                 '������ʍ��ڂֈړ�
        End If
        txt_HDkouza.SelLength = 1
    
    'Backspace or ����󉟉���
    ElseIf KeyCode = vbKeyBack Or KeyCode = vbKeyLeft Then
        If txt_HDkouza.SelStart > 0 Then
            txt_HDkouza.SelStart = txt_HDkouza.SelStart - 1
        End If
        txt_HDkouza.SelLength = 1
        
    '���󉟉���
    ElseIf KeyCode = vbKeyUp Then
        '
        
    '����󉟉���
    ElseIf KeyCode = vbKeyDown Then
        intChkKb = 1                                '������������ނ̓��̓`�F�b�N
        txt_BDdkbid(0).SetFocus                     '������ʍ��ڂֈړ�
        
    'Enter������
    ElseIf KeyCode = vbKeyReturn Then
        intChkKb = 1                                '������������ނ̓��̓`�F�b�N
        txt_BDdkbid(0).SetFocus                     '������ʍ��ڂֈړ�
        
    'Delete������
    ElseIf KeyCode = vbKeyDelete Then
        Exit Sub
    
    End If
    KeyCode = 0
End Sub

Private Sub txt_HDkouza_KeyPress(KeyAscii As Integer)
    '�A���t�@�x�b�g��������啶���ɕϊ�����
    If Chr(KeyAscii) Like "[a-z]" Then
        KeyAscii = KeyAscii - 32
    End If
End Sub

Private Sub txt_HDkouza_LostFocus()
    '������׸ނ������Ă��Ȃ��Ƃ��͎��s���Ȃ�
    If blnUsableEvent = False Then Exit Sub
    
    '���̓`�F�b�N(�󔒂͖���)
    chkHDkouza
    '�w�i�F�𔒂ɖ߂�
    txt_HDkouza.BackColor = vbWhite
End Sub

'���ו�������ʃ{�^���N���b�N��
Private Sub cmd_BDdkbid_Click()
    If CurrentLine >= 0 Then
        '���X�g��\��
        WLS_LIST1.Show vbModal
        Unload WLS_LIST1
        
        txt_BDdkbid(CurrentLine).SetFocus
        If WLSTBD_RTNCODE <> "" Then
            txt_BDdkbid(CurrentLine).Text = WLSTBD_RTNCODE
            txt_BDkouza(CurrentLine).SetFocus
        End If
    End If
End Sub

'���ו���������{�^���N���b�N��
Private Sub cmd_BDkouza_Click()
    If CurrentLine >= 0 Then
        '���X�g��\��
        WLS_LIST2.Show vbModal
        Unload WLS_LIST2
        
        txt_BDkouza(CurrentLine).SetFocus
        If WLSKOZ_RTNCODE <> "" Then
            txt_BDkouza(CurrentLine).Text = WLSKOZ_RTNCODE
            txt_BDnyukn(CurrentLine).SetFocus
        End If
    End If
End Sub

'�w�b�_����������{�^���N���b�N��
Private Sub cmd_HDkouza_Click()
    '���X�g��\��
    WLS_LIST2.Show vbModal
    Unload WLS_LIST2
    
    txt_HDkouza.SetFocus
    If WLSKOZ_RTNCODE <> "" Then
        txt_HDkouza.Text = WLSKOZ_RTNCODE
        txt_BDdkbid(0).SetFocus
    End If
End Sub

