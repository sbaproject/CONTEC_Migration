Option Strict Off
Option Explicit On
Module UDNDKBID_F52
	'
	' �X���b�g��        : ����敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : UDNDKBID.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/11
	' �g�p�v���O������  : URIET54/URIET55
	'
	
	Function UDNDKBID_Derived(ByRef PP As clsPP, ByVal UDNDKBID As Object, ByVal HINCD As Object, ByVal DE_INDEX As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UDNDKBID_Derived = UDNDKBID
		'    If Trim$(UDNDKBID) <> "" Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then Exit Function
		
		''''UDNDKBID = "02"
		''''UDNDKBID_Derived = UDNDKBID
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_MEIKBA(-1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If RD_SSSMAIN_MEIKBA(-1) = "1" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDKBID = "02"
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDKBID_Derived = UDNDKBID
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDKBID = "06"
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDKBID_Derived = UDNDKBID
		End If
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call DB_GetEq(DBN_SYSTBD, 1, WG_DKBSB & UDNDKBID, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call SCR_FromSYSTBD(DE_INDEX)
			'''''        Call DP_SSSMAIN_HINCD(DE_INDEX, HINCD)
			'''''        Call DB_GetEq(DBN_HINMTA, "1", HINCD, BtrNormal)
			'''''        Call SCR_FromHINMTA(DE_INDEX)
		Else
			'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDKBID_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UDNDKBID_Derived = System.DBNull.Value
		End If
	End Function
End Module