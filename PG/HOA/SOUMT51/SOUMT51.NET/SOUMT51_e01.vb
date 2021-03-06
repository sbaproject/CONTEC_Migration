Option Strict Off
Option Explicit On
Module SOUMT51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : SOUMT51.E01
	' 記述者            : Standard Library
	' 作成日付          : 1998/03/10
	' 使用プログラム名  : SOUMT51
	'
	Public Len506 As Short
	Public Len508 As Short
	Public Len509 As Short
	Public Len507 As Short
	Public Len511 As Short
	
	Function DSPMST() As Short
		Dim I As Short
		Dim wkSOUBSCD As String
		Dim wkSOUKOKB As String
		'
		I = 0
		SSS_FASTKEY.Value = SSS_LASTKEY.Value
		Call DB_GetGrEq(DBN_SOUMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		
		'2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		ReDim M_MOTO_A_inf(4)
		'2007/12/18 add-end T.KAWAMUKAI
		
		If DBSTAT = 0 Then
			Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC + 1))
				Call SCR_FromMfil(I)
				Call DP_SSSMAIN_V_DATKB(I, DB_SOUMTA.DATKB) '2006.11.07
				Call DP_SSSMAIN_V_SOUNM(I, DB_SOUMTA.SOUNM) '2006.11.07
				Call DP_SSSMAIN_V_SOUZP(I, DB_SOUMTA.SOUZP) '2006.11.07
				Call DP_SSSMAIN_V_SOUADA(I, DB_SOUMTA.SOUADA) '2006.11.07
				Call DP_SSSMAIN_V_SOUADB(I, DB_SOUMTA.SOUADB) '2006.11.07
				Call DP_SSSMAIN_V_SOUADC(I, DB_SOUMTA.SOUADC) '2006.11.07
				Call DP_SSSMAIN_V_SOUTL(I, DB_SOUMTA.SOUTL) '2006.11.07
				Call DP_SSSMAIN_V_SOUFX(I, DB_SOUMTA.SOUFX) '2006.11.07
				Call DP_SSSMAIN_V_SOUBSC(I, DB_SOUMTA.SOUBSCD) '2006.11.07
				Call DP_SSSMAIN_V_SOUKB(I, DB_SOUMTA.SOUKB) '2006.11.07
				Call DP_SSSMAIN_V_SRSCNK(I, DB_SOUMTA.SRSCNKB) '2006.11.07
				Call DP_SSSMAIN_V_SISNKB(I, DB_SOUMTA.SISNKB) '2006.11.07
				Call DP_SSSMAIN_V_SOUTRI(I, DB_SOUMTA.SOUTRICD) '2006.11.07
				Call DP_SSSMAIN_V_SOUKOK(I, DB_SOUMTA.SOUKOKB) '2006.11.07
				Call DP_SSSMAIN_V_HIKKB(I, DB_SOUMTA.HIKKB) '2006.11.07
				Call DP_SSSMAIN_V_SALPAL(I, DB_SOUMTA.SALPALKB) '2006.11.07
				If DB_SOUMTA.DATKB = "9" Then
					Call DP_SSSMAIN_UPDKB(I, "削除")
				Else
					Call DP_SSSMAIN_UPDKB(I, "更新")
				End If
				Call MEIMTA_RClear()
				wkSOUBSCD = DB_SOUMTA.SOUBSCD & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUBSCD))
				Call DB_GetEq(DBN_MEIMTA, 2, "015" & wkSOUBSCD, BtrNormal)
				Call DP_SSSMAIN_SOUBSNM(I, Trim(DB_MEIMTA.MEINMA))
				Call MEIMTA_RClear()
				wkSOUKOKB = DB_SOUMTA.SOUKOKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_SOUMTA.SOUKOKB))
				Call DB_GetEq(DBN_MEIMTA, 2, "026" & wkSOUKOKB, BtrNormal)
				Call DP_SSSMAIN_SOUKONM(I, Trim(DB_MEIMTA.MEINMA))
				Call TOKMTA_RClear()
				Call DB_GetEq(DBN_TOKMTA, 1, DB_SOUMTA.SOUTRICD, BtrNormal)
				Call SCR_FromTOKMTA(I)
				I = I + 1
				Call DB_GetNext(DBN_SOUMTA, BtrNormal)
			Loop 
		End If
		If DBSTAT = 0 Then
			SSS_LASTKEY.Value = DB_SOUMTA.SOUCD
		Else
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SSS_LASTKEY.Value = HighValue(LenWid(DB_SOUMTA.SOUCD))
		End If
		DSPMST = I
	End Function
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim wkCRW As System.Windows.Forms.Control
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1 '入力担当者コード
		CL_SSSMAIN(1) = 1 '入力担当者
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			CL_SSSMAIN(2 + (lngI * 36)) = 1 '更新区分
			CL_SSSMAIN(6 + (lngI * 36)) = 1 '場所名
			CL_SSSMAIN(8 + (lngI * 36)) = 1 '倉庫区分名
			CL_SSSMAIN(10 + (lngI * 36)) = 1 '取引先名
		Next 
		
		'実行権限チェック
		gs_userid = Left(SSS_OPEID.Value, 6) 'ユーザID
		gs_pgid = SSS_PrgId 'プログラムID
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
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
		Dim Rtn As Short
		'
		Call DB_GetGrEq(DBN_SOUMTA, 1, SSS_LASTKEY.Value, BtrNormal)
		If DBSTAT = 0 Then
			MST_NEXT = DSPMST()
		Else
			SSS_LASTKEY.Value = SSS_FASTKEY.Value
			MST_NEXT = DSPMST()
		End If
	End Function
	
	Function MST_PREV() As Short
		Dim I As Short
		'
		I = SET_GAMEN_KEY()
		I = 0
		Call DB_GetLs(DBN_SOUMTA, 1, SSS_FASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (I < (PP_SSSMAIN.MaxDspC))
			I = I + 1
			Call DB_GetPre(DBN_SOUMTA, BtrNormal)
		Loop 
		If DBSTAT <> 0 And I = 0 Then
			Call DB_GetFirst(DBN_SOUMTA, 1, BtrNormal)
		End If
		SSS_LASTKEY.Value = DB_PARA(DBN_SOUMTA).KeyBuf
		I = DSPMST()
		MST_PREV = I
	End Function
	
	Function SET_GAMEN_KEY() As Short
		'
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(0)
		SSS_LASTKEY.Value = DB_SOUMTA.SOUCD
		SET_GAMEN_KEY = 4
	End Function
	
	Function Execute_GetEvent() As Object
		
		Dim Rtn As Short
		
		'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Execute_GetEvent = True
		If PP_SSSMAIN.LastDe = 0 Then
			''''''''Rtn = DSP_MsgBox(0, "NO_ENTRY", 0)  'データを入力して下さい
			Rtn = DSP_MsgBox(CStr(0), "_COMPLETEC", 0) 'データを入力して下さい
			'UPGRADE_WARNING: オブジェクト Execute_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Execute_GetEvent = False
			Exit Function
		End If
		
	End Function
End Module