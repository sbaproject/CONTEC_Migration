Option Strict Off
Option Explicit On
Module STNNM_F51
	'
	'�X���b�g��      :�x�X���́E��ʍ��ڃX���b�g
	'���j�b�g��      :STNNM.FM1
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/25
	'�g�p�v���O����  :BNKMT51
	'
	
	Function STNNM_CheckC(ByRef STNNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STNNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STNNM_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g STNNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(STNNM) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g STNNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			STNNM_CheckC = -1
		End If
	End Function
End Module