Option Strict Off
Option Explicit On
Module SOUMT51_IEV
	Public Const SSS_MAX_DB As Short = 16
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "SOUMT51"
	' === 20081003 === UPDATE S - RISE)Izumi�@�\�����̂̕ύX
	'Global Const SSS_PrgNm = "�q�ɓo�^                      "
	Public Const SSS_PrgNm As String = "�q�Ƀ}�X�^�o�^�^����                      "
	' === 20081003 === UPDATE S - RISE)Izumi
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
        '
        '2019/10/10 DEL START
        'DBN_SOUMTA = 0
        'DB_PARA(DBN_SOUMTA).tblid = "SOUMTA"
        'DB_PARA(DBN_SOUMTA).DBID = "USR1"
        'SSS_MFIL = DBN_SOUMTA
        ''
        'DBN_SYSTBA = 1
        'DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
        'DB_PARA(DBN_SYSTBA).DBID = "USR1"
        ''
        'DBN_SYSTBB = 2
        'DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
        'DB_PARA(DBN_SYSTBB).DBID = "USR1"
        ''
        'DBN_SYSTBC = 3
        'DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
        'DB_PARA(DBN_SYSTBC).DBID = "USR1"
        ''
        'DBN_SYSTBD = 4
        'DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
        'DB_PARA(DBN_SYSTBD).DBID = "USR1"
        ''
        'DBN_SYSTBF = 5
        'DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
        'DB_PARA(DBN_SYSTBF).DBID = "USR1"
        ''
        'DBN_SYSTBG = 6
        'DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
        'DB_PARA(DBN_SYSTBG).DBID = "USR1"
        ''
        'DBN_SYSTBH = 7
        'DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
        'DB_PARA(DBN_SYSTBH).DBID = "USR1"
        ''
        'DBN_MEIMTA = 8
        'DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
        'DB_PARA(DBN_MEIMTA).DBID = "USR1"
        ''
        'DBN_TANMTA = 9
        'DB_PARA(DBN_TANMTA).tblid = "TANMTA"
        'DB_PARA(DBN_TANMTA).DBID = "USR1"
        ''
        'DBN_TOKMTA = 10
        'DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
        'DB_PARA(DBN_TOKMTA).DBID = "USR1"
        ''
        'DBN_FIXMTA = 11
        'DB_PARA(DBN_FIXMTA).tblid = "FIXMTA"
        'DB_PARA(DBN_FIXMTA).DBID = "USR1"
        ''
        'DBN_UNYMTA = 12
        'DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        ''
        'DBN_EXCTBZ = 13
        'DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        ''
        'DBN_GYMTBZ = 14
        'DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        ''
        'DBN_KNGMTB = 15
        'DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
        '      DB_PARA(DBN_KNGMTB).DBID = "USR1"
        '2019/10/10 DEL END

        SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_HIKKB(De, DB_SOUMTA.HIKKB)
		Call DP_SSSMAIN_SALPALKB(De, DB_SOUMTA.SALPALKB)
		Call DP_SSSMAIN_SISNKB(De, DB_SOUMTA.SISNKB)
		Call DP_SSSMAIN_SOUADA(De, DB_SOUMTA.SOUADA)
		Call DP_SSSMAIN_SOUADB(De, DB_SOUMTA.SOUADB)
		Call DP_SSSMAIN_SOUADC(De, DB_SOUMTA.SOUADC)
		Call DP_SSSMAIN_SOUBSCD(De, DB_SOUMTA.SOUBSCD)
		Call DP_SSSMAIN_SOUCD(De, DB_SOUMTA.SOUCD)
		Call DP_SSSMAIN_SOUFX(De, DB_SOUMTA.SOUFX)
		Call DP_SSSMAIN_SOUKB(De, DB_SOUMTA.SOUKB)
		Call DP_SSSMAIN_SOUKOKB(De, DB_SOUMTA.SOUKOKB)
		Call DP_SSSMAIN_SOUNM(De, DB_SOUMTA.SOUNM)
		Call DP_SSSMAIN_SOUTL(De, DB_SOUMTA.SOUTL)
		Call DP_SSSMAIN_SOUTRICD(De, DB_SOUMTA.SOUTRICD)
		Call DP_SSSMAIN_SOUZP(De, DB_SOUMTA.SOUZP)
		Call DP_SSSMAIN_SRSCNKB(De, DB_SOUMTA.SRSCNKB)
		
		'2007/12/14 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
		'   [����De�͉�ʏ�̍s��(0�`)]
		' === 20080901 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		'    M_MOTO_A_inf(De).WRTDT = DB_SOUMTA.WRTDT            '�X�V���t
		'    M_MOTO_A_inf(De).WRTTM = DB_SOUMTA.WRTTM            '�X�V����
		'    M_MOTO_A_inf(De).UWRTDT = DB_SOUMTA.UWRTDT          '�o�b�`�X�V���t
		'    M_MOTO_A_inf(De).UWRTTM = DB_SOUMTA.UWRTTM          '�o�b�`�X�V����
		
		M_SOUMT_A_inf(De).OPEID = DB_SOUMTA.OPEID '�ŏI��Ǝ҃R�[�h
		M_SOUMT_A_inf(De).CLTID = DB_SOUMTA.CLTID '�N���C�A���g�h�c
		M_SOUMT_A_inf(De).UOPEID = DB_SOUMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		M_SOUMT_A_inf(De).UCLTID = DB_SOUMTA.UCLTID '�N���C���g�h�c�i�o�b�`�j
		M_SOUMT_A_inf(De).WRTDT = DB_SOUMTA.WRTDT '�X�V���t
		M_SOUMT_A_inf(De).WRTTM = DB_SOUMTA.WRTTM '�X�V����
		M_SOUMT_A_inf(De).UWRTDT = DB_SOUMTA.UWRTDT '�o�b�`�X�V���t
		M_SOUMT_A_inf(De).UWRTTM = DB_SOUMTA.UWRTTM '�o�b�`�X�V����
		' === 20080901 === UPDATE E - RISE)Izumi'2007/12/14 add-end T.KAWAMUKAI
		
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.HIKKB = RD_SSSMAIN_HIKKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SALPALKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SALPALKB = RD_SSSMAIN_SALPALKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SISNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SISNKB = RD_SSSMAIN_SISNKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUADA = RD_SSSMAIN_SOUADA(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUADB = RD_SSSMAIN_SOUADB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUADC = RD_SSSMAIN_SOUADC(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUBSCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUBSCD = RD_SSSMAIN_SOUBSCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUFX = RD_SSSMAIN_SOUFX(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUKB = RD_SSSMAIN_SOUKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUKOKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUKOKB = RD_SSSMAIN_SOUKOKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUNM = RD_SSSMAIN_SOUNM(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUTL = RD_SSSMAIN_SOUTL(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUTRICD = RD_SSSMAIN_SOUTRICD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SOUZP = RD_SSSMAIN_SOUZP(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SRSCNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_SOUMTA.SRSCNKB = RD_SSSMAIN_SRSCNKB(De)
		DB_SOUMTA.OPEID = SSS_OPEID.Value
		DB_SOUMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_SOUMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_SOUMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_SOUMTA.WRTTM = DB_ORATM
			DB_SOUMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromTOKMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_SOUTRICD(De, DB_TOKMTA.TOKCD)
		Call DP_SSSMAIN_SOUTRINM(De, DB_TOKMTA.TOKRN)
	End Sub
	
	Sub TOKMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRICD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTA.TOKCD = RD_SSSMAIN_SOUTRICD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SOUTRINM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTA.TOKRN = RD_SSSMAIN_SOUTRINM(De)
		DB_TOKMTA.OPEID = SSS_OPEID.Value
		DB_TOKMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKMTA.WRTTM = DB_ORATM
			DB_TOKMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub


    '2019/09/25 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_SOUMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SOUMTA)
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBA)
    '        Case DBN_SYSTBB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBB)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBC)
    '        Case DBN_SYSTBD
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBD)
    '        Case DBN_SYSTBF
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBF)
    '        Case DBN_SYSTBG
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBG)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBH)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_MEIMTA)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TANMTA)
    '        Case DBN_TOKMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TOKMTA)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_FIXMTA)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_UNYMTA)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_EXCTBZ)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_GYMTBZ)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_KNGMTB)
    '    End Select
    'End Sub
    '2019/09/25 DEL E N D

    '2019/03/25 DEL START
    '   Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_SOUMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SOUMTA = LSet(G_LB)
    '		Case DBN_SYSTBA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBA = LSet(G_LB)
    '		Case DBN_SYSTBB
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBB = LSet(G_LB)
    '		Case DBN_SYSTBC
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBC = LSet(G_LB)
    '		Case DBN_SYSTBD
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBD = LSet(G_LB)
    '		Case DBN_SYSTBF
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBF = LSet(G_LB)
    '		Case DBN_SYSTBG
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBG = LSet(G_LB)
    '		Case DBN_SYSTBH
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_SYSTBH = LSet(G_LB)
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_MEIMTA = LSet(G_LB)
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_TANMTA = LSet(G_LB)
    '		Case DBN_TOKMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_TOKMTA = LSet(G_LB)
    '		Case DBN_FIXMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_FIXMTA = LSet(G_LB)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_UNYMTA = LSet(G_LB)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_EXCTBZ = LSet(G_LB)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_GYMTBZ = LSet(G_LB)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '			DB_KNGMTB = LSet(G_LB)
    '	End Select
    'End Sub
    '2019/09/25 DEL E N D

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