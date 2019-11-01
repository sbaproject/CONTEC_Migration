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
		Dim INPYTDT As String '入庫予定日
		Dim HINNMA As String '型式
		Dim LOTNO As String '製番
		Dim INPYTSU As Decimal '数量
		Dim SIRCD As String '仕入先(コード）
		Dim SIRRN As String '仕入先(名称）
	End Structure
	
	''================================================================================
	'メッセージコード
	'請求仮締解除
	Public Const gc_strMsgENDFP61_E_001 As String = "2ENDFP61_001" 'このコードは使用できません。
	Public Const gc_strMsgENDFP61_E_002 As String = "2ENDFP61_002" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgENDFP61_E_003 As String = "2ENDFP61_003" '本締め済みの為、解除できません。
	Public Const gc_strMsgENDFP61_E_004 As String = "2ENDFP61_004" '未来月への仮締めを行うことはできません。
	Public Const gc_strMsgENDFP61_A_005 As String = "1ENDFP61_005" '月次仮締解除処理を行います。
	Public Const gc_strMsgENDFP61_A_006 As String = "1ENDFP61_006" '月次仮締処理を行います。
	Public Const gc_strMsgENDFP61_E_007 As String = "2ENDFP61_007" '処理を終了しました｡
	Public Const gc_strMsgENDFP61_A_008 As String = "1ENDFP61_008" '終了してよろしいですか？
	Public Const gc_strMsgENDFP61_E_009 As String = "2ENDFP61_009" 'システムエラー
	Public Const gc_strMsgENDFP61_E_010 As String = "2ENDFP61_010" '該当するデータが存在しません。
	Public Const gc_strMsgENDFP61_E_011 As String = "2ENDFP61_011" '更新権限がありません。
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module