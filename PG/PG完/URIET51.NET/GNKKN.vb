Option Strict Off
Option Explicit On
Module GNKKN_F04
	'
	' �X���b�g��        : �������z�E��ʍ��ڃX���b�g
	' ���j�b�g��        : GNKKN.F04
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/05/24
	' �g�p�v���O������  : URIET01, URIET02
	
	'�����P�������㐔��
	Function GNKKN_Derived(ByVal GNKKN As Object, ByVal GNKTK As Object, ByVal URISU As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GNKKN_Derived = GNKKN
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKTK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(GNKTK) = "" Or Not IsNumeric(GNKTK) Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		'' 2003/08/28 �ύX�����P�� �� 0 �̏ꍇ�O��̋��z���c��
		''If GNKTK <> 0 And URISU <> 0 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g GNKTK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		GNKKN_Derived = DCMFRC(GNKTK * URISU, 5, 0)
		''End If
	End Function
End Module