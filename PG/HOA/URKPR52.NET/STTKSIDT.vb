Option Strict Off
Option Explicit On
Module STTKSIDT_F51
	'
	' スロット名        : 開始伝票日付・画面項目スロット
	' ユニット名        : STTKSIDT.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URKPR52
	'
	
	Function STTKSIDT_CheckC(ByVal STTKSIDT As Object) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTKSIDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTKSIDT_CheckC = 0
		rtn = CHECK_DATE(STTKSIDT)
		If rtn Then
		Else
			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト STTKSIDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTKSIDT_CheckC = -1
		End If
	End Function
	
	
	Function STTKSIDT_InitVal(ByVal STTKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTKSIDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTKSIDT_InitVal = DB_UNYMTA.UNYDT
	End Function
	
	Function STTKSIDT_Skip(ByRef CT_STTKSIDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: オブジェクト CT_STTKSIDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CT_STTKSIDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
		'UPGRADE_WARNING: オブジェクト STTKSIDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTKSIDT_Skip = False
	End Function
	
	Function STTKSIDT_Slist(ByRef PP As clsPP, ByVal STTKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTKSIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = STTKSIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト STTKSIDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTKSIDT_Slist = Set_date.Value
	End Function
End Module