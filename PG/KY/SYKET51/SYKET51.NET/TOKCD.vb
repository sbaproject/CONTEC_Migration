Option Strict Off
Option Explicit On
Module TOKCD_F52
	'
	'�X���b�g��      :���Ӑ�R�[�h(�̔��P���}�X�^�o�^�j�E��ʍ��ڃX���b�g
	'���j�b�g��      :TOKCD.FM4
	'�L�q��          :Standard Library
	'�쐬���t        :1997/07/03
	'�g�p�v���O����  :SIRMT03
	'
	
	Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
		WLSTOK.ShowDialog()
		WLSTOK.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		TOKCD_Slist = PP.SlistCom
	End Function
End Module