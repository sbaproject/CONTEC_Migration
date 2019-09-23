Option Strict Off
Option Explicit On
Module UDNDKBID_F52
	'
	' スロット名        : 取引区分・画面項目スロット
	' ユニット名        : UDNDKBID.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/11
	' 使用プログラム名  : URIET54/URIET55
	'
	
	Function UDNDKBID_Derived(ByRef PP As clsPP, ByVal UDNDKBID As Object, ByVal HINCD As Object, ByVal DE_INDEX As Object) As Object
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Derived = UDNDKBID
		'    If Trim$(UDNDKBID) <> "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then Exit Function
		
		''''UDNDKBID = "02"
		''''UDNDKBID_Derived = UDNDKBID
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_MEIKBA(-1) = "1" Then
			'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID = "02"
			'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Derived = UDNDKBID
		Else
			'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID = "06"
			'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Derived = UDNDKBID
		End If
		'
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetEq(DBN_SYSTBD, 1, WG_DKBSB & UDNDKBID, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call SCR_FromSYSTBD(DE_INDEX)
			'''''        Call DP_SSSMAIN_HINCD(DE_INDEX, HINCD)
			'''''        Call DB_GetEq(DBN_HINMTA, "1", HINCD, BtrNormal)
			'''''        Call SCR_FromHINMTA(DE_INDEX)
		Else
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Derived = System.DBNull.Value
		End If
	End Function
End Module