Option Strict Off
Option Explicit On

Friend Class ClsMessage
	'//****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ClsMessage
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    RISE
	'//*＜説明＞
	'//*    メッセージコードに対するメッセージの表示を行なう
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20040401|Rise)          |新規
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// エラーメッセージ用
	'//-----------------------------------------------------------------------------------------
	Private Const cst_異常 As String = "実行時エラーです。システム担当者に連絡して下さい。"
	Private Const cst_詳細 As String = vbCrLf & vbCrLf & "[ 詳細 ]" & vbCrLf
	Private Const cst_参考 As String = vbCrLf & vbCrLf & "[ 参考 ]" & vbCrLf
	
	'//*****************************************************************************************
	'// 定数　　定義
	'//*****************************************************************************************
	'メッセージ登録値
	'ボタン種別
	Private Const gc_strBTNKB_OKOnly As Decimal = 0 'OK
	Private Const gc_strBTNKB_OKCancel As Decimal = 1 'OK/キャンセル
	Private Const gc_strBTNKB_AbortRetryIgnore As Decimal = 2 '中止/再試行/無視
	Private Const gc_strBTNKB_YesNoCancel As Decimal = 3 'はい/いいえ/キャンセル
	Private Const gc_strBTNKB_YesNo As Decimal = 4 'はい/いいえ
	Private Const gc_strBTNKB_RetryCancel As Decimal = 5 '再試行/キャンセル
	
	'//*****************************************************************************************
	'// 構造体定義 SYSTBH.DBM   システムメッセージ
	'//*****************************************************************************************
	Private Structure TYPE_DB_SYSTBH
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MSGKB() As Char 'メッセージ種別        0
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(15),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=15)> Public MSGNM() As Char 'メッセージアイテム
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public MSGSQ() As Char 'メッセージ連番        X(01)
		Dim BTNKB As Decimal 'ボタン種別            000
		Dim BTNON As Decimal 'ボタン初期値          000
		Dim ICNKB As Decimal 'アイコン種別          00
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public MSGCM() As Char 'メッセージ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public COLSQ() As Char '色シーケンス          0
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
	End Structure
	
	'//*****************************************************************************************
	'// ｸﾗｽ関数　　定義
	'//*****************************************************************************************
	Private D0 As ClsComn '//System 関数
	
	'//*****************************************************************************************
	'// 変数   宣言
	'//*****************************************************************************************
	'UPGRADE_ISSUE: OraDatabase オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '2019/04/26 DEL START
    'Private mv_OraDatabase As OraDatabase 'Oracleデータベース
    '2019/04/26 DEL E N D
    'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
    '2019/04/26 DEL START
    'Private mv_OraDynaset As OraDynaset 'Oracleダイナセット
    '2019/04/26 DEL E N D

    '2019/04/26 DEL START
    ''//****************************************************************************************
    ''//* <プロパティ>
    ''//*     Msg_Conn
    ''//* <説  明>
    ''//*    コネクションの取得
    ''//****************************************************************************************
    'Public WriteOnly Property OraDatabase() As OraDatabase
    '	Set(ByVal Value As OraDatabase)
    '		mv_OraDatabase = Value
    '	End Set
    'End Property
    '2019/04/26 DEL E N D

	'//****************************************************************************************
	'//イニシャライズ
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Initialize_Renamed()
		D0 = New ClsComn
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
		If Not (D0 Is Nothing) Then
			'UPGRADE_NOTE: オブジェクト D0 をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
			D0 = Nothing
		End If
        '2019/04/26 DEL START
        'If Not (mv_OraDynaset Is Nothing) Then
        '	'UPGRADE_NOTE: オブジェクト mv_OraDynaset をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '	mv_OraDynaset = Nothing
        'End If
        'If Not (mv_OraDatabase Is Nothing) Then
        '	'UPGRADE_NOTE: オブジェクト mv_OraDatabase をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
        '	mv_OraDatabase = Nothing
        'End If
        '2019/04/26 DEL E N D
    End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function MsgLibrary
	'   概要：  標準メッセージ表示処理
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pin_strMsg      : 追加メッセージ
	'   戻値：  選択ボタン
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		Dim vnt_MousePointer As Object
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		vnt_MousePointer = System.Windows.Forms.Cursor.Current
		D0.Mouse_OFF()
		
		MsgLibrary = False
		
		strMSGKBN = D0.Ctr_AnsiLeftB(Pin_strMsgCode, 1) 'メッセージ種別
		strMSGNM = D0.Ctr_AnsiMidB(Pin_strMsgCode, 2) 'メッセージアイテム
		
		'メッセージマスタ検索
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
				'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
				System.Windows.Forms.Cursor.Current = vnt_MousePointer
				Exit Function
			End If
		End If
		
		'追加メッセージの編集
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'ＤＢアクセス系エラーとする
			''''        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "発生箇所   : " & pin_strMsg
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'Windowsに制御を戻す
		System.Windows.Forms.Application.DoEvents()
		
		'メッセージ表示
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/キャンセル
			Case gc_strBTNKB_OKCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'中止/再試行/無視
			Case gc_strBTNKB_AbortRetryIgnore
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ/キャンセル
			Case gc_strBTNKB_YesNoCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'はい/いいえ
			Case gc_strBTNKB_YesNo
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'再試行/キャンセル
			Case gc_strBTNKB_RetryCancel
				MsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
		'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function DSPMSGCM_SEARCH
	'   概要：  システムメッセージ検索
	'   引数：  pin_strMSGKB    : メッセージ種別
	'           pin_strMSGNM    : メッセージアイテム
	'           pin_strMSGSQ　　: メッセージ連番
	'           pot_DB_SYSTBH   : 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short
		
		Dim strSQL As String
        '2019/04/26 DEL START
        'Dim intData As Short
        '2019/04/26 DEL E N D
        'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/26 DEL START
        'Dim objRec As OraDynaset
        '2019/04/26 DEL E N D
        Dim vnt_MousePointer As Object
		
		Const PROCEDURE As String = "DSPMSGCM_SEARCH"
		
		On Error GoTo ERR_DSPMSGCM_SEARCH
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		vnt_MousePointer = System.Windows.Forms.Cursor.Current
		D0.Mouse_OFF()
		
		DSPMSGCM_SEARCH = 9
		
		strSQL = ""
		strSQL = strSQL & " Select * "
		strSQL = strSQL & "   from SYSTBH "
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  Where MSGKB     = " & D0.Edt_SQL("S", pin_strMSGKB, False)
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "    and MSGNM     = " & D0.Edt_SQL("S", pin_strMSGNM, True)
		'UPGRADE_WARNING: オブジェクト D0.Edt_SQL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "    and MSGSQ     = " & D0.Edt_SQL("S", pin_strMSGSQ, False)
		
		'UPGRADE_WARNING: DSPMSGCM_SEARCH に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        Dim dt As DataTable = DB_GetTable(strSQL)
        '2019/04/12 ADD E N D

		'UPGRADE_WARNING: DSPMSGCM_SEARCH に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/12 ADD START
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            With pot_DB_SYSTBH
                .MSGKB = D0.Chk_Null(dt.Rows(0)("MSGKB"))                    'メッセージ種別
                .MSGNM = D0.Chk_Null(dt.Rows(0)("MSGNM"))                    'メッセージアイテム
                .MSGSQ = D0.Chk_Null(dt.Rows(0)("MSGSQ"))                    'メッセージ連番
                .BTNKB = D0.Chk_Null(dt.Rows(0)("BTNKB"))                    'ボタン種別
                .BTNON = D0.Chk_Null(dt.Rows(0)("BTNON"))                    'ボタン初期値
                .ICNKB = D0.Chk_Null(dt.Rows(0)("ICNKB"))                    'アイコン種別
                .MSGCM = D0.Chk_Null(dt.Rows(0)("MSGCM"))                    'メッセージ
                .COLSQ = D0.Chk_Null(dt.Rows(0)("COLSQ"))                    '色シーケンス
                .OPEID = D0.Chk_Null(dt.Rows(0)("OPEID"))                    '最終作業者コード
                .CLTID = D0.Chk_Null(dt.Rows(0)("CLTID"))                    'クライアントＩＤ
                .WRTTM = D0.Chk_Null(dt.Rows(0)("WRTTM"))                    'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
                .WRTDT = D0.Chk_Null(dt.Rows(0)("WRTDT"))                    'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
            End With
        Else
            '取得データなし
            DSPMSGCM_SEARCH = 1
            System.Windows.Forms.Cursor.Current = vnt_MousePointer
            Exit Function
        End If
        '2019/04/12 ADD E N D

		'UPGRADE_WARNING: DSPMSGCM_SEARCH に変換されていないステートメントがあります。ソース コードを確認してください。
		
		'クローズ
		'UPGRADE_WARNING: DSPMSGCM_SEARCH に変換されていないステートメントがあります。ソース コードを確認してください。
		
		DSPMSGCM_SEARCH = 0
		
		'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
		Exit Function
		
ERR_DSPMSGCM_SEARCH: 
		
		'UPGRADE_WARNING: オブジェクト vnt_MousePointer の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_ISSUE: Screen プロパティ Screen.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = vnt_MousePointer
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RuntimeErrorMsg
	'   概要：  標準メッセージ表示処理
	'   引数：  Pin_strPgNm     : プログラム名
	'           Pin_strMsgCode  : メッセージコード（DB検索用）
	'           pin_strMsg      : 追加メッセージ
	'   戻値：  選択ボタン
	'   備考：  アプリの実行時に出力される標準メッセージ。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RuntimeErrorMsg(ByVal strDescription As String, ByVal strProcedureNM As String, Optional ByVal strAddMessage As String = "") As Object
		
		Call MsgBox("<" & strProcedureNM & "> " & vbCrLf & cst_異常 & cst_詳細 & strDescription & IIf(strAddMessage = "", "", cst_参考 & strAddMessage), MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, My.Application.Info.Title)
		
	End Function
End Class