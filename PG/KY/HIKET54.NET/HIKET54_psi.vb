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
		Dim IsDataRow As Boolean 'データ保持行フラグ
		Dim SYBT As Short '種別(3:支給品,4:製番出庫)
		Dim SBNNO As String '製番
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim ODNYTDT As String '出荷予定日
		Dim OUTYTSU As Decimal '出荷予定数量
		Dim ORGSBNNO As String '元製番
		Dim OUTRSNCD As String '出庫理由コード
		Dim OUTRSNNM As String '出庫理由名
		Dim TOKCD As String '得意先コード
		Dim TOKRN As String '得意先略称
		Dim SIRCD As String '仕入先コード
		Dim SIRRN As String '仕入先略称
		Dim WRTFSTDT As String '登録日
		Dim WRTFSTTM As String '登録時間
		Dim SOUCD As String '倉庫コード
		Dim SOUNM As String '倉庫名
		Dim DATNO As String '伝票管理№
		Dim SPRRENNO As String '分割連番
		Dim PUDLNO As String '入出庫番号
		' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		Dim OUTBMCD As String '送り先部門コード
		Dim OUTTANCD As String '送り先担当者コード
		Dim NHSCD As String '納入先コード
		' === 20080725 === INSERT E -
		'''製番引当／個別解除画面用
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
		Dim SUB_HIKSU_BEF As Decimal '前回入力引当済数
		Dim SUB_MNSU As Decimal '手動引当数
		' === 20080720 === INSERT S - ACE)Nagasawa 自動引当実行中は仮引当を行った見積の改版は行えない
		Dim SUB_FRDSU As Decimal '出荷指示数
		' === 20080720 === INSERT E -
		' === 20080725 === INSERT S - RISE)Izumi
		Dim SUB_OPEID As String ' 最終作業者コード
		Dim SUB_CLTID As String ' クライアントＩＤ
		Dim SUB_WRTTM As String ' タイムスタンプ（時間）
		Dim SUB_WRTDT As String ' タイムスタンプ（日付）
		Dim SUB_UOPEID As String ' 最終作業者コード
		Dim SUB_UCLTID As String ' クライアントＩＤ
		Dim SUB_UWRTTM As String ' タイムスタンプ（バッチ時間）
		Dim SUB_UWRTDT As String ' タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
	End Structure
	''================================================================================
	'製番引当検索,在庫引当／解除
	Public Const gc_strMsgHIKET54_A_001 As String = "1HIKET54_001" '終了してよろしいですか？
	Public Const gc_strMsgHIKET54_E_002 As String = "2HIKET54_002" '検索条件を入力してください。
	Public Const gc_strMsgHIKET54_E_003 As String = "2HIKET54_003" '該当するデータが存在しません。
	Public Const gc_strMsgHIKET54_E_004 As String = "2HIKET54_004" '削除済みレコードです。
	Public Const gc_strMsgHIKET54_E_005 As String = "2HIKET54_005" '在庫管理対象外です。
	Public Const gc_strMsgHIKET54_E_006 As String = "2HIKET54_006" '引当数はマイナス入力できません。
	Public Const gc_strMsgHIKET54_E_007 As String = "2HIKET54_007" '引当数が引当可能数を超えています。
	Public Const gc_strMsgHIKET54_E_008 As String = "2HIKET54_008" '引当数合計が伝票数量を超えています。
	Public Const gc_strMsgHIKET54_E_009 As String = "2HIKET54_009" '対象の明細が存在しません。
	Public Const gc_strMsgHIKET54_E_010 As String = "2HIKET54_010" '入力値が許容範囲外です。
	Public Const gc_strMsgHIKET54_E_011 As String = "2HIKET54_011" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgHIKET54_E_012 As String = "2HIKET54_012" '更新異常
	Public Const gc_strMsgHIKET54_A_013 As String = "1HIKET54_013" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgHIKET54_A_014 As String = "1HIKET54_014" '更新してよろしいですか？
	Public Const gc_strMsgHIKET54_E_015 As String = "2HIKET54_015" '引当数が伝票数量を超えています。
	Public Const gc_strMsgHIKET54_A_017 As String = "1HIKET54_017" '処理が終了しました。
	Public Const gc_strMsgHIKET54_E_018 As String = "2HIKET54_018" 'が実行中です。しばらくして実行してください。
	Public Const gc_strMsgHIKET54_E_019 As String = "2HIKET54_019" '更新権限がありません。
	Public Const gc_strMsgHIKET54_E_020 As String = "2HIKET54_020" '引当の対象となる明細が存在しません。
	' === 20080729 === INSERT S - RISE)Izumi
	Public Const gc_strMsgHIKET54_E_901 As String = "2HIKET54_901" '他のプログラムで更新されたため、更新できません。
	Public Const gc_strMsgHIKET54_E_902 As String = "2HIKET54_902" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgHIKET54_E_903 As String = "2HIKET54_903" '他のプログラムで更新されたため、削除できません。
	' === 20080729 === INSERT E -
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
	Public Structure Cls_HIKET54_Interface
		Dim Mode As Short '伝票種別（3:支給品情報/4:製番出庫情報）
		Dim DATNO As String '伝票管理№
		Dim ODNYTDT As String '出荷予定日
		Dim SPRRENNO As String '分割連番
		Dim SBNNO As String '製番
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		Dim HINNMB As String '商品名１
		Dim UODSU As Decimal '受注数量
		Dim TOKCD As String '得意先コード
		Dim SOUCD As String '倉庫コード
		Dim PUDLNO As String '入出庫番号
		' === 20080725 === INSERT S - ACE)Nagasawa 引当内訳ファイルの引当数には出荷指示数も含むよう修正
		Dim OUTBMCD As String '送り先部門コード
		Dim OUTTANCD As String '送り先担当者コード
		Dim NHSCD As String '納入先コード
		' === 20080725 === INSERT E -
		' === 20080725 === INSERT S - RISE)Izumi
		Dim OPEID As String '最終作業者コード
		Dim CLTID As String 'クライアントＩＤ
		Dim WRTTM As String 'タイムスタンプ（時間）
		Dim WRTDT As String 'タイムスタンプ（日付）
		Dim UOPEID As String '最終作業者コード
		Dim UCLTID As String 'クライアントＩＤ
		Dim UWRTTM As String 'タイムスタンプ（バッチ時間）
		Dim UWRTDT As String 'タイムスタンプ（バッチ日）
		' === 20080725 === INSERT E -
	End Structure
	Public HIKET54_Interface As Cls_HIKET54_Interface
End Module