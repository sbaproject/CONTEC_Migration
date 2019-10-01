Option Strict Off
Option Explicit On
Module UDNTRA_M53
    '
    ' スロット名        : 売上トラン・メインファイル更新スロット(PL/SQL対応)
    ' ユニット名        : UDNTRA.M53
    ' 記述者            : Standard Library
    ' 作成日付          : 2006/09/22
    ' 使用プログラム名  : URIET52
    '
    '20190726 DELL START
    'Function WRTTRN() As Short
    '    '2019/06/05 DELL START
    '    'Dim I As Short
    '    'Dim PlStat As Integer
    '    'Dim wkTOKCD As String

    '    'Dim EXEPATH As String
    '    'Dim FILE1_PATH As String
    '    'Dim lngFileNo1 As Integer
    '    ''
    '    'FR_SSSMAIN.Enabled = False

    '    '' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される

    '    ''''    If WG_DSPKB = 2 Then
    '    ''''        G_PlCnd.nJobMode = 0
    '    ''''    End If

    '    'If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '    '    MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, SSS_PrgNm)
    '    '    WRTTRN = False
    '    '    PlStat = DB_PlFree()
    '    '    FR_SSSMAIN.Enabled = True

    '    '    'シリアル№登録ワークの削除
    '    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    '    Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '    '    Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '    '        Call DB_Delete(DBN_SRAET53)
    '    '        Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '    '    Loop
    '    '    Call DB_EndTransaction()

    '    '    Exit Function
    '    'Else
    '    '    Call SSSWIN_EXCTBZ_OPEN()
    '    'End If

    '    'For I = 0 To MAX_CNDARR - 1
    '    '    G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '    '    G_PlCnd.nCndNum(I) = I + 1
    '    'Next I

    '    'G_PlCnd.sOpeID = SSS_OPEID.Value
    '    'G_PlCnd.sCltID = SSS_CLTID.Value
    '    'G_PlCnd.nCndNum(9) = -9999 'PL/SQLでコミットしない

    '    'G_PlInfo.FCnt = 4
    '    'G_PlInfo.Fno(0) = DBN_UDNTRA
    '    'G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    'G_PlInfo.ArrayFlg(0) = 1
    '    'G_PlInfo.Fno(1) = DBN_UDNTHA
    '    'G_PlInfo.RCnt(1) = 1
    '    'G_PlInfo.ArrayFlg(1) = 0
    '    'G_PlInfo.Fno(2) = DBN_FDNTRA
    '    'G_PlInfo.RCnt(2) = PP_SSSMAIN.LastDe
    '    'G_PlInfo.ArrayFlg(2) = 1
    '    'G_PlInfo.Fno(3) = DBN_FDNTHA
    '    'G_PlInfo.RCnt(3) = 1
    '    'G_PlInfo.ArrayFlg(3) = 0
    '    ''
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(0) = RD_SSSMAIN_TOKCD(-1)
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(1) = RD_SSSMAIN_NHSCD(-1)
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(2) = RD_SSSMAIN_TANCD(-1)

    '    'Call TOKMTA_RClear()
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKCD) - Len(RD_SSSMAIN_TOKCD(-1)))
    '    'Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SSADT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMADT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT And (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then
    '    '    G_PlCnd.sCndStr(3) = "1" '当月度内
    '    'Else
    '    '    G_PlCnd.sCndStr(3) = "0" '前月度
    '    'End If
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(4) = RD_SSSMAIN_DATNO(-1)
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(5) = RD_SSSMAIN_UDNDT(-1)
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'G_PlCnd.sCndStr(6) = RD_SSSMAIN_DENDT(-1)
    '    'G_PlCnd.sCndStr(7) = SSS_SMADT.Value
    '    'G_PlCnd.sCndStr(8) = SSS_SSADT.Value
    '    'G_PlCnd.sCndStr(9) = SSS_KESDT.Value
    '    ''
    '    'Call UDNTHA_RClear()
    '    'Call UDNTHA_FromSCR(-1)
    '    'DB_UDNTHA.DATKB = "1"
    '    'DB_UDNTHA.DENKB = "1"
    '    'DB_UDNTHA.UDNPRAKB = "9"
    '    'DB_UDNTHA.UDNPRBKB = "9"
    '    'DB_UDNTHA.SMADT = SSS_SMADT.Value
    '    'DB_UDNTHA.SSADT = SSS_SSADT.Value
    '    'DB_UDNTHA.KESDT = SSS_KESDT.Value
    '    'Dim WK_FDNNO As String
    '    ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    'WK_FDNNO = RD_SSSMAIN_FDNNO(-1)


    '    '' 緊急出荷基準
    '    'If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '    '    DB_UDNTHA.EMGODNKB = "9"
    '    'Else
    '    '    DB_UDNTHA.EMGODNKB = "1"
    '    'End If
    '    ''
    '    'PlStat = DB_PlStart()
    '    'PlStat = DB_PlCndSet()
    '    'PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '    'If DB_UDNTHA.EMGODNKB = "1" Then
    '    '    '出荷指示見出しトラン
    '    '    Call FDNTHA_RClear()
    '    '    Call FDNTHA_FromSCR(-1)
    '    '    DB_FDNTHA.DATKB = "1"
    '    '    DB_FDNTHA.DENKB = "1"
    '    '    DB_FDNTHA.FDNDT = DB_UNYMTA.UNYDT
    '    '    DB_FDNTHA.CANKB = "0"
    '    '    DB_FDNTHA.WRKKB = "5"
    '    '    DB_FDNTHA.RELFL = "0"
    '    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    'Else
    '    '    Call FDNTHA_RClear()
    '    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    'End If
    '    'I = 0
    '    'Do While I < PP_SSSMAIN.LastDe
    '    '    Call UDNTRA_RClear()
    '    '    Call Mfil_FromSCR(I)
    '    '    DB_UDNTRA.DATKB = "1"
    '    '    DB_UDNTRA.DENKB = "1"
    '    '    DB_UDNTRA.SMADT = SSS_SMADT.Value
    '    '    DB_UDNTRA.SSADT = SSS_SSADT.Value
    '    '    DB_UDNTRA.KESDT = SSS_KESDT.Value
    '    '    DB_UDNTRA.DKBSB = WG_DKBSB
    '    '    DB_UDNTRA.LINNO = VB6.Format(I + 1, "000")

    '    '    ' 緊急出荷基準
    '    '    If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '    '        DB_UDNTRA.EMGODNKB = "9"
    '    '    Else
    '    '        DB_UDNTRA.EMGODNKB = "1"
    '    '    End If

    '    '    PlStat = DB_PlSet(DBN_UDNTRA, I)

    '    '    If DB_UDNTRA.EMGODNKB = "1" Then
    '    '        '出荷指示トラン
    '    '        Call FDNTRA_RClear()
    '    '        Call FDNTRA_FromSCR(I)
    '    '        DB_FDNTRA.DATKB = "1"
    '    '        DB_FDNTRA.DENKB = "1"
    '    '        DB_FDNTRA.FDNDT = DB_UNYMTA.UNYDT
    '    '        DB_FDNTRA.CANKB = "0"
    '    '        DB_FDNTRA.WRKKB = "5"
    '    '        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MNZHIKSU(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ATZHIKSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    '        DB_FDNTRA.HIKSU = RD_SSSMAIN_ATZHIKSU(I) + RD_SSSMAIN_MNZHIKSU(I)
    '    '        DB_FDNTRA.FDNZMIFL = "1"
    '    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '    '    Else
    '    '        Call FDNTRA_RClear()
    '    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '    '    End If
    '    '    I = I + 1
    '    'Loop

    '    'Call DB_BeginTransaction(CStr(BTR_Exclude))

    '    'PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '    'If PlStat <> 0 And PlStat <> 1485 Then
    '    '    MsgBox("PL/SQL Error：" & PlStat)
    '    '    WRTTRN = False
    '    '    DB_AbortTransaction()
    '    '    '''    ElseIf Trim$(G_PlCnd2.sCndStr(2)) <> "" Then
    '    '    '''        MsgBox Error
    '    '    '''        WRTTRN = False
    '    '    '''        DB_AbortTransaction
    '    'Else
    '    '    WRTTRN = True
    '    '    Call DB_EndTransaction()
    '    '    '1998/05/12  １行追加
    '    '    Call DP_SSSMAIN_UDNNO(-1, G_PlCnd2.sCndStr(1))
    '    '    ' === 20130523 === INSERT S - FWEST)Koroyasu 排他制御の解除
    '    '    Call SSSWIN_Unlock_EXCTBZ()
    '    '    ' === 20130523 === INSERT E -
    '    'End If
    '    'PlStat = DB_PlFree()

    '    'FR_SSSMAIN.Enabled = True

    '    ''シリアル№登録ワークの削除
    '    'Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    'Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '    'Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '    '    Call DB_Delete(DBN_SRAET53)
    '    '    Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '    'Loop
    '    'Call DB_EndTransaction()

    '    ''緊急出荷時のみ、物流連携へのテキスト出力
    '    'If DB_UDNTHA.EMGODNKB = "1" Then
    '    '    'INIファイル取得用関数
    '    '    FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '    '    lngFileNo1 = FreeFile()
    '    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    '    FileClose(lngFileNo1)
    '    'End If
    '    '2019/06/05 DELL END

    'End Function
    '20190726 DELL END
    '20190726 DELL START
    '   Function DELTRN() As Short

    '	Dim PlStat As Integer
    '	Dim I As Short
    '	Dim Rtn As Short
    '	Dim wkTOKCD As String

    '	Dim EXEPATH As String
    '	Dim FILE1_PATH As String
    '	Dim lngFileNo1 As Integer


    '	'     PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
    '	If G_PlCnd.nJobMode <> 2 Then Exit Function 'Delete以外
    '	FR_SSSMAIN.Enabled = False

    '	'権限チェック
    '	If gs_UPDAUTH = "9" Then
    '		Rtn = DSP_MsgBox(SSS_ERROR, "UPDAUTH", 0) '更新権限なし
    '		DELTRN = False
    '		Exit Function
    '	End If

    '	If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '		MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '		DELTRN = True
    '		PlStat = DB_PlFree
    '		FR_SSSMAIN.Enabled = True

    '		'シリアル№登録ワークの削除
    '		Call DB_BeginTransaction(CStr(BTR_Exclude))
    '		Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '		Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '			Call DB_Delete(DBN_SRAET53)
    '			Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '		Loop 
    '		Call DB_EndTransaction()

    '		Exit Function
    '	Else
    '		Call SSSWIN_EXCTBZ_OPEN()
    '	End If

    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If RD_SSSMAIN_UDNDT(-1) <= DB_SYSTBA.UKSMEDT Then
    '		Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 0) '月次仮締日を過ぎています。
    '		DELTRN = False
    '		Exit Function
    '	End If
    '	'
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	wkTOKCD = RD_SSSMAIN_TOKCD(-1) & Space(Len(DB_TOKMTA.TOKSEICD) - Len(RD_SSSMAIN_TOKCD(-1)))
    '	Call DB_GetEq(DBN_TOKMTA, 1, wkTOKCD, BtrNormal)
    '	If DBSTAT = 0 Then
    '		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		If RD_SSSMAIN_UDNDT(-1) <= DB_TOKMTA.TOKSMEDT Then
    '			Rtn = DSP_MsgBox(SSS_ERROR, "DATE_1", 1) '登録された得意先の請求締日を過ぎています。
    '			DELTRN = False
    '			Exit Function
    '		End If
    '	End If

    '	'2008/1/22 FKS)ichihara CHG START
    '	'FJCL修正分の反映（377案件分）
    '	'    ' ADD 2007/02/13 売上基準が01(出荷基準)は削除不可とする
    '	'    If RD_SSSMAIN_URIKJN(-1) = "01" Then
    '	'        Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_2", 0) '該当伝票は出荷基準の為、削除できません。
    '	'        DELTRN = False
    '	'        Exit Function
    '	'    End If
    '	' ADD 2007/02/13 売上基準が01(出荷基準)は削除不可とする (2007/12/29 復活)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If RD_SSSMAIN_URIKJN(-1) = "01" Then
    '		Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52_1", 5) '該当伝票は出荷基準の為、削除できません。
    '		DELTRN = False
    '		Exit Function
    '	End If
    '	'2008/1/22 FKS)ichihara CHG END

    '	For I = 0 To MAX_CNDARR - 1
    '		G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '		G_PlCnd.nCndNum(I) = I + 1
    '	Next I

    '	G_PlCnd.sOpeID = SSS_OPEID.Value
    '	G_PlCnd.sCltID = SSS_CLTID.Value

    '	G_PlInfo.FCnt = 4
    '	G_PlInfo.Fno(0) = DBN_UDNTRA
    '	G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '	G_PlInfo.ArrayFlg(0) = 1
    '	G_PlInfo.Fno(1) = DBN_UDNTHA
    '	G_PlInfo.RCnt(1) = 1
    '	G_PlInfo.ArrayFlg(1) = 0
    '	G_PlInfo.Fno(2) = DBN_FDNTRA
    '	G_PlInfo.RCnt(2) = PP_SSSMAIN.LastDe
    '	G_PlInfo.ArrayFlg(2) = 1
    '	G_PlInfo.Fno(3) = DBN_FDNTHA
    '	G_PlInfo.RCnt(3) = 1
    '	G_PlInfo.ArrayFlg(3) = 0
    '	'
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(0) = RD_SSSMAIN_TOKCD(-1)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(1) = RD_SSSMAIN_NHSCD(-1)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(2) = RD_SSSMAIN_TANCD(-1)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SSADT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMADT(-1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	If RD_SSSMAIN_SMADT(-1) > DB_SYSTBA.UKSMEDT And (RD_SSSMAIN_SSADT(-1) > DB_TOKMTA.TOKSMEDT) Then
    '		G_PlCnd.sCndStr(3) = "1" '当月度内
    '	Else
    '		G_PlCnd.sCndStr(3) = "0" '前月度
    '	End If
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(4) = RD_SSSMAIN_DATNO(-1)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(5) = RD_SSSMAIN_UDNDT(-1)
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	G_PlCnd.sCndStr(6) = RD_SSSMAIN_DENDT(-1)
    '	G_PlCnd.sCndStr(7) = SSS_SMADT.Value
    '	G_PlCnd.sCndStr(8) = SSS_SSADT.Value
    '	G_PlCnd.sCndStr(9) = SSS_KESDT.Value
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(-1)

    '	PlStat = DB_PlStart
    '	PlStat = DB_PlCndSet
    '	PlStat = DB_PlSet(DBN_UDNTHA, 0)
    '	PlStat = DB_PlSet(DBN_UDNTRA, 0)
    '       '20190726 DELL START
    '       'Call UDNTHA_RClear()
    '       '20190726 DELL END
    '       Call UDNTHA_FromSCR(-1)
    '	DB_UDNTHA.DATKB = "1"
    '	DB_UDNTHA.DENKB = "1"
    '	DB_UDNTHA.UDNPRAKB = "9"
    '	DB_UDNTHA.UDNPRBKB = "9"
    '	DB_UDNTHA.SMADT = SSS_SMADT.Value
    '	DB_UDNTHA.SSADT = SSS_SSADT.Value
    '	DB_UDNTHA.KESDT = SSS_KESDT.Value
    '	Dim WK_FDNNO As String
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	WK_FDNNO = RD_SSSMAIN_FDNNO(-1)


    '	' 緊急出荷基準
    '	If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '		DB_UDNTHA.EMGODNKB = "9"
    '	Else
    '		DB_UDNTHA.EMGODNKB = "1"
    '	End If
    '	'
    '	PlStat = DB_PlStart
    '	PlStat = DB_PlCndSet
    '	PlStat = DB_PlSet(DBN_UDNTHA, 0)

    '       If DB_UDNTHA.EMGODNKB = "1" Then
    '           '出荷指示見出しトラン
    '           '20190726 DELL START
    '           'Call FDNTHA_RClear()
    '           '20190726 DELL END
    '           Call FDNTHA_FromSCR(-1)
    '           DB_FDNTHA.DATKB = "1"
    '           DB_FDNTHA.DENKB = "1"
    '           DB_FDNTHA.FDNDT = DB_UNYMTA.UNYDT
    '           DB_FDNTHA.CANKB = "0"
    '           DB_FDNTHA.WRKKB = "5"
    '           DB_FDNTHA.RELFL = "0"
    '           PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '       Else
    '           '20190726 DELL END
    '           'Call FDNTHA_RClear()
    '           '20190726 DLEL END
    '           PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '	End If
    '	I = 0
    '       Do While I < PP_SSSMAIN.LastDe
    '           '20190726 DELL START
    '           'Call UDNTRA_RClear()
    '           '20190726 DLL END
    '           Call Mfil_FromSCR(I)
    '           DB_UDNTRA.DATKB = "1"
    '           DB_UDNTRA.DENKB = "1"
    '           DB_UDNTRA.SMADT = SSS_SMADT.Value
    '           DB_UDNTRA.SSADT = SSS_SSADT.Value
    '           DB_UDNTRA.KESDT = SSS_KESDT.Value
    '           DB_UDNTRA.DKBSB = WG_DKBSB
    '           DB_UDNTRA.LINNO = VB6.Format(I + 1, "000")

    '           ' 緊急出荷基準
    '           If FR_SSSMAIN.HD_EMGODNKB.CheckState = 0 Then
    '               DB_UDNTRA.EMGODNKB = "9"
    '           Else
    '               DB_UDNTRA.EMGODNKB = "1"
    '           End If

    '           PlStat = DB_PlSet(DBN_UDNTRA, I)

    '           If DB_UDNTRA.EMGODNKB = "1" Then
    '               '出荷指示トラン
    '               '20910726 DELL START
    '               'Call FDNTRA_RClear()
    '               '20190726 DELL END
    '               Call FDNTRA_FromSCR(I)
    '               DB_FDNTRA.DATKB = "1"
    '               DB_FDNTRA.DENKB = "1"
    '               DB_FDNTRA.FDNDT = DB_UNYMTA.UNYDT
    '               DB_FDNTRA.CANKB = "0"
    '               DB_FDNTRA.WRKKB = "5"
    '               'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MNZHIKSU(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '               'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ATZHIKSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '               DB_FDNTRA.HIKSU = RD_SSSMAIN_ATZHIKSU(I) + RD_SSSMAIN_MNZHIKSU(I)
    '               DB_FDNTRA.FDNZMIFL = "1"
    '               PlStat = DB_PlSet(DBN_FDNTRA, I)
    '           Else
    '               '20190726 DELL START
    '               'Call FDNTRA_RClear()
    '               '20190726 DELL END
    '               PlStat = DB_PlSet(DBN_FDNTRA, I)
    '           End If
    '           I = I + 1
    '       Loop

    '       Call DB_BeginTransaction(CStr(BTR_Exclude))
    '	PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
    '	If PlStat <> 0 And PlStat <> 1485 Then
    '		MsgBox("PL/SQL Error：" & PlStat)
    '		DELTRN = False
    '		DB_AbortTransaction()
    '	Else
    '		DELTRN = True
    '		Call DB_EndTransaction()
    '		' === 20130523 === INSERT S - FWEST)Koroyasu 排他制御の解除
    '		Call SSSWIN_Unlock_EXCTBZ()
    '		' === 20130523 === INSERT E -
    '	End If

    '	PlStat = DB_PlFree

    '	FR_SSSMAIN.Enabled = True

    '	'シリアル№登録ワークの削除
    '	Call DB_BeginTransaction(CStr(BTR_Exclude))
    '	Call DB_GetGrEq(DBN_SRAET53, 1, SSS_CLTID.Value & SSS_PrgId, BtrNormal)
    '	Do While (DBSTAT = 0) And (Trim(DB_SRAET53.RPTCLTID) = Trim(SSS_CLTID.Value)) And (Trim(DB_SRAET53.PRGID) = Trim(SSS_PrgId))
    '		Call DB_Delete(DBN_SRAET53)
    '		Call DB_GetNext(DBN_SRAET53, BtrNormal)
    '	Loop 
    '	Call DB_EndTransaction()

    '	'緊急出荷時のみ、物流連携へのテキスト出力
    '	If DB_UDNTHA.EMGODNKB = "1" Then
    '		'INIファイル取得用関数
    '		FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '		lngFileNo1 = FreeFile
    '		FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '		FileClose(lngFileNo1)
    '	End If

    'End Function
    '20910726 DELL END

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
        '2019/06/04 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/06/04 CHG END
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/06/04 CHG START
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            '2019/06/04 CHG END
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
        '2019/06/04 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/06/04 CHG END
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/06/04 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/06/04 CHG END
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