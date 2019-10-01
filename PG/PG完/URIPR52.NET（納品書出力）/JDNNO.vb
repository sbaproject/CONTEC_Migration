Option Strict Off
Option Explicit On
Module JDNNO_F56
	'
	' スロット名        : 受注伝票番号・画面項目スロット
	' ユニット名        : JDNNO.F56
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIPR52/SEIPR54
	'
	Function JDNNO_Slist(ByRef PP As clsPP, ByVal JDNNO As Object) As Object

        'delete start 20190816 kuwahara
        'DB_PARA(DBN_JDNTHA).KeyNo = 2
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "1"
        'delete end 20190816 kuwahara
        'add start 20190816 kuwahara
        WLSJDN1.JDN1_PARA1 = "1" & "1"
        'add end 20190816 kuwahara
        '2019.04.08 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019.04.08 CHG END
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト JDNNO_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNNO_Slist = PP.SlistCom
	End Function
	Function JDNNO_CheckC(ByVal JDNNO As Object) As Object
		Dim Rtn As Object
		Dim wkJDNNO As String
		Dim wkLINNO As String
		
		'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNNO_CheckC = 0
		'UPGRADE_WARNING: オブジェクト JDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(JDNNO) = "" Then
			Exit Function
		End If
        'UPGRADE_WARNING: オブジェクト JDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190809 kuwahara
        'wkJDNNO = Left(JDNNO, 6) & Space(Len(DB_JDNTHA.JDNNO) - 6)
        wkJDNNO = Left(JDNNO, 6) & Space(10 - 6) ' JDNTHAテーブルのJDNNOが10桁であるため。
        'change end 20190809 kuwahara
        'change start 20190809 kuwahara
        'Call DB_GetEq(DBN_JDNTHA, 2, "1" & "1" & wkJDNNO, BtrNormal)
        GetRowsCommon("JDNTHA", "where DATKB = '1' and DENKB = '1' and JDNNO = '" & wkJDNNO & "'")
        'change end 20190809 kuwahara
        If DBSTAT <> 0 Then
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
			'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			JDNNO_CheckC = -1
		End If
	End Function
End Module