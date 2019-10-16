Attribute VB_Name = "SYSTBB_DBM"
        Option Explicit
'==========================================================================
'   SYSTBB.DBM   消費税テーブル                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBB
    ZEIDT          As String * 8     '改定日付              YYYY/MM/DD
    ZEIRNKKB       As String * 1     '消費税ランク          0
    ZEIRT          As Currency       '消費税率              ##0.00;;#
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    WRTFSTTM       As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    WRTFSTDT       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録日付)    YYYY/MM/DD
End Type
Global DB_SYSTBB As TYPE_DB_SYSTBB
Global DBN_SYSTBB As Integer

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_SYSTBB_Clear
    '   概要：  消費税テーブル構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_SYSTBB_Clear(ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB)

        Dim Clr_DB_SYSTBB As TYPE_DB_SYSTBB
    
        pot_DB_SYSTBB = Clr_DB_SYSTBB
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPZEIRT_SEARCH
    '   概要：  消費税率検索
    '   引数：  pin_strZEIDT    : 基準日
    '           pin_strZEIRNKKB : 消費税ランク
    '           pot_DB_SYSTBB   : 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPZEIRT_SEARCH(ByVal pin_strZEIDT As String, _
                                    ByVal pin_strZEIRNKKB As String, _
                                    ByRef pot_DB_SYSTBB As TYPE_DB_SYSTBB) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody_LC      As U_Ody

    On Error GoTo ERR_DSPZEIRT_SEARCH
    
        DSPZEIRT_SEARCH = 9
        
' === 20131203 === INSERT S - RS)Ishida 消費税法改正対応
        'パラメータの取得日付より、"/"を消去する。
        pin_strZEIDT = Replace(pin_strZEIDT, "/", "")
' === 20131203 === INSERT E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from SYSTBB "
        strSQL = strSQL & "  Where ZEIDT    <= '" & pin_strZEIDT & "' "
        strSQL = strSQL & "    and ZEIRNKKB  = '" & pin_strZEIRNKKB & "' "
        strSQL = strSQL & "  Order by ZEIDT DESC "
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
 
        If CF_Ora_EOF(Usr_Ody_LC) = True Then
            '取得データなし
            DSPZEIRT_SEARCH = 1
            Exit Function
        End If
        
        If CF_Ora_EOF(Usr_Ody_LC) = False Then
            With pot_DB_SYSTBB
                .ZEIDT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIDT", "")                    '伝票削除区分
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRNKKB", "")              '伝票削除区分
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody_LC, "ZEIRT", 0)                     '伝票削除区分
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
        

        DSPZEIRT_SEARCH = 0
        
        Exit Function
    
ERR_DSPZEIRT_SEARCH:
        
        
    End Function


