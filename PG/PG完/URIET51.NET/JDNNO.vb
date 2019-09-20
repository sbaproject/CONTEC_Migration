Option Strict Off
Option Explicit On
Module JDNNO_F61
	'
	' スロット名        : 受注伝票番号・画面項目スロット
	' ユニット名        : JDNNO.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	
	'伝票Noが入力された場合に、そのチェックを行う。
	Function JDNNO_CheckC(ByRef JDNNO As Object, ByRef PP As clsPP, ByRef CP_JDNNO As clsCP, ByVal FRNKB As Object, ByVal JDNTRKB As Object, ByVal URIKJN As Object) As Object
		Dim Rtn As Object
		Dim rResult As Short ' 処理チェック関数戻り値
		Dim rCHECK_HIKSU As Object
		Dim rCHECK_FRDSU As Short
		Dim wkJDNTRKB As String
		Dim rCHECK_URISU As Short
		Dim wkJDNNO As String
		
		Dim strSQL As String
		
		'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNNO_CheckC = 0
		
		' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130416 === INSERT E -
		
		'    If SSSVal(JDNNO) = 0 Then
		'UPGRADE_WARNING: オブジェクト JDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(JDNNO) = "" Then
			
			'番号が空白(or 0)に変更された時に, 初期化する場合
			'単なるエラーでよければこの Ifブロックは不要
			SSS_LASTKEY.Value = ""
			WG_DSPKB = 2
			'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行
			Exit Function
		End If
		
		'Call DB_GetEq(DBN_JDNTHA, 2, "1" & "1" & JDNNO, BtrNormal)
		'UPGRADE_WARNING: オブジェクト JDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/29 CHG START
        'wkJDNNO = Left(JDNNO, 6) & Space(Len(DB_JDNTHA.JDNNO) - 6)
        If DB_JDNTHA.JDNNO Is Nothing OrElse Len(DB_JDNTHA.JDNNO) <= 6 Then
            wkJDNNO = Left(JDNNO, 6)
        Else
            wkJDNNO = Left(JDNNO, 6) & Space(Len(DB_JDNTHA.JDNNO) - 6)
        End If
        '2019/03/29 CHG E N D
		
		strSQL = ""
		strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTHA"
        strSQL = strSQL & " WHERE JDNNO = '" & wkJDNNO & "'"
        '2019/03/29 CHG START
        'Call DB_GetSQL2(DBN_JDNTHA, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/03/29 CHG E N D
        '2019/03/29 CHG START
        'WG_JDNDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
        WG_JDNDATNO = VB6.Format(dt.Rows(0)("MAX(DATNO)"), "0000000000")
        '2019/03/29 CHG E N D
        '2019/03/29 CHG START
        'Call DB_GetEq(DBN_JDNTHA, 1, WG_JDNDATNO, BtrNormal)
        'Call JDNTHA_GetFirstRecByDATNO(WG_JDNDATNO)
        Dim sqlWhereStr As String = ""
        sqlWhereStr = " WHERE DATNO = '" & WG_JDNDATNO & "'"
        Call GetRowsCommon("JDNTHA", sqlWhereStr)
        '2019/03/29 CHG E N D

        '2006/10/12 [DEL-START] ZKTKB = "2"（直送）のチェック無効にする（納品書は出力する為）
        ''''If DBSTAT = 0 And DB_JDNTHA.ZKTKB <> "2" Then
        'If DBSTAT = 0 Then 
        If (DBSTAT = 0) And (DB_JDNTHA.DATKB = "1") And (DB_JDNTHA.DENKB = "1") And (DB_JDNTHA.AKAKROKB = "1") Then 

            ' 受注取引区分（名称３で対象チェック）
            '2019/03/29 CHG START
            'wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
            If DB_MEIMTA.MEICDA Is Nothing Then
                wkJDNTRKB = DB_JDNTHA.JDNTRKB
            Else
                wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
            End If
            '2019/03/29 CHG E N D
            '20190709 DEL START
            'Call MEIMTA_RClear()
            '20190709 DEL END

            '2019/03/29 CHG START
            'Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
            'Call MEIMTA_GetFirstRecByKEYCDAndMEICDA("006", wkJDNTRKB)
            sqlWhereStr = "WHERE KEYCD = '006' AND MEICDA = '" & wkJDNTRKB & "'"
            Call GetRowsCommon("MEIMTA", sqlWhereStr)

            '2019/03/29 CHG E N D
            '2017/04/03 CHG START CIS <課金システム対応>
            '        If Left(DB_MEIMTA.MEINMC, 2) <> "02" Then
            'UPGRADE_WARNING: オブジェクト JDNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Left(DB_MEIMTA.MEINMC, 2) <> "02" And Left(JDNNO, 2) <> "RU" Then
                '2017/04/03 CHG E N D CIS <課金システム対応>
                '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '該当レコード無し
                'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 0) '処理対象外の受注取引区分の為、エラー。
                'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                JDNNO_CheckC = -1
            Else
                '2019/03/29 CHG START
                'Call DB_GetGrEq(DBN_JDNTRA, 1, DB_JDNTHA.DATNO, BtrNormal)
                strSQL = ""
                strSQL &= " SELECT * "
                strSQL &= " FROM JDNTRA "
                strSQL &= " WHERE DATNO = '" & CF_Ora_Sgl(DB_JDNTHA.DATNO) & "' "
 
                Dim dtJDNTRA As DataTable = DB_GetTable(strSQL)
                '2019/03/29 CHG E N D

                '2019/03/29 CHG START
                'If (DBSTAT <> 0) Or (DB_JDNTRA.DATNO <> DB_JDNTHA.DATNO) Then
                If (dtJDNTRA Is Nothing OrElse dt.Rows.Count <= 0) Or (dtJDNTRA.Rows(0)("DATNO") <> DB_JDNTHA.DATNO) Then
                    '2019/03/29 CHG E N D
                    'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
                    'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    JDNNO_CheckC = -1
                Else
                    rCHECK_URISU = 0
                    '2019/03/29 CHG START
                    'Do While (DBSTAT = 0) And (DB_JDNTRA.DATNO = DB_JDNTHA.DATNO) And (rCHECK_URISU = 0)
                    '    If DB_JDNTRA.UODSU <> DB_JDNTRA.URISU Then
                    '        rCHECK_URISU = 1
                    '    End If
                    '    Call DB_GetNext(DBN_JDNTRA, BtrNormal)
                    'Loop
                    For Each row As DataRow In dtJDNTRA.Rows
                        If DB_NullReplace(row("UODSU"), 0) <> DB_NullReplace(row("URISU"), 0) Then
                            rCHECK_URISU = 1
                            Exit For
                        End If
                    Next
                    '2019/03/29 CHG E N D
                    If rCHECK_URISU = 0 Then
                        'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET51", 1) '既に売上済みの為、エラー。
                        'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        JDNNO_CheckC = -1
                        Exit Function
                    End If

                    ' === 20130416 === INSERT S - FWEST)Koroyasu 排他制御の追加
                    '排他チェック
                    ' === 20130530 === UPDATE S - FWEST)Koroyasu
                    '                rResult = SSSWIN_EXCTBZ_CHECK2
                    rResult = SSSWIN_EXCTBZ_CHECK2(JDNNO)
                    ' === 20130530 === UPDATE E
                    Select Case rResult
                        '正常
                        Case 0

                            '排他処理中
                        Case 1
                            'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Rtn = DSP_MsgBox(SSS_ERROR, "_EXCADD", 0) '他のプログラムで更新中のため、登録できません。
                            'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            JDNNO_CheckC = -1
                            Exit Function

                            '異常終了
                        Case 9
                            'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Rtn = DSP_MsgBox(SSS_ERROR, "URKET51_004 ", 0) '更新異常
                            'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            JDNNO_CheckC = -1
                            Exit Function

                    End Select
                    ' === 20130416 === INSERT E -

                    SSS_LASTKEY.Value = DB_JDNTHA.DATNO
                    WG_DSPKB = 2
                    'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Rtn = AE_ChOprtLater(PP, 15) '表示後追加モードに移行

                    '            ' 更新パターンのチェック・エラーチェックを行う
                    '            rResult = checkUpdatePattern(DB_JDNTHA.FRNKB, DB_JDNTHA.JDNTRKB, DB_JDNTHA.URIKJN, FR_SSSMAIN.CHECK_EMGODNKB.Value, " ")
                    '            If rResult = -1 Or rResult > 900 Then
                    '                'エラー伝票呼び出し、または存在しない明細あり
                    '                'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '指定した伝票は呼び出しできません。
                    '                MsgBox "指定した伝票は呼び出しできません。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                    '                JDNNO_CheckC = -1
                    '            End If

                    ' 全伝票明細の手動引当数がゼロかどうかをチェックする
                    '            rCHECK_HIKSU = check_HIKSU(SSS_LASTKEY)
                    '            If rCHECK_HIKSU = 0 Then
                    'すべての明細の手動引当数がゼロ
                    'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '引当未処理です。手動引当登録により引当処理を行ってください。
                    '                MsgBox "引当未処理です。手動引当登録により引当処理を行ってください。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm)
                    '            End If

                    '
                    rCHECK_FRDSU = check_FRDSU(SSS_LASTKEY.Value)
                    If rCHECK_FRDSU = 0 Then
                        'すべての明細の出荷指示数がゼロではない
                        'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '出荷指示取消未処理です。出荷指示取消を行ってください。
                        MsgBox("出荷指示取消未処理です。出荷指示取消を行ってください。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
                    End If
                End If

            End If
        Else
            'UPGRADE_WARNING: オブジェクト Rtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) '該当レコード無し
            'UPGRADE_WARNING: オブジェクト JDNNO_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            JDNNO_CheckC = -1
        End If
        '2006/10/12 [DEL-E N D] ZKTJB = "2"（直送）のチェック無効にする（納品書は出力する為）

        from_JDNNO_Unit = True


        '    Call DB_GetEq(DBN_JDNTHA, 2, "1" & "1" & JDNNO, BtrNormal)
        '    If DBSTAT = 0 And DB_JDNTHA.ZKTKB <> "2" Then
        '        If SSSVal(DB_JDNTHA.JDNENDKB) = 8 Then
        '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 2) '引当済み（完了）
        '            JDNNO_CheckC = -1
        '        ElseIf SSSVal(DB_JDNTHA.JDNENDKB) = 6 Then
        '            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 5) '未承認
        '            JDNNO_CheckC = -1
        '        Else
        '            Call DB_GetGrEq(DBN_JDNTRA, 1, DB_JDNTHA.DATNO, BtrNormal)
        '            If (DBSTAT <> 0) Or (DB_JDNTRA.DATNO <> DB_JDNTHA.DATNO) Then
        '                Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '該当レコード無し
        '                JDNNO_CheckC = -1
        '            Else
        '                SSS_LASTKEY = DB_JDNTHA.DATNO
        '                WG_DSPKB = 2
        '                Rtn = AE_ChOprtLater(PP, 15)    '表示後追加モードに移行
        '            End If
        '        End If
        '    Else
        '        Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)   '該当レコード無し
        '        JDNNO_CheckC = -1
        '    End If
    End Function
	
	Function JDNNO_Slist(ByRef PP As clsPP, ByVal JDNNO As Object) As Object

        '20190730 CHG START
        'DB_PARA(DBN_JDNTHA).KeyNo = 6
        'DB_PARA(DBN_JDNTHA).KeyBuf = "1" & "0"
        WLSJDN1.JDN1_PARA1 = "1" & "0"
        '20190730 CHG END

        '2019/03/25 CHG START
        'WLSJDN.ShowDialog()
        'WLSJDN.Close()
        WLSJDN1.ShowDialog()
        WLSJDN1.Close()
        '2019/03/25 CHG E N D
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト JDNNO_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNNO_Slist = PP.SlistCom
	End Function
	
	
	'更新パターンのチェック・エラーチェックを行う
	Function checkUpdatePattern(ByRef putFRNKB As String, ByRef putJDNTRB As String, ByRef putURIKJN As String, ByRef putEMGODNKB As Short, ByRef putZAIKB As String) As Short
		'引数    ：putFRNKB as String （海外取引区分）
		'引数    ：putJDNTRB as String （受注取引区分）
		'引数    ：putURIKJN as String （売上基準）
		'引数    ：putEMGODNKB as String （緊急出荷チェック 1:緊急出荷 9:それ以外）
		'引数    ：putZAIKB as String （在庫管理区分）
		'戻り値　：更新可（関数定義書　表 1 1　処理一覧を参照 ※関数下部に転記）
		'        ：それ以外エラー（関数定義書　表 1 2　 エラー番号一覧を参照　※関数下部に転記）
		'
		
		Dim pFRNKB As String
		Dim pJDNTRKB As String
		Dim pURIKJN As String
		Dim pEMGODNKB As Short
		Dim pZAIKB As String
		
		pFRNKB = Trim(putFRNKB)
		pJDNTRKB = Trim(putJDNTRB)
		pURIKJN = Trim(putURIKJN)
		pEMGODNKB = putEMGODNKB
		pZAIKB = Trim(putZAIKB)
		
		checkUpdatePattern = 0
		
		
		If pFRNKB = "" Then
			checkUpdatePattern = 0
			Exit Function
		End If
		
		' 海外
		If pFRNKB = "1" Then
			checkUpdatePattern = 901
			Exit Function
		End If
		
		' 国内
		If pFRNKB = "0" Then
			If pJDNTRKB = "" Then Exit Function
			
			checkUpdatePattern = 0
			
			'        ' 単品
			'        If pJDNTRKB = "01" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' 出荷基準
			'            If pURIKJN = "1" Then
			'
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 902
			'                    Exit Function
			'                End If
			'
			'            ' 出荷基準以外
			'            Else
			'                checkUpdatePattern = -1
			'                Exit Function
			'            End If
			'
			'        ' セットアップ
			'        ElseIf pJDNTRKB = "21" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' 出荷基準
			'            If pURIKJN = "1" Then
			'
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 903
			'                    Exit Function
			'                End If
			'
			'            ' 出荷基準以外
			'            Else
			'                checkUpdatePattern = -1
			'                Exit Function
			'            End If
			'
			'        ' システム
			'        ElseIf pJDNTRKB = "31" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' 出荷基準
			'            If pURIKJN = "1" Then
			'
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 2
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    checkUpdatePattern = 904
			'                    Exit Function
			'                End If
			'
			'            ' 出荷基準以外
			'            Else
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 905
			'                    Exit Function
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' 修理
			'        ElseIf pJDNTRKB = "41" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' 出荷基準
			'            If pURIKJN = "1" Then
			'                checkUpdatePattern = -1
			'                Exit Function
			'
			'            ' 出荷基準以外
			'            Else
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 906
			'                    Exit Function
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = 1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' 保守
			'        ElseIf pJDNTRKB = "51" Then
			'            checkUpdatePattern = 907
			'            Exit Function
			'
			'        ' 貸出
			'        ElseIf pJDNTRKB = "61" Then
			'            If pURIKJN = "" Then Exit Function
			'
			'            ' 出荷基準
			'            If pURIKJN = "1" Then
			'
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 908
			'                    Exit Function
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 3
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'                End If
			'
			'            ' 出荷基準以外
			'            Else
			'                ' 緊急出荷チェックあり
			'                If pEMGODNKB = 1 Then
			'                    checkUpdatePattern = 909
			'
			'                ' 緊急出荷チェックなし
			'                ElseIf pEMGODNKB = 0 Then
			'                    If pZAIKB = "" Then Exit Function
			'
			'                    ' 在庫管理対象
			'                    If pZAIKB = "1" Then
			'                        checkUpdatePattern = 3
			'                        Exit Function
			'
			'                    ' 在庫管理対象外
			'                    ElseIf pZAIKB = "9" Then
			'                        checkUpdatePattern = -1
			'                        Exit Function
			'                    End If
			'                End If
			'            End If
			'
			'        ' その他
			'        ElseIf pJDNTRKB = "99" Then
			'            checkUpdatePattern = 910
			'            Exit Function
			'        End If
			
		End If
		
		'表 1 1　処理一覧
		'番号   ※１    ※２            ※３            ※４    ※５
		'2      国内    単品            出荷基準        あり    対処
		'2      国内    セットアップ    出荷基準        あり    対象
		'1      国内    セットアップ    出荷基準        あり    非対象
		'2      国内    システム        出荷基準        あり    対象
		'1      国内    システム        出荷基準        あり    非対称
		'1      国内    システム        出荷基準以外    なし    非対称
		'1      国内    修理            出荷基準以外    なし    非対称
		'3      国内    貸出            出荷基準        なし    対称
		'3      国内    貸出            出荷基準以外    なし    対称
		'0      エラー以外で､上記の処理に該当しない引数引数の場合 (未確定)
		'
		'表 1 2　 エラー番号一覧
		'番号   ※１    ※２            ※３            ※４    ※５
		'901    海外
		'-1     国内    単品            出荷基準以外
		'902    国内    単品            出荷基準        なし
		'-1     国内    単品            出荷基準        あり    非対称
		'-1     国内    セットアップ    出荷基準以外
		'903    国内    セットアップ    出荷基準        なし
		'904    国内    システム        出荷基準        なし
		'905    国内    システム        出荷基準以外    あり
		'-1     国内    システム        出荷基準以外    なし    対象
		'-1     国内    修理            出荷基準
		'906    国内    修理            出荷基準以外    あり
		'-1     国内    修理            出荷基準以外    なし    対象
		'907    国内    保守
		'908    国内    貸出            出荷基準        あり
		'-1     国内    貸出            出荷基準        なし    非対称
		'909    国内    貸出            出荷基準以外    あり
		'-1     国内    貸出            出荷基準以外    なし    非対称
		'910    国内    その他
		'
		'※1:  海外取引区分
		'※2:  受注取引区分
		'※3:  売上基準
		'※4:  緊急出荷チェック
		'※5:  在庫管理区分
		'
		'注1:  番号1⇒売上情報のみ登録
		'      番号2⇒出荷指示を作成
		'      番号3⇒倉庫マスタを更新
		'注２：エラー番号 = -1は、存在しないデータ（例外エラー）
		'注３：エラー番号 > 900は、該当する情報を選択した時、エラーメッセージを表示する
		
	End Function
End Module