Option Strict Off
Option Explicit On
Module JDNTRKB_F52
	'
	'スロット名      :受注取引区分・画面項目スロット
	'ユニット名      :JDNTRKB.F52
	'記述者          :Standard Library
	'作成日付        :2006/08/25
	'使用プログラム  :URIPR52
	'
	
	Function JDNTRKB_CHeck(ByVal JDNTRKB As Object) As Object
		Dim Rtn As Short
		Dim wkJDNTRKB As String
		'
		DB_MEIMTA.MEINMA = ""
        'UPGRADE_WARNING: オブジェクト JDNTRKB_CHeck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        JDNTRKB_CHeck = 0
        'delete start 20190808 kuwahara
        'Call MEIMTA_RClear()
        'delete end 20190808 kuwahara
        'UPGRADE_WARNING: オブジェクト JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト LenWid(Trim$(JDNTRKB)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(Trim(JDNTRKB)) = 0 Then
			Call DP_SSSMAIN_JDNTRNM(0, " ")
		Else
            'UPGRADE_WARNING: オブジェクト JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190809 kuwahara
            'wkJDNTRKB = JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(JDNTRKB))
            wkJDNTRKB = JDNTRKB & Space(Len(20) - Len(JDNTRKB)) 'なぜ20なのかは不明。（サンプルを参照した結果：DB_MEIMTA.MEICDA = 20)
            'change end 20190809 kuwahara
            'UPGRADE_WARNING: オブジェクト JDNTRKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190809 kuwahara
            'Call DB_GetEq(DBN_MEIMTA, 2, "006" & JDNTRKB, BtrNormal)
            GetRowsCommon("MEIMTA", "where KeyCD = '006' and MEICDA = '" & wkJDNTRKB & "'")
            If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除レコードです。
					'UPGRADE_WARNING: オブジェクト JDNTRKB_CHeck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					JDNTRKB_CHeck = -1
				Else
					'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
					Call DP_SSSMAIN_JDNTRNM(0, LeftB(DB_MEIMTA.MEINMA, 10))
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
				'UPGRADE_WARNING: オブジェクト JDNTRKB_CHeck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				JDNTRKB_CHeck = -1
			End If
		End If
	End Function
	Function JDNTRKB_InitVal(ByVal JDNTRKB As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト JDNTRKB_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNTRKB_InitVal = " "
		
	End Function
	
	Function JDNTRKB_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "受注取引区分一覧"
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
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト JDNTRKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNTRKB_Slist = PP.SlistCom
		
	End Function
End Module