Option Strict Off
Option Explicit On
Module SOUCD_F54
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :SOUCD.F54
	'記述者          :Standard Library
	'作成日付        :2006/07/16
	'使用プログラム  :SYKET51
	'
	
	Function SOUCD_Slist(ByRef PP As clsPP, ByVal SOUCD As Object) As Object
		'
		DB_PARA(DBN_SOUMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト SOUCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_SOUMTA).KeyBuf = SOUCD
		WLSSOU.ShowDialog()
		WLSSOU.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SOUCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUCD_Slist = PP.SlistCom
	End Function
End Module