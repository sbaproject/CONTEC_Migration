Option Strict Off
Option Explicit On
Module STTKSIDT_F51
	'
	' �X���b�g��        : �J�n�`�[���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTKSIDT.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URKPR52
	'
	
	Function STTKSIDT_CheckC(ByVal STTKSIDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTKSIDT_CheckC = 0
		rtn = CHECK_DATE(STTKSIDT)
		If rtn Then
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTKSIDT_CheckC = -1
		End If
	End Function
	
	
	Function STTKSIDT_InitVal(ByVal STTKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTKSIDT_InitVal = DB_UNYMTA.UNYDT
	End Function
	
	Function STTKSIDT_Skip(ByRef CT_STTKSIDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_STTKSIDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CT_STTKSIDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTKSIDT_Skip = False
	End Function
	
	Function STTKSIDT_Slist(ByRef PP As clsPP, ByVal STTKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = STTKSIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTKSIDT_Slist = Set_date.Value
	End Function
End Module