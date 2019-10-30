Option Strict Off
Option Explicit On
Module SSSMAIN_PR2
	
	
	'
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	'for ＮｅｗＲＲＲ ＶＡ０３                                                             '
	'                                                                             --2001.10 '
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
	Sub CNT_GAUGE()
		'
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).ForeColor = System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_WHITE)
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 100
		System.Windows.Forms.Application.DoEvents()
	End Sub
	
	Function FSTART_GetEvent() As Short
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			FSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_FILE
		If SSS_ExportFLG Then
			Call SSS_Export()
		Else
			Call SSS_LIST(SSS_FILE)
		End If
	End Function
	
	Function LCANCEL_GetEvent() As Object
		SSS_LSTOP = True
		'UPGRADE_WARNING: オブジェクト LCANCEL_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		LCANCEL_GetEvent = True
	End Function
	
	Function LCONFIG_GetEvent() As Short
		' プリンター設定
		LCONFIG_GetEvent = True
		WLS_PRN.ShowDialog()
	End Function
	
	Function LSTART_GetEvent() As Short
		'#Start/2001.11.28
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			LSTART_GetEvent = False
			Exit Function
		End If
		'#End/2001.11.28
		LSTART_GetEvent = True
		SSS_Makkb = SSS_PRINTER
		Call SSS_LIST(SSS_PRINTER)
	End Function
	
	Function MNSTART_GetEvent() As Short
		MNSTART_GetEvent = True
		Call INQ_LIST()
	End Function
	
	Sub SSS_CLOSE()
		'
		Call CRW_CLOSE()
		Call CRW_END()
		'
		Call DB_RESET()
		Call DB_End()
		'
		System.Windows.Forms.Application.DoEvents()
		'
		On Error Resume Next
	End Sub
	
	Sub SSS_Export()
		Dim Rtn As Short
		Dim wkRptId As String
		'
		Call WORKING_VIEW(True)
		' クリスタルレポートのオープン
		If CRW_INIT() = False Then
			Call Error_Exit("ERROR CRW_INIT")
		Else
			'伝票種別によるRPTファイルの選択(オプションユニットなどでSYSTBIを読んでおく)
			If Trim(SSS_RPTID) = "" Then
				wkRptId = SSS_PrgId
			Else
				wkRptId = SSS_RPTID
			End If
			If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & wkRptId & ".RPT") = False Then
				Call Error_Exit("ERROR CRW_OPEN")
			End If
		End If
		
		'出力状態のチェックのための区分をクリア
		SSS_OUTKB = 0
		
		'
		Call Set_Value()
		'
		If CRW_DOCHECK() = False Then
			MsgBox("他で実行中の為、実行できません。", MB_ICONEXCLAMATION)
			'
			Call CRW_CLOSE()
			'
			Call WORKING_VIEW(False)
			Exit Sub
		End If
		'
		SSS_LSTOP = False
		SSS_MFILCNT = 0
		SSS_LFILCNT = 0
		'
		If SSS_ExportFileKB Then GoTo Next_Proc
		'
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting '矢印と砂時計を表示
		
		Call Loop_Mfil()
		'
		' キャンセル処理
		If SSS_LSTOP = True Then
			Call WORKING_VIEW(False)
			'
			Call CRW_CLOSE()
			'
			Exit Sub
		End If
        '
        '参照先を切り替える
        'Rtn = Crw_ChgLoc
        If Rtn = 0 Then
			MsgBox("CRW_PRINT.CRW_STATUS : " & Rtn & Chr(13) & CRW_GETERRMSG(HCRW))
			Exit Sub
		End If
		
		If SSS_LFILCNT = 0 Then
			'メッセージ格納変数に文字が入っていればそれを表示。
			If Trim(SSS_Message) <> "" Then
				Call MsgBox(SSS_Message, MsgBoxStyle.Information)
				Call WORKING_VIEW(False)
				Call CRW_CLOSE()
				Exit Sub
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				Call WORKING_VIEW(False)
				Call CRW_CLOSE()
				Exit Sub
			End If
		Else
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
			Call WORKING_VIEW(False)
			If Rtn = False Then
				Error_Exit(("ERROR SSS_LIST 出力先選択 RTN=[" & Str(Rtn) & "]"))
			Else
				On Error Resume Next
				Kill(SSS_CRWOPATH & SSS_PrgId & ".TXT")
				On Error GoTo 0
				FR_SSSMAIN.Enabled = False
				System.Windows.Forms.Application.DoEvents()
				Rtn = PEDiscardSavedData(HCRW)
				If SSS_ExportFileName = vbNullString Then SSS_ExportFileName = SSS_PrgId '(1998/11/19 追加）
				If reportExportX(HCRW, SSS_CRWOPATH & SSS_ExportFileName & "." & SSS_ExportFileEXT & Chr(0), SSS_ExportFileType, 0, SSS_ExportSep & Chr(0), SSS_ExportQuat & Chr(0)) <> 1 Then
					Rtn = DSP_MsgBox(SSS_ERROR, "CANTDELFILE", 0)
					Call WORKING_VIEW(False)
					Error_Exit(("ERROR SSS_LIST CRW_PRINT"))
				End If
				
				'出力状態のチェックのための区分をセット
				SSS_OUTKB = SSS_FILE
				'
			End If
			Call WORKING_VIEW(False)
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
			Do While CRW_VIEWCHECK()
                '2019/10/23 CHG START
                'Call Sleep(200)
                Call System.Threading.Thread.Sleep(200)
                '2019/10/23 CHG E N D
                System.Windows.Forms.Application.DoEvents()
			Loop 
			FR_SSSMAIN.Enabled = True
			System.Windows.Forms.Application.DoEvents()
			
		End If
		'
Next_Proc: 
		Call WORKING_VIEW(False)
		''
		If SSS_DYNASQL Then
			'PR2系帳票でダイナミックなSQL文を使う場合
			Call DB_Execute(SSS_LSTMFIL, "DROP TABLE " & Get_DBHEAD() & "_" & Trim(DB_PARA(SSS_LSTMFIL).DBID) & "." & SSS_PrgId & "_" & SSS_CLTID.Value)
		End If
		''
		Call CRW_CLOSE()
		Call Chain_Proc()
	End Sub
	
	Sub SSS_LIST(ByRef LSTKB As Short)
		Dim Rtn As Short
		Dim wkRptId As String
		Dim wkWindowOption As T_PEWindowOptions
		Dim wkPrintOption As T_PEPrintOptions
		Dim wkWidth, wkTop, wkLeft, wkHeight As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		'Dim StartTime, PointTime, Time1, Time2, Time3      '計測用
		'Dim msg1$                                          '計測用
		
		'出力処理中に再度出力処理を呼ぶとエラーになるためボタンを非表示にする
		CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
		CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = False
		CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
		'StartTime = Timer
		'PointTime = Timer
		Call WORKING_VIEW(True)
		' クリスタルレポートのオープン
		If CRW_INIT() = False Then
			Call Error_Exit("ERROR CRW_INIT")
		Else
			'伝票種別によるRPTファイルの選択(オプションユニットなどでSYSTBIを読んでおく)
			If Trim(SSS_RPTID) = "" Then
				wkRptId = SSS_PrgId
			Else
				wkRptId = SSS_RPTID
			End If
			If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & wkRptId & ".RPT") = False Then
				Call Error_Exit("ERROR CRW_OPEN")
			End If
		End If
		
		'出力状態のチェックのための区分をクリア
		SSS_OUTKB = 0
		'
		Call Set_Value()
		'
		If CRW_DOCHECK() = False Then
			MsgBox("他で印刷中の為、実行できません。", MB_ICONEXCLAMATION)
			'
			'出力処理中に再度出力処理を呼ぶとエラーになるため非表示にしていたボタンを表示にする
			'CHG START FKS)INABA 2006/11/15******************************************************************
			'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
			If gs_PRTAUTH = "1" Then '印刷権限有り
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			End If
			If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			End If
			'        FR_SSSMAIN!CM_LSTART.Visible = True
			'        FR_SSSMAIN!CM_VSTART.Visible = True
			'        FR_SSSMAIN!CM_FSTART.Visible = True
			
			'CHG  END  FKS)INABA 2006/11/15******************************************************************
			Call CRW_CLOSE()
			'
			Call WORKING_VIEW(False)
			Exit Sub
		End If
		SSS_LSTOP = False
		SSS_MFILCNT = 0
		SSS_LFILCNT = 0
		'
		'Debug.Print "    印刷データの SQL への出力を開始するまでの時間:" & Str$(Timer - PointTime)
		'Time1 = Timer - PointTime
		'PointTime = Timer
		Call Loop_Mfil()
		
		'Debug.Print "    印刷データを SQL に出力するのに要した時間" & chr(9) & ": " & Str$(Timer - PointTime)
		'Time2 = Timer - PointTime
		'PointTime = Timer
		'キャンセル処理
		If SSS_LSTOP = True Then
			Call WORKING_VIEW(False)
			'
			'出力処理中に再度出力処理を呼ぶとエラーになるため非表示にしていたボタンを表示にする
			'CHG START FKS)INABA 2006/11/15******************************************************************
			'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
			If gs_PRTAUTH = "1" Then '印刷権限有り
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			End If
			If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
			Else
				CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
				CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
			End If
			'        FR_SSSMAIN!CM_LSTART.Visible = True
			'        FR_SSSMAIN!CM_VSTART.Visible = True
			'        FR_SSSMAIN!CM_FSTART.Visible = True
			
			'CHG  END  FKS)INABA 2006/11/15******************************************************************
			Call CRW_CLOSE()
			'
			Exit Sub
		End If
		'
		If SSS_LFILCNT = 0 Then
			'メッセージ格納変数に文字が入っていればそれを表示。
			If Trim(SSS_Message) <> "" Then
				Call MsgBox(SSS_Message, MsgBoxStyle.Information)
				Call WORKING_VIEW(False)
			Else
				Rtn = DSP_MsgBox(SSS_ERROR, "RNOTFOUND", 0)
				Call WORKING_VIEW(False)
			End If
		Else
			'ダイアログによりプリンタ切替えをされたものを再設定する。
			'専用帳票の場合クリスタルレポートのユーザー定義を優先する。
			'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
			If IsDbNull(SSS_Lconfig) Then SSS_Lconfig = ""
            'If SSS_Lconfig <> "USR" Then Call CRW_SET_PRINTER()
            Select Case LSTKB
				Case SSS_PRINTER
					
					Rtn = CRW_PUTPRINTER()
					'印刷部数の指定
					wkPrintOption.StructSize = PE_SIZEOF_PRINT_OPTIONS
					Rtn = PEGetPrintOptions(HCRW, wkPrintOption)
					wkPrintOption.StartPageN = SSS_StartPageNo
					wkPrintOption.stopPageN = SSS_StopPageNo
					wkPrintOption.nReportCopies = SSS_Copies
					If SSS_Copies > 1 Then
						wkPrintOption.collation = IIf((SSS_Collation = 1), PE_COLLATED, PE_UNCOLLATED)
					End If
					Rtn = PESetPrintOptions(HCRW, wkPrintOption)
				Case SSS_VIEW
					'プレビュー画面のデフォルトサイズを指定
					Rtn = GetPrivateProfileString("REPORT", "CRW_LEFT", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkLeft = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_TOP", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkTop = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_HEIGHT", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkHeight = Int(CDbl(Left(wkStr.Value, Rtn)))
					Rtn = GetPrivateProfileString("REPORT", "CRW_WIDTH", "", wkStr.Value, 128, "SSSWIN.INI")
					If Rtn > 0 Then wkWidth = Int(CDbl(Left(wkStr.Value, Rtn)))
					
					'正確性チェック
					If wkTop <= 0 Or wkTop >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkTop = 0
					If wkLeft <= 0 Or wkLeft >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkLeft = 0
					If wkWidth <= 0 Or wkWidth >= VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15
					If wkHeight <= 0 Or wkHeight >= VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15
					If wkLeft + wkWidth > VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 Then wkWidth = VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) / 15 - wkLeft
					If wkTop + wkHeight > VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 Then wkHeight = VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) / 15 - wkHeight
					'
					Rtn = CRW_PUTWINDOW(CStr(FR_SSSMAIN.Text) & "･ﾚﾎﾟｰﾄ", wkLeft, wkTop, wkWidth, wkHeight)
					'プレビュー画面でのボタン表示／非表示
					wkWindowOption.StructSize = PE_SIZEOF_WINDOW_OPTIONS
					Rtn = PEGetWindowOptions(HCRW, wkWindowOption)
					'CHG START FKS)INABA 2006/11/15******************************************************************
					'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
					If gs_PRTAUTH = "1" Then '印刷権限有り
						wkWindowOption.hasPrintButton = 1
						wkWindowOption.hasPrintSetupButton = 1
					Else
						wkWindowOption.hasPrintButton = 0
						wkWindowOption.hasPrintSetupButton = 0
					End If
					If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
						wkWindowOption.hasExportButton = 1
					Else
						wkWindowOption.hasExportButton = 0
					End If
					
					'wkWindowOption.hasPrintButton = IIf((SSS_Hide_Prnbutton), 0, 1)
					'wkWindowOption.hasExportButton = IIf((SSS_Hide_Expbutton), 0, 1)
					'wkWindowOption.hasPrintSetupButton = IIf((SSS_Hide_Prnset), 0, 1)
					'CHG  END  FKS)INABA 2006/11/15******************************************************************
					
					Rtn = PESetWindowOptions(HCRW, wkWindowOption)
				Case SSS_FILE
					Rtn = CRW_SETEXPATR()
			End Select
			If Rtn = False Then
				Error_Exit(("ERROR SSS_LIST 出力先選択 RTN=[" & Str(Rtn) & "]"))
			End If
			If Rtn = True Or Rtn = 1 Then
				FR_SSSMAIN.Enabled = False
				System.Windows.Forms.Application.DoEvents()
                'If CRW_PRINT() = False Then Error_Exit(("ERROR SSS_LIST CRW_PRINT"))
                '出力状態のチェックのための区分をセット
                SSS_OUTKB = LSTKB
				'
			ElseIf Rtn <> PE_ERR_USERCANCELLED Then 
				'CRWでエラーが発生した場合
				Rtn = MsgBox("SSS_LISTでCRWエラーが発生しました：[" & Str(Rtn) & "]")
				Error_Exit(("ERROR SSS_LIST 出力先選択 RTN=[" & Str(Rtn) & "]"))
			End If
			Call WORKING_VIEW(False)
            'Debug.Print "    クリスタルレポートが出力に要した時間" & chr(9) & chr(9) & ": " & Str$(Timer - PointTime)
            'Time3 = Timer - PointTime
            'Debug.Print "トータルで画面表示に要した時間" & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            'Debug.Print ""
            'msg1$ = "印刷データの Jet への出力を開始するまでの時間" & Chr(9) & ": " & Str$(Time1) & Chr(13)
            'msg1$ = msg1$ + "印刷データを Jet に出力するのに要した時間" & Chr(9) & ": " & Str$(Time2) & Chr(13)
            'msg1$ = msg1$ + "クリスタルレポートが出力に要した時間" & Chr(9) & Chr(9) & ": " & Str$(Time3) & Chr(13)
            'msg1$ = msg1$ + "画面表示に要した時間" & Chr(9) & Chr(9) & Chr(9) & ": " & Str$(Timer - StartTime)
            'MsgBox msg1$
            Do While CRW_VIEWCHECK()
                '2019/10/23 CHG START
                'Call Sleep(200)
                Call System.Threading.Thread.Sleep(200)
                '2019/10/23 CHG E N D
                System.Windows.Forms.Application.DoEvents()
            Loop
            FR_SSSMAIN.Enabled = True
			System.Windows.Forms.Application.DoEvents()
		End If
		'
		'出力処理中に再度出力処理を呼ぶとエラーになるため非表示にしていたボタンを表示にする
		'CHG START FKS)INABA 2006/11/15******************************************************************
		'先に取得した権限により、Preview画面の印刷ボタン、プリンタ設定ボタン、ファイル出力ボタンを制御する
		If gs_PRTAUTH = "1" Then '印刷権限有り
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
		Else
			CType(FR_SSSMAIN.Controls("CM_LSTART"), Object).Visible = False
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
		End If
		If gs_FILEAUTH = "1" Then 'ファイル出力権限有り
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = True
		Else
			CType(FR_SSSMAIN.Controls("CM_VSTART"), Object).Visible = True
			CType(FR_SSSMAIN.Controls("CM_FSTART"), Object).Visible = False
		End If
		'        FR_SSSMAIN!CM_LSTART.Visible = True
		'        FR_SSSMAIN!CM_VSTART.Visible = True
		'        FR_SSSMAIN!CM_FSTART.Visible = True
		
		'CHG  END  FKS)INABA 2006/11/15******************************************************************
		''
		If SSS_DYNASQL Then
			'PR2系帳票でダイナミックなSQL文を使う場合
			Call DB_Execute(SSS_LSTMFIL, "DROP TABLE " & Get_DBHEAD() & "_" & Trim(DB_PARA(SSS_LSTMFIL).DBID) & "." & SSS_PrgId & "_" & SSS_CLTID.Value)
		End If
		''
		Call CRW_CLOSE()
		
	End Sub
	
	Function SSSMAIN_Append() As Object
		'ファイルにカレントレコードの追加処理を行う。
		Call INQ_LIST()
		'印字条件をｸﾘｱしない
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Append の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Append = 1
	End Function
	
	Function SSSMAIN_BeginPrg() As Object
        '画面表示前の初期設定処理を行う。
        'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
        '2019/10/23 CHG START
        'If App.PrevInstance Then
        '    MsgBox("【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
        '    End
        'End If
        '2019/10/23 CHG E N D
        ' "しばらくお待ちください" ウィンドウ表示
        'UPGRADE_ISSUE: Load ステートメント はサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' をクリックしてください。
        '2019/10/23 CHG START
        'Load(ICN_ICON)
        ICN_ICON.Show()
        '2019/10/23 CHG E N D
        'UPGRADE_WARNING: オブジェクト SSSMAIN_BeginPrg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        SSSMAIN_BeginPrg = True
		SSS_ExportFLG = False '初期値：印刷処理
		'----------------------------------
		'   SSSWIN プログラム起動チェック
		'----------------------------------
		Call SSSWIN_INIT()
		Call SSSWIN_OPEN()
		'
		'デフォルト用紙サイズと印刷の向きを読み取り
		Call Set_defaultPrintInfo()
		
		Call InitDsp()
		' "しばらくお待ちください" ウィンドウ消去
		ICN_ICON.Close()
	End Function
	
	Function SSSMAIN_Close() As Object
		'終了時の後処理を行う。
		Call SSSWIN_CLOSE()
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Close = True
	End Function
	
	Function SSSMAIN_Current() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Current の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Current = 0
	End Function
	
	Function SSSMAIN_Init() As Object
		'
		Call WORKING_VIEW(False)
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Init の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Init = True
	End Function
	
	Function SSSMAIN_Last() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Last の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Last = 0
	End Function
	
	Function SSSMAIN_Next() As Object
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Next の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Next = 0
	End Function
	
	Function SSSMAIN_Select() As Object
		'処理対象のデータの範囲を設定する。
		'SSSMAIN_Select = SET_GAMEN_KEY()
	End Function
	
	Function SSSMAIN_Update() As Object
		'ファイルの中のカレントレコードの更新を行う。
		Dim Wk As Object
		'MsgBox "データを更新しました。"
		'UPGRADE_WARNING: オブジェクト SSSMAIN_Update の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSSMAIN_Update = 9
	End Function
	
	Function VSTART_GetEvent() As Short
		'
		VSTART_GetEvent = True
		'
		'#Start/2002.1.23
		If CP_SSSMAIN(PP_SSSMAIN.Px).StatusC = Cn_Status1 Then
			Call AE_SetCheck_SSSMAIN(AE_Val2(CP_SSSMAIN(PP_SSSMAIN.Px)), Cn_Status6, True)
		End If
		Call AE_RecalcAll_SSSMAIN()
		If AE_CompleteCheck_SSSMAIN(0) <> 0 Then
			Call AE_CursorSub_SSSMAIN(Cn_CuInCompletePx)
			PP_SSSMAIN.CursorSet = True
			VSTART_GetEvent = False
			Exit Function
		End If
		'#End/2002.1.23
		SSS_Makkb = SSS_VIEW
		Call SSS_LIST(SSS_VIEW)
		'
	End Function
	
	Sub WLS_SLIST_MOVE(ByVal SlistCom As Object, ByVal LENGTH As Short)
		'UPGRADE_WARNING: オブジェクト SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		PP_SSSMAIN.SlistCom = LeftWid(SlistCom, LENGTH)
	End Sub
	
	Sub WORKING_VIEW(ByRef Sw As Short)
		'ゲージの表示 etc...
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.FloodPercent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CType(FR_SSSMAIN.Controls("GAUGE"), Object).FloodPercent = 0
		If Sw Then
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor '砂時計
            '2019/10/23 DEL START
            'Call AE_StatusOut(PP_SSSMAIN, "作業中！ しばらくお待ちください。", System.Drawing.ColorTranslator.ToOle(SSSMSG_BAS.Cn_BLUE))
            '2019/10/23 DEL E N D
            'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = True
			'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CM_LCANCEL.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = True
		Else
			'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
			System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default '既定値
			CType(FR_SSSMAIN.Controls("TX_Message"), Object).Text = ""
			'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!GAUGE.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(FR_SSSMAIN.Controls("GAUGE"), Object).Visible = False
			'UPGRADE_WARNING: オブジェクト FR_SSSMAIN!CM_LCANCEL.Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CType(FR_SSSMAIN.Controls("CM_LCANCEL"), Object).Visible = False
		End If
		System.Windows.Forms.Application.DoEvents()
	End Sub
End Module