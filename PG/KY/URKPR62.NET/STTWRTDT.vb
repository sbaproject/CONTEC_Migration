Option Strict Off
Option Explicit On
Module STTWRTDT_F61
	'
	' スロット名        : 開始・入力日付・画面項目スロット
	' ユニット名        : STTWRTDT.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : UODPR51
	'                     URKPR01 / URKPR02 / URKPR08 / URKPR10
	'                     UODPR05 / UODPR06 /UODPR07
	'                     NYKPR01 / NYKPR03 / SYKPR01 / SYKPR03 / SYKPR11 / SYKPR13
	'                     SYKPR31 / SYKPR33
	'                     IDOPR01 / IDOPR03
	'                     FRKPR01 / FRKPR03
	'                     KAKPR01 / KAKPR02 / KAKPR10 / KAKPR08 / SODPR03 / SODPR04 / SODPR05 / SODPR06 / SODPR07
	'                     SREPR01 / SREPR02 / SREPR04
	'                     NYKPR11 / NYKPR13 / NYKPR31 / NYKPR33
	'                     CSVPR01 / CSVPR02
	'
	
	Function STTWRTDT_CheckC(ByVal STTWRTDT As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト STTWRTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTWRTDT_CheckC = 0
		Rtn = CHECK_DATE(STTWRTDT)
		If Rtn Then
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト STTWRTDT_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTWRTDT_CheckC = -1
		End If
	End Function
	
	Function STTWRTDT_InitVal(ByVal STTWRTDT As Object) As Object
		
		'2008/09/29 CHG START FKS)NAKATA
		''運用日付からシステム日付に変更
		'
		'STTWRTDT_InitVal = DB_UNYMTA.UNYDT
		STTWRTDT_InitVal = VB6.Format(Today, "YYYYMMDD")
		
		'2008/09/29 CHG E.N.D FKS)NAKATA
		
	End Function
	
	Function STTWRTDT_Skip(ByRef CT_STTWRTDT As System.Windows.Forms.Control) As Object
        '
        'UPGRADE_WARNING: オブジェクト CT_STTWRTDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/29 CHG START
        'CT_STTWRTDT.SelStart = 8 'yyyy-mm-dd の dd のところ。
        DirectCast(CT_STTWRTDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd の場所へスキップ。
        '2019/10/29 CHG E N D
        'UPGRADE_WARNING: オブジェクト STTWRTDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTWRTDT_Skip = False
	End Function
	
	Function STTWRTDT_Slist(ByRef PP As clsPP, ByVal STTWRTDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト STTWRTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Set_date.Value = STTWRTDT
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		'UPGRADE_WARNING: オブジェクト STTWRTDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTWRTDT_Slist = Set_date.Value
	End Function
End Module