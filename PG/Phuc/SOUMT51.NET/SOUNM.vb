Option Strict Off
Option Explicit On
Module SOUNM_F53
	'
	' �X���b�g��        : �q�ɖ��́E��ʍ��ڃX���b�g
	' ���j�b�g��        : SOUNM.F52
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/26
	' �g�p�v���O������  : SOUMT51
	'
	
	Function SOUNM_CHECK(ByVal SOUNM As Object, ByVal SOUCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(SOUCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g SOUNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(SOUNM) = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g SOUNM_CHECK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				SOUNM_CHECK = -1
			End If
		End If
		
	End Function
End Module