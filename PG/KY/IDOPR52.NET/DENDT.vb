Option Strict Off
Option Explicit On
Module DENDT_F54
	'
	' �X���b�g��        : �ړ��`�[���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : DENDT.F54
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/22
	' �g�p�v���O������  : IDOPR52
	'
	Dim NotFirst As Short
	
	Function DENDT_CheckC(ByRef DENDT As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(DENDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂��B
			'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DENDT_CheckC = -1
		Else
			If Not IsDate(DENDT) Then
				rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂��B
				'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				DENDT_CheckC = -1
			Else
				'        '�^�p���t�Ƃ�����
				'             If CLng(Format(DENDT, "YYYYMMDD")) > CLng(DB_UNYMTA.UNYDT) Then
				'                 rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)  '���t�Ɍ�肪����܂��B�C�����Ă��������B
				'                 DENDT_CheckC = -1
				'             End If
			End If
		End If
	End Function
	
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		'
		''''If Trim(DENDT) = "" Then                                        '2006.10.19
		''''    DENDT_InitVal = DB_UNYMTA.UNYDT     '�^�p�̓��t�B           '2006.10.19
		''''Else                                                            '2006.10.19
		''''    DENDT_InitVal = DENDT               '�O�̓��t�B             '2006.10.19
		''''End If                                                          '2006.10.19
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_InitVal = ""
	End Function
	
	Function DENDT_Skip(ByRef CT_DENDT As System.Windows.Forms.Control) As Object
		'
		''''CT_DENDT.SelStart = 8 'yyyy-mm-dd �� dd �̂Ƃ���B              '2006.10.19
		''''DENDT_Skip = False                                              '2006.10.19
	End Function
	
	Function DENDT_Slist(ByVal DENDT As Object, ByRef PP As clsPP) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Set_date.Value = DENDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_Slist = Set_date.Value
		
	End Function
End Module