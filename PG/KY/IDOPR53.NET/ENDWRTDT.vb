Option Strict Off
Option Explicit On
Module ENDWRTDT_F57
	'
	' �X���b�g��        : �I���E���͓��t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDWRTDT.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  :
	'
	'
	
	Function ENDWRTDT_Check(ByVal ENDWRTDT As Object, ByVal STTWRTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDWRTDT_Check = 0
		Rtn = CHECK_DATE(ENDWRTDT)
		If Rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDWRTDT < STTWRTDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDWRTDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ENDWRTDT_Check = -1
		End If
	End Function
	
	Function ENDWRTDT_InitVal(ByVal ENDWRTDT As Object) As Object
		'
		''''ENDWRTDT_InitVal = Date
		
		'2008/0929 CHG START FKS)NAKATA
		'�^�p���t����V�X�e�����t�ɕύX
		'    ENDWRTDT_InitVal = DB_UNYMTA.UNYDT
		ENDWRTDT_InitVal = VB6.Format(Today, "YYYYMMDD")
		'2008/09/29 CHG E.N.D FKS)NAKATA
		
	End Function
	
	Function ENDWRTDT_Skip(ByRef CT_ENDWRTDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g CT_ENDWRTDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CT_ENDWRTDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDWRTDT_Skip = False
	End Function
	
	Function ENDWRTDT_Slist(ByRef PP As clsPP, ByVal ENDWRTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = ENDWRTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDWRTDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDWRTDT_Slist = Set_date.Value
	End Function
End Module