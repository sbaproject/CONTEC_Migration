Attribute VB_Name = "HINMTA_DBM"
        Option Explicit
'==========================================================================
'   HINMTA.DBM   商品マスタ                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_HINMTA
    DATKB          As String * 1     '伝票削除区分
    HINMSTKB       As String * 1     'マスタ区分（商品）
    HINCD          As String * 10    '製品コード
    HINNMA         As String * 50    '型式
    HINNMB         As String * 50    '商品名１
    HINNMC         As String * 30    '商品名２
    HINNK          As String * 10    '商品名カナ
    HINNMD         As String * 40    'シリーズ商品名（半角）
    HINNME         As String * 80    'シリーズ商品名（全角）
    UNTCD          As String * 2     '単位コード
    UNTNM          As String * 4     '単位名
    HINKB          As String * 1     '商品区分
    HINID          As String * 2     '商品種別
    HINCLAKB       As String * 1     '分類区分１（商品）
    HINCLBKB       As String * 1     '分類区分２（商品）
    HINCLCKB       As String * 1     '分類区分３（商品）
    HINCLAID       As String * 6     '分類コード１（商品）
    HINCLBID       As String * 6     '分類コード２（商品）
    HINCLCID       As String * 6     '分類コード３（商品）
    HINCLANM       As String * 20    '分類名称１（商品）
    HINCLBNM       As String * 20    '分類名称２（商品）
    HINCLCNM       As String * 20    '分類名称３（商品）
    DSPKB          As String * 1     '検索表示区分
    ZAIKB          As String * 1     '在庫管理区分
    HINZEIKB       As String * 1     '商品消費税区分
    ZEIRNKKB       As String * 1     '消費税ランク
    ZEIRT          As Currency       '消費税率
    HINJUNKB       As String * 1     '順意表出力区分
    MAKCD          As String * 6     'メーカーコード
    HINCMA         As String * 20    '商品備考Ａ
    HINCMB         As String * 20    '商品備考B
    HINCMC         As String * 20    '商品備考C
    HINCMD         As String * 20    '商品備考D
    HINCME         As String * 20    '商品備考Ｅ
    TEIKATK        As Currency       '定価
    ZNKURITK       As Currency       '税抜販売単価
    ZKMURITK       As Currency       '税込販売単価
    ZNKSRETK       As Currency       '税抜仕入単価
    ZKMSRETK       As Currency       '税込仕入単価
    GNKTK          As Currency       '原価単価
    PLANTK         As Currency       '計画単価
    OLDGNKTK       As Currency       '旧原価単価
    GNKTKDT        As String * 8     '適用日(原価単価)
    OLDPLNTK       As Currency       '旧計画単価
    PLNTKDT        As String * 8     '適用日（計画単価)
    SODUNTSU       As Currency       '発注単位数
    TEKZAISU       As Currency       '適正在庫数
    ANZZAISU       As Currency       '安全在庫数（販売計画用）
    HRTDD          As String * 2     '発注リードタイム
    ORTDD          As String * 2     '出荷リードタイム
    PRCDD          As String * 2     '調達リードタイム
    MNFDD          As String * 2     '製造リードタイム
    HINSIRCD       As String * 10    '商品仕入先コード
    HINSIRRN       As String * 40    '商品仕入先名称
    TNACM          As String * 10    '棚番号
    HINNMMKB       As String * 1     '名称ﾏﾆｭｱﾙ入力区分(商品)
    JANCD          As String * 13    'ＪＡＮコード
    HINFRNNM       As String * 50    '商品名海外表記
    ZAIRNK         As String * 3     '在庫ランク
    GNKCD          As String * 3     '原価管理コード
    MINSODSU       As Currency       '最小発注数
    SODADDSU       As Currency       '発注増加数
    JODHIKKB       As String * 1     '受注引当区分
    ORTSTPKB       As String * 1     '出荷停止
    ORTSTPDT       As String * 8     '出荷停止日
    ORTKJDT        As String * 8     '出荷停止解除日
    ORTSTYDT       As String * 8     '出荷開始予定日
    CTLGKB         As String * 1     'カタログ品対象
    MLOKB          As String * 1     '通販対象
    MLOHINID       As String * 10    '通販製品ＩＤ
    MLOIDORT       As Currency       '通販移動比率
    MLOLMTSU       As Currency       '通販移動限度数
    PRDENDKB       As String * 1     '生産終了
    PRDENDDT       As String * 8     '生産終了日付
    SLENDKB        As String * 1     '販売完了
    SLENDDT        As String * 8     '販売完了日付
    JODSTPKB       As String * 1     '受注停止
    JODSTPDT       As String * 8     '受注停止日付
    MNTENDKB       As String * 1     '保守終了
    MNTENDDT       As String * 8     '保守終了日付
    ABODT          As String * 8     '廃止日
    ORTKB          As String * 1     '出荷区分
    SERIKB         As String * 1     'シリアル管理区分
    MAKNM          As String * 30    'メーカー名
    NXTMDL         As String * 40    '後継機種
    JODSTDT        As String * 8     '受注開始日
    ORTSTDT        As String * 8     '出荷開始日
    KOUZA          As String * 3     '口座
    MDLCL          As String * 15    '機種分類
    OLDMDLCL       As String * 15    '旧機種分類
    HINGRP         As String * 4     '商品群
    SKHINGRP       As String * 4     '仕切用商品群
    OEMKB          As String * 1     'ＯＥＭ
    OEMTOKRN       As String * 10    'ＯＥＭ得意先
    OPENKB         As String * 1     'オープン価格区分
    STRMATKB       As String * 2     '戦略物資区分
    TITNM1         As String * 44    '題目１
    TITNM2         As String * 44    '題目２
    TITNM3         As String * 44    '題目３
    CATSPCNM       As String * 100   'カタログスペック
    HINURLNM       As String * 100   '商品URL
    CHARANM        As String * 254   '特徴
    VSNNM          As String * 19    'バージョン
    EDIHINSY       As String * 10    'EDI商品種別
    BTOKB          As String * 10    'BTO区分
    KONPOP         As Currency       '梱包ポイント
    LOTSEQNO       As String * 2     'ロット連番
    KHNKB          As String * 1     '仮本区分
    RELFL          As String * 1     '連携フラグ
    OPEID          As String * 8     '最終作業者コード
    CLTID          As String * 5     'クライアントＩＤ
    WRTTM          As String * 6     'タイムスタンプ（時間）
    WRTDT          As String * 8     'タイムスタンプ（日付）
    WRTFSTTM       As String * 6     'タイムスタンプ（登録時間）
    WRTFSTDT       As String * 8     'タイムスタンプ（登録日）
End Type
Global DB_HINMTA As TYPE_DB_HINMTA
Global DBN_HINMTA As Integer

'商品マスタ検索引数
Public WLSHIN_BHNSEARCH     As String           '部品商品マスタ検索フラグ（1:検索する 1以外:検索しない）
' === 20060828 === INSERT S - ACE)Sejima 仮本区分対応
' === 20060829 === UPDATE S - ACE)Nagasawa
'Public WLSHIN_KHNKB         As String           '仮本区分（1:本　9:仮）
Public WLSHIN_KHNSEARCH     As String           '仮製品検索フラグ（1:仮製品を含めて検索 1以外:本製品のみ検索）
' === 20060829 === UPDATE E -
' === 20060828 === INSERT E
' === 20061026 === INSERT S - FKS)KUMEDA
Public WLSHIN_SKHINGRP      As String           '抽出条件（仕切用商品群）
' === 20061026 === INSERT E
'商品マスタ検索戻り値
Public WLSHIN_RTNCODE       As String           '製品コード

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub DB_HINMTA_Clear
    '   概要：  商品マスタ構造体クリア
    '   引数：　なし
    '   戻値：
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub DB_HINMTA_Clear(ByRef pot_DB_HINMTA As TYPE_DB_HINMTA)

        Dim Clr_DB_HINMTA As TYPE_DB_HINMTA
    
        pot_DB_HINMTA = Clr_DB_HINMTA
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPHINCD_SEARCH
    '   概要：  製品コード検索
    '   引数：  pin_strHINCD  : 検索対象製品コード
    '           pot_DB_HINMTA : 検索結果
    '           pin_strKJNDT  : 原価単価適用基準日
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
'    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
'                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH(ByVal pin_strHINCD As String, _
                                    ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, _
                                    Optional pin_strKJNDT As String = "") As Integer
' === 20060828 === UPDATE E -

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPHINCD_SEARCH
    
        DSPHINCD_SEARCH = 9
        
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
        Select Case True
            '基準日の指定がない場合
            Case Trim(pin_strKJNDT) = ""
                pin_strKJNDT = GV_UNYDate
                
            '日付の形式で渡される場合
            Case IsDate(pin_strKJNDT)
                pin_strKJNDT = Format(pin_strKJNDT, "yyyymmdd")
                
            Case Else
        End Select
' === 20060828 === UPDATE E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from HINMTA "
        strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            DSPHINCD_SEARCH = 1
            GoTo END_DSPHINCD_SEARCH
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_HINMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")              'マスタ区分（商品）
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '製品コード
                .HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")                  '型式
                .HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")                  '商品名１
                .HINNMC = CF_Ora_GetDyn(Usr_Ody, "HINNMC", "")                  '商品名２
                .HINNK = CF_Ora_GetDyn(Usr_Ody, "HINNK", "")                    '商品名カナ
                .HINNMD = CF_Ora_GetDyn(Usr_Ody, "HINNMD", "")                  'シリーズ商品名（半角）
                .HINNME = CF_Ora_GetDyn(Usr_Ody, "HINNME", "")                  'シリーズ商品名（全角）
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")                    '単位コード
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")                    '単位名
                .HINKB = CF_Ora_GetDyn(Usr_Ody, "HINKB", "")                    '商品区分
                .HINID = CF_Ora_GetDyn(Usr_Ody, "HINID", "")                    '商品種別
                .HINCLAKB = CF_Ora_GetDyn(Usr_Ody, "HINCLAKB", "")              '分類区分１（商品）
                .HINCLBKB = CF_Ora_GetDyn(Usr_Ody, "HINCLBKB", "")              '分類区分２（商品）
                .HINCLCKB = CF_Ora_GetDyn(Usr_Ody, "HINCLCKB", "")              '分類区分３（商品）
                .HINCLAID = CF_Ora_GetDyn(Usr_Ody, "HINCLAID", "")              '分類コード１（商品）
                .HINCLBID = CF_Ora_GetDyn(Usr_Ody, "HINCLBID", "")              '分類コード２（商品）
                .HINCLCID = CF_Ora_GetDyn(Usr_Ody, "HINCLCID", "")              '分類コード３（商品）
                .HINCLANM = CF_Ora_GetDyn(Usr_Ody, "HINCLANM", "")              '分類名称１（商品）
                .HINCLBNM = CF_Ora_GetDyn(Usr_Ody, "HINCLBNM", "")              '分類名称２（商品）
                .HINCLCNM = CF_Ora_GetDyn(Usr_Ody, "HINCLCNM", "")              '分類名称３（商品）
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '検索表示区分
                .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "ZAIKB", "")                    '在庫管理区分
                .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "HINZEIKB", "")              '商品消費税区分
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")              '消費税ランク
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", 0)                     '消費税率
                .HINJUNKB = CF_Ora_GetDyn(Usr_Ody, "HINJUNKB", "")              '順意表出力区分
                .MAKCD = CF_Ora_GetDyn(Usr_Ody, "MAKCD", "")                    'メーカーコード
                .HINCMA = CF_Ora_GetDyn(Usr_Ody, "HINCMA", "")                  '商品備考Ａ
                .HINCMB = CF_Ora_GetDyn(Usr_Ody, "HINCMB", "")                  '商品備考B
                .HINCMC = CF_Ora_GetDyn(Usr_Ody, "HINCMC", "")                  '商品備考C
                .HINCMD = CF_Ora_GetDyn(Usr_Ody, "HINCMD", "")                  '商品備考D
                .HINCME = CF_Ora_GetDyn(Usr_Ody, "HINCME", "")                  '商品備考Ｅ
                .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "TEIKATK", 0)                 '定価
                .ZNKURITK = CF_Ora_GetDyn(Usr_Ody, "ZNKURITK", 0)               '税抜販売単価
                .ZKMURITK = CF_Ora_GetDyn(Usr_Ody, "ZKMURITK", 0)               '税込販売単価
                .ZNKSRETK = CF_Ora_GetDyn(Usr_Ody, "ZNKSRETK", 0)               '税抜仕入単価
                .ZKMSRETK = CF_Ora_GetDyn(Usr_Ody, "ZKMSRETK", 0)               '税込仕入単価
                .GNKTK = CF_Ora_GetDyn(Usr_Ody, "GNKTK", 0)                     '原価単価
                .PLANTK = CF_Ora_GetDyn(Usr_Ody, "PLANTK", 0)                   '計画単価
                .OLDGNKTK = CF_Ora_GetDyn(Usr_Ody, "OLDGNKTK", 0)               '旧原価単価
                .GNKTKDT = CF_Ora_GetDyn(Usr_Ody, "GNKTKDT", "")                '適用日(原価単価)
                .OLDPLNTK = CF_Ora_GetDyn(Usr_Ody, "OLDPLNTK", 0)               '旧計画単価
                .PLNTKDT = CF_Ora_GetDyn(Usr_Ody, "PLNTKDT", "")                '適用日（機種分類)
                .SODUNTSU = CF_Ora_GetDyn(Usr_Ody, "SODUNTSU", 0)               '発注単位数
                .TEKZAISU = CF_Ora_GetDyn(Usr_Ody, "TEKZAISU", 0)               '適正在庫数
                .ANZZAISU = CF_Ora_GetDyn(Usr_Ody, "ANZZAISU", 0)               '安全在庫数（販売計画用）
                .HRTDD = CF_Ora_GetDyn(Usr_Ody, "HRTDD", "")                    '発注リードタイム
                .ORTDD = CF_Ora_GetDyn(Usr_Ody, "ORTDD", "")                    '出荷リードタイム
                .PRCDD = CF_Ora_GetDyn(Usr_Ody, "PRCDD", "")                    '調達リードタイム
                .MNFDD = CF_Ora_GetDyn(Usr_Ody, "MNFDD", "")                    '製造リードタイム
                .HINSIRCD = CF_Ora_GetDyn(Usr_Ody, "HINSIRCD", "")              '商品仕入先コード
                .HINSIRRN = CF_Ora_GetDyn(Usr_Ody, "HINSIRRN", "")              '商品仕入先名称
                .TNACM = CF_Ora_GetDyn(Usr_Ody, "TNACM", "")                    '棚番号
                .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "HINNMMKB", "")              '名称ﾏﾆｭｱﾙ入力区分(商品)
                .JANCD = CF_Ora_GetDyn(Usr_Ody, "JANCD", "")                    'ＪＡＮコード
                .HINFRNNM = CF_Ora_GetDyn(Usr_Ody, "HINFRNNM", "")              '商品名海外表記
                .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "ZAIRNK", "")                  '在庫ランク
                .GNKCD = CF_Ora_GetDyn(Usr_Ody, "GNKCD", "")                    '原価管理コード
                .MINSODSU = CF_Ora_GetDyn(Usr_Ody, "MINSODSU", 0)               '最小発注数
                .SODADDSU = CF_Ora_GetDyn(Usr_Ody, "SODADDSU", 0)               '発注増加数
                .JODHIKKB = CF_Ora_GetDyn(Usr_Ody, "JODHIKKB", "")              '受注引当区分
                .ORTSTPKB = CF_Ora_GetDyn(Usr_Ody, "ORTSTPKB", "")              '出荷停止
                .ORTSTPDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTPDT", "")              '出荷停止日
                .ORTKJDT = CF_Ora_GetDyn(Usr_Ody, "ORTKJDT", "")                '出荷停止解除日
                .ORTSTYDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTYDT", "")              '出荷開始予定日
                .CTLGKB = CF_Ora_GetDyn(Usr_Ody, "CTLGKB", "")                  'カタログ品対象
                .MLOKB = CF_Ora_GetDyn(Usr_Ody, "MLOKB", "")                    '通販対象
                .MLOHINID = CF_Ora_GetDyn(Usr_Ody, "MLOHINID", "")              '通販製品ＩＤ
                .MLOIDORT = CF_Ora_GetDyn(Usr_Ody, "MLOIDORT", 0)               '通販移動比率
                .MLOLMTSU = CF_Ora_GetDyn(Usr_Ody, "MLOLMTSU", "")              '通販移動限度数
                .PRDENDKB = CF_Ora_GetDyn(Usr_Ody, "PRDENDKB", "")              '生産終了
                .PRDENDDT = CF_Ora_GetDyn(Usr_Ody, "PRDENDDT", "")              '生産終了日付
                .SLENDKB = CF_Ora_GetDyn(Usr_Ody, "SLENDKB", "")                '販売完了
                .SLENDDT = CF_Ora_GetDyn(Usr_Ody, "SLENDDT", "")                '販売完了日付
                .JODSTPKB = CF_Ora_GetDyn(Usr_Ody, "JODSTPKB", "")              '受注停止
                .JODSTPDT = CF_Ora_GetDyn(Usr_Ody, "JODSTPDT", "")              '受注停止日付
                .MNTENDKB = CF_Ora_GetDyn(Usr_Ody, "MNTENDKB", "")              '保守終了
                .MNTENDDT = CF_Ora_GetDyn(Usr_Ody, "MNTENDDT", "")              '保守終了日付
                .ABODT = CF_Ora_GetDyn(Usr_Ody, "ABODT", "")                    '廃止日
                .ORTKB = CF_Ora_GetDyn(Usr_Ody, "ORTKB", "")                    '出荷区分
                .SERIKB = CF_Ora_GetDyn(Usr_Ody, "SERIKB", "")                  'シリアル管理区分
                .MAKNM = CF_Ora_GetDyn(Usr_Ody, "MAKNM", "")                    'メーカー名
                .NXTMDL = CF_Ora_GetDyn(Usr_Ody, "NXTMDL", "")                  '後継機種
                .JODSTDT = CF_Ora_GetDyn(Usr_Ody, "JODSTDT", "")                '受注開始日
                .ORTSTDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTDT", "")                '出荷開始日
                .KOUZA = CF_Ora_GetDyn(Usr_Ody, "KOUZA", "")                    '口座
                .MDLCL = CF_Ora_GetDyn(Usr_Ody, "MDLCL", "")                    '機種分類
                .OLDMDLCL = CF_Ora_GetDyn(Usr_Ody, "OLDMDLCL", "")              '旧機種分類
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '商品群
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '仕切用商品群
                .OEMKB = CF_Ora_GetDyn(Usr_Ody, "OEMKB", "")                    'ＯＥＭ
                .OEMTOKRN = CF_Ora_GetDyn(Usr_Ody, "OEMTOKRN", "")              'ＯＥＭ得意先
                .OPENKB = CF_Ora_GetDyn(Usr_Ody, "OPENKB", "")                  'オープン価格区分
                .STRMATKB = CF_Ora_GetDyn(Usr_Ody, "STRMATKB", "")              '戦略物資区分
                .TITNM1 = CF_Ora_GetDyn(Usr_Ody, "TITNM1", "")                  '題目１
                .TITNM2 = CF_Ora_GetDyn(Usr_Ody, "TITNM2", "")                  '題目２
                .TITNM3 = CF_Ora_GetDyn(Usr_Ody, "TITNM3", "")                  '題目３
                .CATSPCNM = CF_Ora_GetDyn(Usr_Ody, "CATSPCNM", "")              'カタログスペック
                .HINURLNM = CF_Ora_GetDyn(Usr_Ody, "HINURLNM", "")              '商品URL
                .CHARANM = CF_Ora_GetDyn(Usr_Ody, "CHARANM", "")                '特徴
                .VSNNM = CF_Ora_GetDyn(Usr_Ody, "VSNNM", "")                    'バージョン
                .EDIHINSY = CF_Ora_GetDyn(Usr_Ody, "EDIHINSY", "")              'EDI商品種別
                .BTOKB = CF_Ora_GetDyn(Usr_Ody, "BTOKB", "")                    'BTO区分
                .KONPOP = CF_Ora_GetDyn(Usr_Ody, "KONPOP", 0)                   '梱包ポイント
                .LOTSEQNO = CF_Ora_GetDyn(Usr_Ody, "LOTSEQNO", "")              'ロット連番
                .KHNKB = CF_Ora_GetDyn(Usr_Ody, "KHNKB", "")                    '仮本区分
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
                
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
                        .PLANTK = .OLDPLNTK
                    End If
                End If
' === 20060828 === UPDATE E -

' === 20061107 === INSERT S - ACE)Nagasawa 機種分類適用日対応
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
' === 20061107 === INSERT E -

            End With
        End If

        DSPHINCD_SEARCH = 0
        
END_DSPHINCD_SEARCH:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPHINCD_SEARCH:
        GoTo END_DSPHINCD_SEARCH
        
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function DSPHINCD_SEARCH_B
    '   概要：  製品コード検索（部品商品マスタも合わせて検索）
    '   引数：  pin_strHINCD  : 検索対象製品コード
    '           pot_DB_HINMTA : 検索結果
    '           pin_strKJNDT  : 原価単価適用基準日
    '   戻値：　0:正常終了 1:対象データ無し 9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
'    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
'                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA) As Integer
    Public Function DSPHINCD_SEARCH_B(ByVal pin_strHINCD As String, _
                                      ByRef pot_DB_HINMTA As TYPE_DB_HINMTA, _
                                      Optional ByVal pin_strKJNDT As String = "") As Integer
' === 20060828 === UPDATE E -

        Dim strSQL          As String
        Dim intData         As Integer
        Dim Usr_Ody         As U_Ody

    On Error GoTo ERR_DSPHINCD_SEARCH_B
    
        DSPHINCD_SEARCH_B = 9
        
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
        If Trim(pin_strKJNDT) = "" Then
            pin_strKJNDT = GV_UNYDate
        End If
' === 20060828 === UPDATE E -

        strSQL = ""
        strSQL = strSQL & " Select * "
        strSQL = strSQL & "   from HINMTA "
        strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
        If CF_Ora_EOF(Usr_Ody) = True Then
            '取得データなし
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            
            '部品商品マスタ
            strSQL = ""
            strSQL = strSQL & " Select * "
            strSQL = strSQL & "   from BHNMTA "
            strSQL = strSQL & "  Where HINCD = '" & pin_strHINCD & "' "
            
            'DBアクセス
            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
 
            If CF_Ora_EOF(Usr_Ody) = True Then
                '該当データ無し
                DSPHINCD_SEARCH_B = 1
                GoTo END_DSPHINCD_SEARCH_B
            End If
        End If
        
        If CF_Ora_EOF(Usr_Ody) = False Then
            With pot_DB_HINMTA
                .DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "")                    '伝票削除区分
                .HINMSTKB = CF_Ora_GetDyn(Usr_Ody, "HINMSTKB", "")              'マスタ区分（商品）
                .HINCD = CF_Ora_GetDyn(Usr_Ody, "HINCD", "")                    '製品コード
                .HINNMA = CF_Ora_GetDyn(Usr_Ody, "HINNMA", "")                  '型式
                .HINNMB = CF_Ora_GetDyn(Usr_Ody, "HINNMB", "")                  '商品名１
                .HINNMC = CF_Ora_GetDyn(Usr_Ody, "HINNMC", "")                  '商品名２
                .HINNK = CF_Ora_GetDyn(Usr_Ody, "HINNK", "")                    '商品名カナ
                .HINNMD = CF_Ora_GetDyn(Usr_Ody, "HINNMD", "")                  'シリーズ商品名（半角）
                .HINNME = CF_Ora_GetDyn(Usr_Ody, "HINNME", "")                  'シリーズ商品名（全角）
                .UNTCD = CF_Ora_GetDyn(Usr_Ody, "UNTCD", "")                    '単位コード
                .UNTNM = CF_Ora_GetDyn(Usr_Ody, "UNTNM", "")                    '単位名
                .HINKB = CF_Ora_GetDyn(Usr_Ody, "HINKB", "")                    '商品区分
                .HINID = CF_Ora_GetDyn(Usr_Ody, "HINID", "")                    '商品種別
                .HINCLAKB = CF_Ora_GetDyn(Usr_Ody, "HINCLAKB", "")              '分類区分１（商品）
                .HINCLBKB = CF_Ora_GetDyn(Usr_Ody, "HINCLBKB", "")              '分類区分２（商品）
                .HINCLCKB = CF_Ora_GetDyn(Usr_Ody, "HINCLCKB", "")              '分類区分３（商品）
                .HINCLAID = CF_Ora_GetDyn(Usr_Ody, "HINCLAID", "")              '分類コード１（商品）
                .HINCLBID = CF_Ora_GetDyn(Usr_Ody, "HINCLBID", "")              '分類コード２（商品）
                .HINCLCID = CF_Ora_GetDyn(Usr_Ody, "HINCLCID", "")              '分類コード３（商品）
                .HINCLANM = CF_Ora_GetDyn(Usr_Ody, "HINCLANM", "")              '分類名称１（商品）
                .HINCLBNM = CF_Ora_GetDyn(Usr_Ody, "HINCLBNM", "")              '分類名称２（商品）
                .HINCLCNM = CF_Ora_GetDyn(Usr_Ody, "HINCLCNM", "")              '分類名称３（商品）
                .DSPKB = CF_Ora_GetDyn(Usr_Ody, "DSPKB", "")                    '検索表示区分
                .ZAIKB = CF_Ora_GetDyn(Usr_Ody, "ZAIKB", "")                    '在庫管理区分
                .HINZEIKB = CF_Ora_GetDyn(Usr_Ody, "HINZEIKB", "")              '商品消費税区分
                .ZEIRNKKB = CF_Ora_GetDyn(Usr_Ody, "ZEIRNKKB", "")              '消費税ランク
                .ZEIRT = CF_Ora_GetDyn(Usr_Ody, "ZEIRT", 0)                     '消費税率
                .HINJUNKB = CF_Ora_GetDyn(Usr_Ody, "HINJUNKB", "")              '順意表出力区分
                .MAKCD = CF_Ora_GetDyn(Usr_Ody, "MAKCD", "")                    'メーカーコード
                .HINCMA = CF_Ora_GetDyn(Usr_Ody, "HINCMA", "")                  '商品備考Ａ
                .HINCMB = CF_Ora_GetDyn(Usr_Ody, "HINCMB", "")                  '商品備考B
                .HINCMC = CF_Ora_GetDyn(Usr_Ody, "HINCMC", "")                  '商品備考C
                .HINCMD = CF_Ora_GetDyn(Usr_Ody, "HINCMD", "")                  '商品備考D
                .HINCME = CF_Ora_GetDyn(Usr_Ody, "HINCME", "")                  '商品備考Ｅ
                .TEIKATK = CF_Ora_GetDyn(Usr_Ody, "TEIKATK", 0)                 '定価
                .ZNKURITK = CF_Ora_GetDyn(Usr_Ody, "ZNKURITK", 0)               '税抜販売単価
                .ZKMURITK = CF_Ora_GetDyn(Usr_Ody, "ZKMURITK", 0)               '税込販売単価
                .ZNKSRETK = CF_Ora_GetDyn(Usr_Ody, "ZNKSRETK", 0)               '税抜仕入単価
                .ZKMSRETK = CF_Ora_GetDyn(Usr_Ody, "ZKMSRETK", 0)               '税込仕入単価
                .GNKTK = CF_Ora_GetDyn(Usr_Ody, "GNKTK", 0)                     '原価単価
                .PLANTK = CF_Ora_GetDyn(Usr_Ody, "PLANTK", 0)                   '計画単価
                .OLDGNKTK = CF_Ora_GetDyn(Usr_Ody, "OLDGNKTK", 0)               '旧原価単価
                .GNKTKDT = CF_Ora_GetDyn(Usr_Ody, "GNKTKDT", "")                '適用日(原価単価)
                .OLDPLNTK = CF_Ora_GetDyn(Usr_Ody, "OLDPLNTK", 0)               '旧計画単価
                .PLNTKDT = CF_Ora_GetDyn(Usr_Ody, "PLNTKDT", "")                '適用日（計画単価)
                .SODUNTSU = CF_Ora_GetDyn(Usr_Ody, "SODUNTSU", 0)               '発注単位数
                .TEKZAISU = CF_Ora_GetDyn(Usr_Ody, "TEKZAISU", 0)               '適正在庫数
                .ANZZAISU = CF_Ora_GetDyn(Usr_Ody, "ANZZAISU", 0)               '安全在庫数（販売計画用）
                .HRTDD = CF_Ora_GetDyn(Usr_Ody, "HRTDD", "")                    '発注リードタイム
                .ORTDD = CF_Ora_GetDyn(Usr_Ody, "ORTDD", "")                    '出荷リードタイム
                .PRCDD = CF_Ora_GetDyn(Usr_Ody, "PRCDD", "")                    '調達リードタイム
                .MNFDD = CF_Ora_GetDyn(Usr_Ody, "MNFDD", "")                    '製造リードタイム
                .HINSIRCD = CF_Ora_GetDyn(Usr_Ody, "HINSIRCD", "")              '商品仕入先コード
                .HINSIRRN = CF_Ora_GetDyn(Usr_Ody, "HINSIRRN", "")              '商品仕入先名称
                .TNACM = CF_Ora_GetDyn(Usr_Ody, "TNACM", "")                    '棚番号
                .HINNMMKB = CF_Ora_GetDyn(Usr_Ody, "HINNMMKB", "")              '名称ﾏﾆｭｱﾙ入力区分(商品)
                .JANCD = CF_Ora_GetDyn(Usr_Ody, "JANCD", "")                    'ＪＡＮコード
                .HINFRNNM = CF_Ora_GetDyn(Usr_Ody, "HINFRNNM", "")              '商品名海外表記
                .ZAIRNK = CF_Ora_GetDyn(Usr_Ody, "ZAIRNK", "")                  '在庫ランク
                .GNKCD = CF_Ora_GetDyn(Usr_Ody, "GNKCD", "")                    '原価管理コード
                .MINSODSU = CF_Ora_GetDyn(Usr_Ody, "MINSODSU", 0)               '最小発注数
                .SODADDSU = CF_Ora_GetDyn(Usr_Ody, "SODADDSU", 0)               '発注増加数
                .JODHIKKB = CF_Ora_GetDyn(Usr_Ody, "JODHIKKB", "")              '受注引当区分
                .ORTSTPKB = CF_Ora_GetDyn(Usr_Ody, "ORTSTPKB", "")              '出荷停止
                .ORTSTPDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTPDT", "")              '出荷停止日
                .ORTKJDT = CF_Ora_GetDyn(Usr_Ody, "ORTKJDT", "")                '出荷停止解除日
                .ORTSTYDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTYDT", "")              '出荷開始予定日
                .CTLGKB = CF_Ora_GetDyn(Usr_Ody, "CTLGKB", "")                  'カタログ品対象
                .MLOKB = CF_Ora_GetDyn(Usr_Ody, "MLOKB", "")                    '通販対象
                .MLOHINID = CF_Ora_GetDyn(Usr_Ody, "MLOHINID", "")              '通販製品ＩＤ
                .MLOIDORT = CF_Ora_GetDyn(Usr_Ody, "MLOIDORT", 0)               '通販移動比率
                .MLOLMTSU = CF_Ora_GetDyn(Usr_Ody, "MLOLMTSU", "")              '通販移動限度数
                .PRDENDKB = CF_Ora_GetDyn(Usr_Ody, "PRDENDKB", "")              '生産終了
                .PRDENDDT = CF_Ora_GetDyn(Usr_Ody, "PRDENDDT", "")              '生産終了日付
                .SLENDKB = CF_Ora_GetDyn(Usr_Ody, "SLENDKB", "")                '販売完了
                .SLENDDT = CF_Ora_GetDyn(Usr_Ody, "SLENDDT", "")                '販売完了日付
                .JODSTPKB = CF_Ora_GetDyn(Usr_Ody, "JODSTPKB", "")              '受注停止
                .JODSTPDT = CF_Ora_GetDyn(Usr_Ody, "JODSTPDT", "")              '受注停止日付
                .MNTENDKB = CF_Ora_GetDyn(Usr_Ody, "MNTENDKB", "")              '保守終了
                .MNTENDDT = CF_Ora_GetDyn(Usr_Ody, "MNTENDDT", "")              '保守終了日付
                .ABODT = CF_Ora_GetDyn(Usr_Ody, "ABODT", "")                    '廃止日
                .ORTKB = CF_Ora_GetDyn(Usr_Ody, "ORTKB", "")                    '出荷区分
                .SERIKB = CF_Ora_GetDyn(Usr_Ody, "SERIKB", "")                  'シリアル管理区分
                .MAKNM = CF_Ora_GetDyn(Usr_Ody, "MAKNM", "")                    'メーカー名
                .NXTMDL = CF_Ora_GetDyn(Usr_Ody, "NXTMDL", "")                  '後継機種
                .JODSTDT = CF_Ora_GetDyn(Usr_Ody, "JODSTDT", "")                '受注開始日
                .ORTSTDT = CF_Ora_GetDyn(Usr_Ody, "ORTSTDT", "")                '出荷開始日
                .KOUZA = CF_Ora_GetDyn(Usr_Ody, "KOUZA", "")                    '口座
                .MDLCL = CF_Ora_GetDyn(Usr_Ody, "MDLCL", "")                    '機種分類
                .OLDMDLCL = CF_Ora_GetDyn(Usr_Ody, "OLDMDLCL", "")              '旧機種分類
                .HINGRP = CF_Ora_GetDyn(Usr_Ody, "HINGRP", "")                  '商品群
                .SKHINGRP = CF_Ora_GetDyn(Usr_Ody, "SKHINGRP", "")              '仕切用商品群
                .OEMKB = CF_Ora_GetDyn(Usr_Ody, "OEMKB", "")                    'ＯＥＭ
                .OEMTOKRN = CF_Ora_GetDyn(Usr_Ody, "OEMTOKRN", "")              'ＯＥＭ得意先
                .OPENKB = CF_Ora_GetDyn(Usr_Ody, "OPENKB", "")                  'オープン価格区分
                .STRMATKB = CF_Ora_GetDyn(Usr_Ody, "STRMATKB", "")              '戦略物資区分
                .TITNM1 = CF_Ora_GetDyn(Usr_Ody, "TITNM1", "")                  '題目１
                .TITNM2 = CF_Ora_GetDyn(Usr_Ody, "TITNM2", "")                  '題目２
                .TITNM3 = CF_Ora_GetDyn(Usr_Ody, "TITNM3", "")                  '題目３
                .CATSPCNM = CF_Ora_GetDyn(Usr_Ody, "CATSPCNM", "")              'カタログスペック
                .HINURLNM = CF_Ora_GetDyn(Usr_Ody, "HINURLNM", "")              '商品URL
                .CHARANM = CF_Ora_GetDyn(Usr_Ody, "CHARANM", "")                '特徴
                .VSNNM = CF_Ora_GetDyn(Usr_Ody, "VSNNM", "")                    'バージョン
                .EDIHINSY = CF_Ora_GetDyn(Usr_Ody, "EDIHINSY", "")              'EDI商品種別
                .BTOKB = CF_Ora_GetDyn(Usr_Ody, "BTOKB", "")                    'BTO区分
                .KONPOP = CF_Ora_GetDyn(Usr_Ody, "KONPOP", 0)                   '梱包ポイント
                .LOTSEQNO = CF_Ora_GetDyn(Usr_Ody, "LOTSEQNO", "")              'ロット連番
                .KHNKB = CF_Ora_GetDyn(Usr_Ody, "KHNKB", "")                    '仮本区分
                .RELFL = CF_Ora_GetDyn(Usr_Ody, "RELFL", "")                    '連携フラグ
                .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")                    '最終作業者コード
                .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")                    'クライアントＩＤ
                .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")                    'タイムスタンプ（時間）
                .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")                    'タイムスタンプ（日付）
                .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")              'タイムスタンプ（登録時間）
                .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")              'タイムスタンプ（登録日）
' === 20060828 === UPDATE S - ACE)Nagasawa 原価単価適用日対応
                If Trim(.GNKTKDT) <> "" Then
                    If .GNKTKDT > pin_strKJNDT Then
                        .GNKTK = .OLDGNKTK
' === 20080104 === INSERT S - ACE)Nagasawa
                        .PLANTK = .OLDPLNTK
' === 20080104 === INSERT E -
                    End If
                End If
' === 20060828 === UPDATE E -

' === 20080104 === INSERT S - ACE)Nagasawa
                If Trim(.PLNTKDT) <> "" Then
                    If .PLNTKDT > pin_strKJNDT Then
                        .MDLCL = .OLDMDLCL
                    End If
                End If
' === 20080104 === INSERT E -

            End With
        End If
        
        DSPHINCD_SEARCH_B = 0
        
END_DSPHINCD_SEARCH_B:
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        
        Exit Function
    
ERR_DSPHINCD_SEARCH_B:
        GoTo END_DSPHINCD_SEARCH_B
        
    End Function


