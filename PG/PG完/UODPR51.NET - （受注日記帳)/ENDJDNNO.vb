Option Strict Off
Option Explicit On
Module ENDJDNNO_F61
	'
	' �X���b�g��        : �I���󒍓`�[�ԍ��E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDJDNNO.F61
	' �L�q��            : Muratani
	' �쐬���t          : 2006/09/28
	' �g�p�v���O������  : UODPR51
	'
	
	Function ENDJDNNO_Check(ByVal ENDJDNNO As Object, ByVal STTJDNNO As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDJDNNO_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If ENDJDNNO = "" Then
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g STTJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If ENDJDNNO < STTJDNNO Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ENDJDNNO_Check = -1
			End If
		End If
	End Function
	
	Function ENDJDNNO_InitVal(ByVal ENDJDNNO As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDJDNNO_InitVal = FillVal("", LenWid(DB_JDNTRA.JDNNO))
	End Function
	
	Function ENDJDNNO_Slist(ByRef PP As clsPP, ByVal ENDJDNNO As Object) As Object
        'change start 20190808 kuwahara
        'DB_PARA(DBN_JDNTHA).KeyNo = 2
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "1"
        WLSJDN1.JDN1_PARA1 = "1" & "1"
        'change end 20190808 kuwahara

        '2019.03.26 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019.03.26 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDJDNNO_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDJDNNO_Slist = PP.SlistCom
	End Function
End Module