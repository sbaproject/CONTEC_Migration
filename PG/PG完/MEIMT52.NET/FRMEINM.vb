Option Strict Off
Option Explicit On
Module FRMEINM_F51
	'
	' �X���b�g��        : KEY���́E��ʍ��ڃX���b�g
	' ���j�b�g��        : FRMEINM.F51
	' �L�q��            :  Library
	' �쐬���t          : 2006/07/12
	' �g�p�v���O������  : MEIMT51
	'
	'
	
	Function FRMEINM_CheckC(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object

        '20190826 DEL START
        'Call MEIMTB_RClear()
        '20190826 DEL END

        'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(FRKEYCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(FRKEYCD) = "" Or LenWid(Trim(FRKEYCD)) = 0 Then
			Exit Function
		End If
		'geteq�ł�KEYCD�̖��̂����o���h���̂Œ��ږ��̂����o���B
		'Call DB_GetSQL2(DBN_MEIMTA, "select distinct MEIKMKNM from meimta where KEYCD='" & FRKEYCD & "'")
		Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case Trim(FRKEYCD)
				Case ""
					DB_MEIMTA.MEIKMKNM = ""
				Case Else
					DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
			End Select
		Else
			DB_MEIMTA.MEIKMKNM = ""
		End If
		
	End Function
	
	Function FRMEINM_DerivedC(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(FRKEYCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(FRKEYCD) = "" Or LenWid(Trim(FRKEYCD)) = 0 Then
			Exit Function
		End If
		'geteq�ł�KEYCD�̖��̂����o���h���̂Œ��ږ��̂����o���B
		'Call DB_GetSQL2(DBN_MEIMTA, "select distinct MEIKMKNM from meimta where KEYCD='" & FRKEYCD & "'")
		Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case Trim(FRKEYCD)
				Case ""
					'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FRMEINM_DerivedC = ""
				Case Else
					'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					FRMEINM_DerivedC = DB_MEIMTB.MEIKMKNM
			End Select
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRMEINM_DerivedC = ""
		End If
		
	End Function
	
	Function FRMEINM_InitVal(ByVal FRKEYCD As Object, ByVal FRMEINM As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(FRKEYCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRMEINM_InitVal = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g FRMEINM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			FRMEINM_InitVal = DB_MEIMTB.MEIKMKNM
		End If
		
	End Function
End Module