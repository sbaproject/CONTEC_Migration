Option Strict Off
Option Explicit On
Module TIKKB_F51
	'
	' スロット名        : 地区区分・画面項目スロット
	' ユニット名        : TIKKB.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/30
	' 使用プログラム名  : BMNMT51
	'
	
	Function TIKKB_CheckC(ByVal TIKKB As Object, ByVal EIGYOCD As Object, ByVal De_Index As Object) As Object
		Dim rtn As Short
		Dim wkTIKKB As String
		'2008/12/16 RISE)izumi ADD START  連絡票��:643
		Dim strSQL As String
		Dim wkSTTTKDT As String
		Dim wkENDTKDT As String
		Dim wkBMNCD As String
		'2008/12/16 RISE)izumi ADD END
		
		'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TIKKB_CheckC = 0
		'2008/12/16 RISE)izumi ADD START  連絡票��:643
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
			'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TIKKB_CheckC = -1
			Exit Function
		End If
		'適用開始日・適用終了日が入力されていない場合、エラーとする
		If Trim(wkSTTTKDT) = "" Or Trim(wkENDTKDT) = "" Then
			rtn = DSP_MsgBox(SSS_ERROR, "BMNMT51_1", 9)
			'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TIKKB_CheckC = -1
			Exit Function
		End If
		'2008/12/16 RISE)izumi ADD END
		'UPGRADE_WARNING: オブジェクト TIKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(TIKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(TIKKB) = 0 Or Trim(TIKKB) = "" Then
			'UPGRADE_WARNING: オブジェクト EIGYOCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト LenWid(Trim$(EIGYOCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LenWid(Trim(EIGYOCD)) <> 0 Then
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TIKKB_CheckC = -1
			End If
		Else
			'2008/12/16 RISE)izumi CHG START  連絡票��:643
			'        wkTIKKB = TIKKB & Space(Len(DB_MEIMTA.MEICDA) - Len(TIKKB))
			'        Call DB_GetEq(DBN_MEIMTA, 2, "060" & wkTIKKB, BtrNormal)
			'UPGRADE_WARNING: オブジェクト TIKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkTIKKB = TIKKB & Space(Len(DB_MEIMTC.MEICDA) - Len(TIKKB))
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkSTTTKDT = RD_SSSMAIN_STTTKDT(De_Index)
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			wkENDTKDT = RD_SSSMAIN_ENDTKDT(De_Index)
			
			strSQL = ""
			strSQL = strSQL & "SELECT "
			strSQL = strSQL & " * "
			strSQL = strSQL & "FROM "
			strSQL = strSQL & " MEIMTC "
			strSQL = strSQL & "WHERE "
			strSQL = strSQL & " KEYCD = '060' "
			strSQL = strSQL & "AND "
			strSQL = strSQL & " MEICDA = '" & wkTIKKB & "' "
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
				'2008/12/16 RISE)izumi CHG START  連絡票��:643
				'            If DB_MEIMTA.DATKB = "9" Then
				If DB_MEIMTC.DATKB = "9" Then
					'2008/12/16 RISE)izumi CHG END
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					TIKKB_CheckC = 1
				End If
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト TIKKB_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TIKKB_CheckC = -1
			End If
		End If
		
	End Function
	
	Function TIKKB_Derived(ByVal TIKKB As Object, ByVal EIGYOCD As Object, ByVal De_Index As Short) As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト EIGYOCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Len(Trim(EIGYOCD)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("TIKKB", "0000")
			Call DP_SSSMAIN_TIKKB(De_Index, " ")
		Else
			Call AE_InOutModeN_SSSMAIN("TIKKB", "3303")
		End If
		
	End Function
End Module