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
		Dim DKBID As String
		Dim DKBNM As String
		Dim KANKOZ As String
		Dim NYUKN As Decimal
		Dim FNYUKN As Double
		Dim BNKCD As String
		Dim BNKNM As String
		Dim JDNNO As String
		Dim JDNLINNO As String
		Dim STNNM As String
		Dim TEGDT As String
		Dim TEGNO As String
		Dim LINCMA As String
		Dim LINCMB As String
		'2009/06/05 ADD START FKS)NAKATA
		Dim OKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim DATNO As String
		Dim LINNO As String
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		Dim SYSTBD As TYPE_DB_SYSTBD
	End Structure
	
	''================================================================================
	'メッセージコード
	'入金訂正
	Public Const gc_strMsgURKET52_A_001 As String = "1URKET52_001" '終了してよろしいですか？
	Public Const gc_strMsgURKET52_A_002 As String = "1URKET52_002" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgURKET52_E_003 As String = "2URKET52_003" '更新権限がありません。
	Public Const gc_strMsgURKET52_E_004 As String = "2URKET52_004" '更新異常
	Public Const gc_strMsgURKET52_A_005 As String = "1URKET52_005" '更新してよろしいですか？
	Public Const gc_strMsgURKET52_A_006 As String = "1URKET52_006" '処理が終了しました。
	Public Const gc_strMsgURKET52_E_007 As String = "2URKET52_007" '入力値が許容範囲外です。
	Public Const gc_strMsgURKET52_E_008 As String = "2URKET52_008" '日付に誤りがあります。修正してください。
	Public Const gc_strMsgURKET52_E_009 As String = "2URKET52_009" '削除済みレコードです。
	Public Const gc_strMsgURKET52_E_010 As String = "2URKET52_010" 'このコードは使用できません。
	Public Const gc_strMsgURKET52_E_011 As String = "2URKET52_011" '該当するデータが存在しません。
	Public Const gc_strMsgURKET52_E_012 As String = "2URKET52_012" '伝票の明細部を入力して下さい。
	Public Const gc_strMsgURKET52_E_013 As String = "2URKET52_013" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgURKET52_E_014 As String = "2URKET52_014" '見出部の入力がまだのため明細行の入力ができません。
	Public Const gc_strMsgURKET52_E_015 As String = "2URKET52_015" '運用日以降は入力できません。
	Public Const gc_strMsgURKET52_E_016 As String = "2URKET52_016" '月次更新済みです。この日付では入力できません。
	Public Const gc_strMsgURKET52_E_017 As String = "2URKET52_017" 'マスタ登録内容と入金種別が異なります。
	Public Const gc_strMsgURKET52_E_018 As String = "2URKET52_018" '明細には、手形の入力が必要です。
	Public Const gc_strMsgURKET52_E_019 As String = "2URKET52_019" '振込の場合、銀行コードを入力してください。
	Public Const gc_strMsgURKET52_E_020 As String = "2URKET52_020" '手形の場合、銀行コードを入力してください。
	Public Const gc_strMsgURKET52_E_021 As String = "2URKET52_021" '手形の場合、決済日を入力してください。
	Public Const gc_strMsgURKET52_E_022 As String = "2URKET52_022" '手形の場合、手形番号を入力してください。
	Public Const gc_strMsgURKET52_E_023 As String = "2URKET52_023" '手形の場合、手形支払金額以上を入力してください。
	Public Const gc_strMsgURKET52_E_024 As String = "2URKET52_024" '訂正する入金を選択してください。
	Public Const gc_strMsgURKET52_E_025 As String = "2URKET52_025" '請求先ではありません。
	Public Const gc_strMsgURKET52_E_026 As String = "2URKET52_026" '他のプログラムで更新されたため、更新できません。
	Public Const gc_strMsgURKET52_E_027 As String = "2URKET52_027" '得意先より締日が算出できません。
	Public Const gc_strMsgURKET52_A_028 As String = "1URKET52_028" '削除してよろしいですか？
	Public Const gc_strMsgURKET52_E_029 As String = "2URKET52_029" '変更差額が消込額を超えています。
	'// V1.10↓ ADD
	Public Const gc_strMsgURKET52_E_030 As String = "2URKET52_030" '決済日が過ぎています。入金種別を変更してください。
	'// V1.10↑ ADD
	'2009/06/08 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET52_E_031 As String = "2URKET52_031" '受注金額を上回っています。
	Public Const gc_strMsgURKET52_E_032 As String = "2URKET52_032" '受注金額を下回っています。
	'2009/06/08 ADD E.N.D FKS)NAKATA
	'2009/09/03 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_033 As String = "2URKET52_033" '請求締日以前です。この日付では入力できません。
	Public Const gc_strMsgURKET52_E_034 As String = "2URKET52_034" '請求先担当者が営業でありません。
	Public Const gc_strMsgURKET52_E_035 As String = "2URKET52_035" '期日到来です。本入金済か確認後、現金化して下さい。
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'2009/09/07 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET52_E_036 As String = "2URKET52_036" '充当済の入金です。更新できません。
	'2009/09/07 ADD E.N.D FKS)NAKATA
	'2009/09/23 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_037 As String = "2URKET52_037" '使用できない入金種別です。
	'2009/09/23 ADD E.N.D RISE)MIYAJIMA
	'2009/10/05 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET52_E_038 As String = "2URKET52_038" '関連した受注が完了している為、更新できません。
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	'2009/11/10 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET52_E_039 As String = "2URKET52_039" '受注伝票日付が入金日より後の受注は入力できません。
	'2009/11/10 ADD E.N.D FKS)YAMAMOTO
	'2009/12/28 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET52_E_040 As String = "2URKET52_040" '勘定口座の種別が手形ではありません。
	Public Const gc_strMsgURKET52_E_041 As String = "2URKET52_041" '手形の勘定口座が指定されています。
	'2009/12/28 ADD E.N.D FKS)YAMAMOTO
	'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
	Public Const gc_strMsgURKET52_E_042 As String = "2URKET52_042" '締めを跨いでの日付は入力できません
	'''' ADD 2011/01/14  FKS) T.Yamamoto    End
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module