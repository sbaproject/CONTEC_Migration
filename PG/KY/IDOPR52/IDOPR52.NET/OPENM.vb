Option Strict Off
Option Explicit On
Module OPENM_F51
	'
	' スロット名        : 最終作業者名・画面項目スロット
	' ユニット名        : OPENM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/05
	' 使用プログラム名  : SODET51
	'
	
	Function OPENM_InitVal(ByVal OPENM As Object, ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		'
		If Trim(SSS_OPEID.Value) = "" Then
			Call TANMTA_RClear()
			Call OPENM_Move(-1)
		Else
			Call DB_GetEq(DBN_TANMTA, 1, SSS_OPEID.Value, BtrNormal)
			Call OPENM_Move(-1)
		End If
		'UPGRADE_WARNING: オブジェクト OPENM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		OPENM_InitVal = DB_TANMTA.TANNM
		
	End Function
	
	Sub OPENM_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_OPENM(De, DB_TANMTA.TANNM)
	End Sub
End Module