Option Strict Off
Option Explicit On
Module TOKCD_F51
	'
	'スロット名      :得意先コード(販売単価マスタ登録）・画面項目スロット
	'ユニット名      :TOKCD.FM4
	'記述者          :Standard Library
	'作成日付        :1997/07/03
	'使用プログラム  :SIRMT03
	'
	
	Function TOKCD_Check(ByVal TOKCD As Object, ByVal HINCD As Object, ByVal URITKDT As Object, ByVal TUKKB As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		'Call HINMTA_RClear
		'Call TOKMTA_RClear
		'Call TOKMTC_RClear
		'Call SCR_FromMfil(De_Index)
		'初期値
		DB_TOKMTC.URITK = 0
		'UPGRADE_WARNING: オブジェクト TOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TOKCD_Check = 0
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TOKCD) = "" Then
			'UPGRADE_WARNING: オブジェクト TOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			TOKCD_Check = -1
		Else
			
			'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(HINCD) <> "" And Trim(TOKCD) <> "" And Trim(URITKDT) <> "" And Trim(TUKKB) <> "" Then
				'UPGRADE_WARNING: オブジェクト TUKKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト URITKDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetSQL2(DBN_TOKMTC, "select * from TOKMTC where HINCD ='" & Trim(HINCD) & "' and TOKCD ='" & Trim(TOKCD) & "' and URITKDT ='" & VB6.Format(URITKDT, "YYYYMMDD") & "'" & "and TUKKB ='" & Trim(TUKKB) & "'")
				If DBSTAT = 0 Then
					Do While DBSTAT = 0
						If DB_TOKMTC.DATKB = "9" Then
							'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call DP_SSSMAIN_UPDKB(De_Index, "削除")
						Else
							'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call DP_SSSMAIN_UPDKB(De_Index, "更新")
						End If
						Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
						'HINMTAの存在ﾁｪｯｸ
						If DBSTAT = 0 Then
							'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call HINCD_Move(HINCD, De_Index)
							
						Else
							'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call DP_SSSMAIN_HINNMA(De_Index, "　")
						End If
						Call DB_GetNext(DBN_TOKMTC, BtrNormal)
					Loop 
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "追加")
					Call DB_GetEq(DBN_HINMTA, 1, HINCD, BtrNormal)
					If DBSTAT = 0 Then '商品ﾏｽﾀに当該項目が在る時
						'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call HINCD_Move(HINCD, De_Index)
					Else
						'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call DP_SSSMAIN_HINNMA(De_Index, "　")
					End If
				End If
			End If
			
			Call DB_GetEq(DBN_TOKMTA, 1, TOKCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_TOKMTA.DATKB = "9" Then
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト TOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					TOKCD_Check = 1
				End If
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call TOKCD_Move(TOKCD, De_Index)
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当するデータはありません。
				'UPGRADE_WARNING: オブジェクト TOKCD_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				TOKCD_Check = -1
			End If
			
		End If
	End Function
	
	Function TOKCD_Slist(ByRef PP As clsPP, ByVal TOKCD As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_PARA(DBN_TOKMTA).KeyBuf = TOKCD
		WLSTOK.ShowDialog()
		WLSTOK.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TOKCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		TOKCD_Slist = PP.SlistCom
	End Function
	Sub TOKCD_Move(ByVal TOKCD As Object, ByVal De As Short)
		
		'UPGRADE_WARNING: オブジェクト TOKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(TOKCD) <> "" Then
			Call DP_SSSMAIN_TOKCD(De, DB_TOKMTA.TOKCD)
			Call DP_SSSMAIN_TOKRN(De, DB_TOKMTA.TOKRN)
		Else
			Call DP_SSSMAIN_TOKCD(De, " ")
			Call DP_SSSMAIN_TOKRN(De, " ")
		End If
		
		'UPGRADE_WARNING: オブジェクト SSSVal(DB_TOKMTC.URITK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CStr(DB_TOKMTC.URITK)) = "" Or SSSVal(DB_TOKMTC.URITK) = 0 Then
			Call DP_SSSMAIN_URITK(De, "")
		Else
			Call DP_SSSMAIN_URITK(De, DB_TOKMTC.URITK)
		End If
		
	End Sub
End Module