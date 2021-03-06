Option Strict Off
Option Explicit On
Module SYKET51_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : SYKET51.E01
	' 記述者            : Standard Library
	' 作成日付          : 2006/07/16
	' 使用プログラム名  : SYKET51
	'
	Public WG_WRKKB As String
	Public WG_FDNDT As String
	Public WG_SOUCD As String
	Public WG_TOKCD As String
	Public Const WG_DKBSB As String = "020"
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim WL_JDNNO As String
		Dim WL_CASSU, WL_FRDSU As Decimal
		Dim rtn As Object
		
		I = 0
		WL_JDNNO = Trim(SSS_LASTKEY.Value) & Space(Len(DB_SYKTRA.JDNNO) - Len(Trim(SSS_LASTKEY.Value)))
		Call DB_GetGrEq(DBN_SYKTRA, 2, SSS_CLTID.Value & SSS_PrgId & "1" & SSS_LASTKEY.Value, BtrNormal)
		Do While (DBSTAT = 0) And (WL_JDNNO = DB_SYKTRA.JDNNO)
			If Trim(WG_SOUCD) <> "" And WG_SOUCD <> DB_SYKTRA.OUTSOUCD Then
			Else
				'''' UPD 2008/08/30  FKS) S.Nakajima    Start
				'            If Trim(WG_TOKCD) <> "" And WG_TOKCD <> DB_SYKTRA.TOKCD Then
				If Trim(WG_TOKCD) <> "" And Trim(WG_TOKCD) <> Trim(DB_SYKTRA.TOKCD) Then
					'''' UPD 2008/08/30  FKS) S.Nakajima    End
				Else
					'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYKTRA.FRDSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(DB_SYKTRA.HIKSU) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(DB_SYKTRA.HIKSU) <= SSSVal(DB_SYKTRA.FRDSU) Then ' 出荷指示済
					Else
						''''''''            If CHK_KADOYMD(CNV_DATE(DB_SYKTRA.ODNYTDT)) = False Then    '可能物流稼動日以降は入力できません。
						''''''''            Else
						If WG_FDNDT < CNV_DATE(DB_SYKTRA.ODNYTDT) Then '対象日以外
						Else
							Select Case WG_WRKKB
								Case "2"
									If DB_SYKTRA.WRKKB = "4" Then
										Call DSPTRN_Move(I)
									End If
								Case "3"
									If DB_SYKTRA.WRKKB = "6" Then
										Call DSPTRN_Move(I)
									End If
								Case "4"
									If DB_SYKTRA.WRKKB = "7" Then
										Call DSPTRN_Move(I)
									End If
								Case "5"
									If DB_SYKTRA.WRKKB = "8" Then
										Call DSPTRN_Move(I)
									End If
								Case "6"
									If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Then
										Call DSPTRN_Move(I)
									End If
								Case Else
									''''''''''''''''''''''''''''''''If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
									If DB_SYKTRA.WRKKB = "1" Or DB_SYKTRA.WRKKB = "5" Then
										Call DSPTRN_Move(I)
									End If
							End Select
						End If
						''''''''            End If
					End If
				End If
			End If
			Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		Loop 
		'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DSPTRN = I
		
	End Function
	
	Sub DSPTRN_Move(ByRef I As Short)
		
		Dim wkFRDSU As Short
		
		'''''    Call SCR_FromMfil(I)
		Call SCR_FromSYKTRA(I)
		
		'倉庫セット
		If I = 0 Then
			Call SOUMTA_RClear()
			Call DB_GetEq(DBN_SOUMTA, 1, DB_SYKTRA.OUTSOUCD, BtrNormal)
			Call SCR_FromSOUMTA(I)
		End If
		
		'分納区分セット
		Select Case DB_SYKTRA.BKTHKKB
			Case "1"
				Call DP_SSSMAIN_BKTHKNM(I, "可")
			Case "9"
				Call DP_SSSMAIN_BKTHKNM(I, "不可")
			Case Else
				Call DP_SSSMAIN_BKTHKNM(I, "")
		End Select
		
		'出荷予定残数/出荷可能数/出荷指示数
		wkFRDSU = DB_SYKTRA.HIKSU - DB_SYKTRA.FRDSU
		Call DP_SSSMAIN_FRDYZSU(I, wkFRDSU)
		Call DP_SSSMAIN_FRDKNSU(I, wkFRDSU)
		Call DP_SSSMAIN_FRDSU(I, wkFRDSU)
		
		'出荷停止商品
		Call HINMTA_RClear()
		Call DB_GetEq(DBN_HINMTA, 1, DB_SYKTRA.HINCD, BtrNormal)
		
		If DB_SYKTRA.WRKKB = "2" Or DB_SYKTRA.WRKKB = "3" Or DB_SYKTRA.WRKKB = "5" Then
		Else
			If DB_HINMTA.ORTSTPKB = "9" And DB_HINMTA.ORTSTPDT <= DB_UNYMTA.UNYDT Then
				Call DP_SSSMAIN_FRDSU(I, 0)
			End If
			If DB_HINMTA.ORTSTPKB = "8" Then
				Call DP_SSSMAIN_FRDSU(I, 0)
			End If
			
		End If
		
		I = I + 1
	End Sub
	
	Sub INITDSP()
		Dim lngI As Integer
		Dim EXEPATH As String
		Dim I As Short
		
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(3) = 1 '倉庫ｺｰﾄﾞ
		CL_SSSMAIN(4) = 1 '倉庫名
		CL_SSSMAIN(5) = 1 '得意先ｺｰﾄﾞ
		CL_SSSMAIN(6) = 1 '得意先名
		CL_SSSMAIN(7) = 1 '入力担当者ｺｰﾄﾞ
		CL_SSSMAIN(8) = 1 '入力担当者名
		
		For lngI = 0 To PP_SSSMAIN.MaxDe
			CL_SSSMAIN(10 + (lngI * 15)) = 1 '製番
			CL_SSSMAIN(11 + (lngI * 15)) = 1 '出荷予定日
			CL_SSSMAIN(12 + (lngI * 15)) = 1 '製品ｺｰﾄﾞ
			CL_SSSMAIN(13 + (lngI * 15)) = 1 '型式
			CL_SSSMAIN(14 + (lngI * 15)) = 1 '分納
			CL_SSSMAIN(15 + (lngI * 15)) = 1 '引当数
			CL_SSSMAIN(16 + (lngI * 15)) = 1 '出荷予定残数
			CL_SSSMAIN(17 + (lngI * 15)) = 1 '出荷可能数
			CL_SSSMAIN(18 + (lngI * 15)) = 1 '出庫数
		Next 
		
		'運用日の取得
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		'出庫予定ファイルの削除
		''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
		''''
		''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
		'''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
		''''    Call DB_Delete(DBN_SYKTRA)
		''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
		''''Loop
		
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		
		'実行権限の取得
		Call Get_Authority(DB_UNYMTA.UNYDT)
		
		'出庫予定ファイル作成実行
		EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		
	End Sub
	
	Function INQ_UPDATE() As Object
		Dim rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		INQ_UPDATE = -1
		
		'権限チェック
		If gs_UPDAUTH = "9" Then
			rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '更新権限なし
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			INQ_UPDATE = 0
			Exit Function
		End If
		
		'
		rtn = DELTRN()
		rtn = WRTTRN()
		
	End Function
End Module