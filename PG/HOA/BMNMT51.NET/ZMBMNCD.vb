Option Strict Off
Option Explicit On
Module ZMBMNCD_F51
	'
	' スロット名        : 会計部門・画面項目スロット
	' ユニット名        : ZMBNCD.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/15
	' 使用プログラム名  : BMNMT51
	'
	Function ZMBMNCD_CheckC(ByRef ZMBMNCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkZMBMNCD As String
		'''' ADD 2011/09/22  FKS) T.Yamamoto    Start    連絡票№FC11092201
		Dim strSQL As String
		Dim wkSTTTKDT As String
		Dim wkENDTKDT As String
		'''' ADD 2011/09/22  FKS) T.Yamamoto    End
		
		'UPGRADE_WARNING: オブジェクト ZMBMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ZMBMNCD_CheckC = 0
		'''' ADD 2011/09/22  FKS) T.Yamamoto    Start    連絡票№FC11092201
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkSTTTKDT = RD_SSSMAIN_STTTKDT(De_Index)
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkENDTKDT = RD_SSSMAIN_ENDTKDT(De_Index)
		
		'適用開始日・適用終了日が入力されていない場合、エラーとする
		If Trim(wkSTTTKDT) = "" Or Trim(wkENDTKDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 9)
			'UPGRADE_WARNING: オブジェクト ZMBMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZMBMNCD_CheckC = -1
			Exit Function
		End If
		'''' ADD 2011/09/22  FKS) T.Yamamoto    End
		
		'UPGRADE_WARNING: オブジェクト ZMBMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(ZMBMNCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(ZMBMNCD)) = 0 Then
			rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: オブジェクト ZMBMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ZMBMNCD_CheckC = -1
		Else
            '''' UPD 2011/09/22  FKS) T.Yamamoto    Start    連絡票№FC11092201
            '        wkZMBMNCD = ZMBMNCD & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMBMNCD))
            '        Call DB_GetEq(DBN_MEIMTA, 2, "023" & wkZMBMNCD, BtrNormal)
            '        If DBSTAT = 0 Then
            '            If DB_MEIMTA.DATKB = "9" Then
            'UPGRADE_WARNING: オブジェクト ZMBMNCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/04 CHG START
            'wkZMBMNCD = ZMBMNCD & Space(Len(DB_MEIMTC.MEICDA) - Len(ZMBMNCD))
            If DB_MEIMTA.MEICDA Is Nothing OrElse Len(DB_MEIMTA.MEICDA) - Len(ZMBMNCD) Then
                wkZMBMNCD = (ZMBMNCD)
            Else
                wkZMBMNCD = (ZMBMNCD) & Space(Len(DB_MEIMTA.MEICDA) - Len(ZMBMNCD))
            End If
            '2019/10/04 CHG E N D

            strSQL = ""
			strSQL = strSQL & "SELECT "
			strSQL = strSQL & " * "
			strSQL = strSQL & "FROM "
			strSQL = strSQL & " MEIMTC "
			strSQL = strSQL & "WHERE "
			strSQL = strSQL & " KEYCD = '023' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " MEICDA = '" & AE_EditSQLText(wkZMBMNCD) & "' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " STTTKDT <= '" & wkSTTTKDT & "' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " ENDTKDT >= '" & wkENDTKDT & "' "

            Call DB_GetSQL2(DBN_MEIMTC, strSQL)


            If DBSTAT = 0 Then
				If DB_MEIMTC.DATKB = "9" Then
					'''' UPD 2011/09/22  FKS) T.Yamamoto    End
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト ZMBMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ZMBMNCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト ZMBMNCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ZMBMNCD_CheckC = -1
			End If
			
		End If
		
	End Function
End Module