Option Strict Off
Option Explicit On
Module TANCD_F54
    '
    '�X���b�g��      :�S���҃R�[�h�E��ʍ��ڃX���b�g
    '���j�b�g��      :TANCD.F54

    '�L�q��          :Standard Library
    '�쐬���t        :2006/08/24
    '�g�p�v���O����  :URIET53/SEIPR54
    '

    Function TANCD_Slist(ByRef PP As clsPP, ByVal TANCD As Object) As Object
		'
		DB_PARA(DBN_TANMTA).KeyNo = 1
		'UPGRADE_WARNING: �I�u�W�F�N�g TANCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DB_PARA(DBN_TANMTA).KeyBuf = TANCD
        '2019/06/04 CHG START
        'WLSTAN.ShowDialog()
        'WLSTAN.Close()
        WLSTAN2.ShowDialog()
        WLSTAN2.Close()
        '2019/06/04 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SLISTCOM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TANCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        TANCD_Slist = PP.SLISTCOM
	End Function
End Module