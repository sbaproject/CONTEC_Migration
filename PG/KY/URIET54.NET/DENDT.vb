Option Strict Off
Option Explicit On
Module DENDT_F51
	'
	' スロット名        : 入力日・画面項目スロット
	' ユニット名        : DENDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/24
	' 使用プログラム名  : SODET53
	'
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト DENDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DENDT_InitVal = DB_UNYMTA.UNYDT '本日の日付。
	End Function
End Module