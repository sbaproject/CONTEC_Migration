Option Strict Off
Option Explicit On
Module UNTMTA_M51
	'
	' �X���b�g��        : �P�ʃ}�X�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : UNTMTA.M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/05/29
	' �g�p�v���O������  : UNTMT51
	'
	'20080929 ADD START RISE)Tanimura '�r������
	Structure M_TYPE_UNTMT
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char ' �ŏI��Ǝ҃R�[�h
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' �N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char ' �^�C���X�^���v�i���ԁj
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char ' �^�C���X�^���v�i���t�j
	End Structure
	Public M_UNTMT_inf As M_TYPE_UNTMT
	Public M_UNTMT_A_inf() As M_TYPE_UNTMT
	'20080929 ADD END   RISE)Tanimura
	
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
		
		'20080929 ADD START RISE)Tanimura '�r������
		Dim strOPEID As String ' �ŏI��Ǝ҃R�[�h
		Dim strCLTID As String ' �N���C�A���g�h�c
		Dim strSQL As String
		'20080929 ADD END   RISE)Tanimura
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
		
		'2007/12/14 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(I)
			Call DB_GetEq(DBN_UNTMTA, 1, DB_UNTMTA.UNTCD, BtrNormal)
			If DBSTAT = 0 Then
				'20080929 CHG START RISE)Tanimura '�r������
				'            strWRTDT = DB_UNTMTA.WRTDT            '�X�V���t
				'            strWRTTM = DB_UNTMTA.WRTTM            '�X�V����
				'            strUWRTDT = ""
				'            strUWRTTM = ""
				
				strOPEID = DB_UNTMTA.OPEID ' �ŏI��Ǝ҃R�[�h
				strCLTID = DB_UNTMTA.CLTID ' �N���C�A���g�h�c
				strWRTDT = DB_UNTMTA.WRTDT ' �^�C���X�^���v�i���ԁj
				strWRTTM = DB_UNTMTA.WRTTM ' �^�C���X�^���v�i���t�j
				'20080929 CHG END   RISE)Tanimura
				
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					'20080929 CHG START RISE)Tanimura '�r������
					''2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
					'                HaitaUpdFlg = 0
					'                Dim strSQL As String
					'                strSQL = ""
					'                strSQL = "SELECT WRTDT,WRTTM,WRTFSTDT,WRTFSTTM FROM UNTMTA"
					'                strSQL = strSQL + " WHERE UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "'"
					'                '���b�N����
					'                strSQL = strSQL & "          FOR UPDATE"
					'                Call DB_GetSQL2(DBN_UNTMTA, strSQL)
					'                strWRTDT = DB_UNTMTA.WRTDT            '�X�V���t
					'                strWRTTM = DB_UNTMTA.WRTTM            '�X�V����
					'                strUWRTDT = ""                        '�o�b�`�X�V���t
					'                strUWRTTM = ""                        '�o�b�`�X�V����
					''2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
					'
					'                '�X�V���ԃ`�F�b�N
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					
					HaitaUpdFlg = 0
					
					' �P�ʃ}�X�^
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  OPEID "
					strSQL = strSQL & ", CLTID "
					strSQL = strSQL & ", WRTTM "
					strSQL = strSQL & ", WRTDT "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  UNTMTA "
					strSQL = strSQL & "WHERE"
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & "  UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "' "
					strSQL = strSQL & "FOR UPDATE"
					
					Call DB_GetSQL2(DBN_UNTMTA, strSQL)
					
					strOPEID = DB_UNTMTA.OPEID ' �ŏI��Ǝ҃R�[�h
					strCLTID = DB_UNTMTA.CLTID ' �N���C�A���g�h�c
					strWRTDT = DB_UNTMTA.WRTDT ' �^�C���X�^���v�i���ԁj
					strWRTTM = DB_UNTMTA.WRTTM ' �^�C���X�^���v�i���t�j
					
					' �X�V���ԃ`�F�b�N
					bolRet = UNTMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, I)
					'20080929 CHG END   RISE)Tanimura
					
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgUNTMT51_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
						Call DB_Unlock(DBN_UNTMTA)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
						Exit Sub
					End If
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						intRet = MF_DspMsg(gc_strMsgUNTMT51_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
						Call DB_Unlock(DBN_UNTMTA)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_UNTNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						If Trim(RD_SSSMAIN_UNTNM(I)) <> Trim(RD_SSSMAIN_V_UNTNM(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							'20080929 CHG START RISE)Tanimura '�r������
							''2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
							'                       HaitaUpdFlg = 0
							'                       strSQL = ""
							'                       strSQL = "SELECT WRTDT,WRTTM,WRTFSTDT,WRTFSTTM FROM UNTMTA"
							'                       strSQL = strSQL + " WHERE UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "'"
							'                       '���b�N����
							'                       strSQL = strSQL & "          FOR UPDATE"
							'                       Call DB_GetSQL2(DBN_UNTMTA, strSQL)
							'                       strWRTDT = DB_UNTMTA.WRTDT            '�X�V���t
							'                       strWRTTM = DB_UNTMTA.WRTTM            '�X�V����
							'                       strUWRTDT = ""                        '�o�b�`�X�V���t
							'                       strUWRTTM = ""                        '�o�b�`�X�V����
							''2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
							'
							'                        '�X�V���ԃ`�F�b�N
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							
							HaitaUpdFlg = 0
							
							' �P�ʃ}�X�^
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  OPEID "
							strSQL = strSQL & ", CLTID "
							strSQL = strSQL & ", WRTTM "
							strSQL = strSQL & ", WRTDT "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  UNTMTA "
							strSQL = strSQL & "WHERE"
							'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							strSQL = strSQL & "  UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "' "
							strSQL = strSQL & "FOR UPDATE"
							
							Call DB_GetSQL2(DBN_UNTMTA, strSQL)
							
							strOPEID = DB_UNTMTA.OPEID ' �ŏI��Ǝ҃R�[�h
							strCLTID = DB_UNTMTA.CLTID ' �N���C�A���g�h�c
							strWRTDT = DB_UNTMTA.WRTDT ' �^�C���X�^���v�i���ԁj
							strWRTTM = DB_UNTMTA.WRTTM ' �^�C���X�^���v�i���t�j
							
							' �X�V���ԃ`�F�b�N
							bolRet = UNTMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, I)
							'20080929 CHG END   RISE)Tanimura
							
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgUNTMT51_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-71
								Call DB_Unlock(DBN_UNTMTA)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-71
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
		
		'2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-71
		'�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-71
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(I)
			Call DB_GetEq(DBN_UNTMTA, 1, DB_UNTMTA.UNTCD, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					'�폜
					DB_UNTMTA.DATKB = "9"
					DB_UNTMTA.RELFL = "1"
					DB_UNTMTA.OPEID = SSS_OPEID.Value
					DB_UNTMTA.CLTID = SSS_CLTID.Value
					DB_UNTMTA.WRTTM = WRTTM
					DB_UNTMTA.WRTDT = WRTDT
					'                DB_UNTMTA.UOPEID = SSS_OPEID
					'                DB_UNTMTA.UCLTID = SSS_CLTID
					'                DB_UNTMTA.UWRTTM = WRTTM
					'                DB_UNTMTA.UWRTDT = WRTDT
					'                DB_UNTMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_UNTMTA, 1)
				Else
					'�X�V
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_UNTNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UNTNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_UNTNM(I)) <> Trim(RD_SSSMAIN_V_UNTNM(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_UNTMTA.DATKB = "1"
						DB_UNTMTA.RELFL = "1"
						DB_UNTMTA.WRTTM = WRTTM
						DB_UNTMTA.WRTDT = WRTDT
						'                    DB_UNTMTA.UOPEID = SSS_OPEID
						'                    DB_UNTMTA.UCLTID = SSS_CLTID
						'                    DB_UNTMTA.UWRTTM = WRTTM
						'                    DB_UNTMTA.UWRTDT = WRTDT
						'                    DB_UNTMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_UNTMTA, 1)
					End If '2006.11.07
				End If
			Else
                '�ǉ�
                '2019/09/25 DEL START
                'Call UNTMTA_RClear()
                '2019/09/25 DEL E N D
                Call Mfil_FromSCR(I)
				DB_UNTMTA.DATKB = "1"
				DB_UNTMTA.RELFL = "1"
				'            DB_UNTMTA.FOPEID = SSS_OPEID
				'            DB_UNTMTA.FCLTID = SSS_CLTID
				DB_UNTMTA.WRTFSTTM = WRTTM
				DB_UNTMTA.WRTFSTDT = WRTDT
				DB_UNTMTA.WRTTM = WRTTM
				DB_UNTMTA.WRTDT = WRTDT
				'            DB_UNTMTA.UOPEID = SSS_OPEID
				'            DB_UNTMTA.UCLTID = SSS_CLTID
				'            DB_UNTMTA.UWRTTM = WRTTM
				'            DB_UNTMTA.UWRTDT = WRTDT
				'            DB_UNTMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_UNTMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_UNTMTA)
		Call DB_EndTransaction()
	End Sub
	
	'20080929 ADD START RISE)Tanimura '�r������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function UNTMT51_MF_Chk_UWRTDTTM_T
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pin_strOPEID    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID    : �N���C�A���g�h�c
	'           pin_strWRTTM    : �^�C���X�^���v�i���ԁj
	'           pin_strWRTDT    : �^�C���X�^���v�i���t�j
	'           pin_intIDX      : �����ׂ̏ꍇ�@�@�@�@���׍s�i0�`�j
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo UNTMT51_MF_Chk_UWRTDTTM_T_err
		
		UNTMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_UNTMT_A_inf(pin_intIDX).OPEID) & Trim(M_UNTMT_A_inf(pin_intIDX).CLTID) & Trim(M_UNTMT_A_inf(pin_intIDX).WRTTM) & Trim(M_UNTMT_A_inf(pin_intIDX).WRTDT), "0") <> 0 Then
			' �X�V���ԃ`�F�b�N
			If Trim(M_UNTMT_A_inf(pin_intIDX).OPEID) <> Trim(pin_strOPEID) Or Trim(M_UNTMT_A_inf(pin_intIDX).CLTID) <> Trim(pin_strCLTID) Or Trim(M_UNTMT_A_inf(pin_intIDX).WRTTM) <> Trim(pin_strWRTTM) Or Trim(M_UNTMT_A_inf(pin_intIDX).WRTDT) <> Trim(pin_strWRTDT) Then
				GoTo UNTMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		UNTMT51_MF_Chk_UWRTDTTM_T = True
		
UNTMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
UNTMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo UNTMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function UNTMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo UNTMT51_MF_UpDown_UWRTDTTM_err
		
		UNTMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_UNTMT_A_inf(pin_intIDX).OPEID = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_UNTMT_A_inf(pin_intIDX).CLTID = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_UNTMT_A_inf(pin_intIDX).WRTDT = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_UNTMT_A_inf(pin_intIDX).WRTTM = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		
		UNTMT51_MF_UpDown_UWRTDTTM = True
		
UNTMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
UNTMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo UNTMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function UNTMT_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo UNTMT_MF_SaveRestore_UWRTDTTM_err
		
		UNTMT_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			' �ޔ��E��������
			M_UNTMT_inf.OPEID = M_UNTMT_A_inf(pin_intIDX).OPEID
			M_UNTMT_inf.CLTID = M_UNTMT_A_inf(pin_intIDX).CLTID
			M_UNTMT_inf.WRTDT = M_UNTMT_A_inf(pin_intIDX).WRTDT
			M_UNTMT_inf.WRTTM = M_UNTMT_A_inf(pin_intIDX).WRTTM
		Else
			' ��������
			M_UNTMT_A_inf(pin_intIDX).OPEID = M_UNTMT_inf.OPEID
			M_UNTMT_A_inf(pin_intIDX).CLTID = M_UNTMT_inf.CLTID
			M_UNTMT_A_inf(pin_intIDX).WRTDT = M_UNTMT_inf.WRTDT
			M_UNTMT_A_inf(pin_intIDX).WRTTM = M_UNTMT_inf.WRTTM
		End If
		
		UNTMT_MF_SaveRestore_UWRTDTTM = True
		
UNTMT_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
UNTMT_MF_SaveRestore_UWRTDTTM_err: 
		GoTo UNTMT_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	'20080929 ADD END   RISE)Tanimura
End Module