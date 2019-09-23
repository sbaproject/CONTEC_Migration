Option Strict Off
Option Explicit On
Module UDNNO_F51
	'
	' スロット名        : 受注No(売上番号）・画面項目スロット
	' ユニット名        : UDNNO.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/09
	' 使用プログラム名  : URIET54
	'
	
	'伝票Noが入力された場合に、そのチェックを行う。
	Function UDNNO_CheckC(ByRef UDNNO As Object, ByRef PP As clsPP, ByRef CP_UDNNO As clsCP) As Object
		Dim Rtn As Object
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		Dim strSQL As String
		Dim wkDATNO As String
		'20090115 ADD END   RISE)Tanimura
		
		SetFirst = True
		
		'シリアル№登録ワークの削除
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
			Call DB_Delete(DBN_SRAET52)
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNNO_CheckC = 0
		'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(UDNNO) = "" Then
			'番号が空白(or 0)に変更された時に, 初期化する場合
			'単なるエラーでよければこの Ifブロックは不要
			'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNNO_CheckC = -1
			SSS_LASTKEY.Value = ""
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
			Exit Function
		End If
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_UDNTHA, 1, Left(UDNNO, 10), BtrNormal)
			If DBSTAT = 0 Then
				'2008/1/22 FKS)ichihara CHG START
				'検収基準の売上の返品を可とする
				''2007/08/23 ADD-START   検収基準の売上は返品不可チェック
				'        If DB_UDNTHA.URIKJN = "02" Then
				'            '2007/12/06 FKS)minamoto CHG START
				'            'Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8)  '検収基準の売上の為エラー
				'            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_002", 0)  '検収基準の売上の為エラー
				'            '2007/12/06 FKS)minamoto CHG END
				'            UDNNO_CheckC = -1
				'            Exit Function
				'        End If
				''2007/08/23 ADD-END　   検収基準の売上は返品不可チェック
				'2008/1/22 FKS)ichihara CHG END
				'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetEq(DBN_UDNTRA, 1, Left(UDNNO, 13), BtrNormal)
				If DBSTAT <> 0 Then
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
					'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					UDNNO_CheckC = -1
				Else
					'2007/03/21 UPD-START
					'            If Trim$(DB_UDNTRA.HENRSNCD) <> "" Then
					'UPGRADE_WARNING: オブジェクト SSSVal(DB_UDNTRA.CASSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(DB_UDNTRA.HENRSNCD) <> "" And SSSVal(DB_UDNTRA.CASSU) = 0 Then
						'2007/03/21 UPD-END
						'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 6) '既に返品済みの為エラー
						'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						UDNNO_CheckC = -1
						Exit Function
					End If
					
					If DB_UDNTRA.ZAIKB = "9" Then
						'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '在庫管理なしの為エラー
						'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						UDNNO_CheckC = -1
						Exit Function
					End If
					''''2007.03.14 DEL
					''''        If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
					''''        Else
					''''            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '入金済みの為エラー
					''''            UDNNO_CheckC = -1
					''''            Exit Function
					''''        End If
					''''2007.03.14 DEL
					
					'20090527 DEL START FKS)NAKATA
					'''20090413 ADD START FKS)NAKATA 連絡票№FC09041401
					'''入金消込されている場合、返品不可
					''            If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
					''            Else
					''                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '入金済みの為エラー
					''                UDNNO_CheckC = -1
					''                Exit Function
					''            End If
					'''20090527 DEL E.N.D FKS)NAKATA
					
					'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SSS_LASTKEY.Value = Left(UDNNO, Len(DB_UDNTRA.DATNO) + Len(DB_UDNTRA.LINNO))
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
					WG_DSPKB = 1
					
				End If
			Else
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
				'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNNO_CheckC = -1
			End If
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_ODNTHA, 1, Left(UDNNO, 10), BtrNormal)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DB_GetEq(DBN_ODNTRA, 1, Left(UDNNO, 13), BtrNormal)
				If DBSTAT <> 0 Then
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
					'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					UDNNO_CheckC = -1
				Else
					Call JDNTRA_RClear()
					
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  MAX(DATNO) "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  JDNTRA "
					strSQL = strSQL & "WHERE"
					strSQL = strSQL & "  JDNNO = '" & DB_ODNTRA.JDNNO & "' "
					strSQL = strSQL & "AND"
					strSQL = strSQL & "  LINNO = '" & DB_ODNTRA.JDNLINNO & "' "
					
					Call DB_GetSQL2(DBN_JDNTRA, strSQL)
					
					wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
					
					Call JDNTRA_RClear()
					
					Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_ODNTRA.JDNLINNO, BtrNormal)
					
					If DB_JDNTRA.ZAIKB = "9" Then
						'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '在庫管理なしの為エラー
						'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						UDNNO_CheckC = -1
						Exit Function
					End If
					
					'UPGRADE_WARNING: オブジェクト UDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SSS_LASTKEY.Value = Left(UDNNO, Len(DB_ODNTRA.DATNO) + Len(DB_ODNTRA.LINNO))
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
					WG_DSPKB = 1
				End If
			Else
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
				'UPGRADE_WARNING: オブジェクト UDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				UDNNO_CheckC = -1
			End If
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Function UDNNO_Skip(ByRef PP As clsPP, ByRef CP_UDNDT As clsCP, ByVal SRANO As Object, ByRef CT_UDNNO As System.Windows.Forms.Control) As Object
		
		'UPGRADE_WARNING: オブジェクト SRANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SetFirst = False) And (Trim(SRANO) <> "") Then
			SetFirst = True
			'UPGRADE_WARNING: オブジェクト UDNNO_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNNO_Skip = True
			Call AE_SetFocus(PP, CP_UDNDT.CpPx)
		Else
			'UPGRADE_WARNING: オブジェクト CT_UDNNO.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CT_UDNNO.SelStart = 23
			'UPGRADE_WARNING: オブジェクト UDNNO_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			UDNNO_Skip = False
		End If
	End Function
	
	Function UDNNO_Slist(ByRef PP As clsPP, ByVal UDNNO As Object) As Object
		
		DB_PARA(DBN_UDNTRA).KeyNo = 10
		DB_PARA(DBN_UDNTRA).KeyBuf = "1" & "1"
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		DB_PARA(DBN_ODNTRA).KeyNo = 2
		DB_PARA(DBN_ODNTRA).KeyBuf = "1" & "1"
		'20090115 ADD END   RISE)Tanimura
		WLSUDN.ShowDialog()
		WLSUDN.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト UDNNO_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		UDNNO_Slist = PP.SlistCom
		
	End Function
End Module