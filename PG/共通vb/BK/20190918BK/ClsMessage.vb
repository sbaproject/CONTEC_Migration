Option Strict Off
Option Explicit On

Friend Class ClsMessage
	'//****************************************************************************************
	'//*
	'//*�����́�
	'//*    ClsMessage
	'//*
	'//*���o�[�W������
	'//*    1.00
	'//*���쐬�ҁ�
	'//*    RISE
	'//*��������
	'//*    ���b�Z�[�W�R�[�h�ɑ΂��郁�b�Z�[�W�̕\�����s�Ȃ�
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20040401|Rise)          |�V�K
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// �G���[���b�Z�[�W�p
	'//-----------------------------------------------------------------------------------------
	Private Const cst_�ُ� As String = "���s���G���[�ł��B�V�X�e���S���҂ɘA�����ĉ������B"
	Private Const cst_�ڍ� As String = vbCrLf & vbCrLf & "[ �ڍ� ]" & vbCrLf
	Private Const cst_�Q�l As String = vbCrLf & vbCrLf & "[ �Q�l ]" & vbCrLf
	
	'//*****************************************************************************************
	'// �萔�@�@��`
	'//*****************************************************************************************
	'���b�Z�[�W�o�^�l
	'�{�^�����
	Private Const gc_strBTNKB_OKOnly As Decimal = 0 'OK
	Private Const gc_strBTNKB_OKCancel As Decimal = 1 'OK/�L�����Z��
	Private Const gc_strBTNKB_AbortRetryIgnore As Decimal = 2 '���~/�Ď��s/����
	Private Const gc_strBTNKB_YesNoCancel As Decimal = 3 '�͂�/������/�L�����Z��
	Private Const gc_strBTNKB_YesNo As Decimal = 4 '�͂�/������
	Private Const gc_strBTNKB_RetryCancel As Decimal = 5 '�Ď��s/�L�����Z��
	
	'//*****************************************************************************************
	'// �\���̒�` SYSTBH.DBM   �V�X�e�����b�Z�[�W
	'//*****************************************************************************************
	Private Structure TYPE_DB_SYSTBH
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MSGKB() As Char '���b�Z�[�W���        0
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(15),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=15)> Public MSGNM() As Char '���b�Z�[�W�A�C�e��
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MSGSQ() As Char '���b�Z�[�W�A��        X(01)
		Dim BTNKB As Decimal '�{�^�����            000
		Dim BTNON As Decimal '�{�^�������l          000
		Dim ICNKB As Decimal '�A�C�R�����          00
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public MSGCM() As Char '���b�Z�[�W
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public COLSQ() As Char '�F�V�[�P���X          0
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c      !@@@@@
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
	End Structure
	
	'//*****************************************************************************************
	'// �׽�֐��@�@��`
	'//*****************************************************************************************
	Private D0 As ClsComn '//System �֐�
	
	'//*****************************************************************************************
	'// �ϐ�   �錾
	'//*****************************************************************************************
	'UPGRADE_ISSUE: OraDatabase �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '2019/04/26 DEL START
    'Private mv_OraDatabase As OraDatabase 'Oracle�f�[�^�x�[�X
    '2019/04/26 DEL E N D
    'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
    '2019/04/26 DEL START
    'Private mv_OraDynaset As OraDynaset 'Oracle�_�C�i�Z�b�g
    '2019/04/26 DEL E N D

    '2019/04/26 DEL START
    ''//****************************************************************************************
    ''//* <�v���p�e�B>
    ''//*     Msg_Conn
    ''//* <��  ��>
    ''//*    �R�l�N�V�����̎擾
    ''//****************************************************************************************
    'Public WriteOnly Property OraDatabase() As OraDatabase
    '	Set(ByVal Value As OraDatabase)
    '		mv_OraDatabase = Value
    '	End Set
    'End Property
    '2019/04/26 DEL E N D

	'//****************************************************************************************
	'//�C�j�V�����C�Y
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize �� Class_Initialize_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Initialize_Renamed()
		D0 = New ClsComn
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'//****************************************************************************************
	'//�^�[�~�l�C�g
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Terminate �� Class_Terminate_Renamed �ɃA�b�v�O���[�h����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' ���N���b�N���Ă��������B
	Private Sub Class_Terminate_Renamed()
		If Not (D0 Is Nothing) Then
			'UPGRADE_NOTE: �I�u�W�F�N�g D0 ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
			D0 = Nothing
		End If
        '2019/04/26 DEL START
        'If Not (mv_OraDynaset Is Nothing) Then
        '	'UPGRADE_NOTE: �I�u�W�F�N�g mv_OraDynaset ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '	mv_OraDynaset = Nothing
        'End If
        'If Not (mv_OraDatabase Is Nothing) Then
        '	'UPGRADE_NOTE: �I�u�W�F�N�g mv_OraDatabase ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
        '	mv_OraDatabase = Nothing
        'End If
        '2019/04/26 DEL E N D
    End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MsgLibrary
	'   �T�v�F  �W�����b�Z�[�W�\������
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		Dim vnt_MousePointer As Object
		
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		vnt_MousePointer = System.Windows.Forms.Cursor.Current
		D0.Mouse_OFF()
		
		MsgLibrary = False
		
		strMSGKBN = D0.Ctr_AnsiLeftB(Pin_strMsgCode, 1) '���b�Z�[�W���
		strMSGNM = D0.Ctr_AnsiMidB(Pin_strMsgCode, 2) '���b�Z�[�W�A�C�e��
		
		'���b�Z�[�W�}�X�^����
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
				System.Windows.Forms.Cursor.Current = vnt_MousePointer
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			''''        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "�����ӏ�   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function DSPMSGCM_SEARCH
	'   �T�v�F  �V�X�e�����b�Z�[�W����
	'   �����F  pin_strMSGKB    : ���b�Z�[�W���
	'           pin_strMSGNM    : ���b�Z�[�W�A�C�e��
	'           pin_strMSGSQ�@�@: ���b�Z�[�W�A��
	'           pot_DB_SYSTBH   : ��������
	'   �ߒl�F�@0:����I�� 1:�Ώۃf�[�^���� 9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short
		
		Dim strSQL As String
        '2019/04/26 DEL START
        'Dim intData As Short
        '2019/04/26 DEL E N D
        'UPGRADE_ISSUE: OraDynaset �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
        '2019/04/26 DEL START
        'Dim objRec As OraDynaset
        '2019/04/26 DEL E N D
        Dim vnt_MousePointer As Object
		
		Const PROCEDURE As String = "DSPMSGCM_SEARCH"
		
		On Error GoTo ERR_DSPMSGCM_SEARCH
		
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		vnt_MousePointer = System.Windows.Forms.Cursor.Current
		D0.Mouse_OFF()
		
		DSPMSGCM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBH "
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "  Where MSGKB     = " & D0.Edt_SQL("S", pin_strMSGKB, False)
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "    and MSGNM     = " & D0.Edt_SQL("S", pin_strMSGNM, True)
		'UPGRADE_WARNING: �I�u�W�F�N�g D0.Edt_SQL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "    and MSGSQ     = " & D0.Edt_SQL("S", pin_strMSGSQ, False)
		
		'UPGRADE_WARNING: DSPMSGCM_SEARCH �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

        '2019/04/12 ADD START
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 ADD E N D

		'UPGRADE_WARNING: DSPMSGCM_SEARCH �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B

        '2019/04/12 ADD START
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            With pot_DB_SYSTBH
                .MSGKB = D0.Chk_Null(dt.Rows(0)("MSGKB"))                    '���b�Z�[�W���
                .MSGNM = D0.Chk_Null(dt.Rows(0)("MSGNM"))                    '���b�Z�[�W�A�C�e��
                .MSGSQ = D0.Chk_Null(dt.Rows(0)("MSGSQ"))                    '���b�Z�[�W�A��
                .BTNKB = D0.Chk_Null(dt.Rows(0)("BTNKB"))                    '�{�^�����
                .BTNON = D0.Chk_Null(dt.Rows(0)("BTNON"))                    '�{�^�������l
                .ICNKB = D0.Chk_Null(dt.Rows(0)("ICNKB"))                    '�A�C�R�����
                .MSGCM = D0.Chk_Null(dt.Rows(0)("MSGCM"))                    '���b�Z�[�W
                .COLSQ = D0.Chk_Null(dt.Rows(0)("COLSQ"))                    '�F�V�[�P���X
                .OPEID = D0.Chk_Null(dt.Rows(0)("OPEID"))                    '�ŏI��Ǝ҃R�[�h
                .CLTID = D0.Chk_Null(dt.Rows(0)("CLTID"))                    '�N���C�A���g�h�c
                .WRTTM = D0.Chk_Null(dt.Rows(0)("WRTTM"))                    '��ѽ����(����)
                .WRTDT = D0.Chk_Null(dt.Rows(0)("WRTDT"))                    '��ѽ����(���t)
            End With
        Else
            '�擾�f�[�^�Ȃ�
            DSPMSGCM_SEARCH = 1
            System.Windows.Forms.Cursor.Current = vnt_MousePointer
            Exit Function
        End If
        '2019/04/12 ADD E N D

		'UPGRADE_WARNING: DSPMSGCM_SEARCH �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		
		'�N���[�Y
		'UPGRADE_WARNING: DSPMSGCM_SEARCH �ɕϊ�����Ă��Ȃ��X�e�[�g�����g������܂��B�\�[�X �R�[�h���m�F���Ă��������B
		
		DSPMSGCM_SEARCH = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
		Exit Function
		
ERR_DSPMSGCM_SEARCH: 
		
		'UPGRADE_WARNING: �I�u�W�F�N�g vnt_MousePointer �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_ISSUE: Screen �v���p�e�B Screen.MousePointer �̓J�X�^�� �}�E�X�|�C���^���T�|�[�g���܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Screen �v���p�e�B Screen.MousePointer �ɂ͐V�������삪�܂܂�܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' ���N���b�N���Ă��������B
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RuntimeErrorMsg
	'   �T�v�F  �W�����b�Z�[�W�\������
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RuntimeErrorMsg(ByVal strDescription As String, ByVal strProcedureNM As String, Optional ByVal strAddMessage As String = "") As Object
		
		Call MsgBox("<" & strProcedureNM & "> " & vbCrLf & cst_�ُ� & cst_�ڍ� & strDescription & IIf(strAddMessage = "", "", cst_�Q�l & strAddMessage), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		
	End Function
End Class