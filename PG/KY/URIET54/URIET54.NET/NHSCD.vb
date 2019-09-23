Option Strict Off
Option Explicit On
Module NHSCD_F51
	'
	'スロット名      :納入先コード・画面項目スロット
	'ユニット名      :NHSCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/07/26
	'使用プログラム  :SODET51
	'
	
	Function NHSCD_Slist(ByRef PP As clsPP, ByVal NHSCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト NHSCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_NHSMTA).KeyBuf = NHSCD
		WLSNHS.ShowDialog()
		WLSNHS.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NHSCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCD_Slist = PP.SlistCom
	End Function
End Module