Option Strict Off
Option Explicit On
Module BMNMTA_M51
	'
	' �X���b�g��        : ����}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : BMNMTA.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/29
	' �g�p�v���O������  : BMNMT51
	'
	
	' === 20080929 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_BMNMT
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
	Public M_BMNMT_inf As M_TYPE_BMNMT
	Public M_BMNMT_A_inf() As M_TYPE_BMNMT
	' === 20080929 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080929 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080929 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/13 add-end T.KAWAMUKAI
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
		
		'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BMNMTA.STTTKDT = RD_SSSMAIN_STTTKDT(I)
			'2007/12/18 add-str M.SUEZAWA
			'''        Call DB_GetEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCD & DB_BMNMTA.STTTKDT, BtrLock)
			Call DB_GetEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCD & DB_BMNMTA.STTTKDT, BtrNormal)
			'2007/12/18 add-end M.SUEZAWA
			If DBSTAT = 0 Then
				' === 20080929 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
				strOPEID = DB_BMNMTA.OPEID '�ŏI��Ǝ҃R�[�h
				strCLTID = DB_BMNMTA.CLTID '�N���C�A���g�h�c
				strUOPEID = DB_BMNMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strUCLTID = DB_BMNMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
				' === 20080929 === INSERT E - RISE)Izumi
				strWRTDT = DB_BMNMTA.WRTDT '�X�V���t
				strWRTTM = DB_BMNMTA.WRTTM '�X�V����
				strUWRTDT = DB_BMNMTA.UWRTDT '�o�b�`�X�V���t
				strUWRTTM = DB_BMNMTA.UWRTTM '�o�b�`�X�V����
				
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080929 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BMNMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BMNMTA"
					' === 20080929 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " WHERE BMNCD = '" + RD_SSSMAIN_BMNCD(I) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & "  AND STTTKDT = '" + RD_SSSMAIN_STTTKDT(I) + "'"
					'���b�N����
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_BMNMTA, strSQL)
					'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
					
					'�X�V���ԃ`�F�b�N
					' === 20080929 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = BMNMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20080929 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						' === 20080929 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BMNMTA)
						Call DB_AbortTransaction()
						' === 20080929 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBMNMT51_E_DEL)
						'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
						' === 20080929 === DELETE S - RISE)Izumi
						'                    Call DB_Unlock(DBN_BMNMTA)
						'                    Call DB_AbortTransaction
						' === 20080929 === DELETE E - RISE)Izumi
						HaitaUpdFlg = 1
						'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
						Exit Sub
					End If
					
				Else
					If updkb = "�ǉ�" Then
						' === 20080929 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BMNMTA)
						Call DB_AbortTransaction()
						' === 20080929 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBMNMT51_E_UPD)
						'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
						' === 20080929 === DELETE S - RISE)Izumi
						'                   Call DB_Unlock(DBN_BMNMTA)
						'                   Call DB_AbortTransaction
						' === 20080929 === DELETE E - RISE)Izumi
						Exit Sub
						'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNPRN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNPRNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_EIGYOC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_EIGYOCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMBMNC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMBMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMJGYC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMJGYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNCDU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCDUP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ENDTKD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_ENDTKDT(I)) <> Trim(RD_SSSMAIN_V_ENDTKD(I)) Or Trim(RD_SSSMAIN_BMNNM(I)) <> Trim(RD_SSSMAIN_V_BMNNM(I)) Or Trim(RD_SSSMAIN_BMNZP(I)) <> Trim(RD_SSSMAIN_V_BMNZP(I)) Or Trim(RD_SSSMAIN_BMNADA(I)) <> Trim(RD_SSSMAIN_V_BMNADA(I)) Or Trim(RD_SSSMAIN_BMNADB(I)) <> Trim(RD_SSSMAIN_V_BMNADB(I)) Or Trim(RD_SSSMAIN_BMNADC(I)) <> Trim(RD_SSSMAIN_V_BMNADC(I)) Or Trim(RD_SSSMAIN_BMNTL(I)) <> Trim(RD_SSSMAIN_V_BMNTL(I)) Or Trim(RD_SSSMAIN_BMNFX(I)) <> Trim(RD_SSSMAIN_V_BMNFX(I)) Or Trim(RD_SSSMAIN_BMNURL(I)) <> Trim(RD_SSSMAIN_V_BMNURL(I)) Or Trim(RD_SSSMAIN_BMNCDUP(I)) <> Trim(RD_SSSMAIN_V_BMNCDU(I)) Or Trim(RD_SSSMAIN_ZMJGYCD(I)) <> Trim(RD_SSSMAIN_V_ZMJGYC(I)) Or Trim(RD_SSSMAIN_ZMCD(I)) <> Trim(RD_SSSMAIN_V_ZMCD(I)) Or Trim(RD_SSSMAIN_ZMBMNCD(I)) <> Trim(RD_SSSMAIN_V_ZMBMNC(I)) Or Trim(RD_SSSMAIN_EIGYOCD(I)) <> Trim(RD_SSSMAIN_V_EIGYOC(I)) Or Trim(RD_SSSMAIN_TIKKB(I)) <> Trim(RD_SSSMAIN_V_TIKKB(I)) Or Trim(RD_SSSMAIN_HTANCD(I)) <> Trim(RD_SSSMAIN_V_HTANCD(I)) Or Trim(RD_SSSMAIN_STANCD(I)) <> Trim(RD_SSSMAIN_V_STANCD(I)) Or Trim(RD_SSSMAIN_BMNPRNM(I)) <> Trim(RD_SSSMAIN_V_BMNPRN(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080929 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BMNMTA"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BMNMTA"
							' === 20080929 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " WHERE BMNCD = '" + RD_SSSMAIN_BMNCD(I) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & "  AND STTTKDT = '" + RD_SSSMAIN_STTTKDT(I) + "'"
							'���b�N����
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_BMNMTA, strSQL)
							'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
							'�X�V���ԃ`�F�b�N
							' === 20080929 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							bolRet = BMNMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							' === 20080929 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								' === 20080929 === INSERT S - RISE)Izumi
								Call DB_Unlock(DBN_BMNMTA)
								Call DB_AbortTransaction()
								' === 20080929 === INSERT E - RISE)Izumi
								intRet = MF_DspMsg(gc_strMsgBMNMT51_E_UPD)
								'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
								' === 20080929 === DELETE S - RISE)Izumi
								'                            Call DB_Unlock(DBN_BMNMTA)
								'                            Call DB_AbortTransaction
								' === 20080929 === DELETE E - RISE)Izumi
								HaitaUpdFlg = 1
								'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
								Exit Sub
							End If
						End If
					End If
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/13 add-end T.KAWAMUKAI
		
		I = 0
		'2008/07/07 START DEL FNAP)YAMANE �A���[���F�r��-53
		'��̃`�F�b�N���[�v�̊J�n���_�Ő錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/07 E.N.D DEL FNAP)YAMANE �A���[���F�r��-53
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BMNMTA.STTTKDT = RD_SSSMAIN_STTTKDT(I)
			Call DB_GetEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCD & DB_BMNMTA.STTTKDT, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					DB_BMNMTA.DATKB = "9"
					DB_BMNMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
					DB_BMNMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
					DB_BMNMTA.UOPEID = SSS_OPEID.Value
					DB_BMNMTA.UCLTID = SSS_CLTID.Value
					DB_BMNMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
					DB_BMNMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
					DB_BMNMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_BMNMTA, 1)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNPRN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNPRNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_EIGYOC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_EIGYOCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMBMNC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMBMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ZMJGYC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMJGYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNCDU() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCDUP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ENDTKD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_ENDTKDT(I)) <> Trim(RD_SSSMAIN_V_ENDTKD(I)) Or Trim(RD_SSSMAIN_BMNNM(I)) <> Trim(RD_SSSMAIN_V_BMNNM(I)) Or Trim(RD_SSSMAIN_BMNZP(I)) <> Trim(RD_SSSMAIN_V_BMNZP(I)) Or Trim(RD_SSSMAIN_BMNADA(I)) <> Trim(RD_SSSMAIN_V_BMNADA(I)) Or Trim(RD_SSSMAIN_BMNADB(I)) <> Trim(RD_SSSMAIN_V_BMNADB(I)) Or Trim(RD_SSSMAIN_BMNADC(I)) <> Trim(RD_SSSMAIN_V_BMNADC(I)) Or Trim(RD_SSSMAIN_BMNTL(I)) <> Trim(RD_SSSMAIN_V_BMNTL(I)) Or Trim(RD_SSSMAIN_BMNFX(I)) <> Trim(RD_SSSMAIN_V_BMNFX(I)) Or Trim(RD_SSSMAIN_BMNURL(I)) <> Trim(RD_SSSMAIN_V_BMNURL(I)) Or Trim(RD_SSSMAIN_BMNCDUP(I)) <> Trim(RD_SSSMAIN_V_BMNCDU(I)) Or Trim(RD_SSSMAIN_ZMJGYCD(I)) <> Trim(RD_SSSMAIN_V_ZMJGYC(I)) Or Trim(RD_SSSMAIN_ZMCD(I)) <> Trim(RD_SSSMAIN_V_ZMCD(I)) Or Trim(RD_SSSMAIN_ZMBMNCD(I)) <> Trim(RD_SSSMAIN_V_ZMBMNC(I)) Or Trim(RD_SSSMAIN_EIGYOCD(I)) <> Trim(RD_SSSMAIN_V_EIGYOC(I)) Or Trim(RD_SSSMAIN_TIKKB(I)) <> Trim(RD_SSSMAIN_V_TIKKB(I)) Or Trim(RD_SSSMAIN_HTANCD(I)) <> Trim(RD_SSSMAIN_V_HTANCD(I)) Or Trim(RD_SSSMAIN_STANCD(I)) <> Trim(RD_SSSMAIN_V_STANCD(I)) Or Trim(RD_SSSMAIN_BMNPRNM(I)) <> Trim(RD_SSSMAIN_V_BMNPRN(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_BMNMTA.DATKB = "1"
						DB_BMNMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
						DB_BMNMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
						DB_BMNMTA.UOPEID = SSS_OPEID.Value
						DB_BMNMTA.UCLTID = SSS_CLTID.Value
						DB_BMNMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
						DB_BMNMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
						DB_BMNMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_BMNMTA, 1)
					End If '2006.11.07
				End If
			Else
				Call BMNMTA_RClear()
				Call Mfil_FromSCR(I)
				DB_BMNMTA.DATKB = "1"
				DB_BMNMTA.WRTFSTTM = wkWRTTM ' Format$(Now, "hhnnss")
				DB_BMNMTA.WRTFSTDT = wkWRTDT ' Format$(Now, "YYYYMMDD")
				DB_BMNMTA.FOPEID = SSS_OPEID.Value
				DB_BMNMTA.FCLTID = SSS_CLTID.Value
				DB_BMNMTA.WRTFSTTM = wkWRTTM ' Format(Now, "hhmmss")
				DB_BMNMTA.WRTFSTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
				DB_BMNMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
				DB_BMNMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
				DB_BMNMTA.UOPEID = SSS_OPEID.Value
				DB_BMNMTA.UCLTID = SSS_CLTID.Value
				DB_BMNMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
				DB_BMNMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
				DB_BMNMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_BMNMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_BMNMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080929 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BMNMT51_MF_Chk_UWRTDTTM_T
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
	Public Function BMNMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BMNMT51_MF_Chk_UWRTDTTM_T_err
		
		BMNMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_BMNMT_A_inf(pin_intIDX).OPEID) & Trim(M_BMNMT_A_inf(pin_intIDX).CLTID) & Trim(M_BMNMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BMNMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BMNMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BMNMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BMNMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BMNMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_BMNMT_A_inf(pin_intIDX).OPEID) & Trim(M_BMNMT_A_inf(pin_intIDX).CLTID) & Trim(M_BMNMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BMNMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BMNMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BMNMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BMNMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BMNMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo BMNMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		BMNMT51_MF_Chk_UWRTDTTM_T = True
		
BMNMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
BMNMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo BMNMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080929 === INSERT E - RISE)Izumi
	
	' === 20080929 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BMNMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BMNMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo BMNMT51_MF_UpDown_UWRTDTTM_err
		
		BMNMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_BMNMT_A_inf(pin_intIDX).OPEID = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_BMNMT_A_inf(pin_intIDX).CLTID = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_BMNMT_A_inf(pin_intIDX).UOPEID = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_BMNMT_A_inf(pin_intIDX).UCLTID = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_BMNMT_A_inf(pin_intIDX).WRTDT = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_BMNMT_A_inf(pin_intIDX).WRTTM = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_BMNMT_A_inf(pin_intIDX).UWRTDT = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_BMNMT_A_inf(pin_intIDX).UWRTTM = M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_BMNMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		BMNMT51_MF_UpDown_UWRTDTTM = True
		
BMNMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
BMNMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo BMNMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080929 === INSERT E - RISE)Izumi
	
	' === 20080929 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BMNMT51_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BMNMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo BMNMT51_MF_SaveRestore_UWRTDTTM_err
		
		BMNMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_BMNMT_inf.OPEID = M_BMNMT_A_inf(pin_intIDX).OPEID
			M_BMNMT_inf.CLTID = M_BMNMT_A_inf(pin_intIDX).CLTID
			M_BMNMT_inf.UOPEID = M_BMNMT_A_inf(pin_intIDX).UOPEID
			M_BMNMT_inf.UCLTID = M_BMNMT_A_inf(pin_intIDX).UCLTID
			M_BMNMT_inf.WRTDT = M_BMNMT_A_inf(pin_intIDX).WRTDT
			M_BMNMT_inf.WRTTM = M_BMNMT_A_inf(pin_intIDX).WRTTM
			M_BMNMT_inf.UWRTDT = M_BMNMT_A_inf(pin_intIDX).UWRTDT
			M_BMNMT_inf.UWRTTM = M_BMNMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_BMNMT_A_inf(pin_intIDX).OPEID = M_BMNMT_inf.OPEID
			M_BMNMT_A_inf(pin_intIDX).CLTID = M_BMNMT_inf.CLTID
			M_BMNMT_A_inf(pin_intIDX).UOPEID = M_BMNMT_inf.UOPEID
			M_BMNMT_A_inf(pin_intIDX).UCLTID = M_BMNMT_inf.UCLTID
			M_BMNMT_A_inf(pin_intIDX).WRTDT = M_BMNMT_inf.WRTDT
			M_BMNMT_A_inf(pin_intIDX).WRTTM = M_BMNMT_inf.WRTTM
			M_BMNMT_A_inf(pin_intIDX).UWRTDT = M_BMNMT_inf.UWRTDT
			M_BMNMT_A_inf(pin_intIDX).UWRTTM = M_BMNMT_inf.UWRTTM
		End If
		
		BMNMT51_MF_SaveRestore_UWRTDTTM = True
		
BMNMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
BMNMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo BMNMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080929 === INSERT E - RISE)Izumi
	
	' === 20080929 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BMNMT51_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BMNMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BMNMT51_MF_Clear_UWRTDTTM_err
		
		BMNMT51_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_BMNMT_A_inf(pin_intIDX).OPEID = ""
		M_BMNMT_A_inf(pin_intIDX).CLTID = ""
		M_BMNMT_A_inf(pin_intIDX).UOPEID = ""
		M_BMNMT_A_inf(pin_intIDX).UCLTID = ""
		M_BMNMT_A_inf(pin_intIDX).WRTDT = ""
		M_BMNMT_A_inf(pin_intIDX).WRTTM = ""
		M_BMNMT_A_inf(pin_intIDX).UWRTDT = ""
		M_BMNMT_A_inf(pin_intIDX).UWRTTM = ""
		
		BMNMT51_MF_Clear_UWRTDTTM = True
		
BMNMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
BMNMT51_MF_Clear_UWRTDTTM_err: 
		GoTo BMNMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080929 === INSERT E - RISE)Izumi
End Module