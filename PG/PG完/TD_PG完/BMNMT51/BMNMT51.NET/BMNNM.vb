Option Strict Off
Option Explicit On
Module BMNNM_F51
	'
	'�X���b�g��      :���喼�́E��ʍ��ڃX���b�g
	'���j�b�g��      :BMNNM.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/30
	'�g�p�v���O����  :BNKMT51
	'
	
	Function BMNNM_CheckC(ByRef BMNNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BMNNM_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g BMNNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BMNNM) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g BMNNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			BMNNM_CheckC = -1
		End If
	End Function
End Module