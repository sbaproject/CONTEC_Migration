Option Strict Off
Option Explicit On
Module MEIMT52_IEV
	Public Const SSS_MAX_DB As Short = 12
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "MEIMT52"
	Public Const SSS_PrgNm As String = "���̃}�X�^�o�^�^����                      "
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_SYSTBA = 0
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 1
		DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 2
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 3
		DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBH = 4
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_TANMTA = 5
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 6
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		SSS_MFIL = DBN_MEIMTA
		'
		DBN_MEIMTB = 7
		DB_PARA(DBN_MEIMTB).tblid = "MEIMTB"
		DB_PARA(DBN_MEIMTB).DBID = "USR1"
		'
		DBN_UNYMTA = 8
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 9
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 10
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 11
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_DSPORD(De, DB_MEIMTA.DSPORD)
		Call DP_SSSMAIN_KEYCD(De, DB_MEIMTA.KEYCD)
		Call DP_SSSMAIN_MEICDA(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_MEICDB(De, DB_MEIMTA.MEICDB)
		Call DP_SSSMAIN_MEIKBA(De, DB_MEIMTA.MEIKBA)
		Call DP_SSSMAIN_MEIKBB(De, DB_MEIMTA.MEIKBB)
		Call DP_SSSMAIN_MEIKBC(De, DB_MEIMTA.MEIKBC)
		Call DP_SSSMAIN_MEIKMKNM(De, DB_MEIMTA.MEIKMKNM)
		Call DP_SSSMAIN_MEINMA(De, DB_MEIMTA.MEINMA)
		Call DP_SSSMAIN_MEINMB(De, DB_MEIMTA.MEINMB)
		Call DP_SSSMAIN_MEINMC(De, DB_MEIMTA.MEINMC)
		Call DP_SSSMAIN_MEISUA(De, DB_MEIMTA.MEISUA)
		Call DP_SSSMAIN_MEISUB(De, DB_MEIMTA.MEISUB)
		Call DP_SSSMAIN_MEISUC(De, DB_MEIMTA.MEISUC)
		
		'2007/12/18 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
		'   [����De�͉�ʏ�̍s��(0�`)]
		' === 20080916 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		'    M_MOTO_A_inf(De).WRTDT = DB_MEIMTA.WRTDT            '�X�V���t
		'    M_MOTO_A_inf(De).WRTTM = DB_MEIMTA.WRTTM            '�X�V����
		'    M_MOTO_A_inf(De).UWRTDT = DB_MEIMTA.UWRTDT          '�o�b�`�X�V���t
		'    M_MOTO_A_inf(De).UWRTTM = DB_MEIMTA.UWRTTM          '�o�b�`�X�V����
		
		M_MEIMT_A_inf(De).OPEID = DB_MEIMTA.OPEID '�ŏI��Ǝ҃R�[�h
		M_MEIMT_A_inf(De).CLTID = DB_MEIMTA.CLTID '�N���C�A���g�h�c
		M_MEIMT_A_inf(De).UOPEID = DB_MEIMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		M_MEIMT_A_inf(De).UCLTID = DB_MEIMTA.UCLTID '�N���C���g�h�c�i�o�b�`�j
		M_MEIMT_A_inf(De).WRTDT = DB_MEIMTA.WRTDT '�X�V���t
		M_MEIMT_A_inf(De).WRTTM = DB_MEIMTA.WRTTM '�X�V����
		M_MEIMT_A_inf(De).UWRTDT = DB_MEIMTA.UWRTDT '�o�b�`�X�V���t
		M_MEIMT_A_inf(De).UWRTTM = DB_MEIMTA.UWRTTM '�o�b�`�X�V����
		' === 20080916 === UPDATE E - RISE)Izumi
		'2007/12/18 add-end T.KAWAMUKAI
		
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_DSPORD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.DSPORD = RD_SSSMAIN_DSPORD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_KEYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.KEYCD = RD_SSSMAIN_KEYCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEICDB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEIKBA = RD_SSSMAIN_MEIKBA(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEIKBB = RD_SSSMAIN_MEIKBB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEIKBC = RD_SSSMAIN_MEIKBC(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKMKNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEIKMKNM = RD_SSSMAIN_MEIKMKNM(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEINMA = RD_SSSMAIN_MEINMA(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEINMB = RD_SSSMAIN_MEINMB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEINMC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEINMC = RD_SSSMAIN_MEINMC(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEISUA = RD_SSSMAIN_MEISUA(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEISUB = RD_SSSMAIN_MEISUB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEISUC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEISUC = RD_SSSMAIN_MEISUC(De)
		DB_MEIMTA.OPEID = SSS_OPEID.Value
		DB_MEIMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_MEIMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_MEIMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_MEIMTA.WRTTM = DB_ORATM
			DB_MEIMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMEIMTB(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_FRKEYCD(De, DB_MEIMTB.KEYCD)
		Call DP_SSSMAIN_FRMEINM(De, DB_MEIMTB.MEIKMKNM)
	End Sub
	
	Sub MEIMTB_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FRKEYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTB.KEYCD = RD_SSSMAIN_FRKEYCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FRMEINM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTB.MEIKMKNM = RD_SSSMAIN_FRMEINM(De)
		DB_MEIMTB.OPEID = SSS_OPEID.Value
		DB_MEIMTB.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_MEIMTB.WRTTM = VB6.Format(Now, "hhmmss")
			DB_MEIMTB.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_MEIMTB.WRTTM = DB_ORATM
			DB_MEIMTB.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_OPEID(De, DB_TANMTA.TANCD)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPEID() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TANMTA.TANCD = RD_SSSMAIN_OPEID(De)
		DB_TANMTA.OPEID = SSS_OPEID.Value
		DB_TANMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TANMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TANMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TANMTA.WRTTM = DB_ORATM
			DB_TANMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
            Case DBN_SYSTBA
                '20190826 DEL START
                '             'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '             G_LB = LSet(DB_SYSTBA)
                'Case DBN_SYSTBB
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_SYSTBB)
                'Case DBN_SYSTBC
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_SYSTBC)
                'Case DBN_SYSTBD
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_SYSTBD)
                'Case DBN_SYSTBH
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_SYSTBH)
                'Case DBN_TANMTA
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_TANMTA)
                'Case DBN_MEIMTA
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_MEIMTA)
                'Case DBN_MEIMTB
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_MEIMTB)
                'Case DBN_UNYMTA
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_UNYMTA)
                'Case DBN_EXCTBZ
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_EXCTBZ)
                'Case DBN_GYMTBZ
                '	'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '	G_LB = LSet(DB_GYMTBZ)
                'Case DBN_KNGMTB
                '             'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
                '             G_LB = LSet(DB_KNGMTB)
                '20190826 DEL END
        End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
        '20190826 DEL START
        'Select Case Fno
        '    Case DBN_SYSTBA
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_SYSTBA = LSet(G_LB)
        '    Case DBN_SYSTBB
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_SYSTBB = LSet(G_LB)
        '    Case DBN_SYSTBC
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_SYSTBC = LSet(G_LB)
        '    Case DBN_SYSTBD
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_SYSTBD = LSet(G_LB)
        '    Case DBN_SYSTBH
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_SYSTBH = LSet(G_LB)
        '    Case DBN_TANMTA
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_TANMTA = LSet(G_LB)
        '    Case DBN_MEIMTA
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_MEIMTA = LSet(G_LB)
        '    Case DBN_MEIMTB
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_MEIMTB = LSet(G_LB)
        '    Case DBN_UNYMTA
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_UNYMTA = LSet(G_LB)
        '    Case DBN_EXCTBZ
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_EXCTBZ = LSet(G_LB)
        '    Case DBN_GYMTBZ
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_GYMTBZ = LSet(G_LB)
        '    Case DBN_KNGMTB
        '        'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
        '        DB_KNGMTB = LSet(G_LB)
        'End Select
        '20190826 DEL END
    End Sub
	
	Function RecordFromObject(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		RecordFromObject = Rtc
	End Function
	
	Function ObjectFromRecord(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		ObjectFromRecord = Rtc
	End Function
End Module