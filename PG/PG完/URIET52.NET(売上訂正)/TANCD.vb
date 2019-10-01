Option Strict Off
Option Explicit On
Module TANCD_F54
    '
    'スロット名      :担当者コード・画面項目スロット
    'ユニット名      :TANCD.F54

    '記述者          :Standard Library
    '作成日付        :2006/08/24
    '使用プログラム  :URIET53/SEIPR54
    '

    Function TANCD_Slist(ByRef PP As clsPP, ByVal TANCD As Object) As Object
		'
		DB_PARA(DBN_TANMTA).KeyNo = 1
		'UPGRADE_WARNING: オブジェクト TANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TANMTA).KeyBuf = TANCD
        '2019/06/04 CHG START
        'WLSTAN.ShowDialog()
        'WLSTAN.Close()
        WLSTAN2.ShowDialog()
        WLSTAN2.Close()
        '2019/06/04 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SLISTCOM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TANCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        TANCD_Slist = PP.SLISTCOM
	End Function
End Module