VERSION 5.00
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "SPR32X30.ocx"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '�Œ�(����)
   Caption         =   "�V���A�����o�^"
   ClientHeight    =   5925
   ClientLeft      =   150
   ClientTop       =   720
   ClientWidth     =   5625
   Icon            =   "frmSRAET52.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5925
   ScaleWidth      =   5625
   StartUpPosition =   3  'Windows �̊���l
   Begin VB.TextBox txtDummy 
      Appearance      =   0  '�ׯ�
      BorderStyle     =   0  '�Ȃ�
      Height          =   270
      Left            =   4080
      TabIndex        =   14
      Top             =   4800
      Width           =   15
   End
   Begin VB.Frame Frame1 
      Appearance      =   0  '�ׯ�
      ForeColor       =   &H80000008&
      Height          =   660
      Left            =   0
      TabIndex        =   10
      Top             =   6000
      Width           =   4440
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   2
         Left            =   2760
         Picture         =   "frmSRAET52.frx":030A
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   1
         Left            =   2280
         Picture         =   "frmSRAET52.frx":0494
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   2
         Left            =   1560
         Picture         =   "frmSRAET52.frx":061E
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   1
         Left            =   1200
         Picture         =   "frmSRAET52.frx":0C70
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   2
         Left            =   600
         Picture         =   "frmSRAET52.frx":12C2
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   1
         Left            =   240
         Picture         =   "frmSRAET52.frx":144C
         Top             =   240
         Width           =   360
      End
   End
   Begin FPSpread.vaSpread vaData 
      Height          =   3180
      Left            =   1080
      TabIndex        =   0
      Top             =   1935
      Width           =   3135
      _Version        =   196608
      _ExtentX        =   5530
      _ExtentY        =   5609
      _StockProps     =   64
      AllowCellOverflow=   -1  'True
      AllowMultiBlocks=   -1  'True
      ArrowsExitEditMode=   -1  'True
      BackColorStyle  =   1
      ColHeaderDisplay=   1
      DisplayRowHeaders=   0   'False
      EditEnterAction =   5
      EditModePermanent=   -1  'True
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
      MaxCols         =   3
      MaxRows         =   10
      ProcessTab      =   -1  'True
      Protect         =   0   'False
      RetainSelBlock  =   0   'False
      ScrollBars      =   2
      SelectBlockOptions=   0
      SpreadDesigner  =   "frmSRAET52.frx":15D6
      UserResize      =   0
      VisibleCols     =   3
      VisibleRows     =   1
   End
   Begin VB.Frame Box 
      Appearance      =   0  '�ׯ�
      ForeColor       =   &H80000008&
      Height          =   660
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   5640
      Begin VB.Image CM_Execute 
         Height          =   330
         Left            =   600
         Picture         =   "frmSRAET52.frx":1D9C
         Top             =   240
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Height          =   330
         Left            =   240
         Picture         =   "frmSRAET52.frx":23EE
         Top             =   240
         Width           =   360
      End
      Begin VB.Image Image1 
         Height          =   615
         Left            =   0
         Top             =   120
         Width           =   3615
      End
   End
   Begin Threed5.SSPanel5 SSPanel52 
      Height          =   330
      Left            =   600
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
      Left            =   600
      TabIndex        =   9
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
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   0
      TabIndex        =   11
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
         TabIndex        =   12
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
            TabIndex        =   13
            Text            =   "frmSRAET52.frx":2578
            Top             =   70
            Width           =   5955
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  '�ׯ�
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "frmSRAET52.frx":25AF
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.Image Image2 
      Height          =   3495
      Left            =   960
      Top             =   1800
      Width           =   3375
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
      Left            =   1635
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
      Left            =   1575
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
      Left            =   1575
      TabIndex        =   1
      Top             =   825
      Width           =   930
   End
   Begin VB.Label Label8 
      Alignment       =   1  '�E����
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      BackStyle       =   0  '����
      BorderStyle     =   1  '����
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1485
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
      Left            =   1485
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
      Left            =   1485
      TabIndex        =   5
      Top             =   1065
      Width           =   3285
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
'*  �y�� �� ���z2006/09/04  SYSTEM CREATE CO,.Ltd.
'*  �y�X �V ���z2008/08/05  FKS)NAKATA
'*  �y��    �l�z �V���A���Ǘ��e�[�u���̌�������������ѓ����O���A�Y������SBNNO��HIMCD��
'*               ����ΑS�ďo�͂�����
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
'2008/08/06 CHG START FKS)NAKATA
'Private L_strRSTDT                      As String
Private L_strJDNNO                      As String
'2008/08/06 CHG E.N.D FKS)NAKATA
Private L_strHINCD                      As String
Private L_strSBNNO                      As String
Private L_strURISU                      As String

' �v���p�e�B�l�i�[�p�ϐ�
Dim mstrRPTCLTID                        As String
Dim mstrRSTDT                           As String
Dim mstrHINCD                           As String
Dim mstrSBNNO                           As String
Dim mstrURISU                           As String

'* �ő���͌���
'2008/08/06 CHG START FKS)NAKATA
''Private Const C_lngSERIAL_Len           As Long = 13        '�V���A����
Private Const C_lngSERIAL_Len           As Long = 22        '�V���A���� & ���ѓ�
'2008/08/06 CHG E.N.D FKS)NAKATA

Private LC_lngDataMAX_ROW               As Long
Private LC_lngCurrent                   As Long

'�X�V�m�F���b�Z�[�W�L�����Z������ActiveCell�Z�b�g�p
Private L_LastCol                       As Long     '��
Private L_LastRow                       As Long     '�s
'-------------------------------------------------------------------------�y �ϐ��錾 �z-

'-�y �萔�錾 �z-------------------------------------------------------------------------
'�^�C�g��
Private Const LC_strPG_ID               As String = "SRAET52"
Private Const LC_strTitle               As String = "�V���A�����o�^"

' �p�����[�^ �X�C�b�`��`
Private Const mcPARAM_RPTCLTID          As String = "/RPTCLTID:"
'2008/08/06 CHG START FKS)NAKATA
''���ѓ�����󒍔ԍ��ɕύX
'Private Const mcPARAM_RSTDT             As String = "/RSTDT:"
Private Const mcPARAM_JDNNO             As String = "/JDNNO:"
'2008/08/06 CHG E.N.D FKS)NAKATA
Private Const mcPARAM_HINCD             As String = "/HINCD:"
Private Const mcPARAM_SBNNO             As String = "/SBNNO:"
Private Const mcPARAM_URISU             As String = "/URISU:"

'�X�v���b�h�w�i�F
Private Const LC_lng_va_Edit_Color      As Long = &HFFFF&
Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
Private Const LC_lng_va_Lock_Color      As Long = &HC0C0C0

'�X�v���b�h�̍s
Private Const LC_lngMAX_ROW             As Long = 999999    '* �ő�s��
Private Const LC_lngDEFAULT_ROW         As Long = 1         '* �f�t�H���g�Z�b�g�s

'�X�v���b�h�̍���
Private Const LC_lngCol_CHECK           As Long = 1         '* �ԕi�`�F�b�N
Private Const LC_lngCol_NO              As Long = 2         '* �s��
Private Const LC_lngCol_SERIAL          As Long = 3         '* �V���A����

'�o�׍ς݋敪
Private Const LC_strSYUKA               As String = "02"

'SQL���������̃��[�h
Private Enum enumCREATE_MODE
    Ins
    Del
End Enum

'���b�Z�[�W��
Private Const LC_strAPPEND              As String = "_APPEND        "   '* ���ʃ��b�Z�[�W
Private Const LC_strCURSOR              As String = "_CURSOR        "   '* ���ʃ��b�Z�[�W

'���b�Z�[�W�h�c
Private Const CommonMSGSQ               As String = "0"     '* ���ʃ��b�Z�[�W�h�c
Private Const Entry                     As String = "0"     '* �o�^�m�F���b�Z�[�W
Private Const EntryFinal                As String = "1"     '* �o�^�チ�b�Z�[�W
Private Const NotHINCD                  As String = "2"     '* %CD�Ƃ������i�R�[�h�͑��݂��܂���B
Private Const NoData                    As String = "3"     '* �Y���f�[�^�����݂��܂���B
Private Const NotSerial                 As String = "4"     '* �ԕi�ς̃V���A���������͂���܂����B��낵���ł����B
Private Const NoCheck                   As String = "5"     '* �o�^�Ώۂ̃f�[�^������܂���B
Private Const InfLineOver               As String = "6"     '* ���͍s�������ʂƍ����܂���B
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
    Call Form_Load
End Sub
'-----------------------------------------------------------------------�y����޳��ƭ��z-

'===========================================================================
'�y�g�p�p�r�z [�I��]�{�^���N���b�N��
'�y�� �� ���z CM_EndCm_Click
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_EndCm_Click()
    '* �Z���w�i�F������
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
    End With
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
    Dim lngChkRow       As Long
    Dim blnInsFlg       As Boolean

    strMSGKBN = "1"
    lngChkRow = 0
    blnInsFlg = False

    '* �Z���w�i�F������
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
    End With
    
    '�X�v���b�h�̓��̓`�F�b�N
    If P_EntryCheck(lngRow) = False Then
        Exit Sub
    Else
'''        '���ׂɃ`�F�b�N�������Ă��Ȃ��Ƃ��͏����I��
'''        If lngRow = 0 Then
'''            strMSGKBN = "1"
'''            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoCheck, Mst_Inf)
'''            If intRet <> 0 Then
'''                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
'''                Exit Sub
'''            End If
'''            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'''            If L_LastCol > 0 And L_LastRow > 0 Then
'''                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
'''                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
'''            Else
'''                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
'''                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
'''            End If
'''            Exit Sub
'''        End If
        '�I���s�������ʂƓ������Ȃ��Ƃ��̓G���[
        If lngRow <> CLng(Me.lblURISU.Caption) Then
            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineOver, Mst_Inf)
            If intRet <> 0 Then
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                Exit Sub
            End If
            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
            Exit Sub
        End If
        
        '�V���A�����`�F�b�N
        With vaData
            For lngChkRow = 1 To .MaxRows
                If P_EntryCheckSerial(lngChkRow) = False Then
                    strMSGKBN = "1"
                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NotSerial, Mst_Inf)
                    If intRet <> 0 Then
                        Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
                        Exit Sub
                    End If
                    msgMsgBox = GP_MsgBox(enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
                    If msgMsgBox <> vbYes Then
                        If lngChkRow > 0 Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
                        Else
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                        End If
                        Exit Sub
                    Else
                        blnInsFlg = True
                    End If
                End If
            Next
        End With
    End If

    If blnInsFlg = False Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, Entry, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
        End If
        msgMsgBox = GP_MsgBox(enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        If msgMsgBox <> vbYes Then
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
    '        If L_LastCol > 0 And L_LastRow > 0 Then
    '            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
    '            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
    '        Else
    '            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
    '            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
    '        End If
            Exit Sub
        End If
    End If
    
    Screen.MousePointer = vbHourglass
    
    '�o�^����
    If P_Main() = True Then
    '* �f�[�^�o�^��͉�ʂ����
        Call CM_EndCm_Click
        Exit Sub
    End If

EndLabel:
    '* �Z���w�i�F��ݒ�
    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
    
    Screen.MousePointer = vbDefault
    
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^��MouseDown��
'�y�� �� ���z CM_Execute_MouseDown
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CM_Execute.Picture = IM_Execute(2).Picture
End Sub

'===========================================================================
'�y�g�p�p�r�z [�o�^]�{�^��MouseUp��
'�y�� �� ���z CM_Execute_MouseUp
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
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
'2008/08/07 CHG START FKS)NAKATA
''���ѓ�����󒍔ԍ��ɕύX
''    L_strRSTDT = Replace(strArry(1), mcPARAM_RSTDT, "")
    L_strJDNNO = Replace(strArry(1), mcPARAM_JDNNO, "")
'2008/08/07 CHG E.N.D FKS)NAKATA
    L_strHINCD = Replace(strArry(2), mcPARAM_HINCD, "")
    L_strSBNNO = Replace(strArry(3), mcPARAM_SBNNO, "")
    L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
    
    '�p�����[�^�ŕs��������Ζ{��ʂ͋N�������Ȃ�
    If L_strRPTCLTID = "" Then
        Call GP_MsgBox(Critical, "���[�N�X�e�[�V�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
    
'2008/08/06 CHG START FKS)NAKATA
'' ���ѓ�����󒍔ԍ��ɕύX
''    If L_strRSTDT = "" Then
''        Call GP_MsgBox(Critical, "���ѓ����ݒ肳��Ă��܂���B", LC_strTitle)
''        End
''    End If
    If L_strJDNNO = "" Then
        Call GP_MsgBox(Critical, "�󒍔ԍ����ݒ肳��Ă��܂���B", LC_strTitle)
        End
    End If
'2008/08/06 CHG E.N.D FKS)NAKATA

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
    
    '�X�v���b�h�̏�����
    Call P_vaData_Init
                
    'DB�ڑ�
    Call CF_Ora_USR1_Open
    Call CF_Ora_USR9_Open
    
    '�󂯎�����p�����[�^����ʂɃZ�b�g
    lblHIN1.Caption = L_strHINCD
    If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
        lblHIN2.Caption = strHINNM
    Else
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
    LC_lngCurrent = 1
    
    '��ʂ̏����\��
    If P_Show_Data = False Then
        '�f�[�^���Ȃ��Ƃ�
        strMSGKBN = "1"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoData, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
            End
        End If
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        End
    End If
    
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
'�y��    �l�z
'===========================================================================
Private Sub vaData_EditChange(ByVal Col As Long, ByVal Row As Long)

    With vaData
        If LC_lngMAX_ROW <> .MaxRows Then
            If .MaxRows = Row Then
                .MaxRows = .MaxRows + 1
                .Row = 1
                .Row2 = .MaxRows
                .Col = LC_lngCol_NO
                .Col2 = LC_lngCol_SERIAL
                .BlockMode = True
                .BackColor = Me.BackColor
                .Protect = True
                .Lock = True
                Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
            End If
        End If
    End With

End Sub

Private Sub vaData_KeyPress(KeyAscii As Integer)
    
    Dim msgMsgBox       As VbMsgBoxResult
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    
    If LC_lngCurrent = vaData.MaxRows Then
        L_LastCol = LC_lngCol_CHECK
        L_LastRow = vaData.MaxRows
        Call CM_Execute_Click
        L_LastCol = -1
        L_LastRow = -1
    End If

End Sub

'===========================================================================
'�y�g�p�p�r�z �Z���ړ���
'�y�� �� ���z vaData_LeaveCell
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub vaData_LeaveCell(ByVal Col As Long, ByVal Row As Long, ByVal NewCol As Long, ByVal NewRow As Long, Cancel As Boolean)
    
    '* �Z���w�i�F������
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, False)
    End With

    '* �Z���w�i�F��ݒ�
    If NewCol <> -1 And NewRow <> -1 Then
        Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
    End If
    
    LC_lngCurrent = NewRow

End Sub

'===========================================================================
'�y�g�p�p�r�z �X�v���b�h�t�H�[�J�X�擾��
'�y�� �� ���z vaData_GotFocus
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Sub vaData_GotFocus()

    '�J�[�\������B
    With vaData
        If .ActiveRow > 0 Then
            If .ActiveCol = 1 Then
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
            Else
                Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
            End If
''''    Else                '2006.09.28
''''        cmdExe.SetFocus '2006.09.28
        Else
            txtDummy.SetFocus
        End If
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
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

    Dim lngRow          As Long

    With vaData
        .Row = 1
        .Row2 = .MaxRows
        .Col = LC_lngCol_NO
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .BackColor = Me.BackColor
        .BlockMode = False
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
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .Protect = True
        .Lock = True
        .BlockMode = False
    End With

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
    
    P_Show_Data = False
    
    '�X�v���b�h�̃N���A
    Call P_vaData_Init

    '�f�[�^�̎擾�B
    If P_Get_Data(Usr_Ody_LC) = True Then
        '�f�[�^����ʂɕ\������B
        Call P_Set_Data(Usr_Ody_LC)
        '�X�v���b�h�̓��͐����B
        Call P_Va_Lock
    Else
        '�N���[�Y
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        Exit Function
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
    P_Show_Data = True

End Function

'===========================================================================
'�y�g�p�p�r�z �f�[�^�Z�b�g
'�y�� �� ���z P_Set_Data
'�y��    ���z ByRef Usr_Ody_LC As U_Ody   :�_�C�i�Z�b�g���\����
'�y��    �l�z Boolean
'�y�X �V ���z 2008/08/06 FKS)NAKATA
'�y��    �l�z �X�v���b�h�̃V���A�������Ɏ��ѓ�����������
'===========================================================================
Private Function P_Set_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim lngI        As Long
    Dim lngJ        As Long
    Dim blnFLG      As Boolean
    Dim intLen      As Integer
    
'2008/08/06 ADD START FKS)NAKATA
    Dim wkSRANO As String     '�V���A�������[�N
    Dim wkRSTDT As String     '���ѓ����[�N
'2008/08/06 ADD E.N.D FKS)NAKATA


    On Error GoTo ErrLbl:
    
    P_Set_Data = False
    
    lngI = 0
    blnFLG = False
    
    intLen = Len(CStr(LC_lngMAX_ROW))
    
    With vaData
        '�X�v���b�h�̍s���̐ݒ�
        .ReDraw = False
        .MaxRows = 0

        
        '�X�v���b�h�Ƀf�[�^��\������B
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            lngI = lngI + 1
            
'2008/08/06 ADD START FKS)NAKATA
            'DB���擾�����V���A�����Ǝ��ѓ����i�[
            wkSRANO = CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", "")
            wkRSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "RSTDT", "")
'2008/08/06 ADD E.N.D FKS)NAKATA
            
            
            'LC_lngMAX_ROW�s�𒴂����Ƃ��͋����I��LOOP�����𔲂���
            If lngI > LC_lngMAX_ROW Then
                GoTo LBL_LOOP_END
            End If
            .MaxRows = .MaxRows + 1
            Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)
            If CF_Ora_GetDyn(Usr_Ody_LC, "KBN", "") = "C" Then
                Call .SetText(LC_lngCol_CHECK, lngI, "1")
            End If
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
            
'2008/08/06 ADD START FKS)NAKATA
''�X�v���b�h�ɃV���A�����Ǝ��ѓ����X�y�[�X��1����i�[
''            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            Call .SetText(LC_lngCol_SERIAL, lngI, wkSRANO & " " & wkRSTDT)
'2008/08/06 ADD E.N.D FKS)NAKATA

            Call CF_Ora_MoveNext(Usr_Ody_LC)
        Loop
        
LBL_LOOP_END:
        .MaxRows = Usr_Ody_LC.Obj_Ody.RecordCount
        LC_lngDataMAX_ROW = .MaxRows
                        
        '�w�i�F�̐ݒ�
        Call P_Va_BackColor
        
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
'�y�X �V ���z 2008/08/06 FKS)NAKATA
'�y��    �l�z ���ѓ��̎擾��ǉ�
'===========================================================================
Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim strSQL          As String
    Dim strWKRSTDT      As String
    Dim strWKRPTCLTID   As String
    Dim strDB           As String

'2008/08/06 ADD START FKS)NAKATA
    Dim strPUDLNO       As String
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    On Error GoTo Errlabel:
    
    
'2008/08/06 ADD START FKS)NAKATA
''JDNTRA���PUDLNO�̎擾
    If P_GET_PUDLNO(L_strJDNNO, strPUDLNO) = False Then
        strPUDLNO = ""
    End If
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    P_Get_Data = False
    
    'strWKRSTDT = Left(L_strRSTDT & Space(8), 8)
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    
    strDB = Get_DBHEAD & "_" & ORA_MAX_USR9
    
    'SQL���쐬
    strSQL = ""
    strSQL = strSQL & "Select"
    strSQL = strSQL & vbCrLf & " Case"
    strSQL = strSQL & vbCrLf & "     When WRK.SRANO Is Not Null Then 'C'"
    strSQL = strSQL & vbCrLf & "     Else ''"
    strSQL = strSQL & vbCrLf & " End As KBN"
    strSQL = strSQL & vbCrLf & ",SRA.SRANO"
'2008/08/05 ADD START FKS)NAKATA
    strSQL = strSQL & vbCrLf & ",SRA.RSTDT"
'2008/08/05 ADD E.N.D FKS)NAKATA
    strSQL = strSQL & vbCrLf & ",SRA.WRTTM"
    strSQL = strSQL & vbCrLf & ",SRA.WRTDT"
    strSQL = strSQL & vbCrLf & " From    SRACNTTB SRA"
    strSQL = strSQL & vbCrLf & "             Left Join " & strDB & ".SRAET52 WRK On SRA.SRANO    = WRK.SRANO"
    strSQL = strSQL & vbCrLf & "                                                And WRK.RPTCLTID = " & "'" & strWKRPTCLTID & "'"
'2008/08/05 CHG START FKS)NAKATA
''    strSQL = strSQL & vbCrLf & " Where   SRA.RSTDT     = " & "'" & strWKRSTDT & "'"
''    strSQL = strSQL & vbCrLf & "   And   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
    strSQL = strSQL & vbCrLf & "   Where   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
'2008/08/05 CHG E.N.D FKS)NAKATA

'2008/08/06 ADD START FKS)NAKATA
    strSQL = strSQL & vbCrLf & "   And   SRA.HINCD     = " & "'" & L_strHINCD & "'"
'2008/08/06 ADD E.N.E FKS)NAKATA

    strSQL = strSQL & vbCrLf & "   And   SRA.ZAISYOBN  = " & "'" & LC_strSYUKA & "'"

'2008/08/06 ADD START FKS)NAKATA
    If strPUDLNO <> "" Then
        strSQL = strSQL & vbCrLf & "   And   SRA.PUDLNO  = " & "'" & strPUDLNO & "'"
    End If
'2008/08/06 ADD E.N.D FKS)NAKATA
    strSQL = strSQL & vbCrLf & " Order By SRA.SRANO"
    
    
    'DB�A�N�Z�X
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

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

    Dim lngI   As Long
    Dim intLen As Integer

    lngI = 0
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
        Call SetEdit(vaData, LC_lngCol_NO, 1)
        Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
        '�s�ԍ����Z�b�g
        For lngI = 0 To vaData.MaxRows
            lngI = lngI + 1
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
        Next
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
'�y�g�p�p�r�z �X�v���b�h���̓`�F�b�N�i���C���j
'�y�� �� ���z P_EntryCheck
'�y��    ���z ByRef lngEntryLine As Long  :�L���s��
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_EntryCheck(ByRef lngEntryLine As Long) As Boolean
    
    Dim lngI        As Long
    Dim varCHECK    As Variant
    Dim lngCount    As Long
    
    P_EntryCheck = False
    
    With vaData
        For lngI = 1 To .MaxRows
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            If Nz(varCHECK) = "1" Then
                lngCount = lngCount + 1
            End If
        Next lngI
    End With
    
    lngEntryLine = lngCount
    
    P_EntryCheck = True

End Function

'===========================================================================
'�y�g�p�p�r�z SQL�����������s
'�y�� �� ���z P_EXECUTE_SQL
'�y��    ���z ByVal strMode     As enumCREATE_MODE  :SQL�������[�h
'�y��    ���z ByVal strSRALINNO As String           :��ʍs�ԍ�
'�y��    ���z ByVal strSRANO    As String           :�V���A����
'�y��    ���z ByVal strLOCATION As String           :�I��
'�y��    ���z ByVal strWRTTM    As String           :�f�[�^�쐬����
'�y��    ���z ByVal strWRTDT    As String           :�f�[�^�쐬���t
'�y��    �l�z Boolean
'�y�X �V ���z 2008/08/06 FKS)NAKATA
'�y��    �l�z
'===========================================================================
Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, _
                               ByVal strSRANO As String, _
                               ByVal strWRTTM As String, _
                               ByVal strWRTDT As String) As Boolean
    Dim strSQL As String

'2008/08/06 ADD START FKS)NAKATA
    Dim wkSRANO As String
    Dim wkRSTDT As String
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    P_EXECUTE_SQL = False
    
    strSQL = vbNullString
                                                  
'2008/08/06 ADD START FKS)NAKATA
''�p�����[�^���V���A�����Ǝ��ѓ��ɕ�����
    wkSRANO = Left(Trim(strSRANO), 13)
    wkRSTDT = Right(Trim(strSRANO), 8)
'2008/08/06 ADD E.N.D FKS)NAKATA
                             
    Select Case strMode
        Case enumCREATE_MODE.Ins
            strSQL = strSQL & " INSERT INTO SRAET52 (" & vbCrLf
            strSQL = strSQL & "                      RPTCLTID," & vbCrLf
            strSQL = strSQL & "                      RSTDT," & vbCrLf
            strSQL = strSQL & "                      HINCD," & vbCrLf
            strSQL = strSQL & "                      SBNNO," & vbCrLf
            strSQL = strSQL & "                      SRANO," & vbCrLf
            strSQL = strSQL & "                      WRTTM," & vbCrLf
            strSQL = strSQL & "                      WRTDT" & vbCrLf
            strSQL = strSQL & "                     )" & vbCrLf
            strSQL = strSQL & " VALUES  (" & vbCrLf
            strSQL = strSQL & "          '" & L_strRPTCLTID & "'," & vbCrLf
'2008/08/07 CHG START FKS)NAKATA
''           strSQL = strSQL & "          '" & L_strRSTDT & "'," & vbCrLf
            strSQL = strSQL & "          '" & wkRSTDT & "'," & vbCrLf
'2008/08/07 CHG E.N.D FKS)NAKATA
            strSQL = strSQL & "          '" & L_strHINCD & "'," & vbCrLf
            strSQL = strSQL & "          '" & L_strSBNNO & "'," & vbCrLf
'2008/08/07 CHG START FKS)NAKATA
 ''           strSQL = strSQL & "          '" & strSRANO & "'," & vbCrLf
            strSQL = strSQL & "          '" & wkSRANO & "'," & vbCrLf
'2008/08/07 CHG E.N.D FKS)NAKATA
            strSQL = strSQL & "          '" & strWRTTM & "'," & vbCrLf
            strSQL = strSQL & "          '" & strWRTDT & "'" & vbCrLf
            strSQL = strSQL & "         )" & vbCrLf
        
        Case enumCREATE_MODE.Del
            strSQL = strSQL & " DELETE FROM SRAET52" & vbCrLf
            strSQL = strSQL & " WHERE  RPTCLTID = '" & L_strRPTCLTID & "'" & vbCrLf
    
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

    Dim lngI        As Long
    Dim lngLineNo   As Long
    Dim strSQL      As String
    Dim varCHECK    As Variant
    Dim varNO       As Variant
    Dim varSERIAL   As Variant
    Dim varSBNNO    As Variant
    Dim datNOW      As Date
    Dim intCnt      As Integer
    Dim intMaxKeta  As Integer
    Dim strZero     As String

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

    'DELETE
    If P_EXECUTE_SQL(enumCREATE_MODE.Del, _
                     "", _
                     "", _
                     "") = False Then
        GoTo EndLbl:
    End If
    
    'INSERT
    lngI = 0
    lngLineNo = 0
    With vaData
        For lngI = 1 To .MaxRows
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            If Nz(varCHECK) = "1" Then
                lngLineNo = lngLineNo + 1
                If P_EXECUTE_SQL(enumCREATE_MODE.Ins, _
                                 CStr(varSERIAL), _
                                 L_strWRTTM, _
                                 L_strWRTDT) = False Then
                    GoTo EndLbl:
                End If
            End If
        Next lngI
    End With

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
        .Row = 1
        .Col = lngCol
        .Row2 = .MaxRows
        .Col2 = lngCol
        .BlockMode = True
        .BackColor = LC_lng_va_Lock_Color
        .BlockMode = False
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

    '�X�v���b�h�̔w�i�F�̐ݒ�B
    With objSpread
        .Row = lngRow
        .Col = lngCol
        If lngRow2 <> 0 Then
            .Row2 = lngRow2
        Else
            .Row2 = lngRow
        End If
        If lngRow2 <> 0 Then
            .Col2 = lngCol2
        Else
            .Col2 = lngCol
        End If
        .BlockMode = True
        If bolEdit Then
            .BackColor = LC_lng_va_Edit_Color
        Else
            .BackColor = LC_lng_va_UnEdit_Color
        End If
        .BlockMode = False
    End With

End Sub

'=======================================================================================
'�y�g�p�p�r�z �`�F�b�N�{�b�N�X��ݒ�
'�y�� �� ���z SetCheckBox
'�y��    ���z ByRef objSpread   As Object�F�X�v���b�h
'�y��    ���z ByVal lngCol      As long  �F��ԍ�
'�y��    ���z ByVal lngRow      As long  �F�s�ԍ�
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'=======================================================================================
Private Sub SetCheckBox(ByRef objSpread As Object, _
                        ByVal lngCol As Long, _
                        ByVal lngRow As Long)

    With objSpread
        .Col = lngCol
        .Col2 = lngCol
        .Row = lngRow
        .Row2 = lngRow
        .CellType = CellTypeCheckBox                        ' �����߂̐ݒ�
        .TypeCheckText = ""                                 ' �����ޯ�� ���߼��
        .TypeCheckType = TypeCheckTypeNormal                ' �����ޯ�� ����
        .TypeCheckTextAlign = TypeCheckTextAlignRight       ' ÷�Ĕz�u
        .TypeHAlign = TypeHAlignCenter                      ' �����z�u
        .TypeVAlign = TypeVAlignCenter                      ' �����z�u
        .TypeCheckCenter = True                             ' �����z�u
    End With

End Sub

'===========================================================================
'�y�g�p�p�r�z ���̓`�F�b�N
'�y�� �� ���z P_EntryCheck
'�y��    ���z
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Private Function P_EntryCheckSerial(ByVal lngLineNo As Long) As Boolean

    Dim varCHECK    As Variant
    Dim varSERIAL   As Variant
    Dim strKBN      As String

    P_EntryCheckSerial = False

    With vaData
        Call .GetText(LC_lngCol_CHECK, lngLineNo, varCHECK)
        Call .GetText(LC_lngCol_SERIAL, lngLineNo, varSERIAL)
        If Nz(varCHECK) = "1" Then
            If P_SRANOCheck(CStr(Nz(varSERIAL)), strKBN) = True Then
                If strKBN <> LC_strSYUKA Then
                    Exit Function
                End If
            End If
        End If
    End With

    P_EntryCheckSerial = True

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
    Dim strWKSRANO   As String

    P_SRANOCheckWK = False

    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKSRANO = Left(strSRANO & Space(13), 13)

    'SQL���쐬
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * "
    strSQL = strSQL & " FROM    SRAET52"
    strSQL = strSQL & " WHERE   RPTCLTID <> '" & strWKRPTCLTID & "'"
    strSQL = strSQL & "   AND   SRANO = '" & strWKSRANO & "'"

    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
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
        .CellType = CellTypeEdit                        '��������
        .TypeEditCharSet = TypeEditCharSetAlphanumeric  '���p�p����
        .GridSolid = True
        .GridColor = &H0&
        .Position = PositionCenterLeft
        '���͌������Z�b�g
        Select Case lngCol
            Case LC_lngCol_SERIAL: .TypeMaxEditLen = C_lngSERIAL_Len
        End Select
        .ReDraw = True
    End With
End Sub
'=========================================================================�y ���\�b�h �z=

'2008/08/06 ADD START FKS)NAKATA
'===========================================================================
'�y�g�p�p�r�z ���o�ɔԍ��擾(�󒍃g�����DPUDLNO)
'�y�� �� ���z P_GET_PUDLNO
'�y��    ���z ByVal strJDNNO As String  :�󒍔ԍ�
'�y��    �l�z Boolean
'�y�X �V ���z
'�y��    �l�z �󒍃g�����̓��o�ɔԍ�����������
'===========================================================================
Private Function P_GET_PUDLNO(ByVal strJdnNo As String, _
                                ByRef strPUDLNO As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim wkJDNNO   As String
    Dim wkLINNO   As String

    P_GET_PUDLNO = False
    strPUDLNO = ""
    
    wkJDNNO = Left(strJdnNo, 6)
    wkLINNO = Right(strJdnNo, 3)

    'SQL���쐬
    strSQL = vbNullString
'''' UPD 2010/10/21  FKS) T.Yamamoto    Start    �A���[��FC10102001
'    strSQL = strSQL & " SELECT  * " & vbCrLf
'    strSQL = strSQL & " FROM    JDNTRA" & vbCrLf
'    strSQL = strSQL & " WHERE   JDNNO    = '" & wkJDNNO & "'" & vbCrLf
'    strSQL = strSQL & " AND     LINNO    = '" & wkLINNO & "'" & vbCrLf
    '�C�O�ɏo�ׂ��ꂽ�ꍇ�A�󒍂ƃV���A���̓��o�ɔԍ����قȂ邽�߁A��������Ɍ���
    strSQL = strSQL & " SELECT * " & vbCrLf
    strSQL = strSQL & " FROM   JDNTRA TRA " & vbCrLf
    strSQL = strSQL & " WHERE  JDNNO  = '" & wkJDNNO & "' " & vbCrLf
    strSQL = strSQL & " AND    LINNO  = '" & wkLINNO & "' " & vbCrLf
    strSQL = strSQL & " AND    EXISTS ( " & vbCrLf
    strSQL = strSQL & "                 SELECT * " & vbCrLf
    strSQL = strSQL & "                 FROM   JDNTHA THA " & vbCrLf
    strSQL = strSQL & "                 WHERE  THA.DATNO = TRA.DATNO " & vbCrLf
''''CHG START TOM)KATSUKAWA 2011/02/24 *** �󒍎���敪�̏�����ǉ�
'   strSQL = strSQL & "                 AND    THA.FRNKB = '0' " & vbCrLf
    strSQL = strSQL & "                 AND   (THA.FRNKB = '0' OR THA.JDNTRKB = '21') " & vbCrLf
''''CHG END   TOM)KATSUKAWA 2011/02/24
    strSQL = strSQL & "               ) " & vbCrLf
'''' UPD 2010/10/21  FKS) T.Yamamoto    End
    
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '�擾�f�[�^�L
        strPUDLNO = CF_Ora_GetDyn(Usr_Ody_LC, "PUDLNO", "")
        P_GET_PUDLNO = True
    End If

    '�N���[�Y
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_GET_PUDLNO)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

''2008/08/06 ADD E.N.D FKS)NAKATA
