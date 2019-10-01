Option Strict Off
Option Explicit On
Module SKHINGRP_F51
	'
	' スロット名        : 商品群・画面項目スロット
	' ユニット名        : SKHINGRP.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/14
	' 使用プログラム名  : HINMT51
	'
	Function SKHINGRP_CheckC(ByVal SKHINGRP As Object, ByVal RNKCD As Object, ByVal URISETDT As Object, ByVal De_INDEX As Object) As Object
		Dim rtn As Short
		Dim i As Short
		Dim wkSKHINGRP As String
		'
		'UPGRADE_WARNING: オブジェクト SKHINGRP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SKHINGRP_CheckC = 0
		'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SKHINGRP) = "" Then
			'UPGRADE_WARNING: オブジェクト SKHINGRP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SKHINGRP_CheckC = -1
		Else
			'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSKHINGRP = SKHINGRP + Space(Len(DB_MEIMTA.MEICDA) - Len(SKHINGRP))
            '20190718 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "043" & wkSKHINGRP, BtrNormal)
            Dim strSQL As String = ""
            strSQL = strSQL & "  Where KEYCD  = '043' AND MEICDA = '" & wkSKHINGRP & "'"
            strSQL = strSQL & "  Order By MEICDA "

            Call GetRowsCommon("MEIMTA", strSQL)
            'If DB_MEIMTA.KEYCD Is Nothing Then
            '    DBSTAT = 0
            'Else
            '    DBSTAT = 1
            'End If
            '20190718 CHG END
            If DBSTAT = 0 Then
				Call SCR_FromMEIMTA(0)
				'''''            Call DB_GetEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & Format$(URISETDT, "YYYYMMDD"), BtrNormal)
				'''''            If DBSTAT = 0 Then
				'''''                Call SCR_FromMfil(De_INDEX)
				'''''                If DB_RNKMTA.DATKB = "9" Then
				'''''                    Call DP_SSSMAIN_UPDKB(De_INDEX, "削除")
				'''''                Else
				'''''                    Call DP_SSSMAIN_UPDKB(De_INDEX, "更新")
				'''''                End If
				'''''            Else
				'''''                Call DP_SSSMAIN_UPDKB(De_INDEX, "追加")
				'''''            End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト SKHINGRP_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SKHINGRP_CheckC = -1
			End If
		End If
		
		For i = 0 To PP_SSSMAIN.MaxDspC
			'        Call SCR_FromMfil(I)
			Call DP_SSSMAIN_RNKCD(i, " ")
			Call DP_SSSMAIN_SIKRT(i, " ")
			Call DP_SSSMAIN_URISETDT(i, " ")
			Call DP_SSSMAIN_UPDKB(i, " ")
		Next i
		
	End Function
	Function SKHINGRP_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "仕切用商品群一覧検索"
        CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
        '20190718 CHG START
        '      Call DB_GetGrEq(DBN_MEIMTA, 3, "043", BtrNormal)
        '      Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "043"
        '	CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
        '	Call DB_GetNext(DBN_MEIMTA, BtrNormal)
        'Loop 
        Dim strSQL As String

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "  from MEIMTA "
        strSQL = strSQL & "  Where KEYCD  = '043' "
        strSQL = strSQL & "  Order By MEICDA "

        Dim dt As DataTable = DB_GetTable(strSQL)
        For i As Integer = 0 To dt.Rows.Count - 1
            Call Set_DB_MEIMTA(dt, DB_MEIMTA, i)
            CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(dt.Rows(i)("MEICDA"), 5) & " " & LeftWid(dt.Rows(i)("MEINMA"), 40))
        Next
        '20190718 CHG END
        SSS_WLSLIST_KETA = 5
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SKHINGRP_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SKHINGRP_Slist = PP.SlistCom
		
	End Function
End Module