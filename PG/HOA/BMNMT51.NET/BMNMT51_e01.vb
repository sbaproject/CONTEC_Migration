Option Strict Off
Option Explicit On
Module BMNMT51_E01
	Public wk_SRTNKEY As New VB6.FixedLengthString(128) '検索画面リターンKEY
	Public Len506 As Short
	Public Len508 As Short
	Public Len509 As Short
	Public Len507 As Short
	Public Len511 As Short
	
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : BMNMT51.E01
	' 記述者            : Standard Library
	' 作成日付          : 1997/08/04
	' 使用プログラム名  : BMNMT51
	'
	Function DSPMST() As Short
		Dim I As Short
		Dim svBMNCD As String
		Dim svENDTKDT As String
		Dim strSQL As String
		Dim strKEY As String
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		''''Call DB_GetGrEq(DBN_BMNMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
		
		Call DB_GetSQL2(DBN_BMNMTA, strSQL)
		
		' === 20080929 === UPDATE S - RISE)Izumi チェック項目追加
		'2007/12/17 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		'    ReDim M_MOTO_A_inf(4)
		'2007/12/17 add-end M.SUEZAWA
		ReDim M_BMNMT_A_inf(4)
		' === 20080929 === UPDATE E - RISE)Izumi
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_BMNMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_ENDTKD(I, DB_BMNMTA.ENDTKDT) '2006.11.07
				Call DP_SSSMAIN_V_BMNNM(I, DB_BMNMTA.BMNNM) '2006.11.07
				Call DP_SSSMAIN_V_BMNZP(I, DB_BMNMTA.BMNZP) '2006.11.07
				Call DP_SSSMAIN_V_BMNADA(I, DB_BMNMTA.BMNADA) '2006.11.07
				Call DP_SSSMAIN_V_BMNADB(I, DB_BMNMTA.BMNADB) '2006.11.07
				Call DP_SSSMAIN_V_BMNADC(I, DB_BMNMTA.BMNADC) '2006.11.07
				Call DP_SSSMAIN_V_BMNTL(I, DB_BMNMTA.BMNTL) '2006.11.07
				Call DP_SSSMAIN_V_BMNFX(I, DB_BMNMTA.BMNFX) '2006.11.07
				Call DP_SSSMAIN_V_BMNURL(I, DB_BMNMTA.BMNURL) '2006.11.07
				Call DP_SSSMAIN_V_BMNCDU(I, DB_BMNMTA.BMNCDUP) '2006.11.07
				Call DP_SSSMAIN_V_ZMJGYC(I, DB_BMNMTA.ZMJGYCD) '2006.11.07
				Call DP_SSSMAIN_V_ZMCD(I, DB_BMNMTA.ZMCD) '2006.11.07
				Call DP_SSSMAIN_V_ZMBMNC(I, DB_BMNMTA.ZMBMNCD) '2006.11.07
				Call DP_SSSMAIN_V_EIGYOC(I, DB_BMNMTA.EIGYOCD) '2006.11.07
				Call DP_SSSMAIN_V_TIKKB(I, DB_BMNMTA.TIKKB) '2006.11.07
				Call DP_SSSMAIN_V_HTANCD(I, DB_BMNMTA.HTANCD) '2006.11.07
				Call DP_SSSMAIN_V_STANCD(I, DB_BMNMTA.STANCD) '2006.11.07
				Call DP_SSSMAIN_V_BMNPRN(I, DB_BMNMTA.BMNPRNM) '2006.11.07
				svBMNCD = DB_BMNMTA.BMNCD
				svENDTKDT = DB_BMNMTA.WRTFSTDT
				If DB_BMNMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "削除")
				Else
					Call DP_SSSMAIN_UPDKB(I, "更新")
				End If
				Call DB_GetGrEq(DBN_BMNMTA, 1, DB_BMNMTA.BMNCDUP & "        ", BtrNormal)
				'''' UPD 2009/08/25  FKS) T.Yamamoto    Start    連絡票№:FC09082501
				'            If (DBSTAT = 0) And (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) Then
				'                Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
				'            Else
				'                Call DP_SSSMAIN_BMNNMUP(I, "")
				'            End If
				Call DP_SSSMAIN_BMNNMUP(I, "")
				Do While (DBSTAT = 0)
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTKDT(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCDUP(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If (DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCDUP(I)) And (DB_BMNMTA.STTTKDT <= RD_SSSMAIN_STTTKDT(I)) And (DB_BMNMTA.ENDTKDT >= RD_SSSMAIN_ENDTKDT(I)) Then
						Call DP_SSSMAIN_BMNNMUP(I, DB_BMNMTA.BMNNM)
						Exit Do
					End If
					Call DB_GetNext(DBN_BMNMTA, BtrNormal)
				Loop 
				'''' UPD 2009/08/25  FKS) T.Yamamoto    End
				I = I + 1
				
				''''''''''''Call DB_GetGrEq(DBN_BMNMTA, 1, svBMNCD, BtrNormal)
				strKEY = svBMNCD & svENDTKDT
				strSQL = ""
				strSQL = strSQL & "SELECT *"
				strSQL = strSQL & "  FROM   ("
				strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
				strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
				strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
				strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
				strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
				strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
				strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
				strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
				strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
				strSQL = strSQL & "                    BMN.PGID "
				strSQL = strSQL & "             From BMNMTA BMN"
				strSQL = strSQL & "             ) TBL"
				strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(strKEY) & "'"
				strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
				Call DB_GetSQL2(DBN_BMNMTA, strSQL)
				
				Call DB_GetNext(DBN_BMNMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.WRTFSTDT
		Else
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSS_LASTKEY.Value = HighValue(LenWid(DB_BMNMTA.BMNCD)) & HighValue(LenWid(DB_BMNMTA.WRTFSTDT))
		End If
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim wkCRW As System.Windows.Forms.Control
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			''''    CL_SSSMAIN(2 + (lngI * 23)) = 1             '2006.11.07
			''''    CL_SSSMAIN(23 + (lngI * 23)) = 1            '2006.11.07
			''''    CL_SSSMAIN(24 + (lngI * 23)) = 1            '2006.11.07
			CL_SSSMAIN(2 + (lngI * 42)) = 1
			CL_SSSMAIN(23 + (lngI * 42)) = 1
			CL_SSSMAIN(24 + (lngI * 42)) = 1
		Next 
		
		'運用日取得
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		'実行権限チェック
		gs_userid = Left(SSS_OPEID.Value, 6) 'ユーザID
		gs_pgid = SSS_PrgId 'プログラムID
		If CDbl(Get_Authority(DB_UNYMTA.UNYDT, wkCRW)) = 9 Then
			Call MsgBox("実行権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			End
		End If
		
		'マスタ値取得（固定値マスタ）
		Call DB_GetEq(DBN_FIXMTA, 1, "506", BtrNormal) '14
		If DBSTAT = 0 Then Len506 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal) '2
		If DBSTAT = 0 Then Len507 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "508", BtrNormal) '8
		If DBSTAT = 0 Then Len508 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "509", BtrNormal) '4
		If DBSTAT = 0 Then Len509 = CShort(DB_FIXMTA.FIXVAL)
		
		Call DB_GetEq(DBN_FIXMTA, 1, "511", BtrNormal) '4
		If DBSTAT = 0 Then Len511 = CShort(DB_FIXMTA.FIXVAL)
		
	End Sub
	
	Function MST_NEXT() As Short
		Dim rtn As Short
		Dim strSQL As String
		'
		''''Call DB_GetGrEq(DBN_BMNMTA, 1, SSS_LASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT >= " & "'" & RTrim(SSS_LASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD,TBL.WRTFSTDT"
		Call DB_GetSQL2(DBN_BMNMTA, strSQL)
		
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I As Short
		Dim strSQL As String
		'
		I = SET_GAMEN_KEY()
		I = 0
		''''Call DB_GetLs(DBN_BMNMTA, 1, SSS_FASTKEY, BtrNormal)
		strSQL = ""
		strSQL = strSQL & "SELECT *"
		strSQL = strSQL & "  FROM   ("
		strSQL = strSQL & "             SELECT BMN.DATKB, BMN.BMNCD, BMN.STTTKDT, BMN.ENDTKDT, BMN.BMNNM,"
		strSQL = strSQL & "                    BMN.BMNZP, BMN.BMNADA, BMN.BMNADB, BMN.BMNADC, BMN.BMNTL,"
		strSQL = strSQL & "                    BMN.BMNFX, BMN.BMNURL, BMN.BMNCDUP, BMN.BMNLV, BMN.ZMJGYCD,"
		strSQL = strSQL & "                    BMN.ZMCD, BMN.ZMBMNCD, BMN.EIGYOCD, BMN.TIKKB, BMN.HTANCD,"
		strSQL = strSQL & "                    BMN.STANCD, BMN.BMNPRNM, BMN.RELFL,"
		strSQL = strSQL & "                    BMN.FOPEID, BMN.FCLTID,"
		strSQL = strSQL & "                    BMN.WRTFSTTM, (99999999 - TO_NUMBER(BMN.ENDTKDT)) as WRTFSTDT,"
		strSQL = strSQL & "                    BMN.OPEID, BMN.CLTID, BMN.WRTTM, BMN.WRTDT,"
		strSQL = strSQL & "                    BMN.UOPEID, BMN.UCLTID, BMN.UWRTTM, BMN.UWRTDT,"
		strSQL = strSQL & "                    BMN.PGID "
		strSQL = strSQL & "             From BMNMTA BMN"
		strSQL = strSQL & "             ) TBL"
		strSQL = strSQL & " WHERE   TBL.BMNCD || TBL.WRTFSTDT < " & "'" & RTrim(SSS_FASTKEY.Value) & "'"
		strSQL = strSQL & " ORDER BY TBL.BMNCD DESC, TBL.WRTFSTDT DESC"
		
		Call DB_GetSQL2(DBN_BMNMTA, strSQL)
		
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			DB_PARA(DBN_BMNMTA).nDirection = 2
			Call DB_GetPre(DBN_BMNMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			'        Call DB_GetFirst(DBN_BMNMTA, 1, BtrNormal)
			SSS_LASTKEY.Value = Space(Len(DB_BMNMTA.BMNCD)) & VB6.Format(DB_BMNMTA.WRTFSTDT, "00000000")
		Else
			SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.WRTFSTDT
		End If
		
		I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BMNMTA.BMNCD = RD_SSSMAIN_BMNCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(RD_SSSMAIN_ENDTKDT(0)) = "" Then
			DB_BMNMTA.ENDTKDT = "00000000"
		Else
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_BMNMTA.ENDTKDT = VB6.Format(99999999 - Val(RD_SSSMAIN_ENDTKDT(0)), "00000000")
		End If
		
		SSS_LASTKEY.Value = DB_BMNMTA.BMNCD & DB_BMNMTA.ENDTKDT
		SET_GAMEN_KEY = 4
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim rtn As Short
		
		'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			rtn = DSP_MsgBox(CStr(0), "NO_ENTRY", 0) 'データを入力して下さい
			'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module