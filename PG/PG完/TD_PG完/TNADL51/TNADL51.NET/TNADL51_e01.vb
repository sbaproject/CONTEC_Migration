Option Strict Off
Option Explicit On
Module TNADL51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : TNADL51.E01
	' 記述者            : Standard Library
	' 作成日付          : 1998/03/30
	' 使用プログラム名  : TNADL51
	'
	Dim WRK_MFIL() As TYPE_DB_TNADL51
	
	Sub DSP_BODY(ByRef De As Short)
		'UPGRADE_WARNING: オブジェクト DB_TNADL51 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51 = WRK_MFIL((SSS_CurPage - 1) * SSS_PageLine + De)
		Call SCR_FromMfil(De)
		
		AE_BackColor(5) = &H8000000F '背景色：グレー
		Dim I As Short
		For I = 0 To 15
			Call SetColor(PP_SSSMAIN, "SOUCD", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "SOUNM", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "SMZZAISU", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "SMAINPSU", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "SMAOUTSU", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "SMISAISU", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "ZAISAISU", I, AE_BackColor(5))
			Call SetColor(PP_SSSMAIN, "RELZAISU", I, AE_BackColor(5))
		Next I
	End Sub
	
	Sub DSP_HEAD()
		Call SCR_FromHINMTA(0)
		
	End Sub
	
	'DL4では使用しない
	'Function DSP_KEYCHK()
	'End Function
	
	Sub INITDSP()
		
	End Sub
	
	Sub SET_DATA_KEY()
		G_PlCnd.sCndStr(1) = SSS_WrkKey
	End Sub
	
	Sub SET_GAMEN_KEY()
		
		SSS_SQLPage = 1
		SSS_MaxPage = 1
		ReDim WRK_MFIL(SSS_MaxPage * SSS_PageLine)
		SSS_LastPage = 0
		SSS_LastLine = 0
		SSS_WrkKey = ""

        '運用日等取得
        '20190705 CHG STRT
        'Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
        Call GetRowsCommon("UNYMTA", "")
        If DB_UNYMTA.UNYKBA Is Nothing Then
            DBSTAT = 1
        Else
            DBSTAT = 0
        End If
        '20190705 CHG END

        SSS_SMADT.Value = DeCNV_DATE(Get_Acedt(CNV_DATE(DB_UNYMTA.UNYDT)))

        '   SSS_SMADT = DeCNV_DATE(Get_Acedt(CNV_DATE(RD_SSSMAIN_DSPYM(0))))

        '表示条件転送
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        G_PlCnd.sCndStr(0) = RD_SSSMAIN_HINCD(0)
        G_PlCnd.sCndStr(1) = "   "
        G_PlCnd.sCndStr(2) = SSS_SMADT.Value
        G_PlCnd.sOpeID = SSS_OPEID.Value
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
        G_PlInfo.Fno(0) = DBN_TNADL51
        G_PlInfo.RCnt(0) = 1
        G_PlInfo.ArrayFlg(0) = 1
        G_PlInfo.RMax(0) = SSS_SQLPage * SSS_PageLine + 1
    End Sub
	
	Function GET_DSP_DATA() As Integer
		Dim PLSTAT, cnt As Integer
		Dim I As Short
		GET_DSP_DATA = False
		PLSTAT = DB_PlStart(1)
		PLSTAT = DB_PlCndSet
		PLSTAT = DB_PlSet(DBN_TNADL51, 0)
		PLSTAT = DB_PlExec(SSS_PrgId & "_PACK.M2_" & SSS_PrgId)
		If PLSTAT <> 0 Then
			MsgBox("PL/SQL Error：" & PLSTAT)
		Else
			cnt = DB_PlGetCnt(DBN_TNADL51)
			If cnt = SSS_SQLPage * SSS_PageLine + 1 Then
				PLSTAT = DB_PlGet(DBN_TNADL51, cnt - 1)
				SSS_WrkKey = DB_TNADL51.SOUCD
				cnt = cnt - 1
			Else
				SSS_WrkKey = HighValue(Len(DB_TNADL51.SOUCD))
			End If
			If cnt > 0 Then
				GET_DSP_DATA = True
				SSS_MaxPage = SSS_MaxPage + SSS_SQLPage
				ReDim Preserve WRK_MFIL(SSS_MaxPage * SSS_PageLine)
				I = 0
				Do While cnt > I
					PLSTAT = DB_PlGet(DBN_TNADL51, I)
					'UPGRADE_WARNING: オブジェクト WRK_MFIL(I + SSS_LastPage * SSS_PageLine) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					WRK_MFIL(I + SSS_LastPage * SSS_PageLine) = DB_TNADL51
					I = I + 1
				Loop 
				SSS_LastPage = SSS_LastPage + Int((cnt - 1) / SSS_PageLine) + 1
				SSS_LastLine = (cnt - 1) Mod SSS_PageLine + 1
				SSS_CurPage = SSS_CurPage + 1
			End If
		End If
		PLSTAT = DB_PlFree
	End Function
	
	Function SSSMAIN_OPEID_BeginPrg(ByRef PP As clsPP, ByRef CP_OPEID As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_OPEID.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_OPEID_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_OPEID_BeginPrg = True
	End Function
	Function SSSMAIN_OPENM_BeginPrg(ByRef PP As clsPP, ByRef CP_OPENM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_OPENM.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_OPENM_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_OPENM_BeginPrg = True
	End Function
	Function SSSMAIN_HINNMA_BeginPrg(ByRef PP As clsPP, ByRef CP_HINNMA As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_HINNMA.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_HINNMA_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_HINNMA_BeginPrg = True
	End Function
	
	Function SSSMAIN_HINNMB_BeginPrg(ByRef PP As clsPP, ByRef CP_HINNMB As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_HINNMB.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_HINNMB_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_HINNMB_BeginPrg = True
	End Function
	Function SSSMAIN_UNTNM_BeginPrg(ByRef PP As clsPP, ByRef CP_UNTNM As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		CL_SSSMAIN(CP_UNTNM.CpPx) = 5
		'UPGRADE_WARNING: オブジェクト SSSMAIN_UNTNM_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_UNTNM_BeginPrg = True
	End Function
	Function SSSMAIN_SOUCD_BeginPrg(ByRef PP As clsPP, ByRef CP_SOUCD As clsCP) As Object
		AE_BackColor(5) = &H8000000F '背景色：グレー
		Dim I, STT As Short
		
		STT = 8
		For I = STT + 0 To STT + 15 * 8
			CL_SSSMAIN(I) = 5
		Next I
		'UPGRADE_WARNING: オブジェクト SSSMAIN_SOUCD_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_SOUCD_BeginPrg = True
		
		
	End Function
	
	Function SetColor(ByRef PP As clsPP, ByVal pm_ItemName As String, ByVal De As Short, ByVal pCOLOR As Integer) As Object
		Dim wk_Qx, wk_Px As Short
		Dim Wk_TxVariant As Object
		Dim UCaseObjA As String
		UCaseObjA = UCase(pm_ItemName)
		
		Dim WK_PSIC As Short
		'総項目数算出
		WK_PSIC = PP_SSSMAIN.BodyV + PP_SSSMAIN.BodyPx + (PP_SSSMAIN.PrpC - PP_SSSMAIN.TailPx) + PP_SSSMAIN.EBodyV
		If De > 0 Then De = De - 1
		If De > PP.MaxDsp Then Exit Function 'MAX表示以上は処理しない。
		
		wk_Qx = 0
		Do While wk_Qx < WK_PSIC And Mid(CQ_SSSMAIN(wk_Qx), Cn_AfterPrfx) <> UCaseObjA
			wk_Qx = wk_Qx + 1
		Loop 
		
		If wk_Qx < PP_SSSMAIN.BodyPx Then
		ElseIf wk_Qx < (PP_SSSMAIN.BodyPx + PP_SSSMAIN.BodyV) Then 
			If De < 0 Then De = 0
			wk_Px = wk_Qx - (PP.BodyPx - PP.HeadN) + PP_SSSMAIN.BodyN * De
		End If
		
		AE_Controls(wk_Px).BackColor = System.Drawing.ColorTranslator.FromOle(pCOLOR)
		
	End Function
End Module