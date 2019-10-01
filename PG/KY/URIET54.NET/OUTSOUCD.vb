Option Strict Off
Option Explicit On
Module OUTSOUCD_F51
	'
	'�X���b�g��      :�q�ɃR�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :OUTSOUCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/09/11
	'�g�p�v���O����  :URIET54/URIET55
	'
	'
	Function OUTSOUCD_CheckC(ByVal OUTSOUCD As Object, ByVal DE_INDEX As Object) As Object
		Dim rtn As Short
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        OUTSOUCD_CheckC = 0
        '2019/09/19 DEL START
        'Call SOUMTA_RClear()
        '2019/09/19 DEL E N D
        'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(OUTSOUCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(OUTSOUCD) = 0 Or Trim(OUTSOUCD) = "" Then
		Else
			Call DB_GetEq(DBN_SOUMTA, 1, OUTSOUCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_SOUMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					OUTSOUCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				OUTSOUCD_CheckC = -1
			End If
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Call SCR_FromSOUMTA(DE_INDEX)
	End Function
	
	Function OUTSOUCD_Slist(ByRef PP As clsPP, ByVal OUTSOUCD As Object) As Object
        '2019/09/30 DEL START
        'DB_PARA(DBN_SOUMTA).KeyNo = 1
        'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'DB_PARA(DBN_SOUMTA).KeyBuf = OUTSOUCD
        '2019/09/30 DEL E N D
        WLSSOU.ShowDialog()
		WLSSOU.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g OUTSOUCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		OUTSOUCD_Slist = PP.SlistCom
	End Function
End Module