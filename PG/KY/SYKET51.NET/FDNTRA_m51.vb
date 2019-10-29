Option Strict Off
Option Explicit On
Module FDNTRA_M51
    '
    ' スロット名        : 出荷指示トラン・メインファイル更新スロット(PL/SQL対応)
    ' ユニット名        : FDNTRA.M51
    ' 記述者            : Standard Library
    ' 作成日付          : 2006/07/15
    ' 使用プログラム名  : SYKET51
    '
    '2019/10/28 DEL START
    'Function DELTRN() As Short
    'End Function
    '2019/10/28 DEL E N D
    '2019/10/28 DEL START
    'Function WRTTRN() As Short
    '    Dim I As Short
    '    Dim PlStat As Integer
    '    Dim EXEPATH As String

    '    Dim FILE1_PATH As String
    '    Dim lngFileNo1 As Integer

    '    '
    '    FR_SSSMAIN.Enabled = False

    '    If Left(SSSWIN_EXCTBZ_CHECK, 1) = "9" Then
    '        MsgBox("【" & Trim(Mid(SSSWIN_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
    '        WRTTRN = False
    '        PlStat = DB_PlFree
    '        FR_SSSMAIN.Enabled = True
    '        Exit Function
    '    Else
    '        Call SSSWIN_EXCTBZ_OPEN()
    '    End If

    '    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される

    '    G_PlCnd.nJobMode = 0
    '    For I = 0 To MAX_CNDARR - 1
    '        G_PlCnd.sCndStr(I) = New String(Chr(Asc("A") + I), 20)
    '        G_PlCnd.nCndNum(I) = I + 1
    '    Next I

    '    G_PlCnd.sOpeID = SSS_OPEID.Value
    '    G_PlCnd.sCltID = SSS_CLTID.Value
    '    '2008/05/19 FKS)HONDA ADD START
    '    G_PlCnd2.sErrMsg = ""
    '    '2008/05/19 FKS)HONDA ADD END

    '    G_PlInfo.FCnt = 2
    '    G_PlInfo.Fno(1) = DBN_FDNTHA
    '    G_PlInfo.RCnt(1) = 1
    '    G_PlInfo.ArrayFlg(1) = 0
    '    G_PlInfo.Fno(0) = DBN_FDNTRA
    '    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    '    G_PlInfo.ArrayFlg(0) = 1
    '    '
    '    'Call FDNTHA_RClear()
    '    Call FDNTHA_FromSCR(-1)
    '    '
    '    PlStat = DB_PlStart
    '    PlStat = DB_PlCndSet
    '    PlStat = DB_PlSet(DBN_FDNTHA, 0)
    '    I = 0
    '    Do While I < PP_SSSMAIN.LastDe
    '        Call FDNTRA_RClear()
    '        Call Mfil_FromSCR(I)
    '        PlStat = DB_PlSet(DBN_FDNTRA, I)
    '        I = I + 1
    '    Loop

    '    Call DB_BeginTransaction(CStr(BTR_Exclude))
    '    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_FDNTRA")
    '    If PlStat <> 0 And PlStat <> 1485 Then
    '        MsgBox("PL/SQL Error：" & PlStat)
    '        WRTTRN = False
    '        Call DB_AbortTransaction()
    '    Else
    '        '2008/06/24 START ADD FKS)HAYASHI 連絡票№：FC08062403
    '        If Trim(G_PlCnd2.sErrMsg) <> "" Then
    '            'PL/SQLにてデータ変更による処理スキップが有り
    '            MsgBox(Trim(G_PlCnd2.sErrMsg))
    '            Call DB_AbortTransaction()
    '            PlStat = DB_PlFree
    '            Exit Function
    '        End If
    '        '2008/06/24 E.N.D ADD FKS)HAYASHI 連絡票№：FC08062403
    '        WRTTRN = True
    '        Call DB_EndTransaction()
    '        '2008/05/19 FKS)HONDA ADD START
    '        '2008/06/24 START DEL FKS)HAYASHI 連絡票№：FC08062403
    '        '''    If Trim(G_PlCnd2.sErrMsg) <> 0 Then
    '        '''        'PL/SQLにてデータ変更による処理スキップが有り
    '        '''        MsgBox Trim(G_PlCnd2.sErrMsg)
    '        '''    End If
    '        '2008/06/24 E.N.D DEL FKS)HAYASHI 連絡票№：FC08062403
    '        '2008/05/19 FKS)HONDA ADD END

    '    End If

    '    PlStat = DB_PlFree

    '    FR_SSSMAIN.Enabled = True

    '    '出庫予定ファイルの削除
    '    ''''Call DB_GetGrEq(DBN_SYKTRA, 3, SSS_CLTID & SSS_PrgId, BtrNormal)
    '    ''''Do While (DBSTAT = 0) And (Trim$(DB_SYKTRA.CLTID) = Trim$(SSS_CLTID)) _
    '    '''''                      And (Trim$(DB_SYKTRA.PGID) = Trim$(SSS_PrgId))
    '    ''''    Call DB_Delete(DBN_SYKTRA)
    '    ''''    Call DB_GetNext(DBN_SYKTRA, BtrNormal)
    '    ''''Loop


    '    '出庫予定ファイル作成実行
    '    EXEPATH = AE_AppPath & "\SYKFP70.EXE /CLTID:" & SSS_CLTID.Value & " /PGID:" & SSS_PrgId & " /PGNM:" & SSS_PrgNm
    '    I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)

    '    'INIファイル取得用関数
    '    FILE1_PATH = GP_GetIni(AE_AppPath & "SYKFP51.ini", "FILEPATH", "FILE1")
    '    lngFileNo1 = FreeFile
    '    FileOpen(lngFileNo1, FILE1_PATH, OpenMode.Output)
    '    FileClose(lngFileNo1)

    'End Function
    '2019/10/28 DEL E N D

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
        '2019/10/28 CHG START
        'lngInstr = InStrB(strData, ";")
        lngInstr = InStr(strData, ";")
        '2019/10/28 CHG START
        If lngInstr <> 0 Then
            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
            '2019/10/28 CHG START
            'strWK = MidB(strData, 1, InStrB(strData, ";") - 1)
            strWK = MidB(strData, 1, InStr(strData, ";") - 1)
            '2019/10/28 CHG E N D
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
        '2019/10/28 CHG START
        'AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode), arg1), vbUnicode)
        AnsiLeftB = LeftB(StrArg, arg1)
        '2019/10/28 CHG E N D
    End Function
	
	Function AnsiLenB(ByVal StrArg As String) As Integer
        '概要：文字数ｶｳﾝﾄ
        '引数：StrArg,Input,String,対象文字列
        '説明：Ansiｺｰﾄﾞのﾊﾞｲﾄｵｰﾀﾞで文字列のﾊﾞｲﾄ数を返す
#If Win32 Then
        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
        '2019/10/28 CHG START
        'AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
        AnsiLenB = LenB(StrArg)
        '2019/10/28 CHG E N D
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