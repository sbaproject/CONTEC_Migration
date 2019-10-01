Attribute VB_Name = "KNGMTB_DBM"
        Option Explicit
'==========================================================================
'   KNGMTB.DBM   権限マスタ                UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_KNGMTB
    DATKB           As String * 1       '伝票削除区分
    KNGGRCD         As String * 3       '権限グループ
    PGID            As String * 7       'プログラムID
    UPDFLG          As String * 1       '更新変更フラグ
    UPDAUTH         As String * 1       '更新権限
    PRTFLG          As String * 1       '印刷変更フラグ
    PRTAUTH         As String * 1       '印刷権限
    FILEFLG         As String * 1       'ファイル変更フラグ
    FILEAUTH        As String * 1       'ファイル出力権限
    SALTFLG         As String * 1       '販売単価変更フラグ
    SALTAUTH        As String * 1       '販売単価変更権限
    HDNTFLG         As String * 1       '発注単価変更フラグ
    HDNTAUTH        As String * 1       '発注単価変更権限
    SAPMFLG         As String * 1       '年初計画変更フラグ
    SAPMAUTH        As String * 1       '年初計画修正権限
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_KNGMTB_Clear
    '   概要：  権限マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_KNGMTB_Clear(ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB)

        Dim Clr_DB_KNGMTB As TYPE_DB_KNGMTB
    
        pot_DB_KNGMTB = Clr_DB_KNGMTB
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function KNGMTB_SEARCH
    '   概要：  権限マスタ検索
    '   引数：  pin_strKNGGRCD　 : 権限グループ
    '   　　　　pin_strPGID 　　 : プログラムID
    '   　　　　pot_DB_KNGMTB  　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function KNGMTB_SEARCH(ByVal pin_strKNGGRCD As String, _
                                  ByVal pin_strPGID As String, _
                                  ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_KNGMTB_SEARCH
    
        KNGMTB_SEARCH = 9
        
        Call DB_KNGMTB_Clear(pot_DB_KNGMTB)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from KNGMTB "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and KNGGRCD = '" & CF_ORA_SGL(pin_strKNGGRCD) & "' "
        strSQL = strSQL & "    and PGID    = '" & CF_ORA_SGL(pin_strPGID) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            KNGMTB_SEARCH = 1
            GoTo END_KNGMTB_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_KNGMTB
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "")                '権限グループ
                .UPDFLG = CF_Ora_GetDyn(Usr_Ody, "UPDFLG", "")                  '更新変更フラグ
                .UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "")                '更新権限
                .PRTFLG = CF_Ora_GetDyn(Usr_Ody, "PRTFLG", "")                  '印刷変更フラグ
                .PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "")                '印刷権限
                .FILEFLG = CF_Ora_GetDyn(Usr_Ody, "FILEFLG", "")                'ファイル変更フラグ
                .FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "")              'ファイル出力権限
                .SALTFLG = CF_Ora_GetDyn(Usr_Ody, "SALTFLG", "")                '販売単価変更フラグ
                .SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "")              '販売単価変更権限
                .HDNTFLG = CF_Ora_GetDyn(Usr_Ody, "HDNTFLG", "")                '発注単価変更フラグ
                .HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "")              '発注単価変更権限
                .SAPMFLG = CF_Ora_GetDyn(Usr_Ody, "SAPMFLG", "")                '年初計画変更フラグ
                .SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "")              '年初計画修正権限
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        KNGMTB_SEARCH = 0
        
END_KNGMTB_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_KNGMTB_SEARCH:
        GoTo END_KNGMTB_SEARCH
        
    End Function

