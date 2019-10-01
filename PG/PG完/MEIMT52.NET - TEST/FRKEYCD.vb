Option Strict Off
Option Explicit On
Module FRKEYCD_F51
	'
	'スロット名      :名称コード・画面項目スロット
	'ユニット名      :FRKEYCD.F51
	'記述者          :Standard Library
	'作成日付        :2006/07/12
	'使用プログラム  :MEIMT51
	'
	
	Function FRKEYCD_InitVal(ByVal FRKEYCD As Object, ByRef PP As clsPP, ByRef CP_FRKEYCD As clsCP) As Object
		Dim Rtn As Short
		Dim I As Short
		'
		'FRKEYCD = DB_MEIMTB.KEYCD
		'
		If DB_MEIMTB.KEYCD = FR_SSSMAIN.HD_FRKEYCD.Text Then
			
			'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FRKEYCD_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRKEYCD_InitVal = FRKEYCD
		End If
		
	End Function
	
	Function FRKEYCD_CheckC(ByVal FRKEYCD As Object, ByVal Ex_FRKEYCD As Object) As Object
		Dim Rtn As Short
		Dim wkKey_set As String
        Dim I As Short
        '20190826 DEL START
        'Call MEIMTA_RClear()
        'Call MEIMTB_RClear()
        '20190826 DEL END

        'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        FRKEYCD_CheckC = 0
		'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(FRKEYCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(FRKEYCD)) = 0 Then
			Call SCR_FromMEIMTB(-1)
			'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			FRKEYCD_CheckC = -1
		Else
			'FRKEYCD = Format(FRKEYCD, "000")
			Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
			If DBSTAT = 0 Then
				If DB_MEIMTA.DATKB = "9" Then
					
					Call Dsp_Prompt("RNOTFOUND", 1) ' 削除済レコードです。
					'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					FRKEYCD_CheckC = 1
				Else
					'DB_MEIMTAへの存在ﾁｪｯｸ
					'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
					Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
					'UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
						'コード1とコード2のデータで存在の有無を絞り込むので
						'既存データが在った場合表示（KEYCDとMEICDAとMEICDBで検索)
						If DB_MEIMTA.DATKB = "9" Then
							Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "削除")
						Else
							Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "更新")
						End If
					Else
						'DB上に指定キーのものが存在しないとき
						Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "追加")
						'Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
						Call Dsp_Prompt("RNOTFOUND", 0) '新規レコードです。
						For I = 0 To PP_SSSMAIN.MaxDspC
							Call SCR_FromMEIMTB(-1)
							Call SCR_FromMfil(I)
							If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
						Next I
					End If
				End If
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				'UPGRADE_WARNING: オブジェクト FRKEYCD_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				FRKEYCD_CheckC = -1
				For I = 0 To PP_SSSMAIN.MaxDspC
					Call SCR_FromMEIMTB(-1)
					Call SCR_FromMfil(I)
					If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
				Next I
			End If
		End If
		
		'    ' 未入力の場合には, エラーをかけずに名称等をクリアする
		'    Call MEIMTA_RClear
		'    'Call FRKEYCD_Move(PP_SSSMAIN.De)　'名称は別部品で呼び出すよう処理済
		'    wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
		'    If LenWid(Trim$(FRKEYCD)) = 0 Then
		'      FRKEYCD_CheckC = -1
		'    Else
		'
		'        FRKEYCD = Format(FRKEYCD, "000")
		'
		'        Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
		'        If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
		'        'コード1とコード2のデータで存在の有無を絞り込むので
		'        '既存データが在った場合表示（KEYCDとMEICDAとMEICDBで検索)
		'              If DB_MEIMTA.DATKB = "9" Then
		'                 Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "削除")
		'              Else
		'                 Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "更新")
		'              End If
		'        Else
		'            'DB上に指定キーのものが存在しないとき
		'            Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "新規")
		'            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
		'        End If
		'    End If
		
	End Function
	'Function FRKEYCD_Check(ByVal FRKEYCD, ByVal Ex_FRKEYCD)
	'Dim Rtn As Integer
	'Dim wkKey_set As String
	'Dim I As Integer
	'    Call MEIMTA_RClear
	'    'Call MEIMTB_RClear
	'    FRKEYCD_Check = 0
	'    If LenWid(Trim$(FRKEYCD)) = 0 Then
	'      Call SCR_FromMEIMTB(-1)
	'      FRKEYCD_Check = -1
	'    Else
	'      'FRKEYCD = Format(FRKEYCD, "000")
	'      Call DB_GetEq(DBN_MEIMTB, 1, FRKEYCD, BtrNormal)
	'        If DBSTAT = 0 Then
	'            If DB_MEIMTA.DATKB = "9" Then
	'               Call Dsp_Prompt("RNOTFOUND", 1)         ' 削除済レコードです。
	'               FRKEYCD_Check = 1
	'            Else
	'               'DB_MEIMTAへの存在ﾁｪｯｸ
	'                wkKey_set = FRKEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB
	'                Call DB_GetEq(DBN_MEIMTA, 1, wkKey_set, BtrNormal)
	'                If DBSTAT = 0 And DB_MEIMTA.KEYCD = FRKEYCD Then
	'                'コード1とコード2のデータで存在の有無を絞り込むので
	'                '既存データが在った場合表示（KEYCDとMEICDAとMEICDBで検索)
	'                      If DB_MEIMTA.DATKB = "9" Then
	'                         Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "削除")
	'                      Else
	'                         Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "更新")
	'                      End If
	'                Else
	'                    'DB上に指定キーのものが存在しないとき
	'                    Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "新規")
	'                    Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 該当レコードはありません。
	'
	'                    For I = 0 To PP_SSSMAIN.MaxDspC
	'                       Call SCR_FromMEIMTB(-1)
	'                       Call SCR_FromMfil(I)
	'                       If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
	'                    Next I
	'                End If
	'            End If
	'        Else
	'            Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0) ' 新規レコードです。
	'            FRKEYCD_Check = -1
	'            For I = 0 To PP_SSSMAIN.MaxDspC
	'            Call SCR_FromMEIMTB(-1)
	'            Call SCR_FromMfil(I)
	'            If I <> 0 Then Call DP_SSSMAIN_UPDKB(I, " ")
	'            Next I
	'        End If
	'    End If
	'End Function
	
	Function FRKEYCD_Slist(ByRef PP As clsPP, ByVal FRKEYCD As Object) As Object
		'Dim strcd As String
		'    WLS_LIST.Caption = "名称一覧"
		'    WLS_LIST!LST.Clear
		'    '
		'    WLS_LIST!LST.AddItem "001" & " " & "通貨 "
		'    WLS_LIST!LST.AddItem "002" & " " & "便名 "
		'    WLS_LIST!LST.AddItem "003" & " " & "業種 "
		'    WLS_LIST!LST.AddItem "004" & " " & "地域 "
		'    WLS_LIST!LST.AddItem "005" & " " & "売上基準 "
		'    WLS_LIST!LST.AddItem "006" & " " & "受注取引区分 "
		'    WLS_LIST!LST.AddItem "007" & " " & "発注取引区分 "
		'    WLS_LIST!LST.AddItem "008" & " " & "単価種別 "
		'    WLS_LIST!LST.AddItem "009" & " " & "返品理由 "
		'    WLS_LIST!LST.AddItem "010" & " " & "返品状態 "
		'    WLS_LIST!LST.AddItem "011" & " " & "調整理由 "
		'    WLS_LIST!LST.AddItem "012" & " " & "見積書印字支払方法 "
		'    WLS_LIST!LST.AddItem "013" & " " & "有効期限 "
		'    WLS_LIST!LST.AddItem "014" & " " & "仕向地 "
		'    WLS_LIST!LST.AddItem "015" & " " & "場所 "
		'    WLS_LIST!LST.AddItem "016" & " " & "受注理由 "
		'    WLS_LIST!LST.AddItem "017" & " " & "受注ｷｬﾝｾﾙ理由 "
		'    WLS_LIST!LST.AddItem "018" & " " & "再生原因 "
		'    WLS_LIST!LST.AddItem "019" & " " & "製番区分 "
		'    WLS_LIST!LST.AddItem "020" & " " & "コンピュータ型式 "
		'    WLS_LIST!LST.AddItem "021" & " " & "会計事業所 "
		'    WLS_LIST!LST.AddItem "022" & " " & "会計区分 "
		'    WLS_LIST!LST.AddItem "023" & " " & "会計部門 "
		'    WLS_LIST!LST.AddItem "024" & " " & "発注担当 "
		'    WLS_LIST!LST.AddItem "025" & " " & "生産担当 "
		'    WLS_LIST!LST.AddItem "026" & " " & "倉庫区分 "
		'    WLS_LIST!LST.AddItem "027" & " " & "引当対象区分 "
		'    WLS_LIST!LST.AddItem "028" & " " & "商品種別 "
		'    WLS_LIST!LST.AddItem "029" & " " & "祝日区分 "
		'    WLS_LIST!LST.AddItem "030" & " " & "営業日区分 "
		'    WLS_LIST!LST.AddItem "031" & " " & "保守終了区分 "
		'    WLS_LIST!LST.AddItem "032" & " " & "出荷停止区分 "
		'    WLS_LIST!LST.AddItem "033" & " " & "生産終了区分 "
		'    WLS_LIST!LST.AddItem "034" & " " & "販売完了区分 "
		'    WLS_LIST!LST.AddItem "035" & " " & "受注停止区分 "
		'    WLS_LIST!LST.AddItem "036" & " " & "出荷区分 "
		'
		'    '
		'    'FRKEYCD = Format(FRKEYCD, "000")
		'    'SSS_WLSLIST_KETA = LenWid(FRKEYCD)
		'    SSS_WLSLIST_KETA = 3
		'    WLS_LIST.Show 1
		'    Unload WLS_LIST
		'    FRKEYCD_Slist = PP.SlistCom
		
		WLS_MEI2.Text = "名称キー検索"
		CType(WLS_MEI2.Controls("LST"), Object).Items.Clear()

        '20190827 CHG START
        'DB_PARA(DBN_MEIMTB).KeyNo = 1
        ''UPGRADE_WARNING: オブジェクト FRKEYCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'DB_PARA(DBN_MEIMTB).KeyBuf = FRKEYCD
        PP.SlistCom = System.DBNull.Value
        '20190827 CHG END

        WLS_MEI2.ShowDialog()
		WLS_MEI2.Close()
		'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FRKEYCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		FRKEYCD_Slist = PP.SlistCom
		
		'    WLS_MEI2.Caption = "名称キー検索"
		'    WLS_MEI2!LST.Clear
		'    Call DB_GetFirst(DBN_MEIMTB, 1, BtrNormal)
		'    Do While DBSTAT = 0
		'        If DB_MEIMTA.DATKB <> "9" Then WLS_MEI2!LST.AddItem DB_MEIMTB.KEYCD & " " & Left(Trim(DB_MEIMTB.MEIKMKNM), 20)
		'        Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		'    Loop
		'    SSS_WLSLIST_KETA = CInt(LenWid(DB_MEIMTB.KEYCD))
		'    WLS_MEI2.Show 1
		'    Unload WLS_MEI2
		'    FRKEYCD_Slist = PP.SlistCom
		'
		
	End Function
	Sub FRKEYCD_Move(ByVal DE_INDEX As Object)
		'
		If Trim(DB_MEIMTA.KEYCD) = "" Then
		Else
			Call DP_SSSMAIN_FRKEYCD(PP_SSSMAIN.De, DB_MEIMTA.KEYCD)
			Call DP_SSSMAIN_MEIKMKNM(PP_SSSMAIN.De, DB_MEIMTA.MEIKMKNM)
		End If
	End Sub
End Module