VERSION 5.00
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "SPR32X30.ocx"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�V���A�����o�^"
   ClientHeight    =   5880
   ClientLeft      =   150
   ClientTop       =   840
   ClientWidth     =   5625
   Icon            =   "frmSRAET53.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5880
   ScaleWidth      =   5625
   StartUpPosition =   3  'Windows �̊���l
   Begin VB.TextBox txtDummy 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   270
      Left            =   4800
      TabIndex        =   15
      Top             =   4800
      Width           =   15
   End
   Begin VB.Frame Frame1 
      Height          =   735
      Left            =   240
      TabIndex        =   9
      Top             =   6000
      Width           =   4095
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   2
         Left            =   2400
         Picture         =   "frmSRAET53.frx":030A
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   1
         Left            =   1920
         Picture         =   "frmSRAET53.frx":0494
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   2
         Left            =   1440
         Picture         =   "frmSRAET53.frx":061E
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   1
         Left            =   1080
         Picture         =   "frmSRAET53.frx":0C70
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   2
         Left            =   600
         Picture         =   "frmSRAET53.frx":12C2
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   1
         Left            =   240
         Picture         =   "frmSRAET53.frx":144C
         Top             =   240
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 SSPanel52 
      Height          =   330
      Left            =   720
      TabIndex        =   8
      Top             =   1485
      Width           =   900
      _ExtentX        =   1588
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
      Caption         =   "�� ��"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel51 
      Height          =   645
      Left            =   720
      TabIndex        =   7
      Top             =   750
      Width           =   900
      _ExtentX        =   1588
      _ExtentY        =   1138
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �o�S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "�� �i"
      OutLine         =   -1  'True
   End
   Begin FPSpread.vaSpread vaData 
      Height          =   3150
      Left            =   720
      TabIndex        =   0
      Top             =   1920
      Width           =   3225
      _Version        =   196608
      _ExtentX        =   5689
      _ExtentY        =   5556
      _StockProps     =   64
      AllowMultiBlocks=   -1  'True
      ArrowsExitEditMode=   -1  'True
      BackColorStyle  =   1
      DisplayRowHeaders=   0   'False
      EditEnterAction =   5
      EditModeReplace =   -1  'True
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxCols         =   7
      MaxRows         =   10
      Position        =   3
      ProcessTab      =   -1  'True
      Protect         =   0   'False
      ScrollBars      =   2
      SpreadDesigner  =   "frmSRAET53.frx":15D6
      UserResize      =   0
      VisibleCols     =   3
      VisibleRows     =   1
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   0
      TabIndex        =   10
      Top             =   5280
      Width           =   5655
      _ExtentX        =   9975
      _ExtentY        =   1138
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
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   375
         Index           =   2
         Left            =   585
         TabIndex        =   11
         Top             =   135
         Width           =   4950
         _ExtentX        =   8731
         _ExtentY        =   661
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
            Height          =   285
            Left            =   120
            MultiLine       =   -1  'True
            TabIndex        =   12
            Text            =   "frmSRAET53.frx":1AD9
            Top             =   70
            Width           =   5955
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "frmSRAET53.frx":1B10
         Top             =   135
         Width           =   300
      End
   End
   Begin Threed5.SSPanel5 SSPanel53 
      Height          =   615
      Left            =   0
      TabIndex        =   13
      Top             =   0
      Width           =   5655
      _ExtentX        =   9975
      _ExtentY        =   1085
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
      Begin VB.Image CM_Execute 
         Height          =   330
         Left            =   480
         Picture         =   "frmSRAET53.frx":1C9A
         Top             =   120
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Height          =   330
         Left            =   120
         Picture         =   "frmSRAET53.frx":22EC
         Top             =   120
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  '�ׯ�
         Height          =   555
         Left            =   0
         Top             =   0
         Width           =   3075
      End
   End
   Begin VB.Image Image2 
      Height          =   3375
      Left            =   600
      Top             =   1800
      Width           =   3495
   End
   Begin VB.Label lblDUMMY 
      Height          =   375
      Left            =   0
      TabIndex        =   14
      Top             =   0
      Width           =   135
   End
   Begin VB.Label lblURISU 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      Caption         =   "-999,999"
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   225
      Left            =   1755
      TabIndex        =   3
      Top             =   1560
      Width           =   765
   End
   Begin VB.Label lblHIN2 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      Caption         =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   240
      Left            =   1695
      TabIndex        =   2
      Top             =   1140
      Width           =   3180
   End
   Begin VB.Label lblHIN1 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      Caption         =   "XXXXXXXX"
      BeginProperty Font 
         Name            =   "�l�r �S�V�b�N"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   225
      Left            =   1680
      TabIndex        =   1
      Top             =   825
      Width           =   930
   End
   Begin VB.Label Label8 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      BorderStyle     =   1  '����
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1605
      TabIndex        =   6
      Top             =   1485
      Width           =   1020
   End
   Begin VB.Label Label6 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      BorderStyle     =   1  '����
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1605
      TabIndex        =   4
      Top             =   750
      Width           =   1065
   End
   Begin VB.Label Label7 
      Alignment       =   2  '��������
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      BorderStyle     =   1  '����
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1605
      TabIndex        =   5
      Top             =   1065
      Width           =   3565
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "�����i&1�j"
      Begin VB.Menu MN_Execute 
         Caption         =   "�o�^�i&R�j"
         Shortcut        =   ^R
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "�I���i&X�j"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "�ҏW�i&2�j"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "��ʏ������i&S�j"
         Shortcut        =   ^S
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'***************************************************************************************
'*  �y�g�p�p�r�z�V���A�����o�^
'*  �y�� �� ���z2006/09/29  SYSTEM CREATE CO.,Ltd.
'*  �y�X �V ���z
'*  �y��    �l�z
'***************************************************************************************
Option Explicit

'-�y �ϐ��錾 �z-------------------------------------------------------------------------
'AppPath�ޔ�p
Private L_strAppPath                    As String

'�f�[�^�o�^�p
Private L_strWRTTM                      As String
Private L_strWRTDT                      As String

'�p�����[�^�擾�p
Private L_strRPTCLTID                   As String
Private L_strPRGID                      As String
Private L_strHINCD                      As String
Private L_strSBNNO                      As String
Private L_strURISU                      As String

' �v���p�e�B�l�i�[�p�ϐ�
Dim mstrRPTCLTID                        As String
Dim mstrPRGID                           As String
Dim mstrHINCD                           As String
Dim mstrSBNNO                           As String
Dim mstrURISU                           As String

'�X�v���b�h�ҏW�s�̍ő�l
Private L_lngMAX_EditRow                As Long

'LeaveCell�C�x���g����t���O
Private L_blnLeaveCell                  As Boolean  'True:�C�x���g����, False:�C�x���g������

'�X�V�m�F���b�Z�[�W�L�����Z������ActiveCell�Z�b�g�p
Private L_LastCol                       As Long     '��
Private L_LastRow                       As Long     '�s
'-------------------------------------------------------------------------�y �ϐ��錾 �z-

'-�y �萔�錾 �z-------------------------------------------------------------------------
'�^�C�g��
Private Const LC_strPG_ID               As String = "SRAET53        "
Private Const LC_strTitle               As String = "�V���A�����o�^"

' �p�����[�^ �X�C�b�`��`
Private Const mcPARAM_RPTCLTID          As String = "/RPTCLTID:"
Private Const mcPARAM_PRGID             As String = "/PRGID:"
Private Const mcPARAM_HINCD             As String = "/HINCD:"
Private Const mcPARAM_SBNNO             As String = "/SBNNO:"
Private Const mcPARAM_URISU             As String = "/URISU:"

'�X�v���b�h�w�i�F
Private Const LC_lng_va_Edit_Color      As Long = &HFFFF&
'Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
Private Const LC_lng_va_Lock_Color      As Long = &H8000000F

'�X�v���b�h�̍s
Private Const LC_lngMAX_ROW             As Long = 999999    '�ő�s��
Private Const LC_lngDEFAULT_ROW         As Long = 9999      '�f�t�H���g�Z�b�g�s

'�X�v���b�h�̍���
Private Const LC_lngCol_CHECK           As Long = 1         '�`�F�b�N�{�b�N�X
Private Const LC_lngCol_NO              As Long = 2         '�s��
Private Const LC_lngCol_SERIAL          As Long = 3         '�V���A����
Private Const LC_lngCol_LOCKBN          As Long = 4         '�sۯ��敪
Private Const LC_lngCol_ZAISYOBN        As Long = 5         '�݌ɏ����敪
Private Const LC_lngCol_SBN             As Long = 6         '���ԃR�[�h
Private Const LC_lngCol_HID_SERIAL      As Long = 7         '�����O�V���A����

'* �ő���͌���
Private Const C_lngSERIAL_Len           As Long = 13        '�V���A����
Private Const C_lngTNANO_Len            As Long = 9         '�I��

' �`�F�b�N�{�b�N�X
Private Const C_strCHECKBOX_ON          As String = "1"     'ON
Private Const C_strCHECKBOX_OFF         As String = "9"     'OFF

'�s���b�N�敪
Private Const LC_strLINE_LOCK           As String = "1"     'ۯ�
Private Const LC_strLINE_NOT_LOCK       As String = "9"     'ۯ�����

'�o�׍ς݋敪
Private Const LC_strSYUKA               As String = "02"
Private Const LC_strNOT_SYUKA           As String = "  "

'SQL���������̃��[�h
Private Enum enumCREATE_MODE
    Insert
    Update
    Delete
End Enum

'���b�Z�[�W��
Private Const LC_strAPPEND              As String = "_APPEND        "   '���ʃ��b�Z�[�W
Private Const LC_strCURSOR              As String = "_CURSOR        "   '���ʃ��b�Z�[�W

'���b�Z�[�W�h�c
Private Const CommonMSGSQ               As String = "0"     '* ���ʃ��b�Z�[�W�h�c
Private Const Entry                     As String = "0"     '* �o�^�m�F���b�Z�[�W
Private Const EntryFinal                As String = "1"     '* �o�^�チ�b�Z�[�W
Private Const SerialNoNull              As String = "2"     '* �V���A����NULL
Private Const TnaNoNull                 As String = "3"     '* �I��NULL
Private Const InfSyuka                  As String = "4"     '* �o�׍ς݂̃V���A�����͓��͂���܂����B��낵���ł����H
Private Const InfLineLittle             As String = "5"     '* ���͍s�������ʂ�������Ă��܂��B�o�^���Ă�낵���ł����H
Private Const InfLineOver               As String = "6"     '* ���͍s�������ʂ𒴂��Ă��܂��B
Private Const SerialNoExists            As String = "7"     '* ���͂��Ă���V���A�����Ǘ��e�[�u���ɑ��݂��Ȃ��ׁA�g�p�ł��܂���B
Private Const DoubleSerialNo            As String = "8"     '* �V���A�������d�����Ă��܂��B
Private Const SerialKeta                As String = "9"     '* �V���A������ %N ���܂œ��͉\�ł��B
Private Const TnaNoKeta                 As String = "A"     '* �I�Ԃ� %N ���܂œ��͉\�ł��B
Private Const NotHINCD                  As String = "B"     '* %CD�Ƃ������i�R�[�h�͑��݂��܂���B
'-------------------------------------------------------------------------�y �萔�錾 �z-

'=�y �C�x���g �z=========================================================================

'-�y����޳��ƭ��z-----------------------------------------------------------------------
'===========================================================================
'�y�g�p�p�r�z �o�^(R)�I����
'�y�� �� ���z MN_Execute_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub MN_Execute_Click()
    Call CM_Execute_Click
End Sub

'===========================================================================
'�y�g�p�p�r�z �I��(X)�I����
'�y�� �� ���z MN_EditMn_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub MN_EndCm_Click()
    Call CM_EndCm_Click
End Sub

'===========================================================================
'�y�g�p�p�r�z ��ʏ�����(S)�I����
'�y�� �� ���z MN_APPENDC_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub MN_APPENDC_Click()
    '�X�v���b�h�̃N���A
    Call P_vaData_Init
    '��ʂ̏����\��
    Call P_Show_Data
End Sub

'===========================================================================
'�y�g�p�p�r�z [�I��]�{�^���N���b�N��
'�y�� �� ���z CM_EndCm_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_EndCm_Click()
    Unload Me
End Sub

'===========================================================================
'�y�g�p�p�r�z [�I��]�{�^��MouseDown��
'�y�� �� ���z CM_EndCm_MouseDown
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CM_EndCm.Picture = IM_EndCm(2).Picture
End Sub

'===========================================================================
'�y�g�p�p�r�z [�I��]�{�^��MouseUp��
'�y�� �� ���z CM_EndCm_MouseUp
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CM_EndCm.Picture = IM_EndCm(1).Picture
End Sub

'===========================================================================
'�y�g�p�p�r�z [�I��]�{�^��MouseMove��
'�y�� �� ���z CM_EndCm_MouseMove
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "���j���[�ɖ߂�܂��B"
End Sub

'===========================================================================
'�y�g�p�p�r�z Image2 MouseMove��
'�y�� �� ���z Image2_MouseMove
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub Image2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Screen.MousePointer = vbDefault
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^���N���b�N��
'�y�� �� ���z CM_Execute_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_Click()

    Dim msgMsgBox       As VbMsgBoxResult
    Dim lngRow          As Long
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    Dim strMSGKBN       As String
    Dim strMSGNM        As String

    strMSGKBN = "1"
        
    '�X�v���b�h�̓��̓`�F�b�N
    If P_EntryCheck(lngRow) = False Then
        L_blnLeaveCell = False
        CM_Execute.Picture = IM_Execute(1).Picture
        Exit Sub
    End If
        
    '�L���s���Ɛ��ʂ��r�����b�Z�[�W��؂�ւ���
    If lngRow > CLng(lblURISU.Caption) Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineOver, Mst_Inf)
        If intRet <> 0 Then
            L_blnLeaveCell = False
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
        End If
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '* �Z���w�i�F������
        With vaData
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_CHECK, .MaxRows)
            Call P_Va_BackColor_LINE_LOCK
        End With
        If L_LastCol > 0 And L_LastRow > 0 Then
            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        Else
            If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1)
            End If
        End If
        CM_Execute.Picture = IM_Execute(1).Picture
        Exit Sub
    End If
    
    '�L���s���Ɛ��ʂ��r�����b�Z�[�W��؂�ւ���
    If CLng(lblURISU.Caption) > lngRow Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineLittle, Mst_Inf)
        If intRet <> 0 Then
            L_blnLeaveCell = False
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
        End If
    Else
        strMSGKBN = "0"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strAPPEND, CommonMSGSQ, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            L_blnLeaveCell = False
            CM_Execute.Picture = IM_Execute(1).Picture
            Exit Sub
        End If
    End If
    
    msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
    If msgMsgBox <> vbYes Then
        CM_Execute.Picture = IM_Execute(1).Picture
        L_blnLeaveCell = False
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, vaData.MaxRows)
        Call P_Va_BackColor_LINE_LOCK
        If L_LastCol > 0 And L_LastRow > 0 Then
            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        Else
            If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1)
            End If
        End If
        Exit Sub
    End If
    
    Screen.MousePointer = vbHourglass
    
    '�o�^����
    If P_Main() = True Then
        Call CM_EndCm_Click
        Exit Sub
    End If

EndLabel:
    '* �Z���w�i�F��ݒ�
    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
    
    Screen.MousePointer = vbDefault
    
    L_blnLeaveCell = False
    
    CM_Execute.Picture = IM_Execute(1).Picture
    
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^��MouseDown��
'�y�� �� ���z CM_Execute_MouseDown
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    L_blnLeaveCell = False
    CM_Execute.Picture = IM_Execute(2).Picture
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^��MouseUp��
'�y�� �� ���z CM_Execute_MouseUp
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    L_blnLeaveCell = False
    CM_Execute.Picture = IM_Execute(1).Picture
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^��MouseMove��
'�y�� �� ���z CM_Execute_MouseMove
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "�o�^���܂��B"
End Sub

'===========================================================================
'�y�g�p�p�r�z [�_�~�[]�C���[�WMouseMove��
'�y�� �� ���z Image1_MouseMove
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub

'===========================================================================
'�y�g�p�p�r�z �t�H�[�����[�h��
'�y�� �� ���z Form_Load
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub Form_Load()

    Dim lngIndex    As Long
    Dim strHINNM    As String
    Dim CommandLine As String
    Dim strArry()   As String     ' �����擾�z��
    Dim strRet      As String     ' �������[�N
    Dim strRetU     As String       ' �������[�N
    Dim intRet      As Integer
    Dim strMSGKBN   As String
    Dim Mst_Inf     As TYPE_DB_SYSTBH

    Me.KeyPreview = True
    
    '����v���O�������N�����Ă����ꍇ�͏I������
    If App.PrevInstance Then
        Call GP_MsgBox(Critical, "���ɋN�����Ă��܂��B", LC_strTitle)
        End
    End If
    
    '�t�H�[���̈ʒu���Z�b�g
    Me.Top = (Screen.Height - Me.Height) / 2
    Me.Left = (Screen.Width - Me.Width) / 2
    
    'AppPath�̑ޔ�
    L_strAppPath = App.Path
    
    '�p�����[�^�擾
    strArry = Split(Replace(Command(), """", ""), " ")
    L_strRPTCLTID = Replace(strArry(0), mcPARAM_RPTCLTID, "")
    L_strPRGID = Replace(strArry(1), mcPARAM_PRGID, "")
    L_strHINCD = Replace(strArry(2), mcPARAM_HINCD, "")
    L_strSBNNO = Replace(strArry(3), mcPARAM_SBNNO, "")
    L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
    
    '�p�����[�^�ŕs��������Ζ{��ʂ͋N�������Ȃ�
    If L_strRPTCLTID = "" Then
        Call GP_MsgBox(Critical, "���[�N�X�e�[�V�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
    If L_strPRGID = "" Then
        Call GP_MsgBox(Critical, "�v���O�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
    If L_strHINCD = "" Then
        Call GP_MsgBox(Critical, "���i�R�[�h���ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
    If L_strSBNNO = "" Then
        Call GP_MsgBox(Critical, "���Ԃ��ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
    If L_strURISU = "" Then
        Call GP_MsgBox(Critical, "���㐔�ʂ��ݒ肳��Ă��܂���B", LC_strTitle)
        End
    Else
        If IsNumeric(L_strURISU) = False Then
            Call GP_MsgBox(Critical, "���㐔�ʂ����l�ł͂���܂���B", LC_strTitle)
            End
        End If
    End If

    '�t�H�[���̃N���A
    Call P_FromClear
    
    'DB�ڑ�
    Call CF_Ora_USR1_Open   'USR1
    Call CF_Ora_USR9_Open   'USR9
    
    '�󂯎�����p�����[�^����ʂɃZ�b�g
    lblHIN1.Caption = L_strHINCD
    If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
        lblHIN2.Caption = strHINNM
    Else
        '���݂��Ȃ����i�R�[�h
        strMSGKBN = "1"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NotHINCD, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            End
        End If
        Call GP_MsgBox(Exclamation, Replace(Mst_Inf.MSGCM, "%CD", L_strHINCD), LC_strTitle)
        End
    End If
    lblURISU.Caption = L_strURISU
    
    '��ʂ̏����\��
    Call P_Show_Data
    
    L_LastCol = -1
    L_LastRow = -1
    
End Sub

'===========================================================================
'�y�g�p�p�r�z �A�����[�h��
'�y�� �� ���z Form_QueryUnload
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    'DB�ڑ�����
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
End Sub

'===========================================================================
'�y�g�p�p�r�z �L�[������
'�y�� �� ���z Form_KeyPress
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub Form_KeyPress(KeyAscii As Integer)
    If TypeOf Me.ActiveControl Is TextBox Or _
        TypeOf Me.ActiveControl Is ComboBox Or _
        TypeOf Me.ActiveControl Is OptionButton Then
        
        Call GP_CtrlSend(KeyAscii, Me)
    End If
End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�G�f�B�b�g���[�h�ύX��
'�y�� �� ���z vaData_EditChange
'�y�X �V ���z
'�y��    �l�z�X�v���b�h���ŏI�s�ɒB�������A�V�K���͍s�𐶐�
'===========================================================================
Private Sub vaData_EditChange(ByVal Col As Long, ByVal Row As Long)

    With vaData
        If LC_lngMAX_ROW <> .MaxRows Then
            If .MaxRows = Row Then
                .MaxRows = .MaxRows + 1
                .Row = 1
                .Row2 = .MaxRows
                .Col = LC_lngCol_NO
                .Col2 = LC_lngCol_NO
                .BlockMode = True
                .BackColor = Me.BackColor
                .Protect = True
                .Lock = True
                Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
                Call SetEdit(vaData, LC_lngCol_CHECK, Row + 1)
                Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
                Call SetEdit(vaData, LC_lngCol_LOCKBN, Row + 1)
                Call SetEdit(vaData, LC_lngCol_ZAISYOBN, Row + 1)
                Call SetEdit(vaData, LC_lngCol_SBN, Row + 1)
                Call SetEdit(vaData, LC_lngCol_HID_SERIAL, Row + 1)
            End If
        End If
    End With

End Sub

Private Sub vaData_KeyDown(KeyCode As Integer, Shift As Integer)
    Call F_SendKey(KeyCode)
End Sub

'===========================================================================
'�y�g�p�p�r�z �Z���ړ���
'�y�� �� ���z vaData_LeaveCell
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub vaData_LeaveCell(ByVal Col As Long, ByVal Row As Long, ByVal NewCol As Long, ByVal NewRow As Long, Cancel As Boolean)
    
    Dim lngI            As Long
    Dim lngJ            As Long
    Dim varCHECK        As Variant
    Dim varNO           As Variant
    Dim varSERIAL       As Variant
    Dim varSERIAL_C     As Variant
    Dim varLOCKBN       As Variant
    Dim varNewRowLOCKBN As Variant
    Dim varTNANO        As Variant
    Dim varZAISYOBN     As Variant
    Dim strKBN          As String
    Dim msgMsgBox       As VbMsgBoxResult
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    
    L_blnLeaveCell = True

    '* �Z���w�i�F������
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
        Call P_Va_BackColor_LINE_LOCK
    End With
    
    '�f�[�^���͍ő�s���擾
    L_lngMAX_EditRow = P_Get_EditMaxRow
    
    '�Z���̒l���擾
    Call vaData.GetText(LC_lngCol_ZAISYOBN, Row, varZAISYOBN)
    Call vaData.GetText(LC_lngCol_CHECK, Row, varCHECK)
    Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
    Call vaData.GetText(LC_lngCol_LOCKBN, Row, varLOCKBN)
    If NewRow > 0 Then
        Call vaData.GetText(LC_lngCol_LOCKBN, NewRow, varNewRowLOCKBN)
    End If
    
    '���͕�����啶���ɕϊ����ăZ���ɍăZ�b�g
    Call vaData.SetText(LC_lngCol_SERIAL, Row, StrConv(Nz(varSERIAL), vbUpperCase))
    
    Select Case Col
    '�`�F�b�N�{�b�N�X�̂Ƃ�
        Case LC_lngCol_CHECK
            With vaData
                If varLOCKBN = LC_strLINE_LOCK Then
                    If Row > 0 Then
                        If Row = .MaxRows Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
                        Else
                            If Row = NewRow Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
                            Else
                                If NewCol > 0 And NewRow > 0 Then
                                    If NewCol = LC_lngCol_NO Then
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                                    ElseIf NewCol > LC_lngCol_SERIAL Then
                                        If NewRow = .MaxRows Then
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
                                        Else
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                                        End If
                                    Else
                                        If varNewRowLOCKBN = LC_strLINE_LOCK Then
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                                        Else
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                    End If
                Else
                    If NewCol > 0 And NewRow > 0 Then
                        If NewCol > LC_lngCol_SERIAL Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                        Else
                            If NewCol = LC_lngCol_NO Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
                            ElseIf NewCol > LC_lngCol_SERIAL Then
                                If NewRow = .MaxRows Then
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
                                Else
                                    Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
                                    Call GP_SpActiveCell(vaData, NewCol, NewRow)
                                End If
                            Else
                                Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
                                Call GP_SpActiveCell(vaData, NewCol, NewRow)
                            End If
                        End If
                    End If
                End If
            End With
    
    '�V���A���ԍ��̂Ƃ�
        Case LC_lngCol_SERIAL
            strMSGKBN = "1"
            With vaData
                If Nz(varSERIAL) <> "" Then
                    '���݃`�F�b�N�i�Ǘ��e�[�u���j
                    If P_SRANOCheck(CStr(varSERIAL), strKBN) = False Then
                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoExists, Mst_Inf)
                        If intRet <> 0 Then
                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                            Exit Sub
                        End If
                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                        If Col > 0 And NewRow > 0 Then
                            If Col > LC_lngCol_SERIAL Then
                                If Row = .MaxRows Then
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
                                Else
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
                                End If
                            Else
                                Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                                Call GP_SpActiveCell(vaData, Col, Row)
                            End If
                        Else
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                        End If
                        Exit Sub
                    Else
                        '* �V���A�����d���`�F�b�N
                        lngJ = 1
                        For lngJ = 1 To L_lngMAX_EditRow
                            varSERIAL_C = ""
                            If Row <> lngJ Then
                                Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                                If Nz(varSERIAL_C) <> "" Then
                                    If varSERIAL = varSERIAL_C Then
                                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, DoubleSerialNo, Mst_Inf)
                                        If intRet <> 0 Then
                                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                                            Exit Sub
                                        End If
                                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                                        If Row > 0 Then
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
                                        Else
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                                        End If
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Next

                    '* �擾�����݌ɋ敪���B�����ڂɃZ�b�g
                        If Row > 0 Then
                            Call .SetText(LC_lngCol_ZAISYOBN, Row, strKBN)
                        End If

                    '* �݌ɏ����敪�̏o�׍ςݔ�����s���A�Y�������Ƃ��x�����b�Z�[�W��\��
                        If strKBN = LC_strSYUKA Then
                            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfSyuka, Mst_Inf)
                            If intRet <> 0 Then
                                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                                Exit Sub
                            End If
                            msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
                            If msgMsgBox <> vbYes Then
                                If Col > 0 And Row > 0 Then
                                    Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                                    Call GP_SpActiveCell(vaData, Col, Row)
                                Else
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                                End If
                                Exit Sub
                            End If
                        End If
                    End If
                    '�V���A�����`�F�b�N��OK�̂Ƃ��͎����Ń`�F�b�N�{�b�N�X��ON�ɂ���
                    Call .SetText(LC_lngCol_CHECK, Row, C_strCHECKBOX_ON)

                    If NewCol > LC_lngCol_SERIAL Then
                        If Row = .MaxRows Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
                        Else
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
                        End If
                    ElseIf NewCol < 0 Then
'''                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
'''                        Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
                    Else
                        If NewRow < 0 Then
'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
                        Else
                            If NewCol = LC_lngCol_NO Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                            Else
                                Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
                                Call GP_SpActiveCell(vaData, NewCol, NewRow)
                            End If
                        End If
                    End If
                Else
                    If varCHECK = C_strCHECKBOX_ON Then
                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoNull, Mst_Inf)
                        If intRet <> 0 Then
                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                            Exit Sub
                        End If
                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                        If Row > 0 Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
                        Else
'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
'''                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                        End If
                        Exit Sub
                    Else
                        If NewCol > LC_lngCol_SERIAL Then
                            If Row = .MaxRows Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
                            Else
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
                            End If
                        ElseIf NewCol < 0 Then
'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
                        Else
                            If NewRow < 0 Then
'''                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
'''                                Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
                            Else
                                If NewCol = LC_lngCol_NO Then
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                                Else
                                    If varNewRowLOCKBN = LC_strLINE_LOCK Then
                                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                                        Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                                    Else
                                        Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
                                        Call GP_SpActiveCell(vaData, NewCol, NewRow)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End With
    End Select

    If NewRow - 1 > 0 Then
        '�ォ�珇�Ԃɓ��͂���d�l�ł���ׁA�O�s�̒l��NULL�`�F�b�N��NULL�Ȃ�G���[
        Call vaData.GetText(LC_lngCol_SERIAL, NewRow - 1, varSERIAL)
        If Nz(varSERIAL) = "" Then
            strMSGKBN = "0"
            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strCURSOR, CommonMSGSQ, Mst_Inf)
            If intRet <> 0 Then
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                Exit Sub
            End If
            Call GP_MsgBox(Critical, Mst_Inf.MSGCM, LC_strTitle)
            '* �Z���w�i�F������
            With vaData
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
                Call P_Va_BackColor_LINE_LOCK
            End With
            If Row > 0 Then
                Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                Call GP_SpActiveCell(vaData, Col, Row)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
            End If
            Exit Sub
        End If
    End If
    
    '�ŏI���͍s�̂Ƃ���[�o�^]�{�^���������̏����ďo
    If NewCol = LC_lngCol_LOCKBN And (NewRow > L_lngMAX_EditRow Or NewRow = vaData.MaxRows) Then
        Call vaData.GetText(LC_lngCol_SERIAL, NewRow, varSERIAL)
        If Nz(varSERIAL) = "" Then
            L_lngMAX_EditRow = P_Get_EditMaxRow
            L_blnLeaveCell = True
            L_LastCol = Col
            L_LastRow = Row
            Call CM_EndCm_Click
            L_LastCol = -1
            L_LastRow = -1
            L_blnLeaveCell = False
        End If
    End If

    If L_blnLeaveCell = True Then
        '* �Z���w�i�F������
        With vaData
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
            Call P_Va_BackColor_LINE_LOCK
        End With
        '* �Z���w�i�F��ݒ�
        If NewCol <> -1 Or NewRow <> -1 Then
            If NewCol > LC_lngCol_SERIAL Or varNewRowLOCKBN <> LC_strLINE_LOCK Then
                If NewCol = LC_lngCol_NO Then
                    If Col = LC_lngCol_CHECK Then
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
                    Else
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
                    End If
                Else
                    Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
                    Call GP_SpActiveCell(vaData, NewCol, NewRow)
                End If
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
            End If
        Else
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        End If
    End If
    
    L_blnLeaveCell = False

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�t�H�[�J�X�擾��
'�y�� �� ���z vaData_GotFocus
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub vaData_GotFocus()

    Dim varLOCKBN As Variant

    '�J�[�\������B
    With vaData
        If .ActiveRow > 0 Then
            Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)
            If varLOCKBN = LC_strLINE_LOCK Then
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
            End If
        Else
            txtDummy.SetFocus
        End If
    End With
    
End Sub
'=========================================================================�y �C�x���g �z=

'=�y ���\�b�h �z=========================================================================
'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�w�i�F�ݒ�
'�y�� �� ���z P_Va_BackColor
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_Va_BackColor()

    With vaData
        .Row = 1
        .Row2 = .MaxRows
        .Col = LC_lngCol_NO
        .Col2 = LC_lngCol_NO
        .BlockMode = True
        .BackColor = Me.BackColor
        .BlockMode = False
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�w�i�F�ݒ�(�s���b�N�敪����)
'�y�� �� ���z P_Va_BackColor_LINE_LOCK
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_Va_BackColor_LINE_LOCK()
    
    Dim lngRow          As Long
    Dim varLOCKBN       As Variant

    If IsNumeric(L_lngMAX_EditRow) = False Then
        Exit Sub
    Else
        If L_lngMAX_EditRow <= 0 Then
            Exit Sub
        End If
    End If

    With vaData
        lngRow = 1
        For lngRow = 1 To L_lngMAX_EditRow
            Call .GetText(LC_lngCol_LOCKBN, lngRow, varLOCKBN)
            If varLOCKBN = LC_strLINE_LOCK Then
                Call GP_Va_Col_LockColor_Row(vaData, lngRow)
            End If
        Next
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h���b�N����
'�y�� �� ���z P_Va_Lock
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_Va_Lock()

    With vaData
        .Row = 1
        .Col = LC_lngCol_NO
        .Row2 = .MaxRows
        .Col2 = LC_lngCol_NO
        .BlockMode = True
        .Protect = True
        .BackColor = LC_lng_va_Lock_Color
        .Lock = True
        .BlockMode = False
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�s���b�N����
'�y�� �� ���z P_Va_Lock_Row
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_Va_Lock_Row(ByVal lngRow As Long)

    With vaData
        .Row = lngRow
        .Col = LC_lngCol_NO
        .Row2 = lngRow
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .Protect = True
        .Lock = True
        .BlockMode = False
    End With
    
    Call GP_Va_Col_LockColor_Row(vaData, lngRow)

End Sub

'===========================================================================
'�y�g�p�p�r�z �f�[�^�\��
'�y�� �� ���z P_Show_Data
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_Show_Data() As Boolean

    Dim Usr_Ody_LC  As U_Ody
    Dim lngI        As Long
    Dim intLen      As Integer

    '�f�[�^�̎擾�B
    If P_Get_Data(Usr_Ody_LC) = True Then
        '�f�[�^����ʂɕ\������B
        Call P_Set_Data(Usr_Ody_LC)
    Else
        Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
        Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
        Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
        Call SetEdit(vaData, LC_lngCol_SBN, 1)
        Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
        vaData.MaxRows = LC_lngDEFAULT_ROW
        intLen = Len(CStr(LC_lngMAX_ROW))
        For lngI = 1 To vaData.MaxRows
            Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
            Call vaData.SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
        Next
        Call P_Va_BackColor
    End If
    
    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
    Call GP_Va_Col_LockColor(vaData, LC_lngCol_NO)
    Call P_Va_Lock
    
    
    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
    L_blnLeaveCell = False
    
End Function

'===========================================================================
'�y�g�p�p�r�z �f�[�^�Z�b�g
'�y�� �� ���z P_Set_Data
'�y��    ���z ByRef Usr_Ody_LC As U_Ody   :�_�C�i�Z�b�g���\����
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_Set_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim lngI        As Long
    Dim lngJ        As Long
    Dim blnFLG      As Boolean
    Dim intLen      As Integer
    Dim lngRecCount As Long
    Dim varLOCKBN   As Variant
    Dim varZAISYOBN As Variant

On Error GoTo ErrLbl:
    
    P_Set_Data = False
    
    lngI = 0
    blnFLG = False
    
    intLen = Len(CStr(LC_lngMAX_ROW))
    
    With vaData
        Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
        Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
        Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
        Call SetEdit(vaData, LC_lngCol_SBN, 1)
        Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
        .ReDraw = False
        '�X�v���b�h�̍s���̐ݒ�
        .MaxRows = 0
        '�X�v���b�h�Ƀf�[�^��\������B
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            .MaxRows = .MaxRows + 1
            lngI = lngI + 1
            Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
            If CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", "") = C_strCHECKBOX_ON Then
                Call .SetText(LC_lngCol_CHECK, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", ""))
            End If
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
            Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)
            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            Call .SetText(LC_lngCol_HID_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            Call .SetText(LC_lngCol_LOCKBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "LOCKBN", ""))
            Call .SetText(LC_lngCol_ZAISYOBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", ""))
            Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
            Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
            If varLOCKBN = LC_strLINE_LOCK Then
                Call P_Va_Lock_Row(lngI)
            End If
            Call .SetText(LC_lngCol_SBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SBNNO", ""))
            Call CF_Ora_MoveNext(Usr_Ody_LC)
        Loop
        
        '�����\������X�v���b�h�s���͍Œ�LC_lngDEFAULT_ROW�s�Ƃ���
        lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount
        L_lngMAX_EditRow = lngRecCount
        If lngRecCount > LC_lngDEFAULT_ROW Then
            .MaxRows = lngRecCount
        Else
            .MaxRows = LC_lngDEFAULT_ROW
            blnFLG = True
        End If

        If blnFLG = True Then
            For lngJ = lngI To vaData.MaxRows
                Call .SetText(LC_lngCol_NO, lngJ, Right(Space(intLen) & CStr(lngJ), intLen))
                Call SetEdit(vaData, LC_lngCol_CHECK, lngJ)
                Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
            Next
        End If
        
        .ReDraw = True
    End With
    
    P_Set_Data = True
    

Exit Function
ErrLbl:
    Call GP_MsgBox(Critical, Err.Description)
End Function

'===========================================================================
'�y�g�p�p�r�z �f�[�^�擾
'�y�� �� ���z P_Get_Data
'�y��    ���z ByRef Usr_Ody_LC As U_Ody   :�_�C�i�Z�b�g���\����
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

Dim strSQL          As String
Dim strWKRPTCLTID   As String
Dim strWKPRGID      As String
Dim strWKHINCD      As String
Dim strWKSBNNO      As String

On Error GoTo Errlabel:
    
    P_Get_Data = False
    
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKPRGID = Left(L_strPRGID & Space(7), 7)
    strWKHINCD = Left(L_strHINCD & Space(10), 10)
    strWKSBNNO = Left(L_strSBNNO & Space(20), 20)
    
    'SQL���쐬
    strSQL = ""
    strSQL = strSQL & vbCrLf & "Select"
    strSQL = strSQL & vbCrLf & " RPTCLTID"
    strSQL = strSQL & vbCrLf & " PRGID"
    strSQL = strSQL & vbCrLf & ",HINCD"
    strSQL = strSQL & vbCrLf & ",SBNNO"
    strSQL = strSQL & vbCrLf & ",SRALINNO"
    strSQL = strSQL & vbCrLf & ",SRANO"
    strSQL = strSQL & vbCrLf & ",LOCKBN"
    strSQL = strSQL & vbCrLf & ",ZAISYOBN"
    strSQL = strSQL & vbCrLf & ",CHKFLG"
    strSQL = strSQL & vbCrLf & ",WRTTM"
    strSQL = strSQL & vbCrLf & ",WRTDT"
    strSQL = strSQL & vbCrLf & " From   SRAET53"
    strSQL = strSQL & vbCrLf & " Where  RPTCLTID = " & "'" & StChk(strWKRPTCLTID) & "'"
    strSQL = strSQL & vbCrLf & "   And  PRGID    = " & "'" & StChk(strWKPRGID) & "'"
    strSQL = strSQL & vbCrLf & "   And  HINCD    = " & "'" & StChk(strWKHINCD) & "'"
    strSQL = strSQL & vbCrLf & "   And  SBNNO    = " & "'" & StChk(strWKSBNNO) & "'"    '2008/01/17 ADD
    strSQL = strSQL & vbCrLf & " Order By   SRALINNO"

    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '�擾�f�[�^�L
        P_Get_Data = True
    End If
            
Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_Get_Data)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'�y�g�p�p�r�z ��ʃN���A
'�y�� �� ���z P_FromClear
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_FromClear()
    lblHIN1.Caption = ""
    lblHIN2.Caption = ""
    lblURISU.Caption = ""
    CM_EndCm.Picture = IM_EndCm(1).Picture
    CM_Execute.Picture = IM_Execute(1).Picture
    TX_Message = ""
End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h������
'�y�� �� ���z P_vaData_Init
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub P_vaData_Init()

    Dim lngI    As Long
    Dim lngLine As Long
    Dim intLen  As Integer

    lngI = 0
    lngLine = 0
    intLen = Len(CStr(LC_lngMAX_ROW))

    With vaData
        '�X�v���b�h�̃N���A
        .ReDraw = False
        .Action = ActionClearText
        .MaxRows = LC_lngDEFAULT_ROW
        .Col = LC_lngCol_CHECK
        .Col2 = LC_lngCol_CHECK
        .Row = 1
        .Row2 = .MaxRows
        .CellType = CellTypeCheckBox
        .GridColor = &H0&
        .GridSolid = True
        .TypeCheckType = TypeCheckTypeNormal
        .TypeCheckCenter = True
        .TypeCheckText = ""
        Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
        Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
        Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
        Call SetEdit(vaData, LC_lngCol_SBN, 1)
        Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
        '�s�ԍ����Z�b�g
        For lngI = 0 To vaData.MaxRows
            lngLine = lngLine + 1
            Call .SetText(LC_lngCol_NO, lngLine, Right(Space(intLen) & CStr(lngLine), intLen))
            Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
            Call SetEdit(vaData, LC_lngCol_LOCKBN, lngLine)
            Call SetEdit(vaData, LC_lngCol_ZAISYOBN, lngLine)
            Call SetEdit(vaData, LC_lngCol_SBN, lngLine)
            Call SetEdit(vaData, LC_lngCol_HID_SERIAL, lngLine)
        Next
        .ColsFrozen = LC_lngCol_SERIAL
        .ReDraw = True
    End With

    Call P_Va_BackColor
    Call P_Va_Lock
    
End Sub

'===========================================================================
'�y�g�p�p�r�z ���i���擾
'�y�� �� ���z P_GET_HINNMA
'�y��    ���z ByVal strHINCD As String   :���i�R�[�h
'�y��    ���z ByRef strHINNMA As String  :���i��
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_GET_HINNMA(ByVal strHINCD As String, _
                              ByRef strHINNMA As String) As Boolean
    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKHINCD  As String

    P_GET_HINNMA = False
    
    '���i�R�[�h��10���ɂ���
    strWKHINCD = Left(strHINCD & Space(10), 10)

    'SQL���쐬
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  HINNMA "
    strSQL = strSQL & " FROM    HINMTA"
    strSQL = strSQL & " WHERE   HINCD = '" & strWKHINCD & "'"

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '�擾�f�[�^�L
            strHINNMA = CF_Ora_GetDyn(Usr_Ody_LC, "HINNMA", "")
        P_GET_HINNMA = True
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'�y�g�p�p�r�z �V���A�������݃`�F�b�N�i�Ǘ��e�[�u���j
'�y�� �� ���z P_SRANOCheck
'�y��    ���z ByVal strSRANO As String  :�V���A����
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_SRANOCheck(ByVal strSRANO As String, _
                              ByRef strZAISYOBN As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKSRANO   As String
    Dim strWKHINCD   As String

    P_SRANOCheck = False
    strZAISYOBN = ""
    
    strWKSRANO = Left(strSRANO & Space(13), 13)
    strWKHINCD = Left(L_strHINCD & Space(10), 10)

    'SQL���쐬
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * " & vbCrLf
    strSQL = strSQL & " FROM    SRACNTTB" & vbCrLf
    strSQL = strSQL & " WHERE   SRANO    = '" & strWKSRANO & "'" & vbCrLf
    strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'" & vbCrLf
    
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '�擾�f�[�^�L
        strZAISYOBN = CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", "")
        
        P_SRANOCheck = True
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'�y�g�p�p�r�z �V���A�������݃`�F�b�N�i���[�N�t�@�C���j
'�y�� �� ���z P_SRANOCheckWK
'�y��    ���z ByVal strSRANO As String  :�V���A����
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_SRANOCheckWK(ByVal strSRANO As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKRPTCLTID   As String
    Dim strWKPRGID   As String
    Dim strWKHINCD   As String
    Dim strWKSRANO   As String
    Dim strWKSBNNO   As String

    P_SRANOCheckWK = False
    
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKPRGID = Left(L_strPRGID & Space(7), 7)
    strWKHINCD = Left(L_strHINCD & Space(10), 10)
    strWKSRANO = Left(strSRANO & Space(13), 13)
    strWKSBNNO = Left(L_strSBNNO & Space(20), 20)   '2008/01/17 ADD

    'SQL���쐬
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * "
    strSQL = strSQL & " FROM    SRAET53"
    strSQL = strSQL & " WHERE   RPTCLTID = '" & strWKRPTCLTID & "'"
    strSQL = strSQL & "   AND   PRGID    = '" & strWKPRGID & "'"
    strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'"
    strSQL = strSQL & "   AND   SRANO    = '" & strWKSRANO & "'"
    strSQL = strSQL & "   AND   SBNNO    = '" & strWKSBNNO & "'"
    
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '�擾�f�[�^�L
        P_SRANOCheckWK = True
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h���̓`�F�b�N�i���C���j
'�y�� �� ���z P_EntryCheck
'�y��    ���z ByRef lngEntryLine As Long  :�L���s��
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_EntryCheck(ByRef lngEntryLine As Long) As Boolean
    
    P_EntryCheck = False
    
    'NULL�`�F�b�N�A�V���A�������݃`�F�b�N�A�V���A�����d���`�F�b�N
    If P_NULLCheck(lngEntryLine) = False Then Exit Function
    
    P_EntryCheck = True

End Function

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h���̓`�F�b�N�A�V���A�������݃`�F�b�N
'�y�� �� ���z P_NULLCheck
'�y��    ���z ByRef lngEntryLine As Long  :�L���s��
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_NULLCheck(ByRef lngEntryLine As Long) As Boolean

    Dim lngI            As Long
    Dim lngJ            As Long
    Dim varCHECK        As Variant
    Dim varNO           As Variant
    Dim varSERIAL       As Variant
    Dim varSERIAL_C     As Variant
    Dim varTNANO        As Variant
    Dim strKBN          As String
    Dim msgMsgBox       As VbMsgBoxResult
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    
    strMSGKBN = "1"
    lngEntryLine = 0
    
    P_NULLCheck = False

    '�f�[�^���͍ő�s���擾
    L_lngMAX_EditRow = P_Get_EditMaxRow

    For lngI = 1 To L_lngMAX_EditRow
        With vaData
            '�X�v���b�h�f�[�^���擾
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            If varCHECK = C_strCHECKBOX_ON Then
                If varSERIAL <> vbNullString Then
                    '* �V���A�����d���`�F�b�N
                    lngJ = 1
                    For lngJ = 1 To L_lngMAX_EditRow
                        varSERIAL_C = ""
                        If lngI <> lngJ Then
                            Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                            If Nz(varSERIAL_C) <> "" Then
                                If varSERIAL = varSERIAL_C Then
                                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, DoubleSerialNo, Mst_Inf)
                                    If intRet <> 0 Then
                                        Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                                        Exit Function
                                    End If
                                    Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                                    If lngJ > 0 Then
                                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, lngJ, True)
                                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, lngJ)
                                    Else
                                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, lngI, True)
                                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, lngI)
                                    End If
                                    Exit Function
                                End If
                            End If
                        End If
                    Next
                    lngEntryLine = lngEntryLine + 1
                End If
            End If
        End With
    Next lngI

    P_NULLCheck = True

End Function

'===========================================================================
'�y�g�p�p�r�z �L���s�̍ő�s�����擾
'�y�� �� ���z P_Get_EditMaxRow
'�y��    �l�z Long
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_Get_EditMaxRow() As Long

    Dim lngI            As Long
    Dim lngLine         As Long
    Dim varCHECK        As Variant
    Dim varSERIAL       As Variant
    Dim varHIDSERIAL    As Variant

    P_Get_EditMaxRow = 0
    
    lngI = 1
    With vaData
        For lngI = 1 To .MaxRows
            lngLine = .MaxRows - lngI
            Call .GetText(LC_lngCol_CHECK, lngLine, varCHECK)
            Call .GetText(LC_lngCol_SERIAL, lngLine, varSERIAL)
            Call .GetText(LC_lngCol_HID_SERIAL, lngLine, varHIDSERIAL)
            If Nz(varSERIAL) <> "" Or Nz(varHIDSERIAL) <> "" Then
                P_Get_EditMaxRow = lngLine
                Exit For
            End If
        Next
    End With

End Function

'===========================================================================
'�y�g�p�p�r�z SQL�����������s
'�y�� �� ���z P_EXECUTE_SQL
'�y��    ���z ByVal strMode     As enumCREATE_MODE  :SQL�������[�h
'�y��    ���z ByVal strSRALINNO As String           :��ʍs�ԍ�
'�y��    ���z ByVal strCHECK    As String           :�`�F�b�N�{�b�N�X
'�y��    ���z ByVal strSRANO    As String           :�V���A����
'�y��    ���z ByVal strLOCATION As String           :�I��
'�y��    ���z ByVal strZAISYOBN As String           :�݌ɏ����敪
'�y��    ���z ByVal strSBN      As String           :���ԃR�[�h
'�y��    ���z ByVal strWRTTM    As String           :�f�[�^�쐬����
'�y��    ���z ByVal strWRTDT    As String           :�f�[�^�쐬���t
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, _
                               ByVal strSRALINNO As String, _
                               ByVal strCHECK As String, _
                               ByVal strSRANO As String, _
                               ByVal strZAISYOBN As String, _
                               ByVal strSBN As String, _
                               ByVal strWRTTM As String, _
                               ByVal strWRTDT As String) As Boolean
    Dim strSQL As String
    Dim strCHK As String
    Dim strKBN As String
    
    P_EXECUTE_SQL = False
    
    strSQL = vbNullString
    
    '�`�F�b�N�t���O����
    If strCHECK = C_strCHECKBOX_ON Then
        strCHECK = C_strCHECKBOX_ON
    Else
        strCHECK = C_strCHECKBOX_OFF
    End If
    
    '�݌ɏ����敪����
    If Trim(strZAISYOBN) <> "" Then
        strKBN = strZAISYOBN
    Else
        strKBN = LC_strNOT_SYUKA
    End If

    Select Case strMode
        Case Insert
            strSQL = strSQL & " INSERT INTO SRAET53 (" & vbCrLf
            strSQL = strSQL & "                      RPTCLTID," & vbCrLf
            strSQL = strSQL & "                      PRGID," & vbCrLf
            strSQL = strSQL & "                      HINCD," & vbCrLf
            strSQL = strSQL & "                      SBNNO," & vbCrLf
            strSQL = strSQL & "                      SRALINNO," & vbCrLf
            strSQL = strSQL & "                      SRANO," & vbCrLf
            strSQL = strSQL & "                      LOCKBN," & vbCrLf
            strSQL = strSQL & "                      CHKFLG, " & vbCrLf
            strSQL = strSQL & "                      ZAISYOBN, " & vbCrLf
            strSQL = strSQL & "                      WRTTM," & vbCrLf
            strSQL = strSQL & "                      WRTDT" & vbCrLf
            strSQL = strSQL & "                     )" & vbCrLf
            strSQL = strSQL & " VALUES  (" & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strRPTCLTID) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strPRGID) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strHINCD) & "'," & vbCrLf
''            strSQL = strSQL & "          '" & Space(20) & "'," & vbCrLf
''            strSQL = strSQL & "          '" & StChk(strSBN) & "'," & vbCrLf       '2008/01/17 UPD-DEL
            strSQL = strSQL & "          '" & StChk(L_strSBNNO) & "'," & vbCrLf     '2008/01/17 UPD-ADD
            strSQL = strSQL & "          '" & StChk(strSRALINNO) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strSRANO) & "'," & vbCrLf
            strSQL = strSQL & "          '" & LC_strLINE_NOT_LOCK & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strCHECK) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strKBN) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strWRTTM) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strWRTDT) & "'" & vbCrLf
            strSQL = strSQL & "         )" & vbCrLf

        Case Update
            strSQL = strSQL & " UPDATE SRAET53" & vbCrLf
            strSQL = strSQL & "   SET  SRANO    = '" & StChk(strSRANO) & "'" & vbCrLf
            strSQL = strSQL & "       ,CHKFLG   = '" & StChk(strCHECK) & "'" & vbCrLf
            strSQL = strSQL & "       ,WRTTM    = '" & StChk(strWRTTM) & "'" & vbCrLf
            strSQL = strSQL & "       ,WRTDT    = '" & StChk(strWRTDT) & "'" & vbCrLf
            strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
            strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
            strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
            strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf     '2008/01/17 ����
            strSQL = strSQL & "   AND  SRALINNO = '" & Format(strSRALINNO, "000000") & "'" & vbCrLf

        Case Delete
            strSQL = strSQL & " DELETE FROM SRAET53" & vbCrLf
            strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
            strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
            strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
            strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf     '2008/01/17 ����
            strSQL = strSQL & "   AND  SRALINNO = '" & Format(strSRALINNO, "000000") & "'" & vbCrLf

    End Select
    
    'SQL�𔭍s����
    If CF_Ora_Execute(gv_Odb_USR9, strSQL) = False Then
        Exit Function
    End If
        
    P_EXECUTE_SQL = True

End Function

'=======================================================================================
'�y�g�p�p�r�z �f�[�^�o�^�����i���C���j
'�y�� �� ���z P_Main
'�y�X �V ���z
'�y��    �l�z
'=======================================================================================
Private Function P_Main() As Boolean

    Dim lngI            As Long
    Dim lngLineNo       As Long
    Dim strSQL          As String
    Dim varCHECK        As Variant
    Dim varNO           As Variant
    Dim varSERIAL       As Variant
    Dim varLOCKBN       As Variant
    Dim varZAISYOBN     As Variant
    Dim varSBN          As Variant
    Dim varHIDSERIAL    As Variant
    Dim datNOW          As Date
    Dim intCnt          As Integer
    Dim intMaxKeta      As Integer
    Dim strZero         As String
    Dim strCREATE_MODE  As enumCREATE_MODE

    P_Main = False
    
    'BEGIN TRAN
    If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        GoTo EndLbl:
    End If
    
    '�o�^�����𐶐�
    datNOW = Now
    L_strWRTTM = Format(datNOW, "HHMMSS")
    L_strWRTDT = Format(datNOW, "YYYYMMDD")
    
    '�s�ԍ��pZERO������ݒ�
    intCnt = 0
    intMaxKeta = Len(CStr(LC_lngMAX_ROW))
    For intCnt = 0 To intMaxKeta - 1
        strZero = strZero & "0"
    Next

    '�f�[�^�o�^
    lngI = 0
    lngLineNo = 0
    For lngI = 1 To L_lngMAX_EditRow
        With vaData
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
            Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
            Call .GetText(LC_lngCol_SBN, lngI, varSBN)
            Call .GetText(LC_lngCol_HID_SERIAL, lngI, varHIDSERIAL)
            If Nz(varSERIAL) <> "" Then
                lngLineNo = lngLineNo + 1
                ' �����敪���肷��
                If varLOCKBN = LC_strLINE_LOCK Then
                    strCREATE_MODE = Update
                Else
                    '����͍s
                    If P_SRANOCheckWK(CStr(varSERIAL)) = False Then
                        strCREATE_MODE = Update
                    Else
                        strCREATE_MODE = Insert
                    End If
                End If
                
                If P_EXECUTE_SQL(strCREATE_MODE, _
                                 Format(lngLineNo, strZero), _
                                 CStr(varCHECK), _
                                 CStr(varSERIAL), _
                                 CStr(varZAISYOBN), _
                                 CStr(varSBN), _
                                 L_strWRTTM, _
                                 L_strWRTDT) = False Then
                    GoTo EndLbl:
                End If
            Else
                lngLineNo = lngLineNo + 1
                If Nz(varHIDSERIAL) <> "" Then
                    strCREATE_MODE = Delete
                    If P_EXECUTE_SQL(strCREATE_MODE, _
                                     Format(lngLineNo, strZero), _
                                     CStr(varCHECK), _
                                     CStr(varSERIAL), _
                                     CStr(varZAISYOBN), _
                                     CStr(varSBN), _
                                     L_strWRTTM, _
                                     L_strWRTDT) = False Then
                        GoTo EndLbl:
                    End If
                End If
            End If
        End With
    Next lngI

    'COMMIT
    Call CF_Ora_CommitTrans(gv_Oss_USR9)
    
    P_Main = True
    
    Exit Function
    
    GoTo EndLbl:
ErrLbl:
    '���[���o�b�N
    Call CF_Ora_RollbackTrans(gv_Oss_USR9)
EndLbl:

End Function

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�̗�̃��b�N�F�ݒ�B
'�y�� �� ���z GP_Va_Col_LockColor
'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
'�y��    ���z ByVal lngCol As long�F��ԍ�
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Public Sub GP_Va_Col_LockColor(ByRef objSpread As Object, ByVal lngCol As Long)

    '�X�v���b�h�̔w�i�F�̐ݒ�B
    With objSpread
        .ReDraw = False
        .Row = 1
        .Col = lngCol
        .Row2 = .MaxRows
        .Col2 = lngCol
        .BlockMode = True
        .BackColor = LC_lng_va_Lock_Color
        .BlockMode = False
        .ReDraw = True
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�̗�̃��b�N�F�ݒ�B
'�y�� �� ���z GP_Va_Col_LockColor_Row
'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
'�y��    ���z ByVal lngRow As Long�F�s�ԍ�
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Public Sub GP_Va_Col_LockColor_Row(ByRef objSpread As Object, ByVal lngRow As Long)

    '�X�v���b�h�̔w�i�F�̐ݒ�B
    With objSpread
        .ReDraw = False
        .Row = lngRow
        .Col = LC_lngCol_NO
        .Row2 = lngRow
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .BackColor = Me.BackColor
        .BlockMode = False
        .ReDraw = True
    End With

End Sub

'=======================================================================================
'�y�g�p�p�r�z �X�v���b�h�̗�̕ҏW���F�ݒ�y�щ����B
'�y�� �� ���z GP_Va_Col_EditColor
'�y��    ���z ByRef objSpread As Object�F�X�v���b�h
'�y��    ���z ByVal lngCol As long�F��ԍ�
'�y��    ���z ByVal lngRow As long�F�s�ԍ�
'�y��    ���z ByVal bolEdit As Boolean�F�ҏW���̏ꍇTRUE�F�ҏW�����甲����Ƃ��ɂ�False
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'=======================================================================================
Public Sub GP_Va_Col_EditColor(ByRef objSpread As Object, _
                               ByVal lngCol As Long, _
                               ByVal lngRow As Long, _
                               ByVal bolEdit As Boolean, _
                               Optional ByVal lngCol2 As Long = 0, _
                               Optional ByVal lngRow2 As Long = 0)

    Dim varZAISYOBN As Variant
    Dim lngI        As Long

    '�X�v���b�h�̔w�i�F�̐ݒ�B
    With objSpread
        .ReDraw = False
        .Row = lngRow
        .Col = lngCol
        .BlockMode = True
        If bolEdit Then
            .Row2 = lngRow
            .Col2 = lngCol
            .BackColor = LC_lng_va_Edit_Color
        Else
            If lngRow2 <> 0 Then
                .Row2 = lngRow2
            Else
                .Row2 = lngRow
            End If
            If lngCol2 <> 0 Then
                .Col2 = lngCol2
            Else
                .Col2 = lngCol
            End If
            .BackColor = vbWhite
        End If
        .BlockMode = False
        .ReDraw = True
    End With

    With objSpread
        .ReDraw = False
        .Row = lngRow
        .Col = LC_lngCol_NO
        If lngRow2 <> 0 Then
            .Row2 = lngRow2
        Else
            .Row2 = lngRow
        End If
        .Col2 = LC_lngCol_NO
        .BlockMode = True
        .BackColor = Me.BackColor
        .BlockMode = False
        .ReDraw = True
    End With

End Sub

'=======================================================================================
'�y�g�p�p�r�z �e�L�X�g���ڂ�ݒ�
'�y�� �� ���z SetEdit
'�y��    ���z ByRef objSpread   As Object�F�X�v���b�h
'�y��    ���z ByVal lngCol      As long  �F��ԍ�
'�y��    ���z ByVal lngRow      As long  �F�s�ԍ�
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'=======================================================================================
Private Sub SetEdit(ByRef objSpread As Object, _
                    ByVal lngCol As Long, _
                    ByVal lngRow As Long)
    With vaData
        .ReDraw = False
        .Col = lngCol
        .Col2 = lngCol
        .Row = lngRow
        .Row2 = lngRow
        .GridSolid = True
        .GridColor = &H0&
        .FontSize = 12
        If lngCol = LC_lngCol_CHECK Then
            .Col = LC_lngCol_CHECK
            .Col2 = LC_lngCol_CHECK
            .Row = lngRow
            .Row2 = lngRow
            .CellType = CellTypeCheckBox
            .TypeCheckType = TypeCheckTypeNormal
            .TypeCheckCenter = True
            .TypeCheckText = ""
        Else
            .CellType = CellTypeEdit                        '��������
            .TypeEditCharSet = TypeEditCharSetAlphanumeric  '���p�p����
            .Position = PositionCenterLeft
        End If
        '���͌������Z�b�g
        Select Case lngCol
            Case LC_lngCol_SERIAL: .TypeMaxEditLen = C_lngSERIAL_Len
        End Select
        .ReDraw = True
    End With
End Sub

Private Sub vaData_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)

    Dim varLOCKBN As Variant

    With vaData
        Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)
        
        If varLOCKBN = LC_strLINE_NOT_LOCK Then
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
        End If
    End With

End Sub

Private Sub vaData_Validate(Cancel As Boolean)
    L_lngMAX_EditRow = P_Get_EditMaxRow
End Sub

Private Sub F_SendKey(ByVal KeyCode As Integer)
    Select Case KeyCode
        Case vbKeyF1: SendKeys "%1"
        Case vbKeyF2: SendKeys "%2"
    End Select
End Sub
'=========================================================================�y ���\�b�h �z=

