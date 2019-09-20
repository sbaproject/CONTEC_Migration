Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module AE_CMN
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　共通
	'*  モジュール名　　：　業務共通処理
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.24
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	'************************************************************************************
	'   API
	'************************************************************************************
	'//----------------------------------------------
	'//親プロセスへの終了コード復帰
	'//----------------------------------------------
	Public Declare Sub ExitProcess Lib "kernel32" (ByVal uExitCode As Integer)
	'//----------------------------------------------
	'//スリープ
	'//----------------------------------------------
	Public Declare Function Sleep Lib "kernel32.dll" (ByVal mstime As Integer) As Integer
	
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '入力担当者ＩＤ
		Dim InpTanNm As String '入力担当者名
		Dim InpTKCHGKB As String '単価変更権限
		Dim InpCLIID As String 'クライアントＩＤ
	End Structure
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	'端数計算桁数
	Public Const gc_strRPSKB_D1 As String = "1" '小数第一位
	Public Const gc_strRPSKB_D2 As String = "2" '小数第二位
	Public Const gc_strRPSKB_D3 As String = "3" '小数第三位
	Public Const gc_strRPSKB_D4 As String = "4" '小数第四位
	Public Const gc_strRPSKB_D5 As String = "5" '小数第五位
	Public Const gc_strRPSKB_I1 As String = "10" '１
	Public Const gc_strRPSKB_I2 As String = "11" '１０
	Public Const gc_strRPSKB_I3 As String = "12" '１００
	
	Public Const MAX_PATH As Short = 260
	
	'************************************************************************************
	'   Public変数
	'************************************************************************************
	Public Inp_Inf As Cmn_Inp_Inf '入力者情報
	Public GV_SysDate As String 'ＤＢサーバー日付
	Public GV_SysTime As String 'ＤＢサーバー時刻
	Public GV_UNYDate As String '運用日付
	
	'************************************************************************************
	'   Private変数
	'************************************************************************************
	Dim strINIDATNM(4) As String 'ＩＮＩのシンボル
	Dim SSS_INIDAT(4) As String
	Dim SSS_INICnt As Short
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Init_BAT
	'   概要：  プログラム起動時初期処理(バッチ用)
	'   引数：  pot_strErrMsg : エラーメッセージ
	'           pin_strPGID   : 空白は通常処理　ﾌﾟﾛｸﾞﾗﾑIDが入っている場合はそれぞれの固有の処理を実行
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Init_BAT(ByRef pot_strErrMsg As String, Optional ByRef pin_strPGID As String = "") As Short
		
		Dim datDT As Date
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim DB_UNYMTA As TYPE_DB_UNYMTA
		Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		
		CF_Init_BAT = 9
		
		pot_strErrMsg = ""
		
		'二重起動ﾁｪｯｸ
		'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		If App.PrevInstance Then
			pot_strErrMsg = "【" & Trim(SSS_PrgNm) & "】は既に起動中です。重複して起動する事はできません。"
			Exit Function
		End If
		
		'   日付形式チェック
		datDT = Today
		strYMD = VB6.Format(Year(datDT), "0000") & "/" & VB6.Format(Month(datDT), "00") & "/" & VB6.Format(VB.Day(datDT), "00")
		
		If CStr(datDT) <> strYMD Then
			pot_strErrMsg = "日付の形式 '" & CStr(datDT) & "' が違います。" & " " & "コントロールパネルの地域（地球の絵）の日付" & " " & "の短い形式を yyyy/MM/dd に変更して下さい。"
			Exit Function
		End If
		
		'---------------------
		' 起動パラメータ設定
		'---------------------
		Select Case UCase(Trim(pin_strPGID))
			'出荷予定データ作成処理
			Case "SYKFP70"
				
				'通常
			Case Else
				'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
				intLenCommand = CStr(LenB(Trim(VB.Command())))
				If CDbl(intLenCommand) < 15 Then
					intRet = CF_Get_BATUSER
					If intRet <> 0 Then
						pot_strErrMsg = "バッチを実行する担当者ＩＤ、端末ＩＤがありません。設定を確認して下さい。"
						Exit Function
					End If
				Else
					SSS_CLTID.Value = CF_Ctr_AnsiMidB(VB.Command(), 2, 5) 'クライアントID
					SSS_OPEID.Value = CF_Ctr_AnsiMidB(VB.Command(), 7, 8) '入力担当者ID
				End If
				
				'入力担当者名取得
				Inp_Inf.InpTanCd = SSS_OPEID.Value
				Inp_Inf.InpCLIID = SSS_CLTID.Value
				
				Call DB_TANMTA_Clear(DB_TANMTA)
				intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
				If intRet = 0 Then
					Inp_Inf.InpTanNm = DB_TANMTA.TANNM '入力担当者名
				End If
		End Select
		
		
		'---------------------
		' SSSWIN.INI テーブル設定
		'---------------------
		strINIDATNM(0) = "USR_PATH"
		strINIDATNM(1) = "DAT_PATH"
		strINIDATNM(2) = "PRG_PATH"
		strINIDATNM(3) = "WRK_PATH"
		strINIDATNM(4) = "IMG_PATH"
		SSS_INICnt = 4
		'Iniファイル読込み
		Call CF_INIT_GETINI()
		
		'運用日付取得
		Call CF_Get_UnyDt()
		
		CF_Init_BAT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_INIT_GETINI
	'   概要：  INIファイル読込み（共通）
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CF_INIT_GETINI() As String
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		
		CF_INIT_GETINI = ""
		
		'---------------------
		' SSSWIN.INI 読込み
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				CF_INIT_GETINI = "SSSWIN.INI を確認してください。" & Chr(13) & "[" & strINIDATNM(I) & "]"
				Exit For
			Else
				SSS_INIDAT(I) = CF_Ctr_AnsiLeftB(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_TANNM
	'   概要：  担当者名称取得
	'   引数：　pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :画面業務情報構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""
		
		'担当者マスタ検索
		Call DB_TANMTA_Clear(DB_TANMTA)
		intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_BATUSER
	'   概要：  バッチ用担当者取得
	'   引数：　なし
	'   戻値：　0 : 正常　9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_BATUSER() As Short
		
		Dim Mst_Inf As TYPE_DB_FIXMTA
		Dim intRet As Short
		
		CF_Get_BATUSER = 9
		
		'固定値マスタ検索
		'バッチ用担当者ＩＤ取得
		Call DB_FIXMTA_Clear(Mst_Inf)
		
		intRet = DSPCTLCD_SEARCH(gc_strCTLCD_TANCD_BAT, Mst_Inf)
		If intRet = 0 Then
			SSS_OPEID.Value = Mst_Inf.FIXVAL
		Else
			Exit Function
		End If
		
		'バッチ用端末ＩＤ取得
		Call DB_FIXMTA_Clear(Mst_Inf)
		
		intRet = DSPCTLCD_SEARCH(gc_strCTLCD_CLTID_BAT, Mst_Inf)
		If intRet = 0 Then
			SSS_CLTID.Value = Mst_Inf.FIXVAL
		Else
			Exit Function
		End If
		
		CF_Get_BATUSER = 0
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_SysDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    DBサーバーの日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20041016|ACE)Moriga     |新規作成
	'//**************************************************************************************
	Public Function CF_Get_SysDt() As Boolean
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim Str_Val As String
		Dim Lng_Cnt As Integer
		Dim Lng_Idx As Integer
		Dim Str_SysDt As String
		
		CF_Get_SysDt = False
		
		'// 初期化
		GV_SysDate = ""
		GV_SysTime = ""
		Str_SysDt = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
		
		GV_SysDate = Mid(Str_SysDt, 1, 8)
		GV_SysTime = Mid(Str_SysDt, 9, 6)
		
		CF_Get_SysDt = True
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Get_UnyDt
	'//*
	'//* <戻り値>     型          説明
	'//*              Boolean     True:正常 / False:異常
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*
	'//* <説  明>
	'//*    運用日付(西暦)を取得する。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060706|ACE)Nagasawa   |新規作成
	'//**************************************************************************************
	Public Function CF_Get_UnyDt() As Boolean
		
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_UNYMTA
		
		CF_Get_UnyDt = False
		
		'初期化
		GV_UNYDate = ""
		
		'サーバーのシステム日付取得
		Call CF_Get_SysDt()
		
		'運用日付を取得
		intRet = DSPUNYDT_SEARCH(Mst_Inf)
		If intRet = 0 Then
			GV_UNYDate = Mst_Inf.UNYDT
		Else
			GV_UNYDate = GV_SysDate
		End If
		
		CF_Get_UnyDt = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Edit_ErrLog
	'   概要：  エラーログ出力処理
	'   引数：  pin_strLOG_PATH    : 出力ログファイルパス
	'           pin_strLOG_NAME    : 出力ログファイル名
	'           pin_strPrgId       : 出力プログラム名
	'           pin_intErrCd       : エラーコード
	'           pin_strErrMsg      : エラーメッセージ
	'           pin_strErrLocation : 発生箇所（ファンクション名）
	'           pin_strTime        : 発生時刻
	'           pin_strDate        : 発生日付
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Edit_ErrLog(ByVal pin_strLOG_PATH As String, ByVal pin_strLOG_NAME As String, ByVal pin_strPrgId As String, ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String, ByVal pin_strTime As String, ByVal pin_strDate As String) As Short
		
		Dim intFNo As Short
		Dim strCSV As String
		Dim bolOpen As Boolean
		
		On Error GoTo CF_Edit_ErrLog_End
		
		CF_Edit_ErrLog = 9
		bolOpen = False
		
		intFNo = FreeFile
		
		If Right(Trim(pin_strLOG_PATH), 1) <> "\" Then
			pin_strLOG_PATH = Trim(pin_strLOG_PATH) & "\"
		End If
		
		'ファイルオープン
		FileOpen(intFNo, Trim(pin_strLOG_PATH) & Trim(pin_strLOG_NAME), OpenMode.Append)
		bolOpen = True
		
		strCSV = ""
		'プログラムID
		strCSV = strCSV & pin_strPrgId & ","
		'エラー番号
		strCSV = strCSV & Trim(CStr(pin_intErrCd)) & ","
		'エラー内容
		strCSV = strCSV & pin_strErrMsg & ","
		'発生場所（ファンクション名等）
		strCSV = strCSV & pin_strErrLocation & ","
		'発生日
		strCSV = strCSV & pin_strDate & ","
		'発生時刻
		strCSV = strCSV & pin_strTime
		
		PrintLine(intFNo, strCSV)
		
		CF_Edit_ErrLog = 0
		
CF_Edit_ErrLog_End: 
		
		If bolOpen = True Then
			'クローズ
			FileClose(intFNo)
		End If
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiLeftB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして左から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLeftB(ByVal pm_Value As String, ByVal pm_Len As Integer) As String
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LeftB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLeftB = StrConv(LeftB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiRightB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして右から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiRightB(ByVal pm_Value As String, ByVal pm_Len As Integer) As Object
		
		'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: RightB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiRightB = StrConv(RightB(StrConv(pm_Value, vbFromUnicode), pm_Len), vbUnicode)
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiMidB
	'//*
	'//* <戻り値>     型          説明
	'//*              String      変換後の文字列
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//*              pm_Start           Long             I            切り取り開始バイト数
	'//*              pm_Len             Long             I            文字列の長さ
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして指定した位置から指定の長さの文字列を取得します。
	'//*    指定した長さが、全角文字が途中で切れるバイト数の場合、正しく取得できません。
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiMidB(ByVal pm_Value As String, ByVal pm_Start As Integer, Optional ByVal pm_Len As Integer = 0) As String
		
		Dim Str_Value As String
		
		If pm_Len < 1 Then
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start), vbUnicode)
		Else
			'UPGRADE_ISSUE: 定数 vbUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: MidB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			Str_Value = StrConv(MidB(StrConv(pm_Value, vbFromUnicode), pm_Start, pm_Len), vbUnicode)
			
			'//全角文字が途中で途切れる場合１文字多めにカットする。
			'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
			'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
			If LenB(StrConv(Str_Value, vbFromUnicode)) > pm_Len Then
				Str_Value = Mid(Str_Value, Len(Str_Value) - 1, 1)
			End If
		End If
		
		CF_Ctr_AnsiMidB = Str_Value
		
		Exit Function
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <名  称>
	'//*    CF_Ctr_AnsiLenB
	'//*
	'//* <戻り値>     型          説明
	'//*              Long        長さバイト数
	'//*
	'//* <引  数>     項目名             型              I/O           内容
	'//*              pm_Value           String           I            対象文字列
	'//* <説  明>
	'//*    半角文字を1バイト、全角文字を2バイトとして対象文字列の長さバイト数を取得します。
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付  | 更新者        |内容
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20020715|FKS)           |新規作成
	'//**************************************************************************************
	Public Function CF_Ctr_AnsiLenB(ByVal pm_Value As String) As Integer
		
		'UPGRADE_ISSUE: 定数 vbFromUnicode はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
		'UPGRADE_ISSUE: LenB 関数はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' をクリックしてください。
		CF_Ctr_AnsiLenB = LenB(StrConv(pm_Value, vbFromUnicode))
		
		Exit Function
		
	End Function
	
	Function Get_DBHEAD() As String
		'現在の環境のDBHEAD を返す、環境未設定の場合は、""を返す。
		Dim ret As Short
		Dim wkStr As New VB6.FixedLengthString(128)
		
		Get_DBHEAD = ""
		ret = GetPrivateProfileString("DBSPEC", "DBHEAD", "", wkStr.Value, 128, "SSSWIN.INI")
		If ret > 0 Then Get_DBHEAD = Left(wkStr.Value, ret)
	End Function
	
	Sub Error_Exit(ByVal ErrorMsg As String)
		Dim rtn As Object
		Dim I As Short
		End
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_CmnMsgLibrary_Bat
	'   概要：  標準メッセージ表示処理(バッチ用)
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pin_strMsg      : 追加メッセージ
	'   戻値：
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary_Bat(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		On Error Resume Next
		
		AE_CmnMsgLibrary_Bat = False
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) 'メッセージ種別
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) 'メッセージアイテム
		
		Beep()
		
		'メッセージマスタ検索
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'追加メッセージの編集
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'ＤＢアクセス系エラーとする
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'メッセージ表示
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/キャンセル
			Case gc_strBTNKB_OKCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'中止/再試行/無視
			Case gc_strBTNKB_AbortRetryIgnore
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ/キャンセル
			Case gc_strBTNKB_YesNoCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ
			Case gc_strBTNKB_YesNo
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'再試行/キャンセル
			Case gc_strBTNKB_RetryCancel
				AE_CmnMsgLibrary_Bat = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
	End Function
	
	' === 20061102 === INSERT S - ACE)Nagasawa INIファイル格納場所変更
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Get_IniInf
	'   概要：  Iniファイル読込み処理（プログラム固有）
	'   引数：  pin_strSection :
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short
		
		Dim Wk As New VB6.FixedLengthString(256)
		Dim lngRet As Integer
		
		CF_Get_IniInf = 9
		
		pot_strValue = ""
		
		'Iniファイル読込み
		lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
		If lngRet > 0 Then
			pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
			pot_strValue = Trim(pot_strValue)
		Else
			Exit Function
		End If
		
		CF_Get_IniInf = 0
		
	End Function
	' === 20061102 === INSERT E -
	
	' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_EXCTBZ
	'   概要：  PL/SQL実行処理(排他制御処理)
	'   引数：　Pin_strPRCCASE   : 処理ケース(C:チェック W:書込処理 D:削除処理)
	'           Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御用PL/SQL(PRC_EXCTBZ)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef Pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(担当者コード)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(クライアントID)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(処理ケース)
		Dim strPara4 As String 'ﾊﾟﾗﾒｰﾀ4(業務コード(PGID))
		Dim lngPara5 As Integer 'ﾊﾟﾗﾒｰﾀ5(復帰ｺｰﾄﾞ)
		Dim lngPara6 As Integer 'ﾊﾟﾗﾒｰﾀ6(ｴﾗｰｺｰﾄﾞ)
		Dim strPara7 As String 'ﾊﾟﾗﾒｰﾀ7(ｴﾗｰ内容)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(7) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ = 9
		
		'受渡し変数初期設定
		strPara1 = Inp_Inf.InpTanCd
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = SSS_PrgId
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		
		Pot_strMsg = ""
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7) = gv_Odb_USR1.Parameters("P7")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(7).serverType = ORATYPE_VARCHAR2
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_EXCTBZ_END
		End If
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngPara6 = param(6).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strPara7 = param(7).Value
			Pot_strMsg = strPara7
		End If
		
		'エラー情報設定
		gv_Int_OraErr = lngPara6
		gv_Str_OraErrText = strPara7
		
		AE_Execute_PLSQL_EXCTBZ = lngPara5
		
AE_Execute_PLSQL_EXCTBZ_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P7")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Chk_Lock_EXCTBZ
	'   概要：　排他制御処理
	'   引数：　Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常 1 : 排他業務あり 9 : 異常
	'   備考：  排他制御（排他チェック＆排他テーブルへの書き込み）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'排他チェック
		intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
		If intRet <> 0 Then
			'排他エラー
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御
		intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
		If intRet <> 0 Then
			'排他エラー
			Pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Unlock_EXCTBZ
	'   概要：　排他制御解除処理
	'   引数：　Pot_strMsg       : エラー内容
	'   戻値：　0 : 正常  9 : 異常
	'   備考：  排他制御（排他テーブルからの削除）を行う
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ(ByRef Pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		Pot_strMsg = ""
		bolTrn = False
		
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'排他制御解除
		intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
		If intRet <> 0 Then
			'排他エラー
			Pot_strMsg = strMsg
			CF_Unlock_EXCTBZ = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'コミット
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'ロールバック
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	' === 20061105 === INSERT E -
End Module