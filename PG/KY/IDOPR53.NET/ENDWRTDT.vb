Option Strict Off
Option Explicit On
Module ENDWRTDT_F57
	'
	' スロット名        : 終了・入力日付・画面項目スロット
	' ユニット名        : ENDWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  :
	'
	'
	
	Function ENDWRTDT_Check(ByVal ENDWRTDT As Object, ByVal STTWRTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト ENDWRTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDWRTDT_Check = 0
		Rtn = CHECK_DATE(ENDWRTDT)
		If Rtn Then
			'UPGRADE_WARNING: オブジェクト STTWRTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ENDWRTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ENDWRTDT < STTWRTDT Then
				Rtn = DSP_MsgBox(SSS_ERROR, "ENDCHECK", 0)
				'UPGRADE_WARNING: オブジェクト ENDWRTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ENDWRTDT_Check = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト ENDWRTDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ENDWRTDT_Check = -1
		End If
	End Function
	
	Function ENDWRTDT_InitVal(ByVal ENDWRTDT As Object) As Object
		'
		''''ENDWRTDT_InitVal = Date
		
		'2008/0929 CHG START FKS)NAKATA
		'運用日付からシステム日付に変更
		'    ENDWRTDT_InitVal = DB_UNYMTA.UNYDT
		ENDWRTDT_InitVal = VB6.Format(Today, "YYYYMMDD")
		'2008/09/29 CHG E.N.D FKS)NAKATA
		
	End Function
	
	Function ENDWRTDT_Skip(ByRef CT_ENDWRTDT As System.Windows.Forms.Control) As Object
		'
		'UPGRADE_WARNING: オブジェクト CT_ENDWRTDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CT_ENDWRTDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
		'UPGRADE_WARNING: オブジェクト ENDWRTDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDWRTDT_Skip = False
	End Function
	
	Function ENDWRTDT_Slist(ByRef PP As clsPP, ByVal ENDWRTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト ENDWRTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = ENDWRTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト ENDWRTDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ENDWRTDT_Slist = Set_date.Value
	End Function
End Module