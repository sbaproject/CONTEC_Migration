Option Strict Off
Option Explicit On
Module MEICDB_F52
    '
    '�X���b�g��      :�R�[�h2�E��ʍ��ڃX���b�g
    '���j�b�g��      :MEICDB.F52
    '�L�q��          :Standard Library
    '�쐬���t        :2006/07/12
    '�g�p�v���O����  :MEIMT51
    '

    'Function MEICDB_CheckC(ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	''''2006.07.24�s�v
    '	Dim Rtn As Short
    '	'
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	MEICDB_CheckC = 0

    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If Trim(MEICDB) = "" Then
    '		'        MEICDB_CheckC = -1
    '	Else
    '		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '		Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
    '		If DBSTAT = 0 Then
    '			If DB_MEIMTA.DATKB = "9" Then
    '				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "�폜")

    '                   '20190218
    '                   'Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B

    '				'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				MEICDB_CheckC = 1
    '			Else
    '				'�X�V
    '				'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "�X�V")
    '			End If
    '			'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '			Call SCR_FromMfil(DE_INDEX)
    '		Else
    '			'�V�K
    '			'Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
    '			'MEICDB_CheckC = -1
    '		End If
    '	End If

    'End Function

    'Function MEICDB_DerivedC(ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object

    '	'    MEICDB_DerivedC = MEICDB
    '	'    Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
    '	'    If DBSTAT = 0 Then
    '	'       ' Call Scr_FromMEIMTA(De_Index)
    '	'    End If
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	If Trim(MEICDA) = "" Then
    '		DB_MEIMTA.MEICDB = ""
    '	End If
    'End Function

    'Function MEICDB_Slist(ByRef PP As clsPP, ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	'

    '	WLS_MEI1.Text = "���̃R�[�h2�ꗗ"
    '	CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
    '	Call DB_GetFirst(DBN_MEIMTA, 1, BtrNormal)
    '	'* �����Ƃ��� WLS_MEI1 �͍ŏ�����f�[�^��\������.
    '	'Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	Select Case Trim(MEICDA)
    '		Case ""
    '			Do While DBSTAT = 0
    '				'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = FRKEYCD Then CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
    '				Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '			Loop 
    '		Case Else

    '			Do While DBSTAT = 0
    '				'UPGRADE_WARNING: �I�u�W�F�N�g MEICDA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				'UPGRADE_WARNING: �I�u�W�F�N�g FRKEYCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '				If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = Trim(FRKEYCD) And Trim(DB_MEIMTA.MEICDA) = Trim(MEICDA) Then
    '					CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
    '				End If
    '				Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '			Loop 

    '	End Select
    '	'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDB)
    '	'    SSS_WLSLIST_KETA = 3
    '	WLS_MEI1.ShowDialog()
    '	WLS_MEI1.Close()
    '	'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	'UPGRADE_WARNING: �I�u�W�F�N�g MEICDB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '	MEICDB_Slist = PP.SlistCom

    'End Function
End Module