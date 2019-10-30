Option Strict Off
Option Explicit On
Module TOKCD_F52
	'
	'スロット名      :得意先コード(販売単価マスタ登録）・画面項目スロット
	'ユニット名      :TOKCD.FM4
	'記述者          :Standard Library
	'作成日付        :1997/07/03
	'使用プログラム  :SIRMT03
	'
	
	Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
		WLSTOK.ShowDialog()
		WLSTOK.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TOKCD_Slist = PP.SlistCom
	End Function
End Module