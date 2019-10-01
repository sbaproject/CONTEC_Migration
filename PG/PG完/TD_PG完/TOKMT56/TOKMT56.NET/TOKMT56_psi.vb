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
		Dim UPDKB As String 'モード
		Dim DATKB As String '伝票削除区分
		Dim TOKCD As String '得意先コード
		Dim SKHINGRP As String '仕切用商品群
		Dim SKWRKKB As String '仕切処理区分
		Dim HINCD As String '製品コード
		Dim HINNMA As String '型式
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '更新フラグ
		' 2006/11/15  ADD END
		' === 20080911 === INSERT S - RISE)Izumi
		Dim MOTO_OPEID As String '最終作業者コード
		Dim MOTO_CLTID As String 'クライアントＩＤ
		Dim MOTO_UOPEID As String '最終作業者コード（バッチ）
		Dim MOTO_UCLTID As String 'クライアントＩＤ（バッチ）
		' === 20080911 === INSERT E - RISE)Izumi
		'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		Dim MOTO_WRTDT As String '更新日付
		Dim MOTO_WRTTM As String '更新時間
		Dim MOTO_UWRTDT As String 'バッチ更新日付
		Dim MOTO_UWRTTM As String 'バッチ更新時間
		'2007/12/18 add-end M.SUEZAWA
	End Structure
	
	''================================================================================
	'メッセージコード
	'得意先別取扱商品登録
	Public Const gc_strMsgTOKMT56_E_001 As String = "2TOKMT56_001" '入力値が許容範囲外です。
	Public Const gc_strMsgTOKMT56_E_002 As String = "2TOKMT56_002" '該当するデータが存在しません。
	Public Const gc_strMsgTOKMT56_E_003 As String = "2TOKMT56_003" '削除済みレコードです。
	Public Const gc_strMsgTOKMT56_E_004 As String = "2TOKMT56_004" 'このコードは使用できません。
	Public Const gc_strMsgTOKMT56_E_005 As String = "2TOKMT56_005" '明細行に登録するデータがありません。
	Public Const gc_strMsgTOKMT56_A_006 As String = "1TOKMT56_006" '終了してよろしいですか？
	Public Const gc_strMsgTOKMT56_E_007 As String = "2TOKMT56_007" '製品コードは必須入力項目です。
	Public Const gc_strMsgTOKMT56_A_008 As String = "1TOKMT56_008" '更新してよろしいですか？
	Public Const gc_strMsgTOKMT56_E_009 As String = "2TOKMT56_009" '処理を終了しました｡
	Public Const gc_strMsgTOKMT56_E_010 As String = "2TOKMT56_010" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgTOKMT56_E_011 As String = "2TOKMT56_011" 'システムエラー
	Public Const gc_strMsgTOKMT56_E_012 As String = "2TOKMT56_012" '該当する製品データが存在しません。
	Public Const gc_strMsgTOKMT56_E_013 As String = "2TOKMT56_013" '削除済み製品レコードです。
	Public Const gc_strMsgTOKMT56_E_014 As String = "2TOKMT56_014" 'この製品コードは使用できません。
	Public Const gc_strMsgTOKMT56_E_015 As String = "2TOKMT56_015" '検索条件を入力して下さい。
	Public Const gc_strMsgTOKMT56_A_016 As String = "1TOKMT56_016" '未登録のデータが存在します。更新を行います。
	Public Const gc_strMsgTOKMT56_A_017 As String = "1TOKMT56_017" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgTOKMT56_A_018 As String = "1TOKMT56_018" '現在の編集内容は破棄されます。よろしいですか？
	Public Const gc_strMsgTOKMT56_E_019 As String = "2TOKMT56_019" 'これ以降のデータはありません。
	Public Const gc_strMsgTOKMT56_E_020 As String = "2TOKMT56_020" '見出部の入力がまだのため明細行の入力ができません。
	Public Const gc_strMsgTOKMT56_E_021 As String = "2TOKMT56_021" '更新権限がありません。
	'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
	Public Const gc_strMsgTOKMT56_E_022 As String = "2TOKMT56_022" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgTOKMT56_E_023 As String = "2TOKMT56_023" '他のプログラムで更新されたため、削除できません。
	'2007/12/18 add-end M.SUEZAWA
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module