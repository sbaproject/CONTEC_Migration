Option Strict Off
Option Explicit On
Module ENDOUTDT_F51
	'
	' スロット名        : 終了・入力日付・画面項目スロット
	' ユニット名        : ENDWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : IDOPR53
	'
	'
	
	Function ENDOUTDT_Check(ByVal ENDOUTDT As Object, ByVal STTOUTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDOUTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDOUTDT_Check = 0
		'UPGRADE_WARNING: オブジェクト ENDOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDOUTDT) = "" Then
			Exit Function
		End If
		Rtn = CHECK_DATE(ENDOUTDT)
		If Rtn Then
			'UPGRADE_WARNING: オブジェクト STTOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ENDOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDOUTDT < STTOUTDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: オブジェクト ENDOUTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDOUTDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ENDOUTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDOUTDT_Check = -1
		End If
	End Function
	
	Function ENDOUTDT_InitVal(ByVal ENDOUTDT As Object) As Object
		'
		''''ENDOUTDT_InitVal = Date
		''''ENDOUTDT_InitVal = DB_UNYMTA.UNYDT              '2006.12.06
		'UPGRADE_WARNING: オブジェクト ENDOUTDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDOUTDT_InitVal = ""
	End Function
	
	Function ENDOUTDT_Skip(ByRef CT_ENDOUTDT As System.Windows.Forms.Control, ByVal ENDOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(ENDOUTDT) <> "" Then
            'UPGRADE_WARNING: オブジェクト CT_ENDOUTDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/09 CHG START
            'CT_ENDOUTDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
            DirectCast(CT_ENDOUTDT, TextBox).SelectionStart = 8
            '2019/10/09 CHG E N D
            'UPGRADE_WARNING: オブジェクト ENDOUTDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ENDOUTDT_Skip = False
		End If
	End Function
	
	Function ENDOUTDT_Slist(ByRef PP As clsPP, ByVal ENDOUTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDOUTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = ENDOUTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト ENDOUTDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDOUTDT_Slist = Set_date.Value
	End Function
End Module