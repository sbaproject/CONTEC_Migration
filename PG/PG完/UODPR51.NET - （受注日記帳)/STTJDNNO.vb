Option Strict Off
Option Explicit On
Module STTJDNNO_F61
	'
	' �X���b�g��        : �J�n�󒍓`�[�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : STTJDNNO.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : UODPR51
	'
	
	Function STTJDNNO_InitVal() As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTJDNNO_InitVal = FillVal("", LenWid(DB_JDNTRA.JDNNO))
	End Function
	
	Function STTJDNNO_Slist(ByRef PP As clsPP, ByVal STTJDNNO As Object) As Object
        'delete start 20190808 kuwahara
        'DB_PARA(DBN_JDNTHA).KeyNo = 2
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "1"
        'delete end 20190808 kuwahara
        'add start 20190808 kuwahara
        WLSJDN1.JDN1_PARA1 = "1" & "1"
        'add end 20190808 kuwahara
        '2019.03.26 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019.03.26 CHG END
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTJDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTJDNNO_Slist = PP.SlistCom
	End Function
End Module