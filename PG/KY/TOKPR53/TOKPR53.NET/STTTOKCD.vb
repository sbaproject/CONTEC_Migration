Option Strict Off
Option Explicit On
Module STTTOKCD_F56
	'
	'�X���b�g��      :���Ӑ�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :TOKCD.F56
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/11
	'�g�p�v���O����  :nykpr52
	'
	'
	
	Function STTTOKCD_Check(ByVal STTTOKCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_Check = 0
		Call TOKMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTTOKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If LenWid(STTTOKCD) = 0 Or Trim(STTTOKCD) = "" Then
		Else
			Call DB_GetLsEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call TOKMTA_RClear()
				End If
			Else
				Call TOKMTA_RClear()
			End If
		End If
		'Call SCR_FromTOKMTA(De_Index)
	End Function
	
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		'
		DB_PARA(DBN_TOKMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TOKMTA).KeyBuf = STTTOKCD
		WLSTOK.ShowDialog()
		WLSTOK.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_Slist = PP.SlistCom
	End Function
	Function STTTOKCD_InitVal(ByVal STTTOKCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_InitVal = " "
		
	End Function
End Module