Option Strict Off
Option Explicit On
Module HTANCD_F51
	'
	'スロット名      :発注担当・画面項目スロット
	'ユニット名      :HTANCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/06/15
	'使用プログラム  :BMNMTA51
	
	Function HTANCD_CheckC(ByRef HTANCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkHTANCD As String
		'2008/12/16 RISE)izumi ADD START  連絡票№:643
		Dim strSQL As String
		Dim wkSTTTKDT As String
		Dim wkENDTKDT As String
		Dim wkBMNCD As String
		'2008/12/16 RISE)izumi ADD END
		
		'UPGRADE_WARNING: オブジェクト HTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		HTANCD_CheckC = 0
		'2008/12/16 RISE)izumi ADD START  連絡票№:643
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkBMNCD = RD_SSSMAIN_BMNCD(De_Index)
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkSTTTKDT = RD_SSSMAIN_STTTKDT(De_Index)
		'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		wkENDTKDT = RD_SSSMAIN_ENDTKDT(De_Index)
		'部門コードが入力されていない場合、エラーとする
		If Trim(wkBMNCD) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 8)
			'UPGRADE_WARNING: オブジェクト HTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HTANCD_CheckC = -1
			Exit Function
		End If
		'適用開始日・適用終了日が入力されていない場合、エラーとする
		If Trim(wkSTTTKDT) = "" Or Trim(wkENDTKDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 9)
			'UPGRADE_WARNING: オブジェクト HTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			HTANCD_CheckC = -1
			Exit Function
		End If
		'2008/12/16 RISE)izumi ADD END
		'UPGRADE_WARNING: オブジェクト HTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(HTANCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(HTANCD)) = 0 Then
		Else
            '2008/12/16 RISE)izumi CHG START  連絡票№:643
            '        wkHTANCD = HTANCD & Space(Len(DB_MEIMTA.MEICDA) - Len(HTANCD))
            '        Call DB_GetEq(DBN_MEIMTA, 2, "024" & wkHTANCD, BtrNormal)
            'UPGRADE_WARNING: オブジェクト HTANCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '2019/10/04 CHG START
            'wkHTANCD = HTANCD & Space(Len(DB_MEIMTC.MEICDA) - Len(HTANCD))
            If DB_MEIMTA.MEICDA Is Nothing OrElse Len(DB_MEIMTA.MEICDA) - Len(HTANCD) Then
                wkHTANCD = (HTANCD)
            Else
                wkHTANCD = (HTANCD) & Space(Len(DB_MEIMTA.MEICDA) - Len(HTANCD))
            End If
            '2019/10/04 CHG E N D

            strSQL = ""
			strSQL = strSQL & "SELECT "
			strSQL = strSQL & " * "
			strSQL = strSQL & "FROM "
			strSQL = strSQL & " MEIMTC "
			strSQL = strSQL & "WHERE "
			strSQL = strSQL & " KEYCD = '024' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " MEICDA = '" & wkHTANCD & "' "
			If Trim(wkSTTTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " STTTKDT <= '" & wkSTTTKDT & "' "
			End If
			If Trim(wkENDTKDT) <> "" Then
				strSQL = strSQL & "AND "
				strSQL = strSQL & " ENDTKDT >= '" & wkENDTKDT & "' "
			End If
			
			Call DB_GetSQL2(DBN_MEIMTC, strSQL)
			'2008/12/16 RISE)izumi CHG END
			If DBSTAT = 0 Then
				'2008/12/16 RISE)izumi CHG START  連絡票№:643
				'            If DB_MEIMTA.DATKB = "9" Then
				If DB_MEIMTC.DATKB = "9" Then
					'2008/12/16 RISE)izumi CHG END
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト HTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					HTANCD_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト HTANCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				HTANCD_CheckC = -1
			End If
		End If
		
	End Function
End Module