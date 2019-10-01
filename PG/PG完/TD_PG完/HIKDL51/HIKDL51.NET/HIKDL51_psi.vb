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
		'推定在庫照会用
		Dim IsDataRow As Boolean 'データ保持行フラグ
		Dim DATKB As String 'データ区分
		Dim LINNO As Integer '行番号
		Dim JDNNO As String '受注番号
		Dim MITNO As String '参照見積番号
		Dim MITNOV As String '版数
		'***add-S-tom
		Dim LIN As String '行番号
		'***add-E-tom
		Dim STKDLVDT As String '入出庫日
		Dim DLVSU As Decimal '出庫数
		Dim HIKSU As Decimal '引当数
		Dim JOTAI As String '状態
		Dim STKSU As Decimal '入庫数
		Dim SZAISU As Decimal '推定在庫数
		' === 20070209 === INSERT S - ACE)Yano
		Dim DENDT As String '受注日
		' === 20070209 === INSERT E -
		Dim SBNNO As String '製番
		Dim TOKRN As String '得意先名称
		Dim SOUNM As String '倉庫名
		Dim TOKJDNNO As String '客先注文番号
		Dim COLORFLG1 As String 'カラーフラグ１
		Dim COLORFLG2 As String 'カラーフラグ２
		Dim COLORFLG3 As String 'カラーフラグ３
		Dim COLORFLG4 As String 'カラーフラグ４
		Dim COLORFLG5 As String 'カラーフラグ５
		' === 20060803 === INSERT S - ACE)Nagasawa 運用日の最後のデータに対して着色を行う
		Dim COLORFLG6 As String 'カラーフラグ６
		' === 20060803 === INSERT E -
		' === 20110131 === INSERT S - TOM)Morimoto 管理番号追加
		Dim DATNO As String '管理番号
		' === 20110131 === INSERT E -
		'推定在庫照会（明細）用
		Dim SUB_IsDataRow As Boolean 'データ保持行フラグ
		Dim SUB_LINNO As String '行番号
		Dim SUB_HINCD As String '製品コード
		Dim SUB_HINNMA As String '型式
		' === 20110124 === INSERT S - TOM)Morimoto 発注用伝票管理番号を保持
		'    SUB_HINNMB          As String           '商品名１
		Dim SUB_TOKJDNNO As String '客先注文番号
		' === 20110124 === INSERT E -
		Dim SUB_UODSU As Decimal '受注数量
		Dim SUB_UNTNM As String '単位名
		Dim SUB_UODTK As Decimal '受注単価
		Dim SUB_UODKN As Decimal '受注金額
		Dim SUB_SBT As String '種別
		Dim SUB_SIKTK As Decimal '営業仕切単価
		Dim SUB_TEIKATK As Decimal '定価
		Dim SUB_SIKRT As String '仕切率(出力しない場合用にString)
		Dim SUB_SIKSA As String '仕切差(出力しない場合用にString)
		Dim SUB_ODNYTDT As String '出荷予定日
		Dim SUB_OTPSU As String '出荷実績数(出力しない場合用にString)
		Dim SUB_OTYSU As String '出荷予定数(出力しない場合用にString)
		' === 20061114 === INSERT S - ACE)Yano  製番出庫 推定在庫照会（明細）用
		Dim SUB2_IsDataRow As Boolean 'データ保持行フラグ
		Dim SUB2_HINCD As String '製品コード
		Dim SUB2_HINNMA As String '型式
		Dim SUB2_HINNMB As String '商品名１
		Dim SUB2_UODSU As Decimal '数量
		Dim SUB2_OUTSMSU As Decimal '出荷実績数量
		Dim SUB2_UNTNM As String '単位名
		Dim SUB2_LINCMA As String '明細備考１
		Dim SUB2_LINCMB As String '明細備考２
		' === 20061114 === INSERT E -
		'***add-S-tom*** 引当状況照会追加
		Dim SUB3_IsDataRow As Boolean 'データ保持行フラグ
		Dim SUB3_TRAKB As String '種別
		Dim SUB3_TRANO As String '製番
		Dim SUB3_TRADT As String '入出庫日
		Dim SUB3_SYUSU As Decimal '出庫
		Dim SUB3_HIKSU As Decimal '引当
		Dim SUB3_ATMNKB As String '自／手
		Dim SUB3_NYUSU As Decimal '入庫
		Dim SUB3_TOKRN As String '得意先
		Dim SUB3_BUMNM As String '営業部門
		Dim SUB3_SOUNM As String '倉庫
		'***add-E-tom***
	End Structure
	''================================================================================
	'メッセージコード
	'推定在庫照会（明細）
	Public Const gc_strMsgTNADL71_E_001 As String = "2TNADL71_001" '該当するデータが存在しません。
	'推定在庫照会
	Public Const gc_strMsgTNADL71_A_002 As String = "1TNADL71_002" '終了してよろしいですか？
	Public Const gc_strMsgTNADL71_E_003 As String = "2TNADL71_003" 'ＤＢ更新エラーが発生しました。
	Public Const gc_strMsgTNADL71_E_004 As String = "2TNADL71_004" '入力値が許容範囲外です。
	Public Const gc_strMsgTNADL71_E_005 As String = "2TNADL71_005" '削除済みレコードです。
	Public Const gc_strMsgTNADL71_E_006 As String = "2TNADL71_006" '該当するデータが存在しません。
	Public Const gc_strMsgTNADL71_E_007 As String = "2TNADL71_007" 'データ取得処理で異常が発生しました。
	Public Const gc_strMsgTNADL71_E_008 As String = "2TNADL71_008" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgTNADL71_E_009 As String = "2TNADL71_009" '受注・見積、又は製番出庫のデータではありません。
	Public Const gc_strMsgTNADL71_E_010 As String = "2TNADL71_010" 'このコードは使用できません。
	' === 20060908 === INSERT S - ACE)Sejima 実行ボタンイメージ対応
	Public Const gc_strMsgTNADL71_E_011 As String = "2TNADL71_011" 'これ以降のデータはありません。
	' === 20060908 === INSERT E
	' === 20061121 === INSERT S - ACE)Nagasawa 支給品情報の表示
	Public Const gc_strMsgTNADL71_E_012 As String = "2TNADL71_012" '見込の支給品のため明細の表示は行えません。
	' === 20061121 === INSERT E -
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module