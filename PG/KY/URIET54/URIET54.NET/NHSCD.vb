Option Strict Off
Option Explicit On
Module NHSCD_F51
	'
	'�X���b�g��      :�[����R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :NHSCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/07/26
	'�g�p�v���O����  :SODET51
	'
	
	Function NHSCD_Slist(ByRef PP As clsPP, ByVal NHSCD As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_NHSMTA).KeyBuf = NHSCD
		WLSNHS.ShowDialog()
		WLSNHS.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g NHSCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NHSCD_Slist = PP.SlistCom
	End Function
End Module