Option Strict Off
Option Explicit On
Module TOKCD_F53
	'
	'スロット名      :得意先コード・画面項目スロット
	'ユニット名      :TOKCD.F53
	'記述者          :Standard Library
	'作成日付        :2006/07/22
	'使用プログラム  :SODET53
	'
	
	Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
        '2019/06/04 CHG START
        'WLSTOK.ShowDialog()
        'WLSTOK.Close()
        WLSTOK3.ShowDialog()
        WLSTOK3.Close()
        '2019/06/04 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        TOKCD_Slist = PP.SlistCom
	End Function
End Module