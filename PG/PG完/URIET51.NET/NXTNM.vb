Option Strict Off
Option Explicit On
Module NXTNM_F51
	'
	' �X���b�g��        : ���[�敪���́E��ʍ��ڃX���b�g
	' ���j�b�g��        : NXTNM.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	
	'���i�t�@�C����菤�i���P�擾�B
	Function NXTNM_Derived(ByVal NXTKB As Object, ByVal ENTDT As Object) As Object
		'    If Not IsNull(NXTKB) Then
		'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NXTKB) <> "" Then
			'If SSSVal(NXTKB) = 1 Or SSSVal(NXTKB) = 2 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g NXTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NXTNM_Derived = Mid(SSS_SSADT.Value, 5, 2) & "/" & Mid(SSS_SSADT.Value, 7, 2) & "����"
			'End If
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g NXTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NXTNM_Derived = ""
		End If
	End Function
End Module