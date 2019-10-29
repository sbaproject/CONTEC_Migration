Attribute VB_Name = "TOKMTA_DBM"
        Option Explicit
'==========================================================================
'   TOKMTA.DBM   得意先マスタ                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_TOKMTA
    DATKB          As String * 1     '伝票削除区分          0
    TOKMSTKB       As String * 1     'マスタ区分(得意先)    0
    THSCD          As String * 1     '取引先分類            0
    TOKCD          As String * 10    '得意先コード          !@@@@@@@@@@
    TOKNMA         As String * 60    '得意先名称１
    TOKNMB         As String * 60    '得意先名称２
    TOKRN          As String * 40    '得意先略称
    TOKNK          As String * 10    '得意先名称カナ
    TOKNMC         As String * 30    '得意先名称半角１
    TOKNMD         As String * 30    '得意先名称半角２
    TOKRNNK        As String * 20    '得意先略称カナ
    TOKZP          As String * 20    '得意先郵便番号
    TOKADA         As String * 60    '得意先住所１
    TOKADB         As String * 60    '得意先住所２
    TOKADC         As String * 60    '得意先住所３
    TOKTL          As String * 20    '得意先電話番号
    TOKFX          As String * 20    '得意先ＦＡＸ番号
    TOKBOSNM       As String * 30    '得意先代表者名
    TOKTANNM       As String * 30    '得意先御担当者名
    TOKMLAD        As String * 50    '得意先メールアドレス
    TANCD          As String * 6     '担当者コード          000000
    TANNM          As String * 40    '担当者名
    LMTKN          As Currency       '与信限度額            ####,###,##0.0000;;#
    TOKCLAKB       As String * 1     '分類区分１（得意先）  0
    TOKCLBKB       As String * 1     '分類区分２（得意先）  0
    TOKCLCKB       As String * 1     '分類区分３（得意先）  0
    TOKCLAID       As String * 6     '分類コード１(得意先)  !@@@@@@
    TOKCLBID       As String * 6     '分類コード２(得意先)  !@@@@@@
    TOKCLCID       As String * 6     '分類コード３(得意先)  !@@@@@@
    TOKCLANM       As String * 20    '分類名称１(得意先)
    TOKCLBNM       As String * 20    '分類名称２(得意先)
    TOKCLCNM       As String * 20    '分類名称３(得意先)
    DSPKB          As String * 1     '検索表示区分          0
    TOKJUNKB       As String * 1     '順位表出力区分        0
    TOKSEICD       As String * 10    '請求先コード          !@@@@@@@@@@
    MAINHSCD       As String * 10    '代表納入先コード      !@@@@@@@@@@
    TOKSMEKB       As String * 1     '締区分                0
    TOKSMEDD       As String * 2     '締初期日付(売上)      DD
    TOKSMECC       As String * 2     '締サイクル(売上)      99
    TOKSDWKB       As String * 1     '締め曜日              0
    TOKKESCC       As String * 2     '回収サイクル          00
    TOKKESDD       As String * 2     '回収日付              DD
    TOKKDWKB       As String * 1     '回収曜日              0
    LSTID          As String * 7     '伝票種別              !@@@@@@@
    TKNRPSKB       As String * 1     '金額端数処理桁数      0
    TKNZRNKB       As String * 1     '金額端数処理区分      0
    TOKZEIKB       As String * 1     '消費税区分            0
    TOKZCLKB       As String * 1     '消費税算出区分        0
    TOKRPSKB       As String * 1     '消費税端数処理桁数    0
    TOKZRNKB       As String * 1     '消費税端数処理区分    0
    TOKNMMKB       As String * 1     '名称ﾏﾆｭｱﾙ区分（得）   0
    SKCHKB         As String * 1     '諸口区分              0
    IKOUKB         As String * 1     '移行データ区分        0
    TOKLEADD       As String * 2     '運送日数              DD
    URKZANDT       As String * 8     '売掛残高日付          YYYY/MM/DD
    URKZANKN       As Currency       '売掛残高金額          ##,###,###,###
    SEIZANDT       As String * 8     '請求残高日付          YYYY/MM/DD
    SEIZANKN       As Currency       '請求残高金額          ##,###,###,###
    SMAZANDT       As String * 8     '経理締残高日付        YYYY/MM/DD
    SMAZANKN       As Currency       '経理締残高金額        ##,###,###,###
    SSAZANDT       As String * 8     '請求・支払締残高日付  YYYY/MM/DD
    SSAZANKN       As Currency       '請求・支払締残高金額  ##,###,###,###
    TOKSMEDT       As String * 8     '請求締日付            YYYY/MM/DD
    SSKKZADT       As String * 8     '請求締消込残高日付    YYYY/MM/DD
    SSKKZAKN       As Currency       '請求締消込残高金額    ##,###,###,###
    OLDTOKCD       As String * 5     '旧取引先コード        00000
    TGRPCD         As String * 10    '代表会社コード        0000000000
    OLTGRPCD       As String * 5     '旧代表会社コード      00000
    KIGYOCD        As String * 6     '統一企業コード識別    000000
    KGYEDACD       As String * 6     '統一企業コード枝番    000000
    KAKZUKE        As String * 10    '格付
    BNKCD          As String * 7     '銀行コード            !@@@@@@@
    YKNKB          As String * 1     '預金種別              0
    KOZNO          As String * 7     '口座番号              0000000
    HMEIGI         As String * 40    '振込名義
    SHAKB          As String * 1     '支払区分              0
    TEGSHKN        As Currency       '手形支払金額          ##,###,###,###
    TEGRT          As Currency       '手形比率              ##0.00;;#
    NYUDD          As Currency       'サイト
    TEGSHBS        As String * 1     '手形支払場所          0
    HTSUKB         As String * 1     '振込手数料負担区分    0
    FCTCMCD        As String * 10    'ファクタリング会社コ  0000000000
    GYOSHU         As String * 5     '業種                  00000
    CHIIKI         As String * 5     '地域                  00000
    SEIHKKB        As String * 1     '請求書発行区分        0
    TOKDNKB        As String * 1     '客先指定伝票区分      0
    TUKKB          As String * 3     '通貨区分              !@@@
    BINCD          As String * 2     '便名コード            00
    FRNKB          As String * 1     '海外取引区分          0
    SIMUKE         As String * 5     '仕向地                00000
    EDIKB          As String * 1     'EDI区分               0
    EDIKBC         As String * 1     'EDI処理区分(注文情報  0
    EDIKBCU        As String * 1     'EDI処理区分(注文請    0
    EDIKBN         As String * 1     'EDI処理区分(納期回答  0
    EDIKBS         As String * 1     'EDI処理区分(出荷通知  0
    EDIKBSEI       As String * 1     'EDI処理区分(請求情報  0
    EDIKBNYU       As String * 1     'EDI処理区分(入金情報  0
    EDIKBP         As String * 1     'EDI処理区分(支払明細  0
    EDIKBYBA       As String * 1     'EDI処理区分(商品情報  0
    EDIKBYBB       As String * 1     'EDI処理区分(予備２    0
    EDIKBYBC       As String * 1     'EDI処理区分(予備３    0
    RELFL          As String * 1     '連携フラグ            0
    FOPEID         As String * 8     '初回登録ﾕｰｻﾞｰID       !@@@@@@@@
    FCLTID         As String * 5     '初回登録ｸﾗｲｱﾝﾄID      !@@@@@
    WRTFSTTM       As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
    WRTFSTDT       As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    UOPEID         As String * 8     'ユーザID(ﾊﾞｯﾁ)        !@@@@@@@@
    UCLTID         As String * 5     'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)        !@@@@@
    UWRTTM         As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    UWRTDT         As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
    PGID           As String * 7     'プログラムID          !@@@@@@@@
    
    SHAKBNM        As String * 10    '支払条件を格納（オプション用）
    HYTOKKESDD     As String * 4     '回収日付(表示用)を格納 (オプション用)
    KESISMEDT      As String * 8     '消込日における請求締日を格納   (スラッシュ含む)
End Type
Global DB_TOKMTA As TYPE_DB_TOKMTA
'Global DBN_TOKMTA As Integer
' Index1( TOKCD )
' Index2( TOKNK + TOKCD )
' Index3( TOKCLAID + TOKCLBID + TOKCLCID + TOKCD )
' Index4( TOKCLBID + TOKCLCID + TOKCD )
' Index5( TOKCLCID + TOKCD )
' Index6( TANCD + TOKCD )
' Index7( TOKSEICD + TOKCD )
' Index8( DATKB + KOZNO + HMEIGI )
' Index9( TGRPCD + TOKCD )
' Index10( DATKB + KOZNO )

'Sub TOKMTA_RClear()
'Dim TmpStat
'    TmpStat = Dll_RClear(DBN_TOKMTA, G_LB)
'    Call ResetBuf(DBN_TOKMTA)
'End Sub
