Option Strict Off
Option Explicit On
Module ENDTOKCD_F61
	'
	'�X���b�g��      :���Ӑ�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :ENDTOKCD.F61
	'�L�q��          :Standard Library
	'�쐬���t        :2011/02/21
	'�g�p�v���O����  :THSFP61
	'
	'
	
	Function ENDTOKCD_Check(ByVal ENDTOKCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTOKCD_Check = 0
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(ENDTOKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(ENDTOKCD) = 0 Or Trim(ENDTOKCD) = "" Then
		Else
			Call DB_GetLsEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
			Else
				Call DB_GetLsEq(DBN_SIRMTA, 1, ENDTOKCD, BtrNormal)
				If DBSTAT = 0 Then
					If DB_TOKMTA.DATKB = "9" Then
						Call TOKMTA_RClear()
					End If
				Else
					Call TOKMTA_RClear()
				End If
			End If
		End If
	End Function
	Function ENDTOKCD_Slist(ByRef PP As clsPP, ByVal ENDTOKCD As Object) As Object
		
		WGDENKB = FR_SSSMAIN.HD_THSCD.Text
		WGDENKB = IIf(WGDENKB = "9" Or WGDENKB = "0", "1", WGDENKB)
		WLS_THS1.ShowDialog()
		WLS_THS1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTOKCD_Slist = PP.SlistCom
	End Function
	Function ENDTOKCD_InitVal(ByVal ENDTOKCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTOKCD_InitVal = "�����"
	End Function
End Module