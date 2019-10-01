Option Strict Off
Option Explicit On
Module LINNO_F51
	'
	' スロット名        : 行番号・画面項目スロット
	' ユニット名        : LINNO.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/21
	' 使用プログラム名  : SUODET52
	'
	
	Function LINNO_InitVal(ByVal De_index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト De_index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		LINNO_InitVal = VB6.Format(De_index + 1, "00")
	End Function
End Module