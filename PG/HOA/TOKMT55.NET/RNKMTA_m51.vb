Option Strict Off
Option Explicit On
Module RNKMTA_M51
	'
	' �X���b�g��        : �ݸ�ʎd�ؗ��}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : RNKMTA.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/29
	' �g�p�v���O������  : HINMT51
	'
	
	' === 20080908 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_RNKMT
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
	Public M_RNKMT_inf As M_TYPE_RNKMT
	Public M_RNKMT_A_inf() As M_TYPE_RNKMT
	' === 20080908 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim i As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080908 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080908 === INSERT E - RISE)Izumi
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
		
		'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		i = 0
		Dim strSQL As String
		Do While i < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.SKHINGRP = RD_SSSMAIN_SKHINGRP(0)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.RNKCD = RD_SSSMAIN_RNKCD(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.URISETDT = RD_SSSMAIN_URISETDT(i)
			Call DB_GetEq(DBN_RNKMTA, 1, DB_RNKMTA.SKHINGRP & DB_RNKMTA.RNKCD & DB_RNKMTA.URISETDT, BtrNormal)
			If DBSTAT = 0 Then
				' === 20080908 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
				strOPEID = DB_RNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
				strCLTID = DB_RNKMTA.CLTID '�N���C�A���g�h�c
				strUOPEID = DB_RNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strUCLTID = DB_RNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
				' === 20080908 === INSERT E - RISE)Izumi
				strWRTDT = DB_RNKMTA.WRTDT '�X�V���t
				strWRTTM = DB_RNKMTA.WRTTM '�X�V����
				strUWRTDT = DB_RNKMTA.UWRTDT '�o�b�`�X�V���t
				strUWRTTM = DB_RNKMTA.UWRTTM '�o�b�`�X�V����
				
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(i)
				If updkb = "�폜" Then
					
					'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM RNKMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM RNKMTA"
					' === 20080908 === UPDATE E - RISE)Izumi
					strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM RNKMTA"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " WHERE SKHINGRP = '" + RD_SSSMAIN_SKHINGRP(0) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " AND RNKCD = '" + RD_SSSMAIN_RNKCD(i) + "'"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " AND WRTFSTDT = '" + RD_SSSMAIN_URISETDT(i) + "'"
					'���b�N����
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_RNKMTA, strSQL)
					' === 20080908 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
					strOPEID = DB_RNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
					strCLTID = DB_RNKMTA.CLTID '�N���C�A���g�h�c
					strUOPEID = DB_RNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
					strUCLTID = DB_RNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
					' === 20080908 === INSERT E - RISE)Izumi
					strWRTDT = DB_RNKMTA.WRTDT '�X�V���t
					strWRTTM = DB_RNKMTA.WRTTM '�X�V����
					strUWRTDT = DB_RNKMTA.UWRTDT '�o�b�`�X�V���t
					strUWRTTM = DB_RNKMTA.UWRTTM '�o�b�`�X�V����
					'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
					
					'�X�V���ԃ`�F�b�N
					' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, i)
					bolRet = TOKMT55_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, i)
					' === 20080908 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgTOKMT55_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
						Call DB_Unlock(DBN_RNKMTA)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
						Exit Sub
					End If
					
				Else
					'2007/12/18 add-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						intRet = MF_DspMsg(gc_strMsgTOKMT55_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
						Call DB_Unlock(DBN_RNKMTA)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(i) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SIKRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SIKRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_SIKRT(i)) <> Trim(RD_SSSMAIN_V_SIKRT(i)) Or RD_SSSMAIN_V_DATKB(i) = "9" Then
							
							'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM RNKMTA"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM RNKMTA"
							' === 20080908 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " WHERE SKHINGRP = '" + RD_SSSMAIN_SKHINGRP(0) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " AND RNKCD = '" + RD_SSSMAIN_RNKCD(i) + "'"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " AND WRTFSTDT = '" + RD_SSSMAIN_URISETDT(i) + "'"
							'���b�N����
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_RNKMTA, strSQL)
							' === 20080908 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
							strOPEID = DB_RNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
							strCLTID = DB_RNKMTA.CLTID '�N���C�A���g�h�c
							strUOPEID = DB_RNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
							strUCLTID = DB_RNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
							' === 20080908 === INSERT E - RISE)Izumi
							strWRTDT = DB_RNKMTA.WRTDT '�X�V���t
							strWRTTM = DB_RNKMTA.WRTTM '�X�V����
							strUWRTDT = DB_RNKMTA.UWRTDT '�o�b�`�X�V���t
							strUWRTTM = DB_RNKMTA.UWRTTM '�o�b�`�X�V����
							'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
							
							'�X�V���ԃ`�F�b�N
							' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, i)
							bolRet = TOKMT55_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, i)
							' === 20080908 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgTOKMT55_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
								Call DB_Unlock(DBN_RNKMTA)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
								Exit Sub
							End If
						End If
						'2007/12/18 add-end T.KAWAMUKAI
					End If
				End If
			End If
			i = i + 1
		Loop 
		'2007/12/14 add-end T.KAWAMUKAI
		
		i = 0
		
		'2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-60
		'�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-60
		
		Do While i < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.SKHINGRP = RD_SSSMAIN_SKHINGRP(0)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.RNKCD = RD_SSSMAIN_RNKCD(i)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_RNKMTA.URISETDT = RD_SSSMAIN_URISETDT(i)
			Call DB_GetEq(DBN_RNKMTA, 1, DB_RNKMTA.SKHINGRP & DB_RNKMTA.RNKCD & DB_RNKMTA.URISETDT, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(i)
				If updkb = "�폜" Then
					DB_RNKMTA.DATKB = "9"
					DB_RNKMTA.WRTTM = wkWRTTM
					DB_RNKMTA.WRTDT = wkWRTDT
					DB_RNKMTA.UOPEID = SSS_OPEID.Value
					DB_RNKMTA.UCLTID = SSS_CLTID.Value
					DB_RNKMTA.UWRTTM = wkWRTTM
					DB_RNKMTA.UWRTDT = wkWRTDT
					DB_RNKMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_RNKMTA, 1)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(i) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_SIKRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SIKRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_SIKRT(i)) <> Trim(RD_SSSMAIN_V_SIKRT(i)) Or RD_SSSMAIN_V_DATKB(i) = "9" Then '2006.11.07
						Call Mfil_FromSCR(i)
						DB_RNKMTA.DATKB = "1"
						DB_RNKMTA.WRTTM = wkWRTTM
						DB_RNKMTA.WRTDT = wkWRTDT
						DB_RNKMTA.UOPEID = SSS_OPEID.Value
						DB_RNKMTA.UCLTID = SSS_CLTID.Value
						DB_RNKMTA.UWRTTM = wkWRTTM
						DB_RNKMTA.UWRTDT = wkWRTDT
						DB_RNKMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_RNKMTA, 1)
					End If '2006.11.07
				End If
				DB_RNKMTA.WRTTM = wkWRTTM
				DB_RNKMTA.WRTDT = wkWRTDT
				
			Else
                'Call RNKMTA_RClear()
                Call Mfil_FromSCR(i)
				DB_RNKMTA.DATKB = "1"
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DB_RNKMTA.SKHINGRP = RD_SSSMAIN_SKHINGRP(0)
				DB_RNKMTA.FOPEID = SSS_OPEID.Value
				DB_RNKMTA.FCLTID = SSS_CLTID.Value
				DB_RNKMTA.WRTFSTTM = wkWRTTM
				DB_RNKMTA.WRTFSTDT = wkWRTDT
				DB_RNKMTA.WRTTM = wkWRTTM
				DB_RNKMTA.WRTDT = wkWRTDT
				DB_RNKMTA.UOPEID = SSS_OPEID.Value
				DB_RNKMTA.UCLTID = SSS_CLTID.Value
				DB_RNKMTA.UWRTTM = wkWRTTM
				DB_RNKMTA.UWRTDT = wkWRTDT
				DB_RNKMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_RNKMTA, 1)
			End If
			i = i + 1
		Loop 
		Call DB_Unlock(DBN_RNKMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080908 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT55_MF_Chk_UWRTDTTM_T
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
	Public Function TOKMT55_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT55_MF_Chk_UWRTDTTM_T_err
		
		TOKMT55_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_RNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_RNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_RNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_RNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_RNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_RNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_RNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_RNKMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_RNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_RNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_RNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_RNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_RNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_RNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_RNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_RNKMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo TOKMT55_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		TOKMT55_MF_Chk_UWRTDTTM_T = True
		
TOKMT55_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
TOKMT55_MF_Chk_UWRTDTTM_T_err: 
		GoTo TOKMT55_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080908 === INSERT E - RISE)Izumi
	
	' === 20080908 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT55_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT55_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo TOKMT55_MF_UpDown_UWRTDTTM_err
		
		TOKMT55_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_RNKMT_A_inf(pin_intIDX).OPEID = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_RNKMT_A_inf(pin_intIDX).CLTID = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_RNKMT_A_inf(pin_intIDX).UOPEID = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_RNKMT_A_inf(pin_intIDX).UCLTID = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_RNKMT_A_inf(pin_intIDX).WRTDT = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_RNKMT_A_inf(pin_intIDX).WRTTM = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_RNKMT_A_inf(pin_intIDX).UWRTDT = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_RNKMT_A_inf(pin_intIDX).UWRTTM = M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_RNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		TOKMT55_MF_UpDown_UWRTDTTM = True
		
TOKMT55_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
TOKMT55_MF_UpDown_UWRTDTTM_err: 
		GoTo TOKMT55_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080908 === INSERT E - RISE)Izumi
	
	' === 20080908 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT55_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT55_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo TOKMT55_MF_SaveRestore_UWRTDTTM_err
		
		TOKMT55_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_RNKMT_inf.OPEID = M_RNKMT_A_inf(pin_intIDX).OPEID
			M_RNKMT_inf.CLTID = M_RNKMT_A_inf(pin_intIDX).CLTID
			M_RNKMT_inf.UOPEID = M_RNKMT_A_inf(pin_intIDX).UOPEID
			M_RNKMT_inf.UCLTID = M_RNKMT_A_inf(pin_intIDX).UCLTID
			M_RNKMT_inf.WRTDT = M_RNKMT_A_inf(pin_intIDX).WRTDT
			M_RNKMT_inf.WRTTM = M_RNKMT_A_inf(pin_intIDX).WRTTM
			M_RNKMT_inf.UWRTDT = M_RNKMT_A_inf(pin_intIDX).UWRTDT
			M_RNKMT_inf.UWRTTM = M_RNKMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_RNKMT_A_inf(pin_intIDX).OPEID = M_RNKMT_inf.OPEID
			M_RNKMT_A_inf(pin_intIDX).CLTID = M_RNKMT_inf.CLTID
			M_RNKMT_A_inf(pin_intIDX).UOPEID = M_RNKMT_inf.UOPEID
			M_RNKMT_A_inf(pin_intIDX).UCLTID = M_RNKMT_inf.UCLTID
			M_RNKMT_A_inf(pin_intIDX).WRTDT = M_RNKMT_inf.WRTDT
			M_RNKMT_A_inf(pin_intIDX).WRTTM = M_RNKMT_inf.WRTTM
			M_RNKMT_A_inf(pin_intIDX).UWRTDT = M_RNKMT_inf.UWRTDT
			M_RNKMT_A_inf(pin_intIDX).UWRTTM = M_RNKMT_inf.UWRTTM
		End If
		
		TOKMT55_MF_SaveRestore_UWRTDTTM = True
		
TOKMT55_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
TOKMT55_MF_SaveRestore_UWRTDTTM_err: 
		GoTo TOKMT55_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080908 === INSERT E - RISE)Izumi
	
	' === 20080908 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function TOKMT55_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT55_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT55_MF_Clear_UWRTDTTM_err
		
		TOKMT55_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_RNKMT_A_inf(pin_intIDX).OPEID = ""
		M_RNKMT_A_inf(pin_intIDX).CLTID = ""
		M_RNKMT_A_inf(pin_intIDX).UOPEID = ""
		M_RNKMT_A_inf(pin_intIDX).UCLTID = ""
		M_RNKMT_A_inf(pin_intIDX).WRTDT = ""
		M_RNKMT_A_inf(pin_intIDX).WRTTM = ""
		M_RNKMT_A_inf(pin_intIDX).UWRTDT = ""
		M_RNKMT_A_inf(pin_intIDX).UWRTTM = ""
		
		TOKMT55_MF_Clear_UWRTDTTM = True
		
TOKMT55_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
TOKMT55_MF_Clear_UWRTDTTM_err: 
		GoTo TOKMT55_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080908 === INSERT E - RISE)Izumi
End Module