Option Strict Off
Option Explicit On
Module OPEID_F71
	'
	' スロット名        : 最終作業者コード・画面項目スロット
	' ユニット名        : OPEID.F71
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/23
	' 使用プログラム名  : NHSMR51
	'
	
	Function OPEID_InitVal(ByVal OPEID As Object, ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		'
		'UPGRADE_WARNING: オブジェクト OPEID_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		OPEID_InitVal = SSS_OPEID.Value
		If Trim(SSS_OPEID.Value) = "" Then
			Call TANMTA_RClear()
			Call OPEID_Move(-1)
		Else
			Call TANMTA_RClear()
			Call DB_GetEq(DBN_TANMTA, 1, SSS_OPEID.Value, BtrNormal)
			Call OPEID_Move(-1)
		End If
		
	End Function
	
	Sub OPEID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_OPENM(De, LeftWid(DB_TANMTA.TANNM, 20))
	End Sub
End Module