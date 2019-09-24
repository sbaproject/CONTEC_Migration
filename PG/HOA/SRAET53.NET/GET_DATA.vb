Option Strict Off
Option Explicit On
Module GET_DATA

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
    '2019/09/24 start
    '    Public Function DSPMSGCM_SEARCH(ByVal pin_strMSGKB As String, ByVal pin_strMSGNM As String, ByVal pin_strMSGSQ As String, ByRef pot_DB_SYSTBH As TYPE_DB_SYSTBH) As Short

    '        Dim strSQL As String
    '        Dim intData As Short
    '        'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '        Dim Usr_Ody_LC As U_Ody

    '        On Error GoTo ERR_DSPMSGCM_SEARCH

    '        DSPMSGCM_SEARCH = 9

    '        strSQL = ""
    '        strSQL = strSQL & "Select * From SYSTBH"
    '        strSQL = strSQL & " Where MSGKB = " & "'" & CF_Ora_Sgl(pin_strMSGKB) & "'"
    '        strSQL = strSQL & "   And MSGNM = " & "'" & CF_Ora_Sgl(pin_strMSGNM) & "'"
    '        strSQL = strSQL & "   And MSGSQ = " & "'" & CF_Ora_Sgl(pin_strMSGSQ) & "'"

    '        'DBアクセス
    '        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    '        If CF_Ora_EOF(Usr_Ody_LC) = True Then
    '            '取得データなし
    '            DSPMSGCM_SEARCH = 1
    '            GoTo END_DSPMSGCM_SEARCH
    '        End If

    '        If CF_Ora_EOF(Usr_Ody_LC) = False Then
    '            With pot_DB_SYSTBH
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.MSGKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .MSGKB = CF_Ora_GetDyn(Usr_Ody_LC, "MSGKB", "") 'メッセージ種別
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.MSGNM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .MSGNM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGNM", "") 'メッセージアイテム
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.MSGSQ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .MSGSQ = CF_Ora_GetDyn(Usr_Ody_LC, "MSGSQ", "") 'メッセージ連番
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.BTNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .BTNKB = CF_Ora_GetDyn(Usr_Ody_LC, "BTNKB", 0) 'ボタン種別
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.BTNON の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .BTNON = CF_Ora_GetDyn(Usr_Ody_LC, "BTNON", 0) 'ボタン初期値
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.ICNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .ICNKB = CF_Ora_GetDyn(Usr_Ody_LC, "ICNKB", 0) 'アイコン種別
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .MSGCM = CF_Ora_GetDyn(Usr_Ody_LC, "MSGCM", "") 'メッセージ
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.COLSQ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .COLSQ = CF_Ora_GetDyn(Usr_Ody_LC, "COLSQ", "") '色シーケンス
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.OPEID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "") '最終作業者コード
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.CLTID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "") 'クライアントＩＤ
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.WRTTM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
    '                'UPGRADE_WARNING: オブジェクト pot_DB_SYSTBH.WRTDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "") 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
    '            End With
    '        End If

    '        DSPMSGCM_SEARCH = 0

    'END_DSPMSGCM_SEARCH:

    '        'クローズ
    '        Call CF_Ora_CloseDyn(Usr_Ody_LC)

    '        Exit Function

    'ERR_DSPMSGCM_SEARCH:
    '        GoTo END_DSPMSGCM_SEARCH

    '    End Function
    '2019/09/24 end

End Module