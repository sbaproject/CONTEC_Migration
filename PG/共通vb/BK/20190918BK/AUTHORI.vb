Option Strict Off
Option Explicit On

'2019/04/10 ADD START
Imports PronesDbAccess
'2019/04/10 ADD E N D

Module AUTHORITY_DBM
	'//*****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    AUTHORI.bas
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    RISE
	'//*＜説明＞
	'//*    システム関連・共通モジュール（プログラムの実行権限を取得）
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20070110|Rise)          |共通プログラムの実行権限の取得モジュールより作成
	'//*****************************************************************************************
	Public gs_kengen As String
	Public gs_ari As String
	Public gs_userid As String
	Public gs_pgid As String
	Public gs_UPDAUTH As String
	Public gs_PRTAUTH As String
	Public gs_FILEAUTH As String
	Public gs_SALTAUTH As String
	Public gs_HDNTAUTH As String
	Public gs_SAPMAUTH As String
	
	'**************************************************************************************************
	'プロシジャ名   ：Get_Authority
	'処理概要       ：プログラムの実行権限を取得する
	'                 CrystalReportのプレビュー画面の印刷ボタンをユーザ権限によって制御する
	'引数   １：ec_DATE(担当者の適用日を判断する日付)
	'       ２：ec_CRW(CrystalReportコントロール名) オプション
	'戻値   1：権限マスタにデータ有り
	'       9：権限マスタにデータなし
	'**************************************************************************************************
	Public Function Get_Authority(ByRef ec_DATE As String, Optional ByRef ec_CRW As Object = Nothing) As String
		
		'変数宣言
		Dim ls_sql As String
		'UPGRADE_ISSUE: OraDynaset オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '2019/04/19 DEL START
        'Dim objRec As OraDynaset
        '2019/04/19 DEL E N D

		'初期値は全権限なし
		gs_UPDAUTH = "9" '更新権限
		gs_PRTAUTH = "9" '印刷権限
		gs_FILEAUTH = "9" 'ファイル出力権限
		gs_SALTAUTH = "9" '販売単価変更権限
		gs_HDNTAUTH = "9" '発注単価変更権限
		gs_SAPMAUTH = "9" '販売計画年初計画修正権限
		
		'ユーザIDから印刷権限を取得する
		ls_sql = "  SELECT "
		ls_sql = ls_sql & " K.UPDAUTH,"
		ls_sql = ls_sql & " K.PRTAUTH,"
		ls_sql = ls_sql & " K.FILEAUTH,"
		ls_sql = ls_sql & " K.SALTAUTH,"
		ls_sql = ls_sql & " K.HDNTAUTH,"
		ls_sql = ls_sql & " K.SAPMAUTH "
		ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
		'ls_sql = ls_sql & " WHERE K.KNGGRCD = T.KNGGRCD "
		ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
		ls_sql = ls_sql & "   AND T.TANCD   = '" & gs_userid & "'"
		ls_sql = ls_sql & "   AND K.PGID    = '" & gs_pgid & "'"
		ls_sql = ls_sql & "   AND K.DATKB   = '1'"
		ls_sql = ls_sql & "   AND T.DATKB    = '1'"
		
		'UPGRADE_WARNING: Get_Authority に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/19 ADD START
        Dim dt As DataTable = DB_GetTable(ls_sql)
        '2019/04/19 ADD E N D

        'UPGRADE_WARNING: Get_Authority に変換されていないステートメントがあります。ソース コードを確認してください。

        '2019/04/19 ADD START
        '20190703 CHG START
       ' If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
       '     '取得データなしの場合は権限なしとみなす。
       '     Get_Authority = 9
       ' Else
       '     For Each row As DataRow In dt.Rows
       '         gs_UPDAUTH = D0.Chk_Null(row("UPDAUTH"))     '更新権限
       '         gs_PRTAUTH = D0.Chk_Null(row("PRTAUTH"))     '印刷権限
       '         gs_FILEAUTH = D0.Chk_Null(row("FILEAUTH"))   'ファイル出力権限
       '         gs_SALTAUTH = D0.Chk_Null(row("SALTAUTH"))   '販売単価変更権限
       '         gs_HDNTAUTH = D0.Chk_Null(row("HDNTAUTH"))   '発注単価変更権限
       '         gs_SAPMAUTH = D0.Chk_Null(row("SAPMAUTH"))   '販売計画年初計画修正権限
       '     Next
       '     Get_Authority = 1
       ' End If
        
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            Get_Authority = CStr(9)
        Else
            gs_UPDAUTH = DB_NullReplace(dt.Rows(0).Item("UPDAUTH"), "")
            gs_PRTAUTH = DB_NullReplace(dt.Rows(0).Item("PRTAUTH"), "")
            gs_FILEAUTH = DB_NullReplace(dt.Rows(0).Item("FILEAUTH"), "")
            gs_SALTAUTH = DB_NullReplace(dt.Rows(0).Item("SALTAUTH"), "")
            gs_HDNTAUTH = DB_NullReplace(dt.Rows(0).Item("HDNTAUTH"), "")
            gs_SAPMAUTH = DB_NullReplace(dt.Rows(0).Item("SAPMAUTH"), "")

            Get_Authority = CStr(1)
        End If
        '20190703 CHG END
        '2019/04/19 ADD E N D

		If ec_CRW Is Nothing Then
		Else
			If gs_PRTAUTH = "1" Then
				'印刷権限がある場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowPrintBtn = True '印刷ボタン
			Else
				'印刷権限が無い場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowPrintBtn = False '印刷ボタン
			End If
			If gs_FILEAUTH = "1" Then
				'エクスポート権限がある場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowExportBtn = True 'エクスポートボタン
			Else
				'エクスポート権限が無い場合
				'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ec_CRW.WindowShowExportBtn = False 'エクスポートボタン
			End If
		End If
		
	End Function
End Module