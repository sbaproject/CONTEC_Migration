Option Strict Off
Option Explicit On
Module SBADENKN_F52
	'
	' スロット名        : 伝票合計金額(税込)項目・画面項目スロット
	' ユニット名        : SBADENKN.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/24
	' 使用プログラム名  : URIET53
	
	'仕入金額と消費税金額を合計計算して表示する。
	Function SBADENKN_Derived(ByVal URIKN As Object, ByVal UZEKN As Object, ByRef PP As clsPP) As Object
		Dim I As Short
		
		Do While I < PP.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SBADENKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBADENKN_Derived = SBADENKN_Derived + RD_SSSMAIN_URIKN(I) + RD_SSSMAIN_UZEKN(I)
			I = I + 1
		Loop 
		
	End Function
End Module