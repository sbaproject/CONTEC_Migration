Option Strict Off
Option Explicit On
Module BNKCD_F51
	'
	'�X���b�g��      :��s�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :BNKCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/09/14
	'�g�p�v���O����  :BNKMT51
	'
	
	Function BNKCD_CheckC(ByRef BNKCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g BNKCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BNKCD_CheckC = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g BNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(BNKCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g BNKCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			BNKCD_CheckC = -1
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, BNKCD, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call Scr_FromMfil(De_Index)
				If DB_BNKMTA.DATKB = "9" Then
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
	
	Function BNKCD_Slist(ByRef PP As clsPP, ByVal BNKCD As Object) As Object
		'
		DB_PARA(DBN_BNKMTA).KeyNo = 1
		''''DB_PARA(DBN_BNKMTA).KeyBuf = BNKCD
		DB_PARA(DBN_BNKMTA).KeyBuf = ""
		WLSBNK.ShowDialog()
		WLSBNK.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g BNKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		BNKCD_Slist = PP.SlistCom
	End Function
End Module