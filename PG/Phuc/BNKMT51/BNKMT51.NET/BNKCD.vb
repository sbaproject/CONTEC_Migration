Option Strict Off
Option Explicit On
Module BNKCD_F51
	'
	'スロット名      :銀行コード・画面項目スロット
	'ユニット名      :BNKCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/09/14
	'使用プログラム  :BNKMT51
	'
	
	Function BNKCD_CheckC(ByRef BNKCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト BNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BNKCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト BNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(BNKCD) = "" Then
			'UPGRADE_WARNING: オブジェクト BNKCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			BNKCD_CheckC = -1
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, BNKCD, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call Scr_FromMfil(De_Index)
				If DB_BNKMTA.DATKB = "9" Then
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "削除")
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "更新")
				End If
			Else
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_UPDKB(De_Index, "追加")
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
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト BNKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		BNKCD_Slist = PP.SlistCom
	End Function
End Module