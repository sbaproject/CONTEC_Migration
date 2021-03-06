Option Strict Off
Option Explicit On
Module SSSMAIN0002
	''プログラム総括情報プロシジャ
	''□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	'''================================================================================
	''☆　画面ボディ部の行単位の業務情報　　　　　☆
	''☆　　Cls_Dsp_Body_Row_Infとの互換性を　　　☆
	''☆　　共通の全てのＰＧで宣言する　　　　　　☆
	''☆　　そのため以下の｢Dummy｣は必須！！ 　　　☆
	Public Structure Cls_Dsp_Body_Bus_Inf
		Dim Dummy As String 'ダミー
	End Structure
	'''================================================================================
	'受注残照会（売上予定確認）
	Public Const gc_strMsgHIKFP52_Q_EXIT03 As String = "1HIKFP52_001" '終了してよろしいですか？
	Public Const gc_strMsgHIKFP52_E_NODATA01 As String = "2HIKFP52_002" '該当するデータが存在しません。
	Public Const gc_strMsgHIKFP52_E_DELDATA As String = "2HIKFP52_003" '削除済みレコードです。
	Public Const gc_strMsgHIKFP52_E_INPUTERR As String = "2HIKFP52_004" '入力値が許容範囲外です。
	Public Const gc_strMsgHIKFP52_Q_RUN As String = "1HIKFP52_005" '実行してよろしいですか？
	Public Const gc_strMsgHIKFP52_Q_ZAIKBNG As String = "1HIKFP52_006" '在庫管理対象外です。
	Public Const gc_strMsgHIKFP52_A_UPDATEOK As String = "1HIKFP52_007" '処理が終了しました。
	Public Const gc_strMsgHIKFP52_A_COMPLETEC As String = "2HIKFP52_008" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgHIKFP52_E_UPDATENG As String = "2HIKFP52_009" 'ＤＢ更新エラーが発生しました。
	Public Const gc_strMsgHIKFP52_E_NOTSEIHIN As String = "2HIKFP52_010" '製品ではありません。
	Public Const gc_strMsgHIKFP52_E_011 As String = "2HIKFP52_011" 'このコードは使用できません。
	' === 20061105 === INSERT S - ACE)Nagasawa 排他制御の追加
	Public Const gc_strMsgHIKFP52_E_012 As String = "2HIKFP52_012" 'が実行中です。しばらくして実行してください。
	' === 20061105 === INSERT E -
	' === 20061129 === INSERT S - ACE)Nagasawa 更新権限チェックを変更する
	Public Const gc_strMsgHIKFP52_E_013 As String = "2HIKFP52_013" '更新権限がありません。
	' === 20061129 === INSERT E -
	''□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module