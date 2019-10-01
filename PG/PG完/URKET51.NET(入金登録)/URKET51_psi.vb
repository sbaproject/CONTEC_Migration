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
		Dim SYSTBD As TYPE_DB_SYSTBD
	End Structure
	
	''================================================================================
	'メッセージコード
	'入金登録
	Public Const gc_strMsgURKET51_A_001 As String = "1URKET51_001" '終了してよろしいですか？
	Public Const gc_strMsgURKET51_A_002 As String = "1URKET51_002" '未登録のまま終了してもよろしいですか？
	Public Const gc_strMsgURKET51_E_003 As String = "2URKET51_003" '更新権限がありません。
	Public Const gc_strMsgURKET51_E_004 As String = "2URKET51_004" '更新異常
	Public Const gc_strMsgURKET51_A_005 As String = "1URKET51_005" '更新してよろしいですか？
	Public Const gc_strMsgURKET51_A_006 As String = "1URKET51_006" '処理が終了しました。
	Public Const gc_strMsgURKET51_E_007 As String = "2URKET51_007" '入力値が許容範囲外です。
	Public Const gc_strMsgURKET51_E_008 As String = "2URKET51_008" '日付に誤りがあります。修正してください。
	Public Const gc_strMsgURKET51_E_009 As String = "2URKET51_009" '削除済みレコードです。
	Public Const gc_strMsgURKET51_E_010 As String = "2URKET51_010" 'このコードは使用できません。
	Public Const gc_strMsgURKET51_E_011 As String = "2URKET51_011" '該当するデータが存在しません。
	Public Const gc_strMsgURKET51_E_012 As String = "2URKET51_012" '伝票の明細部を入力して下さい。
	Public Const gc_strMsgURKET51_E_013 As String = "2URKET51_013" '入力されていない項目があります。入力してください。
	Public Const gc_strMsgURKET51_E_014 As String = "2URKET51_014" '見出部の入力がまだのため明細行の入力ができません。
	Public Const gc_strMsgURKET51_E_015 As String = "2URKET51_015" '運用日以降は入力できません。
	Public Const gc_strMsgURKET51_E_016 As String = "2URKET51_016" '月次更新済みです。この日付では入力できません。
	Public Const gc_strMsgURKET51_E_017 As String = "2URKET51_017" 'マスタ登録内容と入金種別が異なります。
	Public Const gc_strMsgURKET51_E_018 As String = "2URKET51_018" '明細には、手形の入力が必要です。
	Public Const gc_strMsgURKET51_E_019 As String = "2URKET51_019" '振込の場合、銀行コードを入力してください。
	Public Const gc_strMsgURKET51_E_020 As String = "2URKET51_020" '手形の場合、銀行コードを入力してください。
	Public Const gc_strMsgURKET51_E_021 As String = "2URKET51_021" '手形の場合、決済日を入力してください。
	Public Const gc_strMsgURKET51_E_022 As String = "2URKET51_022" '手形の場合、手形番号を入力してください。
	Public Const gc_strMsgURKET51_E_023 As String = "2URKET51_023" '手形の場合、手形支払金額以上を入力してください。
	Public Const gc_strMsgURKET51_E_024 As String = "2URKET51_024" 'バーチャル口座が得意先に存在しません。
	Public Const gc_strMsgURKET51_E_025 As String = "2URKET51_025" '請求先ではありません。
	Public Const gc_strMsgURKET51_E_026 As String = "2URKET51_026" '他のプログラムで更新されたため、更新できません。
	Public Const gc_strMsgURKET51_E_027 As String = "2URKET51_027" '得意先より締日が算出できません。
	'2009/06/08 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET51_E_028 As String = "2URKET51_028" '受注金額を上回っています。
	Public Const gc_strMsgURKET51_E_029 As String = "2URKET51_029" '受注金額を下回っています。
	'2009/06/08 ADD E.N.D FKS)NAKATA
	'2009/09/03 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_030 As String = "2URKET51_030" '請求締日以前です。この日付では入力できません。
	Public Const gc_strMsgURKET51_E_031 As String = "2URKET51_031" '請求先担当者が営業でありません。
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	'2009/09/07 ADD START FKS)NAKATA
	Public Const gc_strMsgURKET51_E_032 As String = "2URKET51_032" '充当済の入金です。更新できません。
	'2009/09/07 ADD E.N.D FKS)NAKATA
	'2009/09/23 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_033 As String = "2URKET51_033" '使用できない入金種別です。
	'2009/09/23 ADD E.N.D RISE)MIYAJIMA
	'2009/09/24 ADD START RISE)MIYAJIMA
	Public Const gc_strMsgURKET51_E_034 As String = "2URKET51_034" '変更差額が消込額を超えています。
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	'2009/11/10 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET51_E_035 As String = "2URKET51_035" '受注伝票日付が入金日より後の受注は入力できません。
	'2009/11/10 ADD E.N.D FKS)YAMAMOTO
	'2009/12/28 ADD START FKS)YAMAMOTO
	Public Const gc_strMsgURKET51_E_036 As String = "2URKET51_036" '勘定口座の種別が手形ではありません。
	Public Const gc_strMsgURKET51_E_037 As String = "2URKET51_037" '手形の勘定口座が指定されています。
	'2009/12/28 ADD E.N.D FKS)YAMAMOTO
	'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
	Public Const gc_strMsgURKET51_E_038 As String = "2URKET51_038" '締めを跨いでの日付は入力できません
	'''' ADD 2011/01/14  FKS) T.Yamamoto    End
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module