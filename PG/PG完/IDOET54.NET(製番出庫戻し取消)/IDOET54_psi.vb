Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	''================================================================================
	'☆　画面ボディ部の行単位の業務情報　　　　　☆
	'☆　　Cls_Dsp_Body_Row_Infとの互換性を　　　☆
	'☆　　共通の全てのＰＧで宣言する　　　　　　☆
	'☆　　そのため以下の｢Dummy｣は必須！！ 　　　☆
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String 'ダミー
		Dim LINNO As String '行番号
		Dim SMADT As String '経理締日付
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim UODSU As String '受注数量
		Dim UNTCD As String '単位コード
		Dim UNTNM As String '単位名
		Dim UODTK As String '受注単価
		Dim UODTK_INIT As String '受注単価（初期表示用）
		Dim UODKN As String '受注金額
		Dim SIKTK As String '営業仕切単価
		Dim SIKKN As String '営業仕切金額
		Dim TEIKATK As String '定価
		Dim SIKRT As String '仕切率
		Dim KONSIKRT As String '今回仕切率
		Dim SIKRT_NOMAL As Decimal '標準仕切率
		Dim SIKSA As String '仕切差
		Dim ZAIKB As String '在庫管理区分
		Dim LINCMA As String '明細備考１
		Dim LINCMB As String '明細備考２
		Dim LSTID As String '伝票種別
		Dim HINZEIKB As String '商品消費税区分
		Dim ZEIRT As String '消費税率
		Dim UZEKN As Decimal '消費税額
		Dim ZEIRNKKB As String '消費税ランク
		Dim HINNMMKB As String '名称ﾏﾆｭｱﾙ区分（商品）
		Dim MAKCD As String 'メーカーコード
		Dim HINKB As String '商品区分
		Dim HRTDD As String '発注リードタイム
		Dim ORTDD As String '出荷リードタイム
		Dim ODNYTDT As String '出荷予定日
		Dim UDNYTDT As String '売上予定日
		Dim TNKKB As String '単価種別
		Dim TNKKBNM As String '単価種別名
		Dim GNKCD As String '原価管理コード
		Dim CLMDL As String '分類型式
		Dim HINGRP As String '商品群
		Dim MAKNM As String 'メーカー名
		Dim SBNNO As String '製番
		Dim ZAIRNK As String '在庫ランク
		Dim SODUNTSU As Decimal '発注単位数
		Dim MITTRA_ZAIHIKSU As String '見積トラン.在庫引当数
		Dim MITTRA_NYTHIKSU As String '見積トラン.入庫予定引当数
		Dim HINMTA_HINID As String '商品マスタ.商品種別
		Dim HINMTA_PRDENDKB As String '商品マスタ.生産終了
		Dim HINMTA_PRDENDDT As String '商品マスタ.生産終了日付
		Dim HINMTA_SLENDKB As String '商品マスタ.販売完了
		Dim HINMTA_SLENDDT As String '商品マスタ.販売完了日付
		Dim HINMTA_JODSTPKB As String '商品マスタ.受注停止
		Dim HINMTA_JODSTPDT As String '商品マスタ.受注停止日付
		Dim HINMTA_MDLCL As String '商品マスタ.機種分類
		Dim HINMTA_HINGRP As String '商品マスタ.商品群
		Dim HINMTA_JANCD As String '商品マスタ.JANコード
		Dim HINMTA_KHNKB As String '商品マスタ.仮本区分
		Dim TOKJDNNO As String '注文番号
		Dim TOKJDNED As String '注文明細行番号
		Dim ORD_HINCD As String '注文情報.製品コード
		Dim SIKRT_PER As String '仕切率パーセント
		Dim SIKSA_DSP As String '仕切差背景
		Dim JANCD As String 'JANコード
		'ADD START FKS)INABA 2007/02/15 *************************
		Dim TNACM As String
		'ADD  END  FKS)INABA 2007/02/15 *************************
	End Structure
	''================================================================================
	'メッセージコード
	'受注登録
	Public Const gc_strMsgIDOET52_E_001 As String = "2IDOET52_001" '入力値が許容範囲外です。
	Public Const gc_strMsgIDOET52_E_002 As String = "2IDOET52_002" '削除済みレコードです。
	Public Const gc_strMsgIDOET52_E_003 As String = "2IDOET52_003" 'このコードは使用できません。
	Public Const gc_strMsgIDOET52_E_004 As String = "2IDOET52_004" 'この商品は保守終了品です。
	Public Const gc_strMsgIDOET52_E_005 As String = "2IDOET52_005" 'この商品は販売完了品です。
	Public Const gc_strMsgIDOET52_E_006 As String = "2IDOET52_006" 'この商品は受注停止品です。
	Public Const gc_strMsgIDOET52_W_007 As String = "2IDOET52_007" 'この商品は生産終了品です。
	Public Const gc_strMsgIDOET52_W_008 As String = "2IDOET52_008" 'この商品は出荷停止品です。
	Public Const gc_strMsgIDOET52_E_009 As String = "2IDOET52_009" '該当するデータが存在しません。
	Public Const gc_strMsgIDOET52_E_011 As String = "2IDOET52_011" '見出部の入力がまだのため明細行の入力ができません。
	Public Const gc_strMsgIDOET52_E_013 As String = "2IDOET52_013" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgIDOET52_E_014 As String = "2IDOET52_014" '伝票の明細部を入力して下さい。
	Public Const gc_strMsgIDOET52_A_031 As String = "1IDOET52_031" '終了してよろしいですか？
	Public Const gc_strMsgIDOET52_A_032 As String = "1IDOET52_032" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgIDOET52_E_034 As String = "2IDOET52_034" '更新異常
	Public Const gc_strMsgIDOET52_E_036 As String = "2IDOET52_036" '他端末で更新中です。
	Public Const gc_strMsgIDOET52_A_037 As String = "1IDOET52_037" '更新してよろしいですか？
	Public Const gc_strMsgIDOET52_E_057 As String = "2IDOET52_057" '出庫理由（コード）を入力して下さい。
	Public Const gc_strMsgIDOET52_E_058 As String = "2IDOET52_058" '倉庫コードを入力して下さい。
	Public Const gc_strMsgIDOET52_E_059 As String = "2IDOET52_059" '製番を入力して下さい。
	Public Const gc_strMsgIDOET52_E_060 As String = "2IDOET52_060" '製番の頭文字が不正です。
	Public Const gc_strMsgIDOET52_E_061 As String = "2IDOET52_061" '製番の文字列長が不正です。
	Public Const gc_strMsgIDOET52_E_062 As String = "2IDOET52_062" '製番が製番マスタに登録されていません。
	Public Const gc_strMsgIDOET52_E_063 As String = "2IDOET52_063" '有効在庫数より大きな値は入力できません。
	Public Const gc_strMsgIDOET52_E_064 As String = "2IDOET52_064" '在庫管理品のみ入力できます。
	Public Const gc_strMsgIDOET52_E_065 As String = "2IDOET52_065" '緊急出庫時は代替出荷を選択できません。
	Public Const gc_strMsgIDOET52_E_066 As String = "2IDOET52_066" '引当を解除してください
	Public Const gc_strMsgIDOET52_E_067 As String = "2IDOET52_067" '出荷指示を取り消してください
	Public Const gc_strMsgIDOET52_E_068 As String = "2IDOET52_068" '出庫訂正対象を選択してください
	Public Const gc_strMsgIDOET52_E_070 As String = "2IDOET52_070" '製番が費用製番マスタに登録されていません。
	Public Const gc_strMsgIDOET52_E_071 As String = "2IDOET52_071" '入力された費用製番は入力適用範囲外です
	Public Const gc_strMsgIDOET52_E_072 As String = "2IDOET52_072" '理由が出庫戻し用の場合はマイナスで入力してください。
	Public Const gc_strMsgIDOET52_E_073 As String = "2IDOET52_073" '社内出庫と社外出庫の情報は同時に入力できません。
	Public Const gc_strMsgIDOET52_E_074 As String = "2IDOET52_074" '社外出庫の場合、得意先コードは必須です。
	Public Const gc_strMsgIDOET52_E_075 As String = "2IDOET52_075" '社外出庫の場合、納入先住所は必須です。
	Public Const gc_strMsgIDOET52_E_076 As String = "2IDOET52_076" '社外出庫の場合、便名は必須です。
	Public Const gc_strMsgIDOET52_E_077 As String = "2IDOET52_077" '社内出庫の場合、送付先担当者は必須です。
	Public Const gc_strMsgIDOET52_E_078 As String = "2IDOET52_078" '社内出庫の場合、送付先部門は必須です。
	Public Const gc_strMsgIDOET52_E_079 As String = "2IDOET52_079" '理由が出庫用の場合はマイナス値を入力できません。
	Public Const gc_strMsgIDOET52_E_080 As String = "2IDOET52_080" '戻し数量は支給出庫済数量より多くは入力できません。
	Public Const gc_strMsgIDOET52_E_081 As String = "2IDOET52_081" '商品マスタに存在しません。
	
	Public Const gc_strMsgIDOET52_A_082 As String = "1IDOET52_082" '処理が終了しました。
	Public Const gc_strMsgIDOET52_E_083 As String = "2IDOET52_083" '桁数オーバーです。
	Public Const gc_strMsgIDOET52_E_084 As String = "2IDOET52_084" 'ハイフン個数の誤りです。
	Public Const gc_strMsgIDOET52_E_085 As String = "2IDOET52_085" 'ハイフンが先頭にあります。
	Public Const gc_strMsgIDOET52_E_086 As String = "2IDOET52_086" 'ハイフンが末尾にあります。
	Public Const gc_strMsgIDOET52_E_087 As String = "2IDOET52_087" 'ハイフンを連続して入力しています。
	Public Const gc_strMsgIDOET52_E_088 As String = "2IDOET52_088" '入力が不正です。
	Public Const gc_strMsgIDOET52_E_089 As String = "2IDOET52_089" 'ハイフンの位置が正しくありません。
	Public Const gc_strMsgIDOET52_E_090 As String = "2IDOET52_090" '桁数が正しくありません。
	Public Const gc_strMsgIDOET52_E_091 As String = "2IDOET52_091" '郵便番号を入力してください。
	Public Const gc_strMsgIDOET52_E_092 As String = "2IDOET52_092" '電話番号を入力してください。
	
	Public Const gc_strMsgIDOET52_W_093 As String = "2IDOET52_093" '出荷準備中です。
	Public Const gc_strMsgIDOET52_W_094 As String = "2IDOET52_094" 'ＯＥＭ品です。
	'ADD START FKS)INABA 2007/01/08*******************************************************************
	Public Const gc_strMsgIDOET52_W_095 As String = "2IDOET52_095" '出庫数が現在庫数を超えています。
	Public Const gc_strMsgIDOET52_W_096 As String = "2IDOET52_096" '出庫数が有効在庫数を超えています。
	Public Const gc_strMsgIDOET52_W_097 As String = "2IDOET52_097" '安全在庫数を下回ります。
	'ADD START FKS)INABA 2007/01/08*******************************************************************
	Public Const gc_strMsgUODET51_E_066 As String = "2UODET51_066" '更新権限がありません。
	Public Const gc_strMsgUODET52_E_080 As String = "2UODET52_080" '以下の処理が実行中のためこの画面は使用できません。
	Public Const gc_strMsgUODET52_E_042 As String = "2UODET52_042" 'システムエラー
	
	Public Const gc_strMsgIDOET52_E_098 As String = "2IDOET52_098" '出庫済み数以下は指定できません。
	'ADD START FKS)INABA 2007/02/15 ******************************************************************************
	Public Const gc_strMsgIDOET52_A_099 As String = "1IDOET52_099" '入力した倉庫と標準倉庫が違いますが、よろしいですか？
	Public Const gc_strMsgIDOET52_A_100 As String = "1IDOET52_100" '標準倉庫を設定しますか？
	Public Const gc_strMsgIDOET52_W_101 As String = "2IDOET52_101" '入力した倉庫と標準倉庫が違います。確認してください。
	'ADD  END  FKS)INABA 2007/02/15 ******************************************************************************
	'ADD START FKS)INABA 2007/03/06 ******************************************************************************
	Public Const gc_strMsgIDOET52_A_102 As String = "1IDOET52_102" '取消された製番を指定していますが、よろしいですか？
	'ADD  END  FKS)INABA 2007/03/06 ******************************************************************************
	'ADD STRAT FKS)INABA 2007/03/26 ******************************************************************************
	Public Const gc_strMsgIDOET52_E_103 As String = "2IDOET52_103" 'この倉庫は利用できません。
	'ADD  END  FKS)INABA 2007/03/26 ******************************************************************************
	Public Const gc_strMsgIDOET52_E_010 As String = "2IDOET52_010" '製品コードを入力してください。
	Public Const gc_strMsgIDOET52_E_012 As String = "2IDOET52_012" '数量を入力してください。
	Public Const gc_strMsgIDOET52_E_015 As String = "2IDOET52_015" '緊急出荷以外はシリアルの入力は出来ません。
	
	Public Const gc_strMsgIDOET52_A_016 As String = "1IDOET52_016" 'シリアルが登録されていない明細が有ります。
	'ADD START FKS)INABA 2007/12/14 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_016 As String = "2IDOET52_016" '出庫数が現在庫数を超えています。
	Public Const gc_strMsgIDOET52_E_017 As String = "2IDOET52_017" '出庫数が有効在庫数を超えています。
	'ADD  END  FKS)INABA 2007/12/14 ***************************************************************************************
	'ADD START FKS)INABA 2008/01/23 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_018 As String = "2IDOET52_018" '棚番の登録に過不足が有ります。再登録して下さい。
	'ADD  END  FKS)INABA 2008/01/23 ***************************************************************************************
	
	'' 以下使用未確認
	'DEL START FKS)INABA 2007/12/14 ***************************************************************************************
	'    Public Const gc_strMsgIDOET52_E_016         As String = "2IDOET52_016"  '入力された日付は物流稼動日ではありません。
	'    Public Const gc_strMsgIDOET52_E_017         As String = "2IDOET52_017"  '現在の編集内容は破棄されます。よろしいですか？
	'DEL  END  FKS)INABA 2007/12/14 ***************************************************************************************
	Public Const gc_strMsgIDOET52_E_019 As String = "2IDOET52_019" '得意先より締日が算出できません。
	Public Const gc_strMsgIDOET52_E_020 As String = "2IDOET52_020" '案件が存在する場合は受注理由を入力して下さい。
	Public Const gc_strMsgIDOET52_E_021 As String = "2IDOET52_021" '保守の場合は前受区分を入力してください。
	Public Const gc_strMsgIDOET52_E_022 As String = "2IDOET52_022" '保守の場合は請求区分を入力してください。
	Public Const gc_strMsgIDOET52_E_023 As String = "2IDOET52_023" '既に入力されている製品コードです。
	Public Const gc_strMsgIDOET52_E_024 As String = "2IDOET52_024" '在庫が足りません。
	Public Const gc_strMsgIDOET52_E_025 As String = "2IDOET52_025" '単価取得ができませんでした。
	Public Const gc_strMsgIDOET52_W_026 As String = "2IDOET52_026" '原価割れします
	Public Const gc_strMsgIDOET52_E_027 As String = "2IDOET52_027" '本体合計金額が受注可能額を超えています。
	Public Const gc_strMsgIDOET52_E_028 As String = "2IDOET52_028" '本体合計金額が明細金額と一致しません。
	Public Const gc_strMsgIDOET52_E_029 As String = "2IDOET52_029" '入力された日付はカレンダに登録されていません。
	Public Const gc_strMsgIDOET52_E_030 As String = "2IDOET52_030" 'CLOSEされた案件情報です。
	Public Const gc_strMsgIDOET52_E_033 As String = "2IDOET52_033" 'IniファイルのCRM連携用のパスが設定されていません。
	Public Const gc_strMsgIDOET52_E_035 As String = "2IDOET52_035" '仕切率を標準より下げる場合は特価の設定が必要です。
	Public Const gc_strMsgIDOET52_E_038 As String = "2IDOET52_038" '本体合計金額が受注可能額を超えています。
	Public Const gc_strMsgIDOET52_E_039 As String = "2IDOET52_039" '日付に誤りがあります。修正してください。
	Public Const gc_strMsgIDOET52_E_040 As String = "2IDOET52_040" '参照した版数以外に仮引当が行われています。
	Public Const gc_strMsgIDOET52_E_041 As String = "2IDOET52_041" '入力された案件IDは既に受注入力が行われています。
	Public Const gc_strMsgIDOET52_E_042 As String = "2IDOET52_042" '参照された版数以外の見積に仮引当が行われています。
	Public Const gc_strMsgIDOET52_E_043 As String = "2IDOET52_043" '出荷予定日を入力して下さい。
	Public Const gc_strMsgIDOET52_W_044 As String = "2IDOET52_044" '数量が大口受注数を超えています。
	Public Const gc_strMsgIDOET52_E_045 As String = "2IDOET52_045" 'この得意先は海外取引先です。
	Public Const gc_strMsgIDOET52_E_046 As String = "2IDOET52_046" '納入先コードを入力して下さい。
	Public Const gc_strMsgIDOET52_W_047 As String = "2IDOET52_047" '諸口の得意先です。
	Public Const gc_strMsgIDOET52_E_048 As String = "2IDOET52_048" '諸口の得意先は受注できません。
	Public Const gc_strMsgIDOET52_W_049 As String = "2IDOET52_049" '仮登録された商品が明細に存在します。
	Public Const gc_strMsgIDOET52_E_050 As String = "2IDOET52_050" '仮登録された商品の受注登録は行えません。
	Public Const gc_strMsgIDOET52_E_051 As String = "2IDOET52_051" '入力された日付は営業日ではありません。
	Public Const gc_strMsgIDOET52_E_052 As String = "2IDOET52_052" '月次仮締日を過ぎています。
	Public Const gc_strMsgIDOET52_E_053 As String = "2IDOET52_053" '登録された得意先の請求締日を過ぎています。
	Public Const gc_strMsgIDOET52_E_054 As String = "2IDOET52_054" 'システム､セットアップの見積は参照できません｡
	Public Const gc_strMsgIDOET52_E_055 As String = "2IDOET52_055" 'CRM連携ﾌｧｲﾙは他ﾕｰｻﾞｰで使用中のため書き込めません。
	Public Const gc_strMsgIDOET52_E_056 As String = "2IDOET52_056" '他の受注で既に参照された見積情報です。
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module