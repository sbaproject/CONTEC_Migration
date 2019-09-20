Option Strict Off
Option Explicit On
Module ENDBNKNM_F51
	'
	' スロット名        : 倉庫名称・画面項目スロット
	' ユニット名        : SOUNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function ENDBNKNM_Derived(ByVal ENDBNKNM As Object, ByVal ENDBNKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト ENDBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDBNKCD) = "" Then
			DB_BNKMTA.BNKNM = " "
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, ENDBNKCD, BtrNormal)
		End If
		'UPGRADE_WARNING: オブジェクト ENDBNKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDBNKNM_Derived = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		
	End Function
	Function ENDBNKNM_InitVal(ByVal ENDBNKNM As Object, ByVal ENDBNKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_BNKMTA.BNKCD) = "" Then
		'UPGRADE_WARNING: オブジェクト ENDBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDBNKCD) = "" Then
			''''''''ENDBNKNM_InitVal = FillVal(" ", LenWid(DB_BNKMTA.BNKNM))
			ENDBNKNM_InitVal = Space(50)
		Else
			'UPGRADE_WARNING: オブジェクト ENDBNKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDBNKNM_InitVal = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		End If
	End Function
End Module