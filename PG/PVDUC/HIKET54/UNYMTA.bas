Attribute VB_Name = "UNYMTA_DBM"
        Option Explicit
'==========================================================================
'   UNYMTA.DBM   運用日ﾃｰﾌﾞﾙ                      UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_UNYMTA
    UNYDT          As String * 8     '運用日付
    UNYKBA         As String * 1     '運用区分１
    UNYKBB         As String * 1     '運用区分２
    UNYKBC         As String * 1     '運用区分３
    UNYKBD         As String * 1     '運用区分４
    UNYKBE         As String * 1     '運用区分５
    TERMNO         As String * 2     '期
    ACCYY          As String * 4     '会計年度
    OPEID          As String * 8     '最終作業者コード
    CLTID          As String * 5     'クライアントＩＤ
    WRTTM          As String * 6     'タイムスタンプ（時間）
    WRTDT          As String * 8     'タイムスタンプ（日付）
    WRTFSTTM       As String * 6     'タイムスタンプ（登録時間）
    WRTFSTDT       As String * 8     'タイムスタンプ（登録日）
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_UNYMTA_Clear
    '   概要：  運用日テーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_UNYMTA_Clear(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA)

        Dim Clr_DB_UNYMTA As TYPE_DB_UNYMTA
    
        pot_DB_UNYMTA = Clr_DB_UNYMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPUNYDT_SEARCH
    '   概要：  運用日検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPUNYDT_SEARCH(ByRef pot_DB_UNYMTA As TYPE_DB_UNYMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPUNYDT_SEARCH
    
        DSPUNYDT_SEARCH = 9
        
        Call DB_UNYMTA_Clear(pot_DB_UNYMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from UNYMTA "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPUNYDT_SEARCH = 1
            GoTo END_DSPUNYDT_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_UNYMTA
                .UNYDT = CF_Ora_GetDyn(Usr_Ody, "UNYDT", "")                    '運用日付
                .UNYKBA = CF_Ora_GetDyn(Usr_Ody, "UNYKBA", "")                  '運用区分１
                .UNYKBB = CF_Ora_GetDyn(Usr_Ody, "UNYKBB", "")                  '運用区分２
                .UNYKBC = CF_Ora_GetDyn(Usr_Ody, "UNYKBC", "")                  '運用区分３
                .UNYKBD = CF_Ora_GetDyn(Usr_Ody, "UNYKBD", "")                  '運用区分４
                .UNYKBE = CF_Ora_GetDyn(Usr_Ody, "UNYKBE", "")                  '運用区分５
                .TERMNO = CF_Ora_GetDyn(Usr_Ody, "TERMNO", "")                  '期
                .ACCYY = CF_Ora_GetDyn(Usr_Ody, "ACCYY", "")                    '会計年度
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        DSPUNYDT_SEARCH = 0
        
END_DSPUNYDT_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPUNYDT_SEARCH:
        GoTo END_DSPUNYDT_SEARCH
        
    End Function


