Option Strict Off
Option Explicit On
Module ZKTKB_F01
	'
	' �X���b�g��        : ����敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ZKTKB.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	'
	
	Function ZKTKB_CheckC(ByRef ZKTKB As Object) As Object
		If Not IsNumeric(ZKTKB) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ZKTKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ZKTKB_CheckC = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(ZKTKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(ZKTKB) < 1 Or SSSVal(ZKTKB) > 2 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTKB = "1"
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTKB_CheckC = 0
			End If
		End If
	End Function
	
	Function ZKTKB_InitVal() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g ZKTKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ZKTKB_InitVal = "1"
	End Function
	
	Function ZKTKB_Slist(ByRef PP As clsPP) As Object
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("1 �ʏ�")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("2 ����")
		SSS_WLSLIST_KETA = 1
		WLS_LIST.Text = "����`��"
		WLS_LIST.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SLISTCOM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ZKTKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ZKTKB_Slist = PP.SLISTCOM
	End Function
End Module