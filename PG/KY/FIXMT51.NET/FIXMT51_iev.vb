Option Strict Off
Option Explicit On
Module FIXMT51_IEV
	Public Const SSS_MAX_DB As Short = 9
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "FIXMT51"
	' === 20081002 === UPDATE S - RISE)Izumi �\�����̂̕ύX
	'Global Const SSS_PrgNm = "�Œ�l�o�^                    "
	Public Const SSS_PrgNm As String = "�Œ�l�}�X�^�o�^�^����                    "
	' === 20081002 === UPDATE S - RISE)Izumi
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_SYSTBA = 0
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBC = 1
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBH = 2
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_UNYMTA = 3
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_FIXMTA = 4
		DB_PARA(DBN_FIXMTA).tblid = "FIXMTA"
		DB_PARA(DBN_FIXMTA).DBID = "USR1"
		SSS_MFIL = DBN_FIXMTA
		'
		DBN_TANMTA = 5
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 6
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 7
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 8
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_CTLCD(De, DB_FIXMTA.CTLCD)
		Call DP_SSSMAIN_CTLNM(De, DB_FIXMTA.CTLNM)
		Call DP_SSSMAIN_FIXVAL(De, DB_FIXMTA.FIXVAL)
		Call DP_SSSMAIN_REMARK(De, DB_FIXMTA.REMARK)
		
		'2007/12/13 add-str T.KAWAMUKAI ���f�[�^�̃^�C���X�^���v�ޔ�
		'   [����De�͉�ʏ�̍s��(0�`)]
		' === 20081002 === UPDATE S - RISE)Izumi �`�F�b�N���ڒǉ�
		'    M_MOTO_A_inf(De).WRTDT = DB_FIXMTA.WRTDT            '�X�V���t
		'    M_MOTO_A_inf(De).WRTTM = DB_FIXMTA.WRTTM            '�X�V����
		'    M_MOTO_A_inf(De).UWRTDT = DB_FIXMTA.UWRTDT          '�o�b�`�X�V���t
		'    M_MOTO_A_inf(De).UWRTTM = DB_FIXMTA.UWRTTM          '�o�b�`�X�V����
		M_FIXMT_A_inf(De).OPEID = DB_FIXMTA.OPEID '�ŏI��Ǝ҃R�[�h
		M_FIXMT_A_inf(De).CLTID = DB_FIXMTA.CLTID '�N���C�A���g�h�c
		M_FIXMT_A_inf(De).UOPEID = DB_FIXMTA.UOPEID '�ŏI��Ǝ҃R�[�h�i�o�b�`�j
		M_FIXMT_A_inf(De).UCLTID = DB_FIXMTA.UCLTID '�N���C���g�h�c�i�o�b�`�j
		M_FIXMT_A_inf(De).WRTDT = DB_FIXMTA.WRTDT '�X�V���t
		M_FIXMT_A_inf(De).WRTTM = DB_FIXMTA.WRTTM '�X�V����
		M_FIXMT_A_inf(De).UWRTDT = DB_FIXMTA.UWRTDT '�o�b�`�X�V���t
		M_FIXMT_A_inf(De).UWRTTM = DB_FIXMTA.UWRTTM '�o�b�`�X�V����
		' === 20081002 === UPDATE E - RISE)Izumi
		'2007/12/13 add-end T.KAWAMUKAI
		
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLCD() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_CTLNM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_FIXMTA.CTLNM = RD_SSSMAIN_CTLNM(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_FIXVAL() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_FIXMTA.FIXVAL = RD_SSSMAIN_FIXVAL(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_REMARK() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_FIXMTA.REMARK = RD_SSSMAIN_REMARK(De)
		DB_FIXMTA.OPEID = SSS_OPEID.Value
		DB_FIXMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_FIXMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_FIXMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_FIXMTA.WRTTM = DB_ORATM
			DB_FIXMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_OPEID(De, DB_TANMTA.TANCD)
		Call DP_SSSMAIN_OPENM(De, DB_TANMTA.TANNM)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPEID() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TANMTA.TANCD = RD_SSSMAIN_OPEID(De)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_OPENM() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_TANMTA.TANNM = RD_SSSMAIN_OPENM(De)
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

    '2019/09/24 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBA)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBC)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_SYSTBH)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_UNYMTA)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_FIXMTA)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            G_LB = LSet(DB_TANMTA)
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
    '2019/09/24 DEL E N D


    '2019/09/24 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBA = LSet(G_LB)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBC = LSet(G_LB)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_SYSTBH = LSet(G_LB)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_UNYMTA = LSet(G_LB)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_FIXMTA = LSet(G_LB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet �� 1 �̌^����ʂ̌^�Ɋ��蓖�Ă邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' ���N���b�N���Ă��������B
    '            DB_TANMTA = LSet(G_LB)
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
    '2019/09/24 DEL E N D

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