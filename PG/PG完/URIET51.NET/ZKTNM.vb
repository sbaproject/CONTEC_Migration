Option Strict Off
Option Explicit On
Module ZKTNM_F01
	'
	' スロット名        : 取引区分名称・画面項目スロット
	' ユニット名        : ZKTNM.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	'
	
	'商品ファイルより商品名１取得。
	Function ZKTNM_Derived(ByVal ZKTKB As Object) As Object
		Select Case ZKTKB
			Case "1"
				'UPGRADE_WARNING: オブジェクト ZKTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTNM_Derived = "通常"
			Case "2"
				'UPGRADE_WARNING: オブジェクト ZKTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTNM_Derived = "直送"
			Case "3"
				'UPGRADE_WARNING: オブジェクト ZKTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTNM_Derived = "預り"
			Case "4"
				'UPGRADE_WARNING: オブジェクト ZKTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTNM_Derived = "委託"
			Case Else
				'UPGRADE_WARNING: オブジェクト ZKTNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZKTNM_Derived = "通常"
		End Select
	End Function
End Module