Option Strict Off
Option Explicit On
Module UNTCD_FM1
	'
	'スロット名      :単位コード・画面項目スロット
	'ユニット名      :UNTCD.FM1   
	'記述者          :Standard Library
	'作成日付        :1997/05/28
	'使用プログラム  :UNTMT01
	'
	
	Function UNTCD_CheckC(ByVal UNTCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト UNTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UNTCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト UNTCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(UNTCD) = "" Then
			'UPGRADE_WARNING: オブジェクト UNTCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UNTCD_CheckC = -1
		Else

            '2019/10/11 CHG START
            'Call DB_GetEq(DBN_UNTMTA, 1, UNTCD, BtrNormal)
            GetRowsCommon(DBN_UNTMTA, "where UNTCD = '" & UNTCD & "'")
            '2019/10/11 CHG END

            If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call Scr_FromMfil(De_Index)
				If DB_UNTMTA.DATKB = "9" Then
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
	
	Function UNTCD_Slist(ByRef PP As clsPP, ByVal UNTCD As Object) As Object
		'
		WLS_LIST.Text = "単位一覧"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetFirst(DBN_UNTMTA, 1, BtrNormal)
		Do While DBSTAT = 0
			If DB_UNTMTA.DATKB <> "9" Then CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_UNTMTA.UNTCD & " " & DB_UNTMTA.UNTNM)
			Call DB_GetNext(DBN_UNTMTA, BtrNormal)
		Loop
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

        SSS_WLSLIST_KETA = LenWid(DB_UNTMTA.UNTCD)
        '2019/10/11 ADD START
        If SSS_WLSLIST_KETA = 0 Then
            SSS_WLSLIST_KETA = 2
        End If
        '2019/10/11 ADD END
        WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UNTCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UNTCD_Slist = PP.SlistCom
	End Function
End Module