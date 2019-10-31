Option Strict Off
Option Explicit On
Module SYSTBA_M52
	'
	'スロット名      :メインﾌｧｲﾙ更新(月次更新)・メインファイル更新スロット
	'ユニット名      :SYSTBA.M31
	'記述者          :Standard Library
	'作成日付        :1997/01/28
	'
	Dim WM_CNT As Integer
	Dim WM_GCNT As Decimal
	
	Public WG_MONSMADT As String '月次売掛（買掛）残高設定日
	Public WG_MONSSADT As String '月次請求（支払）残高設定日
	Public WG_YERSMADT As String '今期売掛（買掛）残高設定日
	Public WG_YERSSADT As String '今期請求（支払）残高設定日
	Public WG_ZYERSMADT As String '前期売掛（買掛）残高設定日
	Public WG_ZYERSSADT As String '前期請求（支払）残高設定日
	Public WG_TRNDELDT As String 'トラン削除基準日
	Public WG_SUMDELDT As String 'サマリ削除基準日
	Public WG_ZENSMADT As String '前月売掛（買掛）残高設定日
	Public WG_YEREXCDT As String '年次更新実行判定日
	Public WG_ZZYERSMADT As String '前前期売掛（買掛）残高設定日
	Public WG_ZZYERSSADT As String '前前期請求（支払）残高設定日
	
	
	Sub BATMAN()
		'
		Call BATMFIL()
	End Sub
	
	Sub BATMFIL()
		Dim i As Short
		Dim PlStat As Integer
		'
		If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
			MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			PlStat = DB_PlFree
			FR_SSSMAIN.Enabled = True
		Else
			Call SSSWIN_EXCTBZ_OPEN()
		End If
		
		'UPGRADE_WARNING: オブジェクト CHKDATE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CHKDATE() = False Then
			Exit Sub
		End If
		' 条件設定
		G_PlCnd.nJobMode = 0
		For i = 0 To MAX_CNDARR - 1
			G_PlCnd.sCndStr(i) = New String(Chr(Asc("A") + i), 20)
			G_PlCnd.nCndNum(i) = i + 1
		Next i
		G_PlCnd.sCndStr(0) = WG_MONSMADT
		G_PlCnd.sCndStr(1) = WG_MONSSADT
		G_PlCnd.sCndStr(2) = WG_YERSMADT
		G_PlCnd.sCndStr(3) = WG_YERSSADT
		G_PlCnd.sCndStr(4) = WG_ZYERSMADT
		G_PlCnd.sCndStr(5) = WG_ZYERSSADT
		G_PlCnd.sCndStr(6) = WG_TRNDELDT
		G_PlCnd.sCndStr(7) = WG_SUMDELDT
		G_PlCnd.sCndStr(8) = WG_ZENSMADT
		G_PlCnd.sOpeID = SSS_OPEID.Value
		G_PlCnd.sCltID = SSS_CLTID.Value
		'
		G_PlInfo.FCnt = 0
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_SYSTBA")
		If PlStat <> 0 And PlStat <> 1485 Then
			MsgBox("PL/SQL Error：" & PlStat)
			Call DB_AbortTransaction()
		Else
			Call DB_EndTransaction()
			'''' ADD 2009/05/18  FKS) T.Yamamoto    Start
			'月次帳票データ作成フラグ作成処理
			Call funcWrtFlgFile()
			'''' ADD 2009/05/18  FKS) T.Yamamoto    End
			'''' ADD 2010/10/22  FKS) T.Yamamoto    Start    連絡票№824
			'月初売掛終了フラグ削除処理
			Call funcDelFlgFile()
			'''' ADD 2010/10/22  FKS) T.Yamamoto    End
		End If
		PlStat = DB_PlFree
	End Sub
	'===========================================================
	Function CHKDATE() As Object
		Dim SMAMM, SMAYY, SMADD As Integer
		Dim mm, yy, dd As Integer
		Dim W_dt As Integer
		Dim WL_WRKBUF As Object
		'UPGRADE_WARNING: オブジェクト CHKDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHKDATE = True
		Dim W_YerEXCcc As Short '年次更新実行ﾀｲﾐﾝｸﾞ
		W_YerEXCcc = 6 '年次更新実行ﾀｲﾐﾝｸﾞ(6ヶ月後、実行)
		
		WG_MONSMADT = "" '月次売掛（買掛）残高設定日
		WG_MONSSADT = "" '月次請求（支払）残高設定日
		WG_YERSMADT = "" '今期売掛（買掛）残高設定日
		WG_YERSSADT = "" '今期請求（支払）残高設定日
		WG_ZYERSMADT = "" '前期売掛（買掛）残高設定日
		WG_ZYERSSADT = "" '前期請求（支払）残高設定日
		WG_TRNDELDT = "" 'トラン削除基準日
		WG_SUMDELDT = "" 'サマリ削除基準日
		WG_ZENSMADT = "" '前月月次売掛（買掛）残高設定日
		WG_YEREXCDT = "" '年次更新実行判定日
		WG_ZZYERSMADT = "" '前前期売掛（買掛）残高設定日
		WG_ZZYERSSADT = "" '前前期請求（支払）残高設定日
		
		
		'
		' 当月締日セット
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MONUPDYM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		'
		' 月次売掛（買掛）残高設定日
		WG_MONSMADT = SSS_SMADT.Value
		If WG_MONSMADT <= DB_SYSTBA.MONUPDDT Then
			'UPGRADE_WARNING: オブジェクト CHKDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHKDATE = False
			Exit Function
		End If
		'
		' 月次請求（支払）残高設定日
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MONUPDYM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			WG_MONSSADT = VB6.Format(DateSerial(SMAYY, SMAMM, 0), "YYYYMMDD")
		Else
			WG_MONSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, SMADD), "YYYYMMDD")
		End If
		'
		' 今期売掛（買掛）残高設定日
		SSS_SMADT.Value = VB6.Format(Get_BGNAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If DB_SYSTBA.SMADD > "27" Then
			WG_YERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM + 12, SMADD - 1), "YYYYMMDD")
			WG_ZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM - 12, SMADD - 1), "YYYYMMDD")
		Else
			WG_YERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM + 12, SMADD - 1), "YYYYMMDD")
			WG_ZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSMADT = VB6.Format(DateSerial(SMAYY, SMAMM - 12, SMADD - 1), "YYYYMMDD")
		End If
		'
		' 今期請求（支払）残高設定日
		SSS_SMADT.Value = VB6.Format(Get_BGNAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If DB_SYSTBA.SMADD > "27" Then
			WG_YERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM + 11, 0), "YYYYMMDD")
			WG_ZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, 0), "YYYYMMDD")
			WG_ZZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 13, 0), "YYYYMMDD")
		Else
			WG_YERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM + 11, SMADD - 1), "YYYYMMDD")
			WG_ZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 1, SMADD - 1), "YYYYMMDD")
			WG_ZZYERSSADT = VB6.Format(DateSerial(SMAYY, SMAMM - 13, SMADD - 1), "YYYYMMDD")
		End If
		'
		'UPGRADE_WARNING: オブジェクト SSSVal(MidWid(WG_MONSMADT, 5, 2)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_YEREXCDT = CStr(DateSerial(SSSVal(LeftWid(WG_MONSMADT, 4)), SSSVal(MidWid(WG_MONSMADT, 5, 2)) - W_YerEXCcc, 1))
		WG_YEREXCDT = Get_TouAcedt(CShort(LeftWid(WG_YEREXCDT, 4)), CShort(MidWid(WG_YEREXCDT, 6, 2)))
		
		WG_YEREXCDT = DeCNV_DATE(WG_YEREXCDT)
		
		'
		If WG_ZYERSMADT > WG_YEREXCDT Then
			If WG_ZZYERSMADT <= DB_SYSTBA.YERUPDDT Then
				WG_YERSMADT = ""
			Else
				WG_YERSMADT = WG_ZZYERSMADT
				WG_YERSSADT = WG_ZZYERSSADT
				'年次更新実行
			End If
		ElseIf WG_ZYERSMADT < WG_YEREXCDT Then 
			If WG_ZYERSMADT <= DB_SYSTBA.YERUPDDT Then
				WG_YERSMADT = ""
			Else
				WG_YERSMADT = WG_ZYERSMADT
				WG_YERSSADT = WG_ZYERSSADT
				'年次更新実行
			End If
		Else
			WG_YERSMADT = WG_ZYERSMADT
			WG_YERSSADT = WG_ZYERSSADT
			'年次更新実行
		End If
		'
		'トラン削除基準日
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MONUPDYM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_TRNDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.MONUPDSC), 0), "YYYYMMDD")
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_TRNDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.MONUPDSC) - 1, SMADD), "YYYYMMDD")
		End If
		'
		' サマリ削除基準日
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MONUPDYM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_MONUPDYM = RD_SSSMAIN_MONUPDYM(0)
		SSS_SMADT.Value = VB6.Format(Get_TouAcedt(CShort(LeftWid(WG_MONUPDYM, 4)), CShort(MidWid(WG_MONUPDYM, 5, 2))), "YYYYMMDD")
		SMAYY = CInt(LeftWid(SSS_SMADT.Value, 4))
		SMAMM = CInt(MidWid(SSS_SMADT.Value, 5, 2))
		SMADD = CInt(MidWid(SSS_SMADT.Value, 7, 2))
		If SMADD > CDbl("27") Then
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_SUMDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.YERUPDSC), 0), "YYYYMMDD")
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_SUMDELDT = VB6.Format(DateSerial(SMAYY, SMAMM - SSSVal(DB_SYSTBA.YERUPDSC) - 1, SMADD), "YYYYMMDD")
		End If
		'前月前月月次売掛（買掛）残高設定日
		'UPGRADE_WARNING: オブジェクト SSSVal(MidWid(SSS_SMADT, 5, 2)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ZENSMADT = CStr(DateSerial(SSSVal(LeftWid(SSS_SMADT.Value, 4)), SSSVal(MidWid(SSS_SMADT.Value, 5, 2)) - 1, 1))
		WG_ZENSMADT = Get_TouAcedt(CShort(LeftWid(WG_ZENSMADT, 4)), CShort(MidWid(WG_ZENSMADT, 6, 2)))
		WG_ZENSMADT = DeCNV_DATE(WG_ZENSMADT)
		
	End Function
	
	'''' ADD 2009/05/18  FKS) T.Yamamoto    Start
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub funcWrtFlgFile
	'   概要：  月次帳票データ作成フラグ作成（上書き）処理
	'   引数：  なし
	'   戻値：  True : 正常     False : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub funcWrtFlgFile()
		
		Dim intFileNo As Short
		Dim strFilePath As String
		
		On Error GoTo Err_Run
		
		intFileNo = FreeFile
		strFilePath = GP_GetIni(AE_AppPath & "ENDFP51.ini", "FILEPATH", "FILE")
		
		'''' UPD 2009/07/01  FKS) T.Yamamoto    Start
		'    Open strFilePath For Output As #intFileNo
		'    Close #intFileNo
		If strFilePath = "" Then
			MsgBox("INIファイルの読込に失敗しました。" & vbCrLf & "[" & AE_AppPath & "ENDFP51.ini]", MsgBoxStyle.Critical, "INIファイル読込エラー")
			Exit Sub
		Else
			FileOpen(intFileNo, strFilePath, OpenMode.Output)
			FileClose(intFileNo)
		End If
		
		MsgBox("月次帳票データ作成フラグを作成しました。" & vbCrLf & "[" & strFilePath & "]", MB_OK, Trim(SSS_PrgNm))
		'''' UPD 2009/07/01  FKS) T.Yamamoto    End
		
		Exit Sub
		
Err_Run: 
		
		'''' ADD 2009/07/01  FKS) T.Yamamoto    Start
		MsgBox("月次帳票データ作成フラグの作成に失敗しました。" & vbCrLf & "[" & strFilePath & "]", MsgBoxStyle.Critical, "フラグファイル作成エラー")
		'''' ADD 2009/07/01  FKS) T.Yamamoto    End
		
	End Sub

    ' @(f) GP_GetIni
    '
    ' 機能      :汎用INIファイル書込サブルーチン
    '
    ' 返り値    : String
    '
    ' 引き数    :strIniName INIファイルの名前（拡張子は不要）
    '            strAppName INIファイル内のアプリケーション名
    '　　　　　　keyname　　INIファイル内のキー名
    '
    '2019/10/31 ADD START
    Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/06/12 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/06/12 CHG END
    End Function
    '2019/10/31 ADD E N D
    Function GP_GetIni(ByVal strIniName As String, ByVal strAppName As String, ByVal strKeyName As String) As String
		
		Dim strTxt As New VB6.FixedLengthString(255)
		Dim lngLen As Integer
		
		GP_GetIni = ""
		
		'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If Dir(strIniName) = "" Then
			MsgBox("対象のINIファイルが存在しません。" & vbCrLf & "[" & strIniName & "]", MsgBoxStyle.Critical, "INIファイル読込エラー")
			Exit Function
		End If
		
		'<< データPATHを取得 >>
		lngLen = GetPrivateProfileString(strAppName, strKeyName, "", strTxt.Value, 255, strIniName)
		
		On Error GoTo Error_Routine
		
		GP_GetIni = P_GetIniItem(AnsiLeftB(strTxt.Value, lngLen))
		
		Exit Function
		
Error_Routine: 
		'*MsgBox "指定したキーのエントリが存在しません。" & vbCrLf & "[" & strIniName & "]" & vbCrLf & "アプリケーション：" & strAppName & vbCrLf & "キー：" & strKeyName, vbCritical, "INIファイル読込エラー"
	End Function
	
	Function P_GetIniItem(ByVal strData As String) As String
		
		Dim strWk As String
		Dim strDummy As String
		Dim lngInstr As Integer
		Dim lngInstrRev As Integer
		
		lngInstr = 0

        'イニファイルの";"以降はコメントなので、コメントを省く。
        'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/10/31 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/10/31 CHG E N D
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'strWk = MidB(strData, 1, InStrB(strData, ";") - 1)
            strWk = MidB(strData, 1, InStr(strData, ";") - 1)
        Else
			strWk = strData
		End If
		
		lngInstr = 0
		lngInstrRev = 0
		
		'strWK=""及び、strWK=""""の場合はコメント行。
		If strWk <> "" And strWk <> """" Then
			'シングルコーテーションで囲んだ中の文字のみ取得したいので、
			'シングルコーテーションの文字位置を取得する。
			lngInstr = InStr(strWk, """")
			lngInstrRev = InStrRev(strWk, """")
			'strWkの中にシングルコーテーションが含まれているか判断する。
			If lngInstr <> lngInstrRev Then
				'シングルコーテーションが含まれていた場合。
				'シングルコーテーションで囲んだ中の文字のみ取得する。
				strDummy = Mid(strWk, lngInstr + 1, lngInstrRev - lngInstr - 1)
				
				If strDummy <> "" Then
					'戻り値のセット。
					P_GetIniItem = Trim(strDummy)
				End If
			Else
				'シングルコーテーションが含まれていない場合。
				If Trim(strWk) <> "" Then
					'戻り値のセット
					P_GetIniItem = Trim(strWk)
				End If
			End If
		Else
			P_GetIniItem = ""
		End If
		
	End Function
    '2019/10/31 DEL START
    '   Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
    '	'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '	'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
    'End Function
    '2019/10/31 DEL E N D
    ' StrConv を呼び出します。
    Function AnsiStrConv(ByRef StrArg As Object, ByRef flag As Object) As Object
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト flag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト StrArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(StrArg, flag)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = StrArg
#End If
		
	End Function
	'''' ADD 2009/05/18  FKS) T.Yamamoto    End
	
	'''' ADD 2010/10/22  FKS) T.Yamamoto    Start    連絡票№824
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub funcDelFlgFile
	'   概要：  月初売掛終了フラグ削除処理
	'   引数：  なし
	'   戻値：  True : 正常     False : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub funcDelFlgFile()
		
		Dim intFileNo As Short
		Dim strFilePath As String
		
		On Error GoTo Err_Run
		
		intFileNo = FreeFile
		strFilePath = GP_GetIni(AE_AppPath & "ENDFP51.ini", "FILEPATH2", "FILE")
		
		If strFilePath = "" Then
			MsgBox("INIファイルの読込に失敗しました。" & vbCrLf & "[" & AE_AppPath & "ENDFP51.ini]", MsgBoxStyle.Critical, "INIファイル読込エラー")
			Exit Sub
		Else
			'UPGRADE_WARNING: Dir に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
			If Dir(strFilePath) <> "" Then
				Kill((strFilePath))
			End If
		End If
		
		MsgBox("月初売掛終了フラグを削除しました。" & vbCrLf & "[" & strFilePath & "]", MB_OK, Trim(SSS_PrgNm))
		
		Exit Sub
		
Err_Run: 
		
		MsgBox("月初売掛終了フラグの削除に失敗しました。" & vbCrLf & "[" & strFilePath & "]", MsgBoxStyle.Critical, "フラグファイル削除エラー")
		
	End Sub
	'''' ADD 2010/10/22  FKS) T.Yamamoto    End
End Module