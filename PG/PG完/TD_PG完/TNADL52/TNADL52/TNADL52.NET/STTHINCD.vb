Option Strict Off
Option Explicit On
Module STTHINCD_F81
	'
	' �X���b�g��        : �J�n���i�R�[�h�E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTHINCD.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function STTHINCD_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTHINCD_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINCD))
	End Function
	
	Function STTHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
        '
        '    If IsNull(STTHINCD) Then
        '        DB_PARA(DBN_HINMTA).KeyBuf = ""
        '     Else
        '        DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
        '    End If
        'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190716 DELL START
        'DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
        '20190716 DELL END
        '20190712 CHG START
        '      WLSHIN.ShowDialog()
        'WLSHIN.Close()
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        '20190712 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g STTHINCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        STTHINCD_Slist = PP.SlistCom
	End Function
End Module