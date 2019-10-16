Option Strict Off
Option Explicit On
Module ENDKSIDT_F51
	'
	' スロット名        : 終了伝票日付・画面項目スロット
	' ユニット名        : ENDKSIDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URKPR52
	
	Function ENDKSIDT_Check(ByVal ENDKSIDT As Object, ByVal STTKSIDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDKSIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDKSIDT_Check = 0
		Rtn = CHECK_DATE(ENDKSIDT)
		If Rtn Then
			'UPGRADE_WARNING: オブジェクト STTKSIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ENDKSIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDKSIDT < STTKSIDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: オブジェクト ENDKSIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDKSIDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ENDKSIDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDKSIDT_Check = -1
		End If
		
	End Function
	
	Function ENDKSIDT_InitVal(ByVal ENDKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDKSIDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDKSIDT_InitVal = DB_UNYMTA.UNYDT
	End Function
	
	Function ENDKSIDT_Skip(ByRef CT_ENDKSIDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: オブジェクト CT_ENDKSIDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CT_ENDKSIDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
		'UPGRADE_WARNING: オブジェクト ENDKSIDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDKSIDT_Skip = False
	End Function
	
	Function ENDKSIDT_Slist(ByRef PP As clsPP, ByVal ENDKSIDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDKSIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = ENDKSIDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト ENDKSIDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDKSIDT_Slist = Set_date.Value
	End Function
End Module