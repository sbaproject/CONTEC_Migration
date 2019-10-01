Option Strict Off
Option Explicit On
Module SOUCD_F01
	'
	'スロット名      :倉庫コード・画面項目スロット
	'ユニット名      :SOUCD.F01
	'記述者          :Standard Library
	'作成日付        :1997/07/03
	'使用プログラム  :FRKET01 / NYKET01 / NYKET12 / NYKET31 /
	'                :SODET01 / SREET01 / SYKET01 / SYKET12 /
	'                :SYKET31 / TNAET11 / UODET01 / URIET01
	
	Function SOUCD_CheckC(ByVal SOUCD As Object, ByVal De_Index As Object, ByVal Ex_SOUCD As Object) As Object
		Dim Rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト SOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SOUCD_CheckC = 0
        '20190712 dell start
        'Call SOUMTA_RClear()
        '20190712 dell end
        '20190716  CHG START
        'Call DB_GetEq(DBN_SOUMTA, 1, SOUCD, BtrNormal)

        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE SOUCD = '" & SOUCD & "' "
        Call GetRowsCommon("SOUMTA", sqlWhereStr)

        If DB_SOUMTA.SOUCD Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If

        If DBSTAT = 0 Then
			If DB_SOUMTA.DATKB = "9" Then
				Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
				'UPGRADE_WARNING: オブジェクト SOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SOUCD_CheckC = 1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: オブジェクト SOUCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SOUCD_CheckC = -1
		End If
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call Scr_FromSOUMTA(De_Index)
	End Function
	
	Function SOUCD_Slist(ByRef PP As clsPP, ByVal SOUCD As Object) As Object
		'
		WLS_LIST.Text = "倉庫一覧"
        CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
        '20190716 CHG START
        'Call DB_GetFirst(DBN_SOUMTA, 1, BtrNormal)

        '     Do While DBSTAT = 0
        'If DB_SOUMTA.DATKB <> "9" Then CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_SOUMTA.SOUCD & " " & DB_SOUMTA.SOUNM)
        '         Call DB_GetNext(DBN_SOUMTA, BtrNormal)
        '     Loop 
        'SSS_WLSLIST_KETA = LenWid(DB_SOUMTA.SOUCD)

        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from SOUMTA "


        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("DATKB") <> "9" Then
                CType(WLS_LIST.Controls("LST"), Object).Items.Add(dt.Rows(i)("SOUCD") & " " & dt.Rows(i)("SOUNM"))
                SSS_WLSLIST_KETA = LenWid(dt.Rows(i)("SOUCD"))
            End If
        Next
        '20190716 CHG END
        'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WLS_LIST.ShowDialog()
        WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SOUCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SOUCD_Slist = PP.SlistCom
	End Function
End Module