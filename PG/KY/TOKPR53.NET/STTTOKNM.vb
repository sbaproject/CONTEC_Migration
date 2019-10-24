Option Strict Off
Option Explicit On
Module STTTOKNM_F51
	'
	' �X���b�g��        : ���Ӑ於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : TOKNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/17
	' �g�p�v���O������  : NYKPR52
	'
	
	Function STTTOKNM_Derived(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTOKCD) = "" Then
			DB_TOKMTA.TOKRN = " "
		Else
            'Call TOKMTA_RClear()
            Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
                    'Call TOKMTA_RClear()
                End If
			Else
                'Call TOKMTA_RClear()
            End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKNM_Derived = DB_TOKMTA.TOKRN
		
	End Function
	Function STTTOKNM_InitVal(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_TOKMTA.TOKCD) = "" Then
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTOKCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTTOKNM_InitVal = DB_TOKMTA.TOKRN
		End If
	End Function
End Module