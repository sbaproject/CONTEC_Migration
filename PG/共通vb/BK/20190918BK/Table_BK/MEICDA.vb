Option Strict Off
Option Explicit On
Module MEICDA_F52
    '
    'スロット名      :コード1ﾁｪｯｸ・画面項目スロット
    'ユニット名      :MEICDA.F51
    '記述者          :Standard Library
    '作成日付        :2006/07/13
    '使用プログラム  :MEIMT51
    '

    'Function MEICDA_CheckC(ByRef MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	Dim Rtn As Short
    '	Dim wkMEICDA As String
    '	Dim strSql As String
    '	Dim lngCount As Integer
    '	'
    '	'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	MEICDA_CheckC = 0
    '	' 未入力の場合には, エラーをかけずに名称等をクリアする
    '	'Call MEIMTA_RClear
    '	'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If Trim(MEICDA) = "" Then
    '		'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		MEICDA_CheckC = -1
    '	Else
    '		'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		wkMEICDA = MEICDA & Space(Len(DB_MEIMTA.MEICDA) - Len(Trim(MEICDA)))
    '		'コード１で件数ﾁｪｯｸ
    '		strSql = ""
    '		strSql = strSql & "Select Count(*) From MEIMTA"
    '		strSql = strSql & " Where DATKB = '1'"
    '		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		strSql = strSql & "   And KEYCD  = " & "'" & FRKEYCD & "'"
    '		strSql = strSql & "   And MEICDA = " & "'" & wkMEICDA & "'"
    '		Call DB_GetSQL2(DBN_MEIMTA, strSql)
    '		lngCount = DB_ExtNum.ExtNum(0)
    '		If lngCount >= 2 Then '件数が２件以上の時は何もしない
    '			Exit Function
    '		End If

    '		'件数が１件の時
    '		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & wkMEICDA & "     ", BtrNormal)
    '		If DBSTAT = 0 Then
    '			If DB_MEIMTA.DATKB = "9" Then
    '				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                   Call DP_SSSMAIN_UPDKB(DE_INDEX, "削除")

    '                   '20190218
    '                   'Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。

    '				'UPGRADE_WARNING: オブジェクト MEICDA_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				MEICDA_CheckC = 1
    '			Else
    '				'更新データ
    '				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "更新")
    '			End If
    '			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			Call SCR_FromMfil(DE_INDEX)
    '		Else
    '			''''''''''''Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 新規レコードです。
    '			''''''''''''MEICDA_CheckC = -1
    '			''''''''''''Call MEIMTA_RClear
    '			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			Call DP_SSSMAIN_UPDKB(DE_INDEX, "追加")
    '		End If
    '	End If


    'End Function

    'Function MEICDA_Slist(ByRef PP As clsPP, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	WLS_MEI1.Text = "名称ｺｰﾄﾞ一覧"
    '	CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
    '       SSS_MFILCNT = 0

    '       '20190226
    '       'Call DB_GetFirst(DBN_MEIMTA, 3, BtrNormal)
    '       ''* 原則として WLS_MEI1 は最初からデータを表示する.
    '       ''Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
    '       'Call DB_GetGrEq(DBN_MEIMTA, 3, FRKEYCD, BtrNormal)
    '       ''UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'Do While (DBSTAT = 0) And (DB_MEIMTA.KEYCD = FRKEYCD)
    '       '	If DB_MEIMTA.DATKB = "1" Then
    '       '		CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDA & " " & DB_MEIMTA.MEINMA)
    '       '		SSS_MFILCNT = SSS_MFILCNT + 1
    '       '	End If
    '       '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '       'Loop 

    '	'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '       'SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDA)

    '       PP.SlistCom = System.DBNull.Value
    '       'Call MEIMTA_GetFirst(FRKEYCD, "", "     ")
    '       Dim pWhere As String = ""
    '       pWhere = "WHERE KEYCD = '" & FRKEYCD & "'"
    '       Call GetRowsCommon("MEIMTA", pWhere)

    '       SSS_WLSLIST_KETA = DB_MEIMTA.MEICDA.Length

    '       WLS_MEI1.ShowDialog()
    '	WLS_MEI1.Close()
    '	'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト MEICDA_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	MEICDA_Slist = PP.SlistCom
    'End Function
End Module