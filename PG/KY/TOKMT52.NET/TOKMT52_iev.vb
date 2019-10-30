Option Strict Off
Option Explicit On
Module TOKMT52_IEV
	Public Const SSS_MAX_DB As Short = 18
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "TOKMT52"
	' === 20081003 === UPDATE S - RISE)Izumi�@�\�����̂̕ύX
	'Global Const SSS_PrgNm = "���i�ʓ��Ӑ�P���o�^          "
	Public Const SSS_PrgNm As String = "���Ӑ�P���}�X�^�o�^�^����          "
	' === 20081003 === UPDATE E - RISE)Izumi
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_HINMTA = 0
		DB_PARA(DBN_HINMTA).tblid = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
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
		DBN_TOKMTC = 8
		DB_PARA(DBN_TOKMTC).tblid = "TOKMTC"
		DB_PARA(DBN_TOKMTC).DBID = "USR1"
		SSS_MFIL = DBN_TOKMTC
		'
		DBN_CLSMTA = 9
		DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 10
		DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TANMTA = 11
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_TOKMTA = 12
		DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 13
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 14
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 15
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 16
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 17
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromTOKMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_TOKCD(De, DB_TOKMTA.TOKCD)
		Call DP_SSSMAIN_TOKRN(De, DB_TOKMTA.TOKRN)
	End Sub
	
	Sub TOKMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKRN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTA.TOKRN = RD_SSSMAIN_TOKRN(De)
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
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_HINCD(De, DB_TOKMTC.HINCD)
		Call DP_SSSMAIN_TOKCD(De, DB_TOKMTC.TOKCD)
		Call DP_SSSMAIN_TUKKB(De, DB_TOKMTC.TUKKB)
		Call DP_SSSMAIN_ULTTKKB(De, DB_TOKMTC.ULTTKKB)
		Call DP_SSSMAIN_URITK(De, DB_TOKMTC.URITK)
		Call DP_SSSMAIN_URITKDT(De, DB_TOKMTC.URITKDT)
		
		'2007/12/14 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
		'   [����De�͉�ʏ�̍s��(0�`)]
		' === 20080903 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		'    M_MOTO_A_inf(De).WRTDT = DB_TOKMTC.WRTDT            '�X�V���t
		'    M_MOTO_A_inf(De).WRTTM = DB_TOKMTC.WRTTM            '�X�V����
		'    M_MOTO_A_inf(De).UWRTDT = DB_TOKMTC.UWRTDT          '�o�b�`�X�V���t
		'    M_MOTO_A_inf(De).UWRTTM = DB_TOKMTC.UWRTTM          '�o�b�`�X�V����
		
		M_TOKMT_A_inf(De).OPEID = DB_TOKMTC.OPEID '�ŏI��Ǝ҃R�[�h
		M_TOKMT_A_inf(De).CLTID = DB_TOKMTC.CLTID '�N���C�A���g�h�c
		M_TOKMT_A_inf(De).UOPEID = DB_TOKMTC.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		M_TOKMT_A_inf(De).UCLTID = DB_TOKMTC.UCLTID '�N���C���g�h�c�i�o�b�`�j
		M_TOKMT_A_inf(De).WRTDT = DB_TOKMTC.WRTDT '�X�V���t
		M_TOKMT_A_inf(De).WRTTM = DB_TOKMTC.WRTTM '�X�V����
		M_TOKMT_A_inf(De).UWRTDT = DB_TOKMTC.UWRTDT '�o�b�`�X�V���t
		M_TOKMT_A_inf(De).UWRTTM = DB_TOKMTC.UWRTTM '�o�b�`�X�V����
		' === 20080903 === UPDATE E - RISE)Izumi
		
		'2007/12/14 add-end T.KAWAMUKAI
		
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TUKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ULTTKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.ULTTKKB = RD_SSSMAIN_ULTTKKB(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.URITK = RD_SSSMAIN_URITK(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URITKDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TOKMTC.URITKDT = RD_SSSMAIN_URITKDT(De)
		DB_TOKMTC.OPEID = SSS_OPEID.Value
		DB_TOKMTC.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKMTC.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKMTC.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKMTC.WRTTM = DB_ORATM
			DB_TOKMTC.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub

    '2019/10/18 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_HINMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_HINMTA)
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
    '        Case DBN_TOKMTC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TOKMTC)
    '        Case DBN_CLSMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_CLSMTA)
    '        Case DBN_CLSMTB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_CLSMTB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TANMTA)
    '        Case DBN_TOKMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TOKMTA)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_UNYMTA)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_MEIMTA)
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
    '2019/10/18 DEL E N D

    '2019/10/18 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '   Select Case Fno
    '       Case DBN_HINMTA
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_HINMTA = LSet(G_LB)
    '       Case DBN_SYSTBA
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBA = LSet(G_LB)
    '       Case DBN_SYSTBB
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBB = LSet(G_LB)
    '       Case DBN_SYSTBC
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBC = LSet(G_LB)
    '       Case DBN_SYSTBD
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBD = LSet(G_LB)
    '       Case DBN_SYSTBF
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBF = LSet(G_LB)
    '       Case DBN_SYSTBG
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBG = LSet(G_LB)
    '       Case DBN_SYSTBH
    '           'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '           DB_SYSTBH = LSet(G_LB)
    '       Case DBN_TOKMTC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_TOKMTC = LSet(G_LB)
    '        Case DBN_CLSMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_CLSMTA = LSet(G_LB)
    '        Case DBN_CLSMTB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_CLSMTB = LSet(G_LB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_TANMTA = LSet(G_LB)
    '        Case DBN_TOKMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_TOKMTA = LSet(G_LB)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_UNYMTA = LSet(G_LB)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_MEIMTA = LSet(G_LB)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_EXCTBZ = LSet(G_LB)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_GYMTBZ = LSet(G_LB)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_KNGMTB = LSet(G_LB)
    '    End Select
    'End Sub
    '2019/10/18 DEL E N D

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