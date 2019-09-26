Attribute VB_Name = "TOKMTA_DBM"
        Option Explicit
'==========================================================================
'   TOKMTA.DBM   得意先マスタ                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TOKMTA
    DATKB           As String * 1       '伝票削除区分
    TOKMSTKB        As String * 1       'マスタ区分（得意先）
    THSCD           As String * 1       '取引先分類
    TOKCD           As String * 10      '得意先コード
    TOKNMA          As String * 60      '得意先名称１
    TOKNMB          As String * 60      '得意先名称２
    TOKRN           As String * 40      '得意先略称
    TOKNK           As String * 10      '得意先名称カナ
    TOKNMC          As String * 30      '得意先名称半角１
    TOKNMD          As String * 30      '得意先名称半角２
    TOKRNNK         As String * 20      '得意先略称カナ
    TOKZP           As String * 20      '得意先郵便番号
    TOKADA          As String * 60      '得意先住所１
    TOKADB          As String * 60      '得意先住所２
    TOKADC          As String * 60      '得意先住所３
    TOKTL           As String * 20      '得意先電話番号
    TOKFX           As String * 20      '得意先ＦＡＸ番号
    TOKBOSNM        As String * 30      '得意先代表者名
    TOKTANNM        As String * 30      '得意先御担当者名
    TOKMLAD         As String * 50      '得意先メールアドレス
    TANCD           As String * 6       '担当者コード
    TANNM           As String * 40      '担当者名
    LMTKN           As Currency         '与信限度額
    TOKCLAKB        As String * 1       '分類区分１（得意先）
    TOKCLBKB        As String * 1       '分類区分２（得意先）
    TOKCLCKB        As String * 1       '分類区分３（得意先）
    TOKCLAID        As String * 6       '分類コード１（得意先）
    TOKCLBID        As String * 6       '分類コード２（得意先）
    TOKCLCID        As String * 6       '分類コード３（得意先）
    TOKCLANM        As String * 20      '与信限度設定日
    TOKCLBNM        As String * 20      '分類名称２（得意先）
    TOKCLCNM        As String * 20      '分類名称３（得意先）
    DSPKB           As String * 1       '検索表示区分
    TOKJUNKB        As String * 1       '順位表出力区分
    TOKSEICD        As String * 10      '請求先コード
    MAINHSCD        As String * 10      '代表納入先コード
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
    TOKNMMKB        As String * 1       '名称ﾏﾆｭｱﾙ区分(得)
    SKCHKB          As String * 1       '諸口区分
    IKOUKB          As String * 1       '移行データ区分
    TOKLEADD        As String * 2       '運送日数
    URKZANDT        As String * 8       '売掛残高日付
    URKZANKN        As Currency         '売掛残高金額
    SEIZANDT        As String * 8       '請求残高日付
    SEIZANKN        As Currency         '請求残高金額
    SMAZANDT        As String * 8       '経理締残高日付
    SMAZANKN        As Currency         '経理締残高金額
    SSAZANDT        As String * 8       '請求・支払締残高日付
    SSAZANKN        As Currency         '請求・支払締残高金額
    TOKSMEDT        As String * 8       '請求締日付
    SSKKZADT        As String * 8       '請求締消込残高日付
    SSKKZAKN        As Currency         '請求締消込残高金額
    OLDTOKCD        As String * 5       '旧取引先コード
    TGRPCD          As String * 10      '代表会社コード
    OLTGRPCD        As String * 5       '旧代表会社コード
    KIGYOCD         As String * 6       '統一企業コード（識別）
    KGYEDACD        As String * 6       '統一企業コード（枝番）
    KAKZUKE         As String * 10      '格付
    BNKCD           As String * 7       '銀行コード
    YKNKB           As String * 1       '預金種別
    KOZNO           As String * 7       '口座番号
    HMEIGI          As String * 40      '振込名義
    SHAKB           As String * 1       '支払区分
    TEGSHKN         As Currency         '手形支払金額
    TEGRT           As Currency         '手形比率
    NYUDD           As Currency         'サイト
    TEGSHBS         As String * 1       '手形支払場所
    HTSUKB          As String * 1       '振込手数料負担区分
    FCTCMCD         As String * 10      'ファクタリング会社コード
    GYOSHU          As String * 5       '業種
    CHIIKI          As String * 5       '地域
    SEIHKKB         As String * 1       '請求書発行区分
    TOKDNKB         As String * 1       '客先指定伝票区分
    TUKKB           As String * 3       '通貨区分
    BINCD           As String * 2       '便名コード
    FRNKB           As String * 1       '海外取引区分
    SIMUKE          As String * 5       '仕向地
    EDIKB           As String * 1       'ＥＤＩ区分
    EDIKBC          As String * 1       'ＥＤＩ処理区分（注文情報）
    EDIKBCU         As String * 1       'ＥＤＩ処理区分（注文請）
    EDIKBN          As String * 1       'ＥＤＩ処理区分（納期回答）
    EDIKBS          As String * 1       'ＥＤＩ処理区分（出荷通知）
    EDIKBSEI        As String * 1       'ＥＤＩ処理区分（請求情報）
    EDIKBNYU        As String * 1       'ＥＤＩ処理区分（入金情報）
    EDIKBP          As String * 1       'ＥＤＩ処理区分（支払明細）
    EDIKBYBA        As String * 1       'ＥＤＩ処理区分（商品情報）
    EDIKBYBB        As String * 1       'ＥＤＩ処理区分（予備２）
    EDIKBYBC        As String * 1       'ＥＤＩ処理区分（予備３）
    RELFL           As String * 1       '連携フラグ
    OPEID           As String * 8       '最終作業者コード
    CLTID           As String * 5       'クライアントＩＤ
    WRTTM           As String * 6       'タイムスタンプ（時間）
    WRTDT           As String * 8       'タイムスタンプ（日付）
    WRTFSTTM        As String * 6       'タイムスタンプ（登録時間）
    WRTFSTDT        As String * 8       'タイムスタンプ（登録日）
End Type
Global DB_TOKMTA As TYPE_DB_TOKMTA
Global DBN_TOKMTA As Integer

' === 20060824 === INSERT S - ACE)Sejima 諸口対応
'得意先マスタ検索引数
Public WLSTOK_SKCHKB        As String           '諸口区分
' === 20060824 === INSERT E
' === 20060926 === INSERT S - ACE)Nagasawa
Public WLSTOK_FRNKB         As String           '海外取引区分
' === 20060926 === INSERT E -
'得意先マスタ検索戻り値
Public WLSTOK_RTNCODE       As String           '得意先コード

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_TOKMTA_Clear
    '   概要：  得意先マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_TOKMTA_Clear(ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA)

        Dim Clr_DB_TOKMTA As TYPE_DB_TOKMTA
    
        pot_DB_TOKMTA = Clr_DB_TOKMTA
    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPTOKCD_SEARCH
    '   概要：  得意先コード検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKCD_SEARCH(ByVal pin_strTOKCD As String, _
                                    ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPTOKCD_SEARCH
    
        DSPTOKCD_SEARCH = 9
        
        Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TOKMTA "
        strSQL = strSQL & "  Where TOKCD = '" & pin_strTOKCD & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPTOKCD_SEARCH = 1
            GoTo END_DSPTOKCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TOKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              'マスタ区分（得意先）
                .THSCD = CF_Ora_GetDyn(Usr_Ody, "THSCD", "")                    '取引先分類
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
                .TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "")                  '得意先名称１
                .TOKNMB = CF_Ora_GetDyn(Usr_Ody, "TOKNMB", "")                  '得意先名称２
                .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '得意先略称
                .TOKNK = CF_Ora_GetDyn(Usr_Ody, "TOKNK", "")                    '得意先名称カナ
                .TOKNMC = CF_Ora_GetDyn(Usr_Ody, "TOKNMC", "")                  '得意先名称半角１
                .TOKNMD = CF_Ora_GetDyn(Usr_Ody, "TOKNMD", "")                  '得意先名称半角２
                .TOKRNNK = CF_Ora_GetDyn(Usr_Ody, "TOKRNNK", "")                '得意先略称カナ
                .TOKZP = CF_Ora_GetDyn(Usr_Ody, "TOKZP", "")                    '得意先郵便番号
                .TOKADA = CF_Ora_GetDyn(Usr_Ody, "TOKADA", "")                  '得意先住所１
                .TOKADB = CF_Ora_GetDyn(Usr_Ody, "TOKADB", "")                  '得意先住所２
                .TOKADC = CF_Ora_GetDyn(Usr_Ody, "TOKADC", "")                  '得意先住所３
                .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '得意先電話番号
                .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '得意先ＦＡＸ番号
                .TOKBOSNM = CF_Ora_GetDyn(Usr_Ody, "TOKBOSNM", "")              '得意先代表者名
                .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '得意先御担当者名
                .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '得意先メールアドレス
                .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '担当者コード
                .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '担当者名
                .LMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", 0)                     '与信限度額
                .TOKCLAKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLAKB", "")              '分類区分１（得意先）
                .TOKCLBKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLBKB", "")              '分類区分２（得意先）
                .TOKCLCKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLCKB", "")              '分類区分３（得意先）
                .TOKCLAID = CF_Ora_GetDyn(Usr_Ody, "TOKCLAID", "")              '分類コード１（得意先）
                .TOKCLBID = CF_Ora_GetDyn(Usr_Ody, "TOKCLBID", "")              '分類コード２（得意先）
                .TOKCLCID = CF_Ora_GetDyn(Usr_Ody, "TOKCLCID", "")              '分類コード３（得意先）
                .TOKCLANM = CF_Ora_GetDyn(Usr_Ody, "TOKCLANM", "")              '与信限度設定日
                .TOKCLBNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLBNM", "")              '分類名称２（得意先）
                .TOKCLCNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLCNM", "")              '分類名称３（得意先）
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '検索表示区分
                .TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "TOKJUNKB", "")              '順位表出力区分
                .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '請求先コード
                .MAINHSCD = CF_Ora_GetDyn(Usr_Ody, "MAINHSCD", "")              '代表納入先コード
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
                .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '名称ﾏﾆｭｱﾙ区分(得)
                .SKCHKB = CF_Ora_GetDyn(Usr_Ody, "SKCHKB", "")                  '諸口区分
                .IKOUKB = CF_Ora_GetDyn(Usr_Ody, "IKOUKB", "")                  '移行データ区分
                .TOKLEADD = CF_Ora_GetDyn(Usr_Ody, "TOKLEADD", "")              '運送日数
                .URKZANDT = CF_Ora_GetDyn(Usr_Ody, "URKZANDT", "")              '売掛残高日付
                .URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0)               '売掛残高金額
                .SEIZANDT = CF_Ora_GetDyn(Usr_Ody, "SEIZANDT", "")              '請求残高日付
                .SEIZANKN = CF_Ora_GetDyn(Usr_Ody, "SEIZANKN", 0)               '請求残高金額
                .SMAZANDT = CF_Ora_GetDyn(Usr_Ody, "SMAZANDT", "")              '経理締残高日付
                .SMAZANKN = CF_Ora_GetDyn(Usr_Ody, "SMAZANKN", 0)               '経理締残高金額
                .SSAZANDT = CF_Ora_GetDyn(Usr_Ody, "SSAZANDT", "")              '請求・支払締残高日付
                .SSAZANKN = CF_Ora_GetDyn(Usr_Ody, "SSAZANKN", 0)               '請求・支払締残高金額
                .TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDT", "")              '請求締日付
                .SSKKZADT = CF_Ora_GetDyn(Usr_Ody, "SSKKZADT", "")              '請求締消込残高日付
'レイアウトが修正されるまで暫定
'''                .SSKKZAKN = CF_Ora_GetDyn(Usr_Ody, "SSKKZAKN", 0)               '請求締消込残高金額
                .OLDTOKCD = CF_Ora_GetDyn(Usr_Ody, "OLDTOKCD", "")              '旧取引先コード
                .TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "")                  '代表会社コード
                .OLTGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLTGRPCD", "")              '旧代表会社コード
                .KIGYOCD = CF_Ora_GetDyn(Usr_Ody, "KIGYOCD", "")                '統一企業コード（識別）
                .KGYEDACD = CF_Ora_GetDyn(Usr_Ody, "KGYEDACD", "")              '統一企業コード（枝番）
                .KAKZUKE = CF_Ora_GetDyn(Usr_Ody, "KAKZUKE", "")                '格付
                .BNKCD = CF_Ora_GetDyn(Usr_Ody, "BNKCD", "")                    '銀行コード
                .YKNKB = CF_Ora_GetDyn(Usr_Ody, "YKNKB", "")                    '預金種別
                .KOZNO = CF_Ora_GetDyn(Usr_Ody, "KOZNO", "")                    '口座番号
                .HMEIGI = CF_Ora_GetDyn(Usr_Ody, "HMEIGI", "")                  '振込名義
                .SHAKB = CF_Ora_GetDyn(Usr_Ody, "SHAKB", "")                    '支払区分
                .TEGSHKN = CF_Ora_GetDyn(Usr_Ody, "TEGSHKN", 0)                 '手形支払金額
                .TEGRT = CF_Ora_GetDyn(Usr_Ody, "TEGRT", 0)                     '手形比率
                .NYUDD = CF_Ora_GetDyn(Usr_Ody, "NYUDD", 0)                     'サイト
                .TEGSHBS = CF_Ora_GetDyn(Usr_Ody, "TEGSHBS", "")                '手形支払場所
                .HTSUKB = CF_Ora_GetDyn(Usr_Ody, "HTSUKB", "")                  '振込手数料負担区分
                .FCTCMCD = CF_Ora_GetDyn(Usr_Ody, "FCTCMCD", "")                'ファクタリング会社コード
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "")                  '業種
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "")                  '地域
                .SEIHKKB = CF_Ora_GetDyn(Usr_Ody, "SEIHKKB", "")                '請求書発行区分
                .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "TOKDNKB", "")                '客先指定伝票区分
                .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '通貨区分
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '便名コード
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '海外取引区分
                .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '仕向地
                .EDIKB = CF_Ora_GetDyn(Usr_Ody, "EDIKB", "")                    'ＥＤＩ区分
                .EDIKBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBC", "")                  'ＥＤＩ処理区分（注文情報）
                .EDIKBCU = CF_Ora_GetDyn(Usr_Ody, "EDIKBCU", "")                'ＥＤＩ処理区分（注文請）
                .EDIKBN = CF_Ora_GetDyn(Usr_Ody, "EDIKBN", "")                  'ＥＤＩ処理区分（納期回答）
                .EDIKBS = CF_Ora_GetDyn(Usr_Ody, "EDIKBS", "")                  'ＥＤＩ処理区分（出荷通知）
                .EDIKBSEI = CF_Ora_GetDyn(Usr_Ody, "EDIKBSEI", "")              'ＥＤＩ処理区分（請求情報）
                .EDIKBNYU = CF_Ora_GetDyn(Usr_Ody, "EDIKBNYU", "")              'ＥＤＩ処理区分（入金情報）
                .EDIKBP = CF_Ora_GetDyn(Usr_Ody, "EDIKBP", "")                  'ＥＤＩ処理区分（支払明細）
                .EDIKBYBA = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBA", "")              'ＥＤＩ処理区分（商品情報）
                .EDIKBYBB = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBB", "")              'ＥＤＩ処理区分（予備２）
                .EDIKBYBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBC", "")              'ＥＤＩ処理区分（予備３）
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        DSPTOKCD_SEARCH = 0
        
END_DSPTOKCD_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPTOKCD_SEARCH:
        GoTo END_DSPTOKCD_SEARCH
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPTOKRN_SEARCH
    '   概要：  得意先略称検索
    '   引数：　なし
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPTOKRN_SEARCH(ByVal pin_strTOKRN As String, _
                                    ByRef pot_DB_TOKMTA As TYPE_DB_TOKMTA) As Integer

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPTOKRN_SEARCH
    
        DSPTOKRN_SEARCH = 9
        
        Call DB_TOKMTA_Clear(pot_DB_TOKMTA)
        
        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from TOKMTA "
' === 20070219 === UPDATE S - ACE)Nagasawa 得意先名称保持対応
'        strSQL = strSQL & "  Where TRIM(TOKRN) = '" & Trim(pin_strTOKRN) & "' "
        strSQL = strSQL & "  Where TOKRN = '" & CF_Ora_Sgl(pin_strTOKRN) & "' "
' === 20070219 === UPDATE E -

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPTOKRN_SEARCH = 1
            GoTo END_DSPTOKRN_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_TOKMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .TOKMSTKB = CF_Ora_GetDyn(Usr_Ody, "TOKMSTKB", "")              'マスタ区分（得意先）
                .THSCD = CF_Ora_GetDyn(Usr_Ody, "THSCD", "")                    '取引先分類
                .TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")                    '得意先コード
                .TOKNMA = CF_Ora_GetDyn(Usr_Ody, "TOKNMA", "")                  '得意先名称１
                .TOKNMB = CF_Ora_GetDyn(Usr_Ody, "TOKNMB", "")                  '得意先名称２
                .TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                    '得意先略称
                .TOKNK = CF_Ora_GetDyn(Usr_Ody, "TOKNK", "")                    '得意先名称カナ
                .TOKNMC = CF_Ora_GetDyn(Usr_Ody, "TOKNMC", "")                  '得意先名称半角１
                .TOKNMD = CF_Ora_GetDyn(Usr_Ody, "TOKNMD", "")                  '得意先名称半角２
                .TOKRNNK = CF_Ora_GetDyn(Usr_Ody, "TOKRNNK", "")                '得意先略称カナ
                .TOKZP = CF_Ora_GetDyn(Usr_Ody, "TOKZP", "")                    '得意先郵便番号
                .TOKADA = CF_Ora_GetDyn(Usr_Ody, "TOKADA", "")                  '得意先住所１
                .TOKADB = CF_Ora_GetDyn(Usr_Ody, "TOKADB", "")                  '得意先住所２
                .TOKADC = CF_Ora_GetDyn(Usr_Ody, "TOKADC", "")                  '得意先住所３
                .TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")                    '得意先電話番号
                .TOKFX = CF_Ora_GetDyn(Usr_Ody, "TOKFX", "")                    '得意先ＦＡＸ番号
                .TOKBOSNM = CF_Ora_GetDyn(Usr_Ody, "TOKBOSNM", "")              '得意先代表者名
                .TOKTANNM = CF_Ora_GetDyn(Usr_Ody, "TOKTANNM", "")              '得意先御担当者名
                .TOKMLAD = CF_Ora_GetDyn(Usr_Ody, "TOKMLAD", "")                '得意先メールアドレス
                .TANCD = CF_Ora_GetDyn(Usr_Ody, "TANCD", "")                    '担当者コード
                .TANNM = CF_Ora_GetDyn(Usr_Ody, "TANNM", "")                    '担当者名
                .LMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", 0)                     '与信限度額
                .TOKCLAKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLAKB", "")              '分類区分１（得意先）
                .TOKCLBKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLBKB", "")              '分類区分２（得意先）
                .TOKCLCKB = CF_Ora_GetDyn(Usr_Ody, "TOKCLCKB", "")              '分類区分３（得意先）
                .TOKCLAID = CF_Ora_GetDyn(Usr_Ody, "TOKCLAID", "")              '分類コード１（得意先）
                .TOKCLBID = CF_Ora_GetDyn(Usr_Ody, "TOKCLBID", "")              '分類コード２（得意先）
                .TOKCLCID = CF_Ora_GetDyn(Usr_Ody, "TOKCLCID", "")              '分類コード３（得意先）
                .TOKCLANM = CF_Ora_GetDyn(Usr_Ody, "TOKCLANM", "")              '与信限度設定日
                .TOKCLBNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLBNM", "")              '分類名称２（得意先）
                .TOKCLCNM = CF_Ora_GetDyn(Usr_Ody, "TOKCLCNM", "")              '分類名称３（得意先）
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '検索表示区分
                .TOKJUNKB = CF_Ora_GetDyn(Usr_Ody, "TOKJUNKB", "")              '順位表出力区分
                .TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")              '請求先コード
                .MAINHSCD = CF_Ora_GetDyn(Usr_Ody, "MAINHSCD", "")              '代表納入先コード
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
                .TOKNMMKB = CF_Ora_GetDyn(Usr_Ody, "TOKNMMKB", "")              '名称ﾏﾆｭｱﾙ区分(得)
                .SKCHKB = CF_Ora_GetDyn(Usr_Ody, "SKCHKB", "")                  '諸口区分
                .IKOUKB = CF_Ora_GetDyn(Usr_Ody, "IKOUKB", "")                  '移行データ区分
                .TOKLEADD = CF_Ora_GetDyn(Usr_Ody, "TOKLEADD", "")              '運送日数
                .URKZANDT = CF_Ora_GetDyn(Usr_Ody, "URKZANDT", "")              '売掛残高日付
                .URKZANKN = CF_Ora_GetDyn(Usr_Ody, "URKZANKN", 0)               '売掛残高金額
                .SEIZANDT = CF_Ora_GetDyn(Usr_Ody, "SEIZANDT", "")              '請求残高日付
                .SEIZANKN = CF_Ora_GetDyn(Usr_Ody, "SEIZANKN", 0)               '請求残高金額
                .SMAZANDT = CF_Ora_GetDyn(Usr_Ody, "SMAZANDT", "")              '経理締残高日付
                .SMAZANKN = CF_Ora_GetDyn(Usr_Ody, "SMAZANKN", 0)               '経理締残高金額
                .SSAZANDT = CF_Ora_GetDyn(Usr_Ody, "SSAZANDT", "")              '請求・支払締残高日付
                .SSAZANKN = CF_Ora_GetDyn(Usr_Ody, "SSAZANKN", 0)               '請求・支払締残高金額
                .TOKSMEDT = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDT", "")              '請求締日付
                .SSKKZADT = CF_Ora_GetDyn(Usr_Ody, "SSKKZADT", "")              '請求締消込残高日付
'レイアウトが修正されるまで暫定
'''                .SSKKZAKN = CF_Ora_GetDyn(Usr_Ody, "SSKKZAKN", 0)               '請求締消込残高金額
                .OLDTOKCD = CF_Ora_GetDyn(Usr_Ody, "OLDTOKCD", "")              '旧取引先コード
                .TGRPCD = CF_Ora_GetDyn(Usr_Ody, "TGRPCD", "")                  '代表会社コード
                .OLTGRPCD = CF_Ora_GetDyn(Usr_Ody, "OLTGRPCD", "")              '旧代表会社コード
                .KIGYOCD = CF_Ora_GetDyn(Usr_Ody, "KIGYOCD", "")                '統一企業コード（識別）
                .KGYEDACD = CF_Ora_GetDyn(Usr_Ody, "KGYEDACD", "")              '統一企業コード（枝番）
                .KAKZUKE = CF_Ora_GetDyn(Usr_Ody, "KAKZUKE", "")                '格付
                .BNKCD = CF_Ora_GetDyn(Usr_Ody, "BNKCD", "")                    '銀行コード
                .YKNKB = CF_Ora_GetDyn(Usr_Ody, "YKNKB", "")                    '預金種別
                .KOZNO = CF_Ora_GetDyn(Usr_Ody, "KOZNO", "")                    '口座番号
                .HMEIGI = CF_Ora_GetDyn(Usr_Ody, "HMEIGI", "")                  '振込名義
                .SHAKB = CF_Ora_GetDyn(Usr_Ody, "SHAKB", "")                    '支払区分
                .TEGSHKN = CF_Ora_GetDyn(Usr_Ody, "TEGSHKN", 0)                 '手形支払金額
                .TEGRT = CF_Ora_GetDyn(Usr_Ody, "TEGRT", 0)                     '手形比率
                .NYUDD = CF_Ora_GetDyn(Usr_Ody, "NYUDD", 0)                     'サイト
                .TEGSHBS = CF_Ora_GetDyn(Usr_Ody, "TEGSHBS", "")                '手形支払場所
                .HTSUKB = CF_Ora_GetDyn(Usr_Ody, "HTSUKB", "")                  '振込手数料負担区分
                .FCTCMCD = CF_Ora_GetDyn(Usr_Ody, "FCTCMCD", "")                'ファクタリング会社コード
                .GYOSHU = CF_Ora_GetDyn(Usr_Ody, "GYOSHU", "")                  '業種
                .CHIIKI = CF_Ora_GetDyn(Usr_Ody, "CHIIKI", "")                  '地域
                .SEIHKKB = CF_Ora_GetDyn(Usr_Ody, "SEIHKKB", "")                '請求書発行区分
                .TOKDNKB = CF_Ora_GetDyn(Usr_Ody, "TOKDNKB", "")                '客先指定伝票区分
                .TUKKB = CF_Ora_GetDyn(Usr_Ody, "TUKKB", "")                    '通貨区分
                .BINCD = CF_Ora_GetDyn(Usr_Ody, "BINCD", "")                    '便名コード
                .FRNKB = CF_Ora_GetDyn(Usr_Ody, "FRNKB", "")                    '海外取引区分
                .SIMUKE = CF_Ora_GetDyn(Usr_Ody, "SIMUKE", "")                  '仕向地
                .EDIKB = CF_Ora_GetDyn(Usr_Ody, "EDIKB", "")                    'ＥＤＩ区分
                .EDIKBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBC", "")                  'ＥＤＩ処理区分（注文情報）
                .EDIKBCU = CF_Ora_GetDyn(Usr_Ody, "EDIKBCU", "")                'ＥＤＩ処理区分（注文請）
                .EDIKBN = CF_Ora_GetDyn(Usr_Ody, "EDIKBN", "")                  'ＥＤＩ処理区分（納期回答）
                .EDIKBS = CF_Ora_GetDyn(Usr_Ody, "EDIKBS", "")                  'ＥＤＩ処理区分（出荷通知）
                .EDIKBSEI = CF_Ora_GetDyn(Usr_Ody, "EDIKBSEI", "")              'ＥＤＩ処理区分（請求情報）
                .EDIKBNYU = CF_Ora_GetDyn(Usr_Ody, "EDIKBNYU", "")              'ＥＤＩ処理区分（入金情報）
                .EDIKBP = CF_Ora_GetDyn(Usr_Ody, "EDIKBP", "")                  'ＥＤＩ処理区分（支払明細）
                .EDIKBYBA = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBA", "")              'ＥＤＩ処理区分（商品情報）
                .EDIKBYBB = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBB", "")              'ＥＤＩ処理区分（予備２）
                .EDIKBYBC = CF_Ora_GetDyn(Usr_Ody, "EDIKBYBC", "")              'ＥＤＩ処理区分（予備３）
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
            End With
        End If
        
        DSPTOKRN_SEARCH = 0
        
END_DSPTOKRN_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPTOKRN_SEARCH:
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPLMTKN_SEARCH
    '   概要：  与信限度額検索
    '   引数：　pin_strTOKCD  : 得意先コード
    '           pin_strTGRPCD : 得意先グループコード
    '           pot_curLMTKN  : 与信限度額
    '   戻値：　0:正常終了 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function DSPLMTKN_SEARCH(ByVal pin_strTOKCD As String, _
                                    ByVal pin_strTGRPCD As String, _
                                    ByRef pot_curLMTKN As Currency) As Integer

        Dim strSQL          As String
        Dim Usr_Ody         As U_Ody
        Dim strTOKCD_Where  As String

    On Error GoTo ERR_DSPLMTKN_SEARCH
    
        DSPLMTKN_SEARCH = 9
        pot_curLMTKN = 0
        
        If Trim(pin_strTGRPCD) = "" Then
            strTOKCD_Where = pin_strTOKCD
        Else
            strTOKCD_Where = pin_strTGRPCD
        End If
        
        strSQL = ""
        strSQL = strSQL & " Select LMTKN "
        strSQL = strSQL & "   from TOKMTA "
        strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(strTOKCD_Where) & "' "

        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = False Then
            pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "")                  '与信限度額
            DSPLMTKN_SEARCH = 0
            
            GoTo END_DSPLMTKN_SEARCH
        End If
            
        '取得データが存在しなかった場合で、自分が親以外の場合
        If strTOKCD_Where <> pin_strTOKCD Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            
            strSQL = ""
            strSQL = strSQL & " Select LMTKN "
            strSQL = strSQL & "   from TOKMTA "
            strSQL = strSQL & "  Where DATKB        = '" & gc_strDATKB_USE & "' "
            strSQL = strSQL & "    and TRIM(TOKCD)  = '" & Trim(pin_strTOKCD) & "' "
        
           'DBアクセス
           Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
    
           If CF_Ora_EOF(Usr_Ody) = False Then
               pot_curLMTKN = CF_Ora_GetDyn(Usr_Ody, "LMTKN", "")                  '与信限度額
           End If
        End If
        
        DSPLMTKN_SEARCH = 0
        
END_DSPLMTKN_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)

        Exit Function
    
ERR_DSPLMTKN_SEARCH:
        
    End Function


