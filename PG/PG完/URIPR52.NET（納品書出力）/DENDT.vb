Option Strict Off
Option Explicit On
Module DENDT_F52
	'
	' スロット名        : 売上伝票日付・画面項目スロット
	' ユニット名        : DENDT.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/22
	' 使用プログラム名  : URIPR52
	'
	Dim NotFirst As Short
	
	Function DENDT_CheckC(ByVal DENDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_CheckC = 0
		'UPGRADE_WARNING: オブジェクト DENDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(DENDT) = "" Then
			'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DENDT_CheckC = -1
		Else
			If CHECK_DATE(DENDT) Then
				'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DENDT_CheckC = 0
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
				'UPGRADE_WARNING: オブジェクト DENDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DENDT_CheckC = -1
			End If
		End If
	End Function
	
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		If NotFirst = False Or Not IsDate(DENDT) Then
			NotFirst = True
			'DENDT_InitVal = Date
			'運用日付
			'UPGRADE_WARNING: オブジェクト DENDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DENDT_InitVal = DB_UNYMTA.UNYDT
		Else
			'UPGRADE_WARNING: オブジェクト DENDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト DENDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DENDT_InitVal = DENDT
		End If
	End Function
	
	Function DENDT_Skip(ByRef CT_DENDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: オブジェクト CT_DENDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019.04.08 CHG START
        'CT_DENDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
        DirectCast(CT_DENDT, TextBox).SelectionStart = 0
        '2019.04.08 CHG END
        'UPGRADE_WARNING: オブジェクト DENDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_Skip = False
	End Function
	
	Function DENDT_Slist(ByRef PP As clsPP, ByVal DENDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト DENDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = DENDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト DENDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_Slist = Set_date.Value
	End Function
End Module