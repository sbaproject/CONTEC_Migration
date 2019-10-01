Option Strict Off
Option Explicit On
Module DENDT_F52
	'
	' �X���b�g��        : ����`�[���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : DENDT.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/22
	' �g�p�v���O������  : URIPR52
	'
	Dim NotFirst As Short
	
	Function DENDT_CheckC(ByVal DENDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DENDT) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENDT_CheckC = -1
		Else
			If CHECK_DATE(DENDT) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DENDT_CheckC = 0
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DENDT_CheckC = -1
			End If
		End If
	End Function
	
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		If NotFirst = False Or Not IsDate(DENDT) Then
			NotFirst = True
			'DENDT_InitVal = Date
			'�^�p���t
			'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENDT_InitVal = DB_UNYMTA.UNYDT
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DENDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENDT_InitVal = DENDT
		End If
	End Function
	
	Function DENDT_Skip(ByRef CT_DENDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_DENDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019.04.08 CHG START
        'CT_DENDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
        DirectCast(CT_DENDT, TextBox).SelectionStart = 0
        '2019.04.08 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_Skip = False
	End Function
	
	Function DENDT_Slist(ByRef PP As clsPP, ByVal DENDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = DENDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_Slist = Set_date.Value
	End Function
End Module