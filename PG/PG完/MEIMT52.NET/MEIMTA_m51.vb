Option Strict Off
Option Explicit On
Module MEIMTA_M51
    '
    ' �X���b�g��        : ���C���t�@�C���X�V�X���b�g
    ' ���j�b�g��        : MEIMTA.M51
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/06/08
    ' �g�p�v���O������  : MEIMT51
    '

    ' === 20080916 === INSERT S - RISE)Izumi
    '�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
    Structure M_TYPE_MEIMT
        '20190902 CHG START
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UOPEID() As Char '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public UCLTID() As Char '�N���C�A���g�h�c�i�o�b�`�j
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
        ''UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        '<VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public OPEID As String '�ŏI��Ǝ҃R�[�h
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public CLTID As String '�N���C�A���g�h�c
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public UCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(����)        9(06)
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(���t)        YYYY/MM/DD
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public UWRTTM As String '��ѽ����(����)        9(06)
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UWRTDT As String '��ѽ����(���t)        YYYY/MM/DD
        '20190902 CHG END
    End Structure
    Public M_MEIMT_inf As M_TYPE_MEIMT
	Public M_MEIMT_A_inf() As M_TYPE_MEIMT
	' === 20080916 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim updkb As String
		Dim WRTTM, WRTDT As String
		
		'2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080916 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
		Dim strOPEID As String '�ŏI��Ǝ҃R�[�h
		Dim strCLTID As String '�N���C�A���g�h�c
		Dim strUOPEID As String '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		Dim strUCLTID As String '�N���C�A���g�h�c�i�o�b�`�j
		' === 20080916 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '�X�V���t
		Dim strWRTTM As String '�X�V����
		Dim strUWRTDT As String '�o�b�`�X�V���t
		Dim strUWRTTM As String '�o�b�`�X�V����
		'2007/12/18 add-end T.KAWAMUKAI
		
		
		'�X�V�����`�F�b�N
		If gs_UPDAUTH = "9" Then
			Call MsgBox("�X�V����������܂���B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57
		
		'2007/12/18 add-str T.KAWAMUKAI �����O�ɍX�V���ԃ`�F�b�N������
		'�X�V���ԃ`�F�b�N�i��ʂɕ\������Ă��閾�ו��j
		I = 0
        Dim strSQL As String
        '20190828 ADD START
        Dim pWhere As String = ""
        Dim dt As DataTable = Nothing
        '20190828 ADD END

        Do While I < PP_SSSMAIN.LastDe
			DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
			DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(I)

            '20190828 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrNormal)
            pWhere = "WHERE KEYCD = '" & DB_MEIMTA.KEYCD & "'"
            pWhere = pWhere & "AND MEICDA = '" & DB_MEIMTA.MEICDA & "'"
            pWhere = pWhere & "AND MEICDB = '" & DB_MEIMTA.MEICDB & "'"
            GetRowsCommon(DBN_MEIMTA, pWhere)
            '20190828 CHG END

            If DBSTAT = 0 Then
                ' === 20080916 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                strOPEID = DB_MEIMTA.OPEID '�ŏI��Ǝ҃R�[�h
                strCLTID = DB_MEIMTA.CLTID '�N���C�A���g�h�c
                strUOPEID = DB_MEIMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                strUCLTID = DB_MEIMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                ' === 20080916 === INSERT E - RISE)Izumi
                strWRTDT = DB_MEIMTA.WRTDT '�X�V���t
                strWRTTM = DB_MEIMTA.WRTTM '�X�V����
                strUWRTDT = DB_MEIMTA.UWRTDT '�o�b�`�X�V���t
                strUWRTTM = DB_MEIMTA.UWRTTM '�o�b�`�X�V����

                'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "�폜" Then

                    '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
                    HaitaUpdFlg = 0
                    strSQL = ""
                    ' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                    '                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM MEIMTA"
                    strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM MEIMTA"
                    ' === 20080916 === UPDATE E - RISE)Izumi
                    strSQL = strSQL & " WHERE KEYCD = '" & DB_MEIMTB.KEYCD & "'"
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strSQL = strSQL & " AND MEICDA = '" + RD_SSSMAIN_MEICDA(I) + "'"
                    'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    strSQL = strSQL & " AND MEICDB = '" + RD_SSSMAIN_MEICDB(I) + "'"
                    '���b�N����
                    strSQL = strSQL & "          FOR UPDATE"

                    '20190828 CHG START
                    'Call DB_GetSQL2(DBN_MEIMTA, strSQL)
                    dt = DB_GetTable(strSQL)
                    If Not dt Is Nothing Then
                        DB_MEIMTA.OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                        DB_MEIMTA.CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                        DB_MEIMTA.UOPEID = DB_NullReplace(dt.Rows(0)("UOPEID"), "")
                        DB_MEIMTA.UCLTID = DB_NullReplace(dt.Rows(0)("UCLTID"), "")
                        DB_MEIMTA.WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                        DB_MEIMTA.WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                        DB_MEIMTA.UWRTDT = DB_NullReplace(dt.Rows(0)("UWRTDT"), "")
                        DB_MEIMTA.UWRTTM = DB_NullReplace(dt.Rows(0)("UWRTTM"), "")
                    End If
                    '20190828 CHG END

                    ' === 20080916 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                    strOPEID = DB_MEIMTA.OPEID '�ŏI��Ǝ҃R�[�h
                    strCLTID = DB_MEIMTA.CLTID '�N���C�A���g�h�c
                    strUOPEID = DB_MEIMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                    strUCLTID = DB_MEIMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                    ' === 20080916 === INSERT E - RISE)Izumi
                    strWRTDT = DB_MEIMTA.WRTDT '�X�V���t
                    strWRTTM = DB_MEIMTA.WRTTM '�X�V����
                    strUWRTDT = DB_MEIMTA.UWRTDT '�o�b�`�X�V���t
                    strUWRTTM = DB_MEIMTA.UWRTTM '�o�b�`�X�V����
                    '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57

                    '�X�V���ԃ`�F�b�N
                    ' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                    '                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    bolRet = MEIMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    ' === 20080916 === UPDATE E - RISE)Izumi
                    If bolRet = False Then
                        intRet = MF_DspMsg(gc_strMsgMEIMT52_E_DEL)
                        '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
                        Call DB_Unlock(DBN_MEIMTA)
                        Call DB_AbortTransaction()
                        HaitaUpdFlg = 1
                        '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57
                        Exit Sub
                    End If

                Else
                    If updkb = "�ǉ�" Then
                        intRet = MF_DspMsg(gc_strMsgMEIMT52_E_UPD)
                        '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
                        Call DB_Unlock(DBN_MEIMTA)
                        Call DB_AbortTransaction()
                        '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57
                        Exit Sub
                    Else
                        '2007/12/21 add-str T.KAWAMUKAI
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DSPORD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DSPORD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        If Trim(RD_SSSMAIN_MEINMA(I)) <> Trim(RD_SSSMAIN_V_MEINMA(I)) Or Trim(RD_SSSMAIN_MEINMB(I)) <> Trim(RD_SSSMAIN_V_MEINMB(I)) Or Trim(RD_SSSMAIN_MEINMC(I)) <> Trim(RD_SSSMAIN_V_MEINMC(I)) Or Trim(RD_SSSMAIN_MEISUA(I)) <> Trim(RD_SSSMAIN_V_MEISUA(I)) Or Trim(RD_SSSMAIN_MEISUB(I)) <> Trim(RD_SSSMAIN_V_MEISUB(I)) Or Trim(RD_SSSMAIN_MEISUC(I)) <> Trim(RD_SSSMAIN_V_MEISUC(I)) Or Trim(RD_SSSMAIN_MEIKBA(I)) <> Trim(RD_SSSMAIN_V_MEIKBA(I)) Or Trim(RD_SSSMAIN_MEIKBB(I)) <> Trim(RD_SSSMAIN_V_MEIKBB(I)) Or Trim(RD_SSSMAIN_MEIKBC(I)) <> Trim(RD_SSSMAIN_V_MEIKBC(I)) Or Trim(RD_SSSMAIN_DSPORD(I)) <> Trim(RD_SSSMAIN_V_DSPORD(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
                            '2007/12/21 add-end T.KAWAMUKAI
                            '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
                            HaitaUpdFlg = 0
                            strSQL = ""
                            ' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                            '                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM MEIMTA"
                            strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM MEIMTA"
                            ' === 20080916 === UPDATE E - RISE)Izumi
                            strSQL = strSQL & " WHERE KEYCD = '" & DB_MEIMTB.KEYCD & "'"
                            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            strSQL = strSQL & " AND MEICDA = '" + RD_SSSMAIN_MEICDA(I) + "'"
                            'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                            strSQL = strSQL & " AND MEICDB = '" + RD_SSSMAIN_MEICDB(I) + "'"
                            '���b�N����
                            strSQL = strSQL & "          FOR UPDATE"

                            '20190828 CHG START
                            'Call DB_GetSQL2(DBN_MEIMTA, strSQL)
                            dt = DB_GetTable(strSQL)
                            If Not dt Is Nothing Then
                                DB_MEIMTA.OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                                DB_MEIMTA.CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                                DB_MEIMTA.UOPEID = DB_NullReplace(dt.Rows(0)("UOPEID"), "")
                                DB_MEIMTA.UCLTID = DB_NullReplace(dt.Rows(0)("UCLTID"), "")
                                DB_MEIMTA.WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                                DB_MEIMTA.WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                                DB_MEIMTA.UWRTDT = DB_NullReplace(dt.Rows(0)("UWRTDT"), "")
                                DB_MEIMTA.UWRTTM = DB_NullReplace(dt.Rows(0)("UWRTTM"), "")
                            End If
                            '20190828 CHG END

                            ' === 20080916 === INSERT S - RISE)Izumi �`�F�b�N���ڒǉ�
                            strOPEID = DB_MEIMTA.OPEID '�ŏI��Ǝ҃R�[�h
                            strCLTID = DB_MEIMTA.CLTID '�N���C�A���g�h�c
                            strUOPEID = DB_MEIMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
                            strUCLTID = DB_MEIMTA.UCLTID '�N���C�A���g�h�c�i�o�b�`�j
                            ' === 20080916 === INSERT E - RISE)Izumi
                            strWRTDT = DB_MEIMTA.WRTDT '�X�V���t
                            strWRTTM = DB_MEIMTA.WRTTM '�X�V����
                            strUWRTDT = DB_MEIMTA.UWRTDT '�o�b�`�X�V���t
                            strUWRTTM = DB_MEIMTA.UWRTTM '�o�b�`�X�V����
                            '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57

                            '�X�V���ԃ`�F�b�N
                            ' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
                            '                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            bolRet = MEIMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            ' === 20080916 === UPDATE E - RISE)Izumi
                            If bolRet = False Then
                                intRet = MF_DspMsg(gc_strMsgMEIMT52_E_UPD)
                                '2008/07/11 START ADD FNAP)YAMANE �A���[���F�r��-57
                                Call DB_Unlock(DBN_MEIMTA)
                                Call DB_AbortTransaction()
                                HaitaUpdFlg = 1
                                '2008/07/11 E.N.D ADD FNAP)YAMANE �A���[���F�r��-57
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            I = I + 1
		Loop 
		'2007/12/18 add-end T.KAWAMUKAI
		
		'
		I = 0
		WRTTM = VB6.Format(Now, "hhmmss")
		WRTDT = VB6.Format(Now, "YYYYMMDD")

        '2008/07/11 START DEL FNAP)YAMANE �A���[���F�r��-57
        '�㕔�̃`�F�b�N�̃��[�v�̊J�n���ɐ錾����悤�ɕύX
        '    Call DB_BeginTransaction(BTR_Exclude)
        '2008/07/11 E.N.D DEL FNAP)YAMANE �A���[���F�r��-57

        '20190828 ADD START
        Dim updSQL As String = ""
        '20190828 ADD END

        Do While I < PP_SSSMAIN.LastDe
			
			DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
			DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
			''''    DB_MEIMTA.MEICDA = Trim$(RD_SSSMAIN_MEICDA(I))
			''''    DB_MEIMTA.MEICDB = Trim$(RD_SSSMAIN_MEICDB(I))
			''''    Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrLock)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(I)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(I)
            '2007/10/03 FKS)minamoto CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA, BtrLock)
            '20190828 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrLock)
            pWhere = "WHERE KEYCD = '" & DB_MEIMTA.KEYCD & "'"
            pWhere = pWhere & "AND MEICDA = '" & DB_MEIMTA.MEICDA & "'"
            pWhere = pWhere & "AND MEICDB = '" & DB_MEIMTA.MEICDB & "'"
            GetRowsCommon(DBN_MEIMTA, pWhere)
            '20190828 CHG END

            '2007/10/03 FKS)minamoto CHG END
            If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UPDKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "�폜" Then
					DB_MEIMTA.DATKB = "9"
					DB_MEIMTA.RELFL = "1" '" "
					DB_MEIMTA.OPEID = SSS_OPEID.Value
					DB_MEIMTA.CLTID = SSS_CLTID.Value
					DB_MEIMTA.WRTTM = WRTTM
					DB_MEIMTA.WRTDT = WRTDT
					DB_MEIMTA.UOPEID = SSS_OPEID.Value
					DB_MEIMTA.UCLTID = SSS_CLTID.Value
					DB_MEIMTA.UWRTTM = WRTTM
					DB_MEIMTA.UWRTDT = WRTDT
                    DB_MEIMTA.PGID = SSS_PrgId

                    '20190828 CHG START
                    'Call DB_Update(DBN_MEIMTA, 1)
                    updSQL = ""
                    updSQL = updSQL & " UPDATE "
                    updSQL = updSQL & "        MEIMTA "
                    updSQL = updSQL & " SET "

                    updSQL = updSQL & " DATKB		=	'" & DB_MEIMTA.DATKB & "' "
                    updSQL = updSQL & ",KEYCD		=	'" & DB_MEIMTA.KEYCD & "' "
                    updSQL = updSQL & ",MEIKMKNM	=	'" & DB_MEIMTA.MEIKMKNM & "' "
                    updSQL = updSQL & ",MEICDA		=	'" & DB_MEIMTA.MEICDA & "' "
                    updSQL = updSQL & ",MEICDB		=	'" & DB_MEIMTA.MEICDB & "' "
                    updSQL = updSQL & ",MEINMA		=	'" & DB_MEIMTA.MEINMA & "' "
                    updSQL = updSQL & ",MEINMB		=	'" & DB_MEIMTA.MEINMB & "' "
                    updSQL = updSQL & ",MEINMC		=	'" & DB_MEIMTA.MEINMC & "' "
                    updSQL = updSQL & ",MEISUA		=	 " & DB_MEIMTA.MEISUA
                    updSQL = updSQL & ",MEISUB		=	 " & DB_MEIMTA.MEISUB
                    updSQL = updSQL & ",MEISUC		=	 " & DB_MEIMTA.MEISUC
                    updSQL = updSQL & ",MEIKBA		=	'" & DB_MEIMTA.MEIKBA & "' "
                    updSQL = updSQL & ",MEIKBB		=	'" & DB_MEIMTA.MEIKBB & "' "
                    updSQL = updSQL & ",MEIKBC		=	'" & DB_MEIMTA.MEIKBC & "' "
                    updSQL = updSQL & ",DSPORD		=	'" & DB_MEIMTA.DSPORD & "' "
                    updSQL = updSQL & ",RELFL		=	'" & DB_MEIMTA.RELFL & "' "
                    updSQL = updSQL & ",FOPEID		=	'" & DB_MEIMTA.FOPEID & "' "
                    updSQL = updSQL & ",FCLTID		=	'" & DB_MEIMTA.FCLTID & "' "
                    updSQL = updSQL & ",WRTFSTTM	=	'" & DB_MEIMTA.WRTFSTTM & "' "
                    updSQL = updSQL & ",WRTFSTDT	=	'" & DB_MEIMTA.WRTFSTDT & "' "
                    updSQL = updSQL & ",OPEID		=	'" & DB_MEIMTA.OPEID & "' "
                    updSQL = updSQL & ",CLTID		=	'" & DB_MEIMTA.CLTID & "' "
                    updSQL = updSQL & ",WRTTM		=	'" & DB_MEIMTA.WRTTM & "' "
                    updSQL = updSQL & ",WRTDT		=	'" & DB_MEIMTA.WRTDT & "' "
                    updSQL = updSQL & ",UOPEID		=	'" & DB_MEIMTA.UOPEID & "' "
                    updSQL = updSQL & ",UCLTID		=	'" & DB_MEIMTA.UCLTID & "' "
                    updSQL = updSQL & ",UWRTTM		=	'" & DB_MEIMTA.UWRTTM & "' "
                    updSQL = updSQL & ",UWRTDT		=	'" & DB_MEIMTA.UWRTDT & "' "
                    updSQL = updSQL & ",PGID		=	'" & DB_MEIMTA.PGID & "' "

                    updSQL = updSQL & "  WHERE "
                    updSQL = updSQL & "        KEYCD     = '" & DB_MEIMTA.KEYCD & "' "
                    updSQL = updSQL & "    AND MEICDA    = '" & DB_MEIMTA.MEICDA & "' "
                    updSQL = updSQL & "    AND MEICDB    = '" & DB_MEIMTA.MEICDB & "' "

                    DB_Execute(updSQL)
                    '20190828 CHG END
                Else
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DATKB(I) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_DSPORD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DSPORD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEISUA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_V_MEINMA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If Trim(RD_SSSMAIN_MEINMA(I)) <> Trim(RD_SSSMAIN_V_MEINMA(I)) Or Trim(RD_SSSMAIN_MEINMB(I)) <> Trim(RD_SSSMAIN_V_MEINMB(I)) Or Trim(RD_SSSMAIN_MEINMC(I)) <> Trim(RD_SSSMAIN_V_MEINMC(I)) Or Trim(RD_SSSMAIN_MEISUA(I)) <> Trim(RD_SSSMAIN_V_MEISUA(I)) Or Trim(RD_SSSMAIN_MEISUB(I)) <> Trim(RD_SSSMAIN_V_MEISUB(I)) Or Trim(RD_SSSMAIN_MEISUC(I)) <> Trim(RD_SSSMAIN_V_MEISUC(I)) Or Trim(RD_SSSMAIN_MEIKBA(I)) <> Trim(RD_SSSMAIN_V_MEIKBA(I)) Or Trim(RD_SSSMAIN_MEIKBB(I)) <> Trim(RD_SSSMAIN_V_MEIKBB(I)) Or Trim(RD_SSSMAIN_MEIKBC(I)) <> Trim(RD_SSSMAIN_V_MEIKBC(I)) Or Trim(RD_SSSMAIN_DSPORD(I)) <> Trim(RD_SSSMAIN_V_DSPORD(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_MEIMTA.DATKB = "1"
						DB_MEIMTA.RELFL = "1" '" "
						DB_MEIMTA.WRTTM = WRTTM
						DB_MEIMTA.WRTDT = WRTDT
						DB_MEIMTA.UOPEID = SSS_OPEID.Value
						DB_MEIMTA.UCLTID = SSS_CLTID.Value
						DB_MEIMTA.UWRTTM = WRTTM
						DB_MEIMTA.UWRTDT = WRTDT
						DB_MEIMTA.PGID = SSS_PrgId

                        '20190828 CHG START
                        'Call DB_Update(DBN_MEIMTA, 1)
                        updSQL = ""
                        updSQL = updSQL & " UPDATE "
                        updSQL = updSQL & "        MEIMTA "
                        updSQL = updSQL & " SET "

                        updSQL = updSQL & " DATKB		=	'" & DB_MEIMTA.DATKB & "' "
                        updSQL = updSQL & ",KEYCD		=	'" & DB_MEIMTA.KEYCD & "' "
                        updSQL = updSQL & ",MEIKMKNM	=	'" & DB_MEIMTA.MEIKMKNM & "' "
                        updSQL = updSQL & ",MEICDA		=	'" & DB_MEIMTA.MEICDA & "' "
                        updSQL = updSQL & ",MEICDB		=	'" & DB_MEIMTA.MEICDB & "' "
                        updSQL = updSQL & ",MEINMA		=	'" & DB_MEIMTA.MEINMA & "' "
                        updSQL = updSQL & ",MEINMB		=	'" & DB_MEIMTA.MEINMB & "' "
                        updSQL = updSQL & ",MEINMC		=	'" & DB_MEIMTA.MEINMC & "' "
                        updSQL = updSQL & ",MEISUA		=	 " & DB_MEIMTA.MEISUA
                        updSQL = updSQL & ",MEISUB		=	 " & DB_MEIMTA.MEISUB
                        updSQL = updSQL & ",MEISUC		=	 " & DB_MEIMTA.MEISUC
                        updSQL = updSQL & ",MEIKBA		=	'" & DB_MEIMTA.MEIKBA & "' "
                        updSQL = updSQL & ",MEIKBB		=	'" & DB_MEIMTA.MEIKBB & "' "
                        updSQL = updSQL & ",MEIKBC		=	'" & DB_MEIMTA.MEIKBC & "' "
                        updSQL = updSQL & ",DSPORD		=	'" & DB_MEIMTA.DSPORD & "' "
                        updSQL = updSQL & ",RELFL		=	'" & DB_MEIMTA.RELFL & "' "
                        updSQL = updSQL & ",FOPEID		=	'" & DB_MEIMTA.FOPEID & "' "
                        updSQL = updSQL & ",FCLTID		=	'" & DB_MEIMTA.FCLTID & "' "
                        updSQL = updSQL & ",WRTFSTTM	=	'" & DB_MEIMTA.WRTFSTTM & "' "
                        updSQL = updSQL & ",WRTFSTDT	=	'" & DB_MEIMTA.WRTFSTDT & "' "
                        updSQL = updSQL & ",OPEID		=	'" & DB_MEIMTA.OPEID & "' "
                        updSQL = updSQL & ",CLTID		=	'" & DB_MEIMTA.CLTID & "' "
                        updSQL = updSQL & ",WRTTM		=	'" & DB_MEIMTA.WRTTM & "' "
                        updSQL = updSQL & ",WRTDT		=	'" & DB_MEIMTA.WRTDT & "' "
                        updSQL = updSQL & ",UOPEID		=	'" & DB_MEIMTA.UOPEID & "' "
                        updSQL = updSQL & ",UCLTID		=	'" & DB_MEIMTA.UCLTID & "' "
                        updSQL = updSQL & ",UWRTTM		=	'" & DB_MEIMTA.UWRTTM & "' "
                        updSQL = updSQL & ",UWRTDT		=	'" & DB_MEIMTA.UWRTDT & "' "
                        updSQL = updSQL & ",PGID		=	'" & DB_MEIMTA.PGID & "' "

                        updSQL = updSQL & "  WHERE "
                        updSQL = updSQL & "        KEYCD     = '" & DB_MEIMTA.KEYCD & "' "
                        updSQL = updSQL & "    AND MEICDA    = '" & DB_MEIMTA.MEICDA & "' "
                        updSQL = updSQL & "    AND MEICDB    = '" & DB_MEIMTA.MEICDB & "' "

                        DB_Execute(updSQL)
                        '20190828 CHG END

                    End If '2006.11.07
				End If
			Else
				Call Mfil_FromSCR(I)
				DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
				DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
				DB_MEIMTA.DATKB = "1"
				DB_MEIMTA.RELFL = "1" '" "
				DB_MEIMTA.WRTFSTTM = WRTTM
				DB_MEIMTA.WRTFSTDT = WRTDT
				DB_MEIMTA.FOPEID = SSS_OPEID.Value
				DB_MEIMTA.FCLTID = SSS_CLTID.Value
				DB_MEIMTA.WRTFSTTM = WRTTM
				DB_MEIMTA.WRTFSTDT = WRTDT
				DB_MEIMTA.WRTTM = WRTTM
				DB_MEIMTA.WRTDT = WRTDT
				DB_MEIMTA.UOPEID = SSS_OPEID.Value
				DB_MEIMTA.UCLTID = SSS_CLTID.Value
				DB_MEIMTA.UWRTTM = WRTTM
				DB_MEIMTA.UWRTDT = WRTDT
				DB_MEIMTA.PGID = SSS_PrgId

                '20190828 CHG START
                'Call DB_Insert(DBN_MEIMTA, 1)
                updSQL = ""
                updSQL = updSQL & " '" & DB_MEIMTA.DATKB & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.KEYCD & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEIKMKNM & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEICDA & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEICDB & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEINMA & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEINMB & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEINMC & "' "
                updSQL = updSQL & ", " & DB_MEIMTA.MEISUA
                updSQL = updSQL & ", " & DB_MEIMTA.MEISUB
                updSQL = updSQL & ", " & DB_MEIMTA.MEISUC
                updSQL = updSQL & ",'" & DB_MEIMTA.MEIKBA & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEIKBB & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.MEIKBC & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.DSPORD & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.RELFL & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.FOPEID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.FCLTID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.WRTFSTTM & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.WRTFSTDT & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.OPEID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.CLTID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.WRTTM & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.WRTDT & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.UOPEID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.UCLTID & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.UWRTTM & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.UWRTDT & "' "
                updSQL = updSQL & ",'" & DB_MEIMTA.PGID & "' "

                updSQL = DB_InsertSQL(DBN_MEIMTA, updSQL)
                DB_Execute(updSQL)
                '20190828 CHG END

            End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_MEIMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080916 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MEIMT52_MF_Chk_UWRTDTTM_T
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
	Public Function MEIMT52_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo MEIMT52_MF_Chk_UWRTDTTM_T_err
		
		MEIMT52_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_MEIMT_A_inf(pin_intIDX).OPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).CLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).UOPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).UCLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTTM) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MEIMT_A_inf(pin_intIDX).OPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).CLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).UOPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).UCLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTTM) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo MEIMT52_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		MEIMT52_MF_Chk_UWRTDTTM_T = True
		
MEIMT52_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
MEIMT52_MF_Chk_UWRTDTTM_T_err: 
		GoTo MEIMT52_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080916 === INSERT E - RISE)Izumi
	
	'20080925 ADD START RISE)Tanimura '�r������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MEIMT52_MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MEIMT52_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo MEIMT52_MF_UpDown_UWRTDTTM_err
		
		MEIMT52_MF_UpDown_UWRTDTTM = False
		
		' �X�V���ԁ@�z��ړ�
		M_MEIMT_A_inf(pin_intIDX).OPEID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_MEIMT_A_inf(pin_intIDX).CLTID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_MEIMT_A_inf(pin_intIDX).UOPEID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_MEIMT_A_inf(pin_intIDX).UCLTID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_MEIMT_A_inf(pin_intIDX).WRTDT = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_MEIMT_A_inf(pin_intIDX).WRTTM = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_MEIMT_A_inf(pin_intIDX).UWRTDT = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_MEIMT_A_inf(pin_intIDX).UWRTTM = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		MEIMT52_MF_UpDown_UWRTDTTM = True
		
MEIMT52_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
MEIMT52_MF_UpDown_UWRTDTTM_err: 
		GoTo MEIMT52_MF_UpDown_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MEIMT52_MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MEIMT52_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo MEIMT52_MF_SaveRestore_UWRTDTTM_err
		
		MEIMT52_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			' �ޔ��E��������
			M_MEIMT_inf.OPEID = M_MEIMT_A_inf(pin_intIDX).OPEID
			M_MEIMT_inf.CLTID = M_MEIMT_A_inf(pin_intIDX).CLTID
			M_MEIMT_inf.UOPEID = M_MEIMT_A_inf(pin_intIDX).UOPEID
			M_MEIMT_inf.UCLTID = M_MEIMT_A_inf(pin_intIDX).UCLTID
			M_MEIMT_inf.WRTDT = M_MEIMT_A_inf(pin_intIDX).WRTDT
			M_MEIMT_inf.WRTTM = M_MEIMT_A_inf(pin_intIDX).WRTTM
			M_MEIMT_inf.UWRTDT = M_MEIMT_A_inf(pin_intIDX).UWRTDT
			M_MEIMT_inf.UWRTTM = M_MEIMT_A_inf(pin_intIDX).UWRTTM
		Else
			' ��������
			M_MEIMT_A_inf(pin_intIDX).OPEID = M_MEIMT_inf.OPEID
			M_MEIMT_A_inf(pin_intIDX).CLTID = M_MEIMT_inf.CLTID
			M_MEIMT_A_inf(pin_intIDX).UOPEID = M_MEIMT_inf.UOPEID
			M_MEIMT_A_inf(pin_intIDX).UCLTID = M_MEIMT_inf.UCLTID
			M_MEIMT_A_inf(pin_intIDX).WRTDT = M_MEIMT_inf.WRTDT
			M_MEIMT_A_inf(pin_intIDX).WRTTM = M_MEIMT_inf.WRTTM
			M_MEIMT_A_inf(pin_intIDX).UWRTDT = M_MEIMT_inf.UWRTDT
			M_MEIMT_A_inf(pin_intIDX).UWRTTM = M_MEIMT_inf.UWRTTM
		End If
		
		MEIMT52_MF_SaveRestore_UWRTDTTM = True
		
MEIMT52_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
MEIMT52_MF_SaveRestore_UWRTDTTM_err: 
		GoTo MEIMT52_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	'20080925 ADD END   RISE)Tanimura
End Module