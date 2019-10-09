Option Strict Off
Option Explicit On
Module FIXMT51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : FIXMT51.E01
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/10
	' 使用プログラム名  : FIXMT51
	'
	Public WG_UNYDT As String '運用日
	Function DSPMST() As Short
		Dim I As Short
		Dim wkTOKCD As String
		'
		I = 0
		Call FIXMTA_RClear()
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		Call DB_GetGrEq(DBN_FIXMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		
		' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
		''2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'    ReDim M_MOTO_A_inf(14)
		''2007/12/18 add-end T.KAWAMUKAI
		ReDim M_FIXMT_A_inf(14)
		' === 20081002 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				If DB_FIXMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "削除")
				Else
					Call DP_SSSMAIN_UPDKB(I, "更新")
				End If
				
				I = I + 1
				Call DB_GetNext(DBN_FIXMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_FIXMTA.CTLCD
		Else
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSS_LASTKEY.Value = HighValue(LenWid(DB_FIXMTA.CTLCD))
		End If
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			' CL_SSSMAIN(2 + (lngI * 9)) = 1
			' CL_SSSMAIN(4 + (lngI * 9)) = 1
			' CL_SSSMAIN(6 + (lngI * 9)) = 1
			CL_SSSMAIN(2 + (lngI * 5)) = 1
		Next

        '運用日取得
        '2019/10/07 CHG START
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '2019/10/07 CHG E N D
        If DBSTAT = 0 Then
			WG_UNYDT = DB_UNYMTA.UNYDT
		Else
			WG_UNYDT = ""
		End If
		'---権限取得---
		Dim wkDATE As String
		Dim wkCRW As System.Windows.Forms.Control
		wkDATE = VB6.Format(Now, "YYYYMMDD")
		gs_userid = Left(SSS_OPEID.Value, 6) 'ユーザID
		gs_pgid = "FIXMT51" 'プログラムID
		
		If CDbl(Get_Authority(wkDATE, wkCRW)) = 9 Then
			Call MsgBox("実行権限がありません。", MsgBoxStyle.OKOnly)
			End
		End If
	End Sub
	
	Function MFIL_RelCheck(ByVal CTLCD As Object, ByVal De_Index As Object) As Object
		'
		'UPGRADE_WARNING: オブジェクト MFIL_RelCheck の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		MFIL_RelCheck = 0
		Call FIXMTA_RClear()
		
		'UPGRADE_WARNING: オブジェクト CTLCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CTLCD) = "" Then
			Exit Function
		Else
			
			Call DB_GetEq(DBN_FIXMTA, 1, CTLCD, BtrNormal)
			
			If DBSTAT = 0 Then
				If DB_FIXMTA.DATKB = "9" Then
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "削除")
				Else
					'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call DP_SSSMAIN_UPDKB(De_Index, "更新")
				End If
			Else
				'UPGRADE_WARNING: オブジェクト De_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call DP_SSSMAIN_UPDKB(De_Index, "新規")
			End If
			
		End If
	End Function
	
	Function MST_NEXT() As Short
		Dim Rtn As Short
		'
		Call DB_GetGrEq(DBN_FIXMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Object
		Dim I As Short
		'
		I = SET_GAMEN_KEY()
		I = 0
		Call DB_GetLs(DBN_FIXMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_FIXMTA, BtrNormal)
		Loop
        If DBSTAT <> 0 And I = 0 Then
            Call DB_GetFirst(DBN_FIXMTA, 1, BtrNormal)
        End If
        '2019/10/08 CHG START
        'SSS_LASTKEY.Value = DB_PARA(DBN_FIXMTA).KeyBuf
        SSS_LASTKEY.Value = DB_PARA(4).KeyBuf
        '2019/10/08 CHG E N D
        Call SCR_FromMfil(I)
		I = DSPMST()
		'UPGRADE_WARNING: オブジェクト MST_PREV の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(0)
		
		SSS_LASTKEY.Value = DB_FIXMTA.CTLCD
		
		SET_GAMEN_KEY = 4
	End Function
End Module