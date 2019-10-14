Option Strict Off
Option Explicit On
Module ENDOUTDT_F51
	'
	' �X���b�g��        : �I���E���͓��t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDWRTDT.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  : IDOPR53
	'
	'
	
	Function ENDOUTDT_Check(ByVal ENDOUTDT As Object, ByVal STTOUTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDOUTDT_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDOUTDT) = "" Then
			Exit Function
		End If
		Rtn = CHECK_DATE(ENDOUTDT)
		If Rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g STTOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDOUTDT < STTOUTDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDOUTDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDOUTDT_Check = -1
		End If
	End Function
	
	Function ENDOUTDT_InitVal(ByVal ENDOUTDT As Object) As Object
		'
		''''ENDOUTDT_InitVal = Date
		''''ENDOUTDT_InitVal = DB_UNYMTA.UNYDT              '2006.12.06
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDOUTDT_InitVal = ""
	End Function
	
	Function ENDOUTDT_Skip(ByRef CT_ENDOUTDT As System.Windows.Forms.Control, ByVal ENDOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(ENDOUTDT) <> "" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g CT_ENDOUTDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '2019/10/09 CHG START
            'CT_ENDOUTDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
            DirectCast(CT_ENDOUTDT, TextBox).SelectionStart = 8
            '2019/10/09 CHG E N D
            'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            ENDOUTDT_Skip = False
		End If
	End Function
	
	Function ENDOUTDT_Slist(ByRef PP As clsPP, ByVal ENDOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = ENDOUTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDOUTDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDOUTDT_Slist = Set_date.Value
	End Function
End Module