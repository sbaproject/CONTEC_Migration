Option Strict Off
Option Explicit On
Module HINCD_F54
	'
	'スロット名      :商品コード・画面項目スロット
	'ユニット名      :HINCD.F54
	'記述者          :Standard Library
	'作成日付        :2006/07/16
	'使用プログラム  :SYKET51
	'
	
	Function HINCD_Slist(ByRef PP As clsPP, ByVal HINCD As Object) As Object
		'
		DB_PARA(DBN_HINMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_HINMTA).KeyBuf = HINCD
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト HINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        HINCD_Slist = PP.SlistCom
	End Function
End Module