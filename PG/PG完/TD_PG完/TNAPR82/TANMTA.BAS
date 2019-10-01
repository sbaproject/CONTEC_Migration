Attribute VB_Name = "TANMTA_DBM"
        Option Explicit
'==========================================================================
'   TANMTA.DBM   担当者マスタ                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TANMTA
    DATKB           As String * 1       '伝票削除区分
    TANMSTKB        As String * 1       'マスタ区分（担当者）
    TANCD           As String * 6       '担当者コード
    MAETANCD        As String * 6       '前回担当者コード
    MMTANCD         As String * 6       '前々回担当者コード
    TANNM           As String * 40      '担当者名
    TANNK           As String * 10      '担当者名称カナ
    TANCLAKB        As String * 1       '分類区分１（担当者）
    TANCLBKB        As String * 1       '分類区分２（担当者）
    TANCLCKB        As String * 1       '分類区分３（担当者）
    TANCLAID        As String * 6       '分類コード１（担当者）
    TANCLBID        As String * 6       '分類コード２（担当者）
    TANCLCID        As String * 6       '分類コード３（担当者）
    TANCLANM        As String * 20      '分類名称１（担当者）
    TANCLBNM        As String * 20      '分類名称２（担当者）
    TANCLCNM        As String * 20      '分類名称３（担当者）
    TANBMNCD        As String * 6       '所属部門コード
    KEIBMNCD        As String * 6       '経理部門コード
    TANMLAD         As String * 50      'メールアドレス
    KNGGRCD         As String * 3       '権限グループ
    TANTKDT         As String * 8       '適用日
    OLDBMNCD        As String * 6       '旧所属部門コード
    OLDGRCD         As String * 3       '旧権限グループ
    TANDELDT        As String * 8       '削除年月日
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type
Global DB_TANMTA As TYPE_DB_TANMTA
Global DBN_TANMTA As Integer

' === 20060828 === INSERT S - ACE)Sejima
Public WLSTAN_TANTKDT       As String           '適用日
' === 20060828 === INSERT E

'担当者マスタ検索戻り値
Public WLSTAN_RTNCODE       As String           '担当者コード
Public WLSTAN_TANCLAKB      As String           '営業担当者検索フラグ(空白:全件表示 "1":営業担当者のみ)

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_TANMTA_Clear
    '   概要：  担当者マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TANMTA_Clear(ByRef pot_DB_TANMTA As TYPE_DB_TANMTA)

        Dim Clr_DB_TANMTA As TYPE_DB_TANMTA
    
        pot_DB_TANMTA = Clr_DB_TANMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPTANCD_SEARCH
    '   概要：  担当者コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTANCD_SEARCH(ByVal pin_strTANCD As String, _
                                    ByRef pot_DB_TANMTA As TYPE_DB_TANMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPTANCD_SEARCH
    
        DSPTANCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TANMTA "
        strSQL = strSQL & "  Where TANCD = '" & pin_strTANCD & "' "
        

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '取得データなし
            DSPTANCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_TANMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody_LC, "DATKB", "")                    '伝票削除区分
                .TANMSTKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANMSTKB", "")              'マスタ区分（担当者）
                .TANCD = CF_Ora_GetDyn(Usr_Ody_LC, "TANCD", "")                    '担当者コード
                .MAETANCD = CF_Ora_GetDyn(Usr_Ody_LC, "MAETANCD", "")              '前回担当者コード
                .MMTANCD = CF_Ora_GetDyn(Usr_Ody_LC, "MMTANCD", "")                '前々回担当者コード
                .TANNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANNM", "")                    '担当者名
                .TANNK = CF_Ora_GetDyn(Usr_Ody_LC, "TANNK", "")                    '担当者名称カナ
                .TANCLAKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLAKB", "")              '分類区分１（担当者）
                .TANCLBKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBKB", "")              '分類区分２（担当者）
                .TANCLCKB = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCKB", "")              '分類区分３（担当者）
                .TANCLAID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLAID", "")              '分類コード１（担当者）
                .TANCLBID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBID", "")              '分類コード２（担当者）
                .TANCLCID = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCID", "")              '分類コード３（担当者）
                .TANCLANM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLANM", "")              '分類名称１（担当者）
                .TANCLBNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLBNM", "")              '分類名称２（担当者）
                .TANCLCNM = CF_Ora_GetDyn(Usr_Ody_LC, "TANCLCNM", "")              '分類名称３（担当者）
                .TANBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "TANBMNCD", "")              '所属部門コード
                .KEIBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "KEIBMNCD", "")              '経理部門コード
                .TANMLAD = CF_Ora_GetDyn(Usr_Ody_LC, "TANMLAD", "")                'メールアドレス
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody_LC, "KNGGRCD", "")                '権限グループ
                .TANTKDT = CF_Ora_GetDyn(Usr_Ody_LC, "TANTKDT", "")                '適用日
                .OLDBMNCD = CF_Ora_GetDyn(Usr_Ody_LC, "OLDBMNCD", "")              '旧所属部門コード
                .OLDGRCD = CF_Ora_GetDyn(Usr_Ody_LC, "OLDGRCD", "")                '旧権限グループ
                .TANDELDT = CF_Ora_GetDyn(Usr_Ody_LC, "TANDELDT", "")              '削除年月日
                .RELFL = CF_Ora_GetDyn(Usr_Ody_LC, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        

        DSPTANCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPTANCD_SEARCH:
        
        
    End Function

