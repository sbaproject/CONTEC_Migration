Option Strict Off
Option Explicit On
Module STTJDNNO_F61
	'
	' スロット名        : 開始受注伝票番号・画面項目スロット
	' ユニット名        : STTJDNNO.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : UODPR51
	'
	
	Function STTJDNNO_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTJDNNO_InitVal = FillVal("", LenWid(DB_JDNTRA.JDNNO))
	End Function
	
	Function STTJDNNO_Slist(ByRef PP As clsPP, ByVal STTJDNNO As Object) As Object
        'delete start 20190808 kuwahara
        'DB_PARA(DBN_JDNTHA).KeyNo = 2
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "1"
        'delete end 20190808 kuwahara
        'add start 20190808 kuwahara
        WLSJDN1.JDN1_PARA1 = "1" & "1"
        'add end 20190808 kuwahara
        '2019.03.26 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019.03.26 CHG END
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト STTJDNNO_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTJDNNO_Slist = PP.SlistCom
	End Function
End Module