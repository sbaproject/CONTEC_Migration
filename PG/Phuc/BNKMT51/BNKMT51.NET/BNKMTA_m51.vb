Option Strict Off
Option Explicit On
Module BNKMTA_M51
	'
	' �X���b�g��        : ��s�}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : BNKMTA.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/29
	' �g�p�v���O������  : BNKMT51
	'
	
	' === 20080930 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_BNKMT
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
	Public M_BNKMT_inf As M_TYPE_BNKMT
	Public M_BNKMT_A_inf() As M_TYPE_BNKMT
	' === 20080930 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/12 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080930 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080930 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/12 add-end M.SUEZAWA
		
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
		
		'2007/12/12 add-str M.SUEZAWA �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(I)
			Call DB_GetEq(DBN_BNKMTA, 1, DB_BNKMTA.BNKCD, BtrNormal)
			If DBSTAT = 0 Then
				' === 20080930 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
				strOPEID = DB_BNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
				strCLTID = DB_BNKMTA.CLTID '�N���C�A���g�h�c
				strUOPEID = DB_BNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
				strUCLTID = DB_BNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
				' === 20080930 === INSERT E - RISE)Izumi
				strWRTDT = DB_BNKMTA.WRTDT '�X�V���t
				strWRTTM = DB_BNKMTA.WRTTM '�X�V����
				strUWRTDT = DB_BNKMTA.UWRTDT '�o�b�`�X�V���t
				strUWRTTM = DB_BNKMTA.UWRTTM '�o�b�`�X�V����
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					
					'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080930 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BNKMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BNKMTA"
					' === 20080930 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " WHERE BNKCD = '" + RD_SSSMAIN_BNKCD(I) + "'"
					'���b�N����
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_BNKMTA, strSQL)
					' === 20080930 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
					strOPEID = DB_BNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
					strCLTID = DB_BNKMTA.CLTID '�N���C�A���g�h�c
					strUOPEID = DB_BNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
					strUCLTID = DB_BNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
					' === 20080930 === INSERT E - RISE)Izumi
					strWRTDT = DB_BNKMTA.WRTDT '�X�V���t
					strWRTTM = DB_BNKMTA.WRTTM '�X�V����
					strUWRTDT = DB_BNKMTA.UWRTDT '�o�b�`�X�V���t
					strUWRTTM = DB_BNKMTA.UWRTTM '�o�b�`�X�V����
					'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
					
					'�X�V���ԃ`�F�b�N
					' === 20080930 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = BNKMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20080930 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						' === 20080930 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BNKMTA)
						Call DB_AbortTransaction()
						' === 20080930 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBNKMT51_E_DEL)
						'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
						' === 20080930 === DELETE S - RISE)Izumi
						'                    Call DB_Unlock(DBN_BNKMTA)
						'                    Call DB_AbortTransaction
						' === 20080930 === DELETE E - RISE)Izumi
						HaitaUpdFlg = 1
						'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						' === 20080930 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BNKMTA)
						Call DB_AbortTransaction()
						' === 20080930 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBNKMT51_E_UPD)
						' === 20080930 === DELETE S - RISE)Izumi
						''2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
						'                    Call DB_Unlock(DBN_BNKMTA)
						'                    Call DB_AbortTransaction
						''2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
						' === 20080930 === DELETE E - RISE)Izumi
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STNNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STNNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BNKNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BNKNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_BNKNM(I)) <> Trim(RD_SSSMAIN_V_BNKNM(I)) Or Trim(RD_SSSMAIN_STNNM(I)) <> Trim(RD_SSSMAIN_V_STNNM(I)) Or Trim(RD_SSSMAIN_BNKNK(I)) <> Trim(RD_SSSMAIN_V_BNKNK(I)) Or Trim(RD_SSSMAIN_STNNK(I)) <> Trim(RD_SSSMAIN_V_STNNK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							
							'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080930 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BNKMTA"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BNKMTA"
							' === 20080930 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & " WHERE BNKCD = '" + RD_SSSMAIN_BNKCD(I) + "'"
							'���b�N����
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_BNKMTA, strSQL)
							' === 20080930 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
							strOPEID = DB_BNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
							strCLTID = DB_BNKMTA.CLTID '�N���C�A���g�h�c
							strUOPEID = DB_BNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
							strUCLTID = DB_BNKMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
							' === 20080930 === INSERT E - RISE)Izumi
							strWRTDT = DB_BNKMTA.WRTDT '�X�V���t
							strWRTTM = DB_BNKMTA.WRTTM '�X�V����
							strUWRTDT = DB_BNKMTA.UWRTDT '�o�b�`�X�V���t
							strUWRTTM = DB_BNKMTA.UWRTTM '�o�b�`�X�V����
							'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
							
							'�X�V���ԃ`�F�b�N
							' === 20080930 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							bolRet = BNKMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							' === 20080930 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								' === 20080930 === INSERT S - RISE)Izumi
								Call DB_Unlock(DBN_BNKMTA)
								Call DB_AbortTransaction()
								' === 20080930 === INSERT E - RISE)Izumi
								intRet = MF_DspMsg(gc_strMsgBNKMT51_E_UPD)
								'2008/07/07 START ADD FNAP)YAMANE �A���[���F�r��-53
								' === 20080930 === DELETE S - RISE)Izumi
								'                            Call DB_Unlock(DBN_BNKMTA)
								'                            Call DB_AbortTransaction
								' === 20080930 === DELETE E - RISE)Izumi
								HaitaUpdFlg = 1
								'2008/07/07 E.N.D ADD FNAP)YAMANE �A���[���F�r��-53
								Exit Sub
							End If
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/12 add-end M.SUEZAWA
		'
		I = 0
		'2008/07/07 START DEL FNAP)YAMANE �A���[���F�r��-53
		'�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/07 E.N.D DEL FNAP)YAMANE �A���[���F�r��-53
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(I)
			Call DB_GetEq(DBN_BNKMTA, 1, DB_BNKMTA.BNKCD, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					
					DB_BNKMTA.DATKB = "9"
					DB_BNKMTA.RELFL = "1"
					DB_BNKMTA.OPEID = SSS_OPEID.Value
					DB_BNKMTA.CLTID = SSS_CLTID.Value
					DB_BNKMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
					DB_BNKMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
					DB_BNKMTA.UOPEID = SSS_OPEID.Value
					DB_BNKMTA.UCLTID = SSS_CLTID.Value
					DB_BNKMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
					DB_BNKMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
					DB_BNKMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_BNKMTA, 1)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STNNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STNNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BNKNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKNK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_STNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_BNKNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BNKNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_BNKNM(I)) <> Trim(RD_SSSMAIN_V_BNKNM(I)) Or Trim(RD_SSSMAIN_STNNM(I)) <> Trim(RD_SSSMAIN_V_STNNM(I)) Or Trim(RD_SSSMAIN_BNKNK(I)) <> Trim(RD_SSSMAIN_V_BNKNK(I)) Or Trim(RD_SSSMAIN_STNNK(I)) <> Trim(RD_SSSMAIN_V_STNNK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_BNKMTA.DATKB = "1"
						DB_BNKMTA.RELFL = "1"
						DB_BNKMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
						DB_BNKMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
						DB_BNKMTA.UOPEID = SSS_OPEID.Value
						DB_BNKMTA.UCLTID = SSS_CLTID.Value
						DB_BNKMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
						DB_BNKMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
						DB_BNKMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_BNKMTA, 1)
					End If '2006.11.07
				End If
			Else
				Call BNKMTA_RClear()
				Call Mfil_FromSCR(I)
				DB_BNKMTA.DATKB = "1"
				DB_BNKMTA.RELFL = "1"
				
				DB_BNKMTA.FOPEID = SSS_OPEID.Value
				DB_BNKMTA.FCLTID = SSS_CLTID.Value
				DB_BNKMTA.WRTFSTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.WRTFSTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.UOPEID = SSS_OPEID.Value
				DB_BNKMTA.UCLTID = SSS_CLTID.Value
				DB_BNKMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.PGID = SSS_PrgId
				
				Call DB_Insert(DBN_BNKMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_BNKMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BNKMT51_MF_Chk_UWRTDTTM_T
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
	Public Function BNKMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_Chk_UWRTDTTM_T_err
		
		BNKMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_BNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_BNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo BNKMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		BNKMT51_MF_Chk_UWRTDTTM_T = True
		
BNKMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
BNKMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo BNKMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BNKMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_UpDown_UWRTDTTM_err
		
		BNKMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_BNKMT_A_inf(pin_intIDX).OPEID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_BNKMT_A_inf(pin_intIDX).CLTID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_BNKMT_A_inf(pin_intIDX).UOPEID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_BNKMT_A_inf(pin_intIDX).UCLTID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_BNKMT_A_inf(pin_intIDX).WRTDT = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_BNKMT_A_inf(pin_intIDX).WRTTM = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_BNKMT_A_inf(pin_intIDX).UWRTDT = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_BNKMT_A_inf(pin_intIDX).UWRTTM = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		BNKMT51_MF_UpDown_UWRTDTTM = True
		
BNKMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo BNKMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BNKMT51_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_SaveRestore_UWRTDTTM_err
		
		BNKMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_BNKMT_inf.OPEID = M_BNKMT_A_inf(pin_intIDX).OPEID
			M_BNKMT_inf.CLTID = M_BNKMT_A_inf(pin_intIDX).CLTID
			M_BNKMT_inf.UOPEID = M_BNKMT_A_inf(pin_intIDX).UOPEID
			M_BNKMT_inf.UCLTID = M_BNKMT_A_inf(pin_intIDX).UCLTID
			M_BNKMT_inf.WRTDT = M_BNKMT_A_inf(pin_intIDX).WRTDT
			M_BNKMT_inf.WRTTM = M_BNKMT_A_inf(pin_intIDX).WRTTM
			M_BNKMT_inf.UWRTDT = M_BNKMT_A_inf(pin_intIDX).UWRTDT
			M_BNKMT_inf.UWRTTM = M_BNKMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_BNKMT_A_inf(pin_intIDX).OPEID = M_BNKMT_inf.OPEID
			M_BNKMT_A_inf(pin_intIDX).CLTID = M_BNKMT_inf.CLTID
			M_BNKMT_A_inf(pin_intIDX).UOPEID = M_BNKMT_inf.UOPEID
			M_BNKMT_A_inf(pin_intIDX).UCLTID = M_BNKMT_inf.UCLTID
			M_BNKMT_A_inf(pin_intIDX).WRTDT = M_BNKMT_inf.WRTDT
			M_BNKMT_A_inf(pin_intIDX).WRTTM = M_BNKMT_inf.WRTTM
			M_BNKMT_A_inf(pin_intIDX).UWRTDT = M_BNKMT_inf.UWRTDT
			M_BNKMT_A_inf(pin_intIDX).UWRTTM = M_BNKMT_inf.UWRTTM
		End If
		
		BNKMT51_MF_SaveRestore_UWRTDTTM = True
		
BNKMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo BNKMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function BNKMT51_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_Clear_UWRTDTTM_err
		
		BNKMT51_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_BNKMT_A_inf(pin_intIDX).OPEID = ""
		M_BNKMT_A_inf(pin_intIDX).CLTID = ""
		M_BNKMT_A_inf(pin_intIDX).UOPEID = ""
		M_BNKMT_A_inf(pin_intIDX).UCLTID = ""
		M_BNKMT_A_inf(pin_intIDX).WRTDT = ""
		M_BNKMT_A_inf(pin_intIDX).WRTTM = ""
		M_BNKMT_A_inf(pin_intIDX).UWRTDT = ""
		M_BNKMT_A_inf(pin_intIDX).UWRTTM = ""
		
		BNKMT51_MF_Clear_UWRTDTTM = True
		
BNKMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_Clear_UWRTDTTM_err: 
		GoTo BNKMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
End Module