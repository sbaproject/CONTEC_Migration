Option Strict Off
Option Explicit On
Module IDOPR52_M01
	'
	' スロット名        : クライアント別受注日記帳・メインファイル更新スロット
	' ユニット名        : IDOPR52.M01
	' 記述者            : Standard Library
	' 作成日付          : 1998/02/24
	' 使用プログラム名  : IDOPR52
	'
	
	Function CHK_LCTL() As Short
	End Function
	
	Function ENDCHK() As Short
	End Function
	
	Sub Loop_Mfil()
		Dim PlStat As Short
		
		G_PlCnd.sCndStr(0) = SSS_CLTID.Value
		G_PlCnd.sCndStr(1) = DeCNV_DATE((FR_SSSMAIN.HD_DENDT).Text)
		G_PlCnd.sCndStr(2) = FR_SSSMAIN.HD_PRTKB.Text
		G_PlCnd.sCndStr(3) = FR_SSSMAIN.HD_PRTSB.Text '2006.11.10
		
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
		G_PlInfo.Fno(0) = DBN_IDOPR52
		G_PlInfo.RCnt(0) = 1
		G_PlInfo.ArrayFlg(0) = 0
		'
		Call Mfil_FromSCR(-1)
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		PlStat = DB_PlSet(DBN_IDOPR52, 0)
		'
		'    PlStat = DB_PlExec(Get_EntryToPackage())
		PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_" & SSS_PrgId)
		If PlStat <> 0 And PlStat <> 1485 Then
			MsgBox("PL/SQL Error：" & PlStat)
		Else
			SSS_LFILCNT = G_PlCnd2.nCndNum(0)
			If SSS_LFILCNT > 0 Then
				Call CNT_GAUGE()
			End If
			'正常に終りました。
			'CRWで出力可
		End If
		PlStat = DB_PlFree
	End Sub
	
	Function NEXTCHK() As Short
	End Function
	
	Function NPSNCHK() As Short
	End Function
	
	Function RPSNCHK() As Short
	End Function
	
	Function SEL_RECORD() As String
	End Function
	
	Sub Set_Value()
	End Sub
    '2019/10/25 DEL START
    '    Public Function AnsiTrimStringByByteCount(ByRef ArgSrc As String, ByRef ArgCnt As Integer) As String
    '        '概要：全角半角まじりのＵｎｉＣｏｄｅ文字列を、   ■■■■
    '        '                   文字をきらないように指定されたバイト数に丸めた文字列を返す。
    '        '                                                 ■■■■
    '        '引数：ArgSrc ,Input ,String ,元の文字列
    '        '　　：ArgCnt ,Input ,Long   ,丸める文字数

    '        Dim strResult As String
    '        Dim strTmpChr As String
    '        Dim lngLength As Integer
    '        Dim lngCalCnt As Integer
    '        Dim lngTmpCnt As Integer
    '        Dim lngI As Integer


    '        strResult = ""
    '        lngLength = Len(Trim(ArgSrc))
    '        lngCalCnt = 0
    '        For lngI = 1 To lngLength
    '            strTmpChr = Mid(ArgSrc, lngI, 1)
    '            lngTmpCnt = AnsiLenB(strTmpChr)
    '            If lngCalCnt + lngTmpCnt > ArgCnt Then
    '                GoTo AnsiTrimStringByByteCount_End
    '            Else
    '                lngCalCnt = lngCalCnt + lngTmpCnt
    '                strResult = strResult & strTmpChr
    '            End If
    '        Next

    'AnsiTrimStringByByteCount_End:

    '        If AnsiLenB(strResult) < ArgCnt Then
    '            AnsiTrimStringByByteCount = strResult & New String(" ", ArgCnt - AnsiLenB(strResult))
    '        Else
    '            AnsiTrimStringByByteCount = strResult
    '        End If

    '    End Function
    '2019/10/25 DEL START
    '2019/10/25 DEL START
    '    Public Function AnsiTrimStringByMojiCount(ByRef strSrc As String, ByRef lngDstCount As Integer) As String
    '        '概要：全角半角まじりのＵｎｉＣｏｄｅ文字列を、   ■■■
    '        '                   文字をきらないように指定された文字数（≠バイト数）に丸めた文字列を返す。
    '        '                                                 ■■■
    '        '引数：strSrc     ,Input,String,元の文字列
    '        '　　：lngDstCount,Input,Long,丸める文字数
    '        Dim strDst As String
    '        Dim strTmp As String
    '        Dim lngSrcCount As Integer
    '        Dim lngCalCount As Integer
    '        Dim lngTmpCount As Integer
    '        Dim strFmt As String
    '        Dim lngI As Integer

    '        strDst = ""
    '        lngSrcCount = Len(strSrc)
    '        lngCalCount = 0
    '        For lngI = 1 To lngSrcCount
    '            strTmp = Mid(strSrc, lngI, 1)
    '            lngTmpCount = AnsiLenB(strTmp)
    '            If lngCalCount + lngTmpCount > lngDstCount Then
    '                GoTo AnsiTrimStringByMojiCount_End
    '            Else
    '                lngCalCount = lngCalCount + lngTmpCount
    '                strDst = strDst & strTmp
    '            End If
    '        Next

    'AnsiTrimStringByMojiCount_End:

    '        strFmt = "!"
    '        For lngI = 1 To lngDstCount
    '            strFmt = strFmt & "@"
    '        Next
    '        strDst = VB6.Format(strDst, strFmt)
    '        AnsiTrimStringByMojiCount = strDst

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiInStrB(ByRef varArg1 As Object, ByRef varArg2 As Object, Optional ByRef varArg3 As Object = Nothing) As Integer
    '        '概要：文字列位置の検索
    '        '引数：varArg1,Input,Variant,検索開始位置 or 検索対象文字列
    '        '　　：varArg2,Input,Variant,検索文字列
    '        '　　：varArg3,Input,Variant(Optional),検索文字列(省略可能)
    '        '説明Ａｎｓｉコードのバイトオーダで検索文字列の文字位置(文字数)を返す
    '        Dim lngPos As Integer

    '#If Win32 Then
    '        If IsNumeric(varArg1) Then
    '            'UPGRADE_WARNING: オブジェクト varArg1 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            'UPGRADE_WARNING: オブジェクト varArg2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '            lngPos = LenB(AnsiLeftB(varArg2, varArg1))
    '            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '            AnsiInStrB = InStrB(varArg1, AnsiStrConv(varArg2, vbFromUnicode), AnsiStrConv(varArg3, vbFromUnicode))
    '        Else
    '            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: InStrB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '            AnsiInStrB = InStrB(AnsiStrConv(varArg1, vbFromUnicode), AnsiStrConv(varArg2, vbFromUnicode))
    '        End If
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		If IsNumeric(varArg1) Then
    '		lngPos = LenB(LeftB(varArg2, varArg1))
    '		AnsiInStrB = InStrB(varArg1, varArg2, varArg3)
    '		Else
    '		AnsiInStrB = InStrB(varArg1, varArg2)
    '		End If
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiLeftB(ByVal strArg As String, ByVal lngArg As Integer) As String
    '        '概要：左詰め文字列の抽出
    '        '引数：strArg,Input,String,抽出元文字列
    '        '　　：lngArg,Input,Long,抽出文字数
    '        '説明：Ａｎｓｉコードのバイトオーダで文字列の左端から文字数分の文字列を返す

    '#If Win32 Then
    '        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '        'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiLeftB = LeftB(strArg, lngArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiLenB(ByVal strArg As String) As Integer
    '        '概要：文字数カウント
    '        '引数：strArg,Input,String,対象文字列
    '        '説明：Ａｎｓｉコードのバイトオーダで文字列のﾊﾞｲﾄ数を返す

    '#If Win32 Then
    '        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '        'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '        AnsiLenB = LenB(AnsiStrConv(strArg, vbFromUnicode))
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiLenB = LenB(strArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiMidB(ByVal strArg As String, ByVal lngArg As Integer, Optional ByRef varArg As Object = Nothing) As String
    '        '概要：文字列の抽出
    '        '引数：strArg,Input,String,抽出元文字列
    '        '　　：lngArg,Input,Long,先頭からの抽出開始位置
    '        '　　：varArg,Input,Variant(Optional),抽出文字数(省略可能)
    '        '説明：Ａｎｓｉコードのバイトオーダで文字列の抽出開始位置から文字数分の文字列を返す

    '#If Win32 Then
    '        'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
    '        If IsNothing(varArg) Then
    '            'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '            'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '        Else
    '            'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '            'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '            'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '            AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(strArg, vbFromUnicode), lngArg, varArg), vbUnicode)
    '        End If
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		If IsMissing(varArg) Then
    '		AnsiMidB = MidB(strArg, lngArg)
    '		Else
    '		AnsiMidB = MidB(strArg, lngArg, varArg)
    '		End If
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiRightB(ByVal strArg As String, ByVal lngArg As Integer) As String
    '        '概要：右詰め文字列の抽出
    '        '引数：strArg,Input,String,抽出元文字列
    '        '　　：lngArg,Input,Long,抽出文字数
    '        '説明：Ａｎｓｉコードのバイトオーダで文字列の右端から文字数分の文字列を返す

    '#If Win32 Then
    '        'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '        'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
    '        'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
    '        'UPGRADE_WARNING: オブジェクト AnsiStrConv() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '        AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
    '		AnsiRightB = RightB(strArg, lngArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D

    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'概要：文字列のｺｰﾄﾞ変換
		'引数：varArg,Input,Variant,変換元文字列
		'　　：varCnv,Input,Variant,conversion定数(StrConv 関数参照)
		'説明：Ａｎｓｉ ⇔ ＵｎｉＣｏｄｅに変換した文字列を返す
		
#If Win32 Then
		'UPGRADE_WARNING: オブジェクト varCnv の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト varArg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: 式 Else が True に評価されなかったか、またはまったく評価されなかったため、#If #EndIf ブロックはアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' をクリックしてください。
		AnsiStrConv = varArg
#End If
		
	End Function
End Module