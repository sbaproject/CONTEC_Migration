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
	'共通
	Public Const gc_strMsgURKFP55_I_001 As String = "1URKFP55_001" '○実行してよろしいですか？
	Public Const gc_strMsgURKFP55_I_002 As String = "1URKFP55_002" '○終了してよろしいですか？
	Public Const gc_strMsgURKFP55_I_003 As String = "1URKFP55_003" '○処理を終了しました。
	Public Const gc_strMsgURKFP55_I_004 As String = "1URKFP55_004" '○処理を中断しました。
	Public Const gc_strMsgURKFP55_I_006 As String = "1URKFP55_006" '○テキストファイルから入金処理マスタを更新します。
	Public Const gc_strMsgURKFP55_I_007 As String = "1URKFP55_007" '○終了します。
	Public Const gc_strMsgURKFP55_I_008 As String = "1URKFP55_008" '○ファイルが存在しません。
	Public Const gc_strMsgURKFP55_I_009 As String = "1URKFP55_009" '○入金処理マスタが更新されませんでした。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgURKFP55_E_011 As String = "2URKFP55_011" '処理区分に1,2,3以外は指定できません。
	Public Const gc_strMsgURKFP55_E_012 As String = "2URKFP55_012" '該当する銀行コードが存在しません。
	Public Const gc_strMsgURKFP55_E_013 As String = "2URKFP55_013" 'バーチャル口座の桁数が７文字を超えています。
	Public Const gc_strMsgURKFP55_E_014 As String = "2URKFP55_014" '該当する請求先コードが存在しません。
	Public Const gc_strMsgURKFP55_E_015 As String = "2URKFP55_015" '該当する入金種別コードが存在しません。
	Public Const gc_strMsgURKFP55_E_016 As String = "2URKFP55_016" '該当する勘定口座コードが存在しません。
	Public Const gc_strMsgURKFP55_E_017 As String = "2URKFP55_017" 'DB更新時にエラーがありました。
	Public Const gc_strMsgURKFP55_E_018 As String = "2URKFP55_018" 'DB抽出時にエラーがありました。
	Public Const gc_strMsgURKFP55_E_019 As String = "2URKFP55_019" 'ＤＢでアクセスできませんでした。
	Public Const gc_strMsgURKFP55_E_020 As String = "2URKFP55_020" '項目数に誤りがあります。
	Public Const gc_strMsgURKFP55_E_021 As String = "2URKFP55_021" 'テキスト読み取り時ににエラーがありました。
	Public Const gc_strMsgURKFP55_E_022 As String = "2URKFP55_022" 'INIファイルから取得できませんでした。
	Public Const gc_strMsgURKFP55_E_023 As String = "2URKFP55_023" 'テキストファイルがサーバにコピーできませんでした。
	Public Const gc_strMsgURKFP55_E_024 As String = "2URKFP55_024" 'ログファイルがサーバからコピーできませんでした。
	Public Const gc_strMsgURKFP55_E_025 As String = "2URKFP55_025" '該当する請求先の口座番号が違っています。
End Module