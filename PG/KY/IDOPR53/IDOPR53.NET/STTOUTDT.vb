Option Strict Off
Option Explicit On
Module STTOUTDT_F51
	'
	' スロット名        : 開始・入力日付・画面項目スロット
	' ユニット名        : STTWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : IDOPR53
	'
	
	Function STTOUTDT_CheckC(ByVal STTOUTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTOUTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTOUTDT_CheckC = 0
		'UPGRADE_WARNING: オブジェクト STTOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTOUTDT) = "" Then
			Exit Function
		End If
		Rtn = CHECK_DATE(STTOUTDT)
		If Rtn Then
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト STTOUTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTOUTDT_CheckC = -1
		End If
	End Function
	
	Function STTOUTDT_InitVal(ByVal STTOUTDT As Object) As Object
		'
		''''STTOUTDT_InitVal = Date
		''''STTOUTDT_InitVal = DB_UNYMTA.UNYDT          '2006.12.06
		'UPGRADE_WARNING: オブジェクト STTOUTDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTOUTDT_InitVal = ""
	End Function
	
	Function STTOUTDT_Skip(ByRef CT_STTOUTDT As System.Windows.Forms.Control, ByVal STTOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTOUTDT) <> "" Then
			'UPGRADE_WARNING: オブジェクト CT_STTOUTDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CT_STTOUTDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
			'UPGRADE_WARNING: オブジェクト STTOUTDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTOUTDT_Skip = False
		End If
	End Function
	
	Function STTOUTDT_Slist(ByRef PP As clsPP, ByVal STTOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = STTOUTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト STTOUTDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTOUTDT_Slist = Set_date.Value
	End Function
End Module