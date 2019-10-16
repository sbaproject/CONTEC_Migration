Option Strict Off
Option Explicit On
Module UNTCD_FM1
	'
	'�X���b�g��      :�P�ʃR�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :UNTCD.FM1   
	'�L�q��          :Standard Library
	'�쐬���t        :1997/05/28
	'�g�p�v���O����  :UNTMT01
	'
	
	Function UNTCD_CheckC(ByVal UNTCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g UNTCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UNTCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g UNTCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(UNTCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g UNTCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			UNTCD_CheckC = -1
		Else

            '2019/10/11 CHG START
            'Call DB_GetEq(DBN_UNTMTA, 1, UNTCD, BtrNormal)
            GetRowsCommon(DBN_UNTMTA, "where UNTCD = '" & UNTCD & "'")
            '2019/10/11 CHG END

            If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call Scr_FromMfil(De_Index)
				If DB_UNTMTA.DATKB = "9" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�폜")
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_UPDKB(De_Index, "�X�V")
				End If
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DP_SSSMAIN_UPDKB(De_Index, "�ǉ�")
			End If
		End If
	End Function
	
	Function UNTCD_Slist(ByRef PP As clsPP, ByVal UNTCD As Object) As Object
		'
		WLS_LIST.Text = "�P�ʈꗗ"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetFirst(DBN_UNTMTA, 1, BtrNormal)
		Do While DBSTAT = 0
			If DB_UNTMTA.DATKB <> "9" Then CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_UNTMTA.UNTCD & " " & DB_UNTMTA.UNTNM)
			Call DB_GetNext(DBN_UNTMTA, BtrNormal)
		Loop
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B

        SSS_WLSLIST_KETA = LenWid(DB_UNTMTA.UNTCD)
        '2019/10/11 ADD START
        If SSS_WLSLIST_KETA = 0 Then
            SSS_WLSLIST_KETA = 2
        End If
        '2019/10/11 ADD END
        WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g UNTCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		UNTCD_Slist = PP.SlistCom
	End Function
End Module