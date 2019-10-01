Option Strict Off
Option Explicit On
Friend Class HKKET142F
	Inherits System.Windows.Forms.Form

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

	Private Sub cmdCALC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCALC.Click
		
		'// 2007/01/28 ↓ ADD START
		cmdCALC.Enabled = False
		'// 2007/01/28 ↑ ADD END
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "206") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		Call D0.Mouse_ON()
		
		If Not Set_CalcData Then
			GoTo EXIT_STEP
		End If
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		'// 2007/01/28 ↓ ADD START
		cmdCALC.Enabled = True
		Call Ctr_Setfocus(cmdCALC)
		'    cmdCALC.SetFocus
		'// 2007/01/28 ↑ ADD END
		Call D0.Mouse_OFF()
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	Private Sub cmdCSVOUT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCSVOUT.Click
		Dim str_FileName As Object
		
		Dim str_FileName_1 As String
		Dim str_FileName_2 As String
		
		
		'//検索結果ＣＳＶ出力メッセージ
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "207") = MsgBoxResult.Yes Then
            'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            'add start 20190930 kuwa test CSV
            gvstrFilePath4 = "C:\Users\CIS03\Desktop\HKKET14CSV"
            'add end 20190930 kuwa
            If Dir(gvstrFilePath4, FileAttribute.Directory) = "" Then
                ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124")
                Exit Sub
            End If

            '//作成ファイル名生成
            'UPGRADE_WARNING: オブジェクト str_FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            str_FileName = gvstrFileName4 & "_" & Me.txtHINCD.Text & "_" & VB6.Format(Now, "YYYYMMDD") & "_" & VB6.Format(Now, "HHMMSS") & ".CSV"
			
			'//グラフＣＳＶ作成
			'UPGRADE_WARNING: オブジェクト str_FileName の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call Cra_GraphCSV(gvstrFilePath4, str_FileName)
			
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "208")
		End If
		
		'//V1.10 2006/10/17  ADD START  RISE)
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		Call D0.Mouse_OFF()
		Exit Sub
		'----------------------------------------------------------------------------------------
		'//V1.10 2006/10/17  ADD END  RISE)
		
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''    Dim str_DialogFilePath As String
		''''    Dim str_DialogFileName As String
		''''    Dim str_FileName       As String
		''''    '//V1.10 2006/10/17  ADD END    RISE)
		''''
		''''    '//検索結果ＣＳＶ出力メッセージ
		''''    If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "207") = vbYes Then
		''''        If Dir(gvstrFilePath4, vbDirectory) = "" Then
		''''            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "124"
		''''            Exit Sub
		''''        End If
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''        '//作成ファイル名生成
		''''        str_FileName = gvstrFileName4 & "_" & HKKET142F.txtHINCD.Text & "_" & Format(Now, "YYYYMMDD") & "_" & Format(Now, "HHMMSS") & ".CSV"
		''''
		''''        '//ダイアログボックス起動
		''''        str_DialogFileName = str_FileName
		''''        If Not Run_DialogBox(cdl_SAVE2, str_DialogFilePath, str_DialogFileName) Then
		''''            GoTo EXIT_STEP
		''''        End If
		''''    '//V1.10 2006/10/17  ADD END    RISE)
		''''
		''''        '//検索結果ＣＳＶ処理
		''''        intFileNo = FreeFile(0)
		''''    '//V1.10 2006/10/17  CHG START  RISE)
		''''''''        Open gvstrFilePath4 & "\" & gvstrFileName4 & "_" & HKKET142F.txtHINCD.Text & "_" & Format(Now, "YYYYMMDD") & "_" & Format(Now, "HHMMSS") & ".CSV" For Output As intFileNo
		''''        Open gvstrFilePath4 & "\" & str_FileName For Output As intFileNo
		''''    '//V1.10 2006/10/17  CHG END    RISE)
		''''        strBuff = ""
		''''        strBuff = strBuff & HKKET142F.txtHINCD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtHINNMA.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtHINNMB.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtZAIRNK.Text
		''''        Print #intFileNo, strBuff
		''''        strBuff = ""
		''''        strBuff = strBuff & HKKET142F.txtMINSODSU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtSODADDSU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtANZZAISU.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtLMAMSAVTS.Text
		''''        strBuff = strBuff & HKKET142F.txtLMAAVTS.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtLMZAVTSA.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtCHGRATE.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtPRCCD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtMNFDD.Text & ","
		''''        strBuff = strBuff & HKKET142F.txtTOUZAISU.Text
		''''        Print #intFileNo, strBuff
		''''        strBuff = "表示年月,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.strDSPMONTH(i)       '//表示年月
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "年初計画,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKTRA.strLMAHKS(i)          '//年初計画
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "見直計画,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKTRA.strLMAHMS(i)          '//見直計画
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "前年受注実績,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_JDNTR(i)     '//前年受注実績
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "前年出庫実績,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_ODNTRA(i)    '//前年出庫実績
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "前年発注実績,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_HDNTRA(i)    '//前年発注実績
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "入庫予定,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblINPTRA(i)         '//入庫予定
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "出庫予定,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblOUTTRA(i)         '//出庫予定
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "支給品出庫,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblSKYOUT(i)         '//支給品出庫
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "月末在庫,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrHKKZTRA.dblLAST_STOCK(i)      '//月末在庫
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZZKM(i)          '//在庫切れマーク
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZAZM(i)          '//安全在庫切れマーク
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZMZKM(i)         '//見込在庫切れマーク
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.strLMZMAZM(i)         '//見込安全在庫切れマーク
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		'''''        strBuff = ""
		'''''        For i = 0 To 35
		'''''            strBuff = strBuff & musrHKKZTRA.dblLMZZKT(i)          '//在庫月数
		'''''            If i < 35 Then
		'''''                strBuff = strBuff & ","
		'''''            End If
		'''''        Next i
		'''''        Print #intFileNo, strBuff
		''''        strBuff = "見込案件,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMAK(i)            '//見込案件
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "見込見積,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMMT(i)            '//見込見積
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "見込出庫予定,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMOUTTRA(i)        '//見込出庫予定
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "見込月末在庫,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrMKMTRA.dblMKMLST(i)           '//見込月末在庫
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "発注済数,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMAODSSA(i)        '//発注済数
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "緊急発注済,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMAKODSA(i)        '//緊急発注済
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "入庫指示済数,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblLMZNOSSA(i)        '//入庫指示済数
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "入庫計画数,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.dblDspINPPLAN(i)         '//入庫計画数
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        strBuff = "入庫指示数,"
		''''        For i = 0 To 35
		''''            strBuff = strBuff & musrODINTRA.strLMZNOSS(i)         '//入庫指示数
		''''            If i < 35 Then
		''''                strBuff = strBuff & ","
		''''            End If
		''''        Next i
		''''        Print #intFileNo, strBuff
		''''        Close intFileNo
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		''''        '//選択されたファイルの移動
		''''        On Error Resume Next
		''''        Kill str_DialogFilePath & str_DialogFileName
		''''        FileCopy gvstrFilePath4 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName
		''''        Kill gvstrFilePath4 & "\" & str_FileName
		''''        On Error GoTo 0
		''''    '//V1.10 2006/10/17  ADD END  RISE)
		''''
		''''        ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "208"
		''''    End If
		''''
		''''    '//V1.10 2006/10/17  ADD START  RISE)
		'''''----------------------------------------------------------------------------------------
		''''EXIT_STEP:
		''''    Call D0.Mouse_OFF
		''''    Exit Sub
		'''''----------------------------------------------------------------------------------------
		''''    '//V1.10 2006/10/17  ADD END  RISE)
	End Sub
	
    Private Sub cmdMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMONTH.Click
        Dim Index As Short = cmdMONTH.GetIndex(eventSender)

        '// 2007/02/24 ↓ ADD STR
        'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvvntTop = VB6.PixelsToTwipsY(Me.Top)
        'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
        '// 2007/02/24 ↑ ADD STR

        '//詳細情報表示メッセージ
        If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "204") = MsgBoxResult.Yes Then
            gvintIndex = Index
            '//V1.10 2006/09/20  CHG START  RISE)
            'HKKET143F.Show vbModal
            'Unload HKKET143F
            Me.Visible = False
            '2019/04/15 CHG START
            'HKKET143F.Show()
            HKKET143F.ShowDialog()
            '2019/04/15 CHG E N D
            '//V1.10 2006/09/20  CHG E N D  RISE)
        End If

    End Sub

	Private Sub cmdNEXTHINCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNEXTHINCD.Click
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		
		If gvintNowItem + 1 > UBound(musrHKKZTR.strHINCD) Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "214")
			GoTo EXIT_STEP
		End If
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "211") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		gvstrDisplayID = "E02"
		
		gvlngNowPage = gvlngDefaultPage
		gvintNowItem = gvintNowItem + 1
		
		'// 2008/05/26 ↓ DEL STR 年初計画取込対応
		'    If gvblnInputFlg Then
		'        gvblnLMAHMS = True
		'        gvblnLMZNOS = True
		'    Else
		'        gvblnLMAHMS = False
		'        gvblnLMZNOS = False
		'    End If
		'// 2008/05/26 ↑ DEL STR
		
		Me.txtNOWPAGE.Text = CStr(gvintNowItem)
		
		'//画面初期化
		If Not HKKET142M.Set_Initialize Then
			'//終了処理
			Call Ctr_END()
		End If
		
		'// 2008/05/26 ↓ ADD STR 年初計画取込対応
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		'// 2008/05/26 ↑ DEL STR
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	Private Sub cmdNEXTMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNEXTMONTH.Click
		
		'//前画面・次画面処理
		Call Ctr_PagePrevNext("N")
		
	End Sub
	
	Private Sub cmdPREMONTH_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPREMONTH.Click
		
		'//前画面・次画面処理
		Call Ctr_PagePrevNext("P")
		
	End Sub
	
	Private Sub cmdPREVHINCD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPREVHINCD.Click
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		
		If gvintNowItem - 1 < 1 Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "215")
			GoTo EXIT_STEP
		End If
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "210") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
		gvstrDisplayID = "E02"
		
		gvlngNowPage = gvlngDefaultPage
		gvintNowItem = gvintNowItem - 1
		
		'// 2008/05/26 ↓ DEL STR 年初計画取込対応
		'    If gvblnInputFlg Then
		'        gvblnLMAHMS = True
		'        gvblnLMZNOS = True
		'    Else
		'        gvblnLMAHMS = False
		'        gvblnLMZNOS = False
		'    End If
		'// 2008/05/26 ↑ DEL STR
		
		Me.txtNOWPAGE.Text = CStr(gvintNowItem)
		
		'//画面初期化
		If Not HKKET142M.Set_Initialize Then
			'//終了処理
			Call Ctr_END()
		End If
		
		'// 2008/05/26 ↓ ADD STR 年初計画取込対応
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		'// 2008/05/26 ↑ ADD STR
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	
	Private Sub cmdRETURN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRETURN.Click
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		
		gvstrDisplayID = "E01"
		Me.Close()
	End Sub
	
	Private Sub cmdUPD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUPD.Click
		
		'//V1.10 2006/10/17  ADD START  RISE)
		Dim str_DialogFilePath As String
        Dim str_DialogFileName As String
        '2019/04/19 CHG START
        'Dim str_FileName As String
        Dim str_FileName As String = ""
        '2019/04/19 CHG E N D
        '//V1.10 2006/10/17  ADD END    RISE)
		
		'// 2007/01/28 ↓ ADD START
		cmdUPD.Enabled = False
		'// 2007/01/28 ↑ ADD END
		
		'// V2.20↓ ADD
		If Chk_YuusenFlg = False Then
			GoTo EXIT_STEP
		End If
		'// V2.20↑ ADD
		
		'// 2007/01/09 ↓ ADD STR
		If Not Set_CalcData Then
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 ↑ ADD END
		
		'// 2007/01/09 ↓ ADD STR
		If Not Chk_Hacyusu Then
			GoTo EXIT_STEP
		End If
		'// 2007/01/09 ↑ ADD END
		
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "217") = MsgBoxResult.No Then
			GoTo EXIT_STEP
		End If
		
        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        '2019/04/19 CHG START
        'clsOra.OraBeginTrans()
        Call DB_BeginTrans(CON)
        '2019/04/19 CHG E N D

		Call D0.Mouse_ON()
		If Not Upd_Main(str_FileName) Then
			ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "222")
            Call D0.Mouse_OFF()
            '2019/04/19 CHG START
            'clsOra.OraRollback()
            Call DB_Rollback()
            '2019/04/19 CHG E N D
            GoTo EXIT_STEP
		End If
		Call D0.Mouse_OFF()
		
        '//ﾄﾗﾝｻﾞｸｼｮﾝ制御開始
        '2019/04/22 CHG START
        'clsOra.OraCommitTrans()
        Call DB_Commit()
        '2019/04/22 CHG E N D

		'// 2007/01/09 ↓ ADD STR
		If gvblnLMZNOS = True And gvstrHINKB = "3" Or gvstrHINKB = "4" Or gvstrHINKB = "5" Then
			
			'//グラフＣＳＶ作成
			Call Cra_GraphCSV(gvstrFilePath6, str_FileName)
			
		End If
		'// 2007/01/09 ↑ ADD END
		
		'// 2007/01/09 ↓ DEL STR
		'''''// 2006/10/27 ↓ ADD STR
		'''''// 2006/11/07 ↓ ADD STR
		''''    If gvblnLMZNOS = True And gvstrHINKB = "3" Or _
		'''''                              gvstrHINKB = "4" Or _
		'''''                              gvstrHINKB = "5" Then
		''''        '//ダイアログボックス起動
		''''        str_DialogFileName = str_FileName
		''''        If Not Run_DialogBox(cdl_SAVE2, str_DialogFilePath, str_DialogFileName) Then
		''''            GoTo EXIT_STEP
		''''        End If
		''''
		''''        '//選択されたファイルの移動
		''''        On Error Resume Next
		''''        Kill str_DialogFilePath & str_DialogFileName
		''''        FileCopy gvstrFilePath6 & "\" & str_FileName, str_DialogFilePath & str_DialogFileName
		''''        Kill gvstrFilePath6 & "\" & str_FileName
		''''        On Error GoTo 0
		''''    End If
		'''''// 2006/11/06 ↑ REP,END
		'// 2007/01/09 ↑ DEL END
		
		ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "221")
		
		ReDim musrHKKTRA.strLMAHKS(0)
		ReDim musrHKKTRA.blnLMAHKS(0)
		ReDim musrHKKTRA.strLMAHMS(0)
		ReDim musrHKKTRA.blnLMAHMS(0)
		
		ReDim musrHKKZTRA.strDSPMONTH(0)
		ReDim musrHKKZTRA.dblLAST_JDNTR(0)
		ReDim musrHKKZTRA.dblLAST_ODNTRA(0)
		ReDim musrHKKZTRA.dblLAST_HDNTRA(0)
		ReDim musrHKKZTRA.dblINPTRA(0)
		ReDim musrHKKZTRA.dblOUTTRA(0)
		ReDim musrHKKZTRA.dblSKYOUT(0)
		ReDim musrHKKZTRA.dblLAST_STOCK(0)
		ReDim musrHKKZTRA.strLMZLDT(0)
		ReDim musrHKKZTRA.strLMZHDT(0)
		ReDim musrHKKZTRA.strLMZZKM(0)
		ReDim musrHKKZTRA.strLMZAZM(0)
		ReDim musrHKKZTRA.strLMZMZKM(0)
		ReDim musrHKKZTRA.strLMZMAZM(0)
		ReDim musrHKKZTRA.dblLMZZKT(0)
		ReDim musrHKKZTRA.dblLMAVZS(0)
		
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMAK(0)
		ReDim musrMKMTRA.dblMKMMT(0)
		ReDim musrMKMTRA.dblMKMOUTTRA(0)
		ReDim musrMKMTRA.dblMKMLST(0)
		
		ReDim musrODINTRA.dblLMAODSSA(0)
		ReDim musrODINTRA.dblLMAKODSA(0)
		ReDim musrODINTRA.dblLMZNOSSA(0)
		ReDim musrODINTRA.strINPPLAN(0)
		ReDim musrODINTRA.dblDspINPPLAN(0)
		ReDim musrODINTRA.strLMZNOSS(0)
		'// V2.20↓ ADD
		ReDim musrODINTRA.strLMZNPF(0)
		ReDim musrODINTRA.strLMZNPF_ORG(0)
		'// V2.20↑ ADD
		
		'//画面表示に必要なデータを取得し表示する
		If Not HKKET142M.Get_DisplayData Then
			GoTo EXIT_STEP
		End If
		
		If Not HKKET142M.Set_DisplayData(gvlngNowPage) Then
			GoTo EXIT_STEP
		End If
		
		gvblnLMAHMS = False
		gvblnLMZNOS = False
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		'// 2007/01/28 ↓ ADD START
		cmdUPD.Enabled = True
		Call Ctr_Setfocus(cmdUPD)
		'    cmdUPD.SetFocus
		'// 2007/01/28 ↑ ADD END
		On Error GoTo 0
		Exit Sub
		'----------------------------------------------------------------------------------------
	End Sub
	
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Form
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    Form EVENT
	'//*****************************************************************************************
	'UPGRADE_WARNING: Form イベント HKKET142F.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub HKKET142F_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		'// 2007/02/24 ↓ ADD STR
		Call SetFormInitOrg(Me, 1)
        '// 2007/02/24 ↑ ADD STR
        '//フォーカスコントロール
        'change start 20190930 kuwa
        'ClsFocus.SetFocusCtrl(Me)
        ClsFocus.SetFocusCtrl2(Me)
        'change end 20190930 kuwa
    End Sub

    Private Sub HKKET142F_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000

        '// V2.01 ↓ ADD
        Dim ShiftTest As Short
        '// V2.01 ↑ ADD

        '//Enterキーで次項目へ移動
        Select Case ClsFocus.GetKeyDown(KeyCode)
            Case System.Windows.Forms.Keys.Return
                'change start 20190930 kuwa
                'ClsFocus.EnterNext()
                ClsFocus.EnterNext(False, DirectCast(eventSender, System.Windows.Forms.ContainerControl).ActiveControl.Name)
                'change end 20190930 kuwa
                '// 2007/02/28 ↓ ADD STR
            Case System.Windows.Forms.Keys.F1
                'add start 20190927 フォーカスを移さなければ、Validateの処理を通らないため追加
                cmdCALC.Focus()
                'add end 20190927 kuwa
                Call cmdCALC_Click(cmdCALC, New System.EventArgs())
                'C2-20170418-02 CHG START 2017/04/18 富士通）橋本
                '排他制御がかかっている場合はF5を無効化する処理追加
                'Case vbKeyF5
                '   Call cmdUPD_Click
            Case System.Windows.Forms.Keys.F5
                If gvintPGHaita = 9 Then
                Else
                    Call cmdUPD_Click(cmdUPD, New System.EventArgs())
                End If
                'C2-20170418-02 CHG START 2017/04/18 富士通）橋本
                '// 2007/02/28 ↑ ADD END
                '// 2007/08/18 ↓ ADD STR
            Case System.Windows.Forms.Keys.F3
                Call cmdPREVHINCD_Click(cmdPREVHINCD, New System.EventArgs())
            Case System.Windows.Forms.Keys.F4
                '// V2.01 ↓ ADD
                ShiftTest = Shift And 7
                Select Case ShiftTest
                    Case 4 ' Alt キーが押されました。
                        Exit Sub
                    Case 5 ' Shift と Alt キーが押されました。
                        Exit Sub
                End Select
                '// V2.01 ↑ ADD
                Call cmdNEXTHINCD_Click(cmdNEXTHINCD, New System.EventArgs())
                '// 2007/08/18 ↑ ADD END
                '// 2007/09/10 ↓ ADD STR
            Case System.Windows.Forms.Keys.F12
                Call cmdRETURN_Click(cmdRETURN, New System.EventArgs())
                '// 2007/09/10 ↑ ADD END
                '// 2008/11/17 ↓ ADD STR
            Case System.Windows.Forms.Keys.F6 '//F6:年初計画へｶｰｿﾙ移動
                KeyCode = 0
                txtLMAHKS(0).Focus()
            Case System.Windows.Forms.Keys.F7 '//F7:見直計画へｶｰｿﾙ移動
                KeyCode = 0
                txtLMAHMS(0).Focus()
            Case System.Windows.Forms.Keys.F8 '//F8:連携へｶｰｿﾙ移動
                KeyCode = 0
                txtINPPLAN(0).Focus()
            Case System.Windows.Forms.Keys.F9 '//F9:優先へｶｰｿﾙ移動
                KeyCode = 0
                txtLMZNPF(0).Focus()
            Case System.Windows.Forms.Keys.F10 '//F10:入庫指示へｶｰｿﾙ移動
                KeyCode = 0
                txtLMZNOSS(0).Focus()
                '// 2008/11/17 ↑ ADD end

        End Select
    End Sub
    Private Sub HKKET142F_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Me.Top = VB6.TwipsToPixelsY(gvvntTop)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Me.Left = VB6.TwipsToPixelsX(gvvntLeft)
		'// 2007/02/24 ↑ ADD STR
		
		gvstrDisplayID = "E02"
		
		If gvblnInputFlg Then
			gvblnLMAHMS = True
			gvblnLMZNOS = True
		Else
			gvblnLMAHMS = False
			gvblnLMZNOS = False
		End If
		
		If Mid(gvstrUNYDT, 5, 2) = "01" Or Mid(gvstrUNYDT, 5, 2) = "02" Or Mid(gvstrUNYDT, 5, 2) = "03" Then
			gvlngNowPage = CDbl(Mid(gvstrUNYDT, 5, 2)) + 20
		Else
			gvlngNowPage = CDbl(Mid(gvstrUNYDT, 5, 2)) + 8
		End If
		
		gvlngDefaultPage = gvlngNowPage
		
		'//画面初期化
		If Not HKKET142M.Set_Initialize Then
			'//終了処理
			Call Ctr_END()
		End If

        '2019/04/24 ADD START
        Call SetBar(Me)
        '2019/04/24 ADD E N D

    End Sub
	
	'// 2007/02/24 ↓ ADD STR
	Private Sub HKKET142F_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
	End Sub
	'// 2007/02/24 ↑ ADD STR
	
	Private Sub HKKET142F_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '2019/04/15 DEL START
        'Dim Cancel As Boolean = eventArgs.Cancel
        '2019/04/15 DEL E N D
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		
		'//終了メッセージ
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "213") = MsgBoxResult.No Then
            '2019/04/15 CHG START
            'Cancel = True
            eventArgs.Cancel = True
            '2019/04/15 CHG E N D
            Exit Sub
		End If
		'//V1.10 2006/09/20  ADD START  RISE)
		HKKET141F.Visible = True
		'//V1.10 2006/09/20  ADD E N D  RISE)
        '2019/04/15 CHG START
        'eventArgs.Cancel = Cancel
        eventArgs.Cancel = False
        '2019/04/15 CHG E N D
    End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtINPPLAN
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtINPPLAN EVENT
	'//*****************************************************************************************
	Private Sub txtINPPLAN_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtINPPLAN.Enter
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		
		'//GotFocus処理
		Call Set_ObjectGotFocus(txtINPPLAN(Index), Index)
		
	End Sub
	Private Sub txtINPPLAN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtINPPLAN.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		'//入力可能キーの設定
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtINPPLAN_Validating(txtINPPLAN.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtINPPLAN_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	Private Sub txtINPPLAN_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtINPPLAN.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtINPPLAN.GetIndex(eventSender)
		
		'//入庫計画
		musrODINTRA.strINPPLAN(gvlngNowPage + Index) = Me.txtINPPLAN(Index).Text
		
		If Trim(musrODINTRA.strINPPLAN_ORG(gvlngNowPage + Index)) <> Trim(musrODINTRA.strINPPLAN(gvlngNowPage + Index)) Then
			gvblnLMZNOS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtLMAHKS
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtLMAHKS EVENT
	'//*****************************************************************************************
	Private Sub txtLMAHKS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMAHKS.Enter
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		
		'//GotFocus処理
		Call Set_ObjectGotFocus(txtLMAHKS(Index), Index)
		
	End Sub
	Private Sub txtLMAHKS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMAHKS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		'//入力可能キーの設定
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMAHKS_Validating(txtLMAHKS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMAHKS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMAHKS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMAHKS.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMAHKS.GetIndex(eventSender)
		
		'//年初計画
		'If Not musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) Then
		If Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) <> "" Then
			If Trim(Me.txtLMAHKS(Index).Text) <> "" And Trim(musrHKKTRA.strLMAHKS_ORG(gvlngNowPage + Index)) = "" Then
				Me.txtLMAHKS(Index).Text = Trim(musrHKKTRA.strLMAHKS(gvlngNowPage + Index))
				ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "202")
				GoTo EventExitSub
			End If
		End If
		
		'//年初計画
		musrHKKTRA.strLMAHKS(gvlngNowPage + Index) = Me.txtLMAHKS(Index).Text
		If Trim(musrHKKTRA.strLMAHKS_ORG(gvlngNowPage + Index)) <> Trim(musrHKKTRA.strLMAHKS(gvlngNowPage + Index)) Then
			gvblnLMAHMS = True
		End If
EventExitSub: 
		eventArgs.Cancel = Cancel
	End Sub
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtLMAHMS
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtLMAHMS EVENT
	'//*****************************************************************************************
	Private Sub txtLMAHMS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMAHMS.Enter
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		
		'//GotFocus処理
		Call Set_ObjectGotFocus(txtLMAHMS(Index), Index)
		
	End Sub
	
	Private Sub txtLMAHMS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMAHMS.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		'//入力可能キーの設定
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMAHMS_Validating(txtLMAHMS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMAHMS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
			Case 1 To 26
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMAHMS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMAHMS.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMAHMS.GetIndex(eventSender)
		
		'// 2007/02/21 ↓ DEL STR
		''''    '//見直計画
		''''    'If Not musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) Then
		'''''// 2006/11/14 ↓ UPD STR　コメントアウトになっていた部分を復活
		''''    If Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) <> "" Then
		'''''    If Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index)) <> "" Then
		'''''// 2006/11/14 ↑ UPD END
		''''        If Trim(HKKET142F.txtLMAHMS(Index).Text) <> "" And Trim(musrHKKTRA.strLMAHMS_ORG(gvlngNowPage + Index)) = "" Then
		''''            HKKET142F.txtLMAHMS(Index).Text = Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index))
		''''            ClsMessage.MsgLibrary gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "202"
		''''            Exit Sub
		''''        End If
		''''    End If
		'// 2007/02/21 ↑ DEL END
		
		'//見直計画
		musrHKKTRA.strLMAHMS(gvlngNowPage + Index) = Me.txtLMAHMS(Index).Text
		If Trim(musrHKKTRA.strLMAHMS_ORG(gvlngNowPage + Index)) <> Trim(musrHKKTRA.strLMAHMS(gvlngNowPage + Index)) Then
			gvblnLMAHMS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtLMZNOSS
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtLMZNOSS EVENT
	'//*****************************************************************************************
    Private Sub txtLMZNOSS_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMZNOSS.Enter
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)
        '//GotFocus処理
        Call Set_ObjectGotFocus(txtLMZNOSS(Index), Index)

    End Sub
	
    Private Sub txtLMZNOSS_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMZNOSS.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)
        '//入力可能キーの設定
        Select Case KeyAscii
            Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
            Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMZNOSS_Validating(txtLMZNOSS.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMZNOSS_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
            Case 1 To 26
            Case Else
                KeyAscii = 0
        End Select
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub
	
    Private Sub txtLMZNOSS_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMZNOSS.Validating
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim Index As Short = txtLMZNOSS.GetIndex(eventSender)

        Dim strDate As String

        '//入庫指示
        If System.Drawing.ColorTranslator.ToOle(Me.txtLMZNOSS(Index).BackColor) = gvcst_COLOR_DAIDAIIRO Then
            If Trim(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) <> "" Then
                If Val(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) < Val(Me.txtLMZNOSS(Index).Text) Then
                    Me.txtLMZNOSS(Index).Text = Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index))
                    ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "220")
                    GoTo EventExitSub
                End If
            End If
        End If

        '//入庫指示
        musrODINTRA.strLMZNOSS(gvlngNowPage + Index) = Me.txtLMZNOSS(Index).Text

        If Trim(musrODINTRA.strLMZNOSS_ORG(gvlngNowPage + Index)) <> Trim(musrODINTRA.strLMZNOSS(gvlngNowPage + Index)) Then
            gvblnLMZNOS = True
        End If

        If Trim(Me.txtLMZNOSS(Index).Text) = "" Then
            '//年初計画
            musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) = True
            '//見直計画
            musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) = True
        Else
            '//年初計画
            musrHKKTRA.blnLMAHKS(gvlngNowPage + Index) = False
            '//見直計画
            musrHKKTRA.blnLMAHMS(gvlngNowPage + Index) = False
        End If

        '// V2.00↓ ADD
        If Trim(Me.txtLMZNOSS(Index).Text) <> "" And Val(Trim(Me.txtLMZNOSS(Index).Text)) <> 0 Then
            '//入庫指示が入力されたのでロックする
            Me.txtINPPLAN(Index).ReadOnly = True
            Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
            '// V2.20↓ ADD
            Me.txtLMZNPF(Index).ReadOnly = True
            Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(gvcst_COLOR_HAIIRO)
            '// V2.20↑ ADD
        Else
            '//入庫指示が未入力状態にされたのでロックする
            Select Case musrHKKTRA.intLTKBN(gvlngNowPage + Index)
                Case 0
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' 薄いグリーン
                    '// V2.20↓ ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFC0) ' 薄いグリーン
                    '// V2.20↑ ADD
                Case 1
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' オレンジ
                    '// V2.20↓ ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&H80C0FF) ' オレンジ
                    '// V2.20↑ ADD
                Case 2
                    Me.txtINPPLAN(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' 薄い黄色
                    '// V2.20↓ ADD
                    Me.txtLMZNPF(Index).BackColor = System.Drawing.ColorTranslator.FromOle(&HC0FFFF) ' 薄い黄色
                    '// V2.20↑ ADD
            End Select
        End If
        '// V2.00↑ ADD

EventExitSub:
        eventArgs.Cancel = Cancel
    End Sub
	
	'// V2.20↓ ADD
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtLMZNPF
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtLMZNPF EVENT
	'//*****************************************************************************************
	Private Sub txtLMZNPF_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtLMZNPF.Enter
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		'//GotFocus処理
		Call Set_ObjectGotFocus(txtLMZNPF(Index), Index)
		
	End Sub
	
	Private Sub txtLMZNPF_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtLMZNPF.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		'//入力可能キーの設定
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.D0 To System.Windows.Forms.Keys.D9
			Case System.Windows.Forms.Keys.Back
            Case System.Windows.Forms.Keys.Return
                '2019/04/11 CHG START
                'Call txtLMZNPF_Validating(txtLMZNPF.Item(Index), New System.ComponentModel.CancelEventArgs(Index, False))
                Call txtLMZNPF_Validating(eventSender, New System.ComponentModel.CancelEventArgs())
                '2019/04/11 CHG E N D
			Case 1 To 26
			Case Else
				KeyAscii = 0
		End Select
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	Private Sub txtLMZNPF_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txtLMZNPF.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim Index As Short = txtLMZNPF.GetIndex(eventSender)
		
		'//文字編集
		If Trim(Me.txtLMZNPF(Index).Text) = "" Then
			Me.txtLMZNPF(Index).Text = "0   "
		Else
			Me.txtLMZNPF(Index).Text = Mid(Trim(Me.txtLMZNPF(Index).Text) & "    ", 1, 4)
		End If
		
		'//優先フラグセット
		musrODINTRA.strLMZNPF(gvlngNowPage + Index) = Me.txtLMZNPF(Index).Text
		
		'//変更があるか確認しある場合は gvblnLMZNOS を True にする
		If musrODINTRA.strLMZNPF_ORG(gvlngNowPage + Index) <> musrODINTRA.strLMZNPF(gvlngNowPage + Index) Then
			gvblnLMZNOS = True
		End If
		
		eventArgs.Cancel = Cancel
	End Sub
	'// V2.20↑ ADD
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    txtMEMO
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    txtMEMO EVENT
	'//*****************************************************************************************
	Private Sub txtMEMO_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtMEMO.Enter
		
		'//GotFocus処理
		Call Set_ObjectGotFocus(txtMEMO)
		
	End Sub
	
	Private Sub txtMEMO_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txtMEMO.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'//入力可能キーの設定
		Select Case KeyAscii
			Case System.Windows.Forms.Keys.Back
			Case System.Windows.Forms.Keys.Return
			Case 1 To 26
			Case Else
				If D0.Get_TextLength(txtMEMO.Text) >= 100 Then
					KeyAscii = 0
				End If
		End Select
		
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
End Class