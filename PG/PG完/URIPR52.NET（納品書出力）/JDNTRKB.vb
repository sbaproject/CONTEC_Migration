Option Strict Off
Option Explicit On
Module JDNTRKB_F52
	'
	'�X���b�g��      :�󒍎���敪�E��ʍ��ڃX���b�g
	'���j�b�g��      :JDNTRKB.F52
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/25
	'�g�p�v���O����  :URIPR52
	'
	
	Function JDNTRKB_CHeck(ByVal JDNTRKB As Object) As Object
		Dim Rtn As Short
		Dim wkJDNTRKB As String
		'
		DB_MEIMTA.MEINMA = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_CHeck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        JDNTRKB_CHeck = 0
        'delete start 20190808 kuwahara
        'Call MEIMTA_RClear()
        'delete end 20190808 kuwahara
        'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(JDNTRKB)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(Trim(JDNTRKB)) = 0 Then
			Call DP_SSSMAIN_JDNTRNM(0, " ")
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190809 kuwahara
            'wkJDNTRKB = JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(JDNTRKB))
            wkJDNTRKB = JDNTRKB & Space(Len(20) - Len(JDNTRKB)) '�Ȃ�20�Ȃ̂��͕s���B�i�T���v�����Q�Ƃ������ʁFDB_MEIMTA.MEICDA = 20)
            'change end 20190809 kuwahara
            'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'change start 20190809 kuwahara
            'Call DB_GetEq(DBN_MEIMTA, 2, "006" & JDNTRKB, BtrNormal)
            GetRowsCommon("MEIMTA", "where KeyCD = '006' and MEICDA = '" & wkJDNTRKB & "'")
            If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' �폜���R�[�h�ł��B
					'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_CHeck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					JDNTRKB_CHeck = -1
				Else
					'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
					Call DP_SSSMAIN_JDNTRNM(0, LeftB(DB_MEIMTA.MEINMA, 10))
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' �Y�����R�[�h�͂���܂���B
				'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_CHeck �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				JDNTRKB_CHeck = -1
			End If
		End If
	End Function
	Function JDNTRKB_InitVal(ByVal JDNTRKB As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNTRKB_InitVal = " "
		
	End Function
	
	Function JDNTRKB_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "�󒍎���敪�ꗗ"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        'change start 20190816 kuwahara
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
        '      Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
        '	CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '006' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
            CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & LeftWid(DB_MEIMTA.MEINMA, 40))
        Next
        'change end 20190816 kuwahara

        SSS_WLSLIST_KETA = 2
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNTRKB_Slist = PP.SlistCom
		
	End Function
End Module