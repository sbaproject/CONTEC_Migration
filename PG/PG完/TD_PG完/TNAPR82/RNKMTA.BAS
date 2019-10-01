Attribute VB_Name = "RNKMTA_DBM"
        Option Explicit
'==========================================================================
'   RNKMTA.DBM   ランク別仕切率マスタ　           UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_RNKMTA
    DATKB           As String * 1       '伝票削除区分
    HINGRP          As String * 4       '商品群
    RNKCD           As String * 1       'ランク
    URISETDT        As String * 8       '販売単価設定日付
    SIKRT           As Currency         '仕切率
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type
Global DB_RNKMTA As TYPE_DB_RNKMTA
Global DBN_RNKMTA As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_RNKMTA_Clear
    '   概要：  ランク別仕切率マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_RNKMTA_Clear(ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA)

        Dim Clr_DB_RNKMTA As TYPE_DB_RNKMTA
    
        pot_DB_RNKMTA = Clr_DB_RNKMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPRNKM_SEARCH
    '   概要：  ランク別仕切率マスタ検索
    '   引数：　pin_strHINGRP   : 商品群
    '           pin_strRNKCD    : ランク
    '           pin_strURISETDT : 販売単価設定日付
    '           pot_DB_RNKMTA 　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPRNKM_SEARCH(ByVal pin_strHINGRP As String, _
                                   ByVal pin_strRNKCD As String, _
                                   ByVal pin_strURISETDT As String, _
                                   ByRef pot_DB_RNKMTA As TYPE_DB_RNKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPRNKM_SEARCH
    
        DSPRNKM_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from RNKMTA "
        strSQL = strSQL & "  Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "  and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "  and URISETDT = ( Select MAX(URISETDT) AS _MAX_URISETDT "
        strSQL = strSQL & "                     from RNKMTA "
        strSQL = strSQL & "                    Where HINGRP = '" & pin_strHINGRP & "' "
        strSQL = strSQL & "                      and RNKCD = '" & pin_strRNKCD & "' "
        strSQL = strSQL & "                      and URISETDT <= '" & pin_strURISETDT & "' )"
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPRNKM_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_RNKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '商品群
                .RNKCD = CF_Ora_GetDyn(Usr_Ody, "RNKCD", "")                    'ランク
                .URISETDT = CF_Ora_GetDyn(Usr_Ody, "URISETDT", "")              '販売単価設定日付
                .SIKRT = CF_Ora_GetDyn(Usr_Ody, "SIKRT", 0)                     '仕切率
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        

        DSPRNKM_SEARCH = 0
        
        Exit Function
    
ERR_DSPRNKM_SEARCH:
        
        
    End Function

