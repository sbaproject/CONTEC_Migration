Option Strict Off
Option Explicit On
Module TOKCD_F53
	'
	'�X���b�g��      :���Ӑ�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :TOKCD.F53
	'�L�q��          :Standard Library
	'�쐬���t        :2006/07/22
	'�g�p�v���O����  :SODET53
	'
	
	Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
        '2019/06/04 CHG START
        'WLSTOK.ShowDialog()
        'WLSTOK.Close()
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        '2019/06/04 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        TOKCD_Slist = PP.SlistCom
	End Function
End Module