Option Strict Off
Option Explicit On
Module ZKTNM_F01
	'
	' �X���b�g��        : ����敪���́E��ʍ��ڃX���b�g
	' ���j�b�g��        : ZKTNM.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	'
	
	'���i�t�@�C����菤�i���P�擾�B
	Function ZKTNM_Derived(ByVal ZKTKB As Object) As Object
		Select Case ZKTKB
			Case "1"
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTNM_Derived = "�ʏ�"
			Case "2"
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTNM_Derived = "����"
			Case "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTNM_Derived = "�a��"
			Case "4"
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTNM_Derived = "�ϑ�"
			Case Else
				'UPGRADE_WARNING: �I�u�W�F�N�g ZKTNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ZKTNM_Derived = "�ʏ�"
		End Select
	End Function
End Module