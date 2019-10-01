Attribute VB_Name = "AUTHORITY_DBM"
Option Explicit
Public gs_kengen As String
Public gs_ari As String
Public gs_userid As String
Public gs_pgid   As String
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
Public Function Get_Authority(ec_DATE As String, Optional ec_CRW As Control) As String

'変数宣言
Dim ls_sql  As String
Dim Usr_Ody As U_Ody

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

Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)

If CF_Ora_EOF(Usr_Ody) = True Then
    '取得データなしの場合は権限なしとみなす。
    Get_Authority = 9
Else
    Do Until CF_Ora_EOF(Usr_Ody) = True
        gs_UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")      '更新権限
        gs_PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")      '印刷権限
        gs_FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")    'ファイル出力権限
        gs_SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")    '販売単価変更権限
        gs_HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")    '発注単価変更権限
        gs_SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")    '販売計画年初計画修正権限
        '次レコード
        Call CF_Ora_MoveNext(Usr_Ody)
    Loop
    Get_Authority = 1
End If

If ec_CRW Is Nothing Then
Else
    If gs_PRTAUTH = "1" Then
        '印刷権限がある場合
        ec_CRW.WindowShowPrintBtn = True    '印刷ボタン
    Else
        '印刷権限が無い場合
        ec_CRW.WindowShowPrintBtn = False   '印刷ボタン
    End If
    If gs_FILEAUTH = "1" Then
        'エクスポート権限がある場合
        ec_CRW.WindowShowExportBtn = True   'エクスポートボタン
    Else
        'エクスポート権限が無い場合
        ec_CRW.WindowShowExportBtn = False  'エクスポートボタン
    End If
End If

End Function



