Option Strict Off
Option Explicit On
Module SRANO_F51
	'
	' スロット名        : シリアルNo・画面項目スロット
	' ユニット名        : SRANO.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/08
	' 使用プログラム名  : URIET54
	
	'シリアルNoが入力された場合に、そのチェックを行う。
	Function SRANO_CheckC(ByRef SRANO As Object, ByRef PP As clsPP, ByRef CP_SRANO As clsCP, ByVal CX_SOUCD As Object) As Object
		Dim Rtn As Object
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		Dim strSQL As String
		Dim wkDATNO As String
		'20090115 ADD END   RISE)Tanimura
		
		' === 20141216 === INSERT S - FWEST)Koroyasu 連絡票HAN20141010-01
		Dim wkLINNO As String
		' === 20141216 === INSERT E -
		
		'シリアル�ｓo録ワークの削除
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
			Call DB_Delete(DBN_SRAET52)
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SRANO_CheckC = 0
		'UPGRADE_WARNING: オブジェクト SRANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SRANO) = "" Then
			'番号が空白(or 0)に変更された時に, 初期化する場合
			'単なるエラーでよければこの Ifブロックは不要
			SSS_LASTKEY.Value = ""
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
			Exit Function
		End If
		
		'シリアル管理テーブル取得
		Call DB_GetEq(DBN_SRACNTTB, 1, SRANO, BtrNormal)
		If DBSTAT = 0 Then
			'売上情報取得
			Call DB_GetLsEq(DBN_UDNTRA, 11, "1" & "1" & DB_SRACNTTB.RSTDT & DB_SRACNTTB.HINCD & DB_SRACNTTB.SBNNO & "9999999999", BtrNormal)
			If (DBSTAT = 0) And (DB_UDNTRA.DATKB = "1") And (DB_UDNTRA.AKAKROKB = "1") And (DB_UDNTRA.UDNDT = DB_SRACNTTB.RSTDT) And (DB_UDNTRA.HINCD = DB_SRACNTTB.HINCD) And (DB_UDNTRA.SBNNO = DB_SRACNTTB.SBNNO) Then
				
				' === 20141216 === INSERT S - FWEST)Koroyasu 連絡票HAN20141010-01
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  MAX(DATNO) "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  UDNTRA A "
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        MAX(UWRTDT) UWRTDT "
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        UDNTRA"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        DATKB = '1' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        AKAKROKB = '1' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "WHERE"
				strSQL = strSQL & "  A.DATKB = '1' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.AKAKROKB = '1' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UWRTDT = B.UWRTDT "
				strSQL = strSQL & "AND"
				strSQL = strSQL & "  A.UWRTTM = ( SELECT "
				strSQL = strSQL & "                 MAX(UWRTTM) "
				strSQL = strSQL & "               FROM"
				strSQL = strSQL & "                 UDNTRA"
				strSQL = strSQL & "               WHERE"
				strSQL = strSQL & "                 DATKB = '1' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 AKAKROKB = '1' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 UDNNO = '" & DB_UDNTRA.UDNNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 LINNO = '" & DB_UDNTRA.LINNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 HINCD = '" & DB_UDNTRA.HINCD & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 SBNNO = '" & DB_UDNTRA.SBNNO & "' "
				strSQL = strSQL & "               AND"
				strSQL = strSQL & "                 UWRTDT = B.UWRTDT "
				strSQL = strSQL & "             ) "
				
				Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				
				wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
				
				wkLINNO = DB_UDNTRA.LINNO
                '2019/09/19 DEL START
                'Call UDNTRA_RClear()
                '2019/09/19 DEL E N D
                Call DB_GetLsEq(DBN_UDNTRA, 1, wkDATNO & wkLINNO, BtrNormal)
				' === 20141216 === INSERT E -
				
				'2007/03/21 UPD-START
				'            If Trim$(DB_UDNTRA.HENRSNCD) <> "" Then
				'UPGRADE_WARNING: オブジェクト SSSVal(DB_UDNTRA.CASSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(DB_UDNTRA.HENRSNCD) <> "" And SSSVal(DB_UDNTRA.CASSU) = 0 Then
					'2007/03/21 UPD-END
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 6) '既に返品済みの為エラー
					'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SRANO_CheckC = -1
					Exit Function
				End If
				
				If DB_UDNTRA.ZAIKB = "9" Then
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '在庫管理なしの為エラー
					'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SRANO_CheckC = -1
					Exit Function
				End If
				''''2007.03.14 DEL
				''''        If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
				''''        Else
				''''            Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '入金済みの為エラー
				''''            SRANO_CheckC = -1
				''''            Exit Function
				''''        End If
				''''2007.03.14 DEL
				
				''20090527 DEL START FKS)NAKATA
				''20090413 ADD START FKS)NAKATA 連絡票��FC09041401
				''入金消込されている場合、返品不可
				'            If (DB_UDNTRA.JKESIKN = 0) And (DB_UDNTRA.FKESIKN = 0) Then
				'            Else
				'                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2)  '入金済みの為エラー
				'                SRANO_CheckC = -1
				'                Exit Function
				'            End If
				''20090413 ADD E.N.D FKS)NAKATA
				''20090527 DEL E.N.D FKS)NAKATA
				
				'2008/1/22 FKS)ichihara CHG START
				'検収基準の売上の返品を可とする
				''2007/08/23 ADD-START   検収基準の売上は返品不可チェック
				'            Call DB_GetEq(DBN_UDNTHA, 1, DB_UDNTRA.DATNO, BtrNormal)
				'            If DBSTAT = 0 Then
				'                If DB_UDNTHA.URIKJN = "02" Then
				'                    '2007/12/06 FKS)minamoto CHG START
				'                    'Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8)  '検収基準の売上の為エラー
				'                    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_002", 0)  '検収基準の売上の為エラー
				'                    '2007/12/06 FKS)minamoto CHG START
				'                    SRANO_CheckC = -1
				'                    Exit Function
				'                End If
				'            Else
				'                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 1)  '該当売上データなしの為エラー
				'                SRANO_CheckC = -1
				'                Exit Function
				'            End If
				''2007/08/23 ADD-END　   検収基準の売上は返品不可チェック
				'2008/1/22 FKS)ichihara CHG END
				
				'20090115 ADD START RISE)Tanimura '連絡票No.523
				g_strURIKB = "1"
				'20090115 ADD END   RISE)Tanimura
				
				SSS_LASTKEY.Value = DB_UDNTRA.DATNO & DB_UDNTRA.LINNO
				'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
				WG_DSPKB = 1
			Else
				'20090115 ADD START RISE)Tanimura '連絡票No.523
				' 出荷実績取得
				strSQL = ""
				strSQL = strSQL & "SELECT"
				strSQL = strSQL & "  * "
				strSQL = strSQL & "FROM"
				strSQL = strSQL & "  ("
				strSQL = strSQL & "   SELECT"
				strSQL = strSQL & "     A.*"
				strSQL = strSQL & "   FROM"
				strSQL = strSQL & "     ODNTRA A"
				strSQL = strSQL & "   , ("
				strSQL = strSQL & "      SELECT"
				strSQL = strSQL & "        B2.*"
				strSQL = strSQL & "      FROM"
				strSQL = strSQL & "        JDNTHA B1"
				strSQL = strSQL & "      , JDNTRA B2"
				strSQL = strSQL & "      WHERE"
				strSQL = strSQL & "        B1.DATNO = B2.DATNO"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        (B2.DATNO, B2.LINNO) IN ("
				strSQL = strSQL & "                                 SELECT"
				strSQL = strSQL & "                                   MAX(DATNO) DATNO"
				strSQL = strSQL & "                                 , LINNO      LINNO"
				strSQL = strSQL & "                                 FROM"
				strSQL = strSQL & "                                   JDNTRA"
				strSQL = strSQL & "                                 GROUP BY"
				strSQL = strSQL & "                                   JDNNO"
				strSQL = strSQL & "                                 , LINNO"
				strSQL = strSQL & "                                )"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B2.OTPSU > B2.URISU"
				strSQL = strSQL & "      AND"
				strSQL = strSQL & "        B1.URIKJN IN ('02', '04')"
				strSQL = strSQL & "      AND"
				' === 20110305 === UPDATE S TOM)Morimoto 海外システム適用
				'            strSQL = strSQL & "        B1.FRNKB = '0'"
				strSQL = strSQL & "       (B1.FRNKB = '0'"
				strSQL = strSQL & "        OR ("
				strSQL = strSQL & "                  B1.FRNKB   = '1' "
				strSQL = strSQL & "             AND  B1.JDNTRKB = '21'"
				strSQL = strSQL & "           )"
				strSQL = strSQL & "       )"
				' === 20110305 === UPDATE E TOM)Morimoto
				strSQL = strSQL & "     ) B "
				strSQL = strSQL & "   WHERE"
				strSQL = strSQL & "     A.JDNNO = B.JDNNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.JDNLINNO = B.LINNO"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DATKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.DENKB = '1'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.OTPSU > 0"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.SBNNO = '" & DB_SRACNTTB.SBNNO & "'"
				strSQL = strSQL & "   AND"
				strSQL = strSQL & "     A.HINCD = '" & DB_SRACNTTB.HINCD & "'"
				strSQL = strSQL & "  ) "
				
				Call DB_GetSQL2(DBN_ODNTRA, strSQL)
				If (DBSTAT = 0) And (DB_ODNTRA.DATKB = "1") And (DB_ODNTRA.DENKB = "1") And (DB_SRACNTTB.ZAISYOBN = "02") And (DB_ODNTRA.HINCD = DB_SRACNTTB.HINCD) And (DB_ODNTRA.SBNNO = DB_SRACNTTB.SBNNO) Then
                    '2019/09/19 DEL START
                    'Call JDNTRA_RClear()
                    '2019/09/19 DEL E N D
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
                    '2019/09/19 DEL START
                    'Call JDNTRA_RClear()
                    '2019/09/19 DEL E N D
                    Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_ODNTRA.JDNLINNO, BtrNormal)
					
					If DB_JDNTRA.ZAIKB = "9" Then
						'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 0) '在庫管理なしの為エラー
						'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						SRANO_CheckC = -1
						Exit Function
					End If
					
					g_strURIKB = "2"
					
					SSS_LASTKEY.Value = DB_ODNTRA.DATNO & DB_ODNTRA.LINNO
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
					WG_DSPKB = 1
				Else
					'20090115 ADD END   RISE)Tanimura
					'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 1) '該当売上データなしの為エラー
					'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SRANO_CheckC = -1
					Exit Function
					'20090115 ADD START RISE)Tanimura '連絡票No.523
				End If
				'20090115 ADD END   RISE)Tanimura
			End If
		Else
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
			'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SRANO_CheckC = -1
		End If
		
		'UPGRADE_WARNING: オブジェクト SRANO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SRANO_CheckC = 0 Then
			'UPGRADE_WARNING: オブジェクト SRANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			svSRANO = SRANO
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If PP.SlistCom Is System.DBNull.Value Then
				SetFirst = True
			Else
				SetFirst = False
			End If
		End If
		
	End Function
	
	Function SRANO_InitVal(ByVal SRANO As Object, ByRef PP As clsPP, ByRef CP_SRANO As clsCP) As Object
		
		'    SRANO_InitVal = SRANO
		
	End Function
End Module