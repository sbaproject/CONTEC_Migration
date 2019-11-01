Option Strict Off
Option Explicit On
Module MONUPDYM_F51
	'
	' �X���b�g��        : �O�񌎎��X�V���s���t�E��ʍ��ڃX���b�g
	' ���j�b�g��        : MONUPDYM.F02
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/06/26
	' �g�p�v���O������  : ENDFP01
	'
	'
	Dim NotFirst As Short
	
	Function MONUPDYM_Check(ByRef MONUPDYM As Object) As Object
		Dim Rtn As Short
		Dim W_dt As String
		Dim W_nxtdt As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		MONUPDYM_Check = 0
		''
		''2001/05/11 '���t�͈̓`�F�b�N��ǉ�
		If Not CHECK_DATE(MONUPDYM) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			MONUPDYM_Check = -1
			Exit Function
		End If
		''
		Call DB_GetFirst(DBN_SYSTBA, 1, BtrNormal) 'Insert
		'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		W_dt = Get_TouAcedt(CShort(LeftWid(MONUPDYM, 4)), CShort(MidWid(MONUPDYM, 6, 2)))
		If W_dt <= CNV_DATE(DB_SYSTBA.MONUPDDT) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 3) ' �����X�V�ρB
			'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			MONUPDYM_Check = -1
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(MidWid(DB_SYSTBA.MONUPDDT, 5, 2)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g W_nxtdt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		W_nxtdt = CStr(DateSerial(SSSVal(LeftWid(DB_SYSTBA.MONUPDDT, 4)), SSSVal(MidWid(DB_SYSTBA.MONUPDDT, 5, 2)) + 1, 1))
		'UPGRADE_WARNING: �I�u�W�F�N�g W_nxtdt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		W_nxtdt = Get_TouAcedt(CShort(LeftWid(W_nxtdt, 4)), CShort(MidWid(W_nxtdt, 6, 2)))
		If DB_SYSTBA.ZAIHYKKB <> "1" And W_dt > CNV_DATE(DB_SYSTBA.HYKSTTDT) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g W_nxtdt �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If W_nxtdt < W_dt Then
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 4) ' �O�������X�V�v���B
				'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				MONUPDYM_Check = -1
			End If
		End If
		
	End Function
	
	Function MONUPDYM_InitVal(ByVal MONUPDYM As Object) As Object
		'
		If NotFirst = False Or Not IsDate(MONUPDYM) Then
			NotFirst = True
			MONUPDYM_InitVal = DateAdd(Microsoft.VisualBasic.DateInterval.Month, -1, Today)
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g MONUPDYM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			MONUPDYM_InitVal = MONUPDYM
		End If
	End Function
End Module