Option Strict Off
Option Explicit On
Module TUKMTA_M51
	'
	' �X���b�g��        : ���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : TUKMTA.M01
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/31
	' �g�p�v���O������  : TUKMT51
	'
	'20081002 ADD START RISE)Tanimura '�r������
	Structure M_TYPE_RATMT
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char ' �ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' �N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char ' �^�C���X�^���v�i���ԁj
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char ' �^�C���X�^���v�i���t�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char ' ���[�UID�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char ' �N���C�A���g�h�c�i�o�b�`�j
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char ' �^�C���X�^���v�i�o�b�`���ԁj
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char ' �^�C���X�^���v�i�o�b�`���j
	End Structure
	Public M_RATMT_inf As M_TYPE_RATMT
	Public M_RATMT_A_inf() As M_TYPE_RATMT
	'20081002 ADD END   RISE)Tanimura
	
	Sub UPDMST()
		Dim I As Short
		Dim updkb As String
		Dim WRTTM, WRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/14 add-end T.KAWAMUKAI
		
		'20081002 ADD START RISE)Tanimura '�r������
		Dim strOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim strCLTID As String ' �N���C�A���g�h�c
		Dim strUOPEID As String ' ���[�UID�i�o�b�`�j
		Dim strUCLTID As String ' �N���C�A���g�h�c�i�o�b�`�j
		Dim strSQL As String
		'20081002 ADD END   RISE)Tanimura
		
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
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TUKMTA.TEKIDT = RD_SSSMAIN_TEKIDT(I)
			Call DB_GetSQL2(DBN_TUKMTA, "select * from TUKMTA where TUKKB ='" & DB_TUKMTA.TUKKB & "' and TEKIDT='" & DB_TUKMTA.TEKIDT & "' order by TUKKB,TEKIDT")
			If DBSTAT = 0 Then
				'20081002 CHG START RISE)Tanimura '�r������
				'            strWRTDT = DB_TUKMTA.WRTDT            '�X�V���t
				'            strWRTTM = DB_TUKMTA.WRTTM            '�X�V����
				'            strUWRTDT = DB_TUKMTA.UWRTDT          '�o�b�`�X�V���t
				'            strUWRTTM = DB_TUKMTA.UWRTTM          '�o�b�`�X�V����
				
				strOPEID = DB_TUKMTA.OPEID ' �ŏI��Ǝ҃R�[�h
				strCLTID = DB_TUKMTA.CLTID ' �N���C�A���g�h�c
				strWRTTM = DB_TUKMTA.WRTTM ' �^�C���X�^���v�i���ԁj
				strWRTDT = DB_TUKMTA.WRTDT ' �^�C���X�^���v�i���t�j
				strUOPEID = DB_TUKMTA.UOPEID ' ���[�UID�i�o�b�`�j
				strUCLTID = DB_TUKMTA.UCLTID ' �N���C�A���gID�i�o�b�`�j
				strUWRTTM = DB_TUKMTA.UWRTTM ' �^�C���X�^���v�i�o�b�`���ԁj
				strUWRTDT = DB_TUKMTA.UWRTDT ' �^�C���X�^���v�i�o�b�`���j
				'20081002 CHG END   RISE)Tanimura
				
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					'20081002 CHG START RISE)Tanimura '�r������
					' '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
					'                HaitaUpdFlg = 0
					'                Dim strSQL As String
					'                strSQL = ""
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TUKMTA"
					'                strSQL = strSQL + " WHERE TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
					'                strSQL = strSQL + " AND TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "'"
					'                '���b�N����
					'                strSQL = strSQL & "          FOR UPDATE"
					'                Call DB_GetSQL2(DBN_TUKMTA, strSQL)
					'                strWRTDT = DB_TUKMTA.WRTDT            '�X�V���t
					'                strWRTTM = DB_TUKMTA.WRTTM            '�X�V����
					'                strUWRTDT = DB_TUKMTA.UWRTDT          '�o�b�`�X�V���t
					'                strUWRTTM = DB_TUKMTA.UWRTTM          '�o�b�`�X�V����
					' '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
					'
					'                '�X�V���ԃ`�F�b�N
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					
					HaitaUpdFlg = 0
					
					' ���[�g�}�X�^
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  OPEID "
					strSQL = strSQL & ", CLTID "
					strSQL = strSQL & ", WRTTM "
					strSQL = strSQL & ", WRTDT "
					strSQL = strSQL & ", UOPEID "
					strSQL = strSQL & ", UCLTID "
					strSQL = strSQL & ", UWRTTM "
					strSQL = strSQL & ", UWRTDT "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  TUKMTA "
					strSQL = strSQL & "WHERE"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & "  TUKKB  = '" + RD_SSSMAIN_TUKKB(I) + "' "
					strSQL = strSQL & "AND"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & "  TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "' "
					strSQL = strSQL & "FOR UPDATE"
					
					Call DB_GetSQL2(DBN_TUKMTA, strSQL)
					
					strOPEID = DB_TUKMTA.OPEID ' �ŏI��Ǝ҃R�[�h
					strCLTID = DB_TUKMTA.CLTID ' �N���C�A���g�h�c
					strWRTDT = DB_TUKMTA.WRTDT ' �^�C���X�^���v�i���ԁj
					strWRTTM = DB_TUKMTA.WRTTM ' �^�C���X�^���v�i���t�j
					strUOPEID = DB_TUKMTA.UOPEID ' ���[�UID�i�o�b�`�j
					strUCLTID = DB_TUKMTA.UCLTID ' �N���C�A���gID�i�o�b�`�j
					strUWRTTM = DB_TUKMTA.UWRTTM ' �^�C���X�^���v�i�o�b�`���ԁj
					strUWRTDT = DB_TUKMTA.UWRTDT ' �^�C���X�^���v�i�o�b�`���j
					
					' �X�V���ԃ`�F�b�N
					bolRet = RATMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, strUOPEID, strUCLTID, strUWRTTM, strUWRTDT, I)
					'20081002 CHG END   RISE)Tanimura
					
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgRATMT51_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
						Call DB_Unlock(DBN_TUKMTA)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						intRet = MF_DspMsg(gc_strMsgRATMT51_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
						Call DB_Unlock(DBN_TUKMTA)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_RATERT(I)) <> Trim(RD_SSSMAIN_V_RATERT(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							'20081002 CHG START RISE)Tanimura '�r������
							''2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
							'                        HaitaUpdFlg = 0
							'                        strSQL = ""
							'                        strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TUKMTA"
							'                        strSQL = strSQL + " WHERE TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
							'                        strSQL = strSQL + " AND TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "'"
							'                        '���b�N����
							'                        strSQL = strSQL & "          FOR UPDATE"
							'                        Call DB_GetSQL2(DBN_TUKMTA, strSQL)
							'                        strWRTDT = DB_TUKMTA.WRTDT            '�X�V���t
							'                        strWRTTM = DB_TUKMTA.WRTTM            '�X�V����
							'                        strUWRTDT = DB_TUKMTA.UWRTDT          '�o�b�`�X�V���t
							'                        strUWRTTM = DB_TUKMTA.UWRTTM          '�o�b�`�X�V����
							''2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
							'                        '�X�V���ԃ`�F�b�N
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							
							HaitaUpdFlg = 0
							
							' ���[�g�}�X�^
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  OPEID "
							strSQL = strSQL & ", CLTID "
							strSQL = strSQL & ", WRTTM "
							strSQL = strSQL & ", WRTDT "
							strSQL = strSQL & ", UOPEID "
							strSQL = strSQL & ", UCLTID "
							strSQL = strSQL & ", UWRTTM "
							strSQL = strSQL & ", UWRTDT "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  TUKMTA "
							strSQL = strSQL & "WHERE"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & "  TUKKB  = '" + RD_SSSMAIN_TUKKB(I) + "' "
							strSQL = strSQL & "AND"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & "  TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "' "
							strSQL = strSQL & "FOR UPDATE"
							
							Call DB_GetSQL2(DBN_TUKMTA, strSQL)
							
							strOPEID = DB_TUKMTA.OPEID ' �ŏI��Ǝ҃R�[�h
							strCLTID = DB_TUKMTA.CLTID ' �N���C�A���g�h�c
							strWRTDT = DB_TUKMTA.WRTDT ' �^�C���X�^���v�i���ԁj
							strWRTTM = DB_TUKMTA.WRTTM ' �^�C���X�^���v�i���t�j
							strUOPEID = DB_TUKMTA.UOPEID ' ���[�UID�i�o�b�`�j
							strUCLTID = DB_TUKMTA.UCLTID ' �N���C�A���gID�i�o�b�`�j
							strUWRTTM = DB_TUKMTA.UWRTTM ' �^�C���X�^���v�i�o�b�`���ԁj
							strUWRTDT = DB_TUKMTA.UWRTDT ' �^�C���X�^���v�i�o�b�`���j
							
							' �X�V���ԃ`�F�b�N
							bolRet = RATMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, strUOPEID, strUCLTID, strUWRTTM, strUWRTDT, I)
							'20081002 CHG END   RISE)Tanimura
							
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgRATMT51_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-60
								Call DB_Unlock(DBN_TUKMTA)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-60
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
		
		'
		I = 0
		WRTTM = VB6.Format(Now, "hhmmss")
		WRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-60
		'�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-60
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TEKIDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_TUKMTA.TEKIDT = RD_SSSMAIN_TEKIDT(I)
			'Call DB_GetEq(DBN_TUKMTA, 1, DB_TUKMTA.TUKKB, BtrLock)
			Call DB_GetSQL2(DBN_TUKMTA, "select * from TUKMTA where TUKKB ='" & DB_TUKMTA.TUKKB & "' and TEKIDT='" & DB_TUKMTA.TEKIDT & "' order by TUKKB,TEKIDT")
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					DB_TUKMTA.DATKB = "9"
					DB_TUKMTA.RELFL = "1"
					DB_TUKMTA.OPEID = SSS_OPEID.Value
					DB_TUKMTA.CLTID = SSS_CLTID.Value
					DB_TUKMTA.WRTTM = WRTTM
					DB_TUKMTA.WRTDT = WRTDT
					DB_TUKMTA.UOPEID = SSS_OPEID.Value
					DB_TUKMTA.UCLTID = SSS_CLTID.Value
					DB_TUKMTA.UWRTTM = WRTTM
					DB_TUKMTA.UWRTDT = WRTDT
					DB_TUKMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_TUKMTA, 1)
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RATERT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_RATERT(I)) <> Trim(RD_SSSMAIN_V_RATERT(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_TUKMTA.DATKB = "1"
						DB_TUKMTA.RELFL = "1"
						DB_TUKMTA.WRTTM = WRTTM
						DB_TUKMTA.WRTDT = WRTDT
						DB_TUKMTA.UOPEID = SSS_OPEID.Value
						DB_TUKMTA.UCLTID = SSS_CLTID.Value
						DB_TUKMTA.UWRTTM = WRTTM
						DB_TUKMTA.UWRTDT = WRTDT
						DB_TUKMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_TUKMTA, 1)
					End If
				End If
			Else
				'Call TUKMTA_RClear
				Call Mfil_FromSCR(I)
				DB_TUKMTA.DATKB = "1"
				DB_TUKMTA.RELFL = "1"
				DB_TUKMTA.WRTFSTTM = WRTTM
				DB_TUKMTA.WRTFSTDT = WRTDT
				DB_TUKMTA.FOPEID = SSS_OPEID.Value
				DB_TUKMTA.FCLTID = SSS_CLTID.Value
				DB_TUKMTA.WRTFSTTM = WRTTM
				DB_TUKMTA.WRTFSTDT = WRTDT
				DB_TUKMTA.WRTTM = WRTTM
				DB_TUKMTA.WRTDT = WRTDT
				DB_TUKMTA.UOPEID = SSS_OPEID.Value
				DB_TUKMTA.UCLTID = SSS_CLTID.Value
				DB_TUKMTA.UWRTTM = WRTTM
				DB_TUKMTA.UWRTDT = WRTDT
				DB_TUKMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_TUKMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_TUKMTA)
		Call DB_EndTransaction()
	End Sub
	
	'20081002 ADD START RISE)Tanimura '�r������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RATMT51_MF_Chk_UWRTDTTM_T
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pin_strOPEID    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID    : �N���C�A���g�h�c
	'           pin_strWRTTM    : �^�C���X�^���v�i���ԁj
	'           pin_strWRTDT    : �^�C���X�^���v�i���t�j
	'           pin_strUOPEID   : ���[�UID�i�o�b�`�j
	'           pin_strUCLTID   : �N���C�A���gID�i�o�b�`�j
	'           pin_strUWRTTM   : �^�C���X�^���v�i�o�b�`���ԁj
	'           pin_strUWRTDT   : �^�C���X�^���v�i�o�b�`���j
	'           pin_intIDX      : �����ׂ̏ꍇ�@�@�@�@���׍s�i0�`�j
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo RATMT51_MF_Chk_UWRTDTTM_T_err
		
		RATMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_RATMT_A_inf(pin_intIDX).OPEID) & Trim(M_RATMT_A_inf(pin_intIDX).CLTID) & Trim(M_RATMT_A_inf(pin_intIDX).WRTTM) & Trim(M_RATMT_A_inf(pin_intIDX).WRTDT) & Trim(M_RATMT_A_inf(pin_intIDX).UOPEID) & Trim(M_RATMT_A_inf(pin_intIDX).UCLTID) & Trim(M_RATMT_A_inf(pin_intIDX).UWRTTM) & Trim(M_RATMT_A_inf(pin_intIDX).UWRTDT), "0") <> 0 Then
			' �X�V���ԃ`�F�b�N
			If Trim(M_RATMT_A_inf(pin_intIDX).OPEID) <> Trim(pin_strOPEID) Or Trim(M_RATMT_A_inf(pin_intIDX).CLTID) <> Trim(pin_strCLTID) Or Trim(M_RATMT_A_inf(pin_intIDX).WRTTM) <> Trim(pin_strWRTTM) Or Trim(M_RATMT_A_inf(pin_intIDX).WRTDT) <> Trim(pin_strWRTDT) Or Trim(M_RATMT_A_inf(pin_intIDX).UOPEID) <> Trim(pin_strUOPEID) Or Trim(M_RATMT_A_inf(pin_intIDX).UCLTID) <> Trim(pin_strUCLTID) Or Trim(M_RATMT_A_inf(pin_intIDX).UWRTTM) <> Trim(pin_strUWRTTM) Or Trim(M_RATMT_A_inf(pin_intIDX).UWRTDT) <> Trim(pin_strUWRTDT) Then
				GoTo RATMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		RATMT51_MF_Chk_UWRTDTTM_T = True
		
RATMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
RATMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo RATMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RATMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo RATMT51_MF_UpDown_UWRTDTTM_err
		
		RATMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_RATMT_A_inf(pin_intIDX).OPEID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_RATMT_A_inf(pin_intIDX).CLTID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_RATMT_A_inf(pin_intIDX).WRTDT = M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_RATMT_A_inf(pin_intIDX).WRTTM = M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_RATMT_A_inf(pin_intIDX).UOPEID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_RATMT_A_inf(pin_intIDX).UCLTID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_RATMT_A_inf(pin_intIDX).UWRTDT = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_RATMT_A_inf(pin_intIDX).UWRTTM = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		RATMT51_MF_UpDown_UWRTDTTM = True
		
RATMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo RATMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RATMT51_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo RATMT51_MF_SaveRestore_UWRTDTTM_err
		
		RATMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			' �ޔ��E��������
			M_RATMT_inf.OPEID = M_RATMT_A_inf(pin_intIDX).OPEID
			M_RATMT_inf.CLTID = M_RATMT_A_inf(pin_intIDX).CLTID
			M_RATMT_inf.WRTDT = M_RATMT_A_inf(pin_intIDX).WRTDT
			M_RATMT_inf.WRTTM = M_RATMT_A_inf(pin_intIDX).WRTTM
			M_RATMT_inf.UOPEID = M_RATMT_A_inf(pin_intIDX).UOPEID
			M_RATMT_inf.UCLTID = M_RATMT_A_inf(pin_intIDX).UCLTID
			M_RATMT_inf.UWRTDT = M_RATMT_A_inf(pin_intIDX).UWRTDT
			M_RATMT_inf.UWRTTM = M_RATMT_A_inf(pin_intIDX).UWRTTM
		Else
			' ��������
			M_RATMT_A_inf(pin_intIDX).OPEID = M_RATMT_inf.OPEID
			M_RATMT_A_inf(pin_intIDX).CLTID = M_RATMT_inf.CLTID
			M_RATMT_A_inf(pin_intIDX).WRTDT = M_RATMT_inf.WRTDT
			M_RATMT_A_inf(pin_intIDX).WRTTM = M_RATMT_inf.WRTTM
			M_RATMT_A_inf(pin_intIDX).UOPEID = M_RATMT_inf.UOPEID
			M_RATMT_A_inf(pin_intIDX).UCLTID = M_RATMT_inf.UCLTID
			M_RATMT_A_inf(pin_intIDX).UWRTDT = M_RATMT_inf.UWRTDT
			M_RATMT_A_inf(pin_intIDX).UWRTTM = M_RATMT_inf.UWRTTM
		End If
		
		RATMT51_MF_SaveRestore_UWRTDTTM = True
		
RATMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo RATMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RATMT51_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo RATMT51_MF_Clear_UWRTDTTM_err
		
		RATMT51_MF_Clear_UWRTDTTM = False
		
		' �X�V���ԁ@�z��N���A
		M_RATMT_A_inf(pin_intIDX).OPEID = ""
		M_RATMT_A_inf(pin_intIDX).CLTID = ""
		M_RATMT_A_inf(pin_intIDX).WRTDT = ""
		M_RATMT_A_inf(pin_intIDX).WRTTM = ""
		M_RATMT_A_inf(pin_intIDX).UOPEID = ""
		M_RATMT_A_inf(pin_intIDX).UCLTID = ""
		M_RATMT_A_inf(pin_intIDX).UWRTDT = ""
		M_RATMT_A_inf(pin_intIDX).UWRTTM = ""
		
		RATMT51_MF_Clear_UWRTDTTM = True
		
RATMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_Clear_UWRTDTTM_err: 
		GoTo RATMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function RATMT51_MF_All_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_All_Clear_UWRTDTTM() As Boolean
		
		Dim I As Short
		
		On Error GoTo RATMT51_MF_All_Clear_UWRTDTTM_err
		
		RATMT51_MF_All_Clear_UWRTDTTM = False
		
		' �X�V���ԁ@�z��N���A
		For I = 0 To UBound(M_RATMT_A_inf)
			M_RATMT_A_inf(I).OPEID = ""
			M_RATMT_A_inf(I).CLTID = ""
			M_RATMT_A_inf(I).WRTDT = ""
			M_RATMT_A_inf(I).WRTTM = ""
			M_RATMT_A_inf(I).UOPEID = ""
			M_RATMT_A_inf(I).UCLTID = ""
			M_RATMT_A_inf(I).UWRTDT = ""
			M_RATMT_A_inf(I).UWRTTM = ""
		Next I
		
		RATMT51_MF_All_Clear_UWRTDTTM = True
		
RATMT51_MF_All_Clear_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_All_Clear_UWRTDTTM_err: 
		GoTo RATMT51_MF_All_Clear_UWRTDTTM_End
		
	End Function
	'20081002 ADD END   RISE)Tanimura
End Module