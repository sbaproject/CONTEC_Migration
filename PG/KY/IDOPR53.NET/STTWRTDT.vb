Option Strict Off
Option Explicit On
Module STTWRTDT_F57
	'
	' �X���b�g��        : �J�n�E���͓��t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTWRTDT.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  :
	'
	
	Function STTWRTDT_CheckC(ByVal STTWRTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTWRTDT_CheckC = 0
		Rtn = CHECK_DATE(STTWRTDT)
		If Rtn Then
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STTWRTDT_CheckC = -1
		End If
	End Function
	
	
	Function STTWRTDT_InitVal(ByVal STTWRTDT As Object) As Object
		'
		''''STTWRTDT_InitVal = Date
		
		'2008/0929 CHG START FKS)NAKATA
		'�^�p���t����V�X�e�����t�ɕύX
		'   STTWRTDT_InitVal = DB_UNYMTA.UNYDT
		STTWRTDT_InitVal = VB6.Format(Today, "YYYYMMDD")
		'2008/09/29 CHG E.N.D FKS)NAKATA
		
	End Function
	
	Function STTWRTDT_Skip(ByRef CT_STTWRTDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g CT_STTWRTDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/10/11 CHG START
        'CT_STTWRTDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B
        DirectCast(CT_STTWRTDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
        '2019/10/11 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        STTWRTDT_Skip = False
	End Function
	
	Function STTWRTDT_Slist(ByRef PP As clsPP, ByVal STTWRTDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = STTWRTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g STTWRTDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTWRTDT_Slist = Set_date.Value
	End Function
End Module