Option Strict Off
Option Explicit On
Module MAEUKNM_F61
	'
	' �X���b�g��        : �������́E��ʍ��ڃX���b�g
	' ���j�b�g��        : MAEUKNM.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/07/25
	' �g�p�v���O������  : URIET51
	
	Function MAEUKNM_Derived(ByVal MAEUKKB As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g MAEUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(MAEUKKB) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g MAEUKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case Trim(MAEUKKB)
				Case "1"
					'UPGRADE_WARNING: �I�u�W�F�N�g MAEUKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					MAEUKNM_Derived = "�ʏ�"
				Case "2"
					'UPGRADE_WARNING: �I�u�W�F�N�g MAEUKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					MAEUKNM_Derived = "�O��"
			End Select
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g MAEUKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			MAEUKNM_Derived = ""
		End If
	End Function
End Module