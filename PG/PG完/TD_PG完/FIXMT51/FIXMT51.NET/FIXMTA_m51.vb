Option Strict Off
Option Explicit On
Module FIXMTA_M51
	'
	' �X���b�g��        : �Œ�l�o�^�E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : FIXMTA_M51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/10
	' �g�p�v���O������  : FIXMT51
	'
	
	' === 20081002 === INSERT S - RISE)Izumi
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_FIXMT
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
	Public M_FIXMT_inf As M_TYPE_FIXMT
	Public M_FIXMT_A_inf() As M_TYPE_FIXMT
	' === 20081002 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I, J As Short
		Dim updkb As String
		Dim wkWRTTM, wkWRTDT As String
		
		'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20081002 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20081002 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/13 add-end T.KAWAMUKAI
		
		'
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		'
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���", MsgBoxStyle.OKOnly)
			Exit Sub
		End If
		
		'2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
		
		'2007/12/13 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190801 chg start
            'DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(I)
            DB_FIXMTA2.CTLCD = RD_SSSMAIN_CTLCD(I)

            '2007/12/14 add-str T.KAWAMUKAI
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'DB_FIXMTA.CTLNM = RD_SSSMAIN_CTLNM(I)
            DB_FIXMTA2.CTLNM = RD_SSSMAIN_CTLNM(I)
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FIXVAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'DB_FIXMTA.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            DB_FIXMTA2.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_REMARK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'DB_FIXMTA.REMARK = RD_SSSMAIN_REMARK(I)
            DB_FIXMTA2.REMARK = RD_SSSMAIN_REMARK(I)
            '2007/12/14 add-end T.KAWAMUKAI

            'Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA.CTLCD, BtrNormal)
            Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA2.CTLCD, BtrNormal)
            If DBSTAT = 0 Then
                ' === 20081002 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                'strOPEID = DB_FIXMTA.OPEID '�ŏI��Ǝ҃R�[�h
                'strCLTID = DB_FIXMTA.CLTID '�N���C�A���g�h�c
                'strUOPEID = DB_FIXMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                'strUCLTID = DB_FIXMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                '' === 20081002 === INSERT E - RISE)Izumi
                'strWRTDT = DB_FIXMTA.WRTDT '�X�V���t
                'strWRTTM = DB_FIXMTA.WRTTM '�X�V����
                'strUWRTDT = DB_FIXMTA.UWRTDT '�o�b�`�X�V���t
                'strUWRTTM = DB_FIXMTA.UWRTTM '�o�b�`�X�V����
                strOPEID = DB_FIXMTA2.OPEID '�ŏI��Ǝ҃R�[�h
                strCLTID = DB_FIXMTA2.CLTID '�N���C�A���g�h�c
                strUOPEID = DB_FIXMTA2.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                strUCLTID = DB_FIXMTA2.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                ' === 20081002 === INSERT E - RISE)Izumi
                strWRTDT = DB_FIXMTA2.WRTDT '�X�V���t
                strWRTTM = DB_FIXMTA2.WRTTM '�X�V����
                strUWRTDT = DB_FIXMTA2.UWRTDT '�o�b�`�X�V���t
                strUWRTTM = DB_FIXMTA2.UWRTTM '�o�b�`�X�V����
                '20190801 chg end

                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					'2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM FIXMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM FIXMTA"
					' === 20081002 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSQL = strSQL & " WHERE CTLCD = '" + RD_SSSMAIN_CTLCD(I) + "'"
					'���b�N����
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_FIXMTA, strSQL)
					'2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
					
					'�X�V���ԃ`�F�b�N
					' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = FIXMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20081002 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						' === 20081002 === INSERT S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
						Call DB_Unlock(DBN_FIXMTA)
						Call DB_AbortTransaction()
						' === 20081002 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgFIXMT51_E_DEL)
						'2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
						' === 20081002 === DELETE S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
						'                            Call DB_Unlock(DBN_FIXMTA)
						'                            Call DB_AbortTransaction
						' === 20081002 === DELETE E - RISE)Izumi
						HaitaUpdFlg = 1
						'2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "�ǉ�" Then
						' === 20081002 === INSERT S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
						Call DB_Unlock(DBN_FIXMTA)
						Call DB_AbortTransaction()
						' === 20081002 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgFIXMT51_E_UPD)
						' === 20081002 === DELETE S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
						''2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
						'                            Call DB_Unlock(DBN_FIXMTA)
						'                            Call DB_AbortTransaction
						''2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
						' === 20081002 === DELETE E - RISE)Izumi
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
						HaitaUpdFlg = 0
						strSQL = ""
						' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
						'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM FIXMTA"
						strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM FIXMTA"
						' === 20081002 === UPDATE E - RISE)Izumi
						'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						strSQL = strSQL & " WHERE CTLCD = '" + RD_SSSMAIN_CTLCD(I) + "'"
						'���b�N����
						strSQL = strSQL & "          FOR UPDATE"
						Call DB_GetSQL2(DBN_FIXMTA, strSQL)
						'2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
						'�X�V���ԃ`�F�b�N
						' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
						'                    bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
						bolRet = FIXMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
						' === 20081002 === UPDATE E - RISE)Izumi
						If bolRet = False Then
							' === 20081002 === INSERT S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
							Call DB_Unlock(DBN_FIXMTA)
							Call DB_AbortTransaction()
							' === 20081002 === INSERT E - RISE)Izumi
							intRet = MF_DspMsg(gc_strMsgFIXMT51_E_UPD)
							'2008/07/10 START ADD FNAP)YAMANE �A���[���F�r��-56
							' === 20081002 === DELETE S - RISE)Izumi  ���b�Z�[�W��\������O�Ƀ��[���o�b�N���s��
							'                            Call DB_Unlock(DBN_FIXMTA)
							'                            Call DB_AbortTransaction
							' === 20081002 === DELETE E - RISE)Izumi
							HaitaUpdFlg = 1
							'2008/07/10 E.N.D ADD FNAP)YAMANE �A���[���F�r��-56
							Exit Sub
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/13 add-end T.KAWAMUKAI
		
		'2008/07/10 START DEL FNAP)YAMANE �A���[���F�r��-56
		'��̃`�F�b�N���[�v�̊J�n���_�Ő錾����悤�ɕύX
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/10 E.N.D DEL FNAP)YAMANE �A���[���F�r��-56
		I = 0
		Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190801 chg start
            '         DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(I)
            '         'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '         DB_FIXMTA.CTLNM = RD_SSSMAIN_CTLNM(I)
            ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FIXVAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'DB_FIXMTA.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_REMARK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'DB_FIXMTA.REMARK = RD_SSSMAIN_REMARK(I)
            '         Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA.CTLCD, BtrLock)

            DB_FIXMTA2.CTLCD = RD_SSSMAIN_CTLCD(I)
            DB_FIXMTA2.CTLNM = RD_SSSMAIN_CTLNM(I)
            DB_FIXMTA2.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            DB_FIXMTA2.REMARK = RD_SSSMAIN_REMARK(I)
            Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA2.CTLCD, BtrLock)
            '20190801 chg end
            If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "�폜" Then
                    '20190801 chg start
                    'DB_FIXMTA.DATKB = "9"
                    'DB_FIXMTA.WRTTM = wkWRTTM
                    'DB_FIXMTA.WRTDT = wkWRTDT
                    'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                    'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                    'DB_FIXMTA.UWRTTM = wkWRTTM
                    'DB_FIXMTA.UWRTDT = wkWRTDT
                    'DB_FIXMTA.PGID = "FIXMT51"
                    DB_FIXMTA2.DATKB = "9"
                    DB_FIXMTA2.WRTTM = wkWRTTM
                    DB_FIXMTA2.WRTDT = wkWRTDT
                    DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                    DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                    DB_FIXMTA2.UWRTTM = wkWRTTM
                    DB_FIXMTA2.UWRTDT = wkWRTDT
                    DB_FIXMTA2.PGID = "FIXMT51"
                    Call DB_Update(DBN_FIXMTA, 1)
                Else
                    Call Mfil_FromSCR(I)
                    'DB_FIXMTA.DATKB = "1"
                    'DB_FIXMTA.WRTTM = wkWRTTM
                    'DB_FIXMTA.WRTDT = wkWRTDT
                    'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                    'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                    'DB_FIXMTA.UWRTTM = wkWRTTM
                    'DB_FIXMTA.UWRTDT = wkWRTDT
                    'DB_FIXMTA.PGID = "FIXMT51"
                    DB_FIXMTA2.DATKB = "1"
                    DB_FIXMTA2.WRTTM = wkWRTTM
                    DB_FIXMTA2.WRTDT = wkWRTDT
                    DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                    DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                    DB_FIXMTA2.UWRTTM = wkWRTTM
                    DB_FIXMTA2.UWRTDT = wkWRTDT
                    DB_FIXMTA2.PGID = "FIXMT51"
                    Call DB_Update(DBN_FIXMTA, 1)
				End If
			Else
				Call FIXMTA_RClear()
				Call Mfil_FromSCR(I)
                'DB_FIXMTA.DATKB = "1"
                'DB_FIXMTA.WRTFSTTM = wkWRTTM
                'DB_FIXMTA.WRTFSTDT = wkWRTDT
                'DB_FIXMTA.FOPEID = SSS_OPEID.Value
                'DB_FIXMTA.FCLTID = SSS_CLTID.Value
                'DB_FIXMTA.WRTTM = wkWRTTM
                'DB_FIXMTA.WRTDT = wkWRTDT
                'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                'DB_FIXMTA.UWRTTM = wkWRTTM
                'DB_FIXMTA.UWRTDT = wkWRTDT
                'DB_FIXMTA.PGID = "FIXMT51"
                DB_FIXMTA2.DATKB = "1"
                DB_FIXMTA2.WRTFSTTM = wkWRTTM
                DB_FIXMTA2.WRTFSTDT = wkWRTDT
                DB_FIXMTA2.FOPEID = SSS_OPEID.Value
                DB_FIXMTA2.FCLTID = SSS_CLTID.Value
                DB_FIXMTA2.WRTTM = wkWRTTM
                DB_FIXMTA2.WRTDT = wkWRTDT
                DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                DB_FIXMTA2.UWRTTM = wkWRTTM
                DB_FIXMTA2.UWRTDT = wkWRTDT
                DB_FIXMTA2.PGID = "FIXMT51"
                '20190801 chg end
                Call DB_Insert(DBN_FIXMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_FIXMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function FIXMT51_MF_Chk_UWRTDTTM_T
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
	'   ���l�F  �����׋y�сA�Œ�l�}�X�^�o�^�p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_Chk_UWRTDTTM_T_err
		
		FIXMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_FIXMT_A_inf(pin_intIDX).OPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).CLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).UOPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).UCLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTTM) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_FIXMT_A_inf(pin_intIDX).OPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).CLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).UOPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).UCLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTTM) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo FIXMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		FIXMT51_MF_Chk_UWRTDTTM_T = True
		
FIXMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
FIXMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo FIXMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function FIXMT51_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_UpDown_UWRTDTTM_err
		
		FIXMT51_MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_FIXMT_A_inf(pin_intIDX).OPEID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_FIXMT_A_inf(pin_intIDX).CLTID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_FIXMT_A_inf(pin_intIDX).UOPEID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_FIXMT_A_inf(pin_intIDX).UCLTID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_FIXMT_A_inf(pin_intIDX).WRTDT = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_FIXMT_A_inf(pin_intIDX).WRTTM = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_FIXMT_A_inf(pin_intIDX).UWRTDT = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_FIXMT_A_inf(pin_intIDX).UWRTTM = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		FIXMT51_MF_UpDown_UWRTDTTM = True
		
FIXMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo FIXMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function FIXMT51_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_SaveRestore_UWRTDTTM_err
		
		FIXMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_FIXMT_inf.OPEID = M_FIXMT_A_inf(pin_intIDX).OPEID
			M_FIXMT_inf.CLTID = M_FIXMT_A_inf(pin_intIDX).CLTID
			M_FIXMT_inf.UOPEID = M_FIXMT_A_inf(pin_intIDX).UOPEID
			M_FIXMT_inf.UCLTID = M_FIXMT_A_inf(pin_intIDX).UCLTID
			M_FIXMT_inf.WRTDT = M_FIXMT_A_inf(pin_intIDX).WRTDT
			M_FIXMT_inf.WRTTM = M_FIXMT_A_inf(pin_intIDX).WRTTM
			M_FIXMT_inf.UWRTDT = M_FIXMT_A_inf(pin_intIDX).UWRTDT
			M_FIXMT_inf.UWRTTM = M_FIXMT_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_FIXMT_A_inf(pin_intIDX).OPEID = M_FIXMT_inf.OPEID
			M_FIXMT_A_inf(pin_intIDX).CLTID = M_FIXMT_inf.CLTID
			M_FIXMT_A_inf(pin_intIDX).UOPEID = M_FIXMT_inf.UOPEID
			M_FIXMT_A_inf(pin_intIDX).UCLTID = M_FIXMT_inf.UCLTID
			M_FIXMT_A_inf(pin_intIDX).WRTDT = M_FIXMT_inf.WRTDT
			M_FIXMT_A_inf(pin_intIDX).WRTTM = M_FIXMT_inf.WRTTM
			M_FIXMT_A_inf(pin_intIDX).UWRTDT = M_FIXMT_inf.UWRTDT
			M_FIXMT_A_inf(pin_intIDX).UWRTTM = M_FIXMT_inf.UWRTTM
		End If
		
		FIXMT51_MF_SaveRestore_UWRTDTTM = True
		
FIXMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo FIXMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function FIXMT51_MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_Clear_UWRTDTTM_err
		
		FIXMT51_MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_FIXMT_A_inf(pin_intIDX).OPEID = ""
		M_FIXMT_A_inf(pin_intIDX).CLTID = ""
		M_FIXMT_A_inf(pin_intIDX).UOPEID = ""
		M_FIXMT_A_inf(pin_intIDX).UCLTID = ""
		M_FIXMT_A_inf(pin_intIDX).WRTDT = ""
		M_FIXMT_A_inf(pin_intIDX).WRTTM = ""
		M_FIXMT_A_inf(pin_intIDX).UWRTDT = ""
		M_FIXMT_A_inf(pin_intIDX).UWRTTM = ""
		
		FIXMT51_MF_Clear_UWRTDTTM = True
		
FIXMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_Clear_UWRTDTTM_err: 
		GoTo FIXMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
End Module