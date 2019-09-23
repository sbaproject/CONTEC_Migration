Option Strict Off
Option Explicit On
Module UDNTRA_M52
	'
	' スロット名        : 売上トラン・メインファイル更新スロット(PL/SQL対応)
	' ユニット名        : UDNTRA.M52
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/11
	' 使用プログラム名  : URIET54
	'
	
	Function DELTRN() As Short
	End Function
    '2019/09/219 DELL START
    'Function WRTTRN() As Short
    '    Dim I As Short
    '    Dim PlStat As Integer

    '     Dim FILE1_PATH As String
    '     Dim lngFileNo1 As Integer
    '
    '    FR_SSSMAIN.Enabled = False

    'ADD START FKS)INABA 2009/11/19 *********************
    '連絡票№758
    '    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '        MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '        WRTTRN = False
    '        PlStat = DB_PlFree()
    '        FR_SSSMAIN.Enabled = True
    '       Exit Function
    '    Else
    '        Call SSSWIN_EXCTBZ_OPEN()
    '    End If
    '   'ADD  END  FKS)INABA 2009/11/19 *********************
    '   ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される

    '   G_PlCnd.nJobMode = 0

    '    '20080910 ADD START RISE)Tanimura '排他処理
    '    Call DB_BeginTransaction(CStr(BTR_Exclude))

    '    ' 排他更新時間チェック
    '   'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    If CHK_HAITA_UPD() = 0 Then
    '        ' エラー
    '        Call DSP_MsgBox(SSS_ERROR, "URIET54_001", 0) '他のプログラムで更新されたため、登録できません。
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '        Exit Function
    '    End If
    '    '20080910 ADD END   RISE)Tanimura
    '       'ADD START FKS)INABA 2009/07/03 **************************
    '       '連絡票№739
    '    Dim lw_ret As Short
    '    'UPGRADE_WARNING: オブジェクト CHK_UNYDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    lw_ret = CHK_UNYDT(DB_UNYMTA.UNYDT)
    '   If lw_ret <> 0 Then
    '        Call DSP_MsgBox(SSS_ERROR, "DATE_2", 0) '運用日が変更されました。メニューに戻ってください。。
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '        Exit Function
    '   End If
    '    'ADD  END  FKS)INABA 2009/07/03 **************************
    '    For I = 0 To MAX_CNDARR - 1
    '        G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '        G_PlCnd.nCndNum(I) = I + 1
    '    Next I

    '    G_PlCnd.sOpeID = SSS_OPEID.Value
    '    G_PlCnd.sCltID = SSS_CLTID.Value

    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(0) = RD_SSSMAIN_DATNO(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(1) = RD_SSSMAIN_MEIKBA(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(2) = RD_SSSMAIN_MEIKBB(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(3) = RD_SSSMAIN_MEIKBC(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SRANO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(4) = RD_SSSMAIN_SRANO(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(5) = RD_SSSMAIN_SOUCD(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTSOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(6) = RD_SSSMAIN_OUTSOUCD(0)
    '    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    G_PlCnd.sCndStr(7) = RD_SSSMAIN_HENRSNCD(0)
    '    '20090115 ADD START RISE)Tanimura '連絡票No.523
    '    G_PlCnd.sCndStr(8) = g_strURIKB
    '    '20090115 ADD END   RISE)Tanimura

    '    G_PlInfo.FCnt = 2
    '    G_PlInfo.Fno(0) = DBN_UDNTRA
    '   G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    G_PlInfo.ArrayFlg(0) = 1
    '    G_PlInfo.Fno(1) = DBN_UDNTHA
    '    G_PlInfo.RCnt(1) = 1
    '    G_PlInfo.ArrayFlg(1) = 0
    '
    '   '売上見出しトラン
    '    Call UDNTHA_RClear()
    '    Call UDNTHA_FromSCR(-1)
    '    DB_UDNTHA.DATKB = "1"
    '    DB_UDNTHA.DENKB = "1"
    '    DB_UDNTHA.AKAKROKB = "9"
    '    DB_UDNTHA.SMADT = SSS_SMADT.Value
    '    DB_UDNTHA.SSADT = SSS_SSADT.Value
    '    DB_UDNTHA.KESDT = SSS_KESDT.Value
    '    DB_UDNTHA.UDNPRBKB = "9"
    '    '''' ADD 2009/04/27  FKS) S.Nakajima    Start
    '   'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    DB_UDNTHA.MOTDATNO = RD_SSSMAIN_DATNO(-1)
    '    '''' ADD 2009/04/27  FKS) S.Nakajima    End
    '
    '    PlStat = DB_PlStart()
    '    PlStat = DB_PlCndSet()
    '    PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '    I = 0
    '    Do While I < PP_SSSMAIN.LastDe
    '        '売上トラン
    '       '2019/09/19 DEL START
    '       'Call UDNTRA_RClear()
    '       '2019/09/19 DEL E N D
    '        Call Mfil_FromSCR(I)
    '        DB_UDNTRA.DATKB = "1"
    '        DB_UDNTRA.DENKB = "1"
    '        DB_UDNTRA.AKAKROKB = "9"
    '        DB_UDNTRA.SMADT = SSS_SMADT.Value
    '        DB_UDNTRA.SSADT = SSS_SSADT.Value
    '        DB_UDNTRA.KESDT = SSS_KESDT.Value
    '        DB_UDNTRA.DKBSB = WG_DKBSB
    '        '2007/03/21 ADD-START
    '       'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        DB_UDNTRA.HENRSNCD = RD_SSSMAIN_HENRSNCD(0)
    '        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENSTTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        DB_UDNTRA.HENSTTCD = RD_SSSMAIN_HENSTTCD(0)
    '        '2007/03/21 ADD-END

    '       ''' ADD 2009/04/27  FKS) S.Nakajima    Start
    '       'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        DB_UDNTRA.MOTDATNO = RD_SSSMAIN_DATNO(I)
    '        '''' ADD 2009/04/27  FKS) S.Nakajima    End
    '        PlStat = DB_PlSet(DBN_UDNTRA, I)

    '        I = I + 1
    '   Loop

    '   '20080910 DEL START RISE)Tanimura '排他処理
    '    Call DB_BeginTransaction(BTR_Exclude)
    '   '20080910 DEL END   RISE)Tanimura
    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    If PlStat <> 0 And PlStat <> 1485 Then
    '        MsgBox("PL/SQL Error：" & PlStat)
    '        WRTTRN = False
    '        DB_AbortTransaction()
    '    Else
    '        WRTTRN = True
    '        Call DB_EndTransaction()
    '        ' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
    '        Call SSSWIN_Unlock_EXCTBZ()
    '        ' === 20130708 === INSERT E -
    '   End If
    '    PlStat = DB_PlFree()

    '    'シリアル№登録ワークの削除
    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
    '    Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
    '        Call DB_Delete(DBN_SRAET52)
    '        Call DB_GetNext(DBN_SRAET52, BtrNormal)
    '    Loop
    '    Call DB_EndTransaction()

    '    '20080910 ADD START RISE)Tanimura '排他処理
    '   ' クリア
    '    Erase M_SRACNTTB_MOTO_inf

    '    ReDim M_SRACNTTB_MOTO_inf(0)
    '    '20080910 ADD END   RISE)Tanimura

    '   'INIファイル取得用関数
    '    FILE1_PATH = GP_GetIni(AE_AppPath & "URIET54.ini", "FILEPATH", "FILE1")
    '    lngFileNo1 = FreeFile()
    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    FileClose(lngFileNo1)

    '    FR_SSSMAIN.Enabled = True

    'End Function
    '2019/09/219 DELL E N D

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
		
		Dim strWK As String
		Dim strDummy As String
		Dim lngInstr As Integer
		Dim lngInstrRev As Integer
		
		lngInstr = 0

        'イニファイルの";"以降はコメントなので、コメントを省く。
        'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/09/19 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/09/19 CHG E N D
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/09/19 CHG START
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            '2019/09/19  CHG E N D
        Else
			strWK = strData
		End If
		
		lngInstr = 0
		lngInstrRev = 0
		
		'strWK=""及び、strWK=""""の場合はコメント行。
		If strWK <> "" And strWK <> """" Then
			'シングルコーテーションで囲んだ中の文字のみ取得したいので、
			'シングルコーテーションの文字位置を取得する。
			lngInstr = InStr(strWK, """")
			lngInstrRev = InStrRev(strWK, """")
			'strWkの中にシングルコーテーションが含まれているか判断する。
			If lngInstr <> lngInstrRev Then
				'シングルコーテーションが含まれていた場合。
				'シングルコーテーションで囲んだ中の文字のみ取得する。
				strDummy = Mid(strWK, lngInstr + 1, lngInstrRev - lngInstr - 1)
				
				If strDummy <> "" Then
					'戻り値のセット。
					P_GetIniItem = Trim(strDummy)
				End If
			Else
				'シングルコーテーションが含まれていない場合。
				If Trim(strWK) <> "" Then
					'戻り値のセット
					P_GetIniItem = Trim(strWK)
				End If
			End If
		Else
			P_GetIniItem = ""
		End If
		
	End Function
	
	Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Integer) As String
        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/09/19 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/09/19 CHG E N D
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/09/19 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/09/19 CHG E N D
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiLenB = LenB(StrArg)
#End If
    End Function
	
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
End Module