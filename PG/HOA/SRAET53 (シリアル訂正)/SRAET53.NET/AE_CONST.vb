Option Strict Off
Option Explicit On
Module AE_CONST
	'********************************************************************************
	'*  システム名　　　：  新総合情報システム
	'*  サブシステム名　：　販売システム
	'*  機能　　　　　　：　共通
	'*  モジュール名　　：　共通定数宣言モジュール
	'*  作成者　　　　　：　ACE)長澤
	'*  作成日　　　　　：  2006.05.25
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD　：　修正情報
	'*     修正者
	'********************************************************************************
	
	'************************************************************************************
	'   Public定数
	'************************************************************************************
	'明細行色設定
	' === 20060802 === UPDATE S - ACE)Nagasawa
	'    Public Const COLOR_GREEN = &HC000&          '緑色 = &HC000&(濃い緑)
	Public Const COLOR_GREEN As Integer = &H3DA826 '緑色 = &H3DA826&(濃い緑)
	' === 20060802 === UPDATE E -
	Public Const COLOR_BLUE As Integer = &HFFFFC0 '青色 = &H00FFFFC0&(薄い青)
	Public Const COLOR_PALEGRAY As Integer = &HF0F0F0 '薄い灰色 = &HE0E0E0&(薄い灰色)
	Public Const COLOR_PALERED As Integer = &HC0C0FF '薄い赤色 = &H00C0C0FF&
	'UPGRADE_NOTE: COLOR_PALEYELLOW は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_PALEYELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '薄い黄色 = &HD2FAFA&
	' === 20060804 === INSERT S - ACE)Nagasawa
	'UPGRADE_NOTE: COLOR_NAVY は Constant から Variable に変更されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' をクリックしてください。
	Public COLOR_NAVY As System.Drawing.Color = System.Drawing.Color.Blue '濃い青色 = &H800000&
	' === 20060804 === INSERT E -
	
	'ユーザー伝票NO管理テーブル制御用
	Public Const gc_strDKBSB_MIT As String = "300" '見積番号取得用
	Public Const gc_strDKBSB_UOD As String = "010" '受注番号取得用
	' === 20060815 === INSERT S - ACE)Nagasawa
	Public Const gc_strDKBSB_PUDL As String = "165" '入出庫番号取得用
	' === 20060815 === INSERT E -
	Public Const gc_strDENNM_MIT As String = "見積" '見積番号取得用
	
	'採番マスタ伝票種別
	Public Const gc_strSDKBSB_UOD As String = "20" '受注番号取得用
	
	'商品消費税区分
	Public Const gc_strHINZEIKB_TOK As String = "0" '取引先区分どおり
	Public Const gc_strHINZEIKB_NUK As String = "1" '税抜き
	Public Const gc_strHINZEIKB_KOM As String = "2" '税込み
	Public Const gc_strHINZEIKB_HIK As String = "9" '非課税
	
	'得意先消費税区分
	Public Const gc_strTOKZEIKB_NUK As String = "1" '税抜き
	Public Const gc_strTOKZEIKB_KOM As String = "2" '税込み
	Public Const gc_strTOKZEIKB_HIK As String = "9" '非課税
	
	'消費税端数処理桁数
	Public Const gc_strTOKRPSKB_0 As String = "1" '円未満
	Public Const gc_strTOKRPSKB_10 As String = "2" '十円未満
	Public Const gc_strTOKRPSKB_100 As String = "3" '百円未満
	
	'消費税端数処理桁数
	Public Const gc_strTOKZRNKB_DWN As String = "0" '切捨て
	Public Const gc_strTOKZRNKB_RND As String = "5" '四捨五入
	Public Const gc_strTOKZRNKB_UP As String = "9" '切り上げ
	
	'案件情報ステータス
	Public Const gc_strANSTS_OPEN As String = "10" 'オープン
	Public Const gc_strANSTS_CLOSE As String = "20" 'クローズ
	Public Const gc_strANSTS_KZK_OPEN As String = "40" '継続オープン
	Public Const gc_strANSTS_KZK_CLOSE As String = "50" '継続クローズ
	
	'納期情報用納入業者コード
	Public Const gc_strKNNOUGYO_NO As String = "00" '無し
	Public Const gc_strKNNOUGYO_SGW As String = "01" '佐川
	Public Const gc_strKNNOUGYO_SIN As String = "02" '西濃
	
	'先行製番区分
	Public Const gc_strSNKSBN_NML As String = "1" '通常
	Public Const gc_strSNKSBN_SNK As String = "2" '先行製番
	
	'受注取込エラー区分
	Public Const gc_strTAKERRKB_OK As String = "0" '正常
	Public Const gc_strTAKERRKB_ERR As String = "1" 'エラー
	
	'受注完了区分
	Public Const gc_strJDNENDKB_NML As String = "0" '通常
	Public Const gc_strJDNENDKB_HGI As String = "8" '引当対象外
	
	'名称マスタ（キーコード）
	Public Const gc_strKEYCD_TUKKB As String = "001" '通貨区分
	Public Const gc_strKEYCD_BINCD As String = "002" '便名コード
	Public Const gc_strKEYCD_GYOSHU As String = "003" '業種コード
	Public Const gc_strKEYCD_CHIIKI As String = "004" '地域コード
	Public Const gc_strKEYCD_URIKJN As String = "005" '売上基準
	Public Const gc_strKEYCD_JDNTRKB As String = "006" '受注取引区分
	Public Const gc_strKEYCD_HDNTRKB As String = "007" '発注取引区分
	Public Const gc_strKEYCD_TNKKB As String = "008" '単価種別
	Public Const gc_strKEYCD_SHAJKN As String = "012" '支払条件コード
	Public Const gc_strKEYCD_YUKOKGN As String = "013" '有効期限コード
	Public Const gc_strKEYCD_SIMUKE As String = "014" '仕向地コード
	Public Const gc_strKEYCD_JODRSNKB As String = "016" '受注理由コード
	Public Const gc_strKEYCD_JODCNKB As String = "017" '受注キャンセル理由コード
	Public Const gc_strKEYCD_CMPKTCD As String = "020" 'コンピュータ型式
	Public Const gc_strKEYCD_SOUKOKB As String = "026" '倉庫区分
	Public Const gc_strKEYCD_MAEUKKB As String = "037" '前受区分
	Public Const gc_strKEYCD_SEIKB As String = "038" '請求区分
	Public Const gc_strKEYCD_JDNINKB As String = "039" '受注取込種別
	Public Const gc_strKEYCD_BKTHKKB As String = "046" '分割不可区分
	Public Const gc_strKEYCD_MORDKB As String = "047" '通販出荷区分
	Public Const gc_strKEYCD_GNKCD As String = "048" '原価管理コード
	Public Const gc_strKEYCD_STANCD As String = "098" '生産担当コード
	
	'名称マスタ（コード）
	'受注取引区分
	Public Const gc_strJDNTRKB_TAN As String = "01" '単品
	Public Const gc_strJDNTRKB_SET As String = "11" 'セットアップ
	Public Const gc_strJDNTRKB_SYS As String = "21" 'システム
	Public Const gc_strJDNTRKB_SYR As String = "31" '修理
	Public Const gc_strJDNTRKB_HSY As String = "41" '保守
	Public Const gc_strJDNTRKB_KAS As String = "51" '貸出
	Public Const gc_strJDNTRKB_ELS As String = "99" 'その他
	
	'単価種別
	Public Const gc_strTNKKB_TOK As String = "1" '特（仮）
	Public Const gc_strTNKKB_TOK_NM As String = "特" '特（仮）
	
	'オープン価格区分
	Public Const gc_strOPENKB_NML As String = "1" '通常
	Public Const gc_strOPENKB_OPN As String = "2" 'オープン価格
	
	'商品種別
	Public Const gc_strHINID_NML As String = "01" '通常在庫品
	Public Const gc_strHINID_SETUP As String = "02" 'セットアップ製品
	Public Const gc_strHINID_NEBIKI As String = "11" '出精値引
	Public Const gc_strHINID_TITLE As String = "12" '見積小計タイトル
	
	'分割不可区分
	Public Const gc_strBKTHKKB_KA As String = "1" '分割可
	Public Const gc_strBKTHKKB_FK As String = "9" '分割不可
	
	'通販出荷区分
	Public Const gc_strMORDKB_OK As String = "1" '通販含む
	Public Const gc_strMORDKB_NG As String = "9" '通販含まない
	
	'名称マニュアル入力区分
	Public Const gc_strNMMKB_OK As String = "1" 'する
	Public Const gc_strNMMKB_NG As String = "9" 'しない
	
	'伝票削除区分
	Public Const gc_strDATKB_USE As String = "1" '使用中
	Public Const gc_strDATKB_DEL As String = "9" '削除
	
	'製番区分
	Public Const gc_strSBNNO_MIT As String = "H" '見積
	
	'検索表示区分
	Public Const gc_strDSPKB_OK As String = "1" 'する
	Public Const gc_strDSPKB_NG As String = "9" 'しない
	
	'単価変更権限
	Public Const gc_strTKCHGKB_OK As String = "1" '権限あり
	Public Const gc_strTKCHGKB_NG As String = "9" '権限あり
	
	'在庫管理区分
	Public Const gc_strZAIKB_OK As String = "1" '対象
	Public Const gc_strZAIKB_NG As String = "9" '対象外
	
	'EDI処理区分
	Public Const gc_strEDIKB_OK As String = "1" 'する
	Public Const gc_strEDIKB_NG As String = "9" 'しない
	
	'通貨区分
	Public Const gc_strTUKKB_JPY As String = "JPY" '円
	Public Const gc_strTUKKB_USD As String = "USD" 'アメリカ合衆国ドル
	Public Const gc_strTUKKB_EUR As String = "EUR" 'ユーロ
	Public Const gc_strTUKKB_CNY As String = "CNY" '人民元
	
	'便名コード
	Public Const gc_strBINCD_SGW As String = "01" '佐川
	Public Const gc_strBINCD_SIB As String = "02" '西武
	Public Const gc_strBINCD_SIN As String = "03" '西濃
	Public Const gc_strBINCD_YMT As String = "04" 'ヤマト
	
	'倉庫区分
	Public Const gc_strSOUKOKB_HIN As String = "01" '製品倉庫
	Public Const gc_strSOUKOKB_THN As String = "02" '通販倉庫
	Public Const gc_strSOUKOKB_TORIOKI As String = "03" '取引先取置倉庫
	Public Const gc_strSOUKOKB_KAIGAI As String = "04" '海外倉庫
	Public Const gc_strSOUKOKB_SERVICE As String = "05" 'サービスパーツ倉庫
	Public Const gc_strSOUKOKB_TANASA As String = "06" '棚差倉庫
	Public Const gc_strSOUKOKB_HAIKI As String = "07" '廃棄倉庫
	Public Const gc_strSOUKOKB_KENSA As String = "08" '検査倉庫
	Public Const gc_strSOUKOKB_FURYO As String = "09" '不良品倉庫
	Public Const gc_strSOUKOKB_KASIDASI As String = "10" '貸出倉庫
	
	'前受区分
	Public Const gc_strMAEUKKB_NML As String = "1" '通常
	Public Const gc_strMAEUKKB_MAE As String = "2" '前受
	
	'請求区分
	Public Const gc_strSEIKB_IKT As String = "1" '一括
	Public Const gc_strSEIKB_KBT As String = "2" '個別
	
	'締区分
	Public Const gc_strSMEKB_DAY As String = "1" '日
	Public Const gc_strSMEKB_WEK As String = "2" '曜日
	
	'売上基準
	Public Const gc_strURIKJN_SYK As String = "01" '出荷基準
	Public Const gc_strURIKJN_KNS As String = "02" '検収基準
	Public Const gc_strURIKJN_EKM As String = "03" '役務完了基準
	Public Const gc_strURIKJN_KOJ As String = "04" '工事完了基準
	
	'資産元区分
	Public Const gc_strSISNKB_JI As String = "0" '自社
	Public Const gc_strSISNKB_TA As String = "1" '他社
	
	'注文情報取込種別
	Public Const gc_strPRCKB_VAN As String = "V0000" '注文情報（VAN）
	Public Const gc_strPRCKB_WEB As String = "W0000" '注文情報（WEB）
	Public Const gc_strPRCKB_TUHAN As String = "I0000" '注文情報（インターネット通販）
	
	'受注取込種別
	Public Const gc_strJDNINKB_INP As String = "1" '入力
	Public Const gc_strJDNINKB_ML As String = "2" '通販
	Public Const gc_strJDNINKB_VAN As String = "3" 'VAN
	Public Const gc_strJDNINKB_WEB As String = "4" 'Web
	
	'マスタ区分
	Public Const gc_strMSTKB_TOK As String = "1" '得意先
	Public Const gc_strMSTKB_NHS As String = "2" '納入先
	Public Const gc_strMSTKB_TAN As String = "3" '担当者
	Public Const gc_strMSTKB_SIR As String = "4" '仕入先
	Public Const gc_strMSTKB_HIN As String = "5" '商品
	
	'発行区分
	Public Const gc_strHAKKB_ZUMI As String = "1" '発行済
	Public Const gc_strHAKKB_SAI As String = "5" '再発行
	Public Const gc_strHAKKB_MI As String = "9" '未発行
	
	'出庫区分
	Public Const gc_strOUTKB_NML As String = "1" '通常
	Public Const gc_strOUTKB_KKH As String = "2" '交換品出荷
	
	'受注伝票区分
	Public Const gc_strJDNKB_NML As String = "1" '通常
	Public Const gc_strJDNKB_SHD As String = "2" 'セットアップヘッダ
	Public Const gc_strJDNKB_SBD As String = "3" 'セットアップ明細
	
	'取引区分
	Public Const gc_strZKTKB_NML As String = "1" '通常
	
	'取引区分名称
	Public Const gc_strZKTNM_NML As String = "通常" '通常
	
	'伝票区分
	Public Const gc_strDENKB_URIAGE As String = "1" '売上
	Public Const gc_strDENKB_HENPIN As String = "2" '返品
	Public Const gc_strDENKB_NEBIKI As String = "3" '値引
	Public Const gc_strDENKB_UNCHIN As String = "4" '運賃
	Public Const gc_strDENKB_SONOTA As String = "5" 'その他
	
	'客先伝票指定区分
	Public Const gc_strTOKDNKB_NML As String = "0" '通常
	Public Const gc_strTOKDNKB_STI As String = "1" '指定
	
	'受注取込区分
	Public Const gc_strORDSMKB_MI As String = "0" '未取込
	Public Const gc_strORDSMKB_OK As String = "1" '取込済み
	
	'単位区分
	Public Const gc_strUNTNM_KO As String = "個" '個
	
	'消費税ランク
	Public Const gc_strZEIRNKKB_NML As String = "1" '標準消費税ランク
	
	'商品区分
	Public Const gc_strHINKB_SYOHIN As String = "1" '商品
	Public Const gc_strHINKB_SEIHIN As String = "2" '製品
	Public Const gc_strHINKB_SHIKYU As String = "4" '支給品(受注トラン更新時のみ)
	Public Const gc_strHINKB_BUHIN As String = "9" '部品
	
	'海外取引区分
	Public Const gc_strFRNKB_DMS As String = "0" '国内
	Public Const gc_strFRNKB_FRN As String = "1" '海外
	
	'仕向地
	Public Const pc_strSIMUKE_SANFRANSISCO As String = "00001" 'サンフランシスコ
	Public Const pc_strSIMUKE_SINGAPORE As String = "00002" 'シンガポール
	Public Const pc_strSIMUKE_SHANGHAI As String = "00003" '上海
	
	'受注引当区分
	Public Const gc_strJODHIKKB_OK As String = "1" '引当対象
	Public Const gc_strJODHIKKB_NG As String = "9" '引当対象外
	
	'出荷停止区分
	Public Const gc_strORTSTPKB_NML As String = "1" '通常
	Public Const gc_strORTSTPKB_PRE As String = "8" '出荷準備中
	Public Const gc_strORTSTPKB_STOP As String = "9" '出荷停止
	
	'カタログ品対象区分
	Public Const gc_strCTLGKB_OK As String = "1" '対象
	Public Const gc_strCTLGKB_NG As String = "9" '対象外
	
	'通販対象区分
	Public Const gc_strMLOKB_OK As String = "1" '対象
	Public Const gc_strMLOKB_NG As String = "9" '対象外
	
	'生産終了区分
	Public Const gc_strPRDENDKB_NML As String = "1" '通常
	Public Const gc_strPRDENDKB_END As String = "9" '終了
	
	'販売完了区分
	Public Const gc_strSLENDKB_NML As String = "1" '通常
	Public Const gc_strSLENDKB_END As String = "9" '終了
	
	'受注停止区分
	Public Const gc_strJODSTPKB_NML As String = "1" '通常
	Public Const gc_strJODSTPKB_STOP As String = "9" '受注停止
	
	'保守終了区分
	Public Const gc_strMNTENDKB_NML As String = "1" '通常
	Public Const gc_strMNTENDKB_END As String = "9" '保守終了
	
	'出荷区分
	Public Const gc_strORTKB_NOW As String = "0" '現行
	Public Const gc_strORTKB_OLD As String = "1" '旧
	Public Const gc_strORTKB_NEW As String = "2" '新
	
	'シリアル管理区分
	Public Const gc_strSERIKB_OK As String = "1" 'する
	Public Const gc_strSERIKB_NG As String = "9" 'しない
	
	'ＯＥＭ
	Public Const gc_strOEMKB_OK As String = "1" '対象
	Public Const gc_strOEMKB_NG As String = "9" '対象外
	
	
	'固定値マスタ
	Public Const gc_strCTLCD_ODNYTLT As String = "501" '運送リードタイム
	Public Const gc_strCTLCD_JDOSURT As String = "502" '大口受注の比率
	Public Const gc_strCTLCD_ODNYTLT_ORD As String = "504" '運送リードタイム（注文情報取込用）
	Public Const gc_strCTLCD_TELFAX_KETA As String = "506" '電話番号/FAX番号桁数
	Public Const gc_strCTLCD_TELFAX_HAIHUN As String = "507" '電話番号/FAX番号ハイフン数
	Public Const gc_strCTLCD_ODNYTDT As String = "206" '出荷予定日算出用判定時刻
	Public Const gc_strCTLCD_HINCD_H As String = "207" '発注金額用諸口コード
	Public Const gc_strCTLCD_HINCD_J As String = "208" '発注金額外用諸口コード
	Public Const gc_strCTLCD_HINCD_K As String = "209" '購買品用諸口コード
	
	'ガイドメッセージ
	Public Const IMG_ENDCM_MSG_INF As String = "メニューに戻ります。" '終了
	Public Const IMG_EXECUTE_MSG_INF As String = "登録します。" '登録
	Public Const IMG_HARDCOPY_MSG_INF As String = "画面を印刷します。" '印刷
	Public Const IMG_INSERTDE_MSG_INF As String = "明細行を挿入します。" '挿入
	Public Const IMG_DELETEDE_MSG_INF As String = "明細を一行削除します。" '削除
	Public Const IMG_SLIST_MSG_INF As String = "ウィンドウを表示します。" '検索
	Public Const IMG_PREV_MSG_INF As String = "前のページを表示します。" '前ページ
	Public Const IMG_NEXTCM_MSG_INF As String = "次のページを表示します。" '次ページ
	Public Const IMG_SELECTCM_MSG_INF As String = "画面をクリアしてコードの入力を待ちます。" '検索
	Public Const IMG_EXECUTE2_MSG_INF As String = "実行します。" '実行
	Public Const IMG_LSTART_MSG_INF As String = "印刷を開始します。" '印刷（帳票）
	Public Const IMG_VSTART_MSG_INF As String = "印刷イメージを表示します。" '画面表示
	Public Const IMG_LCONFIG_MSG_INF As String = "プリンターを選択します。" '印刷設定
	
	'メッセージ登録値
	'ボタン種別
	Public Const gc_strBTNKB_OKOnly As Decimal = 0 'OK
	Public Const gc_strBTNKB_OKCancel As Decimal = 1 'OK/キャンセル
	Public Const gc_strBTNKB_AbortRetryIgnore As Decimal = 2 '中止/再試行/無視
	Public Const gc_strBTNKB_YesNoCancel As Decimal = 3 'はい/いいえ/キャンセル
	Public Const gc_strBTNKB_YesNo As Decimal = 4 'はい/いいえ
	Public Const gc_strBTNKB_RetryCancel As Decimal = 5 '再試行/キャンセル
	
	'************************************************************************************
	'   Public変数
	'************************************************************************************
	
	Public gv_strDLGLST01_RTN As String '登録確認画面返り値(1:登録＆発行 2:登録 3:戻る)
	
	Public gv_strDLGMSG01_BNGNM As String '番号名
	Public gv_strDLGMSG01_NO As String '表示番号
End Module