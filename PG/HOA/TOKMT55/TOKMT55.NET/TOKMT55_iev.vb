Option Strict Off
Option Explicit On
Module TOKMT55_IEV
	Public Const SSS_MAX_DB As Short = 12
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "TOKMT55"
	' === 20081003 === UPDATE S - RISE)Izumi�@�\�����̂̕ύX
	'Global Const SSS_PrgNm = "�����N�ʎd�ؗ��o�^            "
	Public Const SSS_PrgNm As String = "�����N�ʎd�ؗ��}�X�^�o�^�^����            "
	' === 20081003 === UPDATE E - RISE)Izumi
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
		DBN_RNKMTA = 6
		DB_PARA(DBN_RNKMTA).tblid = "RNKMTA"
		DB_PARA(DBN_RNKMTA).DBID = "USR1"
		SSS_MFIL = DBN_RNKMTA
		'
		DBN_UNYMTA = 7
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 8
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
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
	
	Sub SCR_FromMEIMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_SKHINGNM(De, DB_MEIMTA.MEINMA)
		Call DP_SSSMAIN_SKHINGRP(De, DB_MEIMTA.MEICDA)
	End Sub
	
	Sub MEIMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEINMA = RD_SSSMAIN_SKHINGNM(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SKHINGRP() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_MEIMTA.MEICDA = RD_SSSMAIN_SKHINGRP(De)
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
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_RNKCD(De, DB_RNKMTA.RNKCD)
		Call DP_SSSMAIN_SIKRT(De, DB_RNKMTA.SIKRT)
		Call DP_SSSMAIN_URISETDT(De, DB_RNKMTA.URISETDT)
		
		'2007/12/14 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
		'   [����De�͉�ʏ�̍s��(0�`)]
		' === 20080908 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		'    M_MOTO_A_inf(De).WRTDT = DB_RNKMTA.WRTDT            '�X�V���t
		'    M_MOTO_A_inf(De).WRTTM = DB_RNKMTA.WRTTM            '�X�V����
		'    M_MOTO_A_inf(De).UWRTDT = DB_RNKMTA.UWRTDT          '�o�b�`�X�V���t
		'    M_MOTO_A_inf(De).UWRTTM = DB_RNKMTA.UWRTTM          '�o�b�`�X�V����
		M_RNKMT_A_inf(De).OPEID = DB_RNKMTA.OPEID '�ŏI��Ǝ҃R�[�h
		M_RNKMT_A_inf(De).CLTID = DB_RNKMTA.CLTID '�N���C�A���g�h�c
		M_RNKMT_A_inf(De).UOPEID = DB_RNKMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		M_RNKMT_A_inf(De).UCLTID = DB_RNKMTA.UCLTID '�N���C���g�h�c�i�o�b�`�j
		M_RNKMT_A_inf(De).WRTDT = DB_RNKMTA.WRTDT '�X�V���t
		M_RNKMT_A_inf(De).WRTTM = DB_RNKMTA.WRTTM '�X�V����
		M_RNKMT_A_inf(De).UWRTDT = DB_RNKMTA.UWRTDT '�o�b�`�X�V���t
		M_RNKMT_A_inf(De).UWRTTM = DB_RNKMTA.UWRTTM '�o�b�`�X�V����
		' === 20080908 === UPDATE E - RISE)Izumi
		'2007/12/14 add-end T.KAWAMUKAI
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_RNKCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_RNKMTA.RNKCD = RD_SSSMAIN_RNKCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_SIKRT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_RNKMTA.SIKRT = RD_SSSMAIN_SIKRT(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_URISETDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_RNKMTA.URISETDT = RD_SSSMAIN_URISETDT(De)
		DB_RNKMTA.OPEID = SSS_OPEID.Value
		DB_RNKMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_RNKMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_RNKMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_RNKMTA.WRTTM = DB_ORATM
			DB_RNKMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_SYSTBA)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_SYSTBB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_SYSTBC)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_SYSTBD)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_SYSTBH)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_TANMTA)
			Case DBN_RNKMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_RNKMTA)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_UNYMTA)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_MEIMTA)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_EXCTBZ)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_GYMTBZ)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				G_LB = LSet(DB_KNGMTB)
		End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_SYSTBA = LSet(G_LB)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_SYSTBB = LSet(G_LB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_SYSTBC = LSet(G_LB)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_SYSTBD = LSet(G_LB)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_SYSTBH = LSet(G_LB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_TANMTA = LSet(G_LB)
			Case DBN_RNKMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_RNKMTA = LSet(G_LB)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_UNYMTA = LSet(G_LB)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_MEIMTA = LSet(G_LB)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_EXCTBZ = LSet(G_LB)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_GYMTBZ = LSet(G_LB)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
				DB_KNGMTB = LSet(G_LB)
		End Select
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