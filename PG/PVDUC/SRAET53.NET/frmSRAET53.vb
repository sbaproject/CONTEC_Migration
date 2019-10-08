Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'***************************************************************************************
	'*  �y�g�p�p�r�z�V���A�����o�^
	'*  �y�� �� ���z2006/09/29  SYSTEM CREATE CO.,Ltd.
	'*  �y�X �V ���z
	'*  �y��    �l�z
	'***************************************************************************************
	
	'-�y �ϐ��錾 �z-------------------------------------------------------------------------
	'AppPath�ޔ�p
	Private L_strAppPath As String
	
	'�f�[�^�o�^�p
	Private L_strWRTTM As String
	Private L_strWRTDT As String
	
	'�p�����[�^�擾�p
	Private L_strRPTCLTID As String
	Private L_strPRGID As String
	Private L_strHINCD As String
	Private L_strSBNNO As String
	Private L_strURISU As String
	
	' �v���p�e�B�l�i�[�p�ϐ�
	Dim mstrRPTCLTID As String
	Dim mstrPRGID As String
	Dim mstrHINCD As String
	Dim mstrSBNNO As String
	Dim mstrURISU As String
	
	'�X�v���b�h�ҏW�s�̍ő�l
	Private L_lngMAX_EditRow As Integer
	
	'LeaveCell�C�x���g����t���O
	Private L_blnLeaveCell As Boolean 'True:�C�x���g����, False:�C�x���g������
	
	'�X�V�m�F���b�Z�[�W�L�����Z������ActiveCell�Z�b�g�p
	Private L_LastCol As Integer '��
	Private L_LastRow As Integer '�s
	'-------------------------------------------------------------------------�y �ϐ��錾 �z-
	
	'-�y �萔�錾 �z-------------------------------------------------------------------------
	'�^�C�g��
	Private Const LC_strPG_ID As String = "SRAET53        "
	Private Const LC_strTitle As String = "�V���A�����o�^"
	
	' �p�����[�^ �X�C�b�`��`
	Private Const mcPARAM_RPTCLTID As String = "/RPTCLTID:"
	Private Const mcPARAM_PRGID As String = "/PRGID:"
	Private Const mcPARAM_HINCD As String = "/HINCD:"
	Private Const mcPARAM_SBNNO As String = "/SBNNO:"
	Private Const mcPARAM_URISU As String = "/URISU:"
	
	'�X�v���b�h�w�i�F
	Private Const LC_lng_va_Edit_Color As Integer = &HFFFF
	'Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
	Private Const LC_lng_va_Lock_Color As Integer = &H8000000F
	
	'�X�v���b�h�̍s
	Private Const LC_lngMAX_ROW As Integer = 999999 '�ő�s��
	Private Const LC_lngDEFAULT_ROW As Integer = 9999 '�f�t�H���g�Z�b�g�s

    '�X�v���b�h�̍���
    '2019/10/04 CHG START
    '   Private Const LC_lngCol_CHECK As Integer = 1 '�`�F�b�N�{�b�N�X
    'Private Const LC_lngCol_NO As Integer = 2 '�s��
    'Private Const LC_lngCol_SERIAL As Integer = 3 '�V���A����
    'Private Const LC_lngCol_LOCKBN As Integer = 4 '�sۯ��敪
    'Private Const LC_lngCol_ZAISYOBN As Integer = 5 '�݌ɏ����敪
    'Private Const LC_lngCol_SBN As Integer = 6 '���ԃR�[�h
    'Private Const LC_lngCol_HID_SERIAL As Integer = 7 '�����O�V���A����
    Private Const LC_lngCol_CHECK As Integer = 0 '�`�F�b�N�{�b�N�X
    Private Const LC_lngCol_NO As Integer = 1 '�s��
    Private Const LC_lngCol_SERIAL As Integer = 2 '�V���A����
    Private Const LC_lngCol_LOCKBN As Integer = 3 '�sۯ��敪
    Private Const LC_lngCol_ZAISYOBN As Integer = 4 '�݌ɏ����敪
    Private Const LC_lngCol_SBN As Integer = 5 '���ԃR�[�h
    Private Const LC_lngCol_HID_SERIAL As Integer = 6 '�����O�V���A����
    '2019/10/04 CHG END
    '* �ő���͌���
    Private Const C_lngSERIAL_Len As Integer = 13 '�V���A����
	Private Const C_lngTNANO_Len As Integer = 9 '�I��
	
	' �`�F�b�N�{�b�N�X
	Private Const C_strCHECKBOX_ON As String = "1" 'ON
	Private Const C_strCHECKBOX_OFF As String = "9" 'OFF
	
	'�s���b�N�敪
	Private Const LC_strLINE_LOCK As String = "1" 'ۯ�
	Private Const LC_strLINE_NOT_LOCK As String = "9" 'ۯ�����
	
	'�o�׍ς݋敪
	Private Const LC_strSYUKA As String = "02"
	Private Const LC_strNOT_SYUKA As String = "  "
	
	'SQL���������̃��[�h
	Private Enum enumCREATE_MODE
		Insert
		Update
		Delete
	End Enum
	
	'���b�Z�[�W��
	Private Const LC_strAPPEND As String = "_APPEND        " '���ʃ��b�Z�[�W
	Private Const LC_strCURSOR As String = "_CURSOR        " '���ʃ��b�Z�[�W
	
	'���b�Z�[�W�h�c
	Private Const CommonMSGSQ As String = "0" '* ���ʃ��b�Z�[�W�h�c
	Private Const Entry As String = "0" '* �o�^�m�F���b�Z�[�W
	Private Const EntryFinal As String = "1" '* �o�^�チ�b�Z�[�W
	Private Const SerialNoNull As String = "2" '* �V���A����NULL
	Private Const TnaNoNull As String = "3" '* �I��NULL
	Private Const InfSyuka As String = "4" '* �o�׍ς݂̃V���A�����͓��͂���܂����B��낵���ł����H
	Private Const InfLineLittle As String = "5" '* ���͍s�������ʂ�������Ă��܂��B�o�^���Ă�낵���ł����H
	Private Const InfLineOver As String = "6" '* ���͍s�������ʂ𒴂��Ă��܂��B
	Private Const SerialNoExists As String = "7" '* ���͂��Ă���V���A�����Ǘ��e�[�u���ɑ��݂��Ȃ��ׁA�g�p�ł��܂���B
	Private Const DoubleSerialNo As String = "8" '* �V���A�������d�����Ă��܂��B
	Private Const SerialKeta As String = "9" '* �V���A������ %N ���܂œ��͉\�ł��B
	Private Const TnaNoKeta As String = "A" '* �I�Ԃ� %N ���܂œ��͉\�ł��B
    Private Const NotHINCD As String = "B" '* %CD�Ƃ������i�R�[�h�͑��݂��܂���B
    '-------------------------------------------------------------------------�y �萔�錾 �z-
    '2019/10/04 ADD START
    'API�֐��̐錾
    Private Const WM_KEYDOWN As Short = &H100S
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '2019/10/04 ADD END

    '=�y �C�x���g �z=========================================================================

    '-�y����޳��ƭ��z-----------------------------------------------------------------------
    '===========================================================================
    '�y�g�p�p�r�z �o�^(R)�I����
    '�y�� �� ���z MN_Execute_Click
    '�y�X �V ���z
    '�y��    �l�z
    '===========================================================================
    Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
		Call CM_Execute_Click(CM_Execute, New System.EventArgs())
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �I��(X)�I����
	'�y�� �� ���z MN_EditMn_Click
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z ��ʏ�����(S)�I����
	'�y�� �� ���z MN_APPENDC_Click
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click

        '�X�v���b�h�̃N���A
        Call P_vaData_Init()
        '��ʂ̏����\��
        Call P_Show_Data()

    End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�I��]�{�^���N���b�N��
	'�y�� �� ���z CM_EndCm_Click
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Me.Close()
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�I��]�{�^��MouseDown��
	'�y�� �� ���z CM_EndCm_MouseDown
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CM_EndCm.Image = IM_EndCm(2).Image
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�I��]�{�^��MouseUp��
	'�y�� �� ���z CM_EndCm_MouseUp
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CM_EndCm.Image = IM_EndCm(1).Image
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�I��]�{�^��MouseMove��
	'�y�� �� ���z CM_EndCm_MouseMove
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "���j���[�ɖ߂�܂��B"
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z Image2 MouseMove��
	'�y�� �� ���z Image2_MouseMove
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub Image2_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image2.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub

    '===========================================================================
    '�y�g�p�p�r�z [�o�^]�{�^���N���b�N��
    '�y�� �� ���z CM_Execute_Click
    '�y�X �V ���z
    '�y��    �l�z
    '===========================================================================
    Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click

        Dim msgMsgBox As MsgBoxResult
        Dim lngRow As Integer
        'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim Mst_Inf As TYPE_DB_SYSTBH
        Dim intRet As Short
        Dim strMSGKBN As String
        Dim strMSGNM As String

        strMSGKBN = "1"

        '�X�v���b�h�̓��̓`�F�b�N
        If P_EntryCheck(lngRow) = False Then
            L_blnLeaveCell = False
            CM_Execute.Image = IM_Execute(1).Image
            Exit Sub
        End If

        '�L���s���Ɛ��ʂ��r�����b�Z�[�W��؂�ւ���
        If lngRow > CInt(lblURISU.Text) Then
            'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
            If intRet <> 0 Then
                L_blnLeaveCell = False
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                Exit Sub
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call GP_MsgBox(COMMON.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
            '* �Z���w�i�F������
            With vaData
                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/07 CHG START
                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_CHECK, .MaxRows)
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, False, LC_lngCol_CHECK, .RowCount - 1)
                '2019/10/07 CHG END
                Call P_Va_BackColor_LINE_LOCK()
            End With
            '2019/10/07 CHG START
            'If L_LastCol > 0 And L_LastRow > 0 Then
            If L_LastCol >= 0 And L_LastRow >= 0 Then
                '2019/10/07 CHG END
                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
            Else
                If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
                Else
                    '2019/10/07 CHG START
                    'Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1, True)
                    'Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1)
                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow, True)
                    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow)
                    '2019/10/07 CHG END
                End If
            End If
            CM_Execute.Image = IM_Execute(1).Image
            Exit Sub
        End If

        '�L���s���Ɛ��ʂ��r�����b�Z�[�W��؂�ւ���
        If CInt(lblURISU.Text) > lngRow Then
            'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
            If intRet <> 0 Then
                L_blnLeaveCell = False
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                Exit Sub
            End If
        Else
            strMSGKBN = "0"
            'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
            If intRet <> 0 Then
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                L_blnLeaveCell = False
                CM_Execute.Image = IM_Execute(1).Image
                Exit Sub
            End If
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        msgMsgBox = GP_MsgBox(COMMON.enmMsg.Execute, Mst_Inf.MSGCM, LC_strTitle)
        If msgMsgBox <> MsgBoxResult.Yes Then
            CM_Execute.Image = IM_Execute(1).Image
            L_blnLeaveCell = False
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/07 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, vaData.MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, False, LC_lngCol_SERIAL, vaData.RowCount - 1)
            '2019/10/07 CHG END
            Call P_Va_BackColor_LINE_LOCK()
            '2019/10/07 DEL START
            'If L_LastCol > 0 And L_LastRow > 0 Then
            If L_LastCol >= 0 And L_LastRow >= 0 Then
                '2019/10/07 DEL END
                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
            Else
                If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
                Else
                    '2019/10/07 CHG START
                    'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1, True)
                    'Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1)
                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow, True)
                    Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow)
                    '2019/10/07 CHG END
                End If
            End If
            Exit Sub
        End If

        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '�o�^����
        If P_Main() = True Then
            Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
            Exit Sub
        End If

EndLabel:
        '* �Z���w�i�F��ݒ�
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)

        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        L_blnLeaveCell = False

        CM_Execute.Image = IM_Execute(1).Image
    End Sub

    '===========================================================================
    '�y�g�p�p�r�z [�o�^]�{�^��MouseDown��
    '�y�� �� ���z CM_Execute_MouseDown
    '�y�X �V ���z
    '�y��    �l�z
    '===========================================================================
    Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		L_blnLeaveCell = False
		CM_Execute.Image = IM_Execute(2).Image
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�o�^]�{�^��MouseUp��
	'�y�� �� ���z CM_Execute_MouseUp
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		L_blnLeaveCell = False
		CM_Execute.Image = IM_Execute(1).Image
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�o�^]�{�^��MouseMove��
	'�y�� �� ���z CM_Execute_MouseMove
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "�o�^���܂��B"
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z [�_�~�[]�C���[�WMouseMove��
	'�y�� �� ���z Image1_MouseMove
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		Call Init_Prompt()
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �t�H�[�����[�h��
	'�y�� �� ���z Form_Load
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Dim lngIndex As Integer
		Dim strHINNM As String
		Dim CommandLine As String
		Dim strArry() As String ' �����擾�z��
		Dim strRet As String ' �������[�N
		Dim strRetU As String ' �������[�N
		Dim intRet As Short
		Dim strMSGKBN As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim Mst_Inf As TYPE_DB_SYSTBH
		
		Me.KeyPreview = True

        '����v���O�������N�����Ă����ꍇ�͏I������
        'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
        '2019/10/04 DEL START
        'If App.PrevInstance Then
        '    Call GP_MsgBox(COMMON.enmMsg.Critical, "���ɋN�����Ă��܂��B", LC_strTitle)
        '    End
        'End If
        '2019/10/04 DEL END

        '�t�H�[���̈ʒu���Z�b�g
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		
		'AppPath�̑ޔ�
		L_strAppPath = My.Application.Info.DirectoryPath
		
		'�p�����[�^�擾
		strArry = Split(Replace(VB.Command(), """", ""), " ")
		L_strRPTCLTID = Replace(strArry(0), mcPARAM_RPTCLTID, "")
		L_strPRGID = Replace(strArry(1), mcPARAM_PRGID, "")
		L_strHINCD = Replace(strArry(2), mcPARAM_HINCD, "")
		L_strSBNNO = Replace(strArry(3), mcPARAM_SBNNO, "")
		L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
		
		'�p�����[�^�ŕs��������Ζ{��ʂ͋N�������Ȃ�
		If L_strRPTCLTID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "���[�N�X�e�[�V�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		If L_strPRGID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "�v���O�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		If L_strHINCD = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "���i�R�[�h���ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		If L_strSBNNO = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "���Ԃ��ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		If L_strURISU = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "���㐔�ʂ��ݒ肳��Ă��܂���B", LC_strTitle)
			End
		Else
			If IsNumeric(L_strURISU) = False Then
				Call GP_MsgBox(Common.enmMsg.Critical, "���㐔�ʂ����l�ł͂���܂���B", LC_strTitle)
				End
			End If
		End If
		
		'�t�H�[���̃N���A
		Call P_FromClear()

        'DB�ڑ�
        Call CF_Ora_USR1_Open() 'USR1
        '2019/10/07 DEL START
        'Call CF_Ora_USR9_Open() 'USR9
        '2019/10/07 DEL END

        '�󂯎�����p�����[�^����ʂɃZ�b�g
        lblHIN1.Text = L_strHINCD
		If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
			lblHIN2.Text = strHINNM
		Else
			'���݂��Ȃ����i�R�[�h
			strMSGKBN = "1"
			'UPGRADE_WARNING: Form_Load �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				End
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call GP_MsgBox(Common.enmMsg.Exclamation, Replace(Mst_Inf.MSGCM, "%CD", L_strHINCD), LC_strTitle)
			End
		End If
        lblURISU.Text = L_strURISU

        '2019/10/07 ADD START
        SetBar(Me)
        '2019/10/07 ADD END

        '��ʂ̏����\��
        Call P_Show_Data()
		
		L_LastCol = -1
		L_LastRow = -1
		
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �A�����[�h��
	'�y�� �� ���z Form_QueryUnload
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        'DB�ڑ�����
        '2019/10/04 DEL START    
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)   
        Call DB_CLOSE(CON)
        '2019/10/04 DEL END
        '2019/10/04 ADD START        
        Call SSSWIN_LOGWRT("�v���O�����I��")
        '2019/10/04 ADD END
        eventArgs.Cancel = Cancel
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �L�[������
	'�y�� �� ���z Form_KeyPress
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub FR_SSSMAIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        '2019/10/07 DEL START
        '      Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        '      If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.ComboBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.RadioButton Then

        '	Call GP_CtrlSend(KeyAscii, Me)
        'End If
        'eventArgs.KeyChar = Chr(KeyAscii)
        '      If KeyAscii = 0 Then
        '          eventArgs.Handled = True
        '      End If
        '2019/10/07 DEL END
    End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�G�f�B�b�g���[�h�ύX��
	'�y�� �� ���z vaData_EditChange
	'�y�X �V ���z
	'�y��    �l�z�X�v���b�h���ŏI�s�ɒB�������A�V�K���͍s�𐶐�
	'===========================================================================
	Private Sub vaData_EditChange(ByVal Col As Integer, ByVal Row As Integer)

        '2019/10/07 DEL START

        '      With vaData
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	If LC_lngMAX_ROW <> .MaxRows Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		If .MaxRows = Row Then
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.MaxRows = .MaxRows + 1
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Row = 1
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Row2 = .MaxRows
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Col = LC_lngCol_NO
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Col2 = LC_lngCol_NO
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.BlockMode = True
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Protect = True
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			.Lock = True
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_CHECK, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_LOCKBN, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_ZAISYOBN, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_SBN, Row + 1)
        '			Call SetEdit(vaData, LC_lngCol_HID_SERIAL, Row + 1)
        '		End If
        '	End If
        'End With

        '2019/10/07 DEL END

    End Sub
	
	Private Sub vaData_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		Call F_SendKey(KeyCode)
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �Z���ړ���
	'�y�� �� ���z vaData_LeaveCell
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub vaData_LeaveCell(ByVal Col As Integer, ByVal Row As Integer, ByVal NewCol As Integer, ByVal NewRow As Integer, ByRef Cancel As Boolean)
        '2019/10/07 DEL START

        'Dim lngI As Integer
        'Dim lngJ As Integer
        'Dim varCHECK As Object
        'Dim varNO As Object
        'Dim varSERIAL As Object
        'Dim varSERIAL_C As Object
        'Dim varLOCKBN As Object
        'Dim varNewRowLOCKBN As Object
        'Dim varTNANO As Object
        'Dim varZAISYOBN As Object
        'Dim strKBN As String
        'Dim msgMsgBox As MsgBoxResult
        'Dim strMSGKBN As String
        'Dim strMSGNM As String
        ''UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        'Dim Mst_Inf As TYPE_DB_SYSTBH
        'Dim intRet As Short

        'L_blnLeaveCell = True

        ''* �Z���w�i�F������
        'With vaData
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
        '	Call P_Va_BackColor_LINE_LOCK()
        'End With

        ''�f�[�^���͍ő�s���擾
        'L_lngMAX_EditRow = P_Get_EditMaxRow

        ''�Z���̒l���擾
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Call vaData.GetText(LC_lngCol_ZAISYOBN, Row, varZAISYOBN)
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Call vaData.GetText(LC_lngCol_CHECK, Row, varCHECK)
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Call vaData.GetText(LC_lngCol_LOCKBN, Row, varLOCKBN)
        'If NewRow > 0 Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Call vaData.GetText(LC_lngCol_LOCKBN, NewRow, varNewRowLOCKBN)
        'End If

        ''���͕�����啶���ɕϊ����ăZ���ɍăZ�b�g
        ''UPGRADE_WARNING: �I�u�W�F�N�g Nz() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'Call vaData.SetText(LC_lngCol_SERIAL, Row, StrConv(Nz(varSERIAL), VbStrConv.UpperCase))

        'Select Case Col
        '	'�`�F�b�N�{�b�N�X�̂Ƃ�
        '	Case LC_lngCol_CHECK
        '		With vaData
        '			'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If varLOCKBN = LC_strLINE_LOCK Then
        '				If Row > 0 Then
        '					'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					If Row = .MaxRows Then
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
        '					Else
        '						If Row = NewRow Then
        '							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
        '							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
        '						Else
        '							If NewCol > 0 And NewRow > 0 Then
        '								If NewCol = LC_lngCol_NO Then
        '									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '								ElseIf NewCol > LC_lngCol_SERIAL Then 
        '									'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '									If NewRow = .MaxRows Then
        '										'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
        '										'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
        '									Else
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '									End If
        '								Else
        '									'UPGRADE_WARNING: �I�u�W�F�N�g varNewRowLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '									If varNewRowLOCKBN = LC_strLINE_LOCK Then
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '									Else
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
        '										Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
        '									End If
        '								End If
        '							End If
        '						End If
        '					End If
        '				Else
        '					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '					Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '				End If
        '			Else
        '				If NewCol > 0 And NewRow > 0 Then
        '					If NewCol > LC_lngCol_SERIAL Then
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '					Else
        '						If NewCol = LC_lngCol_NO Then
        '							Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
        '							Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
        '						ElseIf NewCol > LC_lngCol_SERIAL Then 
        '							'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							If NewRow = .MaxRows Then
        '								'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
        '								'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
        '							Else
        '								Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        '								Call GP_SpActiveCell(vaData, NewCol, NewRow)
        '							End If
        '						Else
        '							Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        '							Call GP_SpActiveCell(vaData, NewCol, NewRow)
        '						End If
        '					End If
        '				End If
        '			End If
        '		End With

        '		'�V���A���ԍ��̂Ƃ�
        '	Case LC_lngCol_SERIAL
        '		strMSGKBN = "1"
        '		With vaData
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If Nz(varSERIAL) <> "" Then
        '				'���݃`�F�b�N�i�Ǘ��e�[�u���j
        '				'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If P_SRANOCheck(CStr(varSERIAL), strKBN) = False Then
        '					'UPGRADE_WARNING: vaData_LeaveCell �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '					If intRet <> 0 Then
        '						Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '						Exit Sub
        '					End If
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '					If Col > 0 And NewRow > 0 Then
        '						If Col > LC_lngCol_SERIAL Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							If Row = .MaxRows Then
        '								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
        '								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
        '							Else
        '								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
        '								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
        '							End If
        '						Else
        '							Call GP_Va_Col_EditColor(vaData, Col, Row, True)
        '							Call GP_SpActiveCell(vaData, Col, Row)
        '						End If
        '					Else
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '					End If
        '					Exit Sub
        '				Else
        '					'* �V���A�����d���`�F�b�N
        '					lngJ = 1
        '					For lngJ = 1 To L_lngMAX_EditRow
        '						'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL_C �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						varSERIAL_C = ""
        '						If Row <> lngJ Then
        '							'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
        '							'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL_C) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '							If Nz(varSERIAL_C) <> "" Then
        '								'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL_C �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '								'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '								If varSERIAL = varSERIAL_C Then
        '									'UPGRADE_WARNING: vaData_LeaveCell �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '									If intRet <> 0 Then
        '										Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '										Exit Sub
        '									End If
        '									'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '									Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '									If Row > 0 Then
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
        '										Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
        '									Else
        '										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '									End If
        '									Exit Sub
        '								End If
        '							End If
        '						End If
        '					Next 

        '					'* �擾�����݌ɋ敪���B�����ڂɃZ�b�g
        '					If Row > 0 Then
        '						'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						Call .SetText(LC_lngCol_ZAISYOBN, Row, strKBN)
        '					End If

        '					'* �݌ɏ����敪�̏o�׍ςݔ�����s���A�Y�������Ƃ��x�����b�Z�[�W��\��
        '					If strKBN = LC_strSYUKA Then
        '						'UPGRADE_WARNING: vaData_LeaveCell �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '						If intRet <> 0 Then
        '							Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '							Exit Sub
        '						End If
        '						'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						msgMsgBox = GP_MsgBox(Common.enmMsg.Execute, Mst_Inf.MSGCM, LC_strTitle)
        '						If msgMsgBox <> MsgBoxResult.Yes Then
        '							If Col > 0 And Row > 0 Then
        '								Call GP_Va_Col_EditColor(vaData, Col, Row, True)
        '								Call GP_SpActiveCell(vaData, Col, Row)
        '							Else
        '								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '							End If
        '							Exit Sub
        '						End If
        '					End If
        '				End If
        '				'�V���A�����`�F�b�N��OK�̂Ƃ��͎����Ń`�F�b�N�{�b�N�X��ON�ɂ���
        '				'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				Call .SetText(LC_lngCol_CHECK, Row, C_strCHECKBOX_ON)

        '				If NewCol > LC_lngCol_SERIAL Then
        '					'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					If Row = .MaxRows Then
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
        '					Else
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
        '					End If
        '				ElseIf NewCol < 0 Then 
        '					'''                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
        '					'''                        Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
        '				Else
        '					If NewRow < 0 Then
        '						'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
        '						'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
        '					Else
        '						If NewCol = LC_lngCol_NO Then
        '							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '						Else
        '							Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        '							Call GP_SpActiveCell(vaData, NewCol, NewRow)
        '						End If
        '					End If
        '				End If
        '			Else
        '				'UPGRADE_WARNING: �I�u�W�F�N�g varCHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If varCHECK = C_strCHECKBOX_ON Then
        '					'UPGRADE_WARNING: vaData_LeaveCell �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '					If intRet <> 0 Then
        '						Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '						Exit Sub
        '					End If
        '					'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '					If Row > 0 Then
        '						Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
        '						Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
        '					Else
        '						'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '						'''                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '					End If
        '					Exit Sub
        '				Else
        '					If NewCol > LC_lngCol_SERIAL Then
        '						'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '						If Row = .MaxRows Then
        '							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
        '							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
        '						Else
        '							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
        '							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
        '						End If
        '					ElseIf NewCol < 0 Then 
        '						'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
        '						'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
        '					Else
        '						If NewRow < 0 Then
        '							'''                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
        '							'''                                Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
        '						Else
        '							If NewCol = LC_lngCol_NO Then
        '								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '							Else
        '								'UPGRADE_WARNING: �I�u�W�F�N�g varNewRowLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '								If varNewRowLOCKBN = LC_strLINE_LOCK Then
        '									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '								Else
        '									Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        '									Call GP_SpActiveCell(vaData, NewCol, NewRow)
        '								End If
        '							End If
        '						End If
        '					End If
        '				End If
        '			End If
        '		End With
        'End Select

        'If NewRow - 1 > 0 Then
        '	'�ォ�珇�Ԃɓ��͂���d�l�ł���ׁA�O�s�̒l��NULL�`�F�b�N��NULL�Ȃ�G���[
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Call vaData.GetText(LC_lngCol_SERIAL, NewRow - 1, varSERIAL)
        '	'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	If Nz(varSERIAL) = "" Then
        '		strMSGKBN = "0"
        '		'UPGRADE_WARNING: vaData_LeaveCell �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '		If intRet <> 0 Then
        '			Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '			Exit Sub
        '		End If
        '		'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		Call GP_MsgBox(Common.enmMsg.Critical, Mst_Inf.MSGCM, LC_strTitle)
        '		'* �Z���w�i�F������
        '		With vaData
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
        '			Call P_Va_BackColor_LINE_LOCK()
        '		End With
        '		If Row > 0 Then
        '			Call GP_Va_Col_EditColor(vaData, Col, Row, True)
        '			Call GP_SpActiveCell(vaData, Col, Row)
        '		Else
        '			Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
        '			Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
        '		End If
        '		Exit Sub
        '	End If
        'End If

        ''�ŏI���͍s�̂Ƃ���[�o�^]�{�^���������̏����ďo
        ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'If NewCol = LC_lngCol_LOCKBN And (NewRow > L_lngMAX_EditRow Or NewRow = vaData.MaxRows) Then
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Call vaData.GetText(LC_lngCol_SERIAL, NewRow, varSERIAL)
        '	'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	If Nz(varSERIAL) = "" Then
        '		L_lngMAX_EditRow = P_Get_EditMaxRow
        '		L_blnLeaveCell = True
        '		L_LastCol = Col
        '		L_LastRow = Row
        '		Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
        '		L_LastCol = -1
        '		L_LastRow = -1
        '		L_blnLeaveCell = False
        '	End If
        'End If

        'If L_blnLeaveCell = True Then
        '	'* �Z���w�i�F������
        '	With vaData
        '		'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
        '		Call P_Va_BackColor_LINE_LOCK()
        '	End With
        '	'* �Z���w�i�F��ݒ�
        '	If NewCol <> -1 Or NewRow <> -1 Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g varNewRowLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		If NewCol > LC_lngCol_SERIAL Or varNewRowLOCKBN <> LC_strLINE_LOCK Then
        '			If NewCol = LC_lngCol_NO Then
        '				If Col = LC_lngCol_CHECK Then
        '					Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
        '					Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
        '				Else
        '					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '					Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '				End If
        '			Else
        '				Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        '				Call GP_SpActiveCell(vaData, NewCol, NewRow)
        '			End If
        '		Else
        '			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
        '			Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
        '		End If
        '	Else
        '		Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '	End If
        'End If

        'L_blnLeaveCell = False

        '2019/10/07 DEL END

    End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�t�H�[�J�X�擾��
	'�y�� �� ���z vaData_GotFocus
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub vaData_GotFocus()

        '2019/10/07 DEL END

        'Dim varLOCKBN As Object

        ''�J�[�\������B
        'With vaData
        '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If .ActiveRow > 0 Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)
        '        'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        If varLOCKBN = LC_strLINE_LOCK Then
        '            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
        '            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
        '        End If
        '    Else
        '        txtDummy.Focus()
        '    End If

        'End With


        '2019/10/07 DEL END

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
            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            '         'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
            Next

            '2019/10/07 CHG END
        End With

    End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�w�i�F�ݒ�(�s���b�N�敪����)
	'�y�� �� ���z P_Va_BackColor_LINE_LOCK
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub P_Va_BackColor_LINE_LOCK()
		
		Dim lngRow As Integer
		Dim varLOCKBN As Object
		
		If IsNumeric(L_lngMAX_EditRow) = False Then
			Exit Sub
		Else
			If L_lngMAX_EditRow <= 0 Then
				Exit Sub
			End If
		End If

        With vaData
            '2019/10/07 CHG START
            'lngRow = 1
            'For lngRow = 1 To L_lngMAX_EditRow
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_LOCKBN, lngRow, varLOCKBN)
            lngRow = 0
            For lngRow = 0 To L_lngMAX_EditRow
                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_LOCKBN, lngRow, varLOCKBN)
                varLOCKBN = .GetValue(lngRow, LC_lngCol_LOCKBN)
                '2019/10/07 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Protect = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = LC_lng_va_Lock_Color
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Lock = True
            '         'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Enabled = False
                .Rows(i).Cells(LC_lngCol_NO).Style.BackColor = System.Drawing.ColorTranslator.FromOle(LC_lng_va_Lock_Color)
            Next

            '2019/10/07 CHG END

        End With

    End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�s���b�N����
	'�y�� �� ���z P_Va_Lock_Row
	'�y��    �l�z Boolean
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub P_Va_Lock_Row(ByVal lngRow As Integer)

        With vaData
            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Protect = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Lock = True
            '         'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .BlockMode = False

            For j As Integer = LC_lngCol_NO To LC_lngCol_SERIAL
                .Rows(lngRow).Cells(j).Enabled = False
            Next

            '2019/10/07 CHG END

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
		
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim lngI As Integer
		Dim intLen As Short
		
		'�f�[�^�̎擾�B
		If P_Get_Data(Usr_Ody_LC) = True Then
			'�f�[�^����ʂɕ\������B
			Call P_Set_Data(Usr_Ody_LC)
		Else
            '2019/10/07 CHG START
            '         Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            '         Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
            'Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
            'Call SetEdit(vaData, LC_lngCol_SBN, 1)
            '         Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
            Call SetEdit(vaData, LC_lngCol_SERIAL, 0)
            Call SetEdit(vaData, LC_lngCol_LOCKBN, 0)
            Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 0)
            Call SetEdit(vaData, LC_lngCol_SBN, 0)
            Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 0)
            'vaData.MaxRows = LC_lngDEFAULT_ROW
            vaData.RowCount = LC_lngDEFAULT_ROW
            '2019/10/07 CHG END
            intLen = Len(CStr(LC_lngMAX_ROW))
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/07 CHG START
            'For lngI = 1 To vaData.MaxRows
            For lngI = 0 To vaData.RowCount - 1
                '2019/10/07 CHG START
                Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/10/07 CHG START
                'Call vaData.SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
                Call vaData.SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI + 1), intLen))
                '2019/10/07 CHG END
            Next
            Call P_Va_BackColor()
		End If
        '2019/10/07 CHG START
        'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
        '2019/10/07 CHG END
        Call GP_Va_Col_LockColor(vaData, LC_lngCol_NO)
		Call P_Va_Lock()
		
		
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
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim blnFLG As Boolean
		Dim intLen As Short
		Dim lngRecCount As Integer
		Dim varLOCKBN As Object
		Dim varZAISYOBN As Object
		
		On Error GoTo ErrLbl
		
		P_Set_Data = False
		
		lngI = 0
		blnFLG = False
		
		intLen = Len(CStr(LC_lngMAX_ROW))

        With vaData
            '2019/10/07 CHG START

            'Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            'Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
            'Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
            'Call SetEdit(vaData, LC_lngCol_SBN, 1)
            'Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''�X�v���b�h�̍s���̐ݒ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MaxRows = 0
            ''�X�v���b�h�Ƀf�[�^��\������B
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .MaxRows = .MaxRows + 1
            '    lngI = lngI + 1
            '    Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody_LC, CHKFLG, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", "") = C_strCHECKBOX_ON Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        Call .SetText(LC_lngCol_CHECK, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", ""))
            '    End If
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
            '    Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_HID_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_LOCKBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "LOCKBN", ""))
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_ZAISYOBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", ""))
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If varLOCKBN = LC_strLINE_LOCK Then
            '        Call P_Va_Lock_Row(lngI)
            '    End If
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_SBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SBNNO", ""))
            '    Call CF_Ora_MoveNext(Usr_Ody_LC)
            'Loop

            ''�����\������X�v���b�h�s���͍Œ�LC_lngDEFAULT_ROW�s�Ƃ���
            ''UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody_LC.Obj_Ody.RecordCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount
            'L_lngMAX_EditRow = lngRecCount
            'If lngRecCount > LC_lngDEFAULT_ROW Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .MaxRows = lngRecCount
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .MaxRows = LC_lngDEFAULT_ROW
            '    blnFLG = True
            'End If

            'If blnFLG = True Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    For lngJ = lngI To vaData.MaxRows
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        Call .SetText(LC_lngCol_NO, lngJ, VB.Right(Space(intLen) & CStr(lngJ), intLen))
            '        Call SetEdit(vaData, LC_lngCol_CHECK, lngJ)
            '        Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
            '    Next
            'End If

            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True


            Call SetEdit(vaData, LC_lngCol_SERIAL, 0)
            Call SetEdit(vaData, LC_lngCol_LOCKBN, 0)
            Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 0)
            Call SetEdit(vaData, LC_lngCol_SBN, 0)
            Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 0)

            .SuspendLayout()

            .Rows.Clear()

            For lngI = 0 To Usr_Ody_LC.dt.Rows.Count - 1

                .RowCount = .RowCount + 1

                Call SetEdit(vaData, LC_lngCol_CHECK, lngI)

                If DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("CHKFLG"), "") = C_strCHECKBOX_ON Then
                    Call .SetValue(lngI, LC_lngCol_CHECK, True)
                End If

                Call .SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI + 1), intLen))
                Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)

                Call .SetValue(lngI, LC_lngCol_SERIAL, DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("SRANO"), ""))

                Call .SetValue(lngI, LC_lngCol_HID_SERIAL, DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("SRANO"), ""))

                Call .SetValue(lngI, LC_lngCol_LOCKBN, DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("LOCKBN"), ""))

                Call .SetValue(lngI, LC_lngCol_ZAISYOBN, DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("ZAISYOBN"), ""))

                varLOCKBN = .GetValue(lngI, LC_lngCol_LOCKBN)

                varZAISYOBN = .GetValue(lngI, LC_lngCol_ZAISYOBN)

                If varLOCKBN = LC_strLINE_LOCK Then
                    Call P_Va_Lock_Row(lngI)
                End If

                Call .SetValue(lngI, LC_lngCol_SBN,  DB_NullReplace(Usr_Ody_LC.dt.Rows(lngI)("SBNNO"), ""))

            Next

            lngRecCount = lngI
            L_lngMAX_EditRow = lngRecCount
            If lngRecCount > LC_lngDEFAULT_ROW Then
                .RowCount = lngRecCount
            Else
                .RowCount = LC_lngDEFAULT_ROW
                blnFLG = True
            End If

            If blnFLG = True Then
                For lngJ = lngI To vaData.RowCount - 1
                    Call .SetValue(lngJ, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngJ + 1), intLen))
                    Call SetEdit(vaData, LC_lngCol_CHECK, lngJ)
                    Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
                Next
            End If

            .ResumeLayout()

            '2019/10/07 CHG END

        End With

        P_Set_Data = True
		
		
		Exit Function
ErrLbl: 
		Call GP_MsgBox(Common.enmMsg.Critical, Err.Description)
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
		
		Dim strSQL As String
		Dim strWKRPTCLTID As String
		Dim strWKPRGID As String
		Dim strWKHINCD As String
		Dim strWKSBNNO As String
		
		On Error GoTo Errlabel
		
		P_Get_Data = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPRGID = VB.Left(L_strPRGID & Space(7), 7)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		strWKSBNNO = VB.Left(L_strSBNNO & Space(20), 20)
		
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
        '2019/10/07 CHG START
        'strSQL = strSQL & vbCrLf & " From   SRAET53"
        strSQL = strSQL & vbCrLf & " From   CNT_USR9.SRAET53"
        '2019/10/07 CHG END
        strSQL = strSQL & vbCrLf & " Where  RPTCLTID = " & "'" & StChk(strWKRPTCLTID) & "'"
		strSQL = strSQL & vbCrLf & "   And  PRGID    = " & "'" & StChk(strWKPRGID) & "'"
		strSQL = strSQL & vbCrLf & "   And  HINCD    = " & "'" & StChk(strWKHINCD) & "'"
		strSQL = strSQL & vbCrLf & "   And  SBNNO    = " & "'" & StChk(strWKSBNNO) & "'" '2008/01/17 ADD
		strSQL = strSQL & vbCrLf & " Order By   SRALINNO"
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'�擾�f�[�^�L
			P_Get_Data = True
		End If
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_Get_Data)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'�y�g�p�p�r�z ��ʃN���A
	'�y�� �� ���z P_FromClear
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub P_FromClear()
		lblHIN1.Text = ""
		lblHIN2.Text = ""
		lblURISU.Text = ""
		CM_EndCm.Image = IM_EndCm(1).Image
		CM_Execute.Image = IM_Execute(1).Image
		TX_Message.Text = ""
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h������
	'�y�� �� ���z P_vaData_Init
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub P_vaData_Init()
		Dim TypeCheckTypeNormal As Object
		Dim CellTypeCheckBox As Object
		Dim ActionClearText As Object
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim intLen As Short
		
		lngI = 0
		lngLine = 0
		intLen = Len(CStr(LC_lngMAX_ROW))

        With vaData
            '2019/10/07 CHG START
            ''�X�v���b�h�̃N���A
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Action �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g ActionClearText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Action = ActionClearText
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.MaxRows = LC_lngDEFAULT_ROW
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_CHECK
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_CHECK
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.CellType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g CellTypeCheckBox �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CellType = CellTypeCheckBox
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridColor = &H0
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridSolid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridSolid = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeCheckTypeNormal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckType = TypeCheckTypeNormal
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckCenter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckCenter = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckText = ""
            'Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            'Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
            'Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
            'Call SetEdit(vaData, LC_lngCol_SBN, 1)
            'Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
            ''�s�ԍ����Z�b�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'For lngI = 0 To vaData.MaxRows
            '	lngLine = lngLine + 1
            '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '	Call .SetText(LC_lngCol_NO, lngLine, VB.Right(Space(intLen) & CStr(lngLine), intLen))
            '	Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_LOCKBN, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_ZAISYOBN, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_SBN, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_HID_SERIAL, lngLine)
            'Next 
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ColsFrozen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ColsFrozen = LC_lngCol_SERIAL
            '         'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         .ReDraw = True


            .SuspendLayout()

            .RowCount = LC_lngDEFAULT_ROW

            For lngI = 0 To vaData.RowCount - 1
                lngLine = lngLine + 1
                .SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngLine), intLen))
            Next

            .ResumeLayout()

            '2019/10/07 CHG END

        End With

        Call P_Va_BackColor()
		Call P_Va_Lock()
		
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
	Private Function P_GET_HINNMA(ByVal strHINCD As String, ByRef strHINNMA As String) As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim strWKHINCD As String
		
		P_GET_HINNMA = False
		
		'���i�R�[�h��10���ɂ���
		strWKHINCD = VB.Left(strHINCD & Space(10), 10)
		
		'SQL���쐬
		strSQL = vbNullString
		strSQL = strSQL & " SELECT  HINNMA "
		strSQL = strSQL & " FROM    HINMTA"
		strSQL = strSQL & " WHERE   HINCD = '" & strWKHINCD & "'"
		
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'�擾�f�[�^�L
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strHINNMA = CF_Ora_GetDyn(Usr_Ody_LC, "HINNMA", "")
			P_GET_HINNMA = True
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'�y�g�p�p�r�z �V���A�������݃`�F�b�N�i�Ǘ��e�[�u���j
	'�y�� �� ���z P_SRANOCheck
	'�y��    ���z ByVal strSRANO As String  :�V���A����
	'�y��    �l�z Boolean
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Function P_SRANOCheck(ByVal strSRANO As String, ByRef strZAISYOBN As String) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim strWKSRANO As String
		Dim strWKHINCD As String
		
		P_SRANOCheck = False
		strZAISYOBN = ""
		
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		
		'SQL���쐬
		strSQL = vbNullString
		strSQL = strSQL & " SELECT  * " & vbCrLf
		strSQL = strSQL & " FROM    SRACNTTB" & vbCrLf
		strSQL = strSQL & " WHERE   SRANO    = '" & strWKSRANO & "'" & vbCrLf
		strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'" & vbCrLf
		
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'�擾�f�[�^�L
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strZAISYOBN = CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", "")
			
			P_SRANOCheck = True
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
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
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim strWKRPTCLTID As String
		Dim strWKPRGID As String
		Dim strWKHINCD As String
		Dim strWKSRANO As String
		Dim strWKSBNNO As String
		
		P_SRANOCheckWK = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPRGID = VB.Left(L_strPRGID & Space(7), 7)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		strWKSBNNO = VB.Left(L_strSBNNO & Space(20), 20) '2008/01/17 ADD
		
		'SQL���쐬
		strSQL = vbNullString
        strSQL = strSQL & " SELECT  * "
        '2019/10/07 CHG START
        'strSQL = strSQL & " FROM    SRAET53"
        strSQL = strSQL & " FROM    CNT_USR9.SRAET53"
        '2019/10/07 CHG END
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
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h���̓`�F�b�N�i���C���j
	'�y�� �� ���z P_EntryCheck
	'�y��    ���z ByRef lngEntryLine As Long  :�L���s��
	'�y��    �l�z Boolean
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Function P_EntryCheck(ByRef lngEntryLine As Integer) As Boolean
		
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
	Private Function P_NULLCheck(ByRef lngEntryLine As Integer) As Boolean
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varSERIAL_C As Object
		Dim varTNANO As Object
		Dim strKBN As String
		Dim msgMsgBox As MsgBoxResult
		Dim strMSGKBN As String
		Dim strMSGNM As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		
		strMSGKBN = "1"
		lngEntryLine = 0
		
		P_NULLCheck = False
		
		'�f�[�^���͍ő�s���擾
		L_lngMAX_EditRow = P_Get_EditMaxRow()
        '2019/10/07 CHG START
        'For lngI = 1 To L_lngMAX_EditRow
        For lngI = 0 To L_lngMAX_EditRow
            '2019/10/07 CHG END
            With vaData
                '2019/10/07 CHG START
                ''�X�v���b�h�f�[�^���擾
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_NO, lngI, varNO)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
                ''UPGRADE_WARNING: �I�u�W�F�N�g varCHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)

                '2019/10/07 CHG END

                '2019/10/07 ADD START
                If varCHECK Is Nothing Then
                    varCHECK = False
                End If
                '2019/10/07 ADD END

                '2019/10/07 CHG START
                'If varCHECK = C_strCHECKBOX_ON Then
                If Int(varCHECK) = C_strCHECKBOX_ON Then
                    '2019/10/07 CHG END
                    'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If varSERIAL <> vbNullString Then
                        '* �V���A�����d���`�F�b�N
                        '2019/10/07 CHG START
                        'lngJ = 1
                        'For lngJ = 1 To L_lngMAX_EditRow
                        lngJ = 0
                        For lngJ = 0 To L_lngMAX_EditRow
                            '2019/10/07 CHG END
                            'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL_C �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            varSERIAL_C = ""
                            If lngI <> lngJ Then
                                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                '2019/10/07 CHG START
                                'Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                                varSERIAL_C = .GetValue(lngJ, LC_lngCol_SERIAL)
                                '2019/10/07 CHG END
                                'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL_C) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                If Nz(varSERIAL_C) <> "" Then
                                    'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL_C �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                    If varSERIAL = varSERIAL_C Then
                                        'UPGRADE_WARNING: P_NULLCheck �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
                                        If intRet <> 0 Then
                                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                                            Exit Function
                                        End If
                                        'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                                        Call GP_MsgBox(COMMON.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
	Private Function P_Get_EditMaxRow() As Integer
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim varCHECK As Object
		Dim varSERIAL As Object
		Dim varHIDSERIAL As Object
		
		P_Get_EditMaxRow = 0
		
		lngI = 1
        With vaData
            '2019/10/07 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'For lngI = 1 To .MaxRows
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    lngLine = .MaxRows - lngI
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_CHECK, lngLine, varCHECK)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_SERIAL, lngLine, varSERIAL)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_HID_SERIAL, lngLine, varHIDSERIAL)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varHIDSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If Nz(varSERIAL) <> "" Or Nz(varHIDSERIAL) <> "" Then
            '        P_Get_EditMaxRow = lngLine
            '        Exit For
            '    End If
            'Next

            For lngI = 0 To .RowCount - 1
                lngLine = (.RowCount - 1) - lngI
                varCHECK = .GetValue(lngLine, LC_lngCol_CHECK)
                varSERIAL = .GetValue(lngLine, LC_lngCol_SERIAL)
                varHIDSERIAL = .GetValue(lngLine, LC_lngCol_HID_SERIAL)
                If Nz(varSERIAL) <> "" Or Nz(varHIDSERIAL) <> "" Then
                    P_Get_EditMaxRow = lngLine
                    Exit For
                End If
            Next
            '2019/10/07 CHG END
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
	Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, ByVal strSRALINNO As String, ByVal strCHECK As String, ByVal strSRANO As String, ByVal strZAISYOBN As String, ByVal strSBN As String, ByVal strWRTTM As String, ByVal strWRTDT As String) As Boolean
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
            Case enumCREATE_MODE.Insert
                '2019/10/07 CHG START
                'strSQL = strSQL & " INSERT INTO SRAET53 (" & vbCrLf
                strSQL = strSQL & " INSERT INTO CNT_USR9.SRAET53 (" & vbCrLf
                '2019/10/07 CHG END
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
				strSQL = strSQL & "          '" & StChk(L_strSBNNO) & "'," & vbCrLf '2008/01/17 UPD-ADD
				strSQL = strSQL & "          '" & StChk(strSRALINNO) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strSRANO) & "'," & vbCrLf
				strSQL = strSQL & "          '" & LC_strLINE_NOT_LOCK & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strCHECK) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strKBN) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strWRTTM) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strWRTDT) & "'" & vbCrLf
				strSQL = strSQL & "         )" & vbCrLf

            Case enumCREATE_MODE.Update
                '2019/10/07 CHG START
                'strSQL = strSQL & " UPDATE SRAET53" & vbCrLf
                strSQL = strSQL & " UPDATE CNT_USR9.SRAET53" & vbCrLf
                '2019/10/07 CHG END
                strSQL = strSQL & "   SET  SRANO    = '" & StChk(strSRANO) & "'" & vbCrLf
				strSQL = strSQL & "       ,CHKFLG   = '" & StChk(strCHECK) & "'" & vbCrLf
				strSQL = strSQL & "       ,WRTTM    = '" & StChk(strWRTTM) & "'" & vbCrLf
				strSQL = strSQL & "       ,WRTDT    = '" & StChk(strWRTDT) & "'" & vbCrLf
				strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
				strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf '2008/01/17 ����
				strSQL = strSQL & "   AND  SRALINNO = '" & VB6.Format(strSRALINNO, "000000") & "'" & vbCrLf

            Case enumCREATE_MODE.Delete
                '2019/10/07 CHG START
                'strSQL = strSQL & " DELETE FROM SRAET53" & vbCrLf
                strSQL = strSQL & " DELETE FROM CNT_USR9.SRAET53" & vbCrLf
                '2019/10/07 CHG END
                strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
				strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf '2008/01/17 ����
				strSQL = strSQL & "   AND  SRALINNO = '" & VB6.Format(strSRALINNO, "000000") & "'" & vbCrLf
				
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
		
		Dim lngI As Integer
		Dim lngLineNo As Integer
		Dim strSQL As String
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varLOCKBN As Object
		Dim varZAISYOBN As Object
		Dim varSBN As Object
		Dim varHIDSERIAL As Object
		Dim datNOW As Date
		Dim intCnt As Short
		Dim intMaxKeta As Short
		Dim strZero As String
		Dim strCREATE_MODE As enumCREATE_MODE
		
		P_Main = False

        'BEGIN TRAN        
        '2019/10/04 CHG START
        'If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        If DB_BeginTrans(CON) = False Then
            '2019/10/04 CHG END
            GoTo EndLbl
        End If

        '�o�^�����𐶐�
        datNOW = Now
		L_strWRTTM = VB6.Format(datNOW, "HHMMSS")
		L_strWRTDT = VB6.Format(datNOW, "YYYYMMDD")
		
		'�s�ԍ��pZERO������ݒ�
		intCnt = 0
		intMaxKeta = Len(CStr(LC_lngMAX_ROW))
		For intCnt = 0 To intMaxKeta - 1
			strZero = strZero & "0"
		Next 
		
		'�f�[�^�o�^
		lngI = 0
        lngLineNo = 0
        '2019/10/07 CHG START
        'For lngI = 1 To L_lngMAX_EditRow
        For lngI = 0 To L_lngMAX_EditRow
            '2019/10/07 CHG END
            With vaData
                '2019/10/07 CHG START

                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_NO, lngI, varNO)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_SBN, lngI, varSBN)
                ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_HID_SERIAL, lngI, varHIDSERIAL)
                ''UPGRADE_WARNING: �I�u�W�F�N�g Nz(varSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)
                varLOCKBN = .GetValue(lngI, LC_lngCol_LOCKBN)
                varZAISYOBN = .GetValue(lngI, LC_lngCol_ZAISYOBN)
                varSBN = .GetValue(lngI, LC_lngCol_SBN)
                varHIDSERIAL = .GetValue(lngI, LC_lngCol_HID_SERIAL)

                '2019/10/07 CHG END

                '2019/10/07 ADD START
                If varCHECK Is Nothing Then
                    varCHECK = False
                End If
                '2019/10/07 ADD END

                If Nz(varSERIAL) <> "" Then
                    lngLineNo = lngLineNo + 1
                    ' �����敪���肷��
                    'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If varLOCKBN = LC_strLINE_LOCK Then
                        strCREATE_MODE = enumCREATE_MODE.Update
                    Else
                        '����͍s
                        'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If P_SRANOCheckWK(CStr(varSERIAL)) = False Then
                            strCREATE_MODE = enumCREATE_MODE.Update
                        Else
                            strCREATE_MODE = enumCREATE_MODE.Insert
                        End If
                    End If

                    'UPGRADE_WARNING: �I�u�W�F�N�g varSBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g varZAISYOBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g varCHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    '2019/10/07 CHG START
                    'If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), CStr(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
                    If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), Int(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
                        'GoTo EndLbl
                        GoTo ErrLbl
                        '2019/10/07 CHG END
                    End If
                Else
                        lngLineNo = lngLineNo + 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varHIDSERIAL) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If Nz(varHIDSERIAL) <> "" Then
                        strCREATE_MODE = enumCREATE_MODE.Delete
                        'UPGRADE_WARNING: �I�u�W�F�N�g varSBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g varZAISYOBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g varCHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        '2019/10/07 CHG START
                        'If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), CStr(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
                        If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), Int(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
                            'GoTo EndLbl
                            GoTo ErrLbl
                            '2019/10/07 CHG END
                        End If
                    End If
                End If
            End With
        Next lngI

        'COMMIT
        '2019/10/07 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR9)
        Call DB_Commit()
        '2019/10/07 CHG END

        P_Main = True
		
		Exit Function
		
		GoTo EndLbl
ErrLbl:
        '���[���o�b�N
        '2019/10/07 CHG START
        'Call CF_Ora_RollbackTrans(gv_Oss_USR9)
        Call DB_Rollback()
        '2019/10/07 CHG END
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
    '2019/10/07 CHG START
    'Public Sub GP_Va_Col_LockColor(ByRef objSpread As Object, ByVal lngCol As Integer)
    Public Sub GP_Va_Col_LockColor(ByRef objSpread As GrapeCity.Win.MultiRow.GcMultiRow, ByVal lngCol As Integer)
        '2019/10/07 CHG END
        '�X�v���b�h�̔w�i�F�̐ݒ�B
        With objSpread
            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = LC_lng_va_Lock_Color
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True


            .SuspendLayout()

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(lngCol).Style.BackColor = Color.FromArgb(LC_lng_va_Lock_Color)
            Next

            .ResumeLayout()

            '2019/10/07 CHG END
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
    '2019/10/07 CHG START
    'Public Sub GP_Va_Col_LockColor_Row(ByRef objSpread As Object, ByVal lngRow As Integer)
    Public Sub GP_Va_Col_LockColor_Row(ByRef objSpread As GrapeCity.Win.MultiRow.GcMultiRow, ByVal lngRow As Integer)
        '2019/10/07 CHG END

        '�X�v���b�h�̔w�i�F�̐ݒ�B
        With objSpread
            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True

            .SuspendLayout()

            For j As Integer = LC_lngCol_NO To LC_lngCol_SERIAL
                .Rows(lngRow).Cells(j).Style.BackColor = Me.BackColor
            Next

            .ResumeLayout()

            '2019/10/07 CHG END

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
    '2019/10/07 CHG START
    'Public Sub GP_Va_Col_EditColor(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer, ByVal bolEdit As Boolean, Optional ByVal lngCol2 As Integer = 0, Optional ByVal lngRow2 As Integer = 0)
    Public Sub GP_Va_Col_EditColor(ByRef objSpread As GrapeCity.Win.MultiRow.GcMultiRow, ByVal lngCol As Integer, ByVal lngRow As Integer, ByVal bolEdit As Boolean, Optional ByVal lngCol2 As Integer = -1, Optional ByVal lngRow2 As Integer = -1)
        '2019/10/07 CHG NED

        Dim varZAISYOBN As Object
        Dim lngI As Integer

        '�X�v���b�h�̔w�i�F�̐ݒ�B
        With objSpread
            '2019/10/07 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            'If bolEdit Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Col2 = lngCol
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .BackColor = LC_lng_va_Edit_Color
            'Else
            '    If lngRow2 <> 0 Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Row2 = lngRow2
            '    Else
            '        'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Row2 = lngRow
            '    End If
            '    If lngCol2 <> 0 Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Col2 = lngCol2
            '    Else
            '        'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Col2 = lngCol
            '    End If
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True

            .SuspendLayout()

            Dim row2 As Integer
            Dim col2 As Integer
            Dim backColor As Color

            If bolEdit Then
                row2 = lngRow
                col2 = lngCol
                backColor = System.Drawing.ColorTranslator.FromOle(LC_lng_va_Edit_Color)
            Else
                If lngRow2 <> -1 Then
                    row2 = lngRow2
                Else
                    row2 = lngRow
                End If
                If lngCol2 <> -1 Then
                    col2 = lngCol2
                Else
                    col2 = lngCol
                End If
                backColor = Color.White
            End If

            For i As Integer = lngRow To row2
                For j As Integer = lngCol To col2
                    .Rows(i).Cells(j).Style.BackColor = backColor
                Next
            Next

            .ResumeLayout()

            '2019/10/07 CHG END

        End With

        With objSpread

            '2019/10/07 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            'If lngRow2 <> 0 Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow2
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True

            .SuspendLayout()

            Dim row2 As Integer
            Dim col2 As Integer
            Dim backColor As Color

            If lngRow2 <> -1 Then
                row2 = lngRow2
            Else
                row2 = lngRow
            End If

            col2 = LC_lngCol_NO

            For i As Integer = lngRow To row2
                .Rows(i).Cells(LC_lngCol_NO).Style.BackColor = backColor
            Next

            .ResumeLayout()

            '2019/10/07 CHG END

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
    Private Sub SetEdit(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
		Dim PositionCenterLeft As Object
		Dim TypeEditCharSetAlphanumeric As Object
		Dim CellTypeEdit As Object
		Dim TypeCheckTypeNormal As Object
		Dim CellTypeCheckBox As Object
        With vaData
            '2019/10/07 DEL START
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = False
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridSolid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridSolid = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridColor = &H0
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.FontSize �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.FontSize = 12
            'If lngCol = LC_lngCol_CHECK Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Col = LC_lngCol_CHECK
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Col2 = LC_lngCol_CHECK
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row = lngRow
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.CellType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CellTypeCheckBox �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .CellType = CellTypeCheckBox
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g TypeCheckTypeNormal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TypeCheckType = TypeCheckTypeNormal
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckCenter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TypeCheckCenter = True
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeCheckText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TypeCheckText = ""
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.CellType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CellTypeEdit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .CellType = CellTypeEdit '��������
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeEditCharSet �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g TypeEditCharSetAlphanumeric �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .TypeEditCharSet = TypeEditCharSetAlphanumeric '���p�p����
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Position �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    'UPGRADE_WARNING: �I�u�W�F�N�g PositionCenterLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Position = PositionCenterLeft
            'End If
            ''���͌������Z�b�g
            'Select Case lngCol
            '    Case LC_lngCol_SERIAL
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeMaxEditLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TypeMaxEditLen = C_lngSERIAL_Len
            'End Select
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True
            '2019/10/07 DEL END
        End With
    End Sub
	
	Private Sub vaData_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)

        '2019/10/07 DEL START

        'Dim varLOCKBN As Object

        'With vaData
        '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)

        '    'UPGRADE_WARNING: �I�u�W�F�N�g varLOCKBN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    If varLOCKBN = LC_strLINE_NOT_LOCK Then
        '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
        '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '        Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
        '    End If
        'End With

        '2019/10/07 DEL END

    End Sub
	
	Private Sub vaData_Validate(ByRef Cancel As Boolean)
		L_lngMAX_EditRow = P_Get_EditMaxRow
	End Sub
	
	Private Sub F_SendKey(ByVal KeyCode As Short)
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F1 : System.Windows.Forms.SendKeys.Send("%1")
			Case System.Windows.Forms.Keys.F2 : System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
    '=========================================================================�y ���\�b�h �z=

    '2019/10/04 ADD START
    '********************************************************************************
    ' @(f)      : Ctrl_send
    '
    ' �@�\      : �R���g���[���ړ����ړ�����B
    '
    ' �Ԃ�l    :
    '
    ' ������    : KeyAscii As Integer
    '
    ' ���l      :

    Function GP_CtrlSend(ByRef KeyAscii As Short, ByRef frm As System.Windows.Forms.Form) As Object
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            PostMessage(frm.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021S)
            KeyAscii = 0
        End If
    End Function

    Public Function Nz(ByVal var As Object, Optional ByVal str_Renamed As String = "") As Object

        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(var) = True Then
            If str_Renamed = "" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Nz = ""
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Nz = str_Renamed
            End If

        ElseIf Len(var) < 1 Then
            If str_Renamed = "" Then
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Nz = ""
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Nz = str_Renamed
            End If
        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g var �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Nz �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Nz = var
        End If

    End Function

    Public Function StChk(ByVal strVar As String) As String

        Dim strWK As String
        Dim strWk2 As String
        Dim lngIndex As Integer
        Const C_strQut As String = "'"

        '�V���O���R�[�e�[�V����1��2�ɒu��������B
        '�I���N����INSERT�y�сAUPDATE���Ɏg�p���Ă��������B
        strWK = vbNullString
        If Len(strVar) > 0 Then

            'VB5�ȉ��Ŏg�p����B
            '        For lngIndex = 1 To Len(strVar)
            '            strWk2 = Mid(strVar, lngIndex, 1)
            '            If strWk2 = C_strQut Then
            '                strWK = strWK & strWk2 & C_strQut
            '            Else
            '                strWK = strWK & strWk2
            '            End If
            '        Next lngIndex

            'VB6�ȏ�Ŏg�p����B
            strWK = Replace(strVar, "'", "''")
        End If

        StChk = strWK

    End Function

    '2019/10/04 ADD START
    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        Call CM_Execute_Click(CM_Execute, New System.EventArgs())
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call MN_APPENDC_Click(MN_APPENDC, New System.EventArgs())
    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
    End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    '�X�V
                    Me.btnF1.PerformClick()

                Case Keys.F9
                    '�N���A
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '�I��
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("�t�H�[��KeyDown�G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
        End Try
    End Sub

    '2019/10/04 ADD END

End Class