Option Strict Off
Option Explicit On
Module BNKNM_F51
	'
	'�X���b�g��      :��s���́E��ʍ��ڃX���b�g
	'���j�b�g��      :BNKNM.FM1
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/25
	'�g�p�v���O����  :BNKMT51
	'
	
	Function BNKNM_CheckC(ByRef BNKNM As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g BNKNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BNKNM_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g BNKNM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BNKNM) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g BNKNM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			BNKNM_CheckC = -1
		End If
	End Function
End Module