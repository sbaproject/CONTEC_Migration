Attribute VB_Name = "MITTHA_DBM"
        Option Explicit
'==========================================================================
'   MITTHA.DBM   見積見出トラン                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_MITTHA
    DATNO           As String * 10      '伝票管理№
    DATKB           As String * 1       '伝票削除区分
    DENKB           As String * 1       '伝票区分
    MITNO           As String * 10      '見積番号
    MITNOV          As String * 2       '版数
    AKNID           As String * 8       '案件ＩＤ
    MITDT           As String * 8       '見積日付
    JDNYTDT         As String * 8       '受注予定日
    DEFNOKDT        As String * 8       '納期
    NOKDTPRT        As String * 40      '客先納期（印字用）
    TOKCD           As String * 10      '得意先コード
    TOKRN           As String * 40      '得意先略称
    NHSCD           As String * 10      '納入先コード
    NHSNMA          As String * 60      '納入先名称１
    NHSNMB          As String * 60      '納入先名称２
    TANCD           As String * 6       '担当者コード
    TANNM           As String * 40      '担当者名
    BUMCD           As String * 6       '部門コード
    BUMNM           As String * 40      '営業部門名
    SOUCD           As String * 3       '倉庫コード
    SOUNM           As String * 20      '倉庫名
    ZKTKB           As String * 1       '取引区分
    ZKTNM           As String * 4       '取引区分名
    SBAMITKN        As Currency         '見積金額（本体合計）
    SBAMZEKN        As Currency         '見積金額（消費税額）
    SBAMZKKN        As Currency         '見積金額（伝票計）
    DENCMA          As String * 80      '備考１
    DENCMB          As String * 80      '備考２
    DENCMC          As String * 80      '備考３
    DENCMD          As String * 80      '備考４
    DENCME          As String * 80      '備考５
    DENCMF          As String * 80      '備考６
    TFPATH          As String * 128     '添付ファイルパス
    LSTID           As String * 7       '伝票種別
    TKNRPSKB        As String * 1       '金額端数処理桁数
    TKNZRNKB        As String * 1       '金額端数処理区分
    TOKZEIKB        As String * 1       '消費税区分
    TOKZCLKB        As String * 1       '消費税算出区分
    TOKRPSKB        As String * 1       '消費税端数処理桁数
    TOKZRNKB        As String * 1       '消費税端数処理区分
    TOKNMMKB        As String * 1       '名称ﾏﾆｭｱﾙ入力区分（得意先）
    NHSNMMKB        As String * 1       '名称ﾏﾆｭｱﾙ入力区分（納入先）
    TOKMSTKB        As String * 1       'マスタ区分（得意先）
    NHSMSTKB        As String * 1       'マスタ区分（納入先）
    TANMSTKB        As String * 1       'マスタ区分（担当者）
    JDNNO           As String * 10      '受注番号
    MSBNNO          As String * 20      '製番
    KENNMA          As String * 40      '件名１
    KENNMB          As String * 40      '件名２
    YUKOKGN         As String * 30      '有効期限
    SHAJKN          As String * 30      '支払条件
    JDNTRKB         As String * 2       '受注取引区分
    NHSADA          As String * 60      '納入先住所１
    NHSADB          As String * 60      '納入先住所２
    NHSADC          As String * 60      '納入先住所３
    KKTMTFL         As String * 1       '確定見積フラグ
    HANPLFL         As String * 1       '販売計画連携フラグ
    TKAFL           As String * 1       '特価フラグ
    KHIKFL          As String * 1       '仮引当フラグ
    TOKTL           As String * 20      '得意先電話番号
    TOKFX           As String * 20      '得意先ＦＡＸ番号
    TOKTANNM        As String * 30      '得意先御担当者名
    TOKMLAD         As String * 50      '得意先メールアドレス
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type
Global DB_MITTHA As TYPE_DB_MITTHA
Global DBN_MITTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + MITNO )
' Index3( SMADT )
' Index4( DATKB + MITDT + MITNO + TOKCD )

Sub MITTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_MITTHA, G_LB)
    Call ResetBuf(DBN_MITTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPMITTHA_SEARCH
    '   概要：  見積見出しトラン検索
    '   引数：　pin_strMITNO          :見積番号
    '           pin_strMITNOV  　　　 :版数
    '           pot_DB_MITTHA  　　　 :見積見出しトランデータ
    '           pin_strDATKB   　　　 :伝票削除区分（Optional、渡されない場合"1"）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPMITTHA_SEARCH(ByVal pin_strMITNO As String, _
                                  ByVal pin_strMITNOV As String, _
                                  ByRef pot_DB_MITTHA As TYPE_DB_MITTHA, _
                         Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPMITTHA_SEARCH
    
    DSPMITTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from MITTHA "
    strSQL = strSQL & "  Where MITNO = '" & pin_strMITNO & "' "
    strSQL = strSQL & "  And   MITNOV = '" & pin_strMITNOV & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        '取得データなし
        DSPMITTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_MITTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '伝票管理№
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '伝票区分
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '見積番号
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  '版数
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    '案件ＩＤ
            .MITDT = CF_Ora_GetDyn(Usr_Ody, "MITDT", "")                    '見積日付
            .JDNYTDT = CF_Ora_GetDyn(Usr_Ody, "JDNYTDT", "")                '受注予定日
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '納期
            .NOKDTPRT = CF_Ora_GetDyn(Usr_Ody, "NOKDTPRT", "")              '客先納期（印字用）
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '得意先略称
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '納入先コード
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '納入先名称１
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '納入先名称２
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '担当者コード
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '担当者名
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    '部門コード
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    '営業部門名
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '倉庫コード
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '倉庫名
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    '取引区分
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    '取引区分名
            .SBAMITKN = CF_Ora_GetDyn(Usr_Ody, "SBAMITKN", 0)               '見積金額（本体合計）
            .SBAMZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZEKN", 0)               '見積金額（消費税額）
            .SBAMZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAMZKKN", 0)               '見積金額（伝票計）
            .DENCMA = CF_Ora_GetDyn(Usr_Ody, "DENCMA", "")                  '備考１
            .DENCMB = CF_Ora_GetDyn(Usr_Ody, "DENCMB", "")                  '備考２
            .DENCMC = CF_Ora_GetDyn(Usr_Ody, "DENCMC", "")                  '備考３
            .DENCMD = CF_Ora_GetDyn(Usr_Ody, "DENCMD", "")                  '備考４
            .DENCME = CF_Ora_GetDyn(Usr_Ody, "DENCME", "")                  '備考５
            .DENCMF = CF_Ora_GetDyn(Usr_Ody, "DENCMF", "")                  '備考６
            .TFPATH = CF_Ora_GetDyn(Usr_Ody, "TFPATH", "")                  '添付ファイルパス
            .LSTID = CF_Ora_GetDyn(Usr_Ody, "LSTID", "")                    '伝票種別
            .TKNRPSKB = CF_Ora_GetDyn(Usr_Ody, "TKNRPSKB", "")              '金額端数処理桁数
            .TKNZRNKB = CF_Ora_GetDyn(Usr_Ody, "TKNZRNKB", "")              '金額端数処理区分
            .TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")              '消費税区分
            .TOKZCLKB = CF_Ora_GetDyn(Usr_Ody, "TOKZCLKB", "")              '消費税算出区分
            .TOKRPSKB = CF_Ora_GetDyn(Usr_Ody, "TOKRPSKB", "")              '消費税端数処理桁数
            .TOKZRNKB = CF_Ora_GetDyn(Usr_Ody, "TOKZRNKB", "")              '消費税端数処理区分
            .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '名称ﾏﾆｭｱﾙ入力区分（得意先）
            .NHSNMMKB = CF_Ora_GetDyn(Usr_Ody, "NHSNMMKB", "")              '名称ﾏﾆｭｱﾙ入力区分（納入先）
            .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              'マスタ区分（得意先）
            .NHSMSTKB = CF_Ora_GetDyn(Usr_Ody, "NHSMSTKB", "")              'マスタ区分（納入先）
            .TANMSTKB = CF_Ora_GetDyn(Usr_Ody, "TANMSTKB", "")              'マスタ区分（担当者）
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    '受注番号
            .MSBNNO = CF_Ora_GetDyn(Usr_Ody, "MSBNNO", "")                  '製番
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '件名１
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '件名２
            .YUKOKGN = CF_Ora_GetDyn(Usr_Ody, "YUKOKGN", "")                '有効期限
            .SHAJKN = CF_Ora_GetDyn(Usr_Ody, "SHAJKN", "")                  '支払条件
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                '受注取引区分
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '納入先住所１
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '納入先住所２
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '納入先住所３
            .KKTMTFL = CF_Ora_GetDyn(Usr_Ody, "KKTMTFL", "")                '確定見積フラグ
            .HANPLFL = CF_Ora_GetDyn(Usr_Ody, "HANPLFL", "")                '販売計画連携フラグ
            .TKAFL = CF_Ora_GetDyn(Usr_Ody, "TKAFL", "")                    '特価フラグ
            .KHIKFL = CF_Ora_GetDyn(Usr_Ody, "KHIKFL", "")                  '仮引当フラグ
            .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '得意先電話番号
            .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '得意先ＦＡＸ番号
            .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '得意先御担当者名
            .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '得意先メールアドレス
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
    

    DSPMITTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPMITTHA_SEARCH:
        
End Function
    


