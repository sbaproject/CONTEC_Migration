Option Strict Off
Option Explicit On
Module TOKMTC_M51
	'
	' �X���b�g��        : �̔��P���}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : TOKMTC.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/20
	' �g�p�v���O������  : TOKMT54
	'
	
	' === 20080903 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_TOKMT
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
	Public M_TOKMT_inf As M_TYPE_TOKMT
	Public M_TOKMT_A_inf() As M_TYPE_TOKMT
	' === 20080903 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I, J As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080903 === INSERT S - RISE)Izumi
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080903 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/14 add-end T.KAWAMUKAI
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.URITKDT = RD_SSSMAIN_URITKDT(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(I)
			Call DB_GetEq(DBN_TOKMTC, 1, DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.URITKDT & DB_TOKMTC.TUKKB, BtrNormal)
			If DBSTAT = 0 Then
				' === 20080903 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
				strOPEID = DB_TOKMTC.OPEID '�ŏI��Ǝ҃R�[�h
				strCLTID = DB_TOKMTC.CLTID '�N���C�A���g�h�c
				strUOPEID = DB_TOKMTC.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strUCLTID = DB_TOKMTC.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
				' === 20080903 === INSERT E - RISE)Izumi
				strWRTDT = DB_TOKMTC.WRTDT '�X�V���t
				strWRTTM = DB_TOKMTC.WRTTM '�X�V����
				strUWRTDT = DB_TOKMTC.UWRTDT '�o�b�`�X�V���t
				strUWRTTM = DB_TOKMTC.UWRTTM '�o�b�`�X�V����
				
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					
					'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TOKMTC"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM TOKMTC"
					' === 20080903 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " WHERE HINCD = '" + RD_SSSMAIN_HINCD(I) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " AND TOKCD = '" + RD_SSSMAIN_TOKCD(I) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " AND URITKDT = '" + RD_SSSMAIN_URITKDT(I) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " AND TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
					'���b�N����
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_TOKMTC, strSQL)
					' === 20080903 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
					strOPEID = DB_TOKMTC.OPEID '�ŏI��Ǝ҃R�[�h
					strCLTID = DB_TOKMTC.CLTID '�N���C�A���g�h�c
					strUOPEID = DB_TOKMTC.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
					strUCLTID = DB_TOKMTC.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
					' === 20080903 === INSERT E - RISE)Izumi
					strWRTDT = DB_TOKMTC.WRTDT '�X�V���t
					strWRTTM = DB_TOKMTC.WRTTM '�X�V����
					strUWRTDT = DB_TOKMTC.UWRTDT '�o�b�`�X�V���t
					strUWRTTM = DB_TOKMTC.UWRTTM '�o�b�`�X�V����
					'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
					
					'�X�V���ԃ`�F�b�N
					' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                    bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = TOKMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20080903 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgTOKMT52_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
						Call DB_Unlock(DBN_TOKMTC)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						intRet = MF_DspMsg(gc_strMsgTOKMT52_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
						Call DB_Unlock(DBN_TOKMTC)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ULTTKK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ULTTKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_URITK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_URITK(I)) <> Trim(RD_SSSMAIN_V_URITK(I)) Or Trim(RD_SSSMAIN_ULTTKKB(I)) <> Trim(RD_SSSMAIN_V_ULTTKK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							
							'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TOKMTC"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM TOKMTC"
							' === 20080903 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " WHERE HINCD = '" + RD_SSSMAIN_HINCD(I) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " AND TOKCD = '" + RD_SSSMAIN_TOKCD(I) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " AND URITKDT = '" + RD_SSSMAIN_URITKDT(I) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " AND TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
							'���b�N����
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_TOKMTC, strSQL)
							' === 20080903 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
							strOPEID = DB_TOKMTC.OPEID '�ŏI��Ǝ҃R�[�h
							strCLTID = DB_TOKMTC.CLTID '�N���C�A���g�h�c
							strUOPEID = DB_TOKMTC.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
							strUCLTID = DB_TOKMTC.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
							' === 20080903 === INSERT E - RISE)Izumi
							strWRTDT = DB_TOKMTC.WRTDT '�X�V���t
							strWRTTM = DB_TOKMTC.WRTTM '�X�V����
							strUWRTDT = DB_TOKMTC.UWRTDT '�o�b�`�X�V���t
							strUWRTTM = DB_TOKMTC.UWRTTM '�o�b�`�X�V����
							'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
							
							'�X�V���ԃ`�F�b�N
							' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							bolRet = TOKMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							' === 20080903 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgTOKMT52_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-67
								Call DB_Unlock(DBN_TOKMTC)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-67
								Exit Sub
							End If
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/14 add-end T.KAWAMUKAI
		
		'2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-67
		'�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-67
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.URITKDT = RD_SSSMAIN_URITKDT(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(I)
			Call DB_GetEq(DBN_TOKMTC, 1, DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.URITKDT & DB_TOKMTC.TUKKB, BtrLock)
			
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					DB_TOKMTC.DATKB = "9"
					DB_TOKMTC.WRTTM = wkWRTTM
					DB_TOKMTC.WRTDT = wkWRTDT
					DB_TOKMTC.UOPEID = SSS_OPEID.Value
					DB_TOKMTC.UCLTID = SSS_CLTID.Value
					DB_TOKMTC.UWRTTM = wkWRTTM
					DB_TOKMTC.UWRTDT = wkWRTDT
					DB_TOKMTC.PGID = SSS_PrgId
					Call DB_Update(DBN_TOKMTC, 1)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_ULTTKK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ULTTKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_URITK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_URITK(I)) <> Trim(RD_SSSMAIN_V_URITK(I)) Or Trim(RD_SSSMAIN_ULTTKKB(I)) <> Trim(RD_SSSMAIN_V_ULTTKK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_TOKMTC.DATKB = "1"
						DB_TOKMTC.WRTTM = wkWRTTM
						DB_TOKMTC.WRTDT = wkWRTDT
						DB_TOKMTC.UOPEID = SSS_OPEID.Value
						DB_TOKMTC.UCLTID = SSS_CLTID.Value
						DB_TOKMTC.UWRTTM = wkWRTTM
						DB_TOKMTC.UWRTDT = wkWRTDT
						DB_TOKMTC.PGID = SSS_PrgId
						Call DB_Update(DBN_TOKMTC, 1)
					End If '2006.11.07
				End If
			Else
				Call TOKMTC_RClear()
				Call Mfil_FromSCR(I)
				DB_TOKMTC.DATKB = "1"
				DB_TOKMTC.FOPEID = SSS_OPEID.Value
				DB_TOKMTC.FCLTID = SSS_CLTID.Value
				DB_TOKMTC.WRTFSTTM = wkWRTTM
				DB_TOKMTC.WRTFSTDT = wkWRTDT
				DB_TOKMTC.WRTTM = wkWRTTM
				DB_TOKMTC.WRTDT = wkWRTDT
				DB_TOKMTC.UOPEID = SSS_OPEID.Value
				DB_TOKMTC.UCLTID = SSS_CLTID.Value
				DB_TOKMTC.UWRTTM = wkWRTTM
				DB_TOKMTC.UWRTDT = wkWRTDT
				DB_TOKMTC.PGID = SSS_PrgId
				Call DB_Insert(DBN_TOKMTC, 1)
			End If
			I = I + 1
		Loop 
		Call DB_EndTransaction()
	End Sub
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT52_MF_Chk_UWRTDTTM_T
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
	Public Function TOKMT52_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_Chk_UWRTDTTM_T_err
		
		TOKMT52_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_TOKMT_A_inf(pin_intIDX).OPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).CLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_TOKMT_A_inf(pin_intIDX).OPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).CLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo TOKMT52_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		TOKMT52_MF_Chk_UWRTDTTM_T = True
		
TOKMT52_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
TOKMT52_MF_Chk_UWRTDTTM_T_err: 
		GoTo TOKMT52_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT52_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_UpDown_UWRTDTTM_err
		
		TOKMT52_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_TOKMT_A_inf(pin_intIDX).OPEID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_TOKMT_A_inf(pin_intIDX).CLTID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_TOKMT_A_inf(pin_intIDX).UOPEID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_TOKMT_A_inf(pin_intIDX).UCLTID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_TOKMT_A_inf(pin_intIDX).WRTDT = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_TOKMT_A_inf(pin_intIDX).WRTTM = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_TOKMT_A_inf(pin_intIDX).UWRTDT = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_TOKMT_A_inf(pin_intIDX).UWRTTM = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		TOKMT52_MF_UpDown_UWRTDTTM = True
		
TOKMT52_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_UpDown_UWRTDTTM_err: 
		GoTo TOKMT52_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT52_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_SaveRestore_UWRTDTTM_err
		
		TOKMT52_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_TOKMT_inf.OPEID = M_TOKMT_A_inf(pin_intIDX).OPEID
			M_TOKMT_inf.CLTID = M_TOKMT_A_inf(pin_intIDX).CLTID
			M_TOKMT_inf.UOPEID = M_TOKMT_A_inf(pin_intIDX).UOPEID
			M_TOKMT_inf.UCLTID = M_TOKMT_A_inf(pin_intIDX).UCLTID
			M_TOKMT_inf.WRTDT = M_TOKMT_A_inf(pin_intIDX).WRTDT
			M_TOKMT_inf.WRTTM = M_TOKMT_A_inf(pin_intIDX).WRTTM
			M_TOKMT_inf.UWRTDT = M_TOKMT_A_inf(pin_intIDX).UWRTDT
			M_TOKMT_inf.UWRTTM = M_TOKMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_TOKMT_A_inf(pin_intIDX).OPEID = M_TOKMT_inf.OPEID
			M_TOKMT_A_inf(pin_intIDX).CLTID = M_TOKMT_inf.CLTID
			M_TOKMT_A_inf(pin_intIDX).UOPEID = M_TOKMT_inf.UOPEID
			M_TOKMT_A_inf(pin_intIDX).UCLTID = M_TOKMT_inf.UCLTID
			M_TOKMT_A_inf(pin_intIDX).WRTDT = M_TOKMT_inf.WRTDT
			M_TOKMT_A_inf(pin_intIDX).WRTTM = M_TOKMT_inf.WRTTM
			M_TOKMT_A_inf(pin_intIDX).UWRTDT = M_TOKMT_inf.UWRTDT
			M_TOKMT_A_inf(pin_intIDX).UWRTTM = M_TOKMT_inf.UWRTTM
		End If
		
		TOKMT52_MF_SaveRestore_UWRTDTTM = True
		
TOKMT52_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_SaveRestore_UWRTDTTM_err: 
		GoTo TOKMT52_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT52_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_Clear_UWRTDTTM_err
		
		TOKMT52_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_TOKMT_A_inf(pin_intIDX).OPEID = ""
		M_TOKMT_A_inf(pin_intIDX).CLTID = ""
		M_TOKMT_A_inf(pin_intIDX).UOPEID = ""
		M_TOKMT_A_inf(pin_intIDX).UCLTID = ""
		M_TOKMT_A_inf(pin_intIDX).WRTDT = ""
		M_TOKMT_A_inf(pin_intIDX).WRTTM = ""
		M_TOKMT_A_inf(pin_intIDX).UWRTDT = ""
		M_TOKMT_A_inf(pin_intIDX).UWRTTM = ""
		
		TOKMT52_MF_Clear_UWRTDTTM = True
		
TOKMT52_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_Clear_UWRTDTTM_err: 
		GoTo TOKMT52_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
End Module