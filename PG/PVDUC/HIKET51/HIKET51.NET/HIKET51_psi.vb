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
		'    SELECTED        As Boolean          '選択/非選択
		'    SELECTB         As Variant
		Dim IsDataRow As Boolean 'データ保持行フラグ
		Dim LINNO As String '行番号
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim UODSU As Decimal '受注数量
		Dim UNTNM As String '単位名
		Dim UODTK As Decimal '受注単価
		Dim UODKN As Decimal '受注金額
		Dim SIKTK As Decimal '営業仕切単価
		Dim TEIKATK As Decimal '定価
		Dim SIKRT As Decimal '仕切率
		Dim LINCMA As String '明細備考１
		Dim LINCMB As String '明細備考２
		Dim ODNYTDT As String '出荷予定日
		Dim GNKCD As String '原価管理コード
		Dim TOKJDNNO As String '客先注文No.
		Dim PUDLNO As String '入出庫番号
		'20080725 ADD START RISE)Tanimura '排他処理
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（バッチ時間）
		Dim WRTDT As String ' タイムスタンプ（バッチ日）
		Dim UOPEID As String ' 最終作業者コード
		Dim UCLTID As String ' クライアントＩＤ
		Dim UWRTTM As String ' タイムスタンプ（バッチ時間）
		Dim UWRTDT As String ' タイムスタンプ（バッチ日）
		'20080725 ADD END   RISE)Tanimura
		'''在庫引当／個別解除画面用
		Dim SUB_IsDataRow As Boolean 'データ保持行フラグ
		Dim SUB_KB As String 'データ区分(1:倉庫別在庫 2:入荷予定)
		Dim SUB_SOUCD As String '倉庫コード
		Dim SUB_HINCD As String '製品コード
		Dim SUB_SISNKB As String '資産元区分
		Dim SUB_SOUTRICD As String '取引先コード
		Dim SUB_SOUKOKB As String '倉庫区分
		Dim SUB_SOUNM As String '倉庫名
		Dim SUB_LOTNO As String 'ロット番号
		Dim SUB_NYUYTDT As String '入庫予定日
		Dim SUB_RELZAISU As Decimal '現在庫数
		Dim SUB_ZUMISU As Decimal '引当済数
		Dim SUB_HIKSU As Decimal '引当可能数
		Dim SUB_INP_HIKSU As Decimal '引当数
		Dim SUB_MOTO_HIKSU As Decimal '引当数(更新前の値)
		' === 20060109 === INSERT S - ACE)Nagasawa
		Dim SUB_HIKSU_BEF As Decimal '前回入力引当済数
		' === 20060109 === INSERT E -
		' === 20070205 === INSERT S - ACE)Yano
		Dim SUB_MNSU As Decimal '手動引当数
		' === 20070205 === INSERT E -
		' === 20080715 === INSERT S - ACE)Nagasawa 自動引当実行中は仮引当を行った見積の改版は行えない
		Dim SUB_FRDSU As Decimal '出荷指示数
		' === 20080715 === INSERT E -
		'20080725 ADD START RISE)Tanimura '排他処理
		Dim SUB_OPEID As String ' 最終作業者コード
		Dim SUB_CLTID As String ' クライアントＩＤ
		Dim SUB_WRTTM As String ' タイムスタンプ（バッチ時間）
		Dim SUB_WRTDT As String ' タイムスタンプ（バッチ日）
		Dim SUB_UOPEID As String ' 最終作業者コード
		Dim SUB_UCLTID As String ' クライアントＩＤ
		Dim SUB_UWRTTM As String ' タイムスタンプ（バッチ時間）
		Dim SUB_UWRTDT As String ' タイムスタンプ（バッチ日）
		'20080725 ADD END   RISE)Tanimura
	End Structure
	''================================================================================
	'在庫引当検索,在庫引当／解除
	Public Const gc_strMsgHIKET51_A_001 As String = "1HIKET51_001" '終了してよろしいですか？
	Public Const gc_strMsgHIKET51_E_002 As String = "2HIKET51_002" '検索条件を入力してください。
	Public Const gc_strMsgHIKET51_E_003 As String = "2HIKET51_003" '該当するデータが存在しません。
	Public Const gc_strMsgHIKET51_E_004 As String = "2HIKET51_004" '見積検索時は、見積番号・版数ともに必須です。
	Public Const gc_strMsgHIKET51_E_005 As String = "2HIKET51_005" '見積番号、受注番号いずれか一方のみ入力して下さい。
	Public Const gc_strMsgHIKET51_E_006 As String = "2HIKET51_006" '引当数はマイナス入力できません。
	Public Const gc_strMsgHIKET51_E_007 As String = "2HIKET51_007" '引当数が引当可能数を超えています。
	Public Const gc_strMsgHIKET51_E_008 As String = "2HIKET51_008" '引当数合計が伝票数量を超えています。
	Public Const gc_strMsgHIKET51_E_009 As String = "2HIKET51_009" '対象の明細が存在しません。
	Public Const gc_strMsgHIKET51_E_010 As String = "2HIKET51_010" '入力値が許容範囲外です。
	Public Const gc_strMsgHIKET51_E_011 As String = "2HIKET51_011" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgHIKET51_E_012 As String = "2HIKET51_012" '更新異常
	Public Const gc_strMsgHIKET51_A_013 As String = "1HIKET51_013" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgHIKET51_A_014 As String = "1HIKET51_014" '更新してよろしいですか？
	' === 20060818 === INSERT S - ACE)Nagasawa
	Public Const gc_strMsgHIKET51_E_015 As String = "2HIKET51_015" '引当数が伝票数量を超えています。
	' === 20060818 === INSERT E -
	' === 20060908 === INSERT S - ACE)Sejima 既に受注となっている見積
	Public Const gc_strMsgHIKET51_E_016 As String = "2HIKET51_016" '既に受注となっている見積です。
	' === 20060908 === INSERT E
	' === 20060926 === INSERT S - ACE)Nagasawa 処理終了メッセージ追加
	Public Const gc_strMsgHIKET51_A_017 As String = "1HIKET51_017" '処理が終了しました。
	' === 20060926 === INSERT E -
	' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
	Public Const gc_strMsgHIKET51_E_018 As String = "2HIKET51_018" 'が実行中です。しばらくして実行してください。
	' === 20061105 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa 更新権限チェックを変更する
	Public Const gc_strMsgHIKET51_E_019 As String = "2HIKET51_019" '更新権限がありません。
	' === 20061129 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa 更新権限チェックを変更する
	Public Const gc_strMsgHIKET51_E_020 As String = "2HIKET51_020" '引当の対象となる明細が存在しません。
	' === 20061129 === INSERT E -
	'2014/02/26 START ADD FWEST)Koroyasu 消費税法改正対応
	Public Const gc_strMsgHIKET51_E_021 As String = "2HIKET51_021" '現在の適用税率の受注でないため、引当できません。
	'2014/02/26 END ADD FWEST)Koroyasu 消費税法改正対応
	'2014/03/04 START ADD FWEST)Koroyasu HAN20131203-01
	Public Const gc_strMsgHIKET51_E_022 As String = "2HIKET51_022" '標準倉庫の場所がSSCであるため、引当できません。
	'2014/03/04 END ADD FWEST)Koroyasu HAN20131203-01
	'20080725 ADD START RISE)Tanimura '排他処理
	Public Const gc_strMsgHIKET51_E_901 As String = "2HIKET51_901" '他のプログラムで更新されたため、更新できません。
	'20080725 ADD END   RISE)Tanimura
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
	Public Structure Cls_HIKET51_Interface
		Dim Mode As Short '伝票種別（1:見積情報/2:受注情報）
		Dim DATNO As String '伝票管理№
		Dim DENNO1 As String '伝票番号１
		Dim DENNO2 As String '伝票番号２
		Dim TANNM As String '担当者名
		Dim LINNO As String '行番号
		Dim PUDLNO As String '入出庫番号
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim UODSU As Decimal '受注数量
		Dim TOKCD As String '得意先コード
		Dim JDNTRKB As String '受注取引区分
		Dim SOUCD As String '倉庫コード
		Dim ODNYTDT As String '出荷予定日
		' === 20071230 === INSERT S - ACE)Yano
		Dim JDNINKB As String '受注取込種別
		' === 20071230 === INSERT E -
		'20080725 ADD START RISE)Tanimura '排他処理
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim WRTTM As String ' タイムスタンプ（バッチ時間）
		Dim WRTDT As String ' タイムスタンプ（バッチ日）
		Dim UOPEID As String ' 最終作業者コード
		Dim UCLTID As String ' クライアントＩＤ
		Dim UWRTTM As String ' タイムスタンプ（バッチ時間）
		Dim UWRTDT As String ' タイムスタンプ（バッチ日）
		'20080725 ADD END   RISE)Tanimura
	End Structure
	Public HIKET51_Interface As Cls_HIKET51_Interface
End Module