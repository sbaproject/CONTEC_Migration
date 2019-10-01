Option Strict Off
Option Explicit On
Module JDNTRKB_F51
	'
	' スロット名        : 受注取引区分・画面項目スロット
	' ユニット名        : JDNTRKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/24
	' 使用プログラム名  : URIET53
	'
	
	Function JDNTRKB_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "受注取引区分一覧"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
			CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 2
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト JDNTRKB_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNTRKB_Slist = PP.SlistCom
		
	End Function
End Module