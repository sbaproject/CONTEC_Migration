Attribute VB_Name = "JDNTHA_DBM"
        Option Explicit
'==========================================================================
'   JDNTHA.DBM   受注見出トラン                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTHA
    DATNO           As String * 10      '伝票管理№
    DATKB           As String * 1       '伝票削除区分
    DENKB           As String * 1       '伝票区分
    JDNNO           As String * 10      '受注番号
    JHDNO           As String * 10      '受発注№
    JDNDT           As String * 8       '受注伝票日付
    DENDT           As String * 8       '受注日付
    DEFNOKDT        As String * 8       '納期
    TOKCD           As String * 10      '得意先コード
    TOKRN           As String * 40      '得意先略称
    NHSCD           As String * 10      '納入先コード
    NHSNMA          As String * 60      '納入先名称１
    NHSNMB          As String * 60      '納入先名称２
    TANCD           As String * 6       '担当者コード
    TANNM           As String * 40      '担当者名
    BUMCD           As String * 6       '部門コード
    BUMNM           As String * 40      '部門名
    TOKSEICD        As String * 10      '請求先コード
    SOUCD           As String * 3       '倉庫コード
    SOUNM           As String * 20      '倉庫名
    ZKTKB           As String * 1       '取引区分
    ZKTNM           As String * 4       '取引区分名
    SMADT           As String * 8       '経理締日付
    JDNENDKB        As String * 1       '受注完了区分
    SBAUODKN        As Currency         '受注金額（本体合計）
    SBAUZEKN        As Currency         '受注金額（消費税額）
    SBAUZKKN        As Currency         '受注金額（伝票計）
    DENCM           As String * 40      '備考
    TOKSMEKB        As String * 1       '締区分
    TOKSMEDD        As String * 2       '締初期日付（売上）
    TOKSMECC        As String * 2       '締サイクル（売上）
    TOKSDWKB        As String * 1       '締め曜日
    TOKKESCC        As String * 2       '回収サイクル
    TOKKESDD        As String * 2       '回収日付
    TOKKDWKB        As String * 1       '回収曜日
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
    MITNO           As String * 10      '見積番号
    MITNOV          As String * 2       '版数
' === 20060726 === UPDATE S - ACE)Nagasawa
'    AKNID           As Currency         '案件ＩＤ
    AKNID           As String           '案件ＩＤ
' === 20060726 === UPDATE E -
    CLMDL           As String * 15      '分類型式
    URIKJN          As String * 1       '売上基準
    BINCD           As String * 2       '便名コード
    KENNMA          As String * 40      '件名１
    KENNMB          As String * 40      '件名２
    BKTHKKB         As String * 1       '分割不可区分
    MAEUKKB         As String * 1       '前受区分
    SEIKB           As String * 1       '請求区分
    JDNTRKB         As String * 2       '受注取引区分
    NHSADA          As String * 60      '納入先住所１
    NHSADB          As String * 60      '納入先住所２
    NHSADC          As String * 60      '納入先住所３
    JDNINKB         As String * 1       '受注取込種別
    DFKJDNNO        As String * 12      'ダイフク受注番号
    TOKJDNNO        As String * 23      '客先注文No.
    HDKEIKN         As Currency         'ハード契約金額
    HDSIKKN         As Currency         'ハード仕切金額
    SFKEIKN         As Currency         'ソフト契約金額
    SFSIKKN         As Currency         'ソフト仕切金額
    CMPKTCD         As String * 2       'コンピュータ型式コード
    CMPKTNM         As String * 20      'コンピュータ型式名
    PRDTBMCD        As String * 6       '生産担当部門コード
    TUKKB           As String * 3       '通貨区分
    SBAFRCKN        As Currency         '外貨受注金額（伝票計）
    JODRSNKB        As String * 3       '受注理由区分
    JODCNKB         As String * 3       '受注キャンセル理由区分
    JSKTANCD        As String * 6       '地域実績担当者コード
    JSKTANNM        As String * 40      '地域実績担当者名
    JSKBMNCD        As String * 6       '地域実績部門コード
    JSKBMNNM        As String * 40      '地域実績部門名
    FRNKB           As String * 1       '海外取引区分
    SIMUKE          As String * 5       '仕向地
    JDNPRKB         As String * 1       '発行区分
    DENCMIN         As String * 40      '社内備考
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
    JDNENDNM        As String * 6       '受注完了区分名
End Type
Global DB_JDNTHA As TYPE_DB_JDNTHA
Global DBN_JDNTHA As Integer
' Index1( DATNO )
' Index2( DATKB + DENKB + JDNNO )
' Index3( SMADT )
' Index4( DATKB + JDNDT + JDNNO + TOKCD )
' Index5( DATKB + TOKCD + JDNNO )
' Index6( DATKB + JDNENDKB + TOKCD + DEFNOKDT + JDNNO )

Sub JDNTHA_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_JDNTHA, G_LB)
    Call ResetBuf(DBN_JDNTHA)
End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPJDNTHA_SEARCH
    '   概要：  受注見出しトラン検索
    '   引数：　pin_strJDNNO          :受注番号
    '           pot_DB_JDNTHA　　　　 :受注見出しトランデータ
    '           pin_strDATKB 　　　　 :伝票削除区分（Optional、渡されない場合"1"）
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Public Function DSPJDNTHA_SEARCH(ByVal pin_strJDNNO As String, _
                                 ByRef pot_DB_JDNTHA As TYPE_DB_JDNTHA, _
                        Optional ByVal pin_strDATKB As String = gc_strDATKB_USE) As Integer

    Dim strSQL          As String
    Dim intData         As Integer
    Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPJDNTHA_SEARCH
    
    DSPJDNTHA_SEARCH = 9
    
    strSQL = ""
    strSQL = strSQL & " Select * "
    strSQL = strSQL & "   from JDNTHA "
    strSQL = strSQL & "  Where JDNNO = '" & pin_strJDNNO & "' "
    strSQL = strSQL & "  And   DATKB = '" & pin_strDATKB & "' "

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    If CF_Ora_EOF(Usr_Ody) = True Then
        '取得データなし
        DSPJDNTHA_SEARCH = 1
        Exit Function
    End If
    
    If CF_Ora_EOF(Usr_Ody) = False Then
        With pot_DB_JDNTHA
            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")                    '伝票管理№
            .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
            .DENKB = CF_Ora_GetDyn(Usr_Ody, "DENKB", "")                    '伝票区分
            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")                    '受注番号
            .JHDNO = CF_Ora_GetDyn(Usr_Ody, "JHDNO", "")                    '受発注№
            .JDNDT = CF_Ora_GetDyn(Usr_Ody, "JDNDT", "")                    '受注伝票日付
            .DENDT = CF_Ora_GetDyn(Usr_Ody, "DENDT", "")                    '受注日付
            .DEFNOKDT = CF_Ora_GetDyn(Usr_Ody, "DEFNOKDT", "")              '納期
            .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
            .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '得意先略称
            .NHSCD = CF_Ora_GetDyn(Usr_Ody, "NHSCD", "")                    '納入先コード
            .NHSNMA = CF_Ora_GetDyn(Usr_Ody, "NHSNMA", "")                  '納入先名称１
            .NHSNMB = CF_Ora_GetDyn(Usr_Ody, "NHSNMB", "")                  '納入先名称２
            .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '担当者コード
            .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '担当者名
            .BUMCD = CF_Ora_GetDyn(Usr_Ody, "BUMCD", "")                    '部門コード
            .BUMNM = CF_Ora_GetDyn(Usr_Ody, "BUMNM", "")                    '部門名
            .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '請求先コード
            .SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")                    '倉庫コード
            .SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")                    '倉庫名
            .ZKTKB = CF_Ora_GetDyn(Usr_Ody, "ZKTKB", "")                    '取引区分
            .ZKTNM = CF_Ora_GetDyn(Usr_Ody, "ZKTNM", "")                    '取引区分名
            .SMADT = CF_Ora_GetDyn(Usr_Ody, "SMADT", "")                    '経理締日付
            .JDNENDKB = CF_Ora_GetDyn(Usr_Ody, "JDNENDKB", "")              '受注完了区分
            .SBAUODKN = CF_Ora_GetDyn(Usr_Ody, "SBAUODKN", 0)               '受注金額（本体合計）
            .SBAUZEKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZEKN", 0)               '受注金額（消費税額）
            .SBAUZKKN = CF_Ora_GetDyn(Usr_Ody, "SBAUZKKN", 0)               '受注金額（伝票計）
            .DENCM = CF_Ora_GetDyn(Usr_Ody, "DENCM", "")                    '備考
            .TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")              '締区分
            .TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")              '締初期日付（売上）
            .TOKSMECC = CF_Ora_GetDyn(Usr_Ody, "TOKSMECC", "")              '締サイクル（売上）
            .TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")              '締め曜日
            .TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")              '回収サイクル
            .TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")              '回収日付
            .TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")              '回収曜日
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
            .MITNO = CF_Ora_GetDyn(Usr_Ody, "MITNO", "")                    '見積番号
            .MITNOV = CF_Ora_GetDyn(Usr_Ody, "MITNOV", "")                  '版数
            .AKNID = CF_Ora_GetDyn(Usr_Ody, "AKNID", "")                    '案件ＩＤ
            .CLMDL = CF_Ora_GetDyn(Usr_Ody, "CLMDL", "")                    '分類型式
            .URIKJN = CF_Ora_GetDyn(Usr_Ody, "URIKJN", "")                  '売上基準
            .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '便名コード
            .KENNMA = CF_Ora_GetDyn(Usr_Ody, "KENNMA", "")                  '件名１
            .KENNMB = CF_Ora_GetDyn(Usr_Ody, "KENNMB", "")                  '件名２
            .BKTHKKB = CF_Ora_GetDyn(Usr_Ody, "BKTHKKB", "")                '分割不可区分
            .MAEUKKB = CF_Ora_GetDyn(Usr_Ody, "MAEUKKB", "")                '前受区分
            .SEIKB = CF_Ora_GetDyn(Usr_Ody, "SEIKB", "")                    '請求区分
            .JDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")                '受注取引区分
            .NHSADA = CF_Ora_GetDyn(Usr_Ody, "NHSADA", "")                  '納入先住所１
            .NHSADB = CF_Ora_GetDyn(Usr_Ody, "NHSADB", "")                  '納入先住所２
            .NHSADC = CF_Ora_GetDyn(Usr_Ody, "NHSADC", "")                  '納入先住所３
            .JDNINKB = CF_Ora_GetDyn(Usr_Ody, "JDNINKB", "")                '受注取込種別
            .DFKJDNNO = CF_Ora_GetDyn(Usr_Ody, "DFKJDNNO", "")              'ダイフク受注番号
            .TOKJDNNO = CF_Ora_GetDyn(Usr_Ody, "TOKJDNNO", "")              '客先注文No.
            .HDKEIKN = CF_Ora_GetDyn(Usr_Ody, "HDKEIKN", 0)                 'ハード契約金額
            .HDSIKKN = CF_Ora_GetDyn(Usr_Ody, "HDSIKKN", 0)                 'ハード仕切金額
            .SFKEIKN = CF_Ora_GetDyn(Usr_Ody, "SFKEIKN", 0)                 'ソフト契約金額
            .SFSIKKN = CF_Ora_GetDyn(Usr_Ody, "SFSIKKN", 0)                 'ソフト仕切金額
            .CMPKTCD = CF_Ora_GetDyn(Usr_Ody, "CMPKTCD", "")                'コンピュータ型式コード
            .CMPKTNM = CF_Ora_GetDyn(Usr_Ody, "CMPKTNM", "")                'コンピュータ型式名
            .PRDTBMCD = CF_Ora_GetDyn(Usr_Ody, "PRDTBMCD", "")              '生産担当部門コード
            .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '通貨区分
            .SBAFRCKN = CF_Ora_GetDyn(Usr_Ody, "SBAFRCKN", 0)               '外貨受注金額（伝票計）
            .JODRSNKB = CF_Ora_GetDyn(Usr_Ody, "JODRSNKB", "")              '受注理由区分
            .JODCNKB = CF_Ora_GetDyn(Usr_Ody, "JODCNKB", "")                '受注キャンセル理由区分
            .JSKTANCD = CF_Ora_GetDyn(Usr_Ody, "JSKTANCD", "")              '地域実績担当者コード
            .JSKTANNM = CF_Ora_GetDyn(Usr_Ody, "JSKTANNM", "")              '地域実績担当者名
            .JSKBMNCD = CF_Ora_GetDyn(Usr_Ody, "JSKBMNCD", "")              '地域実績部門コード
            .JSKBMNNM = CF_Ora_GetDyn(Usr_Ody, "JSKBMNNM", "")              '地域実績部門名
            .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '海外取引区分
            .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '仕向地
            .JDNPRKB = CF_Ora_GetDyn(Usr_Ody, "JDNPRKB", "")                '発行区分
            .DENCMIN = CF_Ora_GetDyn(Usr_Ody, "DENCMIN", "")                '社内備考
            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            .JDNENDNM = CF_Ora_GetDyn(Usr_Ody, "JDNENDNM", "")              '受注完了区分名
        End With
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody)
    

    DSPJDNTHA_SEARCH = 0
    
    Exit Function
    
ERR_DSPJDNTHA_SEARCH:
        
End Function


