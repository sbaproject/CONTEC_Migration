Option Strict Off
Option Explicit On
Module LINNO_F01
	'
	' スロット名        : 行番号・画面項目スロット
	' ユニット名        : LINNO.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : UODET01 / URIET01 / TNAET01
	'
	
	Function LINNO_InitVal(ByVal De_index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト De_index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		LINNO_InitVal = VB6.Format(De_index + 1, "000")
	End Function
End Module