Option Strict Off
Option Explicit On
Module WRTFSTTM_F51
	'
	' スロット名        : 最終作業者コード・画面項目スロット
	' ユニット名        : WRTFSTTM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/05
	' 使用プログラム名  : SODET51
	'
	
	Function WRTFSTTM_InitVal(ByVal WRTFSTTM As Object, ByRef PP As clsPP, ByRef CP_WRTFSTTM As clsCP) As Object
		'
		WRTFSTTM_InitVal = VB6.Format(WG_WRTFSTTM, "00:00:00")
		
	End Function
End Module