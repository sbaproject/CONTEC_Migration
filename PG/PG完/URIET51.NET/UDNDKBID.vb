Option Strict Off
Option Explicit On
Module UDNDKBID_F01
	'
	' スロット名        : 取引区分・画面項目スロット
	' ユニット名        : UDNDKBID.F01
	' 記述者            : Standard Library
	' 作成日付          : 1998/04/28
	' 使用プログラム名  : URIET01
	'
	
	'取引区分コードが入力された場合に、そのチェックを行う。
	Function UDNDKBID_Check(ByRef PP As clsPP, ByRef CP_UDNDKBID As clsCP, ByRef UDNDKBID As Object, ByVal EX_UDNDKBID As Object, ByVal DE_INDEX As Object) As Object
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Check = 0 '正常終了。
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(UDNDKBID) = "" Then Exit Function
		'    If EX_UDNDKBID = UDNDKBID Then Exit Function  1998/04/28 delete
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LINNO = VB6.Format(DE_INDEX + 1, "000")
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If UDNDKBID = "99" Then UDNDKBID = "01"
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetEq(DBN_SYSTBD, 1, WG_DKBSB & UDNDKBID, BtrNormal)
		If DBSTAT = 0 Then
			If Trim(DB_SYSTBD.DFLDKBCD) <> "" Then
				Call DB_GetEq(DBN_HINMTA, 1, DB_SYSTBD.DFLDKBCD, BtrNormal)
				If DBSTAT = 0 Then
					'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト EX_UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If EX_UDNDKBID <> UDNDKBID Then '1998/05/20 Insert
						Call AE_ClearDe_SSSMAIN()
						'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call SCR_FromHINMTA(DE_INDEX)
					End If '1998/05/20 Insert
				Else
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 3)
					'UPGRADE_WARNING: オブジェクト UDNDKBID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					UDNDKBID_Check = -1
					Exit Function
				End If
				Call AE_InOutModeN_SSSMAIN("HINCD", "0000")
				Call AE_InOutModeN_SSSMAIN("HINNMA", "0000")
				Call AE_InOutModeN_SSSMAIN("HINNMB", "0000")
				Call AE_InOutModeN_SSSMAIN("IRISU", "0000")
				Call AE_InOutModeN_SSSMAIN("CASSU", "0000")
				Call AE_InOutModeN_SSSMAIN("URISU", "0000")
				Call AE_InOutModeN_SSSMAIN("URITK", "0000")
			End If
			Select Case SSSVal(DB_SYSTBD.UPDID)
				Case 0, 1
					Call AE_InOutModeN_SSSMAIN("HINCD", "3303")
					Call AE_InOutModeN_SSSMAIN("HINNMA", "2202")
					Call AE_InOutModeN_SSSMAIN("HINNMB", "2202")
					'Call AE_InOutModeN_SSSMAIN("IRISU", "2202")
					Call AE_InOutModeN_SSSMAIN("CASSU", "2202")
					Call AE_InOutModeN_SSSMAIN("URISU", "2202")
					Call AE_InOutModeN_SSSMAIN("URITK", "2202")
				Case Else
			End Select
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call SCR_FromSYSTBD(DE_INDEX)
		Else
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Check = -1
		End If
	End Function
	
	Function UDNDKBID_Derived(ByRef PP As clsPP, ByVal UDNDKBID As Object, ByVal HINCD As Object, ByVal DE_INDEX As Object) As Object
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Derived = UDNDKBID
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(UDNDKBID) <> "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then Exit Function
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID = "01"
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Derived = UDNDKBID
		'
		'UPGRADE_WARNING: オブジェクト UDNDKBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DB_GetEq(DBN_SYSTBD, 1, WG_DKBSB & UDNDKBID, BtrNormal)
		If DBSTAT = 0 Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call SCR_FromSYSTBD(DE_INDEX)
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DP_SSSMAIN_HINCD(DE_INDEX, HINCD)
		Else
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Derived = System.DBNull.Value
		End If
	End Function
	
	Function UDNDKBID_Skip(ByRef PP As clsPP, ByVal HINCD As Object) As Object
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Skip = True
		If PP.CursorDirection = 0 Or PP.CursorDirection = 2 Or PP.CursorDirection = 4 Then '1999/05/20 Update
			'UPGRADE_WARNING: オブジェクト UDNDKBID_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNDKBID_Skip = False
		End If
	End Function
	
	'商品分類コードの入力候補一覧を表示する。
	Function UDNDKBID_Slist(ByRef PP As clsPP) As Object
		WLS_LIST.Text = "区分"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_SYSTBD, 1, WG_DKBSB, BtrNormal)
		Do While DBSTAT = 0 And DB_SYSTBD.DKBSB = WG_DKBSB
			If DB_SYSTBD.DKBID <> "99" Then
				CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_SYSTBD.DKBID & " " & DB_SYSTBD.DKBNM)
			End If
			Call DB_GetNext(DBN_SYSTBD, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 2
		WLS_LIST.ShowDialog() '0:入力候補一覧は入力後に残す指定。
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNDKBID_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNDKBID_Slist = PP.SlistCom
	End Function
End Module