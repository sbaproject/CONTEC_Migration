Option Strict Off
Option Explicit On
Module SOUMTA_M51
	'
	' �X���b�g��        : ���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : SOUMTA.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/09
	' �g�p�v���O������  : SOUMT51
	'
	
	' === 20080901 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_SOUMT
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char '�N���C�A���g�h�c�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
	End Structure
	Public M_SOUMT_inf As M_TYPE_SOUMT
	Public M_SOUMT_A_inf() As M_TYPE_SOUMT
	' === 20080901 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim updkb As String
		Dim WRTTM, WRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080829 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/14 add-end T.KAWAMUKAI
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
        Dim strSQL As String
        '20190819 CHG START
        '      Do While I < PP_SSSMAIN.LastDe
        '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(I)
        '	Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA.SOUCD, BtrNormal)
        '	If DBSTAT = 0 Then
        '		' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
        '		strOPEID = DB_SOUMTA.OPEID '�ŏI��Ǝ҃R�[�h
        '		strCLTID = DB_SOUMTA.CLTID '�N���C�A���g�h�c
        '		strUOPEID = DB_SOUMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        '		strUCLTID = DB_SOUMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
        '		' === 20080829 === INSERT E - RISE)Izumi
        '		strWRTDT = DB_SOUMTA.WRTDT '�X�V���t
        '		strWRTTM = DB_SOUMTA.WRTTM '�X�V����
        '		strUWRTDT = DB_SOUMTA.UWRTDT '�o�b�`�X�V���t
        '		strUWRTTM = DB_SOUMTA.UWRTTM '�o�b�`�X�V����

        '		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		updkb = RD_SSSMAIN_UPDKB(I)
        '		If updkb = "�폜" Then

        '			'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
        '			HaitaUpdFlg = 0
        '			strSQL = ""
        '			' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
        '			'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '			strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
        '			' === 20080829 === UPDATE E - RISE)Izumi
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '			'���b�N����
        '			strSQL = strSQL & "          FOR UPDATE"
        '			Call DB_GetSQL2(DBN_SOUMTA, strSQL)
        '			' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
        '			strOPEID = DB_SOUMTA.OPEID '�ŏI��Ǝ҃R�[�h
        '			strCLTID = DB_SOUMTA.CLTID '�N���C�A���g�h�c
        '			strUOPEID = DB_SOUMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        '			strUCLTID = DB_SOUMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
        '			' === 20080829 === INSERT E - RISE)Izumi
        '			strWRTDT = DB_SOUMTA.WRTDT '�X�V���t
        '			strWRTTM = DB_SOUMTA.WRTTM '�X�V����
        '                  strUWRTDT = DB_SOUMTA.UWRTDT '�o�b�`�X�V���t
        '                  strUWRTTM = DB_SOUMTA.UWRTTM '�o�b�`�X�V����
        '			'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63

        '			'�X�V���ԃ`�F�b�N
        '			' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
        '			'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '			bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '			' === 20080829 === UPDATE E - RISE)Izumi
        '			If bolRet = False Then
        '				intRet = MF_DspMsg(gc_strMsgSOUMT51_E_DEL)
        '				'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
        '				Call DB_Unlock(DBN_SOUMTA)
        '				Call DB_AbortTransaction()
        '				HaitaUpdFlg = 1
        '				'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
        '				Exit Sub
        '			End If

        '		Else
        '			'2007/12/18 upd-str T.KAWAMUKAI
        '			If updkb = "�ǉ�" Then
        '				intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
        '				'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
        '				Call DB_Unlock(DBN_SOUMTA)
        '				Call DB_AbortTransaction()
        '				'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
        '				'2007/12/21 add-str T.KAWAMUKAI
        '				Exit Sub
        '				'2007/12/21 add-end T.KAWAMUKAI
        '			Else
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SALPAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SALPALKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKOK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKOKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTRI() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SRSCNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRSCNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUBSC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUBSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '				If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then

        '					'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
        '					HaitaUpdFlg = 0
        '					strSQL = ""
        '					' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
        '					'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
        '					' === 20080829 === UPDATE E - RISE)Izumi                       strSQL = strSQL + " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '					strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '					strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '					'���b�N����
        '					strSQL = strSQL & "          FOR UPDATE"
        '					Call DB_GetSQL2(DBN_SOUMTA, strSQL)
        '					' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
        '					strOPEID = DB_SOUMTA.OPEID '�ŏI��Ǝ҃R�[�h
        '					strCLTID = DB_SOUMTA.CLTID '�N���C�A���g�h�c
        '					strUOPEID = DB_SOUMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        '					strUCLTID = DB_SOUMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
        '					' === 20080829 === INSERT E - RISE)Izumi
        '					strWRTDT = DB_SOUMTA.WRTDT '�X�V���t
        '					strWRTTM = DB_SOUMTA.WRTTM '�X�V����
        '					strUWRTDT = DB_SOUMTA.UWRTDT '�o�b�`�X�V���t
        '					strUWRTTM = DB_SOUMTA.UWRTTM '�o�b�`�X�V����
        '					'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63

        '					'�X�V���ԃ`�F�b�N
        '					' === 20080901 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
        '					'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '					bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '					' === 20080901 === UPDATE E - RISE)Izumi
        '					If bolRet = False Then
        '						intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
        '						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
        '						Call DB_Unlock(DBN_SOUMTA)
        '						Call DB_AbortTransaction()
        '						HaitaUpdFlg = 1
        '						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
        '						Exit Sub
        '					End If
        '				End If
        '			End If
        '			'2007/12/18 upd-end T.KAWAMUKAI
        '		End If
        '	End If
        '	I = I + 1
        'Loop 
        Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            DB_SOUMTA2.SOUCD = RD_SSSMAIN_SOUCD(I)
            Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA2.SOUCD, BtrNormal)
            If DBSTAT = 0 Then
                ' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                strOPEID = DB_SOUMTA2.OPEID '�ŏI��Ǝ҃R�[�h
                strCLTID = DB_SOUMTA2.CLTID '�N���C�A���g�h�c
                strUOPEID = DB_SOUMTA2.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                strUCLTID = DB_SOUMTA2.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                ' === 20080829 === INSERT E - RISE)Izumi
                strWRTDT = DB_SOUMTA2.WRTDT '�X�V���t
                strWRTTM = DB_SOUMTA2.WRTTM '�X�V����
                strUWRTDT = DB_SOUMTA2.UWRTDT '�o�b�`�X�V���t
                strUWRTTM = DB_SOUMTA2.UWRTTM '�o�b�`�X�V����

                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "�폜" Then

                    '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
                    HaitaUpdFlg = 0
                    strSQL = ""
                    ' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                    '                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                    strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
                    ' === 20080829 === UPDATE E - RISE)Izumi
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                    '���b�N����
                    strSQL = strSQL & "          FOR UPDATE"
                    Call DB_GetSQL2(DBN_SOUMTA, strSQL)
                    ' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                    strOPEID = DB_SOUMTA2.OPEID '�ŏI��Ǝ҃R�[�h
                    strCLTID = DB_SOUMTA2.CLTID '�N���C�A���g�h�c
                    strUOPEID = DB_SOUMTA2.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                    strUCLTID = DB_SOUMTA2.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                    ' === 20080829 === INSERT E - RISE)Izumi
                    strWRTDT = DB_SOUMTA2.WRTDT '�X�V���t
                    strWRTTM = DB_SOUMTA2.WRTTM '�X�V����
                    strUWRTDT = DB_SOUMTA2.UWRTDT '�o�b�`�X�V���t
                    strUWRTTM = DB_SOUMTA2.UWRTTM '�o�b�`�X�V����
                    '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63

                    '�X�V���ԃ`�F�b�N
                    ' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                    '                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    ' === 20080829 === UPDATE E - RISE)Izumi
                    If bolRet = False Then
                        intRet = MF_DspMsg(gc_strMsgSOUMT51_E_DEL)
                        '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
                        Call DB_Unlock(DBN_SOUMTA)
                        Call DB_AbortTransaction()
                        HaitaUpdFlg = 1
                        '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
                        Exit Sub
                    End If

                Else
                    '2007/12/18 upd-str T.KAWAMUKAI
                    If updkb = "�ǉ�" Then
                        intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
                        '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
                        Call DB_Unlock(DBN_SOUMTA)
                        Call DB_AbortTransaction()
                        '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
                        '2007/12/21 add-str T.KAWAMUKAI
                        Exit Sub
                        '2007/12/21 add-end T.KAWAMUKAI
                    Else
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SALPAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SALPALKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKOK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKOKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTRI() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SRSCNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRSCNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUBSC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUBSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then

                            '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
                            HaitaUpdFlg = 0
                            strSQL = ""
                            ' === 20080829 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                            '                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                            strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
                            ' === 20080829 === UPDATE E - RISE)Izumi                       strSQL = strSQL + " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                            strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                            '���b�N����
                            strSQL = strSQL & "          FOR UPDATE"
                            Call DB_GetSQL2(DBN_SOUMTA, strSQL)
                            ' === 20080829 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                            strOPEID = DB_SOUMTA2.OPEID '�ŏI��Ǝ҃R�[�h
                            strCLTID = DB_SOUMTA2.CLTID '�N���C�A���g�h�c
                            strUOPEID = DB_SOUMTA2.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                            strUCLTID = DB_SOUMTA2.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                            ' === 20080829 === INSERT E - RISE)Izumi
                            strWRTDT = DB_SOUMTA2.WRTDT '�X�V���t
                            strWRTTM = DB_SOUMTA2.WRTTM '�X�V����
                            strUWRTDT = DB_SOUMTA2.UWRTDT '�o�b�`�X�V���t
                            strUWRTTM = DB_SOUMTA2.UWRTTM '�o�b�`�X�V����
                            '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63

                            '�X�V���ԃ`�F�b�N
                            ' === 20080901 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                            '                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            ' === 20080901 === UPDATE E - RISE)Izumi
                            If bolRet = False Then
                                intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
                                '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-63
                                Call DB_Unlock(DBN_SOUMTA)
                                Call DB_AbortTransaction()
                                HaitaUpdFlg = 1
                                '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-63
                                Exit Sub
                            End If
                        End If
                    End If
                    '2007/12/18 upd-end T.KAWAMUKAI
                End If
            End If
            I = I + 1
        Loop
        '20190819 CHG END
        '2007/12/14 add-end T.KAWAMUKAI

        '
        I = 0
		WRTTM = VB6.Format(Now, "hhmmss")
		WRTDT = VB6.Format(Now, "YYYYMMDD")

        '2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-63
        '�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
        '    Call DB_BeginTransaction(BTR_Exclude)
        '2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-63
        '20190819 CHG START
        '      Do While I < PP_SSSMAIN.LastDe
        '	'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '	DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(I)
        '	Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA.SOUCD, BtrLock)
        '	If DBSTAT = 0 Then
        '		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '		updkb = RD_SSSMAIN_UPDKB(I)
        '		If updkb = "�폜" Then
        '			DB_SOUMTA.DATKB = "9"
        '			DB_SOUMTA.RELFL = "1"
        '			DB_SOUMTA.OPEID = SSS_OPEID.Value
        '			DB_SOUMTA.CLTID = SSS_CLTID.Value
        '			DB_SOUMTA.WRTTM = WRTTM
        '			DB_SOUMTA.WRTDT = WRTDT
        '                  DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '                  DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '			DB_SOUMTA.UWRTTM = WRTTM
        '			DB_SOUMTA.UWRTDT = WRTDT
        '			DB_SOUMTA.PGID = SSS_PrgId
        '			Call DB_Update(DBN_SOUMTA, 1)
        '		Else
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SALPAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SALPALKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKOK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKOKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTRI() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SRSCNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRSCNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUBSC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUBSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '			If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
        '				Call Mfil_FromSCR(I)
        '				DB_SOUMTA.DATKB = "1"
        '				DB_SOUMTA.RELFL = "1"
        '				DB_SOUMTA.WRTTM = WRTTM
        '				DB_SOUMTA.WRTDT = WRTDT
        '				DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '				DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '				DB_SOUMTA.UWRTTM = WRTTM
        '				DB_SOUMTA.UWRTDT = WRTDT
        '				DB_SOUMTA.PGID = SSS_PrgId
        '				Call DB_Update(DBN_SOUMTA, 1)
        '			End If '2006.11.07
        '		End If
        '	Else
        '		Call SOUMTA_RClear()
        '		Call Mfil_FromSCR(I)
        '		DB_SOUMTA.DATKB = "1"
        '		DB_SOUMTA.RELFL = "1"
        '		DB_SOUMTA.FOPEID = SSS_OPEID.Value
        '		DB_SOUMTA.FCLTID = SSS_CLTID.Value
        '		DB_SOUMTA.WRTFSTTM = WRTTM
        '		DB_SOUMTA.WRTFSTDT = WRTDT
        '		DB_SOUMTA.WRTTM = WRTTM
        '		DB_SOUMTA.WRTDT = WRTDT
        '		DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '		DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '		DB_SOUMTA.UWRTTM = WRTTM
        '		DB_SOUMTA.UWRTDT = WRTDT
        '		DB_SOUMTA.PGID = SSS_PrgId
        '		Call DB_Insert(DBN_SOUMTA, 1)
        '	End If
        '	I = I + 1
        'Loop 
        Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            DB_SOUMTA2.SOUCD = RD_SSSMAIN_SOUCD(I)
            Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA2.SOUCD, BtrLock)
            If DBSTAT = 0 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "�폜" Then
                    DB_SOUMTA2.DATKB = "9"
                    DB_SOUMTA2.RELFL = "1"
                    DB_SOUMTA2.OPEID = SSS_OPEID.Value
                    DB_SOUMTA2.CLTID = SSS_CLTID.Value
                    DB_SOUMTA2.WRTTM = WRTTM
                    DB_SOUMTA2.WRTDT = WRTDT
                    DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                    DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                    DB_SOUMTA2.UWRTTM = WRTTM
                    DB_SOUMTA2.UWRTDT = WRTDT
                    DB_SOUMTA2.PGID = SSS_PrgId
                    Call DB_Update(DBN_SOUMTA, 1)
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SALPAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SALPALKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKOK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKOKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTRI() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SRSCNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRSCNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUBSC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUBSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
                        Call Mfil_FromSCR(I)
                        DB_SOUMTA2.DATKB = "1"
                        DB_SOUMTA2.RELFL = "1"
                        DB_SOUMTA2.WRTTM = WRTTM
                        DB_SOUMTA2.WRTDT = WRTDT
                        DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                        DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                        DB_SOUMTA2.UWRTTM = WRTTM
                        DB_SOUMTA2.UWRTDT = WRTDT
                        DB_SOUMTA2.PGID = SSS_PrgId
                        Call DB_Update(DBN_SOUMTA, 1)
                    End If '2006.11.07
                End If
            Else
                Call SOUMTA_RClear()
                Call Mfil_FromSCR(I)
                DB_SOUMTA2.DATKB = "1"
                DB_SOUMTA2.RELFL = "1"
                DB_SOUMTA2.FOPEID = SSS_OPEID.Value
                DB_SOUMTA2.FCLTID = SSS_CLTID.Value
                DB_SOUMTA2.WRTFSTTM = WRTTM
                DB_SOUMTA2.WRTFSTDT = WRTDT
                DB_SOUMTA2.WRTTM = WRTTM
                DB_SOUMTA2.WRTDT = WRTDT
                DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                DB_SOUMTA2.UWRTTM = WRTTM
                DB_SOUMTA2.UWRTDT = WRTDT
                DB_SOUMTA2.PGID = SSS_PrgId
                Call DB_Insert(DBN_SOUMTA, 1)
            End If
            I = I + 1
        Loop
        '20190819 CHG END
        Call DB_Unlock(DBN_SOUMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SOUMT51_MF_Chk_UWRTDTTM_T
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pin_strOPEID    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID    : �N���C�A���g�h�c
	'           pin_strUOPEID   : �ŏI��Ǝ҃R�[�h�i�o�b�`�j
	'           pin_strUCLTID   : �N���C�A���g�h�c�i�o�b�`�j
	'           pin_strWRTDT    : �X�V���t
	'           pin_strWRTTM    : �X�V����
	'           pin_strUWRTDT   : �o�b�`�X�V���t
	'           pin_strUWRTTM   : �o�b�`�X�V����
	'           pin_intIDX      : �����ׂ̏ꍇ�@�@�@�@���׍s�i0�`�j
	'   �@�@�@�@�@�@�@�@�@�@�@�@�@���Ӑ�l�o�^�̏ꍇ�@0�c���Ӑ� 1�c�d����
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F  �����׋y�сA���Ӑ�l�o�^�p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_Chk_UWRTDTTM_T_err
		
		SOUMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_SOUMT_A_inf(pin_intIDX).OPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).CLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).UOPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).UCLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTTM) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_SOUMT_A_inf(pin_intIDX).OPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).CLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).UOPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).UCLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTTM) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo SOUMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		SOUMT51_MF_Chk_UWRTDTTM_T = True
		
SOUMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
SOUMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo SOUMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SOUMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_UpDown_UWRTDTTM_err
		
		SOUMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_SOUMT_A_inf(pin_intIDX).OPEID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_SOUMT_A_inf(pin_intIDX).CLTID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_SOUMT_A_inf(pin_intIDX).UOPEID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_SOUMT_A_inf(pin_intIDX).UCLTID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_SOUMT_A_inf(pin_intIDX).WRTDT = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_SOUMT_A_inf(pin_intIDX).WRTTM = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_SOUMT_A_inf(pin_intIDX).UWRTDT = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_SOUMT_A_inf(pin_intIDX).UWRTTM = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		SOUMT51_MF_UpDown_UWRTDTTM = True
		
SOUMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo SOUMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SOUMT51_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_SaveRestore_UWRTDTTM_err
		
		SOUMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_SOUMT_inf.OPEID = M_SOUMT_A_inf(pin_intIDX).OPEID
			M_SOUMT_inf.CLTID = M_SOUMT_A_inf(pin_intIDX).CLTID
			M_SOUMT_inf.UOPEID = M_SOUMT_A_inf(pin_intIDX).UOPEID
			M_SOUMT_inf.UCLTID = M_SOUMT_A_inf(pin_intIDX).UCLTID
			M_SOUMT_inf.WRTDT = M_SOUMT_A_inf(pin_intIDX).WRTDT
			M_SOUMT_inf.WRTTM = M_SOUMT_A_inf(pin_intIDX).WRTTM
			M_SOUMT_inf.UWRTDT = M_SOUMT_A_inf(pin_intIDX).UWRTDT
			M_SOUMT_inf.UWRTTM = M_SOUMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_SOUMT_A_inf(pin_intIDX).OPEID = M_SOUMT_inf.OPEID
			M_SOUMT_A_inf(pin_intIDX).CLTID = M_SOUMT_inf.CLTID
			M_SOUMT_A_inf(pin_intIDX).UOPEID = M_SOUMT_inf.UOPEID
			M_SOUMT_A_inf(pin_intIDX).UCLTID = M_SOUMT_inf.UCLTID
			M_SOUMT_A_inf(pin_intIDX).WRTDT = M_SOUMT_inf.WRTDT
			M_SOUMT_A_inf(pin_intIDX).WRTTM = M_SOUMT_inf.WRTTM
			M_SOUMT_A_inf(pin_intIDX).UWRTDT = M_SOUMT_inf.UWRTDT
			M_SOUMT_A_inf(pin_intIDX).UWRTTM = M_SOUMT_inf.UWRTTM
		End If
		
		SOUMT51_MF_SaveRestore_UWRTDTTM = True
		
SOUMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo SOUMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function SOUMT51_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_Clear_UWRTDTTM_err
		
		SOUMT51_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_SOUMT_A_inf(pin_intIDX).OPEID = ""
		M_SOUMT_A_inf(pin_intIDX).CLTID = ""
		M_SOUMT_A_inf(pin_intIDX).UOPEID = ""
		M_SOUMT_A_inf(pin_intIDX).UCLTID = ""
		M_SOUMT_A_inf(pin_intIDX).WRTDT = ""
		M_SOUMT_A_inf(pin_intIDX).WRTTM = ""
		M_SOUMT_A_inf(pin_intIDX).UWRTDT = ""
		M_SOUMT_A_inf(pin_intIDX).UWRTTM = ""
		
		SOUMT51_MF_Clear_UWRTDTTM = True
		
SOUMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_Clear_UWRTDTTM_err: 
		GoTo SOUMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
End Module