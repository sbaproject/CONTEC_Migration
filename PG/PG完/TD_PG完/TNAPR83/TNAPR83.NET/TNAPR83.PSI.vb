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
	
	'メッセージコード
	'共通
	Public Const gc_strMsgTNAPR83_I_001 As String = "1TNAPR83_001" '○実行してよろしいですか？
	Public Const gc_strMsgTNAPR83_I_002 As String = "1TNAPR83_002" '○終了してよろしいですか？
	Public Const gc_strMsgTNAPR83_I_003 As String = "1TNAPR83_003" '○処理を終了しました。
	Public Const gc_strMsgTNAPR83_I_004 As String = "1TNAPR83_014" '○処理を中断しました。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTNAPR83_E_005 As String = "2TNAPR83_005" '●入力値が許容範囲外です。
	Public Const gc_strMsgTNAPR83_E_006 As String = "2TNAPR83_006" '●該当するデータが存在しません。
	Public Const gc_strMsgTNAPR83_E_007 As String = "2TNAPR83_017" '●シーケンス取得でエラーが発生しました。
	Public Const gc_strMsgTNAPR83_E_008 As String = "2TNAPR83_008" '●ＤＢ更新エラーが発生しました。
	Public Const gc_strMsgTNAPR83_E_009 As String = "2TNAPR83_009" '●ＤＢ参照エラーが発生しました。
	Public Const gc_strMsgTNAPR83_E_010 As String = "2TNAPR83_010" '●ＤＢアクセスエラーが発生しました。
	Public Const gc_strMsgTNAPR83_E_011 As String = "2TNAPR83_011" '●帳票出力処理でエラーが発生しました。
	Public Const gc_strMsgTNAPR83_E_012 As String = "2TNAPR83_012" '●入力されていない項目があります。入力して下さい。
	Public Const gc_strMsgTNAPR83_E_013 As String = "2TNAPR83_013" '●日付に誤りがあります。修正してください。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgTNAPR83_E_014 As String = "2TNAPR83_014" '●年月に誤りがあります。修正してください。
End Module