Option Strict Off
Option Explicit On
Module DENNOA_F51
	'
	' �X���b�g��        : ���ח\��No�E��ʍ��ڃX���b�g
	' ���j�b�g��        : DENNOA.F02
	' �L�q��            : Standard Library
	' �쐬���t          : 1999/11/05
	' �g�p�v���O������  : NYKET31
	
	'�`�[No�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function DENNOA_CheckC(ByRef DENNOA As Object, ByRef PP As clsPP, ByRef CP_DENNOA As clsCP) As Object
		
		Dim Rtn As Object
		Dim WK_NHSCD As String
		
		'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENNOA_CheckC = 0
        'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        'WK_NHSCD = Trim(DENNOA) & Space(Len(DB_NHSMTA.NHSCD) - Len(Trim(DENNOA)))
        WK_NHSCD = Trim(DENNOA) & Space(Len(DB_NHSMTA2.NHSCD) - Len(Trim(DENNOA)))

        Call DB_GetEq(DBN_NHSMTA, 1, WK_NHSCD, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g Rtn �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Rtn = DSP_MsgBox(SSS_CONFRM, "NHSMR52", 6) '���ɔ[����R�[�h�����݂��܂��B�ēx�����̔Ԃ��s����
		Else
			Call DP_SSSMAIN_NHSCD(0, DENNOA)
		End If
		AE_Controls(1).Focus()
		
	End Function
	
	Function DENNOA_Slist(ByRef PP As clsPP, ByVal DENNOA As Object) As Object
		Dim WK_DENNOA As String
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		
		' === 20081028 === UPDATE S - RISE)Izumi
		'    Call DB_GetEq(DBN_SYSTBM, 1, "001", BtrNormal)
		Call DB_GetEq(DBN_SYSTBM, 1, "001", RecLock)
		' === 20081028 === UPDATE E - RISE)Izumi
		If DBSTAT = 0 Then
			WK_DENNOA = VB6.Format(Left(CStr(CDbl(DB_SYSTBM.DENNOA) + 1), 9), "000000000")
			DB_SYSTBM.DENNOA = WK_DENNOA
			DB_SYSTBM.OPEID = SSS_OPEID.Value
			DB_SYSTBM.CLTID = SSS_CLTID.Value
			DB_SYSTBM.WRTTM = VB6.Format(Now, "hhmmss")
			DB_SYSTBM.WRTDT = VB6.Format(Now, "YYYYMMDD")
			Call DB_Update(DBN_SYSTBM, 1)
			'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENNOA_Slist = WK_DENNOA
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENNOA_Slist = ""
		End If
		
		Call DB_EndTransaction()
		
		
	End Function
	
	Function DENNOA_Skip(ByRef CT_DENNOA As System.Windows.Forms.Control) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENNOA_Skip = True
        'UPGRADE_WARNING: �I�u�W�F�N�g CT_DENNOA.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190821 CHG START
        'CT_DENNOA.SelStart = 9
        DirectCast(CT_DENNOA, TextBox).SelectionStart = 9
        '20190821 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g DENNOA_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DENNOA_Skip = False
	End Function
End Module