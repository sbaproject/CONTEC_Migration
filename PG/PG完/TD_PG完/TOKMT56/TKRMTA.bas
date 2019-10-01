Attribute VB_Name = "TKRMTA_DBM"
        Option Explicit
'==========================================================================
'   TKRMTA.DBM   得意別取扱商品マスタ             UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TKRMTA
    DATKB           As String * 1       '伝票削除区分
    TOKCD           As String * 10      '得意先コード
    SKHINGRP        As String * 4       '仕切用商品群
    SKWRKKB         As String * 1       '仕切処理区分
    HINCD           As String * 10      '製品コード
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_TKRMTA_Clear
    '   概要：  得意別取扱商品マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TKRMTA_Clear(ByRef pot_DB_TKRMTA As TYPE_DB_TKRMTA)

        Dim Clr_DB_TKRMTA As TYPE_DB_TKRMTA
    
        pot_DB_TKRMTA = Clr_DB_TKRMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function TKRMTA_SEARCH
    '   概要：  得意別取扱商品マスタ検索
    '   引数：  pin_strTOKCD　　 : 得意先コード
    '   　　　　pin_strSKHINGRP　: 仕切用商品群
    '   　　　　pin_strHINCD　　 : 製品コード
    '   　　　　pot_DB_TKRMTA　　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function TKRMTA_SEARCH(ByVal pin_strTOKCD As String, _
                                  ByVal pin_strSKHINGRP As String, _
                                  ByVal pin_strHINCD As String, _
                                  ByRef pot_DB_TKRMTA As TYPE_DB_TKRMTA) As Integer
    
        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_TKRMTA_SEARCH
    
        TKRMTA_SEARCH = 9
        
        Call DB_TKRMTA_Clear(pot_DB_TKRMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TKRMTA "
        strSQL = strSQL & "  Where DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TOKCD     = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_Sgl(pin_strSKHINGRP) & "' "
        strSQL = strSQL & "    and HINCD     = '" & CF_Ora_Sgl(pin_strHINCD) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            TKRMTA_SEARCH = 1
            GoTo END_TKRMTA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TKRMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '仕切用商品群
                .SKWRKKB = CF_Ora_GetDyn(Usr_Ody, "SKWRKKB", "")                '仕切処理区分
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '製品コード
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        TKRMTA_SEARCH = 0
        
END_TKRMTA_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_TKRMTA_SEARCH:
        GoTo END_TKRMTA_SEARCH

    End Function

