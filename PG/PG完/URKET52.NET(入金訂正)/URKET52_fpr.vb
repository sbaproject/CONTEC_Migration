Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付    | 更新者        |内容
	'//* ---------|----------|---------------|-----------------------------------------------
	'//* 1.00     |          |RISE)          |新規作成
	'//* 1.10     |2009/01/22|RISE)宮島      |決済日と運用日を比較し決済日が運用日を超えている場合は、メッセージを表示する。
	'//* 1.20     |2009/03/18|RISE)宮島      |・銀行コードの入力は入金種別が「手形」の場合のみ入力可能とする。(元々)
	'//* 1.20     |2009/03/18|RISE)宮島      |・以下、チェック内容を行わない。
	'//*          |          |               |　①得意先マスタの手形支払金額＞０かつ、明細に手形がない場合、
	'//*          |          |               |     エラー｡ ※仕様書2行目のチェック｡
	'//*          |          |               |  ②入金種別 = 手形かつ､得意先マスタの手形支払金額 > 入力金額
	'//*          |          |               |     の場合､エラー｡ ※仕様書7行目のチェック｡
	'//*          |          |               |  ③②と同内容の海外版チェック ※仕様書8行目のチェック｡
	'//*          |          |               |  ④入金種別 = 振込､かつ､銀行コードが未入力の場合はエラー｡
	'//*          |          |               |      ※仕様書3行目のチェック｡
	'//* 1.20     |2009/03/18|RISE)宮島      |・対象の受注データ（受注見出しトラン）の前受区分が「２．前受」で
	'//*          |          |               |  なければエラーとする。
	'//* 1.20     |2009/03/18|RISE)宮島      |・受注データ（受注見出しトラン）が排他チェックの対象として必要。
	'//*          |          |               |　ただし、排他チェックの内容としては、データの存在チェック（取消されて
	'//*          |          |               |　いないかの確認）、前受区分が「２．前受」かのチェックのみ実施する。
	'//*          |2009/05/27|FKS)中田       |・入金区分が「２．前受」の場合で、かつ仮振込の場合、決済日を入力可能とする。
	'//*          |2009/06/05|FKS)中田       |・前受入金時、受注番号を格納する場所を「売上トラン.受注番号」を「売上トラン.送り状№」へ変更。
	'//*          |          |               |・売上トラン.消込区分に前受入金が使用されたかどうかを判断させるため「９」を格納
	'//*          |2009/06/08|FKS)中田       |・入金区分が「２．前受」の場合、受注番号の未入力チェックの追加。
	'//*          |          |               |・前受入金時の「受注金額=入金額」のチェック(アラート)を追加。
	'//*          |          |               |　　受注金額＜入金額の場合、「受注金額を上回っています。」
	'//*          |          |               |　　受注金額＞入金額の場合、「受注金額を下回っています。」
	'//*          |          |               |・前受入金時、対象の受注データ（受注見出しトラン）の請求先が
	'//*          |          |               |　画面入力の請求先と異なっている場合はエラー
	'//*          |2009/06/10|FKS)中田       |・請求サマリ前受(TOKSSB)・請求サマリ(外貨)の更新部を修正
	'//*          |　　　　　|　　　　　　　 |   ※INSERT時、TOKSSB.DATNO 及び TOKSSC.DATNOを空白にて更新。
	'//*          |　　　　　|　　　　　　　 |   ※UPDATE時、TOKSSB.DATNO 及び TOKSSC.DATNOは更新を行わない。
	'//*          |2009/09/03|RISE)宮島      |・入金種別入力時、決済日到来（現金化済）分について、現金以外の入力はエラーとする
	'//*          |　　　　　|　　　　　　　 |・入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
	'//*          |　　　　　|　　　　　　　 |・決済日のチェック時、前回月次更新実行日だけでなく、入金日とチェックも必要
	'//*          |　　　　　|　　　　　　　 |・入金登録時、担当者が営業担当であることのチェックも必要
	'//*          |　　　　　|　　　　　　　 |・前受区分によって、勘定科目のチェックを実施
	'//*          |2009/09/05|RISE)宮島      |・変更差額チェックのチェック方法の変更　消込入金額=0 and 変更前入金額<>0 の時にエラーを表示する
	'//*          |2009/09/07|FKS)中田       |・前受入金時の「受注金額=入金額」のチェック(アラート)をエラーに変更
	'//*          |          |               |　（逆仕訳は除く）
	'//*          |2009/09/18|RISE)宮島      |・手数料、消費税の取り扱い変更対応
	'//*          |2009/09/23|RISE)宮島      |・得意先マスタ・支払区分≠'5':期日振込 or '6':ファクタリングの場合
	'//*          |          |               |  画面の入金種別＝'08'(仮振込)は、「使用できない入金種別です」のエラーメッセージを表示
	'//*          |2009/09/23|RISE)宮島      |・入金訂正データ読み込み時入金日のエラーチェックがかからない
	'//*          |2009/09/24|RISE)宮島      |・金額差額方法の変更（請求サマリから消込サマリの金種単位へ）
	'//*          |2009/09/24|RISE)宮島      |・前受の本入金時はサマリ系テーブルに更新しない
	'//*          |2009/09/24|RISE)宮島      |・売上トラン・請求サマリの月度判定の変更
	'//*          |2009/09/27|RISE)宮島      |・UDNTRA.RATERT に TUKMTA.RATERT を設定する
	'//*          |2009/09/29|RISE)宮島      |・金額差額のチェック時、売上トランに保持している経理締日付ではなく、画面『入金日』より
	'//*          |          |               |  経理締日付を算出し最新月度の入金消込サマリを相手にする。
	'//*          |2009/09/30|RISE)宮島      |・期日が到来している金種の赤黒作成
	'//*          |2009/10/05|RISE)宮島      |・外貨の時に差額チェックが正しく行われない
	'//*          |2009/10/05|RISE)宮島      |・前受時、受注見出し・受注トランの下記項目を更新する
	'//*          |          |               |  　ユーザID (バッチ), クライアントID(バッチ), タイムスタンプ(バッチ時間), タイムスタンプ(バッチ日), 更新PGID
	'//*          |          |               |  ※画面変更前と変更後両方の受注データに対して行う
	'//*          |2009/10/05|RISE)宮島      |・EXPに移動した受注はエラーにする
	'//*          |2009/10/07|RISE)宮島      |・前受入金で振込仮が無い明細を更新する時に決済日に運用日を設定していたが入金日をデフォルトで設定する
	'//*          |          |               |・期日が到来している金種の赤黒作成の判断基準日を運用日から入金日に変更する
	'//*          |2009/11/10|FKS)山本       |・前受入金時、受注データの受注伝票日付＞画面.入金日の場合エラー
	'//*          |2009/12/28|FKS)山本       |・入金種別と勘定口座がともに手形、もしくは、ともに手形以外でなければエラー
	'//*          |2011/01/14|FKS)山本       |・月次本締日の条件撤廃
	'//*          |          |               |・入金日＞翌締めの場合はエラー
	'//*          |2011/06/14|FKS)山本       |・通常入金時も仮振込の場合は決済日を入力可とする
	'//*          |2011/11/15|FKS)山本       |・請求先の支払区分＝5(期日振込)、6(ﾌｧｸﾀﾘﾝｸﾞ)で、画面.入金種別＝07(他)の場合は
	'//*          |          |               |  売上トラン.入金種別を２(仮入金)とする対象から除外
	'//**************************************************************************************
	
	
	
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(169 + 23 + 0 + 1) As clsCP
	Public CL_SSSMAIN(169) As Short
    Public CQ_SSSMAIN(54) As String


    '□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
    '初期処理時チェック実行フラグ
    Public gv_bolInit As Boolean '初期処理時はTrue(チェックなし）　それ以外はFalse
	Public gv_bolURKET52_INIT As Boolean '画面初期化フラグ（True:変更あり）
	Public gv_bolURKET52_LF_Enable As Boolean 'LF処理実行フラグ(True：実行する）
	Public gv_bolKeyFlg As Boolean
	Public gv_bolUpdFlg As Boolean
	Public gv_bolDelFlg As Boolean
	Private intInput_Bef_RowNo As Short '空白行の先頭行№
	
	Private Structure URKET52_TYPE_HEAD
		Dim DATNO As String '伝票管理番号
		Dim UDNTHA As TYPE_DB_UDNTHA '伝票管理番号に紐づく売上トラン(最初に取得してから変更しない)
		Dim UDNTRA() As TYPE_DB_UDNTRA '伝票管理番号に紐づく売上見出トラン(最初に取得してから変更しない)
		Dim NYUKB As String '入金区分
		Dim NYUDT As String '入金日
		Dim TOKCD As String '請求先コード
		Dim TOKMTA As TYPE_DB_TOKMTA '請求先コードに紐づく得意先データ
		Dim KNJKOZ As String '勘定口座
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim TEGKB() As Short '期日到来(0:到来していない 1:到来している)
		Dim DKBID() As String '取引区分(画面で入力されて取引区分)
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	End Structure
	'見出情報
	'UPGRADE_WARNING: 構造体 URKET52_HEAD_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private URKET52_HEAD_Inf As URKET52_TYPE_HEAD
	
	Private pv_bolMEISAI_INPUT As Boolean '明細入力フラグ(True:入力あり）
	Private pv_bolMEISAI_TEG_INPUT As Boolean '明細手形入力フラグ(True:入力あり）
	Private pv_intMeisaiCnt As Short '入力明細数（更新時使用）
	
	'起動時に取得する値(F_GET_SYSTBA)
	Private pv_strYERUPDDT As String '前回年次更新実行日
	'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
	'月次本締日の条件撤廃
	'Private pv_strMONUPDDT              As String               '前回月次更新実行日
	Private pv_strSMAUPDDT As String '前回経理締実行日
	'''' UPD 2011/01/14  FKS) T.Yamamoto    End
	Private pv_strSMADD As String '決算日
	
	'更新時使用
	Private pv_strSMADT As String '経理締日付
	Private pv_strSSADT As String '締日付
	Private pv_strKESDT As String '決済日付
	Private pv_curNYUKN_SUM As Decimal '合計(円)
	Private pv_dblFNYUKN_SUM As Double '合計(合計)

    '入金検索戻り値
    'Public WLSNDN_RTNCODE As String '伝票管理番号

    'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ

    '**ﾁｪｯｸ関数関連 Start **

    '//戻値
    Public Const CHK_OK As Short = 0 '正常
	Public Const CHK_WARN As Short = 1 '警告
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '未入力エラー
	Public Const CHK_ERR_ELSE As Short = 11 'その他エラー
	
	'F_Chk_Jge_Action関数用
	Public Const CHK_KEEP As Short = 0 'チェック続行
	Public Const CHK_STOP As Short = 1 'チェック中断
	
	'**ﾁｪｯｸ関数関連 End  **
	
	'//F_Set_Next_Focus処理モード
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURNと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHTと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWNと同様の制御
	'//F_Dsp_Item_Detail処理モード
	Public Const DSP_SET As Short = 0 '表示
	Public Const DSP_CLR As Short = 1 'クリア
	
	'フォーマット
	Public Const gc_DSP_FMT_KIN_GAI_1 As String = "#,##0.0000" '金額(外貨)
	
	'伝票取引区分種別
	Private Const pc_strDKBSB_URK As String = "050" '
	
	'名称マスタ（キーコード）
	Private Const pc_strKEYCD_KNJKOZ As String = "062" '勘定口座
	'2009/09/03 ADD START RISE)MIYAJIMA
	Private Const pc_strKEYCD_KNJKOZ_MAE As String = "111" '勘定口座(前受)
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	Private Structure TYPE_NKSSMX
		<VBFixedArray(9)> Dim curSSANYUKN() As Decimal '入金集計金額
		<VBFixedArray(9)> Dim curKSKNYKKN() As Decimal '入金消込集計金額
		<VBFixedArray(9)> Dim curKSKZANKN() As Decimal '前月入金消込残額
		<VBFixedArray(9)> Dim curZAN() As Decimal '残額（入金集計金額－入金消込集計金額＋前月入金消込残額）
		Dim curTOTAL As Decimal '金額合計（0～9までの残額計8:本入金をのぞく）
		Dim strOPEID As String '排他用
		Dim strCLTID As String '排他用
		Dim strWRTTM As String '排他用
		Dim strWRTDT As String '排他用
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim curSSANYUKN(9)
			ReDim curKSKNYKKN(9)
			ReDim curKSKZANKN(9)
			ReDim curZAN(9)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 gc_NKSSMX_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Private gc_NKSSMX_Inf As TYPE_NKSSMX
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	Structure TYPE_DB_JDNTHA_HAITA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public JDNNO() As Char '受注番号              0000000000
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '伝票管理NO.           0000000000  (ﾌﾟﾗｲﾏﾘｷｰ)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '初回登録ﾕｰｻﾞｰID       !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '初回登録ｸﾗｲｱﾝﾄID      !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char 'ユーザID(ﾊﾞｯﾁ)        !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)        !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
	End Structure
	Structure TYPE_DB_JDNTRA_HAITA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public JDNNO() As Char '受注番号              0000000000
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '伝票管理NO.           0000000000    (ﾌﾟﾗｲﾏﾘｷｰ)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public LINNO() As Char '行番号                000           (ﾌﾟﾗｲﾏﾘｷｰ)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public FOPEID() As Char '初回登録ﾕｰｻﾞｰID       !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public FCLTID() As Char '初回登録ｸﾗｲｱﾝﾄID      !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char 'ユーザID(ﾊﾞｯﾁ)        !@@@@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)        !@@@@@
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
	End Structure
	Private gc_JDNTHA_HAITA_Inf() As TYPE_DB_JDNTHA_HAITA
	Private gc_JDNTRA_HAITA_Inf() As TYPE_DB_JDNTRA_HAITA
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'// V1.20↓ ADD
	'前受区分
	Private Const pc_strMAEUKKB As String = "2" '前受区分（1：通常、2：前受）
	'// V1.20↑ ADD
	
	'支払区分
	Private Const pc_strSHAKB_HURI As String = "1" '振込
	Private Const pc_strSHAKB_TEG As String = "2" '手形
	Private Const pc_strSHAKB_HURI_OR_TEG As String = "3" '振込または手形
	Private Const pc_strSHAKB_HURI_AND_TEG As String = "4" '振込手形併用
	Private Const pc_strSHAKB_KIJZITU As String = "5" '期日振込
	Private Const pc_strSHAKB_FACTERING As String = "6" 'ファクタリング
	
	'取引区分コード(pc_strDKBSB_URK とリンク)
	Private Const pc_strDKBID_URK_GENKN As String = "01" '現金
	Private Const pc_strDKBID_URK_HURI As String = "02" '振込
	Private Const pc_strDKBID_URK_TEG As String = "03" '手形
	Private Const pc_strDKBID_URK_SOSAI As String = "04" '相殺
	Private Const pc_strDKBID_URK_NEBIK As String = "05" '値引
	Private Const pc_strDKBID_URK_TESU As String = "06" '手数
	Private Const pc_strDKBID_URK_HOKA As String = "07" '他
	Private Const pc_strDKBID_URK_HURIK As String = "08" '振込仮
	Private Const pc_strDKBID_URK_HNYU As String = "09" '本入金
	Private Const pc_strDKBID_URK_SYOH As String = "99" '消費
	
	'機能 ： 現在時間（ミリ秒含む）の取得
	Public Structure SYSTEMTIME
		Dim wYear As Short
		Dim wMonth As Short
		Dim wDayOfWeek As Short
		Dim wDay As Short
		Dim wHour As Short
		Dim wMinute As Short
		Dim wSecond As Short
		Dim wMilliseconds As Short
	End Structure
	
	'UPGRADE_WARNING: 構造体 SYSTEMTIME に、この Declare ステートメントの引数としてマーシャリング属性を渡す必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' をクリックしてください。
	Private Declare Sub GetLocalTime Lib "kernel32" (ByRef lpSystemTime As SYSTEMTIME)
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	Public pv_intTouraiKbn As Short '期日到来データかの区分(0:していない 1:手形でしている 2:振込仮でしている)
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
	Private Const pc_strKNJKOZ_TEG As String = "D" '手形
    '''' ADD 2009/12/28  FKS) T.Yamamoto    End

    '担当者マスタ検索戻り値
    'Public WLSTAN_RTNCODE As String     '担当者コード
    '2019/05/23  ADD START
    Public D0 = New ClsComn
    ' Public WLSTAN_TANTKDT As String
    'Public WLSTAN_TANCLAKB As String
    Public LV_Col_Order() As Integer
    '2019/05/23 ADD END

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function Ctl_Item_Change
    '   概要：  対象項目のCHANGEの制御
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽの場合
				'現在のﾃｷｽﾄ上の選択状態を取得
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/05/21 CHG START
                'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '2019/05/21 CHG END
				Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'現在の値を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_NUM
						'数値項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_DATE
						'日付項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_CODE, IN_TYP_STR
						'コード、文字項目
						Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
							'変更後の値変換
							Case IN_STR_TYP_N
								'全角の場合
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
										Wk_EditMoji = Wk_EditMoji & "　"
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
							Case Else
								'全角以外
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
										Wk_EditMoji = Wk_EditMoji & Space(2)
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
						End Select
					Case IN_TYP_YYYYMM
						'年月項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case IN_TYP_HHMM
						'時刻項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case Else
				End Select
				
				'編集後の文字を表示形式に変換
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
				
				'選択文字と入力文字の置き換え
				'文字設定
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'入力後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_GotFocus
	'   概要：  対象項目のGOTFOCUSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'ﾌｫｰｶｽを受け取れない場合
			'元の項目へﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			If pm_All.Dsp_Base.Head_Ok_Flg = False And pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL Then
				'元の項目へﾌｫｰｶｽ移動
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
				Exit Function
			End If
			
			'移動前と異なる場合のみ退避
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'移動後のｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyPress
	'   概要：  対象項目のKEYPRESSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'入力フラグ初期化
		Input_Flg = False
		'明細部再作成フラグ初期化
		Re_Body_Crt = False
		
		'以下の入力の場合、無視する
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'入力文字取得
		wk_Moji = Chr(pm_KeyAscii)
		
		'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'現在の値を取得
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				All_Sel_Flg = True
			End If
			
			'入力コード判定
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
				'入力可能文字の場合
				
				'入力可能な文字の場合、入力後処理、明細部再作成を行う
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str関数の文字変更を考慮
				pm_KeyAscii = Asc(wk_Moji)
				
				'日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
				'表示形式が決まっているため一つずつ入力させる
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'全選択時
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'詰文字が左詰以外の場合
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'編集後の文字を表示形式に変換
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'編集後のSelStartを決定
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'右端へ移動
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'詰文字が左詰以外の場合
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'削除後の文字置き換え
					'文字設定
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0
					
					'編集後のSelStartを決定
					'                pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart + 1
					'編集後のSelLengthを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart + 1, Wk_SelLength)
                    '2019/05/21 CHG END
					
					'数値項目特別処理
					If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'小数部があり小数桁数と設定値が同じ場合
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'数値項目以外
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'編集後の文字がMAXの場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '2019/05/21 CHG END
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					
				Else
					'部分選択もしくは、選択なし
					
					If Act_SelLength = 0 Then
						'選択なしの場合(挿入状態)
						'挿入部分の前の文字を取得
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 1 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'空白除去後の現在の文字がMAXの場合、オーバーフロー
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'一番右でオーバーフローした場合、次の項目へ
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'編集前の開始位置が一番右の場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'入力不可
									Beep()
								End If
							Else
								
								'編集後の移動先を判定
								If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
									'詰文字が左詰の場合
								Else
									'編集後のSelStartを決定
									If Act_SelStart + 1 > Len(Wk_CurMoji) Then
										'１つ右の位置が右端の場合
										Wk_SelStart = Len(Wk_CurMoji)
									Else
										'１つ右へ
										Wk_SelStart = Act_SelStart + 1
									End If
									'編集後のSelLengthを決定
									Wk_SelLength = 0
									
									'編集後のSelStartを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/05/21 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'編集後のSelLengthを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '2019/05/21 CHG END

								End If
								
								'入力不可
								Beep()
							End If
							
							'入力不可
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部で整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'編集後のSelStartを決定
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'１つ右の位置が右端の場合
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'１つ右へ
							Wk_SelStart = Act_SelStart + 1
						End If
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
						
						'編集後の移動先を判定
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'編集後の開始位置が一番右の場合
								'数値項目特別処理
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'小数部があり小数桁数と設定値が同じ場合
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'編集後の文字がMAXの場合
											'現在ﾌｫｰｶｽ位置から右へ移動
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'数値項目以外
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '2019/05/21 CHG END
								
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'一部選択
						'現在選択されている文字の１桁を取得
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'選択文字が空文字以外でかつ入力対象の文字以外の場合
							
							'入力不可
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 0 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部無しの場合
							'整数部ありで整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集前の開始位置が最後の文字以降の場合
							'編集後のSelStartを決定
							Wk_SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							Wk_SelLength = 0
						Else
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'入力可能な文字が１桁の場合
								'開始位置を一番右に設定
								'編集後のSelStartを決定
								Wk_SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								Wk_SelLength = 0
							End If
							
						End If
						
						'編集後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
						
						'編集後の移動先を判定
						If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集後の開始位置が最後の文字以降の場合
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'小数部があり小数桁数と設定値が同じ場合
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'数値項目以外
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'編集後の文字がMAXの場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'入力コード以外
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpaceキー
						pm_KeyAscii = 0
						Input_Flg = True
						
						'日付/年月/時刻の場合
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'削現在の開始位置から左へ移動し文字が入力対象かを判定
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'入力文字でない場合
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'編集後のSelLengthを決定
								Wk_SelLength = Act_SelLength
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '2019/05/21 CHG END
								
								'削除不可
								Exit Function
							Case Else
								
						End Select
						
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'開始位置が左の場合、終了
							If Act_SelStart = 0 Then
								'削除不可
								Exit Function
							End If
							
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'削除対象の文字が小数点の場合
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'削除後の桁数オーバーの場合
										'削除不可
										Exit Function
									End If
								End If
							End If
							
							'削除文字の判定
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'削除文字が入力対象の文字の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'削除文字が入力対象の文字の以外場合
								'そのまま
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'削除後のSelStartを決定
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'削除後に現在の開始位置からの文字が入力対象かを判定
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'入力文字でない場合、右へ移動
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'数値項目で未入力の場合は、一番右を開始位置に設定
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'編集後のSelLengthを決定
									Wk_SelLength = 0
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If Act_SelStart = 0 Then
								'開始位置が一番左の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
							Else
								'文字編集
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart - 1
							End If
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'編集後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END

                        'add start 20190826 kuwa
                    Case System.Windows.Forms.Keys.Return
                        pm_Move_Flg = True
                        pm_KeyAscii = 0
                        'add end 20190826 kuwa

                    Case Else
						pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'入力後処理
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'明細入力後の後処理
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_MouseDown
	'   概要：  対象項目のMOUSEDOWNの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			bolSameCtl = False
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'右クリックしたコントロールがアクティブなコントロールと一致
				'カーソル制御用テキストにフォーカスを一時的に退避
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'｢項目内容コピー｣判定
			FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'｢項目内容に貼り付け｣判定
			FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
                'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
                'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
                'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
                '2019/05/23 CHG START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                '2019/05/23 CHG END
                'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
                pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
			'以降の処理は行わない。
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_VS_Scrl_Change
	'   概要：  VS_ScrlのCHANGEの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'縦スクロールバーの値を最上明細ｲﾝﾃﾞｯｸｽに設定
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'画面ボディ情報の配列を再設定
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		
		'画面表示
		Call CF_Body_Dsp(pm_All)
		'コントロール制御
		Call F_Set_Body_Enable(pm_All)
		'チェック済みとする
		Call F_Set_Body_Bef_Chk_Value(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'入力可能な項目かどうかの判断を行う
					If CF_Set_Focus_Ctl(pm_Act_Dsp_Sub_Inf, pm_All) = True Then
						'選択状態の設定（初期選択）
						Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
						'項目色設定
						Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
					Else
						'同一項目の１つ前からENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
	'   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'画面明細の行と同一の明細をインデックスを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'移動先が同じ場合
				If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = True Then
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				Else
					'次のコントロールを探す
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
				
			Else
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'ロストフォーカス処理
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細初期化
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
            ' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御
            '2019/05/23 CHG START
            'Call CF_EXCTBZ_Unlock(pm_All)
            '2019/05/23 CHG END
            ' === 20130711 === INSERT E -
            'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
            '業務の初期値を編集
            Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			'明細項目制御
			Call F_Set_Body_Enable(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'ロストフォーカス処理
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細削除
		Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
        ' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の解除
        '2019/05/23 CHG START
        'Call CF_EXCTBZ_Unlock(pm_All)
        '2019/05/23 CHG END
        ' === 20130711 === INSERT E -
        'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
        '行を追加された後に
        '初期値を追加した行に対してループ内で１行ずつ行う
        'ここでの行は、Dsp_Body_Infの行！！
        For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		Next 
		
		'行Ｎｏ採番処理
		Call F_Edi_Saiban_No(pm_All)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'画面表示
		Call CF_Body_Dsp(pm_All)
		'明細項目制御
		Call F_Set_Body_Enable(pm_All)
		
		'元の画面の行に移動
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'フォーカス決定
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		
		'ロストフォーカス処理
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細挿入
		If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'対象行を画面に表示
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			'明細項目制御
			Call F_Set_Body_Enable(pm_All)
			
			'追加行に移動
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		' === 20130716 === INSERT S - FWEST)Koroyasu 排他制御
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim Row_Wk2 As Short
		' === 20130716 === INSERT E
		
		'ロストフォーカス処理
		Call CF_Ctl_Item_LostFocus_Dummy(pm_All)
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		' === 20130716 === INSERT S - FWEST)Koroyasu 排他制御
		Row_Wk2 = pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row
		' === 20130716 === INSERT E
		
		'共通の明細復元
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'行を追加された後に
			'初期値を追加した行に対してループ内で１行ずつ行う
			'ここでの行は、Dsp_Body_Infの行！！
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			Call CF_Body_Dsp(pm_All)
			'明細項目制御
			Call F_Set_Body_Enable(pm_All)
			
			' === 20130716 === UPDATE S - FWEST)Koroyasu 排他制御
			'        '元の画面の行に移動
			'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			'
			'        'フォーカス決定
			'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
			Chk_Move_Flg = True
			
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)).Detail.Bef_Chk_Value = ""
			
			'各項目のﾁｪｯｸﾙｰﾁﾝ
			Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)), CHK_FROM_BACK_PROCESS, Chk_Move_Flg, pm_All)
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
				
				'元の画面の行に移動
				Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
				
				'フォーカス決定
				Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
				'フォーカス決定
				Call CF_Ctl_MN_Cmn_DE_Focus(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_JDNNO(Row_Wk2).Tag)), Row_Wk, pm_All)
			End If
			' === 20130716 === UPDATE E
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Paste
	'   概要：  貼り付け
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
		'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		Clip_Value = My.Computer.Clipboard.GetText()
		'入力文字可能を取り出す
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'貼り付け内容がない場合、処理中断
		If Paste_Value = "" Then
			Exit Function
		End If
		
		'現在のﾃｷｽﾄ上の選択状態を取得
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/05/21 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '2019/05/21 CHG END
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'現在の値を取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'詰文字が左詰の場合
			
			'文字編集
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'編集後のSelStartを決定
			'右端へ移動
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'詰文字が左詰以外の場合
			
			If Act_SelLength = 0 Then
				'選択なしの場合(挿入状態)
				'文字編集
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'一部選択
				If Act_SelLength >= 2 Then
					'２文字以上選択している場合は
					'選択文字より後ろの文字もつける
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'１文字以下選択している場合は
					'選択文字以降は入れ換え
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'編集後のSelStartを決定
			'左端へ移動
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'日付の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'年月の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'時刻の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'編集後の文字を表示形式に変換
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
		
		'編集後のSelStartを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/05/21 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'編集後のSelLengthを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '2019/05/21 CHG END
		'入力後の後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Edi_Saiban_No
	'   概要：  全明細の行ＮＯを設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Bd_Index As Short
		
		Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(0).Tag)
		For Bd_Index = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【ＮＯ】１・２～を編集
			'画面ボディ情報(pm_All.Dsp_Body_Inf)に編集
			Call CF_Edi_Dsp_Body_Inf(Bd_Index, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DEF)
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Init_Clr_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'個別初期化
		'【ＮＯ】１・２～を編集
		Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf(pm_Bd_Index, pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		'【入金種別】
		Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【勘定口座】
		Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【入金額(円)】
		Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【入金額(外貨)】
		Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【銀行コード】
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【銀行名称】
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【受注番号】
		Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【支店名称】
		Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【決済日】
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【手形番号】
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【備考１】
		Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		
		'【備考２】
		Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
		'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		Call CF_Edi_Dsp_Body_Inf("", pm_All.Dsp_Sub_Inf(Wk_Index), pm_Bd_Index, pm_All, SET_FLG_DEF)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Input_Aft
	'   概要：  画面で項目入力された場合の後処理を行います
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'明細の再作成を行う
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'行を追加された後に
		'初期値を追加した行に対してループ内で１行ずつ行う
		'ここでの行は、Dsp_Body_Infの行！！
		For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
		Next 
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Befe_Focus
	'   概要：  前のフォーカス位置設定(LEFTなど)
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'次の項目を検索
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'フッタ部からボディ部へ移動する場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'ボディ部からヘッダ部へ移動する場合
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
					
					'画面の内容を退避
					Call CF_Body_Bkup(pm_All)
					'移動可能行を一番上に表示した場合の最上明細インデックスを設定
					pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'縦スクロールバーを設定
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					End If
					'画面ボディ情報の配列を再設定
					Call CF_Dell_Refresh_Body_Inf(pm_All)
					'画面表示
					Call CF_Body_Dsp(pm_All)
					
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
				End If
			End If
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'実行指定がある場合(基本あり)
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Next_Focus
	'   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		Dim intRet As Short
		Dim bolDspLstRow As Boolean
		
		bolDspLstRow = False
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'ボディ部
			'Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'最終準備行の場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'入力可能な最初の項目の場合
					'モードにより検索開始位置を決定
					Select Case pm_Mode
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN、KEYDOWNの場合
							'検索開始はフッタ部の最初の項目から
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHTの場合
							'割当ｲﾝﾃﾞｯｸｽ取得
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'最終準備行以外の場合
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'表示されている最終行の場合
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'入力可能な最後の項目の場合
						If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
							'最終準備行以外＆画面上の最終行＆最終項目
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
							
							'画面の内容を退避
							Call CF_Body_Bkup(pm_All)
							'移動可能行を一番下に表示した場合の最上明細インデックスを設定
							pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
							If pm_All.Bd_Vs_Scrl Is Nothing = False Then
								'縦スクロールバーを設定
								Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
							End If
							
							'画面ボディ情報の配列を再設定
							Call CF_Dell_Refresh_Body_Inf(pm_All)
							
							'画面表示
							Call CF_Body_Dsp(pm_All)
							'コントロール制御
							Call F_Set_Body_Enable(pm_All)
							
							'明細１番下行の入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
							If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
								'明細１番下行の最初の項目の一つ前から検索
								Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
								'画面上の最終表示明細の最終入力項目から
								'次の項目へ移動する場合！！
								bolDspLstRow = True
							Else
								'検索開始は対象の項目の次
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							End If
							
						Else
							'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						End If
					Else
						'入力可能な最後の項目以外の場合
						'検索開始は対象の項目の次
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'最終行以外場合
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'ボディ部以外
			'検索開始は対象の項目の次
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				If gv_bolInit = False Then
					Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				Else
					Rtn_Chk = CHK_OK
				End If
				If Rtn_Chk <> CHK_OK Then
					'チェックＮＧの場合
					'キーフラグを元に戻す
					gv_bolKeyFlg = False
					Exit For
				End If
			End If
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Or bolDspLstRow = True Then
					'以下のいずれかを満たす場合、フォーカス移動を行う。
					'
					'　①実行指定がある場合(基本あり)。
					'　②画面上の最終表示明細の最終入力項目から次の項目へ移動する場合。
					'
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				'画面上の最終表示明細の最終入力項目から次の項目へ移動する場合は、
				'移動フラグを立てない。
				'（Ctl_Item_KeyPressから再度本関数が呼ばれるのを回避するため）
				If bolDspLstRow = True Then
					pm_Move_Flg = False
				End If
				Exit For
			End If
		Next 
		
		'最終項目まで検索終了時
		If Index_Wk > pm_All.Dsp_Base.Item_Cnt Then
			'モードにより検索終了後の処理を決定
			Select Case pm_Mode
				Case NEXT_FOCUS_MODE_KEYRETURN
					'KEYRETURNの場合
					'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
					'移動先が検索不可の場合
					'更新前チェック⇒ＤＢ更新⇒初期化
					intRet = F_Ctl_Upd_Process(pm_All)
					If intRet = 0 Then
						'画面初期化
						Call F_Ctl_MN_APPENDC_Click(pm_All)
					End If
					'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
					pm_Move_Flg = True
					
				Case NEXT_FOCUS_MODE_KEYRIGHT
					'KEYRIGHTの場合
					'検索開始項目で選択状態が移動する
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_1)
				Case NEXT_FOCUS_MODE_KEYDOWN
					'KEYDOWNの場合
					
			End Select
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Left_Next_Focus
	'   概要：  Left押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'１文字目を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '2019/05/21 CHG END
				Else
					'詰文字が左詰以外の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'開始位置が一番左の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					
					'左に１桁ずつずらし入力可能な文字を検索
					Wk_SelStart = -1
					For Wk_Point = Act_SelStart - 1 To 0 Step -1
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
							Wk_SelStart = Wk_Point
							Exit For
						End If
					Next 
					
					If Wk_SelStart = -1 Then
						'選択可能な文字がない場合
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					Else
						'選択可能な文字がある場合
						If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
							'移動前の選択開始位置が一番右以外でかつ
							'選択文字数がない場合のみ、
							'同じ項目で移動する場合に選択文字数は継続する
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        '2019/05/21 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '2019/05/21 CHG END
					End If
					
				End If
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Right_Next_Focus
	'   概要：  Right押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/05/21 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '2019/05/21 CHG END
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'最終文字を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '2019/05/21 CHG END
				Else
					'詰文字が左詰以外の場合
					'１桁目を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '2019/05/21 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '2019/05/21 CHG END
				End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'選択開始位置が一番右の場合
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					'選択開始位置が一番右でない場合
					
					'１つ右の１桁を取得
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'次の１桁がない場合
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'一番右へ移動し選択なし状態に
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '2019/05/21 CHG END
						Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'一番右へ移動し選択なし状態に
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '2019/05/21 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '2019/05/21 CHG END
							Else
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						
						'右に１桁ずつずらし入力可能な文字を検索
						Next_SelStart = -1
						For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1
							
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
							
							Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
								Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
									'日付/年月/時刻項目の場合
									'入力可能文字＆と空白も移動可能
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
										Next_SelStart = Wk_Point
										Exit For
									End If
								Case Else
									'日付/年月/時刻項目以外の場合
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
										Next_SelStart = Wk_Point
										Exit For
									End If
									
							End Select
						Next 
						
						If Next_SelStart = -1 Then
							'選択可能な文字がない場合
							'ENTキー押下と同様に次の項目へ
							Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'選択可能な文字がある場合
							
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'同じ項目で移動する場合に選択文字数は継続する
								Wk_SelLength = 0
							Else
								Wk_SelLength = 1
							End If
							
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/05/21 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '2019/05/21 CHG END
						End If
					End If
				End If
				
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Down_Next_Focus
	'   概要：  Down押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
					'項目数を超えた場合
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番下に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細項目制御
						Call F_Set_Body_Enable(pm_All)
						'明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'入力可能な項目かどうかの判断を行う
								If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
									'移動無しで終了
									pm_Move_Flg = False
									Exit Do
								Else
									'同一項目の１つ前からENTキー押下と同様に次の項目へ
									Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
									Exit Do
								End If
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'明細部以外の場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Up_Next_Focus
	'   概要：  Up押下時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'マイナスの場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番上に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						Call CF_Body_Dsp(pm_All)
						'明細項目制御
						Call F_Set_Body_Enable(pm_All)
						'明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								'入力可能な項目かどうかの判断を行う
								If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
									pm_Move_Flg = False
									Exit Do
								Else
									'同一項目の１つ前からENTキー押下と同様に次の項目へ
									Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
									Exit Do
								End If
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'入力可能な最初の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'ヘッダ部の最後の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
					Else
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'明細部以外の場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Now_Dt As Date
		Dim Wk_Mode As Short
		'UPGRADE_WARNING: 構造体 Init_WK の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Init_WK As URKET52_TYPE_HEAD
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		Now_Dt = Now
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'個別初期化
			Select Case Index_Wk
				Case CShort(FR_SSSMAIN.HD_NYUDT.Tag)
					'入金日
					Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All,  , True)
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Index_Wk), False)
			End Select
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
		'全初期化の場合、画面情報保持用の構造体をクリアする
		If Wk_Mode = ITM_ALL_CLR Then
			Init_WK.NYUDT = GV_UNYDate
			'UPGRADE_WARNING: オブジェクト URKET52_HEAD_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URKET52_HEAD_Inf = Init_WK
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 1
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'画面ボディ情報
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'スクロール初期化
			'最大値
			Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最小値
			Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最大ｽｸﾛｰﾙ量
			Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Move_Qty, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'最小ｽｸﾛｰﾙ量
			Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'初期値
			Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All, SET_FLG_DEF)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'配列０の初期情報を対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'全体初期化の場合
			If Wk_Mode = BODY_ALL_CLR Then
				'全行初期状態
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'個別初期化
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
			'(対象の明細の番号情報だけが必要、)
			Wk_Index = CShort(FR_SSSMAIN.BD_LINNO(Index_Bd_Wk).Tag)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			'Dsp_Body_Infの行ＮＯに変換
			Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Dsp_Body_Infに値を初期値を設定
			Call F_Init_Dsp_Body(Wk_Row, pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'入金訂正対象にフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Action
	'   概要：  各チェック関数のチェック前の
	'　　　　　 チェック続行を判定
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'続行
		Rtn_Cd = CHK_KEEP
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'｢KEYRETURN｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'一括チェックなど｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'チェックを中断
			'チェック関数呼出元処理をクリア
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Msg_Move
	'   概要：  各チェック関数のチェック後の
	'　　　　　 メッセージ、ステータス、移動制御
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'メッセージ表示なし
		pm_Msg_Flg = False
		'移動可
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'チェックＯＫ
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'前回と同じチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = True
								Else
									'前回と異なるチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'前回と同じチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'前回と異なるチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＯＫ
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'チェックエラーとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
						Case CHK_WARN
							'警告時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = True
							'画面表示はクリアではなく、セットされるようにする
							pm_Err_Rtn = CHK_OK
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'｢KEYRETURN｣
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＮＧ
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
						Case CHK_WARN
							'警告時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = True
							'画面表示はクリアではなく、セットされるようにする
							pm_Err_Rtn = CHK_OK
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
					End Select
					
			End Select
			
		End If
		
		'チェック関数呼出元処理をクリア
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_DATNO
	'   概要：  見出：入金訂正対象のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_DATNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA() As TYPE_DB_UDNTRA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim Mst_Inf_BNKMTA As TYPE_DB_BNKMTA
		Dim strDATNO As String
		Dim intCnt As Short
		' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の追加
		Dim rResult As Short ' 処理チェック関数戻り値
		' === 20130711 === INSERT E
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_DATNO = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				strDATNO = Input_Value
				
				'売上見出トラン マスタチェック
				If DSPUDNTHA_SEARCH(strDATNO, Tbl_Inf_UDNTHA) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
					GoTo F_Chk_HD_DATNO_End
				End If
				
				If Tbl_Inf_UDNTHA.DATKB = gc_strDATKB_DEL Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_009 '削除済みデータ
					GoTo F_Chk_HD_DATNO_End
				End If
				
				'売上トラン マスタチェック
				If DSPUDNTRA_SEARCH(strDATNO, Tbl_Inf_UDNTRA) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
					GoTo F_Chk_HD_DATNO_End
				End If
				
				For intCnt = 1 To UBound(Tbl_Inf_UDNTRA)
					If Tbl_Inf_UDNTRA(intCnt).DATKB = gc_strDATKB_DEL Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_009 '削除済みデータ
						GoTo F_Chk_HD_DATNO_End
					End If
				Next intCnt
				
				'データを抽出→バッファに設定
				With URKET52_HEAD_Inf
					'読み込んだ売上見出トラン、売上トランを保持
					'UPGRADE_WARNING: オブジェクト URKET52_HEAD_Inf.UDNTHA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.UDNTHA = Tbl_Inf_UDNTHA
					.UDNTRA = VB6.CopyArray(Tbl_Inf_UDNTRA)
					
					'伝票管理番号
					.DATNO = Input_Value
					
					'入金区分
					.NYUKB = Tbl_Inf_UDNTHA.NYUCD
					
					'入金日
					.NYUDT = Tbl_Inf_UDNTHA.UDNDT
					
					'請求先
					.TOKCD = Tbl_Inf_UDNTHA.TOKSEICD
					If DSPTOKCD_SEARCH(.TOKCD, Mst_Inf_TOKMTA) = 0 Then
						'UPGRADE_WARNING: オブジェクト URKET52_HEAD_Inf.TOKMTA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.TOKMTA = Mst_Inf_TOKMTA
					Else
                        'Call DB_TOKMTA_Clear(.TOKMTA)
                    End If
					
					'通貨
					.TOKMTA.TUKKB = Tbl_Inf_UDNTHA.TUKKB
					'2009/09/30 ADD START RISE)MIYAJIMA
					ReDim .DKBID(UBound(Tbl_Inf_UDNTRA))
					ReDim .TEGKB(UBound(Tbl_Inf_UDNTRA))
					'2009/09/30 ADD E.N.D RISE)MIYAJIMA
				End With

                ' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の解除
                '排他解除
                '2019/05/23 CHG START
                'Call CF_Del_EXCTBZ2()
                CF_Unlock_EXCTBZ2()
                '2019/05/23 CHG END
                ' === 20130711 === INSERT E -

                '明細項目を取得
                For intCnt = 1 To UBound(Tbl_Inf_UDNTRA)
					With pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf
						.DKBID = Tbl_Inf_UDNTRA(intCnt).DKBID
						.DKBNM = Tbl_Inf_UDNTRA(intCnt).DKBNM
						
						'マスタチェック
						If SYSTBD_SEARCH(pc_strDKBSB_URK, .DKBID, Mst_Inf_SYSTBD) = 0 Then
							'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf.SYSTBD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SYSTBD = Mst_Inf_SYSTBD
						Else
							Call DB_SYSTBD_Clear(.SYSTBD)
						End If
						
						.KANKOZ = Tbl_Inf_UDNTRA(intCnt).HINSIRCD
						
						.NYUKN = Tbl_Inf_UDNTRA(intCnt).NYUKN
						.FNYUKN = Tbl_Inf_UDNTRA(intCnt).FNYUKN
						
						'２：振込 もしくは、３：手形 の場合は、銀行を読み込む
						If .DKBID = pc_strDKBID_URK_HURI Or .DKBID = pc_strDKBID_URK_TEG Then
							.BNKCD = Tbl_Inf_UDNTRA(intCnt).BNKCD
							If DSPBANK_SEARCH(.BNKCD, Mst_Inf_BNKMTA) = 0 Then
								.BNKNM = Mst_Inf_BNKMTA.BNKNM
								.STNNM = Mst_Inf_BNKMTA.STNNM
							Else
								.BNKNM = ""
								.STNNM = ""
							End If
						Else
							.BNKCD = ""
							.BNKNM = ""
							.STNNM = ""
						End If
						
						'2009/06/05 DEL START FKS)NAKATA
						'.JDNNO = Tbl_Inf_UDNTRA(intCnt).JDNNO
						'.JDNLINNO = Tbl_Inf_UDNTRA(intCnt).JDNLINNO
						'2009/06/05 DEL E.N.E FKS)NAKATA
						
						
						'2009/06/05 ADD START FKS)NAKATA
						.JDNNO = Left(Tbl_Inf_UDNTRA(intCnt).OKRJONO, 6)
						.JDNLINNO = Mid(Tbl_Inf_UDNTRA(intCnt).OKRJONO, 7, 3)
						' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の追加
						'排他チェック
						If Trim(.JDNNO) <> "" Then
                            '2019/05/23 CHG START
                            'rResult = CF_Chk_EXCTBZ(.JDNNO)
                            '2019/05/23 CHG END
                            Select Case rResult
								'正常
								Case 0
									
									'排他処理中
								Case 1
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = "2_EXCUPD" '他のプログラムで更新中のため、訂正できません。
									GoTo F_Chk_HD_DATNO_End
									
									'異常終了
								Case 9
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_004 '更新異常
									GoTo F_Chk_HD_DATNO_End
							End Select
						End If
						' === 20130711 === INSERT E -
						
						.OKRJONO = Tbl_Inf_UDNTRA(intCnt).OKRJONO
						'2009/06/05 ADD E.N.D FKS)NAKATA
						
						'2009/09/30 ADD START RISE)MIYAJIMA
						.DATNO = Tbl_Inf_UDNTRA(intCnt).DATNO
						.LINNO = Tbl_Inf_UDNTRA(intCnt).LINNO
						'2009/09/30 ADD E.N.D RISE)MIYAJIMA
						
						'2009/09/24 DEL START RISE)MIYAJIMA
						''2009/09/18 UPD START RISE)MIYAJIMA
						''                    .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
						'                        .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                    Else
						'                        If .DKBID = pc_strDKBID_URK_SOSAI Or _
						''                           .DKBID = pc_strDKBID_URK_NEBIK Or _
						''                           .DKBID = pc_strDKBID_URK_TESU Or _
						''                           .DKBID = pc_strDKBID_URK_HOKA Or _
						''                           .DKBID = pc_strDKBID_URK_SYOH Then
						'                            .TEGDT = "        "
						'                        Else
						'                            .TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'                        End If
						'                    End If
						''2009/09/18 UPD E.N.D RISE)MIYAJIMA
						'2009/09/24 DEL E.N.D RISE)MIYAJIMA
						'2009/09/24 ADD START RISE)MIYAJIMA
						.TEGDT = Tbl_Inf_UDNTRA(intCnt).TEGDT
						'2009/09/24 ADD E.N.D RISE)MIYAJIMA
						.TEGNO = Tbl_Inf_UDNTRA(intCnt).TEGNO
						
						.LINCMA = Tbl_Inf_UDNTRA(intCnt).LINCMA
						.LINCMB = Tbl_Inf_UDNTRA(intCnt).LINCMB
					End With
				Next intCnt
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
			End If
		End If
		
F_Chk_HD_DATNO_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_DATNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_DATNO_Inf
	'   概要：  見出：入金訂正対象による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_DATNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim intCnt As Short
		
		Dim blnUpd As Boolean
		Dim blnInputRow As Boolean
		'// V1.10↓ ADD
		Dim blnTEGDTERR As Boolean
		'// V1.10↑ ADD
		
		blnUpd = False
		
		'// V1.10↓ ADD
		blnTEGDTERR = False
		'// V1.10↑ ADD
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim strTEGDT As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		Dim strJdnNo As String
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				
				'【入金訂正対象】
				Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.DATNO, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【入金区分】
				Trg_Index = CShort(FR_SSSMAIN.HD_NYUKB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.NYUKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【入金日】
				Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.NYUDT, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【請求先コード】
				Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKCD, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【請求先名】
				Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKMTA.TOKRN, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				'【通貨】
				Trg_Index = CShort(FR_SSSMAIN.HD_TUKKB.Tag)
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(URKET52_HEAD_Inf.TOKMTA.TUKKB, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
				
				For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
					
					'画面の行
					Bd_Index = intCnt
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Wk_Row = intCnt
					
					blnInputRow = False
					
					'行の状態を設定
					If UBound(URKET52_HEAD_Inf.UDNTRA) >= Bd_Index Then
						'データのある行を入力済み状態にする
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_INPUT
						blnInputRow = True
					ElseIf (UBound(URKET52_HEAD_Inf.UDNTRA) + 1) = Bd_Index Then 
						'最後の行を設定
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW
					Else
						'空白行を設定
						pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_DEFAULT
					End If
					
					If blnInputRow = True Then
						'【入金種別(コード)】
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【入金種別(名称)】
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【勘定口座】
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)

                        '【入金額(円)】
                        Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)

                        '画面に編集
                        Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【入金額(外貨)】
						Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【銀行コード】
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【銀行名称】
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【受注番号】
						Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
						
						strJdnNo = Left(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO, 6) & Mid(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO, 2, 2)
						
						'2009/06/05 ADD START FKS)NAKATA
						'                    strJdnNo = Left$(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO, 6) _
						''                             & Mid$(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO, 8, 2)
						'2009/06/05 ADD E.N.D FKS)NAKATA
						
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(strJdnNo, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(strJdnNo, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【支店名称】
						Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【決済日】
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
						
						'2009/09/24 ADD START RISE)MIYAJIMA
						If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
							strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT
						Else
							If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_SOSAI Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_NEBIK Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_TESU Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_HOKA Or pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_SYOH Then
								strTEGDT = "        "
							Else
								strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT
							End If
						End If
						'2009/09/24 ADD E.N.D RISE)MIYAJIMA
						
						'2009/09/24 UPD START RISE)MIYAJIMA
						'                    '画面に編集
						'                    Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT _
						''                                            , pm_All.Dsp_Sub_Inf(Wk_Index) _
						''                                            , Wk_Row _
						''                                            , pm_All _
						''                                            , SET_FLG_DB)
						'
						'                    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						'                    Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT _
						''                                            , pm_All.Dsp_Sub_Inf(Wk_Index) _
						''                                            , Bd_Index _
						''                                            , pm_All _
						''                                            , SET_FLG_DB)
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(strTEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(strTEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						'2009/09/24 UPD E.N.D RISE)MIYAJIMA
						
						'【手形番号】
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【備考１】
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						
						'【備考２】
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
						
						'画面に編集
						Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
						
						'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
						Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						'// V1.10↓ ADD
						If Trim(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT) <> "" Then
							If GV_UNYDate > pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT Then
								blnTEGDTERR = True
							End If
						End If
						'// V1.10↑ ADD
					Else
						'【入金種別(コード)】
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【入金種別(名称)】
						Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【勘定口座】
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【入金額(円)】
						Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【入金額(外貨)】
						Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【銀行コード】
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【銀行名称】
						Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【受注番号】
						Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【支店名称】
						Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【決済日】
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【手形番号】
						Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【備考１】
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'【備考２】
						Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
						Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
						
						'情報の初期化
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf '１行目のデータ
							.DKBID = ""
							.DKBNM = ""
							.KANKOZ = ""
							.NYUKN = 0
							.FNYUKN = 0
							.BNKCD = ""
							.BNKNM = ""
							.JDNNO = ""
							.JDNLINNO = ""
							.STNNM = ""
							.TEGDT = ""
							.TEGNO = ""
							.LINCMA = ""
							.LINCMB = ""
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = ""
							'2009/06/05 ADD E.N.D FKS)NAKATA
							Call DB_SYSTBD_Clear(.SYSTBD)
						End With
					End If
				Next intCnt
				
				blnUpd = True
				'// V1.10↓ ADD
				If blnTEGDTERR = True Then
					'2009/09/24 UPD START RISE)MIYAJIMA
					'                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_030, pm_All)
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_035, pm_All)
					'2009/09/24 UPD E.N.D RISE)MIYAJIMA
				End If
				'// V1.10↑ ADD
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'【入金訂正対象】
			Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【入金区分】
			Trg_Index = CShort(FR_SSSMAIN.HD_NYUKB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【入金日】
			Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(GV_UNYDate, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			'【請求先コード】
			Trg_Index = CShort(FR_SSSMAIN.HD_TOKCD.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【請求先名】
			Trg_Index = CShort(FR_SSSMAIN.HD_TOKRN.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'【通貨区分】
			Trg_Index = CShort(FR_SSSMAIN.HD_TUKKB.Tag)
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
			
			'情報の初期化
			URKET52_HEAD_Inf.DATNO = ""
			URKET52_HEAD_Inf.NYUKB = ""
			URKET52_HEAD_Inf.NYUDT = GV_UNYDate
			URKET52_HEAD_Inf.TOKCD = ""
            'Call DB_TOKMTA_Clear(URKET52_HEAD_Inf.TOKMTA)

            '明細をすべて削除する
            For Wk_Row = pm_All.Dsp_Base.Max_Body_Cnt To 1 Step -1
				If Wk_Row = 1 Then
					'１行目は、項目をクリア
					
					'【入金種別(コード)】
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【入金種別(名称)】
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【勘定口座】
					Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【入金額(円)】
					Wk_Index = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【入金額(外貨)】
					Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【銀行コード】
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【銀行名称】
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【受注番号】
					Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【支店名称】
					Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【決済日】
					Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【手形番号】
					Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【備考１】
					Wk_Index = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					'【備考２】
					Wk_Index = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
					Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All) '画面クリア
					
					Bd_Index = Wk_Row
					
					'情報の初期化
					With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf '１行目のデータ
						.DKBID = ""
						.DKBNM = ""
						.KANKOZ = ""
						.NYUKN = 0
						.FNYUKN = 0
						.BNKCD = ""
						.BNKNM = ""
						.JDNNO = ""
						.JDNLINNO = ""
						.STNNM = ""
						.TEGDT = ""
						.TEGNO = ""
						.LINCMA = ""
						.LINCMB = ""
						'2009/06/05 ADD START FKS)NAKATA
						.OKRJONO = ""
						'2009/06/05 ADD E.N.D FKS)NAKATA
						Call DB_SYSTBD_Clear(.SYSTBD)
					End With
					
					'行を状態変更
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW
				Else
					'１行目以外は、行削除する
					Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(Wk_Row).Tag)
					If CF_Jge_Enabled_MN_DeleteDE(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All) = True Then
						Call CF_Ctl_MN_DeleteDE(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					End If
					
					'色が残ってしまう場合があるので、対処
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
					
					'行を状態変更
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_DEFAULT
				End If
			Next 
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		If blnUpd = True Then
			'** ｺﾝﾄﾛｰﾙ制御 **
			'【受注番号】
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				'前受入金
				Call F_Util_JDNNO_SetOnOff(True, pm_All)
			Else
				'入金
				Call F_Util_JDNNO_SetOnOff(False, pm_All)
				Call F_Util_JDNNO_Clear(pm_All)
			End If
			
			'【入金額(外貨)】
			If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				Call F_Util_FNYUKN_SetOnOff(True, pm_All) '海外
			Else
				Call F_Util_FNYUKN_SetOnOff(False, pm_All) '国内か、エラー
				Call F_Util_FNYUKN_Clear(pm_All)
			End If
			Call F_Util_FNYUKN_Sum(pm_All)
			
			'【入金額(円)】
			Call F_Util_NYUKN_Sum(pm_All)
			
			'入金種別に応じて行の有効・無効を変更する
			Call F_Util_DKBID_SwitchOnOff(1, pm_All)
			Call F_Util_DKBID_SwitchOnOff(2, pm_All)
			Call F_Util_DKBID_SwitchOnOff(3, pm_All)
			Call F_Util_DKBID_SwitchOnOff(4, pm_All)
			Call F_Util_DKBID_SwitchOnOff(5, pm_All)
			Call F_Util_DKBID_SwitchOnOff(6, pm_All)
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_NYUKB
	'   概要：  見出：入金区分のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_NYUKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_NYUKB = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.NYUKB = ""

        '未入力チェック
        'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
            '2019/06/06 ADD START
            Retn_Code = CHK_ERR_NOT_INPUT
            Err_Cd = ""
            '2019/06/06 ADD END
        Else
            '未入力以外のチェック済
            pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True

            '基礎チェック
            If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
                Retn_Code = CHK_ERR_ELSE
                Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
            Else
                '2019/06/06 ADD START
                Select Case CShort(Input_Value)
                    Case 1, 2 '１：入金、２：前受入金
                        '2019/06/06 ADD END
                        'ＯＫ
                        Retn_Code = CHK_OK
                        pm_Chk_Move = True

                        URKET52_HEAD_Inf.NYUKB = Input_Value
                        '2019/06/06 ADD START
                    Case Else
                        Retn_Code = CHK_ERR_ELSE
                        'Err_Cd = gc_strMsgURKET51_E_011 '該当データなし
                        pm_Chk_Move = True
                End Select
                '2019/06/06 ADD END
            End If
		End If
		
F_Chk_HD_NYUKB_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_NYUKB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_NYUKB_Inf
	'   概要：  見出：入金区分による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_NYUKB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_NYUDT
	'   概要：  見出：入金日のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_NYUDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'2009/09/23 DEL START RISE)MIYAJIMA
		'    'チェック実行判定
		'    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		'    If Rtn_Cd = CHK_STOP Then
		'        '中断の場合
		'        F_Chk_HD_NYUDT = Retn_Code
		'        Exit Function
		'    End If
		'2009/09/23 DEL E.N.D RISE)MIYAJIMA
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.NYUDT = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			Err_Cd = ""
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_008 '入力範囲外
			Else
				'システム日付より未来はエラー
				If Input_Value > GV_UNYDate Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_015
				Else
					'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
					'月次本締日の条件撤廃
					'                '前回月次更新実行日より過去はエラー
					'                If Trim(Input_Value) <= Trim(pv_strMONUPDDT) Then
					'前回経理締実行日より過去はエラー
					If Trim(Input_Value) <= Trim(pv_strSMAUPDDT) Then
						'''' UPD 2011/01/14  FKS) T.Yamamoto    End
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_016
                        GoTo F_Chk_HD_NYUDT_End
                    End If
					'2009/09/03 ADD START RISE)MIYAJIMA
					'画面.入金日 <= 前回請求日の場合はエラーを表示する
					If Trim(Input_Value) <= Trim(URKET52_HEAD_Inf.TOKMTA.TOKSMEDT) Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_033
						GoTo F_Chk_HD_NYUDT_End
					End If
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'''' ADD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
					'締めを跨いでの日付はエラー
					date1 = VB6.Format(CNV_DATE(Left(pv_strSMAUPDDT, 6) & "01"), "YYYY/MM/DD")
					date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
					date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
					If Trim(Input_Value) > DeCNV_DATE(date3) Then
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_042
						GoTo F_Chk_HD_NYUDT_End
					End If
					'''' ADD 2011/01/14  FKS) T.Yamamoto    End
					
					'ＯＫ
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					URKET52_HEAD_Inf.NYUDT = Input_Value
				End If
			End If
		End If
		
F_Chk_HD_NYUDT_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_NYUDT = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_NYUDT_Inf
	'   概要：  見出：入金日による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_NYUDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_TOKCD
	'   概要：  見出：請求先コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TOKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		'2009/09/03 ADD START RISE)MIYAJIMA
		Dim strTANCLAKB As String
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_TOKCD = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.TOKCD = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'2009/09/03 ADD START RISE)MIYAJIMA
				'営業担当フラグを取得
				Call F_Util_GET_TANMTA_TANCLAKB(URKET52_HEAD_Inf.TOKMTA.TANCD, strTANCLAKB)
				If strTANCLAKB <> "1" Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_034 '請求先担当者が営業でありません
					GoTo F_Chk_HD_TOKCD_End
				End If
				'画面.入金日 <= 前回請求日の場合はエラーを表示する
				If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(URKET52_HEAD_Inf.TOKMTA.TOKSMEDT) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_033
					GoTo F_Chk_HD_TOKCD_End
				End If
				'2009/09/03 ADD E.N.D RISE)MIYAJIMA
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKCD = Input_Value
			End If
		End If
		
F_Chk_HD_TOKCD_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TOKCD = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_TOKCD_Inf
	'   概要：  見出：請求先コードによる画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TOKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_TOKRN
	'   概要：  見出：請求先名称のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TOKRN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_TOKRN = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.TOKMTA.TOKRN = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKMTA.TOKRN = Input_Value
			End If
		End If
		
F_Chk_HD_TOKRN_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TOKRN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_TOKRN_Inf
	'   概要：  見出：請求先名称による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TOKRN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_TUKKB
	'   概要：  見出：通貨のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_TUKKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_TUKKB = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.TOKMTA.TUKKB = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				URKET52_HEAD_Inf.TOKMTA.TUKKB = Input_Value
			End If
		End If
		
F_Chk_HD_TUKKB_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_TUKKB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_TUKKB_Inf
	'   概要：  見出：通貨による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_TUKKB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KNJKOZ
	'   概要：  見出：勘定口座のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KNJKOZ(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'2009/09/03 DEL START RISE)MIYAJIMA
		'    'チェック実行判定
		'    Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		'    If Rtn_Cd = CHK_STOP Then
		'        '中断の場合
		'        F_Chk_HD_KNJKOZ = Retn_Code
		'        Exit Function
		'    End If
		'2009/09/03 DEL E.N.D RISE)MIYAJIMA
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'情報の初期化
		URKET52_HEAD_Inf.KNJKOZ = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'マスタチェック
				If F_Util_KNJKOZ_Search(Input_Value, Mst_Inf) = 0 Then
					'論理削除チェック
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '削除済みデータ
						Case Else
							'ＯＫ
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							URKET52_HEAD_Inf.KNJKOZ = Input_Value
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
				End If
			End If
		End If
		
F_Chk_HD_KNJKOZ_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_HD_KNJKOZ = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_KNJKOZ_Inf
	'   概要：  見出：勘定口座による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_KNJKOZ_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Bd_Index As Short
		Dim Wk_Row As Short
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				
				If Trim(URKET52_HEAD_Inf.KNJKOZ) <> "" Then
					For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
						'すでに入力されている明細：勘定口座を書き換える
						
						'【勘定口座】
						Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(intCnt).Tag)
						
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Wk_Index))) <> "" Then
							'If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KANKOZ) <> "" Then
							pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KANKOZ = URKET52_HEAD_Inf.KNJKOZ
							
							'画面の行
							Wk_Row = intCnt
							
							'pm_All.Dsp_Body_Infの行ＮＯを取得
							Bd_Index = intCnt
							
							'画面に編集
							Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
							'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
							Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
						End If
					Next intCnt
				End If
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_DKBID
	'   概要：  明細：入金種別コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DKBID(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim Mst_Inf_BNKMTA As TYPE_DB_BNKMTA
		Dim strTOKCD As String
		Dim dteNYUDT As Date
		
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
		Dim strKNJKOZ As String
		Dim Mst_Inf_MEIMTA As TYPE_DB_MEIMTA
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_DKBID = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
		strKNJKOZ = ""
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'画面の行
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
			.DKBID = ""
			.DKBNM = ""
			.BNKCD = ""
			.BNKNM = ""
			.STNNM = ""
			.TEGDT = ""
			.TEGNO = ""
			Call DB_SYSTBD_Clear(.SYSTBD)
		End With
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'マスタチェック
				If SYSTBD_SEARCH(pc_strDKBSB_URK, Input_Value, Mst_Inf_SYSTBD) = 0 Then
					'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
					'勘定口座が指定されている場合、名称マスタを検索
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strKNJKOZ = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_KANKOZ(Bd_Index).Tag))))
					If strKNJKOZ <> "" Then
						If F_Util_KNJKOZ_Search(strKNJKOZ, Mst_Inf_MEIMTA) = 0 Then
							'手形の勘定口座が指定されている場合
							If Trim(Mst_Inf_MEIMTA.MEINMC) = pc_strKNJKOZ_TEG Then
								'３：手形以外の場合、エラー
								If Input_Value <> pc_strDKBID_URK_TEG Then
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_041 '手形の勘定口座が指定されています。
									GoTo F_Chk_BD_DKBID_End
								End If
								'手形の勘定口座以外が指定されている場合
							Else
								'３：手形の場合、エラー
								If Input_Value = pc_strDKBID_URK_TEG Then
									Retn_Code = CHK_ERR_ELSE
									Err_Cd = gc_strMsgURKET52_E_040 '勘定口座の種別が手形ではありません。
									GoTo F_Chk_BD_DKBID_End
								End If
							End If
						Else
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
							GoTo F_Chk_BD_DKBID_End
						End If
					End If
					'''' ADD 2009/12/28  FKS) T.Yamamoto    End
					
					'ＯＫ
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
						.DKBID = Input_Value
						.DKBNM = Mst_Inf_SYSTBD.DKBNM
						If Trim(URKET52_HEAD_Inf.KNJKOZ) <> "" Then
							.KANKOZ = URKET52_HEAD_Inf.KNJKOZ
						End If
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Bus_Inf.SYSTBD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SYSTBD = Mst_Inf_SYSTBD
					End With
					
					'// V1.20↓ UPD
					'                '２：振込 もしくは、３：手形 の場合は、銀行を読み込む
					'                If Input_Value = pc_strDKBID_URK_HURI Or Input_Value = pc_strDKBID_URK_TEG Then
					'２：振込 の場合は、銀行を読み込む
					If Input_Value = pc_strDKBID_URK_HURI Then
						'// V1.20↑ UPD
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						strTOKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_TOKCD.Tag)))
						
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
							.BNKCD = URKET52_HEAD_Inf.TOKMTA.BNKCD
						End With
						
						'銀行を検索し、名称を取得
						If DSPBANK_SEARCH_ALL(URKET52_HEAD_Inf.TOKMTA.BNKCD, Mst_Inf_BNKMTA) = 0 Then
							With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
								.BNKNM = Mst_Inf_BNKMTA.BNKNM
								.STNNM = Mst_Inf_BNKMTA.STNNM
							End With
						End If
					End If
					
					'３：手形 の場合は、決済日を読み込む
					If Input_Value = pc_strDKBID_URK_TEG Then
						'入力された入金日＋得意先．サイトの日分加算した日付
						dteNYUDT = CDate(VB6.Format(URKET52_HEAD_Inf.NYUDT, "@@@@/@@/@@"))
						
						dteNYUDT = DateSerial(Year(dteNYUDT), Month(dteNYUDT), VB.Day(dteNYUDT) + URKET52_HEAD_Inf.TOKMTA.NYUDD)
						
						With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
							.TEGDT = VB6.Format(dteNYUDT, "yyyymmdd")
						End With
					End If
					
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Or pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF Then
						'変更されていない場合は、処理を行わない
						'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
							GoTo F_Chk_BD_DKBID_End
						End If
					End If
					
					'入金種別のダミーフラグ１と得意先マスタ(＝請求先)．支払区分の関連
					Select Case URKET52_HEAD_Inf.TOKMTA.SHAKB
						Case pc_strSHAKB_HURI, pc_strSHAKB_TEG, pc_strSHAKB_HURI_OR_TEG, pc_strSHAKB_HURI_AND_TEG
							'2009/09/18 ADD START RISE)MIYAJIMA
							If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_HURIK Then
								Retn_Code = CHK_ERR_ELSE 'エラー
								'2009/09/23 UPD START RISE)MIYAJIMA
								'                            Err_Cd = gc_strMsgURKET52_E_017
								Err_Cd = gc_strMsgURKET52_E_037
								'2009/09/23 UPD E.N.D RISE)MIYAJIMA
								GoTo F_Chk_BD_DKBID_End
							End If
							'2009/09/18 ADD E.N.D RISE)MIYAJIMA
							'得意先マスタ．支払区分＝１：振込 or ２：手形 or ３：振込または手形 or ４：振込手形併用
							If Trim(Mst_Inf_SYSTBD.DKBFLA) <> "" Then
								'エラー
								'2018/11/08 ADD START <C2-20170130-01> CIS)山口
								'                            Retn_Code = CHK_ERR_ELSE
								Retn_Code = CHK_WARN 'ワーニング
								'2018/11/08 ADD END <C2-20170130-01> CIS)山口
								Err_Cd = gc_strMsgURKET52_E_017
								GoTo F_Chk_BD_DKBID_End
							End If
							
						Case pc_strSHAKB_KIJZITU, pc_strSHAKB_FACTERING
							'得意先マスタ．支払区分＝５：期日振込 or ６：ファクタリング
							
							'UPGRADE_WARNING: オブジェクト SSSVal(Mst_Inf_SYSTBD.DKBFLA) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If SSSVal(Mst_Inf_SYSTBD.DKBFLA) < 1 Then
								'エラー
								Retn_Code = CHK_WARN 'ワーニング
								Err_Cd = gc_strMsgURKET52_E_017
								GoTo F_Chk_BD_DKBID_End
							End If
							
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
				End If
			End If
		End If
		
F_Chk_BD_DKBID_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_DKBID = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_DKBID_Inf
	'   概要：  明細：入金種別コードによる画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_DKBID_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		'画面の行
		Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				
				'【入金種別(名称)】
				Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【勘定口座】
				Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【銀行コード】
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKCD, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【銀行名称】
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【支店名称】
				Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【決済日】
				Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【手形番号】
				Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'** ｺﾝﾄﾛｰﾙ制御 **
				Call F_Util_DKBID_SwitchOnOff(Wk_Row, pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			
			'【入金種別(名称)】
			Wk_Index = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【銀行コード】
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【銀行名称】
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【支店名称】
			Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【決済日】
			Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【手形番号】
			Wk_Index = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'** ｺﾝﾄﾛｰﾙ制御 **
			Call F_Util_DKBID_SwitchOnOff(Wk_Row, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_DKBNM
	'   概要：  明細：入金種別名称のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DKBNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_DKBNM = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBNM = Input_Value
			End If
		End If
		
F_Chk_BD_DKBNM_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_DKBNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_DKBNM_Inf
	'   概要：  明細：入金種別名称による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_DKBNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_KANKOZ
	'   概要：  明細：勘定口座のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_KANKOZ(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		Dim Mst_Inf As TYPE_DB_MEIMTA
		
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
		Dim strDKBID As String
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_KANKOZ = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
		strDKBID = ""
		'''' ADD 2009/12/28  FKS) T.Yamamoto    End
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'マスタチェック
				If F_Util_KNJKOZ_Search(Input_Value, Mst_Inf) = 0 Then
					'論理削除チェック
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '削除済みデータ
						Case Else
							'''' ADD 2009/12/28  FKS) T.Yamamoto    Start    連絡票№767
							'入金種別が指定されている場合
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strDKBID = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_DKBID(Bd_Index).Tag))))
							If strDKBID <> "" Then
								'入金種別＝３：手形の場合
								If strDKBID = pc_strDKBID_URK_TEG Then
									'手形の勘定口座以外の場合エラー
									If Trim(Mst_Inf.MEINMC) <> pc_strKNJKOZ_TEG Then
										Retn_Code = CHK_ERR_ELSE
										Err_Cd = gc_strMsgURKET52_E_040 '勘定口座の種別が手形ではありません。
										GoTo F_Chk_BD_KANKOZ_End
									End If
									'入金種別<>３：手形の場合
								Else
									'手形の勘定口座の場合エラー
									If Trim(Mst_Inf.MEINMC) = pc_strKNJKOZ_TEG Then
										Retn_Code = CHK_ERR_ELSE
										Err_Cd = gc_strMsgURKET52_E_041 '手形の勘定口座が指定されています。
										GoTo F_Chk_BD_KANKOZ_End
									End If
								End If
							End If
							'''' ADD 2009/12/28  FKS) T.Yamamoto    End
							
							'ＯＫ
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.KANKOZ = Input_Value
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
				End If
			End If
		End If
		
F_Chk_BD_KANKOZ_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_KANKOZ = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_KANKOZ_Inf
	'   概要：  明細：勘定口座による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_KANKOZ_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_NYUKN
	'   概要：  明細：入金額(円)のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_NYUKN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_NYUKN = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN = 0
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.NYUKN = CDec(Input_Value)
			End If
		End If
		
F_Chk_BD_NYUKN_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_NYUKN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_NYUKN_Inf
	'   概要：  明細：入金額(円)による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_NYUKN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				Call F_Util_NYUKN_Sum(pm_All)
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Call F_Util_NYUKN_Sum(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_FNYUKN
	'   概要：  明細：入金額(外貨)のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_FNYUKN(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_FNYUKN = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN = 0
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FNYUKN = CDbl(Input_Value)
			End If
		End If
		
F_Chk_BD_FNYUKN_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_FNYUKN = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_FNYUKN_Inf
	'   概要：  明細：入金額(外貨)による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_FNYUKN_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				Call F_Util_FNYUKN_Sum(pm_All)
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Call F_Util_FNYUKN_Sum(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_BNKCD
	'   概要：  明細：銀行コードのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_BNKCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		Dim strBNKCD As String
		Dim Mst_Inf As TYPE_DB_BNKMTA
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_BNKCD = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'画面の行
		Wk_Row = pm_Chk_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
			.BNKCD = ""
			.BNKNM = ""
			.STNNM = ""
		End With
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strBNKCD = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_BNKCD(Wk_Row).Tag)))
				
				'マスタチェック
				If DSPBANK_SEARCH_ALL(strBNKCD, Mst_Inf) = 0 Then
					'論理削除チェック
					Select Case True
						Case Mst_Inf.DATKB = gc_strDATKB_DEL
							Retn_Code = CHK_ERR_ELSE
							Err_Cd = gc_strMsgURKET52_E_009 '削除済みデータ
						Case Else
							'ＯＫ
							Retn_Code = CHK_OK
							pm_Chk_Move = True
							
							With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
								.BNKCD = Mst_Inf.BNKCD
								.BNKNM = Mst_Inf.BNKNM
								.STNNM = Mst_Inf.STNNM
							End With
					End Select
				Else
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
				End If
			End If
		End If
		
F_Chk_BD_BNKCD_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_BNKCD = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_BNKCD_Inf
	'   概要：  明細：銀行コードによる画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_BNKCD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		'画面の行
		Wk_Row = pm_Dsp_Sub_Inf.Detail.Body_Index
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				
				'【銀行名称】
				Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'【支店名称】
				Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
				
				'画面に編集
				Call CF_Edi_Dsp_Body_Item(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All, SET_FLG_DB)
				
				'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
				Call CF_Edi_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM, pm_All.Dsp_Sub_Inf(Wk_Index), Bd_Index, pm_All, SET_FLG_DB)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			
			'【銀行名称】
			Wk_Index = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'【支店名称】
			Wk_Index = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_BNKNM
	'   概要：  明細：銀行名称のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_BNKNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_BNKNM = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.BNKNM = Input_Value
			End If
		End If
		
F_Chk_BD_BNKNM_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_BNKNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_BNKNM_Inf
	'   概要：  明細：銀行名称による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_BNKNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_JDNNO
	'   概要：  明細：受注番号のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_JDNNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
		Dim intRet As Short
		'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の追加
		Dim rResult As Short ' 処理チェック関数戻り値
		' === 20130711 === INSERT E
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_JDNNO = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO = ""
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO = ""
		
		'2009/06/05 ADD START FKS)NAKATA
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO = ""
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'入力された受注番号を受注番号と受注行番号に分割
				strJdnNo = Left(Input_Value, 6) '入力の６桁を取得
				strJDNLINNO = Mid(Input_Value, 7, 2) '入力の６＋１桁目から２桁を取得
				strJDNLINNO = "0" & strJDNLINNO '３桁にそろえる（３桁ゼロ埋めデータのため）
				
				'''' UPD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
				'            If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
				'                Retn_Code = CHK_ERR_ELSE
				'                Err_Cd = gc_strMsgURKET52_E_011          '該当データなし
				'                GoTo F_Chk_BD_JDNNO_End
				'            End If
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intRet = F_Util_CheckJDNNO(strJdnNo, strJDNLINNO, CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_NYUDT.Tag))))
				If intRet <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Select Case intRet
						Case 1
							Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
						Case 2
							Err_Cd = gc_strMsgURKET52_E_039 '受注伝票日付の年月＞画面.入金日の年月
					End Select
					GoTo F_Chk_BD_JDNNO_End
				End If
                '''' UPD 2009/11/10  FKS) T.Yamamoto    End

                ' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の追加
                '排他チェック
                '2019/05/23 CHG START
                'rResult = CF_Chk_EXCTBZ(strJdnNo)
                '2019/05/23 CHG END
                Select Case rResult
					'正常
					Case 0
						
						'排他処理中
					Case 1
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = "2_EXCADD" '他のプログラムで更新中のため、登録できません。
						GoTo F_Chk_BD_JDNNO_End
						
						'異常終了
					Case 9
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_004 '更新異常
						GoTo F_Chk_BD_JDNNO_End
				End Select
				' === 20130711 === INSERT E -
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNNO = strJdnNo
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.JDNLINNO = strJDNLINNO
				
				'2009/06/05 ADD START FKS)NAKATA
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.OKRJONO = Trim(strJdnNo) & Trim(strJDNLINNO)
				'2009/06/05 ADD E.N.D FKS)NAKATA
				
				
			End If
		End If

F_Chk_BD_JDNNO_End:
        ' === 20130716 === INSERT S - FWEST)Koroyasu 排他制御の追加
        '2019/05/23 CHG START
        'Call CF_EXCTBZ_Unlock(pm_All)
        '2019/05/23 CHG END
        ' === 20130716 === INSERT E

        '戻値、メッセージ、ステータス、移動制御
        Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_JDNNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_JDNNO_Inf
	'   概要：  明細：受注番号による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_JDNNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_STNNM
	'   概要：  明細：支店名称のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_STNNM(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_STNNM = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.STNNM = Input_Value
			End If
		End If
		
F_Chk_BD_STNNM_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_STNNM = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_STNNM_Inf
	'   概要：  明細：支店名称による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_STNNM_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_TEGDT
	'   概要：  明細：決済日のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_TEGDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_TEGDT = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_008 '入力範囲外
			Else
				'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
				'月次本締日の条件撤廃
				'            '前回月次更新実行日より過去はエラー
				'            If Trim(Input_Value) <= Trim(pv_strMONUPDDT) Then
				'前回経理締実行日より過去はエラー
				If Trim(Input_Value) <= Trim(pv_strSMAUPDDT) Then
					'''' UPD 2011/01/14  FKS) T.Yamamoto    End
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_016
					GoTo F_Chk_BD_TEGDT_End
				End If
				'2009/09/03 ADD START RISE)MIYAJIMA
				'画面.入金日 > 画面.決済日の場合はエラーを表示する
				If Trim(URKET52_HEAD_Inf.NYUDT) > Trim(Input_Value) Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgURKET52_E_008
					GoTo F_Chk_BD_TEGDT_End
				End If
				'運用日テーブル.運用日付（UNYMTA）> 画面.決済日の場合
				If Trim(GV_UNYDate) > Trim(Input_Value) Then
					'種別は現金以外はエラー表示する
					'2009/09/18 ADD START RISE)MIYAJIMA
					'                If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID = pc_strDKBID_URK_TEG Then
					If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.DKBID <> pc_strDKBID_URK_GENKN Then
						'2009/09/18 ADD E.N.D RISE)MIYAJIMA
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgURKET52_E_035
						GoTo F_Chk_BD_TEGDT_End
					End If
				End If
				'2009/09/03 ADD E.N.D RISE)MIYAJIMA
				
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGDT = Input_Value
			End If
		End If
		
F_Chk_BD_TEGDT_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_TEGDT = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_TEGDT_Inf
	'   概要：  明細：決済日による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_TEGDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_TEGNO
	'   概要：  明細：手形番号のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_TEGNO(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_TEGNO = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.TEGNO = Input_Value
			End If
		End If
		
F_Chk_BD_TEGNO_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_TEGNO = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_TEGNO_Inf
	'   概要：  明細：手形番号による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_TEGNO_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_LINCMA
	'   概要：  明細：備考１のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_LINCMA(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_LINCMA = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMA = Input_Value
			End If
		End If
		
F_Chk_BD_LINCMA_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_LINCMA = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_LINCMA_Inf
	'   概要：  明細：備考１による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_LINCMA_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_LINCMB
	'   概要：  明細：備考２のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_LINCMB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		Dim Bd_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_LINCMB = Retn_Code
			Exit Function
		End If
		
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Chk_Dsp_Sub_Inf, pm_All)
		
		'情報の初期化
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB = ""
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgURKET52_E_007 '入力範囲外
			Else
				'ＯＫ
				Retn_Code = CHK_OK
				pm_Chk_Move = True
				
				pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.LINCMB = Input_Value
			End If
		End If
		
F_Chk_BD_LINCMB_End: 
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_BD_LINCMB = Retn_Code
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_BD_LINCMB_Inf
	'   概要：  明細：備考２による画面表示
	'   引数：  pm_Dsp_Sub_Inf   :
	'           pm_Mode          : 画面表示モード
	'           pm_All           : 画面情報
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_BD_LINCMB_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Dsp_Value As Object
		Dim Wk_Index As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'項目内容が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_Item_Detail
	'   概要：  各項目の画面表示
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_DATNO.Name
				'入金訂正対象による画面表示
				Call F_Dsp_HD_DATNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_NYUKB.Name
				'入金区分による画面表示
				Call F_Dsp_HD_NYUKB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_NYUDT.Name
				'入金日による画面表示
				Call F_Dsp_HD_NYUDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TOKCD.Name
				'請求先コードによる画面表示
				Call F_Dsp_HD_TOKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TOKRN.Name
				'請求先名称による画面表示
				Call F_Dsp_HD_TOKRN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_TUKKB.Name
				'通貨による画面表示
				Call F_Dsp_HD_TUKKB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.HD_KNJKOZ.Name
				'勘定口座による画面表示
				Call F_Dsp_HD_KNJKOZ_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_DKBID(1).Name
				'入金種別コードによる画面表示
				Call F_Dsp_BD_DKBID_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_DKBNM(1).Name
				'入金種別名称による画面表示
				Call F_Dsp_BD_DKBNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_KANKOZ(1).Name
				'勘定口座による画面表示
				Call F_Dsp_BD_KANKOZ_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_NYUKN(1).Name
				'入金額(円)による画面表示
				Call F_Dsp_BD_NYUKN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_FNYUKN(1).Name
				'入金額(外貨)による画面表示
				Call F_Dsp_BD_FNYUKN_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_BNKCD(1).Name
				'銀行コードによる画面表示
				Call F_Dsp_BD_BNKCD_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_BNKNM(1).Name
				'銀行名称による画面表示
				Call F_Dsp_BD_BNKNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_JDNNO(1).Name
				'受注番号による画面表示
				Call F_Dsp_BD_JDNNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_STNNM(1).Name
				'支店名称による画面表示
				Call F_Dsp_BD_STNNM_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_TEGDT(1).Name
				'決済日による画面表示
				Call F_Dsp_BD_TEGDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_TEGNO(1).Name
				'手形番号による画面表示
				Call F_Dsp_BD_TEGNO_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMA(1).Name
				'備考１による画面表示
				Call F_Dsp_BD_LINCMA_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMB(1).Name
				'備考２による画面表示
				Call F_Dsp_BD_LINCMB_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All)
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Chk
	'   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'①基本入力内容のチェック
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_DATNO.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：入金訂正対象のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_DATNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_NYUKB.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：入金区分のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_NYUKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_NYUDT.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：入金日のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_NYUDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TOKCD.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：請求先コードのﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_TOKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TOKRN.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：請求先名称のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_TOKRN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_TUKKB.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：通貨のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_TUKKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.HD_KNJKOZ.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'見出：勘定口座のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KNJKOZ(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_DKBID(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：入金種別コードのﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_DKBID(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_DKBNM(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：入金種別名称のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_DKBNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_KANKOZ(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：勘定口座のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_KANKOZ(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_NYUKN(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：入金額(円)のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_NYUKN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_FNYUKN(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：入金額(外貨)のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_FNYUKN(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_BNKCD(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：銀行コードのﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_BNKCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_BNKNM(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：銀行名称のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_BNKNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_JDNNO(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：受注番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_JDNNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_STNNM(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：支店名称のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_STNNM(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_TEGDT(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：決済日のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_TEGDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_TEGNO(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：手形番号のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_TEGNO(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMA(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：備考１のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_LINCMA(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
			Case FR_SSSMAIN.BD_LINCMB(1).Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'明細：備考２のﾁｪｯｸ
				Rtn_Chk = F_Chk_BD_LINCMB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
		End Select
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> Trim(pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value) Then
					'画面編集ありとする
					gv_bolURKET52_INIT = True
				End If
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> System.Windows.Forms.CheckState.Unchecked Then
					'画面編集ありとする
					gv_bolURKET52_INIT = True
				End If
				
			Case Else
		End Select
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_Chk
	'   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim intMoveFocus As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			
			'取得内容表示/クリア
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'未入力メッセージ
				If Rtn_Chk = CHK_ERR_NOT_INPUT Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_014, pm_All)
				End If
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		Rtn_Chk = F_Ctl_Head_RelChk(pm_All, intMoveFocus)
		'チェックＮＧ
		If Rtn_Chk <> CHK_OK Then
			
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
			
			F_Ctl_Head_Chk = Rtn_Chk
			Exit Function
		End If
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'１行目のボディ部を準備最終行として開放する
			'pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
			'チェックＯＫ
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_RelChk
	'   概要：  ﾍｯﾀﾞ部の関連ﾁｪｯｸ
	'   引数：　pm_ErrIdx : エラー発生時のフォーカス移動対象（ゼロ:入金区分へ移動）
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String 'エラーコード

        '2009/09/03 ADD START RISE)MIYAJIMA
        Dim strTANCLAKB As String
        '2009/09/03 ADD E.N.D RISE)MIYAJIMA

        '各ﾁｪｯｸ関数と同じ戻値
        Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
		
		'入金訂正対象のチェック
		If Trim(URKET52_HEAD_Inf.DATNO) = "" Then
			Err_Cd = gc_strMsgURKET52_E_024
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		
		'入金日のチェック(読み込んだ直後は編集なしと見なしているのでもう１回チェック)
		If URKET52_HEAD_Inf.NYUDT > GV_UNYDate Then
			Err_Cd = gc_strMsgURKET52_E_015
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			GoTo F_Ctl_Head_RelChk_END
		Else
			'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
			'月次本締日の条件撤廃
			'        '前回月次更新実行日より過去はエラー
			'        If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strMONUPDDT) Then
			'前回経理締実行日より過去はエラー
			If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strSMAUPDDT) Then
				'''' UPD 2011/01/14  FKS) T.Yamamoto    End
				Err_Cd = gc_strMsgURKET52_E_016
				pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				GoTo F_Ctl_Head_RelChk_END
			End If
		End If
		
		'2009/09/03 ADD START RISE)MIYAJIMA
		'営業担当フラグを取得
		Call F_Util_GET_TANMTA_TANCLAKB(URKET52_HEAD_Inf.TOKMTA.TANCD, strTANCLAKB)
		If CDbl(strTANCLAKB) <> 1 Then
			Err_Cd = gc_strMsgURKET52_E_034
			pm_ErrIdx = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			GoTo F_Ctl_Head_RelChk_END
		End If
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Head_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Head_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Body_Chk
	'   概要：  ﾎﾞﾃﾞｨ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk_Col As Short
		Dim Index_Wk_Row As Short
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Dsp_Mode As Short
		
		Dim Err_Row As Short
		Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Bd_Idx As Short
		Dim Err_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim intMoveFocus As Short
		Dim curMitKn As Decimal
		Dim curZeiKn As Decimal
		Dim intErrRow As Short
		Dim bolSKCH As Boolean '構成品チェック(True：諸口のみ(購買品除く))
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		pv_bolMEISAI_INPUT = False
		pv_bolMEISAI_TEG_INPUT = False
		pv_intMeisaiCnt = 0
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
					'入力待状態、入力済状態、最終準備行を対象
					
					'隠行に画面明細の対象行をコピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					
					For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
						
						'画面明細の隠行の項目のｲﾝﾃﾞｯｸｽを取得
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
						
						'エラー状態を初期状態に（単項目ﾁｪｯｸを行わせるため）
						Call F_Reset_ErrStatus(Dsp_Sub_Inf_Wk)
						
						'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
						
						If Rtn_Chk = CHK_OK Then
							'チェックＯＫ時
							'取得内容表示
							Dsp_Mode = DSP_SET
						Else
							'チェックＮＧ時
							'取得内容クリア
							Dsp_Mode = DSP_CLR
						End If
						
						'取得内容表示/クリア
						Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
						
						If Index_Wk_Row = 1 And Index_Wk_Col = 7 Then
							Index_Wk_Col = Index_Wk_Col
						End If
						
						'｢画面ボディ情報｣にワークの｢画面項目情報｣を編集
						'画面項目詳細情報を設定
						'条件によって変更される項目のみ
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						
						'チェックＮＧ
						Select Case Rtn_Chk
							'OKの場合
							Case CHK_OK
								
								'未入力
							Case CHK_ERR_NOT_INPUT
								
							Case Else
								
								'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
								'エラー用変数格納
								'行情報
								Err_Row = Index_Wk_Row
								'対象ｺﾝﾄﾛｰﾙ情報
								Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
								'画面項目詳細情報を設定
								'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
								
								GoTo ERR_EXIT
						End Select
						
					Next 
					
					'関連ﾁｪｯｸ
					Rtn_Chk = F_Ctl_Body_RelChk(Index_Wk_Row, pm_All, intMoveFocus, intErrRow)
					'チェックＮＧ
					If Rtn_Chk <> CHK_OK Then
						
						'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
						'エラー用変数格納
						'行情報
						Err_Row = intErrRow
						'対象ｺﾝﾄﾛｰﾙ情報
						Err_Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(intMoveFocus).Ctl
						
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Err_Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Sub_Inf(intMoveFocus).Detail
						
						If pm_All.Dsp_Base.Body_Fst_Idx <= intMoveFocus And pm_All.Dsp_Base.Foot_Fst_Idx > intMoveFocus Then
							GoTo ERR_EXIT
						Else
							'ﾁｪｯｸ後移動
							Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intMoveFocus), pm_All)
							
							F_Ctl_Body_Chk = CHK_ERR_ELSE
							GoTo END_EXIT
						End If
					End If
					
					'画面明細の対象行に隠行をコピー(元に戻す)
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
					
			End Select
		Next 
		
		'明細行に入力がない場合、エラー
		If pv_bolMEISAI_INPUT = False Then
			
			'エラーメッセージ表示
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_012, pm_All)
			
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.BD_DKBID(1).Tag)), pm_All)
			
			F_Ctl_Body_Chk = CHK_ERR_ELSE
			GoTo END_EXIT
			
		End If
		
		'// V1.20↓ DEL
		'    '明細行に手形の入力がない場合、エラー
		'    If pv_bolMEISAI_TEG_INPUT = False Then
		'        '得意先マスタ．手形支払金額＞０ のみ
		'        If URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 Then
		'            'エラーメッセージ表示
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_018, pm_All)
		'
		'            'ﾁｪｯｸ後移動なし
		'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_DKBID(1).Tag), pm_All)
		'
		'            F_Ctl_Body_Chk = CHK_ERR_ELSE
		'            GoTo END_EXIT
		'        End If
		'    End If
		'// V1.20↑ DEL
		
		F_Ctl_Body_Chk = Rtn_Chk
		
END_EXIT: 
		
		Exit Function
		
ERR_EXIT: 
		'エラー時、ﾌｫｰｶｽ移動
		'対象行を画面に表示
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'コントロール制御
		Call F_Set_Body_Enable(pm_All)
		'対象行から画面明細の行を取得
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'画面明細の行と同一の明細をインデックスを取得
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		
		If Err_Index > 0 Then
			'同一項目の１つ前からENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		GoTo END_EXIT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Body_RelChk
	'   概要：  ﾎﾞﾃﾞｨ部の関連ﾁｪｯｸ
	'   引数：　pm_intRow : チェック対象明細行
	'         　pm_all    : 画面情報
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_RelChk(ByRef pm_intRow As Short, ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short, ByRef pm_ErrRow As Short) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String 'エラーコード
		
		Dim intDKBID As Short
		Dim intDKBNM As Short
		Dim intKANKOZ As Short
		Dim intNYUKN As Short
		Dim intFNYUKN As Short
		Dim intBNKCD As Short
		Dim intBNKNM As Short
		Dim intJDNNO As Short
		Dim intSTNNM As Short
		Dim intTEGDT As Short
		Dim intTEGNO As Short
		Dim intLINCMA As Short
		Dim intLINCMB As Short
		Dim bolCheck As Boolean
		Dim strDKBID As String
		
		'2009/09/03 ADD START RISE)MIYAJIMA
		Dim Mst_Inf As TYPE_DB_MEIMTA
		'2009/09/03 ADD E.N.D RISE)MIYAJIMA
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_DKBID(1).Tag)
		pm_ErrRow = pm_intRow
		
		'１行チェック
		intDKBID = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		intDKBNM = CShort(FR_SSSMAIN.BD_DKBNM(0).Tag)
		intKANKOZ = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		intNYUKN = CShort(FR_SSSMAIN.BD_NYUKN(0).Tag)
		intFNYUKN = CShort(FR_SSSMAIN.BD_FNYUKN(0).Tag)
		intBNKCD = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		intBNKNM = CShort(FR_SSSMAIN.BD_BNKNM(0).Tag)
		intJDNNO = CShort(FR_SSSMAIN.BD_JDNNO(0).Tag)
		intSTNNM = CShort(FR_SSSMAIN.BD_STNNM(0).Tag)
		intTEGDT = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		intTEGNO = CShort(FR_SSSMAIN.BD_TEGNO(0).Tag)
		intLINCMA = CShort(FR_SSSMAIN.BD_LINCMA(0).Tag)
		intLINCMB = CShort(FR_SSSMAIN.BD_LINCMB(0).Tag)
		bolCheck = False
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strDKBID = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBID)))
		
		'１行に必要な情報が入力されている場合、OK
		If strDKBID <> "" Then
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case True
				'勘定口座は、必須入力
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_KANKOZ(1).Tag)
					
					'2009/09/03 ADD START RISE)MIYAJIMA
				Case F_Util_KNJKOZ_Search(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))), Mst_Inf) = 1
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_KANKOZ(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_011
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'入金額(円)は、必須入力
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN))) = "" Or SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))) = 0
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_NYUKN(1).Tag)
					
					'入金額(外貨)は、必須入力（ただし、海外のみ）
				Case URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And (Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN))) = "" Or SSSVal(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))) = 0)
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_FNYUKN(1).Tag)
					
					'2009/06/08 ADD START FKS)NAKATA
					'受注番号は、必須入力（ただし、前受のみ）
				Case URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intJDNNO))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_JDNNO(1).Tag)
					'2009/06/08 ADD E.N.D FKS)NAKATA
					
					
					'// V1.20↓ DEL
					'            '入金種別＝振込の場合
					'            '銀行コードは、必須入力
					'            Case strDKBID = pc_strDKBID_URK_HURI _
					''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = ""
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_BNKCD(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_019
					'// V1.20↑ DEL
					
					'入金種別＝手形の場合
					'銀行コードは、必須入力
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_BNKCD(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_020
					
					'入金種別＝手形の場合
					'決済日は、必須入力
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_021
					
					'入金種別＝手形の場合
					'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
					'月次本締日の条件撤廃
					'            '決済日は、前回月次更新実行日より過去はエラー
					'            '(読み込んだ直後は編集なしと見なしているのでもう１回チェック)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) <> "" _
					''             And Replace(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "/", "") <= Trim(pv_strMONUPDDT)
					'決済日は、前回経理締実行日より過去はエラー
					'(読み込んだ直後は編集なしと見なしているのでもう１回チェック)
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) <> "" And Replace(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "/", "") <= Trim(pv_strSMAUPDDT)
					'''' UPD 2011/01/14  FKS) T.Yamamoto    End
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_016
					
					'入金種別＝手形の場合
					'手形番号は、必須入力
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGNO))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGNO(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_022
					
					
					'2009/06/08 ADD START FKS)NAKATA
					'決済日は、必須入力（ただし、前受のみ）
				Case URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And strDKBID = pc_strDKBID_URK_HURIK And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					'2009/06/08 ADD E.N.D FKS)NAKATA
					
					'2009/09/03 ADD START RISE)MIYAJIMA
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(URKET52_HEAD_Inf.NYUDT) > VB6.Format(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "YYYYMMDD")
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_008
					
					'運用日テーブル.運用日付（UNYMTA）> 画面.決済日の場合
				Case strDKBID = pc_strDKBID_URK_TEG And Trim(GV_UNYDate) > VB6.Format(Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))), "YYYYMMDD")
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_TEGDT(1).Tag)
					Err_Cd = gc_strMsgURKET52_E_035
					'2009/09/03 ADD E.N.D RISE)MIYAJIMA
					
					'// V1.20↓ DEL
					'            '入金種別＝手形の場合
					'            '得意先マスタ．手形支払金額＞０
					'            ' かつ 得意先マスタ．手形支払金額＞画面．入金額(円)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > SSSVal(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN)))
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_NYUKN(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_023
					'// V1.20↑ DEL
					
					'// V1.20↓ DEL
					'            '入金種別＝手形の場合
					'            '得意先マスタ．手形支払金額＞０
					'            ' かつ 得意先マスタ．手形支払金額＞画面．入金額(外貨)
					'            Case strDKBID = pc_strDKBID_URK_TEG _
					''             And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > 0 _
					''             And URKET52_HEAD_Inf.TOKMTA.TEGSHKN > SSSVal(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN)))
					'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_FNYUKN(1).Tag)
					'                Err_Cd = gc_strMsgURKET52_E_023
					'// V1.20↑ DEL
					
					'必要な情報が入力されている場合OK
				Case Else
					bolCheck = True
					pv_bolMEISAI_INPUT = True
					pv_intMeisaiCnt = pv_intMeisaiCnt + 1
					
			End Select
			
			'// V1.20↓ DEL
			'        '手形の入力が１明細もない場合はエラー
			'        If strDKBID = pc_strDKBID_URK_TEG Then
			'            pv_bolMEISAI_TEG_INPUT = True
			'        End If
			'// V1.20↑ DEL
		End If
		
		'１行全部未入力の場合OK
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBID))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDKBNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intKANKOZ))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intNYUKN))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFNYUKN))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKCD))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intJDNNO))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSTNNM))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGDT))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intTEGNO))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intLINCMA))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intLINCMB))) = "" Then
			bolCheck = True
		End If
		
		If bolCheck = False Then
			If Err_Cd = "" Then
				'個別でメッセージが定義されていない場合は、汎用的なメッセージを出す
				Err_Cd = gc_strMsgURKET52_E_013
			End If
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Body_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Body_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Tail_Chk
	'   概要：  ﾃｲﾙ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Tail_Chk(ByRef pm_All As Cls_All) As Short
		Dim Rtn_Chk As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'チェックなし
		
		F_Ctl_Tail_Chk = Rtn_Chk
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_ALL_RelChk
	'   概要：  ﾁｪｯｸﾙｰﾁﾝ制御（全関連チェック）
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_ALL_RelChk(ByRef pm_All As Cls_All) As Short
		Dim Rtn_Chk As Short
		Dim Err_Cd As String
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		Err_Cd = ""
		
		'2009/09/24 DEL START RISE)MIYAJIMA
		'    '変更差額上限チェック
		'    If F_Util_CheckSumOver(pm_All) <> 0 Then
		'        Rtn_Chk = CHK_ERR_ELSE
		'
		'        'メッセージ出力
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
		'
		'        'ﾁｪｯｸ後移動なし
		'        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_NYUKN(1).Tag), pm_All)
		'    End If
		'2009/09/24 DEL E.N.D RISE)MIYAJIMA
		
		F_Ctl_ALL_RelChk = Rtn_Chk
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_DATNO
	'   概要：  対象項目の入金訂正対象ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_DATNO(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_DATNO.Tag)
		Next_Focus = Trg_Index + 1
		
		'ﾌｫｰｶｽをコードへ移動
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'現在のActiveコントロールの選択状態解除
			'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'ﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolURKET52_LF_Enable = False
			
			WLSNDN_RTNCODE = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'入金訂正対象画面を呼び出す
			WLSNDN.ShowDialog()
			WLSNDN.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSNDN_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSNDN_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_NYUDT
	'   概要：  対象項目の見出：入金日ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_NYUDT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		Dim Trg_Index As Short
		
		Trg_Index = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
		Next_Focus = Trg_Index + 1
		
		'ﾌｫｰｶｽを各項目へ移動
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'現在のActiveコントロールの選択状態解除
			'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'ﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
			
			gv_bolURKET52_LF_Enable = False
			
			WLSDATE_RTNCODE = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Set_date.Value = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
			'カレンダ検索画面を呼び出す
			WLS_DATE.ShowDialog()
			WLS_DATE.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSDATE_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
				
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_KNJKOZ
	'   概要：  対象項目の見出：勘定口座ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_KNJKOZ(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_MEI() As TYPE_DB_MEIMTA
		Dim intCnt As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_KNJKOZ.Tag)
		Next_Focus = Trg_Index
		
		'ﾌｫｰｶｽを受注取引区分へ移動
		Dim strItem As String
		If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
			'現在のActiveコントロールの選択状態解除
			'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
			'ﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)

            'リスト選択画面の情報を設定
            '2009/09/03 UPD START RISE)MIYAJIMA
            '        Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")

            '2009/09/03 UPD E.N.D RISE)MIYAJIMA
            If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
                Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ_MAE, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
            Else
                Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
            End If

            WLS_LIST.Text = "勘定口座一覧"
            CType(WLS_LIST.Controls("LST"), Object).Items.Clear()

            For intCnt = 1 To UBound(Mst_Inf_MEI)
                If Mst_Inf_MEI(intCnt).DATKB <> "9" Then
                    strItem = LeftWid(Mst_Inf_MEI(intCnt).MEICDB, 1) & LeftWid(Mst_Inf_MEI(intCnt).MEICDA, 9) & " " & LeftWid(Mst_Inf_MEI(intCnt).MEINMA, 40)
                    CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
                End If
            Next
            Erase Mst_Inf_MEI

            'For i As Integer = 0 To dt.Rows.Count - 1
            '    Call DB_MEIMTA_SetData(dt, pot_DB_MEIMTA(intData))
            '    intData = intData + 1
            'Next

            '桁数設定
            SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'リスト選択画面を呼び出す
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If PP_SSSMAIN.SlistCom <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CStr(NEXT_FOCUS_MODE_KEYRIGHT), Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Focus), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_DKBID
	'   概要：  対象項目の見出：入金種別ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_DKBID(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_TBD() As TYPE_DB_SYSTBD
		Dim intCnt As Short
		
		'ｲﾝﾃﾞｯｸｽ取得
		Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(0).Tag)
		
		'ﾌｫｰｶｽ移動先を検索
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'明細領域
			'対象行の製品コードへ移動
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'明細以外領域
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'ヘッタ部の場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					'明細の１行目に移動
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'ﾌｫｰｶｽを移動
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'現在のActiveコントロールの選択状態解除
				'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'項目色設定
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Focus_Flg = True
			End If
		End If
		
		Dim strItem As String
		If Focus_Flg = True Then
			'リスト選択画面の情報を設定
			Call SYSTBD_SEARCH_ALL(pc_strDKBSB_URK, Mst_Inf_TBD)
			WLS_LIST.Text = "入金種別"
			CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
			For intCnt = 1 To UBound(Mst_Inf_TBD)
				strItem = Mst_Inf_TBD(intCnt).DKBID & " " & Mst_Inf_TBD(intCnt).DKBNM
				CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
			Next intCnt
			Erase Mst_Inf_TBD
			
			'桁数設定
			SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'リスト選択画面を呼び出す
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If PP_SSSMAIN.SlistCom <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'明細入力後の後処理
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				'対象行の次項目へ移動（wk_indexは該当のテキスト配列ゼロを指定しておく）
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾁｪｯｸ後移動なし
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_KANKOZ
	'   概要：  対象項目の明細：勘定口座ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_KANKOZ(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		Dim Mst_Inf_MEI() As TYPE_DB_MEIMTA
		Dim intCnt As Short
		
		'ｲﾝﾃﾞｯｸｽ取得
		Wk_Index = CShort(FR_SSSMAIN.BD_KANKOZ(0).Tag)
		
		'ﾌｫｰｶｽ移動先を検索
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'明細領域
			'対象行の製品コードへ移動
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'明細以外領域
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'ヘッタ部の場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					'明細の１行目に移動
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'ﾌｫｰｶｽを移動
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'現在のActiveコントロールの選択状態解除
				'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'項目色設定
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Focus_Flg = True
			End If
		End If
		
		Dim strItem As String
		If Focus_Flg = True Then
			'リスト選択画面の情報を設定
			'2009/09/03 UPD START RISE)MIYAJIMA
			'        Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ_MAE, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			Else
				Call DSPMEIMTA_SEARCH_SORTUSE(pc_strKEYCD_KNJKOZ, Mst_Inf_MEI, "KEYCD, MEICDB, MEICDA")
			End If
			'2009/09/03 UPD E.N.D RISE)MIYAJIMA
			WLS_LIST.Text = "勘定口座一覧"
			CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
			For intCnt = 1 To UBound(Mst_Inf_MEI)
				If Mst_Inf_MEI(intCnt).DATKB <> "9" Then
					strItem = LeftWid(Mst_Inf_MEI(intCnt).MEICDB, 1) & LeftWid(Mst_Inf_MEI(intCnt).MEICDA, 9) & " " & LeftWid(Mst_Inf_MEI(intCnt).MEINMA, 40)
					CType(WLS_LIST.Controls("LST"), Object).Items.Add(strItem)
				End If
			Next intCnt
			Erase Mst_Inf_MEI
			
			'桁数設定
			SSS_WLSLIST_KETA = pm_All.Dsp_Sub_Inf(Trg_Index).Detail.MaxLengthB
			
			gv_bolURKET52_LF_Enable = False
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			PP_SSSMAIN.SlistCom = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'リスト選択画面を呼び出す
			WLS_LIST.ShowDialog()
			WLS_LIST.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			'UPGRADE_WARNING: オブジェクト PP_SSSMAIN.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If PP_SSSMAIN.SlistCom <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(PP_SSSMAIN.SlistCom, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'明細入力後の後処理
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				'対象行の次項目へ移動（wk_indexは該当のテキスト配列ゼロを指定しておく）
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾁｪｯｸ後移動なし
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_BNKCD
	'   概要：  対象項目の明細：銀行コードボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_BNKCD(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'ｲﾝﾃﾞｯｸｽ取得
		Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(0).Tag)
		
		'ﾌｫｰｶｽ移動先を検索
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'明細領域
			'対象行の製品コードへ移動
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'明細以外領域
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'ヘッタ部の場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					'明細の１行目に移動
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
            'ﾌｫｰｶｽを移動
            If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
                '現在のActiveコントロールの選択状態解除
                'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
                'ﾌｫｰｶｽ移動
                Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
                '選択状態の設定（初期選択）
                Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
                '項目色設定
                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
                'ﾌｫｰｶｽ移動
                Focus_Flg = True
            End If
        End If
		
		If Focus_Flg = True Then
			gv_bolURKET52_LF_Enable = False
			
			WLSBNKMTA2_RTNCODE = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'銀行検索画面を呼び出す
			WLSBNK2.ShowDialog()
			WLSBNK2.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSBNKMTA2_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSBNKMTA2_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'明細入力後の後処理
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				'対象行の次項目へ移動（wk_indexは該当のテキスト配列ゼロを指定しておく）
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾁｪｯｸ後移動なし
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS_TEGDT
	'   概要：  対象項目の明細：決済日ボタンの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS_TEGDT(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Trg_Index As Short
		Dim Focus_Flg As Boolean
		
		Dim Dsp_Value As Object
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Dsp_Mode As Short
		Dim Chk_Move_Flg As Boolean
		Dim Next_Focus As Short
		
		'ｲﾝﾃﾞｯｸｽ取得
		Wk_Index = CShort(FR_SSSMAIN.BD_TEGDT(0).Tag)
		
		'ﾌｫｰｶｽ移動先を検索
		Focus_Flg = False
		Trg_Index = 0
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			'明細領域
			'対象行の製品コードへ移動
			Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
		Else
			'明細以外領域
			If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD Or (pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index = 0) Then
				'ヘッタ部の場合
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫの場合
					'明細の１行目に移動
					Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), 1, pm_All)
				End If
			End If
		End If
		
		Next_Focus = Trg_Index
		
		If Trg_Index > 0 Then
			'ﾌｫｰｶｽを移動
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All) = True Then
				'現在のActiveコントロールの選択状態解除
				'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)), ITEM_NORMAL_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				'選択状態の設定（初期選択）
				Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
				'項目色設定
				Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
				'ﾌｫｰｶｽ移動
				Focus_Flg = True
			End If
		End If
		
		If Focus_Flg = True Then
			gv_bolURKET52_LF_Enable = False
			
			WLSDATE_RTNCODE = ""
			
			'Windowsに処理を返す
			System.Windows.Forms.Application.DoEvents()
			
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Set_date.Value = Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index)))
			'カレンダ検索画面を呼び出す
			WLS_DATE.ShowDialog()
			WLS_DATE.Close()
			
			gv_bolURKET52_LF_Enable = True
			
			If WLSDATE_RTNCODE <> "" Then
				'検索ＯＫ
				'画面に編集
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Dsp_Value = CF_Cnv_Dsp_Item(WLSDATE_RTNCODE, pm_All.Dsp_Sub_Inf(Trg_Index), False)
				
				'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
				Call CF_Set_Item_Not_Change(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'明細入力後の後処理
				Call F_Ctl_Item_Input_Aft(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Trg_Index))
				
				'チェック
				'各項目のﾁｪｯｸﾙｰﾁﾝ
				Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Trg_Index), CHK_FROM_KEYRETURN, Chk_Move_Flg, pm_All)
				
				If Rtn_Chk = CHK_OK Then
					'チェックＯＫ時
					'取得内容表示
					Dsp_Mode = DSP_SET
				Else
					'チェックＮＧ時
					'取得内容クリア
					Dsp_Mode = DSP_CLR
				End If
				'取得内容表示/クリア
				Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Trg_Index), Dsp_Mode, pm_All)
				
				'対象行の次項目へ移動（wk_indexは該当のテキスト配列ゼロを指定しておく）
				Wk_Index = CF_Get_Idex_Same_Bd_Ctl(pm_All.Dsp_Sub_Inf(Wk_Index), pm_Act_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				If Chk_Move_Flg = True Then
					'ﾁｪｯｸ後移動あり
					Call SSSMAIN0001.F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Wk_Index), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					'ﾁｪｯｸ後移動なし
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
					'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Wk_Index), ITEM_NORMAL_STATUS, pm_All)
				End If
			End If
		Else
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_FNYUKN_Clear
	'   概要：  すべての行の入金額(外貨)をクリアする
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_Clear(ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【入金額(外貨)】
			Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'画面の行
			Wk_Row = intCnt
			
			'pm_All.Dsp_Body_Infの行ＮＯを取得
			Bd_Index = intCnt
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'情報の初期化
			With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
				.FNYUKN = 0
			End With
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_FNYUKN_SetOnOff
	'   概要：  すべての行の入金額(外貨)の有効・無効を変更する
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_SetOnOff(ByVal pin_Value As Boolean, ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【入金額(外貨)】
			Wk_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'有効・無効を変更する
			Call CF_Set_Item_Focus_Ctl(pin_Value, pm_All.Dsp_Sub_Inf(Wk_Index))
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_JDNNO_Clear
	'   概要：  すべての行の受注番号をクリアする
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_JDNNO_Clear(ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		Dim Wk_Row As Short
		Dim Bd_Index As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【受注番号】
			Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(intCnt).Tag)
			
			'画面の行
			Wk_Row = intCnt
			
			'pm_All.Dsp_Body_Infの行ＮＯを取得
			Bd_Index = intCnt
			
			'画面クリア
			Call CF_Clr_Dsp_Body_Item(pm_All.Dsp_Sub_Inf(Wk_Index), Wk_Row, pm_All)
			
			'情報の初期化
			With pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf
				.JDNNO = ""
				.JDNLINNO = ""
			End With
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_JDNNO_SetOnOff
	'   概要：  すべての行の受注番号の有効・無効を変更する
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_JDNNO_SetOnOff(ByVal pin_Value As Boolean, ByRef pm_All As Cls_All)
		Dim Wk_Index As Short
		Dim intCnt As Short
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【受注番号】
			Wk_Index = CShort(FR_SSSMAIN.BD_JDNNO(intCnt).Tag)
			
			'有効・無効を変更する
			Call CF_Set_Item_Focus_Ctl(pin_Value, pm_All.Dsp_Sub_Inf(Wk_Index))
		Next intCnt
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_DKBID_SwitchOnOff
	'   概要：  入金種別に応じて行の有効・無効を変更する
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_DKBID_SwitchOnOff(ByVal pin_intRow As Short, ByRef pm_All As Cls_All)
		Dim strDKBID As String
		Dim Trg_Index As Short
		Dim blnBNKCD As Boolean
		Dim blnTEGDT As Boolean
		Dim blnTEGNO As Boolean
		
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strDKBID = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_DKBID(pin_intRow).Tag)))
		blnBNKCD = False
		blnTEGDT = False
		blnTEGNO = False
		
		Select Case Trim(strDKBID)
			Case pc_strDKBID_URK_HURI
				'振込
				'blnBNKCD = True
			Case pc_strDKBID_URK_TEG
				'手形
				blnBNKCD = True
				blnTEGDT = True
				blnTEGNO = True
				'2009/05/27 ADD START FKS)NAKATA
			Case pc_strDKBID_URK_HURIK
				'''' DEL 2011/06/14  FKS) T.Yamamoto    Start    入金改善
				'仮振込の場合は決済日を入力可とする
				'            '入金区分が「前受」で、かつ仮振込
				'            If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
				'''' DEL 2011/06/14  FKS) T.Yamamoto    End
				blnTEGDT = True
				'''' DEL 2011/06/14  FKS) T.Yamamoto    Start    入金改善
				'            End If
				'''' DEL 2011/06/14  FKS) T.Yamamoto    End
				'2009/05/27 ADD START FKS)NAKATA
		End Select
		
		Trg_Index = CShort(FR_SSSMAIN.BD_BNKCD(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnBNKCD, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		Trg_Index = CShort(FR_SSSMAIN.BD_TEGDT(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnTEGDT, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		Trg_Index = CShort(FR_SSSMAIN.BD_TEGNO(pin_intRow).Tag)
		Call CF_Set_Item_Focus_Ctl(blnTEGNO, pm_All.Dsp_Sub_Inf(Trg_Index))
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_KNJKOZ_Search
	'   概要：  勘定口座を検索する
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_KNJKOZ_Search(ByVal pin_strInputValue As String, ByRef pot_DB_MEIMTA As TYPE_DB_MEIMTA) As Short
		Const c_LenMEICDB As Short = 1
		Const c_LenMEICDA As Short = 9
		
		Dim Retn_Code As Short
		Dim strMEICDA As String
		Dim strMEICDB As String
		
		pin_strInputValue = pin_strInputValue & Space(c_LenMEICDB + c_LenMEICDA)
		
		strMEICDB = LeftWid(pin_strInputValue, c_LenMEICDB)
		strMEICDA = MidWid(pin_strInputValue, c_LenMEICDB + 1, c_LenMEICDA)
		
		'2009/09/03 UPD START RISE)MIYAJIMA
		'    F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ_MAE, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		Else
			F_Util_KNJKOZ_Search = DSPMEIM_SEARCH(pc_strKEYCD_KNJKOZ, strMEICDA, pot_DB_MEIMTA, strMEICDB)
		End If
		'2009/09/03 UPD E.N.D RISE)MIYAJIMA
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_Get_Simebi
	'   概要：
	'   引数：  pin_strNYUDT
	'           pin_strTOKCD
	'           pot_strSMADT 実行結果：経理締日付
	'           pot_strSSADT 実行結果：締日付
	'           pot_strKESDT 実行結果：決済日付
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_Simebi(ByVal pin_strNYUDT As String, ByVal pin_strTOKCD As String, ByRef Pot_strSMADT As String, ByRef pot_strSSADT As String, ByRef Pot_strKESDT As String) As Short
		Dim strSMADT As String
		Dim strSSADT As String
		Dim strKESDT As String
		Dim intNXTKB As Short
		'// V1.10↓ ADD
		Dim strSSAKBN As String
		'// V1.10↑ ADD
		
		F_Util_Get_Simebi = 9
		
		If Trim(pin_strNYUDT) = "" Then Exit Function
		If Trim(pin_strTOKCD) = "" Then Exit Function
		intNXTKB = 0
		
		'--- 経理締め日付取得 ---
		strSMADT = F_Util_Get_Acedt(VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), pv_strSMADD)
		
		'=== 請求締め日付取得 ===
		With URKET52_HEAD_Inf.TOKMTA
			'UPGRADE_WARNING: オブジェクト SSSVal(URKET52_HEAD_Inf.TOKMTA.TOKSMEKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(.TOKSMEKB) = 1 Then
				'--- 月X回締め ---
				'UPGRADE_WARNING: オブジェクト SSSVal(URKET52_HEAD_Inf.TOKMTA.TOKSMECC) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSSADT = Get_SMEDT1(SSSVal(.TOKSMEDD), SSSVal(.TOKSMECC), VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), intNXTKB)
				
				'// V1.20↓ DEL
				'            strKESDT = Get_KESDT1(SSSVal(.TOKSMEDD) _
				''                                , SSSVal(.TOKSMECC) _
				''                                , SSSVal(.TOKKESCC) _
				''                                , SSSVal(.TOKKESDD) _
				''                                , Format(pin_strNYUDT, "@@@@/@@/@@"))
				'// V1.20↑ DEL
			Else
				'--- 週締め ---
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSSADT = Get_SMEDT2(SSSVal(.TOKSDWKB), VB6.Format(pin_strNYUDT, "@@@@/@@/@@"), intNXTKB)
				
				'// V1.20↓ DEL
				'            strKESDT = Get_KESDT2(SSSVal(.TOKSDWKB) _
				''                                , SSSVal(.TOKKESCC) _
				''                                , SSSVal(.TOKKDWKB) _
				''                                , Format(pin_strNYUDT, "@@@@/@@/@@"))
				'// V1.20↑ DEL
			End If
			'// V1.10↓ ADD
			Call F_Get_FIXMTA(strSSAKBN)
			Call AE_GetKESDT(strSSADT, .TOKSMEKB, .TOKKESCC, .TOKKESDD, .TOKKDWKB, strSSAKBN, strKESDT)
			'// V1.10↑ ADD
		End With
		
		Pot_strSMADT = VB6.Format(strSMADT, "YYYYMMDD")
		pot_strSSADT = VB6.Format(strSSADT, "YYYYMMDD")
		'// V1.10↓ UPD
		'    Pot_strKESDT = Format$(strKESDT, "YYYYMMDD")
		Pot_strKESDT = strKESDT
		'// V1.10↑ UPD
		
		F_Util_Get_Simebi = 0
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_Get_Acedt
	'   概要：  該当経理締日付
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_Acedt(ByVal pin_wdate As String, ByVal pin_SMADD As String) As String
		If Not CHECK_DATE(pin_wdate) Then
			Call Error_Exit("日付エラー(Get_Acedt): " & pin_wdate)
		End If
		
		If pin_SMADD > "27" Then
			F_Util_Get_Acedt = CStr(DateSerial(Year(CDate(pin_wdate)), Month(CDate(pin_wdate)) + 1, 0))
		ElseIf Right(pin_wdate, 2) <= pin_SMADD Then 
			F_Util_Get_Acedt = Left(pin_wdate, 8) & pin_SMADD
		Else
			'UPGRADE_WARNING: オブジェクト SSSVal(pin_SMADD) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			F_Util_Get_Acedt = CStr(DateSerial(Year(CDate(pin_wdate)), Month(CDate(pin_wdate)) + 1, SSSVal(pin_SMADD)))
		End If
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_CheckJDNNO
	'   概要：  受注番号チェック
	'   引数：  pin_strJDNNO
	'           pin_strJDNLINNO
	'           pin_strNYUDT
	'   戻値：　0:正常終了 9:異常終了
	'           1:該当データなし
	'           2:受注伝票日付の年月＞画面.入金日の年月
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''' UPD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
	'Private Function F_Util_CheckJDNNO(ByVal pin_strJDNNO As String _
	''                                 , ByVal pin_strJDNLINNO As String) As Integer
	Private Function F_Util_CheckJDNNO(ByVal pin_strJDNNO As String, ByVal pin_strJDNLINNO As String, Optional ByVal pin_strNYUDT As String = "") As Short
		'''' UPD 2009/11/10  FKS) T.Yamamoto    End
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		'**** 2009/09/07 CHG START FKS)NAKATA
		Dim strJDNTRKB As String
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
		Dim strNYUYM As String
		Dim strJDNYM As String
		'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		
		On Error GoTo F_Util_CheckJDNNO_err
		
		F_Util_CheckJDNNO = 9
		
		'SQL
		strSQL = ""
		'**** 2009/09/07 CHG START FKS)NAKATA
		'strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & " SELECT DATNO , JDNTRKB "
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '取得データ退避
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
        Else
            'change start 20190827 kuwa
            '         'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
            ''**** 2009/09/07 ADD START FKS)NAKATA
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
            ''**** 2009/09/07 ADD E.N.D FKS)NAKATA

            strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
            'change end 20190827 kuwa

        End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
		strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		'// V1.20↓ ADD
		strSQL = strSQL & "    AND AKAKROKB = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		'// V1.20↑ ADD
		'2009/06/08 ADD START FKS)NAKATA
		'請求先
		strSQL = strSQL & "    AND TOKSEICD = '" & URKET52_HEAD_Inf.TOKCD & "' "
        '2009/06/08 ADD E.N.D FKS)NAKATA


        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
            '''' ADD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
        Else
            If pin_strNYUDT <> "" Then
				strNYUYM = Left(Replace(pin_strNYUDT, "/", ""), 6)
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190827 kuwa '要確認(他は引数が三つの場合が多い。Optionalなのでなくとも大丈夫だと思うが)
                'strJDNYM = Left(CF_Ora_GetDyn(Usr_Ody, "JDNDT"), 6)
                strJDNYM = Left(DB_NullReplace(dt.Rows(0)("JDNDT"), ""), 6)
                'change end 20190827 kuwa
                If strNYUYM < strJDNYM Then
					F_Util_CheckJDNNO = 2
					GoTo F_Util_CheckJDNNO_end
				End If
			End If
			'''' ADD 2009/11/10  FKS) T.Yamamoto    End
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		'**** 2009/09/07 CHG START FKS)NAKATA
		'システム・セットアップ受注にて「001」以外の受注行番号を入力するとエラーとする
		If (strJDNTRKB = "11" Or strJDNTRKB = "21") And Trim(pin_strJDNLINNO) <> "001" Then
			F_Util_CheckJDNNO = 1
			GoTo F_Util_CheckJDNNO_end
		End If
		'**** 2009/09/07 CHG E.N.D FKS)NAKATA
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTRA "
		strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
		strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		'**** 2009/09/07 CHG START FKS)NAKATA
		'システム・セットアップ以外は、行単位にて受注トランの確認を行う。
		'strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
		If (strJDNTRKB = "11" Or strJDNTRKB = "21") Then
		Else
			strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
		End If
        '**** 2009/09/07 CHG E.N.D FKS)NAKATA

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_CheckJDNNO = 1
            GoTo F_Util_CheckJDNNO_end
        End If

        F_Util_CheckJDNNO = 0
		
F_Util_CheckJDNNO_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Util_CheckJDNNO_err: 
		GoTo F_Util_CheckJDNNO_end
		
	End Function
	
	'2009/06/08 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_Get_UODKN
	'   概要：  受注金額の取得
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Get_UODKN(ByVal pin_strJDNNO As String, ByVal pin_strJDNLINNO As String) As Decimal
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		Dim strJDNTRKB As String
		
		Dim curUODKN As Decimal
		Dim curNYUKN As Decimal
		
		
		On Error GoTo F_Util_Get_UODKN_err
		
		curUODKN = 0
		curNYUKN = 0
		
		F_Util_Get_UODKN = curUODKN - curNYUKN
		
		
		'過去の入金額の取得(自分自身以外を参照する)
		strSQL = ""
		strSQL = strSQL & " SELECT   NVL(SUM(TRA.NYUKN),0) AS NYUKN "
		strSQL = strSQL & "   FROM 　UDNTRA TRA"
		strSQL = strSQL & "  　　,   UDNTHA THA"
		strSQL = strSQL & "  WHERE   TRA.DATNO   =  THA.DATNO"
		strSQL = strSQL & "    AND   TRA.DATKB   =  '1'"
		strSQL = strSQL & "  　AND   TRA.DENKB   =  '8'"
		'strSQL = strSQL & "  　AND   TRA.KESIKB  =  '9'"
		strSQL = strSQL & "  　AND   TRA.DKBID   != '09'" '本入金は相手にしない
		strSQL = strSQL & "  　AND   TRA.OKRJONO = '" & Trim(pin_strJDNNO) & Trim(pin_strJDNLINNO) & "' "
		strSQL = strSQL & "  　AND   TRA.UDNDT  <= '" & GV_UNYDate & "' "
		strSQL = strSQL & "    AND   TRA.DATNO <> '" & WLSNDN_RTNCODE & "' "
		strSQL = strSQL & "  　AND   THA.NYUCD   =  '2'"
		strSQL = strSQL & "  　AND   THA.FRNKB   =  '0'"


        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '取得データ退避
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190827 kuwa
            'curNYUKN = CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")
            curNYUKN = DB_NullReplace(dt.Rows(0)("NYUKN"), "")
            'change end 20190827 kuwa
        End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		'最新の伝票管理№・受注取引区分の取得
		strSQL = ""
		strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & " ,      JDNTRKB"
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "            AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
		strSQL = strSQL & "    AND MAEUKKB      = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '取得データ退避
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
            GoTo F_Util_Get_UODKN_end
        Else
            'change start 20190827 kuwa
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
            strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
            strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
            'change end 20190827 kuwa

        End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		
		Select Case Trim(strJDNTRKB)
			'セットアップ(受注トラン.受注伝票区分=「1：通常、2：ｾｯﾄｱｯﾌﾟﾍｯﾀﾞ」)
			'伝票単位にて受注金額を取得する
			Case "11"
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(UODKN) + SUM(UZEKN),0) AS UODKN "
				strSQL = strSQL & "   FROM JDNTRA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				strSQL = strSQL & "    AND JDNKB IN ('1','2') "
				
				
				'システム(受注見出しトランより取得)
				'伝票単位にて受注金額を取得する
			Case "21"
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(SBAUODKN) + SUM(SBAUZEKN),0) AS UODKN　"
				strSQL = strSQL & "   FROM JDNTHA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				
				
				'上記以外
				'明細行単位にて受注金額を取得する
			Case Else
				
				strSQL = ""
				strSQL = strSQL & " SELECT NVL(SUM(UODKN) + SUM(UZEKN),0) AS UODKN "
				strSQL = strSQL & "   FROM JDNTRA "
				strSQL = strSQL & "  WHERE DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
				strSQL = strSQL & "    AND DATNO = '" & CF_Ora_String(strDATNO, 10) & "' "
				strSQL = strSQL & "    AND JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
				strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strJDNLINNO, 3) & "' "
				
		End Select


        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '取得データ退避
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_Util_Get_UODKN = curUODKN - curNYUKN
            GoTo F_Util_Get_UODKN_end
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190827 kuwa
            'curUODKN = CF_Ora_GetDyn(Usr_Ody, "UODKN", "")
            curUODKN = DB_NullReplace(dt.Rows(0)("UODKN"), "")
            'change end 20190827 kuwa
        End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		F_Util_Get_UODKN = curUODKN - curNYUKN
		
		
		
F_Util_Get_UODKN_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Util_Get_UODKN_err: 
		GoTo F_Util_Get_UODKN_end
		
	End Function
	'2009/06/08 ADD E.N.D FKS)NAKATA
	
	'2009/09/24 DEL START RISE)MIYAJIMA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function F_Util_CheckSumOver
	''   概要：  変更差額上限チェック
	''   引数：
	''   戻値：
	''   備考： 入金額変更時・入金取消時に、請求サマリの消込入金額残累計より、変更差額・取消額が大きい時はエラーとし、再入力を促す。
	''          Ex.) 消込入金額残が100万の時、150万の入金伝票を40万に変更・または取消することはできない。→差額が100万以上のため。50万以上なら変更可。
	''          ※海外得意先の時は、請求サマリ外貨の消込入金残額累計を判断基準にする。
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function F_Util_CheckSumOver(pm_All As Cls_All) As Integer
	'    Dim strSQL      As String
	'    Dim curMOTKN    As Currency '変更前の金額
	'    Dim curCHGKN    As Currency '変更後の金額
	'    Dim curZANKN    As Currency 'SQL でDBから取得する請求サマリ．消込入金額残
	'    Dim intCnt      As Integer
	'    Dim intRet      As Integer
	'
	'    F_Util_CheckSumOver = 9
	'
	'    '請求サマリ．消込入金額残 を取得
	'    intRet = F_Util_CheckSumOver_GetZANKN(pm_All, curZANKN)
	'    If intRet <> 0 Then
	'        F_Util_CheckSumOver = intRet
	'        Exit Function
	'    End If
	'
	'    '残額がゼロの場合 以外 チェックを行う
	''2009/09/05 DEL START RISE)MIYAJIMA
	''    If curZANKN <> 0 Then
	''2009/09/05 DEL E.N.D RISE)MIYAJIMA
	'        With URKET52_HEAD_Inf
	'            If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
	'                '海外
	'
	'                '変更前の金額を取得
	'                curMOTKN = .UDNTHA.SBAFRNKN
	'
	'                '変更後の金額を取得
	'                curCHGKN = pv_dblFNYUKN_SUM
	'            Else
	'                '国内
	'
	'                If .NYUKB = gc_strMAEUKKB_NML Then
	'                    '入金
	'
	'                    '変更前の金額を取得 (請求サマリ更新時の条件を考慮して集計)
	'                    curMOTKN = 0
	'                    For intCnt = 1 To UBound(.UDNTRA)
	'                        'デフォルトコード≠３
	'                        If Trim(.UDNTRA(intCnt).DFLDKBCD) <> "3" Then
	'                            curMOTKN = curMOTKN + .UDNTRA(intCnt).NYUKN
	'                        End If
	'                    Next intCnt
	'
	'                    '変更後の金額を取得 (請求サマリ更新時の条件を考慮して集計)
	'                    curCHGKN = 0
	'                    For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
	'                        'デフォルトコード≠３
	'                        If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.DFLDKBCD) <> "3" Then
	'                            curCHGKN = curCHGKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
	'                        End If
	'                    Next intCnt
	'                 Else
	'                    '前受入金
	'
	'                    '変更前の金額を取得
	'                    curMOTKN = .UDNTHA.SBANYUKN
	'
	'                    '変更後の金額を取得
	'                    curCHGKN = pv_curNYUKN_SUM
	'                End If
	'            End If
	'        End With
	'
	'
	''2009/09/05 ADD START RISE)MIYAJIMA
	'    If curZANKN <> 0 Then
	''2009/09/05 ADD E.N.D RISE)MIYAJIMA
	'        'チェック
	'        '変更前の金額　－　変更後の金額　＞　請求サマリ．消込入金額残
	'        If curMOTKN < 0 Or curCHGKN < 0 Then
	'            If Abs(curMOTKN - curCHGKN) > Abs(curZANKN) Then
	'                F_Util_CheckSumOver = 2
	'                Exit Function
	'            End If
	'        Else
	'            If Abs(curMOTKN) - Abs(curCHGKN) > Abs(curZANKN) Then
	'                F_Util_CheckSumOver = 2
	'                Exit Function
	'            End If
	'        End If
	'    End If
	'
	''2009/09/05 ADD START RISE)MIYAJIMA
	'    If curZANKN = 0 And curMOTKN <> 0 And curMOTKN > curCHGKN Then
	'        F_Util_CheckSumOver = 2
	'        Exit Function
	'    End If
	''2009/09/05 ADD E.N.D RISE)MIYAJIMA
	'
	'    F_Util_CheckSumOver = 0
	'End Function
	'2009/09/24 DEL E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_CheckSumOver
	'   概要：  変更差額上限チェック
	'   引数：
	'   戻値：
	'   備考： 入金額変更時・入金取消時に、請求サマリの消込入金額残累計より、変更差額・取消額が大きい時はエラーとし、再入力を促す。
	'          Ex.) 消込入金額残が100万の時、150万の入金伝票を40万に変更・または取消することはできない。→差額が100万以上のため。50万以上なら変更可。
	'          ※海外得意先の時は、請求サマリ外貨の消込入金残額累計を判断基準にする。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_CheckSumOver(ByRef pm_All As Cls_All, ByRef pm_Mode As Short) As Short
		
		Dim curAryMOTKN(9) As Decimal '変更前の金額
		Dim curAryCHGKN(9) As Decimal '変更後の金額
		Dim curMOTKN As Decimal '変更前の金額
		Dim curCHGKN As Decimal '変更後の金額
		Dim curZANKN As Decimal 'SQL でDBから取得する請求サマリ．消込入金額残
		Dim I As Short
		Dim intCnt As Short
		Dim intRet As Short
		
		F_Util_CheckSumOver = 9
		
		'変更後の金額を取得 (請求サマリ更新時の条件を考慮して集計)
		'UPGRADE_NOTE: Erase は System.Array.Clear にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		System.Array.Clear(curAryCHGKN, 0, curAryCHGKN.Length)
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'デフォルトコード≠３
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID) <> "" Then
				If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.DFLDKBCD) <> "3" Then
					'2009/10/05 UPD START RISE)MIYAJIMA
					'        curAryCHGKN(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID) = _
					''        curAryCHGKN(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID) + _
					''        pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
					If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
						curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) = curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.FNYUKN
					Else
						curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) = curAryCHGKN(CInt(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.SYSTBD.UPDID)) + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
					End If
					'2009/10/05 UPD E.N.D RISE)MIYAJIMA
				End If
			End If
		Next intCnt
		
		'変更前の金額を取得 (請求サマリ更新時の条件を考慮して集計)
		With URKET52_HEAD_Inf
			'UPGRADE_NOTE: Erase は System.Array.Clear にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
			System.Array.Clear(curAryMOTKN, 0, curAryMOTKN.Length)
			For intCnt = 1 To UBound(.UDNTRA)
				'デフォルトコード≠３
				If Trim(.UDNTRA(intCnt).DFLDKBCD) <> "3" Then
					'2009/10/05 UPD START RISE)MIYAJIMA
					'                curAryMOTKN(.UDNTRA(intCnt).UPDID) = _
					''                curAryMOTKN(.UDNTRA(intCnt).UPDID) + _
					''                .UDNTRA(intCnt).NYUKN
					If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
						curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) = curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) + .UDNTRA(intCnt).FNYUKN
					Else
						curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) = curAryMOTKN(CInt(.UDNTRA(intCnt).UPDID)) + .UDNTRA(intCnt).NYUKN
					End If
					'2009/10/05 UPD E.N.D RISE)MIYAJIMA
				End If
			Next intCnt
		End With
		
		'2009/09/30 UPD START RISE)MIYAJIMA
		'金額チェック
		
		For I = 0 To 9
			Select Case URKET52_HEAD_Inf.TOKMTA.SHAKB
				Case pc_strSHAKB_HURI, pc_strSHAKB_TEG, pc_strSHAKB_HURI_OR_TEG, pc_strSHAKB_HURI_AND_TEG
					If I <> 7 Then '振込仮(UPDID = 7)
						curMOTKN = curMOTKN + curAryMOTKN(I)
						curCHGKN = curCHGKN + curAryCHGKN(I)
						curZANKN = curZANKN + gc_NKSSMX_Inf.curZAN(I)
					End If
				Case pc_strSHAKB_KIJZITU, pc_strSHAKB_FACTERING
					curMOTKN = curMOTKN + curAryMOTKN(I)
					curCHGKN = curCHGKN + curAryCHGKN(I)
					curZANKN = curZANKN + gc_NKSSMX_Inf.curZAN(I)
			End Select
		Next I
		
		'訂正時
		If pm_Mode = 1 Then
			If curMOTKN <> 0 Or curCHGKN <> 0 Then
				If curZANKN - (curMOTKN - curCHGKN) < 0 Then
					F_Util_CheckSumOver = 2
					Exit Function
				End If
			End If
		End If
		
		'削除時
		If pm_Mode = 9 Then
			If curMOTKN <> 0 Then
				If curZANKN - curMOTKN < 0 Then
					F_Util_CheckSumOver = 2
					Exit Function
				End If
			End If
		End If
		
		'    '金種単位の残額チェック
		'    For I = 0 To 9
		'
		'        '訂正時
		'        If pm_Mode = 1 Then
		'            If curAryMOTKN(I) <> 0 Or curAryCHGKN(I) <> 0 Then
		'                If gc_NKSSMX_Inf.curZAN(I) - (curAryMOTKN(I) - curAryCHGKN(I)) < 0 Then
		'                    F_Util_CheckSumOver = 2
		'                    Exit Function
		'                End If
		'            End If
		'        End If
		'
		'        '削除時
		'        If pm_Mode = 9 Then
		'            If curAryMOTKN(I) <> 0 Then
		'                If gc_NKSSMX_Inf.curZAN(I) - curAryMOTKN(I) < 0 Then
		'                    F_Util_CheckSumOver = 2
		'                    Exit Function
		'                End If
		'            End If
		'        End If
		'
		'    Next I
		'
		'    'グロスの残額チェック
		'    If curZANKN <> 0 Then
		'        'チェック
		'        '変更前の金額　－　変更後の金額　＞　請求サマリ．消込入金額残
		'        If curMOTKN < 0 Or curCHGKN < 0 Then
		'            If Abs(curMOTKN - curCHGKN) > Abs(curZANKN) Then
		'                F_Util_CheckSumOver = 2
		'                Exit Function
		'            End If
		'        Else
		'            If Abs(curMOTKN) - Abs(curCHGKN) > Abs(curZANKN) Then
		'                F_Util_CheckSumOver = 2
		'                Exit Function
		'            End If
		'        End If
		'    End If
		'
		'    If curZANKN = 0 And curMOTKN <> 0 And curMOTKN > curCHGKN Then
		'        F_Util_CheckSumOver = 2
		'        Exit Function
		'    End If
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		F_Util_CheckSumOver = 0
	End Function
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/24 DEL START RISE)MIYAJIMA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function F_Util_CheckSumOver_GetZANKN
	''   概要：  変更差額上限チェック用
	''           チェックに使う請求サマリ．消込入金額残を取得する
	''   引数：  pot_curZANKN：請求サマリ．消込入金額残
	''   戻値：
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function F_Util_CheckSumOver_GetZANKN(pm_All As Cls_All _
	''                                            , ByRef pot_curZANKN As Currency) As Integer
	'    Dim strSQL          As String
	'    Dim Usr_Ody_LC      As U_Ody
	'
	'On Error GoTo ERR_F_Util_CheckSumOver_GetZANKN
	'
	'    F_Util_CheckSumOver_GetZANKN = 9
	'
	'    With URKET52_HEAD_Inf
	'        If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
	'            '海外
	'            strSQL = ""
	'            strSQL = strSQL & " SELECT SUM(FKSZANKN) AS SUMDATA "
	'            strSQL = strSQL & " FROM TOKSSC "
	'            strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
	'            strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
	'            strSQL = strSQL & "   AND SSADT = '" & CF_Ora_String(.UDNTHA.SSADT, 8) & "' "
	'        Else
	'            '国内
	'            strSQL = ""
	'            strSQL = strSQL & " SELECT SUM(KSKZANKN) AS SUMDATA "
	'            If .NYUKB = gc_strMAEUKKB_NML Then  '入金
	'                strSQL = strSQL & " FROM TOKSSA "
	'            Else                                '前受入金
	'                strSQL = strSQL & " FROM TOKSSB "
	'            End If
	'            strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
	'            strSQL = strSQL & "   AND SSADT = '" & CF_Ora_String(.UDNTHA.SSADT, 8) & "' "
	'        End If
	'    End With
	'
	'    'DBアクセス
	'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
	'
	'    If CF_Ora_EOF(Usr_Ody_LC) = True Then
	'        '取得データなし
	'        pot_curZANKN = 0
	'    Else
	'        '取得データあり
	'        pot_curZANKN = CF_Ora_GetDyn(Usr_Ody_LC, "SUMDATA", 0)
	'    End If
	'
	'    F_Util_CheckSumOver_GetZANKN = 0
	'
	'END_F_Util_CheckSumOver_GetZANKN:
	'
	'    'クローズ
	'    Call CF_Ora_CloseDyn(Usr_Ody_LC)
	'
	'    Exit Function
	'
	'ERR_F_Util_CheckSumOver_GetZANKN:
	'    GoTo END_F_Util_CheckSumOver_GetZANKN
	'
	'End Function
	'2009/09/24 DEL E.N.D RISE)MIYAJIMA
	
	'2009/09/24 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_CheckSumOver_GetZANKN
	'   概要：  変更差額上限チェック用
	'           チェックに使う消込サマリ．消込入金額残を取得する
	'   引数：  pot_curZANKN：消込サマリ．消込入金額残構造体
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_CheckSumOver_GetZANKN(ByRef pm_All As Cls_All) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim I As Short
		'UPGRADE_WARNING: 構造体 UsrNKSSMX_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim UsrNKSSMX_Inf As TYPE_NKSSMX
		
		On Error GoTo ERR_F_Util_CheckSumOver_GetZANKN
		
		F_Util_CheckSumOver_GetZANKN = 9
		
		With URKET52_HEAD_Inf
			If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				'海外
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM NKSSMC "
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
				'2009/09/29 UPD START RISE)MIYAJIMA
				'            strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(.UDNTHA.SMADT, 8) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				'2009/09/29 UPD E.N.D RISE)MIYAJIMA
			Else
				'国内
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				If .NYUKB = gc_strMAEUKKB_NML Then '入金
					strSQL = strSQL & " FROM NKSSMA "
				Else '前受入金
					strSQL = strSQL & " FROM NKSSMB "
				End If
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				'2009/09/29 UPD START RISE)MIYAJIMA
				'            strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(.UDNTHA.SMADT, 8) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				'2009/09/29 UPD E.N.D RISE)MIYAJIMA
			End If
		End With

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody_LC) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '取得データあり
            With UsrNKSSMX_Inf
                For I = 0 To 9
                    'change start 20190826 kuwa
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.curSSANYUKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "SSANYUKN" & VB6.Format(I, "00"), 0)
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.curKSKNYKKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "KSKNYKKN" & VB6.Format(I, "00"), 0)
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody_LC, "KSKZANKN" & VB6.Format(I, "00"), 0)

                    'add start 20190826 kuwa
                    ReDim Preserve .curSSANYUKN(I)
                    ReDim Preserve .curKSKNYKKN(I)
                    ReDim Preserve .curKSKZANKN(I)
                    ReDim Preserve .curZAN(I)
                    'add end 20190826 
                    .curSSANYUKN(I) = DB_NullReplace(dt.Rows(0)("SSANYUKN" & VB6.Format(I, "00")), 0)
                    .curKSKNYKKN(I) = DB_NullReplace(dt.Rows(0)("KSKNYKKN" & VB6.Format(I, "00")), 0)
                    .curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                    'change end 20190826 kuwa
                    .curZAN(I) = .curSSANYUKN(I) - .curKSKNYKKN(I) + .curKSKZANKN(I)
                    If I <> 8 Then '本入金は相手にしない
                        .curTOTAL = .curTOTAL + .curZAN(I)
                    End If
                Next I
                'change start 20190826 kuwa
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.strOPEID = CF_Ora_GetDyn(Usr_Ody_LC, "OPEID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.strCLTID = CF_Ora_GetDyn(Usr_Ody_LC, "CLTID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.strWRTTM = CF_Ora_GetDyn(Usr_Ody_LC, "WRTTM", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.strWRTDT = CF_Ora_GetDyn(Usr_Ody_LC, "WRTDT", "")

                .strOPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                .strCLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                .strWRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                .strWRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                'change end 20190826 kuwa
            End With
        End If

        'UPGRADE_WARNING: オブジェクト gc_NKSSMX_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gc_NKSSMX_Inf = UsrNKSSMX_Inf
		
		F_Util_CheckSumOver_GetZANKN = 0
		
END_F_Util_CheckSumOver_GetZANKN: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_F_Util_CheckSumOver_GetZANKN: 
		GoTo END_F_Util_CheckSumOver_GetZANKN
		
	End Function
	'2009/09/24 ADD E.N.D RISE)MIYAJIMA
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_NYUKN_Sum
	'   概要：  入金額・合計(円)の集計処理
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_NYUKN_Sum(ByRef pm_All As Cls_All)
		Dim intCnt As Short
		Dim Trg_Index As Short
		Dim blnEmpty As Boolean 'True=すべて未入力
		Dim Dsp_Value As Object
		Dim curNYUKN As Decimal
		
		blnEmpty = True
		curNYUKN = 0
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【入金額(円)】
			Trg_Index = CShort(FR_SSSMAIN.BD_NYUKN(intCnt).Tag)
			
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))) <> "" Then
				blnEmpty = False
				curNYUKN = curNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
			End If
		Next intCnt
		
		pv_curNYUKN_SUM = curNYUKN
		Trg_Index = CShort(FR_SSSMAIN.TL_SBANYUKN.Tag)
		If blnEmpty = True Then
			'すべて未入力だったら、空白表示
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		Else
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(pv_curNYUKN_SUM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub F_Util_FNYUKN_Sum
	'   概要：  入金額・合計(外貨)の集計処理
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub F_Util_FNYUKN_Sum(ByRef pm_All As Cls_All)
		Dim intCnt As Short
		Dim Trg_Index As Short
		Dim blnEmpty As Boolean 'True=すべて未入力
		Dim Dsp_Value As Object
		Dim dblFNYUKN As Double
		
		blnEmpty = True
		dblFNYUKN = 0
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			'【入金額(外貨)】
			Trg_Index = CShort(FR_SSSMAIN.BD_FNYUKN(intCnt).Tag)
			
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Trg_Index))) <> "" Then
				blnEmpty = False
				dblFNYUKN = dblFNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.FNYUKN
			End If
		Next intCnt
		
		pv_dblFNYUKN_SUM = dblFNYUKN
		Trg_Index = CShort(FR_SSSMAIN.TL_SBAFRNKN.Tag)
		If blnEmpty = True Then
			'すべて未入力だったら、空白表示
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Trg_Index), ITM_ALL_ONLY, pm_All)
		Else
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Cnv_Dsp_Item(pv_dblFNYUKN_SUM, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		End If
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_GET_TANMTA_KEIBMNCD
	'   概要：  経理部門コードを取得
	'   引数：　pot_strTANCD       : 担当者コード
	'       ：　pot_strKEIBMNCD    : 経理部門コード
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Util_GET_TANMTA_KEIBMNCD(ByRef pot_strTANCD As String, ByRef pot_strKEIBMNCD As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strTANBMNCD As String '所属部門コード
		Dim strOLDBMNCD As String '旧所属部門コード
		Dim strTANTKDT As String '適用日
		Dim strZMBMNCD As String '会計部門コード
		Dim strTKDT As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_KEIBMNCD
		
		F_Util_GET_TANMTA_KEIBMNCD = 9
		
		strTKDT = Replace(URKET52_HEAD_Inf.NYUDT, "/", "")
		
		'担当者Ｍ
		strSQL = ""
		strSQL = strSQL & " SELECT TANBMNCD, OLDBMNCD, TANTKDT "
		strSQL = strSQL & " FROM TANMTA "
		strSQL = strSQL & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'strTANBMNCD = CF_Ora_GetDyn(Usr_Ody, "TANBMNCD", "")
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strOLDBMNCD = CF_Ora_GetDyn(Usr_Ody, "OLDBMNCD", "")
            ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'strTANTKDT = CF_Ora_GetDyn(Usr_Ody, "TANTKDT", "")

            strTANBMNCD = DB_NullReplace(dt.Rows(0)("TANBMNCD"), "")
            strOLDBMNCD = DB_NullReplace(dt.Rows(0)("OLDBMNCD"), "")
            strTANTKDT = DB_NullReplace(dt.Rows(0)("TANTKDT"), "")
            'change end 20190826 kuwa
        Else
            GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		End If
		
		'部門Ｍ
		strSQL = ""
		strSQL = strSQL & " SELECT ZMBMNCD "
		strSQL = strSQL & " FROM BMNMTA "
		strSQL = strSQL & " WHERE "
		'UPGRADE_WARNING: オブジェクト SSSVal(strTANTKDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(strTKDT) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(strTKDT) >= SSSVal(strTANTKDT) Then
			strSQL = strSQL & " BMNCD = '" & strTANBMNCD & "' "
		Else
			strSQL = strSQL & " BMNCD = '" & strOLDBMNCD & "' "
		End If
		strSQL = strSQL & " AND '" & strTKDT & "' BETWEEN STTTKDT AND ENDTKDT "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190827 kuwa
            'strZMBMNCD = CF_Ora_GetDyn(Usr_Ody, "ZMBMNCD", "")
            strZMBMNCD = DB_NullReplace(dt.Rows(0)("ZMBMNCD"), "")
            'change end 20190827 kuwa
        Else
            GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		End If
		
		'経理部門コードを引数へ設定する
		pot_strKEIBMNCD = strZMBMNCD
		
		F_Util_GET_TANMTA_KEIBMNCD = 0
		
END_F_Util_GET_TANMTA_KEIBMNCD: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Util_GET_TANMTA_KEIBMNCD: 
		GoTo END_F_Util_GET_TANMTA_KEIBMNCD
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_Upd_Process
    '   概要：  更新メインルーチン
    '   引数：　なし
    '   戻値：　0 :更新終了　9:更新なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
        Dim intRet As Short

        On Error GoTo Err_F_Ctl_Upd_Process

        F_Ctl_Upd_Process = 9

        If gv_bolUpdFlg = True Then
            Exit Function
        End If

        gv_bolUpdFlg = True

        '砂時計にする
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        'アクティブコントロールのＬＦ処理
        If CF_Ctl_Item_LostFocus_Dummy(pm_All) <> CHK_OK Then
            'チェックNGの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        '画面の内容を退避
        Call CF_Body_Bkup(pm_All)

        'ヘッダ部のチェック
        intRet = F_Ctl_Head_Chk(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        'ボディ部のチェック
        intRet = F_Ctl_Body_Chk(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        'テイル部のチェック
        intRet = F_Ctl_Tail_Chk(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        '全体チェック
        intRet = F_Ctl_ALL_RelChk(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If

        '2009/10/05 ADD START RISE)MIYAJIMA
        '受注の排他情報取得　（ただし、前受のみ）
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
            Call F_Get_JDN_HAITA(pm_All)
        End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        '2009/06/08 ADD START FKS)NAKATA
        '「受注金額=入金額」のチェック　（ただし、前受のみ）
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_UODKN_JDNNO(pm_All)
            If intRet <> CHK_OK Then
                'チェックＮＧの場合
                GoTo End_F_Ctl_Upd_Process
            End If

        End If
        '2009/06/08 ADD E.N.D FKS)NAKATA
        '*** 2009/09/07 ADD START FKS)NAKATA
        ''消込のチェック　（ただし、前受のみ）
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_KESIZUMI(pm_All)
            If intRet <> CHK_OK Then
                'チェックＮＧの場合
                GoTo End_F_Ctl_Upd_Process
            End If
        End If
        '*** 2009/09/07 ADD E.N.D FKS)NAKATA

        '2009/09/18 ADD START RISE)MIYAJIMA
        '期日到来チェック
        intRet = F_Chk_AllKESAIBI(pm_All)
        If intRet <> CHK_OK Then
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/18 ADD E.N.D RISE)MIYAJIMA

        '2009/09/29 DEL START RISE)MIYAJIMA
        ''2009/09/24 ADD START RISE)MIYAJIMA
        '    '変更差額上限チェック
        '    If F_Util_CheckSumOver(pm_All, 1) <> 0 Then
        '        'メッセージ出力
        '        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
        '        'チェックＮＧの場合
        '        GoTo End_F_Ctl_Upd_Process
        '    End If
        ''2009/09/24 ADD E.N.D RISE)MIYAJIMA
        '2009/09/29 DEL E.N.D RISE)MIYAJIMA

        '2009/10/05 ADD START RISE)MIYAJIMA
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
            intRet = F_Chk_EXIST_MotoJDNNO(pm_All)
            If intRet <> 0 Then
                Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_038, pm_All) ' MSG内容:関連した受注が完了している為、更新できません。
                GoTo End_F_Ctl_Upd_Process
            End If
        End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        'マウスポインタを戻す
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        gv_bolURKET52_LF_Enable = False

        'Windowsに処理を返す
        System.Windows.Forms.Application.DoEvents()

        gv_bolURKET52_LF_Enable = True

        '受注登録の権限がない場合は処理を行わない
        If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_003, pm_All)
            GoTo End_F_Ctl_Upd_Process
        End If

        '経理締日付、締日付、決済日付 取得
        intRet = F_Util_Get_Simebi(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.TOKCD, pv_strSMADT, pv_strSSADT, pv_strKESDT)
        If intRet <> 0 Then
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_027, pm_All)
            GoTo End_F_Ctl_Upd_Process
        End If

        '2009/09/30 ADD START RISE)MIYAJIMA
        '消込サマリ．消込入金額残 を取得
        intRet = F_Util_CheckSumOver_GetZANKN(pm_All)
        If intRet <> 0 Then
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/30 ADD E.N.D RISE)MIYAJIMA

        '2009/09/29 ADD START RISE)MIYAJIMA
        '変更差額上限チェック
        If F_Util_CheckSumOver(pm_All, 1) <> 0 Then
            'メッセージ出力
            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
            'チェックＮＧの場合
            GoTo End_F_Ctl_Upd_Process
        End If
        '2009/09/29 ADD E.N.D RISE)MIYAJIMA

        '''' ADD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
        '画面.入金日の年月 < 受注伝票日付の年月の場合はエラー
        If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then

            intRet = F_Chk_NYUDT_JDNDT(pm_All)
            If intRet <> CHK_OK Then
                'チェックＮＧの場合
                GoTo End_F_Ctl_Upd_Process
            End If

        End If
        '''' ADD 2009/11/10  FKS) T.Yamamoto    End

        '登録確認
        If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_005, pm_All) = MsgBoxResult.No Then
            GoTo End_F_Ctl_Upd_Process
        End If

        '初期ﾌｫｰｶｽ位置設定
        Call F_Init_Cursor_Set(pm_All)

        'ボタン非表示
        'delete start 20190826 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = False
        'delete end 20190826 kuwa

        '登録処理
        intRet = F_Update_Main(pm_All)
        If intRet <> 0 Then
            F_Ctl_Upd_Process = intRet
            GoTo Err_F_Ctl_Upd_Process
        End If

        '登録完了
        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_006, pm_All)

        F_Ctl_Upd_Process = 0

End_F_Ctl_Upd_Process:
        'マウスポインタを戻す
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'ボタン表示
        '2019/06/06 DEL START
        'FR_SSSMAIN.CM_Execute.Visible = True
        '2019/06/06 DEL END
        gv_bolUpdFlg = False

        'キーフラグを元に戻す
        gv_bolKeyFlg = False
        Exit Function

Err_F_Ctl_Upd_Process:
        GoTo End_F_Ctl_Upd_Process

    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Update_Main
    '   概要：  更新メイン処理
    '   引数：  pm_All        : 画面情報
    '   戻値：　0：正常終了　9:異常終了
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Update_Main(ByRef pm_All As Cls_All) As Short
		Dim intRet As Short
		Dim strDATNO As String '伝票管理№
		Dim strDenNo As String '伝票№
		Dim strRecNo As String 'レコード管理№
		Dim intCnt As Short
		Dim bolTran As Boolean
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim bolAKAKRO As Boolean
		Dim strSMADT_Rec As String
		Dim strSSADT_Rec As String
		Dim strKESDT_Rec As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		Dim int_DspIndex As Short
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		On Error GoTo F_Update_Main_err
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_Update_Main = 9
		bolTran = False
		
		'更新時刻 取得
		Call CF_Get_SysDt()

        'トランザクションの開始
        '2019/05/23 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/05/23 CHG END
        bolTran = True
		
		'売上見出トランの排他制御
		With URKET52_HEAD_Inf.UDNTHA
			intRet = F_UDNTHA_Exicz(.DATNO, .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End With
		
		'売上トランの排他制御
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			With URKET52_HEAD_Inf.UDNTRA(intCnt)
				intRet = F_UDNTRA_Exicz(.DATNO, CShort(.LINNO), .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
				If intRet <> 0 Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
			End With
		Next 
		
		'// V1.20↓ ADD
		intRet = F_Chk_HAITA_JDNNO(pm_All)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		'// V1.20↑ ADD
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'受注見出トランの排他制御
			intRet = F_JDNTHA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'受注トランの排他制御
			intRet = F_JDNTRA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'入金消込サマリの排他制御
		intRet = F_Chk_HAITA_NKSSMX(pm_All)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		'月またぎかどうか判断する
		intRet = AE_UpdateURI_Chk_AkaKro(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.UDNTHA.SMADT, URKET52_HEAD_Inf.UDNTHA.SSADT)
		If intRet = 0 Then
			bolAKAKRO = False
		Else
			bolAKAKRO = True
		End If
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'--------------------------------------------------------------------------------
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'決済日が期日到来しているか判断する（変更前データで判断）
		Call F_Util_Tourai(pm_All)
		
		Select Case pv_intTouraiKbn
			Case 0
				
				If bolAKAKRO = False Then
					
					' --- 当月度内 ---
					
					'売上見出トラン 論理削除
					'UPGRADE_WARNING: オブジェクト F_UDNTHA_Update_DelF() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'売上トラン 論理削除
					'UPGRADE_WARNING: オブジェクト F_UDNTRA_Update_DelF() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'入金訂正対象ボタンで取得したデータをコピー
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
						
						'サマリファイル群更新
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
					Next 
					
				Else
					
					' --- 前月度以前 ---
					
					'新しい伝票管理№を取得
					intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'赤伝票データを新規登録する
					
					'入金訂正対象ボタンで取得したデータをコピーして変更していく
					'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTHA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
					With Tbl_Inf_UDNTHA
						.DATNO = strDATNO
						.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
						.SBANYUKN = .SBANYUKN * -1 'マイナス値
						.SBAFRNKN = .SBAFRNKN * -1 'マイナス値
						.MOTDATNO = URKET52_HEAD_Inf.DATNO
						.UDNDT = URKET52_HEAD_Inf.NYUDT
						.SMADT = pv_strSMADT
						.SSADT = pv_strSSADT
						.KESDT = pv_strKESDT
						.FOPEID = SSS_OPEID.Value '初回登録ユーザID
						.FCLTID = SSS_CLTID.Value '初回登録クライアントID
						.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
						.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
						.OPEID = SSS_OPEID.Value '最終作業者コード
						.CLTID = SSS_CLTID.Value 'クライアントＩＤ
						.WRTTM = GV_SysTime 'タイムスタンプ（時間）
						.WRTDT = GV_SysDate 'タイムスタンプ（日付）
						.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
						.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
						.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
						.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
						.PGID = SSS_PrgId '更新PGID
						.DLFLG = gc_strDLFLG_UPD
					End With
					
					'売上見出トラン新規登録 (赤伝票)
					intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						
						'新しいレコード管理№を取得
						intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						'赤伝票データを新規登録する
						
						'入金訂正対象ボタンで取得したデータをコピーして変更していく
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.DATNO = strDATNO
							.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
							.RECNO = strRecNo
							.NYUKN = .NYUKN * -1 'マイナス値
							.FNYUKN = .FNYUKN * -1 'マイナス値
							
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = .OKRJONO
							'2009/06/05 ADD START FKS)NAKATA
							
							.MOTDATNO = URKET52_HEAD_Inf.DATNO
							.UDNDT = URKET52_HEAD_Inf.NYUDT
							.SMADT = pv_strSMADT
							.SSADT = pv_strSSADT
							.KESDT = pv_strKESDT
							.FOPEID = SSS_OPEID.Value '初回登録ユーザID
							.FCLTID = SSS_CLTID.Value '初回登録クライアントID
							.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
							.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
							.OPEID = SSS_OPEID.Value '最終作業者コード
							.CLTID = SSS_CLTID.Value 'クライアントＩＤ
							.WRTTM = GV_SysTime 'タイムスタンプ（時間）
							.WRTDT = GV_SysDate 'タイムスタンプ（日付）
							.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
							.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
							.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
							.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
							.PGID = SSS_PrgId '更新PGID
							.DLFLG = gc_strDLFLG_UPD
						End With
						
						'売上トラン新規登録 (赤伝票)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA 'サマリ更新処理で更新用変数を使用している為、金額等の符号を反転
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'サマリファイル群更新
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
					Next 
				End If
				
			Case Else
				
				' --- 期日到来 ---
				
				'新しい伝票管理№を取得
				intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
				
				'赤伝票データを新規登録する
				
				'入金訂正対象ボタンで取得したデータをコピーして変更していく
				'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTHA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
				With Tbl_Inf_UDNTHA
					.DATNO = strDATNO
					.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
					.SBANYUKN = .SBANYUKN * -1 'マイナス値
					.SBAFRNKN = .SBAFRNKN * -1 'マイナス値
					.MOTDATNO = URKET52_HEAD_Inf.DATNO
					.UDNDT = URKET52_HEAD_Inf.NYUDT
					.SMADT = pv_strSMADT
					.SSADT = pv_strSSADT
					.KESDT = pv_strKESDT
					.FOPEID = SSS_OPEID.Value '初回登録ユーザID
					.FCLTID = SSS_CLTID.Value '初回登録クライアントID
					.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
					.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
					.OPEID = SSS_OPEID.Value '最終作業者コード
					.CLTID = SSS_CLTID.Value 'クライアントＩＤ
					.WRTTM = GV_SysTime 'タイムスタンプ（時間）
					.WRTDT = GV_SysDate 'タイムスタンプ（日付）
					.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
					.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
					.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
					.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
					.PGID = SSS_PrgId '更新PGID
					.DLFLG = gc_strDLFLG_UPD
				End With
				
				'売上見出トラン新規登録 (赤伝票)
				intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
				
				For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
					
					'新しいレコード管理№を取得
					intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
					If intRet <> 0 Then
						F_Update_Main = intRet
						GoTo F_Update_Main_err
					End If
					
					'赤伝票データを新規登録する
					
					If URKET52_HEAD_Inf.TEGKB(intCnt) = 0 Then
						
						'入金訂正対象ボタンで取得したデータをコピーして変更していく
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.DATNO = strDATNO
							.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
							.RECNO = strRecNo
							.NYUKN = .NYUKN * -1 'マイナス値
							.FNYUKN = .FNYUKN * -1 'マイナス値
							
							'2009/06/05 ADD START FKS)NAKATA
							.OKRJONO = .OKRJONO
							'2009/06/05 ADD START FKS)NAKATA
							
							.MOTDATNO = URKET52_HEAD_Inf.DATNO
							.UDNDT = URKET52_HEAD_Inf.NYUDT
							.SMADT = pv_strSMADT
							.SSADT = pv_strSSADT
							.KESDT = pv_strKESDT
							.FOPEID = SSS_OPEID.Value '初回登録ユーザID
							.FCLTID = SSS_CLTID.Value '初回登録クライアントID
							.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
							.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
							.OPEID = SSS_OPEID.Value '最終作業者コード
							.CLTID = SSS_CLTID.Value 'クライアントＩＤ
							.WRTTM = GV_SysTime 'タイムスタンプ（時間）
							.WRTDT = GV_SysDate 'タイムスタンプ（日付）
							.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
							.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
							.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
							.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
							.PGID = SSS_PrgId '更新PGID
							.DLFLG = gc_strDLFLG_UPD
						End With
						
						'売上トラン新規登録 (赤伝票)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA 'サマリ更新処理で更新用変数を使用している為、金額等の符号を反転
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'サマリファイル群更新
						intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
					Else
						
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
						With Tbl_Inf_UDNTRA
							.NYUKN = .NYUKN * -1 'マイナス値
							.FNYUKN = .FNYUKN * -1 'マイナス値
						End With
						
						'画面に格納されている場所を検索
						'UPGRADE_WARNING: オブジェクト F_Get_DspIndex() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						int_DspIndex = F_Get_DspIndex(pm_All, Tbl_Inf_UDNTRA.DATNO, Tbl_Inf_UDNTRA.LINNO)
						
						'伝票№は、登録済みのものを使う
						strDenNo = URKET52_HEAD_Inf.UDNTHA.UDNNO
						
						'売上トラン登録データ作成
						intRet = F_UDNTRA_MakeInf_Tourai(pm_All, int_DspIndex, strDATNO, strDenNo, strRecNo, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						'売上トラン新規登録 (赤伝票)
						intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
						With Tbl_Inf_UDNTRA 'サマリ更新処理で更新用変数を使用している為、金額等の符号を反転
							.NYUKN = .NYUKN * -1
							.FNYUKN = .FNYUKN * -1
						End With
						
						'サマリファイル群更新
						intRet = F_UPDSMF2(pm_All, intCnt, -1, Tbl_Inf_UDNTRA, URKET52_HEAD_Inf.UDNTRA(intCnt).DKBID, URKET52_HEAD_Inf.DKBID(intCnt), URKET52_HEAD_Inf.TEGKB(intCnt))
						If intRet <> 0 Then
							F_Update_Main = intRet
							GoTo F_Update_Main_err
						End If
						
					End If
					
				Next 
				
		End Select
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/30 DEL START RISE)MIYAJIMA
		''2009/09/24 UPD START RISE)MIYAJIMA
		''    If URKET52_HEAD_Inf.UDNTHA.SMADT > pv_strMONUPDDT Then
		'    If bolAKAKRO = False Then
		'        '当月度内
		''2009/09/24 UPD E.N.D RISE)MIYAJIMA
		'
		'        '売上見出トラン 論理削除
		'        intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        '売上トラン 論理削除
		'        intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, False)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
		'            '入金訂正対象ボタンで取得したデータをコピー
		'            Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
		'            Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
		'
		'            'サマリファイル群更新
		'            intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'        Next
		'    Else
		'
		'        '前月度
		'
		'        '新しい伝票管理№を取得
		'        intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        '赤伝票データを新規登録する
		'
		'        '入金訂正対象ボタンで取得したデータをコピーして変更していく
		'        Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
		'        With Tbl_Inf_UDNTHA
		'            .DATNO = strDATNO
		'            .AKAKROKB = gc_strAKAKROKB_AKA      '赤伝票
		'            .SBANYUKN = .SBANYUKN * -1          'マイナス値
		'            .SBAFRNKN = .SBAFRNKN * -1          'マイナス値
		'            .MOTDATNO = URKET52_HEAD_Inf.DATNO
		'            .UDNDT = URKET52_HEAD_Inf.NYUDT
		'            .SMADT = pv_strSMADT
		'            .SSADT = pv_strSSADT
		'            .KESDT = pv_strKESDT
		'            .FOPEID = SSS_OPEID         '初回登録ユーザID
		'            .FCLTID = SSS_CLTID         '初回登録クライアントID
		'            .WRTFSTTM = GV_SysTime      'タイムスタンプ（登録時間）
		'            .WRTFSTDT = GV_SysDate      'タイムスタンプ（登録日）
		'            .OPEID = SSS_OPEID          '最終作業者コード
		'            .CLTID = SSS_CLTID          'クライアントＩＤ
		'            .WRTTM = GV_SysTime         'タイムスタンプ（時間）
		'            .WRTDT = GV_SysDate         'タイムスタンプ（日付）
		'            .UOPEID = SSS_OPEID         'ユーザID（バッチ）
		'            .UCLTID = SSS_CLTID         'クライアントID（バッチ）
		'            .UWRTTM = GV_SysTime        'タイムスタンプ（バッチ時間）
		'            .UWRTDT = GV_SysDate        'タイムスタンプ（バッチ日付）
		'            .PGID = SSS_PrgId           '更新PGID
		'            .DLFLG = gc_strDLFLG_UPD
		'        End With
		'
		'        '売上見出トラン新規登録 (赤伝票)
		'        intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
		'        If intRet <> 0 Then
		'            F_Update_Main = intRet
		'            GoTo F_Update_Main_err
		'        End If
		'
		'        For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
		'
		'            '新しいレコード管理№を取得
		'            intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'
		'            '赤伝票データを新規登録する
		'
		'            '入金訂正対象ボタンで取得したデータをコピーして変更していく
		'            Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
		'            With Tbl_Inf_UDNTRA
		'                .DATNO = strDATNO
		'                .AKAKROKB = gc_strAKAKROKB_AKA      '赤伝票
		'                .RECNO = strRecNo
		'                .NYUKN = .NYUKN * -1                'マイナス値
		'                .FNYUKN = .FNYUKN * -1              'マイナス値
		'
		'                '2009/06/05 ADD START FKS)NAKATA
		'                .OKRJONO = .OKRJONO
		'                '2009/06/05 ADD START FKS)NAKATA
		'
		'                .MOTDATNO = URKET52_HEAD_Inf.DATNO
		'                .UDNDT = URKET52_HEAD_Inf.NYUDT
		'                .SMADT = pv_strSMADT
		'                .SSADT = pv_strSSADT
		'                .KESDT = pv_strKESDT
		'                .FOPEID = SSS_OPEID         '初回登録ユーザID
		'                .FCLTID = SSS_CLTID         '初回登録クライアントID
		'                .WRTFSTTM = GV_SysTime      'タイムスタンプ（登録時間）
		'                .WRTFSTDT = GV_SysDate      'タイムスタンプ（登録日）
		'                .OPEID = SSS_OPEID          '最終作業者コード
		'                .CLTID = SSS_CLTID          'クライアントＩＤ
		'                .WRTTM = GV_SysTime         'タイムスタンプ（時間）
		'                .WRTDT = GV_SysDate         'タイムスタンプ（日付）
		'                .UOPEID = SSS_OPEID         'ユーザID（バッチ）
		'                .UCLTID = SSS_CLTID         'クライアントID（バッチ）
		'                .UWRTTM = GV_SysTime        'タイムスタンプ（バッチ時間）
		'                .UWRTDT = GV_SysDate        'タイムスタンプ（バッチ日付）
		'                .PGID = SSS_PrgId           '更新PGID
		'                .DLFLG = gc_strDLFLG_UPD
		'            End With
		'
		'            '売上トラン新規登録 (赤伝票)
		'            intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'
		'            With Tbl_Inf_UDNTRA 'サマリ更新処理で更新用変数を使用している為、金額等の符号を反転
		'                .NYUKN = .NYUKN * -1
		'                .FNYUKN = .FNYUKN * -1
		'            End With
		'
		'            'サマリファイル群更新
		'            intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                F_Update_Main = intRet
		'                GoTo F_Update_Main_err
		'            End If
		'        Next
		'    End If
		'2009/09/30 DEL E.N.D RISE)MIYAJIMA
		
		'--------------------------------------------------------------------------------
		
		'新しい伝票管理№を取得
		intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'伝票№は、登録済みのものを使う
		strDenNo = URKET52_HEAD_Inf.UDNTHA.UDNNO
		
		
		'売上見出トラン登録データ作成
		intRet = F_UDNTHA_MakeInf(pm_All, strDATNO, strDenNo, Tbl_Inf_UDNTHA)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'売上見出トラン新規登録
		intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		'受取手形削除 (サマリファイル群更新時に登録)
		intRet = F_UTGTRA_Delete(pm_All, strDenNo)
		If intRet <> 0 Then
			F_Update_Main = intRet
			GoTo F_Update_Main_err
		End If
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'新しいレコード管理№を取得
			intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'売上トラン登録データ作成
			intRet = F_UDNTRA_MakeInf(pm_All, intCnt, strDATNO, strDenNo, strRecNo, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'売上トラン新規登録
			intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'サマリファイル群更新
			intRet = F_UPDSMF(pm_All, intCnt, 1, Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'更新条件：伝票区分＝８ かつ 手形発生フラグ＝１
			If Tbl_Inf_UDNTRA.DENKB = "8" And Tbl_Inf_UDNTRA.DKBTEGFL = "1" Then
				'受取手形トランの更新
				intRet = F_UTGTRA(pm_All, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_Update_Main = intRet
					GoTo F_Update_Main_err
				End If
			End If
		Next intCnt
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'受注見出トラン タイムスタンプ更新
			'UPGRADE_WARNING: オブジェクト F_JDNTHA_Upd_TimeStamp() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_JDNTHA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
			
			'受注トラン 　　タイムスタンプ更新
			'UPGRADE_WARNING: オブジェクト F_JDNTRA_Upd_TimeStamp() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_JDNTRA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_Update_Main = intRet
				GoTo F_Update_Main_err
			End If
		End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        'コミット
        '2019/05/23 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/05/23 CHG END
        bolTran = False
		
		F_Update_Main = 0
		
F_Update_Main_End: 
		'砂時計を戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_Update_Main_err: 
		
		If bolTran = True Then
            'ロールバック
            '2019/05/23 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/05/23 CHG END
        End If
		
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_UpdDel_Process
	'   概要：  削除メインルーチン
	'   引数：　なし
	'   戻値：　0 :更新終了　9:更新なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_UpdDel_Process(ByRef pm_All As Cls_All) As Short
		Dim intRet As Short
		Dim Index_Wk As Short
		
		On Error GoTo Err_F_Ctl_UpdDel_Process
		
		F_Ctl_UpdDel_Process = 9
		
		If gv_bolDelFlg = True Then
			Exit Function
		End If
		
		gv_bolDelFlg = True
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'アクティブコントロールのＬＦ処理
		If CF_Ctl_Item_LostFocus_Dummy(pm_All) <> CHK_OK Then
			'チェックNGの場合
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'入金訂正対象のチェック
		If Trim(URKET52_HEAD_Inf.DATNO) = "" Then
			'チェックＮＧの場合
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_024, pm_All)
			
			Index_Wk = CShort(FR_SSSMAIN.HD_DATNO.Tag)
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'入金日のチェック
		If URKET52_HEAD_Inf.NYUDT > GV_UNYDate Then
			'チェックＮＧの場合
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_015, pm_All)
			
			Index_Wk = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
			
			GoTo End_F_Ctl_UpdDel_Process
		Else
			'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
			'月次本締日の条件撤廃
			'        '前回月次更新実行日より過去はエラー
			'        If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strMONUPDDT) Then
			'前回経理締実行日より過去はエラー
			If Trim(URKET52_HEAD_Inf.NYUDT) <= Trim(pv_strSMAUPDDT) Then
				'''' UPD 2011/01/14  FKS) T.Yamamoto    End
				'チェックＮＧの場合
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_016, pm_All)
				
				Index_Wk = CShort(FR_SSSMAIN.HD_NYUDT.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		'受注の排他情報取得　（ただし、前受のみ）
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			Call F_Get_JDN_HAITA(pm_All)
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'*** 2009/09/07 ADD START FKS)NAKATA
		'消込のチェック　（ただし、前受のみ）
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			
			intRet = F_Chk_KESIZUMI(pm_All)
			If intRet <> CHK_OK Then
				'チェックＮＧの場合
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		
		'2009/09/29 DEL START RISE)MIYAJIMA
		''2009/09/24 ADD START RISE)MIYAJIMA
		'    '変更差額上限チェック
		'    If F_Util_CheckSumOver(pm_All, 9) <> 0 Then
		'        'メッセージ出力
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
		'        'チェックＮＧの場合
		'        GoTo End_F_Ctl_UpdDel_Process
		'    End If
		''2009/09/24 ADD E.N.D RISE)MIYAJIMA
		'2009/09/29 DEL E.N.D RISE)MIYAJIMA
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			intRet = F_Chk_EXIST_MotoJDNNO(pm_All)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_038, pm_All) ' MSG内容:関連した受注が完了している為、更新できません。
				GoTo End_F_Ctl_UpdDel_Process
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		gv_bolURKET52_LF_Enable = False
		
		'Windowsに処理を返す
		System.Windows.Forms.Application.DoEvents()
		
		gv_bolURKET52_LF_Enable = True
		
		'受注登録の権限がない場合は処理を行わない
		If Inp_Inf.InpJDNUPDKB <> gc_strJDNUPDKB_OK Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_003, pm_All)
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'経理締日付、締日付、決済日付 取得
		intRet = F_Util_Get_Simebi(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.TOKCD, pv_strSMADT, pv_strSSADT, pv_strKESDT)
		If intRet <> 0 Then
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_027, pm_All)
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'2009/09/30 ADD START RISE)MIYAJIMA
		'消込サマリ．消込入金額残 を取得
		intRet = F_Util_CheckSumOver_GetZANKN(pm_All)
		If intRet <> 0 Then
			GoTo End_F_Ctl_UpdDel_Process
		End If
		'2009/09/30 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/29 ADD START RISE)MIYAJIMA
		'変更差額上限チェック
		If F_Util_CheckSumOver(pm_All, 9) <> 0 Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_029, pm_All)
			'チェックＮＧの場合
			GoTo End_F_Ctl_UpdDel_Process
		End If
		'2009/09/29 ADD E.N.D RISE)MIYAJIMA
		
		'削除確認
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_028, pm_All) = MsgBoxResult.No Then
			GoTo End_F_Ctl_UpdDel_Process
		End If
		
		'初期ﾌｫｰｶｽ位置設定
		Call F_Init_Cursor_Set(pm_All)

        'ボタン非表示
        'delete start 20190828 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = False
        'delete end 20190828 kuwa

        '削除処理
        intRet = F_UpdateDel_Main(pm_All)
		If intRet <> 0 Then
			F_Ctl_UpdDel_Process = intRet
			GoTo Err_F_Ctl_UpdDel_Process
		End If
		
		'削除完了
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_A_006, pm_All)
		
		F_Ctl_UpdDel_Process = 0
		
End_F_Ctl_UpdDel_Process: 
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        'ボタン表示
        'delete start 20190828 kuwa
        'FR_SSSMAIN.CM_Execute.Visible = True
        'delete end 20190828 kuwa
        gv_bolDelFlg = False
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		Exit Function
		
Err_F_Ctl_UpdDel_Process: 
		GoTo End_F_Ctl_UpdDel_Process
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UpdateDel_Main
	'   概要：  削除メイン処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_UpdateDel_Main(ByRef pm_All As Cls_All) As Short
		Dim intRet As Short
		Dim strDATNO As String '伝票管理№
		Dim strDenNo As String '伝票№
		Dim strRecNo As String 'レコード管理№
		Dim intCnt As Short
		Dim bolTran As Boolean
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		Dim bolAKAKRO As Boolean
		Dim strSMADT_Rec As String
		Dim strSSADT_Rec As String
		Dim strKESDT_Rec As String
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		On Error GoTo F_UpdateDel_Main_err
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		F_UpdateDel_Main = 9
		bolTran = False
		
		'更新時刻 取得
		Call CF_Get_SysDt()

        'トランザクションの開始
        '2019/05/23 CHG START
        'Call CF_Ora_BeginTrans(gv_Oss_USR1)
        Call DB_BeginTrans(CON)
        '2019/05/23 CHG END
        bolTran = True
		
		'売上見出トランの排他制御
		With URKET52_HEAD_Inf.UDNTHA
			intRet = F_UDNTHA_Exicz(.DATNO, .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End With
		
		'売上トランの排他制御
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			With URKET52_HEAD_Inf.UDNTRA(intCnt)
				intRet = F_UDNTRA_Exicz(.DATNO, CShort(.LINNO), .FOPEID, .FCLTID, .WRTFSTTM, .WRTFSTDT, .OPEID, .CLTID, .WRTTM, .WRTDT, .UOPEID, .UCLTID, .UWRTTM, .UWRTDT)
				If intRet <> 0 Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			End With
		Next 
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'受注見出トランの排他制御
			intRet = F_JDNTHA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'受注トランの排他制御
			intRet = F_JDNTRA_Exicz()
			If intRet <> 0 Then
				Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_026, pm_All) ' MSG内容:他端末で更新中です。
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End If
		'2009/10/05 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 ADD START RISE)MIYAJIMA
		'月またぎかどうか判断する
		intRet = AE_UpdateURI_Chk_AkaKro(URKET52_HEAD_Inf.NYUDT, URKET52_HEAD_Inf.UDNTHA.SMADT, URKET52_HEAD_Inf.UDNTHA.SSADT)
		If intRet = 0 Then
			bolAKAKRO = False
		Else
			bolAKAKRO = True
		End If
		'2009/09/24 ADD E.N.D RISE)MIYAJIMA
		
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.UDNTHA.SMADT > pv_strMONUPDDT Then
		If bolAKAKRO = False Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'当月度内
			
			'売上見出トラン 論理削除
			'UPGRADE_WARNING: オブジェクト F_UDNTHA_Update_DelF() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_UDNTHA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, True)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'売上トラン 論理削除
			'UPGRADE_WARNING: オブジェクト F_UDNTRA_Update_DelF() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_UDNTRA_Update_DelF(pm_All, URKET52_HEAD_Inf.UDNTHA.DATNO, True)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
				'入金訂正対象ボタンで取得したデータをコピー
				'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
				Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL
				
				'サマリファイル群更新
				intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			Next 
		Else
			'前月度
			
			'新しい伝票管理№を取得
			intRet = F_SYSTBA_SaibanDATNO(pm_All, strDATNO)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'赤伝票データを新規登録する
			
			'入金訂正対象ボタンで取得したデータをコピーして変更していく
			'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTHA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Tbl_Inf_UDNTHA = URKET52_HEAD_Inf.UDNTHA
			With Tbl_Inf_UDNTHA
				.DATNO = strDATNO
				.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
				.SBANYUKN = .SBANYUKN * -1 'マイナス値
				.SBAFRNKN = .SBAFRNKN * -1 'マイナス値
				.MOTDATNO = URKET52_HEAD_Inf.DATNO
				.UDNDT = URKET52_HEAD_Inf.NYUDT
				.SMADT = pv_strSMADT
				.SSADT = pv_strSSADT
				.KESDT = pv_strKESDT
				.FOPEID = SSS_OPEID.Value '初回登録ユーザID
				.FCLTID = SSS_CLTID.Value '初回登録クライアントID
				.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
				.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
				.OPEID = SSS_OPEID.Value '最終作業者コード
				.CLTID = SSS_CLTID.Value 'クライアントＩＤ
				.WRTTM = GV_SysTime 'タイムスタンプ（時間）
				.WRTDT = GV_SysDate 'タイムスタンプ（日付）
				.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
				.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
				.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
				.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
				.PGID = SSS_PrgId '更新PGID
				.DLFLG = gc_strDLFLG_UPD
			End With
			
			'売上見出トラン新規登録 (赤伝票)
			intRet = F_UDNTHA_Insert(pm_All, Tbl_Inf_UDNTHA)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
				
				'新しいレコード管理№を取得
				intRet = F_SYSTBA_SaibanRECNO(pm_All, strRecNo)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
				
				'赤伝票データを新規登録する
				
				'入金訂正対象ボタンで取得したデータをコピーして変更していく
				'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
				With Tbl_Inf_UDNTRA
					.DATNO = strDATNO
					.AKAKROKB = gc_strAKAKROKB_AKA '赤伝票
					.RECNO = strRecNo
					.NYUKN = .NYUKN * -1 'マイナス値
					.FNYUKN = .FNYUKN * -1 'マイナス値
					
					'2009/06/05 ADD START FKS)NAKATA
					.OKRJONO = .OKRJONO
					'2009/06/05 ADD E.N.D FKS)NAKATA
					
					.MOTDATNO = URKET52_HEAD_Inf.DATNO
					.UDNDT = URKET52_HEAD_Inf.NYUDT
					.SMADT = pv_strSMADT
					.SSADT = pv_strSSADT
					.KESDT = pv_strKESDT
					.FOPEID = SSS_OPEID.Value '初回登録ユーザID
					.FCLTID = SSS_CLTID.Value '初回登録クライアントID
					.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
					.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
					.OPEID = SSS_OPEID.Value '最終作業者コード
					.CLTID = SSS_CLTID.Value 'クライアントＩＤ
					.WRTTM = GV_SysTime 'タイムスタンプ（時間）
					.WRTDT = GV_SysDate 'タイムスタンプ（日付）
					.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
					.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
					.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
					.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
					.PGID = SSS_PrgId '更新PGID
					.DLFLG = gc_strDLFLG_UPD
				End With
				
				'売上トラン新規登録 (赤伝票)
				intRet = F_UDNTRA_Insert(pm_All, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
				
				With Tbl_Inf_UDNTRA 'サマリ更新処理で更新用変数を使用している為、金額等の符号を反転
					.NYUKN = .NYUKN * -1
					.FNYUKN = .FNYUKN * -1
				End With
				
				'サマリファイル群更新
				intRet = F_UPDSMF(pm_All, intCnt, -1, Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					F_UpdateDel_Main = intRet
					GoTo F_UpdateDel_Main_err
				End If
			Next 
		End If
		
		'受取手形削除
		intRet = F_UTGTRA_Delete(pm_All, URKET52_HEAD_Inf.UDNTHA.UDNNO)
		If intRet <> 0 Then
			F_UpdateDel_Main = intRet
			GoTo F_UpdateDel_Main_err
		End If
		
		'2009/10/05 ADD START RISE)MIYAJIMA
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'受注見出トラン タイムスタンプ更新
			'UPGRADE_WARNING: オブジェクト F_JDNTHA_Upd_TimeStamp() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_JDNTHA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
			
			'受注トラン 　　タイムスタンプ更新
			'UPGRADE_WARNING: オブジェクト F_JDNTRA_Upd_TimeStamp() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			intRet = F_JDNTRA_Upd_TimeStamp(pm_All)
			If intRet <> 0 Then
				F_UpdateDel_Main = intRet
				GoTo F_UpdateDel_Main_err
			End If
		End If
        '2009/10/05 ADD E.N.D RISE)MIYAJIMA

        'コミット
        '2019/05/23 CHG START
        'Call CF_Ora_CommitTrans(gv_Oss_USR1)
        Call DB_Commit()
        '2019/05/23 CHG END
        bolTran = False
		
		F_UpdateDel_Main = 0
		
F_UpdateDel_Main_End: 
		'砂時計を戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		Exit Function
		
F_UpdateDel_Main_err: 
		
		If bolTran = True Then
            'ロールバック
            '2019/05/23 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '2019/05/23 CHG END
        End If
		
		GoTo F_UpdateDel_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBA_SaibanDATNO
	'   概要：  伝票管理NO採番処理
	'   引数：  pm_All        : 画面情報
	'           pot_strDATNO  : 伝票管理No
	'   戻値：  0:正常  1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBA_SaibanDATNO(ByRef pm_All As Cls_All, ByRef pot_strDatNo As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy As U_Ody
		Dim curDatNo As Decimal
		Dim curSTTDATNO As Decimal
		Dim curENDDATNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBA_SaibanDATNO_err
		
		F_SYSTBA_SaibanDATNO = 9
		
		'SQL：データ取得＆ロック
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBA "
		strSQL = strSQL & "    FOR UPDATE " 'ロック

        'change start 20190826 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBA_SaibanDATNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'EOF判定
        'change start 20190826 kuwa
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            F_SYSTBA_SaibanDATNO = 1
            GoTo F_SYSTBA_SaibanDATNO_err
        End If

        'データ取得
        'change start 20190826 kuwa
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curSTTDATNO = CDec(CF_Ora_GetDyn(usrOdy, "STTDATNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curENDDATNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDDATNO", "0"))
        curDatNo = CDec(DB_NullReplace(dt.Rows(0)("DATNO"), 0))
        curSTTDATNO = CDec(DB_NullReplace(dt.Rows(0)("STTDATNO"), 0))
        curENDDATNO = CDec(DB_NullReplace(dt.Rows(0)("ENDDATNO"), 0))
        'change end 20190826 kuwa
        curDatNo = curDatNo + 1
		
		'開始・終了番号の範囲でないならリセット
		If curDatNo < curSTTDATNO Or curDatNo > curENDDATNO Then
			curDatNo = curSTTDATNO
		End If
		
		pot_strDatNo = VB6.Format(CStr(curDatNo), "0000000000")
		
		'SQL：更新処理
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET DATNO = '" & CF_Ora_String(pot_strDatNo, 10) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（登録日）
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBA_SaibanDATNO_err
		End If
		
		'正常終了
		F_SYSTBA_SaibanDATNO = 0
		
F_SYSTBA_SaibanDATNO_end: 
		Exit Function
		
F_SYSTBA_SaibanDATNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBA_SaibanDATNO")
		
		GoTo F_SYSTBA_SaibanDATNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBA_SaibanRECNO
	'   概要：  レコード管理NO採番処理
	'   引数：  pm_All        : 画面情報
	'           pot_strRECNO  : レコード管理No
	'   戻値：  0:正常  1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBA_SaibanRECNO(ByRef pm_All As Cls_All, ByRef pot_strRECNO As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy As U_Ody
		Dim curRecNo As Decimal
		Dim curSTTRECNO As Decimal
		Dim curENDRECNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBA_SaibanRECNO_err
		
		F_SYSTBA_SaibanRECNO = 9
		
		'SQL：データ取得＆ロック
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBA "
		strSQL = strSQL & "    FOR UPDATE " 'ロック

        'change start 20190827 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBA_SaibanRECNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190827 kuwa

        'EOF判定
        'change start 20190827 kuwa
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190827 kuwa
            F_SYSTBA_SaibanRECNO = 1
            GoTo F_SYSTBA_SaibanRECNO_err
        End If

        'データ取得
        'change start 20190827 kuwa
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curSTTRECNO = CDec(CF_Ora_GetDyn(usrOdy, "STTRECNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curENDRECNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDRECNO", "0"))
        curRecNo = CDec(DB_NullReplace(dt.Rows(0)("RECNO"), "0"))
        curSTTRECNO = CDec(DB_NullReplace(dt.Rows(0)("STTRECNO"), "0"))
        curENDRECNO = CDec(DB_NullReplace(dt.Rows(0)("ENDRECNO"), "0"))
        'change end 20190827 kuwa
        curRecNo = curRecNo + 1
		
		'開始・終了番号の範囲でないならリセット
		If curRecNo < curSTTRECNO Or curRecNo > curENDRECNO Then
			curRecNo = curSTTRECNO
		End If
		
		pot_strRECNO = VB6.Format(CStr(curRecNo), "0000000000")
		
		'SQL：更新処理
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET RECNO = '" & CF_Ora_String(pot_strRECNO, 10) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（登録日）
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBA_SaibanRECNO_err
		End If
		
		'正常終了
		F_SYSTBA_SaibanRECNO = 0
		
F_SYSTBA_SaibanRECNO_end: 
		Exit Function
		
F_SYSTBA_SaibanRECNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBA_SaibanRECNO")
		
		GoTo F_SYSTBA_SaibanRECNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SYSTBC_SaibanDENNO
	'   概要：  伝票管理NO採番処理
	'   引数：  pm_All        : 画面情報
	'           pot_strDENNO  : 伝票管理No
	'   戻値：  0:正常  1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_SaibanDENNO(ByRef pm_All As Cls_All, ByRef Pot_strDENNO As String) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 usrOdy の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim usrOdy As U_Ody
		Dim curDENNO As Decimal
		Dim curSTTDENNO As Decimal
		Dim curENDDENNO As Decimal
		Dim bolRet As Boolean
		
		On Error GoTo F_SYSTBC_SaibanDENNO_err
		
		F_SYSTBC_SaibanDENNO = 9
		
		'SQL：データ取得＆ロック
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM SYSTBC "
		strSQL = strSQL & "  WHERE DKBSB = '" & CF_Ora_String(pc_strDKBSB_URK, 3) & "' "
		strSQL = strSQL & "    AND ADDDENCD IS NOT NULL "
		strSQL = strSQL & "    FOR UPDATE " 'ロック

        'change start 20190827 kuwa
        'bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
        'If bolRet = False Then
        'GoTo F_SYSTBC_SaibanDENNO_err
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190827 kuwa

        'EOF判定
        'If CF_Ora_EOF(usrOdy) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190827 kuwa
            F_SYSTBC_SaibanDENNO = 1
            GoTo F_SYSTBC_SaibanDENNO_err
        End If

        'データ取得
        'change start 20190827 kuwa
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '      curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curSTTDENNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", "0"))
        ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'curENDDENNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", "0"))
        curDENNO = CDec(DB_NullReplace(dt.Rows(0)("DENNO"), "0"))
        curSTTDENNO = CDec(DB_NullReplace(dt.Rows(0)("STTNO"), "0"))
        curENDDENNO = CDec(DB_NullReplace(dt.Rows(0)("ENDNO"), "0"))
        'change end 20190827 kuwa

        curDENNO = curDENNO + 1
		
		'開始・終了番号の範囲でないならリセット
		If curDENNO < curSTTDENNO Or curDENNO > curENDDENNO Then
			curDENNO = curSTTDENNO
		End If
		
		Pot_strDENNO = VB6.Format(CStr(curDENNO), "00000000")
		
		'SQL：更新処理
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBC "
		strSQL = strSQL & "    SET DENNO = '" & CF_Ora_String(Pot_strDENNO, 8) & "' "
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM    = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT    = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , WRTFSTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "      , WRTFSTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "  WHERE DKBSB = '" & CF_Ora_String(pc_strDKBSB_URK, 3) & "' "
		strSQL = strSQL & "    AND ADDDENCD IS NOT NULL "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_SYSTBC_SaibanDENNO_err
		End If
		
		'正常終了
		F_SYSTBC_SaibanDENNO = 0
		
F_SYSTBC_SaibanDENNO_end: 
		Exit Function
		
F_SYSTBC_SaibanDENNO_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_SYSTBC_SaibanDENNO")
		
		GoTo F_SYSTBC_SaibanDENNO_end
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTHA_MakeInf
	'   概要：  売上見出トラン登録データ作成
	'   引数：  pm_All             : 画面情報
	'           pin_strDATNO       : 伝票管理NO.
	'           pin_strDENNO       : 伝票番号
	'           pot_Tbl_Inf_UDNTHA : 売上見出トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_MakeInf(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByRef pot_Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA) As Short
		Dim strBUMCD As String
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		
		On Error GoTo F_UDNTHA_MakeInf_err
		
		F_UDNTHA_MakeInf = 9
		
		'経理部門コードを取得
		Call F_Util_GET_TANMTA_KEIBMNCD(URKET52_HEAD_Inf.TOKMTA.TANCD, strBUMCD)
		
		With Tbl_Inf_UDNTHA
			.DATNO = pin_strDATNO '伝票管理NO.
			.DATKB = gc_strDATKB_USE '伝票削除区分  １：使用中
			.AKAKROKB = gc_strAKAKROKB_KURO '赤黒区分      １：黒伝票
			.DENKB = "8" '伝票区分      ８：入金
			.UDNNO = pin_strDENNO '売上伝票番号
			.FDNNO = "" '納品書№
			.JDNNO = "" '受注伝票番号
			.USDNO = "" '直送伝票NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '売上伝票日付
			.DENDT = GV_UNYDate '売上日付
			.REGDT = URKET52_HEAD_Inf.NYUDT '初回伝票日付
			.TOKCD = URKET52_HEAD_Inf.TOKCD '得意先コード
			.TOKRN = URKET52_HEAD_Inf.TOKMTA.TOKRN '得意先略称
			.NHSCD = "" '納入先コード
			.NHSRN = "" '納入先略称
			.NHSNMA = "" '納入先名称１
			.NHSNMB = "" '納入先名称２
			.TANCD = "" '担当者コード
			.TANNM = "" '担当者名
			.BUMCD = "" '部門コード
			.BUMNM = "" '部門名
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '請求先コード
			.SOUCD = "" '倉庫コード
			.SOUNM = "" '倉庫名
			.NXTKB = "" '帳端区分
			.NXTNM = "" '帳端名称
			.EMGODNKB = "" '緊急出荷区分
			.OKRJONO = "" '送り状№
			.INVNO = "" 'インボイス№
			.SMADT = pv_strSMADT '経理締日付
			.SSADT = pv_strSSADT '締日付
			.KESDT = pv_strKESDT '決済日付
			.NYUCD = URKET52_HEAD_Inf.NYUKB '入金区分
			.ZKTKB = "" '取引区分
			.ZKTNM = "" '取引区分名
			.KENNMA = "" '件名１
			.KENNMB = "" '件名２
			.NHSADA = "" '納入先住所１
			.NHSADB = "" '納入先住所２
			.NHSADC = "" '納入先住所３
			.MAEUKNM = "" '前受区分名称
			.KEIBUMCD = strBUMCD '経理部門コード
			.UPFKB = "1" '売上同時出荷区分
			.SBAURIKN = 0 '売上金額(本体合計)
			.SBAUZEKN = 0 '売上金額(消費税額)
			.SBAUZKKN = 0 '売上金額(伝票計)
			.SBAFRUKN = 0 '外貨売上金額(伝票計)
			.SBANYUKN = pv_curNYUKN_SUM '入金金額(伝票計)
			.SBAFRNKN = pv_dblFNYUKN_SUM '外貨入金額(伝票計)
			.DENCM = "" '備考
			.DENCMIN = "" '社内備考
			.TOKSMEKB = URKET52_HEAD_Inf.TOKMTA.TOKSMEKB '締区分
			.TOKSMEDD = URKET52_HEAD_Inf.TOKMTA.TOKSMEDD '締初期日付(売上)
			.TOKSMECC = URKET52_HEAD_Inf.TOKMTA.TOKSMECC '締サイクル(売上)
			.TOKSDWKB = URKET52_HEAD_Inf.TOKMTA.TOKSDWKB '締め曜日
			.TOKKESCC = URKET52_HEAD_Inf.TOKMTA.TOKKESCC '回収サイクル
			.TOKKESDD = URKET52_HEAD_Inf.TOKMTA.TOKKESDD '回収日付
			.TOKKDWKB = URKET52_HEAD_Inf.TOKMTA.TOKKDWKB '回収曜日
			.LSTID = URKET52_HEAD_Inf.TOKMTA.LSTID '伝票種別
			.TOKJUNKB = URKET52_HEAD_Inf.TOKMTA.TOKJUNKB '順位表出力区分
			.TOKMSTKB = URKET52_HEAD_Inf.TOKMTA.TOKMSTKB 'マスタ区分(得意先)
			.TKNRPSKB = URKET52_HEAD_Inf.TOKMTA.TKNRPSKB '金額端数処理桁数
			.TKNZRNKB = URKET52_HEAD_Inf.TOKMTA.TKNZRNKB '金額端数処理区分
			.TOKZEIKB = URKET52_HEAD_Inf.TOKMTA.TOKZEIKB '消費税区分
			.TOKZCLKB = URKET52_HEAD_Inf.TOKMTA.TOKZCLKB '消費税算出区分
			.TOKRPSKB = URKET52_HEAD_Inf.TOKMTA.TOKRPSKB '消費税端数処理桁数
			.TOKZRNKB = URKET52_HEAD_Inf.TOKMTA.TOKZRNKB '消費税端数処理区分
			.TOKNMMKB = URKET52_HEAD_Inf.TOKMTA.TOKNMMKB '名称ﾏﾆｭｱﾙ区分
			.NHSMSTKB = "" 'マスタ区分(納入先)
			.NHSNMMKB = "" '名称ﾏﾆｭｱﾙ区分
			.TANMSTKB = "" 'マスタ区分(担当者)
			.URIKJN = "" '売上基準
			.MAEUKKB = "" '前受区分
			.SEIKB = "" '請求区分
			.JDNTRKB = "" '受注取引区分
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '通貨区分
			.FRNKB = URKET52_HEAD_Inf.TOKMTA.FRNKB '海外取引区分
			.UDNPRAKB = "" '納品書発行区分
			.UDNPRBKB = "" '個別請求発行区分
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '元伝票管理番号
			.FOPEID = SSS_OPEID.Value '初回登録ユーザID
			.FCLTID = SSS_CLTID.Value '初回登録クライアントID
			.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
			.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
			.OPEID = SSS_OPEID.Value '最終作業者コード
			.CLTID = SSS_CLTID.Value 'クライアントＩＤ
			.WRTTM = GV_SysTime 'タイムスタンプ（時間）
			.WRTDT = GV_SysDate 'タイムスタンプ（日付）
			.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
			.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
			.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
			.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
			.PGID = SSS_PrgId '更新PGID
			.DLFLG = gc_strDLFLG_UPD '削除フラグ
		End With
		
		'UPGRADE_WARNING: オブジェクト pot_Tbl_Inf_UDNTHA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_Tbl_Inf_UDNTHA = Tbl_Inf_UDNTHA
		
		F_UDNTHA_MakeInf = 0
		
F_UDNTHA_MakeInf_end: 
		Exit Function
		
F_UDNTHA_MakeInf_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_MakeInf")
		GoTo F_UDNTHA_MakeInf_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTHA_Insert
	'   概要：  売上見出トラン新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTHA : 売上見出トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTHA_Insert_err
		
		F_UDNTHA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "        ( DATNO " '伝票管理NO.
		strSQL = strSQL & "        , DATKB " '伝票削除区分
		strSQL = strSQL & "        , AKAKROKB " '赤黒区分
		strSQL = strSQL & "        , DENKB " '伝票区分
		strSQL = strSQL & "        , UDNNO " '売上伝票番号
		strSQL = strSQL & "        , FDNNO " '納品書№
		strSQL = strSQL & "        , JDNNO " '受注伝票番号
		strSQL = strSQL & "        , USDNO " '直送伝票NO
		strSQL = strSQL & "        , UDNDT " '売上伝票日付
		strSQL = strSQL & "        , DENDT " '売上日付
		strSQL = strSQL & "        , REGDT " '初回伝票日付
		strSQL = strSQL & "        , TOKCD " '得意先コード
		strSQL = strSQL & "        , TOKRN " '得意先略称
		strSQL = strSQL & "        , NHSCD " '納入先コード
		strSQL = strSQL & "        , NHSRN " '納入先略称
		strSQL = strSQL & "        , NHSNMA " '納入先名称１
		strSQL = strSQL & "        , NHSNMB " '納入先名称２
		strSQL = strSQL & "        , TANCD " '担当者コード
		strSQL = strSQL & "        , TANNM " '担当者名
		strSQL = strSQL & "        , BUMCD " '部門コード
		strSQL = strSQL & "        , BUMNM " '部門名
		strSQL = strSQL & "        , TOKSEICD " '請求先コード
		strSQL = strSQL & "        , SOUCD " '倉庫コード
		strSQL = strSQL & "        , SOUNM " '倉庫名
		strSQL = strSQL & "        , NXTKB " '帳端区分
		strSQL = strSQL & "        , NXTNM " '帳端名称
		strSQL = strSQL & "        , EMGODNKB " '緊急出荷区分
		strSQL = strSQL & "        , OKRJONO " '送り状№
		strSQL = strSQL & "        , INVNO " 'インボイス№
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSADT " '締日付
		strSQL = strSQL & "        , KESDT " '決済日付
		strSQL = strSQL & "        , NYUCD " '入金区分
		strSQL = strSQL & "        , ZKTKB " '取引区分
		strSQL = strSQL & "        , ZKTNM " '取引区分名
		strSQL = strSQL & "        , KENNMA " '件名１
		strSQL = strSQL & "        , KENNMB " '件名２
		strSQL = strSQL & "        , NHSADA " '納入先住所１
		strSQL = strSQL & "        , NHSADB " '納入先住所２
		strSQL = strSQL & "        , NHSADC " '納入先住所３
		strSQL = strSQL & "        , MAEUKNM " '前受区分名称
		strSQL = strSQL & "        , KEIBUMCD " '経理部門コード
		strSQL = strSQL & "        , UPFKB " '売上同時出荷区分
		strSQL = strSQL & "        , SBAURIKN " '売上金額(本体合計)
		strSQL = strSQL & "        , SBAUZEKN " '売上金額(消費税額)
		strSQL = strSQL & "        , SBAUZKKN " '売上金額(伝票計)
		strSQL = strSQL & "        , SBAFRUKN " '外貨売上金額(伝票計)
		strSQL = strSQL & "        , SBANYUKN " '入金金額(伝票計)
		strSQL = strSQL & "        , SBAFRNKN " '外貨入金額(伝票計)
		strSQL = strSQL & "        , DENCM " '備考
		strSQL = strSQL & "        , DENCMIN " '社内備考
		strSQL = strSQL & "        , TOKSMEKB " '締区分
		strSQL = strSQL & "        , TOKSMEDD " '締初期日付(売上)
		strSQL = strSQL & "        , TOKSMECC " '締サイクル(売上)
		strSQL = strSQL & "        , TOKSDWKB " '締め曜日
		strSQL = strSQL & "        , TOKKESCC " '回収サイクル
		strSQL = strSQL & "        , TOKKESDD " '回収日付
		strSQL = strSQL & "        , TOKKDWKB " '回収曜日
		strSQL = strSQL & "        , LSTID " '伝票種別
		strSQL = strSQL & "        , TOKJUNKB " '順位表出力区分
		strSQL = strSQL & "        , TOKMSTKB " 'マスタ区分(得意先)
		strSQL = strSQL & "        , TKNRPSKB " '金額端数処理桁数
		strSQL = strSQL & "        , TKNZRNKB " '金額端数処理区分
		strSQL = strSQL & "        , TOKZEIKB " '消費税区分
		strSQL = strSQL & "        , TOKZCLKB " '消費税算出区分
		strSQL = strSQL & "        , TOKRPSKB " '消費税端数処理桁数
		strSQL = strSQL & "        , TOKZRNKB " '消費税端数処理区分
		strSQL = strSQL & "        , TOKNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "        , NHSMSTKB " 'マスタ区分(納入先)
		strSQL = strSQL & "        , NHSNMMKB " '名称ﾏﾆｭｱﾙ区分
		strSQL = strSQL & "        , TANMSTKB " 'マスタ区分(担当者)
		strSQL = strSQL & "        , URIKJN " '売上基準
		strSQL = strSQL & "        , MAEUKKB " '前受区分
		strSQL = strSQL & "        , SEIKB " '請求区分
		strSQL = strSQL & "        , JDNTRKB " '受注取引区分
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , FRNKB " '海外取引区分
		strSQL = strSQL & "        , UDNPRAKB " '納品書発行区分
		strSQL = strSQL & "        , UDNPRBKB " '個別請求発行区分
		strSQL = strSQL & "        , MOTDATNO " '元伝票管理番号
		strSQL = strSQL & "        , FOPEID " '初回登録ユーザID
		strSQL = strSQL & "        , FCLTID " '初回登録クライアントID
		strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントＩＤ
		strSQL = strSQL & "        , WRTTM " 'タイムスタンプ（時間）
		strSQL = strSQL & "        , WRTDT " 'タイムスタンプ（日付）
		strSQL = strSQL & "        , UOPEID " 'ユーザID（バッチ）
		strSQL = strSQL & "        , UCLTID " 'クライアントID（バッチ）
		strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "        , PGID " '更新PGID
		strSQL = strSQL & "        , DLFLG " '削除フラグ
		strSQL = strSQL & "        ) "
		With pin_Tbl_Inf_UDNTHA
			strSQL = strSQL & " VALUES "
			strSQL = strSQL & "        ( '" & CF_Ora_String(.DATNO, 10) & "' " '伝票管理NO.
			strSQL = strSQL & "        , '" & CF_Ora_String(.DATKB, 1) & "' " '伝票削除区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.AKAKROKB, 1) & "' " '赤黒区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENKB, 1) & "' " '伝票区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNNO, 8) & "' " '売上伝票番号
			strSQL = strSQL & "        , '" & CF_Ora_String(.FDNNO, 8) & "' " '納品書№
			strSQL = strSQL & "        , '" & CF_Ora_String(.JDNNO, 10) & "' " '受注伝票番号
			strSQL = strSQL & "        , '" & CF_Ora_String(.USDNO, 8) & "' " '直送伝票NO
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNDT, 8) & "' " '売上伝票日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENDT, 8) & "' " '売上日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.REGDT, 8) & "' " '初回伝票日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKCD, 10) & "' " '得意先コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKRN, 40) & "' " '得意先略称
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSCD, 10) & "' " '納入先コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSRN, 40) & "' " '納入先略称
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMA, 60) & "' " '納入先名称１
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMB, 60) & "' " '納入先名称２
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANCD, 6) & "' " '担当者コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANNM, 40) & "' " '担当者名
			strSQL = strSQL & "        , '" & CF_Ora_String(.BUMCD, 6) & "' " '部門コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.BUMNM, 40) & "' " '部門名
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSEICD, 10) & "' " '請求先コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.SOUCD, 3) & "' " '倉庫コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.SOUNM, 20) & "' " '倉庫名
			strSQL = strSQL & "        , '" & CF_Ora_String(.NXTKB, 1) & "' " '帳端区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.NXTNM, 10) & "' " '帳端名称
			strSQL = strSQL & "        , '" & CF_Ora_String(.EMGODNKB, 1) & "' " '緊急出荷区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.OKRJONO, 15) & "' " '送り状№
			strSQL = strSQL & "        , '" & CF_Ora_String(.INVNO, 8) & "' " 'インボイス№
			strSQL = strSQL & "        , '" & CF_Ora_String(.SMADT, 8) & "' " '経理締日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.SSADT, 8) & "' " '締日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.KESDT, 8) & "' " '決済日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.NYUCD, 1) & "' " '入金区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.ZKTKB, 1) & "' " '取引区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.ZKTNM, 4) & "' " '取引区分名
			strSQL = strSQL & "        , '" & CF_Ora_String(.KENNMA, 40) & "' " '件名１
			strSQL = strSQL & "        , '" & CF_Ora_String(.KENNMB, 40) & "' " '件名２
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADA, 60) & "' " '納入先住所１
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADB, 60) & "' " '納入先住所２
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSADC, 60) & "' " '納入先住所３
			strSQL = strSQL & "        , '" & CF_Ora_String(.MAEUKNM, 10) & "' " '前受区分名称
			strSQL = strSQL & "        , '" & CF_Ora_String(.KEIBUMCD, 6) & "' " '経理部門コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.UPFKB, 1) & "' " '売上同時出荷区分
			strSQL = strSQL & "        ,  " & CStr(.SBAURIKN) '売上金額(本体合計)
			strSQL = strSQL & "        ,  " & CStr(.SBAUZEKN) '売上金額(消費税額)
			strSQL = strSQL & "        ,  " & CStr(.SBAUZKKN) '売上金額(伝票計)
			strSQL = strSQL & "        ,  " & CStr(.SBAFRUKN) '外貨売上金額(伝票計)
			strSQL = strSQL & "        ,  " & CStr(.SBANYUKN) '入金金額(伝票計)
			strSQL = strSQL & "        ,  " & CStr(.SBAFRNKN) '外貨入金額(伝票計)
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENCM, 40) & "' " '備考
			strSQL = strSQL & "        , '" & CF_Ora_String(.DENCMIN, 40) & "' " '社内備考
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMEKB, 1) & "' " '締区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMEDD, 2) & "' " '締初期日付(売上)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSMECC, 2) & "' " '締サイクル(売上)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKSDWKB, 1) & "' " '締め曜日
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKESCC, 2) & "' " '回収サイクル
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKESDD, 2) & "' " '回収日付
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKKDWKB, 1) & "' " '回収曜日
			strSQL = strSQL & "        , '" & CF_Ora_String(.LSTID, 7) & "' " '伝票種別
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKJUNKB, 1) & "' " '順位表出力区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKMSTKB, 1) & "' " 'マスタ区分(得意先)
			strSQL = strSQL & "        , '" & CF_Ora_String(.TKNRPSKB, 1) & "' " '金額端数処理桁数
			strSQL = strSQL & "        , '" & CF_Ora_String(.TKNZRNKB, 1) & "' " '金額端数処理区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZEIKB, 1) & "' " '消費税区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZCLKB, 1) & "' " '消費税算出区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKRPSKB, 1) & "' " '消費税端数処理桁数
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKZRNKB, 1) & "' " '消費税端数処理区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TOKNMMKB, 1) & "' " '名称ﾏﾆｭｱﾙ区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSMSTKB, 1) & "' " 'マスタ区分(納入先)
			strSQL = strSQL & "        , '" & CF_Ora_String(.NHSNMMKB, 1) & "' " '名称ﾏﾆｭｱﾙ区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TANMSTKB, 1) & "' " 'マスタ区分(担当者)
			strSQL = strSQL & "        , '" & CF_Ora_String(.URIKJN, 2) & "' " '売上基準
			strSQL = strSQL & "        , '" & CF_Ora_String(.MAEUKKB, 1) & "' " '前受区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.SEIKB, 1) & "' " '請求区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.JDNTRKB, 2) & "' " '受注取引区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.TUKKB, 3) & "' " '通貨区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.FRNKB, 1) & "' " '海外取引区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNPRAKB, 1) & "' " '納品書発行区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.UDNPRBKB, 1) & "' " '個別請求発行区分
			strSQL = strSQL & "        , '" & CF_Ora_String(.MOTDATNO, 10) & "' " '元伝票管理番号
			strSQL = strSQL & "        , '" & CF_Ora_String(.FOPEID, 8) & "' " '初回登録ユーザID
			strSQL = strSQL & "        , '" & CF_Ora_String(.FCLTID, 5) & "' " '初回登録クライアントID
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTFSTTM, 6) & "' " 'タイムスタンプ（登録時間）
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTFSTDT, 8) & "' " 'タイムスタンプ（登録日）
			strSQL = strSQL & "        , '" & CF_Ora_String(.OPEID, 8) & "' " '最終作業者コード
			strSQL = strSQL & "        , '" & CF_Ora_String(.CLTID, 5) & "' " 'クライアントＩＤ
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTTM, 6) & "' " 'タイムスタンプ（時間）
			strSQL = strSQL & "        , '" & CF_Ora_String(.WRTDT, 8) & "' " 'タイムスタンプ（日付）
			strSQL = strSQL & "        , '" & CF_Ora_String(.UOPEID, 8) & "' " 'ユーザID（バッチ）
			strSQL = strSQL & "        , '" & CF_Ora_String(.UCLTID, 5) & "' " 'クライアントID（バッチ）
			strSQL = strSQL & "        , '" & CF_Ora_String(.UWRTTM, 6) & "' " 'タイムスタンプ（バッチ時間）
			strSQL = strSQL & "        , '" & CF_Ora_String(.UWRTDT, 8) & "' " 'タイムスタンプ（バッチ日付）
			strSQL = strSQL & "        , '" & CF_Ora_String(.PGID, 7) & "' " '更新PGID
			strSQL = strSQL & "        , '" & CF_Ora_String(.DLFLG, 1) & "' " '削除フラグ
			strSQL = strSQL & "        ) "
		End With
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTHA_Insert_err
		End If
		
		F_UDNTHA_Insert = 0
		
F_UDNTHA_Insert_end: 
		Exit Function
		
F_UDNTHA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_Insert")
		GoTo F_UDNTHA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTHA_Update_DelF
	'   概要：  売上見出トラン論理削除処理
	'   引数：  pm_All             : 画面情報
	'           pin_strDATNO       : 伝票管理番号
	'           pin_blnUpdDLFLG    : True = DLFLG も更新
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTHA_Update_DelF(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_blnUpdDLFLG As Boolean) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTHA_Update_DelF_err
		
		'UPGRADE_WARNING: オブジェクト F_UDNTHA_Update_DelF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_UDNTHA_Update_DelF = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTHA "
		strSQL = strSQL & "    SET DATKB  = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '伝票削除区分
		strSQL = strSQL & "      , OPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID（バッチ）
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID（バッチ）
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
		If pin_blnUpdDLFLG = True Then
			strSQL = strSQL & "  , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_DEL, 1) & "' " '削除フラグ
		End If
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '伝票削除区分

        'SQL実行
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
			GoTo F_UDNTHA_Update_DelF_err
		End If
		
		'UPGRADE_WARNING: オブジェクト F_UDNTHA_Update_DelF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_UDNTHA_Update_DelF = 0
		
F_UDNTHA_Update_DelF_end: 
		Exit Function
		
F_UDNTHA_Update_DelF_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTHA_Update_DelF")
		GoTo F_UDNTHA_Update_DelF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTRA_MakeInf
	'   概要：  売上トラン登録データ作成
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_strDATNO       : 伝票管理NO.
	'           pin_strDENNO       : 伝票番号
	'           pin_strRECNO       : レコード管理NO.
	'           pot_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_MakeInf(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByVal pin_strRECNO As String, ByRef pot_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim strDKBSB As String
		Dim strDKBID As String
		Dim strDKBNM As String
		
		Dim curNYUKN As Decimal
		Dim dblFNYUKN As Double
		
		Dim strNYUKB As String
		
		Dim strLINCMA As String
		Dim strLINCMB As String
		Dim strBNKCD As String
		Dim strBNKNM As String
		Dim strTEGNO As String
		Dim strTEGDT As String
		Dim strUPDID As String
		Dim strDFLDKBCD As String
		Dim strDKBZAIFL As String
		Dim strDKBTEGFL As String
		Dim strDKBFLA As String
		Dim strDKBFLB As String
		Dim strDKBFLC As String
		
		'2009/06/05 ADD START FKS)NAKATA
		Dim strOKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim strKANKOZ As String
		
		On Error GoTo F_UDNTRA_MakeInf_err
		
		F_UDNTRA_MakeInf = 9
		
		'受注番号
		strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNNO
		strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNLINNO
		
		'2009/06/05 ADD START FKS)NAKATA
		strOKRJONO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.OKRJONO
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'取引区分
		strDKBSB = pc_strDKBSB_URK
		strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBID
		strDKBNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBNM
		
		'入金額
		curNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.NYUKN
		dblFNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.FNYUKN
		
		'入金種別
		'2009/09/18 UPD START RISE)MIYAJIMA
		'    Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
		'        Case "3":  strNYUKB = "4"
		'        Case "2":  strNYUKB = "2"
		'        Case Else: strNYUKB = "1"
		'    End Select
		Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
			Case "3" : strNYUKB = "4"
			Case "2" : strNYUKB = "2"
			Case Else : strNYUKB = "1"
		End Select
		If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
			Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBID)
				'''' UPD 2011/11/15  FKS) T.Yamamoto    Start    連絡票№FC11110201
				'他を除く
				'            Case pc_strDKBID_URK_SOSAI _
				''               , pc_strDKBID_URK_NEBIK _
				''               , pc_strDKBID_URK_TESU _
				''               , pc_strDKBID_URK_HOKA _
				''               , pc_strDKBID_URK_SYOH
				Case pc_strDKBID_URK_SOSAI, pc_strDKBID_URK_NEBIK, pc_strDKBID_URK_TESU, pc_strDKBID_URK_SYOH
					'''' UPD 2011/11/15  FKS) T.Yamamoto    End
					strNYUKB = "2"
			End Select
		End If
		'2009/09/18 UPD E.N.D RISE)MIYAJIMA
		
		strLINCMA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMA
		strLINCMB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMB
		strBNKCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKCD
		strBNKNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKNM
		strTEGNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGNO
		strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGDT
		strUPDID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.UPDID
		strDFLDKBCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD
		strDKBZAIFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBZAIFL
		strDKBTEGFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBTEGFL
		strDKBFLA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLA
		strDKBFLB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLB
		strDKBFLC = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLC
		strKANKOZ = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.KANKOZ
		
		With Tbl_Inf_UDNTRA
			.DATNO = pin_strDATNO '伝票管理NO.
			.DATKB = gc_strDATKB_USE '伝票削除区分
			.AKAKROKB = gc_strAKAKROKB_KURO '赤黒区分
			.DENKB = "8" '伝票区分
			.UDNNO = pin_strDENNO '売上伝票番号
			.LINNO = VB6.Format(pin_intRow, "000") '行番号
			.ZKTKB = "" '取引区分
			.ODNNO = "" '出荷伝票番号
			.ODNLINNO = "" '行番号
			
			'2009/06/05 CHG START FKS)NAKATA
			'.JDNNO = strJdnNo                                   '受注伝票番号
			'.JDNLINNO = strJDNLINNO                             '受注伝票行番号
			.JDNNO = "" '受注伝票番号
			.JDNLINNO = "" '受注伝票行番号
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.RECNO = pin_strRECNO 'レコード管理NO.
			.USDNO = "" '直送伝票NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '売上伝票日付
			.DKBSB = strDKBSB '伝票取引区分種別
			.DKBID = strDKBID '取引区分コード
			.DKBNM = strDKBNM '取引区分名称
			.HENRSNCD = "" '返品理由
			.HENSTTCD = "" '返品状態
			.SMADT = pv_strSMADT '経理締日付
			.SSADT = pv_strSSADT '締日付
			.KESDT = pv_strKESDT '決済日付
			.TOKCD = URKET52_HEAD_Inf.TOKCD '得意先コード
			.TANCD = "" '担当者コード
			.NHSCD = "" '納入先コード
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '請求先コード
			.SOUCD = "" '倉庫コード
			.SBNNO = "" '製番
			.HINCD = "" '製品コード
			.TOKJDNNO = "" '客先注文番号
			.HINNMA = "" '型式
			.HINNMB = "" '商品名１
			.UNTCD = "" '単位コード
			.UNTNM = "" '単位名
			.IRISU = 0 '入数
			.CASSU = 0 'ケース数
			.URISU = 0 '売上数量
			.URITK = 0 '単価
			.GNKTK = 0 '原価単価
			.SIKTK = 0 '営業仕切単価
			.FURITK = 0 '外貨単価
			.URIKN = 0 '売上金額
			.FURIKN = 0 '外貨売上金額
			.SIKKN = 0 '営業仕切金額
			.UZEKN = 0 '消費税金額
			.NYUDT = "" '入金日
			.NYUKN = curNYUKN '入金額
			.FNYUKN = dblFNYUKN '外貨入金額
			.GNKKN = 0 '原価金額
			.JKESIKN = 0 '消込金額
			.FKESIKN = 0 '外貨消込金額
			
			'2009/06/05 ADD START FKS)NAKATA
			'.KESIKB = ""                                        '消込区分
			.KESIKB = CStr(9)
			'2009/06/05 ADD E.N.D FKS)NAKATA
			
			.NYUKB = strNYUKB '入金種別
			.TNKID = "" '種別
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '通貨区分
			'2009/09/27 UPD START RISE)MIYAJIMA
			'        .RATERT = 0                                         '為替レート
			'UPGRADE_WARNING: オブジェクト F_Get_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.RATERT = F_Get_RATERT(URKET52_HEAD_Inf.TOKMTA.TUKKB, URKET52_HEAD_Inf.NYUDT) '為替レート
			'2009/09/27 UPD E.N.D RISE)MIYAJIMA
			.EMGODNKB = "" '緊急出荷区分
			
			'2009/06/05 CHG START FKS)NAKATA
			'.OKRJONO = ""                                       '送り状№
			.OKRJONO = strOKRJONO
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.INVNO = "" 'インボイス№
			.LINCMA = strLINCMA '明細備考１
			.LINCMB = strLINCMB '明細備考２
			.BNKCD = strBNKCD '銀行コード
			.BNKNM = strBNKNM '銀行名称
			.TEGNO = strTEGNO '手形番号
			'2009/09/18 UPD START RISE)MIYAJIMA
			.TEGDT = strTEGDT '手形期日
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
				.TEGDT = strTEGDT '手形期日
			Else
				If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
					If .DKBID <> pc_strDKBID_URK_GENKN And .DKBID <> pc_strDKBID_URK_HURI And .DKBID <> pc_strDKBID_URK_TEG And .DKBID <> pc_strDKBID_URK_HNYU And .DKBID <> pc_strDKBID_URK_HURIK Then
						.TEGDT = F_GET_MaeukeTEGDT(pm_All, Trim(strOKRJONO), strTEGDT) '手形期日
					Else
						.TEGDT = strTEGDT '手形期日
					End If
				End If
			End If
			'2009/09/18 UPD E.N.D RISE)MIYAJIMA
			.UPDID = strUPDID '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
			.DFLDKBCD = strDFLDKBCD 'デフォルトコード
			.DKBZAIFL = strDKBZAIFL '在庫関連フラグ
			.DKBTEGFL = strDKBTEGFL '手形発生フラグ
			.DKBFLA = strDKBFLA 'ダミーフラグ１
			.DKBFLB = strDKBFLB 'ダミーフラグ２
			.DKBFLC = strDKBFLC 'ダミーフラグ３
			.LSTID = "" '伝票種別
			.HINZEIKB = "" '商品消費税区分
			.HINMSTKB = "" 'マスタ区分(商品)
			.TOKMSTKB = "" 'マスタ区分(得意先)
			.NHSMSTKB = "" 'マスタ区分(納入先)
			.TANMSTKB = "" 'マスタ区分(担当者)
			.ZEIRNKKB = "" '消費税ランク
			.HINKB = "" '商品区分
			.ZEIRT = 0 '消費税率
			.ZAIKB = "" '在庫管理区分
			.MRPKB = "" '展開区分
			.HINJUNKB = "" '順位表出力区分
			.MAKCD = "" 'メーカーコード
			.HINSIRCD = strKANKOZ '商品仕入先コード
			.HINNMMKB = "" '名称ﾏﾆｭｱﾙ区分(商品)
			.HRTDD = "" '発注リードタイム
			.ORTDD = "" '出荷リードタイム
			.ZNKURIKN = 0 '税抜課税対象額
			.ZKMURIKN = 0 '税込課税対象額
			.ZKMUZEKN = 0 '税込消費税
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '元伝票管理番号
			.FOPEID = SSS_OPEID.Value '初回登録ユーザID
			.FCLTID = SSS_CLTID.Value '初回登録クライアントID
			.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
			.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
			.OPEID = SSS_OPEID.Value '最終作業者コード
			.CLTID = SSS_CLTID.Value 'クライアントＩＤ
			.WRTTM = GV_SysTime 'タイムスタンプ（時間）
			.WRTDT = GV_SysDate 'タイムスタンプ（日付）
			.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
			.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
			.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
			.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
			.PGID = SSS_PrgId '更新PGID
			.DLFLG = gc_strDLFLG_UPD '削除フラグ
		End With
		
		'UPGRADE_WARNING: オブジェクト pot_Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_Tbl_Inf_UDNTRA = Tbl_Inf_UDNTRA
		
		F_UDNTRA_MakeInf = 0
		
F_UDNTRA_MakeInf_end: 
		Exit Function
		
F_UDNTRA_MakeInf_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_MakeInf")
		GoTo F_UDNTRA_MakeInf_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTRA_Insert
	'   概要：  売上トラン新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTRA_Insert_err
		
		F_UDNTRA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA " & vbCrLf
		strSQL = strSQL & " ( DATNO " & vbCrLf '伝票管理NO.
		strSQL = strSQL & " , DATKB " & vbCrLf '伝票削除区分
		strSQL = strSQL & " , AKAKROKB " & vbCrLf '赤黒区分
		strSQL = strSQL & " , DENKB " & vbCrLf '伝票区分
		strSQL = strSQL & " , UDNNO " & vbCrLf '売上伝票番号
		strSQL = strSQL & " , LINNO " & vbCrLf '行番号
		strSQL = strSQL & " , ZKTKB " & vbCrLf '取引区分
		strSQL = strSQL & " , ODNNO " & vbCrLf '出荷伝票番号
		strSQL = strSQL & " , ODNLINNO " & vbCrLf '行番号
		strSQL = strSQL & " , JDNNO " & vbCrLf '受注伝票番号
		strSQL = strSQL & " , JDNLINNO " & vbCrLf '受注伝票行番号
		strSQL = strSQL & " , RECNO " & vbCrLf 'レコード管理NO.
		strSQL = strSQL & " , USDNO " & vbCrLf '直送伝票NO
		strSQL = strSQL & " , UDNDT " & vbCrLf '売上伝票日付
		strSQL = strSQL & " , DKBSB " & vbCrLf '伝票取引区分種別
		strSQL = strSQL & " , DKBID " & vbCrLf '取引区分コード
		strSQL = strSQL & " , DKBNM " & vbCrLf '取引区分名称
		strSQL = strSQL & " , HENRSNCD " & vbCrLf '返品理由
		strSQL = strSQL & " , HENSTTCD " & vbCrLf '返品状態
		strSQL = strSQL & " , SMADT " & vbCrLf '経理締日付
		strSQL = strSQL & " , SSADT " & vbCrLf '締日付
		strSQL = strSQL & " , KESDT " & vbCrLf '決済日付
		strSQL = strSQL & " , TOKCD " & vbCrLf '得意先コード
		strSQL = strSQL & " , TANCD " & vbCrLf '担当者コード
		strSQL = strSQL & " , NHSCD " & vbCrLf '納入先コード
		strSQL = strSQL & " , TOKSEICD " & vbCrLf '請求先コード
		strSQL = strSQL & " , SOUCD " & vbCrLf '倉庫コード
		strSQL = strSQL & " , SBNNO " & vbCrLf '製番
		strSQL = strSQL & " , HINCD " & vbCrLf '製品コード
		strSQL = strSQL & " , TOKJDNNO " & vbCrLf '客先注文番号
		strSQL = strSQL & " , HINNMA " & vbCrLf '型式
		strSQL = strSQL & " , HINNMB " & vbCrLf '商品名１
		strSQL = strSQL & " , UNTCD " & vbCrLf '単位コード
		strSQL = strSQL & " , UNTNM " & vbCrLf '単位名
		strSQL = strSQL & " , IRISU " & vbCrLf '入数
		strSQL = strSQL & " , CASSU " & vbCrLf 'ケース数
		strSQL = strSQL & " , URISU " & vbCrLf '売上数量
		strSQL = strSQL & " , URITK " & vbCrLf '単価
		strSQL = strSQL & " , GNKTK " & vbCrLf '原価単価
		strSQL = strSQL & " , SIKTK " & vbCrLf '営業仕切単価
		strSQL = strSQL & " , FURITK " & vbCrLf '外貨単価
		strSQL = strSQL & " , URIKN " & vbCrLf '売上金額
		strSQL = strSQL & " , FURIKN " & vbCrLf '外貨売上金額
		strSQL = strSQL & " , SIKKN " & vbCrLf '営業仕切金額
		strSQL = strSQL & " , UZEKN " & vbCrLf '消費税金額
		strSQL = strSQL & " , NYUDT " & vbCrLf '入金日
		strSQL = strSQL & " , NYUKN " & vbCrLf '入金額
		strSQL = strSQL & " , FNYUKN " & vbCrLf '外貨入金額
		strSQL = strSQL & " , GNKKN " & vbCrLf '原価金額
		strSQL = strSQL & " , JKESIKN " & vbCrLf '消込金額
		strSQL = strSQL & " , FKESIKN " & vbCrLf '外貨消込金額
		strSQL = strSQL & " , KESIKB " & vbCrLf '消込区分
		strSQL = strSQL & " , NYUKB " & vbCrLf '入金種別
		strSQL = strSQL & " , TNKID " & vbCrLf '種別
		strSQL = strSQL & " , TUKKB " & vbCrLf '通貨区分
		strSQL = strSQL & " , RATERT " & vbCrLf '為替レート
		strSQL = strSQL & " , EMGODNKB " & vbCrLf '緊急出荷区分
		strSQL = strSQL & " , OKRJONO " & vbCrLf '送り状№
		strSQL = strSQL & " , INVNO " & vbCrLf 'インボイス№
		strSQL = strSQL & " , LINCMA " & vbCrLf '明細備考１
		strSQL = strSQL & " , LINCMB " & vbCrLf '明細備考２
		strSQL = strSQL & " , BNKCD " & vbCrLf '銀行コード
		strSQL = strSQL & " , BNKNM " & vbCrLf '銀行名称
		strSQL = strSQL & " , TEGNO " & vbCrLf '手形番号
		strSQL = strSQL & " , TEGDT " & vbCrLf '手形期日
		strSQL = strSQL & " , UPDID " & vbCrLf '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
		strSQL = strSQL & " , DFLDKBCD " & vbCrLf 'デフォルトコード
		strSQL = strSQL & " , DKBZAIFL " & vbCrLf '在庫関連フラグ
		strSQL = strSQL & " , DKBTEGFL " & vbCrLf '手形発生フラグ
		strSQL = strSQL & " , DKBFLA " & vbCrLf 'ダミーフラグ１
		strSQL = strSQL & " , DKBFLB " & vbCrLf 'ダミーフラグ２
		strSQL = strSQL & " , DKBFLC " & vbCrLf 'ダミーフラグ３
		strSQL = strSQL & " , LSTID " & vbCrLf '伝票種別
		strSQL = strSQL & " , HINZEIKB " & vbCrLf '商品消費税区分
		strSQL = strSQL & " , HINMSTKB " & vbCrLf 'マスタ区分(商品)
		strSQL = strSQL & " , TOKMSTKB " & vbCrLf 'マスタ区分(得意先)
		strSQL = strSQL & " , NHSMSTKB " & vbCrLf 'マスタ区分(納入先)
		strSQL = strSQL & " , TANMSTKB " & vbCrLf 'マスタ区分(担当者)
		strSQL = strSQL & " , ZEIRNKKB " & vbCrLf '消費税ランク
		strSQL = strSQL & " , HINKB " & vbCrLf '商品区分
		strSQL = strSQL & " , ZEIRT " & vbCrLf '消費税率
		strSQL = strSQL & " , ZAIKB " & vbCrLf '在庫管理区分
		strSQL = strSQL & " , MRPKB " & vbCrLf '展開区分
		strSQL = strSQL & " , HINJUNKB " & vbCrLf '順位表出力区分
		strSQL = strSQL & " , MAKCD " & vbCrLf 'メーカーコード
		strSQL = strSQL & " , HINSIRCD " & vbCrLf '商品仕入先コード
		strSQL = strSQL & " , HINNMMKB " & vbCrLf '名称ﾏﾆｭｱﾙ区分(商品)
		strSQL = strSQL & " , HRTDD " & vbCrLf '発注リードタイム
		strSQL = strSQL & " , ORTDD " & vbCrLf '出荷リードタイム
		strSQL = strSQL & " , ZNKURIKN " & vbCrLf '税抜課税対象額
		strSQL = strSQL & " , ZKMURIKN " & vbCrLf '税込課税対象額
		strSQL = strSQL & " , ZKMUZEKN " & vbCrLf '税込消費税
		strSQL = strSQL & " , MOTDATNO " & vbCrLf '元伝票管理番号
		strSQL = strSQL & " , FOPEID " & vbCrLf '初回登録ユーザID
		strSQL = strSQL & " , FCLTID " & vbCrLf '初回登録クライアントID
		strSQL = strSQL & " , WRTFSTTM " & vbCrLf 'タイムスタンプ（登録時間）
		strSQL = strSQL & " , WRTFSTDT " & vbCrLf 'タイムスタンプ（登録日）
		strSQL = strSQL & " , OPEID " & vbCrLf '最終作業者コード
		strSQL = strSQL & " , CLTID " & vbCrLf 'クライアントＩＤ
		strSQL = strSQL & " , WRTTM " & vbCrLf 'タイムスタンプ（時間）
		strSQL = strSQL & " , WRTDT " & vbCrLf 'タイムスタンプ（日付）
		strSQL = strSQL & " , UOPEID " & vbCrLf 'ユーザID（バッチ）
		strSQL = strSQL & " , UCLTID " & vbCrLf 'クライアントID（バッチ）
		strSQL = strSQL & " , UWRTTM " & vbCrLf 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & " , UWRTDT " & vbCrLf 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & " , PGID " & vbCrLf '更新PGID
		strSQL = strSQL & " , DLFLG " & vbCrLf '削除フラグ
		strSQL = strSQL & " ) " & vbCrLf
		With pin_Tbl_Inf_UDNTRA
			strSQL = strSQL & " VALUES " & vbCrLf
			strSQL = strSQL & " ( '" & CF_Ora_String(.DATNO, 10) & "' " & vbCrLf '伝票管理NO.
			strSQL = strSQL & " , '" & CF_Ora_String(.DATKB, 1) & "' " & vbCrLf '伝票削除区分
			strSQL = strSQL & " , '" & CF_Ora_String(.AKAKROKB, 1) & "' " & vbCrLf '赤黒区分
			strSQL = strSQL & " , '" & CF_Ora_String(.DENKB, 1) & "' " & vbCrLf '伝票区分
			strSQL = strSQL & " , '" & CF_Ora_String(.UDNNO, 8) & "' " & vbCrLf '売上伝票番号
			strSQL = strSQL & " , '" & CF_Ora_String(.LINNO, 3) & "' " & vbCrLf '行番号
			strSQL = strSQL & " , '" & CF_Ora_String(.ZKTKB, 1) & "' " & vbCrLf '取引区分
			strSQL = strSQL & " , '" & CF_Ora_String(.ODNNO, 8) & "' " & vbCrLf '出荷伝票番号
			strSQL = strSQL & " , '" & CF_Ora_String(.ODNLINNO, 3) & "' " & vbCrLf '行番号
			strSQL = strSQL & " , '" & CF_Ora_String(.JDNNO, 10) & "' " & vbCrLf '受注伝票番号
			strSQL = strSQL & " , '" & CF_Ora_String(.JDNLINNO, 3) & "' " & vbCrLf '受注伝票行番号
			strSQL = strSQL & " , '" & CF_Ora_String(.RECNO, 10) & "' " & vbCrLf 'レコード管理NO.
			strSQL = strSQL & " , '" & CF_Ora_String(.USDNO, 8) & "' " & vbCrLf '直送伝票NO
			strSQL = strSQL & " , '" & CF_Ora_String(.UDNDT, 8) & "' " & vbCrLf '売上伝票日付
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBSB, 3) & "' " & vbCrLf '伝票取引区分種別
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBID, 2) & "' " & vbCrLf '取引区分コード
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBNM, 6) & "' " & vbCrLf '取引区分名称
			strSQL = strSQL & " , '" & CF_Ora_String(.HENRSNCD, 2) & "' " & vbCrLf '返品理由
			strSQL = strSQL & " , '" & CF_Ora_String(.HENSTTCD, 2) & "' " & vbCrLf '返品状態
			strSQL = strSQL & " , '" & CF_Ora_String(.SMADT, 8) & "' " & vbCrLf '経理締日付
			strSQL = strSQL & " , '" & CF_Ora_String(.SSADT, 8) & "' " & vbCrLf '締日付
			strSQL = strSQL & " , '" & CF_Ora_String(.KESDT, 8) & "' " & vbCrLf '決済日付
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKCD, 10) & "' " & vbCrLf '得意先コード
			strSQL = strSQL & " , '" & CF_Ora_String(.TANCD, 6) & "' " & vbCrLf '担当者コード
			strSQL = strSQL & " , '" & CF_Ora_String(.NHSCD, 10) & "' " & vbCrLf '納入先コード
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKSEICD, 10) & "' " & vbCrLf '請求先コード
			strSQL = strSQL & " , '" & CF_Ora_String(.SOUCD, 3) & "' " & vbCrLf '倉庫コード
			strSQL = strSQL & " , '" & CF_Ora_String(.SBNNO, 20) & "' " & vbCrLf '製番
			strSQL = strSQL & " , '" & CF_Ora_String(.HINCD, 10) & "' " & vbCrLf '製品コード
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKJDNNO, 23) & "' " & vbCrLf '客先注文番号
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMA, 50) & "' " & vbCrLf '型式
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMB, 50) & "' " & vbCrLf '商品名１
			strSQL = strSQL & " , '" & CF_Ora_String(.UNTCD, 2) & "' " & vbCrLf '単位コード
			strSQL = strSQL & " , '" & CF_Ora_String(.UNTNM, 4) & "' " & vbCrLf '単位名
			strSQL = strSQL & " ,  " & CStr(.IRISU) & vbCrLf '入数
			strSQL = strSQL & " ,  " & CStr(.CASSU) & vbCrLf 'ケース数
			strSQL = strSQL & " ,  " & CStr(.URISU) & vbCrLf '売上数量
			strSQL = strSQL & " ,  " & CStr(.URITK) & vbCrLf '単価
			strSQL = strSQL & " ,  " & CStr(.GNKTK) & vbCrLf '原価単価
			strSQL = strSQL & " ,  " & CStr(.SIKTK) & vbCrLf '営業仕切単価
			strSQL = strSQL & " ,  " & CStr(.FURITK) & vbCrLf '外貨単価
			strSQL = strSQL & " ,  " & CStr(.URIKN) & vbCrLf '売上金額
			strSQL = strSQL & " ,  " & CStr(.FURIKN) & vbCrLf '外貨売上金額
			strSQL = strSQL & " ,  " & CStr(.SIKKN) & vbCrLf '営業仕切金額
			strSQL = strSQL & " ,  " & CStr(.UZEKN) & vbCrLf '消費税金額
			strSQL = strSQL & " , '" & CF_Ora_String(.NYUDT, 8) & "' " & vbCrLf '入金日
			strSQL = strSQL & " ,  " & CStr(.NYUKN) & vbCrLf '入金額
			strSQL = strSQL & " ,  " & CStr(.FNYUKN) & vbCrLf '外貨入金額
			strSQL = strSQL & " ,  " & CStr(.GNKKN) & vbCrLf '原価金額
			strSQL = strSQL & " ,  " & CStr(.JKESIKN) & vbCrLf '消込金額
			strSQL = strSQL & " ,  " & CStr(.FKESIKN) & vbCrLf '外貨消込金額
			strSQL = strSQL & " , '" & CF_Ora_String(.KESIKB, 1) & "' " & vbCrLf '消込区分
			strSQL = strSQL & " , '" & CF_Ora_String(.NYUKB, 1) & "' " & vbCrLf '入金種別
			strSQL = strSQL & " , '" & CF_Ora_String(.TNKID, 2) & "' " & vbCrLf '種別
			strSQL = strSQL & " , '" & CF_Ora_String(.TUKKB, 3) & "' " & vbCrLf '通貨区分
			strSQL = strSQL & " ,  " & CStr(.RATERT) & vbCrLf '為替レート
			strSQL = strSQL & " , '" & CF_Ora_String(.EMGODNKB, 1) & "' " & vbCrLf '緊急出荷区分
			strSQL = strSQL & " , '" & CF_Ora_String(.OKRJONO, 15) & "' " & vbCrLf '送り状№
			strSQL = strSQL & " , '" & CF_Ora_String(.INVNO, 8) & "' " & vbCrLf 'インボイス№
			strSQL = strSQL & " , '" & CF_Ora_String(.LINCMA, 20) & "' " & vbCrLf '明細備考１
			strSQL = strSQL & " , '" & CF_Ora_String(.LINCMB, 20) & "' " & vbCrLf '明細備考２
			strSQL = strSQL & " , '" & CF_Ora_String(.BNKCD, 7) & "' " & vbCrLf '銀行コード
			strSQL = strSQL & " , '" & CF_Ora_String(.BNKNM, 50) & "' " & vbCrLf '銀行名称
			strSQL = strSQL & " , '" & CF_Ora_String(.TEGNO, 10) & "' " & vbCrLf '手形番号
			strSQL = strSQL & " , '" & CF_Ora_String(.TEGDT, 8) & "' " & vbCrLf '手形期日
			strSQL = strSQL & " , '" & CF_Ora_String(.UPDID, 2) & "' " & vbCrLf '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
			strSQL = strSQL & " , '" & CF_Ora_String(.DFLDKBCD, 13) & "' " & vbCrLf 'デフォルトコード
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBZAIFL, 1) & "' " & vbCrLf '在庫関連フラグ
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBTEGFL, 1) & "' " & vbCrLf '手形発生フラグ
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLA, 1) & "' " & vbCrLf 'ダミーフラグ１
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLB, 1) & "' " & vbCrLf 'ダミーフラグ２
			strSQL = strSQL & " , '" & CF_Ora_String(.DKBFLC, 1) & "' " & vbCrLf 'ダミーフラグ３
			strSQL = strSQL & " , '" & CF_Ora_String(.LSTID, 7) & "' " & vbCrLf '伝票種別
			strSQL = strSQL & " , '" & CF_Ora_String(.HINZEIKB, 1) & "' " & vbCrLf '商品消費税区分
			strSQL = strSQL & " , '" & CF_Ora_String(.HINMSTKB, 1) & "' " & vbCrLf 'マスタ区分(商品)
			strSQL = strSQL & " , '" & CF_Ora_String(.TOKMSTKB, 1) & "' " & vbCrLf 'マスタ区分(得意先)
			strSQL = strSQL & " , '" & CF_Ora_String(.NHSMSTKB, 1) & "' " & vbCrLf 'マスタ区分(納入先)
			strSQL = strSQL & " , '" & CF_Ora_String(.TANMSTKB, 1) & "' " & vbCrLf 'マスタ区分(担当者)
			strSQL = strSQL & " , '" & CF_Ora_String(.ZEIRNKKB, 1) & "' " & vbCrLf '消費税ランク
			strSQL = strSQL & " , '" & CF_Ora_String(.HINKB, 1) & "' " & vbCrLf '商品区分
			strSQL = strSQL & " ,  " & CStr(.ZEIRT) & vbCrLf '消費税率
			strSQL = strSQL & " , '" & CF_Ora_String(.ZAIKB, 1) & "' " & vbCrLf '在庫管理区分
			strSQL = strSQL & " , '" & CF_Ora_String(.MRPKB, 1) & "' " & vbCrLf '展開区分
			strSQL = strSQL & " , '" & CF_Ora_String(.HINJUNKB, 1) & "' " & vbCrLf '順位表出力区分
			strSQL = strSQL & " , '" & CF_Ora_String(.MAKCD, 6) & "' " & vbCrLf 'メーカーコード
			strSQL = strSQL & " , '" & CF_Ora_String(.HINSIRCD, 10) & "' " & vbCrLf '商品仕入先コード
			strSQL = strSQL & " , '" & CF_Ora_String(.HINNMMKB, 1) & "' " & vbCrLf '名称ﾏﾆｭｱﾙ区分(商品)
			strSQL = strSQL & " , '" & CF_Ora_String(.HRTDD, 2) & "' " & vbCrLf '発注リードタイム
			strSQL = strSQL & " , '" & CF_Ora_String(.ORTDD, 2) & "' " & vbCrLf '出荷リードタイム
			strSQL = strSQL & " ,  " & CStr(.ZNKURIKN) & vbCrLf '税抜課税対象額
			strSQL = strSQL & " ,  " & CStr(.ZKMURIKN) & vbCrLf '税込課税対象額
			strSQL = strSQL & " ,  " & CStr(.ZKMUZEKN) & vbCrLf '税込消費税
			strSQL = strSQL & " , '" & CF_Ora_String(.MOTDATNO, 10) & "' " & vbCrLf '元伝票管理番号
			strSQL = strSQL & " , '" & CF_Ora_String(.FOPEID, 8) & "' " & vbCrLf '初回登録ユーザID
			strSQL = strSQL & " , '" & CF_Ora_String(.FCLTID, 5) & "' " & vbCrLf '初回登録クライアントID
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTFSTTM, 6) & "' " & vbCrLf 'タイムスタンプ（登録時間）
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTFSTDT, 8) & "' " & vbCrLf 'タイムスタンプ（登録日）
			strSQL = strSQL & " , '" & CF_Ora_String(.OPEID, 8) & "' " & vbCrLf '最終作業者コード
			strSQL = strSQL & " , '" & CF_Ora_String(.CLTID, 5) & "' " & vbCrLf 'クライアントＩＤ
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTTM, 6) & "' " & vbCrLf 'タイムスタンプ（時間）
			strSQL = strSQL & " , '" & CF_Ora_String(.WRTDT, 8) & "' " & vbCrLf 'タイムスタンプ（日付）
			strSQL = strSQL & " , '" & CF_Ora_String(.UOPEID, 8) & "' " & vbCrLf 'ユーザID（バッチ）
			strSQL = strSQL & " , '" & CF_Ora_String(.UCLTID, 5) & "' " & vbCrLf 'クライアントID（バッチ）
			strSQL = strSQL & " , '" & CF_Ora_String(.UWRTTM, 6) & "' " & vbCrLf 'タイムスタンプ（バッチ時間）
			strSQL = strSQL & " , '" & CF_Ora_String(.UWRTDT, 8) & "' " & vbCrLf 'タイムスタンプ（バッチ日付）
			strSQL = strSQL & " , '" & CF_Ora_String(.PGID, 7) & "' " & vbCrLf '更新PGID
			strSQL = strSQL & " , '" & CF_Ora_String(.DLFLG, 1) & "' " & vbCrLf '削除フラグ
			strSQL = strSQL & "   ) "
		End With
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTRA_Insert_err
		End If
		
		F_UDNTRA_Insert = 0
		
F_UDNTRA_Insert_end: 
		Exit Function
		
F_UDNTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_Insert")
		GoTo F_UDNTRA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTRA_Update_DelF
	'   概要：  売上トラン論理削除処理
	'   引数：  pm_All             : 画面情報
	'           pin_strDATNO       : 伝票管理番号
	'           pin_blnUpdDLFLG    : True = DLFLG も更新
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_Update_DelF(ByRef pm_All As Cls_All, ByVal pin_strDATNO As String, ByVal pin_blnUpdDLFLG As Boolean) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UDNTRA_Update_DelF_err
		
		'UPGRADE_WARNING: オブジェクト F_UDNTRA_Update_DelF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_UDNTRA_Update_DelF = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA "
		strSQL = strSQL & "    SET DATKB  = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '伝票削除区分
		strSQL = strSQL & "      , OPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID（バッチ）
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID（バッチ）
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
		If pin_blnUpdDLFLG = True Then
			strSQL = strSQL & "  , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_DEL, 1) & "' " '削除フラグ
		End If
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '伝票削除区分
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UDNTRA_Update_DelF_err
		End If
		
		'UPGRADE_WARNING: オブジェクト F_UDNTRA_Update_DelF の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_UDNTRA_Update_DelF = 0
		
F_UDNTRA_Update_DelF_end: 
		Exit Function
		
F_UDNTRA_Update_DelF_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_Update_DelF")
		GoTo F_UDNTRA_Update_DelF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UPDSMF
	'   概要：  サマリファイル群の更新
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トランデータ
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UPDSMF(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim intRet As Short
		
		On Error GoTo F_UPDSMF_err
		
		F_UPDSMF = 9
		
		'更新条件：入金区分＝１：入金 かつ デフォルトコード≠３
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'請求サマリ更新
			intRet = F_TOKSSA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'入金消込サマリの更新
			intRet = F_NKSSMA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
		End If
		
		'更新条件：入金区分＝２：前受入金
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'前受請求サマリ更新
			intRet = F_TOKSSB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'入金消込サマリ前受の更新
			intRet = F_NKSSMB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		'更新条件：入金区分＝１：入金 かつ 海外取引区分＝１：海外
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'請求サマリ外貨の更新
			intRet = F_TOKSSC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
			
			'入金消込サマリ外貨の更新
			intRet = F_NKSSMC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		'更新条件：入金区分＝１：入金 かつ デフォルトコード≠２
		'更新条件：入金区分＝２：前受入金
		If (URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "2") Or URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'売掛サマリ請求の更新
			intRet = F_TOKSME(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF = intRet
				GoTo F_UPDSMF_err
			End If
		End If
		
		F_UPDSMF = 0
		
F_UPDSMF_end: 
		Exit Function
		
F_UPDSMF_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UPDSMF")
		GoTo F_UPDSMF_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSA
	'   概要：  請求サマリ処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSAURIKN(9) As Decimal '売上集計金額
		Dim curSSAUZEKN As Decimal '売上消費税金額
		Dim curSSANYUKN(9) As Decimal '入金集計金額
		Dim curKSKZANKN As Decimal '消込入金額残
		
		On Error GoTo F_TOKSSA_err
		
		F_TOKSSA = 9
		
		'売上集計金額
		curSSAURIKN(0) = 0
		curSSAURIKN(1) = 0
		curSSAURIKN(2) = 0
		curSSAURIKN(3) = 0
		curSSAURIKN(4) = 0
		curSSAURIKN(5) = 0
		curSSAURIKN(6) = 0
		curSSAURIKN(7) = 0
		curSSAURIKN(8) = 0
		curSSAURIKN(9) = 0
		curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'売上消費税金額
		curSSAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'入金集計金額
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'消込入金額残
		curKSKZANKN = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_TOKSSA_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSA_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_TOKSSA_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		'ランク別処理
		'UPGRADE_WARNING: オブジェクト SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSA_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		'伝票枚数をカウントアップ
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSA_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSA_err
			End If
		End If
		
		F_TOKSSA = 0
		
F_TOKSSA_end: 
		Exit Function
		
F_TOKSSA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA")
		GoTo F_TOKSSA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSA_Update
	'   概要：  請求サマリ更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSAURIKN    : 売上集計金額
	'           pin_curSSAUZEKN    : 売上消費税金額
	'           pin_curSSANYUKN    : 入金集計金額
	'           pin_curKSKZANKN    : 消込入金額残
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_Update_err
		
		F_TOKSSA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "      , SSAURIKN00 = SSAURIKN00 + " & CStr(pin_curSSAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "      , SSAURIKN01 = SSAURIKN01 + " & CStr(pin_curSSAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "      , SSAURIKN02 = SSAURIKN02 + " & CStr(pin_curSSAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "      , SSAURIKN03 = SSAURIKN03 + " & CStr(pin_curSSAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "      , SSAURIKN04 = SSAURIKN04 + " & CStr(pin_curSSAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "      , SSAURIKN05 = SSAURIKN05 + " & CStr(pin_curSSAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "      , SSAURIKN06 = SSAURIKN06 + " & CStr(pin_curSSAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "      , SSAURIKN07 = SSAURIKN07 + " & CStr(pin_curSSAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "      , SSAURIKN08 = SSAURIKN08 + " & CStr(pin_curSSAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "      , SSAURIKN09 = SSAURIKN09 + " & CStr(pin_curSSAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CStr(pin_curSSAUZEKN) '売上消費税金額
		strSQL = strSQL & "      , SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , KSKZANKN   = KSKZANKN   + " & CStr(pin_curKSKZANKN) '消込入金額残
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSA_Update_err
		End If
		
		F_TOKSSA_Update = 0
		
F_TOKSSA_Update_end: 
		Exit Function
		
F_TOKSSA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_Update")
		GoTo F_TOKSSA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSA_Insert
	'   概要：  請求サマリ新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSAURIKN    : 売上集計金額
	'           pin_curSSAUZEKN    : 売上消費税金額
	'           pin_curSSANYUKN    : 入金集計金額
	'           pin_curKSKZANKN    : 消込入金額残
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_Insert_err
		
		F_TOKSSA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSA "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SSADT " '締日付
		strSQL = strSQL & "        , KESDT " '決済日付
		strSQL = strSQL & "        , SSAURIKN00 " '売上集計金額00
		strSQL = strSQL & "        , SSAURIKN01 " '売上集計金額01
		strSQL = strSQL & "        , SSAURIKN02 " '売上集計金額02
		strSQL = strSQL & "        , SSAURIKN03 " '売上集計金額03
		strSQL = strSQL & "        , SSAURIKN04 " '売上集計金額04
		strSQL = strSQL & "        , SSAURIKN05 " '売上集計金額05
		strSQL = strSQL & "        , SSAURIKN06 " '売上集計金額06
		strSQL = strSQL & "        , SSAURIKN07 " '売上集計金額07
		strSQL = strSQL & "        , SSAURIKN08 " '売上集計金額08
		strSQL = strSQL & "        , SSAURIKN09 " '売上集計金額09
		strSQL = strSQL & "        , SSAUZEKN " '売上消費税金額
		strSQL = strSQL & "        , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN " '消込入金額
		strSQL = strSQL & "        , KSKZANKN " '消込入金額残
		strSQL = strSQL & "        , SSADENSU " '伝票枚数
		strSQL = strSQL & "        , DATNO " '伝票管理NO.
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAUZEKN) '売上消費税金額
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        , 0 " '消込入金額
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN) '消込入金額残
		strSQL = strSQL & "        , 0 " '伝票枚数
		strSQL = strSQL & "        , '" & Space(10) & "' " '伝票管理NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "

        'SQL実行
        bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
        If bolRet = False Then
			GoTo F_TOKSSA_Insert_err
		End If
		
		F_TOKSSA_Insert = 0
		
F_TOKSSA_Insert_end: 
		Exit Function
		
F_TOKSSA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_Insert")
		GoTo F_TOKSSA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSA_UpdateRANK
	'   概要：  請求サマリ更新（ランク別処理）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double 'ランク別税込課税金額
		Dim dblSZAKZOKN(2) As Double 'ランク別税抜課税金額
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSA_UpdateRANK_err
		
		F_TOKSSA_UpdateRANK = 9
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'ランク別税込課税金額
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'ランク別税抜課税金額
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET SSAURIKN09 = SSAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '売上集計金額09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) 'ランク別税抜課税金額02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSA_UpdateRANK_err
		End If
		
		F_TOKSSA_UpdateRANK = 0
		
F_TOKSSA_UpdateRANK_end: 
		Exit Function
		
F_TOKSSA_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_UpdateRANK")
		GoTo F_TOKSSA_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSA_UpdateDENSU
	'   概要：  請求サマリ更新（伝票枚数をカウントアップ）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSA_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSA_UpdateDENSU_err
		
		F_TOKSSA_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA "
		strSQL = strSQL & "    SET SSADENSU = SSADENSU + " & CStr(pin_intSMFKB) '伝票枚数
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSA_UpdateDENSU_err
		End If
		
		F_TOKSSA_UpdateDENSU = 0
		
F_TOKSSA_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSA_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSA_UpdateDENSU")
		GoTo F_TOKSSA_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB
	'   概要：  前受請求サマリ処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSAURIKN(9) As Decimal '売上集計金額
		Dim curSSAUZEKN As Decimal '売上消費税金額
		Dim curSSANYUKN(9) As Decimal '入金集計金額
		Dim curKSKZANKN As Decimal '消込入金額残
		
		On Error GoTo F_TOKSSB_err
		
		F_TOKSSB = 9
		
		'売上集計金額
		curSSAURIKN(0) = 0
		curSSAURIKN(1) = 0
		curSSAURIKN(2) = 0
		curSSAURIKN(3) = 0
		curSSAURIKN(4) = 0
		curSSAURIKN(5) = 0
		curSSAURIKN(6) = 0
		curSSAURIKN(7) = 0
		curSSAURIKN(8) = 0
		curSSAURIKN(9) = 0
		curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'売上消費税金額
		curSSAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'入金集計金額
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'消込入金額残
		curKSKZANKN = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_TOKSSB_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSB_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_TOKSSB_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSAURIKN, curSSAUZEKN, curSSANYUKN, curKSKZANKN) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		'ランク別処理
		'UPGRADE_WARNING: オブジェクト SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSB_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		'伝票枚数をカウントアップ
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSB_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSB_err
			End If
		End If
		
		F_TOKSSB = 0
		
F_TOKSSB_end: 
		Exit Function
		
F_TOKSSB_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB")
		GoTo F_TOKSSB_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB_Update
	'   概要：  前受請求サマリ更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSAURIKN    : 売上集計金額
	'           pin_curSSAUZEKN    : 売上消費税金額
	'           pin_curSSANYUKN    : 入金集計金額
	'           pin_curKSKZANKN    : 消込入金額残
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_Update_err
		
		F_TOKSSB_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 8) & "' " '得意先コード
		strSQL = strSQL & "      , KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "      , SSAURIKN00 = SSAURIKN00 + " & CStr(pin_curSSAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "      , SSAURIKN01 = SSAURIKN01 + " & CStr(pin_curSSAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "      , SSAURIKN02 = SSAURIKN02 + " & CStr(pin_curSSAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "      , SSAURIKN03 = SSAURIKN03 + " & CStr(pin_curSSAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "      , SSAURIKN04 = SSAURIKN04 + " & CStr(pin_curSSAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "      , SSAURIKN05 = SSAURIKN05 + " & CStr(pin_curSSAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "      , SSAURIKN06 = SSAURIKN06 + " & CStr(pin_curSSAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "      , SSAURIKN07 = SSAURIKN07 + " & CStr(pin_curSSAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "      , SSAURIKN08 = SSAURIKN08 + " & CStr(pin_curSSAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "      , SSAURIKN09 = SSAURIKN09 + " & CStr(pin_curSSAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CStr(pin_curSSAUZEKN) '売上消費税金額
		strSQL = strSQL & "      , SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , KSKZANKN   = KSKZANKN   + " & CStr(pin_curKSKZANKN) '消込入金額残
		'2009/06/10 DEL START FKS)NAKATA
		'strSQL = strSQL & "      , DATNO      = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '伝票管理NO.
		'2009/06/10 DEL E.N.D FKS)NAKATA
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "        '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSB_Update_err
		End If
		
		F_TOKSSB_Update = 0
		
F_TOKSSB_Update_end: 
		Exit Function
		
F_TOKSSB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_Update")
		GoTo F_TOKSSB_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB_Insert
	'   概要：  前受請求サマリ新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSAURIKN    : 売上集計金額
	'           pin_curSSAUZEKN    : 売上消費税金額
	'           pin_curSSANYUKN    : 入金集計金額
	'           pin_curKSKZANKN    : 消込入金額残
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSAURIKN() As Decimal, ByVal pin_curSSAUZEKN As Decimal, ByRef pin_curSSANYUKN() As Decimal, ByVal pin_curKSKZANKN As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_Insert_err
		
		F_TOKSSB_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSB "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SSADT " '締日付
		strSQL = strSQL & "        , KESDT " '決済日付
		strSQL = strSQL & "        , SSAURIKN00 " '売上集計金額00
		strSQL = strSQL & "        , SSAURIKN01 " '売上集計金額01
		strSQL = strSQL & "        , SSAURIKN02 " '売上集計金額02
		strSQL = strSQL & "        , SSAURIKN03 " '売上集計金額03
		strSQL = strSQL & "        , SSAURIKN04 " '売上集計金額04
		strSQL = strSQL & "        , SSAURIKN05 " '売上集計金額05
		strSQL = strSQL & "        , SSAURIKN06 " '売上集計金額06
		strSQL = strSQL & "        , SSAURIKN07 " '売上集計金額07
		strSQL = strSQL & "        , SSAURIKN08 " '売上集計金額08
		strSQL = strSQL & "        , SSAURIKN09 " '売上集計金額09
		strSQL = strSQL & "        , SSAUZEKN " '売上消費税金額
		strSQL = strSQL & "        , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN " '消込入金額
		strSQL = strSQL & "        , KSKZANKN " '消込入金額残
		strSQL = strSQL & "        , SSADENSU " '伝票枚数
		strSQL = strSQL & "        , DATNO " '伝票管理NO.
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curSSAUZEKN) '売上消費税金額
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        , 0 " '消込入金額
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN) '消込入金額残
		strSQL = strSQL & "        , 0 " '伝票枚数
		'2009/06/10 CHG START FKS)NAKATA
		'strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '伝票管理NO.
		strSQL = strSQL & "        , '" & Space(10) & "' " '伝票管理NO.
		'2009/06/10 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_Insert_err
		End If
		
		F_TOKSSB_Insert = 0
		
F_TOKSSB_Insert_end: 
		Exit Function
		
F_TOKSSB_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_Insert")
		GoTo F_TOKSSB_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB_UpdateRANK
	'   概要：  前受請求サマリ更新（ランク別処理）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double 'ランク別税込課税金額
		Dim dblSZAKZOKN(2) As Double 'ランク別税抜課税金額
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSB_UpdateRANK_err
		
		F_TOKSSB_UpdateRANK = 9
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'ランク別税込課税金額
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'ランク別税抜課税金額
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET SSAURIKN09 = SSAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '売上集計金額09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) 'ランク別税抜課税金額02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_UpdateRANK_err
		End If
		
		F_TOKSSB_UpdateRANK = 0
		
F_TOKSSB_UpdateRANK_end: 
		Exit Function
		
F_TOKSSB_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_UpdateRANK")
		GoTo F_TOKSSB_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSB_UpdateDENSU
	'   概要：  前受請求サマリ更新（伝票枚数をカウントアップ）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSB_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSB_UpdateDENSU_err
		
		F_TOKSSB_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB "
		strSQL = strSQL & "    SET SSADENSU = SSADENSU + " & CStr(pin_intSMFKB) '伝票枚数
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSB_UpdateDENSU_err
		End If
		
		F_TOKSSB_UpdateDENSU = 0
		
F_TOKSSB_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSB_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSB_UpdateDensu")
		GoTo F_TOKSSB_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSC
	'   概要：  請求サマリ外貨処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim dblSSCURIKN(9) As Double '売上集計金額
		Dim dblSSCUZEKN As Double '売上消費税金額
		Dim dblSSCNYUKN(9) As Double '入金集計金額
		Dim dblFKSZANKN As Double '消込入金額残
		
		On Error GoTo F_TOKSSC_err
		
		F_TOKSSC = 9
		
		'売上集計金額
		dblSSCURIKN(0) = 0
		dblSSCURIKN(1) = 0
		dblSSCURIKN(2) = 0
		dblSSCURIKN(3) = 0
		dblSSCURIKN(4) = 0
		dblSSCURIKN(5) = 0
		dblSSCURIKN(6) = 0
		dblSSCURIKN(7) = 0
		dblSSCURIKN(8) = 0
		dblSSCURIKN(9) = 0
		dblSSCURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = dblSSCURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FURIKN * pin_intSMFKB
		
		'売上消費税金額
		dblSSCUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'入金集計金額
		dblSSCNYUKN(0) = 0
		dblSSCNYUKN(1) = 0
		dblSSCNYUKN(2) = 0
		dblSSCNYUKN(3) = 0
		dblSSCNYUKN(4) = 0
		dblSSCNYUKN(5) = 0
		dblSSCNYUKN(6) = 0
		dblSSCNYUKN(7) = 0
		dblSSCNYUKN(8) = 0
		dblSSCNYUKN(9) = 0
		dblSSCNYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = dblSSCNYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'消込入金額残
		dblFKSZANKN = pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_TOKSSC_Update(pm_All, pin_Tbl_Inf_UDNTRA, dblSSCURIKN, dblSSCUZEKN, dblSSCNYUKN, dblFKSZANKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSSC_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_TOKSSC_Insert(pm_All, pin_Tbl_Inf_UDNTRA, dblSSCURIKN, dblSSCUZEKN, dblSSCNYUKN, dblFKSZANKN) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		'ランク別処理
		'UPGRADE_WARNING: オブジェクト SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSSC_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		'伝票枚数をカウントアップ
		If pin_intRow = 1 And pin_Tbl_Inf_UDNTRA.DENKB = "1" Then
			If F_TOKSSC_UpdateDENSU(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSSC_err
			End If
		End If
		
		F_TOKSSC = 0
		
F_TOKSSC_end: 
		Exit Function
		
F_TOKSSC_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC")
		GoTo F_TOKSSC_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSC_Update
	'   概要：  請求サマリ外貨更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_dblSSCURIKN    : 売上集計金額
	'           pin_dblSSCUZEKN    : 売上消費税金額
	'           pin_dblSSCNYUKN    : 入金集計金額
	'           pin_dblFKSZANKN    : 消込入金額残
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_dblSSCURIKN() As Double, ByVal pin_dblSSCUZEKN As Double, ByRef pin_dblSSCNYUKN() As Double, ByVal pin_dblFKSZANKN As Double, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_Update_err
		
		F_TOKSSC_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET KESDT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "      , SSCURIKN00 = SSCURIKN00 + " & CStr(pin_dblSSCURIKN(0)) '売上集計金額00
		strSQL = strSQL & "      , SSCURIKN01 = SSCURIKN01 + " & CStr(pin_dblSSCURIKN(1)) '売上集計金額01
		strSQL = strSQL & "      , SSCURIKN02 = SSCURIKN02 + " & CStr(pin_dblSSCURIKN(2)) '売上集計金額02
		strSQL = strSQL & "      , SSCURIKN03 = SSCURIKN03 + " & CStr(pin_dblSSCURIKN(3)) '売上集計金額03
		strSQL = strSQL & "      , SSCURIKN04 = SSCURIKN04 + " & CStr(pin_dblSSCURIKN(4)) '売上集計金額04
		strSQL = strSQL & "      , SSCURIKN05 = SSCURIKN05 + " & CStr(pin_dblSSCURIKN(5)) '売上集計金額05
		strSQL = strSQL & "      , SSCURIKN06 = SSCURIKN06 + " & CStr(pin_dblSSCURIKN(6)) '売上集計金額06
		strSQL = strSQL & "      , SSCURIKN07 = SSCURIKN07 + " & CStr(pin_dblSSCURIKN(7)) '売上集計金額07
		strSQL = strSQL & "      , SSCURIKN08 = SSCURIKN08 + " & CStr(pin_dblSSCURIKN(8)) '売上集計金額08
		strSQL = strSQL & "      , SSCURIKN09 = SSCURIKN09 + " & CStr(pin_dblSSCURIKN(9)) '売上集計金額09
		strSQL = strSQL & "      , SSCUZEKN   = SSCUZEKN   + " & CStr(pin_dblSSCUZEKN) '売上消費税金額
		strSQL = strSQL & "      , SSCNYUKN00 = SSCNYUKN00 + " & CStr(pin_dblSSCNYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSCNYUKN01 = SSCNYUKN01 + " & CStr(pin_dblSSCNYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSCNYUKN02 = SSCNYUKN02 + " & CStr(pin_dblSSCNYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSCNYUKN03 = SSCNYUKN03 + " & CStr(pin_dblSSCNYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSCNYUKN04 = SSCNYUKN04 + " & CStr(pin_dblSSCNYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSCNYUKN05 = SSCNYUKN05 + " & CStr(pin_dblSSCNYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSCNYUKN06 = SSCNYUKN06 + " & CStr(pin_dblSSCNYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSCNYUKN07 = SSCNYUKN07 + " & CStr(pin_dblSSCNYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSCNYUKN08 = SSCNYUKN08 + " & CStr(pin_dblSSCNYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSCNYUKN09 = SSCNYUKN09 + " & CStr(pin_dblSSCNYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , FKSZANKN   = FKSZANKN   + " & CStr(pin_dblFKSZANKN) '消込入金額残
		'2009/06/10 DEL START FKS)NAKATA
		'strSQL = strSQL & "      , DATNO      = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '伝票管理NO.
		'2009/06/10 DEL E.N.D FKS)NAKATA
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "        '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSSC_Update_err
		End If
		
		F_TOKSSC_Update = 0
		
F_TOKSSC_Update_end: 
		Exit Function
		
F_TOKSSC_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_Update")
		GoTo F_TOKSSC_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSC_Insert
	'   概要：  請求サマリ外貨新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_dblSSCURIKN    : 売上集計金額
	'           pin_dblSSCUZEKN    : 売上消費税金額
	'           pin_dblSSCNYUKN    : 入金集計金額
	'           pin_dblFKSZANKN    : 消込入金額残
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_dblSSCURIKN() As Double, ByVal pin_dblSSCUZEKN As Double, ByRef pin_dblSSCNYUKN() As Double, ByVal pin_dblFKSZANKN As Double) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_Insert_err
		
		F_TOKSSC_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSC "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , SSADT " '締日付
		strSQL = strSQL & "        , KESDT " '決済日付
		strSQL = strSQL & "        , SSCURIKN00 " '売上集計金額00
		strSQL = strSQL & "        , SSCURIKN01 " '売上集計金額01
		strSQL = strSQL & "        , SSCURIKN02 " '売上集計金額02
		strSQL = strSQL & "        , SSCURIKN03 " '売上集計金額03
		strSQL = strSQL & "        , SSCURIKN04 " '売上集計金額04
		strSQL = strSQL & "        , SSCURIKN05 " '売上集計金額05
		strSQL = strSQL & "        , SSCURIKN06 " '売上集計金額06
		strSQL = strSQL & "        , SSCURIKN07 " '売上集計金額07
		strSQL = strSQL & "        , SSCURIKN08 " '売上集計金額08
		strSQL = strSQL & "        , SSCURIKN09 " '売上集計金額09
		strSQL = strSQL & "        , SSCUZEKN " '売上消費税金額
		strSQL = strSQL & "        , FAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , FAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , FAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , FAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , FAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , FAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , FBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , FBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , FBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , FBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , FBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , FBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SSCNYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSCNYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSCNYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSCNYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSCNYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSCNYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSCNYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSCNYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSCNYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSCNYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , FKSNYKKN " '消込入金額
		strSQL = strSQL & "        , FKSZANKN " '消込入金額残
		strSQL = strSQL & "        , SSCDENSU " '伝票枚数
		strSQL = strSQL & "        , DATNO " '伝票管理NO.
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "        , '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.KESDT, 8) & "' " '決済日付
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(0)) '売上集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(1)) '売上集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(2)) '売上集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(3)) '売上集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(4)) '売上集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(5)) '売上集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(6)) '売上集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(7)) '売上集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(8)) '売上集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCURIKN(9)) '売上集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCUZEKN) '売上消費税金額
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_dblSSCNYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        , 0 " '消込入金額
		strSQL = strSQL & "        ,  " & CStr(pin_dblFKSZANKN) '消込入金額残
		strSQL = strSQL & "        , 0 " '伝票枚数
		'2009/06/10 CHG START FKS)NAKATA
		'strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' "  '伝票管理NO.
		strSQL = strSQL & "        , '" & Space(10) & "' " '伝票管理NO.
		'2009/06/10 CHG E.N.D FKS)NAKATA
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_Insert_err
		End If
		
		F_TOKSSC_Insert = 0
		
F_TOKSSC_Insert_end: 
		Exit Function
		
F_TOKSSC_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_Insert")
		GoTo F_TOKSSC_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSC_UpdateRANK
	'   概要：  請求サマリ外貨更新（ランク別処理）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblFAKZIKN(2) As Double 'ランク別税込課税金額
		Dim dblFAKZOKN(2) As Double 'ランク別税抜課税金額
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSSC_UpdateRANK_err
		
		F_TOKSSC_UpdateRANK = 9
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'ランク別税込課税金額
		dblFAKZIKN(0) = 0
		dblFAKZIKN(1) = 0
		dblFAKZIKN(2) = 0
		dblFAKZIKN(intZEIRNKKB) = dblFAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'ランク別税抜課税金額
		dblFAKZOKN(0) = 0
		dblFAKZOKN(1) = 0
		dblFAKZOKN(2) = 0
		dblFAKZOKN(intZEIRNKKB) = dblFAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET SSCURIKN09 = SSCURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '売上集計金額09
		strSQL = strSQL & "      , FAKZIKN00  = FAKZIKN00  + " & CStr(dblFAKZIKN(0)) 'ランク別税込課税金額00
		strSQL = strSQL & "      , FAKZIKN01  = FAKZIKN01  + " & CStr(dblFAKZIKN(1)) 'ランク別税込課税金額01
		strSQL = strSQL & "      , FAKZIKN02  = FAKZIKN02  + " & CStr(dblFAKZIKN(2)) 'ランク別税込課税金額02
		strSQL = strSQL & "      , FAKZOKN00  = FAKZOKN00  + " & CStr(dblFAKZOKN(0)) 'ランク別税抜課税金額00
		strSQL = strSQL & "      , FAKZOKN01  = FAKZOKN01  + " & CStr(dblFAKZOKN(1)) 'ランク別税抜課税金額01
		strSQL = strSQL & "      , FAKZOKN02  = FAKZOKN02  + " & CStr(dblFAKZOKN(2)) 'ランク別税抜課税金額02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "                 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_UpdateRANK_err
		End If
		
		F_TOKSSC_UpdateRANK = 0
		
F_TOKSSC_UpdateRANK_end: 
		Exit Function
		
F_TOKSSC_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_UpdateRANK")
		GoTo F_TOKSSC_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSSC_UpdateDENSU
	'   概要：  請求サマリ外貨更新（伝票枚数をカウントアップ）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSSC_UpdateDENSU(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSSC_UpdateDENSU_err
		
		F_TOKSSC_UpdateDENSU = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC "
		strSQL = strSQL & "    SET SSCDENSU = SSCDENSU + " & CStr(pin_intSMFKB) '伝票枚数
		'strSQL = strSQL & "      , WRTTM = '" & GCF_Ora_String(GV_SysTime, 6) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & GCF_Ora_String(GV_SysDate, 8) & "' "                'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SSADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SSADT, 8) & "' "   '締日付
		strSQL = strSQL & "    AND SSADT = '" & pv_strSSADT & "' " '締日付
		'2009/09/24 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSSC_UpdateDENSU_err
		End If
		
		F_TOKSSC_UpdateDENSU = 0
		
F_TOKSSC_UpdateDENSU_end: 
		Exit Function
		
F_TOKSSC_UpdateDENSU_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSSC_UpdateDENSU")
		GoTo F_TOKSSC_UpdateDENSU_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSME
	'   概要：  売掛サマリ請求処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSMAURIKN(9) As Decimal '売上集計金額
		Dim curSMAUZEKN As Decimal '売上消費税金額
		Dim curSMAGNKKN(9) As Decimal '原価集計金額
		Dim curSMANYUKN(9) As Decimal '入金集計金額
		
		On Error GoTo F_TOKSME_err
		
		F_TOKSME = 9
		
		'売上集計金額
		curSMAURIKN(0) = 0
		curSMAURIKN(1) = 0
		curSMAURIKN(2) = 0
		curSMAURIKN(3) = 0
		curSMAURIKN(4) = 0
		curSMAURIKN(5) = 0
		curSMAURIKN(6) = 0
		curSMAURIKN(7) = 0
		curSMAURIKN(8) = 0
		curSMAURIKN(9) = 0
		curSMAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMAURIKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.URIKN * pin_intSMFKB
		
		'売上消費税金額
		curSMAUZEKN = pin_Tbl_Inf_UDNTRA.UZEKN * pin_intSMFKB
		
		'原価集計金額
		curSMAGNKKN(0) = 0
		curSMAGNKKN(1) = 0
		curSMAGNKKN(2) = 0
		curSMAGNKKN(3) = 0
		curSMAGNKKN(4) = 0
		curSMAGNKKN(5) = 0
		curSMAGNKKN(6) = 0
		curSMAGNKKN(7) = 0
		curSMAGNKKN(8) = 0
		curSMAGNKKN(9) = 0
		curSMAGNKKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMAGNKKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.GNKKN * pin_intSMFKB
		
		'入金集計金額
		curSMANYUKN(0) = 0
		curSMANYUKN(1) = 0
		curSMANYUKN(2) = 0
		curSMANYUKN(3) = 0
		curSMANYUKN(4) = 0
		curSMANYUKN(5) = 0
		curSMANYUKN(6) = 0
		curSMANYUKN(7) = 0
		curSMANYUKN(8) = 0
		curSMANYUKN(9) = 0
		curSMANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSMANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_TOKSME_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSMAURIKN, curSMAUZEKN, curSMAGNKKN, curSMANYUKN, lngRowCnt) <> 0 Then
			GoTo F_TOKSME_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_TOKSME_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSMAURIKN, curSMAUZEKN, curSMAGNKKN, curSMANYUKN) <> 0 Then
				GoTo F_TOKSME_err
			End If
		End If
		
		'ランク別処理
		'UPGRADE_WARNING: オブジェクト SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) > 0 Then
			If F_TOKSME_UpdateRANK(pm_All, pin_intSMFKB, pin_Tbl_Inf_UDNTRA) <> 0 Then
				GoTo F_TOKSME_err
			End If
		End If
		
		F_TOKSME = 0
		
F_TOKSME_end: 
		Exit Function
		
F_TOKSME_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME")
		GoTo F_TOKSME_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSME_Update
	'   概要：  売掛サマリ請求更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSMAURIKN    : 売上集計金額
	'           pin_curSMAUZEKN    : 売上消費税金額
	'           pin_curSMAGNKKN    : 原価集計金額
	'           pin_curSMANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSMAURIKN() As Decimal, ByVal pin_curSMAUZEKN As Decimal, ByRef pin_curSMAGNKKN() As Decimal, ByRef pin_curSMANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSME_Update_err
		
		F_TOKSME_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME "
		strSQL = strSQL & "    SET SMAURIKN00 = SMAURIKN00 + " & CStr(pin_curSMAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "      , SMAURIKN01 = SMAURIKN01 + " & CStr(pin_curSMAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "      , SMAURIKN02 = SMAURIKN02 + " & CStr(pin_curSMAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "      , SMAURIKN03 = SMAURIKN03 + " & CStr(pin_curSMAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "      , SMAURIKN04 = SMAURIKN04 + " & CStr(pin_curSMAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "      , SMAURIKN05 = SMAURIKN05 + " & CStr(pin_curSMAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "      , SMAURIKN06 = SMAURIKN06 + " & CStr(pin_curSMAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "      , SMAURIKN07 = SMAURIKN07 + " & CStr(pin_curSMAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "      , SMAURIKN08 = SMAURIKN08 + " & CStr(pin_curSMAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "      , SMAURIKN09 = SMAURIKN09 + " & CStr(pin_curSMAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CStr(pin_curSMAUZEKN) '売上消費税金額
		strSQL = strSQL & "      , SMAGNKKN00 = SMAGNKKN00 + " & CStr(pin_curSMAGNKKN(0)) '原価集計金額00
		strSQL = strSQL & "      , SMAGNKKN01 = SMAGNKKN01 + " & CStr(pin_curSMAGNKKN(1)) '原価集計金額01
		strSQL = strSQL & "      , SMAGNKKN02 = SMAGNKKN02 + " & CStr(pin_curSMAGNKKN(2)) '原価集計金額02
		strSQL = strSQL & "      , SMAGNKKN03 = SMAGNKKN03 + " & CStr(pin_curSMAGNKKN(3)) '原価集計金額03
		strSQL = strSQL & "      , SMAGNKKN04 = SMAGNKKN04 + " & CStr(pin_curSMAGNKKN(4)) '原価集計金額04
		strSQL = strSQL & "      , SMAGNKKN05 = SMAGNKKN05 + " & CStr(pin_curSMAGNKKN(5)) '原価集計金額05
		strSQL = strSQL & "      , SMAGNKKN06 = SMAGNKKN06 + " & CStr(pin_curSMAGNKKN(6)) '原価集計金額06
		strSQL = strSQL & "      , SMAGNKKN07 = SMAGNKKN07 + " & CStr(pin_curSMAGNKKN(7)) '原価集計金額07
		strSQL = strSQL & "      , SMAGNKKN08 = SMAGNKKN08 + " & CStr(pin_curSMAGNKKN(8)) '原価集計金額08
		strSQL = strSQL & "      , SMAGNKKN09 = SMAGNKKN09 + " & CStr(pin_curSMAGNKKN(9)) '原価集計金額09
		strSQL = strSQL & "      , SMANYUKN00 = SMANYUKN00 + " & CStr(pin_curSMANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SMANYUKN01 = SMANYUKN01 + " & CStr(pin_curSMANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SMANYUKN02 = SMANYUKN02 + " & CStr(pin_curSMANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SMANYUKN03 = SMANYUKN03 + " & CStr(pin_curSMANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SMANYUKN04 = SMANYUKN04 + " & CStr(pin_curSMANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SMANYUKN05 = SMANYUKN05 + " & CStr(pin_curSMANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SMANYUKN06 = SMANYUKN06 + " & CStr(pin_curSMANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SMANYUKN07 = SMANYUKN07 + " & CStr(pin_curSMANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SMANYUKN08 = SMANYUKN08 + " & CStr(pin_curSMANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SMANYUKN09 = SMANYUKN09 + " & CStr(pin_curSMANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '経理締日付
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_TOKSME_Update_err
		End If
		
		F_TOKSME_Update = 0
		
F_TOKSME_Update_end: 
		Exit Function
		
F_TOKSME_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_Update")
		GoTo F_TOKSME_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSME_Insert
	'   概要：  売掛サマリ請求新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSMAURIKN    : 売上集計金額
	'           pin_curSMAUZEKN    : 売上消費税金額
	'           pin_curSMAGNKKN    : 原価集計金額
	'           pin_curSMANYUKN    : 入金集計金額
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSMAURIKN() As Decimal, ByVal pin_curSMAUZEKN As Decimal, ByRef pin_curSMAGNKKN() As Decimal, ByRef pin_curSMANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_TOKSME_Insert_err
		
		F_TOKSME_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSME "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SMAURIKN00 " '売上集計金額00
		strSQL = strSQL & "        , SMAURIKN01 " '売上集計金額01
		strSQL = strSQL & "        , SMAURIKN02 " '売上集計金額02
		strSQL = strSQL & "        , SMAURIKN03 " '売上集計金額03
		strSQL = strSQL & "        , SMAURIKN04 " '売上集計金額04
		strSQL = strSQL & "        , SMAURIKN05 " '売上集計金額05
		strSQL = strSQL & "        , SMAURIKN06 " '売上集計金額06
		strSQL = strSQL & "        , SMAURIKN07 " '売上集計金額07
		strSQL = strSQL & "        , SMAURIKN08 " '売上集計金額08
		strSQL = strSQL & "        , SMAURIKN09 " '売上集計金額09
		strSQL = strSQL & "        , SMAUZEKN " '売上消費税金額
		strSQL = strSQL & "        , SZAKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZAKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZAKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZAKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZAKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZAKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SZBKZIKN00 " 'ランク別税込課税金額00
		strSQL = strSQL & "        , SZBKZIKN01 " 'ランク別税込課税金額01
		strSQL = strSQL & "        , SZBKZIKN02 " 'ランク別税込課税金額02
		strSQL = strSQL & "        , SZBKZOKN00 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        , SZBKZOKN01 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        , SZBKZOKN02 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        , SMAGNKKN00 " '原価集計金額00
		strSQL = strSQL & "        , SMAGNKKN01 " '原価集計金額01
		strSQL = strSQL & "        , SMAGNKKN02 " '原価集計金額02
		strSQL = strSQL & "        , SMAGNKKN03 " '原価集計金額03
		strSQL = strSQL & "        , SMAGNKKN04 " '原価集計金額04
		strSQL = strSQL & "        , SMAGNKKN05 " '原価集計金額05
		strSQL = strSQL & "        , SMAGNKKN06 " '原価集計金額06
		strSQL = strSQL & "        , SMAGNKKN07 " '原価集計金額07
		strSQL = strSQL & "        , SMAGNKKN08 " '原価集計金額08
		strSQL = strSQL & "        , SMAGNKKN09 " '原価集計金額09
		strSQL = strSQL & "        , SMANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SMANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SMANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SMANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SMANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SMANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SMANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SMANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SMANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SMANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , DATNO " '伝票管理NO.
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '経理締日付
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(0)) '売上集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(1)) '売上集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(2)) '売上集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(3)) '売上集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(4)) '売上集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(5)) '売上集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(6)) '売上集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(7)) '売上集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(8)) '売上集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAURIKN(9)) '売上集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAUZEKN) '売上消費税金額
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税込課税金額02
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額00
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額01
		strSQL = strSQL & "        ,  0 " 'ランク別税抜課税金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(0)) '原価集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(1)) '原価集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(2)) '原価集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(3)) '原価集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(4)) '原価集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(5)) '原価集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(6)) '原価集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(7)) '原価集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(8)) '原価集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMAGNKKN(9)) '原価集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSMANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        , '" & Space(10) & "' " '伝票管理NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSME_Insert_err
		End If
		
		F_TOKSME_Insert = 0
		
F_TOKSME_Insert_end: 
		Exit Function
		
F_TOKSME_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_Insert")
		GoTo F_TOKSME_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_TOKSME_UpdateRANK
	'   概要：  売掛サマリ請求更新（ランク別処理）
	'   引数：  pm_All             : 画面情報
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_TOKSME_UpdateRANK(ByRef pm_All As Cls_All, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim dblSZAKZIKN(2) As Double 'ランク別税込課税金額
		Dim dblSZAKZOKN(2) As Double 'ランク別税抜課税金額
		Dim intZEIRNKKB As Short
		
		On Error GoTo F_TOKSME_UpdateRANK_err
		
		F_TOKSME_UpdateRANK = 9
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intZEIRNKKB = SSSVal(pin_Tbl_Inf_UDNTRA.ZEIRNKKB) - 1
		
		'ランク別税込課税金額
		dblSZAKZIKN(0) = 0
		dblSZAKZIKN(1) = 0
		dblSZAKZIKN(2) = 0
		dblSZAKZIKN(intZEIRNKKB) = dblSZAKZIKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZKMURIKN * pin_intSMFKB
		
		'ランク別税抜課税金額
		dblSZAKZOKN(0) = 0
		dblSZAKZOKN(1) = 0
		dblSZAKZOKN(2) = 0
		dblSZAKZOKN(intZEIRNKKB) = dblSZAKZOKN(intZEIRNKKB) + pin_Tbl_Inf_UDNTRA.ZNKURIKN * pin_intSMFKB
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME "
		strSQL = strSQL & "    SET SMAURIKN09 = SMAURIKN09 - " & CStr(pin_Tbl_Inf_UDNTRA.ZKMUZEKN) '売上集計金額09
		strSQL = strSQL & "      , SZAKZIKN00 = SZAKZIKN00 + " & CStr(dblSZAKZIKN(0)) 'ランク別税込課税金額00
		strSQL = strSQL & "      , SZAKZIKN01 = SZAKZIKN01 + " & CStr(dblSZAKZIKN(1)) 'ランク別税込課税金額01
		strSQL = strSQL & "      , SZAKZIKN02 = SZAKZIKN02 + " & CStr(dblSZAKZIKN(2)) 'ランク別税込課税金額02
		strSQL = strSQL & "      , SZAKZOKN00 = SZAKZOKN00 + " & CStr(dblSZAKZOKN(0)) 'ランク別税抜課税金額00
		strSQL = strSQL & "      , SZAKZOKN01 = SZAKZOKN01 + " & CStr(dblSZAKZOKN(1)) 'ランク別税抜課税金額01
		strSQL = strSQL & "      , SZAKZOKN02 = SZAKZOKN02 + " & CStr(dblSZAKZOKN(2)) 'ランク別税抜課税金額02
		'strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' "       'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		'strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' "       'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' " '経理締日付
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_TOKSME_UpdateRANK_err
		End If
		
		F_TOKSME_UpdateRANK = 0
		
F_TOKSME_UpdateRANK_end: 
		Exit Function
		
F_TOKSME_UpdateRANK_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_TOKSME_UpdateRANK")
		GoTo F_TOKSME_UpdateRANK_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UTGTRA
	'   概要：  受取手形トラン
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim intRet As Short
		Dim lngRowCnt As Integer
		
		On Error GoTo F_UTGTRA_err
		
		F_UTGTRA = 9
		
		'使用可能かつ黒伝票のレコードだけ作成
		If pin_Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_USE And pin_Tbl_Inf_UDNTRA.AKAKROKB = gc_strAKAKROKB_KURO Then
			'更新
			intRet = F_UTGTRA_Update(pm_All, pin_Tbl_Inf_UDNTRA, lngRowCnt)
			If intRet <> 0 Then
				GoTo F_UTGTRA_err
			End If
			
			If lngRowCnt <= 0 Then
				'新規作成
				intRet = F_UTGTRA_Insert(pm_All, pin_Tbl_Inf_UDNTRA)
				If intRet <> 0 Then
					GoTo F_UTGTRA_err
				End If
			End If
		End If
		
		'    If pin_Tbl_Inf_UDNTRA.DATKB = gc_strDATKB_DEL Then
		'        '削除
		'        intRet = F_UTGTRA_Delete(pm_All, pin_Tbl_Inf_UDNTRA)
		'        If intRet <> 0 Then
		'            GoTo F_UTGTRA_err
		'        End If
		'    Else
		'        '更新
		'        intRet = F_UTGTRA_Update(pm_All, pin_Tbl_Inf_UDNTRA, lngRowCnt)
		'        If intRet <> 0 Then
		'            GoTo F_UTGTRA_err
		'        End If
		'
		'        If lngRowCnt <= 0 Then
		'            '新規作成
		'            intRet = F_UTGTRA_Insert(pm_All, pin_Tbl_Inf_UDNTRA)
		'            If intRet <> 0 Then
		'                GoTo F_UTGTRA_err
		'            End If
		'        End If
		'    End If
		
		F_UTGTRA = 0
		
F_UTGTRA_end: 
		Exit Function
		
F_UTGTRA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA")
		GoTo F_UTGTRA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UTGTRA_Delete
	'   概要：  受取手形トラン削除
	'   引数：  pm_All             : 画面情報
	'           pin_strUDNNO       : 売上伝票番号
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Delete(ByRef pm_All As Cls_All, ByVal pin_strUDNNO As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Delete_err
		
		F_UTGTRA_Delete = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " DELETE UTGTRA "
		strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_strUDNNO, 8) & "' " '売上伝票番号
		
		'    'SQL
		'    strSQL = ""
		'    strSQL = strSQL & " DELETE UTGTRA "
		'    strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' "  '売上伝票番号
		'    strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' "  '行番号
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UTGTRA_Delete_err
		End If
		
		F_UTGTRA_Delete = 0
		
F_UTGTRA_Delete_end: 
		Exit Function
		
F_UTGTRA_Delete_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Delete")
		GoTo F_UTGTRA_Delete_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UTGTRA_Update
	'   概要：  受取手形トラン更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Update_err
		
		F_UTGTRA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE UTGTRA "
		strSQL = strSQL & "    SET DATNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "      , NDNNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '入金伝票番号
		strSQL = strSQL & "      , LINNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '行番号
		strSQL = strSQL & "      , NDNDT  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNDT, 8) & "' " '入金伝票日付
		strSQL = strSQL & "      , TOKCD  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "      , BNKCD  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.BNKCD, 7) & "' " '銀行コード
		strSQL = strSQL & "      , TEGDT  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGDT, 8) & "' " '手形期日
		strSQL = strSQL & "      , TEGNO  = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGNO, 10) & "' " '手形番号
		strSQL = strSQL & "      , TEGKN  = " & CStr(pin_Tbl_Inf_UDNTRA.NYUKN) '手形金額
		strSQL = strSQL & "      , LINCMA = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMA, 20) & "' " '明細備考１
		strSQL = strSQL & "      , LINCMB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMB, 20) & "' " '明細備考２
		strSQL = strSQL & "      , UOPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UCLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'ｸﾗｲｱﾝﾄID(ﾊﾞｯﾁ)
		strSQL = strSQL & "      , UWRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , UWRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "      , PGID   = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
		strSQL = strSQL & "      , DLFLG  = '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '削除フラグ
		strSQL = strSQL & "  WHERE NDNNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '売上伝票番号
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '行番号
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_UTGTRA_Update_err
		End If
		
		F_UTGTRA_Update = 0
		
F_UTGTRA_Update_end: 
		Exit Function
		
F_UTGTRA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Update")
		GoTo F_UTGTRA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UTGTRA_Insert
	'   概要：  受取手形トラン新規登録
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UTGTRA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_UTGTRA_Insert_err
		
		F_UTGTRA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UTGTRA "
		strSQL = strSQL & "        ( DATNO " '伝票管理NO.
		strSQL = strSQL & "        , NDNNO " '入金伝票番号
		strSQL = strSQL & "        , LINNO " '行番号
		strSQL = strSQL & "        , NDNDT " '入金伝票日付
		strSQL = strSQL & "        , TOKCD " '得意先コード
		strSQL = strSQL & "        , BNKCD " '銀行コード
		strSQL = strSQL & "        , TEGDT " '手形期日
		strSQL = strSQL & "        , TEGNO " '手形番号
		strSQL = strSQL & "        , TEGKN " '手形金額
		strSQL = strSQL & "        , LINCMA " '明細備考１
		strSQL = strSQL & "        , LINCMB " '明細備考２
		strSQL = strSQL & "        , FOPEID " '初回登録ユーザID
		strSQL = strSQL & "        , FCLTID " '初回登録クライアントID
		strSQL = strSQL & "        , WRTFSTTM " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , WRTFSTDT " 'タイムスタンプ（登録日）
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントＩＤ
		strSQL = strSQL & "        , WRTTM " 'タイムスタンプ（時間）
		strSQL = strSQL & "        , WRTDT " 'タイムスタンプ（日付）
		strSQL = strSQL & "        , UOPEID " 'ユーザID（バッチ）
		strSQL = strSQL & "        , UCLTID " 'クライアントID（バッチ）
		strSQL = strSQL & "        , UWRTTM " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "        , UWRTDT " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "        , PGID " '更新PGID
		strSQL = strSQL & "        , DLFLG " '削除フラグ
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.DATNO, 10) & "' " '伝票管理NO.
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNNO, 8) & "' " '入金伝票番号
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINNO, 3) & "' " '行番号
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.UDNDT, 8) & "' " '入金伝票日付
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKSEICD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.BNKCD, 7) & "' " '銀行コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGDT, 8) & "' " '手形期日
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TEGNO, 10) & "' " '手形番号
		strSQL = strSQL & "        ,  " & CStr(pin_Tbl_Inf_UDNTRA.NYUKN) '手形金額
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMA, 20) & "' " '明細備考１
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.LINCMB, 20) & "' " '明細備考２
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '初回登録ユーザID
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '初回登録クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（登録時間）
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（登録日）
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（日付）
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID（バッチ）
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID（バッチ）
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
		strSQL = strSQL & "        , '" & CF_Ora_String(gc_strDLFLG_INS, 1) & "' " '削除フラグ
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_UTGTRA_Insert_err
		End If
		
		F_UTGTRA_Insert = 0
		
F_UTGTRA_Insert_end: 
		Exit Function
		
F_UTGTRA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UTGTRA_Insert")
		GoTo F_UTGTRA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA
	'   概要：  入金消込サマリ処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '入金集計金額
		
		On Error GoTo F_NKSSMA_err
		
		F_NKSSMA = 9
		
		'入金集計金額
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_NKSSMA_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMA_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMA_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMA_err
			End If
		End If
		
		F_NKSSMA = 0
		
F_NKSSMA_end: 
		Exit Function
		
F_NKSSMA_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA")
		GoTo F_NKSSMA_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA_Update
	'   概要：  入金消込サマリ更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA_Update_err
		
		F_NKSSMA_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMA "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMA_Update_err
		End If
		
		F_NKSSMA_Update = 0
		
F_NKSSMA_Update_end: 
		Exit Function
		
F_NKSSMA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA_Update")
		GoTo F_NKSSMA_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA_Insert
	'   概要：  入金消込サマリ新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA_Insert_err
		
		F_NKSSMA_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMA "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  0 " '前月入金消込金額00
		strSQL = strSQL & "        ,  0 " '前月入金消込金額01
		strSQL = strSQL & "        ,  0 " '前月入金消込金額02
		strSQL = strSQL & "        ,  0 " '前月入金消込金額03
		strSQL = strSQL & "        ,  0 " '前月入金消込金額04
		strSQL = strSQL & "        ,  0 " '前月入金消込金額05
		strSQL = strSQL & "        ,  0 " '前月入金消込金額06
		strSQL = strSQL & "        ,  0 " '前月入金消込金額07
		strSQL = strSQL & "        ,  0 " '前月入金消込金額08
		strSQL = strSQL & "        ,  0 " '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMA_Insert_err
		End If
		
		F_NKSSMA_Insert = 0
		
F_NKSSMA_Insert_end: 
		Exit Function
		
F_NKSSMA_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA_Insert")
		GoTo F_NKSSMA_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB
	'   概要：  入金消込サマリ前受処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '入金集計金額
		
		On Error GoTo F_NKSSMB_err
		
		F_NKSSMB = 9
		
		'入金集計金額
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_NKSSMB_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMB_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMB_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMB_err
			End If
		End If
		
		F_NKSSMB = 0
		
F_NKSSMB_end: 
		Exit Function
		
F_NKSSMB_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB")
		GoTo F_NKSSMB_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB_Update
	'   概要：  入金消込サマリ前受更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB_Update_err
		
		F_NKSSMB_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMB "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMB_Update_err
		End If
		
		F_NKSSMB_Update = 0
		
F_NKSSMB_Update_end: 
		Exit Function
		
F_NKSSMB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB_Update")
		GoTo F_NKSSMB_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB_Insert
	'   概要：  入金消込サマリ前受新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB_Insert_err
		
		F_NKSSMB_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMB "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  0 " '前月入金消込金額00
		strSQL = strSQL & "        ,  0 " '前月入金消込金額01
		strSQL = strSQL & "        ,  0 " '前月入金消込金額02
		strSQL = strSQL & "        ,  0 " '前月入金消込金額03
		strSQL = strSQL & "        ,  0 " '前月入金消込金額04
		strSQL = strSQL & "        ,  0 " '前月入金消込金額05
		strSQL = strSQL & "        ,  0 " '前月入金消込金額06
		strSQL = strSQL & "        ,  0 " '前月入金消込金額07
		strSQL = strSQL & "        ,  0 " '前月入金消込金額08
		strSQL = strSQL & "        ,  0 " '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMB_Insert_err
		End If
		
		F_NKSSMB_Insert = 0
		
F_NKSSMB_Insert_end: 
		Exit Function
		
F_NKSSMB_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB_Insert")
		GoTo F_NKSSMB_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC
	'   概要：  入金消込サマリ外貨処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim lngRowCnt As Integer
		
		Dim curSSANYUKN(9) As Decimal '入金集計金額
		
		On Error GoTo F_NKSSMC_err
		
		F_NKSSMC = 9
		
		'入金集計金額
		curSSANYUKN(0) = 0
		curSSANYUKN(1) = 0
		curSSANYUKN(2) = 0
		curSSANYUKN(3) = 0
		curSSANYUKN(4) = 0
		curSSANYUKN(5) = 0
		curSSANYUKN(6) = 0
		curSSANYUKN(7) = 0
		curSSANYUKN(8) = 0
		curSSANYUKN(9) = 0
		curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) = curSSANYUKN(CInt(pin_Tbl_Inf_UDNTRA.UPDID)) + pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		
		'計算結果を更新する
		If F_NKSSMC_Update(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMC_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMC_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curSSANYUKN) <> 0 Then
				GoTo F_NKSSMC_err
			End If
		End If
		
		F_NKSSMC = 0
		
F_NKSSMC_end: 
		Exit Function
		
F_NKSSMC_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC")
		GoTo F_NKSSMC_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC_Update
	'   概要：  入金消込サマリ外貨更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC_Update_err
		
		F_NKSSMC_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMC "
		strSQL = strSQL & "    SET SSANYUKN00 = SSANYUKN00 + " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "      , SSANYUKN01 = SSANYUKN01 + " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "      , SSANYUKN02 = SSANYUKN02 + " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "      , SSANYUKN03 = SSANYUKN03 + " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "      , SSANYUKN04 = SSANYUKN04 + " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "      , SSANYUKN05 = SSANYUKN05 + " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "      , SSANYUKN06 = SSANYUKN06 + " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "      , SSANYUKN07 = SSANYUKN07 + " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "      , SSANYUKN08 = SSANYUKN08 + " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "      , SSANYUKN09 = SSANYUKN09 + " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMC_Update_err
		End If
		
		F_NKSSMC_Update = 0
		
F_NKSSMC_Update_end: 
		Exit Function
		
F_NKSSMC_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC_Update")
		GoTo F_NKSSMC_Update_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC_Insert
	'   概要：  入金消込サマリ外貨新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curSSANYUKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC_Insert_err
		
		F_NKSSMC_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMC "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		'2009/09/30 UPD START RISE)MIYAJIMA
		'    strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.SMADT, 8) & "' "   '経理締日付
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		'2009/09/30 UPD E.N.D RISE)MIYAJIMA
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(0)) '入金集計金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(1)) '入金集計金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(2)) '入金集計金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(3)) '入金集計金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(4)) '入金集計金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(5)) '入金集計金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(6)) '入金集計金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(7)) '入金集計金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(8)) '入金集計金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curSSANYUKN(9)) '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  0 " '前月入金消込金額00
		strSQL = strSQL & "        ,  0 " '前月入金消込金額01
		strSQL = strSQL & "        ,  0 " '前月入金消込金額02
		strSQL = strSQL & "        ,  0 " '前月入金消込金額03
		strSQL = strSQL & "        ,  0 " '前月入金消込金額04
		strSQL = strSQL & "        ,  0 " '前月入金消込金額05
		strSQL = strSQL & "        ,  0 " '前月入金消込金額06
		strSQL = strSQL & "        ,  0 " '前月入金消込金額07
		strSQL = strSQL & "        ,  0 " '前月入金消込金額08
		strSQL = strSQL & "        ,  0 " '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMC_Insert_err
		End If
		
		F_NKSSMC_Insert = 0
		
F_NKSSMC_Insert_end: 
		Exit Function
		
F_NKSSMC_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC_Insert")
		GoTo F_NKSSMC_Insert_end
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Enable
	'   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
	'   　　　　明細行のｺﾝﾄﾛｰﾙ制御を行う
	'   引数：　pm_All　: 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		Dim InpRow As Short
		Dim Wk_ColHINCD As Short
		Dim strJDNTRKB As String
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
						Case FR_SSSMAIN.BD_DKBID(1).Text, FR_SSSMAIN.BD_DKBID(2).Text, FR_SSSMAIN.BD_DKBID(3).Text, FR_SSSMAIN.BD_DKBID(4).Text, FR_SSSMAIN.BD_DKBID(5).Text, FR_SSSMAIN.BD_DKBID(6).Text
							Wk_Index = CShort(FR_SSSMAIN.BD_DKBID(Wk_Row).Tag)
							Call F_Dsp_BD_DKBID_Inf(pm_All.Dsp_Sub_Inf(Wk_Index), DSP_SET, pm_All)
							
						Case FR_SSSMAIN.BD_BNKCD(1).Text, FR_SSSMAIN.BD_BNKCD(2).Text, FR_SSSMAIN.BD_BNKCD(3).Text, FR_SSSMAIN.BD_BNKCD(4).Text, FR_SSSMAIN.BD_BNKCD(5).Text, FR_SSSMAIN.BD_BNKCD(6).Text
							Wk_Index = CShort(FR_SSSMAIN.BD_BNKCD(Wk_Row).Tag)
							Call F_Dsp_BD_BNKCD_Inf(pm_All.Dsp_Sub_Inf(Wk_Index), DSP_SET, pm_All)
							
						Case FR_SSSMAIN.BD_NYUKN(0).Name
							'背景色設定
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_NYUKN(Wk_Row).Tag)), pm_All)
							
						Case FR_SSSMAIN.BD_FNYUKN(0).Name
							'背景色設定
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.BD_FNYUKN(Wk_Row).Tag)), pm_All)
							
						Case Else
							'背景色設定
							Call F_Set_Body_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					End Select
				End If
			Next 
		End If
		
		'** ｺﾝﾄﾛｰﾙ制御 **
		
		'【受注番号】
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'前受入金
			Call F_Util_JDNNO_SetOnOff(True, pm_All)
		Else
			'入金
			Call F_Util_JDNNO_SetOnOff(False, pm_All)
			Call F_Util_JDNNO_Clear(pm_All)
		End If
		
		'【入金額(外貨)】
		If URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
			Call F_Util_FNYUKN_SetOnOff(True, pm_All) '海外
		Else
			Call F_Util_FNYUKN_SetOnOff(False, pm_All) '国内か、エラー
			Call F_Util_FNYUKN_Clear(pm_All)
		End If
		
		'入金額
		Call F_Util_NYUKN_Sum(pm_All)
		Call F_Util_FNYUKN_Sum(pm_All)
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Bef_Chk_Value
	'   概要：  明細表示時にチェック済み項目とする
	'   引数：　pm_All　: 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Bef_Chk_Value(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
					Select Case True
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.TextBox
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))) <> "" Then
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
						Case TypeOf pm_All.Dsp_Sub_Inf(Index_Wk).Ctl Is System.Windows.Forms.CheckBox
							If CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk)) <> System.Windows.Forms.CheckState.Unchecked Then
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(Index_Wk))
								pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Not_Input_Chk_Fin_Flg = True
							End If
					End Select
					
				End If
			Next 
		End If
		
	End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function AE_Hardcopy_SSSMAIN
    '   概要：  ハードコピー画面呼出し後処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
        If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        On Error Resume Next
        System.Windows.Forms.Application.DoEvents()
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
        '2019/05/22 CHG START
        'FR_SSSMAIN.PrintForm()
        '2019/05/22 CHG END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
        If Err.Number <> 0 Then
            If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
        End If
        On Error GoTo 0
        AE_Hardcopy_SSSMAIN = Cn_CuCurrent
    End Function

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function F_Ctl_MN_APPENDC_Click
    '   概要：  画面初期化制御
    '   引数：　pm_All : 画面情報
    '   戻値：　なし
    '   備考：  全画面ローカル共通処理
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function F_Ctl_MN_APPENDC_Click(ByRef pm_All As Cls_All) As Short
		
		Dim strKJNDT As String

        ' === 20130711 === INSERT S - FWEST)Koroyasu 排他制御の解除
        '排他解除
        '2019/05/23 CHG START
        'Call CF_Del_EXCTBZ2()
        CF_Unlock_EXCTBZ2()
        '2019/05/23 CHG END
        ' === 20130711 === INSERT E -

        '画面明細情報設定
        Call F_Init_Def_Body_Inf(pm_All)
		
		'画面内容初期化
		Call F_Init_Clr_Dsp(-1, pm_All)

        '入力担当者編集
        '2019/05/23 CHG START
        'Call CF_Set_Frm_IN_TANCD(FR_SSSMAIN, pm_All)
        Call CF_Set_Frm_IN_TANCD_URKET52(FR_SSSMAIN, pm_All)
        '2019/05/23 CHG END

        '画面ボディ部初期化
        Call F_Init_Clr_Dsp_Body(-1, pm_All)
		
		'初期表示編集
		Call F_Edi_Dsp_Def(pm_All)
		
		'画面明細表示
		Call CF_Body_Dsp(pm_All)
		
		'入力担当者の権限を再設定
		Call F_Chg_INPTANCD_KNG(Inp_Inf, pm_All, GV_UNYDate)
		
		gv_bolInit = True
		
		'初期ﾌｫｰｶｽ位置設定
		Call SSSMAIN0001.F_Init_Cursor_Set(pm_All)
		
		gv_bolInit = False
		
		'画面変更なしとする
		gv_bolURKET52_INIT = False
		gv_bolURKET52_LF_Enable = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Def_Body_Inf
	'   概要：  画面ボディ情報設定
	'   引数：　pm_All : 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Init_Def_Body_Inf(ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Col_Index As Short
		Dim Index_Wk As Short
		
		'初期画面ボディ情報設定
		Call CF_Init_Set_Body_Inf(pm_All)
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細行が存在する場合
			
			'画面ボディの列分の配列定義
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'初期状態
			pm_All.Dsp_Body_Inf.Row_Inf(0).Status = BODY_ROW_STATE_DEFAULT
			
			'初期化用設定
			'画面ボディの列分の配列定義
			ReDim Preserve pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'初期状態
			pm_All.Dsp_Body_Inf.Init_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'復元情報設定
			'列分の復元行の配列定義
			ReDim Preserve pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(pm_All.Dsp_Base.Body_Col_Cnt)
			'初期状態
			pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Status = BODY_ROW_STATE_DEFAULT
			
			'画面ボディ情報の配列０番目に列情報を定義する
			For Bd_Col_Index = 1 To pm_All.Dsp_Base.Body_Col_Cnt
				'画面ボディ情報
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index) = pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Body_Fst_Idx + Bd_Col_Index - 1).Detail
				
				'初期化用情報
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_All.Dsp_Body_Inf.Init_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
				
				'復元情報
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf.Item_Detail(Bd_Col_Index) = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail(Bd_Col_Index)
			Next 
			
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Edi_Dsp_Def
	'   概要：  初期時の画面編集
	'   引数：　pm_All : 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Dsp_Def(ByRef pm_All As Cls_All) As Short
		Dim Index_Wk As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'UPGRADE_WARNING: オブジェクト FR_SSSMAIN.SYSDT.Tag の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Index_Wk = CShort(FR_SSSMAIN.SYSDT.Tag)
		'画面日付
		Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(VB6.Format(GV_UNYDate, "@@@@/@@/@@"), pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Reset_ErrStatus
	'   概要：  エラー状態初期化
	'   引数：　なし
	'   戻値：　0:正常  11:異常
	'   備考：  対象外のコントロールについては初期化を行わない
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Reset_ErrStatus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf) As Short
		
		Dim Ret_Value As Short
		F_Reset_ErrStatus = 9
		Ret_Value = CHK_OK
		
		'    With FR_SSSMAIN
		'        Select Case pm_Dsp_Sub_Inf.Ctl.NAME
		'            'いちおう、ヘッダ部、ボディ部、テイル部は分けておく
		'            Case .HD_SOUCD.NAME
		'            Case .BD_ODNYTDT(0).NAME
		'                '出荷予定日
		'                pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
		'
		'            Case Else
		'                '対象が「○○○」の場合
		'
		'        End Select
		'    End With
		
		F_Reset_ErrStatus = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chg_INPTANCD_KNG
	'   概要：  入力担当者権限変更
	'   引数：　なし
	'   戻値：　0:正常  11:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chg_INPTANCD_KNG(ByRef pot_Inp_Inf As Cmn_Inp_Inf, ByRef pm_All As Cls_All, Optional ByVal pin_strKJNDT As String = "") As Short
		
		F_Chg_INPTANCD_KNG = 9
		
		'権限再取得
		Call F_Get_INPTANCD_Inf(pot_Inp_Inf.InpTanCd, pot_Inp_Inf, pin_strKJNDT)
		'明細使用可否設定
		Call F_Set_Body_Enable(pm_All)
		
		F_Chg_INPTANCD_KNG = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Item_Color
	'   概要：  明細の項目色設定
	'   引数：  pm_Dsp_Sub_Inf : 画面項目情報
	'           pm_all         : 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Item_Color(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		'    Dim intRow          As Integer
		'    Dim intDspRow       As Integer
		'
		'    intRow = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)           '明細行番号
		'    intDspRow = pm_Dsp_Sub_Inf.Detail.Body_Index                '画面表示行番号
		'
		'    Select Case pm_Dsp_Sub_Inf.Ctl.NAME
		'        '明細：入金額(円)
		'        Case FR_SSSMAIN.BD_NYUKN(0).NAME
		'            'オーバーフローが発生している場合は背景色は赤に変更
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '背景色設定
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_NYUKN(intDspRow).Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        '明細：入金額(外貨)
		'        Case FR_SSSMAIN.BD_FNYUKN(0).NAME
		'            'オーバーフローが発生している場合は背景色は赤に変更
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '背景色設定
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_FNYUKN(intDspRow).Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        'テイル：合計(円)
		'        Case FR_SSSMAIN.TL_SBANYUKN.NAME
		'            'オーバーフローが発生している場合は背景色は赤に変更
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '背景色設定
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.TL_SBANYUKN.Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        'テイル：合計(外貨)
		'        Case FR_SSSMAIN.TL_SBAFRNKN.NAME
		'            'オーバーフローが発生している場合は背景色は赤に変更
		'            If pm_All.Dsp_Body_Inf.Row_Inf(intRow).Bus_Inf.bolOver = True Then
		'                '背景色設定
		'                pm_All.Dsp_Sub_Inf(FR_SSSMAIN.TL_SBAFRNKN.Tag).Ctl.BackColor = COLOR_RED
		'            End If
		'
		'        Case Else
		'    End Select
		'
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_SYSTBA
	'   概要：  ユーザ情報取得
	'   引数：
	'   戻値：　0:正常  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_SYSTBA() As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		On Error GoTo F_GET_SYSTBA_Err
		
		F_GET_SYSTBA = 9
		
		'変数初期化
		pv_strYERUPDDT = ""
		'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
		'月次本締日の条件撤廃
		'    pv_strMONUPDDT = ""
		pv_strSMAUPDDT = ""
		'''' UPD 2011/01/14  FKS) T.Yamamoto    End
		pv_strSMADD = ""
		
		'SQL編集
		strSQL = ""
		strSQL = strSQL & " SELECT YERUPDDT " '年次更新実行日
		'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
		'月次本締日の条件撤廃
		'    strSQL = strSQL & "      , MONUPDDT " '月次更新実行日
		strSQL = strSQL & "      , SMAUPDDT " '前回経理締実行日
		'''' UPD 2011/01/14  FKS) T.Yamamoto    End
		strSQL = strSQL & "      , SMADD " '決算日
		strSQL = strSQL & "   FROM SYSTBA "

        'SQL実行
        'change 20190726 START hou
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        '      If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pv_strYERUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "YERUPDDT", ""))
        '	'''' UPD 2011/01/14  FKS) T.Yamamoto    Start    連絡票№FC11011401
        '	'月次本締日の条件撤廃
        '	'        pv_strMONUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "MONUPDDT", ""))
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pv_strSMAUPDDT = Trim(CF_Ora_GetDyn(Usr_Ody, "SMAUPDDT", ""))
        '	'''' UPD 2011/01/14  FKS) T.Yamamoto    End
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pv_strSMADD = Trim(CF_Ora_GetDyn(Usr_Ody, "SMADD", ""))
        'End If
        Dim dt As DataTable = DB_GetTable(strSQL)

        If dt Is Nothing OrElse dt.Rows.Count >= 1 Then
            'Dim intcnt As Short = 0
            For Each row As DataRow In dt.Rows
                '    intcnt = intcnt + 1
                pv_strYERUPDDT = Trim(DB_NullReplace(row("YERUPDDT"), ""))
                pv_strSMAUPDDT = Trim(DB_NullReplace(row("SMAUPDDT"), ""))
                pv_strSMADD = Trim(DB_NullReplace(row("SMADD"), ""))
            Next
        End If
        'change 20190726 END hou

        F_GET_SYSTBA = 0
		
F_GET_SYSTBA_End: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_GET_SYSTBA_Err: 
		
		GoTo F_GET_SYSTBA_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_LostFocus_Dummy
	'   概要：  対象項目のLOSTFOCUSダミー処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：　ActiveControlに対してLOSTFOCUS時と同様のチェック、画面制御を行う。
	'          （ただしフォーカス移動は行わない）
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_LostFocus_Dummy(ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		Dim Wk_Row As Short
		Dim LF_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf
		
		On Error GoTo CF_Ctl_Item_LostFocus_Dummy_End
		
		CF_Ctl_Item_LostFocus_Dummy = CHK_OK
		
		If gv_bolURKET52_LF_Enable = False Then
			Exit Function
		End If
		
		If FR_SSSMAIN.ActiveControl Is Nothing Then
			Exit Function
		End If
		
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		If IsNumeric(FR_SSSMAIN.ActiveControl.Tag) = False Then
			Exit Function
		End If
		
		'ﾛｽﾄﾌｫｰｶｽ実行判定
		If pm_All.Dsp_Base.LostFocus_Flg = True Then
			pm_All.Dsp_Base.LostFocus_Flg = False
			Exit Function
		End If
		
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト LF_Dsp_Sub_Inf の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		LF_Dsp_Sub_Inf = pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag))
		
		Move_Flg = False
		Chk_Move_Flg = True
		
		'各項目のﾁｪｯｸﾙｰﾁﾝ
		Rtn_Chk = SSSMAIN0001.F_Ctl_Item_Chk(LF_Dsp_Sub_Inf, CHK_FROM_LOSTFOCUS, Chk_Move_Flg, pm_All)
		
		If Rtn_Chk = CHK_OK Then
			'チェックＯＫ時
			'取得内容表示
			Dsp_Mode = DSP_SET
		Else
			'チェックＮＧ時
			'取得内容クリア
			Dsp_Mode = DSP_CLR
		End If
		'取得内容表示/クリア
		Call SSSMAIN0001.F_Dsp_Item_Detail(LF_Dsp_Sub_Inf, Dsp_Mode, pm_All)
		
		If Chk_Move_Flg = True Then
			'ﾁｪｯｸ後移動あり
			Call CF_Set_Item_Color(LF_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			'明細背景色設定
			Call F_Set_Body_Item_Color(LF_Dsp_Sub_Inf, pm_All)
		Else
			'ﾁｪｯｸ後移動なし
		End If
		
		Wk_Row = LF_Dsp_Sub_Inf.Detail.Body_Index
		
		'チェック結果を画面情報に戻す
		'UPGRADE_ISSUE: Control Tag は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.ActiveControl.Tag)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.ActiveControl.Tag)) = LF_Dsp_Sub_Inf
		
		CF_Ctl_Item_LostFocus_Dummy = Rtn_Chk
		
CF_Ctl_Item_LostFocus_Dummy_End: 
		
	End Function
	
	Public Function GetLocalTimeText() As String
		Dim t As SYSTEMTIME
		Dim r As String
		
		On Error GoTo Err_GetLocalTimeText
		Call GetLocalTime(t)
		
		r = VB6.Format(t.wHour, "00") & ":" & VB6.Format(t.wMinute, "00") & ":" & VB6.Format(t.wSecond, "00") & "." & VB6.Format(t.wMilliseconds, "000")
		
		GetLocalTimeText = r
		
End_GetLocalTimeText: 
		Exit Function
		
Err_GetLocalTimeText: 
		Call MsgBox(Err.Description & " : " & Err.Number & " : " & Err.Source)
	End Function
	
	'// V1.20↓ ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HAITA_JDNNO
	'   概要：  明細：受注番号の排他ﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HAITA_JDNNO(ByRef pm_All As Cls_All) As Short
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Retn_Code = CHK_OK
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'受注番号
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			
			If strJdnNo <> "" Or strJDNLINNO <> "" Then
				If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					GoTo F_Chk_HAITA_JDNNO_End
				End If
			End If
			
		Next intCnt
		
F_Chk_HAITA_JDNNO_End: 
		
		F_Chk_HAITA_JDNNO = Retn_Code
	End Function
	'// V1.20↑ ADD
	
	'2009/06/08 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_UODKN_JDNNO
	'   概要：  明細：受注金額=入金額チェック
	'   引数：  pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_UODKN_JDNNO(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim intCnt2 As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim curNYUKN As Decimal
		Dim curUODKN As Decimal
		
		'*** 2009/09/07 ADD START FKS)NAKATA
		Dim strDKBID As String '入金種別
		'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'初期化
			strJdnNo = ""
			strJDNLINNO = ""
			curNYUKN = 0
			'*** 2009/09/07 ADD START FKS)NAKATA
			strDKBID = ""
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
			
			'*** 2009/09/07 ADD START FKS)NAKATA
			'入金種別
			
			strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
			
			'*** 2009/09/07 ADD START FKS)NAKATA
			'本入金は処理を行わない
			If Trim(strDKBID) <> "09" Then
				'*** 2009/09/07 ADD E.N.D FKS)NAKATA
				
				'受注番号
				strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
				strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
				
				
				'入金額
				curNYUKN = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.NYUKN
				
				
				For intCnt2 = 1 To pv_intMeisaiCnt
					
					'自分自身以外の明細行を対象とする
					If intCnt <> intCnt2 Then
						
						'*** 2009/09/07 CHG START FKS)NAKATA
						'If Trim(strJdnNo) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNNO) _
						'' And Trim(strJDNLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNLINNO) Then
						
						'本入金は相手にしない
						If Trim(strJdnNo) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNNO) And Trim(strJDNLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.JDNLINNO) And Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.DKBID) <> "09" Then
							'*** 2009/09/07 CHG E.N.D FKS)NAKATA
							
							curNYUKN = curNYUKN + pm_All.Dsp_Body_Inf.Row_Inf(intCnt2).Bus_Inf.NYUKN
							
						End If
					End If
				Next intCnt2
				
				If strJdnNo <> "" Or strJDNLINNO <> "" Then
					
					'受注金額の取得
					curUODKN = F_Util_Get_UODKN(strJdnNo, strJDNLINNO)
					
					'受注金額 > 入金額
					If curNYUKN > curUODKN Then
						
						Msg_Flg = True
						Err_Cd = gc_strMsgURKET52_E_031 '受注金額を上回っています。
						GoTo F_Chk_UODKN_JDNNO_End
						
						'受注金額 < 入金額
					ElseIf curNYUKN < curUODKN Then 
						
						Msg_Flg = True
						Err_Cd = gc_strMsgURKET52_E_032 '受注金額を下回っています。
						GoTo F_Chk_UODKN_JDNNO_End
						
					End If
					
				End If
				'*** 2009/09/07 ADD START FKS)NAKATA
			End If
			'*** 2009/09/07 ADD E.N.D FKS)NAKATA
		Next intCnt
		
F_Chk_UODKN_JDNNO_End: 
		
		'*** 2009/09/07 CHG START FKS)NAKATA
		'アラートメッセージからエラーメッセージに変更
		'''    If Msg_Flg = True And Trim(Err_Cd) <> "" Then
		'''        'メッセージ出力
		'''        If AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All) = vbNo Then
		'''            Retn_Code = CHK_WARN 'ワーニング
		'''        Else
		'''            Retn_Code = CHK_OK
		'''        End If
		'''
		'''    End If
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		'*** 2009/09/07 CHG E.N.D FKS)NAKATA
		
		F_Chk_UODKN_JDNNO = Retn_Code
		
	End Function
	'2009/06/08 ADD E.N.D FKS)NAKATA
	
	'*** 2009/09/07 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_UODKN_JDNNO
	'   概要：  明細：受注金額=入金額チェック
	'   引数：  pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_Chk_KESIZUMI(ByRef pm_All As Cls_All) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim strOKRJONO As String
		Dim strDKBID As String
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		Dim strJDNTRKB As String
		Dim intKESI As Short
		
		On Error GoTo F_Chk_KESIZUMI_err
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		
		
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'本入金への振替は無視する
			If strDKBID <> "09" Then
				
				'送り状№の格納
				strOKRJONO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.OKRJONO)
				
				strJdnNo = Left(Trim(strOKRJONO), 6)
				strJDNLINNO = Right(Trim(strOKRJONO), 3)
				
				'受注取引区分の取得
				strSQL = ""
				strSQL = strSQL & " SELECT DATNO "
				strSQL = strSQL & " ,      JDNTRKB"
				strSQL = strSQL & "   FROM JDNTHA "
				strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
				strSQL = strSQL & "           FROM JDNTHA "
				strSQL = strSQL & "          WHERE JDNNO = '" & strJdnNo & "'"
				strSQL = strSQL & "            AND DATKB = '1' "
				strSQL = strSQL & "            AND MAEUKKB  = '2' "
				strSQL = strSQL & "        ) SUB "
				strSQL = strSQL & "  WHERE JDNNO        = '" & strJdnNo & "'"
				strSQL = strSQL & "    AND DATKB        = '1'"
				strSQL = strSQL & "    AND AKAKROKB     = '1'"
				strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
				strSQL = strSQL & "    AND MAEUKKB      = '2'"
				strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

                'DBアクセス
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                '取得データ退避
                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = False Then
                If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                    'change end 20190826 kuwa
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'change start 20190827 kuwa
                    'strJDNTRKB = CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")
                    strJDNTRKB = DB_NullReplace(dt.Rows(0)("JDNTRKB"), "")
                    'change end 20190827 kuwa
                End If


                '消込されているかの確認
                strSQL = "" & vbCrLf
				strSQL = strSQL & "SELECT  COUNT(*) AS CNT"
				strSQL = strSQL & "  FROM   NKSTRA"
				strSQL = strSQL & " WHERE   DATKB     = '1'"
				strSQL = strSQL & "  AND    AKAKROKB  = '1'"
				strSQL = strSQL & "  AND    JDNNO     = '" & strJdnNo & "'"
				
				'システム・セットアップは伝票単位にて確認
				If strJDNTRKB = "11" Or strJDNTRKB = "21" Then
				Else
					strSQL = strSQL & "  AND   JDNLINNO  = '" & strJDNLINNO & "'"
				End If
				
				strSQL = strSQL & "  AND    KDNNO NOT IN "
				strSQL = strSQL & "     ("
				strSQL = strSQL & "     SELECT  MOTKDNNO"
				strSQL = strSQL & "       FROM  NKSTRA"
				strSQL = strSQL & "         WHERE   JDNNO   =   '" & strJdnNo & "'"
				
				'システム・セットアップは伝票単位にて確認
				If strJDNTRKB = "11" Or strJDNTRKB = "21" Then
				Else
					strSQL = strSQL & "       AND   JDNLINNO  = '" & strJDNLINNO & "'"
				End If
				strSQL = strSQL & "           AND  TRIM(MOTKDNNO) IS NOT NULL"
				strSQL = strSQL & "       )"


                'DBアクセス
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                dt = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                '取得データ退避
                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = False Then
                If dt Is Nothing OrElse dt.Rows.Count > 0 Then
                    'change end 20190826 kuwa
                    'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'change start 20190827 kuwa
                    'intKESI = SSSVal(CF_Ora_GetDyn(Usr_Ody, "CNT", ""))
                    intKESI = SSSVal(DB_NullReplace(dt.Rows(0)("CNT"), ""))
                    'change end 20190827 kuwa
                Else
                    GoTo F_Chk_KESIZUMI_end
				End If
				
				'クローズ
				Call CF_Ora_CloseDyn(Usr_Ody)
				
				'消込済の場合
				If intKESI > 0 Then
					
					Msg_Flg = True
					Err_Cd = gc_strMsgURKET52_E_036 '充当済みです。更新できません。
					GoTo F_Chk_KESIZUMI_end
					
				End If
			End If
			
		Next intCnt
		
		
F_Chk_KESIZUMI_end: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_Chk_KESIZUMI = Retn_Code
		
		Exit Function
		
F_Chk_KESIZUMI_err: 
		GoTo F_Chk_KESIZUMI_end
		
	End Function
	'*** 2009/09/07 ADD E.N.D FKS)NAKATA
	
	
	'// V1.20↓ ADD
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_FIXMTA
	'   概要：  固定値マスタ取得
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_FIXMTA(ByRef pin_strFIXVAL As String) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_Get_FIXMTA_err
		
		F_Get_FIXMTA = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " SELECT FIXVAL "
		strSQL = strSQL & "   FROM FIXMTA "
		strSQL = strSQL & "  WHERE CTLCD        = '" & CF_Ora_String(gc_strCTLCD_SSAKB, 10) & "' "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        '取得データ
        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            pin_strFIXVAL = ""
            GoTo F_Get_FIXMTA_end
        Else
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'pin_strFIXVAL = CF_Ora_GetDyn(Usr_Ody, "FIXVAL", "")
            pin_strFIXVAL = DB_NullReplace(dt.Rows(0)("FIXVAL"), "")
            'change end 20190826 kuwa
        End If
		
		F_Get_FIXMTA = 0
		
F_Get_FIXMTA_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Get_FIXMTA_err: 
		GoTo F_Get_FIXMTA_end
		
	End Function
	'// V1.20↑ ADD
	
	'2009/09/03 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_GET_TANMTA_TANCLAKB
	'   概要：  営業担当フラグを取得
	'   引数：　pot_strTANCD       : 担当者コード
	'       ：　pot_strKEIBMNCD    : 営業担当フラグ
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
		
		F_Util_GET_TANMTA_TANCLAKB = 9
		
		pot_strTANCLAKB = ""
		
		'担当者Ｍ
		strSQL = ""
		strSQL = strSQL & " SELECT TANCLAKB "
		strSQL = strSQL & " FROM TANMTA "
		strSQL = strSQL & " WHERE TANCD = '" & pot_strTANCD & "' "

        'DBアクセス
        'changr 20190729 START hou
        '      Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

        'If CF_Ora_EOF(Usr_Ody) = False Then
        '	'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
        Dim dt As DataTable = DB_GetTable(strSQL)
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            pot_strTANCLAKB = DB_NullReplace(dt.Rows(0)("TANCLAKB"), "")
            'change 20190729 END hou
        Else
            GoTo END_F_Util_GET_TANMTA_TANCLAKB
		End If
		
		F_Util_GET_TANMTA_TANCLAKB = 0
		
END_F_Util_GET_TANMTA_TANCLAKB: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Util_GET_TANMTA_TANCLAKB: 
		GoTo END_F_Util_GET_TANMTA_TANCLAKB
		
	End Function
	'2009/09/03 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/18 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_AllKESAIBI
	'   概要：  明細：期日到来か判定
	'   引数：  pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_Chk_AllKESAIBI(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim strDKBID As String
		Dim strOKRJONO As String
		Dim strTEGDT As String
		
		On Error GoTo F_Chk_AllKESAIBI_err
		
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'本入金への振替は無視する
			If strDKBID <> pc_strDKBID_URK_HNYU Then
				
				If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT) <> "" Then
					strTEGDT = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT)
				Else
					strTEGDT = ""
				End If
				
				If Trim(strTEGDT) <> "" Then
					'運用日テーブル.運用日付（UNYMTA）> 画面.決済日の場合
					If Trim(GV_UNYDate) > Trim(strTEGDT) Then
						If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID <> pc_strDKBID_URK_GENKN Then
							Msg_Flg = True
							Err_Cd = gc_strMsgURKET52_E_035
							GoTo F_Chk_AllKESAIBI_end
						End If
					End If
				End If
				
			End If
		Next intCnt
		
F_Chk_AllKESAIBI_end: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Retn_Code = CHK_ERR_ELSE
		End If
		
		F_Chk_AllKESAIBI = Retn_Code
		
		Exit Function
		
F_Chk_AllKESAIBI_err: 
		GoTo F_Chk_AllKESAIBI_end
		
	End Function
	'2009/09/18 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/18 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_MaeukeTEGDT
	'   概要：  明細：期日到来か判定
	'   引数：  pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function F_GET_MaeukeTEGDT(ByRef pm_All As Cls_All, ByRef pmstrOKRJONO As String, ByRef pstrTEGDT As String) As String
		
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strDKBID As String
		Dim strOKRJONO As String
		Dim strDSPTEGDT As String
		Dim strMAXTEGDT As String
		
		Dim I As Short
		
		On Error GoTo F_GET_MaeukeTEGDT_err
		
		F_GET_MaeukeTEGDT = ""
		
		strDSPTEGDT = ""
		strMAXTEGDT = ""
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'取引区分取得
			strDKBID = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.DKBID)
			
			'受注番号の取引区分が（08：振込仮）のものを検索する
			If strDKBID = pc_strDKBID_URK_HURIK Then
				'送り状№の格納
				strOKRJONO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.OKRJONO)
				'受注番号を比較（同一のものを探す）
				If pmstrOKRJONO = strOKRJONO Then
					'決済日を入手
					strDSPTEGDT = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.TEGDT)
					'決済日の最大を求めるために比較
					If strMAXTEGDT <= strDSPTEGDT Then
						strMAXTEGDT = strDSPTEGDT
					End If
				End If
			End If
		Next intCnt
		
		'※取引区分が08：振込仮の明細が存在しない場合は、運用日を最大決済日として設定する
		If strMAXTEGDT = "" Then
			If Trim(pstrTEGDT) <> "" Then
				strMAXTEGDT = Trim(pstrTEGDT)
			Else
				'2009/10/07 UPD START RISE)MIYAJIMA
				'            strMAXTEGDT = Trim(GV_UNYDate)
				strMAXTEGDT = Trim(URKET52_HEAD_Inf.NYUDT)
				'2009/10/07 UPD E.N.D RISE)MIYAJIMA
			End If
		End If
		
		F_GET_MaeukeTEGDT = strMAXTEGDT
		
F_GET_MaeukeTEGDT_end: 
		
		Exit Function
		
F_GET_MaeukeTEGDT_err: 
		GoTo F_GET_MaeukeTEGDT_end
		
	End Function
	'2009/09/18 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/27 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_RATERT
	'   概要：  通貨に対するレートを取得する
	'   引数：  pstrTUKKB：通貨区分,pstrUDNDT：所得基準日
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_RATERT(ByVal pstrTUKKB As String, ByVal pstrUDNDT As String) As Object
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		
		On Error GoTo ERR_F_Get_RATERT
		
		'UPGRADE_WARNING: オブジェクト F_Get_RATERT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_Get_RATERT = 0
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM TUKMTA "
		strSQL = strSQL & " WHERE TUKKB  =  '" & CF_Ora_String(pstrTUKKB, 3) & "' "
		strSQL = strSQL & "   AND TEKIDT <= '" & CF_Ora_String(pstrUDNDT, 8) & "' "
		strSQL = strSQL & " ORDER BY TEKIDT DESC "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'If CF_Ora_EOF(Usr_Ody_LC) = False Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'F_Get_RATERT = CF_Ora_GetDyn(Usr_Ody_LC, "RATERT", 0)
            F_Get_RATERT = DB_NullReplace(dt.Rows(0)("RATERT"), 0)
            'change end 20190826 kuwa
        End If

END_F_Get_RATERT: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
		
ERR_F_Get_RATERT: 
		GoTo END_F_Get_RATERT
		
	End Function
	'2009/09/27 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_Tourai
	'   概要：  期日到来しているかの判断を行う
	'   引数：  pm_All             : 画面情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_Tourai(ByRef pm_All As Cls_All) As Object
		
		Dim I As Short
		Dim J As Short
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		On Error GoTo F_Util_Tourai_err
		
		'UPGRADE_WARNING: オブジェクト F_Util_Tourai の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_Util_Tourai = 9
		
		pv_intTouraiKbn = 0
		
		For I = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) <> "" Then
				
				If URKET52_HEAD_Inf.UDNTHA.NYUCD <> "2" Then
					'通常
					'                For J = I To UBound(URKET52_HEAD_Inf.UDNTRA)
					For J = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'変更前の情報を構造体にコピー
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(J)
						If Trim(Tbl_Inf_UDNTRA.DATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(Tbl_Inf_UDNTRA.LINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
							'取引区分転送
							URKET52_HEAD_Inf.DKBID(J) = pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID
							'取引区分が異なっているかの判断
							If Trim(Tbl_Inf_UDNTRA.DKBID) <> Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) Then
								If Trim(Tbl_Inf_UDNTRA.TEGDT) <> "" Then
									'2009/10/07 UPD START RISE)MIYAJIMA
									'                                If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Then
									If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Or Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(URKET52_HEAD_Inf.NYUDT) Then
										'2009/10/07 UPD E.N.D RISE)MIYAJIMA
										'期日が到来しているのでフラグON
										URKET52_HEAD_Inf.TEGKB(J) = 1
										pv_intTouraiKbn = 1
									End If
								End If
							End If
						End If
					Next J
				Else
					'前受
					'                For J = I To UBound(URKET52_HEAD_Inf.UDNTRA)
					For J = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
						'変更前の情報を構造体にコピー
						'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(J)
						If Trim(Tbl_Inf_UDNTRA.DATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(Tbl_Inf_UDNTRA.LINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
							'取引区分転送
							URKET52_HEAD_Inf.DKBID(J) = pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID
							If Trim(Tbl_Inf_UDNTRA.NYUKB) = "2" Then
								'取引区分が異なっているかの判断
								If Trim(Tbl_Inf_UDNTRA.DKBID) <> Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DKBID) Then
									If Trim(Tbl_Inf_UDNTRA.TEGDT) <> "" Then
										'2009/10/07 UPD START RISE)MIYAJIMA
										'                                    If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Then
										If Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(GV_UNYDate) Or Trim(Tbl_Inf_UDNTRA.TEGDT) <= Trim(URKET52_HEAD_Inf.NYUDT) Then
											'2009/10/07 UPD E.N.D RISE)MIYAJIMA
											'期日が到来しているのでフラグON
											URKET52_HEAD_Inf.TEGKB(J) = 1
											pv_intTouraiKbn = 1
										End If
									End If
								End If
							End If
						End If
					Next J
				End If
				
			End If
		Next I
		
		'UPGRADE_WARNING: オブジェクト F_Util_Tourai の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_Util_Tourai = 0
		
F_Util_Tourai_end: 
		Exit Function
		
F_Util_Tourai_err: 
		GoTo F_Util_Tourai_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HAITA_NKSSMX
	'   概要：  入金消込サマリ排他制御
	'   引数：  pm_All             : 画面情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HAITA_NKSSMX(ByRef pm_All As Cls_All) As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		
		On Error GoTo F_Chk_HAITA_NKSSMX_err
		
		F_Chk_HAITA_NKSSMX = 9
		
		With URKET52_HEAD_Inf
			If .TOKMTA.FRNKB = gc_strFRNKB_FRN Then
				'海外
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM NKSSMC "
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(.TOKMTA.TUKKB, 3) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				strSQL = strSQL & " FOR UPDATE "
			Else
				'国内
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				If .NYUKB = gc_strMAEUKKB_NML Then '入金
					strSQL = strSQL & " FROM NKSSMA "
				Else '前受入金
					strSQL = strSQL & " FROM NKSSMB "
				End If
				strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(.TOKCD, 10) & "' "
				strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
				strSQL = strSQL & " FOR UPDATE "
			End If
		End With

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            ' データなしの場合
            F_Chk_HAITA_NKSSMX = 1
            GoTo F_Chk_HAITA_NKSSMX_end
        Else
            ' 更新前データと異なるデータが存在した場合はエラーとする。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'change start 20190826 kuwa
            'If gc_NKSSMX_Inf.strOPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or gc_NKSSMX_Inf.strCLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or gc_NKSSMX_Inf.strWRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or gc_NKSSMX_Inf.strWRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Then
            If gc_NKSSMX_Inf.strOPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or gc_NKSSMX_Inf.strCLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or gc_NKSSMX_Inf.strWRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or gc_NKSSMX_Inf.strWRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Then
                'change end 20190826 kuwa
                GoTo F_Chk_HAITA_NKSSMX_end
            End If
        End If
		
		F_Chk_HAITA_NKSSMX = 0
		
F_Chk_HAITA_NKSSMX_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Chk_HAITA_NKSSMX_err: 
		GoTo F_Chk_HAITA_NKSSMX_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_DspIndex
	'   概要：  画面のどこに格納されているか検索する
	'   引数：  pm_All             : 画面情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_DspIndex(ByRef pm_All As Cls_All, ByRef strDATNO As String, ByRef strLINNO As String) As Object
		
		Dim I As Short
		
		On Error GoTo F_Get_DspIndex_err
		
		'UPGRADE_WARNING: オブジェクト F_Get_DspIndex の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_Get_DspIndex = 0
		
		For I = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If Trim(strDATNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.DATNO) And Trim(strLINNO) = Trim(pm_All.Dsp_Body_Inf.Row_Inf(I).Bus_Inf.LINNO) Then
				'UPGRADE_WARNING: オブジェクト F_Get_DspIndex の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				F_Get_DspIndex = I
			End If
		Next I
		
F_Get_DspIndex_end: 
		Exit Function
		
F_Get_DspIndex_err: 
		GoTo F_Get_DspIndex_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UDNTRA_MakeInf_Tourai
	'   概要：  売上トラン登録データ作成
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_strDATNO       : 伝票管理NO.
	'           pin_strDENNO       : 伝票番号
	'           pin_strRECNO       : レコード管理NO.
	'           pot_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UDNTRA_MakeInf_Tourai(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_strDATNO As String, ByVal pin_strDENNO As String, ByVal pin_strRECNO As String, ByRef pot_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA) As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Dim strDKBSB As String
		Dim strDKBID As String
		Dim strDKBNM As String
		
		Dim curNYUKN As Decimal
		Dim dblFNYUKN As Double
		
		Dim strNYUKB As String
		
		Dim strLINCMA As String
		Dim strLINCMB As String
		Dim strBNKCD As String
		Dim strBNKNM As String
		Dim strTEGNO As String
		Dim strTEGDT As String
		Dim strUPDID As String
		Dim strDFLDKBCD As String
		Dim strDKBZAIFL As String
		Dim strDKBTEGFL As String
		Dim strDKBFLA As String
		Dim strDKBFLB As String
		Dim strDKBFLC As String
		
		'2009/06/05 ADD START FKS)NAKATA
		Dim strOKRJONO As String
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim strKANKOZ As String
		
		On Error GoTo F_UDNTRA_MakeInf_Tourai_err
		
		F_UDNTRA_MakeInf_Tourai = 9
		
		'受注番号
		strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNNO
		strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.JDNLINNO
		
		'2009/06/05 ADD START FKS)NAKATA
		strOKRJONO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.OKRJONO
		'2009/06/05 ADD E.N.D FKS)NAKATA
		
		
		'取引区分
		strDKBSB = pc_strDKBSB_URK
		strDKBID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBID
		strDKBNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.DKBNM
		
		'入金額
		curNYUKN = pot_Tbl_Inf_UDNTRA.NYUKN
		dblFNYUKN = pot_Tbl_Inf_UDNTRA.FNYUKN
		
		'入金種別
		'2009/09/18 UPD START RISE)MIYAJIMA
		'    Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
		'        Case "3":  strNYUKB = "4"
		'        Case "2":  strNYUKB = "2"
		'        Case Else: strNYUKB = "1"
		'    End Select
		Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD)
			Case "3" : strNYUKB = "4"
			Case "2" : strNYUKB = "2"
			Case Else : strNYUKB = "1"
		End Select
		If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
			Select Case Trim(pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBID)
				Case pc_strDKBID_URK_SOSAI, pc_strDKBID_URK_NEBIK, pc_strDKBID_URK_TESU, pc_strDKBID_URK_HOKA, pc_strDKBID_URK_SYOH
					strNYUKB = "2"
			End Select
		End If
		'2009/09/18 UPD E.N.D RISE)MIYAJIMA
		
		strLINCMA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMA
		strLINCMB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.LINCMB
		strBNKCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKCD
		strBNKNM = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.BNKNM
		strTEGNO = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGNO
		strTEGDT = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.TEGDT
		strUPDID = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.UPDID
		strDFLDKBCD = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DFLDKBCD
		strDKBZAIFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBZAIFL
		strDKBTEGFL = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBTEGFL
		strDKBFLA = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLA
		strDKBFLB = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLB
		strDKBFLC = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.SYSTBD.DKBFLC
		strKANKOZ = pm_All.Dsp_Body_Inf.Row_Inf(pin_intRow).Bus_Inf.KANKOZ
		
		With Tbl_Inf_UDNTRA
			.DATNO = pin_strDATNO '伝票管理NO.
			.DATKB = gc_strDATKB_USE '伝票削除区分
			.AKAKROKB = gc_strAKAKROKB_AKA '赤黒区分
			.DENKB = "8" '伝票区分
			.UDNNO = pin_strDENNO '売上伝票番号
			.LINNO = VB6.Format(pin_intRow, "000") '行番号
			.ZKTKB = "" '取引区分
			.ODNNO = "" '出荷伝票番号
			.ODNLINNO = "" '行番号
			
			'2009/06/05 CHG START FKS)NAKATA
			'.JDNNO = strJdnNo                                   '受注伝票番号
			'.JDNLINNO = strJDNLINNO                             '受注伝票行番号
			.JDNNO = "" '受注伝票番号
			.JDNLINNO = "" '受注伝票行番号
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.RECNO = pin_strRECNO 'レコード管理NO.
			.USDNO = "" '直送伝票NO
			.UDNDT = URKET52_HEAD_Inf.NYUDT '売上伝票日付
			.DKBSB = strDKBSB '伝票取引区分種別
			.DKBID = strDKBID '取引区分コード
			.DKBNM = strDKBNM '取引区分名称
			.HENRSNCD = "" '返品理由
			.HENSTTCD = "" '返品状態
			.SMADT = pv_strSMADT '経理締日付
			.SSADT = pv_strSSADT '締日付
			.KESDT = pv_strKESDT '決済日付
			.TOKCD = URKET52_HEAD_Inf.TOKCD '得意先コード
			.TANCD = "" '担当者コード
			.NHSCD = "" '納入先コード
			.TOKSEICD = URKET52_HEAD_Inf.TOKCD '請求先コード
			.SOUCD = "" '倉庫コード
			.SBNNO = "" '製番
			.HINCD = "" '製品コード
			.TOKJDNNO = "" '客先注文番号
			.HINNMA = "" '型式
			.HINNMB = "" '商品名１
			.UNTCD = "" '単位コード
			.UNTNM = "" '単位名
			.IRISU = 0 '入数
			.CASSU = 0 'ケース数
			.URISU = 0 '売上数量
			.URITK = 0 '単価
			.GNKTK = 0 '原価単価
			.SIKTK = 0 '営業仕切単価
			.FURITK = 0 '外貨単価
			.URIKN = 0 '売上金額
			.FURIKN = 0 '外貨売上金額
			.SIKKN = 0 '営業仕切金額
			.UZEKN = 0 '消費税金額
			.NYUDT = "" '入金日
			.NYUKN = curNYUKN '入金額
			.FNYUKN = dblFNYUKN '外貨入金額
			.GNKKN = 0 '原価金額
			.JKESIKN = 0 '消込金額
			.FKESIKN = 0 '外貨消込金額
			
			'2009/06/05 ADD START FKS)NAKATA
			'.KESIKB = ""                                        '消込区分
			.KESIKB = CStr(9)
			'2009/06/05 ADD E.N.D FKS)NAKATA
			
			.NYUKB = strNYUKB '入金種別
			.TNKID = "" '種別
			.TUKKB = URKET52_HEAD_Inf.TOKMTA.TUKKB '通貨区分
			'2009/09/27 UPD START RISE)MIYAJIMA
			'        .RATERT = 0                                         '為替レート
			'UPGRADE_WARNING: オブジェクト F_Get_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.RATERT = F_Get_RATERT(URKET52_HEAD_Inf.TOKMTA.TUKKB, URKET52_HEAD_Inf.NYUDT) '為替レート
			'2009/09/27 UPD E.N.D RISE)MIYAJIMA
			.EMGODNKB = "" '緊急出荷区分
			
			'2009/06/05 CHG START FKS)NAKATA
			'.OKRJONO = ""                                       '送り状№
			.OKRJONO = strOKRJONO
			'2009/06/05 CHG E.N.D FKS)NAKATA
			
			.INVNO = "" 'インボイス№
			.LINCMA = strLINCMA '明細備考１
			.LINCMB = strLINCMB '明細備考２
			.BNKCD = strBNKCD '銀行コード
			.BNKNM = strBNKNM '銀行名称
			.TEGNO = strTEGNO '手形番号
			'2009/09/18 UPD START RISE)MIYAJIMA
			.TEGDT = strTEGDT '手形期日
			If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML Then
				.TEGDT = strTEGDT '手形期日
			Else
				If URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_KIJZITU Or URKET52_HEAD_Inf.TOKMTA.SHAKB = pc_strSHAKB_FACTERING Then
					If .DKBID <> pc_strDKBID_URK_GENKN And .DKBID <> pc_strDKBID_URK_HURI And .DKBID <> pc_strDKBID_URK_TEG And .DKBID <> pc_strDKBID_URK_HNYU And .DKBID <> pc_strDKBID_URK_HURIK Then
						.TEGDT = F_GET_MaeukeTEGDT(pm_All, Trim(strOKRJONO), strTEGDT) '手形期日
					Else
						.TEGDT = strTEGDT '手形期日
					End If
				End If
			End If
			'2009/09/18 UPD E.N.D RISE)MIYAJIMA
			.UPDID = strUPDID '更新用ｲﾝﾃﾞｯｸｽ(ACNT)
			.DFLDKBCD = strDFLDKBCD 'デフォルトコード
			.DKBZAIFL = strDKBZAIFL '在庫関連フラグ
			.DKBTEGFL = strDKBTEGFL '手形発生フラグ
			.DKBFLA = strDKBFLA 'ダミーフラグ１
			.DKBFLB = strDKBFLB 'ダミーフラグ２
			.DKBFLC = strDKBFLC 'ダミーフラグ３
			.LSTID = "" '伝票種別
			.HINZEIKB = "" '商品消費税区分
			.HINMSTKB = "" 'マスタ区分(商品)
			.TOKMSTKB = "" 'マスタ区分(得意先)
			.NHSMSTKB = "" 'マスタ区分(納入先)
			.TANMSTKB = "" 'マスタ区分(担当者)
			.ZEIRNKKB = "" '消費税ランク
			.HINKB = "" '商品区分
			.ZEIRT = 0 '消費税率
			.ZAIKB = "" '在庫管理区分
			.MRPKB = "" '展開区分
			.HINJUNKB = "" '順位表出力区分
			.MAKCD = "" 'メーカーコード
			.HINSIRCD = strKANKOZ '商品仕入先コード
			.HINNMMKB = "" '名称ﾏﾆｭｱﾙ区分(商品)
			.HRTDD = "" '発注リードタイム
			.ORTDD = "" '出荷リードタイム
			.ZNKURIKN = 0 '税抜課税対象額
			.ZKMURIKN = 0 '税込課税対象額
			.ZKMUZEKN = 0 '税込消費税
			.MOTDATNO = URKET52_HEAD_Inf.UDNTHA.DATNO '元伝票管理番号
			.FOPEID = SSS_OPEID.Value '初回登録ユーザID
			.FCLTID = SSS_CLTID.Value '初回登録クライアントID
			.WRTFSTTM = GV_SysTime 'タイムスタンプ（登録時間）
			.WRTFSTDT = GV_SysDate 'タイムスタンプ（登録日）
			.OPEID = SSS_OPEID.Value '最終作業者コード
			.CLTID = SSS_CLTID.Value 'クライアントＩＤ
			.WRTTM = GV_SysTime 'タイムスタンプ（時間）
			.WRTDT = GV_SysDate 'タイムスタンプ（日付）
			.UOPEID = SSS_OPEID.Value 'ユーザID（バッチ）
			.UCLTID = SSS_CLTID.Value 'クライアントID（バッチ）
			.UWRTTM = GV_SysTime 'タイムスタンプ（バッチ時間）
			.UWRTDT = GV_SysDate 'タイムスタンプ（バッチ日付）
			.PGID = SSS_PrgId '更新PGID
			.DLFLG = gc_strDLFLG_UPD '削除フラグ
		End With
		
		'UPGRADE_WARNING: オブジェクト pot_Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_Tbl_Inf_UDNTRA = Tbl_Inf_UDNTRA
		
		F_UDNTRA_MakeInf_Tourai = 0
		
F_UDNTRA_MakeInf_Tourai_end: 
		Exit Function
		
F_UDNTRA_MakeInf_Tourai_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UDNTRA_MakeInf_Tourai")
		GoTo F_UDNTRA_MakeInf_Tourai_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_UPDSMF
	'   概要：  サマリファイル群の更新
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トランデータ
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_UPDSMF2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim intRet As Short
		
		On Error GoTo F_UPDSMF2_err
		
		F_UPDSMF2 = 9
		
		'更新条件：入金区分＝１：入金 かつ デフォルトコード≠３
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'請求サマリ更新
			intRet = F_TOKSSA(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'入金消込サマリの更新
			intRet = F_NKSSMA2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
		End If
		
		'更新条件：入金区分＝２：前受入金
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'前受請求サマリ更新
			intRet = F_TOKSSB(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'入金消込サマリ前受の更新
			intRet = F_NKSSMB2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		'更新条件：入金区分＝１：入金 かつ 海外取引区分＝１：海外
		'2009/09/24 UPD START RISE)MIYAJIMA
		'    If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN Then
		If URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And URKET52_HEAD_Inf.TOKMTA.FRNKB = gc_strFRNKB_FRN And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "3" Then
			'2009/09/24 UPD E.N.D RISE)MIYAJIMA
			'請求サマリ外貨の更新
			intRet = F_TOKSSC(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
			
			'入金消込サマリ外貨の更新
			intRet = F_NKSSMC2(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA, pin_strOLDDKBID, pin_strNEWDKBID, pin_intTEGKB)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		'更新条件：入金区分＝１：入金 かつ デフォルトコード≠２
		'更新条件：入金区分＝２：前受入金
		If (URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_NML And Trim(pin_Tbl_Inf_UDNTRA.DFLDKBCD) <> "2") Or URKET52_HEAD_Inf.NYUKB = gc_strMAEUKKB_MAE Then
			'売掛サマリ請求の更新
			intRet = F_TOKSME(pm_All, pin_intRow, pin_intSMFKB, pin_Tbl_Inf_UDNTRA)
			If intRet <> 0 Then
				F_UPDSMF2 = intRet
				GoTo F_UPDSMF2_err
			End If
		End If
		
		F_UPDSMF2 = 0
		
F_UPDSMF2_end: 
		Exit Function
		
F_UPDSMF2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_UPDSMF")
		GoTo F_UPDSMF2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA2
	'   概要：  入金消込サマリ処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '入金集計金額
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMA2_err
		
		F_NKSSMA2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMA "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            '取得データあり
            For I = 0 To 9
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID取得
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
		End If
		
		If durKSKZANKN_WK < 0 Then
			curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
		End If
		
		'計算結果を更新する
		If F_NKSSMA2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMA2_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMA2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMA2_err
			End If
		End If
		
		F_NKSSMA2 = 0
		
F_NKSSMA2_end: 
		Exit Function
		
F_NKSSMA2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2")
		GoTo F_NKSSMA2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB2
	'   概要：  入金消込サマリ前受処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '入金集計金額
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMB2_err
		
		F_NKSSMB2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMB "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '取得データあり
            For I = 0 To 9
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID取得
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.NYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
			
			If durKSKZANKN_WK < 0 Then
				curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
			End If
		End If
		
		'計算結果を更新する
		If F_NKSSMB2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMB2_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMB2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMB2_err
			End If
		End If
		
		F_NKSSMB2 = 0
		
F_NKSSMB2_end: 
		Exit Function
		
F_NKSSMB2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2")
		GoTo F_NKSSMB2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC2
	'   概要：  入金消込サマリ外貨処理
	'   引数：  pm_All             : 画面情報
	'           pin_intRow         : 行番号
	'           pin_intSMFKB       : 符号(黒伝票の場合は+1、赤伝票の場合は-1)
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2(ByRef pm_All As Cls_All, ByVal pin_intRow As Short, ByVal pin_intSMFKB As Short, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByVal pin_strOLDDKBID As String, ByVal pin_strNEWDKBID As String, ByVal pin_intTEGKB As Short) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim I As Short
		
		Dim Mst_Inf_SYSTBD As TYPE_DB_SYSTBD
		Dim curKSKZANKN(9) As Decimal '入金集計金額
		Dim durKSKZANKN_WK As Decimal
		Dim durNYUKINKN_WK As Decimal
		Dim intOLDUPDID As Decimal
		Dim intNEWUPDID As Decimal
		Dim lngRowCnt As Integer
		
		On Error GoTo F_NKSSMC2_err
		
		F_NKSSMC2 = 9
		
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & " FROM NKSSMC "
		strSQL = strSQL & " WHERE TOKCD = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKCD, 10) & "' "
		strSQL = strSQL & "   AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' "
		strSQL = strSQL & "   AND TUKKB = '" & CF_Ora_String(URKET52_HEAD_Inf.TOKMTA.TUKKB, 3) & "' "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) <> True Then
        If dt Is Nothing OrElse dt.Rows.Count > 0 Then
            'change end 20190826 kuwa
            '取得データあり
            For I = 0 To 9
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190826 kuwa
                'curKSKZANKN(I) = CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & VB6.Format(I, "00"), 0)
                curKSKZANKN(I) = DB_NullReplace(dt.Rows(0)("KSKZANKN" & VB6.Format(I, "00")), 0)
                'change end 20190826 kuwa
            Next I
        End If

        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
		
		'UPDID取得
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strOLDDKBID, Mst_Inf_SYSTBD)
		intOLDUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		Call SYSTBD_SEARCH(pc_strDKBSB_URK, pin_strNEWDKBID, Mst_Inf_SYSTBD)
		intNEWUPDID = CDec(Mst_Inf_SYSTBD.UPDID)
		
		durNYUKINKN_WK = pin_Tbl_Inf_UDNTRA.FNYUKN * pin_intSMFKB
		durKSKZANKN_WK = curKSKZANKN(intOLDUPDID) + durNYUKINKN_WK
		If curKSKZANKN(intOLDUPDID) > 0 Then
			If durKSKZANKN_WK >= 0 Then
				curKSKZANKN(intOLDUPDID) = durKSKZANKN_WK
				durKSKZANKN_WK = 0
			Else
				curKSKZANKN(intOLDUPDID) = curKSKZANKN(intOLDUPDID) + (durNYUKINKN_WK - durKSKZANKN_WK)
			End If
			
			If durKSKZANKN_WK < 0 Then
				curKSKZANKN(intNEWUPDID) = curKSKZANKN(intNEWUPDID) + durKSKZANKN_WK
			End If
		End If
		
		'計算結果を更新する
		If F_NKSSMC2_Update(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN, lngRowCnt) <> 0 Then
			GoTo F_NKSSMC2_err
		End If
		
		'更新対象がなかったら、新規登録する
		If lngRowCnt <= 0 Then
			If F_NKSSMC2_Insert(pm_All, pin_Tbl_Inf_UDNTRA, curKSKZANKN) <> 0 Then
				GoTo F_NKSSMC2_err
			End If
		End If
		
		F_NKSSMC2 = 0
		
F_NKSSMC2_end: 
		Exit Function
		
F_NKSSMC2_err: 
		'Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2")
		GoTo F_NKSSMC2_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA2_Update
	'   概要：  入金消込サマリ更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curKSKZANKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA2_Update_err
		
		F_NKSSMA2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMA "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMA2_Update_err
		End If
		
		F_NKSSMA2_Update = 0
		
F_NKSSMA2_Update_end: 
		Exit Function
		
F_NKSSMA2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2_Update")
		GoTo F_NKSSMA2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMA2_Insert
	'   概要：  入金消込サマリ新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMA2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMA2_Insert_err
		
		F_NKSSMA2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMA "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		strSQL = strSQL & "        ,  0 " '入金集計金額00
		strSQL = strSQL & "        ,  0 " '入金集計金額01
		strSQL = strSQL & "        ,  0 " '入金集計金額02
		strSQL = strSQL & "        ,  0 " '入金集計金額03
		strSQL = strSQL & "        ,  0 " '入金集計金額04
		strSQL = strSQL & "        ,  0 " '入金集計金額05
		strSQL = strSQL & "        ,  0 " '入金集計金額06
		strSQL = strSQL & "        ,  0 " '入金集計金額07
		strSQL = strSQL & "        ,  0 " '入金集計金額08
		strSQL = strSQL & "        ,  0 " '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMA2_Insert_err
		End If
		
		F_NKSSMA2_Insert = 0
		
F_NKSSMA2_Insert_end: 
		Exit Function
		
F_NKSSMA2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMA2_Insert")
		GoTo F_NKSSMA2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB2_Update
	'   概要：  入金消込サマリ前受更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB2_Update_err
		
		F_NKSSMB2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMB "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMB2_Update_err
		End If
		
		F_NKSSMB2_Update = 0
		
F_NKSSMB2_Update_end: 
		Exit Function
		
F_NKSSMB2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2_Update")
		GoTo F_NKSSMB2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMB2_Insert
	'   概要：  入金消込サマリ前受新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMB2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMB2_Insert_err
		
		F_NKSSMB2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMB "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		strSQL = strSQL & "        ,  0 " '入金集計金額00
		strSQL = strSQL & "        ,  0 " '入金集計金額01
		strSQL = strSQL & "        ,  0 " '入金集計金額02
		strSQL = strSQL & "        ,  0 " '入金集計金額03
		strSQL = strSQL & "        ,  0 " '入金集計金額04
		strSQL = strSQL & "        ,  0 " '入金集計金額05
		strSQL = strSQL & "        ,  0 " '入金集計金額06
		strSQL = strSQL & "        ,  0 " '入金集計金額07
		strSQL = strSQL & "        ,  0 " '入金集計金額08
		strSQL = strSQL & "        ,  0 " '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMB2_Insert_err
		End If
		
		F_NKSSMB2_Insert = 0
		
F_NKSSMB2_Insert_end: 
		Exit Function
		
F_NKSSMB2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMB2_Insert")
		GoTo F_NKSSMB2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC2_Update
	'   概要：  入金消込サマリ外貨更新
	'   引数：  pm_All             : 画面情報
	'           pin_Tbl_Inf_UDNTRA : 売上トラン情報
	'           pin_curSSANYUKN    : 入金集計金額
	'           pot_lngRowCnt      : 更新件数
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2_Update(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal, ByRef pot_lngRowCnt As Integer) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC2_Update_err
		
		F_NKSSMC2_Update = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " UPDATE NKSSMC "
		strSQL = strSQL & "    SET KSKZANKN00 = " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "      , KSKZANKN01 = " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "      , KSKZANKN02 = " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "      , KSKZANKN03 = " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "      , KSKZANKN04 = " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "      , KSKZANKN05 = " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "      , KSKZANKN06 = " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "      , KSKZANKN07 = " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "      , KSKZANKN08 = " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "      , KSKZANKN09 = " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "      , OPEID = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "      , WRTTM = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "      , WRTDT = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL, pot_lngRowCnt)
		If bolRet = False Then
			GoTo F_NKSSMC2_Update_err
		End If
		
		F_NKSSMC2_Update = 0
		
F_NKSSMC2_Update_end: 
		Exit Function
		
F_NKSSMC2_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2_Update")
		GoTo F_NKSSMC2_Update_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/09/30 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_NKSSMC2_Insert
	'   概要：  入金消込サマリ外貨新規登録
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_NKSSMC2_Insert(ByRef pm_All As Cls_All, ByRef pin_Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA, ByRef pin_curKSKZANKN() As Decimal) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_NKSSMC2_Insert_err
		
		F_NKSSMC2_Insert = 9
		
		'SQL
		strSQL = ""
		strSQL = strSQL & " INSERT INTO NKSSMC "
		strSQL = strSQL & "        ( TOKCD " '得意先コード
		strSQL = strSQL & "        , TUKKB " '通貨区分
		strSQL = strSQL & "        , SMADT " '経理締日付
		strSQL = strSQL & "        , SSANYUKN00 " '入金集計金額00
		strSQL = strSQL & "        , SSANYUKN01 " '入金集計金額01
		strSQL = strSQL & "        , SSANYUKN02 " '入金集計金額02
		strSQL = strSQL & "        , SSANYUKN03 " '入金集計金額03
		strSQL = strSQL & "        , SSANYUKN04 " '入金集計金額04
		strSQL = strSQL & "        , SSANYUKN05 " '入金集計金額05
		strSQL = strSQL & "        , SSANYUKN06 " '入金集計金額06
		strSQL = strSQL & "        , SSANYUKN07 " '入金集計金額07
		strSQL = strSQL & "        , SSANYUKN08 " '入金集計金額08
		strSQL = strSQL & "        , SSANYUKN09 " '入金集計金額09
		strSQL = strSQL & "        , KSKNYKKN00 " '入金消込集計金額00
		strSQL = strSQL & "        , KSKNYKKN01 " '入金消込集計金額01
		strSQL = strSQL & "        , KSKNYKKN02 " '入金消込集計金額02
		strSQL = strSQL & "        , KSKNYKKN03 " '入金消込集計金額03
		strSQL = strSQL & "        , KSKNYKKN04 " '入金消込集計金額04
		strSQL = strSQL & "        , KSKNYKKN05 " '入金消込集計金額05
		strSQL = strSQL & "        , KSKNYKKN06 " '入金消込集計金額06
		strSQL = strSQL & "        , KSKNYKKN07 " '入金消込集計金額07
		strSQL = strSQL & "        , KSKNYKKN08 " '入金消込集計金額08
		strSQL = strSQL & "        , KSKNYKKN09 " '入金消込集計金額09
		strSQL = strSQL & "        , KSKZANKN00 " '前月入金消込金額00
		strSQL = strSQL & "        , KSKZANKN01 " '前月入金消込金額01
		strSQL = strSQL & "        , KSKZANKN02 " '前月入金消込金額02
		strSQL = strSQL & "        , KSKZANKN03 " '前月入金消込金額03
		strSQL = strSQL & "        , KSKZANKN04 " '前月入金消込金額04
		strSQL = strSQL & "        , KSKZANKN05 " '前月入金消込金額05
		strSQL = strSQL & "        , KSKZANKN06 " '前月入金消込金額06
		strSQL = strSQL & "        , KSKZANKN07 " '前月入金消込金額07
		strSQL = strSQL & "        , KSKZANKN08 " '前月入金消込金額08
		strSQL = strSQL & "        , KSKZANKN09 " '前月入金消込金額09
		strSQL = strSQL & "        , OPEID " '最終作業者コード
		strSQL = strSQL & "        , CLTID " 'クライアントID
		strSQL = strSQL & "        , WRTTM " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , WRTDT " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "        ( '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TOKCD, 10) & "' " '得意先コード
		strSQL = strSQL & "        , '" & CF_Ora_String(pin_Tbl_Inf_UDNTRA.TUKKB, 3) & "' " '通貨区分
		strSQL = strSQL & "        , '" & CF_Ora_String(pv_strSMADT, 8) & "' " '経理締日付
		strSQL = strSQL & "        ,  0 " '入金集計金額00
		strSQL = strSQL & "        ,  0 " '入金集計金額01
		strSQL = strSQL & "        ,  0 " '入金集計金額02
		strSQL = strSQL & "        ,  0 " '入金集計金額03
		strSQL = strSQL & "        ,  0 " '入金集計金額04
		strSQL = strSQL & "        ,  0 " '入金集計金額05
		strSQL = strSQL & "        ,  0 " '入金集計金額06
		strSQL = strSQL & "        ,  0 " '入金集計金額07
		strSQL = strSQL & "        ,  0 " '入金集計金額08
		strSQL = strSQL & "        ,  0 " '入金集計金額09
		strSQL = strSQL & "        ,  0 " '入金消込集計金額00
		strSQL = strSQL & "        ,  0 " '入金消込集計金額01
		strSQL = strSQL & "        ,  0 " '入金消込集計金額02
		strSQL = strSQL & "        ,  0 " '入金消込集計金額03
		strSQL = strSQL & "        ,  0 " '入金消込集計金額04
		strSQL = strSQL & "        ,  0 " '入金消込集計金額05
		strSQL = strSQL & "        ,  0 " '入金消込集計金額06
		strSQL = strSQL & "        ,  0 " '入金消込集計金額07
		strSQL = strSQL & "        ,  0 " '入金消込集計金額08
		strSQL = strSQL & "        ,  0 " '入金消込集計金額09
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(0)) '前月入金消込金額00
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(1)) '前月入金消込金額01
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(2)) '前月入金消込金額02
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(3)) '前月入金消込金額03
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(4)) '前月入金消込金額04
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(5)) '前月入金消込金額05
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(6)) '前月入金消込金額06
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(7)) '前月入金消込金額07
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(8)) '前月入金消込金額08
		strSQL = strSQL & "        ,  " & CStr(pin_curKSKZANKN(9)) '前月入金消込金額09
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "        , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysTime, 6) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		strSQL = strSQL & "        , '" & CF_Ora_String(GV_SysDate, 8) & "' " 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		strSQL = strSQL & "        ) "
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_NKSSMC2_Insert_err
		End If
		
		F_NKSSMC2_Insert = 0
		
F_NKSSMC2_Insert_end: 
		Exit Function
		
F_NKSSMC2_Insert_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_NKSSMC2_Insert")
		GoTo F_NKSSMC2_Insert_end
		
	End Function
	'2009/09/30 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_UODKN_JDNNO
	'   概要：  受注見出・受注トランの排他情報取得
	'   引数：  pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_JDN_HAITA(ByRef pm_All As Cls_All) As Short
		
		Dim Tbl_Inf_UDNTHA As TYPE_DB_UDNTHA
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		On Error GoTo F_Get_JDN_HAITA_err
		
		F_Get_JDN_HAITA = 9
		
		'初期化
		ReDim gc_JDNTHA_HAITA_Inf(0)
		ReDim gc_JDNTRA_HAITA_Inf(0)
		
		'変更前情報取得
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			
			'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
			
			'受注番号
			strJdnNo = Mid(Tbl_Inf_UDNTRA.OKRJONO, 1, 6)
			strJDNLINNO = Mid(Tbl_Inf_UDNTRA.OKRJONO, 7, 3)
			
			If Trim(strJdnNo) <> "" Then
				'排他情報取得
				Call F_Get_JDN_HAITA_Inf(strJdnNo)
			End If
			
		Next intCnt
		
		'変更後情報
		For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			'受注番号
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			If Trim(strJdnNo) <> "" Then
				'排他情報取得
				Call F_Get_JDN_HAITA_Inf(strJdnNo)
			End If
			
		Next intCnt
		
		F_Get_JDN_HAITA = 0
		
F_Get_JDN_HAITA_end: 
		
		Exit Function
		
F_Get_JDN_HAITA_err: 
		GoTo F_Get_JDN_HAITA_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_Get_UODKN
	'   概要：  受注データの排他情報取得
	'   引数：
	'   戻値：
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_JDN_HAITA_Inf(ByVal pin_strJDNNO As String) As Boolean
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strDATNO As String
		Dim strLINNO As String
		Dim intJDNTHAIndex As Short
		Dim intJDNTRAIndex As Short
		Dim I As Short
		
		On Error GoTo F_Get_JDN_HAITA_Inf_err
		
		F_Get_JDN_HAITA_Inf = False
		
		'最新の受注データの取得
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTHA "
		strSQL = strSQL & "      , (SELECT MAX(DATNO) AS MAX_DATNO "
		strSQL = strSQL & "           FROM JDNTHA "
		strSQL = strSQL & "          WHERE JDNNO = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "            AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "            AND MAEUKKB  = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "        ) SUB "
		strSQL = strSQL & "  WHERE JDNNO        = '" & CF_Ora_String(pin_strJDNNO, 10) & "' "
		strSQL = strSQL & "    AND DATKB        = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND AKAKROKB     = '" & CF_Ora_String(gc_strAKAKROKB_KURO, 1) & "' "
		strSQL = strSQL & "    AND TOKSEICD     = '" & URKET52_HEAD_Inf.TOKCD & "' "
		strSQL = strSQL & "    AND MAEUKKB      = '" & CF_Ora_String(pc_strMAEUKKB, 1) & "' "
		strSQL = strSQL & "    AND JDNTHA.DATNO = SUB.MAX_DATNO "

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        'change end 20190826 kuwa

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            GoTo F_Get_JDN_HAITA_Inf_end
        End If

        '伝票管理NOの取得
        'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'change start 20190826 kuwa
        'strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        strDATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
        'change end 20190826 kuwa

        intJDNTHAIndex = 0
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			If Trim(gc_JDNTHA_HAITA_Inf(I).DATNO) = Trim(strDATNO) Then
				intJDNTHAIndex = I
				Exit For
			End If
		Next I
		If intJDNTHAIndex = 0 Then
			intJDNTHAIndex = UBound(gc_JDNTHA_HAITA_Inf) + 1
			ReDim Preserve gc_JDNTHA_HAITA_Inf(intJDNTHAIndex)

            With gc_JDNTHA_HAITA_Inf(intJDNTHAIndex)
                'change start 20190826 kuwa
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.FOPEID = CF_Ora_GetDyn(Usr_Ody, "FOPEID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.FCLTID = CF_Ora_GetDyn(Usr_Ody, "FCLTID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
                ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")

                .DATNO = DB_NullReplace(dt.Rows(0)("DATNO"), "")
                .JDNNO = DB_NullReplace(dt.Rows(0)("JDNNO"), "")
                .FOPEID = DB_NullReplace(dt.Rows(0)("FOPEID"), "")
                .FCLTID = DB_NullReplace(dt.Rows(0)("FCLTID"), "")
                .WRTFSTTM = DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "")
                .WRTFSTDT = DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "")
                .OPEID = DB_NullReplace(dt.Rows(0)("OPEID"), "")
                .CLTID = DB_NullReplace(dt.Rows(0)("CLTID"), "")
                .WRTTM = DB_NullReplace(dt.Rows(0)("WRTTM"), "")
                .WRTDT = DB_NullReplace(dt.Rows(0)("WRTDT"), "")
                .UOPEID = DB_NullReplace(dt.Rows(0)("UOPEID"), "")
                .UCLTID = DB_NullReplace(dt.Rows(0)("UCLTID"), "")
                .UWRTTM = DB_NullReplace(dt.Rows(0)("UWRTTM"), "")
                .UWRTDT = DB_NullReplace(dt.Rows(0)("UWRTDT"), "")
                'change end 20190826 kuwa
            End With
        End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		'最新の受注データの取得
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM JDNTRA "
		strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(strDATNO, 10) & "' " '伝票管理NO.

        'DBアクセス
        'change start 20190826 kuwa
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        dt = DB_GetTable(strSQL)

        'change start 20190826 kuwa
        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            'change end 20190826 kuwa
            GoTo F_Get_JDN_HAITA_Inf_end
        End If

        '取得データ退避
        'change start 20190826 kuwa
        'Do Until CF_Ora_EOF(Usr_Ody)

        '    '伝票管理NOの取得
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strDATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    strLINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")

        '    intJDNTRAIndex = 0
        '    For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
        '        If Trim(gc_JDNTRA_HAITA_Inf(I).DATNO) = Trim(strDATNO) And Trim(gc_JDNTRA_HAITA_Inf(I).LINNO) = Trim(strLINNO) Then
        '            intJDNTRAIndex = I
        '            Exit For
        '        End If
        '    Next I
        '    If intJDNTRAIndex = 0 Then
        '        intJDNTRAIndex = UBound(gc_JDNTRA_HAITA_Inf) + 1
        '        ReDim Preserve gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)

        '        With gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .DATNO = CF_Ora_GetDyn(Usr_Ody, "DATNO", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .JDNNO = CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .LINNO = CF_Ora_GetDyn(Usr_Ody, "LINNO", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .FOPEID = CF_Ora_GetDyn(Usr_Ody, "FOPEID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .FCLTID = CF_Ora_GetDyn(Usr_Ody, "FCLTID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .WRTFSTTM = CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .WRTFSTDT = CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")
        '            'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            .UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")
        '        End With
        '    End If

        '    Call CF_Ora_MoveNext(Usr_Ody)
        'Loop

        For Each row As DataRow In dt.Rows
            '伝票管理NOの取得
            strDATNO = DB_NullReplace(row("DATNO"), "")
            strLINNO = DB_NullReplace(row("LINNO"), "")

            intJDNTRAIndex = 0
            For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
                If Trim(gc_JDNTRA_HAITA_Inf(I).DATNO) = Trim(strDATNO) And Trim(gc_JDNTRA_HAITA_Inf(I).LINNO) = Trim(strLINNO) Then
                    intJDNTRAIndex = I
                    Exit For
                End If
            Next I
            If intJDNTRAIndex = 0 Then
                intJDNTRAIndex = UBound(gc_JDNTRA_HAITA_Inf) + 1
                ReDim Preserve gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)

                With gc_JDNTRA_HAITA_Inf(intJDNTRAIndex)
                    .DATNO = DB_NullReplace(row("DATNO"), "")
                    .JDNNO = DB_NullReplace(row("JDNNO"), "")
                    .LINNO = DB_NullReplace(row("LINNO"), "")
                    .FOPEID = DB_NullReplace(row("FOPEID"), "")
                    .FCLTID = DB_NullReplace(row("FCLTID"), "")
                    .WRTFSTTM = DB_NullReplace(row("WRTFSTTM"), "")
                    .WRTFSTDT = DB_NullReplace(row("WRTFSTDT"), "")
                    .OPEID = DB_NullReplace(row("OPEID"), "")
                    .CLTID = DB_NullReplace(row("CLTID"), "")
                    .WRTTM = DB_NullReplace(row("WRTTM"), "")
                    .WRTDT = DB_NullReplace(row("WRTDT"), "")
                    .UOPEID = DB_NullReplace(row("UOPEID"), "")
                    .UCLTID = DB_NullReplace(row("UCLTID"), "")
                    .UWRTTM = DB_NullReplace(row("UWRTTM"), "")
                    .UWRTDT = DB_NullReplace(row("UWRTDT"), "")
                End With
            End If

            Call CF_Ora_MoveNext(Usr_Ody)
        Next
        'change end 20190826 kuwa


        F_Get_JDN_HAITA_Inf = True
		
F_Get_JDN_HAITA_Inf_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_Get_JDN_HAITA_Inf_err: 
		GoTo F_Get_JDN_HAITA_Inf_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_JDNTHA_Exicz
	'   概要：  受注見出し排他制御
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_JDNTHA_Exicz() As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim I As Short
		
		On Error GoTo F_JDNTHA_Exicz_err
		
		F_JDNTHA_Exicz = 9
		
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			
			With gc_JDNTHA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM JDNTHA "
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '伝票管理NO.
				strSQL = strSQL & " FOR UPDATE "

                ' DBアクセス
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    'change end 20190826 kuwa
                    ' データなしの場合
                    F_JDNTHA_Exicz = 1
                    GoTo F_JDNTHA_Exicz_end
                End If

                ' 更新前データと異なるデータが存在した場合はエラーとする。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190826 kuwa
                'If .FOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or .FCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or .WRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or .WRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or .OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or .CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or .WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or .WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or .UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or .UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or .UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or .UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If .FOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or .FCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or .WRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or .WRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or .OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or .CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or .WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or .WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or .UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or .UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or .UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or .UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    'change end 20190826 kuwa
                    GoTo F_JDNTHA_Exicz_end
                End If
            End With
			
		Next I
		
		F_JDNTHA_Exicz = 0
		
F_JDNTHA_Exicz_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_JDNTHA_Exicz_err: 
		GoTo F_JDNTHA_Exicz_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_JDNTRA_Exicz
	'   概要：  受注トラン排他制御
	'   引数：
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_JDNTRA_Exicz() As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim I As Short
		
		On Error GoTo F_JDNTRA_Exicz_err
		
		F_JDNTRA_Exicz = 9
		
		For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
			
			With gc_JDNTRA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " SELECT * "
				strSQL = strSQL & " FROM JDNTRA "
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '伝票管理NO.
				strSQL = strSQL & " AND   LINNO    = '" & CF_Ora_String(.LINNO, 3) & "' " '行番号.
				strSQL = strSQL & " FOR UPDATE "

                ' DBアクセス
                'change start 20190826 kuwa
                'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                Dim dt As DataTable = DB_GetTable(strSQL)
                'change end 20190826 kuwa

                'change start 20190826 kuwa
                'If CF_Ora_EOF(Usr_Ody) = True Then
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    'change end 20190826 kuwa
                    ' データなしの場合
                    F_JDNTRA_Exicz = 1
                    GoTo F_JDNTRA_Exicz_end
                End If

                ' 更新前データと異なるデータが存在した場合はエラーとする。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UWRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, UOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, CLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, OPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTDT, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, WRTFSTTM, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FCLTID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, FOPEID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'change start 20190826 kuwa
                'If .FOPEID <> CF_Ora_GetDyn(Usr_Ody, "FOPEID", "") Or .FCLTID <> CF_Ora_GetDyn(Usr_Ody, "FCLTID", "") Or .WRTFSTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTTM", "") Or .WRTFSTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTFSTDT", "") Or .OPEID <> CF_Ora_GetDyn(Usr_Ody, "OPEID", "") Or .CLTID <> CF_Ora_GetDyn(Usr_Ody, "CLTID", "") Or .WRTTM <> CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") Or .WRTDT <> CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") Or .UOPEID <> CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") Or .UCLTID <> CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") Or .UWRTTM <> CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") Or .UWRTDT <> CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") Then
                If .FOPEID <> DB_NullReplace(dt.Rows(0)("FOPEID"), "") Or .FCLTID <> DB_NullReplace(dt.Rows(0)("FCLTID"), "") Or .WRTFSTTM <> DB_NullReplace(dt.Rows(0)("WRTFSTTM"), "") Or .WRTFSTDT <> DB_NullReplace(dt.Rows(0)("WRTFSTDT"), "") Or .OPEID <> DB_NullReplace(dt.Rows(0)("OPEID"), "") Or .CLTID <> DB_NullReplace(dt.Rows(0)("CLTID"), "") Or .WRTTM <> DB_NullReplace(dt.Rows(0)("WRTTM"), "") Or .WRTDT <> DB_NullReplace(dt.Rows(0)("WRTDT"), "") Or .UOPEID <> DB_NullReplace(dt.Rows(0)("UOPEID"), "") Or .UCLTID <> DB_NullReplace(dt.Rows(0)("UCLTID"), "") Or .UWRTTM <> DB_NullReplace(dt.Rows(0)("UWRTTM"), "") Or .UWRTDT <> DB_NullReplace(dt.Rows(0)("UWRTDT"), "") Then
                    'change end 20190826 kuwa
                    GoTo F_JDNTRA_Exicz_end
                End If
            End With
			
		Next I
		
		F_JDNTRA_Exicz = 0
		
F_JDNTRA_Exicz_end: 
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
F_JDNTRA_Exicz_err: 
		GoTo F_JDNTRA_Exicz_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_JDNTHA_Upd_TimeStamp
	'   概要：  受注見出しトラン処理
	'   引数：  pm_All             : 画面情報
	'           pin_strDATNO       : 伝票管理番号
	'           pin_blnUpdDLFLG    : True = DLFLG も更新
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTHA_Upd_TimeStamp(ByRef pm_All As Cls_All) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim I As Short
		
		On Error GoTo F_JDNTHA_Upd_TimeStamp_err
		
		'UPGRADE_WARNING: オブジェクト F_JDNTHA_Upd_TimeStamp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_JDNTHA_Upd_TimeStamp = 9
		
		For I = 1 To UBound(gc_JDNTHA_HAITA_Inf)
			
			With gc_JDNTHA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " UPDATE JDNTHA "
				strSQL = strSQL & "    SET UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID（バッチ）
				strSQL = strSQL & "      , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID（バッチ）
				strSQL = strSQL & "      , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（バッチ時間）
				strSQL = strSQL & "      , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（バッチ日付）
				strSQL = strSQL & "      , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '伝票管理NO.
				
				'SQL実行
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_JDNTHA_Upd_TimeStamp_err
				End If
			End With
		Next I
		
		'UPGRADE_WARNING: オブジェクト F_JDNTHA_Upd_TimeStamp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_JDNTHA_Upd_TimeStamp = 0
		
F_JDNTHA_Upd_TimeStamp_end: 
		Exit Function
		
F_JDNTHA_Upd_TimeStamp_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_JDNTHA_Upd_TimeStamp")
		GoTo F_JDNTHA_Upd_TimeStamp_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_JDNTRA_Upd_TimeStamp
	'   概要：  受注見出しトラン処理
	'   引数：  pm_All             : 画面情報
	'           pin_strDATNO       : 伝票管理番号
	'           pin_blnUpdDLFLG    : True = DLFLG も更新
	'   戻値：  0:正常   1:データ無し  9:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_JDNTRA_Upd_TimeStamp(ByRef pm_All As Cls_All) As Object
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim I As Short
		
		On Error GoTo F_JDNTRA_Upd_TimeStamp_err
		
		'UPGRADE_WARNING: オブジェクト F_JDNTRA_Upd_TimeStamp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_JDNTRA_Upd_TimeStamp = 9
		
		For I = 1 To UBound(gc_JDNTRA_HAITA_Inf)
			
			With gc_JDNTRA_HAITA_Inf(I)
				'SQL
				strSQL = ""
				strSQL = strSQL & " UPDATE JDNTRA "
				strSQL = strSQL & "    SET UOPEID  = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " 'ユーザID（バッチ）
				strSQL = strSQL & "      , UCLTID  = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントID（バッチ）
				strSQL = strSQL & "      , UWRTTM  = '" & CF_Ora_String(GV_SysTime, 6) & "' " 'タイムスタンプ（バッチ時間）
				strSQL = strSQL & "      , UWRTDT  = '" & CF_Ora_String(GV_SysDate, 8) & "' " 'タイムスタンプ（バッチ日付）
				strSQL = strSQL & "      , PGID    = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '更新PGID
				strSQL = strSQL & " WHERE DATNO    = '" & CF_Ora_String(.DATNO, 10) & "' " '伝票管理NO.
				strSQL = strSQL & " AND   LINNO    = '" & CF_Ora_String(.LINNO, 3) & "' " '行番号.
				
				'SQL実行
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo F_JDNTRA_Upd_TimeStamp_err
				End If
			End With
		Next I
		
		'UPGRADE_WARNING: オブジェクト F_JDNTRA_Upd_TimeStamp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		F_JDNTRA_Upd_TimeStamp = 0
		
F_JDNTRA_Upd_TimeStamp_end: 
		Exit Function
		
F_JDNTRA_Upd_TimeStamp_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgURKET52_E_004, pm_All, "F_JDNTRA_Upd_TimeStamp")
		GoTo F_JDNTRA_Upd_TimeStamp_end
		
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'2009/10/05 ADD START RISE)MIYAJIMA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_EXIST_MotoJDNNO
	'   概要：  明細：受注番号の存在チェック(変更前のデータが対象)
	'   引数：　pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_EXIST_MotoJDNNO(ByRef pm_All As Cls_All) As Short
		Dim Retn_Code As Short
		
		Dim intCnt As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		Dim Tbl_Inf_UDNTRA As TYPE_DB_UDNTRA
		
		Retn_Code = CHK_OK
		
		'変更前情報取得
		For intCnt = 1 To UBound(URKET52_HEAD_Inf.UDNTRA)
			
			'UPGRADE_WARNING: オブジェクト Tbl_Inf_UDNTRA の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Tbl_Inf_UDNTRA = URKET52_HEAD_Inf.UDNTRA(intCnt)
			
			'受注番号
			strJdnNo = Mid(Tbl_Inf_UDNTRA.OKRJONO, 1, 6)
			strJDNLINNO = Mid(Tbl_Inf_UDNTRA.OKRJONO, 7, 3)
			
			If Trim(strJdnNo) <> "" Then
				If F_Util_CheckJDNNO(strJdnNo, strJDNLINNO) <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					GoTo F_Chk_EXIST_MotoJDNNO_End
				End If
			End If
			
		Next intCnt
		
F_Chk_EXIST_MotoJDNNO_End: 
		
		F_Chk_EXIST_MotoJDNNO = Retn_Code
	End Function
	'2009/10/05 ADD E.N.D RISE)MIYAJIMA
	
	'''' ADD 2009/11/10  FKS) T.Yamamoto    Start    連絡票№757
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_NYUDT_JDNDT
	'   概要：  受注伝票日付の年月＞画面.入金日の年月チェック
	'   引数：　pm_All                :画面情報
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_NYUDT_JDNDT(ByRef pm_All As Cls_All) As Short
		
		Dim Retn_Code As Short
		Dim Err_Cd As String
		Dim Msg_Flg As Boolean
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strJdnNo As String
		Dim strJDNLINNO As String
		
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		
		strJdnNo = ""
		strJDNLINNO = ""
		
		For intCnt = 1 To pv_intMeisaiCnt
			
			'受注番号
			strJdnNo = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNNO
			strJDNLINNO = pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.JDNLINNO
			
			If strJdnNo <> "" Or strJDNLINNO <> "" Then
				intRet = F_Util_CheckJDNNO(strJdnNo, strJDNLINNO, URKET52_HEAD_Inf.NYUDT)
				If intRet <> 0 Then
					Retn_Code = CHK_ERR_ELSE
					Select Case intRet
						Case 1
							Err_Cd = gc_strMsgURKET52_E_011 '該当データなし
						Case 2
							Err_Cd = gc_strMsgURKET52_E_039 '受注伝票日付の年月＞画面.入金日の年月
					End Select
					Msg_Flg = True
					GoTo F_Chk_NYUDT_JDNDT_End
				End If
			End If
			
		Next intCnt
		
F_Chk_NYUDT_JDNDT_End: 
		
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Chk_NYUDT_JDNDT = Retn_Code
		
	End Function
    '''' ADD 2009/11/10  FKS) T.Yamamoto    End

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

    '2019/05/23 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_IN_TANCD
    '   概要：  入力担当者編集
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD_URKET52(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '入力担当者コード
            'UPGRADE_ISSUE: Control HD_IN_TANCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '入力担当者名
            'UPGRADE_ISSUE: Control HD_IN_TANNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '2019/05/23 ADD END

End Module