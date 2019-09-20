Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

Friend Class ClsOraDB
	'//*****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ClsOraDB
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    RISE
	'//*＜説明＞
	'//*    データベース関連・共通クラス
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20060705|Rise)          |新規
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// エラーメッセージ用
	'//-----------------------------------------------------------------------------------------
	Private Const cst_異常 As String = "実行時エラーです。システム担当者に連絡して下さい。"
	Private Const cst_詳細 As String = vbCrLf & vbCrLf & "[ 詳細 ]" & vbCrLf
	Private Const cst_参考 As String = vbCrLf & vbCrLf & "[ 参考 ]" & vbCrLf
	
	'//-----------------------------------------------------------------------------------------
	'// オラクルオブジェクト
	'//-----------------------------------------------------------------------------------------
	Private mv_OracleSession As Object 'Oracleセッション
	'UPGRADE_ISSUE: OraDatabase オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Private mv_OraDatabase As OraDatabase 'Oracleデータベース
	'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
	Private mv_OraDynaset As OraDynaset 'Oracleダイナセット
	Private mv_strUser As String '接続ユーザ
	Private mv_strPassword As String 'パスワード
	Private mv_strDBName As String 'サービス名
	
	'//****************************************************************************************
	'//イニシャライズ
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Initialize_Renamed()
		
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'//****************************************************************************************
	'//ターミネイト
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Terminate は Class_Terminate_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Terminate_Renamed()
		Call OraDisConnect()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	'//****************************************************************************************
	'//* <プロパティ>
	'//*     Msg_Conn
	'//* <説  明>
	'//*    コネクションの取得
	'//****************************************************************************************
	Public ReadOnly Property OraDatabase() As Object
		Get
			OraDatabase = mv_OraDatabase
		End Get
	End Property
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraConnect
	'　機能　　Oracleに対しoo4oにて接続を行う
	'　引数　　なし
	'　返値　　ブール値(Boolean)
	'　備考　　接続に成功した場合、返値にTrueを返却
	'　　　　　接続に失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraConnect(ByRef pDBNAME As Object, ByRef pLOGINID As Object, ByRef pPASSWORD As Object, Optional ByVal pMsgDsp As Boolean = True) As Boolean
		Dim ORADYN_DEFAULT As Object
		
		Const PROCEDURE As String = "OraConnect"
		
		On Error GoTo ONERR_STEP
		
		OraConnect = False
		
		' 接続文字列を設定
		'UPGRADE_WARNING: オブジェクト pDBNAME の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_strDBName = pDBNAME
		'UPGRADE_WARNING: オブジェクト pLOGINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_strUser = pLOGINID
		'UPGRADE_WARNING: オブジェクト pPASSWORD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_strPassword = pPASSWORD
		
		' Oracleセッションの作成
		mv_OracleSession = CreateObject("OracleInProcServer.XOraSession")
		'UPGRADE_WARNING: オブジェクト mv_OracleSession.OpenDatabase の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_OraDatabase = mv_OracleSession.OpenDatabase(Trim(mv_strDBName), Trim(mv_strUser) & "/" & Trim(mv_strPassword), ORADYN_DEFAULT)
		
		OraConnect = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If pMsgDsp Then
			MsgBox("<" & PROCEDURE & "> " & vbCrLf & "データベースの接続に失敗しました。処理を中止します。" & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		End If
		Resume EXIT_STEP
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraDisConnect
	'　機能　　Oracleの接続を切断する
	'　引数　　なし
	'　返値　　ブール値(Boolean)
	'　備考　　接続に成功した場合、返値にTrueを返却
	'　　　　　接続に失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraDisConnect(Optional ByVal pMsgDsp As Boolean = True) As Boolean
		
		Const PROCEDURE As String = "OraDisConnect"
		
		On Error GoTo ONERR_STEP
		
		OraDisConnect = False
		
		' 接続を切断する
		
		If Not mv_OraDynaset Is Nothing Then
			'UPGRADE_NOTE: オブジェクト mv_OraDynaset をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			mv_OraDynaset = Nothing
		End If
		
		If Not mv_OraDatabase Is Nothing Then
			'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Close の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			mv_OraDatabase.Close()
			'UPGRADE_NOTE: オブジェクト mv_OraDatabase をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			mv_OraDatabase = Nothing
		End If
		
		If Not mv_OracleSession Is Nothing Then
			'UPGRADE_NOTE: オブジェクト mv_OracleSession をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			mv_OracleSession = Nothing
		End If
		
		OraDisConnect = True
		
		On Error GoTo 0
		Exit Function
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		If pMsgDsp Then
			MsgBox("<" & PROCEDURE & "> " & vbCrLf & "データベースの切断に失敗しました。処理を中止します。" & cst_詳細 & Err.Description, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		End If
		Resume EXIT_STEP
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraCreateDyn
	'　機能　　レコードセットを取得します
	'　引数　　SQL文(String)
	'          レコード(Object)
	'          レコードセットオプション(Variant)
	'　返値　　ブール値(Boolean)
	'　備考　　取得成功の場合、返値にTrueを返却
	'　　　　　取得失敗の場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraCreateDyn(ByVal pSQL As String, ByRef pOBJ As OraDynaset, Optional ByVal pOption As Object = Nothing, Optional ByVal pCallProcedure As String = "", Optional ByVal pMsgDsp As Boolean = True) As Boolean

        '2019/04/11 DEL START
        '       Dim ORATYPE_VARCHAR2 As Object
        '		Dim ORAPARM_INPUT As Object
        '		Dim ORADYN_NO_BLANKSTRIP As Object
        '		Dim ORADYN_NO_REFETCH As Object
        '		Dim ORADYN_NOCACHE As Object
        '		Dim ORADYN_READONLY As Object

        '		Const PROCEDURE As String = "OraCreateDyn"

        '		Dim IntCnt As Integer '//フィールドカウンタ
        '		Dim LngOption As Integer '//ﾊﾟﾗﾒｰﾀ（ORADYN_READONLY Or ORADYN_NOCACHEなど）
        '		Dim vlStrERRMsg As String

        '		On Error GoTo ERR_HANDLE

        '		'// ﾊﾟﾗﾒｰﾀの設定
        '		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '		If IsNothing(pOption) = False Then
        '			'UPGRADE_WARNING: オブジェクト pOption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			LngOption = CInt(pOption)
        '		Else
        '			'UPGRADE_WARNING: オブジェクト ORADYN_NO_BLANKSTRIP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト ORADYN_NO_REFETCH の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト ORADYN_NOCACHE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト ORADYN_READONLY の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			LngOption = ORADYN_READONLY + ORADYN_NOCACHE + ORADYN_NO_REFETCH + ORADYN_NO_BLANKSTRIP
        '		End If

        '		'// SQLｽﾃｰﾄﾒﾝﾄの実行
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.CreateDynaset の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		pOBJ = mv_OraDatabase.CreateDynaset(pSQL, LngOption)

        '		'//正常終了
        '		OraCreateDyn = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 

        '		If pMsgDsp Then
        '			'ｴﾗｰﾒｯｾｰｼﾞ表示
        '			'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & CStr(mv_OraDatabase.LastServerErrText), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        '		End If

        '		'ﾊﾟﾗﾒｰﾀのｸﾘｱ
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '		'PL/SQLを呼ぶ
        '		'プログラムID
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_ID", My.Application.Info.Title, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_ID").serverType = ORATYPE_VARCHAR2

        '		'エラー番号
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_CODE", mv_OraDatabase.LastServerErr, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_CODE").serverType = ORATYPE_VARCHAR2

        '		'エラー内容
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_MSG", mv_OraDatabase.LastServerErrText, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_MSG").serverType = ORATYPE_VARCHAR2

        '		'発生場所
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_POINT", pCallProcedure, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_POINT").serverType = ORATYPE_VARCHAR2

        '		clsOra.OraExecute("BEGIN PTERRLOG(:PARA_ID,:PARA_CODE,:PARA_MSG,:PARA_POINT); END;")

        '		'ﾊﾟﾗﾒｰﾀのｸﾘｱ
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraCloseDyn
	'　機能　　引数のレコードセットをクローズ及び解放します。
	'　引数　　レコードセット情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　開放成功の場合、返値にTrueを返却
	'　　　　　開放失敗の場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraCloseDyn(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraCloseDyn = False
		
		If (pOBJ Is Nothing) = False Then
			'UPGRADE_NOTE: オブジェクト pOBJ をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			pOBJ = Nothing
		End If
		
		OraCloseDyn = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	'----------------------------------------------------------------------------------------
	'　関数名　OraBeginTrans
	'　機能　　トランザクション制御の開始
	'　引数　　データベース接続情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　接続に成功した場合、返値にTrueを返却
	'　　　　　接続に失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraBeginTrans() As Boolean
		
		Const PROCEDURE As String = "OraBeginTrans"
		
		On Error GoTo ONERR_STEP
		
		OraBeginTrans = False
		
		'//ﾄﾗﾝｻﾞｸｼｮﾝ開始
		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.DbBeginTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_OraDatabase.DbBeginTrans()
		
		'//正常終了
		OraBeginTrans = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 ↓ DEL STR
		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
		'''''                            cst_詳細 & Err.Description, _
		'''''                            vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 ↑ DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraCommitTrans
	'　機能　　トランザクションのコミット
	'　引数　　データベース接続情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　コミットに成功した場合、返値にTrueを返却
	'　　　　　コミットに失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraCommitTrans() As Boolean
		
		Const PROCEDURE As String = "OraCommitTrans"
		
		On Error GoTo ONERR_STEP
		
		OraCommitTrans = False
		
		'//ｺﾐｯﾄ
		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.DbCommitTrans の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_OraDatabase.DbCommitTrans()
		
		'//正常終了
		OraCommitTrans = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 ↓ DEL STR
		''''        MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
		'''''                                cst_詳細 & Err.Description, _
		'''''                                vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 ↑ DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraRollback
	'　機能　　トランザクションのロールバック
	'　引数　　データベース接続情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　ロールバックに成功した場合、返値にTrueを返却
	'　　　　　ロールバックに失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraRollback() As Boolean
		
		Const PROCEDURE As String = "OraRollback"
		
		On Error GoTo ONERR_STEP
		
		OraRollback = False
		
		'//ｺﾐｯﾄ
		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.DbRollback の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		mv_OraDatabase.DbRollback()
		
		'//正常終了
		OraRollback = True
		
		'----------------------------------------------------------------------------------------
EXIT_STEP: 
		On Error GoTo 0
		Exit Function
		'----------------------------------------------------------------------------------------
ONERR_STEP: 
		'// 2007/01/17 ↓ DEL STR
		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
		'''''                            cst_詳細 & Err.Description, _
		'''''                            vbOKOnly + vbCritical, App.Title
		'// 2007/01/17 ↑ DEL END
	End Function
	
	'----------------------------------------------------------------------------------------
	'　関数名　OraExecute
	'　機能　　更新系(INSERT UPDATE DELETE)のSQLｽﾃｰﾄﾒﾝﾄを実行
	'　引数　　データベース接続情報(Object)
	'          SQL文字列(String)
	'          実行レコード数(Long)
	'          メッセージ表示・非表示(Boolean)
	'　返値　　ブール値(Boolean)
	'　備考　　実行に成功した場合、返値にTrueを返却
	'　　　　　実行に失敗した場合、返値にFalseを返却
	'----------------------------------------------------------------------------------------
	Public Function OraExecute(ByVal pSQL As String, Optional ByRef pRowCnt As Integer = 0, Optional ByVal pCallProcedure As String = "", Optional ByVal pMsgDsp As Boolean = True) As Boolean

        '2019/04/11 DEL START
        '       Dim ORATYPE_VARCHAR2 As Object
        '		Dim ORAPARM_INPUT As Object

        '		Dim LngRowCnt As Integer '//実行の戻り値
        '		Dim vlStrERRMsg As String

        '		Const PROCEDURE As String = "OraExecute"

        '		On Error GoTo RUNTIME_ERROR

        '		OraExecute = False

        '		'// SQLｽﾃｰﾄﾒﾝﾄの実行
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.ExecuteSQL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		LngRowCnt = mv_OraDatabase.ExecuteSQL(pSQL)

        '		'UPGRADE_NOTE: IsMissing() は IsNothing() に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' をクリックしてください。
        '		If Not IsNothing(pRowCnt) Then
        '			pRowCnt = LngRowCnt
        '		End If

        '		'//正常終了
        '		OraExecute = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'RUNTIME_ERROR: 

        '		If pMsgDsp Then
        '			'ｴﾗｰﾒｯｾｰｼﾞ表示
        '			'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			MsgBox("<" & PROCEDURE & "> " & vbCrLf & cst_異常 & cst_詳細 & CStr(mv_OraDatabase.LastServerErrText), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
        '		End If

        '		'ﾊﾟﾗﾒｰﾀのｸﾘｱ
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '		'PL/SQLを呼ぶ
        '		'プログラムID
        '		'UPGRADE_WARNING: App プロパティ App.EXEName には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_ID", My.Application.Info.AssemblyName, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_ID").serverType = ORATYPE_VARCHAR2

        '		'エラー番号
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErr の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_CODE", mv_OraDatabase.LastServerErr, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_CODE").serverType = ORATYPE_VARCHAR2

        '		'エラー内容
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.LastServerErrText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_MSG", mv_OraDatabase.LastServerErrText, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_MSG").serverType = ORATYPE_VARCHAR2

        '		'発生場所
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Add("PARA_POINT", pCallProcedure, ORAPARM_INPUT)
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		'UPGRADE_WARNING: オブジェクト ORATYPE_VARCHAR2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters("PARA_POINT").serverType = ORATYPE_VARCHAR2

        '		clsOra.OraExecute("BEGIN PTERRLOG(:PARA_ID,:PARA_CODE,:PARA_MSG,:PARA_POINT); END;")

        '		'ﾊﾟﾗﾒｰﾀのｸﾘｱ
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_ID")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_CODE")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_MSG")
        '		'UPGRADE_WARNING: オブジェクト mv_OraDatabase.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		mv_OraDatabase.Parameters.Remove("PARA_POINT")

        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraBOF
	'　機能　　BOFチェックを行います
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　ＢＯＦの場合、返値にTrueを返却
	'　　　　　ＢＯＦ以外の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraBOF(ByRef pOBJ As OraDynaset) As Boolean
		
		'UPGRADE_WARNING: オブジェクト pOBJ.BOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		OraBOF = pOBJ.BOF
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraEOF
	'　機能　　EOFチェックを行います
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　ＥＯＦの場合、返値にTrueを返却
	'　　　　　ＥＯＦ以外の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraEOF(ByRef pOBJ As OraDynaset) As Boolean
		
		'UPGRADE_WARNING: オブジェクト pOBJ.EOF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		OraEOF = pOBJ.EOF
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMoveFirst
	'　機能　　レコードセットの先頭へ移動します
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMoveFirst(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMoveFirst = False
		
		'//先頭レコードへ移動
		'UPGRADE_WARNING: オブジェクト pOBJ.MoveFirst の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pOBJ.MoveFirst()
		
		'//正常終了
		OraMoveFirst = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMoveLast
	'　機能　　レコードセットの末尾へ移動します
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMoveLast(ByRef pOBJ As OraDynaset) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMoveLast = False

        '		'//先頭レコードへ移動
        '		'UPGRADE_WARNING: オブジェクト pOBJ.OraMoveLast の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		pOBJ.OraMoveLast()

        '		'//正常終了
        '		OraMoveLast = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMovePrev
	'　機能　　レコードセットの一つ前へ移動します
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMovePrev(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMovePrev = False
		
		'//前レコードに移動
		'UPGRADE_WARNING: オブジェクト pOBJ.MovePrevious の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pOBJ.MovePrevious()
		
		'//正常終了
		OraMovePrev = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMoveNext
	'　機能　　レコードセットの次のレコードへ移動します
	'　引数　　テーブル情報(Object)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMoveNext(ByRef pOBJ As OraDynaset) As Boolean
		
		On Error GoTo ERR_HANDLE
		
		OraMoveNext = False
		
		'//次レコードに移動
		'UPGRADE_WARNING: オブジェクト pOBJ.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pOBJ.MoveNext()
		
		'//正常終了
		OraMoveNext = True
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMovePrevN
	'　機能　　指定行数分レコードセットの前のレコードへ移動します
	'　引数　　テーブル情報(Object)
	'　　　　　移動レコード数(Long)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMovePrevN(ByRef pOBJ As OraDynaset, ByVal pRow As Integer) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMovePrevN = False

        '		'//Ｎ行分前レコードに移動
        '		'UPGRADE_WARNING: オブジェクト pOBJ.MovePreviousn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		pOBJ.MovePreviousn(pRow)

        '		'//正常終了
        '		OraMovePrevN = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function
	
	'-----------------------------------------------------------
	'　関数名　OraMoveNextN
	'　機能　　指定行数分レコードセットの次のレコードへ移動します
	'　引数　　テーブル情報(Object)
	'　　　　　移動レコード数(Long)
	'　返値　　ブール値(Boolean)
	'　備考　　移動成功の場合、返値にTrueを返却
	'　　　　　移動失敗の場合、返値にFalseを返却
	'-----------------------------------------------------------
	Public Function OraMoveNextN(ByRef pOBJ As OraDynaset, ByVal pm_Row As Integer) As Boolean

        '2019/04/11 DEL START
        '		On Error GoTo ERR_HANDLE

        '		OraMoveNextN = False

        '		'//Ｎ行分次レコードに移動
        '		'UPGRADE_WARNING: オブジェクト pOBJ.MoveNextn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		pOBJ.MoveNextn(pm_Row)

        '		'//正常終了
        '		OraMoveNextN = True

        'EXIT_HANDLE: 
        '		On Error GoTo 0
        '		Exit Function

        'ERR_HANDLE: 
        '        GoTo EXIT_HANDLE
        '2019/04/11 DEL E N D
		
	End Function

    '2019/04/12 DEL START
    '    '-----------------------------------------------------------
    '    '　関数名　GetNowDt
    '    '　機能　　サーバの現在日付取得
    '    '　引数　　戻り値の書式区分(0:yymmdd 1:yyyymmdd) (省略時=0)
    '    '　返値　　現在日付(YYYYMMDD)
    '    '　備考　　なし
    '    '-----------------------------------------------------------
    '	Public Function OraGetNowDt(Optional ByVal pmiKBN As Short = 0) As String

    '		Const PROCEDURE As String = "OraGetNowDt"

    '		On Error GoTo ONERR_STEP

    '		Dim strSQL As String
    '		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '		Dim objRec As OraDynaset
    '		Dim lngDate As Integer

    '		' SQL文の作成
    '		strSQL = ""
    '		strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'YYYYMMDD') NDATE " & vbCrLf
    '		strSQL = strSQL & "FROM   DUAL " & vbCrLf

    '		'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

    '        '2019/04/12 ADD START
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

    '        '2019/04/12 ADD START
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then 
    '            lngDate = dt.Rows(0)("NDATE")
    '        Else
    '            lngDate = Format(Now, "YYYYMMDD")
    '        End If 
    '        '2019/04/12 ADD E N D

    '        Select Case pmiKBN
    '            Case 0
    '                OraGetNowDt = Mid(CStr(lngDate), 3)
    '            Case 1
    '                OraGetNowDt = CStr(lngDate)
    '        End Select

    '        'UPGRADE_WARNING: OraGetNowDt に変換されていないステートメントがあります。ソース コードを確認してください。

    '        '----------------------------------------------------------------------------------------
    'EXIT_STEP:
    '        On Error GoTo 0
    '        Exit Function
    '        '----------------------------------------------------------------------------------------
    'ONERR_STEP:
    '        '// 2007/01/17 ↓ DEL STR
    '        ''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
    '        '''''                            cst_詳細 & Err.Description, _
    '        '''''                            vbOKOnly + vbCritical, App.Title
    '        '// 2007/01/17 ↑ DEL END
    '        Resume EXIT_STEP
    '	End Function
    '2019/04/12 DEL E N D

    '2019/04/12 DEL START
    '    '-----------------------------------------------------------
    '	'　関数名　GetNowTm
    '	'　機能　　サーバの現在時刻取得
    '	'　引数　　なし
    '	'　返値　　現在時刻(HHMMSS)
    '	'　備考　　なし
    '	'-----------------------------------------------------------
    '	Public Function OraGetNowTm() As String

    '		Const PROCEDURE As String = "OraGetNowTm"

    '		On Error GoTo ONERR_STEP

    '		Dim strSQL As String
    '		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '		Dim objRec As OraDynaset

    '		' SQL文の作成
    '		strSQL = ""
    '		strSQL = strSQL & "SELECT TO_CHAR(SYSDATE, 'HH24MISS') NTIME " & vbCrLf
    '		strSQL = strSQL & "FROM   DUAL " & vbCrLf

    '		' データ取得
    '		'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

    '        '2019/04/12 ADD START
    '        Dim dt As DataTable = DB_GetTable(strSQL)
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

    '        '2019/04/12 ADD START
    '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '            OraGetNowTm = dt.Rows(0)("NTIME")
    '        Else
    '            OraGetNowTm = Format(Now, "HHMMSS")
    '        End If
    '        '2019/04/12 ADD E N D

    '		'UPGRADE_WARNING: OraGetNowTm に変換されていないステートメントがあります。ソース コードを確認してください。

    '		'----------------------------------------------------------------------------------------
    'EXIT_STEP: 
    '		On Error GoTo 0
    '		Exit Function
    '		'----------------------------------------------------------------------------------------
    'ONERR_STEP: 
    '		'// 2007/01/17 ↓ DEL STR
    '		''''    MsgBox "<" & PROCEDURE & "> " & vbCrLf & cst_異常 & _
    '		'''''                            cst_詳細 & Err.Description, _
    '		'''''                            vbOKOnly + vbCritical, App.Title
    '		'// 2007/01/17 ↑ DEL END
    '		Resume EXIT_STEP
    '	End Function
    '2019/04/12 DEL E N D
End Class