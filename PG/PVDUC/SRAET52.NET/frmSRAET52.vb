Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'***************************************************************************************
	'*  �y�g�p�p�r�z�V���A�����o�^
	'*  �y�� �� ���z2006/09/04  SYSTEM CREATE CO,.Ltd.
	'*  �y�X �V ���z2008/08/05  FKS)NAKATA
	'*  �y��    �l�z �V���A���Ǘ��e�[�u���̌�������������ѓ����O���A�Y������SBNNO��HIMCD��
	'*               ����ΑS�ďo�͂�����
	'***************************************************************************************
	
	'-�y �ϐ��錾 �z-------------------------------------------------------------------------
	'AppPath�ޔ�p
	Private L_strAppPath As String
	
	'�f�[�^�o�^�p
	Private L_strWRTTM As String
	Private L_strWRTDT As String
	
	'�p�����[�^�擾�p
	Private L_strRPTCLTID As String
	'2008/08/06 CHG START FKS)NAKATA
	'Private L_strRSTDT                      As String
	Private L_strJDNNO As String
	'2008/08/06 CHG E.N.D FKS)NAKATA
	Private L_strHINCD As String
	Private L_strSBNNO As String
	Private L_strURISU As String
	
	' �v���p�e�B�l�i�[�p�ϐ�
	Dim mstrRPTCLTID As String
	Dim mstrRSTDT As String
	Dim mstrHINCD As String
	Dim mstrSBNNO As String
	Dim mstrURISU As String
	
	'* �ő���͌���
	'2008/08/06 CHG START FKS)NAKATA
	''Private Const C_lngSERIAL_Len           As Long = 13        '�V���A����
	Private Const C_lngSERIAL_Len As Integer = 22 '�V���A���� & ���ѓ�
	'2008/08/06 CHG E.N.D FKS)NAKATA
	
	Private LC_lngDataMAX_ROW As Integer
	Private LC_lngCurrent As Integer
	
	'�X�V�m�F���b�Z�[�W�L�����Z������ActiveCell�Z�b�g�p
	Private L_LastCol As Integer '��
	Private L_LastRow As Integer '�s
	'-------------------------------------------------------------------------�y �ϐ��錾 �z-
	
	'-�y �萔�錾 �z-------------------------------------------------------------------------
	'�^�C�g��
	Private Const LC_strPG_ID As String = "SRAET52"
	Private Const LC_strTitle As String = "�V���A�����o�^"
	
	' �p�����[�^ �X�C�b�`��`
	Private Const mcPARAM_RPTCLTID As String = "/RPTCLTID:"
	'2008/08/06 CHG START FKS)NAKATA
	''���ѓ�����󒍔ԍ��ɕύX
	'Private Const mcPARAM_RSTDT             As String = "/RSTDT:"
	Private Const mcPARAM_JDNNO As String = "/JDNNO:"
	'2008/08/06 CHG E.N.D FKS)NAKATA
	Private Const mcPARAM_HINCD As String = "/HINCD:"
	Private Const mcPARAM_SBNNO As String = "/SBNNO:"
	Private Const mcPARAM_URISU As String = "/URISU:"
	
	'�X�v���b�h�w�i�F
	Private Const LC_lng_va_Edit_Color As Integer = &HFFFF
	Private Const LC_lng_va_UnEdit_Color As Integer = &HFFFFFF
	Private Const LC_lng_va_Lock_Color As Integer = &HC0C0C0
	
	'�X�v���b�h�̍s
	Private Const LC_lngMAX_ROW As Integer = 999999 '* �ő�s��
	Private Const LC_lngDEFAULT_ROW As Integer = 1 '* �f�t�H���g�Z�b�g�s

    '�X�v���b�h�̍���    
    Private Const LC_lngCol_CHECK As Integer = 0 '* �ԕi�`�F�b�N
    Private Const LC_lngCol_NO As Integer = 1 '* �s��
    Private Const LC_lngCol_SERIAL As Integer = 2 '* �V���A����    

    '�o�׍ς݋敪
    Private Const LC_strSYUKA As String = "02"
	
	'SQL���������̃��[�h
	Private Enum enumCREATE_MODE
		Ins
		Del
	End Enum
	
	'���b�Z�[�W��
	Private Const LC_strAPPEND As String = "_APPEND        " '* ���ʃ��b�Z�[�W
	Private Const LC_strCURSOR As String = "_CURSOR        " '* ���ʃ��b�Z�[�W
	
	'���b�Z�[�W�h�c
	Private Const CommonMSGSQ As String = "0" '* ���ʃ��b�Z�[�W�h�c
	Private Const Entry As String = "0" '* �o�^�m�F���b�Z�[�W
	Private Const EntryFinal As String = "1" '* �o�^�チ�b�Z�[�W
	Private Const NotHINCD As String = "2" '* %CD�Ƃ������i�R�[�h�͑��݂��܂���B
	Private Const NoData As String = "3" '* �Y���f�[�^�����݂��܂���B
	Private Const NotSerial As String = "4" '* �ԕi�ς̃V���A���������͂���܂����B��낵���ł����B
	Private Const NoCheck As String = "5" '* �o�^�Ώۂ̃f�[�^������܂���B
    Private Const InfLineOver As String = "6" '* ���͍s�������ʂƍ����܂���B

    '2019/09/23 ADD START
    'API�֐��̐錾
    Private Const WM_KEYDOWN As Short = &H100S
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '2019/09/23 ADD END
    '-------------------------------------------------------------------------�y �萔�錾 �z-


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
		Call FR_SSSMAIN_Load(Me, New System.EventArgs())
	End Sub
	'-----------------------------------------------------------------------�y����޳��ƭ��z-
	
	'===========================================================================
	'�y�g�p�p�r�z [�I��]�{�^���N���b�N��
	'�y�� �� ���z CM_EndCm_Click
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
        '2019/10/01 DEL START
        ''* �Z���w�i�F������
        'With vaData
        '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '    '2019/09/23 CHG START
        '    'Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
        '    Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .RowCount - 1)
        '    '2019/09/23 CHG END
        'End With
        'Me.Close()
        '2019/10/01 DEL END
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

        '2019/10/01 DEL START

        '        Dim msgMsgBox As MsgBoxResult
        '		Dim lngRow As Integer
        '		'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '		Dim Mst_Inf As TYPE_DB_SYSTBH
        '		Dim intRet As Short
        '		Dim strMSGKBN As String
        '		Dim strMSGNM As String
        '		Dim lngChkRow As Integer
        '		Dim blnInsFlg As Boolean

        '		strMSGKBN = "1"
        '		lngChkRow = 0
        '		blnInsFlg = False

        '		'* �Z���w�i�F������
        '		With vaData
        '			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
        '		End With

        '		'�X�v���b�h�̓��̓`�F�b�N
        '		If P_EntryCheck(lngRow) = False Then
        '			Exit Sub
        '		Else
        '			'''        '���ׂɃ`�F�b�N�������Ă��Ȃ��Ƃ��͏����I��
        '			'''        If lngRow = 0 Then
        '			'''            strMSGKBN = "1"
        '			'''            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoCheck, Mst_Inf)
        '			'''            If intRet <> 0 Then
        '			'''                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", vbOKOnly + vbExclamation, LC_strTitle)
        '			'''                Exit Sub
        '			'''            End If
        '			'''            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '			'''            If L_LastCol > 0 And L_LastRow > 0 Then
        '			'''                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
        '			'''                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        '			'''            Else
        '			'''                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
        '			'''                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
        '			'''            End If
        '			'''            Exit Sub
        '			'''        End If
        '			'�I���s�������ʂƓ������Ȃ��Ƃ��̓G���[
        '			If lngRow <> CInt(Me.lblURISU.Text) Then
        '				'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '				If intRet <> 0 Then
        '					Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '					Exit Sub
        '				End If
        '				'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '				Exit Sub
        '			End If

        '			'�V���A�����`�F�b�N
        '			With vaData
        '                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '                '2019/09/23 CHG START
        '                'For lngChkRow = 1 To .MaxRows
        '                For lngChkRow = 1 To .RowCount - 1
        '                    '2019/09/23 CHG END
        '                    If P_EntryCheckSerial(lngChkRow) = False Then
        '                        strMSGKBN = "1"
        '                        'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '                        If intRet <> 0 Then
        '                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '                            Exit Sub
        '                        End If
        '                        'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '                        msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        '                        If msgMsgBox <> MsgBoxResult.Yes Then
        '                            If lngChkRow > 0 Then
        '                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
        '                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
        '                            Else
        '                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '                            End If
        '                            Exit Sub
        '                        Else
        '                            blnInsFlg = True
        '                        End If
        '                    End If
        '                Next
        '            End With
        '		End If

        '		If blnInsFlg = False Then
        '			'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
        '			If intRet <> 0 Then
        '				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '				Exit Sub
        '			End If
        '			'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			msgMsgBox = GP_MsgBox(Common.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        '			If msgMsgBox <> MsgBoxResult.Yes Then
        '				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '				Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '				'        If L_LastCol > 0 And L_LastRow > 0 Then
        '				'            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
        '				'            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        '				'        Else
        '				'            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
        '				'            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
        '				'        End If
        '				Exit Sub
        '			End If
        '		End If

        '		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '		'�o�^����
        '		If P_Main() = True Then
        '			'* �f�[�^�o�^��͉�ʂ����
        '			Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
        '			Exit Sub
        '		End If

        'EndLabel: 
        '		'* �Z���w�i�F��ݒ�
        '		Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)

        '		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '2019/10/01 DEL END

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
        '2019/09/23 DEL START
        'If App.PrevInstance Then
        '    Call GP_MsgBox(COMMON.enmMsg.Critical, "���ɋN�����Ă��܂��B", LC_strTitle)
        '    End
        'End If
        '2019/09/23 DEL END
        '�t�H�[���̈ʒu���Z�b�g
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		
		'AppPath�̑ޔ�
		L_strAppPath = My.Application.Info.DirectoryPath
		
		'�p�����[�^�擾
		strArry = Split(Replace(VB.Command(), """", ""), " ")
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
			Call GP_MsgBox(Common.enmMsg.Critical, "���[�N�X�e�[�V�����h�c���ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		
		'2008/08/06 CHG START FKS)NAKATA
		'' ���ѓ�����󒍔ԍ��ɕύX
		''    If L_strRSTDT = "" Then
		''        Call GP_MsgBox(Critical, "���ѓ����ݒ肳��Ă��܂���B", LC_strTitle)
		''        End
		''    End If
		If L_strJDNNO = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "�󒍔ԍ����ݒ肳��Ă��܂���B", LC_strTitle)
			End
		End If
		'2008/08/06 CHG E.N.D FKS)NAKATA
		
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
		
		'�X�v���b�h�̏�����
		Call P_vaData_Init()
		
		'DB�ڑ�
		Call CF_Ora_USR1_Open()
        Call CF_Ora_USR9_Open()

        '�󂯎�����p�����[�^����ʂɃZ�b�g
        lblHIN1.Text = L_strHINCD
		If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
			lblHIN2.Text = strHINNM
		Else
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
        LC_lngCurrent = 1

        '2019/10/01 ADD START
        SetBar(Me)
        '2019/10/01 ADD END

        '��ʂ̏����\��
        If P_Show_Data = False Then
			'�f�[�^���Ȃ��Ƃ�
			strMSGKBN = "1"
			'UPGRADE_WARNING: Form_Load �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				End
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        'DB�ڑ�����
        '2019/09/23 CHG START        
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        Call DB_CLOSE(CON)
        '2019/09/23 CHG END
        '2019/09/23 ADD START
        DB_CLOSE(CON_USR9)
        Call SSSWIN_LOGWRT("�v���O�����I��")
        '2019/09/23 ADD END
        eventArgs.Cancel = Cancel
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �L�[������
	'�y�� �� ���z Form_KeyPress
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub FR_SSSMAIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.ComboBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.RadioButton Then
			
			Call GP_CtrlSend(KeyAscii, Me)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'===========================================================================
	'�y�g�p�p�r�z �X�v���b�h�G�f�B�b�g���[�h�ύX��
	'�y�� �� ���z vaData_EditChange
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Sub vaData_EditChange(ByVal Col As Integer, ByVal Row As Integer)

        With vaData
            '2019/10/01 DEL START
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'If LC_lngMAX_ROW <> .MaxRows Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If .MaxRows = Row Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .MaxRows = .MaxRows + 1
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Row = 1
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Row2 = .MaxRows
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Col = LC_lngCol_NO
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Col2 = LC_lngCol_SERIAL
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BlockMode = True
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Protect = True
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .Lock = True
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
            '    End If
            'End If
            '2019/10/01 DEL END
        End With

    End Sub
	
	Private Sub vaData_KeyPress(ByRef KeyAscii As Short)
		
		Dim msgMsgBox As MsgBoxResult
		Dim strMSGKBN As String
		Dim strMSGNM As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short

        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/01 CHG START
        'If LC_lngCurrent = vaData.MaxRows Then
        If LC_lngCurrent = vaData.RowCount - 1 Then
            '2019/10/01 CHG END
            L_LastCol = LC_lngCol_CHECK
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/01 CHG START
            'L_LastRow = vaData.MaxRows
            L_LastRow = vaData.RowCount - 1
            '2019/10/01 CHG END
            '2019/10/01 CHG START
            'Call CM_Execute_Click(CM_Execute, New System.EventArgs())
            btnF1.PerformClick()
            '2019/10/01 CHG END
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
	Private Sub vaData_LeaveCell(ByVal Col As Integer, ByVal Row As Integer, ByVal NewCol As Integer, ByVal NewRow As Integer, ByRef Cancel As Boolean)
		
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
        '2019/09/23 DEL START
        '�J�[�\������B
        '      With vaData
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	If .ActiveRow > 0 Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveCol �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		If .ActiveCol = 1 Then
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
        '		Else
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveCol �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
        '		End If
        '		''''    Else                '2006.09.28
        '		''''        cmdExe.SetFocus '2006.09.28
        '	Else
        '		txtDummy.Focus()
        '	End If
        '	'UPGRADE_WARNING: �I�u�W�F�N�g vaData.ActiveRow �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
        'End With
        '2019/09/23 DEL END
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
		
		Dim lngRow As Integer

        With vaData
            '2019/09/23 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
                .Rows(i).Cells(LC_lngCol_SERIAL).Style.BackColor = Me.BackColor
            Next

            '2019/09/23 CHG END
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
            ''2019/09/23 CHG START
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = 1
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Protect �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Protect = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Lock �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Lock = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Enabled = False
                .Rows(i).Cells(LC_lngCol_SERIAL).Enabled = False
            Next

            '2019/09/23 CHG END
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
		
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim lngI As Integer
		Dim intLen As Short
		
		P_Show_Data = False
		
		'�X�v���b�h�̃N���A
		Call P_vaData_Init()
		
		'�f�[�^�̎擾�B
		If P_Get_Data(Usr_Ody_LC) = True Then
			'�f�[�^����ʂɕ\������B
			Call P_Set_Data(Usr_Ody_LC)
			'�X�v���b�h�̓��͐����B
			Call P_Va_Lock()
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
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim blnFLG As Boolean
		Dim intLen As Short
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim wkSRANO As String '�V���A�������[�N
		Dim wkRSTDT As String '���ѓ����[�N
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		On Error GoTo ErrLbl
		
		P_Set_Data = False
		
		lngI = 0
		blnFLG = False

        intLen = Len(CStr(LC_lngMAX_ROW))

        '2019/09/23 ADD START
        Dim dt As DataTable = Usr_Ody_LC.dt
        '2019/09/23 ADD END        

        With vaData

            '2019/09/23 CHG START

            ''�X�v���b�h�̍s���̐ݒ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B            
            ''.ReDraw = False
            '''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B            
            ''.MaxRows = 0
            ''�X�v���b�h�Ƀf�[�^��\������B
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    lngI = lngI + 1

            '    '2008/08/06 ADD START FKS)NAKATA
            '    'DB���擾�����V���A�����Ǝ��ѓ����i�[
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    wkSRANO = CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", "")
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    wkRSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "RSTDT", "")
            '    '2008/08/06 ADD E.N.D FKS)NAKATA


            '    'LC_lngMAX_ROW�s�𒴂����Ƃ��͋����I��LOOP�����𔲂���
            '    If lngI > LC_lngMAX_ROW Then
            '        GoTo LBL_LOOP_END
            '    End If
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .MaxRows = .MaxRows + 1
            '    Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(Usr_Ody_LC, KBN, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    If CF_Ora_GetDyn(Usr_Ody_LC, "KBN", "") = "C" Then
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B                    
            '        Call .SetText(LC_lngCol_CHECK, lngI, "1")
            '    End If
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B                
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))

            '    '2008/08/06 ADD START FKS)NAKATA
            '    ''�X�v���b�h�ɃV���A�����Ǝ��ѓ����X�y�[�X��1����i�[
            '    ''            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B                
            '    Call .SetText(LC_lngCol_SERIAL, lngI, wkSRANO & " " & wkRSTDT)

            '    '2008/08/06 ADD E.N.D FKS)NAKATA

            '    Call CF_Ora_MoveNext(Usr_Ody_LC)
            'Loop

            '.Template = Me.Template31

            .SuspendLayout()

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                If dt.Rows.Count > LC_lngMAX_ROW Then
                    .RowCount = LC_lngMAX_ROW
                Else
                    .RowCount = dt.Rows.Count
                End If

                For cnt As Integer = 0 To dt.Rows.Count - 1

                    lngI = lngI + 1

                    wkSRANO = Trim(DB_NullReplace(dt.Rows(cnt)("SRANO"), ""))

                    wkRSTDT = Trim(DB_NullReplace(dt.Rows(cnt)("RSTDT"), ""))

                    If lngI > LC_lngMAX_ROW Then
                        GoTo LBL_LOOP_END
                    End If

                    '.RowCount = cnt + 1

                    Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)

                    If Trim(DB_NullReplace(dt.Rows(cnt)("KBN"), "")) = "C" Then
                        .SetValue(cnt, LC_lngCol_CHECK, False)
                    End If

                    .SetValue(cnt, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI), intLen))

                    .SetValue(cnt, LC_lngCol_SERIAL, wkSRANO & " " & wkRSTDT)

                Next

            End If

            '2019/09/23 CHG END            

LBL_LOOP_END:
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g Usr_Ody_LC.Obj_Ody.RecordCount �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            '.MaxRows = Usr_Ody_LC.Obj_Ody.RecordCount
            '''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'LC_lngDataMAX_ROW = .MaxRows

            ''�w�i�F�̐ݒ�
            'Call P_Va_BackColor()

            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B           
            '.ReDraw = True            

            LC_lngDataMAX_ROW = .RowCount

            '�w�i�F�̐ݒ�
            Call P_Va_BackColor()

            .ResumeLayout()

            '2019/09/23 CHG END
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
	'�y�X �V ���z 2008/08/06 FKS)NAKATA
	'�y��    �l�z ���ѓ��̎擾��ǉ�
	'===========================================================================
	Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean
		
		Dim strSQL As String
		Dim strWKRSTDT As String
		Dim strWKRPTCLTID As String
		Dim strDB As String
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim strPUDLNO As String
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		On Error GoTo Errlabel
		
		
		'2008/08/06 ADD START FKS)NAKATA
		''JDNTRA���PUDLNO�̎擾
		If P_GET_PUDLNO(L_strJDNNO, strPUDLNO) = False Then
			strPUDLNO = ""
		End If
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		P_Get_Data = False
		
		'strWKRSTDT = Left(L_strRSTDT & Space(8), 8)
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)

        '2019/09/24 CHG START
        'strDB = Get_DBHEAD() & "_" & ORA_MAX_USR9
        strDB = "CNT_USR9"
        '2019/09/24 CHG END

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
        '    strSQL = strSQL & vbCrLf & " Where   SRA.RSTDT     = " & "'" & strWKRSTDT & "'"
        '    strSQL = strSQL & vbCrLf & "   And   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
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

        'strSQL = strSQL & vbCrLf & " Order By SRA.SRANO FETCH FIRST 10 ROWS ONLY"


        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)


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
		Dim intLen As Short
		
		lngI = 0
		intLen = Len(CStr(LC_lngMAX_ROW))

        With vaData
            '2019/09/23 CHG START
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
            'Call SetEdit(vaData, LC_lngCol_NO, 1)
            'Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            ''�s�ԍ����Z�b�g
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'For lngI = 0 To vaData.MaxRows
            '    lngI = lngI + 1
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.SetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
            'Next
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True

            .SuspendLayout()

            .RowCount = LC_lngDEFAULT_ROW

            '�s�ԍ����Z�b�g
            For lngI = 0 To vaData.RowCount - 1
                Call .SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI + 1), intLen))
            Next

            .ResumeLayout()

            '2019/09/23 CHG END

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
	'�y�g�p�p�r�z �X�v���b�h���̓`�F�b�N�i���C���j
	'�y�� �� ���z P_EntryCheck
	'�y��    ���z ByRef lngEntryLine As Long  :�L���s��
	'�y��    �l�z Boolean
	'�y�X �V ���z
	'�y��    �l�z
	'===========================================================================
	Private Function P_EntryCheck(ByRef lngEntryLine As Integer) As Boolean
		
		Dim lngI As Integer
		Dim varCHECK As Object
		Dim lngCount As Integer
		
		P_EntryCheck = False
		
		With vaData
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            'For lngI = 1 To .MaxRows
            For lngI = 0 To .RowCount - 1
                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                '2019/09/23 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varCHECK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
	Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, ByVal strSRANO As String, ByVal strWRTTM As String, ByVal strWRTDT As String) As Boolean
		Dim strSQL As String
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim wkSRANO As String
		Dim wkRSTDT As String
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		P_EXECUTE_SQL = False
		
		strSQL = vbNullString
		
		'2008/08/06 ADD START FKS)NAKATA
		''�p�����[�^���V���A�����Ǝ��ѓ��ɕ�����
		wkSRANO = VB.Left(Trim(strSRANO), 13)
		wkRSTDT = VB.Right(Trim(strSRANO), 8)
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		Select Case strMode
            Case enumCREATE_MODE.Ins
                '2019/10/01 CHG START
                'strSQL = strSQL & " INSERT INTO SRAET52 (" & vbCrLf
                strSQL = strSQL & " INSERT INTO CNT_USR9.SRAET52 (" & vbCrLf
                '2019/10/01 CHG END
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
                '2019/10/01 CHG START
                'strSQL = strSQL & " DELETE FROM SRAET52" & vbCrLf
                strSQL = strSQL & " DELETE FROM CNT_USR9.SRAET52" & vbCrLf
                '2019/10/01 CHG END
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
		
		Dim lngI As Integer
		Dim lngLineNo As Integer
		Dim strSQL As String
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varSBNNO As Object
		Dim datNOW As Date
		Dim intCnt As Short
		Dim intMaxKeta As Short
		Dim strZero As String
		
		P_Main = False

        'BEGIN TRAN
        '2019/09/23 CHG START
        'If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        If DB_BeginTrans(CON) = False Then
            '2019/09/23 CHG END
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
		
		'DELETE
		If P_EXECUTE_SQL(enumCREATE_MODE.Del, "", "", "") = False Then
			GoTo EndLbl
		End If
		
		'INSERT
		lngI = 0
		lngLineNo = 0
		With vaData
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            'For lngI = 1 To .MaxRows
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_NO, lngI, varNO)
            '    'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            For lngI = 0 To .RowCount - 1
                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)
                '2019/09/23 CHG END
                'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varCHECK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If Nz(varCHECK) = "1" Then
                    lngLineNo = lngLineNo + 1
                    'UPGRADE_WARNING: �I�u�W�F�N�g varSERIAL �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If P_EXECUTE_SQL(enumCREATE_MODE.Ins, CStr(varSERIAL), L_strWRTTM, L_strWRTDT) = False Then
                        GoTo EndLbl
                    End If
                End If
            Next lngI
        End With
		
		'COMMIT
		Call CF_Ora_CommitTrans(gv_Oss_USR9)
		
		P_Main = True
		
		Exit Function
		
		GoTo EndLbl
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
	Public Sub GP_Va_Col_LockColor(ByRef objSpread As Object, ByVal lngCol As Integer)
		
		'�X�v���b�h�̔w�i�F�̐ݒ�B
		With objSpread
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Row = 1
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Col = lngCol
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Row2 = .MaxRows
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.Col2 = lngCol
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.BlockMode = True
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			.BackColor = LC_lng_va_Lock_Color
			'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
    Public Sub GP_Va_Col_EditColor(ByRef objSpread As GrapeCity.Win.MultiRow.GcMultiRow, ByVal lngCol As Integer, ByVal lngRow As Integer, ByVal bolEdit As Boolean, Optional ByVal lngCol2 As Integer = 0, Optional ByVal lngRow2 As Integer = 0)

        '�X�v���b�h�̔w�i�F�̐ݒ�B
        With objSpread

            '2019/10/01 CHG START

            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            'If lngRow2 <> 0 Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow2
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Row2 = lngRow
            'End If
            'If lngRow2 <> 0 Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Col2 = lngCol2
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .Col2 = lngCol
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = True
            'If bolEdit Then
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .BackColor = LC_lng_va_Edit_Color
            'Else
            '    'UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BackColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '    .BackColor = LC_lng_va_UnEdit_Color
            'End If
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.BlockMode �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.BlockMode = False


            Dim row2 As Integer
            Dim col2 As Integer

            If lngRow2 <> 0 Then
                row2 = lngRow2
                col2 = lngCol2
            Else
                row2 = lngRow
                col2 = lngCol
            End If

            Dim backColor As Color

            If bolEdit Then
                backColor = Color.FromArgb(LC_lng_va_Edit_Color)
            Else
                backColor = Color.FromArgb(LC_lng_va_UnEdit_Color)
            End If

            For i As Integer = lngRow To row2
                For j As Integer = lngCol To col2
                    .Rows(i).Cells(j).Style.BackColor = backColor
                Next
            Next

            '2019/10/01 CHG END

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
    Private Sub SetCheckBox(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
        Dim TypeVAlignCenter As Object
        Dim TypeHAlignCenter As Object
        Dim TypeCheckTextAlignRight As Object
        Dim TypeCheckTypeNormal As Object
        Dim CellTypeCheckBox As Object


        With objSpread
            '2019/09/23 DEL START
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Col2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Col2 = lngCol
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.Row2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Row2 = lngRow
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.CellType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g CellTypeCheckBox �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CellType = CellTypeCheckBox ' �����߂̐ݒ�
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeCheckText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckText = "" ' �����ޯ�� ���߼��
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeCheckType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeCheckTypeNormal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckType = TypeCheckTypeNormal ' �����ޯ�� ����
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeCheckTextAlign �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeCheckTextAlignRight �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckTextAlign = TypeCheckTextAlignRight ' ÷�Ĕz�u
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeHAlign �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeHAlignCenter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeHAlign = TypeHAlignCenter ' �����z�u
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeVAlign �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeVAlignCenter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeVAlign = TypeVAlignCenter ' �����z�u
            ''UPGRADE_WARNING: �I�u�W�F�N�g objSpread.TypeCheckCenter �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeCheckCenter = True ' �����z�u            
            '2019/09/23 DEL END
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
    Private Function P_EntryCheckSerial(ByVal lngLineNo As Integer) As Boolean
		
		Dim varCHECK As Object
		Dim varSERIAL As Object
		Dim strKBN As String
		
		P_EntryCheckSerial = False
		
		With vaData
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            'Call .GetText(LC_lngCol_CHECK, lngLineNo, varCHECK)
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GetText �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'Call .GetText(LC_lngCol_SERIAL, lngLineNo, varSERIAL)
            varCHECK = .GetValue(lngLineNo, LC_lngCol_CHECK)
            varSERIAL = .GetValue(lngLineNo, LC_lngCol_SERIAL)
            '2019/09/23 CHG END
            'UPGRADE_WARNING: �I�u�W�F�N�g Nz(varCHECK) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            If Nz(varCHECK) = "1" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g Nz() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
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
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim strWKRPTCLTID As String
		Dim strWKSRANO As String
		
		P_SRANOCheckWK = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		
		'SQL���쐬
		strSQL = vbNullString
        strSQL = strSQL & " SELECT  * "
        '2019/10/01 CHG START
        'strSQL = strSQL & " FROM    SRAET52"
        strSQL = strSQL & " FROM    CNT_USR9.SRAET52"
        '2019/10/01 CHG END
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
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
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
    Private Sub SetEdit(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
        Dim PositionCenterLeft As Object
        Dim TypeEditCharSetAlphanumeric As Object
        Dim CellTypeEdit As Object
        With vaData
            '2019/09/23 DEL START
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
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.CellType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g CellTypeEdit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.CellType = CellTypeEdit '��������
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeEditCharSet �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g TypeEditCharSetAlphanumeric �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.TypeEditCharSet = TypeEditCharSetAlphanumeric '���p�p����
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridSolid �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridSolid = True
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.GridColor �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.GridColor = &H0
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.Position �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ''UPGRADE_WARNING: �I�u�W�F�N�g PositionCenterLeft �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.Position = PositionCenterLeft
            ''���͌������Z�b�g
            'Select Case lngCol
            '    Case LC_lngCol_SERIAL
            '        'UPGRADE_WARNING: �I�u�W�F�N�g vaData.TypeMaxEditLen �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '        .TypeMaxEditLen = C_lngSERIAL_Len
            'End Select
            ''UPGRADE_WARNING: �I�u�W�F�N�g vaData.ReDraw �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '.ReDraw = True
            '2019/09/23 DEL END
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
    Private Function P_GET_PUDLNO(ByVal strJdnNo As String, ByRef strPUDLNO As String) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_LC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_LC As U_Ody
		Dim wkJDNNO As String
		Dim wkLINNO As String
		
		P_GET_PUDLNO = False
		strPUDLNO = ""
		
		wkJDNNO = VB.Left(strJdnNo, 6)
		wkLINNO = VB.Right(strJdnNo, 3)
		
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
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPUDLNO = CF_Ora_GetDyn(Usr_Ody_LC, "PUDLNO", "")
			P_GET_PUDLNO = True
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "�f�[�^�擾���ɃG���[���������܂����B(P_GET_PUDLNO)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function

    ''2008/08/06 ADD E.N.D FKS)NAKATA

    '2019/09/23 ADD START
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

    'Public Sub SetBar(ByRef pForm As Form)
    '    Try
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = My.Application.Info.AssemblyName
    '    Catch ex As Exception
    '        MsgBox("�����ް,�ð���ް�ݒ�֐��G���[" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "�G���[")
    '    End Try

    'End Sub

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

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click

        '2019/10/01 ADD START

        Dim msgMsgBox As MsgBoxResult
        Dim lngRow As Integer
        'UPGRADE_ISSUE: TYPE_DB_SYSTBH �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        Dim Mst_Inf As TYPE_DB_SYSTBH
        Dim intRet As Short
        Dim strMSGKBN As String
        Dim strMSGNM As String
        Dim lngChkRow As Integer
        Dim blnInsFlg As Boolean

        strMSGKBN = "1"
        lngChkRow = 0
        blnInsFlg = False

        '* �Z���w�i�F������
        With vaData
            '2019/10/01 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, False)
            '2019/10/01 CHG END
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
            If lngRow <> CInt(Me.lblURISU.Text) Then
                'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
                If intRet <> 0 Then
                    Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                    Exit Sub
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call GP_MsgBox(COMMON.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                Exit Sub
            End If

            '�V���A�����`�F�b�N
            With vaData
                'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                '2019/09/23 CHG START
                'For lngChkRow = 1 To .MaxRows
                For lngChkRow = 0 To .RowCount - 1
                    '2019/09/23 CHG END
                    If P_EntryCheckSerial(lngChkRow) = False Then
                        strMSGKBN = "1"
                        'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
                        If intRet <> 0 Then
                            Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                            Exit Sub
                        End If
                        'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
                        If msgMsgBox <> MsgBoxResult.Yes Then
                            If lngChkRow > 0 Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
                            Else
                                '2019/10/01 CHG START
                                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                                'Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 0)
                                '2019/10/01 CHG END
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
            'UPGRADE_WARNING: CM_Execute_Click �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
            If intRet <> 0 Then
                Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                Exit Sub
            End If
            'UPGRADE_WARNING: �I�u�W�F�N�g Mst_Inf.MSGCM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
            If msgMsgBox <> MsgBoxResult.Yes Then
                '2019/10/01 CHG START
                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                'Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 0)
                '2019/10/01 CHG END
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

        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '�o�^����
        If P_Main() = True Then
            '* �f�[�^�o�^��͉�ʂ����
            '2019/10/01 CHG START
            'Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
            btnF12.PerformClick()
            '2019/10/01 CHG END
            Exit Sub
        End If

EndLabel:
        '* �Z���w�i�F��ݒ�
        '2019/10/01 CHG START
        'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
        '2019/10/01 CHG END
        'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '2019/10/01 ADD END

    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        '2019/10/01 ADD START
        '* �Z���w�i�F������
        With vaData
            'UPGRADE_WARNING: �I�u�W�F�N�g vaData.MaxRows �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/09/23 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 0, False, LC_lngCol_NO, .RowCount - 1)
            '2019/09/23 CHG END
        End With
        Me.Close()
        '2019/10/01 ADD END
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call FR_SSSMAIN_Load(Me, New System.EventArgs())
    End Sub

    '2019/09/23 ADD END
End Class