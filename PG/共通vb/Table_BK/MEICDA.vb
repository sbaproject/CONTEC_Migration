Option Strict Off
Option Explicit On
Module MEICDA_F52
    '
    '�X���b�g��      :�R�[�h1�����E��ʍ��ڃX���b�g
    '���j�b�g��      :MEICDA.F51
    '�L�q��          :Standard Library
    '�쐬���t        :2006/07/13
    '�g�p�v���O����  :MEIMT51
    '

    'Function MEICDA_CheckC(ByRef MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	Dim Rtn As Short
    '	Dim wkMEICDA As String
    '	Dim strSql As String
    '	Dim lngCount As Integer
    '	'
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	MEICDA_CheckC = 0
    '	' �����͂̏ꍇ�ɂ�, �G���[���������ɖ��̓����N���A����
    '	'Call MEIMTA_RClear
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If Trim(MEICDA) = "" Then
    '		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		MEICDA_CheckC = -1
    '	Else
    '		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		wkMEICDA = MEICDA & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(MEICDA)))
    '		'�R�[�h�P�Ō�������
    '		strSql = ""
    '		strSql = strSql & "Select Count(*) From MEIMTA"
    '		strSql = strSql & " Where DATKB = '1'"
    '		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		strSql = strSql & "   And KEYCD  = " & "'" & FRKEYCD & "'"
    '		strSql = strSql & "   And MEICDA = " & "'" & wkMEICDA & "'"
    '		Call DB_GetSQL2(DBN_MEIMTA, strSql)
    '		lngCount = DB_ExtNum.ExtNum(0)
    '		If lngCount >= 2 Then '�������Q���ȏ�̎��͉������Ȃ�
    '			Exit Function
    '		End If

    '		'�������P���̎�
    '		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & wkMEICDA & "     ", BtrNormal)
    '		If DBSTAT = 0 Then
    '			If DB_MEIMTA.DATKB = "9" Then
    '				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '                   Call DP_SSSMAIN_UPDKB(DE_INDEX, "�폜")

    '                   '20190218
    '                   'Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B

    '				'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				MEICDA_CheckC = 1
    '			Else
    '				'�X�V�f�[�^
    '				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "�X�V")
    '			End If
    '			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			Call SCR_FromMfil(DE_INDEX)
    '		Else
    '			''''''''''''Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �V�K���R�[�h�ł��B
    '			''''''''''''MEICDA_CheckC = -1
    '			''''''''''''Call MEIMTA_RClear
    '			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			Call DP_SSSMAIN_UPDKB(DE_INDEX, "�ǉ�")
    '		End If
    '	End If


    'End Function

    'Function MEICDA_Slist(ByRef PP As clsPP, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	WLS_MEI1.Text = "���̺��ވꗗ"
    '	CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
    '       SSS_MFILCNT = 0

    '       '20190226
    '       'Call DB_GetFirst(DBN_MEIMTA, 3, BtrNormal)
    '       ''* �����Ƃ��� WLS_MEI1 �͍ŏ�����f�[�^��\������.
    '       ''Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
    '       'Call DB_GetGrEq(DBN_MEIMTA, 3, FRKEYCD, BtrNormal)
    '       ''UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       'Do While (DBSTAT = 0) And (DB_MEIMTA.KEYCD = FRKEYCD)
    '       '	If DB_MEIMTA.DATKB = "1" Then
    '       '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDA & " " & DB_MEIMTA.MEINMA)
    '       '		SSS_MFILCNT = SSS_MFILCNT + 1
    '       '	End If
    '       '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '       'Loop 

    '	'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '       'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)

    '       PP.SlistCom = System.DBNull.Value
    '       'Call MEIMTA_GetFirst(FRKEYCD, "", "     ")
    '       Dim pWhere As String = ""
    '       pWhere = "WHERE KEYCD = '" & FRKEYCD & "'"
    '       Call GetRowsCommon("MEIMTA", pWhere)

    '       SSS_WLSLIST_KETA = DB_MEIMTA.MEICDA.Length

    '       WLS_MEI1.ShowDialog()
    '	WLS_MEI1.Close()
    '	'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	MEICDA_Slist = PP.SlistCom
    'End Function
End Module