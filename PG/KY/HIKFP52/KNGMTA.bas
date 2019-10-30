Attribute VB_Name = "KNGMTA_DBM"
        Option Explicit
'==========================================================================
'   KNGMTA.DBM   権限マスタ                UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_KNGMTA
    DATKB           As String * 1       '伝票削除区分
    KNGGRCD         As String * 3       '権限グループ
    SALTKKB         As String * 1       '販売単価変更
    HDNTKKB         As String * 1       '発注単価変更
    SAPMODKB        As String * 1       '販売計画年初計画修正
    SAPCSVKB        As String * 1       '販売計画CSV出力
    TRIUPDKB        As String * 1       '取引先マスタ更新
    NHSUPDKB        As String * 1       '納入先マスタ更新
    HINUPDKB        As String * 1       '商品マスタ更新
    SIKUPDKB        As String * 1       '仕切関連マスタ更新
    TUPUPDKB        As String * 1       '海外販売単価マスタ更新
    SUPUPDKB        As String * 1       '仕入単価マスタ更新
    SBNUPDKB        As String * 1       '製番マスタ更新
    BMNUPDKB        As String * 1       '部門マスタ更新
    TANUPDKB        As String * 1       '担当者マスタ更新
    KNGUPDKB        As String * 1       '権限マスタ更新
    BNKUPDKB        As String * 1       '銀行マスタ更新
    SOUUPDKB        As String * 1       '倉庫マスタ更新
    MEIUPDKB        As String * 1       '名称マスタ更新
    FIXUPDKB        As String * 1       '固定値マスタ更新
    TUKUPDKB        As String * 1       'レートマスタ更新
    UNTUPDKB        As String * 1       '単位マスタ更新
    CLDUPDKB        As String * 1       'カレンダーマスタ更新
    TAXUPDKB        As String * 1       '消費税率マスタ更新
    TZNUPDKB        As String * 1       '得意先残高更新
    SZNUPDKB        As String * 1       '仕入先残高更新
    JDNUPDKB        As String * 1       '受注更新
    HDNUPDKB        As String * 1       '発注更新
    YOBKBA          As String * 1       '予備区分A
    YOBKBB          As String * 1       '予備区分B
    YOBKBC          As String * 1       '予備区分C
    YOBKBD          As String * 1       '予備区分D
    YOBKBE          As String * 1       '予備区分E
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_KNGMTA_Clear
    '   概要：  権限マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_KNGMTA_Clear(ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA)

        Dim Clr_DB_KNGMTA As TYPE_DB_KNGMTA
    
        pot_DB_KNGMTA = Clr_DB_KNGMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function KNGMTA_SEARCH
    '   概要：  権限マスタ検索
    '   引数：  pin_strKNGGRCD　 : 権限グループ
    '   　　　　pot_DB_KNGMTA  　: 検索結果
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function KNGMTA_SEARCH(ByVal pin_strKNGGRCD As String, _
                                  ByRef pot_DB_KNGMTA As TYPE_DB_KNGMTA) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTGRPCD       As String

    On Error GoTo ERR_KNGMTA_SEARCH
    
        KNGMTA_SEARCH = 9
        
        Call DB_KNGMTA_Clear(pot_DB_KNGMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from KNGMTA "
        strSQL = strSQL & "  Where DATKB   = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and KNGGRCD = '" & CF_Ora_Sgl(pin_strKNGGRCD) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            KNGMTA_SEARCH = 1
            GoTo END_KNGMTA_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_KNGMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "")                '権限グループ
                .SALTKKB = CF_Ora_GetDyn(Usr_Ody, "SALTKKB", "")                '販売単価変更
                .HDNTKKB = CF_Ora_GetDyn(Usr_Ody, "HDNTKKB", "")                '発注単価変更
                .SAPMODKB = CF_Ora_GetDyn(Usr_Ody, "SAPMODKB", "")              '販売計画年初計画修正
                .SAPCSVKB = CF_Ora_GetDyn(Usr_Ody, "SAPCSVKB", "")              '販売計画CSV出力
                .TRIUPDKB = CF_Ora_GetDyn(Usr_Ody, "TRIUPDKB", "")              '取引先マスタ更新
                .NHSUPDKB = CF_Ora_GetDyn(Usr_Ody, "NHSUPDKB", "")              '納入先マスタ更新
                .HINUPDKB = CF_Ora_GetDyn(Usr_Ody, "HINUPDKB", "")              '商品マスタ更新
                .SIKUPDKB = CF_Ora_GetDyn(Usr_Ody, "SIKUPDKB", "")              '仕切関連マスタ更新
                .TUPUPDKB = CF_Ora_GetDyn(Usr_Ody, "TUPUPDKB", "")              '海外販売単価マスタ更新
                .SUPUPDKB = CF_Ora_GetDyn(Usr_Ody, "SUPUPDKB", "")              '仕入単価マスタ更新
                .SBNUPDKB = CF_Ora_GetDyn(Usr_Ody, "SBNUPDKB", "")              '製番マスタ更新
                .BMNUPDKB = CF_Ora_GetDyn(Usr_Ody, "BMNUPDKB", "")              '部門マスタ更新
                .TANUPDKB = CF_Ora_GetDyn(Usr_Ody, "TANUPDKB", "")              '担当者マスタ更新
                .KNGUPDKB = CF_Ora_GetDyn(Usr_Ody, "KNGUPDKB", "")              '権限マスタ更新
                .BNKUPDKB = CF_Ora_GetDyn(Usr_Ody, "BNKUPDKB", "")              '銀行マスタ更新
                .SOUUPDKB = CF_Ora_GetDyn(Usr_Ody, "SOUUPDKB", "")              '倉庫マスタ更新
                .MEIUPDKB = CF_Ora_GetDyn(Usr_Ody, "MEIUPDKB", "")              '名称マスタ更新
                .FIXUPDKB = CF_Ora_GetDyn(Usr_Ody, "FIXUPDKB", "")              '固定値マスタ更新
                .TUKUPDKB = CF_Ora_GetDyn(Usr_Ody, "TUKUPDKB", "")              'レートマスタ更新
                .UNTUPDKB = CF_Ora_GetDyn(Usr_Ody, "UNTUPDKB", "")              '単位マスタ更新
                .CLDUPDKB = CF_Ora_GetDyn(Usr_Ody, "CLDUPDKB", "")              'カレンダーマスタ更新
                .TAXUPDKB = CF_Ora_GetDyn(Usr_Ody, "TAXUPDKB", "")              '消費税率マスタ更新
                .TZNUPDKB = CF_Ora_GetDyn(Usr_Ody, "TZNUPDKB", "")              '得意先残高更新
                .SZNUPDKB = CF_Ora_GetDyn(Usr_Ody, "SZNUPDKB", "")              '仕入先残高更新
                .JDNUPDKB = CF_Ora_GetDyn(Usr_Ody, "JDNUPDKB", "")              '受注更新
                .HDNUPDKB = CF_Ora_GetDyn(Usr_Ody, "HDNUPDKB", "")              '発注更新
                .YOBKBA = CF_Ora_GetDyn(Usr_Ody, "YOBKBA", "")                  '予備区分A
                .YOBKBB = CF_Ora_GetDyn(Usr_Ody, "YOBKBB", "")                  '予備区分B
                .YOBKBC = CF_Ora_GetDyn(Usr_Ody, "YOBKBC", "")                  '予備区分C
                .YOBKBD = CF_Ora_GetDyn(Usr_Ody, "YOBKBD", "")                  '予備区分D
                .YOBKBE = CF_Ora_GetDyn(Usr_Ody, "YOBKBE", "")                  '予備区分E
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        KNGMTA_SEARCH = 0
        
END_KNGMTA_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_KNGMTA_SEARCH:
        GoTo END_KNGMTA_SEARCH
        
    End Function

