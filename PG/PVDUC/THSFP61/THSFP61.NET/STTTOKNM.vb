Option Strict Off
Option Explicit On
Module STTTOKNM_F61
	'
	' �X���b�g��        : ���Ӑ於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTTOKNM.F61
	' �L�q��            : Standard Library
	' �쐬���t          : 2011/02/21
	' �g�p�v���O������  : THSFP61
	'
	
	Function STTTOKNM_Derived(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKNM_Derived = ""
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTTOKCD) = "" Then
			DB_TOKMTA.TOKRN = " "
		Else
			Call TOKMTA_RClear()
			Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				STTTOKNM_Derived = DB_TOKMTA.TOKRN
			Else
				Call TOKMTA_RClear()
				Call SIRMTA_RClear()
				Call DB_GetEq(DBN_SIRMTA, 1, STTTOKCD, BtrNormal)
				If DBSTAT = 0 Then
					If DB_SIRMTA.DATKB = "9" Then
						Call SIRMTA_RClear()
					End If
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTOKNM_Derived = DB_SIRMTA.SIRRN
				Else
					Call SIRMTA_RClear()
				End If
			End If
		End If
		
	End Function
	
	Function STTTOKNM_InitVal(ByVal STTTOKNM As Object, ByVal STTTOKCD As Object, ByVal De_Index As Object) As Object
		
		Select Case FR_SSSMAIN.HD_THSCD.Text
			Case "0", "1", "2", "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(STTTOKCD) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTOKNM_InitVal = DB_TOKMTA.TOKRN
				End If
			Case "4", "5"
				'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(STTTOKCD) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTOKNM_InitVal = FillVal(" ", LenWid(DB_SIRMTA.SIRRN))
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					STTTOKNM_InitVal = DB_SIRMTA.SIRRN
				End If
		End Select
		
	End Function
End Module