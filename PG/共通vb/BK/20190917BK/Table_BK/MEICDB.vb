Option Strict Off
Option Explicit On
Module MEICDB_F52
    '
    'スロット名      :コード2・画面項目スロット
    'ユニット名      :MEICDB.F52
    '記述者          :Standard Library
    '作成日付        :2006/07/12
    '使用プログラム  :MEIMT51
    '

    'Function MEICDB_CheckC(ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	''''2006.07.24不要
    '	Dim Rtn As Short
    '	'
    '	'UPGRADE_WARNING: オブジェクト MEICDB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	MEICDB_CheckC = 0

    '	'UPGRADE_WARNING: オブジェクト MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If Trim(MEICDB) = "" Then
    '		'        MEICDB_CheckC = -1
    '	Else
    '		'UPGRADE_WARNING: オブジェクト MEICDB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		Call DB_GetEq(DBN_MEIMTA, 1, FRKEYCD & MEICDA & MEICDB, BtrNormal)
    '		If DBSTAT = 0 Then
    '			If DB_MEIMTA.DATKB = "9" Then
    '				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "削除")

    '                   '20190218
    '                   'Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。

    '				'UPGRADE_WARNING: オブジェクト MEICDB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				MEICDB_CheckC = 1
    '			Else
    '				'更新
    '				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				Call DP_SSSMAIN_UPDKB(DE_INDEX, "更新")
    '			End If
    '			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			Call SCR_FromMfil(DE_INDEX)
    '		Else
    '			'新規
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
    '	'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If Trim(MEICDA) = "" Then
    '		DB_MEIMTA.MEICDB = ""
    '	End If
    'End Function

    'Function MEICDB_Slist(ByRef PP As clsPP, ByVal MEICDB As Object, ByVal MEICDA As Object, ByVal FRKEYCD As Object, ByVal DE_INDEX As Object) As Object
    '	'

    '	WLS_MEI1.Text = "名称コード2一覧"
    '	CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
    '	Call DB_GetFirst(DBN_MEIMTA, 1, BtrNormal)
    '	'* 原則として WLS_MEI1 は最初からデータを表示する.
    '	'Call DB_GetGrEq(DBN_MEIMTA, 1, MEICDA, BtrNormal)
    '	'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	Select Case Trim(MEICDA)
    '		Case ""
    '			Do While DBSTAT = 0
    '				'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = FRKEYCD Then CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
    '				Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '			Loop 
    '		Case Else

    '			Do While DBSTAT = 0
    '				'UPGRADE_WARNING: オブジェクト MEICDA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				If DB_MEIMTA.DATKB <> "9" And DB_MEIMTA.KEYCD = Trim(FRKEYCD) And Trim(DB_MEIMTA.MEICDA) = Trim(MEICDA) Then
    '					CType(WLS_MEI1.Controls("LST"), Object).Items.Add(DB_MEIMTA.MEICDB & " " & DB_MEIMTA.MEINMB)
    '				End If
    '				Call DB_GetNext(DBN_MEIMTA, BtrNormal)
    '			Loop 

    '	End Select
    '	'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	SSS_WLSLIST_KETA = LenWid(DB_MEIMTA.MEICDB)
    '	'    SSS_WLSLIST_KETA = 3
    '	WLS_MEI1.ShowDialog()
    '	WLS_MEI1.Close()
    '	'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト MEICDB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	MEICDB_Slist = PP.SlistCom

    'End Function
End Module