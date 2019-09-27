Attribute VB_Name = "GET_DATA"
Option Explicit

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
Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, _
                                ByVal pin_strMSGNM As String, _
                                ByVal pin_strMSGSQ As String, _
                                ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPMSGCM_SEARCH

    DSPMSGCM_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & "Select * From SYSTBH"
    strSQL = strSQL & " Where MSGKB = " & "'" & CF_Ora_Sgl(pin_strMSGKB) & "'"
    strSQL = strSQL & "   And MSGNM = " & "'" & CF_Ora_Sgl(pin_strMSGNM) & "'"
    strSQL = strSQL & "   And MSGSQ = " & "'" & CF_Ora_Sgl(pin_strMSGSQ) & "'"
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = True Then
        '取得データなし
        DSPMSGCM_SEARCH = 1
        GoTo END_DSPMSGCM_SEARCH
    End If
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        With pot_DB_SYSTBH
            .MSGKB = CF_Ora_GetDyn(Usr_Ody_LC, "MSGKB", "")                    'メッセージ種別
            .MSGNM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGNM", "")                    'メッセージアイテム
            .MSGSQ = CF_Ora_GetDyn(Usr_Ody_LC, "MSGSQ", "")                    'メッセージ連番
            .BTNKB = CF_Ora_GetDyn(Usr_Ody_LC, "BTNKB", 0)                     'ボタン種別
            .BTNON = CF_Ora_GetDyn(Usr_Ody_LC, "BTNON", 0)                     'ボタン初期値
            .ICNKB = CF_Ora_GetDyn(Usr_Ody_LC, "ICNKB", 0)                     'アイコン種別
            .MSGCM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGCM", "")                    'メッセージ
            .COLSQ = CF_Ora_GetDyn(Usr_Ody_LC, "COLSQ", "")                    '色シーケンス
            .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '最終作業者コード
            .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    'クライアントＩＤ
            .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
            .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
        End With
    End If

    DSPMSGCM_SEARCH = 0
    
END_DSPMSGCM_SEARCH:
    
    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

    Exit Function

ERR_DSPMSGCM_SEARCH:
    GoTo END_DSPMSGCM_SEARCH
    
End Function




