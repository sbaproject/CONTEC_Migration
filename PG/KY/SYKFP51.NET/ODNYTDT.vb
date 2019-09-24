Option Strict Off
Option Explicit On
Module ODNYTDT_F51
	'
	' �X���b�g��        : �o�ח\����E��ʍ��ڃX���b�g
	' ���j�b�g��        : ODNYTDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2005/06/20
	' �g�p�v���O������  : SYKFP51
	'
	'
	Dim NotFirst As Short
	
	Function ODNYTDT_CheckC(ByVal ODNYTDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ODNYTDT_CheckC = 0
		rtn = CHECK_DATE(ODNYTDT)
		If rtn Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ODNYTDT < CNV_DATE(DB_UNYMTA.UNYDT) Then
				rtn = DSP_MsgBox(SSS_CONFRM, "SYKFP51", 0) '�������O���w��͓��͂ł��܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ODNYTDT_CheckC = -1
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If CHK_KADOYMD(ODNYTDT) = False Then
					rtn = DSP_MsgBox(SSS_CONFRM, "SYKFP51", 1) '�\�����ғ����ȍ~���͓��͂ł��܂���B
					'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ODNYTDT_CheckC = -1
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If ODNYTDT <> CNV_DATE(DB_UNYMTA.UNYDT) Then
						If DSP_MsgBox(SSS_CONFRM, "SYKFP51", 2) <> IDYES Then '���ғ������w�肵�Ă��܂��B���s���Ă���낵���ł����H
							'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							ODNYTDT_CheckC = 1
						End If
					End If
				End If
			End If
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ODNYTDT_CheckC = -1
		End If
	End Function
	
	Function ODNYTDT_InitVal(ByVal ODNYTDT As Object) As Object
		'''''If NotFirst = False Or Not IsDate(ODNYTDT) Then
		''''    NotFirst = True
		''''    ODNYTDT_InitVal = DB_UNYMTA.UNYDT       '�^�p���}�X�^�̉^�p���B
		''''Else
		''''    ODNYTDT_InitVal = ODNYTDT        '�O�̓`�[�̓��t�B
		''''End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ODNYTDT_InitVal = DB_UNYMTA.UNYDT '�^�p���}�X�^�̉^�p���B
	End Function
	
	Function ODNYTDT_Skip(ByRef CT_ODNYTDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g CT_ODNYTDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/09/23 CHG START
        'CT_ODNYTDT.SelStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
        DirectCast(CT_ODNYTDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �̏ꏊ�փX�L�b�v�B
        '2019/09/23 CHG E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        ODNYTDT_Skip = False
	End Function
	
	Function ODNYTDT_Slist(ByVal ODNYTDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = ODNYTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g ODNYTDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ODNYTDT_Slist = Set_date.Value
	End Function
End Module