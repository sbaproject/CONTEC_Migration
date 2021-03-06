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
	Public Const gc_strMsgHINFP62_I_001 As String = "1HINFP62_001" '○実行してよろしいですか？
	Public Const gc_strMsgHINFP62_I_002 As String = "1HINFP62_002" '○終了してよろしいですか？
	Public Const gc_strMsgHINFP62_I_003 As String = "1HINFP62_003" '○処理を終了しました。
	Public Const gc_strMsgHINFP62_I_004 As String = "1HINFP62_004" '○処理を中断しました。
	Public Const gc_strMsgHINFP62_I_006 As String = "1HINFP62_006" '○CSVファイルから商品マスタを更新します。
	Public Const gc_strMsgHINFP62_I_007 As String = "1HINFP62_007" '○終了します。
	Public Const gc_strMsgHINFP62_I_008 As String = "1HINFP62_008" '○ファイルが存在しません。
	Public Const gc_strMsgHINFP62_I_009 As String = "1HINFP62_009" '○商品マスタが更新されませんでした。
	'---------------------------------------------------------------------------------------------------------------------
	Public Const gc_strMsgHINFP62_E_011 As String = "2HINFP62_011" '最小発注数に数字以外が入っています。
	Public Const gc_strMsgHINFP62_E_012 As String = "2HINFP62_012" '最小増加数に数字以外が入っています。
	Public Const gc_strMsgHINFP62_E_013 As String = "2HINFP62_013" '安全在庫数に数字以外が入っています。
	Public Const gc_strMsgHINFP62_E_014 As String = "2HINFP62_014" '受注停止日に誤りがあります。
	Public Const gc_strMsgHINFP62_E_015 As String = "2HINFP62_015" '販売完了日に誤りがあります。
	Public Const gc_strMsgHINFP62_E_016 As String = "2HINFP62_016" '手配終了日に誤りがあります。
	Public Const gc_strMsgHINFP62_E_017 As String = "2HINFP62_017" '修理受付日に誤りがあります。
	Public Const gc_strMsgHINFP62_E_018 As String = "2HINFP62_018" '品名の桁数が５０文字を超えています。
	Public Const gc_strMsgHINFP62_E_019 As String = "2HINFP62_019" '価格区分の桁数が１文字を超えています。
	Public Const gc_strMsgHINFP62_E_020 As String = "2HINFP62_020" '在庫ランクの桁数が半角３文字を超えています。
	Public Const gc_strMsgHINFP62_E_021 As String = "2HINFP62_021" '最小発注数の桁数が４桁を超えています。
	Public Const gc_strMsgHINFP62_E_022 As String = "2HINFP62_022" '発注増加数の桁数が４桁を超えています。
	Public Const gc_strMsgHINFP62_E_023 As String = "2HINFP62_023" '安全在庫数の桁数が６桁を超えています。
	Public Const gc_strMsgHINFP62_E_024 As String = "2HINFP62_024" '後継機種の桁数が４０文字を超えています。
	Public Const gc_strMsgHINFP62_E_025 As String = "2HINFP62_025" '受注停止の桁数が１文字を超えています。
	Public Const gc_strMsgHINFP62_E_026 As String = "2HINFP62_026" '販売完了の桁数が１文字を超えています。
	Public Const gc_strMsgHINFP62_E_027 As String = "2HINFP62_027" '手配終了の桁数が１文字を超えています。
	Public Const gc_strMsgHINFP62_E_028 As String = "2HINFP62_028" '修理受付の桁数が１文字を超えています。
	Public Const gc_strMsgHINFP62_E_029 As String = "2HINFP62_029" 'メーカの桁数が３０文字を超えています。
	Public Const gc_strMsgHINFP62_E_030 As String = "2HINFP62_030" '備考Ａの桁数が２０文字を超えています。
	Public Const gc_strMsgHINFP62_E_031 As String = "2HINFP62_031" '備考Ｂの桁数が２０文字を超えています。
	Public Const gc_strMsgHINFP62_E_032 As String = "2HINFP62_032" '備考Ｃの桁数が２０文字を超えています。
	Public Const gc_strMsgHINFP62_E_033 As String = "2HINFP62_033" '備考Ｄの桁数が２０文字を超えています。
	Public Const gc_strMsgHINFP62_E_034 As String = "2HINFP62_034" '備考Ｅの桁数が２０文字を超えています。
	Public Const gc_strMsgHINFP62_E_035 As String = "2HINFP62_035" '該当する製造コードが存在しません。
	Public Const gc_strMsgHINFP62_E_036 As String = "2HINFP62_036" '品名が設定されていません。
	Public Const gc_strMsgHINFP62_E_037 As String = "2HINFP62_037" '該当する単位コードが存在しません。
	Public Const gc_strMsgHINFP62_E_038 As String = "2HINFP62_038" '該当する倉庫コードが存在しません。
	Public Const gc_strMsgHINFP62_E_039 As String = "2HINFP62_039" '倉庫コードが間違っています。
	Public Const gc_strMsgHINFP62_E_040 As String = "2HINFP62_040" '在庫ランクが間違っています。
	Public Const gc_strMsgHINFP62_E_041 As String = "2HINFP62_041" '価格区分は１、２以外は指定できません。
	Public Const gc_strMsgHINFP62_E_042 As String = "2HINFP62_042" '提供区分は０、２以外は指定できません。
	Public Const gc_strMsgHINFP62_E_043 As String = "2HINFP62_043" '受注停止は１、９以外は指定できません。
	Public Const gc_strMsgHINFP62_E_044 As String = "2HINFP62_044" '販売完了は１、９以外は指定できません。
	Public Const gc_strMsgHINFP62_E_045 As String = "2HINFP62_045" '手配終了は１、９以外は指定できません。
	Public Const gc_strMsgHINFP62_E_046 As String = "2HINFP62_046" '修理受付は１、９以外は指定できません。
	Public Const gc_strMsgHINFP62_E_047 As String = "2HINFP62_047" '受注停止日　日付エラー。
	Public Const gc_strMsgHINFP62_E_048 As String = "2HINFP62_048" '受注停止日が設定されています。
	Public Const gc_strMsgHINFP62_E_049 As String = "2HINFP62_049" '受注停止日が設定されていません。
	Public Const gc_strMsgHINFP62_E_050 As String = "2HINFP62_050" '販売完了日　日付エラー。
	Public Const gc_strMsgHINFP62_E_051 As String = "2HINFP62_051" '販売完了日が設定されています。
	Public Const gc_strMsgHINFP62_E_052 As String = "2HINFP62_052" '販売完了日が設定されていません。
	Public Const gc_strMsgHINFP62_E_053 As String = "2HINFP62_053" '手配終了日　日付エラー。
	Public Const gc_strMsgHINFP62_E_054 As String = "2HINFP62_054" '手配終了日が設定されています。
	Public Const gc_strMsgHINFP62_E_055 As String = "2HINFP62_055" '手配終了日が設定されていません。
	Public Const gc_strMsgHINFP62_E_056 As String = "2HINFP62_056" '修理受付日　日付エラー。
	Public Const gc_strMsgHINFP62_E_057 As String = "2HINFP62_057" '修理受付日が設定されています。
	Public Const gc_strMsgHINFP62_E_058 As String = "2HINFP62_058" '修理受付日が設定されていません。
	Public Const gc_strMsgHINFP62_E_059 As String = "2HINFP62_059" '更新データが一件もありませんでした。
	Public Const gc_strMsgHINFP62_E_060 As String = "2HINFP62_060" 'DB更新時にエラーがありました。
	Public Const gc_strMsgHINFP62_E_061 As String = "2HINFP62_061" 'DB抽出時にエラーがありました。
	Public Const gc_strMsgHINFP62_E_062 As String = "2HINFP62_062" 'ログ書き込み時にエラーがありました。
	Public Const gc_strMsgHINFP62_E_063 As String = "2HINFP62_063" 'CSV読み取り時ににエラーがありました。
	Public Const gc_strMsgHINFP62_E_064 As String = "2HINFP62_064" 'DBアクセスできませんでした。
	Public Const gc_strMsgHINFP62_E_065 As String = "2HINFP62_065" '項目数に誤りがあります。
	Public Const gc_strMsgHINFP62_E_066 As String = "2HINFP62_066" 'INIファイあるから取得できませんでした。
	Public Const gc_strMsgHINFP62_E_067 As String = "2HINFP62_067" 'テキストファイルがサーバにコピーできませんでした。
	Public Const gc_strMsgHINFP62_E_068 As String = "2HINFP62_068" 'ログファイルがサーバからコピーできませんでした。
End Module