Option Strict Off
Option Explicit On
Module HINCD_F54
	'
	'�X���b�g��      :���i�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :HINCD.F54
	'�L�q��          :Standard Library
	'�쐬���t        :2006/07/16
	'�g�p�v���O����  :SYKET51
	'
	
	Function HINCD_Slist(ByRef PP As clsPP, ByVal HINCD As Object) As Object
		'
		DB_PARA(DBN_HINMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_HINMTA).KeyBuf = HINCD
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g HINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        HINCD_Slist = PP.SlistCom
	End Function
End Module