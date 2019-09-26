Option Strict Off
Option Explicit On
Module NHSCLAID_FM1
	'
	' スロット名        : 納品先分類区分Ａ・画面項目スロット
	' ユニット名        : NHSCLAID.FM1
	' 記述者            : Standard Library
	' 作成日付          : 1998/10/02
	' 使用プログラム名  : NHSMR01
	'
	
	Function NHSCLAID_Check(ByVal NHSCLAID As Object, ByVal EX_NHSCLAID As Object, ByVal De_Index As Object) As Object
		'Function NHSCLAID_Check(ByVal NHSCLAID, ByVal De_Index)
		Dim Rtn As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト NHSCLAID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLAID_Check = 0
        'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(NHSCLAID) = "" Then
            '2019/09/25 DEL START
            'Call CLSMTA_RClear()
            '2019/09/25 DEL END
            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call NHSCLAID_Move(De_Index)
            '98/09/26 2行追加
            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call NHSCLBID_Move(De_Index)
            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call NHSCLCID_Move(De_Index)
            'Else 98/09/26 1行修正
            'UPGRADE_WARNING: オブジェクト EX_NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        ElseIf NHSCLAID <> EX_NHSCLAID Then
            'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト LenWid(RTrim$(NHSCLAID)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            keyVal = RTrim(NHSCLAID) & Space(LenWid(DB_NHSMTA.NHSCLAID) - LenWid(RTrim(NHSCLAID)))
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLAKB & keyVal, BtrNormal)
			'98/10/02 1行追加
			If DBSTAT = 0 Then Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "1" & keyVal, BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call NHSCLAID_Move(De_Index)
                '98/09/26 3行追加
                '2019/09/25 DEL START
                'Call CLSMTA_RClear()
                '2019/09/25 DEL END
                'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call NHSCLBID_Move(De_Index)
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call NHSCLCID_Move(De_Index)
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト NHSCLAID_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSCLAID_Check = -1
			End If
		End If
	End Function
	
	Function NHSCLAID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(DB_SYSTBF.CLAKB)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(DB_SYSTBF.CLAKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLAID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLAID", "3303")
		End If
	End Function
	
	Sub NHSCLAID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLAID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLANM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLAID_Slist(ByRef PP As clsPP) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "分類一覧"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "1", BtrNormal)
		Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "1"
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLAKB & DB_CLSMTB.CLAID, BtrNormal)
			If DBSTAT = 0 Then
				CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & " " & DB_CLSMTA.CLSNM)
			End If
			Call DB_GetNext(DBN_CLSMTB, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NHSCLAID_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLAID_Slist = PP.SlistCom
	End Function
End Module