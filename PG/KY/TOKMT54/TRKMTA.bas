Attribute VB_Name = "TRKMTA_DBM"
        Option Explicit
'==========================================================================
'   TRKMTA.DBM   得意別商品ランクマスタ             UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TRKMTA
    DATKB           As String * 1       '伝票削除区分
    TOKCD           As String * 10      '得意先コード
    SKHINGRP        As String * 4       '仕切用商品群
    TRKRNK          As String * 1       'ランク
    TRKOEM          As String * 1       'OEM
    STTKSTDT        As String * 8       '開始単価設定日付
    NBKRT           As Currency         '値引率
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
' === 20080909 === INSERT S - RISE)Izumi
    UOPEID          As String * 8       '最終作業者コード（バッチ）
    UCLTID          As String * 5       'クライアントＩＤ（バッチ）
    UWRTTM          As String * 6       'タイムスタンプ（バッチ時間）
    UWRTDT          As String * 8       'タイムスタンプ（バッチ日付）
' === 20080909 === INSERT S - RISE)Izumi
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_TRKMTA_Clear
    '   概要：  得意別商品ランクマスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TRKMTA_Clear(ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA)

        Dim Clr_DB_TRKMTA As TYPE_DB_TRKMTA
    
        pot_DB_TRKMTA = Clr_DB_TRKMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function TRKMTA_SEARCH
    '   概要：  得意別商品ランクマスタ検索
    '   引数：  pin_strTOKCD　　 : 得意先コード
    '   　　　　pin_strSKHINGRP　: 仕切用商品群
    '   　　　　pin_strSTTKSTDT  : 開始単価設定日付
    '   　　　　pin_strTRKRNK    : ランク
    '   　　　　pot_DB_TRKMTA　　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function TRKMTA_SEARCH(ByVal pin_strTOKCD As String, _
                                  ByVal pin_strSKHINGRP As String, _
                                  ByVal pin_strSTTKSTDT As String, _
                                  ByVal pin_strTRKRNK As String, _
                                  ByRef pot_DB_TRKMTA As TYPE_DB_TRKMTA) As Integer
    
        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_TRKMTA_SEARCH
    
        TRKMTA_SEARCH = 9
        
        Call DB_TRKMTA_Clear(pot_DB_TRKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TRKMTA "
        strSQL = strSQL & "  Where DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TOKCD     = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
        strSQL = strSQL & "    and SKHINGRP  = '" & CF_Ora_Sgl(pin_strSKHINGRP) & "' "
        strSQL = strSQL & "    and STTKSTDT  = '" & CF_Ora_Sgl(pin_strSTTKSTDT) & "' "
        strSQL = strSQL & "    and TRKRNK    = '" & CF_Ora_Sgl(pin_strTRKRNK) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            TRKMTA_SEARCH = 1
            GoTo END_TRKMTA_SEARCH
        End If

        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TRKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '仕切用商品群
                .TRKRNK = CF_Ora_GetDyn(Usr_Ody, "TRKRNK", "")                  'ランク
                .TRKOEM = CF_Ora_GetDyn(Usr_Ody, "TRKOEM", "")                  'OEM
                .STTKSTDT = CF_Ora_GetDyn(Usr_Ody, "STTKSTDT", "")              '開始単価設定日付
                .NBKRT = CF_Ora_GetDyn(Usr_Ody, "NBKRT", "")                    '値引率
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        TRKMTA_SEARCH = 0
        
END_TRKMTA_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_TRKMTA_SEARCH:
        GoTo END_TRKMTA_SEARCH

    End Function

