VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   Appearance      =   0  '�ׯ�
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�J�����_�[�}�X�^�o�^�^����"
   ClientHeight    =   10395
   ClientLeft      =   555
   ClientTop       =   750
   ClientWidth     =   10710
   FillColor       =   &H00FF0000&
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
      Size            =   9.75
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   Icon            =   "CLDMT51.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   PaletteMode     =   1  'Z ���ް
   ScaleHeight     =   10395
   ScaleWidth      =   10710
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   362
      TabStop         =   0   'False
      Top             =   9375
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   361
      TabStop         =   0   'False
      Top             =   9375
      Width           =   765
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   356
      TabStop         =   0   'False
      Top             =   9120
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   355
      TabStop         =   0   'False
      Top             =   9120
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   345
      TabStop         =   0   'False
      Top             =   7335
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   344
      TabStop         =   0   'False
      Top             =   7335
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   337
      TabStop         =   0   'False
      Top             =   7590
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   336
      TabStop         =   0   'False
      Top             =   7590
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   329
      TabStop         =   0   'False
      Top             =   7845
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   328
      TabStop         =   0   'False
      Top             =   7845
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   321
      TabStop         =   0   'False
      Top             =   8100
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   320
      TabStop         =   0   'False
      Top             =   8100
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   313
      TabStop         =   0   'False
      Top             =   8355
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   312
      TabStop         =   0   'False
      Top             =   8355
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   305
      TabStop         =   0   'False
      Top             =   8610
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   304
      TabStop         =   0   'False
      Top             =   8610
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   297
      TabStop         =   0   'False
      Top             =   8865
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   296
      TabStop         =   0   'False
      Top             =   8865
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   268
      TabStop         =   0   'False
      Top             =   5550
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   267
      TabStop         =   0   'False
      Top             =   5550
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   260
      TabStop         =   0   'False
      Top             =   5805
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   259
      TabStop         =   0   'False
      Top             =   5805
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   252
      TabStop         =   0   'False
      Top             =   6060
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   251
      TabStop         =   0   'False
      Top             =   6060
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   244
      TabStop         =   0   'False
      Top             =   6315
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   243
      TabStop         =   0   'False
      Top             =   6315
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   236
      TabStop         =   0   'False
      Top             =   6570
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   235
      TabStop         =   0   'False
      Top             =   6570
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   228
      TabStop         =   0   'False
      Top             =   6825
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   227
      TabStop         =   0   'False
      Top             =   6825
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   220
      TabStop         =   0   'False
      Top             =   7080
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   219
      TabStop         =   0   'False
      Top             =   7080
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   191
      TabStop         =   0   'False
      Top             =   3765
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   190
      TabStop         =   0   'False
      Top             =   3765
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   183
      TabStop         =   0   'False
      Top             =   4020
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   182
      TabStop         =   0   'False
      Top             =   4020
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   175
      TabStop         =   0   'False
      Top             =   4275
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   174
      TabStop         =   0   'False
      Top             =   4275
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   167
      TabStop         =   0   'False
      Top             =   4530
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   166
      TabStop         =   0   'False
      Top             =   4530
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   159
      TabStop         =   0   'False
      Top             =   4785
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   158
      TabStop         =   0   'False
      Top             =   4785
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   151
      TabStop         =   0   'False
      Top             =   5040
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   150
      TabStop         =   0   'False
      Top             =   5040
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   143
      TabStop         =   0   'False
      Top             =   5295
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   142
      TabStop         =   0   'False
      Top             =   5295
      Width           =   690
   End
   Begin VB.TextBox HD_IN_TANCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   2  '��
      Left            =   7515
      MaxLength       =   10
      TabIndex        =   92
      Text            =   "XXXXX6"
      Top             =   660
      Width           =   765
   End
   Begin VB.TextBox HD_IN_TANNM 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   345
      IMEMode         =   4  '�S�p�Ђ炪��
      Left            =   8265
      MaxLength       =   24
      TabIndex        =   91
      Text            =   "MMMMMMMMM1MMMMMMMMM2"
      Top             =   660
      Width           =   2280
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   83
      TabStop         =   0   'False
      Top             =   3510
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   82
      TabStop         =   0   'False
      Top             =   3510
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   75
      TabStop         =   0   'False
      Top             =   3255
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   74
      TabStop         =   0   'False
      Top             =   3255
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   67
      TabStop         =   0   'False
      Top             =   3000
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   66
      TabStop         =   0   'False
      Top             =   3000
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   62
      TabStop         =   0   'False
      Top             =   2745
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   61
      TabStop         =   0   'False
      Top             =   2745
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   58
      TabStop         =   0   'False
      Top             =   2490
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   57
      TabStop         =   0   'False
      Top             =   2490
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   54
      TabStop         =   0   'False
      Top             =   2235
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   53
      TabStop         =   0   'False
      Top             =   2235
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   50
      TabStop         =   0   'False
      Top             =   1980
      Width           =   690
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   49
      TabStop         =   0   'False
      Top             =   1980
      Width           =   765
   End
   Begin VB.TextBox BD_WKKBNM 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   2490
      MaxLength       =   50
      TabIndex        =   42
      TabStop         =   0   'False
      Text            =   "M2"
      Top             =   1725
      Width           =   690
   End
   Begin VB.TextBox HD_CLDDT 
      Appearance      =   0  '�ׯ�
      Height          =   330
      IMEMode         =   2  '��
      Left            =   1335
      MaxLength       =   50
      TabIndex        =   1
      Text            =   "9999/99"
      Top             =   795
      Width           =   900
   End
   Begin VB.TextBox HD_UPDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      Height          =   7920
      IMEMode         =   2  '��
      Left            =   945
      MaxLength       =   8
      TabIndex        =   37
      TabStop         =   0   'False
      Text            =   "XXXX"
      Top             =   1725
      Width           =   810
   End
   Begin VB.TextBox BD_CLDT 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   1740
      MaxLength       =   8
      TabIndex        =   36
      TabStop         =   0   'False
      Text            =   "99"
      Top             =   1725
      Width           =   765
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   735
      Index           =   16
      Left            =   -45
      TabIndex        =   33
      Top             =   9705
      Width           =   15420
      _ExtentX        =   27199
      _ExtentY        =   1296
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
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
         Index           =   17
         Left            =   675
         TabIndex        =   34
         Top             =   135
         Width           =   9825
         _ExtentX        =   17330
         _ExtentY        =   820
         ForeColor       =   0
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
         Begin VB.TextBox TX_Message 
            Appearance      =   0  '�ׯ�
            BackColor       =   &H8000000F&
            BorderStyle     =   0  '�Ȃ�
            ForeColor       =   &H00000000&
            Height          =   240
            Left            =   90
            MultiLine       =   -1  'True
            TabIndex        =   35
            Text            =   "CLDMT51.frx":030A
            Top             =   90
            Width           =   7350
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "CLDMT51.frx":0341
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   645
      Index           =   0
      Left            =   0
      TabIndex        =   30
      Top             =   10635
      Width           =   13605
      _ExtentX        =   16695
      _ExtentY        =   820
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
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
         TabIndex        =   32
         Top             =   45
         Width           =   330
      End
      Begin VB.TextBox TX_Mode 
         Appearance      =   0  '�ׯ�
         BackColor       =   &H00FFC0FF&
         Height          =   375
         Left            =   12195
         TabIndex        =   31
         Text            =   "Ӱ��"
         Top             =   45
         Width           =   870
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   2
         Left            =   7470
         Picture         =   "CLDMT51.frx":04CB
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   7155
         Picture         =   "CLDMT51.frx":0655
         Top             =   45
         Width           =   300
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   6660
         Picture         =   "CLDMT51.frx":07DF
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_SelectCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   6300
         Picture         =   "CLDMT51.frx":0969
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   3465
         Picture         =   "CLDMT51.frx":0AF3
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_DELETEDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3105
         Picture         =   "CLDMT51.frx":0C7D
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   2745
         Picture         =   "CLDMT51.frx":0E07
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_INSERTDE 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   2385
         Picture         =   "CLDMT51.frx":0F91
         Top             =   45
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5850
         Picture         =   "CLDMT51.frx":111B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_NEXTCM 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   5490
         Picture         =   "CLDMT51.frx":176D
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   4770
         Picture         =   "CLDMT51.frx":1DBF
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   5130
         Picture         =   "CLDMT51.frx":2411
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   1530
         Picture         =   "CLDMT51.frx":2A63
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   3915
         Picture         =   "CLDMT51.frx":2BED
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   495
         Picture         =   "CLDMT51.frx":2D77
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   135
         Picture         =   "CLDMT51.frx":2F01
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Slist 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   4275
         Picture         =   "CLDMT51.frx":308B
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Hardcopy 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1890
         Picture         =   "CLDMT51.frx":3215
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   855
         Picture         =   "CLDMT51.frx":339F
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   1
         Left            =   1215
         Picture         =   "CLDMT51.frx":39F1
         Top             =   45
         Visible         =   0   'False
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   555
      Index           =   15
      Left            =   -45
      TabIndex        =   28
      Top             =   0
      Width           =   15420
      _ExtentX        =   27199
      _ExtentY        =   979
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
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
         Left            =   8900
         TabIndex        =   29
         Top             =   105
         Width           =   1680
         _ExtentX        =   2963
         _ExtentY        =   582
         ForeColor       =   0
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
      Begin VB.Image CM_EndCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   225
         Picture         =   "CLDMT51.frx":4043
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_NEXTCm 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1380
         Picture         =   "CLDMT51.frx":41CD
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_Execute 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   585
         Picture         =   "CLDMT51.frx":481F
         Top             =   90
         Width           =   360
      End
      Begin VB.Image CM_PREV 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Left            =   1020
         Picture         =   "CLDMT51.frx":4E71
         Top             =   90
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   600
         Left            =   -60
         Top             =   -45
         Width           =   15330
      End
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   5
      Left            =   2490
      TabIndex        =   27
      Top             =   1290
      Width           =   690
      _ExtentX        =   1217
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "�j��"
      OutLine         =   -1  'True
   End
   Begin VB.Timer TM_StartUp 
      Enabled         =   0   'False
      Interval        =   1
      Left            =   43380
      Top             =   43380
   End
   Begin VB.TextBox TX_CursorRest 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   375
      IMEMode         =   2  '��
      Left            =   43380
      TabIndex        =   0
      Top             =   43380
      Width           =   330
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   330
      Index           =   2
      Left            =   180
      TabIndex        =   41
      Top             =   795
      Width           =   1170
      _ExtentX        =   2064
      _ExtentY        =   582
      ForeColor       =   0
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
      Caption         =   "*�o�^�N��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   4
      Left            =   1740
      TabIndex        =   90
      Top             =   1290
      Width           =   765
      _ExtentX        =   1349
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "���t"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   345
      Index           =   1
      Left            =   6300
      TabIndex        =   93
      Top             =   660
      Width           =   1230
      _ExtentX        =   2170
      _ExtentY        =   609
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   8
      BevelOuter      =   1
      Caption         =   "���͒S����"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   3
      Left            =   945
      TabIndex        =   116
      Top             =   1290
      Width           =   810
      _ExtentX        =   1429
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "Ӱ��"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   990
      MaxLength       =   50
      TabIndex        =   370
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   990
      MaxLength       =   50
      TabIndex        =   371
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   990
      MaxLength       =   50
      TabIndex        =   372
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   990
      MaxLength       =   50
      TabIndex        =   373
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   990
      MaxLength       =   50
      TabIndex        =   374
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   990
      MaxLength       =   50
      TabIndex        =   375
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   990
      MaxLength       =   50
      TabIndex        =   376
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   990
      MaxLength       =   50
      TabIndex        =   377
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   990
      MaxLength       =   50
      TabIndex        =   378
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   990
      MaxLength       =   50
      TabIndex        =   379
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   990
      MaxLength       =   50
      TabIndex        =   380
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   990
      MaxLength       =   50
      TabIndex        =   381
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   990
      MaxLength       =   50
      TabIndex        =   382
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   990
      MaxLength       =   50
      TabIndex        =   383
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   990
      MaxLength       =   50
      TabIndex        =   384
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   990
      MaxLength       =   50
      TabIndex        =   385
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   990
      MaxLength       =   50
      TabIndex        =   386
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   990
      MaxLength       =   50
      TabIndex        =   387
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   990
      MaxLength       =   50
      TabIndex        =   388
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   990
      MaxLength       =   50
      TabIndex        =   389
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   990
      MaxLength       =   50
      TabIndex        =   390
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   990
      MaxLength       =   50
      TabIndex        =   391
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   990
      MaxLength       =   50
      TabIndex        =   392
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   990
      MaxLength       =   50
      TabIndex        =   393
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   990
      MaxLength       =   50
      TabIndex        =   394
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   990
      MaxLength       =   50
      TabIndex        =   395
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   990
      MaxLength       =   50
      TabIndex        =   396
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   990
      MaxLength       =   50
      TabIndex        =   397
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   990
      MaxLength       =   50
      TabIndex        =   398
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   990
      MaxLength       =   50
      TabIndex        =   399
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin VB.TextBox BD_WKKB 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   990
      MaxLength       =   50
      TabIndex        =   400
      TabStop         =   0   'False
      Text            =   "X"
      Top             =   1400
      Visible         =   0   'False
      Width           =   600
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   9
      Left            =   6930
      TabIndex        =   97
      Top             =   1290
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "���Y�ғ��敪"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   8
      Left            =   5535
      TabIndex        =   45
      Top             =   1290
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "�����ғ��敪"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   10
      Left            =   8325
      TabIndex        =   44
      Top             =   1290
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "��s�ғ��敪"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   7
      Left            =   4140
      TabIndex        =   43
      Top             =   1290
      Width           =   1410
      _ExtentX        =   2487
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "�c�Ɠ��敪"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   6
      Left            =   3165
      TabIndex        =   38
      Top             =   1290
      Width           =   990
      _ExtentX        =   1746
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   "�j�Փ�"
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   2
      Text            =   "X"
      Top             =   1725
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   3
      Text            =   "X"
      Top             =   1725
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   6
      Text            =   "X"
      Top             =   1725
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   4
      Text            =   "X"
      Top             =   1725
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   7
      Top             =   1980
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   8
      Top             =   1980
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   11
      Top             =   1980
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   9
      Top             =   1980
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   12
      Top             =   2235
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   13
      Top             =   2235
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   16
      Top             =   2235
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   14
      Top             =   2235
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   17
      Top             =   2490
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   18
      Top             =   2490
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   21
      Top             =   2490
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   19
      Top             =   2490
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   22
      Top             =   2745
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   23
      Top             =   2745
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   26
      Top             =   2745
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   24
      Top             =   2745
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   65
      Top             =   3000
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   68
      Top             =   3000
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   69
      Top             =   3000
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   70
      Top             =   3000
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   73
      Top             =   3255
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   76
      Top             =   3255
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   77
      Top             =   3255
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   78
      Top             =   3255
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   81
      Top             =   3510
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   84
      Top             =   3510
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   85
      Top             =   3510
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   86
      Top             =   3510
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   7
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   94
      Top             =   3510
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   6
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   95
      Top             =   3255
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   5
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   96
      Top             =   3000
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   4
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   25
      Top             =   2745
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   3
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   20
      Top             =   2490
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   2
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   15
      Top             =   2235
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   1
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   10
      Top             =   1980
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   0
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   5
      Text            =   "X"
      Top             =   1725
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   131
      Top             =   3765
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   132
      Top             =   4020
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   133
      Top             =   4275
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   134
      Top             =   4530
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   135
      Top             =   4785
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   136
      Top             =   5040
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   137
      Top             =   5295
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   139
      Top             =   5295
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   140
      Top             =   5295
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   141
      Top             =   5295
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   14
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   144
      Top             =   5295
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   147
      Top             =   5040
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   148
      Top             =   5040
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   149
      Top             =   5040
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   13
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   152
      Top             =   5040
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   155
      Top             =   4785
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   156
      Top             =   4785
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   157
      Top             =   4785
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   12
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   160
      Top             =   4785
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   163
      Top             =   4530
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   164
      Top             =   4530
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   165
      Top             =   4530
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   11
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   168
      Top             =   4530
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   171
      Top             =   4275
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   172
      Top             =   4275
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   173
      Top             =   4275
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   10
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   176
      Top             =   4275
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   179
      Top             =   4020
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   180
      Top             =   4020
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   181
      Top             =   4020
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   9
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   184
      Top             =   4020
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   187
      Top             =   3765
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   188
      Top             =   3765
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   189
      Top             =   3765
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   8
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   192
      Top             =   3765
      Width           =   990
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   208
      Top             =   5550
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   209
      Top             =   5805
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   210
      Top             =   6060
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   211
      Top             =   6315
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   212
      Top             =   6570
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   213
      Top             =   6825
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   214
      Top             =   7080
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   216
      Top             =   7080
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   217
      Top             =   7080
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   218
      Top             =   7080
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   21
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   221
      Top             =   7080
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   224
      Top             =   6825
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   225
      Top             =   6825
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   226
      Top             =   6825
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   20
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   229
      Top             =   6825
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   232
      Top             =   6570
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   233
      Top             =   6570
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   234
      Top             =   6570
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   19
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   237
      Top             =   6570
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   240
      Top             =   6315
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   241
      Top             =   6315
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   242
      Top             =   6315
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   18
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   245
      Top             =   6315
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   248
      Top             =   6060
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   249
      Top             =   6060
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   250
      Top             =   6060
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   17
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   253
      Top             =   6060
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   256
      Top             =   5805
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   257
      Top             =   5805
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   258
      Top             =   5805
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   16
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   261
      Top             =   5805
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   264
      Top             =   5550
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   265
      Top             =   5550
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   266
      Top             =   5550
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   15
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   269
      Top             =   5550
      Width           =   990
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   285
      Top             =   7335
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   286
      Top             =   7590
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   287
      Top             =   7845
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   288
      Top             =   8100
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   289
      Top             =   8355
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   290
      Top             =   8610
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   291
      Top             =   8865
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   293
      Top             =   8865
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   294
      Top             =   8865
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   295
      Top             =   8865
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   28
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   298
      Top             =   8865
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   301
      Top             =   8610
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   302
      Top             =   8610
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   303
      Top             =   8610
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   27
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   306
      Top             =   8610
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   309
      Top             =   8355
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   310
      Top             =   8355
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   311
      Top             =   8355
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   26
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   314
      Top             =   8355
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   317
      Top             =   8100
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   318
      Top             =   8100
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   319
      Top             =   8100
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   25
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   322
      Top             =   8100
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   325
      Top             =   7845
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   326
      Top             =   7845
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   327
      Top             =   7845
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   24
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   330
      Top             =   7845
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   333
      Top             =   7590
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   334
      Top             =   7590
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   335
      Top             =   7590
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   23
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   338
      Top             =   7590
      Width           =   990
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   341
      Top             =   7335
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   342
      Top             =   7335
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   343
      Top             =   7335
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   22
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   346
      Top             =   7335
      Width           =   990
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   350
      Top             =   9120
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   352
      Top             =   9120
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   353
      Top             =   9120
      Width           =   1410
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   354
      Top             =   9120
      Width           =   1410
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   29
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   357
      Top             =   9120
      Width           =   990
   End
   Begin VB.TextBox BD_CLDHLKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   360
      Top             =   9375
      Width           =   990
   End
   Begin VB.TextBox BD_SLDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   4140
      MaxLength       =   30
      TabIndex        =   363
      Top             =   9375
      Width           =   1410
   End
   Begin VB.TextBox BD_BNKKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   8325
      MaxLength       =   30
      TabIndex        =   364
      Top             =   9375
      Width           =   1410
   End
   Begin VB.TextBox BD_DTBKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   5535
      MaxLength       =   30
      TabIndex        =   365
      Top             =   9375
      Width           =   1410
   End
   Begin VB.TextBox BD_PRDKDKB 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   2  '��
      Index           =   30
      Left            =   6930
      MaxLength       =   30
      TabIndex        =   367
      Top             =   9375
      Width           =   1410
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   14
      Left            =   6570
      TabIndex        =   115
      Top             =   1290
      Width           =   1200
      _ExtentX        =   2117
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   $"CLDMT51.frx":54C3
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   13
      Left            =   5460
      TabIndex        =   114
      Top             =   1290
      Width           =   1125
      _ExtentX        =   1984
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   $"CLDMT51.frx":54D6
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   12
      Left            =   4275
      TabIndex        =   47
      Top             =   1290
      Width           =   1200
      _ExtentX        =   2117
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   $"CLDMT51.frx":54ED
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D1 
      Height          =   450
      Index           =   11
      Left            =   3165
      TabIndex        =   39
      Top             =   1290
      Width           =   1125
      _ExtentX        =   1984
      _ExtentY        =   794
      ForeColor       =   0
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
      Caption         =   $"CLDMT51.frx":5504
      OutLine         =   -1  'True
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   40
      TabStop         =   0   'False
      Text            =   "99,999"
      Top             =   1725
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   46
      TabStop         =   0   'False
      Text            =   "99,999"
      Top             =   1725
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   48
      TabStop         =   0   'False
      Top             =   1980
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   51
      TabStop         =   0   'False
      Top             =   1980
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   52
      TabStop         =   0   'False
      Top             =   2235
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   55
      TabStop         =   0   'False
      Top             =   2235
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   56
      TabStop         =   0   'False
      Top             =   2490
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   59
      TabStop         =   0   'False
      Top             =   2490
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   60
      TabStop         =   0   'False
      Top             =   2745
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   63
      TabStop         =   0   'False
      Top             =   2745
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   64
      TabStop         =   0   'False
      Top             =   3000
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   71
      TabStop         =   0   'False
      Top             =   3000
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   72
      TabStop         =   0   'False
      Top             =   3255
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   79
      TabStop         =   0   'False
      Top             =   3255
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   80
      TabStop         =   0   'False
      Top             =   3510
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   87
      TabStop         =   0   'False
      Top             =   3510
      Width           =   1200
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   98
      TabStop         =   0   'False
      Top             =   3510
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   7
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   99
      TabStop         =   0   'False
      Top             =   3510
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   100
      TabStop         =   0   'False
      Top             =   3255
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   6
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   101
      TabStop         =   0   'False
      Top             =   3255
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   102
      TabStop         =   0   'False
      Top             =   3000
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   5
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   103
      TabStop         =   0   'False
      Top             =   3000
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   104
      TabStop         =   0   'False
      Top             =   2745
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   4
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   105
      TabStop         =   0   'False
      Top             =   2745
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   106
      TabStop         =   0   'False
      Top             =   2490
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   3
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   107
      TabStop         =   0   'False
      Top             =   2490
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   108
      TabStop         =   0   'False
      Top             =   2235
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   2
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   109
      TabStop         =   0   'False
      Top             =   2235
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   110
      TabStop         =   0   'False
      Top             =   1980
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   1
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   111
      TabStop         =   0   'False
      Top             =   1980
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   112
      TabStop         =   0   'False
      Text            =   "99,999"
      Top             =   1725
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   0
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   113
      TabStop         =   0   'False
      Text            =   "99,999"
      Top             =   1725
      Width           =   1125
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   117
      TabStop         =   0   'False
      Top             =   3765
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   118
      TabStop         =   0   'False
      Top             =   3765
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   119
      TabStop         =   0   'False
      Top             =   4020
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   120
      TabStop         =   0   'False
      Top             =   4020
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   121
      TabStop         =   0   'False
      Top             =   4275
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   122
      TabStop         =   0   'False
      Top             =   4275
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   123
      TabStop         =   0   'False
      Top             =   4530
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   124
      TabStop         =   0   'False
      Top             =   4530
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   125
      TabStop         =   0   'False
      Top             =   4785
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   126
      TabStop         =   0   'False
      Top             =   4785
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   127
      TabStop         =   0   'False
      Top             =   5040
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   128
      TabStop         =   0   'False
      Top             =   5040
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   129
      TabStop         =   0   'False
      Top             =   5295
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   130
      TabStop         =   0   'False
      Top             =   5295
      Width           =   1200
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   138
      TabStop         =   0   'False
      Top             =   5295
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   14
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   145
      TabStop         =   0   'False
      Top             =   5295
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   146
      TabStop         =   0   'False
      Top             =   5040
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   13
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   153
      TabStop         =   0   'False
      Top             =   5040
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   154
      TabStop         =   0   'False
      Top             =   4785
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   12
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   161
      TabStop         =   0   'False
      Top             =   4785
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   162
      TabStop         =   0   'False
      Top             =   4530
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   11
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   169
      TabStop         =   0   'False
      Top             =   4530
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   170
      TabStop         =   0   'False
      Top             =   4275
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   10
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   177
      TabStop         =   0   'False
      Top             =   4275
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   178
      TabStop         =   0   'False
      Top             =   4020
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   9
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   185
      TabStop         =   0   'False
      Top             =   4020
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   186
      TabStop         =   0   'False
      Top             =   3765
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   8
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   193
      TabStop         =   0   'False
      Top             =   3765
      Width           =   1125
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   194
      TabStop         =   0   'False
      Top             =   5550
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   195
      TabStop         =   0   'False
      Top             =   5550
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   196
      TabStop         =   0   'False
      Top             =   5805
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   197
      TabStop         =   0   'False
      Top             =   5805
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   198
      TabStop         =   0   'False
      Top             =   6060
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   199
      TabStop         =   0   'False
      Top             =   6060
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   200
      TabStop         =   0   'False
      Top             =   6315
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   201
      TabStop         =   0   'False
      Top             =   6315
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   202
      TabStop         =   0   'False
      Top             =   6570
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   203
      TabStop         =   0   'False
      Top             =   6570
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   204
      TabStop         =   0   'False
      Top             =   6825
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   205
      TabStop         =   0   'False
      Top             =   6825
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   206
      TabStop         =   0   'False
      Top             =   7080
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   207
      TabStop         =   0   'False
      Top             =   7080
      Width           =   1200
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   215
      TabStop         =   0   'False
      Top             =   7080
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   21
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   222
      TabStop         =   0   'False
      Top             =   7080
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   223
      TabStop         =   0   'False
      Top             =   6825
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   20
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   230
      TabStop         =   0   'False
      Top             =   6825
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   231
      TabStop         =   0   'False
      Top             =   6570
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   19
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   238
      TabStop         =   0   'False
      Top             =   6570
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   239
      TabStop         =   0   'False
      Top             =   6315
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   18
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   246
      TabStop         =   0   'False
      Top             =   6315
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   247
      TabStop         =   0   'False
      Top             =   6060
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   17
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   254
      TabStop         =   0   'False
      Top             =   6060
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   255
      TabStop         =   0   'False
      Top             =   5805
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   16
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   262
      TabStop         =   0   'False
      Top             =   5805
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   263
      TabStop         =   0   'False
      Top             =   5550
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   15
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   270
      TabStop         =   0   'False
      Top             =   5550
      Width           =   1125
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   271
      TabStop         =   0   'False
      Top             =   7335
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   272
      TabStop         =   0   'False
      Top             =   7335
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   273
      TabStop         =   0   'False
      Top             =   7590
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   274
      TabStop         =   0   'False
      Top             =   7590
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   275
      TabStop         =   0   'False
      Top             =   7845
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   276
      TabStop         =   0   'False
      Top             =   7845
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   277
      TabStop         =   0   'False
      Top             =   8100
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   278
      TabStop         =   0   'False
      Top             =   8100
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   279
      TabStop         =   0   'False
      Top             =   8355
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   280
      TabStop         =   0   'False
      Top             =   8355
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   281
      TabStop         =   0   'False
      Top             =   8610
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   282
      TabStop         =   0   'False
      Top             =   8610
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   283
      TabStop         =   0   'False
      Top             =   8865
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   284
      TabStop         =   0   'False
      Top             =   8865
      Width           =   1200
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   292
      TabStop         =   0   'False
      Top             =   8865
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   28
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   299
      TabStop         =   0   'False
      Top             =   8865
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   300
      TabStop         =   0   'False
      Top             =   8610
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   27
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   307
      TabStop         =   0   'False
      Top             =   8610
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   308
      TabStop         =   0   'False
      Top             =   8355
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   26
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   315
      TabStop         =   0   'False
      Top             =   8355
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   316
      TabStop         =   0   'False
      Top             =   8100
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   25
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   323
      TabStop         =   0   'False
      Top             =   8100
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   324
      TabStop         =   0   'False
      Top             =   7845
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   24
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   331
      TabStop         =   0   'False
      Top             =   7845
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   332
      TabStop         =   0   'False
      Top             =   7590
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   23
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   339
      TabStop         =   0   'False
      Top             =   7590
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   340
      TabStop         =   0   'False
      Top             =   7335
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   22
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   347
      TabStop         =   0   'False
      Top             =   7335
      Width           =   1125
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   348
      TabStop         =   0   'False
      Top             =   9120
      Width           =   1125
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   349
      TabStop         =   0   'False
      Top             =   9120
      Width           =   1200
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   351
      TabStop         =   0   'False
      Top             =   9120
      Width           =   1200
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   29
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   358
      TabStop         =   0   'False
      Top             =   9120
      Width           =   1125
   End
   Begin VB.TextBox BD_SLSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   3165
      MaxLength       =   30
      TabIndex        =   359
      TabStop         =   0   'False
      Top             =   9375
      Width           =   1125
   End
   Begin VB.TextBox BD_DTBKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   4275
      MaxLength       =   30
      TabIndex        =   366
      TabStop         =   0   'False
      Top             =   9375
      Width           =   1200
   End
   Begin VB.TextBox BD_CLDSMDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   6570
      MaxLength       =   30
      TabIndex        =   368
      TabStop         =   0   'False
      Top             =   9375
      Width           =   1200
   End
   Begin VB.TextBox BD_PRDKDDD 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H8000000F&
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      IMEMode         =   4  '�S�p�Ђ炪��
      Index           =   30
      Left            =   5460
      MaxLength       =   30
      TabIndex        =   369
      TabStop         =   0   'False
      Top             =   9375
      Width           =   1125
   End
   Begin VB.Label Label1 
      Caption         =   "�敪�E�E�E�@1:�ғ��� 9:��ғ���"
      Height          =   300
      Index           =   1
      Left            =   2460
      TabIndex        =   89
      Top             =   945
      Width           =   3375
   End
   Begin VB.Label Label1 
      Caption         =   "�j�Փ��E�E�E1:�ʏ� 9:�j��"
      Height          =   315
      Index           =   0
      Left            =   2460
      TabIndex        =   88
      Top             =   720
      Width           =   3135
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "����(&1)"
      Begin VB.Menu MN_Execute 
         Caption         =   "�o�^(&R)"
         Shortcut        =   ^R
      End
      Begin VB.Menu Bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I��(&X)"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "�ҏW(&2)"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "��ʏ�����(&S)"
         Shortcut        =   ^S
      End
      Begin VB.Menu MN_ClearItm 
         Caption         =   "���ڏ�����"
      End
      Begin VB.Menu MN_UnDoItem 
         Caption         =   "���ڕ���"
      End
      Begin VB.Menu MN_ClearDE 
         Caption         =   "���׍s������"
      End
      Begin VB.Menu MN_DeleteDE 
         Caption         =   "���׍s�폜(&T)"
         Shortcut        =   ^T
      End
      Begin VB.Menu MN_InsertDE 
         Caption         =   "���׍s�}��(&I)"
         Shortcut        =   ^I
      End
      Begin VB.Menu MN_UnDoDe 
         Caption         =   "���׍s����"
      End
      Begin VB.Menu Bar21 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Cut 
         Caption         =   "�؂���(&X)"
         Shortcut        =   ^X
      End
      Begin VB.Menu MN_Copy 
         Caption         =   "�R�s�[(&C)"
         Shortcut        =   ^C
      End
      Begin VB.Menu MN_Paste 
         Caption         =   "�\��t��(&V)"
         Shortcut        =   ^V
      End
   End
   Begin VB.Menu MN_Oprt 
      Caption         =   "�⏕(&3)"
      Begin VB.Menu MN_Prev 
         Caption         =   "�O��"
         Shortcut        =   {F8}
      End
      Begin VB.Menu MN_NextCm 
         Caption         =   "����"
         Shortcut        =   {F9}
      End
      Begin VB.Menu MN_SelectCm 
         Caption         =   "�ꗗ�\��"
         Shortcut        =   {F4}
      End
      Begin VB.Menu Bar31 
         Caption         =   "-"
      End
      Begin VB.Menu MN_Slist 
         Caption         =   "�E�C���h�E�\��(&L)"
         Shortcut        =   {F5}
      End
      Begin VB.Menu MN_UPDKB 
         Caption         =   "���[�h�ύX"
         Shortcut        =   {F6}
      End
   End
   Begin VB.Menu SM_ShortCut 
      Caption         =   "ShortCut"
      Visible         =   0   'False
      Begin VB.Menu SM_AllCopy 
         Caption         =   "���ړ��e�R�s�[(&C)"
      End
      Begin VB.Menu SM_FullPast 
         Caption         =   "���ڂɓ\��t��(&P)"
      End
      Begin VB.Menu SM_Esc 
         Caption         =   "�����(Esc)"
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
'���������������� �S��ʃ��[�J�����ʏ��� Start ��������������������������������
Private Const FM_PANEL3D1_CNT       As Integer = 18 '�p�l���R���g���[����
'*** End Of Generated Declaration Section ****

'=== ����ʂ̑S�����i�[ =================
Private Main_Inf As Cls_All
'=== ����ʂ̑S�����i�[ =================

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Init_Def_Dsp
    '   �T�v�F  ��ʂ̊e���ڏ���ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Dsp() As Integer

    Dim Index_Wk        As Integer
    Dim BD_Cnt          As Integer
    Dim Wk_Cnt          As Integer

'    gb_dateYM = "0000/00"
    gb_dateYM = ""
    gb_CldUpdFlg = False
    
    '��ʊ�b���ʏ��ݒ�
    Call CF_Init_Def_Dsp(Me, Main_Inf)

    '/////////////////////
    '// ���b�Z�[�W���ʐݒ�
    '/////////////////////
    Set Main_Inf.Dsp_IM_Denkyu = IM_Denkyu(0)
    Set Main_Inf.Off_IM_Denkyu = IM_Denkyu(1)
    Set Main_Inf.On_IM_Denkyu = IM_Denkyu(2)
    Set Main_Inf.Dsp_TX_Message = TX_Message

    '���׃y�[�W���ݒ�
    MinPageNum = 1
    MaxPageNum = 1
    NowPageNum = 1

    '��ʊ�b���ݒ�
    With Main_Inf.Dsp_Base
        .Dsp_Ctg = DSP_CTG_REVISION                 '��ʕ���
        .Item_Cnt = 425                             '��ʍ��ڐ�
        .Dsp_Body_Cnt = 30                          '��ʕ\�����א��i�O�F���ׂȂ��A�P�`�F�\�������א��j
        .Max_Body_Cnt = 0                           '�ő�\�����א��i�O�F���ׂȂ��A�P�`�F�ő喾�א��j
        .Body_Col_Cnt = 12                          '���ׂ̗񍀖ڐ�
        .Dsp_Body_Move_Qty = .Dsp_Body_Cnt - 1      '��ʈړ���
    End With

    '��ʍ��ڏ��
    ReDim Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Item_Cnt)

    '/////////////////////
    '// �S��ʗp����p���۰�
    '/////////////////////
    '�����ݒ�p�^�C�}�[
    Set Main_Inf.TM_StartUp_Ctl = TM_StartUp
    Main_Inf.TM_StartUp_Ctl.Interval = 1
    Main_Inf.TM_StartUp_Ctl.Enabled = True

    Index_Wk = 0
    '�J�[�\������p�e�L�X�g
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
    '// ���j���[���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '�����P
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
    '�o�^
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
'
'    Index_Wk = Index_Wk + 1
'    '��ʈ��
'    MN_HARDCOPY.Tag = Index_Wk
'    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = MN_HARDCOPY
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_MN
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_ELSE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_ELSE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = ""
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_ELSE
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
'    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�I��
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
    '�����Q(�ҏW)
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
    '��ʏ�����
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
    '���ڏ�����
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
    '���ڕ���
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
    '���׍s������
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
    '���׍s�폜
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
    '���׍s�}��
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
    '���׍s����
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
    '�؂���
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
    '�R�s�[
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
    '�\��t��
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
    '�����R(�⏕)
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
    '�O��
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
    '����
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
    '�ꗗ�\��
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
    '�E�C���h�E�\��
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
    '���[�h�ύX
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
    '���ړ��e�ɃR�s�[
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
    '������
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
    '���ڂɓ\��t��
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
    '�I���C���[�W
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
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_EndCm_Inf.Click_Off_Img = IM_EndCm(0)
    Set Main_Inf.IM_EndCm_Inf.Click_On_Img = IM_EndCm(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�o�^�C���[�W
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
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_Execute_Inf.Click_Off_Img = IM_Execute(0)
    Set Main_Inf.IM_Execute_Inf.Click_On_Img = IM_Execute(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�O�ŃC���[�W
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
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_PrevCm_Inf.Click_Off_Img = IM_PREV(0)
    Set Main_Inf.IM_PrevCm_Inf.Click_On_Img = IM_PREV(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '���ŃC���[�W
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
    '=== �Ұ�ސݒ� ======================
    Set Main_Inf.IM_NextCm_Inf.Click_Off_Img = IM_NEXTCM(0)
    Set Main_Inf.IM_NextCm_Inf.Click_On_Img = IM_NEXTCM(1)
    '=== �Ұ�ސݒ� ======================

    Index_Wk = Index_Wk + 1
    '�w�b�_�C���[�W
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
    '�������t
    SYSDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = SYSDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm = "SYSDT"
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
    '// �w�b�_���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '�o�^�N��
    HD_CLDDT.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_CLDDT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_YYYYMM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 7
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_YYYYMM_SLASH
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False

    Index_Wk = Index_Wk + 1
    '���͒S����(����)
    HD_IN_TANCD.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANCD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm = "HD_IN_TANCD"
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
    '���͒S����(����)
    HD_IN_TANNM.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_IN_TANNM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm = "HD_IN_TANNM"
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
    '���[�h
    HD_UPDKB.Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = HD_UPDKB
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD
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

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Head_Lst_Idx = Index_Wk      '�w�b�_���̍ŏI�̍��ڂ̲��ޯ��

    '///////////////
    '// �{�f�B���ҏW
    '///////////////
    Index_Wk = Index_Wk + 1
    '���t
    BD_CLDT(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDT(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_DATE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = ""
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Body_Fst_Idx = Index_Wk      '���ו��̺��۰ٔz��̍ŏ��̍��ڂ̲��ޯ��

    Index_Wk = Index_Wk + 1
    '�j���i�R�[�h�j
    BD_WKKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WKKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '�j���i���́j
    BD_WKKBNM(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WKKBNM(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_STR
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_NX
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 2
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 2
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
    '�j�Փ�
    BD_CLDHLKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDHLKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '�c�Ɠ��敪
    BD_SLDKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SLDKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '�����ғ��敪
    BD_DTBKDKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DTBKDKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '���Y�ғ��敪
    BD_PRDKDKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRDKDKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '��s�ғ��敪
    BD_BNKKDKB(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKKDKB(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_CODE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_X
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 1
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
    '�c�ƒʎZ�ғ�����
    BD_SLSMDD(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SLSMDD(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '�����ʎZ�ғ�����
    BD_DTBKDDD(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DTBKDDD(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '���Y�ʎZ�ғ�����
    BD_PRDKDDD(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRDKDDD(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    Index_Wk = Index_Wk + 1
    '����ʎZ�ғ�����
    BD_CLDSMDD(0).Tag = Index_Wk
    Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDSMDD(0)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Typ = IN_TYP_NUM
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.In_Str_Typ = IN_STR_TYP_KIN
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.MaxLengthB = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_MaxLengthB = 6
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Int_Fig = 5
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Fra_Fig = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Num_Sign_Fig = IN_NUM_ELSE
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Chr = Space(1)
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Fil_Point = FIL_POINT_RIGHT
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Fmt = DSP_FMT_KIN_1
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = 0
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = False
    Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True

    For BD_Cnt = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt

        Index_Wk = Index_Wk + 1
        '���t
        BD_CLDT(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDT(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�j���i�R�[�h�j
        BD_WKKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WKKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�j���i���́j
        BD_WKKBNM(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_WKKBNM(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�j�Փ�
        BD_CLDHLKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDHLKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�c�Ɠ��敪
        BD_SLDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SLDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�����ғ��敪
        BD_DTBKDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DTBKDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���Y�ғ��敪
        BD_PRDKDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRDKDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '��s�ғ��敪
        BD_BNKKDKB(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_BNKKDKB(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�c�ƒʎZ�ғ�����
        BD_SLSMDD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_SLSMDD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '�����ʎZ�ғ�����
        BD_DTBKDDD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_DTBKDDD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '���Y�ʎZ�ғ�����
        BD_PRDKDDD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_PRDKDDD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

        Index_Wk = Index_Wk + 1
        '����ʎZ�ғ�����
        BD_CLDSMDD(BD_Cnt).Tag = Index_Wk
        Set Main_Inf.Dsp_Sub_Inf(Index_Wk).Ctl = BD_CLDSMDD(BD_Cnt)
        Main_Inf.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index = BD_Cnt
        '���ו��̂P�s��̏���ݒ�
        Call CF_Copy_Def_Dsp_Body(Index_Wk, Main_Inf.Dsp_Base.Body_Col_Cnt, Main_Inf)

    Next

    '///////////////
    '// �t�b�^���ҏW
    '///////////////


    '///////////////////
    '// ���b�Z�[�W���ҏW
    '///////////////////
    Index_Wk = Index_Wk + 1
    '���b�Z�[�W
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

    '��ʊ�b���ݒ�
    Main_Inf.Dsp_Base.Foot_Fst_Idx = Index_Wk      '�t�b�^���̍ŏ��̍��ڂ̲��ޯ��

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
    '// ���̑��ҏW
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

    '��L�ݒ���e�����ۂ̺��۰قɐݒ肷��
    Call CF_Init_Item_Property(Main_Inf)
    '��ʍ��ڏ����Đݒ�
    Call CF_ReSet_Dsp_Sub_Inf(Main_Inf)

    '///////////////////
    '// ���ʍ��ڂ̍Đݒ�
    '///////////////////
    '�J�[�\������p�e�L�X�g
    TX_CursorRest.TabStop = False
    TX_Message.TabStop = False

'�r���������������������������������������������������������r
    '��ʕύX�Ȃ��Ƃ���
    gv_bolCLDMT51_INIT = False
    gv_bolInit = False
    gv_bolCLDMT51_LF_Enable = True
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyReturn
    '   �T�v�F  �e���ڂ�VBKEYRETURN����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyReturn(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRETURN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
        '�L�[�t���O�����ɖ߂�
        gv_bolKeyFlg = False
    End If
    '�擾���e�\��/�N���A
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
    
    If Chk_Move_Flg = True Then
'        '������ړ�����
''        Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
'        If SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf) = CHK_WARN Then
''            Call Ctl_MN_Execute_Click
'            Rtn_Chk = Ctl_MN_Execute_Click
'            If Rtn_Chk = CHK_OK Then
'                gv_bolCLDMT51_INIT = False
'            End If
'        End If
'
        '������ړ�����
        Call SSSMAIN0001.F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, Main_Inf)
        
        '�ŏI���ځi���Ɉړ��ł��Ȃ����ځj�̎��A�o�^�������s��
        If Move_Flg = False Then
'            Call Ctl_MN_Execute_Click
            If Ctl_MN_Execute_Click = CHK_OK Then
                gv_bolCLDMT51_INIT = False
            End If
        End If
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyRight
    '   �T�v�F  �e���ڂ�VBKEYRIGHT����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyRight(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer
'
'    Dim Move_Flg        As Boolean
'    Dim Rtn_Chk         As Integer
'    Dim Chk_Move_Flg    As Boolean
'    Dim Dsp_Mode        As Integer
'
'    Move_Flg = False
'    Chk_Move_Flg = True
'
'    'KEYRIGHT����
'    Rtn_Chk = SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'
'    If Move_Flg = True Then
'    '���̍��ڂֈړ������ꍇ
''        If Rtn_Chk = CHK_ERR_ELSE Then
''            Exit Function
''        End If
'
'        '�e���ڂ�����ٰ��
'        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)
'
'        If Rtn_Chk = CHK_OK Then
'        '�`�F�b�N�n�j��
'            '�擾���e�\��
'            Dsp_Mode = DSP_SET
'        Else
'        '�`�F�b�N�m�f��
'            '�擾���e�N���A
'            Dsp_Mode = DSP_CLR
'        End If
'        '�擾���e�\��/�N���A
'        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)
'
'        If Chk_Move_Flg = True Then
'
'            'KEYRIGHT����(̫����ړ��Ȃ�)
'            Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
'            '������ړ�����
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        Else
'            '������ړ��Ȃ�
'            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
'            '�I����Ԃ̐ݒ�i�����I���j
'            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
'            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
'            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
'        End If
'    End If
'

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYRIGHT����
    Rtn_Chk = SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        If Rtn_Chk = CHK_ERR_ELSE Then
            Exit Function
        End If
        
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYRIGHT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        '�擾���e�\��/�N���A
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'KEYRIGHT����(̫����ړ��Ȃ�)
            Call SSSMAIN0001.F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyDown
    '   �T�v�F  �e���ڂ�VBKEYDOWN����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyDown(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = False

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYDOWN, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYDOWN����
        Call F_Set_Down_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If
    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyLeft
    '   �T�v�F  �e���ڂ�VBKEYLEFT����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyLeft(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    'KEYLEFT����
'    Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)
    Rtn_Chk = SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        If Rtn_Chk = CHK_ERR_ELSE Then
            Exit Function
        End If
        
        '�e���ڂ�����ٰ��
        Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYLEFT, Chk_Move_Flg, Main_Inf)

        If Rtn_Chk = CHK_OK Then
        '�`�F�b�N�n�j��
            '�擾���e�\��
            Dsp_Mode = DSP_SET
        Else
        '�`�F�b�N�m�f��
            '�擾���e�N���A
            Dsp_Mode = DSP_CLR
        End If
        '�擾���e�\��/�N���A
        Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

        If Chk_Move_Flg = True Then
            'KEYLEFT����(̫����ړ�����)
            Call SSSMAIN0001.F_Set_Left_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf, True)
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '������ړ��Ȃ�
            Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
            '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        End If
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_VbKeyUp
    '   �T�v�F  �e���ڂ�VBKEYUP����
    '   �����F�@Cls_Dsp_Sub_Inf     :��ʍ��ڏ��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_VbKeyUp(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Integer

    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_Dsp_Sub_Inf, CHK_FROM_KEYUP, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call SSSMAIN0001.F_Dsp_Item_Detail(pm_Dsp_Sub_Inf, Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
    '������ړ�����
        'KEYUP����
        Call SSSMAIN0001.F_Set_Up_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, Main_Inf)

        If Move_Flg = True Then
        '���̍��ڂֈړ������ꍇ
            '������ړ�����
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
        Else
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)

            '���ڐF�ݒ�
            Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, Main_Inf)
        End If

    Else
    '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, Main_Inf)
        '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
        Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyDown
    '   �T�v�F  �e���ڂ�KEYDOWN����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '          pm_KeyCode   :�L�[�R�[�h
    '          pm_Shift     :shift�L�[�������
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyDown(pm_Ctl As Control, ByRef pm_KeyCode As Integer, pm_Shift As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg     As Boolean

' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C��
    'Enter���̂݃t���O��ON
    If pm_KeyCode = vbKeyReturn Then
        If gv_bolKeyFlg = True Then
            Exit Function
        End If

        gv_bolKeyFlg = True
    End If
' === 20060801 === INSERT E
    
    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    
    Select Case True
        '��������
        Case pm_KeyCode = vbKeyReturn And pm_Shift = 0
            pm_KeyCode = 0
            '����������
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyRight And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyRight(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyDown And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyDown(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyLeft And pm_Shift = 0
            pm_KeyCode = 0
            '������
            Call Ctl_Item_VbKeyLeft(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        '����
        Case pm_KeyCode = vbKeyUp And pm_Shift = 0
            '������
            pm_KeyCode = 0
            Call Ctl_Item_VbKeyUp(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'DELETE��
        Case pm_KeyCode = vbKeyDelete And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyDelete(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
        
        'INSERT��
        Case pm_KeyCode = vbKeyInsert And pm_Shift = 0
            pm_KeyCode = 0
            Call CF_Ctl_Item_KeyInsert(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        'TAB��
        Case pm_KeyCode = vbKeyF16
            pm_KeyCode = 0
            '����������
            Call Ctl_Item_VbKeyReturn(Main_Inf.Dsp_Sub_Inf(Trg_Index))

        'Shift+TAB��
        Case pm_KeyCode = vbKeyF15
            pm_KeyCode = 0
            '�O̫����ʒu�ֈړ�
            Call F_Set_Befe_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf)
    
' === 20060930 === INSERT S - ACE)Nagasawa �t�@���N�V�����L�[�����Ή�
        '�t�@���N�V�����L�[������
        Case pm_KeyCode >= vbKeyF1 And pm_KeyCode <= vbKeyF12
            '�t�@���N�V�����L�[���ʏ���
            Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
' === 20060930 === INSERT E -

        Case Else
            '�G���[�t���O�𗎂Ƃ�
            Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_DEF
        
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KEYUP
    '   �T�v�F  �e���ڂ�KEYUP����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyUp(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' === 20060801 === INSERT S - �G���^�[�L�[�A�łɂ��s��C��
    '�L�[�t���O�����ɖ߂�
    gv_bolKeyFlg = False
' === 20060801 === INSERT E -

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_LostFocus
    '   �T�v�F  �e���ڂ�LOSTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_LostFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index       As Integer
    Dim Act_Index       As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '����̫������۰َ擾
    Act_Index = CInt(Me.ActiveControl.Tag)

' === 20060702 === INSERT S
    '۽�̫������s����
    If Main_Inf.Dsp_Base.LostFocus_Flg = True Then
        Main_Inf.Dsp_Base.LostFocus_Flg = False
        Exit Function
    End If
' === 20060702 === INSERT E

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_LOSTFOCUS, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)

    If Chk_Move_Flg = True Then
        '������ړ�����
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)

        '����̫������۰ق̑I�������Đݒ�
        '�I����Ԃ̐ݒ�
        Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), 0)
        '���ڐF�ݒ�
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

    Else
        '������ړ��Ȃ�
        Call CF_Set_Item_SetFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_GotFocus
    '   �T�v�F  �e���ڂ�GOTFOCUS����
    '   �����F�@pm_Ctl      :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_GotFocus(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Rtn_Chk     As Integer
    Dim Move_Flg    As Boolean
    Dim Wk_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    '��ʒP�ʂ̏���(�����Ȃ�)
    '���ו��ł��ړ��O�����ו��łȂ��ꍇ
    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD _
    And Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area <> Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Cursor_Idx).Detail.In_Area Then

        'ͯ�ޕ�����
        Rtn_Chk = F_Ctl_Head_Chk(Main_Inf)

        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
    End If

' === 20060801 === INSERT S - ������ʕ\���{�^�������������Ƃ�������悤�ɂ���Ή�
    If TypeOf pm_Ctl Is SSCommand5 Then
        '������ʌďo�̏ꍇ�͏I��
        Exit Function
    End If

    If Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.In_Area = IN_AREA_DSP_BD Then
        '���׍s�R���g���[��������
        If Trg_Index >= Main_Inf.Dsp_Base.Body_Fst_Idx Then
            '���׌����{�^���̖��׍s���ϐ��ɓ����s����ݒ�
            For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
                If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index Then
                    '�ݒ�ς݂̏ꍇ�͏I��
                    Exit For
                End If
                Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index
            Next
        End If
    Else
        '���׌����{�^���̖��׍s���ϐ���������
        For Wk_Index = Main_Inf.Dsp_Base.Head2_Lst_Idx + 1 To Main_Inf.Dsp_Base.Body_Fst_Idx - 1
            If Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0 Then
                '�ݒ�ς݂̏ꍇ�͏I��
                Exit For
            End If
            Main_Inf.Dsp_Sub_Inf(Wk_Index).Detail.Body_Index = 0
        Next
    End If
' === 20060801 === INSERT E

    '����̫����擾����
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click
'    '���j���[�g�p�ې���
'    Call F_Ctl_MN_Enabled(Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_KeyPress
    '   �T�v�F  �e���ڂ�KEYPRESS����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           pm_KeyAscii     :�L�[��ASCII�R�[�h
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_KeyPress(pm_Ctl As Control, ByRef pm_KeyAscii As Integer) As Integer

    Dim Trg_Index    As Integer
    Dim Move_Flg        As Boolean
    Dim Rtn_Chk         As Integer
    Dim Chk_Move_Flg    As Boolean
    Dim Dsp_Mode        As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Move_Flg = False
    Chk_Move_Flg = True

    '����KEYPRESS����
    Rtn_Chk = CF_Ctl_Item_KeyPress(Main_Inf.Dsp_Sub_Inf(Trg_Index), pm_KeyAscii, Move_Flg, Main_Inf, False)

    If Move_Flg = True Then
    '���̍��ڂֈړ������ꍇ
        If Rtn_Chk <> CHK_OK Then
            Exit Function
        End If
            If Rtn_Chk = CHK_OK Then
            '�e���ڂ�����ٰ��
            Rtn_Chk = F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYPRESS, Chk_Move_Flg, Main_Inf)
    
            If Rtn_Chk = CHK_OK Then
            '�`�F�b�N�n�j��
                '�擾���e�\��
                Dsp_Mode = DSP_SET
            Else
            '�`�F�b�N�m�f��
                '�擾���e�N���A
                Dsp_Mode = DSP_CLR
            End If
            '�擾���e�\��/�N���A
            Call F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, Main_Inf)
    
            If Chk_Move_Flg = True Then
                '����̫����ʒu����E�ֈړ�
                Call F_Set_Right_Next_Focus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Move_Flg, Main_Inf, True)
                '������ړ�����
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            Else
                '�I����Ԃ̐ݒ�i�����I���j
                Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
    
                '���ڐF�ݒ�(�G���[����̫����Ȃ��̐F�ݒ�I�I)
                Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, Main_Inf)
            End If
    
        End If
    
    Else
        '���ڐF�ݒ�(���͊J�n�ŐF��̫�������̑O�i�F�����ɐݒ�I�I)
        Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, Main_Inf, ITEM_COLOR_KEYPRESS)
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Change
    '   �T�v�F  �e���ڂ�CHANGE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Change(pm_Ctl As Control) As Integer

    Dim Trg_Index    As Integer
    
    If Main_Inf.Dsp_Base.Change_Flg = True Then
        Main_Inf.Dsp_Base.Change_Flg = False
        Exit Function
    End If

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)
    
    '�G���[�t���O�𗎂Ƃ�
    Main_Inf.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_DEF
                    
    '����KEYCHANG����
    Call CF_Ctl_Item_Change(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
    '��ʒP�ʂ̏���(�����Ȃ�)
    
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseUp
    '   �T�v�F  �e���ڂ�MOUSEUP����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseUp(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case True
        Case TypeOf pm_Ctl Is TextBox
            '�I����Ԃ̐ݒ�i�����I���j
            Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)

        Case TypeOf pm_Ctl Is SSPanel5
            '�p�l���̏ꍇ
            Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case TypeOf pm_Ctl Is SSCommand5
            '�{�^���̏ꍇ
' 2006/11/28  ADD START  KUMEDA
            If Me.ActiveControl Is Nothing Then
                Exit Function
            End If
' 2006/11/28  ADD END

            If TypeOf Main_Inf.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)).Ctl Is SSCommand5 Then
                Call SSSMAIN0001.CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)
            End If

        Case TypeOf pm_Ctl Is Image
            '�C���[�W�̏ꍇ
            Select Case Trg_Index
                Case CInt(CM_EndCm.Tag)
                '�I���Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, False, Main_Inf)
                Case CInt(CM_Execute.Tag)
                '�o�^�Ұ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, False, Main_Inf)
'                Case CInt(CM_INSERTDE.Tag)
'                '���׍s�}���Ұ��
'                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, False, Main_Inf)
'                Case CInt(CM_DELETEDE.Tag)
'                '���׍s�폜�Ұ��
'                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, False, Main_Inf)
'                Case CInt(CM_SLIST.Tag)
'                '�����Ұ��
'                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, False, Main_Inf)
                Case CInt(CM_PREV.Tag)
                '�O�ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, False, Main_Inf)
                Case CInt(CM_NEXTCm.Tag)
                '���ŲҰ��
                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, False, Main_Inf)
'                Case CInt(CM_SelectCm.Tag)
'                '�ꗗ�\���Ұ��
'                    Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, False, Main_Inf)

            End Select
    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseMove
    '   �T�v�F  �e���ڂ�MOUSEMOVE����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseMove(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    Select Case Trg_Index
        Case CInt(Image1.Tag)
            '�Ұ�ނP������
            Call CF_Clr_Prompt(Main_Inf)

        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Prompt(IMG_ENDCM_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_Execute.Tag)
        '�o�^�Ұ��
            Call CF_Set_Prompt(IMG_EXECUTE_MSG_INF, COLOR_BLACK, Main_Inf)
'        Case CInt(CM_INSERTDE.Tag)
'        '���׍s�}���Ұ��
'            Call CF_Set_Prompt(IMG_INSERTDE_MSG_INF, COLOR_BLACK, Main_Inf)
'        Case CInt(CM_DELETEDE.Tag)
'        '���׍s�폜�Ұ��
'            Call CF_Set_Prompt(IMG_DELETEDE_MSG_INF, COLOR_BLACK, Main_Inf)
'        Case CInt(CM_SLIST.Tag)
'        '�����Ұ��
'            Call CF_Set_Prompt(IMG_SLIST_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_PREV.Tag)
        '�O�ŲҰ��
            Call CF_Set_Prompt(IMG_PREV_MSG_INF, COLOR_BLACK, Main_Inf)
        Case CInt(CM_NEXTCm.Tag)
        '���ŲҰ��
            Call CF_Set_Prompt(IMG_NEXTCM_MSG_INF, COLOR_BLACK, Main_Inf)
'        Case CInt(CM_SelectCm.Tag)
'        '�ꗗ�\���Ұ��
'            Call CF_Set_Prompt("�ꗗ�\�����܂��B", COLOR_BLACK, Main_Inf)

    End Select

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_MouseDown
    '   �T�v�F  �e���ڂ�MOUSEDOWN����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '           Button          Button          :�����L�[
    '           Shift           :�V�t�g�L�[�������
    '           X               :X���W
    '           Y               :Y���W
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_MouseDown(pm_Ctl As Control, Button As Integer, Shift As Integer, X As Single, Y As Single) As Integer

    Dim Trg_Index    As Integer
    Dim Act_Index    As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

' === 20060702 === INSERT S
    '��è�޺��۰ي������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)
' === 20060702 === INSERT E

    Select Case Trg_Index
        Case CInt(CM_EndCm.Tag)
        '�I���Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_EndCm_Inf, True, Main_Inf)

        Case CInt(CM_Execute.Tag)
        '�o�^�Ұ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Execute_Inf, True, Main_Inf)

'        Case CInt(CM_INSERTDE.Tag)
'        '���׍s�}���Ұ��
'            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_INSERTDE_Inf, True, Main_Inf)
'
'        Case CInt(CM_DELETEDE.Tag)
'        '���׍s�폜�Ұ��
'            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_DELETEDE_Inf, True, Main_Inf)
'
'        Case CInt(CM_SLIST.Tag)
'        '������ʕ\���Ұ��
'            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_Slist_Inf, True, Main_Inf)
'
        Case CInt(CM_PREV.Tag)
        '�O�ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_PrevCm_Inf, True, Main_Inf)

        Case CInt(CM_NEXTCm.Tag)
        '���ŲҰ��
            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_NextCm_Inf, True, Main_Inf)

'        Case CInt(CM_SelectCm.Tag)
'        '�ꗗ�\���Ұ��
'            Call CF_Set_Img(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.IM_SelectCm_Inf, True, Main_Inf)
'
    End Select

' === 20060702 === INSERT S
    '����MOUSEDOWN����
    Call SSSMAIN0001.CF_Ctl_Item_MouseDown(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf, Button, Shift, X, Y)
' === 20060702 === INSERT E

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_Item_Click
    '   �T�v�F  �e���ڂ�CLICK����
    '   �����F�@pm_Ctl          :�R���g���[���̃N���X��
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_Item_Click(pm_Ctl As Control) As Integer

    Dim Trg_Index   As Integer
    Dim Wk_Index    As Integer
    Dim RetnCd      As Integer
    Dim int_Chk     As Integer

    '�������ޯ���擾
    Trg_Index = CInt(pm_Ctl.Tag)

    RetnCd = -1

    Select Case Trg_Index

'        Case CInt(CM_SLIST.Tag), CInt(MN_Slist.Tag)
'            '�e������ʌďo
'            Call F_Ctl_CS(Main_Inf)
'
        Case CInt(CM_Execute.Tag), CInt(MN_Execute.Tag)
            '�o�^
'            Call Ctl_MN_Execute_Click
            int_Chk = Ctl_MN_Execute_Click
            If int_Chk = CHK_OK Then
                gv_bolCLDMT51_INIT = False
            End If

'        Case CInt(CM_INSERTDE.Tag), CInt(MN_InsertDE.Tag)
'            '���׍s�}��
'            Call Ctl_MN_InsertDE_Click
'
'        Case CInt(CM_DELETEDE.Tag), CInt(MN_DeleteDE.Tag)
'            '���׍s�폜
'            Call Ctl_MN_DeleteDE_Click
'
        Case CInt(CM_PREV.Tag), CInt(MN_Prev.Tag)
            '�O�ł�
            Call Ctl_CM_PREV_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

        Case CInt(CM_NEXTCm.Tag), CInt(MN_NextCm.Tag)
            '���ł�
            Call Ctl_CM_NEXTCM_Click(Main_Inf.Dsp_Sub_Inf(Trg_Index), Main_Inf)

'        Case CInt(CM_SelectCm.Tag), CInt(MN_SelectCm.Tag)
'            '�ꗗ�\��
'            Call Ctl_MN_SelectCm_Click
'
        '=============================================

        Case CInt(MN_Ctrl.Tag)
            '�����P
            Call Ctl_MN_Ctrl_Click

'        Case CInt(MN_HARDCOPY.Tag)
'            '��ʈ��
'            Call Ctl_MN_HARDCOPY_Click
'
        Case CInt(CM_EndCm.Tag), CInt(MN_EndCm.Tag)
            '�I��
            Call Ctl_MN_EndCm_Click
            Exit Function

        Case CInt(MN_EditMn.Tag)
            '�ҏW�Q
            Call Ctl_MN_EditMn_Click

        Case CInt(MN_APPENDC.Tag)
            '��ʏ�����
            Call Ctl_MN_APPENDC_Click

        Case CInt(MN_ClearItm.Tag)
            '���ڏ�����
            Call Ctl_MN_ClearItm_Click

        Case CInt(MN_UnDoItem.Tag)
            '���ڕ���
            Call Ctl_MN_UnDoItem_Click

        Case CInt(MN_ClearDE.Tag)
            '���׍s������
            Call Ctl_MN_ClearDE_Click

        Case CInt(MN_UnDoDe.Tag)
            '���׍s����
            Call Ctl_MN_UnDoDe_Click

        Case CInt(MN_Cut.Tag)
            '�؂���
            Call Ctl_MN_Cut_Click

        Case CInt(MN_Copy.Tag)
            '�R�s�[
            Call Ctl_MN_Copy_Click

        Case CInt(MN_Paste.Tag)
            '�\��t��
            Call Ctl_MN_Paste_Click

        Case CInt(MN_Oprt.Tag)
            '�⏕�R
            Call Ctl_MN_Oprt_Click

        Case CInt(MN_UPDKB.Tag)
            '���[�h�ύX
            Call Ctl_MN_UPDKB_Click

        Case CInt(SM_AllCopy.Tag)
            '���ړ��e�ɃR�s�[
            Call Ctl_SM_AllCopy_Click

        Case CInt(SM_Esc.Tag)
            '������
            Call Ctl_SM_Esc_Click

        Case CInt(SM_FullPast.Tag)
            '���ڂɓ\��t��
            Call Ctl_SM_FullPast_Click

    End Select

    '�X�e�[�^�X�o�[������
    Call CF_Clr_Prompt(Main_Inf)
    
'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
    '�y�[�W�J�ڃ{�^���������̕s��Ή��B�i�t�H�[�J�X�̒D������������j
    If gb_pageChange = True Then
        gb_txtChange = True
    End If
'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Ctrl_Click
    '   �T�v�F  ���j���[�����P�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Ctrl_Click() As Integer

    Dim Ant_Index   As Integer
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

'' 2007/01/11  START  ���ɖ߂�
''    '��o�^�����
''    If gb_CldUpdFlg = True Then
''        MN_Execute.Enabled = True
''    Else
''        MN_Execute.Enabled = False
''    End If
'    '��o�^�����
    MN_Execute.Enabled = CF_Jge_Enabled_MN_Execute(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'' 2007/01/11  END
'    '��폜�����
'    MN_DeleteCM.Enabled = CF_Jge_Enabled_MN_DeleteCM(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
'    '���ʈ�������
'    MN_HARDCOPY.Enabled = CF_Jge_Enabled_MN_HARDCOPY(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
     '��I�������
    MN_EndCm.Enabled = CF_Jge_Enabled_MN_EndCm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EditMn_Click
    '   �T�v�F  ���j���[�ҏW�Q�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EditMn_Click() As Integer

    Dim Ant_Index   As Integer
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Ant_Index = CInt(Me.ActiveControl.Tag)

    '���ʏ����������
    MN_APPENDC.Enabled = CF_Jge_Enabled_MN_APPENDC(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڏ����������
    MN_ClearItm.Enabled = CF_Jge_Enabled_MN_ClearItm(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����ڕ��������
    MN_UnDoItem.Enabled = CF_Jge_Enabled_MN_UnDoItem(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '����׍s�����������
'    MN_ClearDE.Enabled = CF_Jge_Enabled_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_ClearDE.Enabled = False
    '����׍s�폜�����
'    MN_DeleteDE.Enabled = CF_Jge_Enabled_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_DeleteDE.Enabled = False
    '����׍s�}�������
'    MN_InsertDE.Enabled = CF_Jge_Enabled_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_InsertDE.Enabled = False
    '����׍s���������
'    MN_UnDoDe.Enabled = CF_Jge_Enabled_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    MN_UnDoDe.Enabled = False
    '��؂��裔���
    MN_Cut.Enabled = CF_Jge_Enabled_MN_Cut(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��R�s�[�����
    MN_Copy.Enabled = CF_Jge_Enabled_MN_Copy(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)
    '��\��t�������
    MN_Paste.Enabled = CF_Jge_Enabled_MN_Paste(Main_Inf.Dsp_Sub_Inf(Ant_Index), Main_Inf)

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Oprt_Click
    '   �T�v�F  ���j���[�⏕�R�̎g�p�s�𐧌�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Oprt_Click() As Integer

    '��O�ţ������
    MN_Prev.Enabled = True
    '����ţ������
    MN_NextCm.Enabled = True
    '��ꗗ�\���������
    MN_SelectCm.Enabled = False
    '��E�C���h�E�\���������
    MN_Slist.Enabled = False
    '����[�h�ύX�������
    MN_UPDKB.Enabled = False

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Ctl_MN_Execute_Click
'   �T�v�F  �o�^
'   �����F�@�Ȃ�
'   �ߒl�F�@�Ȃ�
'   ���l�F  �S��ʃ��[�J�����ʏ���
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Execute_Click() As Integer

    Dim intRet          As Integer

    Ctl_MN_Execute_Click = CHK_OK
    
' 2007/01/11  DLT START  KUMEDA   *** �����`�F�b�N�̏ꏊ�ύX
'    '�J�����_�X�V�����������ꍇ�A�����s��Ȃ�
'    If gb_CldUpdFlg = False Then
'        Exit Function
'    End If
' 2007/01/11  DLT END

' === 20060825 === INSERT S
    '���s�O����
    If F_Chk_CM_Execute(Main_Inf) Then
        Ctl_MN_Execute_Click = CHK_ERR_ELSE
        Exit Function
    End If
' === 20060825 === INSERT E

    intRet = F_Ctl_Upd_Process(Main_Inf)
    If intRet = CHK_OK Then
        '��ʍĕ\��
        Main_Inf.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag).Detail.Bef_Chk_Value = Null
        
        Call Ctl_Item_KeyDown(HD_CLDDT, vbKeyReturn, 0)
        Call Ctl_Item_LostFocus(HD_CLDDT)
    
    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteCM_Click
    '   �T�v�F  �폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteCM_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_HARDCOPY_Click
    '   �T�v�F  ��ʈ��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_HARDCOPY_Click() As Integer
'�r���������������������������������������������������������r
    Dim wk_Cursor As Integer

    'Operable=TRUE�̎��̂�ok
    If PP_SSSMAIN.Operable = False Then
        Exit Function
    End If
    '�n�[�h�R�s�[�C�x���g���s
    If SSSMAIN_Hardcopy_Getevent() Then
        wk_Cursor = SSSMAIN0001.AE_Hardcopy_SSSMAIN()
    End If
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_EndCm_Click
    '   �T�v�F  �I��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_EndCm_Click() As Integer
'�r���������������������������������������������������������r
    Unload FR_SSSMAIN
'�d���������������������������������������������������������d
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Ctl_MN_APPENDC_Click
'   �T�v�F  ��ʏ���������
'   �����F�@�Ȃ�
'   �ߒl�F�@�Ȃ�
'   ���l�F  �S��ʃ��[�J�����ʏ���
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_APPENDC_Click() As Integer
'LLLLL 20060913 UPD S LLLLLLLLLLLLLLLLLLLL
    '��ʓ��e������
'    Call F_Init_Clr_Dsp(-1, Main_Inf)
    Call F_Init_Clr_Dsp(-2, Main_Inf)

    '��ʃ{�f�B��������
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

' === 20060825 === INSERT S
    '�P�s�ڂ̃{�f�B���������ŏI�s�Ƃ��ĊJ������
    Main_Inf.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
' === 20060825 === INSERT E

    '�����t�H�[�J�X�ʒu�ݒ�
    Call F_Init_Cursor_Set(Main_Inf)

' === 20060801 === INSERT S - ����W�\�����̕s��Ή�
    gv_bolCLDMT51_LF_Enable = True
' === 20060801 === INSERT E

' === 20060825 === INSERT S
    '���̓R���g���[���̎g�p�ې���
    Call F_Set_Inp_Item_Focus_Ctl(True, Main_Inf)
    
'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click
'    '���j���[�g�p�ې���
'    Call F_Ctl_MN_Enabled(Main_Inf)
' === 20060825 === INSERT E
'LLLLL 20060913 UPD E LLLLLLLLLLLLLLLLLLLL

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearItm_Click
    '   �T�v�F  ���ڏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearItm_Click() As Integer

    Dim Act_Index   As Integer
' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '��ʓ��e������
    Call F_Init_Clr_Dsp(Act_Index, Main_Inf)

    '����̫����擾����
    Call CF_Ctl_Item_GotFocus(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click


End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoItem_Click
    '   �T�v�F  ���ڕ���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
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

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̕�������
    Call CF_Ctl_UnDoItem(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    Move_Flg = False
    Chk_Move_Flg = True

    '�e���ڂ�����ٰ��
    Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(Main_Inf.Dsp_Sub_Inf(Act_Index), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, Main_Inf)

    If Rtn_Chk = CHK_OK Then
    '�`�F�b�N�n�j��
        '�擾���e�\��
        Dsp_Mode = DSP_SET
    Else
    '�`�F�b�N�m�f��
        '�擾���e�N���A
        Dsp_Mode = DSP_CLR
    End If
    '�擾���e�\��/�N���A
    Call SSSMAIN0001.F_Dsp_Item_Detail(Main_Inf.Dsp_Sub_Inf(Act_Index), Dsp_Mode, Main_Inf)
    
    '�G���[�t���O�𗎂Ƃ�
    Main_Inf.Dsp_Sub_Inf(Act_Index).Detail.Err_Status = ERR_DEF

    '�I����Ԃ̐ݒ�i�����I���j
    Call CF_Set_Sel_Ini(Main_Inf.Dsp_Sub_Inf(Act_Index), SEL_INI_MODE_2)

    '���ڐF�ݒ�
    Call CF_Set_Item_Color(Main_Inf.Dsp_Sub_Inf(Act_Index), ITEM_SELECT_STATUS, Main_Inf)

'�r���������������������������������������������������������r
'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_ClearDE_Click
    '   �T�v�F  ���׍s������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_ClearDE_Click() As Integer

    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̏���������
    Call SSSMAIN0001.CF_Ctl_MN_ClearDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_DeleteDE_Click
    '   �T�v�F  ���׍s�폜
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_DeleteDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̍폜����
    Call SSSMAIN0001.CF_Ctl_MN_DeleteDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
' === 20060825 === INSERT S
'    '���j���[�g�p�ې���
'    '�����P
'    Call Ctl_MN_Ctrl_Click
'    '�ҏW�Q
'    Call Ctl_MN_EditMn_Click
'    '�⏕�R
'    Call Ctl_MN_Oprt_Click
'    '���j���[�g�p�ې���
'    Call F_Ctl_MN_Enabled(Main_Inf)
'    '�y�[�W�{�^���g�p�ې���i�{�f�B���ɐ��䂪�ڂ����ꍇ�j
'    Call F_Ctl_PageButton_Enabled(Main_Inf)
' === 20060825 === INSERT E
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_InsertDE_Click
    '   �T�v�F  ���׍s�}��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_InsertDE_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̑}������
    Call SSSMAIN0001.CF_Ctl_MN_InsertDE(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UnDoDe_Click
    '   �T�v�F  ���׍s����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UnDoDe_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y���s�̕�������
    Call SSSMAIN0001.CF_Ctl_MN_UnDoDe(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Cut_Click
    '   �T�v�F  �؂���
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Cut_Click() As Integer

    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̐؂���
    Call CF_Cmn_Ctl_MN_Cut(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

    '���ڏ�����
    Call Ctl_MN_ClearItm_Click

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Copy_Click
    '   �T�v�F  �R�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Copy_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̃R�s�[
    Call CF_Cmn_Ctl_MN_Copy(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Paste_Click
    '   �T�v�F  �\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Paste_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Act_Index), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_SelectCm_Click
    '   �T�v�F  �ꗗ�\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_SelectCm_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_Slist_Click
    '   �T�v�F  �E�B���h�E�\��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_Slist_Click() As Integer
'�r���������������������������������������������������������r
    Call F_Ctl_CS(Main_Inf)
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_MN_UPDKB_Click
    '   �T�v�F  ���[�h�ύX
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_MN_UPDKB_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function SM_AllCopy_Click
    '   �T�v�F  ���ړ��e�ɃR�s�[
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_AllCopy_Click() As Integer
    '���ړ��e�ɃR�s�[
    Call CF_Cmn_Ctl_SM_AllCopy(Main_Inf)
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_Esc_Click
    '   �T�v�F  ������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_Esc_Click() As Integer
'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Ctl_SM_FullPast_Click
    '   �T�v�F  ���ڂɓ\��t��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �S��ʃ��[�J�����ʏ���
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_SM_FullPast_Click() As Integer
    Dim Act_Index   As Integer

' 2006/11/28  ADD START  KUMEDA
    If Me.ActiveControl Is Nothing Then
        Exit Function
    End If
' 2006/11/28  ADD END

    '�������ޯ���擾
    Act_Index = CInt(Me.ActiveControl.Tag)

    '�Y�����ڂ̓\��t��
    '���j���j���[�̉�ʢ�\��t����Ɠ���֐����g�p�I�I
    Call SSSMAIN0001.CF_Ctl_MN_Paste(Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.PopupMenu_Idx), Main_Inf)

'�r���������������������������������������������������������r
'�d���������������������������������������������������������d
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Ctl_CM_PREV_Click
'   �T�v�F  ���ׂ̑O�y�[�W�i�O���j��\��
'   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
'           pm_all              :�S�\����
'   �ߒl�F�@�Ȃ�
'   ���l�F  �S��ʃ��[�J�����ʏ���
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_PREV_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim Chng_Flg         As Boolean
    Dim intRet           As Integer
    Dim Err_Cd           As String       '�G���[�R�[�h
    
    Chng_Flg = True
    
'2008/07/09 START ADD FNAP)YAMANE �A���[���F�r��-54
    HAITA_FLG = 0
'2008/07/09 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
    
    '���׃f�[�^�ύX�`�F�b�N
'    intRet = Chk_Body_Change(pm_All)
'    If intRet <> CHK_OK Then
    If gv_bolCLDMT51_INIT = True Then
        
        Err_Cd = gc_strMsgCLDMT51_A_009
        '�m�F���b�Z�[�W�\��
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    
        '�߂�l�ɂ���ď����𕪂���
        Select Case intRet
            Case vbYes
            '�u�͂��v�̏ꍇ
                
                gb_pageChange = True
                '�X�V�����̎��s
                intRet = Ctl_MN_Execute_Click
                If intRet = CHK_ERR_ELSE Then
                    gb_pageChange = False
                    Exit Function
                End If
'2008/07/09 START ADD FNAP)YAMANE �A���[���F�r��-54
                If HAITA_FLG = 1 Then
                    gb_pageChange = False
                    Exit Function
                End If
'2008/07/09 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
                gb_pageChange = False
                gv_bolCLDMT51_INIT = False
                
            Case vbNo
            '�u�������v�̏ꍇ
                gv_bolCLDMT51_INIT = False
                
            Case vbCancel
            '�u�L�����Z���v�̏ꍇ
                Chng_Flg = False
            
            Case Else
                Chng_Flg = False
        
        End Select
        
    End If
    
    If Chng_Flg = True Then
    '�O�ŏo�͏���
        Call Set_HD_CLDDT(pm_Act_Dsp_Sub_Inf, pm_All, 1)  '1:�O���A2:����
    End If
    
End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Ctl_CM_NEXTCM_Click
'   �T�v�F  ���ׂ̎��y�[�W�i�����j��\��
'   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
'           pm_all              :�S�\����
'   �ߒl�F�@�Ȃ�
'   ���l�F  �S��ʃ��[�J�����ʏ���
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Ctl_CM_NEXTCM_Click(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All)

    Dim Chng_Flg         As Boolean
    Dim intRet           As Integer
    Dim Err_Cd           As String       '�G���[�R�[�h
    
    Chng_Flg = True
    
'2008/07/09 START ADD FNAP)YAMANE �A���[���F�r��-54
    HAITA_FLG = 0
'2008/07/09 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
    
    '���׃f�[�^�ύX�`�F�b�N
'    intRet = Chk_Body_Change(pm_All)
'    If intRet <> CHK_OK Then
    If gv_bolCLDMT51_INIT = True Then
    
        Err_Cd = gc_strMsgCLDMT51_A_009
        '�m�F���b�Z�[�W�\��
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
    
        '�߂�l�ɂ���ď����𕪂���
        Select Case intRet
            Case vbYes
            '�u�͂��v�̏ꍇ
                gb_pageChange = True
                '�X�V�����̎��s
                intRet = Ctl_MN_Execute_Click
                If intRet = CHK_ERR_ELSE Then
                    gb_pageChange = False
                    Exit Function
                End If
'2008/07/09 START ADD FNAP)YAMANE �A���[���F�r��-54
                If HAITA_FLG = 1 Then
                    gb_pageChange = False
                    Exit Function
                End If
'2008/07/09 E.N.D ADD FNAP)YAMANE �A���[���F�r��-54
                gb_pageChange = False
                gv_bolCLDMT51_INIT = False
                
            Case vbNo
            '�u�������v�̏ꍇ
                gv_bolCLDMT51_INIT = False
                
            Case vbCancel
            '�u�L�����Z���v�̏ꍇ
                Chng_Flg = False
            
            Case Else
                Chng_Flg = False
        
        End Select
    
    End If
        
    '���ŏo�͏���
    If Chng_Flg = True Then
        Call Set_HD_CLDDT(pm_Act_Dsp_Sub_Inf, pm_All, 2)  '1:�O���A2:����
    End If
    
End Function

'���������������� �S��ʃ��[�J�����ʏ��� End ��������������������������������


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Set_HD_CLDDT
    '   �T�v�F  �O�ŁA���Őݒ菈��
    '   �����F�@pm_Act_Dsp_Sub_Inf  :��ʍ��ڏ��
    '           pm_all              :�S�\����
    '       �F  pm_Pnflg            :1�ˑO���A2�ˎ���
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Set_HD_CLDDT(pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All, pm_Pnflg As Integer) As Integer
    
    Dim strpreDate       As String
    Dim strDate          As String
    Dim strDateY         As String
    Dim strDateM         As String
    Dim Wk_Index As Integer
    
    strDate = "000000"
'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
    gb_txtChange = False
    gb_pageChange = False
        
'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
    
    '�o�^�N���e�L�X�g�{�b�N�X�̒l���擾����B
    strDate = FR_SSSMAIN.HD_CLDDT.Text
    strpreDate = strDate
    strDate = CF_Get_Input_Ok_Item(CStr(strDate), pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag))
    
'    If strDate = "000000" Then
    If strDate = "" Then
    '�����l�̏ꍇ�A�������Ȃ�
    Else
        strDateY = CInt(Mid(strDate, 1, 4))
        strDateM = CInt(Mid(strDate, 5, 2))
    
        If pm_Pnflg = 1 Then
        '�O�ňړ��̏ꍇ
            Select Case strDateM
            Case 1
            '1���̏ꍇ�A�O�N12����ݒ�
                strDateY = strDateY - 1
                strDateM = 12
            Case Else
            '���̑��̌��̏ꍇ�A�}�C�i�X1��
                strDateM = strDateM - 1
            End Select
        Else
        '���ňړ��̏ꍇ
            Select Case strDateM
            Case 12
            '12���̏ꍇ�A���N1����ݒ�
                strDateY = strDateY + 1
                strDateM = 1
            Case Else
            '���̑��̌��̏ꍇ�A�v���X1��
                strDateM = strDateM + 1
            End Select
        End If
        
        '�[�����߂��ĕ�����ɖ߂�
        strDate = Right("0000" & strDateY, 4) + Right("00" & strDateM, 2)
        gb_dateYM = CF_Cnv_Dsp_Item(strDate, Main_Inf.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag), False)
        
        '�o�^�N���e�L�X�g�{�b�N�X�ɒl�ݒ�
        Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(strDate, pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag), False), pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag), pm_All, SET_FLG_DEF)
        
        gv_bolKeyFlg = False
        Call Ctl_Item_KeyDown(HD_CLDDT, vbKeyReturn, 0)
    
        If FR_SSSMAIN.HD_CLDDT.ForeColor = vbRed Then
            '�o�^�N����ύX�O�ɖ߂�
            Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(strpreDate, pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag), False), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)), pm_All)
            gv_bolKeyFlg = False
            Call Ctl_Item_KeyDown(HD_CLDDT, vbKeyReturn, 0)
        End If
    End If

End Function

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function Chk_Body_Change
'   �T�v�F  ���׃f�[�^�ɕύX���Ȃ����`�F�b�N
'   �����F�@pm_all              :�S�\����
'   �ߒl�F�@�Ȃ�
'   ���l�F  �S��ʃ��[�J�����ʏ���
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Chk_Body_Change(pm_All As Cls_All) As Integer

    Dim Chng_Flg         As Integer
    Dim Index_Wk         As Integer
    Dim Dsp_Value        As Variant
    
    Chng_Flg = CHK_OK
    
    '���׃f�[�^���`�F�b�N
    For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
        
        '���ݓ��e
        Dsp_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
        '�O����e�Ɣ�r
        If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value <> Dsp_Value Then
        '�ύX����
            Chng_Flg = CHK_ERR_ELSE
            Exit For
        End If
    
    Next Index_Wk
    
    Chk_Body_Change = Chng_Flg
End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Edi_Dsp_Def
    '   �T�v�F  �������̉�ʕҏW
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Edi_Dsp_Def() As Integer
    Dim Index_Wk        As Integer

'�r���������������������������������������������������������r
    '�t�H�[���^�C�g��
    FR_SSSMAIN.Caption = SSS_PrgNm

    Index_Wk = CInt(SYSDT.Tag)
    '��ʓ��t
' === 20060727 === UPDATE S
'    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(Now, "YYYY/MM/DD"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
    Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(Format(GV_UNYDate, "@@@@/@@/@@"), Main_Inf.Dsp_Sub_Inf(Index_Wk), False), Main_Inf.Dsp_Sub_Inf(Index_Wk), Main_Inf, SET_FLG_DEF)
' === 20060727 === UPDATE E
'�d���������������������������������������������������������d

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub TM_StartUp_Timer
    '   �T�v�F  �����t�H�[�J�X�ݒ���s��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �^�C�}�[�C�x���g����
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub TM_StartUp_Timer()
    '��x����̂��ߎg�p�s��
    Main_Inf.TM_StartUp_Ctl.Enabled = False
    '��ʈ���N������TRUE�Ƃ���
    PP_SSSMAIN.Operable = True
    '����̫����ʒu�ݒ�s
    Call F_Init_Cursor_Set(Main_Inf)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Form_Load
    '   �T�v�F  �t�H�[�����[�h���̏����ݒ���s��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �t�H�[�����[�h������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Form_Load()

    'DB�ڑ�
    Call CF_Ora_USR1_Open

    '���ʏ���������
    Call CF_Init

    '��ʏ��ݒ�
    Call Init_Def_Dsp

    '��ʓ��e������
    Call F_Init_Clr_Dsp(-1, Main_Inf)

    '��ʖ��׏��ݒ�
    Call Init_Def_Body_Inf

    '��ʖ��ו�������
    Call F_Init_Clr_Dsp_Body(-1, Main_Inf)

    '���׃��P�[�V����
    Call Set_Body_Location

    '�����\���ҏW
    Call Edi_Dsp_Def

    '��ʖ��ו\��
    Call CF_Body_Dsp(Main_Inf)

    '��ʕ\���ʒu�ݒ�
    Call CF_Set_Frm_Location(FR_SSSMAIN)

    '���͒S���ҕҏW
    Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, Main_Inf)

    '�V�X�e�����ʏ���
    Call CF_System_Process(Me)

'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
    '�����`�F�b�N�i�����Ȃ��̏ꍇ�A�X�V�����͍s���Ȃ��j
    If F_Chk_KNGMTA_CLDUPDKB(Main_Inf) = CHK_OK Then
        gb_CldUpdFlg = True
    Else
        gb_CldUpdFlg = False
    End If

'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
    
    '��ʕҏW�Ȃ��Ƃ���
    gv_bolCLDMT51_INIT = False
    gv_bolInit = False
    gv_bolCLDMT51_LF_Enable = True

End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Init_Def_Body_Inf
    '   �T�v�F  ��ʃ{�f�B���ݒ�
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Init_Def_Body_Inf() As Integer

    Dim Bd_Col_Index    As Integer
    Dim Index_Wk        As Integer

    '������ʃ{�f�B���ݒ�
    Call CF_Init_Set_Body_Inf(Main_Inf)

    If Main_Inf.Dsp_Base.Dsp_Body_Cnt > 0 Then
    '���׍s�����݂���ꍇ

        '��ʃ{�f�B�̗񕪂̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT

        '�������p�ݒ�
        '��ʃ{�f�B�̗񕪂̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT

        '�������ݒ�
        '�񕪂̕����s�̔z���`
        ReDim Preserve Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Main_Inf.Dsp_Base.Body_Col_Cnt)
        '�������
        Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT

        '��ʃ{�f�B���̔z��O�Ԗڂɗ�����`����
        For Bd_Col_Index = 1 To Main_Inf.Dsp_Base.Body_Col_Cnt
            '��ʃ{�f�B���
            Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Sub_Inf(Main_Inf.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail

            '�������p���
            Main_Inf.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)

            '�������
            Main_Inf.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = Main_Inf.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
        Next

    End If

End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Function Set_Body_Location
    '   �T�v�F  ���ׂ̔z�u
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Function Set_Body_Location() As Integer

    Const Hosei_Value   As Integer = -20

    Dim BD_CLDT_Top    As Integer      '���t��Top
    Dim BD_CLDT_Height As Integer      '���t��Height

    Dim Bd_Index        As Integer

    '�P�s�ڂ̓��t��Top��Height����Ƃ���
    BD_CLDT_Top = BD_CLDT(1).Top
    BD_CLDT_Height = BD_CLDT(1).Height + Hosei_Value

    '�\���ŏI�s�܂ŏ���
    For Bd_Index = 1 To Main_Inf.Dsp_Base.Dsp_Body_Cnt
        If Bd_Index >= 2 Then
        '�Q�s�ڈȍ~����
'            '�z�u
'            '���t
'            BD_CLDT(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�j���i�R�[�h�j
'            BD_WKKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�j���i���́j
'            BD_WKKBNM(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�j�Փ�
'            BD_CLDHLKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�c�Ɠ��敪
'            BD_SLDKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�����ғ��敪
'            BD_DTBKDKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '���Y�ғ��敪
'            BD_PRDKDKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '��s�ғ��敪
'            BD_BNKKDKB(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�c�ƒʎZ�ғ�����
'            BD_SLSMDD(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '�����ʎZ�ғ�����
'            BD_DTBKDDD(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '���Y�ʎZ�ғ�����
'            BD_PRDKDDD(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
'            '����ʎZ����
'            BD_CLDSMDD(Bd_Index).Top = BD_CLDT_Top + BD_CLDT_Height * (Bd_Index - 1)
        
        End If

        '�\��
        '���t
        BD_CLDT(Bd_Index).Visible = True
        '�j���i�R�[�h�j
        BD_WKKB(Bd_Index).Visible = False
        '�j���i���́j
        BD_WKKBNM(Bd_Index).Visible = True
        '�j�Փ�
        BD_CLDHLKB(Bd_Index).Visible = True
        '�c�Ɠ��敪
        BD_SLDKB(Bd_Index).Visible = True
        '�����ғ��敪
        BD_DTBKDKB(Bd_Index).Visible = True
        '���Y�ғ��敪
        BD_PRDKDKB(Bd_Index).Visible = True
        '��s�ғ��敪
        BD_BNKKDKB(Bd_Index).Visible = True
        '�c�ƒʎZ�ғ�����
        BD_SLSMDD(Bd_Index).Visible = True
        '�����ʎZ�ғ�����
        BD_DTBKDDD(Bd_Index).Visible = True
        '���Y�ʎZ�ғ�����
        BD_PRDKDDD(Bd_Index).Visible = True
        '����ʎZ����
        BD_CLDSMDD(Bd_Index).Visible = True

    Next

End Function
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub Form_QueryUnload
    '   �T�v�F  ��ʂ��I������ۂ̐ݒ���s��
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F  �t�H�[���A�����[�h������
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    
    Dim intRet           As Integer
    Dim Err_Cd           As String       '�G���[�R�[�h
    
    '�m�F���b�Z�[�W�\��
    If (gv_bolCLDMT51_INIT = True) And (gb_CldUpdFlg = True) Then
    '��ʍ��ڂɕύX������A�X�V����������ꍇ
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_A_011, Main_Inf)
    Else
    '��ʍ��ڂɕύX���Ȃ��A�܂��͍X�V�������Ȃ��ꍇ
        intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_A_003, Main_Inf)
    End If
    
    If intRet <> vbNo Then
    '������ʃN���[�Y
        Call F_Ctl_WLS_Close

        '���ʏI�������H
        Set FR_SSSMAIN = Nothing
        
    Else
        Cancel = True
        '�X�e�[�^�X�o�[������
        Call CF_Clr_Prompt(Main_Inf)

        Exit Sub
        
    End If
    
' === 20060907 === INSERT S
    Main_Inf.Dsp_Base.IsUnload = True
' === 20060907 === INSERT E

    'DB�ڑ�����
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
    
' 2006/11/15  ADD START  KUMEDA
    Call SSSWIN_LOGWRT("�v���O�����I��")
' 2006/11/15  ADD END

End Sub

Private Sub MN_Execute_Click()
    Debug.Print "MN_Execute_Click"
    Call Ctl_Item_Click(MN_Execute)
End Sub

Private Sub MN_HARDCOPY_Click()
'    Debug.Print "MN_HARDCOPY_Click"
'    Call Ctl_Item_Click(MN_HARDCOPY)
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
'    Call Ctl_Item_Click(MN_DeleteDE)
End Sub

Private Sub MN_InsertDE_Click()
    Debug.Print "MN_InsertDE_Click"
'    Call Ctl_Item_Click(MN_InsertDE)
End Sub

Private Sub MN_UnDoDe_Click()
    Debug.Print "MN_UnDoDe_Click"
'    Call Ctl_Item_Click(MN_UnDoDe)
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
'    Call Ctl_Item_Click(MN_UPDKB)
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
'    Debug.Print "CM_INSERTDE_Click"
'    Call Ctl_Item_Click(CM_INSERTDE)
End Sub

Private Sub CM_DELETEDE_Click()
'    Debug.Print "CM_DELETEDE_Click"
'    Call Ctl_Item_Click(CM_DELETEDE)
End Sub

Private Sub CM_SLIST_Click()
'    Debug.Print "CM_SLIST_Click"
'    Call Ctl_Item_Click(CM_SLIST)
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
'    Debug.Print "MCM_SelectCm_Click"
'    Call Ctl_Item_Click(CM_SelectCm)
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
'    Debug.Print "CM_INSERTDE_MouseDown"
'    Call Ctl_Item_MouseDown(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_DELETEDE_MouseDown"
'    Call Ctl_Item_MouseDown(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_SLIST_MouseDown"
'    Call Ctl_Item_MouseDown(CM_SLIST, Button, Shift, X, Y)
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
'    Debug.Print "CM_SelectCm_MouseDown"
'    Call Ctl_Item_MouseDown(CM_SelectCm, Button, Shift, X, Y)
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
'    Debug.Print "CM_INSERTDE_MouseMove"
'    Call Ctl_Item_MouseMove(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_DELETEDE_MouseMove"
'    Call Ctl_Item_MouseMove(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_SLIST_MouseMove"
'    Call Ctl_Item_MouseMove(CM_SLIST, Button, Shift, X, Y)
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
'    Debug.Print "CM_SelectCm_MouseMove"
'    Call Ctl_Item_MouseMove(CM_SelectCm, Button, Shift, X, Y)
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
'    Debug.Print "CM_INSERTDE_MouseUp"
'    Call Ctl_Item_MouseUp(CM_INSERTDE, Button, Shift, X, Y)
End Sub

Private Sub CM_DELETEDE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_DELETEDE_MouseUp"
'    Call Ctl_Item_MouseUp(CM_DELETEDE, Button, Shift, X, Y)
End Sub

Private Sub CM_SLIST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
'    Debug.Print "CM_SLIST_MouseUp"
'    Call Ctl_Item_MouseUp(CM_SLIST, Button, Shift, X, Y)
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
'    Debug.Print "CM_SelectCm_MouseUp"
'    Call Ctl_Item_MouseUp(CM_SelectCm, Button, Shift, X, Y)
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

Private Sub HD_IN_TANCD_GotFocus()
    Debug.Print "HD_IN_TANCD_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_GotFocus()
    Debug.Print "HD_IN_TANNM_GotFocus"
    Call Ctl_Item_GotFocus(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANCD, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANNM_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyDown"
    Call Ctl_Item_KeyDown(HD_IN_TANNM, KEYCODE, Shift)
End Sub

Private Sub HD_IN_TANCD_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANCD_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANCD, KeyAscii)
End Sub

Private Sub HD_IN_TANNM_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_IN_TANNM_KeyPress"
    Call Ctl_Item_KeyPress(HD_IN_TANNM, KeyAscii)
End Sub

Private Sub HD_IN_TANCD_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANCD_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_IN_TANNM_KeyUp"
    Call Ctl_Item_KeyUp(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_LostFocus()
    Debug.Print "HD_IN_TANCD_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANCD)
End Sub

Private Sub HD_IN_TANNM_LostFocus()
    Debug.Print "HD_IN_TANNM_LostFocus"
    Call Ctl_Item_LostFocus(HD_IN_TANNM)
End Sub

Private Sub HD_IN_TANCD_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseDown"
    Call Ctl_Item_MouseDown(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANCD_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANCD_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANCD, Button, Shift, X, Y)
End Sub

Private Sub HD_IN_TANNM_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_IN_TANNM_MouseUp"
    Call Ctl_Item_MouseUp(HD_IN_TANNM, Button, Shift, X, Y)
End Sub

Private Sub HD_CLDDT_Change()
    Debug.Print "HD_CLDDT_Change"
    Call Ctl_Item_Change(HD_CLDDT)
End Sub

Private Sub HD_UPDKB_Change()
    Debug.Print "HD_UPDKB_Change"
    Call Ctl_Item_Change(HD_UPDKB)
End Sub

Private Sub HD_CLDDT_GotFocus()
    Debug.Print "HD_CLDDT_GotFocus"
    Call Ctl_Item_GotFocus(HD_CLDDT)
End Sub

Private Sub HD_UPDKB_GotFocus()
    Debug.Print "HD_UPDKB_GotFocus"
    Call Ctl_Item_GotFocus(HD_UPDKB)
End Sub

Private Sub HD_CLDDT_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_CLDDT_KeyDown"
    Call Ctl_Item_KeyDown(HD_CLDDT, KEYCODE, Shift)
End Sub

Private Sub HD_UPDKB_KeyDown(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_UPDKB_KeyDown"
    Call Ctl_Item_KeyDown(HD_UPDKB, KEYCODE, Shift)
End Sub

Private Sub HD_CLDDT_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_CLDDT_KeyPress"
    Call Ctl_Item_KeyPress(HD_CLDDT, KeyAscii)
End Sub

Private Sub HD_UPDKB_KeyPress(KeyAscii As Integer)
    Debug.Print "HD_UPDKB_KeyPress"
    Call Ctl_Item_KeyPress(HD_UPDKB, KeyAscii)
End Sub

Private Sub HD_CLDDT_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_CLDDT_KeyUp"
    Call Ctl_Item_KeyUp(HD_CLDDT)
End Sub

Private Sub HD_UPDKB_KeyUp(KEYCODE As Integer, Shift As Integer)
    Debug.Print "HD_UPDKB_KeyUp"
    Call Ctl_Item_KeyUp(HD_UPDKB)
End Sub

Private Sub HD_CLDDT_LostFocus()
    Debug.Print "HD_CLDDT_LostFocus"
    Call Ctl_Item_LostFocus(HD_CLDDT)
End Sub

Private Sub HD_UPDKB_LostFocus()
    Debug.Print "HD_UPDKB_LostFocus"
    Call Ctl_Item_LostFocus(HD_UPDKB)
End Sub

Private Sub HD_CLDDT_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_CLDDT_MouseDown"
    Call Ctl_Item_MouseDown(HD_CLDDT, Button, Shift, X, Y)
End Sub

Private Sub HD_UPDKB_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_UPDKB_MouseDown"
    Call Ctl_Item_MouseDown(HD_UPDKB, Button, Shift, X, Y)
End Sub

Private Sub HD_CLDDT_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_CLDDT_MouseUp"
    Call Ctl_Item_MouseUp(HD_CLDDT, Button, Shift, X, Y)
End Sub

Private Sub HD_UPDKB_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "HD_UPDKB_MouseUp"
    Call Ctl_Item_MouseUp(HD_UPDKB, Button, Shift, X, Y)
End Sub

Private Sub BD_CLDT_Change(Index As Integer)
    Debug.Print "BD_CLDT_Change"
    Call Ctl_Item_Change(BD_CLDT(Index))
End Sub

Private Sub BD_WKKB_Change(Index As Integer)
    Debug.Print "BD_WKKB_Change"
    Call Ctl_Item_Change(BD_WKKB(Index))
End Sub

Private Sub BD_WKKBNM_Change(Index As Integer)
    Debug.Print "BD_WKKBNM_Change"
    Call Ctl_Item_Change(BD_WKKBNM(Index))
End Sub

Private Sub BD_CLDHLKB_Change(Index As Integer)
    Debug.Print "BD_CLDHLKB_Change"
    Call Ctl_Item_Change(BD_CLDHLKB(Index))
End Sub

Private Sub BD_SLDKB_Change(Index As Integer)
    Debug.Print "BD_SLDKB_Change"
    Call Ctl_Item_Change(BD_SLDKB(Index))
End Sub

Private Sub BD_DTBKDKB_Change(Index As Integer)
    Debug.Print "BD_DTBKDKB_Change"
    Call Ctl_Item_Change(BD_DTBKDKB(Index))
End Sub

Private Sub BD_PRDKDKB_Change(Index As Integer)
    Debug.Print "BD_PRDKDKB_Change"
    Call Ctl_Item_Change(BD_PRDKDKB(Index))
End Sub

Private Sub BD_BNKKDKB_Change(Index As Integer)
    Debug.Print "BD_BNKKDKB_Change"
    Call Ctl_Item_Change(BD_BNKKDKB(Index))
End Sub

Private Sub BD_SLSMDD_Change(Index As Integer)
    Debug.Print "BD_SLSMDD_Change"
    Call Ctl_Item_Change(BD_SLSMDD(Index))
End Sub

Private Sub BD_DTBKDDD_Change(Index As Integer)
    Debug.Print "BD_DTBKDDD_Change"
    Call Ctl_Item_Change(BD_DTBKDDD(Index))
End Sub

Private Sub BD_PRDKDDD_Change(Index As Integer)
    Debug.Print "BD_PRDKDDD_Change"
    Call Ctl_Item_Change(BD_PRDKDDD(Index))
End Sub

Private Sub BD_CLDSMDD_Change(Index As Integer)
    Debug.Print "BD_CLDSMDD_Change"
    Call Ctl_Item_Change(BD_CLDSMDD(Index))
End Sub

Private Sub BD_CLDT_GotFocus(Index As Integer)
    Debug.Print "BD_CLDT_GotFocus"
    Call Ctl_Item_GotFocus(BD_CLDT(Index))
End Sub

Private Sub BD_WKKB_GotFocus(Index As Integer)
    Debug.Print "BD_WKKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_WKKB(Index))
End Sub

Private Sub BD_WKKBNM_GotFocus(Index As Integer)
    Debug.Print "BD_WKKBNM_GotFocus"
    Call Ctl_Item_GotFocus(BD_WKKBNM(Index))
End Sub

Private Sub BD_CLDHLKB_GotFocus(Index As Integer)
    Debug.Print "BD_CLDHLKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_CLDHLKB(Index))
End Sub

Private Sub BD_SLDKB_GotFocus(Index As Integer)
    Debug.Print "BD_SLDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_SLDKB(Index))
End Sub

Private Sub BD_DTBKDKB_GotFocus(Index As Integer)
    Debug.Print "BD_DTBKDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_DTBKDKB(Index))
End Sub

Private Sub BD_PRDKDKB_GotFocus(Index As Integer)
    Debug.Print "BD_PRDKDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_PRDKDKB(Index))
End Sub

Private Sub BD_BNKKDKB_GotFocus(Index As Integer)
    Debug.Print "BD_BNKKDKB_GotFocus"
    Call Ctl_Item_GotFocus(BD_BNKKDKB(Index))
End Sub

Private Sub BD_SLSMDD_GotFocus(Index As Integer)
    Debug.Print "BD_SLSMDD_GotFocus"
    Call Ctl_Item_GotFocus(BD_SLSMDD(Index))
End Sub

Private Sub BD_DTBKDDD_GotFocus(Index As Integer)
    Debug.Print "BD_DTBKDDD_GotFocus"
    Call Ctl_Item_GotFocus(BD_DTBKDDD(Index))
End Sub

Private Sub BD_PRDKDDD_GotFocus(Index As Integer)
    Debug.Print "BD_PRDKDDD_GotFocus"
    Call Ctl_Item_GotFocus(BD_PRDKDDD(Index))
End Sub

Private Sub BD_CLDSMDD_GotFocus(Index As Integer)
    Debug.Print "BD_CLDSMDD_GotFocus"
    Call Ctl_Item_GotFocus(BD_CLDSMDD(Index))
End Sub

Private Sub BD_CLDT_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDT_KeyDown"
    Call Ctl_Item_KeyDown(BD_CLDT(Index), KEYCODE, Shift)
End Sub

Private Sub BD_WKKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WKKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_WKKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_WKKBNM_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WKKBNM_KeyDown"
    Call Ctl_Item_KeyDown(BD_WKKBNM(Index), KEYCODE, Shift)
End Sub

Private Sub BD_CLDHLKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDHLKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_CLDHLKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SLDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SLDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_SLDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_DTBKDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DTBKDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_DTBKDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_PRDKDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRDKDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_PRDKDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_BNKKDKB_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_BNKKDKB_KeyDown"
    Call Ctl_Item_KeyDown(BD_BNKKDKB(Index), KEYCODE, Shift)
End Sub

Private Sub BD_SLSMDD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SLSMDD_KeyDown"
    Call Ctl_Item_KeyDown(BD_SLSMDD(Index), KEYCODE, Shift)
End Sub

Private Sub BD_DTBKDDD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DTBKDDD_KeyDown"
    Call Ctl_Item_KeyDown(BD_DTBKDDD(Index), KEYCODE, Shift)
End Sub

Private Sub BD_PRDKDDD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRDKDDD_KeyDown"
    Call Ctl_Item_KeyDown(BD_PRDKDDD(Index), KEYCODE, Shift)
End Sub

Private Sub BD_CLDSMDD_KeyDown(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDSMDD_KeyDown"
    Call Ctl_Item_KeyDown(BD_CLDSMDD(Index), KEYCODE, Shift)
End Sub

Private Sub BD_CLDT_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_CLDT_KeyPress"
    Call Ctl_Item_KeyPress(BD_CLDT(Index), KeyAscii)
End Sub

Private Sub BD_WKKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_WKKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_WKKB(Index), KeyAscii)
End Sub

Private Sub BD_WKKBNM_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_WKKBNM_KeyPress"
    Call Ctl_Item_KeyPress(BD_WKKBNM(Index), KeyAscii)
End Sub

Private Sub BD_CLDHLKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_CLDHLKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_CLDHLKB(Index), KeyAscii)
End Sub

Private Sub BD_SLDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SLDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_SLDKB(Index), KeyAscii)
End Sub

Private Sub BD_DTBKDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_DTBKDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_DTBKDKB(Index), KeyAscii)
End Sub

Private Sub BD_PRDKDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_PRDKDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_PRDKDKB(Index), KeyAscii)
End Sub

Private Sub BD_BNKKDKB_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_BNKKDKB_KeyPress"
    Call Ctl_Item_KeyPress(BD_BNKKDKB(Index), KeyAscii)
End Sub

Private Sub BD_SLSMDD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_SLSMDD_KeyPress"
    Call Ctl_Item_KeyPress(BD_SLSMDD(Index), KeyAscii)
End Sub

Private Sub BD_DTBKDDD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_DTBKDDD_KeyPress"
    Call Ctl_Item_KeyPress(BD_DTBKDDD(Index), KeyAscii)
End Sub

Private Sub BD_PRDKDDD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_PRDKDDD_KeyPress"
    Call Ctl_Item_KeyPress(BD_PRDKDDD(Index), KeyAscii)
End Sub

Private Sub BD_CLDSMDD_KeyPress(Index As Integer, KeyAscii As Integer)
    Debug.Print "BD_CLDSMDD_KeyPress"
    Call Ctl_Item_KeyPress(BD_CLDSMDD(Index), KeyAscii)
End Sub

Private Sub BD_CLDT_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDT_KeyUp"
    Call Ctl_Item_KeyUp(BD_CLDT(Index))
End Sub

Private Sub BD_WKKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WKKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_WKKB(Index))
End Sub

Private Sub BD_WKKBNM_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_WKKBNM_KeyUp"
    Call Ctl_Item_KeyUp(BD_WKKBNM(Index))
End Sub

Private Sub BD_CLDHLKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDHLKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_CLDHLKB(Index))
End Sub

Private Sub BD_SLDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SLDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_SLDKB(Index))
End Sub

Private Sub BD_DTBKDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DTBKDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_DTBKDKB(Index))
End Sub

Private Sub BD_PRDKDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRDKDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_PRDKDKB(Index))
End Sub

Private Sub BD_BNKKDKB_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_BNKKDKB_KeyUp"
    Call Ctl_Item_KeyUp(BD_BNKKDKB(Index))
End Sub

Private Sub BD_SLSMDD_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_SLSMDD_KeyUp"
    Call Ctl_Item_KeyUp(BD_SLSMDD(Index))
End Sub

Private Sub BD_DTBKDDD_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_DTBKDDD_KeyUp"
    Call Ctl_Item_KeyUp(BD_DTBKDDD(Index))
End Sub

Private Sub BD_PRDKDDD_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_PRDKDDD_KeyUp"
    Call Ctl_Item_KeyUp(BD_PRDKDDD(Index))
End Sub

Private Sub BD_CLDSMDD_KeyUp(Index As Integer, KEYCODE As Integer, Shift As Integer)
    Debug.Print "BD_CLDSMDD_KeyUp"
    Call Ctl_Item_KeyUp(BD_CLDSMDD(Index))
End Sub

Private Sub BD_CLDT_LostFocus(Index As Integer)
    Debug.Print "BD_CLDT_LostFocus"
    Call Ctl_Item_LostFocus(BD_CLDT(Index))
End Sub

Private Sub BD_WKKB_LostFocus(Index As Integer)
    Debug.Print "BD_WKKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_WKKB(Index))
End Sub

Private Sub BD_WKKBNM_LostFocus(Index As Integer)
    Debug.Print "BD_WKKBNM_LostFocus"
    Call Ctl_Item_LostFocus(BD_WKKBNM(Index))
End Sub

Private Sub BD_CLDHLKB_LostFocus(Index As Integer)
    Debug.Print "BD_CLDHLKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_CLDHLKB(Index))
End Sub

Private Sub BD_SLDKB_LostFocus(Index As Integer)
    Debug.Print "BD_SLDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_SLDKB(Index))
End Sub

Private Sub BD_DTBKDKB_LostFocus(Index As Integer)
    Debug.Print "BD_DTBKDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_DTBKDKB(Index))
End Sub

Private Sub BD_PRDKDKB_LostFocus(Index As Integer)
    Debug.Print "BD_PRDKDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_PRDKDKB(Index))
End Sub

Private Sub BD_BNKKDKB_LostFocus(Index As Integer)
    Debug.Print "BD_BNKKDKB_LostFocus"
    Call Ctl_Item_LostFocus(BD_BNKKDKB(Index))
End Sub

Private Sub BD_SLSMDD_LostFocus(Index As Integer)
    Debug.Print "BD_SLSMDD_LostFocus"
    Call Ctl_Item_LostFocus(BD_SLSMDD(Index))
End Sub

Private Sub BD_DTBKDDD_LostFocus(Index As Integer)
    Debug.Print "BD_DTBKDDD_LostFocus"
    Call Ctl_Item_LostFocus(BD_DTBKDDD(Index))
End Sub

Private Sub BD_PRDKDDD_LostFocus(Index As Integer)
    Debug.Print "BD_PRDKDDD_LostFocus"
    Call Ctl_Item_LostFocus(BD_PRDKDDD(Index))
End Sub

Private Sub BD_CLDSMDD_LostFocus(Index As Integer)
    Debug.Print "BD_CLDSMDD_LostFocus"
    Call Ctl_Item_LostFocus(BD_CLDSMDD(Index))
End Sub

Private Sub BD_CLDT_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDT_MouseDown"
    Call Ctl_Item_MouseDown(BD_CLDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WKKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WKKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_WKKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WKKBNM_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WKKBNM_MouseDown"
    Call Ctl_Item_MouseDown(BD_WKKBNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_CLDHLKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDHLKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_CLDHLKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SLDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SLDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_SLDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_DTBKDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DTBKDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_DTBKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRDKDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRDKDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_PRDKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_BNKKDKB_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_BNKKDKB_MouseDown"
    Call Ctl_Item_MouseDown(BD_BNKKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SLSMDD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SLSMDD_MouseDown"
    Call Ctl_Item_MouseDown(BD_SLSMDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_DTBKDDD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DTBKDDD_MouseDown"
    Call Ctl_Item_MouseDown(BD_DTBKDDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRDKDDD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRDKDDD_MouseDown"
    Call Ctl_Item_MouseDown(BD_PRDKDDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_CLDSMDD_MouseDown(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDSMDD_MouseDown"
    Call Ctl_Item_MouseDown(BD_CLDSMDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_CLDT_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDT_MouseUp"
    Call Ctl_Item_MouseUp(BD_CLDT(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WKKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WKKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_WKKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_WKKBNM_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_WKKBNM_MouseUp"
    Call Ctl_Item_MouseUp(BD_WKKBNM(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_CLDHLKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDHLKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_CLDHLKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SLDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SLDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_SLDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_DTBKDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DTBKDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_DTBKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRDKDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRDKDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_PRDKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_BNKKDKB_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_BNKKDKB_MouseUp"
    Call Ctl_Item_MouseUp(BD_BNKKDKB(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_SLSMDD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_SLSMDD_MouseUp"
    Call Ctl_Item_MouseUp(BD_SLSMDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_DTBKDDD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_DTBKDDD_MouseUp"
    Call Ctl_Item_MouseUp(BD_DTBKDDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_PRDKDDD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_PRDKDDD_MouseUp"
    Call Ctl_Item_MouseUp(BD_PRDKDDD(Index), Button, Shift, X, Y)
End Sub

Private Sub BD_CLDSMDD_MouseUp(Index As Integer, Button As Integer, Shift As Integer, X As Single, Y As Single)
    Debug.Print "BD_CLDSMDD_MouseUp"
    Call Ctl_Item_MouseUp(BD_CLDSMDD(Index), Button, Shift, X, Y)
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


