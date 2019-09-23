Option Strict Off
Option Explicit On
Module SBAURIKN_F01
	'
	' スロット名        : 伝票合計売上金額項目・画面項目スロット
	' ユニット名        : SBAURIKN.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	
	'売上合計金額を計算して表示する。
	Function SBAURIKN_Derived(ByVal URIKN As Object, ByRef PP As clsPP, ByRef CP_SBAURIKN As clsCP) As Object
		Dim NullSw, I As Short
		Dim Sum As Decimal
		Dim VALU As Decimal
		'
		On Error GoTo OverFlow
		NullSw = True
		Sum = 0
		I = 0
		Do While I < PP.LastDe
			VALU = 0
			If IsNumeric(RD_SSSMAIN_URIKN(I)) Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				VALU = RD_SSSMAIN_URIKN(I)
				Sum = Sum + VALU
				NullSw = False
			End If
			I = I + 1
		Loop 
		If NullSw = False Then 'Null以外の受注金額がある場合。
			'UPGRADE_WARNING: オブジェクト SBAURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAURIKN_Derived = Sum
		Else '受注金額は全てNullの場合。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SBAURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAURIKN_Derived = System.DBNull.Value
		End If
		Exit Function
OverFlow: 
		CP_SBAURIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト SBAURIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SBAURIKN_Derived = "??????????????????"
	End Function
End Module