Option Strict Off
Option Explicit On
Module AUTHORITY_DBM
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
        '2019.04.22 del start 仮
		'変数宣言
        'Dim ls_sql As String
        ''UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
        'Dim Usr_Ody As U_Ody

        ''初期値は全権限なし
        'gs_UPDAUTH = "9" '更新権限
        'gs_PRTAUTH = "9" '印刷権限
        'gs_FILEAUTH = "9" 'ファイル出力権限
        'gs_SALTAUTH = "9" '販売単価変更権限
        'gs_HDNTAUTH = "9" '発注単価変更権限
        'gs_SAPMAUTH = "9" '販売計画年初計画修正権限

        ''ユーザIDから印刷権限を取得する
        'ls_sql = "  SELECT "
        'ls_sql = ls_sql & " K.UPDAUTH,"
        'ls_sql = ls_sql & " K.PRTAUTH,"
        'ls_sql = ls_sql & " K.FILEAUTH,"
        'ls_sql = ls_sql & " K.SALTAUTH,"
        'ls_sql = ls_sql & " K.HDNTAUTH,"
        'ls_sql = ls_sql & " K.SAPMAUTH "
        'ls_sql = ls_sql & " FROM KNGMTB K,TANMTA T "
        ''ls_sql = ls_sql & " WHERE K.KNGGRCD = T.KNGGRCD "
        'ls_sql = ls_sql & " WHERE K.KNGGRCD = (CASE WHEN T.TANTKDT <= '" & ec_DATE & "' THEN T.KNGGRCD ELSE T.OLDGRCD END) "
        'ls_sql = ls_sql & "   AND T.TANCD   = '" & gs_userid & "'"
        'ls_sql = ls_sql & "   AND K.PGID    = '" & gs_pgid & "'"
        'ls_sql = ls_sql & "   AND K.DATKB   = '1'"
        'ls_sql = ls_sql & "   AND T.DATKB    = '1'"

        '      '2019.04.22 chg start
        '      'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
        '      Call DB_GetSQL2(DBN_KNGMTB, ls_sql)
        '      '2019.04.22 chg end

        'If CF_Ora_EOF(Usr_Ody) = True Then
        '	'取得データなしの場合は権限なしとみなす。
        '	Get_Authority = CStr(9)
        'Else
        '	Do Until CF_Ora_EOF(Usr_Ody) = True
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '更新権限
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '印刷権限
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") 'ファイル出力権限
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '販売単価変更権限
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '発注単価変更権限
        '		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '販売計画年初計画修正権限
        '              '次レコード
        '              '2019.04.22 chg start
        '              'Call CF_Ora_MoveNext(Usr_Ody)
        '              Call DB_GetNext(DBN_KNGMTB, BtrNormal)
        '              '2019.04.22 chg end
        '	Loop 
        '	Get_Authority = CStr(1)
        'End If

        'If ec_CRW Is Nothing Then
        'Else
        '	If gs_PRTAUTH = "1" Then
        '		'印刷権限がある場合
        '		'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		ec_CRW.WindowShowPrintBtn = True '印刷ボタン
        '	Else
        '		'印刷権限が無い場合
        '		'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowPrintBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		ec_CRW.WindowShowPrintBtn = False '印刷ボタン
        '	End If
        '	If gs_FILEAUTH = "1" Then
        '		'エクスポート権限がある場合
        '		'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		ec_CRW.WindowShowExportBtn = True 'エクスポートボタン
        '	Else
        '		'エクスポート権限が無い場合
        '		'UPGRADE_WARNING: オブジェクト ec_CRW.WindowShowExportBtn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		ec_CRW.WindowShowExportBtn = False 'エクスポートボタン
        '	End If
        'End If
        '2019.04.22 del end
	End Function
End Module