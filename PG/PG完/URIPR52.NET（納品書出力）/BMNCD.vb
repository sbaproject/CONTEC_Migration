Option Strict Off
Option Explicit On
Module BMNCD_F52
    '
    '�X���b�g��      :����R�[�h�E��ʍ��ڃX���b�g
    '���j�b�g��      :BMNCD.F52
    '�L�q��          :Standard Library
    '�쐬���t        :2006/08/22
    '�g�p�v���O����  :URIPR52
    '

    Function BMNCD_CheckC(ByRef BMNCD As Object, ByVal DE_INDEX As Object) As Object
        Dim Rtn As Short
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        BMNCD_CheckC = 0
        'delete start 20190808 kuwahara
        'Call BMNMTA_RClear()
        'delete end 20190808 kuwahara
        'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(Trim$(BMNCD)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If LenWid(Trim(BMNCD)) = 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            BMNCD_CheckC = 0
        Else
            'change start 20190809 kuwahara
            'Call DB_GetEq(DBN_BMNMTA, 4, BMNCD, BtrNormal)
            GetRowsCommon("BMNMTA", "where BMNCD = '" & BMNCD & "'")
            'change end 20190809 kuwahara

            If DBSTAT = 0 Then
                If DB_BMNMTA.DATKB = "9" Then
                    Call Dsp_Prompt("RNOTFOUND", 1)         ' �폜�σ��R�[�h�ł��B
                    BMNCD_CheckC = 1
                End If
            Else
                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
                'UPGRADE_WARNING: �I�u�W�F�N�g BMNCD_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                BMNCD_CheckC = -1
            End If
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g DE_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Call SCR_FromBMNMTA(DE_INDEX)
    End Function

    Function BMNCD_Slist(ByRef PP As clsPP, ByVal BMNCD As Object) As Object
		'''    DB_PARA(DBN_BMNMTA).KeyNo = 1
		'''    DB_PARA(DBN_BMNMTA).KeyBuf = BMNCD
		'''    WLSBMN.Show 1
		'''    Unload WLSBMN
		'''    BMNCD_Slist = PP.SlistCom
		WLS_BMN1.Text = "�c�ƕ���ꗗ"
        CType(WLS_BMN1.Controls("LST"), Object).Items.Clear()
        'change start 20190816 kuwahara
        'Call DB_GetFirst(DBN_BMNMTA, 1, BtrNormal)
        GetRowsCommon("BMNMTA", "")
        'change end 20190816 kuwahara

        ''not add start 20190819 kuwahara
        'Dim strSQL As String = "select BMNCD from BMNMTA ;"
        'Dim dt As DataTable = DB_GetTable(strSQL)
        ''not add end 20190819 kuwahara

        'not change start 20190819 kuwahara '�������x�����߁Afor���ɏ��������悤�Ƃ������f�O
        Do While (DBSTAT = 0)
            If (DB_BMNMTA.DATKB = "1") And (DB_BMNMTA.STTTKDT <= DB_UNYMTA.UNYDT) And (DB_BMNMTA.ENDTKDT >= DB_UNYMTA.UNYDT) Then
                CType(WLS_BMN1.Controls("LST"), Object).Items.Add(DB_BMNMTA.BMNCD & "   " & LeftWid(DB_BMNMTA.BMNNM, 40) & " " & CNV_DATE(DB_BMNMTA.STTTKDT) & " " & CNV_DATE(DB_BMNMTA.ENDTKDT))
            End If
            'change start 20190816 kuwahara
            'Call DB_GetNext(DBN_BMNMTA, BtrNormal)
            Call DB_GetNext("BMNMTA", BtrNormal)
            'change end 20190819 kuwahara
        Loop

        ''For i As Integer = 0 To dt.Rows.Count - 1
        ''    'If (DB_BMNMTA.DATKB = "1") And (DB_BMNMTA.STTTKDT <= DB_UNYMTA.UNYDT) And (DB_BMNMTA.ENDTKDT >= DB_UNYMTA.UNYDT) Then
        ''    If dt.Rows(i)("DATKB") = 1 And dt.Rows(i)("STTTKDT") <= DB_UNYMTA.UNYDT And (dt.Rows(i)("ENDTKDT") >= DB_UNYMTA.UNYDT) Then
        ''        CType(WLS_BMN1.Controls("LST"), Object).Items.Add(dt.Rows(i)("BMNCD") & "   " & LeftWid(dt.Rows(i)("BMNNM"), 40) & " " & CNV_DATE(dt.Rows(i)("STTTKDT")) & " " & CNV_DATE(dt.Rows(i)("ENDTKDT")))
        ''        Exit For
        ''    End If
        ''    'End If
        ''    'Call DB_GetNext("BMNMTA", BtrNormal)
        ''    DB_BMNMTA = GetNextRowsCommon("BMNMTA", i)
        ''Next
        'not change end 20190819 kuwahara

        'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        SSS_WLSLIST_KETA = LenWid(DB_BMNMTA.BMNCD)
		WLS_BMN1.ShowDialog()
        WLS_BMN1.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        BMNCD_Slist = Left(PP.SlistCom, 6)
	End Function
End Module