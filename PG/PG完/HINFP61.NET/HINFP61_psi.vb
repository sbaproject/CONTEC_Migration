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
	End Structure
	''================================================================================
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
	Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)

    'メッセージコード
    '共通gc_strMsgHINFP61_E_008
    Public Const gc_strMsgHINFP61_I_001 As String = "1HINFP61_001" '○実行してよろしいですか？
	Public Const gc_strMsgHINFP61_I_002 As String = "1HINFP61_002" '○終了してよろしいですか？
	Public Const gc_strMsgHINFP61_I_003 As String = "1HINFP61_003" '○処理を終了しました。
	Public Const gc_strMsgHINFP61_I_004 As String = "1HINFP61_004" '○処理を中断しました。
	Public Const gc_strMsgHINFP61_I_005 As String = "1HINFP61_005" '○ファイルが存在します。上書きしてもよろしいですか?
	Public Const gc_strMsgHINFP61_I_006 As String = "1HINFP61_006" '○抽出したデータをファイルに出力します。
	Public Const gc_strMsgHINFP61_I_007 As String = "1HINFP61_007" '○終了します。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgHINFP61_E_008 As String = "2HINFP61_008" '●入力値が許容範囲外です。
	Public Const gc_strMsgHINFP61_E_009 As String = "2HINFP61_009" '●該当するデータが存在しません。
	Public Const gc_strMsgHINFP61_E_010 As String = "2HINFP61_010" '●ＤＢ参照エラーが発生しました。
    Public Const gc_strMsgHINFP61_E_011 As String = "2HINFP61_011" '●ＣＳＶ出力処理でエラーが発生しました。

End Module