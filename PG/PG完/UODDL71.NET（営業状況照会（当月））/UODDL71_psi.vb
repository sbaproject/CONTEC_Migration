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
		Dim Selected As String '選択/非選択
		Dim DIVISION As String '部門別総括表（1:部門、2:地区、3:営業所、99:全社）、機種別総括表（1:商品群別合計、2:明細、99:総合計）、機種明細表（1:商品群合計、2:分類Ａ合計、3:分類Ｂ合計、99:総合計）
		Dim DIVCODE As String '部門別総括表（部門コードor地区区分or営業所コード）
		Dim MEISYO As String '名称
		Dim BD_UODSU_T As Decimal '受注数
		Dim BD_UODKN_T As Decimal '受注金額
		Dim BD_SIKKN_T As Decimal '仕切
		Dim BD_BAISA_T As Decimal '売差
		Dim BD_BSART_T As Decimal '売差率
	End Structure
	
	''================================================================================
	'メッセージコード
	'営業状況照会
	Public Const gc_strMsgUODDL71_E_001 As String = "2UODDL71_001" '入力値が許容範囲外です。
	Public Const gc_strMsgUODDL71_E_002 As String = "2UODDL71_002" '該当するデータが存在しません。
	Public Const gc_strMsgUODDL71_E_003 As String = "2UODDL71_003" '削除済みレコードです。
	Public Const gc_strMsgUODDL71_E_004 As String = "2UODDL71_004" 'このコードは使用できません。
	Public Const gc_strMsgUODDL71_E_005 As String = "2UODDL71_005" '検索条件を入力してください。
	Public Const gc_strMsgUODDL71_E_006 As String = "1UODDL71_006" '終了してよろしいですか？
	Public Const gc_strMsgUODDL71_E_007 As String = "2UODDL71_007" 'これ以降のデータはありません。
	Public Const gc_strMsgUODDL71_E_008 As String = "2UODDL71_008" '明細を選択してください。
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module