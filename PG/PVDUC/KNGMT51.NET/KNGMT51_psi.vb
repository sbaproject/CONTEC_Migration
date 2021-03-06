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
		Dim KNGGRCD As String '権限グループ
		Dim PGID As String 'プログラムＩＤ
		Dim MEINMA As String 'プログラム名
		Dim UPDFLG As String '更新権限変更可能フラグ
		Dim UPDAUTH As String '更新権限
		Dim PRTFLG As String '印刷権限変更可能フラグ
		Dim PRTAUTH As String '印刷権限
		Dim FILEFLG As String 'ファイル出力権限変更可能フラグ
		Dim FILEAUTH As String 'ファイル出力権限
		Dim SALTFLG As String '販売単価変更権限変更可能フラグ
		Dim SALTAUTH As String '販売単価変更権限
		Dim HDNTFLG As String '発注単価変更権限変更可能フラグ
		Dim HDNTAUTH As String '発注単価変更権限
		Dim SAPMFLG As String '販売計画年初計画修正権限変更可能フラグ
		Dim SAPMAUTH As String '販売計画年初計画修正権限
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '更新フラグ
		' 2006/11/15  ADD END
		'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		Dim MOTO_WRTDT As String '更新日付
		Dim MOTO_WRTTM As String '更新時間
		Dim MOTO_UWRTDT As String 'バッチ更新日付
		Dim MOTO_UWRTTM As String 'バッチ更新時間
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim MOTO_OPEID As String '最終作業者コード
		Dim MOTO_CLTID As String 'クライアントＩＤ
		Dim MOTO_UOPEID As String '最終作業者コード（バッチ）
		Dim MOTO_UCLTID As String 'クライアントＩＤ（バッチ）
		' === 20080902 === INSERT E - RISE)Izumi
	End Structure
	
	''================================================================================
	'メッセージコード
	'権限登録
	Public Const gc_strMsgKNGMT51_E_001 As String = "2KNGMT51_001" '入力値が許容範囲外です。
	Public Const gc_strMsgKNGMT51_E_002 As String = "2KNGMT51_002" '該当するデータが存在しません。
	Public Const gc_strMsgKNGMT51_E_003 As String = "2KNGMT51_003" '削除済みレコードです。
	Public Const gc_strMsgKNGMT51_E_004 As String = "2KNGMT51_004" 'このコードは使用できません。
	Public Const gc_strMsgKNGMT51_E_005 As String = "2KNGMT51_005" '明細行に登録するデータがありません。
	Public Const gc_strMsgKNGMT51_A_006 As String = "1KNGMT51_006" '終了してよろしいですか？
	Public Const gc_strMsgKNGMT51_E_007 As String = "2KNGMT51_007" '権限グループは必須入力項目です。
	Public Const gc_strMsgKNGMT51_A_008 As String = "1KNGMT51_008" '更新してよろしいですか？
	Public Const gc_strMsgKNGMT51_E_009 As String = "2KNGMT51_009" '処理を終了しました｡
	Public Const gc_strMsgKNGMT51_E_010 As String = "2KNGMT51_010" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgKNGMT51_E_011 As String = "2KNGMT51_011" 'システムエラー
	Public Const gc_strMsgKNGMT51_A_012 As String = "1KNGMT51_012" '未登録のデータが存在します。更新を行います。
	Public Const gc_strMsgKNGMT51_A_013 As String = "1KNGMT51_013" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgKNGMT51_A_014 As String = "1KNGMT51_014" '現在の編集内容は破棄されます。よろしいですか？
	Public Const gc_strMsgKNGMT51_E_015 As String = "2KNGMT51_015" 'これ以降のデータはありません。
	Public Const gc_strMsgKNGMT51_E_016 As String = "2KNGMT51_016" '更新権限がありません。
	'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
	Public Const gc_strMsgKNGMT51_E_017 As String = "2KNGMT51_017" '他のプログラムで更新されたため、訂正できません。
	''    Public Const gc_strMsgKNGMT51_E_018         As String = "2KNGMT51_018"      '他のプログラムで更新されたため、削除できません。
	'2007/12/18 add-end M.SUEZAWA
	'ADD START FKS)INABA 2009/10/08 ************************************************************************************************
	'連絡票��FC09101403
	Public Const gc_strMsgKNGMT51_E_020 As String = "2KNGMT51_020" '他のプログラムで更新されたため、訂正できません。
	Public Const gc_strMsgKNGMT51_E_021 As String = "1KNGMT51_021" '他のプログラムで更新されたため、訂正できません。
	'ADD  END  FKS)INABA 2009/10/08 ************************************************************************************************
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module