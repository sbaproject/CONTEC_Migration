Option Strict Off
Option Explicit On
Module UDNNO_F61
	'
	' スロット名        : 売上伝票番号・画面項目スロット
	' ユニット名        : UDNNO.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	'
	
	'売上伝票Noの初期値を設定する。
	Function UDNNO_InitVal(ByVal UDNNO As Object, ByRef PP As clsPP, ByRef CP_UDNNO As clsCP) As Object
        Dim WK_UDNNO As Object
        '2019/03/27 CHG START
        'Call DB_GetEq(DBN_SYSTBC, 1, WG_DKBSB, BtrNormal)
        '2019/06/26 CHG START
        'Call SYSTBC_GetFirstRecByDKBSB(WG_DKBSB)
        Dim sqlWhereStr As String = ""
        If DB_NullReplace(WG_DKBSB, "") = "" Then
            sqlWhereStr = ""
        Else
            sqlWhereStr = "WHERE DKBSB = '" & WG_DKBSB & "'"
        End If

        Call GetRowsCommon("SYSTBC", sqlWhereStr)

        If DB_SYSTBC.DKBSB Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '2019/06/26 CHG E N D
        '2019/03/27 CHG E N D
        If DBSTAT = 0 Then '伝票テーブルが見つかった。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト WK_UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WK_UDNNO = SSSVal(DB_SYSTBC.DENNO) + 1
		Else
			'UPGRADE_WARNING: オブジェクト WK_UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WK_UDNNO = 1
		End If
		'UPGRADE_WARNING: オブジェクト SSS_EDTITM_EEE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNNO_InitVal = SSS_EDTITM_EEE(CP_UDNNO, WK_UDNNO, -1)
	End Function
End Module