Option Strict Off
Option Explicit On
Module NHSNMA_F71
	'
	' �X���b�g��        : �[���於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : NHSNMA.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/09/26
	' �g�p�v���O������  : NHSMR51
	'
	
	Function NHSNMA_Check(ByVal NHSNMA As Object, ByVal NHSCD As Object) As Object
		Dim rtn As Short
		
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMA_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSNMA_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NHSCD) <> "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(NHSNMA) = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g NHSNMA_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				NHSNMA_Check = -1
			End If
		End If
	End Function
End Module