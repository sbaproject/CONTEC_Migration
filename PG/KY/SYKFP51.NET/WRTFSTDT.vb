Option Strict Off
Option Explicit On
Module WRTFSTDT_F51
	'
	' スロット名        : 最終作業者コード・画面項目スロット
	' ユニット名        : WRTFSTDT.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/05
	' 使用プログラム名  : SODET51
	'
	
	Function WRTFSTDT_InitVal(ByVal WRTFSTDT As Object, ByRef PP As clsPP, ByRef CP_WRTFSTDT As clsCP) As Object
		'
		'UPGRADE_WARNING: オブジェクト WRTFSTDT_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WRTFSTDT_InitVal = WG_WRTFSTDT
		
	End Function
End Module