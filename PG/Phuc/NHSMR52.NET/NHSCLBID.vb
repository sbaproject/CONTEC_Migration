Option Strict Off
Option Explicit On
Module NHSCLBID_FM1
	'
	' スロット名        : 納品先分類区分Ｂ・画面項目スロット
	' ユニット名        : NHSCLBID.FM1
	' 記述者            : Standard Library
	' 作成日付          : 1998/09/26
	' 使用プログラム名  : NHSMT01
	'
	
	Function NHSCLBID_Check(ByVal NHSCLAID As Object, ByVal NHSCLBID As Object, ByVal EX_NHSCLBID As Object, ByVal De_Index As Object) As Object
		'Function NHSCLBID_Check(ByVal NHSCLAID, ByVal NHSCLBID, ByVal De_Index)
		Dim rtn, keyLen As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト NHSCLBID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLBID_Check = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		keyLen = LenWid(DB_CLSMTA.CLSID)
		'
		'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(NHSCLBID) = "" Then
			Call CLSMTA_RClear()
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call NHSCLBID_Move(De_Index)
			'98/09/26 1行追加
			'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call NHSCLCID_Move(De_Index)
			'Else 98/09/26 1行修正
			'UPGRADE_WARNING: オブジェクト EX_NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf NHSCLBID <> EX_NHSCLBID Then 
			If DB_SYSTBF.OYAKBB = "1" Then
				'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				keyVal = CStr(NHSCLAID) & Space(keyLen - LenWid(CStr(NHSCLAID)))
			Else
				keyVal = Space(keyLen)
			End If
			'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "2" & keyVal & NHSCLBID, BtrNormal)
			'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLBKB & NHSCLBID, BtrNormal)
			If DB_PARA(DBN_CLSMTA).Status = 0 And DB_PARA(DBN_CLSMTB).Status = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call NHSCLBID_Move(De_Index)
				'98/09/26 2行追加
				Call CLSMTA_RClear()
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call NHSCLCID_Move(De_Index)
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "DONTSELECT", 0) ' このコードは選択できません。
				'UPGRADE_WARNING: オブジェクト NHSCLBID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSCLBID_Check = -1
			End If
		End If
	End Function
	
	Function NHSCLBID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(DB_SYSTBF.CLBKB)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(DB_SYSTBF.CLBKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLBID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLBID", "3303")
		End If
	End Function
	
	Sub NHSCLBID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLBID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLBNM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLBID_Slist(ByRef PP As clsPP, ByVal NHSCLAID As Object) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "分類一覧"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "2", BtrNormal)
		If DB_SYSTBF.OYAKBB = "1" Then
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "2"
				'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If DB_CLSMTB.CLAID = NHSCLAID Then
					'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
					GoSub ReadCLSMTA
				End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		Else
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "2"
				'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
				GoSub ReadCLSMTA
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		End If
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NHSCLBID_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLBID_Slist = PP.SlistCom
		Exit Function
ReadCLSMTA: 
		Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLBKB & DB_CLSMTB.CLBID, BtrNormal)
		If DBSTAT = 0 Then
			CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & "  " & DB_CLSMTA.CLSNM)
		End If
		'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Return 
	End Function
End Module