Attribute VB_Name = "SOUMTA_DBM"
        Option Explicit
'==========================================================================
'   SOUMTA.DBM   倉庫マスタ                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SOUMTA
    DATKB          As String * 1     '伝票削除区分          0
    SOUCD          As String * 3     '倉庫コード            000
    SOUNM          As String * 20    '倉庫名
    SOUZP          As String * 20    '倉庫郵便番号
    SOUADA         As String * 60    '倉庫住所１
    SOUADB         As String * 60    '倉庫住所２
    SOUADC         As String * 60    '倉庫住所３
    SOUTL          As String * 20    '倉庫電話番号
    SOUFX          As String * 20    '倉庫ＦＡＸ番号
    SOUBSCD        As String * 3     '場所コード            000
    SOUKB          As String * 1     '倉庫種別              0
    SRSCNKB        As String * 1     'ｼﾘｱﾙｽｷｬﾝ要否区分      0
    SISNKB         As String * 1     '資産元区分            0
    SOUTRICD       As String * 10    '取引先コード          !@@@@@@@@@@
    SOUKOKB        As String * 2     '倉庫区分              00
    HIKKB          As String * 1     '引当対象区分          0
    SALPALKB       As String * 1     '販売計画対象区分
    RELFL          As String * 1     '連携フラグ            X
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    WRTFSTTM       As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    WRTFSTDT       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
End Type
Global DB_SOUMTA As TYPE_DB_SOUMTA
Global DBN_SOUMTA As Integer

'倉庫マスタ検索戻り値
Public WLSSOU_RTNCODE       As String           '倉庫コード

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SOUMTA_Clear
    '   概要：  倉庫マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SOUMTA_Clear(ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA)

        Dim Clr_DB_SOUMTA As TYPE_DB_SOUMTA
    
        pot_DB_SOUMTA = Clr_DB_SOUMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPSOUCD_SEARCH
    '   概要：  倉庫コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPSOUCD_SEARCH(ByVal pin_strSOUCD As String, _
                                    ByRef pot_DB_SOUMTA As TYPE_DB_SOUMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody
        
    On Error GoTo ERR_DSPSOUCD_SEARCH
    
        DSPSOUCD_SEARCH = 9
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SOUMTA "
        strSQL = strSQL & "  Where SOUCD = '" & pin_strSOUCD & "' "
        

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            Call CF_Ora_CloseDyn(Usr_Ody)
            DSPSOUCD_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_SOUMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '倉庫コード
                .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '倉庫名
                .SOUZP = CF_Ora_GetDyn(Usr_Ody, "SOUZP", "")                    '倉庫郵便番号
                .SOUADA = CF_Ora_GetDyn(Usr_Ody, "SOUADA", "")                  '倉庫住所１
                .SOUADB = CF_Ora_GetDyn(Usr_Ody, "SOUADB", "")                  '倉庫住所２
                .SOUADC = CF_Ora_GetDyn(Usr_Ody, "SOUADC", "")                  '倉庫住所３
                .SOUTL = CF_Ora_GetDyn(Usr_Ody, "SOUTL", "")                    '倉庫電話番号
                .SOUFX = CF_Ora_GetDyn(Usr_Ody, "SOUFX", "")                    '倉庫ＦＡＸ番号
                .SOUBSCD = CF_Ora_GetDyn(Usr_Ody, "SOUBSCD", "")                '場所コード
                .SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB", "")                    '倉庫種別
                .SRSCNKB = CF_Ora_GetDyn(Usr_Ody, "SRSCNKB", "")                'シリアルスキャン要否区分
                .SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")                  '資産元区分
                .SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")              '取引先コード
                .SOUKOKB = CF_Ora_GetDyn(Usr_Ody, "SOUKOKB", "")                '倉庫区分
                .HIKKB = CF_Ora_GetDyn(Usr_Ody, "HIKKB", "")                    '引当対象区分
                .SALPALKB = CF_Ora_GetDyn(Usr_Ody, "SALPALKB", "")              '販売計画対象区分
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        DSPSOUCD_SEARCH = 0
        
        Exit Function
    
ERR_DSPSOUCD_SEARCH:
        
        
    End Function


