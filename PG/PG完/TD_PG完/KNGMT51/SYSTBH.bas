Attribute VB_Name = "SYSTBH_DBM"
        Option Explicit
'==========================================================================
'   SYSTBH.DBM   システムメッセージ               UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBH
    MSGKB          As String * 1     'メッセージ種別        0
    MSGNM          As String * 15    'メッセージアイテム
    MSGSQ          As String * 1     'メッセージ連番        X(01)
    BTNKB          As Currency       'ボタン種別            000
    BTNON          As Currency       'ボタン初期値          000
    ICNKB          As Currency       'アイコン種別          00
    MSGCM          As String * 50    'メッセージ
    COLSQ          As String * 1     '色シーケンス          0
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SYSTBH_Clear
    '   概要：  システムメッセージテーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SYSTBH_Clear(ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH)

        Dim Clr_DB_SYSTBH As TYPE_DB_SYSTBH
    
        pot_DB_SYSTBH = Clr_DB_SYSTBH
    
    End Sub
    
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
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBH "
        strSQL = strSQL & "  Where MSGKB     = '" & CF_Ora_Sgl(pin_strMSGKB) & "' "
        strSQL = strSQL & "    and MSGNM     = '" & CF_Ora_Sgl(pin_strMSGNM) & "' "
        strSQL = strSQL & "    and MSGSQ     = '" & CF_Ora_Sgl(pin_strMSGSQ) & "' "
        
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




