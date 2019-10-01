Option Strict Off
Option Explicit On
Module BMNMT51_IEV
	'2008/12/16 RISE)izumi CHG START  �A���[��:643
	'Global Const SSS_MAX_DB% = 15
	Public Const SSS_MAX_DB As Short = 16
	'2008/12/16 RISE)izumi CHG END
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "BMNMT51"
	' === 20081003 === UPDATE S - RISE)Izumi�@�\�����̂̕ύX
	'Global Const SSS_PrgNm = "����o�^                      "
	Public Const SSS_PrgNm As String = "����}�X�^�o�^�^����                      "
	' === 20081003 === UPDATE E - RISE)Izumi
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_BMNMTA = 0
		DB_PARA(DBN_BMNMTA).tblid = "BMNMTA"
		DB_PARA(DBN_BMNMTA).DBID = "USR1"
		SSS_MFIL = DBN_BMNMTA
		'
		DBN_SYSTBA = 1
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 2
		DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 3
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 4
		DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 5
		DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 6
		DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 7
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_TANMTA = 8
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 9
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_FIXMTA = 10
		DB_PARA(DBN_FIXMTA).tblid = "FIXMTA"
		DB_PARA(DBN_FIXMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 11
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 12
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 13
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 14
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		'2008/12/16 RISE)izumi ADD START  �A���[��:643
		DBN_MEIMTC = 15
		DB_PARA(DBN_MEIMTC).tblid = "MEIMTC"
		DB_PARA(DBN_MEIMTC).DBID = "USR1"
		'2008/12/16 RISE)izumi ADD END
		
		SSS_BILFL = 9
	End Sub

    Sub SCR_FromMfil(ByVal De As Short) 'Generated.
        '20190807 CHG START
        'Call DP_SSSMAIN_BMNADA(De, DB_BMNMTA.BMNADA)
        'Call DP_SSSMAIN_BMNADB(De, DB_BMNMTA.BMNADB)
        'Call DP_SSSMAIN_BMNADC(De, DB_BMNMTA.BMNADC)
        'Call DP_SSSMAIN_BMNCD(De, DB_BMNMTA.BMNCD)
        'Call DP_SSSMAIN_BMNCDUP(De, DB_BMNMTA.BMNCDUP)
        'Call DP_SSSMAIN_BMNFX(De, DB_BMNMTA.BMNFX)
        'Call DP_SSSMAIN_BMNLV(De, DB_BMNMTA.BMNLV)
        'Call DP_SSSMAIN_BMNNM(De, DB_BMNMTA.BMNNM)
        'Call DP_SSSMAIN_BMNPRNM(De, DB_BMNMTA.BMNPRNM)
        'Call DP_SSSMAIN_BMNTL(De, DB_BMNMTA.BMNTL)
        'Call DP_SSSMAIN_BMNURL(De, DB_BMNMTA.BMNURL)
        'Call DP_SSSMAIN_BMNZP(De, DB_BMNMTA.BMNZP)
        'Call DP_SSSMAIN_EIGYOCD(De, DB_BMNMTA.EIGYOCD)
        'Call DP_SSSMAIN_ENDTKDT(De, DB_BMNMTA.ENDTKDT)
        'Call DP_SSSMAIN_HTANCD(De, DB_BMNMTA.HTANCD)
        'Call DP_SSSMAIN_STANCD(De, DB_BMNMTA.STANCD)
        'Call DP_SSSMAIN_STTTKDT(De, DB_BMNMTA.STTTKDT)
        'Call DP_SSSMAIN_TIKKB(De, DB_BMNMTA.TIKKB)
        'Call DP_SSSMAIN_ZMBMNCD(De, DB_BMNMTA.ZMBMNCD)
        'Call DP_SSSMAIN_ZMCD(De, DB_BMNMTA.ZMCD)
        'Call DP_SSSMAIN_ZMJGYCD(De, DB_BMNMTA.ZMJGYCD)
        Call DP_SSSMAIN_BMNADA(De, DB_BMNMTA2.BMNADA)
        Call DP_SSSMAIN_BMNADB(De, DB_BMNMTA2.BMNADB)
        Call DP_SSSMAIN_BMNADC(De, DB_BMNMTA2.BMNADC)
        Call DP_SSSMAIN_BMNCD(De, DB_BMNMTA2.BMNCD)
        Call DP_SSSMAIN_BMNCDUP(De, DB_BMNMTA2.BMNCDUP)
        Call DP_SSSMAIN_BMNFX(De, DB_BMNMTA2.BMNFX)
        Call DP_SSSMAIN_BMNLV(De, DB_BMNMTA2.BMNLV)
        Call DP_SSSMAIN_BMNNM(De, DB_BMNMTA2.BMNNM)
        Call DP_SSSMAIN_BMNPRNM(De, DB_BMNMTA2.BMNPRNM)
        Call DP_SSSMAIN_BMNTL(De, DB_BMNMTA2.BMNTL)
        Call DP_SSSMAIN_BMNURL(De, DB_BMNMTA2.BMNURL)
        Call DP_SSSMAIN_BMNZP(De, DB_BMNMTA2.BMNZP)
        Call DP_SSSMAIN_EIGYOCD(De, DB_BMNMTA2.EIGYOCD)
        Call DP_SSSMAIN_ENDTKDT(De, DB_BMNMTA2.ENDTKDT)
        Call DP_SSSMAIN_HTANCD(De, DB_BMNMTA2.HTANCD)
        Call DP_SSSMAIN_STANCD(De, DB_BMNMTA2.STANCD)
        Call DP_SSSMAIN_STTTKDT(De, DB_BMNMTA2.STTTKDT)
        Call DP_SSSMAIN_TIKKB(De, DB_BMNMTA2.TIKKB)
        Call DP_SSSMAIN_ZMBMNCD(De, DB_BMNMTA2.ZMBMNCD)
        Call DP_SSSMAIN_ZMCD(De, DB_BMNMTA2.ZMCD)
        Call DP_SSSMAIN_ZMJGYCD(De, DB_BMNMTA2.ZMJGYCD)
        '20190807 CHG END


        '2007/12/13 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
        '   [����De�͉�ʏ�̍s��(0�`)]
        ' === 20080929 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
        '    M_MOTO_A_inf(De).WRTDT = DB_BMNMTA.WRTDT            '�X�V���t
        '    M_MOTO_A_inf(De).WRTTM = DB_BMNMTA.WRTTM            '�X�V����
        '    M_MOTO_A_inf(De).UWRTDT = DB_BMNMTA.UWRTDT          '�o�b�`�X�V���t
        '    M_MOTO_A_inf(De).UWRTTM = DB_BMNMTA.UWRTTM          '�o�b�`�X�V����

        '20190807 CHG START
        '      M_BMNMT_A_inf(De).OPEID = DB_BMNMTA.OPEID '�ŏI��Ǝ҃R�[�h
        '      M_BMNMT_A_inf(De).CLTID = DB_BMNMTA.CLTID '�N���C�A���g�h�c
        'M_BMNMT_A_inf(De).UOPEID = DB_BMNMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        'M_BMNMT_A_inf(De).UCLTID = DB_BMNMTA.UCLTID '�N���C���g�h�c�i�o�b�`�j
        'M_BMNMT_A_inf(De).WRTDT = DB_BMNMTA.WRTDT '�X�V���t
        'M_BMNMT_A_inf(De).WRTTM = DB_BMNMTA.WRTTM '�X�V����
        'M_BMNMT_A_inf(De).UWRTDT = DB_BMNMTA.UWRTDT '�o�b�`�X�V���t
        'M_BMNMT_A_inf(De).UWRTTM = DB_BMNMTA.UWRTTM '�o�b�`�X�V����
        M_BMNMT_A_inf(De).OPEID = DB_BMNMTA2.OPEID '�ŏI��Ǝ҃R�[�h
        M_BMNMT_A_inf(De).CLTID = DB_BMNMTA2.CLTID '�N���C�A���g�h�c
        M_BMNMT_A_inf(De).UOPEID = DB_BMNMTA2.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
        M_BMNMT_A_inf(De).UCLTID = DB_BMNMTA2.UCLTID '�N���C���g�h�c�i�o�b�`�j
        M_BMNMT_A_inf(De).WRTDT = DB_BMNMTA2.WRTDT '�X�V���t
        M_BMNMT_A_inf(De).WRTTM = DB_BMNMTA2.WRTTM '�X�V����
        M_BMNMT_A_inf(De).UWRTDT = DB_BMNMTA2.UWRTDT '�o�b�`�X�V���t
        M_BMNMT_A_inf(De).UWRTTM = DB_BMNMTA2.UWRTTM '�o�b�`�X�V����
        '20190807 CHG END
        ' === 20080929 === UPDATE E - RISE)Izumi
        '2007/12/13 add-end T.KAWAMUKAI

    End Sub

    Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
        '20190807 CHG START
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADA() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNADA = RD_SSSMAIN_BMNADA(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNADB = RD_SSSMAIN_BMNADB(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNADC = RD_SSSMAIN_BMNADC(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCDUP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNCDUP = RD_SSSMAIN_BMNCDUP(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNFX = RD_SSSMAIN_BMNFX(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNLV() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNLV = RD_SSSMAIN_BMNLV(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNNM = RD_SSSMAIN_BMNNM(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNPRNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNPRNM = RD_SSSMAIN_BMNPRNM(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNTL = RD_SSSMAIN_BMNTL(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNURL = RD_SSSMAIN_BMNURL(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.BMNZP = RD_SSSMAIN_BMNZP(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_EIGYOCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.EIGYOCD = RD_SSSMAIN_EIGYOCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.ENDTKDT = RD_SSSMAIN_ENDTKDT(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.HTANCD = RD_SSSMAIN_HTANCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.STANCD = RD_SSSMAIN_STANCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.STTTKDT = RD_SSSMAIN_STTTKDT(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.TIKKB = RD_SSSMAIN_TIKKB(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMBMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.ZMBMNCD = RD_SSSMAIN_ZMBMNCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.ZMCD = RD_SSSMAIN_ZMCD(De)
        ''UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMJGYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_BMNMTA.ZMJGYCD = RD_SSSMAIN_ZMJGYCD(De)
        'DB_BMNMTA.OPEID = SSS_OPEID.Value
        'DB_BMNMTA.CLTID = SSS_CLTID.Value
        'If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
        '    DB_BMNMTA.WRTTM = VB6.Format(Now, "hhmmss")
        '    DB_BMNMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
        'Else
        '    DB_BMNMTA.WRTTM = DB_ORATM
        '    DB_BMNMTA.WRTDT = DB_ORADT

        DB_BMNMTA2.BMNADA = RD_SSSMAIN_BMNADA(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNADB = RD_SSSMAIN_BMNADB(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNADC() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNADC = RD_SSSMAIN_BMNADC(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNCD = RD_SSSMAIN_BMNCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNCDUP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNCDUP = RD_SSSMAIN_BMNCDUP(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNFX() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNFX = RD_SSSMAIN_BMNFX(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNLV() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNLV = RD_SSSMAIN_BMNLV(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNNM = RD_SSSMAIN_BMNNM(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNPRNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNPRNM = RD_SSSMAIN_BMNPRNM(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNTL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNTL = RD_SSSMAIN_BMNTL(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNURL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNURL = RD_SSSMAIN_BMNURL(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_BMNZP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.BMNZP = RD_SSSMAIN_BMNZP(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_EIGYOCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.EIGYOCD = RD_SSSMAIN_EIGYOCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ENDTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.ENDTKDT = RD_SSSMAIN_ENDTKDT(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HTANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.HTANCD = RD_SSSMAIN_HTANCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STANCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.STANCD = RD_SSSMAIN_STANCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_STTTKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.STTTKDT = RD_SSSMAIN_STTTKDT(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TIKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.TIKKB = RD_SSSMAIN_TIKKB(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMBMNCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.ZMBMNCD = RD_SSSMAIN_ZMBMNCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.ZMCD = RD_SSSMAIN_ZMCD(De)
        'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZMJGYCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DB_BMNMTA2.ZMJGYCD = RD_SSSMAIN_ZMJGYCD(De)
        DB_BMNMTA2.OPEID = SSS_OPEID.Value
        DB_BMNMTA2.CLTID = SSS_CLTID.Value
        If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
            DB_BMNMTA2.WRTTM = VB6.Format(Now, "hhmmss")
            DB_BMNMTA2.WRTDT = VB6.Format(Now, "YYYYMMDD")
        Else
            DB_BMNMTA2.WRTTM = DB_ORATM
            DB_BMNMTA2.WRTDT = DB_ORADT
            '20190807 CHG END
        End If
    End Sub

    Sub UpdSmf() 'Generated.
	End Sub

    '20190807 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_BMNMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_BMNMTA)
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
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TANMTA)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_MEIMTA)
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
    '            '2008/12/16 RISE)izumi ADD START  �A���[��:643
    '        Case DBN_MEIMTC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_MEIMTC)
    '            '2008/12/16 RISE)izumi ADD END
    '    End Select
    'End Sub

    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_BMNMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_BMNMTA = LSet(G_LB)
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBA = LSet(G_LB)
    '        Case DBN_SYSTBB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBB = LSet(G_LB)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBC = LSet(G_LB)
    '        Case DBN_SYSTBD
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBD = LSet(G_LB)
    '        Case DBN_SYSTBF
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBF = LSet(G_LB)
    '        Case DBN_SYSTBG
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBG = LSet(G_LB)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBH = LSet(G_LB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_TANMTA = LSet(G_LB)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_MEIMTA = LSet(G_LB)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_FIXMTA = LSet(G_LB)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_UNYMTA = LSet(G_LB)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_EXCTBZ = LSet(G_LB)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_GYMTBZ = LSet(G_LB)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_KNGMTB = LSet(G_LB)
    '            '2008/12/16 RISE)izumi ADD START  �A���[��:643
    '        Case DBN_MEIMTC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_MEIMTC = LSet(G_LB)
    '            '2008/12/16 RISE)izumi ADD END
    '    End Select
    'End Sub
    '20190807 DEL END

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