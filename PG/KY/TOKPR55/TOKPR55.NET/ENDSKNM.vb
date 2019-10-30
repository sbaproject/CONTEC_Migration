Option Strict Off
Option Explicit On
Module ENDSKNM_F51
	'
	' �X���b�g��        : �d�ؗp���i�Q���́E��ʍ��ڃX���b�g
	' ���j�b�g��        : SKNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function ENDSKNM_Derived(ByVal ENDSKNM As Object, ByVal ENDSKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDSKCD) = "" Then
			DB_MEIMTA.MEINMA = " "
		Else
			Call MEIMTA_RClear()
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Call DB_GetEq(DBN_MEIMTA, 1, "043" & ENDSKCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ENDSKCD)) & Space(Len(DB_MEIMTA.MEICDB)), BtrNormal)
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDSKNM_Derived = DB_MEIMTA.MEINMA
		
	End Function
	Function ENDSKNM_InitVal(ByVal ENDSKNM As Object, ByVal ENDSKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_MEIMTA.MEICDA) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDSKCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDSKNM_InitVal = FillVal(" ", LenWid(DB_MEIMTA.MEINMA))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDSKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDSKNM_InitVal = DB_MEIMTA.MEINMA
		End If
	End Function
End Module