Option Strict Off
Option Explicit On
Module ENDKSIDT_F51
	'
	' �X���b�g��        : �I���`�[���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDKSIDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URKPR52
	
	Function ENDKSIDT_Check(ByVal ENDKSIDT As Object, ByVal STTKSIDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDKSIDT_Check = 0
		Rtn = CHECK_DATE(ENDKSIDT)
		If Rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g STTKSIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDKSIDT < STTKSIDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDKSIDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDKSIDT_Check = -1
		End If
		
	End Function
	
	Function ENDKSIDT_InitVal(ByVal ENDKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDKSIDT_InitVal = DB_UNYMTA.UNYDT
	End Function
	
	Function ENDKSIDT_Skip(ByRef CT_ENDKSIDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_ENDKSIDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CT_ENDKSIDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDKSIDT_Skip = False
	End Function
	
	Function ENDKSIDT_Slist(ByRef PP As clsPP, ByVal ENDKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = ENDKSIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDKSIDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDKSIDT_Slist = Set_date.Value
	End Function
End Module