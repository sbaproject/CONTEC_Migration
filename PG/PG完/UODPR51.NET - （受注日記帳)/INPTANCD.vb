Option Strict Off
Option Explicit On
Module INPTANCD_F61
	'
	'スロット名      :銀行コード・画面項目スロット
	'ユニット名      :INPTANCD.F61
	'記述者          :kobayashi
	'作成日付        :2006/08/01
	'使用プログラム  :BNKMT01
	'
	
	Function INPTANCD_Check(ByRef INPTANCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト INPTANCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		INPTANCD_Check = 0
		
		'UPGRADE_WARNING: オブジェクト INPTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(INPTANCD) = "" Then
			' INPTANCD_Check = -1
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_INPTANNM(De_Index, " ")
			
		Else
			Call DB_GetEq(DBN_TANMTA, 1, INPTANCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TANMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト INPTANCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					INPTANCD_Check = 1
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_INPTANCD(De_Index, DB_TANMTA.TANCD)
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_INPTANNM(De_Index, Trim(DB_TANMTA.TANNM))
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト INPTANCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				INPTANCD_Check = -1
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_INPTANNM(De_Index, " ")
			End If
		End If
		
	End Function
	
	Function INPTANCD_Slist(ByRef PP As clsPP, ByVal INPTANCD As Object) As Object
        '2019.03.26 CHG START
        'WLSTAN.Text = "入力担当者一覧"
        'CType(WLSTAN.Controls("LST"), Object).Items.Clear()
        WLSTAN2.Text = "入力担当者一覧"
        CType(WLSTAN2.Controls("LST"), Object).Items.Clear()
        '2019.03.26 CHG END
        'change start 20190807 kuwahara
        'Call DB_GetFirst(DBN_TANMTA, 1, BtrNormal)
        GetRowsCommon("TANMTA", "")
        'chane end 20190807 kuwahara
        Do While DBSTAT = 0
            '2019.03.26 CHG START
            'If DB_TANMTA.DATKB <> "9" Then CType(WLSTAN.Controls("LST"), Object).Items.Add(DB_TANMTA.TANCD & " " & DB_TANMTA.TANNM)
            If DB_TANMTA.DATKB <> "9" Then CType(WLSTAN2.Controls("LST"), Object).Items.Add(DB_TANMTA.TANCD & " " & DB_TANMTA.TANNM)
            '2019.03.26 CHG END
            Call DB_GetNext(DBN_TANMTA, BtrNormal)
        Loop
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSS_WLSLIST_KETA = LenWid(DB_TANMTA.TANCD)
        '2019.03.26 CHG START
        'WLSTAN.ShowDialog()
        'WLSTAN.Close()
        WLSTAN2.ShowDialog()
        WLSTAN2.Close()
        '2019.03.26 CHE END
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト INPTANCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		INPTANCD_Slist = PP.SlistCom
	End Function
End Module