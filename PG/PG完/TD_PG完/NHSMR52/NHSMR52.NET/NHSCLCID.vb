Option Strict Off
Option Explicit On
Module NHSCLCID_FM1
	'
	' スロット名        : 納品先分類区分Ｃ・画面項目スロット
	' ユニット名        : NHSCLCID.FM1
	' 記述者            : SNHSdard Library
	' 作成日付          : 1997/05/28
	' 使用プログラム名  : NHSMR01
	'
	
	Function NHSCLCID_CheckC(ByVal NHSCLAID As Object, ByVal NHSCLBID As Object, ByVal NHSCLCID As Object, ByVal De_Index As Object) As Object
		Dim rtn, keyLen As Short
		Dim keyVal As String
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト NHSCLCID_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLCID_CheckC = 0
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		keyLen = LenWid(DB_CLSMTA.CLSID)
        '
        'UPGRADE_WARNING: オブジェクト NHSCLCID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(NHSCLCID) = "" Then
            '20190821 CHG START
            'Call CLSMTA_RClear()
            '20190821 CHG END
            'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call NHSCLCID_Move(De_Index)
        Else
            If DB_SYSTBF.OYAKBC = "1" Then
				'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				keyVal = CStr(NHSCLBID) & Space(keyLen - LenWid(CStr(NHSCLBID)))
				If DB_SYSTBF.OYAKBB = "1" Then
					'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					keyVal = CStr(NHSCLAID) & Space(keyLen - LenWid(CStr(NHSCLAID))) & keyVal
				Else
					keyVal = Space(keyLen) & keyVal
				End If
			Else
				keyVal = Space(keyLen) & Space(keyLen)
			End If
			''
			''2001/05/10 分類Ｃを有効にする
			''Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB & "3" & keyVal & NHSCLAID, BtrNormal)
			'UPGRADE_WARNING: オブジェクト NHSCLCID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "3" & keyVal & NHSCLCID, BtrNormal)
			'UPGRADE_WARNING: オブジェクト NHSCLCID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLCKB & NHSCLCID, BtrNormal)
			If DB_PARA(DBN_CLSMTB).Status = 0 And DB_PARA(DBN_CLSMTA).Status = 0 Then
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call NHSCLCID_Move(De_Index)
			Else
				rtn = DSP_MsgBox(SSS_ERROR, "DONTSELECT", 0) ' このコードは選択できません。
				'UPGRADE_WARNING: オブジェクト NHSCLCID_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				NHSCLCID_CheckC = -1
			End If
		End If
	End Function
	
	Function NHSCLCID_InitVal() As Object
		'
		If SSS_MSTKB.Value <> DB_SYSTBF.MSTKB Then Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(DB_SYSTBF.CLCKB)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(DB_SYSTBF.CLCKB)) = 0 Then
			Call AE_InOutModeN_SSSMAIN("NHSCLCID", "0000")
		Else
			Call AE_InOutModeN_SSSMAIN("NHSCLCID", "3303")
		End If
	End Function
	
	Sub NHSCLCID_Move(ByVal De As Short)
		'
		Call DP_SSSMAIN_NHSCLCID(De, DB_CLSMTA.CLSID)
		Call DP_SSSMAIN_NHSCLCNM(De, DB_CLSMTA.CLSNM)
	End Sub
	
	Function NHSCLCID_Slist(ByRef PP As clsPP, ByVal NHSCLAID As Object, ByVal NHSCLBID As Object) As Object
		'
		Call DB_GetEq(DBN_SYSTBF, 1, SSS_MSTKB.Value, BtrNormal)
		WLS_LIST.Text = "分類一覧"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_CLSMTB, 1, SSS_MSTKB.Value & "3", BtrNormal)
		If DB_SYSTBF.OYAKBB = "1" And DB_SYSTBF.OYAKBC = "1" Then
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
				'UPGRADE_WARNING: オブジェクト NHSCLAID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If DB_CLSMTB.CLBID = NHSCLBID And DB_CLSMTB.CLAID = NHSCLAID Then
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '20190821 CHG START
                    'GoSub ReadCLSMTA
                    GoTo ReadCLSMTA
                    '20190821 CHG END
                End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		ElseIf DB_SYSTBF.OYAKBC = "1" Then  'Update 1996 / 5 / 22
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
				'UPGRADE_WARNING: オブジェクト NHSCLBID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If DB_CLSMTB.CLBID = NHSCLBID Then
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '20190821 CHG START
                    'GoSub ReadCLSMTA
                    GoTo ReadCLSMTA
                    '20190821 CHG END
                End If
				Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		Else
			Do While DBSTAT = 0 And DB_CLSMTB.MSTKB = DB_SYSTBF.MSTKB And DB_CLSMTB.CLSKEYKB = "3"
                'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                '20190821 CHG START
                'GoSub ReadCLSMTA
                GoTo ReadCLSMTA
                '20190821 CHG END
                Call DB_GetNext(DBN_CLSMTB, BtrNormal)
			Loop 
		End If
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_WLSLIST_KETA = LenWid(DB_CLSMTA.CLSID)
		WLS_LIST.ShowDialog()
		WLS_LIST.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト NHSCLCID_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		NHSCLCID_Slist = PP.SlistCom
		Exit Function
ReadCLSMTA: 
		Call DB_GetEq(DBN_CLSMTA, 1, DB_SYSTBF.CLCKB & DB_CLSMTB.CLCID, BtrNormal)
		If DBSTAT = 0 Then
			CType(WLS_LIST.Controls("LST"), Object).Items.Add(DB_CLSMTA.CLSID & "  " & DB_CLSMTA.CLSNM)
		End If
        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        'Return 
    End Function
End Module