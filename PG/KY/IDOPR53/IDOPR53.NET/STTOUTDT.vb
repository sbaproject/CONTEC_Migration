Option Strict Off
Option Explicit On
Module STTOUTDT_F51
	'
	' �X���b�g��        : �J�n�E���͓��t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTWRTDT.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  : IDOPR53
	'
	
	Function STTOUTDT_CheckC(ByVal STTOUTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTOUTDT_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTOUTDT) = "" Then
			Exit Function
		End If
		Rtn = CHECK_DATE(STTOUTDT)
		If Rtn Then
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTOUTDT_CheckC = -1
		End If
	End Function
	
	Function STTOUTDT_InitVal(ByVal STTOUTDT As Object) As Object
		'
		''''STTOUTDT_InitVal = Date
		''''STTOUTDT_InitVal = DB_UNYMTA.UNYDT          '2006.12.06
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTOUTDT_InitVal = ""
	End Function
	
	Function STTOUTDT_Skip(ByRef CT_STTOUTDT As System.Windows.Forms.Control, ByVal STTOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STTOUTDT) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CT_STTOUTDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CT_STTOUTDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
			'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTOUTDT_Skip = False
		End If
	End Function
	
	Function STTOUTDT_Slist(ByRef PP As clsPP, ByVal STTOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = STTOUTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTOUTDT_Slist = Set_date.Value
	End Function
End Module