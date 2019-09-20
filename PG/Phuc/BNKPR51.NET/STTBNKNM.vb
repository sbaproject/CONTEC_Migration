Option Strict Off
Option Explicit On
Module STTBNKNM_F51
	'
	' スロット名        : 倉庫名称・画面項目スロット
	' ユニット名        : SOUNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function STTBNKNM_Derived(ByVal STTBNKNM As Object, ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト STTBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTBNKCD) = "" Then
			DB_BNKMTA.BNKNM = " "
		Else
			Call DB_GetEq(DBN_BNKMTA, 1, STTBNKCD, BtrNormal)
		End If
		'UPGRADE_WARNING: オブジェクト STTBNKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTBNKNM_Derived = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		
	End Function
	Function STTBNKNM_InitVal(ByVal STTBNKNM As Object, ByVal STTBNKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_SOUMTA.BNKCD) = "" Then
		'UPGRADE_WARNING: オブジェクト STTBNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTBNKCD) = "" Then
			''''''''STTBNKNM_InitVal = FillVal(" ", LenWid(DB_BNKMTA.BNKNM))
			STTBNKNM_InitVal = Space(50)
		Else
			'UPGRADE_WARNING: オブジェクト STTBNKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTBNKNM_InitVal = Trim(AnsiTrimStringByByteCount(DB_BNKMTA.BNKNM, 30)) & " " & Trim(AnsiTrimStringByByteCount(DB_BNKMTA.STNNM, 20))
		End If
	End Function
End Module