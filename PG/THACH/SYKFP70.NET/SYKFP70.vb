Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module SSSMAIN0001
	
	Public Structure Cls_All
		Dim dummy As String
	End Structure
	
	Public SSS_CLTID As New VB6.FixedLengthString(5)
	Public SSS_OPEID As New VB6.FixedLengthString(8)

    'UPGRADE_ISSUE: パラメータ 'As Any' の宣言はサポートされません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' をクリックしてください。
    '2019/09/18 CHG START
    'Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    '2019/09/18 CHG E N D

    'プログラム情報
    Public Const SSS_PrgId As String = "SYKFP70"
	Public Const SSS_PrgNm As String = "出荷予定データ作成"
	
	'メッセージコード
	Private Const pc_strMsgCode_001 As String = "2SYKFP70_001" 'PLSQL実行エラー用メッセージ
	Private Const pc_strMsgCode_002 As String = "2SYKFP70_002"
	
	'INIファイル名
	Private Const pc_strININame As String = "SSSWIN.ini"
	
	'INIファイル読込用定数
	Private Const pc_strIni_LOGPATH As String = "LOG_PATH"
	Private Const pc_strIni_LOGNAME As String = "LOG_NAME"
	
	'INIファイル読込内容格納変数
	Private pv_strLOG_PATH As String 'エラーログファイルパス
	Private pv_strLOG_NAME As String 'エラーログファイル名
	
	'コマンドライン引数内容格納変数
	Private pv_strPGID_Moto As String '呼出元プログラムID
	Private pv_strPGNM_Moto As String '呼出元プログラム名
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub Main
	'   概要：  主処理
	'   引数：  なし
	'   戻値：  なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub Main()
		
		Dim intRet As Short
		Dim intRet_Main As Short
		
		On Error GoTo Err_Main
		
		'初期処理
		intRet = InitMain()
		If intRet <> 0 Then
			GoTo Err_Main
		End If
		
		'トランザクション開始
		Call CF_Ora_BeginTrans(gv_Odb_USR1)
		
		'PLSQL実行処理
		intRet_Main = F_Execute_PLSQL
		If intRet_Main <> 0 Then
			'エラーログ出力
			Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "F_Execute_PLSQL")
		End If
		
		If intRet_Main = 0 Then
			'コミット
			Call CF_Ora_CommitTrans(gv_Odb_USR1)
		Else
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Odb_USR1)
		End If
		
		'終了処理
		intRet = EndMain()
		
End_Main: 
		'終了
		Exit Sub
		
Err_Main: 
		GoTo End_Main
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function InitMain
	'   概要：  初期処理
	'   引数：  なし
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function InitMain() As Short
		
		Dim intRet As Short
		Dim bolRet As Boolean
		Dim strErrMsg As String
		
		InitMain = 9
		
		strErrMsg = ""
		
		'INIファイル読込み
		intRet = F_INIT_GETINI()
		If intRet <> 0 Then
			Exit Function
		End If
		
		'DB接続
		bolRet = CF_Ora_USR1_Open_BAT()
		If bolRet = False Then
			'エラーログ出力
			Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "InitMain")
			Exit Function
		End If
		
		'共通初期化処理
		intRet = CF_Init_BAT(strErrMsg, SSS_PrgId)
		If intRet <> 0 Then
			'エラーログ出力
			Call F_Edit_ErrLog(0, strErrMsg, "InitMain")
			Exit Function
		End If
		
		'コマンドライン引数取得処理
		intRet = F_Get_CmdLine(strErrMsg)
		If intRet <> 0 Then
			'エラーログ出力
			Call F_Edit_ErrLog(0, strErrMsg, "InitMain")
			Exit Function
		End If
		
		InitMain = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Execute_PLSQL
	'   概要：  SQL実行処理
	'   引数：  なし
	'   戻値：  0 : 正常 9: 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Execute_PLSQL() As Short
		
		Dim intRet As Short
		Dim strSQL As String 'SQL文
		Dim strParam1 As String 'ﾊﾟﾗﾒｰﾀ1(ﾌﾟﾛｸﾞﾗﾑID)
		Dim strParam2 As String 'ﾊﾟﾗﾒｰﾀ2(ｸﾗｲｱﾝﾄID)
		Dim lngParam3 As Integer 'ﾊﾟﾗﾒｰﾀ7(復帰ｺｰﾄﾞ)
		Dim strParam4 As New VB6.FixedLengthString(3000) 'ﾊﾟﾗﾒｰﾀ8(ｴﾗｰ内容)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(4) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		F_Execute_PLSQL = 9
		
		'受渡し変数初期設定
		strParam1 = pv_strPGID_Moto
		strParam2 = SSS_CLTID.Value
		lngParam3 = 0
		strParam4.Value = ""
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strParam1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strParam2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", lngParam3, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P4", strParam4.Value, ORAPARM_OUTPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4) = gv_Odb_USR1.Parameters("P4")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(4).serverType = ORATYPE_CHAR
		
		'PL/SQL呼び出しSQL
		strSQL = "BEGIN SYKFP70.P01(:P1,:P2,:P3,:P4); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_Execute_PLSQL_END
		End If
		
		'** 戻り値取得
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		lngParam3 = param(3).Value
		'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
		If IsDbNull(param(4).Value) = False Then
			'UPGRADE_WARNING: オブジェクト param().Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strParam4.Value = param(4).Value
		End If
		
		'エラー情報設定
		gv_Str_OraErrText = Trim(strParam4.Value)
		
		F_Execute_PLSQL = lngParam3
		
F_Execute_PLSQL_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P4")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function EndMain
	'   概要：  終了処理
	'   引数：  なし
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function EndMain() As Short
		
		Dim bolRet As Boolean
		
		EndMain = 9
		
		'DB接続解除
		bolRet = CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
		If bolRet = False Then
			'エラーログ出力
			Call F_Edit_ErrLog(gv_Int_OraErr, gv_Str_OraErrText, "EndMain")
			Exit Function
		End If
		
		EndMain = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_INIT_GETINI
	'   概要：  Iniファイル読込み処理（プログラム固有）
	'   引数：  なし
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_INIT_GETINI() As Short
		
		Dim Wk As New VB6.FixedLengthString(256)
		Dim lngRet As Integer
		Dim intRet As Short
		
		F_INIT_GETINI = 9
		
		' === 20061102 === UPDATE S - ACE)Nagasawa INIファイル格納場所変更
		'    'SSSWIN.INI 読込み
		'    'ログファイルパス
		'    lngRet = GetPrivateProfileString(SSS_PrgId, pc_strIni_LOGPATH, "", Wk, Len(Wk), pc_strININame)
		'    If lngRet > 0 Then
		'        pv_strLOG_PATH = CF_Ctr_AnsiLeftB(Wk, lngRet)
		'        pv_strLOG_PATH = Trim$(pv_strLOG_PATH)
		'        If Right(pv_strLOG_PATH, 1) <> "\" Then
		'            pv_strLOG_PATH = pv_strLOG_PATH & "\"
		'        End If
		'    Else
		'        Exit Function
		'    End If
		'
		'    'ログファイル名
		'    lngRet = GetPrivateProfileString(SSS_PrgId, pc_strIni_LOGNAME, "", Wk, Len(Wk), pc_strININame)
		'    If lngRet > 0 Then
		'        pv_strLOG_NAME = CF_Ctr_AnsiLeftB(Wk, lngRet)
		'        pv_strLOG_NAME = Trim$(pv_strLOG_NAME)
		'    Else
		'        Exit Function
		'    End If
		
		'SSSWIN.INI 読込み
		'ログファイルパス
		intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_LOGPATH, pv_strLOG_PATH)
		If lngRet <> 0 Then
			Exit Function
		End If
		
		'ログファイル名
		intRet = CF_Get_IniInf(SSS_PrgId, pc_strIni_LOGNAME, pv_strLOG_NAME)
		If lngRet <> 0 Then
			Exit Function
		End If
		' === 20061102 === UPDATE E -
		
		F_INIT_GETINI = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Edit_ErrLog
	'   概要：  エラーログ出力処理
	'   引数：  pin_intErrCd       : エラーコード（オラクルエラー時以外はゼロ）
	'           pin_strErrMsg      : エラーメッセージ
	'           pin_strErrLocation : 発生箇所（ファンクション名）
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Edit_ErrLog(ByVal pin_intErrCd As Short, ByVal pin_strErrMsg As String, ByVal pin_strErrLocation As String) As Short
		
		Dim intRet As Short
		Dim strTime As String
		Dim strDate As String
		
		F_Edit_ErrLog = 9
		
		strTime = ""
		strDate = ""
		
		'システム日付取得
		Call CF_Get_SysDt()
		If GV_SysDate = "" Then
			strDate = VB6.Format(Now, "yyyymmdd")
		Else
			strDate = GV_SysDate
		End If
		
		If GV_SysTime = "" Then
			strTime = VB6.Format(Now, "HHMMSS")
		Else
			strTime = GV_SysTime
		End If
		
		'エラーログ書き込み
		Call CF_Edit_ErrLog(pv_strLOG_PATH, pv_strLOG_NAME, SSS_PrgId, pin_intErrCd, pin_strErrMsg, pin_strErrLocation, strTime, strDate)
		
		'エラーメッセージ出力処理
		If pin_intErrCd <> 0 Then
			Call AE_CmnMsgLibrary_Bat(pv_strPGNM_Moto, pc_strMsgCode_001, "SYKFP70.P01")
		Else
			Call AE_CmnMsgLibrary_Bat(pv_strPGNM_Moto, pc_strMsgCode_002, pin_strErrMsg)
		End If
		
		F_Edit_ErrLog = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_CmdLine
	'   概要：  コマンドライン引数取得処理
	'   引数：  pot_strErrMsg : エラーメッセージ
	'   戻値：  0 : 正常 9 : 異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_CmdLine(ByRef pot_strErrMsg As String) As Short
		
		Dim intRet As Short
		Dim strTime As String
		Dim strDate As String
		Dim strCmd() As String
		Dim strCmd2() As String
		
		F_Get_CmdLine = 9
		
		pot_strErrMsg = ""
		
		strCmd = Split(Trim(VB.Command()), "/")
		If UBound(strCmd) < 3 Then
			pot_strErrMsg = SSS_PrgNm & "処理実行用の引数が正しくありません。設定を確認してください。"
			Exit Function
		End If
		
		'クライアントID取得
		strCmd2 = Split(Trim(strCmd(1)), ":")
		Select Case True
			'引数がコロンで区切られていない場合
			Case UBound(strCmd2) < 1
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数が正しくありません。設定を確認してください。"
				'引数の位置が正しくない場合
			Case UCase(Trim(strCmd2(0))) <> "CLTID"
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数(ｸﾗｲｱﾝﾄID)が正しくありません。設定を確認してください。"
			Case Else
				SSS_CLTID.Value = Trim(strCmd2(1))
		End Select
		
		If Trim(pot_strErrMsg) <> "" Then
			Exit Function
		End If
		
		'プログラムID取得
		strCmd2 = Split(Trim(strCmd(2)), ":")
		Select Case True
			'引数がコロンで区切られていない場合
			Case UBound(strCmd2) < 1
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数が正しくありません。設定を確認してください。"
				'引数の位置が正しくない場合
			Case UCase(Trim(strCmd2(0))) <> "PGID"
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数(ﾌﾟﾛｸﾞﾗﾑID)が正しくありません。設定を確認してください。"
			Case Else
				pv_strPGID_Moto = Trim(strCmd2(1))
		End Select
		
		If Trim(pot_strErrMsg) <> "" Then
			Exit Function
		End If
		
		'プログラム名取得
		strCmd2 = Split(Trim(strCmd(3)), ":")
		Select Case True
			'引数がコロンで区切られていない場合
			Case UBound(strCmd2) < 1
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数が正しくありません。設定を確認してください。"
				'引数の位置が正しくない場合
			Case UCase(Trim(strCmd2(0))) <> "PGNM"
				pot_strErrMsg = SSS_PrgNm & "処理実行用の引数(ﾌﾟﾛｸﾞﾗﾑ名)が正しくありません。設定を確認してください。"
			Case Else
				pv_strPGNM_Moto = Trim(strCmd2(1))
		End Select
		
		If Trim(pot_strErrMsg) <> "" Then
			Exit Function
		End If
		
		F_Get_CmdLine = 0
		
	End Function
End Module